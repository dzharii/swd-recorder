using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using System.Diagnostics.Contracts;

namespace SwdPageRecorder.WebDriver
{
    public static class SwdBrowser
    {
        private static IWebDriver _driver = null;
        public static IWebDriver Driver()
        {
            if (_driver == null) throw new ArgumentNullException("_driver", @"Driver was not initialized. Make sure you called Initialize before using Browser.");
            return _driver;
        }

        public static void Initialize()
        {
            _driver = new ChromeDriver();

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
