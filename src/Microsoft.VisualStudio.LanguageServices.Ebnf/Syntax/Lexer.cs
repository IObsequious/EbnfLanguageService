using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text;

namespace Ollon.VisualStudio.Languages.Syntax
{
    public class Lexer
    {
        internal readonly CharBuffer TextWindow;
        private readonly ITextSnapshot _snapshot;
        private LexerMode _lexerMode;

        public Lexer(ITextSnapshot snapshot, string text)
        {
            _lexerMode = LexerMode.None;
            _snapshot = snapshot;
            TextWindow = new CharBuffer(text);
        }

        public Lexer(SnapshotSpan snapshotSpan)
        {
            _snapshot = snapshotSpan.Snapshot;
            _lexerMode = LexerMode.None;
            TextWindow = new CharBuffer(_snapshot.GetText());
        }

        public List<SyntaxToken> Tokenize()
        {
            List<SyntaxToken> list = new List<SyntaxToken>();
            SyntaxToken token = Lex();
            while (token != null)
            {
                list.Add(token);
                token = Lex();
            }
            return list;
        }

        public SyntaxToken Lex()
        {
            TextWindow.Start();

            char c = TextWindow.PeekChar();

            if (TextUtilities.IsWhitespaceChar(c))
            {
                TextWindow.AdvanceChar();
                return SyntaxFactory.Whitespace(_snapshot, TextWindow.StringStart, TextWindow.Width);
            }

            if (TextUtilities.IsNewLine(c))
            {
                switch (c)
                {
                    case '\r':
                        {
                            if (TextWindow.PeekChar(1) == '\n')
                            {
                                TextWindow.AdvanceChar(2);
                                return SyntaxFactory.EndOfLine(_snapshot, TextWindow.StringStart, TextWindow.Width);
                            }
                            TextWindow.AdvanceChar();
                            return SyntaxFactory.EndOfLine(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case '\n':
                        {
                            TextWindow.AdvanceChar();
                            return SyntaxFactory.EndOfLine(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                }
            }

            if (TextUtilities.IsIdentifierStartCharacter(c))
            {
                TextWindow.AdvanceChar();

                while (TextUtilities.IsIdentifierPartCharacter(TextWindow.PeekChar()))
                {
                    TextWindow.AdvanceChar();
                }

                return SyntaxFactory.Identifier(_snapshot, TextWindow.StringStart, TextWindow.Width);
            }

            if (TextUtilities.IsQuoteChar(c))
            {
                if (TextWindow.PeekChar(1) == '\\' && TextWindow.PeekChar(2) == 'u')
                {
                    TextWindow.AdvanceChar(8);
                    return SyntaxFactory.CharacterLiteral(_snapshot, TextWindow.StringStart, TextWindow.Width);
                }

                return ScanStringLiteral();
            }

            if (c == '?')
            {
                return ScanSpecialSequence();
            }

            switch (c)
            {
                case ':':
                    {
                        if (TextWindow.PeekChar(1) == ':')
                        {
                            TextWindow.AdvanceChar();

                            if (TextWindow.PeekChar(1) == '=')
                            {
                                TextWindow.AdvanceChar();
                                return SyntaxFactory.Defining(_snapshot, TextWindow.StringStart, TextWindow.Width);
                            }
                            else if (TextWindow.PeekChar(1) == '-')
                            {
                                TextWindow.AdvanceChar();
                                return SyntaxFactory.Defining(_snapshot, TextWindow.StringStart, TextWindow.Width);
                            }

                            return SyntaxFactory.Defining(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }

                        TextWindow.AdvanceChar();
                        return SyntaxFactory.Defining(_snapshot, TextWindow.StringStart, TextWindow.Width);
                    }
                case ';':
                    {
                        TextWindow.AdvanceChar();
                        return SyntaxFactory.Terminator(_snapshot, TextWindow.StringStart, TextWindow.Width);
                    }
                case '-':
                    {
                        TextWindow.AdvanceChar();
                        return SyntaxFactory.Minus(_snapshot, TextWindow.StringStart, TextWindow.Width);
                    }
                case '+':
                    {
                        TextWindow.AdvanceChar();
                        return SyntaxFactory.Plus(_snapshot, TextWindow.StringStart, TextWindow.Width);
                    }
                case '*':
                    {
                        TextWindow.AdvanceChar();
                        return SyntaxFactory.Star(_snapshot, TextWindow.StringStart, TextWindow.Width);
                    }
                case '/':
                    {
                        TextWindow.AdvanceChar();
                        return SyntaxFactory.Slash(_snapshot, TextWindow.StringStart, TextWindow.Width);
                    }
                case '.':
                    {
                        if (TextWindow.PeekChar(1) == '.')
                        {
                            TextWindow.AdvanceChar(2);
                            return SyntaxFactory.CharacterRange(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }

                        TextWindow.AdvanceChar();
                        return SyntaxFactory.Terminator(_snapshot, TextWindow.StringStart, TextWindow.Width);
                    }
                case '|':
                    {
                        TextWindow.AdvanceChar();
                        return SyntaxFactory.Separator(_snapshot, TextWindow.StringStart, TextWindow.Width);
                    }
                case '(':
                    {
                        if (TextWindow.PeekChar(1) == '*')
                        {
                            return ScanComment();
                        }

                        TextWindow.AdvanceChar();
                        return SyntaxFactory.OpenParen(_snapshot, TextWindow.StringStart, TextWindow.Width);
                    }
                case '[':
                    {
                        TextWindow.AdvanceChar();
                        return SyntaxFactory.OpenBracket(_snapshot, TextWindow.StringStart, TextWindow.Width);
                    }
                case '{':
                    {
                        TextWindow.AdvanceChar();
                        return SyntaxFactory.OpenBrace(_snapshot, TextWindow.StringStart, TextWindow.Width);
                    }
                case ')':
                    {
                        TextWindow.AdvanceChar();
                        return SyntaxFactory.CloseParen(_snapshot, TextWindow.StringStart, TextWindow.Width);
                    }
                case ']':
                    {
                        TextWindow.AdvanceChar();
                        return SyntaxFactory.CloseBracket(_snapshot, TextWindow.StringStart, TextWindow.Width);
                    }
                case '}':
                    {
                        TextWindow.AdvanceChar();
                        return SyntaxFactory.CloseBrace(_snapshot, TextWindow.StringStart, TextWindow.Width);
                    }
                default:
                    {
                        TextWindow.AdvanceChar();
                        break;
                    }
            }

            return null;
        }

        public SyntaxToken LexSyntaxToken()
        {
            if (_lexerMode != LexerMode.None)
            {
                if (_lexerMode == LexerMode.SpecialSequenceContent)
                {
                    _lexerMode = LexerMode.SpecialSequenceToken;

                    return ScanSpecialSequence();
                }

                if (_lexerMode == LexerMode.SpecialSequenceToken)
                {
                    TextWindow.Start();
                    TextWindow.AdvanceChar();
                    _lexerMode = LexerMode.None;
                    return SyntaxFactory.SpecialSequence(_snapshot, TextWindow.StringStart, TextWindow.Width);
                }
            }

            while (TextWindow.More())
            {
                TextWindow.Start();
                char c = TextWindow.PeekChar();

                if (TextUtilities.IsIdentifierStartCharacter(c))
                {
                    TextWindow.AdvanceChar();

                    while (TextUtilities.IsIdentifierPartCharacter(TextWindow.PeekChar()))
                    {
                        TextWindow.AdvanceChar();
                    }

                    return SyntaxFactory.Identifier(_snapshot, TextWindow.StringStart, TextWindow.Width);
                }

                switch (c)
                {
                    case '\'':
                    case '"':
                        {
                            return ScanStringLiteral();
                        }
                    case ' ':
                    case '\t':       // Horizontal tab
                    case '\v':       // Vertical Tab
                    case '\f':       // Form-feed
                    case '\u001A':
                        {
                            while (TextUtilities.IsWhitespaceChar(c))
                            {
                                TextWindow.AdvanceChar();
                                c = TextWindow.NextChar();
                            }
                            return SyntaxFactory.Whitespace(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case '\r':
                    case '\n':
                        {
                            if (c == '\r' && TextWindow.PeekChar(1) == '\n')
                            {
                                TextWindow.AdvanceChar(2);
                                return SyntaxFactory.EndOfLine(_snapshot, TextWindow.StringStart, TextWindow.Width);
                            }

                            TextWindow.AdvanceChar();
                            return SyntaxFactory.EndOfLine(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case '(':
                        {
                            if (TextWindow.PeekChar(1) == '*')
                            {
                                return ScanComment();
                            }

                            TextWindow.AdvanceChar();
                            return SyntaxFactory.OpenParen(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case '?':
                        {
                            _lexerMode = LexerMode.SpecialSequenceContent;
                            TextWindow.AdvanceChar();
                            return SyntaxFactory.SpecialSequence(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case ':':
                        {
                            if (TextWindow.PeekChar(1) == ':')
                            {
                                TextWindow.AdvanceChar();

                                if (TextWindow.PeekChar(1) == '=')
                                {
                                    TextWindow.AdvanceChar();
                                    return SyntaxFactory.Defining(_snapshot, TextWindow.StringStart, TextWindow.Width);
                                }
                                else if (TextWindow.PeekChar(1) == '-')
                                {
                                    TextWindow.AdvanceChar();
                                    return SyntaxFactory.Defining(_snapshot, TextWindow.StringStart, TextWindow.Width);
                                }

                                return SyntaxFactory.Defining(_snapshot, TextWindow.StringStart, TextWindow.Width);
                            }

                            TextWindow.AdvanceChar();
                            return SyntaxFactory.Defining(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case ';':
                        {
                            TextWindow.AdvanceChar();
                            return SyntaxFactory.Terminator(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case '-':
                        {
                            TextWindow.AdvanceChar();
                            return SyntaxFactory.Minus(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case '+':
                        {
                            TextWindow.AdvanceChar();
                            return SyntaxFactory.Plus(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case '*':
                        {
                            TextWindow.AdvanceChar();
                            return SyntaxFactory.Star(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case '/':
                        {
                            TextWindow.AdvanceChar();
                            return SyntaxFactory.Slash(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case '.':
                        {
                            if (TextWindow.PeekChar(1) == '.')
                            {
                                TextWindow.AdvanceChar(2);
                                return SyntaxFactory.CharacterRange(_snapshot, TextWindow.StringStart, TextWindow.Width);
                            }

                            TextWindow.AdvanceChar();
                            return SyntaxFactory.Terminator(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case '|':
                        {
                            TextWindow.AdvanceChar();
                            return SyntaxFactory.Separator(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case '[':
                        {
                            TextWindow.AdvanceChar();
                            return SyntaxFactory.OpenBracket(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case '{':
                        {
                            TextWindow.AdvanceChar();
                            return SyntaxFactory.OpenBrace(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case ')':
                        {
                            TextWindow.AdvanceChar();
                            return SyntaxFactory.CloseParen(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case ']':
                        {
                            TextWindow.AdvanceChar();
                            return SyntaxFactory.CloseBracket(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                    case '}':
                        {
                            TextWindow.AdvanceChar();
                            return SyntaxFactory.CloseBrace(_snapshot, TextWindow.StringStart, TextWindow.Width);
                        }
                }

                break;
            }

            return null;
        }

        private SyntaxToken ScanStringLiteral()
        {
            if (ScanStringText(out bool terminated) && terminated)
            {
                return SyntaxFactory.StringLiteral(_snapshot, TextWindow.StringStart, TextWindow.Width);
            }
            else
            {
                return SyntaxFactory.UnterminatedStringLiteral(_snapshot, TextWindow.StringStart, TextWindow.Width);
            }
        }

        private SyntaxToken ScanComment()
        {
            if (ScanCommentText(out bool terminated) && terminated)
            {
                return SyntaxFactory.Comment(_snapshot, TextWindow.StringStart, TextWindow.Width);
            }
            else
            {
                return SyntaxFactory.UnterminatedComment(_snapshot, TextWindow.StringStart, TextWindow.Width);
            }
        }

        private SyntaxToken ScanSpecialSequence()
        {
            if (ScanSpecialSequenceText(out bool terminated) && terminated)
            {
                return SyntaxFactory.SpecialSequence(_snapshot, TextWindow.StringStart, TextWindow.Width);
            }
            else
            {
                return SyntaxFactory.UnterminatedSpecialSequence(_snapshot, TextWindow.StringStart, TextWindow.Width);
            }
        }

        private bool ScanStringText(out bool isTerminated)
        {
            if (TextUtilities.IsQuoteChar(TextWindow.PeekChar()))
            {
                char quote = TextWindow.PeekChar();

                TextWindow.AdvanceChar();

                char ch;
                while (true)
                {
                    if ((ch = TextWindow.PeekChar()) == char.MaxValue)
                    {
                        isTerminated = false;
                        break;
                    }
                    else if (ch == quote)
                    {
                        TextWindow.AdvanceChar();
                        isTerminated = true;
                        break;
                    }
                    else
                    {
                        TextWindow.AdvanceChar();
                    }
                }

                return true;
            }
            else
            {
                isTerminated = false;
                return false;
            }
        }

        private bool ScanCommentText(out bool isTerminated)
        {
            TextWindow.Start();

            if (TextWindow.PeekChar() == '(' && TextWindow.PeekChar(1) == '*')
            {
                TextWindow.AdvanceChar(2);

                char ch;
                while (true)
                {
                    if ((ch = TextWindow.PeekChar()) == char.MaxValue)
                    {
                        isTerminated = false;
                        break;
                    }
                    else if (ch == '*' && TextWindow.PeekChar(1) == ')')
                    {
                        TextWindow.AdvanceChar(2);
                        isTerminated = true;
                        break;
                    }
                    else
                    {
                        TextWindow.AdvanceChar();
                    }
                }

                return true;
            }
            else
            {
                isTerminated = false;
                return false;
            }
        }

        private bool ScanSpecialSequenceText(out bool isTerminated)
        {
            TextWindow.Start();

            if (TextWindow.PeekChar() == '?')
            {
                TextWindow.AdvanceChar();

                char ch;
                while (true)
                {
                    if ((ch = TextWindow.PeekChar()) == char.MaxValue)
                    {
                        isTerminated = false;
                        break;
                    }
                    else if (ch == '?')
                    {
                        TextWindow.AdvanceChar();
                        isTerminated = true;
                        break;
                    }
                    else
                    {
                        TextWindow.AdvanceChar();
                    }
                }

                return true;
            }
            else
            {
                isTerminated = false;
                return false;
            }
        }
    }
}
