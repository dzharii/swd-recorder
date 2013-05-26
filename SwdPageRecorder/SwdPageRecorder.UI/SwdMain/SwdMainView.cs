using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


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



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello!");
        }

        private void btnStartWebDriver_Click(object sender, EventArgs e)
        {
            presenter.StartNewBrowser();            

        }

        private void btnTestLocator_Click(object sender, EventArgs e)
        {

            presenter.TestLocators();

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
    }
}
