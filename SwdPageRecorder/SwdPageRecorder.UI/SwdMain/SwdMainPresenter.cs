using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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



namespace SwdPageRecorder.UI
{
    public class SwdMainPresenter
    {
        private SwdMainView view;
        public IWebDriver Driver { get { return SwdBrowser.GetDriver(); } }

        public Thread visualSearchWorker = null;



        public SwdMainPresenter(SwdMainView view)
        {
            this.view = view;
        }


        internal void StartNewBrowser(WebDriverOptions browserOptions)
        {
            SwdBrowser.Initialize(browserOptions);
            
        }


        public By ByFromLocatorSearchMethod(LocatorSearchMethod searchMethod, string locator)
        {
            By by = null;
            switch (searchMethod)
            {
                case LocatorSearchMethod.Id:
                    by = By.Id(locator);
                    break;
                case LocatorSearchMethod.CssSelector:
                    by = By.CssSelector(locator);
                    break;
                case LocatorSearchMethod.XPath:
                    by = By.XPath(locator);
                    break;

                case LocatorSearchMethod.Name:
                    by = By.Name(locator);
                    break;

                case LocatorSearchMethod.TagName:
                    by = By.TagName(locator);
                    break;

                case LocatorSearchMethod.ClassName:
                    by = By.ClassName(locator);
                    break;

                case LocatorSearchMethod.LinkText:
                    by = By.LinkText(locator);
                    break;

                case LocatorSearchMethod.PartialLinkText:
                    by = By.PartialLinkText(locator);
                    break;
            }
            return by;
        }


        public ReadOnlyCollection<IWebElement>  FindElements(LocatorSearchMethod searchMethod, string locator)
        {

            var by = ByFromLocatorSearchMethod(searchMethod, locator);
            return Driver.FindElements(by);
        }

        internal void TestLocators()
        {

            var searchMethod = view.GetLocatorSearchMethod();
            var locator = view.GetLocatorText();
            
            var elements = FindElements(searchMethod, locator);

            List<ResultElement> displayList = new List<ResultElement>();
            foreach (var el in elements)
            {
                ResultElement displayItem = new ResultElement();
                displayItem.DisplayString = el.TagName + " " + el.Text;
                displayItem.WebElement = el;
                displayList.Add(displayItem);
            }

            view.DisplaySearchResults(displayList);
        }



        internal void UpdatePageDefinition(WebElementDefinition element)
        {
            view.AddToPageDefinitions(element);

        }

        internal void GenerateSourceCodeForPageObject()
        {
            var definitions = view.GetWebElementDefinitionFromTree();
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

        internal void HighLightWebElement(WebElementDefinition element)
        {
            var by = ByFromLocatorSearchMethod(element.HowToSearch, element.Locator);
            SwdBrowser.HighlightElement(by);
            
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

                    UpdatePageDefinition(element);
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


        private void ParseXmlNodes(TreeNode tnode, XmlNodeList xmlNodes)
        {

            foreach (XmlNode xmlNode in xmlNodes)
            {
                if (xmlNode.Attributes == null) continue;
                
                List<string> attributes = new List<string>();
                                
                for (int i = 0; i < xmlNode.Attributes.Count; i++)
                {
                    var attr=xmlNode.Attributes[i];
                    attributes.Add(attr.LocalName + "=" + attr.Value);
                }

                string nodeName = xmlNode.LocalName + " " + String.Join(" ", attributes);


                var newNode = new TreeNode(nodeName);
                tnode.Nodes.Add(newNode);

                if (xmlNode.HasChildNodes)
                {
                    ParseXmlNodes(newNode, xmlNode.ChildNodes);
                }
            }

        }

        internal void UpdateTestHtmlDocumentView()
        {
            XmlDocument doc = SwdBrowser.GetPageSourceXml();

            var root = doc.FirstChild;
            var treeRootNode = new TreeNode(root.LocalName);
            ParseXmlNodes(treeRootNode, root.ChildNodes);

            view.AddTestHtmlNodes(treeRootNode);


        }
    }
}
