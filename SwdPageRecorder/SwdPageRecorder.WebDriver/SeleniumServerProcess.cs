using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Net;

namespace SwdPageRecorder.WebDriver
{
    public static class SeleniumServerProcess
    {
        private static Process currentProcess;

        
        public static void Launch(string pathToStartupBatFile, string additionalArgs = "")
        {
            if (IsRunning())
            {
                Console.WriteLine("Remote Driver was already started");
                return;
            }
            
            currentProcess = new Process();
            var p = currentProcess;
            p.StartInfo.FileName = pathToStartupBatFile;
            p.StartInfo.Arguments =  additionalArgs;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.RedirectStandardOutput = false;
            p.Start();

            WaitForWebDriver();
        }

        private static void WaitForWebDriver()
        {
            string httpResponse = "";

            Exception lastException = null;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (!httpResponse.Contains("WebDriver Hub"))
            {
                try
                {
                    
                    WebClient client = new WebClient();
                    httpResponse = client.DownloadString(@"http://localhost:4444/wd/hub");
                }
                catch (Exception e)
                {
                    lastException = e;
                }

                if (sw.Elapsed > TimeSpan.FromMinutes(1))
                {
                    throw new TimeoutException("WaitForWebDriver: Timeout; \n" + lastException.Message);
                }
            }
        }

        public static bool IsRunning()
        {
            return IsRunning(@"http://localhost:4444/wd/hub");
        }

        public static bool IsRunning(string webdriverUrl)
        {
            string httpResponse = "";

            try
            {
                WebClient client = new WebClient();
                httpResponse = client.DownloadString(webdriverUrl);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return httpResponse.Contains("WebDriver Hub");
            
        }

        public static void Close()
        {
            currentProcess.Close();
        }

    }
}
