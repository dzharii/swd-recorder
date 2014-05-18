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
            presenter.UpdatePageTreeFromFileName();
            presenter.UpdateControlsState();
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
                presenter.ShowPropertiesForNode(e.Node);
            }
        }

        private void tvWebElements_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (presenter.IsWebElementNode(e.Node))
            {
                presenter.ShowPropertiesForNode(e.Node);
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
            lblLastCallTime.DoInvokeAction(() =>
            {
                lblLastCallTime.Text = elapsedTime;
            });
        }

        internal SwdPageObject GetWebElementDefinitionFromTree()
        {
            var pageObject = new SwdPageObject();

            string pageObjectName = "MyPage";
            
            if (tvWebElements.Nodes.Count > 0)
            {
                string rootNodeText = tvWebElements.Nodes[0].Text;

                pageObjectName = String.IsNullOrWhiteSpace(rootNodeText) 
                                        ? pageObjectName 
                                        : rootNodeText;
            }

            pageObject.PageObjectName = pageObjectName;

            foreach (var treeNode in tvWebElements.Nodes[0].Nodes)
            {
                var node = treeNode as TreeNode;
                var elementDefinition = node.Tag as WebElementDefinition;
                pageObject.Items.Add(elementDefinition);
            }

            return pageObject;
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
                presenter.NotifyOnChanges();

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
            cbPageObjectFiles.DoInvokeAction(() =>
            {
                    cbPageObjectFiles.Items.Clear();
                    cbPageObjectFiles.Items.AddRange(files);
            });
        }

        public void UpdatePageTreeFromFileName()
        {
            cbPageObjectFiles.DoInvokeAction(() =>
            {
                var firstNode = tvWebElements.Nodes[0];
                var currentName = cbPageObjectFiles.Text;
                if (!String.IsNullOrWhiteSpace(currentName))
                {
                    firstNode.Text = currentName;
                    presenter.NotifyOnChanges();
                }
                else
                {
                    firstNode.Text = "No Name";
                }
            });
        }

        private void cbPageObjectFiles_TextChanged(object sender, EventArgs e)
        {
            
            presenter.UpdatePageTreeFromFileName();
        }

        private void btnSavePageObject_Click(object sender, EventArgs e)
        {
            presenter.SavePageObject(); 
        }



        internal bool ConfirmFileOverwrite(string targetFullPath)
        {
            string text = String.Format("File: {0}\r\nalready exists.\r\nDo you want to replace it?", targetFullPath);
            string caption = @"Confirm Save As";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            return MessageBox.Show(text, caption, buttons) == DialogResult.Yes;
        }

        internal void NotifyOnSaveError(string errorMessage, string targetFile)
        {
            string text = String.Format("An error had occurred during saving the Page Object.\r\nFile: {0}\r\nError:{1}", targetFile, errorMessage);
            string caption = "Save - Error";
            MessageBox.Show(text, caption);
        }

        private void cbPageObjectFiles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbPageObjectFiles.DoInvokeAction(() =>
            {
                string selectedItemText = cbPageObjectFiles.SelectedItem as string;
                presenter.LoadPageObject(selectedItemText);
            });
        }


        internal void NotifyOnLoadError(string errorMessage, string targetFile)
        {
            string text = String.Format("An error had occurred during loading the Page Object.\r\nFile: {0}\r\nError:{1}", targetFile, errorMessage);
            string caption = "Load - Error";
            MessageBox.Show(text, caption);

        }

        internal void ClearPageObjectTree()
        {
            tvWebElements.DoInvokeAction(() =>
            {
                tvWebElements.Nodes[0].Nodes.Clear();
                UpdatePageTreeFromFileName();
            });
        }

        private void btnNewPageObject_Click(object sender, EventArgs e)
        {
            cbPageObjectFiles.DoInvokeAction(() =>
            {
                cbPageObjectFiles.Text = "";
                ClearPageObjectTree();
                presenter.NotifyOnChanges();
            });
        }

        private void btnViewInWindowsExplorer_Click(object sender, EventArgs e)
        {
            presenter.OpenDefaultFolderInWindowsExplorer();
        }


        internal string GetPageObjectName()
        {
            string pageObjectName = "";
            cbPageObjectFiles.DoInvokeAction(() =>
            {
                pageObjectName = cbPageObjectFiles.Text;
            });

            return pageObjectName;
        }
    }
}
