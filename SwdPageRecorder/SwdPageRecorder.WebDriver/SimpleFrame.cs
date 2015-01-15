using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwdPageRecorder.WebDriver
{
    public class SimpleFrame
    {
        public int Index { get; set; }
        public string LocatorNameOrId { get; set; }
        public string Title { get; set; }

        public string ParentFrame { get; set; }
        public List<string> ChildFrames { get; set; }

        public SimpleFrame()
        {
        }

        public SimpleFrame(int index, string loc, string title, string parent, List<string> childs)
        {
            this.Index = index;
            this.LocatorNameOrId = loc;
            this.Title = title;
            this.ParentFrame = parent;
            this.ChildFrames = childs;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
