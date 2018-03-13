// -----------------------------------------------------------------------
// <copyright file="LanguageServiceProvider.cs" company="Ollon, LLC">
//     Copyright © 2017 Ollon, LLC. All rights reserved
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Differencing;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;
using Microsoft.VisualStudio.Text.IncrementalSearch;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Text.Outlining;
using Microsoft.VisualStudio.Text.Projection;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace Ollon.VisualStudio.Languages.Services
{
    /// <summary>
    /// Defines the <see cref="LanguageServiceProvider" />
    /// </summary>
    [Export(typeof(ILanguageServiceProvider))]
    internal class LanguageServiceProvider : ILanguageServiceProvider
    {
        /// <summary>
        /// Gets or sets the BufferGraphFactoryService
        /// </summary>
        [Import]
        public IBufferGraphFactoryService BufferGraphFactoryService { get; private set; }

        /// <summary>
        /// Gets or sets the BufferTagAggregatorFactoryService
        /// </summary>
        [Import]
        public IBufferTagAggregatorFactoryService BufferTagAggregatorFactoryService { get; private set; }

        /// <summary>
        /// Gets or sets the ClassificationFormatMapService
        /// </summary>
        [Import]
        public IClassificationFormatMapService ClassificationFormatMapService { get; private set; }

        /// <summary>
        /// Gets or sets the ClassificationTypeRegistryService
        /// </summary>
        [Import]
        public IClassificationTypeRegistryService ClassificationTypeRegistryService { get; private set; }

        /// <summary>
        /// Gets or sets the ClassifierAggregatorService
        /// </summary>
        [Import]
        public IClassifierAggregatorService ClassifierAggregatorService { get; private set; }

        /// <summary>
        /// Gets or sets the ContentTypeRegistryService
        /// </summary>
        [Import]
        public IContentTypeRegistryService ContentTypeRegistryService { get; private set; }

        /// <summary>
        /// Gets or sets the DifferenceService
        /// </summary>
        [Import]
        public IDifferenceService DifferenceService { get; private set; }

        /// <summary>
        /// Gets or sets the EditorFormatMapService
        /// </summary>
        [Import]
        public IEditorFormatMapService EditorFormatMapService { get; private set; }

        /// <summary>
        /// Gets or sets the EditorOperationsFactoryService
        /// </summary>
        [Import]
        public IEditorOperationsFactoryService EditorOperationsFactoryService { get; private set; }

        /// <summary>
        /// Gets or sets the EditorOptionsFactoryService
        /// </summary>
        [Import]
        public IEditorOptionsFactoryService EditorOptionsFactoryService { get; private set; }

        /// <summary>
        /// Gets or sets the FileExtensionRegistryService
        /// </summary>
        [Import]
        public IFileExtensionRegistryService FileExtensionRegistryService { get; private set; }

        /// <summary>
        /// Gets or sets the FormattedTextSourceFactoryService
        /// </summary>
        [Import]
        public IFormattedTextSourceFactoryService FormattedTextSourceFactoryService { get; private set; }

        /// <summary>
        /// Gets or sets the GlyphService
        /// </summary>
        [Import]
        public IGlyphService GlyphService { get; private set; }

        /// <summary>
        /// Gets or sets the IncrementalSearchFactoryService
        /// </summary>
        [Import]
        public IIncrementalSearchFactoryService IncrementalSearchFactoryService { get; private set; }

        /// <summary>
        /// Gets or sets the IntellisenseSessionStackMapService
        /// </summary>
        [Import]
        public IIntellisenseSessionStackMapService IntellisenseSessionStackMapService { get; private set; }

        /// <summary>
        /// Gets or sets the OutliningManagerService
        /// </summary>
        [Import]
        public IOutliningManagerService OutliningManagerService { get; private set; }

        /// <summary>
        /// Gets or sets the ProjectionBufferFactoryService
        /// </summary>
        [Import]
        public IProjectionBufferFactoryService ProjectionBufferFactoryService { get; private set; }

        /// <summary>
        /// Gets or sets the RtfBuilderService
        /// </summary>
        [Import]
        public IRtfBuilderService RtfBuilderService { get; private set; }

        /// <summary>
        /// Gets or sets the ScrollMapFactoryService
        /// </summary>
        [Import]
        public IScrollMapFactoryService ScrollMapFactoryService { get; private set; }

        /// <summary>
        /// Gets or sets the ServiceProvider
        /// </summary>
        [Import]
        public SVsServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// Gets or sets the SmartIndentationService
        /// </summary>
        [Import]
        public ISmartIndentationService SmartIndentationService { get; private set; }

        /// <summary>
        /// Gets or sets the StandardClassificationService
        /// </summary>
        [Import]
        public IStandardClassificationService StandardClassificationService { get; private set; }

        /// <summary>
        /// Gets or sets the TextAndAdornmentSequencerFactoryService
        /// </summary>
        [Import]
        public ITextAndAdornmentSequencerFactoryService TextAndAdornmentSequencerFactoryService { get; private set; }

        /// <summary>
        /// Gets or sets the TextBufferFactoryService
        /// </summary>
        [Import]
        public ITextBufferFactoryService TextBufferFactoryService { get; private set; }

        /// <summary>
        /// Gets or sets the TextDifferencingSelectorService
        /// </summary>
        [Import]
        public ITextDifferencingSelectorService TextDifferencingSelectorService { get; private set; }

        /// <summary>
        /// Gets or sets the TextDocumentFactoryService
        /// </summary>
        [Import]
        public ITextDocumentFactoryService TextDocumentFactoryService { get; private set; }

        /// <summary>
        /// Gets or sets the TextEditorFactoryService
        /// </summary>
        [Import]
        public ITextEditorFactoryService TextEditorFactoryService { get; private set; }

        /// <summary>
        /// Gets or sets the TextSearchService
        /// </summary>
        [Import]
        public ITextSearchService TextSearchService { get; private set; }

        /// <summary>
        /// Gets or sets the TextStructureNavigatorSelectorService
        /// </summary>
        [Import]
        public ITextStructureNavigatorSelectorService TextStructureNavigatorSelectorService { get; private set; }

        /// <summary>
        /// Gets or sets the TextUndoHistoryRegistry
        /// </summary>
        [Import]
        public ITextUndoHistoryRegistry TextUndoHistoryRegistry { get; private set; }

        /// <summary>
        /// Gets or sets the ViewClassifierAggregatorService
        /// </summary>
        [Import]
        public IViewClassifierAggregatorService ViewClassifierAggregatorService { get; private set; }

        /// <summary>
        /// Gets or sets the ViewTagAggregatorFactoryService
        /// </summary>
        [Import]
        public IViewTagAggregatorFactoryService ViewTagAggregatorFactoryService { get; private set; }

        /// <summary>
        /// Gets or sets the VsEditorAdaptersFactoryService
        /// </summary>
        [Import]
        public IVsEditorAdaptersFactoryService VsEditorAdaptersFactoryService { get; private set; }

        /// <summary>
        /// Gets or sets the VsFontsAndColorsInformationService
        /// </summary>
        [Import]
        public IVsFontsAndColorsInformationService VsFontsAndColorsInformationService { get; private set; }

        /// <summary>
        /// Gets or sets the WpfKeyboardTrackingService
        /// </summary>
        [Import]
        public IWpfKeyboardTrackingService WpfKeyboardTrackingService { get; private set; }
    }
}
