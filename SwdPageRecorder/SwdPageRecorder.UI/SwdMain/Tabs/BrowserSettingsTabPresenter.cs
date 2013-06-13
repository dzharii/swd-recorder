using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using SwdPageRecorder.WebDriver;
using SwdPageRecorder.WebDriver.JsCommand;

using System.Xml;
using System.Xml.Linq;

using System.Windows.Forms;
using System.Diagnostics;

namespace SwdPageRecorder.UI
{
    public class BrowserSettingsTabPresenter
    {
        private BrowserSettingsTab view = null;
        
        public BrowserSettingsTabPresenter(BrowserSettingsTab view)
        {
            this.view = view;
        }

        internal void StartNewBrowser(WebDriverOptions browserOptions)
        {
            SwdBrowser.Initialize(browserOptions);

        }
    }
}
