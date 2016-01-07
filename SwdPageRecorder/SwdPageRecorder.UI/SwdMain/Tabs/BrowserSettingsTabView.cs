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
using SwdPageRecorder.ConfigurationManagement.Profiles;

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

            Profile selectedProfile = ddlBrowserToStart.SelectedItem as Profile;


            var browserOptions = new WebDriverOptions()
            {
                BrowserProfile = selectedProfile,
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

        private void ChangeBrowsersList(bool showRemoteWebDriverProfiles)
        {

            Profile selectedItem = ddlBrowserToStart.SelectedItem as Profile;
            Profile previousValue = null;

            if (selectedItem != null)
            {
                previousValue = selectedItem;
            }

            ddlBrowserToStart.Items.Clear();

            Profile[] addedItems = null;
            if (showRemoteWebDriverProfiles)
            {
                addedItems = Presenter.GetRemoteWebdriverProfiles();
            }
            else
            {
                addedItems = Presenter.GetLocalWebdriverProfiles();
            }
            ddlBrowserToStart.Items.AddRange(addedItems);

            int index = TryFindPreviousIndex(previousValue, addedItems);

            index = index >= 0 ? index : 0;
            ddlBrowserToStart.SelectedIndex = index;
        }

        private int TryFindPreviousIndex(Profile previousValue, Profile[] addedItems)
        {
            int index = -1;
            if (previousValue == null) return index;
            if (addedItems == null) return index;

            for (var i = 0; i < addedItems.Length; i++)
            {
                if (previousValue.DisplayName != null && addedItems[i].DisplayName == previousValue.DisplayName)
                {
                    index = i;
                    break;
                }
            }

            return index;
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

        internal void SetUseRemoteHubConnection(bool useRemoteHubConnection)
        {
            chkUseRemoteHub.DoInvokeAction(() => chkUseRemoteHub.Checked = useRemoteHubConnection);
        }

        internal void SetMaximizeBrowserWindow(bool maximizeBrowserWindow)
        {
            chkMaximizeBrowserWindow.DoInvokeAction(() => chkMaximizeBrowserWindow.Checked = maximizeBrowserWindow);
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

        internal void SetRemoteHubUrl(string remoteHubUrl)
        {
            txtRemoteHubUrl.DoInvokeAction(() => txtRemoteHubUrl.Text = remoteHubUrl);
        }

        internal void SetRunSeleniumServerBatch(bool batchAutorun)
        {
            chkAutomaticallyStartServer.DoInvokeAction(() => chkAutomaticallyStartServer.Checked = batchAutorun);
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

                var index = ddlBrowserToStart.Items.IndexOf(browserOptions.BrowserProfile.DisplayName);

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
