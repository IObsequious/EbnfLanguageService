using System;

namespace Ollon.VisualStudio.Languages.Regions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class OutliningRegionBoundsAttribute : Attribute
    {
        public OutliningRegionBoundsAttribute(string start, string end)
        {
            Start = start;
            End = end;
        }

        public string Start { get; }

        public string End { get; }
    }
}