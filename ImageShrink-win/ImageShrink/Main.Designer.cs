namespace ImageShrink
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.AddToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ClearToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.QualityToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.QualityComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.StartToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.HelpToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.WebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SavePathLabel = new System.Windows.Forms.Label();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.BrowseFileButton = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.PathColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OriginalSizeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AfterSizeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileListView = new System.Windows.Forms.ListView();
            this.OpenOutputButton = new System.Windows.Forms.Button();
            this.DragDropPictureBox = new System.Windows.Forms.PictureBox();
            this.LanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DragDropPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.BackColor = System.Drawing.SystemColors.Window;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripButton,
            this.ClearToolStripButton,
            this.toolStripSeparator1,
            this.QualityToolStripLabel,
            this.QualityComboBox,
            this.toolStripSeparator2,
            this.StartToolStripButton,
            this.HelpToolStripDropDownButton});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(10);
            this.ToolStrip.Size = new System.Drawing.Size(443, 44);
            this.ToolStrip.TabIndex = 0;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // AddToolStripButton
            // 
            this.AddToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddToolStripButton.Image")));
            this.AddToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddToolStripButton.Name = "AddToolStripButton";
            this.AddToolStripButton.Size = new System.Drawing.Size(52, 21);
            this.AddToolStripButton.Text = "Add";
            this.AddToolStripButton.Click += new System.EventHandler(this.AddToolStripButton_Click);
            // 
            // ClearToolStripButton
            // 
            this.ClearToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearToolStripButton.Image")));
            this.ClearToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearToolStripButton.Name = "ClearToolStripButton";
            this.ClearToolStripButton.Size = new System.Drawing.Size(58, 21);
            this.ClearToolStripButton.Text = "Clear";
            this.ClearToolStripButton.Click += new System.EventHandler(this.ClearToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 24);
            // 
            // QualityToolStripLabel
            // 
            this.QualityToolStripLabel.Name = "QualityToolStripLabel";
            this.QualityToolStripLabel.Size = new System.Drawing.Size(51, 21);
            this.QualityToolStripLabel.Text = "Quality:";
            // 
            // QualityComboBox
            // 
            this.QualityComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.QualityComboBox.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QualityComboBox.Name = "QualityComboBox";
            this.QualityComboBox.Size = new System.Drawing.Size(75, 24);
            this.QualityComboBox.TextChanged += new System.EventHandler(this.QualityComboBox_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 24);
            // 
            // StartToolStripButton
            // 
            this.StartToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("StartToolStripButton.Image")));
            this.StartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartToolStripButton.Name = "StartToolStripButton";
            this.StartToolStripButton.Size = new System.Drawing.Size(55, 21);
            this.StartToolStripButton.Text = "Start";
            this.StartToolStripButton.Click += new System.EventHandler(this.StartToolStripButton_Click);
            // 
            // HelpToolStripDropDownButton
            // 
            this.HelpToolStripDropDownButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.HelpToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.HelpToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LanguageToolStripMenuItem,
            this.WebsiteToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.HelpToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("HelpToolStripDropDownButton.Image")));
            this.HelpToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HelpToolStripDropDownButton.Name = "HelpToolStripDropDownButton";
            this.HelpToolStripDropDownButton.Size = new System.Drawing.Size(48, 21);
            this.HelpToolStripDropDownButton.Text = "Help";
            // 
            // WebsiteToolStripMenuItem
            // 
            this.WebsiteToolStripMenuItem.Name = "WebsiteToolStripMenuItem";
            this.WebsiteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.WebsiteToolStripMenuItem.Text = "Website";
            this.WebsiteToolStripMenuItem.Click += new System.EventHandler(this.WebsiteToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AboutToolStripMenuItem.Text = "About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // SavePathLabel
            // 
            this.SavePathLabel.AutoSize = true;
            this.SavePathLabel.Location = new System.Drawing.Point(18, 379);
            this.SavePathLabel.Name = "SavePathLabel";
            this.SavePathLabel.Size = new System.Drawing.Size(59, 12);
            this.SavePathLabel.TabIndex = 2;
            this.SavePathLabel.Text = "SavePath:";
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Location = new System.Drawing.Point(83, 375);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.Size = new System.Drawing.Size(219, 21);
            this.OutputTextBox.TabIndex = 3;
            // 
            // BrowseFileButton
            // 
            this.BrowseFileButton.Location = new System.Drawing.Point(303, 374);
            this.BrowseFileButton.Name = "BrowseFileButton";
            this.BrowseFileButton.Size = new System.Drawing.Size(50, 23);
            this.BrowseFileButton.TabIndex = 4;
            this.BrowseFileButton.Text = "Browse";
            this.BrowseFileButton.UseVisualStyleBackColor = true;
            this.BrowseFileButton.Click += new System.EventHandler(this.BrowseFileButton_Click);
            // 
            // PathColumnHeader
            // 
            this.PathColumnHeader.Text = "Path";
            this.PathColumnHeader.Width = 0;
            // 
            // StateColumnHeader
            // 
            this.StateColumnHeader.Text = "State";
            this.StateColumnHeader.Width = 50;
            // 
            // FileColumnHeader
            // 
            this.FileColumnHeader.Text = "File";
            this.FileColumnHeader.Width = 150;
            // 
            // OriginalSizeColumnHeader
            // 
            this.OriginalSizeColumnHeader.Text = "OriginalSize";
            this.OriginalSizeColumnHeader.Width = 100;
            // 
            // AfterSizeColumnHeader
            // 
            this.AfterSizeColumnHeader.Text = "AfterSize";
            this.AfterSizeColumnHeader.Width = 100;
            // 
            // FileListView
            // 
            this.FileListView.AllowDrop = true;
            this.FileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PathColumnHeader,
            this.StateColumnHeader,
            this.FileColumnHeader,
            this.OriginalSizeColumnHeader,
            this.AfterSizeColumnHeader});
            this.FileListView.FullRowSelect = true;
            this.FileListView.GridLines = true;
            this.FileListView.HideSelection = false;
            this.FileListView.Location = new System.Drawing.Point(18, 52);
            this.FileListView.Name = "FileListView";
            this.FileListView.Size = new System.Drawing.Size(406, 300);
            this.FileListView.TabIndex = 1;
            this.FileListView.UseCompatibleStateImageBehavior = false;
            this.FileListView.View = System.Windows.Forms.View.Details;
            this.FileListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ImageFileDragDrop);
            this.FileListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.ImageFileDragEnter);
            // 
            // OpenOutputButton
            // 
            this.OpenOutputButton.Location = new System.Drawing.Point(364, 374);
            this.OpenOutputButton.Name = "OpenOutputButton";
            this.OpenOutputButton.Size = new System.Drawing.Size(60, 23);
            this.OpenOutputButton.TabIndex = 5;
            this.OpenOutputButton.Text = "Open";
            this.OpenOutputButton.UseVisualStyleBackColor = true;
            this.OpenOutputButton.Click += new System.EventHandler(this.OpenOutputButton_Click);
            // 
            // DragDropPictureBox
            // 
            this.DragDropPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DragDropPictureBox.BackgroundImage")));
            this.DragDropPictureBox.Location = new System.Drawing.Point(146, 127);
            this.DragDropPictureBox.Name = "DragDropPictureBox";
            this.DragDropPictureBox.Size = new System.Drawing.Size(150, 150);
            this.DragDropPictureBox.TabIndex = 6;
            this.DragDropPictureBox.TabStop = false;
            // 
            // LanguageToolStripMenuItem
            // 
            this.LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem";
            this.LanguageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.LanguageToolStripMenuItem.Text = "Language";
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(443, 417);
            this.Controls.Add(this.OpenOutputButton);
            this.Controls.Add(this.BrowseFileButton);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.SavePathLabel);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.FileListView);
            this.Controls.Add(this.DragDropPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageShrink";
            this.Load += new System.EventHandler(this.Main_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ImageFileDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ImageFileDragEnter);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DragDropPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.Label SavePathLabel;
        private System.Windows.Forms.ToolStripButton AddToolStripButton;
        private System.Windows.Forms.ToolStripButton ClearToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel QualityToolStripLabel;
        private System.Windows.Forms.ToolStripComboBox QualityComboBox;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button BrowseFileButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton StartToolStripButton;
        private System.Windows.Forms.ToolStripDropDownButton HelpToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem WebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.ColumnHeader PathColumnHeader;
        private System.Windows.Forms.ColumnHeader StateColumnHeader;
        private System.Windows.Forms.ColumnHeader FileColumnHeader;
        private System.Windows.Forms.ColumnHeader OriginalSizeColumnHeader;
        private System.Windows.Forms.ColumnHeader AfterSizeColumnHeader;
        private System.Windows.Forms.ListView FileListView;
        private System.Windows.Forms.Button OpenOutputButton;
        private System.Windows.Forms.PictureBox DragDropPictureBox;
        private System.Windows.Forms.ToolStripMenuItem LanguageToolStripMenuItem;
    }
}

