using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SwdPageRecorder.UI
{
    public class WebElementDefinition
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z_][a-zA-Z_0-9]*$", ErrorMessage = "Name should have no spaces and special characters like < $ ; > etc.")]
        public string Name { get; set;  }

        public LocatorSearchMethod HowToSearch { get; set; }
        public string Locator { get; set; }

        public override string ToString()
        {
            return Name;
        }


        public string QuotedLoacator {
            get {
                var value = Locator;
                value = value.Replace("\"", "\"\"");
                value = value.Replace("{", "{{");
                value = value.Replace("}", "}}");
                return value;
            }
        }
        public string How
        {
            get
            {
                var value = Enum.GetName(typeof(LocatorSearchMethod), this.HowToSearch);
                return value;
            }
        }
    }
}
