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
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.IO;



namespace SwdPageRecorder.UI
{
    public class SwdMainPresenter
    {
        private SwdMainView view;
        public IWebDriver Driver { get { return SwdBrowser.GetDriver(); } }

        public Thread visualSearchWorker = null;

        const int VisualSearchQueryDelayMs = 777;

        public string ScreenshotsLocation { get {
            return Path.Combine(Utils.AssemblyDirectory, "Screenshots");
        } }

        public void InitView(SwdMainView view)
        {
            this.view = view;

            // Subscribe to WebDriverUtils events
            SwdBrowser.OnDriverStarted += InitControls;
            SwdBrowser.OnDriverClosed += InitControls;

            SwdBrowser.OnDriverStarted += InitSwitchToControls;

            InitControls();
        }

        private void InitSwitchToControls()
        {

            view.SetInitialRefreshMessageForSwitchToControls();
        }

        
        public void RefreshWindowsList()
        {
            Exception outException;
            bool isOk = false;

            isOk = UIActions.PerformSlowOperation(
                        "Operation: Refresh All Windows List",
                        () =>
                        {
                            BrowserWindow[] currentWindows = SwdBrowser.GetBrowserWindows();
                            string currentWindowHandle = SwdBrowser.GetCurrentWindowHandle();
                            view.UpdateBrowserWindowsList(currentWindows, currentWindowHandle);
                        },
                            out outException,
                            null,
                            TimeSpan.FromMinutes(1)
                        );

            if (!isOk)
            {
                MyLog.Error("Failed to refresh All Windows List");
                if (outException != null) throw outException;
            }
        }

        public void RefreshFramesList()
        {
            Exception outException;
            bool isOk = false;
            isOk = UIActions.PerformSlowOperation(
                        "Operation: Refresh All Frames List",
                        () =>
                        {
                            BrowserPageFrame rootFrame = SwdBrowser.GetPageFramesTree();
                            BrowserPageFrame[] currentPageFrames = rootFrame.ToList().ToArray();
                            SwdBrowser.SwitchToDefaultContent();
                            view.UpdatePageFramesList(currentPageFrames);
                        },
                            out outException,
                            null,
                            TimeSpan.FromMinutes(1)
                        );

            if (!isOk)
            {
                MyLog.Error("Failed to refresh All Frames List");
                MyLog.Exception(outException);
                if (outException != null) throw outException;
            }
        }


        
        public void RefreshSwitchToList()
        {
            if (SwdBrowser.IsWorking)
            {
                view.DisableSwitchToControls();
                RefreshWindowsList();
                RefreshFramesList();
                view.EnableSwitchToControls();
            }
            else
            {
                view.DisableSwitchToControls();
            }
        }


        internal void SetBrowserUrl(string browserUrl)
        {
            Driver.Navigate().GoToUrl(browserUrl);
        }



        public void ProcessCommands()
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

                SimpleFrame simpleFrame;
                BrowserPageFrame browserPageFrame = view.getCurrentlyChosenFrame();
                if (browserPageFrame != null)
                {
                    List<string> childs = new List<string>();
                    string parentTitle;
                    if (browserPageFrame.ParentFrame != null)
                    {
                        parentTitle = browserPageFrame.ParentFrame.GetTitle();
                    }
                    else
                    {
                        parentTitle = "none";
                    }
                    if (browserPageFrame.ChildFrames != null)
                    {
                        foreach (BrowserPageFrame b in browserPageFrame.ChildFrames)
                        {
                            childs.Add(b.GetTitle());
                        }
                    }

                    simpleFrame = new SimpleFrame(browserPageFrame.Index, browserPageFrame.LocatorNameOrId, browserPageFrame.GetTitle(), parentTitle, childs);
                }
                else
                {
                    simpleFrame = new SimpleFrame(-1, "noFrameChosen", "noFrameChosen", "noFrameChosen", null);
                }

