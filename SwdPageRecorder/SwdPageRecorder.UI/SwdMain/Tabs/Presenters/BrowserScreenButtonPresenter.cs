using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SwdPageRecorder.WebDriver;

namespace SwdPageRecorder.UI.SwdMain.Tabs.Presenters
{
    public class BrowserScreenButtonPresenter : IPresenter<BrowserScreenButtonView>
    {
        private BrowserScreenButtonView view = null;

        public void InitWithView(BrowserScreenButtonView view)
        {
            this.view = view;

        SwdBrowser.OnNewScreenshotTaken += SwdBrowser_OnNewScreenshotTaken;

        }

        /// <summary>
        /// \TODO: Duplicate!!!
        /// </summary>
        /// <param name="screenshot"></param>
        void SwdBrowser_OnNewScreenshotTaken(Screenshot screenshot)
        {
            using (var ms = new MemoryStream(screenshot.AsByteArray))
            {

                Bitmap src = Image.FromStream(ms) as Bitmap;
                
                Rectangle cropRect = new Rectangle { 
                  Width = src.Width,
                  Height = Math.Min(src.Height, 700)
                };
                
                Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

                using(Graphics g = Graphics.FromImage(target))
                {
                   g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height), 
                                    cropRect,                        
                                    GraphicsUnit.Pixel);
                }
                
                view.UpdateImage(target);
            }
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
