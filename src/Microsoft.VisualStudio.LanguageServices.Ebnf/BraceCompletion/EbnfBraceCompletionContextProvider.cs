using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.BraceCompletion;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;

namespace Ollon.VisualStudio.Languages.BraceCompletion
{
    [BracePair('(', ')')]
    [BracePair('[', ']')]
    [BracePair('{', '}')]
    [ContentType("Ebnf")]
    [Export(typeof(IBraceCompletionContextProvider))]
    public class EbnfBraceCompletionContextProvider : IBraceCompletionContextProvider
    {
        [Import]
        internal IClassifierAggregatorService ClassifierService { get; private set; }

        public bool TryCreateContext(ITextView textView, SnapshotPoint openingPoint, char openingBrace, char closingBrace, out IBraceCompletionContext context)
        {
            if (IsValid(openingPoint))
            {
                context = new EbnfBraceCompletionContext();
                return true;
            }

            context = null;
            return false;
        }

        private bool IsValid(SnapshotPoint point)
        {
            if (point > 0)
            {
                IList<ClassificationSpan> spans = ClassifierService.GetClassifier(point.Snapshot.TextBuffer)
                                                           .GetClassificationSpans(new SnapshotSpan(point - 1, 1));

                foreach (var span in spans)
                {
                    if (span.ClassificationType.IsOfType(EbnfClassificationTypeNames.EbnfComment))
                    {
                        return false;
                    }
                    if (span.ClassificationType.IsOfType(EbnfClassificationTypeNames.EbnfString))
                    {
                        return false;
                    }
                    if (span.ClassificationType.IsOfType(EbnfClassificationTypeNames.EbnfSpecialSequence))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        [Export(typeof(IBraceCompletionContext))]
        private class EbnfBraceCompletionContext : IBraceCompletionContext
        {
            public bool AllowOverType(IBraceCompletionSession session)
            {
                return true;
            }

            public void Finish(IBraceCompletionSession session)
            {

            }

            public void OnReturn(IBraceCompletionSession session)
            {

            }

            public void Start(IBraceCompletionSession session)
            {

            }
        }
    }
}
