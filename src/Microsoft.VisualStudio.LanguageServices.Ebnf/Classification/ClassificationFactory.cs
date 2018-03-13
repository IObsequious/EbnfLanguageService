using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text.Classification;

namespace Ollon.VisualStudio.Languages.Classification
{
    internal static class ClassificationFactory
    {
        private static IComponentModel GetComponentModel()
        {
            return Package.GetGlobalService(typeof(SComponentModel)) as IComponentModel;
        }

        private static ExportProvider DefaultExportProvider => GetComponentModel().DefaultExportProvider;

        private static IClassificationTypeRegistryService Registry =>
        DefaultExportProvider.GetExportedValue<IClassificationTypeRegistryService>();

        public static IClassificationType GetClassificationType(string name)
        {
            return Registry.GetClassificationType(name);
        }

        //public static IClassificationType ErrorType => GetClassificationType(EbnfClassificationTypeNames.EbnfError);

        //public static IClassificationType EbnfComment => GetClassificationType(EbnfClassificationTypeNames.EbnfComment);
        //public static IClassificationType EbnfKeyword => GetClassificationType(EbnfClassificationTypeNames.EbnfKeyword);
        //public static IClassificationType EbnfInteger => GetClassificationType(EbnfClassificationTypeNames.EbnfInteger);
        //public static IClassificationType EbnfString => GetClassificationType(EbnfClassificationTypeNames.EbnfString);
        //public static IClassificationType EbnfExcludedCode => GetClassificationType(EbnfClassificationTypeNames.EbnfExcludedCode);
        //public static IClassificationType EbnfSymbolDefinition => GetClassificationType(EbnfClassificationTypeNames.EbnfSymbolDefinition);
        //public static IClassificationType EbnfSymbolReference => GetClassificationType(EbnfClassificationTypeNames.EbnfSymbolReference);
        //public static IClassificationType EbnfOperator => GetClassificationType(EbnfClassificationTypeNames.EbnfOperator);
        //public static IClassificationType EbnfWhiteSpace => GetClassificationType(EbnfClassificationTypeNames.EbnfWhiteSpace);
        //public static IClassificationType EbnfLiteral => GetClassificationType(EbnfClassificationTypeNames.EbnfLiteral);
        //public static IClassificationType EbnfCharacter => GetClassificationType(EbnfClassificationTypeNames.EbnfCharacter);
        //public static IClassificationType EbnfIdentifier => GetClassificationType(EbnfClassificationTypeNames.EbnfIdentifier);

        //public static IClassificationType EbnfSpecialSequence => GetClassificationType(EbnfClassificationTypeNames.EbnfSpecialSequence);

        public static IClassificationType Other => GetClassificationType(ClassificationTypeNames.Other);
        public static IClassificationType DefiningToken => GetClassificationType(SyntaxKindNames.DefiningToken);
        public static IClassificationType TerminatorToken => GetClassificationType(SyntaxKindNames.TerminatorToken);
        public static IClassificationType SeparatorToken => GetClassificationType(SyntaxKindNames.SeparatorToken);
        public static IClassificationType PlusToken => GetClassificationType(SyntaxKindNames.PlusToken);
        public static IClassificationType MinusToken => GetClassificationType(SyntaxKindNames.MinusToken);
        public static IClassificationType StarToken => GetClassificationType(SyntaxKindNames.StarToken);
        public static IClassificationType SlashToken => GetClassificationType(SyntaxKindNames.SlashToken);
        public static IClassificationType CharacterRangeToken => GetClassificationType(SyntaxKindNames.CharacterRangeToken);
        public static IClassificationType OpenParenToken => GetClassificationType(SyntaxKindNames.OpenParenToken);
        public static IClassificationType OpenBracketToken => GetClassificationType(SyntaxKindNames.OpenBracketToken);
        public static IClassificationType OpenBraceToken => GetClassificationType(SyntaxKindNames.OpenBraceToken);
        public static IClassificationType CloseParenToken => GetClassificationType(SyntaxKindNames.CloseParenToken);
        public static IClassificationType CloseBracketToken => GetClassificationType(SyntaxKindNames.CloseBracketToken);
        public static IClassificationType CloseBraceToken => GetClassificationType(SyntaxKindNames.CloseBraceToken);
        public static IClassificationType WhitespaceToken => GetClassificationType(SyntaxKindNames.WhitespaceToken);
        public static IClassificationType EndOfLineToken => GetClassificationType(SyntaxKindNames.EndOfLineToken);
        public static IClassificationType CommentToken => GetClassificationType(SyntaxKindNames.CommentToken);
        public static IClassificationType UnterminatedCommentToken => GetClassificationType(SyntaxKindNames.UnterminatedCommentToken);
        public static IClassificationType IdentifierToken => GetClassificationType(SyntaxKindNames.IdentifierToken);
        public static IClassificationType StringLiteralToken => GetClassificationType(SyntaxKindNames.StringLiteralToken);
        public static IClassificationType UnterminatedStringLiteralToken => GetClassificationType(SyntaxKindNames.UnterminatedStringLiteralToken);
        public static IClassificationType NumericLiteralToken => GetClassificationType(SyntaxKindNames.NumericLiteralToken);
        public static IClassificationType CharacterLiteralToken => GetClassificationType(SyntaxKindNames.CharacterLiteralToken);
        public static IClassificationType NullLiteralToken => GetClassificationType(SyntaxKindNames.NullLiteralToken);
        public static IClassificationType SpecialSequenceToken => GetClassificationType(SyntaxKindNames.SpecialSequenceToken);
        public static IClassificationType UnterminatedSpecialSequenceToken => GetClassificationType(SyntaxKindNames.UnterminatedSpecialSequenceToken);
    }
}
