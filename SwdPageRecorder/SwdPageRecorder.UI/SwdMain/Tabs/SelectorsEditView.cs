using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SwdPageRecorder.WebDriver;

namespace SwdPageRecorder.UI
{
    public partial class SelectorsEditView : UserControl, IView
    {
        private SelectorsEditPresenter presenter;


        const string otherLocator_Name = "Name";
        const string otherLocator_TagName = "Tag Name";
        const string otherLocator_ClassName = "Class Name";
        const string otherLocator_LinkText = "Link Text";
        const string otherLocator_PartialLinkText = "Partial Link Text";


        string[] otherLocatorListItems = new string[] 
        {
            otherLocator_Name,
            otherLocator_TagName,
            otherLocator_ClassName,
            otherLocator_LinkText,
            otherLocator_PartialLinkText,
        };



        public SelectorsEditView()
        {
            InitializeComponent();
            this.presenter = Presenters.SelectorsEditPresenter;
            presenter.InitWithView(this);
            InitOtherLocatorDropDown();

        }


        private void InitOtherLocatorDropDown()
        {
            ddlOtherLocator.Items.AddRange(otherLocatorListItems);
            ddlOtherLocator.SelectedIndex = ddlOtherLocator.FindString(otherLocator_LinkText);
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

        private void btnNewWebElement_Click(object sender, EventArgs e)
        {
            presenter.NewWebElement();
        }

        private void btnCopyWebElement_Click(object sender, EventArgs e)
        {
            presenter.CopyWebElement();
        }

        private void btnHighlightWebElementInBrowser_Click(object sender, EventArgs e)
        {
            var element = GetWebElementDefinitionFromForm();
            presenter.HighLightWebElement(element);
        }

        private void btnUpdateDeclaration_Click(object sender, EventArgs e)
        {
            var element = GetWebElementDefinitionFromForm();
            Presenters.PageObjectDefinitionPresenter.UpdatePageDefinition(element);
        }


        public WebElementDefinition GetWebElementDefinitionFromForm()
        {
            var element = new WebElementDefinition()
            {
                Name = txtWebElementName.Text,
                HowToSearch = GetLocatorSearchMethod(),
                Locator = GetLocatorText(),
                
                ReturnsCollection = chkReturnsListOfWebElements.Checked,

                // Properties
                HtmlTag = txtPropHtmlTag.Text,
                AllHtmlTagProperties = txtAllElementHtmlProps.Tag != null 
                                       ? txtAllElementHtmlProps.Tag as WebElementHtmlAttributes
                                       : new WebElementHtmlAttributes(),

                // Custom Args
                Arg1 = txtPropArg1.Text,
                Arg2 = txtPropArg2.Text,
                Arg3 = txtPropArg3.Text,

            };
            return element;
        }

        internal void UpdateElementPropertiesForm(WebElementDefinition sourceElement)
        {
            var element = sourceElement.Clone();

            txtPropHtmlTag.Text = element.HtmlTag;

            StringBuilder htmlProperties = new StringBuilder();
            foreach (KeyValuePair<string, string> item in element.AllHtmlTagProperties)
            {
                htmlProperties.AppendFormat("{0}=\"{1}\";", item.Key, item.Value);
            }

            txtAllElementHtmlProps.Text = htmlProperties.ToString();
            txtAllElementHtmlProps.Tag = element.AllHtmlTagProperties;

            txtPropArg1.Text = element.Arg1 ?? "";
            txtPropArg2.Text = element.Arg2 ?? "";
            txtPropArg3.Text = element.Arg3 ?? "";
        }
        
        
        internal void ClearWebElementForm()
        {
            txtWebElementName.Clear();
            txtHtmlId.Clear();
            txtCssSelector.Clear();
            txtXPath.Clear();
            txtOtherLocator.Clear();

            txtPropHtmlTag.Clear();
            txtAllElementHtmlProps.Clear();
            txtPropHtmlTag.Tag = null;

            txtPropArg1.Clear();
            txtPropArg2.Clear();
            txtPropArg3.Clear();

            chkReturnsListOfWebElements.Checked = false;

        }

        internal void AppendWebElementNameWith(string appendWithStr)
        {
            txtWebElementName.Text += appendWithStr;
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
                        searchMethod = LocatorSearchMethod.PartialLinkText;
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

        internal void UpdateWebElementForm(WebElementDefinition formData)
        {
            ClearWebElementForm();
            txtWebElementName.Text = formData.Name;

             // Fill with the formData
             txtCssSelector.Text = formData.CssSelector;

            // override the setting with possibly modified value
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

            chkReturnsListOfWebElements.Checked = formData.ReturnsCollection;

            UpdateElementPropertiesForm(formData);

        }

        private void btnReadElementProperties_Click(object sender, EventArgs e)
        {
            var element = GetWebElementDefinitionFromForm();
            presenter.ReadElementProperties(element);
        }

        internal void DisplayWarningMessage(string message)
        {
            MessageBox.Show(message, "Yo! (SWD Page Recorder)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
