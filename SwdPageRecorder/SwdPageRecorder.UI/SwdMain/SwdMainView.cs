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
        }







        private void btnGenerateSourceCode_Click(object sender, EventArgs e)
        {
            presenter.GenerateSourceCodeForPageObject();
        }

        internal void DisplayGeneratedCode(string[] code)
        {
            txtSourceCode.Lines = code;
        }

        private void txtBrowserUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == FormKeys.Enter)
            {
                presenter.SetBrowserUrl(txtBrowserUrl.Text);
            }
        }

        private void btnGetHtmlSource_Click(object sender, EventArgs e)
        {
            presenter.DisplayHtmlPageSource();
        }

        internal void FillHtmlCodeBox(string[] htmlLines)
        {
            txtHtmlPageSource.Lines = htmlLines;
        }

        private void btnStartVisualSearch_Click(object sender, EventArgs e)
        {
            presenter.StartVisualSearch();
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
        
    }
}
