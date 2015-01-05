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

using System.Net;

namespace SwdPageRecorder.UI
{
    public class SwitchToPopupPresenter : IPresenter<SwitchToPopupView>
    {
        const int LANG_INTERNAL = 0;
        const int LANG_CSHARP = 1;
        const int LANG_JAVA = 2;

        List<string> languagesListItems = new List<string>();
        BrowserPageFrame currentFrame = null;

        public SwitchToPopupPresenter()
        {
            languagesListItems.Add("Dot-separated list of IDs");
            languagesListItems.Add("C#");
            languagesListItems.Add("Java");
        }
        
        
        private SwitchToPopupView view = null;

        public void InitWithView(SwitchToPopupView view)
        {
            this.view = view;
        }

        internal void InitWithFrame(BrowserPageFrame currentFrame)
        {
            this.currentFrame = currentFrame;
            this.view.InitLanguagesList(languagesListItems);
        }

        internal void GenerateSwitchToCode(int outputLanguage)
        {
            string result = "";
            int[] currentFramePath = currentFrame.GetPath().Skip(1).ToArray();
            switch (outputLanguage)
            {
                case LANG_INTERNAL:
                    result = GenerateDotSeparatedCode(currentFramePath);
                    break;
                case LANG_CSHARP:
                    result = GenerateCSharpCode(currentFramePath);
                    break;
                case LANG_JAVA:
                    result = GenerateJavaCode(currentFramePath);
                    break;
            }

            view.DisplayGeneratedCode(result);

        }

        private string GenerateCSharpCode(int[] currentFramePath)
        {
            if (currentFramePath.Length == 0)
            {
                return String.Empty;
            }

            StringBuilder result = new StringBuilder("driver");
            foreach (var frameIndex in currentFramePath)
            {
                result.AppendFormat(".SwitchTo().Frame({0})", frameIndex);
            }
            result.Append(";");
            return result.ToString();
        }

        private string GenerateJavaCode(int[] currentFramePath)
        {
            if (currentFramePath.Length == 0)
            {
                return String.Empty;
            }

            StringBuilder result = new StringBuilder("driver");
            foreach (var frameIndex in currentFramePath)
            {
                result.AppendFormat(".switchTo().frame({0})", frameIndex);
            }
            result.Append(";");
            return result.ToString();
        }

        private string GenerateDotSeparatedCode(int[] framePath)
        {
            string result = String.Join(".", framePath);
            return result;
        }
    }
}
