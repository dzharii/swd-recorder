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
    public class PageObjectDefinitionPresenter
    {
        private PageObjectDefinition view;
        public bool _isEditingExistingNode = false;
        public TreeNode _currentEditingNode = null;


        public void InitView(PageObjectDefinition view)
        {

            this.view = view;
        }


        internal void UpdatePageDefinition(WebElementDefinition element)
        {
            UpdatePageDefinition(element, false);
        }

        internal void UpdatePageDefinition(WebElementDefinition element, bool forceAddNew)
        {

            if (forceAddNew)
            {
                view.AddToPageDefinitions(element);
                return;
            }

            if (_isEditingExistingNode)
            {
                view.UpdateExistingPageDefinition(_currentEditingNode, element);
            }
            else
            {
                _isEditingExistingNode = true;
                _currentEditingNode = view.AddToPageDefinitions(element);
            }
        }


        internal void OpenExistingNodeForEdit(TreeNode treeNode)
        {
            Presenters.SwdMainPresenter.OpenExistingNodeForEdit(treeNode);
        }
    }
}
