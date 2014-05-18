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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("WebElements:");
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.propPageElement = new System.Windows.Forms.PropertyGrid();
            this.btnViewInWindowsExplorer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSavePageObject = new System.Windows.Forms.Button();
            this.btnNewPageObject = new System.Windows.Forms.Button();
            this.cbPageObjectFiles = new System.Windows.Forms.ComboBox();
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
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.propPageElement);
            this.groupBox4.Controls.Add(this.btnViewInWindowsExplorer);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.btnSavePageObject);
            this.groupBox4.Controls.Add(this.btnNewPageObject);
            this.groupBox4.Controls.Add(this.cbPageObjectFiles);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.tvWebElements);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(238, 475);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Page Object";
            // 
            // propPageElement
            // 
            this.propPageElement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propPageElement.Location = new System.Drawing.Point(7, 214);
            this.propPageElement.Name = "propPageElement";
            this.propPageElement.Size = new System.Drawing.Size(224, 215);
            this.propPageElement.TabIndex = 9;
            // 
            // btnViewInWindowsExplorer
            // 
            this.btnViewInWindowsExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewInWindowsExplorer.Location = new System.Drawing.Point(146, 23);
            this.btnViewInWindowsExplorer.Name = "btnViewInWindowsExplorer";
            this.btnViewInWindowsExplorer.Size = new System.Drawing.Size(42, 23);
            this.btnViewInWindowsExplorer.TabIndex = 8;
            this.btnViewInWindowsExplorer.Text = "Files";
            this.btnViewInWindowsExplorer.UseVisualStyleBackColor = true;
            this.btnViewInWindowsExplorer.Click += new System.EventHandler(this.btnViewInWindowsExplorer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "PageObject File:";
            // 
            // btnSavePageObject
            // 
            this.btnSavePageObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavePageObject.Location = new System.Drawing.Point(189, 23);
            this.btnSavePageObject.Name = "btnSavePageObject";
            this.btnSavePageObject.Size = new System.Drawing.Size(42, 23);
            this.btnSavePageObject.TabIndex = 6;
            this.btnSavePageObject.Text = "Save";
            this.btnSavePageObject.UseVisualStyleBackColor = true;
            this.btnSavePageObject.Click += new System.EventHandler(this.btnSavePageObject_Click);
            // 
            // btnNewPageObject
            // 
            this.btnNewPageObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewPageObject.Location = new System.Drawing.Point(98, 23);
            this.btnNewPageObject.Name = "btnNewPageObject";
            this.btnNewPageObject.Size = new System.Drawing.Size(42, 23);
            this.btnNewPageObject.TabIndex = 5;
            this.btnNewPageObject.Text = "New";
            this.btnNewPageObject.UseVisualStyleBackColor = true;
            this.btnNewPageObject.Click += new System.EventHandler(this.btnNewPageObject_Click);
            // 
            // cbPageObjectFiles
            // 
            this.cbPageObjectFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPageObjectFiles.FormattingEnabled = true;
            this.cbPageObjectFiles.Location = new System.Drawing.Point(7, 48);
            this.cbPageObjectFiles.Name = "cbPageObjectFiles";
            this.cbPageObjectFiles.Size = new System.Drawing.Size(224, 21);
            this.cbPageObjectFiles.TabIndex = 4;
            this.cbPageObjectFiles.SelectionChangeCommitted += new System.EventHandler(this.cbPageObjectFiles_SelectionChangeCommitted);
            this.cbPageObjectFiles.TextChanged += new System.EventHandler(this.cbPageObjectFiles_TextChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.lblLastCallTime);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Location = new System.Drawing.Point(6, 435);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(225, 34);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Stats";
            // 
            // lblLastCallTime
            // 
            this.lblLastCallTime.AutoSize = true;
            this.lblLastCallTime.Location = new System.Drawing.Point(61, 16);
            this.lblLastCallTime.Name = "lblLastCallTime";
            this.lblLastCallTime.Size = new System.Drawing.Size(26, 13);
            this.lblLastCallTime.TabIndex = 1;
            this.lblLastCallTime.Text = "0ms";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Call time:";
            // 
            // tvWebElements
            // 
            this.tvWebElements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvWebElements.Location = new System.Drawing.Point(7, 75);
            this.tvWebElements.Name = "tvWebElements";
            treeNode1.Name = "Node0";
            treeNode1.Text = "WebElements:";
            this.tvWebElements.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvWebElements.Size = new System.Drawing.Size(225, 133);
            this.tvWebElements.TabIndex = 2;
            this.tvWebElements.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvWebElements_NodeMouseClick);
            this.tvWebElements.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvWebElements_NodeMouseDoubleClick);
            this.tvWebElements.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvWebElements_DragDrop);
            this.tvWebElements.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvWebElements_DragEnter);
            this.tvWebElements.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tvWebElements_KeyUp);
            // 
            // PageObjectDefinitionView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.groupBox4);
            this.Name = "PageObjectDefinitionView";
            this.Size = new System.Drawing.Size(246, 486);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        public System.Windows.Forms.Button btnSavePageObject;
        public System.Windows.Forms.Button btnNewPageObject;
        public System.Windows.Forms.ComboBox cbPageObjectFiles;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnViewInWindowsExplorer;
        public System.Windows.Forms.PropertyGrid propPageElement;
    }
}
