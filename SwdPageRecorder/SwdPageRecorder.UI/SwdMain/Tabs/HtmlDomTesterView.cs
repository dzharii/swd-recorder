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
    public partial class HtmlDomTesterView : UserControl, IView
    {
        private HtmlDomTesterPresenter presenter;
        public HtmlDomTesterView()
        {
            InitializeComponent();
            this.presenter = Presenters.HtmlDomTesterPresenter;
            presenter.InitView(this);
        }
    }
}
