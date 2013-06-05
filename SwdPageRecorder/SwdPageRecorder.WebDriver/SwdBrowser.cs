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

using Sgml;


namespace SwdPageRecorder.WebDriver
{
    public static class SwdBrowser
    {
        private static IWebDriver _driver = null;
        private static bool isRemote = false;
        public static IWebDriver GetDriver()
        {
            if (_driver == null) throw new ArgumentNullException("_driver", @"GetDriver was not initialized. Make sure you called Initialize before using Browser.");
            return _driver;
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

        public static XmlDocument GetPageSourceXml()
        {

            string currentPageSource = GetDriver().PageSource;
            XmlDocument doc = new XmlDocument();

            using (Stream pageStream = GenerateStreamFromString(currentPageSource))
            using (TextReader txtReader = new StreamReader(pageStream))
            {
                // setup SgmlReader
                Sgml.SgmlReader sgmlReader = new Sgml.SgmlReader();
                sgmlReader.DocType = "HTML";
                sgmlReader.WhitespaceHandling = WhitespaceHandling.All;
                sgmlReader.CaseFolding = Sgml.CaseFolding.ToLower;

                sgmlReader.InputStream = txtReader;

                // create document
                doc.PreserveWhitespace = true;
                doc.XmlResolver = null;
                doc.Load(sgmlReader);
            }
            return doc;
        }


        public static string XmlTidy(XmlDocument document)
        {
            string result = "";

            
            using (MemoryStream memStream = new MemoryStream())
            using (XmlTextWriter writer = new XmlTextWriter(memStream, Encoding.Unicode))
            {
                try
                {
                    writer.Formatting = Formatting.Indented;

                    // Write the XML into a formatting XmlTextWriter
                    document.WriteContentTo(writer);
                    writer.Flush();
                    memStream.Flush();

                    // Have to rewind the MemoryStream in order to read
                    // its contents.
                    memStream.Position = 0;

                    // Read MemoryStream contents into a StreamReader.
                    StreamReader sReader = new StreamReader(memStream);

                    // Extract the text from the StreamReader.
                    string formattedXML = sReader.ReadToEnd();

                    result = formattedXML;
                }
                catch (XmlException)
                {
                }
            }

            return result;
        }



        public static string GetTidyHtml()
        {

            var xml = GetPageSourceXml();
            return XmlTidy(xml);
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

    }
}
