using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

using SwdPageRecorder.WebDriver;

using SwdPageRecorder.TestModel;

using FluentAssertions;

namespace SwdPageRecorder.Tests.Integration
{
    [TestFixture]
    public class WebElement_Explorer_Tests : MyTest    
    {
        const int firstFrame = 0;
        const int secondFrame = 1;
        const int thirdFrame = 2;

        [Test(Description = "WebDriver"), Ignore]
        public void WebElementExplorer_Test()
        {
            Helper.RunDefaultBrowser();
            Helper.LoadTestFile("page_with_frames.html");

            Helper.ToFrame(secondFrame);

            SwdBrowser.InjectVisualSearch();

            //Helper.ClickId();

            throw new NotImplementedException();
            
        }

    }
}
