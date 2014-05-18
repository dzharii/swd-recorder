using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.ClearScript;
using Microsoft.ClearScript.Windows;
using OpenQA.Selenium;
using SwdPageRecorder.WebDriver;

using SwdPageRecorder.WebDriver.OpenQA.Selenium.Support.PageObjects;

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

        }


        private void btnRunScript_Click(object sender, EventArgs e)
        {
            using (var engine = new JScriptEngine())
            {
                var code = txtJavaScriptCode.Text;

                engine.AddHostObject("driver", SwdBrowser.GetDriver());

                var uiPageObject = Presenters.PageObjectDefinitionPresenter.GetWebElementDefinitionFromTree();

                foreach (var element in uiPageObject.Items)
                {
                    IWebElement proxyElement = SwdBrowser.CreateWebElementProxy(element);
                    string name = element.Name;
                    engine.AddHostObject(name, proxyElement);
                }

                var result = engine.Evaluate(code) ?? "(none)";

                txtConsole.AppendText(result.ToString() + "\r\n");

            }
        }


    }
}
