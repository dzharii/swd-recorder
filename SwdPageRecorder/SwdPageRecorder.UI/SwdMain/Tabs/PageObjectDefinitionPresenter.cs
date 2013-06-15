using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using System.ComponentModel.DataAnnotations;

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
    public class PageObjectDefinitionPresenter : IPresenter<PageObjectDefinitionView>
    {
        private PageObjectDefinitionView view;
        public bool _isEditingExistingNode = false;
        public TreeNode _currentEditingNode = null;


        public void InitWithView(PageObjectDefinitionView view)
        {

            this.view = view;
        }



        internal void UpdatePageDefinition(WebElementDefinition element)
        {
            UpdatePageDefinition(element, false);
        }

        internal void UpdatePageDefinition(WebElementDefinition element, bool forceAddNew)
        {

            var results = new List<ValidationResult>();
            var context = new ValidationContext(element, null, null);

            bool isValid = Validator.TryValidateObject(element, context, results, true);
            if (!isValid)
            {
                var validationMessage = String.Join("\n", results.Select(t => String.Format("- {0}", t.ErrorMessage)));
                view.DisplayMessage("Validation Error", validationMessage);
                return;
            }

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
            Presenters.SelectorsEditPresenter.OpenExistingNodeForEdit(treeNode);
        }

        internal void UpdateLastCallStat(string statText)
        {
            view.UpdateLastCallStat(statText);
        }

        internal WebElementDefinition[] GetWebElementDefinitionFromTree()
        {
            return view.GetWebElementDefinitionFromTree();
        }
    }
}
