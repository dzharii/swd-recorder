using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SwdPageRecorder.UI
{
    public class WebElementDefinition
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z_][a-zA-Z_0-9]*$", ErrorMessage = "Name should have no spaces and special characters like < $ ; > etc.")]
        [XmlAttribute(Type = typeof(string))]
        public string Name { get; set;  }

        [DisplayName("Search Method")]
        [XmlAttribute(Type = typeof(LocatorSearchMethod))]
        public LocatorSearchMethod HowToSearch { get; set; }

        [DisplayName("Locator")]
        [XmlAttribute(Type = typeof(string))]
        public string Locator { get; set; }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        [XmlAttribute(Type = typeof(string))]
        public string HtmlTag { get; set; }        
        
        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        [XmlAttribute(Type = typeof(WebElementLocator[]))]
        public WebElementLocator[] AlternativeFindBys { get; set; }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        [XmlAttribute(Type = typeof(bool))]
        public bool ReturnsCollection { get; set; }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        [XmlAttribute(Type = typeof(WebElementHtmlAttributes))]
        public WebElementHtmlAttributes AllHtmlTagProperties { get; set; }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        [XmlAttribute(Type = typeof(string))]
        public string Arg1 { get; set; }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        [XmlAttribute(Type = typeof(string))]
        public string Arg2 { get; set; }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        [XmlAttribute(Type = typeof(string))]
        public string Arg3 { get; set; }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        [XmlAttribute(Type = typeof(string))]
        public string HtmlFrameId { get; set; }

        public WebElementDefinition()
        {
            ReturnsCollection = false;
            AlternativeFindBys = new WebElementLocator[] { };
            HtmlTag = "";
            AllHtmlTagProperties = new WebElementHtmlAttributes();
        }

        public override string ToString()
        {
            return Name;
        }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        [XmlIgnore]
        public string How
        {
            get
            {
                var value = Enum.GetName(typeof(LocatorSearchMethod), this.HowToSearch);
                return value;
            }
        }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        [XmlIgnore]
        public string Type
        {
            get
            {
                var type = string.Empty;

                if (AllHtmlTagProperties.ContainsKey("type"))
                {
                    type = AllHtmlTagProperties["type"];
                }

                return type;
            }
        }

        public WebElementDefinition Clone()
        {
            var clone =  new WebElementDefinition()
            {
                Name = Name,
                Locator = Locator,
                HowToSearch = HowToSearch,
                HtmlTag = HtmlTag,
                ReturnsCollection = ReturnsCollection,
                Arg1 = Arg1,
                Arg2 = Arg2,
                Arg3 = Arg3,
                HtmlFrameId = HtmlFrameId,
                AllHtmlTagProperties = new WebElementHtmlAttributes(),
                AlternativeFindBys = null,
            };


            foreach (var entry in AllHtmlTagProperties)
            {
                clone.AllHtmlTagProperties.Add(entry.Key, entry.Value);
            }


            List<WebElementLocator> clonedfindBys = new List<WebElementLocator>();
            foreach (var entry in AlternativeFindBys)
            {
                clonedfindBys.Add(new WebElementLocator() 
                                      { 
                                          HowToSearch = entry.HowToSearch, 
                                          Locator = entry.Locator,
                                      });
            }

            clone.AlternativeFindBys = clonedfindBys.ToArray();

            return clone;
        }
    }
}
