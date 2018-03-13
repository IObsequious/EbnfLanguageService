// -----------------------------------------------------------------------
// <copyright file="Interface1.cs" company="Ollon, LLC">
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
    /// Defines the <see cref="ILanguageServiceProvider" />
    /// </summary>
    public interface ILanguageServiceProvider
    {
        /// <summary>
        /// Gets or sets the BufferGraphFactoryService
        /// </summary>
        IBufferGraphFactoryService BufferGraphFactoryService { get; }

        /// <summary>
        /// Gets or sets the BufferTagAggregatorFactoryService
        /// </summary>
        IBufferTagAggregatorFactoryService BufferTagAggregatorFactoryService { get; }

        /// <summary>
        /// Gets or sets the ClassificationFormatMapService
        /// </summary>
        IClassificationFormatMapService ClassificationFormatMapService { get; }

        /// <summary>
        /// Gets or sets the ClassificationTypeRegistryService
        /// </summary>
        IClassificationTypeRegistryService ClassificationTypeRegistryService { get; }

        /// <summary>
        /// Gets or sets the ClassifierAggregatorService
        /// </summary>
        IClassifierAggregatorService ClassifierAggregatorService { get; }

        /// <summary>
        /// Gets or sets the ContentTypeRegistryService
        /// </summary>
        IContentTypeRegistryService ContentTypeRegistryService { get; }

        /// <summary>
        /// Gets or sets the DifferenceService
        /// </summary>
        IDifferenceService DifferenceService { get; }

        /// <summary>
        /// Gets or sets the EditorFormatMapService
        /// </summary>
        IEditorFormatMapService EditorFormatMapService { get; }

        /// <summary>
        /// Gets or sets the EditorOperationsFactoryService
        /// </summary>
        IEditorOperationsFactoryService EditorOperationsFactoryService { get; }

        /// <summary>
        /// Gets or sets the EditorOptionsFactoryService
        /// </summary>
        IEditorOptionsFactoryService EditorOptionsFactoryService { get; }

        /// <summary>
        /// Gets or sets the FileExtensionRegistryService
        /// </summary>
        IFileExtensionRegistryService FileExtensionRegistryService { get; }

        /// <summary>
        /// Gets or sets the FormattedTextSourceFactoryService
        /// </summary>
        IFormattedTextSourceFactoryService FormattedTextSourceFactoryService { get; }

        /// <summary>
        /// Gets or sets the GlyphService
        /// </summary>
        IGlyphService GlyphService { get; }

        /// <summary>
        /// Gets or sets the IncrementalSearchFactoryService
        /// </summary>
        IIncrementalSearchFactoryService IncrementalSearchFactoryService { get; }

        /// <summary>
        /// Gets or sets the IntellisenseSessionStackMapService
        /// </summary>
        IIntellisenseSessionStackMapService IntellisenseSessionStackMapService { get; }

        /// <summary>
        /// Gets or sets the OutliningManagerService
        /// </summary>
        IOutliningManagerService OutliningManagerService { get; }

        /// <summary>
        /// Gets or sets the ProjectionBufferFactoryService
        /// </summary>
        IProjectionBufferFactoryService ProjectionBufferFactoryService { get; }

        /// <summary>
        /// Gets or sets the RtfBuilderService
        /// </summary>
        IRtfBuilderService RtfBuilderService { get; }

        /// <summary>
        /// Gets or sets the ScrollMapFactoryService
        /// </summary>
        IScrollMapFactoryService ScrollMapFactoryService { get; }

        /// <summary>
        /// Gets or sets the ServiceProvider
        /// </summary>
        SVsServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Gets or sets the SmartIndentationService
        /// </summary>
        ISmartIndentationService SmartIndentationService { get; }

        /// <summary>
        /// Gets or sets the StandardClassificationService
        /// </summary>
        IStandardClassificationService StandardClassificationService { get; }

        /// <summary>
        /// Gets or sets the TextAndAdornmentSequencerFactoryService
        /// </summary>
        ITextAndAdornmentSequencerFactoryService TextAndAdornmentSequencerFactoryService { get; }

        /// <summary>
        /// Gets or sets the TextBufferFactoryService
        /// </summary>
        ITextBufferFactoryService TextBufferFactoryService { get; }

        /// <summary>
        /// Gets or sets the TextDifferencingSelectorService
        /// </summary>
        ITextDifferencingSelectorService TextDifferencingSelectorService { get; }

        /// <summary>
        /// Gets or sets the TextDocumentFactoryService
        /// </summary>
        ITextDocumentFactoryService TextDocumentFactoryService { get; }

        /// <summary>
        /// Gets or sets the TextEditorFactoryService
        /// </summary>
        ITextEditorFactoryService TextEditorFactoryService { get; }

        //ITextParagraphPropertiesFactoryService TextParagraphPropertiesFactoryService { get; }
        //ITextParagraphPropertiesFactoryService TextParagraphPropertiesFactoryService { get; }
        /// <summary>
        /// Gets or sets the TextSearchService
        /// </summary>
        ITextSearchService TextSearchService { get; }

        /// <summary>
        /// Gets or sets the TextStructureNavigatorSelectorService
        /// </summary>
        ITextStructureNavigatorSelectorService TextStructureNavigatorSelectorService { get; }

        /// <summary>
        /// Gets or sets the TextUndoHistoryRegistry
        /// </summary>
        ITextUndoHistoryRegistry TextUndoHistoryRegistry { get; }

        /// <summary>
        /// Gets or sets the ViewClassifierAggregatorService
        /// </summary>
        IViewClassifierAggregatorService ViewClassifierAggregatorService { get; }

        /// <summary>
        /// Gets or sets the ViewTagAggregatorFactoryService
        /// </summary>
        IViewTagAggregatorFactoryService ViewTagAggregatorFactoryService { get; }

        /// <summary>
        /// Gets or sets the VsEditorAdaptersFactoryService
        /// </summary>
        IVsEditorAdaptersFactoryService VsEditorAdaptersFactoryService { get; }

        /// <summary>
        /// Gets or sets the VsFontsAndColorsInformationService
        /// </summary>
        IVsFontsAndColorsInformationService VsFontsAndColorsInformationService { get; }

        /// <summary>
        /// Gets or sets the WpfKeyboardTrackingService
        /// </summary>
        IWpfKeyboardTrackingService WpfKeyboardTrackingService { get; }
    }
}
