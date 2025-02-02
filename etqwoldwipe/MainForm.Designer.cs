namespace etqwoldwipe
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSearchGame = new System.Windows.Forms.Button();
            this.txtGamePath = new System.Windows.Forms.TextBox();
            this.txtUserPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getMD5sFromURLToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMD5DataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMD5DataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lbResults = new System.Windows.Forms.ListBox();
            this.cmResults = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.computeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMD5Computed = new System.Windows.Forms.TextBox();
            this.pbHashing = new System.Windows.Forms.ProgressBar();
            this.btnCompute = new System.Windows.Forms.Button();
            this.cbExcludeOfficial = new System.Windows.Forms.CheckBox();
            this.txtMD5Expected = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ttExcludeOfficial = new System.Windows.Forms.ToolTip(this.components);
            this.ttComputedMD5 = new System.Windows.Forms.ToolTip(this.components);
            this.ttExpectedMD5 = new System.Windows.Forms.ToolTip(this.components);
            this.ttSearch = new System.Windows.Forms.ToolTip(this.components);
            this.ttCompute = new System.Windows.Forms.ToolTip(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.ttDelete = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.cmResults.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearchGame
            // 
            this.btnSearchGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchGame.Location = new System.Drawing.Point(632, 41);
            this.btnSearchGame.Name = "btnSearchGame";
            this.btnSearchGame.Size = new System.Drawing.Size(75, 23);
            this.btnSearchGame.TabIndex = 3;
            this.btnSearchGame.Text = "&Search";
            this.ttSearch.SetToolTip(this.btnSearchGame, "Search for a new set of files using current settings");
            this.btnSearchGame.UseVisualStyleBackColor = true;
            this.btnSearchGame.Click += new System.EventHandler(this.btnSearchGame_Click);
            // 
            // txtGamePath
            // 
            this.txtGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGamePath.Location = new System.Drawing.Point(80, 43);
            this.txtGamePath.Name = "txtGamePath";
            this.txtGamePath.Size = new System.Drawing.Size(546, 20);
            this.txtGamePath.TabIndex = 2;
            // 
            // txtUserPath
            // 
            this.txtUserPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserPath.Location = new System.Drawing.Point(79, 69);
            this.txtUserPath.Name = "txtUserPath";
            this.txtUserPath.Size = new System.Drawing.Size(546, 20);
            this.txtUserPath.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Game Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "&User Path:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(718, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getMD5sFromURLToolStrip,
            this.loadMD5DataToolStripMenuItem,
            this.saveMD5DataToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // getMD5sFromURLToolStrip
            // 
            this.getMD5sFromURLToolStrip.Name = "getMD5sFromURLToolStrip";
            this.getMD5sFromURLToolStrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.getMD5sFromURLToolStrip.Size = new System.Drawing.Size(206, 22);
            this.getMD5sFromURLToolStrip.Text = "&Get MD5s from URL";
            this.getMD5sFromURLToolStrip.Click += new System.EventHandler(this.getMD5sFromURLToolStrip_Click);
            // 
            // loadMD5DataToolStripMenuItem
            // 
            this.loadMD5DataToolStripMenuItem.Name = "loadMD5DataToolStripMenuItem";
            this.loadMD5DataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadMD5DataToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.loadMD5DataToolStripMenuItem.Text = "&Open MD5 Datafile";
            this.loadMD5DataToolStripMenuItem.Click += new System.EventHandler(this.loadMD5DataToolStripMenuItem_Click);
            // 
            // saveMD5DataToolStripMenuItem
            // 
            this.saveMD5DataToolStripMenuItem.Name = "saveMD5DataToolStripMenuItem";
            this.saveMD5DataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMD5DataToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.saveMD5DataToolStripMenuItem.Text = "&Save MD5 Datafile";
            this.saveMD5DataToolStripMenuItem.Click += new System.EventHandler(this.saveMD5DataToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.aboutToolStripMenuItem.Text = "&Manual";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.aboutToolStripMenuItem1.Text = "&About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // lbResults
            // 
            this.lbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbResults.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbResults.FormattingEnabled = true;
            this.lbResults.IntegralHeight = false;
            this.lbResults.Location = new System.Drawing.Point(16, 143);
            this.lbResults.Name = "lbResults";
            this.lbResults.Size = new System.Drawing.Size(690, 268);
            this.lbResults.TabIndex = 12;
            this.lbResults.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbResults_MouseUp);
            this.lbResults.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbResults_DrawItem);
            this.lbResults.SelectedIndexChanged += new System.EventHandler(this.lbResults_SelectedIndexChanged);
            // 
            // cmResults
            // 
            this.cmResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.computeToolStripMenuItem});
            this.cmResults.Name = "cmResults";
            this.cmResults.Size = new System.Drawing.Size(137, 26);
            // 
            // computeToolStripMenuItem
            // 
            this.computeToolStripMenuItem.Name = "computeToolStripMenuItem";
            this.computeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.computeToolStripMenuItem.Text = "Compute File";
            this.computeToolStripMenuItem.Click += new System.EventHandler(this.computeToolStripMenuItem_Click);
            // 
            // txtMD5Computed
            // 
            this.txtMD5Computed.Location = new System.Drawing.Point(16, 117);
            this.txtMD5Computed.Name = "txtMD5Computed";
            this.txtMD5Computed.ReadOnly = true;
            this.txtMD5Computed.Size = new System.Drawing.Size(229, 20);
            this.txtMD5Computed.TabIndex = 8;
            this.ttComputedMD5.SetToolTip(this.txtMD5Computed, "The MD5 hash that has been computed for the selected file");
            // 
            // pbHashing
            // 
            this.pbHashing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbHashing.Location = new System.Drawing.Point(16, 417);
            this.pbHashing.Name = "pbHashing";
            this.pbHashing.Size = new System.Drawing.Size(690, 23);
            this.pbHashing.TabIndex = 11;
            // 
            // btnCompute
            // 
            this.btnCompute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompute.Location = new System.Drawing.Point(632, 67);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(75, 23);
            this.btnCompute.TabIndex = 6;
            this.btnCompute.Text = "&Compute";
            this.ttCompute.SetToolTip(this.btnCompute, "Compute MD5 hashes for all currently loaded .pk4 or .mega files");
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // cbExcludeOfficial
            // 
            this.cbExcludeOfficial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExcludeOfficial.AutoSize = true;
            this.cbExcludeOfficial.Checked = true;
            this.cbExcludeOfficial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbExcludeOfficial.Location = new System.Drawing.Point(439, 26);
            this.cbExcludeOfficial.Name = "cbExcludeOfficial";
            this.cbExcludeOfficial.Size = new System.Drawing.Size(187, 17);
            this.cbExcludeOfficial.TabIndex = 0;
            this.cbExcludeOfficial.Text = "E&xclude official files from searches";
            this.ttExcludeOfficial.SetToolTip(this.cbExcludeOfficial, "Excludes official ETQW files from appearing in new searches");
            this.cbExcludeOfficial.UseVisualStyleBackColor = true;
            // 
            // txtMD5Expected
            // 
            this.txtMD5Expected.Location = new System.Drawing.Point(251, 117);
            this.txtMD5Expected.Name = "txtMD5Expected";
            this.txtMD5Expected.ReadOnly = true;
            this.txtMD5Expected.Size = new System.Drawing.Size(229, 20);
            this.txtMD5Expected.TabIndex = 10;
            this.ttExpectedMD5.SetToolTip(this.txtMD5Expected, "The MD5 hash that has been loaded for the selected file");
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Ready";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "C&omputed MD5 Checksum:";
            this.ttComputedMD5.SetToolTip(this.label3, "The MD5 hash that has been computed for the selected file");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(251, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "&Expected MD5 Checksum:";
            this.ttExpectedMD5.SetToolTip(this.label4, "The MD5 hash that has been loaded for the selected file");
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblStatus);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 451);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(718, 20);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(632, 93);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "&Delete";
            this.ttDelete.SetToolTip(this.btnDelete, "Deletes all files where the computed MD5 checksum does not match the expected MD5" +
                    " checksum");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 471);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnSearchGame);
            this.Controls.Add(this.btnCompute);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMD5Expected);
            this.Controls.Add(this.cbExcludeOfficial);
            this.Controls.Add(this.pbHashing);
            this.Controls.Add(this.txtMD5Computed);
            this.Controls.Add(this.lbResults);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserPath);
            this.Controls.Add(this.txtGamePath);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "ETQW Old Wipe";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cmResults.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchGame;
        private System.Windows.Forms.TextBox txtGamePath;
        private System.Windows.Forms.TextBox txtUserPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ListBox lbResults;
        private System.Windows.Forms.TextBox txtMD5Computed;
        private System.Windows.Forms.ProgressBar pbHashing;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.CheckBox cbExcludeOfficial;
        private System.Windows.Forms.ToolStripMenuItem loadMD5DataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMD5DataToolStripMenuItem;
        private System.Windows.Forms.TextBox txtMD5Expected;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip cmResults;
        private System.Windows.Forms.ToolStripMenuItem computeToolStripMenuItem;
        private System.Windows.Forms.ToolTip ttExcludeOfficial;
        private System.Windows.Forms.ToolTip ttComputedMD5;
        private System.Windows.Forms.ToolTip ttExpectedMD5;
        private System.Windows.Forms.ToolTip ttSearch;
        private System.Windows.Forms.ToolTip ttCompute;
        private System.Windows.Forms.ToolStripMenuItem getMD5sFromURLToolStrip;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolTip ttDelete;
    }
}

