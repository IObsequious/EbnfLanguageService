using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;

namespace Ollon.VisualStudio.Languages.Regions
{
    public class RegionTagSpan : TagSpan<OutliningRegionTag>
    {
        public ITextSnapshot TextSnapshot { get; }
        public Region Region { get; }

        public ITextSnapshotLine StartLine { get; }

        public ITextSnapshotLine EndLine { get; }

        //public LinePositionSpan LineSpan => Convert(Region);

        public Span TextSpan => Microsoft.VisualStudio.Text.Span.FromBounds(StartLine.Start + Region.StartOffset, EndLine.End.Position);

        public string HoverText => TextSnapshot.GetText(TextSpan);

        public static RegionTagSpan From(ITextSnapshot snapshot, Region region)
        {
            GetSnapshotLines(snapshot, region, out ITextSnapshotLine startLine, out ITextSnapshotLine endLine);

            SnapshotSpan snapspan = new SnapshotSpan(startLine.Start + region.StartOffset, endLine.End);

            Span outLiningSpan = Microsoft.VisualStudio.Text.Span.FromBounds(startLine.Start + region.StartOffset, endLine.End.Position);

            string hoverText = snapshot.GetText(outLiningSpan);

            OutliningRegionTag outliningRegionTag = new OutliningRegionTag(true, false, "...", hoverText);

            return new RegionTagSpan(snapshot, region, startLine, endLine, snapspan, outliningRegionTag);
        }

        public RegionTagSpan(ITextSnapshot snapshot, Region region, ITextSnapshotLine startLine, ITextSnapshotLine endLine, SnapshotSpan snapspan, OutliningRegionTag outliningRegion)
            : base(snapspan, outliningRegion)
        {
            Region = region;
            StartLine = startLine;
            EndLine = endLine;
        }

        private static void GetSnapshotLines(ITextSnapshot snapshot, Region region, out ITextSnapshotLine startLine, out ITextSnapshotLine endLine)
        {
            startLine = snapshot.GetLineFromLineNumber(region.StartLine);
            endLine = snapshot.GetLineFromLineNumber(region.EndLine);
        }

        //private static LinePositionSpan Convert(Region region)
        //{
        //    LinePosition start = new LinePosition(region.StartLine, region.StartOffset);
        //    LinePosition end = new LinePosition(region.EndLine, 0);
        //    return new LinePositionSpan(start, end);
        //}
    }
}
