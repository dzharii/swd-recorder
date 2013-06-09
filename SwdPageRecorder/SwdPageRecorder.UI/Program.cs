using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SwdPageRecorder.WebDriver;
using System.Net;

namespace SwdPageRecorder.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //GlobalProxySelection.Select = new  WebProxy("127.0.0.1", 8888);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);

            Application.Run(new SwdMainView());
                        
        }



        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            SwdBrowser.CloseDriver();
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            SwdBrowser.CloseDriver();
        }
    }
}
