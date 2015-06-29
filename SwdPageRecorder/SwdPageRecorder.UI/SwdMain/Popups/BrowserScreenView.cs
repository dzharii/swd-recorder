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
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SwdPageRecorder.WebDriver;
using WINKeys = System.Windows.Forms.Keys;

namespace SwdPageRecorder.UI.SwdMain.Popups
{
    public partial class BrowserScreenView : Form
    {
        /* HAS Changes Script
         
        (function() {
            var result = {};
            var activeEl = document.activeElement || {};
            var expectedPropsTypes = ["string", "number", "boolean"];

            for(var propName in activeEl) {
                var shouldCollect = expectedPropsTypes.indexOf(typeof activeEl[propName]) >= 0;

                if (shouldCollect && activeEl[propName]) {
                    result[propName] = activeEl[propName];
                }
            }
            var jsonResult = "";
            try {
                jsonResult = JSON.stringify(result);
            }
            catch (e) {
                console.warn("SWD Error ignored:", e);
            }
            return jsonResult;
        })();         
         
         
         */


        UserCommandProcessor UserCommand { get; set; }
        


        public BrowserScreenView()
        {
            UserCommand = new UserCommandProcessor();
            InitializeComponent();
            imgBox.Zoom = 100;

            var lastImage = SwdBrowser.LatestScreenshot;
            
            if (lastImage != null)
            {
                UpdateScreenshot(lastImage);
            }


            RegisterEvents();            
        }

        public void RegisterEvents() {
            UserCommand.OnMouseClick += UserCommand_OnMouseClick;
            SwdBrowser.OnNewScreenshotTaken += SwdBrowser_OnNewScreenshotTaken;        
        }

        public void UnregisterEvents()
        {
            UserCommand.OnMouseClick -= UserCommand_OnMouseClick;
            SwdBrowser.OnNewScreenshotTaken -= SwdBrowser_OnNewScreenshotTaken;
        }

        void SwdBrowser_OnNewScreenshotTaken(Screenshot screenshot)
        {
            UpdateScreenshot(screenshot);
        }


        void UserCommand_OnMouseClick(UserCommands.MouseClickCommand evt)
        {
            MouseEventArgs mouse = evt.MouseEvent;
            var imageViewPort = imgBox.GetImageViewPort();

            int absoluteX = mouse.X - imageViewPort.Left;
            int absoluteY = mouse.Y - imageViewPort.Top;


            absoluteX = (Convert.ToInt32(absoluteX / imgBox.ZoomFactor) + Convert.ToInt32(imgBox.HorizontalScroll.Value / imgBox.ZoomFactor));
            absoluteY = Convert.ToInt32(absoluteY / imgBox.ZoomFactor) + Convert.ToInt32(imgBox.VerticalScroll.Value / imgBox.ZoomFactor);


            txtLog.DoInvokeAction(() =>
            {
                txtLog.Text += "\r\n" + "X " + absoluteX.ToString() + " Y " + absoluteY.ToString();
            });




            if (!ModifierKeys.HasFlag(WINKeys.Control))
            {



            };


            

            var clickCommand =
            @"return (function SWD_GET_ELEMENT() {
                  var absoluteX = {## absoluteX ##};
                  var absoluteY = {## absoluteY ##};
                  var view = {
                      Left: window.scrollX,
                      Top: window.scrollY,        
                      Right: window.scrollX + window.innerWidth,
                      Bottom: window.scrollY + window.innerHeight
                  };
              
                  var elementInsideViewPort = (view.Left <= absoluteX && absoluteX <= view.Right) &&
                                              (view.Top <= absoluteY && absoluteY <= view.Bottom);
                  if (!elementInsideViewPort) {
                    window.scroll(Math.max(absoluteX - 30, 0), Math.max(absoluteY - 30, 0));
                  }
                  absoluteX = absoluteX - window.scrollX;
                  absoluteY = absoluteY - window.scrollY;
                  return document.elementFromPoint(absoluteX, absoluteY);
              })()"
            .Replace("{## absoluteX ##}", absoluteX.ToString())
            .Replace("{## absoluteY ##}", absoluteY.ToString());

            IWebElement element = (IWebElement)SwdBrowser.ExecuteJavaScript(clickCommand);
            // element.Click();

            if (element == null) 
            {
                MyLog.Error("Element is null after performing command " + clickCommand ?? "<null>");
                return;
            }
            if (element.TagName == "iframe")
            {
                try
                {
                    var frameLocation = element.Location;
                    absoluteX = absoluteX - frameLocation.X;
                    absoluteY = absoluteY - frameLocation.Y;

                    MyLog.Debug("Switching to IFrame");
                    SwdBrowser.GetDriver().SwitchTo().Frame(element);

                    clickCommand = String.Format(@"return document.elementFromPoint({0}, {1});", absoluteX, absoluteY);
                    element = (IWebElement)SwdBrowser.ExecuteJavaScript(clickCommand);
                    ClickOnElement(absoluteX, absoluteY, element);
                }
                finally
                {
                    SwdBrowser.SwitchToDefaultContent();
                }
            }
            else
            {
                ClickOnElement(absoluteX, absoluteY, element);
            }
        }

