// -----------------------------------------------------------------------
// <copyright file="CharacterStringMatchAttribute.cs" company="Ollon, LLC">
//     Copyright (c) 2017 Ollon, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Ollon.VisualStudio.Languages.InsertMatch
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CharacterStringMatchAttribute : Attribute
    {
        public CharacterStringMatchAttribute(char character, string match)
        {
            Character = character;
            Match = match;
        }

        public char Character { get; }

        public string Match { get; }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class StringPatternMatchAttribute : Attribute
    {
        public StringPatternMatchAttribute(string start, string end)
        {
            Start = start;
            End = end;
        }

        public string Start { get; }

        public string End { get; }
    }
}
