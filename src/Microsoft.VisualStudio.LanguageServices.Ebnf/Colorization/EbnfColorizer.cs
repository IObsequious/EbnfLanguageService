using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Utilities;

namespace Ollon.VisualStudio.Languages.Colorization
{
    [Export(typeof(IVsTextViewCreationListener))]
    [Name("Ebnf Colorizer")]
    [ContentType("Ebnf")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    public class EbnfColorizer : IVsTextViewCreationListener
    {
        public void VsTextViewCreated(IVsTextView textViewAdapter)
        {

        }
    }
}
