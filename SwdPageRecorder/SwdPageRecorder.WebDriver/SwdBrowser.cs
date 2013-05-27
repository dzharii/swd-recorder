using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.PhantomJS;

namespace SwdPageRecorder.WebDriver
{
    public static class SwdBrowser
    {
        private static IWebDriver _driver = null;
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
            throw new NotImplementedException();
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
            return null;
        }


        static readonly Finalizer finalizer = new Finalizer();
        sealed class Finalizer
        {
            ~Finalizer()
            {

                try
                {
                    if (_driver != null)
                    {
                        _driver.Close();
                        _driver.Quit();
                        _driver = null;
                    }
                }
                catch
                {

                }
            }
        }



    }
}
