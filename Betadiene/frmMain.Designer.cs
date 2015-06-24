﻿namespace Betadiene
{
    partial class frmMain
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
            this.txtOut = new System.Windows.Forms.TextBox();
            this.mnBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oFD = new System.Windows.Forms.OpenFileDialog();
            this.lbMsgServer = new System.Windows.Forms.ListBox();
            this.lbVariables = new System.Windows.Forms.ListBox();
            this.clearScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frequencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.densityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.percentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.createZScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descriptiveStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearOLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOut
            // 
            this.txtOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOut.Font = new System.Drawing.Font("Lucida Console", 10F);
            this.txtOut.Location = new System.Drawing.Point(12, 27);
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOut.Size = new System.Drawing.Size(976, 656);
            this.txtOut.TabIndex = 0;
            this.txtOut.WordWrap = false;
            // 
            // mnBar
            // 
            this.mnBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.statisticsToolStripMenuItem,
            this.regressionToolStripMenuItem,
            this.dataToolStripMenuItem});
            this.mnBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnBar.Location = new System.Drawing.Point(0, 0);
            this.mnBar.Name = "mnBar";
            this.mnBar.Size = new System.Drawing.Size(1229, 23);
            this.mnBar.TabIndex = 3;
            this.mnBar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveOutputToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadDataToolStripMenuItem
            // 
            this.loadDataToolStripMenuItem.Name = "loadDataToolStripMenuItem";
            this.loadDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadDataToolStripMenuItem.Text = "Load Data...";
            this.loadDataToolStripMenuItem.Click += new System.EventHandler(this.loadDataToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 6);
            // 
            // saveOutputToolStripMenuItem
            // 
            this.saveOutputToolStripMenuItem.Name = "saveOutputToolStripMenuItem";
            this.saveOutputToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveOutputToolStripMenuItem.Text = "Save Output...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(145, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramToolStripMenuItem,
            this.descriptiveStatisticsToolStripMenuItem});
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(62, 19);
            this.statisticsToolStripMenuItem.Text = "Analysis";
            // 
            // regressionToolStripMenuItem
            // 
            this.regressionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linearOLSToolStripMenuItem});
            this.regressionToolStripMenuItem.Name = "regressionToolStripMenuItem";
            this.regressionToolStripMenuItem.Size = new System.Drawing.Size(76, 19);
            this.regressionToolStripMenuItem.Text = "Regression";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearScreenToolStripMenuItem,
            this.toolStripMenuItem3,
            this.createZScoreToolStripMenuItem,
            this.showTableToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 19);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // oFD
            // 
            this.oFD.Filter = "All files|*.*";
            // 
            // lbMsgServer
            // 
            this.lbMsgServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMsgServer.FormattingEnabled = true;
            this.lbMsgServer.Location = new System.Drawing.Point(994, 352);
            this.lbMsgServer.Name = "lbMsgServer";
            this.lbMsgServer.Size = new System.Drawing.Size(223, 329);
            this.lbMsgServer.TabIndex = 4;
            // 
            // lbVariables
            // 
            this.lbVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVariables.FormattingEnabled = true;
            this.lbVariables.Location = new System.Drawing.Point(994, 26);
            this.lbVariables.Name = "lbVariables";
            this.lbVariables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbVariables.Size = new System.Drawing.Size(223, 316);
            this.lbVariables.TabIndex = 5;
            this.lbVariables.SelectedIndexChanged += new System.EventHandler(this.lbVariables_SelectedIndexChanged);
            // 
            // clearScreenToolStripMenuItem
            // 
            this.clearScreenToolStripMenuItem.Name = "clearScreenToolStripMenuItem";
            this.clearScreenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearScreenToolStripMenuItem.Text = "Clear Screen";
            this.clearScreenToolStripMenuItem.Click += new System.EventHandler(this.clearScreenToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frequencyToolStripMenuItem,
            this.densityToolStripMenuItem,
            this.percentToolStripMenuItem});
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // frequencyToolStripMenuItem
            // 
            this.frequencyToolStripMenuItem.Name = "frequencyToolStripMenuItem";
            this.frequencyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.frequencyToolStripMenuItem.Text = "Frequency";
            this.frequencyToolStripMenuItem.Click += new System.EventHandler(this.frequencyToolStripMenuItem_Click);
            // 
            // densityToolStripMenuItem
            // 
            this.densityToolStripMenuItem.Name = "densityToolStripMenuItem";
            this.densityToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.densityToolStripMenuItem.Text = "Density";
            this.densityToolStripMenuItem.Click += new System.EventHandler(this.densityToolStripMenuItem_Click);
            // 
            // percentToolStripMenuItem
            // 
            this.percentToolStripMenuItem.Name = "percentToolStripMenuItem";
            this.percentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.percentToolStripMenuItem.Text = "Percent";
            this.percentToolStripMenuItem.Click += new System.EventHandler(this.percentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // createZScoreToolStripMenuItem
            // 
            this.createZScoreToolStripMenuItem.Name = "createZScoreToolStripMenuItem";
            this.createZScoreToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createZScoreToolStripMenuItem.Text = "Create Z-Score";
            this.createZScoreToolStripMenuItem.Click += new System.EventHandler(this.createZScoreToolStripMenuItem_Click);
            // 
            // descriptiveStatisticsToolStripMenuItem
            // 
            this.descriptiveStatisticsToolStripMenuItem.Name = "descriptiveStatisticsToolStripMenuItem";
            this.descriptiveStatisticsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.descriptiveStatisticsToolStripMenuItem.Text = "Descriptive Statistics";
            this.descriptiveStatisticsToolStripMenuItem.Click += new System.EventHandler(this.descriptiveStatisticsToolStripMenuItem_Click);
            // 
            // linearOLSToolStripMenuItem
            // 
            this.linearOLSToolStripMenuItem.Name = "linearOLSToolStripMenuItem";
            this.linearOLSToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.linearOLSToolStripMenuItem.Text = "Linear (OLS)";
            this.linearOLSToolStripMenuItem.Click += new System.EventHandler(this.linearOLSToolStripMenuItem_Click);
            // 
            // showTableToolStripMenuItem
            // 
            this.showTableToolStripMenuItem.Name = "showTableToolStripMenuItem";
            this.showTableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showTableToolStripMenuItem.Text = "Show Table";
            this.showTableToolStripMenuItem.Click += new System.EventHandler(this.showTableToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 695);
            this.Controls.Add(this.lbVariables);
            this.Controls.Add(this.lbMsgServer);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.mnBar);
            this.MainMenuStrip = this.mnBar;
            this.Name = "frmMain";
            this.Text = "Betadiene";
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.mnBar.ResumeLayout(false);
            this.mnBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.MenuStrip mnBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regressionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog oFD;
        private System.Windows.Forms.ListBox lbMsgServer;
        private System.Windows.Forms.ListBox lbVariables;
        private System.Windows.Forms.ToolStripMenuItem clearScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frequencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem densityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem percentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem createZScoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descriptiveStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearOLSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTableToolStripMenuItem;
    }
}

