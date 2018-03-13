using System;
using System.Collections.Generic;
using System.Linq;

namespace Ollon.VisualStudio.Languages.Syntax
{
    public class CharBuffer
    {
        private readonly char[] _buffer;
        private readonly int _length;
        private int _offset;
        private int _stringStart;
        private List<char> _stack;

        public CharBuffer(string text)
        {
            _buffer = text.ToCharArray();
            _length = _buffer.Length;
            _offset = 0;
            _stringStart = 0;
        }

        public int Position => _offset;

        public int StringStart => _stringStart;

        public int Width => _offset - _stringStart;

        public char PeekChar()
        {
            int position = Position;
            if (position < _length)
            {
                return _buffer[position];
            }

            return char.MaxValue;
        }

        public char PeekChar(int ahead)
        {
            int position = Position;
            position += ahead;
            if (position < _length)
            {
                return _buffer[position];
            }

            return char.MaxValue;
        }

        public char NextChar()
        {
            char peek = PeekChar();

            if (peek != char.MaxValue)
            {
                AdvanceChar();
            }

            return peek;
        }

        public bool More()
        {
            return _offset < _length;
        }
        public void Start()
        {
            _stringStart = _offset;
        }

        public void AdvanceChar()
        {
            _offset++;
        }

        public void AdvanceChar(int ahead)
        {
            _offset += ahead;
        }
    }
}
