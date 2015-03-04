using System;
using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

using SwdPageRecorder.WebDriver;
using SwdPageRecorder.TestModel;

using FluentAssertions;

namespace SwdPageRecorder.Tests.Integration.SwdPageRecorder.WebDriver
{
    [TestFixture]
    public class SwdBrowser_Tests : MyTest    
    {

        /// <summary>
        /// SwdBrowser.Initialize should be able to connect to the Remote Hub 
        /// Tests: @SwdBrowser.Initialize, @WebDriverOptions, @SwdBrowser.TestRemoteHub, @SwdBrowser.RunStandaloneServer
        /// 
        /// 1. The test verifies if the remote hub started with @SwdBrowser.TestRemoteHub and starts the server
        /// 2. Then it verifies if the HtmlUnitDriver is active
        /// </summary>
        [Test(Description = "WebDriver")]
        public void Initialize_should_be_able_to_start_new_browser()
        {
            WebDriverOptions options = new WebDriverOptions()
            {
                 BrowserName = WebDriverOptions.browser_HtmlUnitWithJavaScript,
                 IsRemote = true,
                 RemoteUrl = "http://localhost:4444/wd/hub/",
            };

            bool isSeleniumServerAvailable = true;

            try
            {
                SwdBrowser.TestRemoteHub(options.RemoteUrl);
            }
            catch (Exception e)
            {
                isSeleniumServerAvailable = false;
                Console.WriteLine("FAILED: " + e.Message);
            }

            if (!isSeleniumServerAvailable)
            {
                SwdBrowser.RunStandaloneServer("start_selenium_server.bat");
            }

            SwdBrowser.Initialize(options);

            var rempteDriver = (RemoteWebDriver) SwdBrowser.GetDriver();

            rempteDriver.Capabilities.BrowserName.Should().Be("htmlunit");

            SwdBrowser.CloseDriver();
        }


        // ===========================================================================
        private static string[] GetDesktopWindowsWithSpecialTitle(string specialTitle)
        {
            var specialWindows = (from title in Helper.GetAllMainWindowTitlesOnDesktop()
                                  where title.Contains(specialTitle)
                                  select title).ToArray();

            return specialWindows;
        }

        /// <summary>
        /// SwdBrowser.CloseDriver() should close the opened browser window
        /// Tests: @SwdBrowser.CloseDriver, 
        /// 
        /// 1. It opens a FireFox browser
        /// 2. Executes a special JavaScript which sets the document title to "SwdBrowser.CloseDriver TEST TEST"
        /// 3. And verifies the window was opened
        /// 4. Closes the browser with @SwdBrowser.CloseDriver
        /// 5. Verifies there are no windows with such title on Windows Desktop
        /// </summary>
        [Test(Description = "WebDriver")]
        public void CloseDriver_should_close_the_opened_browser_instance()
        {
            WebDriverOptions options = new WebDriverOptions()
            {
                BrowserName = WebDriverOptions.browser_Firefox,
                IsRemote = false,
            };

            string specialTitle = "SwdBrowser.CloseDriver TEST TEST";

            string[] specialWindows = new string[] { };
            
            specialWindows = GetDesktopWindowsWithSpecialTitle(specialTitle);
            specialWindows.Length.Should().Be(0, "Expected no windows with title <{0}> at the beginning", specialTitle);

            SwdBrowser.Initialize(options);

            string changeTitleScript = string.Format("document.title = '{0}'", specialTitle);
            SwdBrowser.ExecuteJavaScript(changeTitleScript);

            specialWindows = GetDesktopWindowsWithSpecialTitle(specialTitle);
            specialWindows.Length.Should().Be(1, "Expected only 1 window with title <{0}> after new driver was created", specialTitle);

            SwdBrowser.CloseDriver();

            specialWindows = GetDesktopWindowsWithSpecialTitle(specialTitle);
            specialWindows.Length.Should().Be(0, "Expected no windows with title <{0}> after the driver was closed", specialTitle);


        }



        [Test(Description = "WebDriver")]
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

            SwdBrowser.CloseDriver();
        }

        [Test(Description = "WebDriver")]
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

            SwdBrowser.CloseDriver();
        }

        [Test(Description = "WebDriver")]
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

            SwdBrowser.CloseDriver();
            
        }

    }
}
