using System;
using System.Linq;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

using SwdPageRecorder.WebDriver;

using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;

using System.Diagnostics;

namespace SwdPageRecorder.TestModel
{
    public static class Helper
    {
        // http://stackoverflow.com/a/283917/1126595

        static public string AssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        
        public static void RunDefaultBrowser()
        {
            WebDriverOptions options = new WebDriverOptions()
            {
                BrowserName = WebDriverOptions.browser_Firefox
                //BrowserName = WebDriverOptions.browser_PhantomJS,
            };

            SwdBrowser.Initialize(options);
        }



        public static void LoadTestFile(string pageRelativePath)
        {
            string fullPath = Path.Combine(AssemblyDirectory(), "TestResource", pageRelativePath);
            Uri uri = new Uri(fullPath);

            string uriPath = uri.AbsoluteUri;

            SwdBrowser.GetDriver().Url = uriPath;
        }

        public static void ClickId(string elementId)
        {
            var element = SwdBrowser.GetDriver().FindElement(By.Id(elementId));
            element.Click();
        }

        public static void DumpArray(IEnumerable array)
        {
            foreach(object item in array)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static object JS(string script)
        {
            var driver = SwdBrowser.GetDriver();
            IJavaScriptExecutor jsExec = driver as IJavaScriptExecutor;
            return jsExec.ExecuteScript(script);

        }

        public static string JSToString(string script)
        {
            return Convert.ToString(JS(script));
        }

        public static int JSToInt(string script)
        {
            return Convert.ToInt32(JS(script));
        }

        public static bool JSToBool(string script)
        {
            return Convert.ToBoolean(JS(script));
        }



        public static void JSToConsole(string script)
        {
            Console.WriteLine(JSToString(script));
        }

        public static void ToFrame(int index)
        {
            var driver = SwdBrowser.GetDriver();
            driver.SwitchTo().Frame(index);
        }

        public static string GetRecorderAppPath()
        {
            return Path.Combine(Helper.AssemblyDirectory(), "SwdPageRecorder.UI.exe");
        }

        
        public static string[] GetAllMainWindowTitlesOnDesktop()
        {
            List<string> result = new List<string>();

            Process[] processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                if (!string.IsNullOrWhiteSpace(process.MainWindowTitle))
                {
                    result.Add(process.MainWindowTitle);
                }
            }
            return result.ToArray();
        }



    }
}
