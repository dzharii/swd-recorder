using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

using SwdPageRecorder.WebDriver;
using SwdPageRecorder.TestModel;

using FluentAssertions;

namespace SwdPageRecorder.Tests.Integration
{
    [TestClass]
    public class SwdBrowser_Tests : MyTest    
    {
        [TestMethod]
        [Ignore]
        public void Initialize_should_be_able_to_start_new_browser()
        {
            WebDriverOptions options = new WebDriverOptions()
            {
                 BrowserName = WebDriverOptions.browser_HtmlUnitWithJavaScript,
                 IsRemote = true,
                 RemoteUrl = "http://localhost:4444/wd/hub/",
            };

            SwdBrowser.RunStandaloneServer("start_selenium_server.bat");


            SwdBrowser.Initialize(options);

            var rempteDriver = (RemoteWebDriver) SwdBrowser.GetDriver();

            rempteDriver.Capabilities.BrowserName.Should().Be("htmlunit");
        }

        [TestMethod]
        public void Enumerate_Windows_Tabs()
        {
            Helper.RunDefaultBrowser();
            Helper.LoadTestFile("page_opens_several_tabs.html");

            Helper.ClickId("openTab2");
            Helper.ClickId("openTab3");

            BrowserWindow[] actualWindows = SwdBrowser.GetBrowserWindows();

            string[] expectedWindowTitles = new string[]
            {
                "Page Tab1",
                "Page Tab3",
                "Page Tab2",
            };

            string[] actualTitles = actualWindows.Select(w => w.Title).ToArray();

            actualTitles.Should().Contain(expectedWindowTitles);
        }

        [TestMethod]
        public void Enumerate_Windows_Popup()
        {
            Helper.RunDefaultBrowser();
            Helper.LoadTestFile("page_opens_several_tabs.html");

            Helper.ClickId("openTab2");
            Helper.ClickId("openTab3");
            Helper.ClickId("openJavaScriptPopup");
            

            BrowserWindow[] actualWindows = SwdBrowser.GetBrowserWindows();

            string[] expectedWindowTitles = new string[]
            {
               "Page Tab1", 
               "JavaScript Popup", 
               "Page Tab3", 
               "Page Tab2"
            };

            string[] actualTitles = actualWindows.Select(w => w.Title).ToArray();

            actualTitles.Should().Contain(expectedWindowTitles);
        }

        [TestMethod]
        public void Get_Frames_Tree()
        {

            string[] expectedTitles = new string[]
            {
              "DefaultContent", 
              "firstFrame", 
              "secondFrame", 
              "secondFrame.idIframeInsideSecondFrame", 
              "thirdFrame", 
              "thirdFrame.0"
            };

            
            Helper.RunDefaultBrowser();
            Helper.LoadTestFile("page_with_frames.html");


            BrowserPageFrame rootFrame = SwdBrowser.GetPageFramesTree();
            List<BrowserPageFrame> allFrames = rootFrame.ToList();

            string[] actualTitles = allFrames.Select(i => i.ToString()).ToArray();

            actualTitles.Should().Equal(expectedTitles);
            
        }

    }
}
