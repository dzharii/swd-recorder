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
    public class BrowserSettingsTabPresenter : IPresenter<BrowserSettingsTabView>
    {
        private BrowserSettingsTabView view = null;
        
        public void InitWithView(BrowserSettingsTabView view)
        {
            this.view = view;

            // Subscribe to WebDriverUtils events
            SwdBrowser.OnDriverStarted += InitControls;
            SwdBrowser.OnDriverClosed += InitControls;
            InitControls();

            view.SetStatus("Not started");
        }

        private void InitControls()
        {
            var driverIsRunning = SwdBrowser.IsWorking;
            if (driverIsRunning)
            {
                view.SetStatus("Running");
            }
            else
            {
                view.SetStatus("Not running");
            }
            
        }

        public void StartNewBrowser(WebDriverOptions browserOptions)
        {
            if (SwdBrowser.IsWorking)
            {
                StopDriver();
            }
            else
            {
                StartDriver(browserOptions);
            }
        }

        public void StartDriver(WebDriverOptions browserOptions)
        {
            view.DisableDriverStartButton();
            SwdBrowser.Initialize(browserOptions);
            view.DriverWasStarted();
            view.EnableDriverStartButton();

        }

        public void StopDriver()
        {
            view.DisableDriverStartButton();
            SwdBrowser.CloseDriver();
            view.EnableDriverStartButton();
            view.DriverWasStopped();
        }
    }
}
