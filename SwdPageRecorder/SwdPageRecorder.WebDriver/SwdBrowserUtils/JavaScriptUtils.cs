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
    public static class JavaScriptUtils
    {


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



        internal static void InjectVisualSearch(IWebDriver webDriver)
        {

            MyLog.Write("InjectVisualSearch: Started");
            string javaScript = ReadJavaScriptFromFile(Path.Combine("JavaScript", "ElementSearch.js"));
            IJavaScriptExecutor jsExec = webDriver as IJavaScriptExecutor;

            if (!IsVisualSearchScriptInjected(webDriver))
            {
                MyLog.Write("InjectVisualSearch: Was not injected. Perform Inject");
                jsExec.ExecuteScript(javaScript);
            }
            MyLog.Write("InjectVisualSearch: Finished");
        }

        public static bool IsVisualSearchScriptInjected(IWebDriver webDriver)
        {
            string jsCheckScript = @"return window.swd_visual_search_injected === undefined ? 'false' : 'true';";
            IJavaScriptExecutor jsExec = webDriver as IJavaScriptExecutor;

            string isInjected = jsExec.ExecuteScript(jsCheckScript) as string;
            return isInjected == "true";
            
        }

        internal static void HighlightElement(By by)
        {
            throw new NotImplementedException();
        }

        internal static void HighlightElement(By by, IWebDriver webDriver)
        {
            var element = webDriver.FindElement(by);
            IJavaScriptExecutor jsExec = webDriver as IJavaScriptExecutor;
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

        public static string GetElementXPath(IWebElement webElement, IWebDriver webDriver)
        {
            IJavaScriptExecutor jsExec = webDriver as IJavaScriptExecutor;
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
        {
            return getPathTo(element.parentNode) + '/' + element.tagName.toLowerCase() + '[' + (ix + 1) + ']';
        }
        if (sibling.nodeType === 1 && sibling.tagName === element.tagName)
            ix++;
    }
}

var element = arguments[0];
var xpath = '';
xpath = getPathTo(element);
return xpath;
", webElement);
        }
    }
}
