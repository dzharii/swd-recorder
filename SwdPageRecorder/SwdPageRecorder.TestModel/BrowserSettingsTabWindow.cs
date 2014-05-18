using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace SwdPageRecorder.TestModel
{
    public class BrowserSettingsTabWindow : MyBaseWindow
    {
        private ComboBox ddlBrowserToStart()
        {
            return Get<ComboBox>("ddlBrowserToStart");
        }


        private Button btnStart()
        {
            return Get<Button>("btnStartWebDriver");
        }

        private Button btnStop()
        {
            return btnStart(); // Magic!
        }


        public BrowserSettingsTabWindow SelectBrowser(string browserName)
        {
            ddlBrowserToStart()
                .Items
                .Where(n => n.Text == browserName)
                .First()
                .Select();

            return this;
        }

        public BrowserSettingsTabWindow StartBrowser()
        {
            btnStart().RaiseClickEvent();
            return this;
        }

        public BrowserSettingsTabWindow StopBrowser()
        {
            btnStop().RaiseClickEvent();
            return this;
        }
    }
}
