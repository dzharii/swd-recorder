using System;
using SwdPageRecorder.WebDriver;

namespace SwdPageRecorder.UI
{
    public class FullHtmlSourceTabPresenter: IPresenter<FullHtmlSourceTabView>
    {
        private FullHtmlSourceTabView view;

        public void InitWithView(FullHtmlSourceTabView view)
        {
            this.view = view;

            // Subscribe to WebDriverUtils events
            SwdBrowser.OnDriverStarted += InitControls;
            SwdBrowser.OnDriverClosed += InitControls;
            InitControls();
        }

        private void InitControls()
        {
            var shouldControlBeEnabled = SwdBrowser.IsWorking;
            view.btnGetHtmlSource.Enabled = shouldControlBeEnabled;
            view.txtHtmlPageSource.Enabled = shouldControlBeEnabled;
        }

        internal void DisplayHtmlPageSource()
        {
            string htmlSource = SwdBrowser.GetHtml();
            view.FillHtmlCodeBox(htmlSource);
        }



        internal void TidyHtml(string htmlContent)
        {

            throw new NotImplementedException();
        }
    }
}
