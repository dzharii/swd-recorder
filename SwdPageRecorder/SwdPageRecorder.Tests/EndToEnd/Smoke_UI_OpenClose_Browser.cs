using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

using SwdPageRecorder.TestModel;

using System.IO;




namespace SwdPageRecorder.Tests.EndToEnd
{
    [TestClass]
    public class Smoke_UI_OpenClose_Browser : MyTest
    {
        //http://teststack.azurewebsites.net/White/UIItems.html


        private void OpenAppWithBrowser(string browserName)
        {
            var mainWin = MainWindow.GetWindow();
            mainWin.DisplayState = DisplayState.Maximized;

            var browserSettingsTab = new BrowserSettingsTabWindow();

            browserSettingsTab.SelectBrowser(browserName);
            browserSettingsTab.StartBrowser();

            UglySleep();

            browserSettingsTab.WaitWhileWaitingIndicatorDisplayed();

            browserSettingsTab.StopBrowser();
            
            UglySleep();
            browserSettingsTab.WaitWhileWaitingIndicatorDisplayed();
            
            mainWin.Close();
            App.Close();
        }

        private static void UglySleep()
        {
            System.Threading.Thread.Sleep(500);
        }



        [TestMethod, TestCategory("UI")]
        public void Start_and_Stop_Open_Recorder_with_Firefox()
        {
            OpenAppWithBrowser("Firefox");
        }

        [TestMethod, TestCategory("UI")]
        public void Start_and_Stop_Open_Recorder_with_Google_Chrome()
        {
            OpenAppWithBrowser("Chrome");
        }

        [TestMethod, TestCategory("UI")]
        public void Start_and_Stop_Open_Recorder_with_PahntomJS()
        {
            OpenAppWithBrowser("PhantomJS");
        }

        [TestMethod, TestCategory("UI")]
        public void Start_and_Stop_Open_Recorder_with_InternetExplorer()
        {
            OpenAppWithBrowser("InternetExplorer");
        }

    }
}
