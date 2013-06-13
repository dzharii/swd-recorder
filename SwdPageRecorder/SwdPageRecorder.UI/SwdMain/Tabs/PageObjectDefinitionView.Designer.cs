namespace SwdPageRecorder.UI
{
    partial class PageObjectDefinitionView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Pages");
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblLastCallTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tvWebElements = new System.Windows.Forms.TreeView();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.tvWebElements);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(238, 475);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Page Object";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblLastCallTime);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Location = new System.Drawing.Point(6, 235);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(225, 154);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Stats";
            // 
            // lblLastCallTime
            // 
            this.lblLastCallTime.AutoSize = true;
            this.lblLastCallTime.Location = new System.Drawing.Point(62, 28);
            this.lblLastCallTime.Name = "lblLastCallTime";
            this.lblLastCallTime.Size = new System.Drawing.Size(26, 13);
            this.lblLastCallTime.TabIndex = 1;
            this.lblLastCallTime.Text = "0ms";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Call time:";
            // 
            // tvWebElements
            // 
            this.tvWebElements.LabelEdit = true;
            this.tvWebElements.Location = new System.Drawing.Point(6, 19);
            this.tvWebElements.Name = "tvWebElements";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Pages";
            this.tvWebElements.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvWebElements.Size = new System.Drawing.Size(225, 186);
            this.tvWebElements.TabIndex = 2;
            this.tvWebElements.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvWebElements_NodeMouseDoubleClick);
            // 
            // PageObjectDefinitionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Name = "PageObjectDefinitionView";
            this.Size = new System.Drawing.Size(246, 486);
            this.groupBox4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.Label lblLastCallTime;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TreeView tvWebElements;
    }
}
