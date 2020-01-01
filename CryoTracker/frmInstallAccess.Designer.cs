namespace CryoTracker
{
    partial class frmInstallAccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInstallAccess));
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnDownloadAccess = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.lblGotoMicrosoft = new System.Windows.Forms.Label();
            this.DownloadAccessProgressBar = new System.Windows.Forms.ProgressBar();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(15, 15);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(6);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(182, 20);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to CryoTracker";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(16, 56);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(6);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(255, 13);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "CryoTracker requires Microsoft Access 2007 or 2010";
            // 
            // btnDownloadAccess
            // 
            this.btnDownloadAccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadAccess.Location = new System.Drawing.Point(187, 208);
            this.btnDownloadAccess.Name = "btnDownloadAccess";
            this.btnDownloadAccess.Size = new System.Drawing.Size(105, 23);
            this.btnDownloadAccess.TabIndex = 7;
            this.btnDownloadAccess.Text = "Download";
            this.btnDownloadAccess.UseVisualStyleBackColor = true;
            this.btnDownloadAccess.Click += new System.EventHandler(this.btnDownloadAccess_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(379, 208);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Location = new System.Drawing.Point(298, 208);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 8;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // lblGotoMicrosoft
            // 
            this.lblGotoMicrosoft.AutoSize = true;
            this.lblGotoMicrosoft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGotoMicrosoft.Location = new System.Drawing.Point(16, 94);
            this.lblGotoMicrosoft.Margin = new System.Windows.Forms.Padding(6);
            this.lblGotoMicrosoft.MaximumSize = new System.Drawing.Size(440, 0);
            this.lblGotoMicrosoft.Name = "lblGotoMicrosoft";
            this.lblGotoMicrosoft.Size = new System.Drawing.Size(427, 26);
            this.lblGotoMicrosoft.TabIndex = 2;
            this.lblGotoMicrosoft.Text = "If you don\'t have a copy of either you can install a standalone runtime engine fo" +
    "r 2007 by clicking Download and then running the installer";
            // 
            // DownloadAccessProgressBar
            // 
            this.DownloadAccessProgressBar.Location = new System.Drawing.Point(12, 211);
            this.DownloadAccessProgressBar.Name = "DownloadAccessProgressBar";
            this.DownloadAccessProgressBar.Size = new System.Drawing.Size(169, 16);
            this.DownloadAccessProgressBar.TabIndex = 6;
            this.DownloadAccessProgressBar.Visible = false;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.lblWelcome);
            this.pnlInfo.Controls.Add(this.lblGotoMicrosoft);
            this.pnlInfo.Controls.Add(this.lblMessage);
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(466, 187);
            this.pnlInfo.TabIndex = 5;
            // 
            // frmInstallAccess
            // 
            this.AcceptButton = this.btnDownloadAccess;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 243);
            this.Controls.Add(this.btnDownloadAccess);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.DownloadAccessProgressBar);
            this.Controls.Add(this.pnlInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInstallAccess";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Install Microsoft Access 2007 or 2010";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInstallAccess_FormClosed);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblWelcome;
        internal System.Windows.Forms.Label lblMessage;
        internal System.Windows.Forms.Button btnDownloadAccess;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Button btnFinish;
        internal System.Windows.Forms.Label lblGotoMicrosoft;
        internal System.Windows.Forms.ProgressBar DownloadAccessProgressBar;
        internal System.Windows.Forms.Panel pnlInfo;
    }
}