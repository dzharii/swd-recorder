using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwdPageRecorder.WebDriver
{

    public class PageSourceWatcher
    {
        private Task watcher;

        public event Action OnPageSourceChanged;

        string previousHtmlSource = null;
        CancellationTokenSource cancelationSource;
        CancellationToken cancelationToken;

        public PageSourceWatcher()
        {
            cancelationSource = new CancellationTokenSource();
            cancelationToken = cancelationSource.Token;
            watcher = new Task(PageSourceWatcherWorker, cancelationToken);
            
        }

        public void Start()
        {
            watcher.Start();
            MyLog.Write("PageSourceWatcher Started");
        }

        public void Stop()
        {
            cancelationSource.Cancel();
            MyLog.Write("PageSourceWatcher Stopped");
        }



        public void PageSourceWatcherWorker()
        {
            cancelationToken.ThrowIfCancellationRequested();

            while (true)
            {
                cancelationToken.ThrowIfCancellationRequested();

                try
                {
                    if (SwdBrowser.IsWorking)
                    {
                        var actualSource = SwdBrowser.GetDriver().PageSource ?? "";
                        if (previousHtmlSource != actualSource)
                        {
                            previousHtmlSource = actualSource;

                            if (OnPageSourceChanged != null)
                            {
                                OnPageSourceChanged();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MyLog.Write("PageSourceWatcher Exception");
                    MyLog.Exception(ex);
                }

                Task.Delay(1000, cancelationToken);
            }
        }
    }
}
