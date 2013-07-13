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

using SwdPageRecorder.WebDriver.SwdBrowserUtils;


namespace SwdPageRecorder.WebDriver
{
    public static class SwdBrowser
    {
        public static event Action OnDriverStarted;
        public static event Action OnDriverClosed;
        
        private static IWebDriver _driver = null;
        private static bool isRemote = false;

        public static bool Started { get; private set; }

        private static object lockObject = new object();

        static SwdBrowser()
        {
            Started = false;
        }

        public static IWebDriver GetDriver()
        {
            lock (lockObject)
            {
                if (_driver == null) throw new ArgumentNullException("_driver", @"GetDriver was not initialized. Make sure you called Initialize before using Browser.");
                return _driver;
            }
        }

        public static void Initialize(WebDriverOptions browserOptions)
        {

            if (_driver != null)
            {
                _driver.Quit();
                if (OnDriverClosed != null) OnDriverClosed();
                Started = false;
            }

            bool wasRemoteDriverCreated = false;
            _driver = WebDriverUtils.Initialize(browserOptions, out wasRemoteDriverCreated);
            isRemote = wasRemoteDriverCreated;

            Started = true;

            // Fire OnDriverStarted event
            if (OnDriverStarted != null)
            {
                OnDriverStarted();
                
            }
        }

        public static void CloseDriver()
        {

            if (_driver != null)
            {
                _driver.Dispose();

                // Fire OnDriverClosed
                if (OnDriverClosed != null)
                {
                    OnDriverClosed();
                    
                }
            }
            Started = false;
        }

        public static void InjectVisualSearch()
        {
            JavaScriptUtils.InjectVisualSearch(GetDriver());
        }

        public static bool IsVisualSearchScriptInjected()
        {
            return JavaScriptUtils.IsVisualSearchScriptInjected(GetDriver());
        }

        public static void HighlightElement(By by)
        {
            JavaScriptUtils.HighlightElement(by, GetDriver());
        }

        public static HtmlDocument GetPageSource()
        {
            return HtmlPageUtils.GetPageSource(GetDriver());
        }


        public static string GetTidyHtml()
        {
            return HtmlPageUtils.GetTidyHtml(GetDriver());
        }


        public static BrowserCommand GetNextCommand() // Returns null if no new commands received
        {
            return BrowserCommands.GetNextCommand(GetDriver());
        }


        public static string GetElementXPath(IWebElement webElement)
        {
            return JavaScriptUtils.GetElementXPath(webElement, GetDriver());
        }

        
        // Check if the current driver is working
        public static bool IsWorking 
        {
            get
            {
                bool result = true;
                if (_driver != null)
                {
                    try
                    {
                        // Try to get page title
                        var title = _driver.Title;
                    }
                    catch
                    {
                        result = false;
                    }
                }
                else // When driver is Null it definitely not working
                {
                    result = false;
                }
                return result;
            }
        }


        static readonly Finalizer finalizer = new Finalizer();

        sealed class Finalizer
        {
            ~Finalizer()
            {
                CloseDriver();
            }
        }

    }
}
