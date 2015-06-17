using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwdPageRecorder.UI.SwdMain.Popups.Components.WebDriver
{
    public partial class WebDriverBrowserComponentView : UserControl
    {
        private Label label1;
    
        public WebDriverBrowserComponentView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "WEBDRIVER";
            // 
            // WebDriverBrowserComponentView
            // 
            this.Controls.Add(this.label1);
            this.Name = "WebDriverBrowserComponentView";
            this.Size = new System.Drawing.Size(193, 208);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
