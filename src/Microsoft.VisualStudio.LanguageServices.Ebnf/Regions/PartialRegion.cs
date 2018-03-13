using Microsoft.VisualStudio.Text;

namespace Ollon.VisualStudio.Languages.Regions
{
    public class PartialRegion
    {
        public ITextSnapshot Snapshot { get; set; }
        public int StartLine { get; set; }
        public int StartOffset { get; set; }
        public int Level { get; set; }
        public PartialRegion PartialParent { get; set; }
    }
}