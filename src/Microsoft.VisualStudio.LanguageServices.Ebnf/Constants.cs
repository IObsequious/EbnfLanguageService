using System;
using System.Collections.Generic;
using System.Linq;

namespace Ollon.VisualStudio.Languages
{
    public static class Constants
    {
        public const string LanguageName = "Extended Backus-Naur Form";
    }

    public static class SyntaxKindNames
    {
        public const string DefiningToken = nameof(DefiningToken);
        public const string TerminatorToken = nameof(TerminatorToken);
        public const string SeparatorToken = nameof(SeparatorToken);
        public const string PlusToken = nameof(PlusToken);
        public const string MinusToken = nameof(MinusToken);
        public const string StarToken = nameof(StarToken);
        public const string SlashToken = nameof(SlashToken);
        public const string CharacterRangeToken = nameof(CharacterRangeToken);
        public const string OpenParenToken = nameof(OpenParenToken);
        public const string OpenBracketToken = nameof(OpenBracketToken);
        public const string OpenBraceToken = nameof(OpenBraceToken);
        public const string CloseParenToken = nameof(CloseParenToken);
        public const string CloseBracketToken = nameof(CloseBracketToken);
        public const string CloseBraceToken = nameof(CloseBraceToken);
        public const string WhitespaceToken = nameof(WhitespaceToken);
        public const string EndOfLineToken = nameof(EndOfLineToken);
        public const string CommentToken = nameof(CommentToken);
        public const string UnterminatedCommentToken = nameof(UnterminatedCommentToken);
        public const string IdentifierToken = nameof(IdentifierToken);
        public const string StringLiteralToken = nameof(StringLiteralToken);
        public const string UnterminatedStringLiteralToken = nameof(UnterminatedStringLiteralToken);
        public const string NumericLiteralToken = nameof(NumericLiteralToken);
        public const string CharacterLiteralToken = nameof(CharacterLiteralToken);
        public const string NullLiteralToken = nameof(NullLiteralToken);
        public const string SpecialSequenceToken = nameof(SpecialSequenceToken);
        public const string UnterminatedSpecialSequenceToken = nameof(UnterminatedSpecialSequenceToken);
    }
}
