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


        public SwdMainView()
        {
            InitializeComponent();
            presenter = new SwdMainPresenter(this);
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
    }
}
