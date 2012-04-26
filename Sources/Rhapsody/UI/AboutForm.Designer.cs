using System;

namespace Rhapsody.UI {
    partial class AboutForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.btnOK = new System.Windows.Forms.Button();
            this.lblBottomBevel = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.chkCredits = new System.Windows.Forms.CheckBox();
            this.pnlAbout = new System.Windows.Forms.Panel();
            this.lblCaution = new System.Windows.Forms.Label();
            this.lblCautionText = new System.Windows.Forms.Label();
            this.lblRights = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCredits = new System.Windows.Forms.Panel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.pnlAbout.SuspendLayout();
            this.pnlCredits.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(357, 205);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "O&K";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblBottomBevel
            // 
            this.lblBottomBevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBottomBevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBottomBevel.Location = new System.Drawing.Point(13, 193);
            this.lblBottomBevel.Name = "lblBottomBevel";
            this.lblBottomBevel.Size = new System.Drawing.Size(418, 2);
            this.lblBottomBevel.TabIndex = 5;
            // 
            // picIcon
            // 
            this.picIcon.Image = ((System.Drawing.Image)(resources.GetObject("picIcon.Image")));
            this.picIcon.Location = new System.Drawing.Point(13, 31);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(128, 128);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picIcon.TabIndex = 8;
            this.picIcon.TabStop = false;
            // 
            // chkCredits
            // 
            this.chkCredits.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCredits.Location = new System.Drawing.Point(12, 205);
            this.chkCredits.Name = "chkCredits";
            this.chkCredits.Size = new System.Drawing.Size(75, 25);
            this.chkCredits.TabIndex = 7;
            this.chkCredits.Text = "Credits";
            this.chkCredits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCredits.UseVisualStyleBackColor = true;
            this.chkCredits.CheckedChanged += new System.EventHandler(this.chkCredits_CheckedChanged);
            // 
            // pnlAbout
            // 
            this.pnlAbout.Controls.Add(this.lblCaution);
            this.pnlAbout.Controls.Add(this.lblCautionText);
            this.pnlAbout.Controls.Add(this.lblRights);
            this.pnlAbout.Controls.Add(this.lblCopyright);
            this.pnlAbout.Controls.Add(this.lblTitle);
            this.pnlAbout.Location = new System.Drawing.Point(147, 31);
            this.pnlAbout.Name = "pnlAbout";
            this.pnlAbout.Size = new System.Drawing.Size(285, 128);
            this.pnlAbout.TabIndex = 9;
            // 
            // lblCaution
            // 
            this.lblCaution.AutoSize = true;
            this.lblCaution.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaution.Location = new System.Drawing.Point(16, 75);
            this.lblCaution.Name = "lblCaution";
            this.lblCaution.Size = new System.Drawing.Size(53, 13);
            this.lblCaution.TabIndex = 8;
            this.lblCaution.Text = "Caution:";
            // 
            // lblCautionText
            // 
            this.lblCautionText.AutoSize = true;
            this.lblCautionText.Location = new System.Drawing.Point(16, 93);
            this.lblCautionText.Name = "lblCautionText";
            this.lblCautionText.Size = new System.Drawing.Size(240, 26);
            this.lblCautionText.TabIndex = 9;
            this.lblCautionText.Text = "I take no responsibility for any damage that may\r\noccur as a result of using this" +
    " application. ";
            // 
            // lblRights
            // 
            this.lblRights.AutoSize = true;
            this.lblRights.Location = new System.Drawing.Point(16, 37);
            this.lblRights.Name = "lblRights";
            this.lblRights.Size = new System.Drawing.Size(104, 13);
            this.lblRights.TabIndex = 7;
            this.lblRights.Text = "All Rights Reserved.";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(16, 21);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(181, 13);
            this.lblCopyright.TabIndex = 6;
            this.lblCopyright.Text = "Copyright 2007-2012 Soheil Rashidi.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(16, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(122, 13);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Rhapsody {version}";
            // 
            // pnlCredits
            // 
            this.pnlCredits.Controls.Add(this.linkLabel3);
            this.pnlCredits.Controls.Add(this.linkLabel2);
            this.pnlCredits.Controls.Add(this.label2);
            this.pnlCredits.Controls.Add(this.label1);
            this.pnlCredits.Controls.Add(this.linkLabel1);
            this.pnlCredits.Controls.Add(this.label4);
            this.pnlCredits.Location = new System.Drawing.Point(147, 31);
            this.pnlCredits.Name = "pnlCredits";
            this.pnlCredits.Size = new System.Drawing.Size(285, 128);
            this.pnlCredits.TabIndex = 12;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(16, 101);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(156, 13);
            this.linkLabel3.TabIndex = 5;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "http://www.vbaccelerator.com";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(16, 59);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(208, 13);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "http://www.famfamfam.com/lab/icons/silk";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SysImageList code:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Other icons:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(16, 19);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(141, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://chrfb.deviantart.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Application icon:";
            // 
            // AboutForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(444, 242);
            this.Controls.Add(this.chkCredits);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.lblBottomBevel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pnlAbout);
            this.Controls.Add(this.pnlCredits);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Rhapsody";
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.pnlAbout.ResumeLayout(false);
            this.pnlAbout.PerformLayout();
            this.pnlCredits.ResumeLayout(false);
            this.pnlCredits.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblBottomBevel;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.CheckBox chkCredits;
        private System.Windows.Forms.Panel pnlAbout;
        private System.Windows.Forms.Label lblCaution;
        private System.Windows.Forms.Label lblCautionText;
        private System.Windows.Forms.Label lblRights;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCredits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label2;
    }
}