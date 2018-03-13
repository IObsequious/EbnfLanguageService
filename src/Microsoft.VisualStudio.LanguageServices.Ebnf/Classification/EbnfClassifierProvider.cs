using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Ollon.VisualStudio.Languages.Classification
{
    [ContentType("Ebnf")]
    [Export(typeof(IClassifierProvider))]
    public partial class EbnfClassifierProvider : IClassifierProvider
    {
        public IClassifier GetClassifier(ITextBuffer textBuffer)
        {
            return textBuffer.Properties.GetOrCreateSingletonProperty(() => new EbnfClassifier(this, textBuffer));
        }
    }
}
