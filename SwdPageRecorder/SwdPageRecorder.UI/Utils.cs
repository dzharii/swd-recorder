using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using SwdPageRecorder.WebDriver;
using SwdPageRecorder.WebDriver.JsCommand;

namespace SwdPageRecorder.UI
{
    public static class Utils
    {

        public static By ByFromLocatorSearchMethod(LocatorSearchMethod searchMethod, string locator)
        {
            By by = null;
            switch (searchMethod)
            {
                case LocatorSearchMethod.Id:
                    by = By.Id(locator);
                    break;
                case LocatorSearchMethod.CssSelector:
                    by = By.CssSelector(locator);
                    break;
                case LocatorSearchMethod.XPath:
                    by = By.XPath(locator);
                    break;

                case LocatorSearchMethod.Name:
                    by = By.Name(locator);
                    break;

                case LocatorSearchMethod.TagName:
                    by = By.TagName(locator);
                    break;

                case LocatorSearchMethod.ClassName:
                    by = By.ClassName(locator);
                    break;

                case LocatorSearchMethod.LinkText:
                    by = By.LinkText(locator);
                    break;

                case LocatorSearchMethod.PartialLinkText:
                    by = By.PartialLinkText(locator);
                    break;
            }
            return by;
        }
    }
}
