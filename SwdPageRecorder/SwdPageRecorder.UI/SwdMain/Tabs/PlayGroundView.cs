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
    public partial class PlayGroundView : UserControl, IView
    {
        private PlayGroundPresenter presenter;


        public PlayGroundView()
        {
            InitializeComponent();


            this.presenter = Presenters.PlayGroundPresenter;
            presenter.InitWithView(this);

            txtJavaScriptCode.Language = FastColoredTextBoxNS.Language.JS;
            
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


        private void btnRunScript_Click(object sender, EventArgs e)
        {
            var code = txtJavaScriptCode.Text;
            presenter.RunScript(code);
        }



        internal void AppendConsole(string text)
        {
            txtConsole.AppendText(text);
        }
    }
}
