using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwdPageRecorder.UI.SwdMain.Popups;
using SwdPageRecorder.UI.SwdMain.Tabs.Presenters;

namespace SwdPageRecorder.UI.SwdMain.Tabs
{
    public partial class BrowserScreenButtonView : UserControl,  IView
    {
        public BrowserScreenButtonPresenter Presenter { get; private set; }
    
        public BrowserScreenButtonView()
        {
            InitializeComponent();
            Presenter = MyPresenters.BrowserScreenButtonPresenter;
            Presenter.InitWithView(this);
        }

        private void imgBox_DoubleClick(object sender, EventArgs e)
        {


        }

        private void btnOpenBrowserScreen_Click(object sender, EventArgs e)
        {
            var browserScreenView = new BrowserScreenView();
            browserScreenView.Show();
        }

        public void UpdateImage(Image image)
        {
            imgBox.Image = image;
            imgBox.ZoomToRegion(0, 0, imgBox.Width, imgBox.Height);

        }
    }
}
