using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwdPageRecorder.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

using FormKeys = System.Windows.Forms.Keys;

namespace SwdPageRecorder.UI
{
    public partial class BrowserSettingsTabView : UserControl, IView
    {
        public BrowserSettingsTabPresenter Presenter {get; private set;}
        private Control[] driverControls;
                
        public BrowserSettingsTabView()
        {
            InitializeComponent();
            Presenter = Presenters.BrowserSettingsTabPresenter;
            Presenter.InitWithView(this);
                        
            HandleRemoteDriverSettingsEnabledStatus();

            driverControls = new Control[] { chkUseRemoteHub, grpRemoteConnection, ddlBrowserToStart };

            SetDesiredCapsAvailability(false);
            Presenter.InitDesiredCapabilities();


        }

        private void SetDesiredCapsAvailability(bool enabled)
        {
            grpDesiredCaps.DoInvokeAction( () => grpDesiredCaps.Enabled = enabled);
        }

        private void btnStartWebDriver_Click(object sender, EventArgs e)
        {
            var isRemoteDriver = chkUseRemoteHub.Checked;
            var startSeleniumServerIfNotStarted = chkAutomaticallyStartServer.Checked;
            var shouldMaximizeBrowserWindow = chkMaximizeBrowserWindow.Checked;

            var browserOptions = new WebDriverOptions()
            {
                BrowserName = ddlBrowserToStart.SelectedItem as string,
                IsRemote = isRemoteDriver,
                RemoteUrl = txtRemoteHubUrl.Text,
            };


            Presenter.StartNewBrowser(browserOptions, startSeleniumServerIfNotStarted, shouldMaximizeBrowserWindow); 
        }

        private void HandleRemoteDriverSettingsEnabledStatus()
        {
            grpRemoteConnection.DoInvokeAction(
                    () => grpRemoteConnection.Enabled = chkUseRemoteHub.Checked); 

            ChangeBrowsersList(chkUseRemoteHub.Checked);
        }

        private void ChangeBrowsersList(bool showAll)
        {
            var selectedItem = ddlBrowserToStart.SelectedItem;
            string previousValue = "";

            if (selectedItem != null)
            {
                previousValue = ddlBrowserToStart.SelectedItem as string;
            }

            ddlBrowserToStart.Items.Clear();

            string[] addedItems = null;
            if (showAll)
            {
                addedItems = WebDriverOptions.allWebdriverBrowsersSupported;
                ddlBrowserToStart.Items.AddRange(addedItems);
            }
            else
            {
                addedItems = WebDriverOptions.embededWebdriverBrowsersSupported;
                ddlBrowserToStart.Items.AddRange(addedItems);
            }

            int index = Array.IndexOf(addedItems, previousValue);
            index = index >= 0 ? index : 0;
            ddlBrowserToStart.SelectedIndex = index;

        }

        private void chkUseRemoteHub_CheckedChanged(object sender, EventArgs e)
        {
            HandleRemoteDriverSettingsEnabledStatus();
        }



        private void SetControlsState(string startButtonCaption, bool isEnabled)
        {
            btnStartWebDriver.DoInvokeAction(() => btnStartWebDriver.Text = startButtonCaption);

            foreach (var control in driverControls)
            {
                btnStartWebDriver.DoInvokeAction(() => control.Enabled = isEnabled);
            }
            HandleRemoteDriverSettingsEnabledStatus();
        }
        
        internal void DriverIsStopping()
        {
            SetControlsState("Start", true);
            SetDesiredCapsAvailability(false);
        }

        internal void DriverWasStarted()
        {
            SetControlsState("Stop", false);
            SetDesiredCapsAvailability(true);
        }

        internal void DisableDriverStartButton()
        {
            btnStartWebDriver.DoInvokeAction( () =>  btnStartWebDriver.Enabled = false);
        }

        internal void EnableDriverStartButton()
        {
            btnStartWebDriver.DoInvokeAction(() => btnStartWebDriver.Enabled = true);
        }

        internal void SetStatus(string status)
        {

            lblWebDriverStatus.DoInvokeAction(() => lblWebDriverStatus.Text = status);
        }

        private void btnLoadCapabilities_Click(object sender, EventArgs e)
        {
            Presenter.LoadCapabilities();
        }

        private void btnTestRemoteHub_Click(object sender, EventArgs e)
        {
            Presenter.TestRemoteHub(txtRemoteHubUrl.Text);
        }

        internal void SetTestResult(string result, bool isOk)
        {
            lblRemoteHubStatus.Text = result;
            lblRemoteHubStatus.ForeColor = (isOk) ? Color.Green : Color.Red;
        }

        internal void SetBrowserStartupSettings(WebDriverOptions browserOptions)
        {
            Action action = new Action(() =>
            {
                chkUseRemoteHub.Checked = browserOptions.IsRemote;

                var index = ddlBrowserToStart.Items.IndexOf(browserOptions.BrowserName);

                ddlBrowserToStart.SelectedIndex = index;

                txtRemoteHubUrl.Text = browserOptions.RemoteUrl;
            });

            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }

        }

        internal void ClickOnStartButton()
        {
            btnStartWebDriver.DoInvokeAction(() => btnStartWebDriver.PerformClick());
        }

        private void lnkSeleniumDownloadPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://docs.seleniumhq.org/download/");
        }

        internal void DisableMaximizeBrowserChackBox()
        {
            chkMaximizeBrowserWindow.DoInvokeAction(() =>
            {
                chkMaximizeBrowserWindow.Enabled = false;
            });
            
        }

        internal void EnableMaximizeBrowserChackBox()
        {
            chkMaximizeBrowserWindow.DoInvokeAction(() =>
            {
                chkMaximizeBrowserWindow.Enabled = true;
            });
        }
    }
}
