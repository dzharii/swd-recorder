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
using SwdPageRecorder.ConfigurationManagement.MyConfigurationMappings;
using SwdPageRecorder.ConfigurationManagement;
using SwdPageRecorder.ConfigurationManagement.Profiles;

namespace SwdPageRecorder.UI
{
    public class BrowserSettingsTabPresenter : IPresenter<BrowserSettingsTabView>
    {
        private BrowserSettingsTabView view = null;
        private DesiredCapabilitiesData _desiredCapabilitiesdata = null;

        private static MyConfigurationCollection.MyConfigEntry Config() => MyConfiguration.GetCurrent();

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
                view.DisableMaximizeBrowserChackBox();
            }
            else
            {
                view.SetStatus("Not running");
                view.EnableMaximizeBrowserChackBox();
            }
        }


        public bool wasBrowserStarted = false;
        public void StartNewBrowser(WebDriverOptions browserOptions, bool startSeleniumServerIfNotStarted, bool shouldMaximizeBrowserWindow)
        {
            if (wasBrowserStarted)
            {
                StopDriver();
            }
            else
            {
                if (startSeleniumServerIfNotStarted
                && !SeleniumServerProcess.IsRunning(browserOptions.RemoteUrl))
                {
                    Exception outException;
                    bool isOk = UIActions.PerformSlowOperation(
                                "Operation: Start local RemoteWebDriver Server",
                                () =>
                                {
                                    SeleniumServerProcess.Launch("start_selenium_server.bat");
                                    TestRemoteHub(browserOptions.RemoteUrl);
                                },
                                    out outException,
                                    null,
                                    TimeSpan.FromMinutes(2)
                                );

                    if (!isOk)
                    {
                        MyLog.Error("Failed to start local Selenium Server");
                        if (outException != null) throw outException;
                    }

                }

                StartDriver(browserOptions, shouldMaximizeBrowserWindow);
            }
        }

        public Profile[] GetLocalWebdriverProfiles()
        {
            ProfileDiscovery profileDiscovery = new ProfileDiscovery();
            Profile[] allProfiles = profileDiscovery.Discover();

            Profile[] result = allProfiles.Where(p => p.ProfileConfig.profile.canUseWithLocalWebdriver).ToArray();
            return result;
        }

        public Profile[] GetRemoteWebdriverProfiles()
        {
            ProfileDiscovery profileDiscovery = new ProfileDiscovery();
            Profile[] allProfiles = profileDiscovery.Discover();

            Profile[] result = allProfiles.Where(p => p.ProfileConfig.profile.canUseWithRemoteWebdriver).ToArray();
            return result;
        }

        internal void ConfigureView()
        {
            if (Config() == null) return;

            var appConfig = Config().application;
            if (appConfig == null) return;

            var browserSettings = Config().application.browserSettingsTab;
            if (browserSettings == null) return;

            bool? useRemoteHubConnection = browserSettings.useRemoteHubConnection;
            if (useRemoteHubConnection != null)
            {
                view.SetUseRemoteHubConnection(useRemoteHubConnection == true);
            }

            bool? maximizeBrowserWindow = browserSettings.maximizeBrowserWindow;
            if (maximizeBrowserWindow != null)
            {
                view.SetMaximizeBrowserWindow(maximizeBrowserWindow == true);
            }

            if (browserSettings.RemoteHubConnectionSettings != null) {
                ConfigureRemoteHubSettings(browserSettings.RemoteHubConnectionSettings);
            }

        }

        private void ConfigureRemoteHubSettings(MyConfigurationCollection.Remotehubconnectionsettings remoteHub)
        {

            if (remoteHub.remoteHubUrl != null)
            {
                view.SetRemoteHubUrl(remoteHub.remoteHubUrl);
            }

            bool? batchAutorun = remoteHub.runStartSeleniumServerBatWhenWebdriverIsNotAvailable;
            if (batchAutorun != null)
            {
                view.SetRunSeleniumServerBatch(batchAutorun == true);
            }
        }


        public void StartDriver(WebDriverOptions browserOptions, bool shouldMaximizeBrowserWindow)
        {

            MyLog.Write("StartDriver - Entered");

            wasBrowserStarted = false;
            
            view.DisableDriverStartButton();
            
            Exception threadException;

            bool isSuccessful =  UIActions.PerformSlowOperation(
                                "Operation: Start new WebDriver instance",
                                () =>
                                {
                                    SwdBrowser.Initialize(browserOptions);
                                    wasBrowserStarted = true;

                                    if (shouldMaximizeBrowserWindow)
                                    {
                                        SwdBrowser.Maximize();
                                    }

                                },
                                    out threadException,
                                    null,
                                    TimeSpan.FromMinutes(10)
                                );
            
            view.EnableDriverStartButton();

            if (isSuccessful)
            {
                SetDesiredCapabilities(browserOptions);
                view.DriverWasStarted();
            }
            else if (threadException != null) throw threadException;

            MyLog.Write("StartDriver - Exited");
        }

        private void SetDesiredCapabilities(WebDriverOptions browserOptions)
        {

            switch (browserOptions.BrowserProfile.ActivationBrowserName)
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
            MyLog.Write("StopDriver - Entered");
            view.DisableDriverStartButton();
            
            view.DriverIsStopping();

            Exception threadException;
            UIActions.PerformSlowOperation(
                        "Operation: Stop WebDriver instance",
                        () =>
                        {
                            Presenters.SwdMainPresenter.StopVisualSearch();
                            SwdBrowser.CloseDriver();
                        },
                            out threadException,
                            null,
                            TimeSpan.FromMinutes(10)
                        );

            if (threadException != null)
            {
                MyLog.Exception(threadException);
            }

            view.EnableDriverStartButton();
            
            wasBrowserStarted = false;
            MyLog.Write("StopDriver - Exited");
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

        public bool TestRemoteHub(string url)
        {
            string result = "OK";
            bool isOk = true;

            try
            {
                SwdBrowser.TestRemoteHub(url);
            }
            catch(Exception e)
            {
                isOk = false;
                result = "FAILED: " + e.Message;
            }
            view.SetTestResult(result, isOk);
            return isOk;
        }

        public void SetBrowserStartupSettings(WebDriverOptions browserOptions)
        {
                        
            view.SetBrowserStartupSettings(browserOptions);
        }

        public void ClickStart()
        {
            view.ClickOnStartButton();
        }
    }
}
