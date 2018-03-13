using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text;

namespace Ollon.VisualStudio.Languages.Syntax
{
    public static class SyntaxFactory
    {
        public static SyntaxToken CharacterRange(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.CharacterRangeToken, startPosition, length);
        }

        public static SyntaxToken EndOfFile(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.EndOfFileToken, startPosition, length);
        }

        public static SyntaxToken Defining(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.DefiningToken, startPosition, length);
        }

        public static SyntaxToken Terminator(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.TerminatorToken, startPosition, length);
        }

        public static SyntaxToken Separator(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.SeparatorToken, startPosition, length);
        }

        public static SyntaxToken Plus(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.PlusToken, startPosition, length);
        }

        public static SyntaxToken Minus(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.MinusToken, startPosition, length);
        }

        public static SyntaxToken Star(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.StarToken, startPosition, length);
        }

        public static SyntaxToken Slash(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.SlashToken, startPosition, length);
        }

        public static SyntaxToken OpenParen(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.OpenParenToken, startPosition, length);
        }

        public static SyntaxToken OpenBracket(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.OpenBracketToken, startPosition, length);
        }

        public static SyntaxToken OpenBrace(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.OpenBraceToken, startPosition, length);
        }

        public static SyntaxToken CloseParen(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.CloseParenToken, startPosition, length);
        }

        public static SyntaxToken CloseBracket(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.CloseBracketToken, startPosition, length);
        }

        public static SyntaxToken CloseBrace(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.CloseBraceToken, startPosition, length);
        }

        public static SyntaxToken Whitespace(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.WhitespaceToken, startPosition, length);
        }

        public static SyntaxToken EndOfLine(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.EndOfLineToken, startPosition, length);
        }

        public static SyntaxToken Comment(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.CommentToken, startPosition, length);
        }

        public static SyntaxToken Identifier(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.IdentifierToken, startPosition, length);
        }

        public static SyntaxToken StringLiteral(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.StringLiteralToken, startPosition, length);
        }

        public static SyntaxToken UnterminatedComment(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.UnterminatedCommentToken, startPosition, length);
        }

        public static SyntaxToken UnterminatedSpecialSequence(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.UnterminatedSpecialSequenceToken, startPosition, length);
        }

        public static SyntaxToken UnterminatedStringLiteral(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.UnterminatedStringLiteralToken, startPosition, length);
        }

        public static SyntaxToken NumericLiteral(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.NumericLiteralToken, startPosition, length);
        }

        public static SyntaxToken CharacterLiteral(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.CharacterLiteralToken, startPosition, length);
        }

        public static SyntaxToken NullLiteral(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.NullLiteralToken, startPosition, length);
        }

        public static SyntaxToken SpecialSequence(ITextSnapshot textSnapshot, int startPosition, int length)
        {
            return new SyntaxToken(textSnapshot, SyntaxKind.SpecialSequenceToken, startPosition, length);
        }
    }
}
