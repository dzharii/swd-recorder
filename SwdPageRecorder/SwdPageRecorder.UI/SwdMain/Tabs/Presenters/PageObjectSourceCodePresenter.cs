using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SwdPageRecorder.WebDriver;

namespace SwdPageRecorder.UI
{
    public class PageObjectSourceCodePresenter : IPresenter<PageObjectSourceCodeView>
    {

        const string codeTemplateFileExtension = ".cshtml";


        private PageObjectSourceCodeView view;

        public void InitWithView(PageObjectSourceCodeView view)
        {
            this.view = view;
        }

        internal void GenerateSourceCodeForPageObject()
        {
            var definitions = Presenters.PageObjectDefinitionPresenter.GetWebElementDefinitionFromTree();
            var generator = new CSharpPageObjectGenerator();
            string selectedTemalateName = view.GetSelectedTemplateFile();

            if (string.IsNullOrWhiteSpace(selectedTemalateName))
            {
                view.WarnTemplateNeedsToBeSelected();
                return;
            }

            var fullTemplatePath = Path.Combine(GetDefaultCodeTemplateDirectory(),
                                            selectedTemalateName + codeTemplateFileExtension);

            string[] code;

            try
            {
                code = generator.Generate(definitions, fullTemplatePath);
            }
            catch (Exception e)
            {
                MyLog.Exception(e);
                throw;
            }
            
            view.DisplayGeneratedCode(code);

        }


        public string GetDefaultCodeTemplateDirectory()
        {
            string fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string theDirectory = Path.GetDirectoryName(fullPath);
            return Path.Combine(theDirectory, "CodeTemplates");
        }

        
        internal void InitTemplateFilesList()
        {
            var templateDir = GetDefaultCodeTemplateDirectory();
            if (!Directory.Exists(templateDir))
            {
                return;
            }
            string[] files = Directory.GetFiles(templateDir)
                     .Where(f => f.EndsWith(codeTemplateFileExtension))
                     .Select(f => Path.GetFileNameWithoutExtension(f))
                     .ToArray();

            view.SetPageObjectFiles(files);
        }

        internal void TrySelectDefaultTemplate()
        {
            if (view.cbCodeTemplates.SelectedItem == null)
            {
                foreach (var item in view.cbCodeTemplates.Items)
                {
                    string itemName = item as string;
                    if (itemName != null 
                    &&  itemName.ToLower().Contains("default"))
                    {
                        view.cbCodeTemplates.SelectedItem = item;
                    }
                }
            }
        }
    }
}
