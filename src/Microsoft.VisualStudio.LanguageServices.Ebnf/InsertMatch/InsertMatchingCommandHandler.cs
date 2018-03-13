using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;

namespace Ollon.VisualStudio.Languages.InsertMatch
{
    //[CharacterStringMatch('(', ")")]
    //[CharacterStringMatch('{', "}")]
    //[CharacterStringMatch('[', "]")]
    [CharacterStringMatch(':', " ;")]
    [CharacterStringMatch('=', " ;")]
    [CharacterStringMatch('"', "\"")]
    [CharacterStringMatch('\'', "'")]
    [CharacterStringMatch('?', " ?")]
    public class InsertMatchingCommandHandler : IOleCommandTarget
    {
        public InsertMatchingCommandHandler(IVsTextView vsTextView, ITextView textView, InsertMatchingTextViewCreationListener provider)
        {
            VsTextView = vsTextView;
            TextView = textView;
            Provider = provider;

            vsTextView.AddCommandFilter(this, out IOleCommandTarget nextHandler);
            if (nextHandler != null)
            {
                NextHandler = nextHandler;
            }
        }

        public IOleCommandTarget NextHandler { get; }
        public IVsTextView VsTextView { get; }
        public ITextView TextView { get; }
        public InsertMatchingTextViewCreationListener Provider { get; }

        private List<char> _inputBuffer;

        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            return NextHandler.QueryStatus(ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        public int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            if (VsShellUtilities.IsInAutomationFunction(Provider.ServiceProvider))
            {
                return NextHandler.Exec(ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
            }

            char typedChar = char.MaxValue;
            _inputBuffer = new List<char>();

            if (pguidCmdGroup == VSConstants.VSStd2K && nCmdID == (uint)VSConstants.VSStd2KCmdID.TYPECHAR)
            {
                typedChar = (char)(ushort)Marshal.GetObjectForNativeVariant(pvaIn);
            }

            int retVal = NextHandler.Exec(ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);

            int currentPosition = TextView.Caret.Position.BufferPosition.Position;

            ITextSnapshotLine line = TextView.TextSnapshot.GetLineFromPosition(currentPosition);

            int linestart = line.Start.Position;
            int currentend = currentPosition;
            int column = currentend - linestart;

            var matchingCharacters = GetMatchingCharacters();

            foreach (KeyValuePair<char, string> entry in matchingCharacters)
            {
                if (typedChar == entry.Key)
                {
                    InsertCharacter(entry.Value, currentPosition, line, column);
                    return VSConstants.S_OK;
                }
            }

            return retVal;
        }

        private void InsertCharacter(string match, int currentPosition, ITextSnapshotLine line, int column)
        {
            ITextSnapshot snapshot = TextView.TextBuffer.Insert(currentPosition, match);
            VsTextView.SetCaretPos(line.LineNumber, column);
        }

        private static Dictionary<string, string> GetMatchingStrings()
        {
            object[] attributes = typeof(InsertMatchingCommandHandler).GetCustomAttributes(typeof(StringPatternMatchAttribute), false);

            StringPatternMatchAttribute[] array = Cast<StringPatternMatchAttribute>(attributes);

            return array.ToDictionary(r => r.Start, r => r.End);
        }

        private static Dictionary<char, string> GetMatchingCharacters()
        {
            object[] attributes = typeof(InsertMatchingCommandHandler).GetCustomAttributes(typeof(CharacterStringMatchAttribute), false);

            CharacterStringMatchAttribute[] array = Cast<CharacterStringMatchAttribute>(attributes);

            return array.ToDictionary(r => r.Character, r => r.Match);
        }

        private static T[] Cast<T>(IEnumerable<object> o) => o.Select(x => (T)x).ToArray();
    }
}
