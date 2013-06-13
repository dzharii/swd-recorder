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
    public partial class BrowserSettingsTab : UserControl
    {
        public BrowserSettingsTabPresenter presenter = null;
                
        public BrowserSettingsTab()
        {
            InitializeComponent();
            presenter = new BrowserSettingsTabPresenter(this);
                        
            HandleRemoteDriverSettingsEnabledStatus();
        }



        private void btnStartWebDriver_Click(object sender, EventArgs e)
        {
            var browserOptions = new WebDriverOptions()
            {
                BrowserName = ddlBrowserToStart.SelectedItem as string,
                IsRemote = chkUseRemoteHub.Checked,
                RemoteUrl = txtRemoteHubUrl.Text,
            };

            presenter.StartNewBrowser(browserOptions); 
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

    }
}
