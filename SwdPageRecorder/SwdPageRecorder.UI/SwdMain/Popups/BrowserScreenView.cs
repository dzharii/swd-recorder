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
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SwdPageRecorder.WebDriver;
using WINKeys = System.Windows.Forms.Keys;

namespace SwdPageRecorder.UI.SwdMain.Popups
{
    public partial class BrowserScreenView : Form
    {

        UserCommandProcessor UserCommand { get; set; }
        
        public BrowserScreenView()
        {
            UserCommand = new UserCommandProcessor();
            InitializeComponent();

            UserCommand.OnMouseClick += UserCommand_OnMouseClick;
            
        }

        void UserCommand_OnMouseClick(UserCommands.MouseClickCommand evt)
        {
            MouseEventArgs mouse = evt.MouseEvent;
            int absoluteX = mouse.X;
            int absoluteY = mouse.Y;


            absoluteX = (Convert.ToInt32(absoluteX / imgBox.ZoomFactor) + Convert.ToInt32(imgBox.HorizontalScroll.Value / imgBox.ZoomFactor));
            absoluteY = Convert.ToInt32(absoluteY / imgBox.ZoomFactor) + Convert.ToInt32(imgBox.VerticalScroll.Value / imgBox.ZoomFactor);

            if (!ModifierKeys.HasFlag(WINKeys.Control))
            {

                var clickCommand = String.Format(@"return document.elementFromPoint({0}, {1});", absoluteX, absoluteY);
                IWebElement element = (IWebElement)SwdBrowser.ExecuteJavaScript(clickCommand);
                // element.Click();

                Actions actions = new Actions(SwdBrowser.GetDriver());
                actions.MoveToElement(element)
                       .Click()
                       .Perform();

                button1_Click(this, null);

                return;
            };


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

            //SwdBrowser.ExecuteJavaScript(script, absoluteX, absoluteY);
            button1_Click(null, null);
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


        }

        private void imgBox_MouseWheel(object sender, MouseEventArgs e)
        {

        }

        private void imgBox_MouseClick(object sender, MouseEventArgs e)
        {
            bool isZoomingUp = e.Delta > 0;
            bool allowZoom = imgBox.ZoomFactor > 1 || imgBox.ZoomFactor == 1.0 && isZoomingUp;
            imgBox.AllowZoom = allowZoom;

            if (imgBox.ZoomFactor < 1) imgBox.Zoom = 100;

        }

        private void imgBox_MouseDown(object sender, MouseEventArgs evt)
        {
            UserCommand.AddMouseDown(evt);
        }

        private void imgBox_MouseMove(object sender, MouseEventArgs evt)
        {
            UserCommand.AddMouseMove(evt);
        }

        private void imgBox_MouseUp(object sender, MouseEventArgs evt)
        {
            UserCommand.AddMouseUp(evt);
        }
    }
}
