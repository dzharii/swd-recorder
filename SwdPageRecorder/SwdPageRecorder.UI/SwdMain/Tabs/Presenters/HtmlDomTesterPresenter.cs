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

using HAP = HtmlAgilityPack;

namespace SwdPageRecorder.UI
{
    public class HtmlDomTesterPresenter : IPresenter<HtmlDomTesterView>
    {
        private HtmlDomTesterView view;

        public IWebDriver Driver { get { return SwdBrowser.GetDriver(); } }

        public void InitWithView(HtmlDomTesterView view)
        {
            this.view = view;

            // Subscribe to WebDriverUtils events
            SwdBrowser.OnDriverStarted += InitControls;
            SwdBrowser.OnDriverClosed += InitControls;
            InitControls();
        }

        private void InitControls()
        {
            var shouldControlBeEnabled = SwdBrowser.IsWorking;

            view.btnTestLocator.Enabled = shouldControlBeEnabled;
        }

        public ReadOnlyCollection<IWebElement> FindElements(LocatorSearchMethod searchMethod, string locator)
        {

            var by = Utils.ByFromLocatorSearchMethod(searchMethod, locator);
            return Driver.FindElements(by);
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

        internal void TestLocators()
        {

            var searchMethod = Presenters.SelectorsEditPresenter.GetLocatorSearchMethod();
            var locator = Presenters.SelectorsEditPresenter.GetLocatorText();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var elements = FindElements(searchMethod, locator);
            sw.Stop();

            
            Presenters.PageObjectDefinitionPresenter.UpdateLastCallStat(sw.ElapsedMilliseconds.ToString() + " ms");

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

        private void ParseHtmlNodes(TreeNode tnode, HAP.HtmlNodeCollection htmlNodes, string parentXPath)
        {

            
            var childrenCount = new Dictionary<string, int>();

            foreach (HAP.HtmlNode htmlNode in htmlNodes)
            {

                var currentNodeName = htmlNode.Name.ToLower();

                if (currentNodeName.StartsWith("#")) continue;

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


                if (htmlNode.Attributes == null) continue;

                var attributes = new List<string>();

                for (int i = 0; i < htmlNode.Attributes.Count; i++)
                {
                    var attr = htmlNode.Attributes[i];
                    attributes.Add(attr.Name+ "= \"" + attr.Value + "\"");
                }

                string nodeDisplayName = currentNodeName + " " + String.Join(" ", attributes);


                var newNode = new TreeNode(nodeDisplayName);
                newNode.Name = currentNodeName;


                newNode.Tag = new HtmlTreeNodeData()
                {
                    OriginalHtmlNode = htmlNode,
                    nodeXPath = currentNodeXPath,
                };

                tnode.Nodes.Add(newNode);

                if (htmlNode.Name == "form")
                {

                }


                if (htmlNode.HasChildNodes)
                {

                    ParseHtmlNodes(newNode, htmlNode.ChildNodes, currentNodeXPath);
                }
            }

        }

        internal void UpdateTestHtmlDocumentView()
        {
            var doc = SwdBrowser.GetPageSource();

            var root = doc.DocumentNode.ChildNodes.FindFirst(@"html");
            var treeRootNode = new TreeNode(root.Name);
            treeRootNode.Name = root.Name.ToLower();
            treeRootNode.Tag = new HtmlTreeNodeData()
            {
                nodeXPath = "/html",
                OriginalHtmlNode = root,
            };
            ParseHtmlNodes(treeRootNode, root.ChildNodes, "/html[1]");

            view.AddTestHtmlNodes(treeRootNode);


        }

        internal void UpdateHtmlPropertiesForSelectedNode(TreeNode htmlTreeNode)
        {
            var htmlNode = (htmlTreeNode.Tag as HtmlTreeNodeData).OriginalHtmlNode;

            List<string> attributes = new List<string>();

            if (htmlNode.Attributes != null)
            {
                for (int i = 0; i < htmlNode.Attributes.Count; i++)
                {
                    var attr = htmlNode.Attributes[i];
                    attributes.Add(attr.Name + "= \"" + attr.Value + "\"");
                }
            }

            view.UpdateHtmlProperties(attributes);

        }

        internal void HighLightElementFromNode(TreeNode treeNode)
        {
            string xpath = GetXPathFromTreeNode(treeNode);
            var by = Utils.ByFromLocatorSearchMethod(LocatorSearchMethod.XPath, xpath);
            SwdBrowser.HighlightElement(by);
        }

        private string GetXPathFromTreeNode(TreeNode treeNode)
        {
            HtmlTreeNodeData nodeData = treeNode.Tag as HtmlTreeNodeData;
            return nodeData.nodeXPath;
        }

        internal void ShowElementInTree(ResultElement element)
        {
            IWebElement webElement = element.WebElement;
            string xPath = SwdBrowser.GetElementXPath(webElement);

            var travelNodes = GetTreeTravelDataFromXPath(xPath);

            view.FindAndHighlightElementInTree(travelNodes);
        }

    }
}
