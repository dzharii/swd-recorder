using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

using System.Diagnostics;

namespace SwdPageRecorder.TestModel
{
    public abstract class MyBaseWindow
    {
        public  T Get<T>(string primaryIdentification) where T : IUIItem
        {
            MainWindow.GetWindow().Focus();
            return MainWindow.GetWindow().Get<T>(primaryIdentification);
        }

        protected Label lblWaitingIndicator()
        {
            return Get<Label>("lblLoadingInProgress");
        }

        public void WaitWhileWaitingIndicatorDisplayed()
        {
            Stopwatch sw = new Stopwatch();

            try
            {
                System.Threading.Thread.Sleep(100);
                var waitingIndicator = lblWaitingIndicator();

                sw.Start();
                while (waitingIndicator.Visible)
                {
                    System.Threading.Thread.Sleep(100);
                    if (sw.Elapsed > TimeSpan.FromSeconds(30))
                    {
                        Console.WriteLine("WaitWhileWaitingIndicatorDisplayedL Operation took more than 30 seconds :(");
                        return;
                    }
                }
            }
            catch { }
        }
    }
}
