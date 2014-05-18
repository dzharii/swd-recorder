using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.PhantomJS;
using System.Net;
using SwdPageRecorder.WebDriver.JsCommand;

using System.Xml;

using HtmlAgilityPack;

namespace SwdPageRecorder.WebDriver.SwdBrowserUtils
{
    public static class HtmlPageUtils
    {
        public static HtmlDocument GetPageSource(IWebDriver webDriver)
        {
            string currentPageSource = (webDriver.PageSource ?? "").Replace("\r\n", "");

            var htmlDoc = new HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;

            // https://htmlagilitypack.codeplex.com/discussions/247206
            HtmlNode.ElementsFlags.Remove("form");

            htmlDoc.LoadHtml(currentPageSource);
            return htmlDoc;
        }

    }
}
