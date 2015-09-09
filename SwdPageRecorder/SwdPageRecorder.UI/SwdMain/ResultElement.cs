using OpenQA.Selenium;

namespace SwdPageRecorder.UI
{
    public class ResultElement
    {
        public string DisplayString { get; set; }
        public IWebElement WebElement { get; set; }

        public override string ToString()
        {
            return DisplayString;
        }
    }
}
