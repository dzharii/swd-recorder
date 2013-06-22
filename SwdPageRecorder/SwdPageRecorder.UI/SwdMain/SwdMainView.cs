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
    public partial class SwdMainView : Form, IView
    {
        private SwdMainPresenter presenter = null;
        
        public SwdMainView()
        {
            InitializeComponent();
            presenter = Presenters.SwdMainPresenter;
            presenter.InitView(this);
            presenter.InitControls();
        }


        private void txtBrowserUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == FormKeys.Enter)
            {
                presenter.SetBrowserUrl(txtBrowserUrl.Text);
            }
        }


        private void btnStartVisualSearch_Click(object sender, EventArgs e)
        {
            presenter.ChangeVisualSearchRunningState();
        }



        internal void UpdateVisualSearchResult(string xPathAttributeValue)
        {

            var action = (MethodInvoker)delegate
            {
                txtVisualSearchResult.Text = xPathAttributeValue;
            };

            if (txtVisualSearchResult.InvokeRequired)
            {
                txtVisualSearchResult.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void btnBrowser_Go_Click(object sender, EventArgs e)
        {
            presenter.SetBrowserUrl(txtBrowserUrl.Text);

        }


        internal void VisualSearchStopped()
        {
            btnStartVisualSearch.Text = "Start";
        }

        internal void VisuaSearchStarted()
        {
            btnStartVisualSearch.Text = "Stop";
        }
    }
}
