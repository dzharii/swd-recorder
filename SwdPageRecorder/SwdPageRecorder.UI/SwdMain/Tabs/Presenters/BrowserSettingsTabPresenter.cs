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

using System.Net;

namespace SwdPageRecorder.UI
{
    public class BrowserSettingsTabPresenter : IPresenter<BrowserSettingsTabView>
    {
        private BrowserSettingsTabView view = null;
        private DesiredCapabilitiesData _desiredCapabilitiesdata = null;
        
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


        public bool wasBrowserStarted = false;
        public void StartNewBrowser(WebDriverOptions browserOptions)
        {
            if (wasBrowserStarted)
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
            wasBrowserStarted = false;
            bool startFailure = false;
            view.DisableDriverStartButton();
            try
            {
                SwdBrowser.Initialize(browserOptions);
                wasBrowserStarted = true;
            }
            catch
            {
                startFailure = true;
                throw;
            }
            finally
            {
                if (!startFailure)
                {
                    SetDesiredCapabilities(browserOptions);
                    view.DriverWasStarted();
                }
                view.EnableDriverStartButton();
            }
        }

        private void SetDesiredCapabilities(WebDriverOptions browserOptions)
        {

            switch (browserOptions.BrowserName)
            {
                case WebDriverOptions.browser_Chrome:
                    _desiredCapabilitiesdata = new ChromeDesiredCapabilitiesData();
                    break;
                case WebDriverOptions.browser_InternetExplorer:
                    _desiredCapabilitiesdata = new IEDesiredCapabilitiesData();
                    break;
                default: 
                    _desiredCapabilitiesdata = new DesiredCapabilitiesData();
                    break;
            }
            
            
        }

        public void StopDriver()
        {
            view.DisableDriverStartButton();
            SwdBrowser.CloseDriver();
            view.EnableDriverStartButton();
            view.DriverWasStopped();
            wasBrowserStarted = false;
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
                string capabilityName = prop.Name.Replace("__", ".");

                if (!remoteDriver.Capabilities.HasCapability(capabilityName)) continue;

                object driverValue = remoteDriver.Capabilities.GetCapability(capabilityName);
                if (driverValue == null) continue;

                if (prop.PropertyType == typeof(bool?))
                {
                    bool? boolValue = GetValueOrNull<bool>(driverValue.ToString());
                    prop.SetValue(_desiredCapabilitiesdata, boolValue, null);
                }
                else if (prop.PropertyType == typeof(int?))
                {
                    int? intValue = GetValueOrNull<int>(driverValue.ToString());
                    prop.SetValue(_desiredCapabilitiesdata, intValue, null);
                }
                else
                {
                    prop.SetValue(_desiredCapabilitiesdata, driverValue.ToString(), null);
                }
            }
            InitDesiredCapabilities();
        }

        internal void TestRemoteHub(string url)
        {
            var client = new WebClient();
            string result = "OK";
            bool isOk = true;

            string response = "";
            try
            {
                response = client.DownloadString(url);
            }
            catch(Exception e)
            {
                isOk = false;
                result = "FAILED: " + e.Message;
            }
            view.SetTestResult(result, isOk);

        }
    }
}
