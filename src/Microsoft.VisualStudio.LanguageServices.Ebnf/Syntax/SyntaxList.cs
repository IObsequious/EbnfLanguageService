using System;
using System.Collections.Generic;
using System.Linq;

namespace Ollon.VisualStudio.Languages.Syntax
{
    public static class SyntaxList
    {
        public static SyntaxList<T> Create<T>()
        {
            return new SyntaxList<T>(new List<T>());
        }

        public static SyntaxList<T> CreateRange<T>(params T[] items)
        {
            return new SyntaxList<T>(items);
        }

        public static SyntaxList<T>.Builder CreateBuilder<T>()
        {
            return new SyntaxList<T>.Builder(8);
        }
    }
}
