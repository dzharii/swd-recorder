using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwdPageRecorder.UI
{
    public class WebElementDefinition
    {
        public string Name { get; set;  }
        public LocatorSearchMethod HowToSearch { get; set; }
        public string Locator { get; set; }
        public int ListId { get; set; }

        public WebElementDefinition()
        {
            ListId = -1;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
