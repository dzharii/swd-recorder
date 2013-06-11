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
    public partial class SwdMainView : Form
    {


        public SwdMainPresenter presenter = null;

        const string otherLocator_Name            = "Name";
        const string otherLocator_TagName         = "Tag Name";
        const string otherLocator_ClassName       = "Class Name";
        const string otherLocator_LinkText        = "Link Text";
        const string otherLocator_PartialLinkText = "Partial Link Text";


        string[] otherLocatorListItems = new string[] 
        {
            otherLocator_Name,
            otherLocator_TagName,
            otherLocator_ClassName,
            otherLocator_LinkText,
            otherLocator_PartialLinkText,
        };





        //private System.Windows.Forms.PropertyGrid OptionsPropertyGrid;
        // http://msdn.microsoft.com/en-us/library/aa302326.aspx

        public SwdMainView()
        {
            InitializeComponent();
            presenter = new SwdMainPresenter(this);

            ddlOtherLocator.Items.AddRange(otherLocatorListItems);
            ddlOtherLocator.SelectedIndex = ddlOtherLocator.FindString(otherLocator_LinkText);

            HandleRemoteDriverSettingsEnabledStatus();


        }

        private void ChangeBrowsersList(bool showAll)
        {
            var selectedItem = ddlBrowserToStart.SelectedItem;
            string previousValue = "";
            
            if (selectedItem != null)
            {
                previousValue = ddlBrowserToStart.SelectedItem as string;
            }

            ddlBrowserToStart.Items.Clear();

            string[] addedItems = null;
            if (showAll)
            {
                addedItems = WebDriverOptions.allWebdriverBrowsersSupported;
                ddlBrowserToStart.Items.AddRange(addedItems);
            }
            else
            {
                addedItems = WebDriverOptions.embededWebdriverBrowsersSupported;
                ddlBrowserToStart.Items.AddRange(addedItems);
            }

            int index = Array.IndexOf(addedItems, previousValue);
            index = index >= 0 ? index : 0;
            ddlBrowserToStart.SelectedIndex = index;

        }



        private void btnStartWebDriver_Click(object sender, EventArgs e)
        {
            var browserOptions = new WebDriverOptions()
            {
                BrowserName = ddlBrowserToStart.SelectedItem as string,
                IsRemote = chkUseRemoteHub.Checked,
                RemoteUrl = txtRemoteHubUrl.Text,
            };

            presenter.StartNewBrowser(browserOptions);   
            

        }

        private void btnTestLocator_Click(object sender, EventArgs e)
        {

            presenter.TestLocators();
            presenter.UpdateTestHtmlDocumentView();

        }

        internal LocatorSearchMethod GetLocatorSearchMethod()
        {
            var searchMethod = LocatorSearchMethod.NotSet;

            if (rbtnHtmlId.Checked)
            {
                searchMethod = LocatorSearchMethod.Id;
            }
            else if (rbtnCssSelector.Checked)
            {
                searchMethod = LocatorSearchMethod.CssSelector;
            }
            else if (rbtnXPath.Checked)
            {
                searchMethod = LocatorSearchMethod.XPath;
            }
            else if (rbtnOtherLocator.Checked)
            {
                switch (ddlOtherLocator.SelectedItem as string)
                {
                    case otherLocator_Name: 
                        searchMethod = LocatorSearchMethod.Name;
                        break;
                    case otherLocator_TagName: 
                        searchMethod = LocatorSearchMethod.TagName;
                        break;
                    case otherLocator_ClassName: 
                        searchMethod = LocatorSearchMethod.ClassName;
                        break;
                    case otherLocator_LinkText: 
                        searchMethod = LocatorSearchMethod.LinkText;
                        break;
                    case otherLocator_PartialLinkText: 
                        searchMethod = LocatorSearchMethod.PartialLinkText ;
                        break;
                }

            }
            return searchMethod;
        }

        public string GetLocatorText()
        {
            string locatorText = "";
            switch (GetLocatorSearchMethod())
            {
                case LocatorSearchMethod.Id:
                    locatorText = txtHtmlId.Text;
                    break;
                case LocatorSearchMethod.CssSelector:
                    locatorText = txtCssSelector.Text;
                    break;
                case LocatorSearchMethod.XPath:
                    locatorText = txtXPath.Text;
                    break;
                default:
                    locatorText = txtOtherLocator.Text;
                    break;

            }
            return locatorText;
        }

        public void DisplaySearchResults(List<ResultElement> displayList)
        {
            
            lbElements.Items.Clear();
            lbElements.Items.AddRange(displayList.ToArray());
        }

        private void lbElements_DoubleClick(object sender, EventArgs e)
        {
            // TODO: TEST TEST
            if (lbElements.SelectedItem != null)
            {
                var element = lbElements.SelectedItem as ResultElement;
                presenter.ShowElementInTree(element);
            }
        }

        private void ddlOtherLocator_Click(object sender, EventArgs e)
        {
            rbtnOtherLocator.Checked = true;
        }

        private void txtOtherLocator_Enter(object sender, EventArgs e)
        {
            rbtnOtherLocator.Checked = true;
        }

        private void txtXPath_Enter(object sender, EventArgs e)
        {
            rbtnXPath.Checked = true;
        }

        private void txtCssSelector_Enter(object sender, EventArgs e)
        {
            rbtnCssSelector.Checked = true;
        }

        private void txtHtmlId_Enter(object sender, EventArgs e)
        {
            rbtnHtmlId.Checked = true;
        }


        private WebElementDefinition GetWebElementDefinitionFromForm()
        {
            var element = new WebElementDefinition()
            {
                Name = txtWebElementName.Text,
                HowToSearch = GetLocatorSearchMethod(),
                Locator = GetLocatorText(),
            };
            return element;
        }

        private void btnUpdateDeclaration_Click(object sender, EventArgs e)
        {

            bool isValid = true;
            if (String.IsNullOrWhiteSpace(txtWebElementName.Text))
            {
                validationError.SetError(txtWebElementName, @"Please, come up with some name");
                isValid = false;
            }

            if (!isValid) return;

            var element = GetWebElementDefinitionFromForm();

            presenter.UpdatePageDefinition(element);
        }

        internal IEnumerable<WebElementDefinition> GetKnownWebElements()
        {
            foreach (var item in tvWebElements.Nodes) // BUG?
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


        private void HandleRemoteDriverSettingsEnabledStatus()
        {
            if (chkUseRemoteHub.Checked)
            {
                grpRemoteConnection.Enabled = true;
            }
            else
            {
                grpRemoteConnection.Enabled = false;
            }

            ChangeBrowsersList(chkUseRemoteHub.Checked);
        }
        
        private void chkUseRemoteHub_CheckedChanged(object sender, EventArgs e)
        {
            HandleRemoteDriverSettingsEnabledStatus();
            
        }

        private void tvWebElements_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            presenter.OpenExistingNodeForEdit(e.Node);
        }

        private void btnGenerateSourceCode_Click(object sender, EventArgs e)
        {
            presenter.GenerateSourceCodeForPageObject();
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

        internal void UpdateLastCallStat(string elapsedTime)
        {
            lblLastCallTime.Text = elapsedTime;
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

        private void btnHighlightWebElementInBrowser_Click(object sender, EventArgs e)
        {
            var element = GetWebElementDefinitionFromForm();
            presenter.HighLightWebElement(element);
        }



        internal void UpdateWebElementForm(WebElementDefinition formData)
        {
            ClearWebElementForm();
            txtWebElementName.Text = formData.Name;



            switch (formData.HowToSearch)
            {
                case LocatorSearchMethod.Id:
                    txtHtmlId.Text = formData.Locator;
                    rbtnHtmlId.Checked = true;
                    break;
                case LocatorSearchMethod.CssSelector:
                    txtCssSelector.Text = formData.Locator;
                    rbtnCssSelector.Checked = true;
                    break;
                case LocatorSearchMethod.XPath:
                    txtXPath.Text = formData.Locator;
                    rbtnXPath.Checked = true;
                    break;
                default:
                    string itemToSelect = "";
                    switch (formData.HowToSearch)
                    {
                        case LocatorSearchMethod.Name: itemToSelect = otherLocator_Name; break;
                        case LocatorSearchMethod.TagName: itemToSelect = otherLocator_TagName; break;
                        case LocatorSearchMethod.ClassName: itemToSelect = otherLocator_ClassName; break;
                        case LocatorSearchMethod.LinkText: itemToSelect = otherLocator_LinkText; break;
                        case LocatorSearchMethod.PartialLinkText: itemToSelect = otherLocator_PartialLinkText; break;
                    }
                    if (!String.IsNullOrEmpty(itemToSelect))
                    {
                        txtOtherLocator.Text = formData.Locator;
                        rbtnOtherLocator.Checked = true;
                        ddlOtherLocator.SelectedIndex = Array.IndexOf(otherLocatorListItems, itemToSelect);
                    }
                    break;
            }
        }

        private void btnNewWebElement_Click(object sender, EventArgs e)
        {
            presenter.NewWebElement();
        }

        internal void ClearWebElementForm()
        {
            txtWebElementName.Clear();
            txtHtmlId.Clear();
            txtCssSelector.Clear();
            txtXPath.Clear();
            txtOtherLocator.Clear();
        }

        private void btnCopyWebElement_Click(object sender, EventArgs e)
        {
            presenter.CopyWebElement();
        }

        internal void AppendWebElementNameWith(string appendWithStr)
        {
            txtWebElementName.Text += appendWithStr;
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
    }
}
