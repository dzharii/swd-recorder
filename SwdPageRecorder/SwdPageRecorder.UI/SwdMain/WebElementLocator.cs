using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SwdPageRecorder.UI
{
    public class WebElementLocator
    {
        [DisplayName("Search Method")]
        [XmlAttribute(Type = typeof(LocatorSearchMethod))]
        public LocatorSearchMethod HowToSearch { get; set; }

        [DisplayName("Locator")]
        [XmlAttribute(Type = typeof(string))]
        public string Locator { get; set; }
    }
}
