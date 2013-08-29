using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SwdPageRecorder.WebDriver;
using System.Net;
using System.Threading;

namespace SwdPageRecorder.UI
{
    public static class SWDRecorder_Program
    {

     
        
        public static SwdMainView Run(SwdMainView mainForm)
        {
            
            Application.EnableVisualStyles();

            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);

            
            Application.Run(mainForm);
            return mainForm;
        }

        [STAThread]
        static void Main()
        {
            
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new SwdMainView();
            Run(mainForm);
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
