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
    public static class BrowserCommands
    {

        const string javaScript_GetCommand = @"return document.swdpr_command === undefined ? '' : document.swdpr_command;";
        
        private static string lastCommandId = null;
        public static BrowserCommand GetNextCommand(IWebDriver webDriver)
        {
            BrowserCommand result = null;
            IJavaScriptExecutor js = webDriver as IJavaScriptExecutor;

            string jsonCommand = string.Empty;

            try
            {
                jsonCommand = js.ExecuteScript(javaScript_GetCommand) as string;
            }
            catch (Exception e)
            { 
                MyLog.Exception(e);
                jsonCommand = "";
                throw;
            }

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
