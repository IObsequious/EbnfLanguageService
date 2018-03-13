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
        private class EbnfDropdownBars : TypeAndMemberDropdownBars
        {
            public IVsTextView TextView { get; }
            public EbnfDropdownBars(EbnfLanguageService languageService, IVsTextView view) : base(languageService)
            {
                TextView = view;
            }

            public override bool OnSynchronizeDropdowns(LanguageService languageService, IVsTextView textView, int line, int col, ArrayList dropDownTypes, ArrayList dropDownMembers, ref int selectedType, ref int selectedMember)
            {
                throw new NotImplementedException();
            }
        }
    }
}
