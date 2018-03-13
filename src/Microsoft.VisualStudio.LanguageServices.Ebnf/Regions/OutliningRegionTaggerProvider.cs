// -----------------------------------------------------------------------
// <copyright file="OutliningRegionTaggerProvider.cs" company="Ollon, LLC">
//     Copyright (c) 2017 Ollon, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace Ollon.VisualStudio.Languages.Regions
{
    [Export(typeof(ITaggerProvider))]
    [TagType(typeof(OutliningRegionTag))]
    [ContentType("Ebnf")]
    public class OutliningRegionTaggerProvider : ITaggerProvider
    {
        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
        {
            return (ITagger<T>)new OutliningRegionTagger(buffer);
        }

        [OutliningRegionBounds("(*", "*)")]
        public class OutliningRegionTagger : ITagger<OutliningRegionTag>
        {
            private const string startHide = "(*";     //the characters that start the outlining region
            private const string endHide = "*)";       //the characters that end the outlining region
            private readonly ITextBuffer buffer;
            private ITextSnapshot snapshot;
            private List<Region> regions;
            public OutliningRegionTagger(ITextBuffer buffer)
            {
                this.buffer = buffer;
                snapshot = buffer.CurrentSnapshot;
                regions = new List<Region>();
                Process();
                this.buffer.Changed += OnBufferOnChanged;
            }

            private void OnBufferOnChanged(object sender, TextContentChangedEventArgs e)
            {
                if (e.After != buffer.CurrentSnapshot)
                    return;
                Process();
            }

            public IEnumerable<ITagSpan<OutliningRegionTag>> GetTags(NormalizedSnapshotSpanCollection spans)
            {
                if (spans.Count == 0)
                    yield break;
                List<Region> currentRegions = regions;
                ITextSnapshot currentSnapshot = snapshot;
                SnapshotSpan entire = new SnapshotSpan(spans[0].Start, spans[spans.Count - 1].End).TranslateTo(currentSnapshot, SpanTrackingMode.EdgeExclusive);
                int startLineNumber = entire.Start.GetContainingLine().LineNumber;
                int endLineNumber = entire.End.GetContainingLine().LineNumber;
                foreach (var region in currentRegions)
                {
                    if (region.StartLine <= endLineNumber &&
                        region.EndLine >= startLineNumber)
                    {
                        var startLine = currentSnapshot.GetLineFromLineNumber(region.StartLine);
                        var endLine = currentSnapshot.GetLineFromLineNumber(region.EndLine);

                        //the region starts at the beginning of the "[", and goes until the *end* of the line that contains the "]".
                        SnapshotPoint snapshotPoint = startLine.Start + region.StartOffset;
                        int snapshotPosition = snapshotPoint.Position;
                        Span outliningSpan = Span.FromBounds(snapshotPosition, endLine.End.Position);
                        string hoverText = snapshot.GetText(outliningSpan);

                        yield return RegionTagSpan.From(currentSnapshot, region);
                    }
                }
            }

            private static bool TryGetLevel(string text, int startIndex, out int level)
            {
                level = -1;
                if (text.Length > startIndex + 3)
                {
                    if (int.TryParse(text.Substring(startIndex + 1), out level))
                        return true;
                }
                return false;
            }

            private static SnapshotSpan AsSnapshotSpan(Region region, ITextSnapshot snapshot)
            {
                var startLine = snapshot.GetLineFromLineNumber(region.StartLine);
                var endLine = (region.StartLine == region.EndLine) ? startLine
                    : snapshot.GetLineFromLineNumber(region.EndLine);
                return new SnapshotSpan(startLine.Start + region.StartOffset, endLine.End);
            }

            private void Process()
            {
                ITextSnapshot newSnapshot = buffer.CurrentSnapshot;
                List<Region> newRegions = new List<Region>();

                PartialRegion currentRegion = null;

                foreach (ITextSnapshotLine line in newSnapshot.Lines)
                {
                    string text = line.GetTextIncludingLineBreak();

                    int regionStart = -1;

                    foreach (var entry in GetOutliningRegionBounds())
                    {
                        int check = -1;

                        string start = entry.Key;
                        string end = entry.Value;

                        if ((check = text.IndexOf(start, StringComparison.Ordinal)) != -1)
                        {
                            int currentLevel = currentRegion?.Level ?? 1;
                            if (!TryGetLevel(text, check, out int newLevel))
                                newLevel = currentLevel + 1;
                            if (currentLevel == newLevel && currentRegion != null)
                            {
                                newRegions.Add(new Region
                                {
                                    Snapshot = newSnapshot,
                                    Level = currentRegion.Level,
                                    StartLine = currentRegion.StartLine,
                                    StartOffset = currentRegion.StartOffset,
                                    EndLine = line.LineNumber
                                });

                                currentRegion = new PartialRegion
                                {
                                    Snapshot = newSnapshot,
                                    Level = newLevel,
                                    StartLine = line.LineNumber,
                                    StartOffset = regionStart,
                                    PartialParent = currentRegion.PartialParent
                                };
                            }
                            //this is a new (sub)region
                            else
                            {
                                currentRegion = new PartialRegion
                                {
                                    Snapshot = newSnapshot,
                                    Level = newLevel,
                                    StartLine = line.LineNumber,
                                    StartOffset = regionStart,
                                    PartialParent = currentRegion
                                };
                            }
                        }
                        else if ((check = text.IndexOf(end, StringComparison.Ordinal)) != -1)
                        {
                            int currentLevel = currentRegion?.Level ?? 1;
                            if (!TryGetLevel(text, check, out int closingLevel))
                                closingLevel = currentLevel;

                            //the regions match
                            if (currentRegion != null &&
                                currentLevel == closingLevel)
                            {
                                newRegions.Add(new Region()
                                {
                                    Snapshot = newSnapshot,
                                    Level = currentLevel,
                                    StartLine = currentRegion.StartLine,
                                    StartOffset = currentRegion.StartOffset,
                                    EndLine = line.LineNumber
                                });

                                currentRegion = currentRegion.PartialParent;
                            }
                        }
                    }
                }

                //determine the changed span, and send a changed event with the new spans
                List<Span> oldSpans =
                    new List<Span>(regions.Select(r => AsSnapshotSpan(r, snapshot)
                        .TranslateTo(newSnapshot, SpanTrackingMode.EdgeExclusive)
                        .Span));
                List<Span> newSpans =
                        new List<Span>(newRegions.Select(r => AsSnapshotSpan(r, newSnapshot).Span));
                NormalizedSpanCollection oldSpanCollection = new NormalizedSpanCollection(oldSpans);
                NormalizedSpanCollection newSpanCollection = new NormalizedSpanCollection(newSpans);
                //the changed regions are regions that appear in one set or the other, but not both.
                NormalizedSpanCollection removed =
                NormalizedSpanCollection.Difference(oldSpanCollection, newSpanCollection);
                int changeStart = int.MaxValue;
                int changeEnd = -1;
                if (removed.Count > 0)
                {
                    changeStart = removed[0].Start;
                    changeEnd = removed[removed.Count - 1].End;
                }
                if (newSpans.Count > 0)
                {
                    changeStart = Math.Min(changeStart, newSpans[0].Start);
                    changeEnd = Math.Max(changeEnd, newSpans[newSpans.Count - 1].End);
                }
                snapshot = newSnapshot;
                regions = newRegions;
                if (changeStart <= changeEnd)
                {
                    ITextSnapshot snap = snapshot;
                    if (TagsChanged != null)
                        TagsChanged(this, new SnapshotSpanEventArgs(
                            new SnapshotSpan(snapshot, Span.FromBounds(changeStart, changeEnd))));
                }
            }

            private static Dictionary<string, string> GetOutliningRegionBounds()
            {
                var attributes = typeof(OutliningRegionTagger).GetCustomAttributes(typeof(OutliningRegionBoundsAttribute), false);

                OutliningRegionBoundsAttribute[] array = Cast<OutliningRegionBoundsAttribute>(attributes);

                return array.ToDictionary(r => r.Start, r => r.End);
            }

            private static T[] Cast<T>(object[] o) => o.Select(x => (T)x).ToArray();

            public event EventHandler<SnapshotSpanEventArgs> TagsChanged;
        }
    }
}
