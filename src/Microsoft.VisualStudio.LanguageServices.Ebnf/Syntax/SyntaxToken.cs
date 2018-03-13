using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Ollon.VisualStudio.Languages.Classification;

namespace Ollon.VisualStudio.Languages.Syntax
{
    public class SyntaxToken
    {
        public SyntaxToken(ITextSnapshot snapshot, SyntaxKind kind, int start, int length)
        {
            Snapshot = snapshot;
            Start = new SnapshotPoint(snapshot, start);
            End = new SnapshotPoint(snapshot, start + length);
            Length = length;
            Kind = kind;
        }

        public SyntaxKind Kind { get; }

        public IClassificationType ClassificationType
        {
            get
            {
                return ClassificationFacts.GetClassificationType(Kind);
            }
        }

        public ClassificationSpan ClassificationSpan
        {
            get
            {
                return new ClassificationSpan(SnapshotSpan, ClassificationType);
            }
        }

        public SnapshotPoint Start { get; }

        public SnapshotPoint End { get; }

        public int Length { get; }

        public ITextSnapshot Snapshot { get; }

        public Span TextSpan
        {
            get
            {
                return Span.FromBounds(Start, End);
            }
        }

        public SnapshotSpan SnapshotSpan
        {
            get
            {
                return new SnapshotSpan(Snapshot, TextSpan);
            }
        }

        public string Text
        {
            get
            {
                return Snapshot.GetText(SnapshotSpan);
            }
        }
    }
}
