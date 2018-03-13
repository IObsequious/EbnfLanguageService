using System;
using System.Collections.Generic;
using System.Linq;

namespace Ollon.VisualStudio.Languages.Syntax
{
    public enum SyntaxKind
    {
        None,
        EndOfFileToken,

        DefiningToken,
        TerminatorToken,
        SeparatorToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        CharacterRangeToken,

        OpenParenToken,
        OpenBracketToken,
        OpenBraceToken,
        CloseParenToken,
        CloseBracketToken,
        CloseBraceToken,

        WhitespaceToken,
        EndOfLineToken,

        CommentToken,
        UnterminatedCommentToken,

        IdentifierToken,

        StringLiteralToken,
        UnterminatedStringLiteralToken,
        NumericLiteralToken,
        CharacterLiteralToken,
        NullLiteralToken,

        SpecialSequenceToken,
        UnterminatedSpecialSequenceToken,
    }
}
