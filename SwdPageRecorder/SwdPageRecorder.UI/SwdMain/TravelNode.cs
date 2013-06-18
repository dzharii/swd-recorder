using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwdPageRecorder.UI
{
    public class TravelNode
    {
        public string NodeName { get; set; }
        public int NodeIndex { get; set; }

        public override string ToString()
        {
            return String.Format("{0}[{1}]", NodeName, NodeIndex);
        }
    }
}
