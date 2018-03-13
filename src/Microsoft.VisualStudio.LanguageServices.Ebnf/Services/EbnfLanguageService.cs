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
    [Guid(LanguageGuid)]
    public partial class EbnfLanguageService : LanguageService
    {
        public const string LanguageGuid = "E6F926FE-C271-44F5-A186-672DADDCAD93";

        private LanguagePreferences _preferences = null;
        public EbnfLanguageService(object site)
        {
            SetSite(site);
        }
        public override string Name => Constants.LanguageName;

        public override TypeAndMemberDropdownBars CreateDropDownHelper(IVsTextView forView)
        {
            if (Preferences.ShowNavigationBar)
                return new EbnfDropdownBars(this, forView);

            return null;
        }

        public override LanguagePreferences GetLanguagePreferences()
        {
            if (_preferences == null)
            {
                _preferences = new LanguagePreferences(Site, typeof(EbnfLanguageService).GUID, Name);

                if (_preferences != null)
                {
                    _preferences.Init();

                    _preferences.EnableCodeSense = true;
                    _preferences.EnableMatchBraces = true;
                    _preferences.EnableMatchBracesAtCaret = true;
                    _preferences.EnableShowMatchingBrace = true;
                    _preferences.EnableCommenting = true;
                    _preferences.HighlightMatchingBraceFlags = _HighlightMatchingBraceFlags.HMB_USERECTANGLEBRACES;
                    _preferences.LineNumbers = true;
                    _preferences.MaxErrorMessages = 100;
                    _preferences.AutoOutlining = true;
                    _preferences.MaxRegionTime = 2000;
                    _preferences.ShowNavigationBar = true;
                    _preferences.InsertTabs = false;
                    _preferences.IndentSize = 2;
                    _preferences.ShowNavigationBar = true;
                    _preferences.EnableAsyncCompletion = true;

                    _preferences.WordWrap = false;
                    _preferences.WordWrapGlyphs = true;

                    _preferences.AutoListMembers = true;
                    _preferences.EnableQuickInfo = true;
                    _preferences.ParameterInformation = true;
                    _preferences.HideAdvancedMembers = false;

                }
            }


            return _preferences;
        }

        public override IScanner GetScanner(IVsTextLines buffer)
        {
            return null;
        }

        public override AuthoringScope ParseSource(ParseRequest req)
        {
            return null;
        }

        public override string GetFormatFilterList()
        {
            return $"Ebnf Grammar File (*.ebnf)|*.ebnf";
        }
    }
}
