using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwdPageRecorder.WebDriver;

namespace SwdPageRecorder.UI.SwdMain.Popups
{
    public partial class BrowserScreenView : Form
    {
        public BrowserScreenView()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var screenshot = SwdBrowser.TakeScreenshot();
            //screenshot.AsByteArray

            imgBox.Zoom = 100;

            using (var ms = new MemoryStream(screenshot.AsByteArray))
            {
                imgBox.Image = Image.FromStream(ms);
            }

        }

        private void imgBox_Click(object sender, EventArgs args)
        {

            if (!ModifierKeys.HasFlag(Keys.Control)) return;
            
            MouseEventArgs mouse = args as MouseEventArgs;

            
                        
            int absoluteX = mouse.X; // + ;
            int absoluteY = mouse.Y; // + ;


            absoluteX = (Convert.ToInt32(absoluteX / imgBox.ZoomFactor) + Convert.ToInt32(imgBox.HorizontalScroll.Value / imgBox.ZoomFactor)) ;
            absoluteY = Convert.ToInt32(absoluteY / imgBox.ZoomFactor) + Convert.ToInt32(imgBox.VerticalScroll.Value / imgBox.ZoomFactor);
            

            string script =
            @"(function showRectangle(x, y) {
                var rectangle = document.createElement('div');
                rectangle.style.border = '3px solid red';
                rectangle.style.position = 'absolute';
                
                rectangle.style.left = x + 'px';
                rectangle.style.top  = y + 'px';

                rectangle.style.width  = '100px';
                rectangle.style.height = '20px';

                document.body.appendChild(rectangle);
                setTimeout(function cbRemoveRectangle() {
                    doNastyStuff();
                }, 2000);
            })(arguments[0], arguments[1]);";

            SwdBrowser.ExecuteJavaScript(script, absoluteX, absoluteY);
        }

        private void imgBox_MouseWheel(object sender, MouseEventArgs e)
        {
            bool isZoomingUp = e.Delta > 0;
            bool allowZoom = imgBox.ZoomFactor > 1 || imgBox.ZoomFactor == 1.0 && isZoomingUp;
            imgBox.AllowZoom = allowZoom;

            if (imgBox.ZoomFactor < 1) imgBox.Zoom = 100;
        }
    }
}
