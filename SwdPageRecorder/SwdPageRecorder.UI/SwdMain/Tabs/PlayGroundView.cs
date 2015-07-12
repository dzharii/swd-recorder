using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenQA.Selenium;
using SwdPageRecorder.WebDriver;

namespace SwdPageRecorder.UI
{

    delegate void SetTextCallback(string text);
    public partial class PlayGroundView : UserControl, IView
    {
        private PlayGroundPresenter presenter;
        private System.ComponentModel.BackgroundWorker runScriptBackgroundWorker;
        public PlayGroundView()
        {
            InitializeComponent();


            this.presenter = Presenters.PlayGroundPresenter;
            presenter.InitWithView(this);

            txtJavaScriptCode.Language = FastColoredTextBoxNS.Language.JS;
            // https://msdn.microsoft.com/en-us/library/cc221403%28v=vs.95%29.aspx
            this.runScriptBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.runScriptBackgroundWorker.DoWork +=
                new DoWorkEventHandler(runScriptBackgroundWorker_DoWork);
            // this.runScriptBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorkerExample_ProgressChanged);
            this.runScriptBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(runScriptBackgroundWorker_RunWorkerCompleted);

            presenter.InitiCodeEditor();

            txtJavaScriptCode.Text =
@"// WebDriver Playground enables you to operate the WebElements at runtime. 
// Go to any page and define any web element into PageObject tree on the right side. 
// For instance, you have declared a text field with name “txtLogin”. 
// Now you can write the following JavaScript to manipulate the web element: 
// 
//      txtLogin.Clear()
//      txtLogin.SendKeys(""Hello World"")
// 
// WebDriver Playground is in ALPHA quality. The following classes supported: 
// PageObject web elements, (IWebElement), driver (IWebDriver), By, Keys, Actions.

driver.Navigate().GoToUrl(""https://github.com/dzharii/swd-recorder"");
driver.GetScreenshot().SaveAsFile(""Screenshots\\mywebpagetest.png"", ImageFormat.Png); // See <SwdRecorder.exe-folder>\Screenshots
";

        }

        private void percentageProgress_ValueChanged(int oldValue, int newValue)
        {
            // runScriptBackgroundWorker.ReportProgress(newValue);
            // progressBar1.Value = e.ProgressPercentage;
        }
        private void runScriptBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker.CancellationPending == true) return;
            presenter.RunScript(e.Argument.ToString());
        }

        private void runScriptBackgroundWorker_RunWorkerCompleted(object sender,
            RunWorkerCompletedEventArgs e)
        {
            Presenters.SwdMainPresenter.DisplayLoadingIndicator(false);
            btnRunScript.Enabled = true;
        }

        private void btnRunScript_Click(object sender, EventArgs e)
        {
            if (runScriptBackgroundWorker.IsBusy != true)
            {
                btnRunScript.Enabled = false;
                var code = txtJavaScriptCode.Text;
                Presenters.SwdMainPresenter.DisplayLoadingIndicator(true);
                runScriptBackgroundWorker.RunWorkerAsync(code);
            }
        }
        internal void AppendConsole(string text)
        {
            txtConsole.DoInvokeAction(() => txtConsole.AppendText(text));
        }
    }
}
