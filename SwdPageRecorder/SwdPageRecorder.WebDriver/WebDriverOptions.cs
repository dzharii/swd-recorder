using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SwdPageRecorder.WebDriver
{
    public class WebDriverOptions
    {
        public const string browser_Firefox = "Firefox";
        public const string browser_Chrome = "Chrome";
        public const string browser_InternetExplorer = "InternetExplorer";
        public const string browser_PhantomJS = "PhantomJS";
        public const string browser_HtmlUnit = "HtmlUnit";
        public const string browser_HtmlUnitWithJavaScript = "HtmlUnitWithJavaScript";
        public const string browser_Opera = "Opera";
        public const string browser_Safari = "Safari";
        public const string browser_IPhone = "IPhone";
        public const string browser_IPad = "IPad";
        public const string browser_Android = "Android";


        public static readonly string[] allWebdriverBrowsersSupported = new string[]
        {
            browser_Firefox,
            browser_Chrome,
            browser_InternetExplorer,
            browser_PhantomJS,
            browser_HtmlUnit,
            browser_HtmlUnitWithJavaScript,
            browser_Opera,
            browser_Safari,
            browser_IPhone,
            browser_IPad,
            browser_Android,
        };

        public static readonly string[] embededWebdriverBrowsersSupported = new string[]
        {
            browser_Firefox,
            browser_Chrome,
            browser_InternetExplorer,
            browser_PhantomJS,
            browser_Safari,
        };

        public string BrowserName { get; set; }

        public bool IsRemote { get; set; }

        public string RemoteUrl { get; set; }
    }
}
