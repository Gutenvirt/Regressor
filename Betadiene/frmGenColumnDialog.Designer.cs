using System.ComponentModel;
using System.Windows.Forms;

namespace Betadiene
{
    partial class FrmGenColumnDialog
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
            this.txtTrue = new System.Windows.Forms.TextBox();
            this.cmbVar1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOps = new System.Windows.Forms.ComboBox();
            this.txtFalse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.cmbVar2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTrue
            // 
            this.txtTrue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTrue.Location = new System.Drawing.Point(74, 159);
            this.txtTrue.Name = "txtTrue";
            this.txtTrue.Size = new System.Drawing.Size(100, 20);
            this.txtTrue.TabIndex = 0;
            // 
            // cmbVar1
            // 
            this.cmbVar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbVar1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVar1.FormattingEnabled = true;
            this.cmbVar1.Location = new System.Drawing.Point(38, 124);
            this.cmbVar1.Name = "cmbVar1";
            this.cmbVar1.Size = new System.Drawing.Size(159, 22);
            this.cmbVar1.TabIndex = 1;
            this.cmbVar1.Text = "Select Variable";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "IF";
            // 
            // cmbOps
            // 
            this.cmbOps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbOps.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOps.FormattingEnabled = true;
            this.cmbOps.Items.AddRange(new object[] {
            ">",
            "<",
            ">=",
            "<=",
            "!=",
            "=="});
            this.cmbOps.Location = new System.Drawing.Point(203, 124);
            this.cmbOps.Name = "cmbOps";
            this.cmbOps.Size = new System.Drawing.Size(37, 22);
            this.cmbOps.TabIndex = 3;
            this.cmbOps.Text = "Op";
            // 
            // txtFalse
            // 
            this.txtFalse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFalse.Location = new System.Drawing.Point(245, 159);
            this.txtFalse.Name = "txtFalse";
            this.txtFalse.Size = new System.Drawing.Size(100, 20);
            this.txtFalse.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "THEN";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(16, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(470, 20);
            this.textBox2.TabIndex = 6;
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdGenerate.Location = new System.Drawing.Point(411, 123);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(75, 56);
            this.cmdGenerate.TabIndex = 7;
            this.cmdGenerate.Text = "Run";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbVar2
            // 
            this.cmbVar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbVar2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVar2.FormattingEnabled = true;
            this.cmbVar2.Location = new System.Drawing.Point(246, 124);
            this.cmbVar2.Name = "cmbVar2";
            this.cmbVar2.Size = new System.Drawing.Size(159, 22);
            this.cmbVar2.TabIndex = 8;
            this.cmbVar2.Text = "Select Variable";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(184, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "ELSE";
            // 
            // frmGenColumnDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 197);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbVar2);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFalse);
            this.Controls.Add(this.cmbOps);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbVar1);
            this.Controls.Add(this.txtTrue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmGenColumnDialog";
            this.Text = "GenColumnDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtTrue;
        private ComboBox cmbVar1;
        private Label label1;
        private ComboBox cmbOps;
        private TextBox txtFalse;
        private Label label2;
        private TextBox textBox2;
        private Button cmdGenerate;
        private ComboBox cmbVar2;
        private Label label3;
    }
}