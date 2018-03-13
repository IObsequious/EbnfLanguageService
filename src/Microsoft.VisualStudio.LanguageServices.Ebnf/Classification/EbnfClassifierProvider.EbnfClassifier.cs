using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Ollon.VisualStudio.Languages.Text;

namespace Ollon.VisualStudio.Languages.Classification
{
    public partial class EbnfClassifierProvider
    {
        private class EbnfClassifier : IClassifier
        {
            private readonly EbnfClassifierProvider _provider;
            private readonly ITextBuffer _textBuffer;
            private readonly EbnfDocument _document;

            public EbnfClassifier(EbnfClassifierProvider provider, ITextBuffer textBuffer)
            {
                _provider = provider;
                _textBuffer = textBuffer;
                _document = EbnfDocument.From(_textBuffer);
            }

            public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

            public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
            {
                List<ClassificationSpan> spans = new List<ClassificationSpan>();

                foreach (var token in _document.Tokens)
                {
                    spans.Add(token.ClassificationSpan);
                }

                return spans;
            }
        }
    }
}
