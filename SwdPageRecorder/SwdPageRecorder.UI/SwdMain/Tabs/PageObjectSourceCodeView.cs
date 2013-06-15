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
    public partial class PageObjectSourceCodeView : UserControl, IView
    {
        private PageObjectSourceCodePresenter presenter;
        public PageObjectSourceCodeView()
        {
            InitializeComponent();

            this.presenter = Presenters.FullHtmlSourceTabPresenter;
            this.presenter.InitWithView(this);
        }

        private void btnGenerateSourceCode_Click(object sender, EventArgs e)
        {
            presenter.GenerateSourceCodeForPageObject();
        }

        internal void DisplayGeneratedCode(string[] code)
        {
            txtSourceCode.Lines = code;
        }
    }
}
