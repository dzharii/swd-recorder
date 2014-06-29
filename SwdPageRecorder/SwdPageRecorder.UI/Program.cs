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
        
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new ThreadExceptionHandler().ApplicationThreadException;
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
                        
            var mainForm = new SwdMainView();
            Application.Run(mainForm);
        }

        internal class ThreadExceptionHandler
        {
            public void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
            {
                MyLog.Exception(e.Exception);
                string exceptionType = string.Format("Error type: ({0})", e.Exception.GetType().ToString());
                MessageBox.Show(e.Exception.Message + "\r\n" + exceptionType, "SWD Page Recorder - Error");
            }
        }


        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            SwdBrowser.CloseDriver();
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            SwdBrowser.CloseDriver();
        }

        public static void CloseApplication()
        {
            SwdBrowser.CloseDriver();
            Application.Exit();
        }



    }
}
