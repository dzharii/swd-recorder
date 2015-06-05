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
using System.Collections.ObjectModel;

using System.Xml;

using HtmlAgilityPack;

using SwdPageRecorder.WebDriver.SwdBrowserUtils;

using SwdPageRecorder.WebDriver.OpenQA.Selenium.Support.PageObjects;
using System.Reflection;
using System.Threading.Tasks;


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

            if (_driver == null) throw new ArgumentNullException("_driver", @"GetDriver was not initialized. Make sure you called Initialize before using Browser.");
            return _driver;

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

            MyLog.Write("CloseDriver Entered");
            lock (lockObject)
            {
                if (_driver != null)
                {
                    bool success = true;
                    try
                    {
                        var tempDriver = _driver;

                        var closingTask = new Task(() =>
                        {
                            tempDriver.Close();
                            tempDriver.Dispose();
                        });

                        closingTask.Start();
                        // and no wait...

                    }
                    catch (Exception e)
                    {

                        MyLog.Exception(e);
                        success = true;
                    }
                    finally {
                        _driver = null;
                    }

                    // Fire OnDriverClosed
                    if (success && OnDriverClosed != null)
                    {
                        OnDriverClosed();

                    }
                }
                Started = false;
                MyLog.Write("CloseDriver Exited");
            }
        }

        public static object ExecuteJavaScript(string script, params object[] args)
        {
            IJavaScriptExecutor executor = GetDriver() as IJavaScriptExecutor;
            if (executor == null)
            {
                throw new WebDriverException("Driver does not implement IJavaScriptExecutor");
            }

            object result = executor.ExecuteScript(script, args);
            return result;
        }

        public static void InjectVisualSearch()
        {
            lock (lockObject)
            {
                JavaScriptUtils.InjectVisualSearch(GetDriver());
            }
        }
        
        public static void DestroyVisualSearch()
        {
            lock (lockObject)
            {
                JavaScriptUtils.DestroyVisualSearch(GetDriver());
            }
        }

        public static bool IsVisualSearchScriptInjected()
        {
            lock (lockObject)
            {
                return JavaScriptUtils.IsVisualSearchScriptInjected(GetDriver());
            }
        }

        public static void HighlightElement(By by)
        {
            lock (lockObject)
            {
                JavaScriptUtils.HighlightElement(by, GetDriver());
            }
        }

        public static HtmlDocument GetPageSource()
        {
            lock (lockObject)
            {
                return HtmlPageUtils.GetPageSource(GetDriver());
            }
        }


        public static string GetHtml()
        {
            lock (lockObject)
            {
                return GetDriver().PageSource;
            }
        }


        public static BrowserCommand GetNextCommand() // Returns null if no new commands received
        {
            lock (lockObject)
            {
                return BrowserCommands.GetNextCommand(GetDriver());
            }
        }


        public static string GetElementXPath(IWebElement webElement)
        {
            lock (lockObject)
            {
                return JavaScriptUtils.GetElementXPath(webElement, GetDriver());
            }
        }

        
        // Check if the current driver is working
        public static bool IsWorking 
        {
            get
            {
                lock (lockObject)
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
        }

        public static Dictionary<string, string> ReadElementAttributes(By by)
        {
            lock (lockObject)
            {
                return JavaScriptUtils.ReadElementAttributes(by, GetDriver());
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

        public static void RunStandaloneServer()
        {
            throw new NotImplementedException();
        }

        public static void RunStandaloneServer(string pathToStartUpBatFile)
        {
            SeleniumServerProcess.Launch(pathToStartUpBatFile);
        }

        public static BrowserWindow[] GetBrowserWindows()
        {
            lock (lockObject)
            {
                var windowHandles = GetDriver().WindowHandles;
                var result = new List<BrowserWindow>();

                string currentHandle = GetDriver().CurrentWindowHandle;

                foreach (var winHandle in windowHandles)
                {
                    var item = new BrowserWindow();
                    item.WindowHandle = winHandle;
                    GetDriver().SwitchTo().Window(winHandle);
                    item.Title = GetDriver().Title;
                    result.Add(item);
                }

                GetDriver().SwitchTo().Window(currentHandle);

                return result.ToArray();
            }
        }

        public static IWebElement[] GetAllFrameElements()
        {
            lock (lockObject)
            {
                var driver = SwdBrowser.GetDriver();
                var frames = driver.FindElements(By.CssSelector(@"frame, iframe"));
                return frames.ToArray();
            }
        }


        public static BrowserPageFrame GetPageFramesTree()
        {
            lock (lockObject)
            {
                BrowserPageFrame root = new BrowserPageFrame()
                {
                    ChildFrames = null,
                    Index = -1,
                    LocatorNameOrId = "DefaultContent",
                    ParentFrame = null,
                };

                GetDriver().SwitchTo().DefaultContent();
                root.ChildFrames = GetPageFramesTree(root);

                return root;
            }
        }

        public static List<BrowserPageFrame> GetPageFramesTree(BrowserPageFrame parent)
        {

            lock (lockObject)
            {
                List<BrowserPageFrame> children = new List<BrowserPageFrame>();

                //
                var driver = SwdBrowser.GetDriver();

                var allFramesOnThePage = GetAllFrameElements();
                for (var i = 0; i < allFramesOnThePage.Length; i++)
                {
                    var frameElement = allFramesOnThePage[i];

                    BrowserPageFrame frameItem = new BrowserPageFrame()
                    {
                        ChildFrames = null,
                        Index = i,
                        LocatorNameOrId = null,
                        ParentFrame = parent,
                    };

                    string elementId = frameElement.GetAttribute("id");
                    string elementName = frameElement.GetAttribute("name");

                    if (!String.IsNullOrEmpty(elementName))
                    {
                        frameItem.LocatorNameOrId = elementName;
                    }
                    else if (!String.IsNullOrEmpty(elementId))
                    {
                        frameItem.LocatorNameOrId = elementId;
                    }
                    else
                    {
                        frameItem.LocatorNameOrId = String.Empty;
                    }

                    GetDriver().SwitchTo().Frame(i);
                    frameItem.ChildFrames = GetPageFramesTree(frameItem);

                    List<BrowserPageFrame> frameStack = new List<BrowserPageFrame>();
                    SwdBrowser.GoToFrame(parent, ref frameStack);

                    children.Add(frameItem);
                }

                return children;
            }
        }

        
        public static void GoToFrame(BrowserPageFrame frame)
        {
            lock (lockObject)
            {
                List<BrowserPageFrame> frameStack = new List<BrowserPageFrame>();
                GoToFrame(frame, ref frameStack);
            }
        }
        private static void GoToFrame(BrowserPageFrame frame, ref List<BrowserPageFrame> frameStack)
        {
            if (frame.ParentFrame == null)
            {
                SwdBrowser.GetDriver().SwitchTo().DefaultContent();
                frameStack.Reverse();
                foreach (var frameItem in frameStack)
                {
                    SwdBrowser.GetDriver().SwitchTo().Frame(frameItem.Index);
                }
                return;
            }
            else
            {
                frameStack.Add(frame);
                GoToFrame(frame.ParentFrame, ref frameStack);
            }
        }

        public static string GetCurrentWindowHandle()
        {
            lock (lockObject)
            {
                return GetDriver().CurrentWindowHandle;
            }
        }



        public static void GotoWindow(BrowserWindow window)
        {
            lock (lockObject)
            {
                GetDriver().SwitchTo().Window(window.WindowHandle);
            }
        }

        public static void SwitchToDefaultContent()
        {
            lock (lockObject)
            {
                GetDriver().SwitchTo().DefaultContent();
            }
        }

        public static string Url 
        { 
            get {
                    lock (lockObject)
                    {
                        return SwdBrowser.GetDriver().Url;
                    }
                } 
            set {
                    lock (lockObject)
                    {
                        SwdBrowser.GetDriver().Url = value;
                    }
                }
        }

        public static void Maximize()
        {
            lock (lockObject)
            {
                SwdBrowser.GetDriver().Manage().Window.Maximize();
            }
        }

        public static By ConvertLocatorSearchMethodToBy(LocatorSearchMethod searchMethod, string locator)
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


        public static IWebElement CreateWebElementProxy(WebElementDefinition element)
        {
            By elementBy = ConvertLocatorSearchMethodToBy(element.HowToSearch, element.Locator);
            bool shouldBecached = false;

            var driverParam = GetDriver();
            var bysParam = new By[] { elementBy };

            var elementProxy = new WebElementProxy(driverParam, bysParam, shouldBecached);

            return elementProxy;
        }

        /// <summary>
        /// Tests remote hub availabbility. 
        /// Throws Exception when the hub is not available. 
        /// </summary>
        /// <param name="url"></param>

        public static void TestRemoteHub(string url)
        {
            var client = new WebClient();
            string response = "";
            response = client.DownloadString(url);
            
        }

        // Copy-pasted  from 
        // https://github.com/SeleniumHQ/selenium/blob/master/dotnet/src/support/Extensions/WebDriverExtensions.cs
        // 
        public static Screenshot TakeScreenshot()
        {
            var driver = GetDriver();
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            if (screenshotDriver == null)
            {
                IHasCapabilities capabilitiesDriver = driver as IHasCapabilities;
                if (capabilitiesDriver == null)
                {
                    throw new WebDriverException("Driver does not implement ITakesScreenshot or IHasCapabilities");
                }

                if (!capabilitiesDriver.Capabilities.HasCapability(CapabilityType.TakesScreenshot) || !(bool)capabilitiesDriver.Capabilities.GetCapability(CapabilityType.TakesScreenshot))
                {
                    throw new WebDriverException("Driver capabilities do not support taking screenshots");
                }

                MethodInfo executeMethod = driver.GetType().GetMethod("Execute", BindingFlags.Instance | BindingFlags.NonPublic);
                Response screenshotResponse = executeMethod.Invoke(driver, new object[] { DriverCommand.Screenshot, null }) as Response;
                if (screenshotResponse == null)
                {
                    throw new WebDriverException("Unexpected failure getting screenshot; response was not in the proper format.");
                }

                string screenshotResult = screenshotResponse.Value.ToString();
                return new Screenshot(screenshotResult);
            }

            return screenshotDriver.GetScreenshot();
        }
    }
}
