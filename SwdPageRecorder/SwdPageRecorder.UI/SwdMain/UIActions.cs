using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using SwdPageRecorder.WebDriver;
using SwdPageRecorder.WebDriver.JsCommand;

using System.Xml;
using System.Xml.Linq;

using System.Windows.Forms;
using System.Diagnostics;

using System.Net;


namespace SwdPageRecorder.UI
{
    public class UIActions
    {
        private static bool threadFinished = false;
        private static void ThreadWorker(Action operation, out Exception exception, Action<Exception> onException)
        {
            Exception threadException = null;
            try
            {
                operation();
            }
            catch (Exception e)
            {
                if (onException != null) onException(e);
                threadException = e;
            }
            finally
            {
                threadFinished = true;
                exception = threadException;
            }
        }

        public static bool PerformSlowOperation(string operationId, Action operation, out Exception exception, Action<Exception> onThreadException, TimeSpan operationTimeout)
        {
            MyLog.Write("PerformSlowOperation: Started for operation: " + operationId);

            bool isSuccessful  = true;
            threadFinished = false;
            exception = null;

            Exception threadException = null;

            Thread opThread = new Thread(
            () =>
            {
                ThreadWorker(operation, out threadException, onThreadException);
            });


            Presenters.SwdMainPresenter.DisplayLoadingIndicator(true);
            
            Stopwatch timeSpent = new Stopwatch();
            timeSpent.Start();

            opThread.Start();
            
            while (!threadFinished)
            {
                Application.DoEvents();

                if (timeSpent.Elapsed > operationTimeout)
                {
                    Presenters.SwdMainPresenter.DisplayLoadingIndicator(false);

                    string errorMessage = "Timeout had occurred while performing operation << "
                                                + operationId + " >>. Timeout was: "
                                                + operationTimeout.TotalSeconds + "sec";
                    MyLog.Error(errorMessage);
                    throw new TimeoutException(errorMessage);
                }
                
            }

            if (threadException != null)
            {
                MyLog.Write("PerformSlowOperation: Found Exception: " + threadException.Message);
                isSuccessful = false;
                exception = threadException;
            }

            Presenters.SwdMainPresenter.DisplayLoadingIndicator(false);
            
            MyLog.Write("PerformSlowOperation: Finished for operation: " + operationId);
            MyLog.Write("PerformSlowOperation: Operation result: " + (isSuccessful ? "successful :)" : "unsuccessful :("));

            return isSuccessful;

        }
    }
}
