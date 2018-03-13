// -----------------------------------------------------------------------
// <copyright file="InsertMatchingViewTaggerProvider.cs" company="Ollon, LLC">
//     Copyright (c) 2017 Ollon, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Utilities;

namespace Ollon.VisualStudio.Languages.InsertMatch
{
    [Export(typeof(IVsTextViewCreationListener))]
    [Name("insert matching provider")]
    [ContentType("Ebnf")]
    [TextViewRole(PredefinedTextViewRoles.Editable)]
    public class InsertMatchingTextViewCreationListener : IVsTextViewCreationListener
    {
        [Import]
        internal IVsEditorAdaptersFactoryService AdapterService { get; private set; }

        [Import]
        internal SVsServiceProvider ServiceProvider { get; private set; }

        public void VsTextViewCreated(IVsTextView textViewAdapter)
        {
            ITextView textView = AdapterService.GetWpfTextView(textViewAdapter);

            InsertMatchingCommandHandler CreateCommandHandler()
            {
                return new InsertMatchingCommandHandler(textViewAdapter, textView, this);
            }

            textView.Properties.GetOrCreateSingletonProperty(CreateCommandHandler);
        }
    }
}
