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

using SwdPageRecorder.UI.FeaturesAndWorkarounds;

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
            grpDesiredCaps.Enabled = enabled;
        }

        private void btnStartWebDriver_Click(object sender, EventArgs e)
        {
            var browserOptions = new WebDriverOptions()
            {
                BrowserName = ddlBrowserToStart.SelectedItem as string,
                IsRemote = chkUseRemoteHub.Checked,
                RemoteUrl = txtRemoteHubUrl.Text,
            };

            Presenter.StartNewBrowser(browserOptions); 
        }

        private void HandleRemoteDriverSettingsEnabledStatus()
        {
            if (chkUseRemoteHub.Checked)
            {
                grpRemoteConnection.Enabled = true;
            }
            else
            {
                grpRemoteConnection.Enabled = false;
            }

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
            btnStartWebDriver.Text = startButtonCaption;

            foreach (var control in driverControls)
            {
                control.Enabled = isEnabled;
            }
            HandleRemoteDriverSettingsEnabledStatus();

        }
        
        internal void DriverWasStopped()
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
            btnStartWebDriver.Enabled = false;
        }

        internal void EnableDriverStartButton()
        {
            btnStartWebDriver.Enabled = true;
        }

        internal void SetStatus(string status)
        {
            lblWebDriverStatus.Text = status;
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
    }
}
