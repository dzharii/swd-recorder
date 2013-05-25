using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace SwdPageRecorder.UI
{
    public class ResultElement
    {
        public string DisplayString { get; set; }
        public IWebElement WebElement { get; set; }

        public override string ToString()
        {
            return DisplayString;
        }
    }
}
