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
    public partial class JavaScriptEditorView : UserControl, IView
    {
        private JavascriptEditorTabPresenter presenter;

        

        public JavaScriptEditorView()
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            InitializeComponent();

            
            this.presenter = Presenters.JavascriptEditorTabPresenter;
            presenter.InitWithView(this);

            txtJavaScriptEditor.Language = FastColoredTextBoxNS.Language.JS;

            
            StringBuilder warningText = new StringBuilder();

            warningText.AppendLine("var myString = ");
            warningText.AppendLine("        ['JavaScript Snippets is in alpha-quality. The general functionality is working,',");
            warningText.AppendLine("         'but I do not grantee the stable work.  Please make sure you always save your ',");
            warningText.AppendLine("         'page objects in order to avoid data lose in case of possible application crash.',");
            warningText.AppendLine("         'Do not afraid to use it ;). Feedback is always appreciated:',");
            warningText.AppendLine("         ' https://github.com/dzhariy/swd-recorder/issues?state=open ',");
            warningText.AppendLine("        ].join('\\n');");
            warningText.AppendLine(" ");
            warningText.AppendLine("return myString;");

            txtJavaScriptEditor.Text = warningText.ToString();
        }


        internal void UpdateTree(TreeNode root)
        {
            tvJavaScriptFiels.Nodes.Clear();
            tvJavaScriptFiels.Nodes.Add(root);
        }

        internal void ExpandTree()
        {
            tvJavaScriptFiels.ExpandAll();
        }

        private void tvJavaScriptFiels_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            presenter.TryOpenJavaScriptFile(e.Node);
        }

        internal void UpdateFileEditor(string fileContent)
        {
            txtJavaScriptEditor.Clear();
            txtJavaScriptEditor.Text = fileContent;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            
            presenter.RunScript();
        }

        internal string GetJavaScriptCodeFromEditor()
        {
            return txtJavaScriptEditor.Text;
        }

        internal void AppendConsole(string consoleOut)
        {
            txtOutputConsole.AppendText(consoleOut + "\r\n");
        }

        internal void SetControlsToEnabledState(bool isEnabled)
        {
            groupJsFilesTree.Enabled = isEnabled;
            groupCode.Enabled = isEnabled;
            groupConsoleOutput.Enabled = isEnabled;
        }

        private void btnShowFiles_Click(object sender, EventArgs e)
        {
            presenter.ShowSnippetsFolder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            presenter.ReloadJavaScriptFilesTree();
        }
    }
}
