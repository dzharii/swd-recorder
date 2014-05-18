using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SwdPageRecorder.WebDriver
{
    [Serializable]
    public class SwdPageObject
    {
        public string PageObjectName { get; set; }

        public int Version { get; set; }

        public List<WebElementDefinition> Items { get; set; }

        public string FrameDisplayName { get; set; }
        public string FrameInternalName { get; set; }

        public string PageTitle { get; set; }

        public SwdPageObject()
        {
            PageObjectName = "SwdPageObjectClass";
            Items = new List<WebElementDefinition>();

            FrameDisplayName = String.Empty;
            FrameInternalName = String.Empty;

            PageTitle = String.Empty;

            Version = 2;
        }
    }
}
