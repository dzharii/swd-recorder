using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using SwdPageRecorder.WebDriver;

namespace SwdPageRecorder.UI
{
    public class SwdMainPresenter
    {
        private SwdMainView view;
        public IWebDriver Driver { get { return SwdBrowser.GetDriver(); } }



        public SwdMainPresenter(SwdMainView view)
        {
            this.view = view;
        }


        internal void StartNewBrowser(WebDriverOptions browserOptions)
        {
            SwdBrowser.Initialize(browserOptions);
            Driver.Navigate().GoToUrl(@"http://yandex.ru");
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
    }
}
