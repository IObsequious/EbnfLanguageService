using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Ollon.VisualStudio.Languages.Classification
{
    public static class ClassificationTypes
    {
        [Export]
        [Name("Ebnf")]
        [BaseDefinition("code")]
        [BaseDefinition("projection")]
        [BaseDefinition("text")]
        [BaseDefinition("intellisense")]
        [BaseDefinition("formal language")]
        internal static ContentTypeDefinition ebnfContentTypeDefinition;

        [Export]
        [FileExtension(".ebnf")]
        [ContentType("Ebnf")]
        internal static FileExtensionToContentTypeDefinition ebnfFileExtensionToContentTypeDefinition;

        //[Export]
        //[Name(EbnfClassificationTypeNames.EbnfError)]
        //[BaseDefinition(ClassificationTypeNames.Er)]
        //internal static ClassificationTypeDefinition EbnfErrorClassificationTypeDefinition;

        //[Export]
        //[Name(EbnfClassificationTypeNames.EbnfComment)]
        //[BaseDefinition(ClassificationTypeNames.Comment)]
        //internal static ClassificationTypeDefinition EbnfCommentClassificationTypeDefinition;

        //[Export]
        //[Name(EbnfClassificationTypeNames.EbnfKeyword)]
        //[BaseDefinition(ClassificationTypeNames.Keyword)]
        //internal static ClassificationTypeDefinition EbnfKeywordClassificationTypeDefinition;

        //[Export]
        //[Name(EbnfClassificationTypeNames.EbnfInteger)]
        //[BaseDefinition(ClassificationTypeNames.Number)]
        //internal static ClassificationTypeDefinition EbnfIntegerClassificationTypeDefinition;

        //[Export]
        //[Name(EbnfClassificationTypeNames.EbnfString)]
        //[BaseDefinition(ClassificationTypeNames.String)]
        //internal static ClassificationTypeDefinition EbnfStringClassificationTypeDefinition;

        //[Export]
        //[Name(EbnfClassificationTypeNames.EbnfExcludedCode)]
        //[BaseDefinition(ClassificationTypeNames.ExcludedCode)]
        //internal static ClassificationTypeDefinition EbnfExcludedCodeClassificationTypeDefinition;

        //[Export]
        //[Name(EbnfClassificationTypeNames.EbnfSymbolDefinition)]
        //[BaseDefinition(ClassificationTypeNames.SymbolDefinition)]
        //internal static ClassificationTypeDefinition EbnfSymbolDefinitionClassificationTypeDefinition;

        //[Export]
        //[Name(EbnfClassificationTypeNames.EbnfSymbolReference)]
        //[BaseDefinition(ClassificationTypeNames.SymbolReference)]
        //internal static ClassificationTypeDefinition EbnfSymbolReferenceClassificationTypeDefinition;

        //[Export]
        //[Name(EbnfClassificationTypeNames.EbnfOperator)]
        //[BaseDefinition(ClassificationTypeNames.Operator)]
        //internal static ClassificationTypeDefinition EbnfOperatorClassificationTypeDefinition;

        //[Export]
        //[Name(EbnfClassificationTypeNames.EbnfWhiteSpace)]
        //[BaseDefinition(ClassificationTypeNames.WhiteSpace)]
        //internal static ClassificationTypeDefinition EbnfWhiteSpaceClassificationTypeDefinition;

        //[Export]
        //[Name(EbnfClassificationTypeNames.EbnfLiteral)]
        //[BaseDefinition(ClassificationTypeNames.Literal)]
        //internal static ClassificationTypeDefinition EbnfLiteralClassificationTypeDefinition;

        //[Export]
        //[Name(EbnfClassificationTypeNames.EbnfCharacter)]
        //[BaseDefinition(ClassificationTypeNames.Character)]
        //internal static ClassificationTypeDefinition EbnfCharacterClassificationTypeDefinition;

        //[Export]
        //[Name(EbnfClassificationTypeNames.EbnfIdentifier)]
        //[BaseDefinition(ClassificationTypeNames.Identifier)]
        //internal static ClassificationTypeDefinition EbnfIdentifierClassificationTypeDefinition;

        //[Export]
        //[Name(EbnfClassificationTypeNames.EbnfSpecialSequence)]
        //[BaseDefinition(ClassificationTypeNames.ExcludedCode)]
        //internal static ClassificationTypeDefinition EbnfSpecialSequenceClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.DefiningToken)]
        [BaseDefinition(ClassificationTypeNames.Identifier)]
        internal static ClassificationTypeDefinition DefiningTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.TerminatorToken)]
        [BaseDefinition(ClassificationTypeNames.Identifier)]
        internal static ClassificationTypeDefinition TerminatorTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.SeparatorToken)]
        [BaseDefinition(ClassificationTypeNames.Identifier)]
        internal static ClassificationTypeDefinition SeparatorTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.PlusToken)]
        [BaseDefinition(ClassificationTypeNames.Operator)]
        internal static ClassificationTypeDefinition PlusTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.MinusToken)]
        [BaseDefinition(ClassificationTypeNames.Operator)]
        internal static ClassificationTypeDefinition MinusTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.StarToken)]
        [BaseDefinition(ClassificationTypeNames.Operator)]
        internal static ClassificationTypeDefinition StarTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.SlashToken)]
        [BaseDefinition(ClassificationTypeNames.Operator)]
        internal static ClassificationTypeDefinition SlashTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.CharacterRangeToken)]
        [BaseDefinition(ClassificationTypeNames.Identifier)]
        internal static ClassificationTypeDefinition CharacterRangeTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.OpenParenToken)]
        [BaseDefinition(ClassificationTypeNames.Identifier)]
        internal static ClassificationTypeDefinition OpenParenTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.OpenBracketToken)]
        [BaseDefinition(ClassificationTypeNames.Identifier)]
        internal static ClassificationTypeDefinition OpenBracketTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.OpenBraceToken)]
        [BaseDefinition(ClassificationTypeNames.Identifier)]
        internal static ClassificationTypeDefinition OpenBraceTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.CloseParenToken)]
        [BaseDefinition(ClassificationTypeNames.Identifier)]
        internal static ClassificationTypeDefinition CloseParenTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.CloseBracketToken)]
        [BaseDefinition(ClassificationTypeNames.Identifier)]
        internal static ClassificationTypeDefinition CloseBracketTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.CloseBraceToken)]
        [BaseDefinition(ClassificationTypeNames.Identifier)]
        internal static ClassificationTypeDefinition CloseBraceTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.WhitespaceToken)]
        [BaseDefinition(ClassificationTypeNames.WhiteSpace)]
        internal static ClassificationTypeDefinition WhitespaceTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.EndOfLineToken)]
        [BaseDefinition(ClassificationTypeNames.WhiteSpace)]
        internal static ClassificationTypeDefinition EndOfLineTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.CommentToken)]
        [BaseDefinition(ClassificationTypeNames.Comment)]
        internal static ClassificationTypeDefinition CommentTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.UnterminatedCommentToken)]
        [BaseDefinition(ClassificationTypeNames.Comment)]
        internal static ClassificationTypeDefinition UnterminatedCommentTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.IdentifierToken)]
        [BaseDefinition(ClassificationTypeNames.Identifier)]
        internal static ClassificationTypeDefinition IdentifierTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.StringLiteralToken)]
        [BaseDefinition(ClassificationTypeNames.String)]
        internal static ClassificationTypeDefinition StringLiteralTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.UnterminatedStringLiteralToken)]
        [BaseDefinition(ClassificationTypeNames.String)]
        internal static ClassificationTypeDefinition UnterminatedStringLiteralTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.NumericLiteralToken)]
        [BaseDefinition(ClassificationTypeNames.Number)]
        internal static ClassificationTypeDefinition NumericLiteralTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.CharacterLiteralToken)]
        [BaseDefinition(ClassificationTypeNames.Character)]
        internal static ClassificationTypeDefinition CharacterLiteralTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.NullLiteralToken)]
        [BaseDefinition(ClassificationTypeNames.SymbolDefinition)]
        internal static ClassificationTypeDefinition NullLiteralTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.SpecialSequenceToken)]
        [BaseDefinition(ClassificationTypeNames.ExcludedCode)]
        internal static ClassificationTypeDefinition SpecialSequenceTokenClassificationTypeDefinition;

        [Export]
        [Name(SyntaxKindNames.UnterminatedSpecialSequenceToken)]
        [BaseDefinition(ClassificationTypeNames.ExcludedCode)]
        internal static ClassificationTypeDefinition UnterminatedSpecialSequenceTokenClassificationTypeDefinition;

        [Export(typeof(EditorFormatDefinition))]
        [UserVisible(true)]
        [ClassificationType(ClassificationTypeNames = SyntaxKindNames.CharacterLiteralToken)]
        [Name(CharacterLiteralFormatName)]
        [Order(Before = Priority.Default)]
        private class CharacterLiteralClassificationFormatDefinition : ClassificationFormatDefinition
        {
            public const string CharacterLiteralFormatName = "CharacterLiteralFormat";
            public const string CharacterLiteralFormatDisplayName = "Character Literal Format";
            public CharacterLiteralClassificationFormatDefinition()
            {
                this.DisplayName = CharacterLiteralFormatDisplayName;
                this.ForegroundColor = Colors.LightGoldenrodYellow;
            }
        }

        private class StringLiteralClassificationFormatDefinition : ClassificationFormatDefinition
        {
            public const string FormatName = "StringLiteralFormat";
            public const string FormatDisplayName = "String Literal Format";
        }
    }
}
