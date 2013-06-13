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

        private bool _isEditingExistingNode = false;
        private TreeNode _currentEditingNode = null;



        public SwdMainPresenter(SwdMainView view)
        {
            this.view = view;
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

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var elements = FindElements(searchMethod, locator);
            sw.Stop();

            view.UpdateLastCallStat(sw.ElapsedMilliseconds.ToString() + " ms");

            List<ResultElement> displayList = new List<ResultElement>();
            foreach (var el in elements)
            {
                ResultElement displayItem = new ResultElement();

                string tagName = el.TagName;
                string elementId = el.GetAttribute("id") ?? "n/a";
                string elementName = el.GetAttribute("name") ?? "n/a";

                if (tagName == "input")
                {
                    var elementType = el.GetAttribute("type") ?? "n/a";
                    var elementValue = el.GetAttribute("value") ?? "n/a";
                    displayItem.DisplayString = String.Format("{0}[type=\'{4}\'] id=\"{1}\"; name=\"{2}\"; value=\"{3}\"", el.TagName, elementId, elementName, elementValue, elementType);
                }
                else
                {
                    string elementText = el.Text ?? "n/a";
                    displayItem.DisplayString = String.Format("{0} id=\"{1}\"; name=\"{2}\"; text(\"{3}\")", el.TagName, elementId, elementName, elementText);
                }

                displayItem.WebElement = el;
                displayList.Add(displayItem);
            }

            view.DisplaySearchResults(displayList);
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
                    bool addNew = true;
                    UpdatePageDefinition(element, addNew);
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




        private void ParseXmlNodes(TreeNode tnode, XmlNodeList xmlNodes, string parentXPath)
        {

            var childrenCount = new Dictionary<string, int>();

            foreach (XmlNode xmlNode in xmlNodes)
            {

                var currentNodeName = xmlNode.LocalName.ToLower();
                if (childrenCount.ContainsKey(currentNodeName))
                {
                    childrenCount[currentNodeName]++;
                }
                else
                {
                    childrenCount[currentNodeName] = 1;
                }

                var currentNodeXPath = parentXPath;
                currentNodeXPath += String.Format("/{0}[{1}]", currentNodeName, childrenCount[currentNodeName]);
                
                
                if (xmlNode.Attributes == null) continue;
                
                var attributes = new List<string>();
                                
                for (int i = 0; i < xmlNode.Attributes.Count; i++)
                {
                    var attr = xmlNode.Attributes[i];
                    attributes.Add(attr.LocalName + "= \"" + attr.Value + "\"");
                }

                string nodeDisplayName = currentNodeName + " " + String.Join(" ", attributes);


                var newNode = new TreeNode(nodeDisplayName);
                newNode.Name = currentNodeName;


                newNode.Tag = new HtmlTreeNodeData()
                    {
                        OriginalXmlNode = xmlNode,
                        nodeXPath = currentNodeXPath,
                    };

                tnode.Nodes.Add(newNode);

                if (xmlNode.HasChildNodes)
                {

                    ParseXmlNodes(newNode, xmlNode.ChildNodes, currentNodeXPath);
                }
            }

        }

        internal void UpdateTestHtmlDocumentView()
        {
            XmlDocument doc = SwdBrowser.GetPageSourceXml();

            var root = doc.FirstChild;
            var treeRootNode = new TreeNode(root.LocalName);
            treeRootNode.Name = root.LocalName.ToLower();
            treeRootNode.Tag = new HtmlTreeNodeData() 
            {
                nodeXPath = "/html",
                OriginalXmlNode = root,
            };
            ParseXmlNodes(treeRootNode, root.ChildNodes, "/html[1]");

            view.AddTestHtmlNodes(treeRootNode);


        }


        private static List<TravelNode> GetTreeTravelDataFromXPath(string xpath)
        {
            var result = new List<TravelNode>();
            var selectors = xpath.Split('/').Skip(1);
            foreach (var selector in selectors)
            {

                Match match = Regex.Match(selector, @"^(\w+)(?:\[(\d+)\])?", RegexOptions.IgnoreCase);
                var nodeName = match.Groups[1].Value;

                var nodelIndexString = match.Groups[2].Value;
                nodelIndexString = String.IsNullOrWhiteSpace(nodelIndexString) ? "1" : nodelIndexString;

                var nodeIndex = Convert.ToInt32(nodelIndexString);
                nodeIndex--;

                result.Add(new TravelNode() { NodeName = nodeName, NodeIndex = nodeIndex });
            }

            return result;
        }

        internal void ShowElementInTree(ResultElement element)
        {
            IWebElement webElement = element.WebElement;
            string xPath = SwdBrowser.GetElementXPath(webElement);

            var travelNodes = GetTreeTravelDataFromXPath(xPath);

            view.FindAndHighlightElementInTree(travelNodes);
        }

        internal void OpenExistingNodeForEdit(TreeNode treeNode)
        {
            _isEditingExistingNode = true;
            _currentEditingNode = treeNode;
            var webElementFormData = treeNode.Tag as WebElementDefinition;
            view.UpdateWebElementForm(webElementFormData);
        }

        internal void NewWebElement()
        {
            _isEditingExistingNode = false;
            _currentEditingNode = null;
            view.ClearWebElementForm();
        }

        internal void CopyWebElement()
        {
            _isEditingExistingNode = false;
            _currentEditingNode = null;
            view.AppendWebElementNameWith("__Copy");
        }

        internal void UpdateHtmlPropertiesForSelectedNode(TreeNode htmlTreeNode)
        {
            var xmlNode = (htmlTreeNode.Tag as HtmlTreeNodeData).OriginalXmlNode;

            List<string> attributes = new List<string>();

            if (xmlNode.Attributes != null)
            {
                for (int i = 0; i < xmlNode.Attributes.Count; i++)
                {
                    var attr = xmlNode.Attributes[i];
                    attributes.Add(attr.LocalName + "= \"" + attr.Value + "\"");
                }
            }

            view.UpdateHtmlProperties(attributes);

        }

        internal void HighLightElementFromNode(TreeNode treeNode)
        {
            string xpath = GetXPathFromTreeNode(treeNode);
            var by = ByFromLocatorSearchMethod(LocatorSearchMethod.XPath, xpath);
            SwdBrowser.HighlightElement(by);
        }

        private string GetXPathFromTreeNode(TreeNode treeNode)
        {
            HtmlTreeNodeData nodeData = treeNode.Tag as HtmlTreeNodeData;
            return nodeData.nodeXPath;
        }
    }
}
