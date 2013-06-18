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


namespace SwdPageRecorder.WebDriver
{
    public static class SwdBrowser
    {
        private static IWebDriver _driver = null;
        private static bool isRemote = false;


        private static object lockObject = new object();
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
            if (browserOptions.IsRemote)
            {
                _driver = ConnetctToRemoteWebDriver(browserOptions);
            }
            else
            {
                _driver = StartEmbededWebDriver(browserOptions);
            }
        }

        private static IWebDriver ConnetctToRemoteWebDriver(WebDriverOptions browserOptions)
        {
            DesiredCapabilities caps = null;
            Uri hubUri = new Uri(browserOptions.RemoteUrl);
            
            switch (browserOptions.BrowserName)
            {

                case WebDriverOptions.browser_Firefox:
                    caps = DesiredCapabilities.Firefox();
                    break;
                case WebDriverOptions.browser_Chrome:
                    caps = DesiredCapabilities.Chrome();
                    break;
                case WebDriverOptions.browser_InternetExplorer:
                    caps = DesiredCapabilities.InternetExplorer();
                    break;
                case WebDriverOptions.browser_PhantomJS:
                    caps = DesiredCapabilities.PhantomJS();
                    break;
                case WebDriverOptions.browser_HtmlUnit:
                    caps = DesiredCapabilities.HtmlUnit();
                    break;
                case WebDriverOptions.browser_HtmlUnitWithJavaScript:
                    caps = DesiredCapabilities.HtmlUnitWithJavaScript();
                    break;
                case WebDriverOptions.browser_Opera:
                    caps = DesiredCapabilities.Opera();
                    break;
                case WebDriverOptions.browser_Safari:
                    caps = DesiredCapabilities.Safari();
                    break;
                case WebDriverOptions.browser_IPhone:
                    caps = DesiredCapabilities.IPhone();
                    break;
                case WebDriverOptions.browser_IPad:
                    caps = DesiredCapabilities.IPad();
                    break;
                case WebDriverOptions.browser_Android:
                    caps = DesiredCapabilities.Android();
                    break;
            }
            isRemote = true;
            return new RemoteWebDriver(hubUri, caps);
        }

        private static IWebDriver StartEmbededWebDriver(WebDriverOptions browserOptions)
        {
            switch (browserOptions.BrowserName)
            {
            
                case WebDriverOptions.browser_Firefox:
                    return new FirefoxDriver();
                case WebDriverOptions.browser_Chrome:
                    return new ChromeDriver();
                case WebDriverOptions.browser_InternetExplorer:
                    return new InternetExplorerDriver();
                case WebDriverOptions.browser_PhantomJS:
                    return new PhantomJSDriver();
                case WebDriverOptions.browser_Safari:
                    return new SafariDriver();
            }
            isRemote = false;
            return null;
        }

        public static void CloseDriver()
        {

            if (_driver != null)
            {
                _driver.Dispose();
            }
        }


        public static string ReadJavaScriptFromFile(string filePath)
        {
            string result = "";
            string contents = File.ReadAllText(filePath);


            // Replace comments
            contents = Regex.Replace(contents, @"(/\*[^/]+\*/)", @"");
            contents = Regex.Replace(contents, @"(\s//[^/\n]+)", @"");
            
            // Replace newlines
            result = Regex.Replace(contents, @"\r\n|\n", @" ");

            return result;
        }


        public static void InjectVisualSearch()
        {
            string javaScript = ReadJavaScriptFromFile(Path.Combine("JavaScript", "ElementSearch.js"));
            IJavaScriptExecutor jsExec = GetDriver() as IJavaScriptExecutor;

            jsExec.ExecuteScript(javaScript);

        }

        public static void HighlightElement(By by)
        {
         
            var element = GetDriver().FindElement(by);
            IJavaScriptExecutor jsExec = GetDriver() as IJavaScriptExecutor;
            jsExec.ExecuteScript(
            @"
                element = arguments[0];
                original_style = element.getAttribute('style');
                element.setAttribute('style', original_style + ""; background: yellow; border: 2px solid red;"");
                setTimeout(function(){
                    element.setAttribute('style', original_style);
                }, 300);

           ", element);
        }

        
        // TODO: Move to Utility
        public static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static HtmlDocument GetPageSource()
        {

            string currentPageSource = (GetDriver().PageSource ?? "").Replace("\r\n", "");
            
            var htmlDoc = new HtmlDocument();
            htmlDoc.OptionFixNestedTags = true;

            // https://htmlagilitypack.codeplex.com/discussions/247206
            HtmlNode.ElementsFlags.Remove("form");
            
            htmlDoc.LoadHtml(currentPageSource);
            return htmlDoc;
        }


        public static string XmlTidy(HtmlDocument document)
        {
            return document.DocumentNode.OuterHtml;
        }



        public static string GetTidyHtml()
        {
            var html = GetPageSource();
            return XmlTidy(html);
        }

        private static string lastCommandId = null;
        public static BrowserCommand GetNextCommand() // Returns null if no new commands received
        {
            BrowserCommand result = null;

            IWebElement body = null;

            try
            {
                body = SwdBrowser.GetDriver().FindElement(By.TagName(@"body"));
            }
            catch { }

            if (body == null) return null;

            string jsonCommand = body.GetAttribute("swdpr_command");

            if (!String.IsNullOrWhiteSpace(jsonCommand))
            {

                var unknownCommand = BrowserCommandParser.ParseCommand<BrowserCommand>(jsonCommand);

                if (lastCommandId == unknownCommand.CommandId) return null;

                if (unknownCommand.Command == @"GetXPathFromElement")
                {
                    result = BrowserCommandParser.ParseCommand<GetXPathFromElement>(jsonCommand);
                }
                else if ((unknownCommand.Command == @"AddElement"))
                {
                    result = BrowserCommandParser.ParseCommand<AddElement>(jsonCommand);
                }
                lastCommandId = unknownCommand.CommandId;
            }


            return result;

        }


        public static string GetElementXPath(IWebElement webElement)
        {
            IJavaScriptExecutor jsExec = GetDriver() as IJavaScriptExecutor;
            return (string)jsExec.ExecuteScript(
@"
function getPathTo(element) {
    if (element === document.body)
        return '/html/' + element.tagName.toLowerCase();

    var ix = 0;
    var siblings = element.parentNode.childNodes;
    for (var i = 0; i < siblings.length; i++) {
        var sibling = siblings[i];
        if (sibling === element)
            return getPathTo(element.parentNode) + '/' + element.tagName.toLowerCase() + '[' + (ix + 1) + ']';
        if (sibling.nodeType === 1 && sibling.tagName === element.tagName)
            ix++;
    }
}

var element = arguments[0];
return getPathTo(element);

", webElement);
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
                return result;
            }
        }
    }
}
