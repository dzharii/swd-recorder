using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;

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

        public static void Initialize()
        {
            //_driver = new ChromeDriver();

            //DesiredCapabilities caps = DesiredCapabilities.Chrome();
            DesiredCapabilities caps = DesiredCapabilities.HtmlUnitWithJavaScript();
            _driver = new RemoteWebDriver(caps);

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
