using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwdPageRecorder.WebDriver
{
    public class BrowserWindow
    {
        public string WindowHandle { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return Title ?? "";
        }
    }
}
