using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwdPageRecorder.WebDriver;

namespace SwdPageRecorder.UI
{
    public partial class SwitchToPopupView : Form, IView
    {
        private SwitchToPopupPresenter presenter;
        
        private SwdMainView parentView;

        public SwitchToPopupView(BrowserPageFrame currentFrame, SwdMainView parent)
        {
            InitializeComponent();
            
            this.parentView = parent;
            this.presenter = Presenters.SwitchToPopupPresenter;

            presenter.InitWithView(this);
            presenter.InitWithFrame(currentFrame);
        }

        private void DisplayOnCenter()
        {
            var parentX = parentView.Location.X;
            var parentY = parentView.Location.Y;

            var parentWidth  = parentView.Size.Width;
            var parentHeight = parentView.Size.Height;

            // Place Popup center on Parent Center
            var popupX = parentX + (parentWidth / 2) - (this.Size.Width / 2);
            var popupY = parentY + (parentHeight / 2) - (this.Size.Height / 2);

            // Make sure the popup is displayed on the screen
            popupX = Math.Max(0, popupX);
            popupY = Math.Max(0, popupY);

            this.Location = new Point(popupX, popupY);

        }

        internal void InitLanguagesList(List<string> languagesListItems)
        {
            lstLanguages.Items.AddRange(languagesListItems.ToArray());
            // Should it trigger the Change event? 
            lstLanguages.SelectedIndex = 0;
        }

        private void lstLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.GenerateSwitchToCode(lstLanguages.SelectedIndex);
        }

        internal void DisplayGeneratedCode(string generatedCode)
        {
            txtOutput.Clear();
            txtOutput.Text = generatedCode;
        }

        private void SwitchToPopupView_Shown(object sender, EventArgs e)
        {
            DisplayOnCenter();
        }
    }
}
