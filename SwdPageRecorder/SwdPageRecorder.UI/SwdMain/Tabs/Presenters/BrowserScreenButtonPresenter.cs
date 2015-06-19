using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwdPageRecorder.WebDriver;

namespace SwdPageRecorder.UI.SwdMain.Tabs.Presenters
{
    public class BrowserScreenButtonPresenter : IPresenter<BrowserScreenButtonView>
    {
        private BrowserScreenButtonView view = null;

        public void InitWithView(BrowserScreenButtonView view)
        {
            this.view = view;
        }

        public void UpdateScreenshot()
        {
            var screenshot = SwdBrowser.TakeScreenshot();

            using (var ms = new MemoryStream(screenshot.AsByteArray))
            {
                var image = Image.FromStream(ms);
                view.UpdateImage(image);
            }
        }
    }
}
