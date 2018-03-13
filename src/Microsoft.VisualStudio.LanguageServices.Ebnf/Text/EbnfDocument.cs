using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text;
using Ollon.VisualStudio.Languages.Syntax;

namespace Ollon.VisualStudio.Languages.Text
{
    public class EbnfDocument
    {
        public ITextBuffer Buffer { get; }

        public SyntaxList<SyntaxToken> Tokens { get; private set; }

        public static EbnfDocument From(ITextBuffer textBuffer)
        {
            return textBuffer.Properties.GetOrCreateSingletonProperty(() => new EbnfDocument(textBuffer));
        }

        private EbnfDocument(ITextBuffer textBuffer)
        {
            Buffer = textBuffer;
            Parse();
            Buffer.Changed += OnTextBufferChanged;
        }

        private void OnTextBufferChanged(object sender, TextContentChangedEventArgs e)
        {
            Parse();
        }

        private void Parse()
        {
            var builder = SyntaxList.CreateBuilder<SyntaxToken>();
            Lexer lexer = new Lexer(Buffer.CurrentSnapshot, Buffer.CurrentSnapshot.GetText());
            builder.AddRange(lexer.Tokenize());
            Tokens = builder.ToList();
        }

        public SyntaxList<SyntaxToken> GetTokensInSpan(SnapshotSpan span)
        {
            var builder = SyntaxList.CreateBuilder<SyntaxToken>();
            foreach (var token in Tokens)
            {
                if (span.Contains(token.SnapshotSpan))
                {
                    builder.Add(token);
                }
            }
            return builder.ToList();
        }
    }
}
