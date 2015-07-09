using System.ComponentModel;
using System.Windows.Forms;

namespace Betadiene
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.exportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frequencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.densityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.percentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descriptiveStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.aNOVAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.correlationCoefficientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearOLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.createZScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.integrateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ifToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oFD = new System.Windows.Forms.OpenFileDialog();
            this.lblCmdHistory = new System.Windows.Forms.ListBox();
            this.lbVariables = new System.Windows.Forms.ListBox();
            this.txtCmdBox = new System.Windows.Forms.TextBox();
            this.mnBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOut
            // 
            this.txtOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOut.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOut.Location = new System.Drawing.Point(12, 26);
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOut.Size = new System.Drawing.Size(819, 457);
            this.txtOut.TabIndex = 100;
            this.txtOut.TabStop = false;
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
            this.mnBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnBar.Size = new System.Drawing.Size(1009, 23);
            this.mnBar.TabIndex = 4;
            this.mnBar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDataToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveOutputToolStripMenuItem,
            this.exportDataToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadDataToolStripMenuItem
            // 
            this.loadDataToolStripMenuItem.Name = "loadDataToolStripMenuItem";
            this.loadDataToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.loadDataToolStripMenuItem.Text = "Load Data...";
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
            // exportDataToolStripMenuItem
            // 
            this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            this.exportDataToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exportDataToolStripMenuItem.Text = "Export Data...";
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
            this.descriptiveStatisticsToolStripMenuItem,
            this.toolStripMenuItem4,
            this.aNOVAToolStripMenuItem,
            this.correlationCoefficientsToolStripMenuItem});
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(62, 19);
            this.statisticsToolStripMenuItem.Text = "Analysis";
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frequencyToolStripMenuItem,
            this.densityToolStripMenuItem,
            this.percentToolStripMenuItem});
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // frequencyToolStripMenuItem
            // 
            this.frequencyToolStripMenuItem.Name = "frequencyToolStripMenuItem";
            this.frequencyToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.frequencyToolStripMenuItem.Text = "Frequency";
            // 
            // densityToolStripMenuItem
            // 
            this.densityToolStripMenuItem.Name = "densityToolStripMenuItem";
            this.densityToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.densityToolStripMenuItem.Text = "Density";
            // 
            // percentToolStripMenuItem
            // 
            this.percentToolStripMenuItem.Name = "percentToolStripMenuItem";
            this.percentToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.percentToolStripMenuItem.Text = "Percent";
            // 
            // descriptiveStatisticsToolStripMenuItem
            // 
            this.descriptiveStatisticsToolStripMenuItem.Name = "descriptiveStatisticsToolStripMenuItem";
            this.descriptiveStatisticsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.descriptiveStatisticsToolStripMenuItem.Text = "Descriptive Statistics";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(196, 6);
            // 
            // aNOVAToolStripMenuItem
            // 
            this.aNOVAToolStripMenuItem.Name = "aNOVAToolStripMenuItem";
            this.aNOVAToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aNOVAToolStripMenuItem.Text = "ANOVA - One way";
            // 
            // correlationCoefficientsToolStripMenuItem
            // 
            this.correlationCoefficientsToolStripMenuItem.Name = "correlationCoefficientsToolStripMenuItem";
            this.correlationCoefficientsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.correlationCoefficientsToolStripMenuItem.Text = "Correlation Coefficients";
            // 
            // regressionToolStripMenuItem
            // 
            this.regressionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linearOLSToolStripMenuItem});
            this.regressionToolStripMenuItem.Name = "regressionToolStripMenuItem";
            this.regressionToolStripMenuItem.Size = new System.Drawing.Size(76, 19);
            this.regressionToolStripMenuItem.Text = "Regression";
            // 
            // linearOLSToolStripMenuItem
            // 
            this.linearOLSToolStripMenuItem.Name = "linearOLSToolStripMenuItem";
            this.linearOLSToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.linearOLSToolStripMenuItem.Text = "Linear (OLS)";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearScreenToolStripMenuItem,
            this.toolStripMenuItem3,
            this.createZScoreToolStripMenuItem,
            this.showTableToolStripMenuItem,
            this.integrateToolStripMenuItem,
            this.generateColumnToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 19);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // clearScreenToolStripMenuItem
            // 
            this.clearScreenToolStripMenuItem.Name = "clearScreenToolStripMenuItem";
            this.clearScreenToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.clearScreenToolStripMenuItem.Text = "Clear Screen";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(164, 6);
            // 
            // createZScoreToolStripMenuItem
            // 
            this.createZScoreToolStripMenuItem.Name = "createZScoreToolStripMenuItem";
            this.createZScoreToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.createZScoreToolStripMenuItem.Text = "Create Z-Score";
            // 
            // showTableToolStripMenuItem
            // 
            this.showTableToolStripMenuItem.Name = "showTableToolStripMenuItem";
            this.showTableToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.showTableToolStripMenuItem.Text = "Show Table";
            // 
            // integrateToolStripMenuItem
            // 
            this.integrateToolStripMenuItem.Name = "integrateToolStripMenuItem";
            this.integrateToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.integrateToolStripMenuItem.Text = "Integrate";
            // 
            // generateColumnToolStripMenuItem
            // 
            this.generateColumnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillToolStripMenuItem,
            this.ifToolStripMenuItem,
            this.operationToolStripMenuItem});
            this.generateColumnToolStripMenuItem.Name = "generateColumnToolStripMenuItem";
            this.generateColumnToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.generateColumnToolStripMenuItem.Text = "Generate Column";
            // 
            // fillToolStripMenuItem
            // 
            this.fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            this.fillToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.fillToolStripMenuItem.Text = "Fill...";
            // 
            // ifToolStripMenuItem
            // 
            this.ifToolStripMenuItem.Name = "ifToolStripMenuItem";
            this.ifToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ifToolStripMenuItem.Text = "If...";
            // 
            // operationToolStripMenuItem
            // 
            this.operationToolStripMenuItem.Name = "operationToolStripMenuItem";
            this.operationToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.operationToolStripMenuItem.Text = "Operation...";
            // 
            // oFD
            // 
            this.oFD.Filter = "All files|*.*";
            // 
            // lblCmdHistory
            // 
            this.lblCmdHistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCmdHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCmdHistory.FormattingEnabled = true;
            this.lblCmdHistory.Location = new System.Drawing.Point(837, 346);
            this.lblCmdHistory.Name = "lblCmdHistory";
            this.lblCmdHistory.Size = new System.Drawing.Size(160, 197);
            this.lblCmdHistory.TabIndex = 3;
            this.lblCmdHistory.TabStop = false;
            this.lblCmdHistory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblCmdHistory_MouseDoubleClick);
            // 
            // lbVariables
            // 
            this.lbVariables.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbVariables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbVariables.FormattingEnabled = true;
            this.lbVariables.Location = new System.Drawing.Point(837, 26);
            this.lbVariables.Name = "lbVariables";
            this.lbVariables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbVariables.Size = new System.Drawing.Size(160, 314);
            this.lbVariables.TabIndex = 2;
            this.lbVariables.TabStop = false;
            this.lbVariables.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbVariables_MouseDoubleClick);
            // 
            // txtCmdBox
            // 
            this.txtCmdBox.AcceptsTab = true;
            this.txtCmdBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCmdBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtCmdBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmdBox.HideSelection = false;
            this.txtCmdBox.Location = new System.Drawing.Point(12, 489);
            this.txtCmdBox.MinimumSize = new System.Drawing.Size(2, 50);
            this.txtCmdBox.Multiline = true;
            this.txtCmdBox.Name = "txtCmdBox";
            this.txtCmdBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCmdBox.Size = new System.Drawing.Size(819, 50);
            this.txtCmdBox.TabIndex = 0;
            this.txtCmdBox.Text = "import c:\\counting.csv";
            this.txtCmdBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCmdBox_KeyUp);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 562);
            this.Controls.Add(this.txtCmdBox);
            this.Controls.Add(this.lbVariables);
            this.Controls.Add(this.lblCmdHistory);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.mnBar);
            this.MainMenuStrip = this.mnBar;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Betadiene";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnBar.ResumeLayout(false);
            this.mnBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtOut;
        private MenuStrip mnBar;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadDataToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem saveOutputToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem statisticsToolStripMenuItem;
        private ToolStripMenuItem regressionToolStripMenuItem;
        private ToolStripMenuItem dataToolStripMenuItem;
        private OpenFileDialog oFD;
        private ListBox lblCmdHistory;
        private ToolStripMenuItem clearScreenToolStripMenuItem;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private ToolStripMenuItem frequencyToolStripMenuItem;
        private ToolStripMenuItem densityToolStripMenuItem;
        private ToolStripMenuItem percentToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem createZScoreToolStripMenuItem;
        private ToolStripMenuItem descriptiveStatisticsToolStripMenuItem;
        private ToolStripMenuItem linearOLSToolStripMenuItem;
        private ToolStripMenuItem showTableToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem aNOVAToolStripMenuItem;
        private ToolStripMenuItem correlationCoefficientsToolStripMenuItem;
        private ToolStripMenuItem integrateToolStripMenuItem;
        private ToolStripMenuItem generateColumnToolStripMenuItem;
        private ToolStripMenuItem fillToolStripMenuItem;
        private ToolStripMenuItem ifToolStripMenuItem;
        private ToolStripMenuItem operationToolStripMenuItem;
        private ListBox lbVariables;
        private TextBox txtCmdBox;
        private ToolStripMenuItem exportDataToolStripMenuItem;
    }
}

