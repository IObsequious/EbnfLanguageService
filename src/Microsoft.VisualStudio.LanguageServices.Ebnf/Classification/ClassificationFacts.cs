using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text.Classification;
using Ollon.VisualStudio.Languages.Syntax;

namespace Ollon.VisualStudio.Languages.Classification
{
    public static class ClassificationFacts
    {
        public static IClassificationType GetClassificationType(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.DefiningToken:
                    return ClassificationFactory.DefiningToken;
                case SyntaxKind.TerminatorToken:
                    return ClassificationFactory.TerminatorToken;
                case SyntaxKind.SeparatorToken:
                    return ClassificationFactory.SeparatorToken;
                case SyntaxKind.PlusToken:
                    return ClassificationFactory.PlusToken;
                case SyntaxKind.MinusToken:
                    return ClassificationFactory.MinusToken;
                case SyntaxKind.StarToken:
                    return ClassificationFactory.StarToken;
                case SyntaxKind.SlashToken:
                    return ClassificationFactory.SlashToken;
                case SyntaxKind.CharacterRangeToken:
                    return ClassificationFactory.CharacterRangeToken;
                case SyntaxKind.OpenParenToken:
                    return ClassificationFactory.OpenParenToken;
                case SyntaxKind.OpenBracketToken:
                    return ClassificationFactory.OpenBracketToken;
                case SyntaxKind.OpenBraceToken:
                    return ClassificationFactory.OpenBraceToken;
                case SyntaxKind.CloseParenToken:
                    return ClassificationFactory.CloseParenToken;
                case SyntaxKind.CloseBracketToken:
                    return ClassificationFactory.CloseBracketToken;
                case SyntaxKind.CloseBraceToken:
                    return ClassificationFactory.CloseBraceToken;
                case SyntaxKind.WhitespaceToken:
                    return ClassificationFactory.WhitespaceToken;
                case SyntaxKind.EndOfLineToken:
                    return ClassificationFactory.EndOfLineToken;
                case SyntaxKind.CommentToken:
                    return ClassificationFactory.CommentToken;
                case SyntaxKind.UnterminatedCommentToken:
                    return ClassificationFactory.UnterminatedCommentToken;
                case SyntaxKind.IdentifierToken:
                    return ClassificationFactory.IdentifierToken;
                case SyntaxKind.StringLiteralToken:
                    return ClassificationFactory.StringLiteralToken;
                case SyntaxKind.UnterminatedStringLiteralToken:
                    return ClassificationFactory.UnterminatedStringLiteralToken;
                case SyntaxKind.NumericLiteralToken:
                    return ClassificationFactory.NumericLiteralToken;
                case SyntaxKind.CharacterLiteralToken:
                    return ClassificationFactory.CharacterLiteralToken;
                case SyntaxKind.NullLiteralToken:
                    return ClassificationFactory.NullLiteralToken;
                case SyntaxKind.SpecialSequenceToken:
                    return ClassificationFactory.SpecialSequenceToken;
                case SyntaxKind.UnterminatedSpecialSequenceToken:
                    return ClassificationFactory.UnterminatedSpecialSequenceToken;
                default:
                    return ClassificationFactory.Other;
            }
        }
    }
}
