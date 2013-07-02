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
        private DesiredCapabilitiesData _desiredCapabilitiesdata = new DesiredCapabilitiesData();
        
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

        internal void InitDesiredCapabilities()
        {
            view.grdDesiredCapabilities.SelectedObject = _desiredCapabilitiesdata;
        }

        public static T? GetValueOrNull<T>(string valueAsString)
            where T : struct
        {
            if (string.IsNullOrEmpty(valueAsString))
                return null;
            return (T)Convert.ChangeType(valueAsString, typeof(T));
        }
        
        internal void LoadCapabilities()
        {
            var remoteDriver = (RemoteWebDriver)SwdBrowser.GetDriver();
            foreach (var prop in _desiredCapabilitiesdata.GetType().GetProperties())
            {
                if (!remoteDriver.Capabilities.HasCapability(prop.Name)) continue;

                object driverValue = remoteDriver.Capabilities.GetCapability(prop.Name);
                if (driverValue == null) continue;

                if (prop.PropertyType == typeof(bool?))
                {
                    bool? boolValue = GetValueOrNull<bool>(driverValue.ToString());
                    prop.SetValue(_desiredCapabilitiesdata, boolValue, null);
                }
                else
                {
                    prop.SetValue(_desiredCapabilitiesdata, driverValue.ToString(), null);
                }
            }
            InitDesiredCapabilities();
        }
    }
}
