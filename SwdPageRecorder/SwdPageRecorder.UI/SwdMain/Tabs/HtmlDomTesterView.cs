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
            presenter.InitWithView(this);
        }

        private void btnTestLocator_Click(object sender, EventArgs e)
        {
            presenter.UpdateTestHtmlDocumentView();
            presenter.TestLocators();
        }

        public void DisplaySearchResults(List<ResultElement> displayList)
        {

            lbElements.Items.Clear();
            lbElements.Items.AddRange(displayList.ToArray());
        }

        internal void AddTestHtmlNodes(TreeNode x)
        {
            tvHtmlDoc.Nodes.Clear();
            tvHtmlDoc.Nodes.Add(x);

        }

        private void tvHtmlDoc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            presenter.UpdateHtmlPropertiesForSelectedNode(e.Node);
        }


        
        private void tvHtmlDoc_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            presenter.HighLightElementFromNode(e.Node);
        }

        // Prevent Expand on double click
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

        internal void UpdateHtmlProperties(List<string> attributes)
        {
            txtHtmlNodeProperties.Text = String.Join(Environment.NewLine, attributes);
        }

        private void lbElements_DoubleClick(object sender, EventArgs e)
        {
            if (lbElements.SelectedItem != null)
            {
                var element = lbElements.SelectedItem as ResultElement;
                presenter.ShowElementInTree(element);
         
            }
        }

        internal TreeNode FindTreeNode(List<TravelNode> travelNodes)
        {
            var searchNodes = tvHtmlDoc.Nodes;
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
            if (htmlNode != null)
            {
                htmlNode.EnsureVisible();
            }
            else
            {
                MessageBox.Show("Tree: Element was not found");
            }
        }

    }
}