        private static void DrawMarker(int absoluteX, int absoluteY)
        {
            string script =
            @"(function showRectangle(x, y) {
                var rectangle = document.createElement('div');
                rectangle.style.background = 'red';
                rectangle.style.position = 'absolute';
                rectangle.style.borderRadius = '50%';
                
                rectangle.style.left = (x - 5) + 'px';
                rectangle.style.top  = (y - 5) + 'px';

                rectangle.style.width  = '10px';
                rectangle.style.height = '10px';

                document.body.appendChild(rectangle);
                setTimeout(function cbRemoveRectangle() {
                    if (rectangle) {
                        rectangle.remove();
                    }
                }, 2000);
            })(arguments[0], arguments[1]);";

            SwdBrowser.ExecuteJavaScript(script, absoluteX, absoluteY);
        }

        private void ClickOnElement(int absoluteX, int absoluteY, IWebElement element)
        {
            MyLog.Debug("Element from point: " + SafeDump(element));
            var elementLocation = element.Location;
            int offsetX = absoluteX - elementLocation.X;
            int offsetY = absoluteY - elementLocation.Y;

            if (element != null)
            {
                DrawMarker(absoluteX, absoluteY);

                
                //Actions actions = new Actions(SwdBrowser.GetDriver());
                //actions.MoveToElement(element, offsetX, offsetY)
                //       .Click()
                //       .Perform();

                element.Click();
                
            }
            else
            {
                MyLog.Error(String.Format(@"The call returned NULL element: return document.elementFromPoint({0}, {1});", absoluteX, absoluteY));

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var screenshot = SwdBrowser.TakeScreenshot();
            //screenshot.AsByteArray

            //imgBox.Zoom = 100;

            UpdateScreenshot(screenshot);

        }

        private void UpdateScreenshot(Screenshot screenshot)
        {
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
           
            //bool isZoomingUp = e.Delta > 0;
            //bool allowZoom = imgBox.ZoomFactor > 1 || imgBox.ZoomFactor == 1.0 && isZoomingUp;
            //imgBox.AllowZoom = allowZoom;

            //if (imgBox.ZoomFactor < 1) imgBox.Zoom = 100;

        }

        private void imgBox_MouseDown(object sender, MouseEventArgs evt)
        {
            UserCommand.AddMouseDown(evt);
        }

        private void imgBox_MouseMove(object sender, MouseEventArgs evt)
        {
            // UserCommand.AddMouseMove(evt);
        }

        private void imgBox_MouseUp(object sender, MouseEventArgs evt)
        {
            UserCommand.AddMouseUp(evt);
        }


        private string SafeDump(object target) 
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Error = new EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs>((s, args) => { args.ErrorContext.Handled = true;  }),
                MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return JsonConvert.SerializeObject(target, 
                                               Formatting.Indented, 
                                               settings);

        
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                
            };

            txtLog.DoInvokeAction(() =>
            {
                txtLog.Text = JsonConvert.SerializeObject(imgBox.GetImageViewPort(), Formatting.Indented, settings)
                               + "\r\n"
                               + JsonConvert.SerializeObject(imgBox.GetInsideViewPort(), Formatting.Indented, settings);
            });

        }

        private void imgBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SwdBrowser.GetDriver().SwitchTo().ActiveElement().SendKeys(e.KeyChar.ToString());
        }

        private void BrowserScreenView_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterEvents();
        }
    }
}
