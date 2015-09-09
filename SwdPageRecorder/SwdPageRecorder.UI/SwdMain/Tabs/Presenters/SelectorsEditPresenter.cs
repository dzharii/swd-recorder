using System;
using System.Collections.Generic;
using SwdPageRecorder.WebDriver;
using System.Windows.Forms;

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

        public bool IsValidForm()
        {
            bool isValid = true;
            var element = view.GetWebElementDefinitionFromForm();
            if (string.IsNullOrWhiteSpace(element.Locator))
            {
                string message = "Locator's value cannot be empty.\n\n" + 
                                 "Please, type the Locator value or load the existing element\n" + 
                                 "from the PageObject pane (double-click) before attempting\n" + 
                                 "to Highlight or Test the locator.";

                view.DisplayWarningMessage(message);
                isValid = false;
            }
            return isValid;
        }

        internal void NewWebElement()
        {
            MyPresenters.PageObjectDefinitionPresenter._isEditingExistingNode = false;
            MyPresenters.PageObjectDefinitionPresenter._currentEditingNode = null;
            view.ClearWebElementForm();
        }

        internal void CopyWebElement()
        {
            MyPresenters.PageObjectDefinitionPresenter._isEditingExistingNode = false;
            MyPresenters.PageObjectDefinitionPresenter._currentEditingNode = null;
            view.AppendWebElementNameWith("__Copy");
        }

        internal void HighLightWebElement(WebElementDefinition element)
        {
            if (!IsValidForm()) return;

            var by = SwdBrowser.ConvertLocatorSearchMethodToBy(element.HowToSearch, element.Locator);
            SwdBrowser.HighlightElement(by);

        }

        internal void OpenExistingNodeForEdit(TreeNode treeNode)
        {
            MyPresenters.PageObjectDefinitionPresenter._isEditingExistingNode = true;
            MyPresenters.PageObjectDefinitionPresenter._currentEditingNode = treeNode;
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

            UpdateWebElementWithAdditionalProperties(element);
            view.UpdateElementPropertiesForm(element);
        }

        public void UpdateWebElementWithAdditionalProperties(WebElementDefinition element)
        {
            var by = SwdBrowser.ConvertLocatorSearchMethodToBy(element.HowToSearch, element.Locator);
            var attributes = new Dictionary<string, string>();
            try
            {
                attributes = SwdBrowser.ReadElementAttributes(by);
            }
            catch(Exception e)
            {
                string errorMsg = string.Format(
                                "UpdateWebElementWithAdditionalProperties:\n" +
                                "Failed to find element: How={0};   Locator={1}\n" + 
                                "With exception:\n {2}"
                                , element.HowToSearch.ToString()
                                , element.Locator.ToString()
                                , e.Message
                                
                                );
                MyLog.Error(errorMsg);
            }
                

            if (attributes.Count == 0) return;

            element.HtmlTag = attributes["TagName"];
            attributes.Remove("TagName");

            WebElementHtmlAttributes elementAttrs = new WebElementHtmlAttributes();

            foreach (var attrKey in attributes.Keys)
            {
                elementAttrs.Add(attrKey, attributes[attrKey]);
            }

            element.AllHtmlTagProperties = elementAttrs;
        }
    }
}
