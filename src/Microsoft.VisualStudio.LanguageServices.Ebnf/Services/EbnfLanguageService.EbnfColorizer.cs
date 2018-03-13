using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace Ollon.VisualStudio.Languages.Services
{
    public partial class EbnfLanguageService
    {
        private class EbnfColorizer : Colorizer
        {
            public EbnfColorizer(EbnfLanguageService svc, IVsTextLines buffer, IScanner scanner) : base(svc, buffer, scanner)
            {
            }
        }
    }
}
