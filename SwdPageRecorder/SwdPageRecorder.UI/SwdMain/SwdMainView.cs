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
            // InitOtherLocatorDropDown();

        }




        private void btnTestLocator_Click(object sender, EventArgs e)
        {

            presenter.TestLocators();
            presenter.UpdateTestHtmlDocumentView();

        }



        public void DisplaySearchResults(List<ResultElement> displayList)
        {
            
            lbElements.Items.Clear();
            lbElements.Items.AddRange(displayList.ToArray());
        }

        private void lbElements_DoubleClick(object sender, EventArgs e)
        {
            if (lbElements.SelectedItem != null)
            {
                var element = lbElements.SelectedItem as ResultElement;
                presenter.ShowElementInTree(element);
            }
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

        internal void AddTestHtmlNodes(TreeNode x)
        {
            tvHtmlDoc.Nodes.Clear();
            tvHtmlDoc.Nodes.Add(x);

        }



        internal TreeNode FindTreeNode(List<TravelNode> travelNodes)
        {
            var searchNodes = tvHtmlDoc.Nodes;
            TreeNode result = null;
            for (var i = 0; i < travelNodes.Count; i++)
            {
                bool isLastTravelNode = (i == travelNodes.Count - 1);

                var travelNode = travelNodes[i];
                var targetNodeIndex = -1;
                foreach (TreeNode treeNode in searchNodes)
                {
                    if (treeNode.Name == travelNode.NodeName)
                    {
                        targetNodeIndex++;

                        if (targetNodeIndex == travelNode.NodeIndex)
                        {
                            if (isLastTravelNode)
                            {
                                return treeNode;
                            }
                            else
                            {
                                searchNodes = treeNode.Nodes;
                                break;
                            }
                        }
                    }
                }
            }
            return null;
        }


        
        internal void FindAndHighlightElementInTree(List<TravelNode> travelNodes)
        {
            var htmlNode = FindTreeNode(travelNodes);
            tvHtmlDoc.SelectedNode = htmlNode;
            tvHtmlDoc.Focus();
            htmlNode.EnsureVisible();
        }




        private void tvHtmlDoc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            presenter.UpdateHtmlPropertiesForSelectedNode(e.Node);
        }

        internal void UpdateHtmlProperties(List<string> attributes)
        {
            txtHtmlNodeProperties.Text = String.Join(Environment.NewLine, attributes);
        }


        // Prevent Expand on double click
        private void tvHtmlDoc_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            presenter.HighLightElementFromNode(e.Node);
        }

        private bool _shouldPreventExpandCollapse = false;
        private DateTime _lastMouseDown = DateTime.Now;

        private void tvHtmlDoc_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = _shouldPreventExpandCollapse;
            _shouldPreventExpandCollapse = false;
        }

        private void tvHtmlDoc_MouseDown(object sender, MouseEventArgs e)
        {
            int delta = (int)DateTime.Now.Subtract(_lastMouseDown).TotalMilliseconds;
            _shouldPreventExpandCollapse = (delta < SystemInformation.DoubleClickTime);
            _lastMouseDown = DateTime.Now;
        }

        private void tvHtmlDoc_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = _shouldPreventExpandCollapse;
            _shouldPreventExpandCollapse = false;
        }
        // =====================================


        private void btnBrowser_Go_Click(object sender, EventArgs e)
        {
            presenter.SetBrowserUrl(txtBrowserUrl.Text);

        }
        
    }
}
