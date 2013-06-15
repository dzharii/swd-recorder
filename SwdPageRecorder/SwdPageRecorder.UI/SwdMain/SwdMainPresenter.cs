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
    public class SwdMainPresenter
    {
        private SwdMainView view;
        public IWebDriver Driver { get { return SwdBrowser.GetDriver(); } }

        public Thread visualSearchWorker = null;

        public void InitView(SwdMainView view)
        {
            this.view = view;
        }


        internal void GenerateSourceCodeForPageObject()
        {
            var definitions = view.pageObjectDefinitionView.GetWebElementDefinitionFromTree();
            var generator = new CSharpPageObjectGenerator();

            string[] code = generator.Generate(definitions);
            view.DisplayGeneratedCode(code);

        }

        internal void SetBrowserUrl(string browserUrl)
        {
            Driver.Navigate().GoToUrl(browserUrl);
        }



        internal void DisplayHtmlPageSource()
        {

            string singleLineSource = SwdBrowser.GetTidyHtml();
            string[] htmlLines = SplitSingleLineToMultyLine(singleLineSource);
            view.FillHtmlCodeBox(htmlLines);
        }

        private string[] SplitSingleLineToMultyLine(string singleLineSource)
        {
            string[] result = singleLineSource.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return result;
        }




        public void VisualSearch_UpdateSearchResult()
        {

            while (true)
            {

                var command = SwdBrowser.GetNextCommand();
                if (command is GetXPathFromElement)
                {
                    var getXPathCommand = command as GetXPathFromElement;
                    view.UpdateVisualSearchResult(getXPathCommand.XPathValue);
                }
                else if (command is AddElement)
                {
                    var addElementCommand = command as AddElement;

                    var element = new WebElementDefinition()
                    {
                        Name = addElementCommand.ElementCodeName,
                        HowToSearch = LocatorSearchMethod.XPath,
                        Locator = addElementCommand.ElementXPath,
                    };
                    bool addNew = true;
                    
                    Presenters.PageObjectDefinitionPresenter.UpdatePageDefinition(element, addNew);
                }
                Thread.Sleep(100);
            }

        }
        
        internal void StartVisualSearch()
        {
            SwdBrowser.InjectVisualSearch();

            if (visualSearchWorker!=null)
            {
                visualSearchWorker.Abort();
                visualSearchWorker = null;
            }

            visualSearchWorker = new Thread(VisualSearch_UpdateSearchResult);
            visualSearchWorker.IsBackground = true;
            visualSearchWorker.Start();
        }
    }
}
