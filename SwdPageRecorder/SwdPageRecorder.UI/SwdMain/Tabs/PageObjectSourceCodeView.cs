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

            presenter = Presenters.FullHtmlSourceTabPresenter;
            presenter.InitWithView(this);
            presenter.InitTemplateFilesList();
            presenter.TrySelectDefaultTemplate();

        }

        private void btnGenerateSourceCode_Click(object sender, EventArgs e)
        {
            presenter.GenerateSourceCodeForPageObject();
        }

        internal void DisplayGeneratedCode(string[] code)
        {
            txtSourceCode.Lines = code;
        }

        internal void SetPageObjectFiles(string[] files)
        {
            cbCodeTemplates.Items.Clear();
            if (files.Length > 0)
            {
                cbCodeTemplates.Items.AddRange(files);
            }

        }

        internal string GetSelectedTemplateFile()
        {
            string selectedTemalateName = "";
            if (cbCodeTemplates.SelectedItem != null)
            {
                selectedTemalateName = cbCodeTemplates.SelectedItem as string;
            }
            return selectedTemalateName;
        }

        internal void WarnTemplateNeedsToBeSelected()
        {
            MessageBox.Show("Please, select a code template from the list");
        }
    }
}
