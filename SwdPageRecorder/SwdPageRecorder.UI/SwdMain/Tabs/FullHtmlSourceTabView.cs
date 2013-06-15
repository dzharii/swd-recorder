using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwdPageRecorder.UI
{
    public partial class FullHtmlSourceTabView : UserControl, IView
    {
        private FullHtmlSourceTabPresenter presenter;
        public FullHtmlSourceTabView()
        {
            InitializeComponent();

            this.presenter = Presenters.PageObjectSourceCodePresenter;
            presenter.InitWithView(this);
        }

        private void btnGetHtmlSource_Click(object sender, EventArgs e)
        {
            presenter.DisplayHtmlPageSource();
        }

        internal void FillHtmlCodeBox(string[] htmlLines)
        {
            txtHtmlPageSource.Lines = htmlLines;
        }
    }
}
