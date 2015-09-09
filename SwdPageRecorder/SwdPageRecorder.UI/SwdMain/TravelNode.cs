using System;

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
