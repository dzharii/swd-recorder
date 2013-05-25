using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Support.PageObjects;

namespace SwdPageRecorder.UI
{
    public enum LocatorSearchMethod
    {
        NotSet = -1,
        Id = 0,
        Name = 1,
        TagName = 2,
        ClassName = 3,
        CssSelector = 4,
        LinkText = 5,
        PartialLinkText = 6,
        XPath = 7,
        Custom = 8,
    }
}
