using System;
using System.Drawing;
using System.Windows.Forms;
using SwdPageRecorder.WebDriver;

namespace SwdPageRecorder.UI
{
    public partial class BrowserSettingsTabView : UserControl, IView
    {
        public BrowserSettingsTabPresenter Presenter {get; private set;}
        private Control[] driverControls;
                
        public BrowserSettingsTabView()
        {
            InitializeComponent();
            Presenter = MyPresenters.BrowserSettingsTabPresenter;
            Presenter.InitWithView(this);
                        
            HandleRemoteDriverSettingsEnabledStatus();

            driverControls = new Control[] { ddlBrowserToStart };

            SetDesiredCapsAvailability(false);
            Presenter.InitDesiredCapabilities();


        }

        private void SetDesiredCapsAvailability(bool enabled)
        {
            grpDesiredCaps.DoInvokeAction( () => grpDesiredCaps.Enabled = enabled);
        }

        private void btnStartWebDriver_Click(object sender, EventArgs e)
        {
            var shouldMaximizeBrowserWindow = chkMaximizeBrowserWindow.Checked;

            var browserOptions = new WebDriverOptions()
            {
                BrowserName = ddlBrowserToStart.SelectedItem as string,
                RemoteUrl = txtRemoteHubUrl.Text,
            };

            
            Presenter.StartNewBrowser(browserOptions, shouldMaximizeBrowserWindow); 
        }

        private void HandleRemoteDriverSettingsEnabledStatus()
        {
            ChangeBrowsersList();
        }

        private void ChangeBrowsersList()
        {
            var selectedItem = ddlBrowserToStart.SelectedItem;
            string previousValue = "";

            if (selectedItem != null)
            {
                previousValue = ddlBrowserToStart.SelectedItem as string;
            }

            ddlBrowserToStart.Items.Clear();

            string[] addedItems = null;

            addedItems = WebDriverOptions.allWebdriverBrowsersSupported;
            ddlBrowserToStart.Items.AddRange(addedItems);

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
            lblRemoteHubStatus.DoInvokeAction(() =>
            {
                lblRemoteHubStatus.Text = result;
                lblRemoteHubStatus.ForeColor = (isOk) ? Color.Green : Color.Red;
            });
        }

        internal void SetBrowserStartupSettings(WebDriverOptions browserOptions)
        {
            Action action = new Action(() =>
            {
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
