using System;
using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

using SwdPageRecorder.WebDriver;
using SwdPageRecorder.TestModel;

using FluentAssertions;
using System.Diagnostics;
using System.Threading;


namespace SwdPageRecorder.Tests.Integration.SwdPageRecorder.WebDriver
{
    [TestFixture]    
    public class In_SwdPageRecorder_IsWorking
    {

        [Test]
        public void PerformanceTest()
        {
            WebDriverOptions options = new WebDriverOptions()
            {
                BrowserName = WebDriverOptions.browser_Firefox,
                RemoteUrl = "http://localhost:4444/wd/hub/"
            };

            const int TOTAL_ITERATIONS = 1000;

            SwdBrowser.Initialize(options);
            SwdBrowser.GetDriver().Quit();
            Thread.Sleep(5000);
            Stopwatch swLegacy = Stopwatch.StartNew();
            for (var i = 0; i < TOTAL_ITERATIONS; i++) 
            {
                var result = SwdBrowser.IsWorking;
                result.Should().BeFalse();
            }
            Console.WriteLine(swLegacy.ElapsedMilliseconds.ToString() + "ms");

        
        }

    }
}