                var element = new WebElementDefinition()
                {
                    Name = addElementCommand.ElementCodeName,
                    HowToSearch = LocatorSearchMethod.XPath,
                    Locator = addElementCommand.ElementXPath,
                    CssSelector = addElementCommand.ElementCssSelector,
                    frame = simpleFrame,
                };
                bool addNew = true;
                Presenters.SelectorsEditPresenter.UpdateWebElementWithAdditionalProperties(element);
                Presenters.PageObjectDefinitionPresenter.UpdatePageDefinition(element, addNew);
            }
        }

        bool webElementExplorerStarted = false;
        bool webElementExplorerThreadPaused = false;

        public void ResumeWebElementExplorerProcessing()
        {
            MyLog.Write("ResumeWebElementExplorerProcessing");
            webElementExplorerThreadPaused = false;
        }

        public void PauseWebElementExplorerProcessing()
        {
            MyLog.Write("PauseWebElementExplorerProcessing");
            webElementExplorerThreadPaused = true;
        }

        public void VisualSearch_UpdateSearchResult()
        {
            try
            {
                MyLog.Write("VisualSearch_UpdateSearchResult: Started");
                while (webElementExplorerStarted == true)
                {
                    if (!webElementExplorerThreadPaused)
                    {
                        try
                        {
                            if (!SwdBrowser.IsVisualSearchScriptInjected())
                            {
                                MyLog.Write("VisualSearch_UpdateSearchResult: Found the Visual search is not injected. Injecting");
                                SwdBrowser.InjectVisualSearch();
                            }

                            if (!webElementExplorerThreadPaused)
                            {
                                ProcessCommands();
                            }
                        }
                        catch (Exception e)
                        {
                            StopVisualSearch();
                            MyLog.Error("Visual search stopped:");
                            MyLog.Exception(e);
                        }
                    }
                    Thread.Sleep(VisualSearchQueryDelayMs);
                }
            }
            finally
            {
                StopVisualSearch();
                MyLog.Write("VisualSearch_UpdateSearchResult: Finished");
            }

        }

        internal void StopVisualSearch()
        {
            view.VisualSearchStopped();
            webElementExplorerStarted = false;
        }

        internal void StartVisualSearch()
        {
            SwdBrowser.InjectVisualSearch();
            if (visualSearchWorker != null)
            {
                visualSearchWorker.Abort();
                visualSearchWorker = null;
            }

            webElementExplorerStarted = true;

            visualSearchWorker = new Thread(VisualSearch_UpdateSearchResult);
            visualSearchWorker.IsBackground = true;
            visualSearchWorker.Start();

            while (!visualSearchWorker.IsAlive)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
            }

            view.VisuaSearchStarted();

        }


        internal void ChangeVisualSearchRunningState()
        {
            view.DisableWebElementExplorerRunButton();

            try
            {
                if (webElementExplorerStarted)
                {
                    StopVisualSearch();
                    view.DisableWebElementExplorerResultsField();
                }
                else
                {
                    StartVisualSearch();
                    view.EnableWebElementExplorerResultsField();
                }
            }
            finally
            {
                view.EnableWebElementExplorerRunButton();
            }
        }

        internal void InitControls()
        {
            var shouldControlBeEnabled = SwdBrowser.IsWorking;
            view.SetDriverDependingControlsEnabled(shouldControlBeEnabled);

        }

        public void DisplayLoadingIndicator(bool showLoading)
        {
            if (showLoading)
            {
                view.ShowGlobalLoading();
            }
            else
            {
                view.HideGlobalLoading();
            }
        }

        internal void SwitchToFrame(BrowserPageFrame frame)
        {
            PauseWebElementExplorerProcessing();
            try
            {
                SwdBrowser.DestroyVisualSearch();
                SwdBrowser.GoToFrame(frame);
                MyLog.Write("FRAME: Switched to frame with Index= " + frame.Index + "; and Full Name:" + frame.ToString());
            }
            finally
            {
                ResumeWebElementExplorerProcessing();
            }
        }



        internal void SwitchToWindow(BrowserWindow window)
        {
            PauseWebElementExplorerProcessing();
            view.DisableSwitchToControls();
            try 
            {
                SwdBrowser.GotoWindow(window);
                MyLog.Write("WINDOW: Switched to window/popup with WinID= "
                            + window.WindowHandle + "; and Title:" + window.Title);
                RefreshFramesList();
            }
            finally 
            {
                ResumeWebElementExplorerProcessing();
                view.EnableSwitchToControls();
            }
        }

        internal void OpenSwitchToFrameCodeHelperPopup(BrowserPageFrame currentFrame)
        {
            SwitchToPopupView popupForm = new SwitchToPopupView(currentFrame, view);
            popupForm.ShowDialog();
        }

        internal Task TakeAndSaveScreenshot()
        {
            
            var task = new Task(() =>
            {
                EnsureScreenshotsDirectoryExists();

                MyLog.Write("Action: TakeAndSaveScreenshot()");
                try
                {

                    var pageUrl = new Uri(SwdBrowser.GetDriver().Url);
                    var host = pageUrl.Host;
                    string newFileName = DateTime.Now.ToString("yyyy-dd-M__HH-mm-ss") + "_" + host + ".png";
                    string newFilePath = Path.Combine(ScreenshotsLocation, newFileName);
                    
                    Screenshot screenshot = SwdBrowser.TakeScreenshot();
                    screenshot.SaveAsFile(newFilePath, ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    MyLog.Write("Action: TakeAndSaveScreenshot() FAILED");
                    MyLog.Exception(ex);
                    throw;
                }
            });
            task.Start();
            return task;
        }

        private void EnsureScreenshotsDirectoryExists()
        {
            if (!Directory.Exists(ScreenshotsLocation)) {
                Directory.CreateDirectory(ScreenshotsLocation);
            }
        }

        internal void OpenScreenshotsFolder()
        {
            EnsureScreenshotsDirectoryExists();
            Process.Start(ScreenshotsLocation);
        }
    }
}
