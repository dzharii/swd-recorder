using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SwdPageRecorder.UI
{
    public class WebElementDefinition
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z_][a-zA-Z_0-9]*$", ErrorMessage = "Name should have no spaces and special characters like < $ ; > etc.")]
        public string Name { get; set;  }

        [DisplayName("Search Method")]
        public LocatorSearchMethod HowToSearch { get; set; }

        [DisplayName("Locator")]
        public string Locator { get; set; }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public string HtmlTag { get; set; }        
        
        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public WebElementLocator[] AlternativeFindsBy { get; set; }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public bool ReturnsCollection { get; set; }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public WebElementHtmlAttributes AllHtmlTagProperties { get; set; }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public string Arg1 { get; set; }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public string Arg2 { get; set; }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public string Arg3 { get; set; }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public string Arg4 { get; set; }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public string Arg5 { get; set; }

        public WebElementDefinition()
        {
            ReturnsCollection = false;
            AlternativeFindsBy = new WebElementLocator[] { };
            HtmlTag = "";
            AllHtmlTagProperties = new WebElementHtmlAttributes();
        }


        public override string ToString()
        {
            return Name;
        }

        [BrowsableAttribute(false), DefaultValueAttribute(false)]
        public string How
        {
            get
            {
                var value = Enum.GetName(typeof(LocatorSearchMethod), this.HowToSearch);
                return value;
            }
        }

        public WebElementDefinition Clone()
        {
            return new WebElementDefinition()
            {
                Name = Name,
                Locator = Locator,
                HowToSearch = HowToSearch,
            };
        }
    }
}
