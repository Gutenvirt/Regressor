namespace Betadiene
{
    partial class Form1
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
            this.txtCmds = new System.Windows.Forms.TextBox();
            this.cmdGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOut
            // 
            this.txtOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOut.Font = new System.Drawing.Font("Lucida Console", 10F);
            this.txtOut.Location = new System.Drawing.Point(12, 12);
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOut.Size = new System.Drawing.Size(962, 421);
            this.txtOut.TabIndex = 0;
            this.txtOut.WordWrap = false;
            // 
            // txtCmds
            // 
            this.txtCmds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmds.Font = new System.Drawing.Font("Lucida Console", 10F);
            this.txtCmds.Location = new System.Drawing.Point(12, 439);
            this.txtCmds.Multiline = true;
            this.txtCmds.Name = "txtCmds";
            this.txtCmds.Size = new System.Drawing.Size(864, 62);
            this.txtCmds.TabIndex = 1;
            this.txtCmds.WordWrap = false;
            // 
            // cmdGo
            // 
            this.cmdGo.Location = new System.Drawing.Point(882, 439);
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(92, 62);
            this.cmdGo.TabIndex = 2;
            this.cmdGo.Text = "Go";
            this.cmdGo.UseVisualStyleBackColor = true;
            this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 513);
            this.Controls.Add(this.cmdGo);
            this.Controls.Add(this.txtCmds);
            this.Controls.Add(this.txtOut);
            this.Name = "Form1";
            this.Text = "Betadiene";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.TextBox txtCmds;
        private System.Windows.Forms.Button cmdGo;
    }
}

