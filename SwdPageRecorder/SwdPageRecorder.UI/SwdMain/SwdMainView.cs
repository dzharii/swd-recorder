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
            foreach (var displayItem in displayList)
            {
                lbElements.Items.Add(displayItem);
            }
        }

        private void lbElements_DoubleClick(object sender, EventArgs e)
        {
            // TODO: TEST TEST
            if (lbElements.SelectedItem != null)
            {
                var element = lbElements.SelectedItem as ResultElement;
                element.WebElement.Click();
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

        private void btnUpdateDeclaration_Click(object sender, EventArgs e)
        {

            bool isValid = true;
            if (String.IsNullOrWhiteSpace(txtWebElementName.Text))
            {
                validationError.SetError(txtWebElementName, @"Please, come up with some name");
                isValid = false;
            }


            if (!isValid) return;


            var element = new WebElementDefinition()
            {
                Name = txtWebElementName.Text,
                HowToSearch = GetLocatorSearchMethod(),
                Locator = GetLocatorText(),
            };

            presenter.UpdatePageDefinition(element);
        }

        internal IEnumerable<WebElementDefinition> GetKnownWebElements()
        {
            foreach (var item in tvWebElements.Nodes) // BUG?
            {
                yield return (item as WebElementDefinition);
            }
        }

        internal void AddToPageDefinitions(WebElementDefinition element)
        {
            var newNode = new TreeNode();
            newNode.Text = element.ToString();
            newNode.Tag = element;


            tvWebElements.Nodes[0].Nodes.Add(newNode);
            tvWebElements.Nodes[0].Expand();
            
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
            var element = e.Node.Tag as WebElementDefinition;
            presenter.HighLightWebElement(element);
            
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
            this.txtVisualSearchResult.Invoke((MethodInvoker)delegate
            {
                txtVisualSearchResult.Text = xPathAttributeValue;
            });
        }

        internal void AddTestHtmlNodes(TreeNode x)
        {
            tvHtmlDoc.Nodes.Clear();
            tvHtmlDoc.Nodes.Add(x);

        }
    }
}
