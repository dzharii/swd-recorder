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
using System.Threading;

namespace SwdPageRecorder.UI
{
    public partial class PageObjectDefinitionView : UserControl, IView
    {
        private PageObjectDefinitionPresenter presenter = null;
        
        public PageObjectDefinitionView()
        {
            InitializeComponent();

            presenter = Presenters.PageObjectDefinitionPresenter;
            presenter.InitWithView(this);

            // Enable DragDrop operations only for standalone window
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                tvWebElements.ItemDrag += tvWebElements_ItemDrag;
                tvWebElements.AllowDrop = true;
            }

            presenter.InitPageObjectFiles();
        }


        public void DisplayMessage(string title, string message)
        {
            MessageBox.Show(message, title);
        }

        private void tvWebElements_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (presenter.IsWebElementNode(e.Node))
            {
                presenter.OpenExistingNodeForEdit(e.Node);
            }
        }

        internal IEnumerable<WebElementDefinition> GetKnownWebElements()
        {
            foreach (var item in tvWebElements.Nodes)
            {
                yield return (item as WebElementDefinition);
            }
        }

        internal TreeNode AddToPageDefinitions(WebElementDefinition element)
        {
            var newNode = new TreeNode();
            newNode.Text = element.ToString();
            newNode.Tag = element;

            var action = (MethodInvoker)delegate
            {

                tvWebElements.Nodes[0].Nodes.Add(newNode);
                newNode.EnsureVisible();
            };

            if (tvWebElements.InvokeRequired)
            {
                tvWebElements.Invoke(action);
            }
            else
            {
                action();
            }

            return newNode;
        }

        internal void UpdateExistingPageDefinition(TreeNode existingNode, WebElementDefinition element)
        {
            var action = (MethodInvoker)delegate
            {
                existingNode.Text = element.ToString();
                existingNode.Tag = element;
                existingNode.EnsureVisible();
            };

            if (tvWebElements.InvokeRequired)
            {
                tvWebElements.Invoke(action);
            }
            else
            {
                action();
            }
        }

        internal void UpdateLastCallStat(string elapsedTime)
        {
            lblLastCallTime.Text = elapsedTime;
        }

        internal WebElementDefinition[] GetWebElementDefinitionFromTree()
        {
            var definitions = new List<WebElementDefinition>();

            foreach (var treeNode in tvWebElements.Nodes[0].Nodes)
            {
                var node = treeNode as TreeNode;
                var elementDefinition = node.Tag as WebElementDefinition;
                definitions.Add(elementDefinition);
            }

            return definitions.ToArray();
        }

        private void tvWebElements_KeyUp(object sender, KeyEventArgs e)
        {
            var selectedNode = tvWebElements.SelectedNode;
            
            if (selectedNode == null) return;
            if (! presenter.IsWebElementNode(selectedNode)) return;

            if (e.KeyValue == Convert.ToInt32(FormKeys.Delete))
            {
                presenter.ReleaseNode(selectedNode);
                selectedNode.Remove();

            }

        }

        private void tvWebElements_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode NewNode;

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                if (DestinationNode.TreeView == NewNode.TreeView)
                {
                    if (presenter.IsWebElementNode(NewNode))
                    {
                        var copiedNode = (TreeNode)NewNode.Clone();
                        DestinationNode.Parent.Nodes.Insert(DestinationNode.Index, copiedNode);
                        DestinationNode.Expand();
                        tvWebElements.SelectedNode = copiedNode;
                        //Remove Original Node
                        NewNode.Remove();
                    }
                }
            }                
        }

        void tvWebElements_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }


        private void tvWebElements_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }



        internal void SetPageObjectFiles(string[] files)
        {
            cbPageObjectFiles.Items.Clear();
            cbPageObjectFiles.Items.AddRange(files);
        }

        private void cbPageObjectFiles_TextChanged(object sender, EventArgs e)
        {
            var firstNode = tvWebElements.Nodes[0];
            var currentName = cbPageObjectFiles.Text;
            if (!String.IsNullOrWhiteSpace(currentName))
            {
                firstNode.Text = currentName;
            }
            else
            {
                firstNode.Text = "No Name";
            }
        }
    }
}
