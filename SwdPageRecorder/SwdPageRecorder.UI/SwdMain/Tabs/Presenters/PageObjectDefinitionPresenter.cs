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

using System.IO;
using System.Xml.Serialization;

using System.ComponentModel;

namespace SwdPageRecorder.UI
{
    public class PageObjectDefinitionPresenter : IPresenter<PageObjectDefinitionView>
    {

        const string PoxFileExtension = ".pox";
        
        private PageObjectDefinitionView view;
        public bool _isEditingExistingNode = false;
        public TreeNode _currentEditingNode = null;

        public bool IsDirty { get; private set; }

        public event Action OnPageObjectTreeChanged = null;

        public void RaisePageObjectTreeChanged()
        {
            if (OnPageObjectTreeChanged != null)
            {
                OnPageObjectTreeChanged();
            }
        }

        public PageObjectDefinitionPresenter()
        {
            IsDirty = false;
        }

        private string lastSavedFilePath = String.Empty;


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
                NotifyOnChanges();
                return;
            }

            if (_isEditingExistingNode)
            {
                view.UpdateExistingPageDefinition(_currentEditingNode, element);
                NotifyOnChanges();
            }
            else
            {
                _isEditingExistingNode = true;
                _currentEditingNode = view.AddToPageDefinitions(element);
                NotifyOnChanges();
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

        internal SwdPageObject GetWebElementDefinitionFromTree()
        {
            return view.GetWebElementDefinitionFromTree();
        }

        internal bool IsWebElementNode(TreeNode treeNode)
        {
            return (treeNode.Tag as WebElementDefinition) != null;
        }

        internal void ReleaseNode(TreeNode selectedNode)
        {
            _isEditingExistingNode = false;
            _currentEditingNode = null;

        }

        public string GetDefaultPageObjectsDirectory()
        {
            string fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string theDirectory = Path.GetDirectoryName(fullPath);
            return theDirectory;
        }

        internal void InitPageObjectFiles()
        {
            var theDirectory = GetDefaultPageObjectsDirectory();
            string[] files = Directory.GetFiles(theDirectory)
                     .Where(f => f.EndsWith(PoxFileExtension))
                     .Select( f => Path.GetFileNameWithoutExtension(f))
                     .ToArray();
            
            view.SetPageObjectFiles(files);
        }

        internal void UpdatePageTreeFromFileName()
        {
            view.UpdatePageTreeFromFileName();
        }

        internal void UpdateControlsState()
        {
            bool buttonSaveShouldBeEnabled = true;

            // When the PageObject name is empty
            if (string.IsNullOrWhiteSpace(view.GetPageObjectName()))
            {
                buttonSaveShouldBeEnabled = false;
            }
            // Or no changes had occured after last save
            else if (!IsDirty)
            {
                buttonSaveShouldBeEnabled = false;
            }
            view.btnSavePageObject.Enabled = buttonSaveShouldBeEnabled;
        }

        internal void NotifyOnChanges()
        {
            IsDirty = true;
            UpdateControlsState();
            RaisePageObjectTreeChanged();
        }

        internal void SavePageObject()
        {
            string pageObjectFileName = GetPageObjectFileName();
            string targetFullPath = Path.Combine(GetDefaultPageObjectsDirectory(), pageObjectFileName);

            if (File.Exists(targetFullPath) && lastSavedFilePath != targetFullPath)
            {
                if (!view.ConfirmFileOverwrite(targetFullPath))
                {
                    return;
                }
            }

            try
            {
                SavePageObjectToFile(targetFullPath);
            }
            catch(Exception e)
            {
                MyLog.Exception(e);
                view.NotifyOnSaveError(e.Message, targetFullPath);
                return;
            }
            InitPageObjectFiles();

            IsDirty = false;
            lastSavedFilePath = targetFullPath;
            UpdateControlsState();
        }

        private void SavePageObjectToFile(string targetFullPath)
        {
            var definitions = GetWebElementDefinitionFromTree();
            using (var stream = File.Create(targetFullPath))
            {
                var serializer = new XmlSerializer(typeof(SwdPageObject));
                serializer.Serialize(stream, definitions);
            }

        }

        private string GetPageObjectFileName()
        {
            string fileName = view.GetPageObjectName().Trim();
            if (!fileName.ToLower().EndsWith(PoxFileExtension))
            {
                fileName += PoxFileExtension;
            }

            return fileName;
        }

        internal void LoadPageObject(string pageObjectFileName)
        {
            string pageObjectFile = pageObjectFileName + PoxFileExtension;
            string targetFullPath = Path.Combine(GetDefaultPageObjectsDirectory(), pageObjectFile);

            SwdPageObject pageObject = null;
            try
            {
                pageObject = LoadPageObjectFromFile(targetFullPath);
            }
            catch (Exception e)
            {
                MyLog.Exception(e);
                view.NotifyOnLoadError(e.Message, targetFullPath);
                return;
            }

            view.ClearPageObjectTree();
            foreach (var def in pageObject.Items)
            {

                UpdatePageDefinition(def, forceAddNew: true);
            }

            IsDirty = false;
            lastSavedFilePath = targetFullPath;
            UpdateControlsState();
            RaisePageObjectTreeChanged();
        }

        private SwdPageObject LoadPageObjectFromFile(string pageObjectFileName)
        {
            SwdPageObject definitions = null;

            using (FileStream stream = File.OpenRead(pageObjectFileName))
            {
                var serializer = new XmlSerializer(typeof(SwdPageObject));
                definitions = (SwdPageObject)serializer.Deserialize(stream);
            }
            return definitions;
        }

        internal void OpenDefaultFolderInWindowsExplorer()
        {
            Process.Start(GetDefaultPageObjectsDirectory());
        }

        internal void ShowPropertiesForNode(TreeNode treeNode)
        {
            WebElementDefinition element = (treeNode.Tag as WebElementDefinition);

            WebElementDefinition readOnlyElement = element.Clone();
            TypeDescriptor.AddAttributes(readOnlyElement, new Attribute[] { new ReadOnlyAttribute(true) });
            element = readOnlyElement;

            view.propPageElement.SelectedObject = readOnlyElement;
        }

    }
}
