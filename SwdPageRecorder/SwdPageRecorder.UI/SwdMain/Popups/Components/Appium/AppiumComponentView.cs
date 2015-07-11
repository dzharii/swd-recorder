using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwdPageRecorder.UI.SwdMain.Popups.Components.Appium
{
    public partial class AppiumComponentView : UserControl
    {
        private Label label1;
    
        public AppiumComponentView()
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
            this.label1.Location = new System.Drawing.Point(64, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "APPIUM";
            // 
            // AppiumComponentView
            // 
            this.Controls.Add(this.label1);
            this.Name = "AppiumComponentView";
            this.Size = new System.Drawing.Size(201, 246);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
