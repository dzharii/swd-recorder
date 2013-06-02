﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using SwdPageRecorder.WebDriver;

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

            string singleLineSource = Driver.PageSource;
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
                var body = SwdBrowser.GetDriver().FindElement(By.TagName(@"body"));
                string xPathAttributeValue = body.GetAttribute("xpath");
                if (!String.IsNullOrWhiteSpace(xPathAttributeValue))
                {
                    view.UpdateVisualSearchResult(xPathAttributeValue);
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

        public static IEnumerable<TreeNode> AddRange(TreeNode collection, IEnumerable<TreeNode> nodes)
        {
            var items = nodes.ToArray();
            collection.Nodes.AddRange(items);
            return new[] { collection };
        }

        private IEnumerable<TreeNode> GetNodes(TreeNode node, XElement element)
        {
            return element.HasElements ?
                AddRange(node, from item in element.Elements()
                              let tree = new TreeNode(item.Name.LocalName)
                              from newNode in GetNodes(tree, item)
                              select newNode)
                              :
                new[] { node };
        }

        internal void UpdateTestHtmlDocumentView()
        {
            XmlDocument doc = SwdBrowser.GetPageSourceXml();

            var xDocument = XDocument.Load(new XmlNodeReader(doc));

            var root = xDocument.Root;
            var x = GetNodes(new TreeNode(root.Name.LocalName), root).ToArray();

            view.AddTestHtmlNodes(x);

            
        }
    }
}
