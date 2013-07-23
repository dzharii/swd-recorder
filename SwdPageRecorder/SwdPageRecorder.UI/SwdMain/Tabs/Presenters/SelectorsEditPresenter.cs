using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using SwdPageRecorder.WebDriver;
using SwdPageRecorder.WebDriver.JsCommand;

using System.Xml;
using System.Xml.Linq;

using System.Windows.Forms;
using System.Diagnostics;

namespace SwdPageRecorder.UI
{
    public class SelectorsEditPresenter : IPresenter<SelectorsEditView>
    {
        private SelectorsEditView view;

        public void InitWithView(SelectorsEditView view)
        {
            this.view = view;

            // Subscribe to WebDriverUtils events
            SwdBrowser.OnDriverStarted += InitControls;
            SwdBrowser.OnDriverClosed += InitControls;
            InitControls();
        }

        private void InitControls()
        {
            var isDriverAlive = SwdBrowser.IsWorking;

            view.btnHighlightWebElementInBrowser.Enabled = isDriverAlive;
            view.btnReadElementProperties.Enabled = isDriverAlive;
        }

        internal void NewWebElement()
        {
            Presenters.PageObjectDefinitionPresenter._isEditingExistingNode = false;
            Presenters.PageObjectDefinitionPresenter._currentEditingNode = null;
            view.ClearWebElementForm();
        }

        internal void CopyWebElement()
        {
            Presenters.PageObjectDefinitionPresenter._isEditingExistingNode = false;
            Presenters.PageObjectDefinitionPresenter._currentEditingNode = null;
            view.AppendWebElementNameWith("__Copy");
        }

        internal void HighLightWebElement(WebElementDefinition element)
        {
            var by = Utils.ByFromLocatorSearchMethod(element.HowToSearch, element.Locator);
            SwdBrowser.HighlightElement(by);

        }

        internal void OpenExistingNodeForEdit(TreeNode treeNode)
        {
            Presenters.PageObjectDefinitionPresenter._isEditingExistingNode = true;
            Presenters.PageObjectDefinitionPresenter._currentEditingNode = treeNode;
            var webElementFormData = treeNode.Tag as WebElementDefinition;
            view.UpdateWebElementForm(webElementFormData);
        }

        internal LocatorSearchMethod GetLocatorSearchMethod()
        {
            return view.GetLocatorSearchMethod();
        }

        internal string GetLocatorText()
        {
            return view.GetLocatorText();
        }

        internal void ReadElementProperties(WebElementDefinition element)
        {
            var by = Utils.ByFromLocatorSearchMethod(element.HowToSearch, element.Locator);
            var attributes = SwdBrowser.ReadElementAttributes(by);

            if (attributes.Count == 0) return;

            element.HtmlTag = attributes["TagName"];
            attributes.Remove("TagName");

            WebElementHtmlAttributes elementAttrs = new WebElementHtmlAttributes();

            foreach (var attrKey in attributes.Keys)
            {
                elementAttrs.Add(attrKey, attributes[attrKey]);
            }

            element.AllHtmlTagProperties = elementAttrs;

            view.UpdateElementPropertiesForm(element);
        }
    }
}
