using System;
using Rhapsody.UI.Steps;

namespace Rhapsody.UI {
    partial class MainForm {
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
            this.components = new System.ComponentModel.Container();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblBottomBevel = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.cmsOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOptionsNoPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptionsNoSpellChecking = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptionsMarkDamagedAlbums = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSteps = new System.Windows.Forms.Panel();
            this.stpFiles = new FilesStep();
            this.stpFinish = new FinishStep();
            this.stpAlbumSetup = new AlbumStep();
            this.pnlBottom.SuspendLayout();
            this.cmsOptions.SuspendLayout();
            this.pnlSteps.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnOptions);
            this.pnlBottom.Controls.Add(this.btnBack);
            this.pnlBottom.Controls.Add(this.btnNext);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.lblBottomBevel);
            this.pnlBottom.Controls.Add(this.btnAbout);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 540);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1042, 52);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(95, 14);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(77, 25);
            this.btnOptions.TabIndex = 2;
            this.btnOptions.Text = "&Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(799, 14);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 25);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "&Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(874, 14);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(955, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblBottomBevel
            // 
            this.lblBottomBevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBottomBevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBottomBevel.Location = new System.Drawing.Point(0, 0);
            this.lblBottomBevel.Name = "lblBottomBevel";
            this.lblBottomBevel.Size = new System.Drawing.Size(1042, 2);
            this.lblBottomBevel.TabIndex = 0;
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(12, 14);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(77, 25);
            this.btnAbout.TabIndex = 1;
            this.btnAbout.Text = "&About...";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // cmsOptions
            // 
            this.cmsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOptionsNoPlaylist,
            this.mnuOptionsNoSpellChecking,
            this.mnuOptionsMarkDamagedAlbums});
            this.cmsOptions.Name = "cmsFile";
            this.cmsOptions.Size = new System.Drawing.Size(261, 92);
            this.cmsOptions.Text = "Options";
            this.cmsOptions.Opening += new System.ComponentModel.CancelEventHandler(this.cmsOptions_Opening);
            // 
            // mnuOptionsNoPlaylist
            // 
            this.mnuOptionsNoPlaylist.Name = "mnuOptionsNoPlaylist";
            this.mnuOptionsNoPlaylist.Size = new System.Drawing.Size(260, 22);
            this.mnuOptionsNoPlaylist.Text = "Do not generate &playlist";
            this.mnuOptionsNoPlaylist.Click += new System.EventHandler(this.mnuOptionsNoPlaylist_Click);
            // 
            // mnuOptionsNoSpellChecking
            // 
            this.mnuOptionsNoSpellChecking.Name = "mnuOptionsNoSpellChecking";
            this.mnuOptionsNoSpellChecking.Size = new System.Drawing.Size(260, 22);
            this.mnuOptionsNoSpellChecking.Text = "Do not check the &spelling of names";
            this.mnuOptionsNoSpellChecking.Visible = false;
            this.mnuOptionsNoSpellChecking.Click += new System.EventHandler(this.mnuOptionsNoSpellChecking_Click);
            // 
            // mnuOptionsMarkDamagedAlbums
            // 
            this.mnuOptionsMarkDamagedAlbums.Name = "mnuOptionsMarkDamagedAlbums";
            this.mnuOptionsMarkDamagedAlbums.Size = new System.Drawing.Size(260, 22);
            this.mnuOptionsMarkDamagedAlbums.Text = "Mark damaged albums";
            this.mnuOptionsMarkDamagedAlbums.Click += new System.EventHandler(this.mnuOptionsMarkDamagedAlbums_Click);
            // 
            // pnlSteps
            // 
            this.pnlSteps.Controls.Add(this.stpFiles);
            this.pnlSteps.Controls.Add(this.stpFinish);
            this.pnlSteps.Controls.Add(this.stpAlbumSetup);
            this.pnlSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSteps.Location = new System.Drawing.Point(0, 0);
            this.pnlSteps.Name = "pnlSteps";
            this.pnlSteps.Size = new System.Drawing.Size(1042, 540);
            this.pnlSteps.TabIndex = 0;
            // 
            // stpFiles
            // 
            this.stpFiles.BackEnabled = false;
            this.stpFiles.CancelText = null;
            this.stpFiles.Context = null;
            this.stpFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stpFiles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stpFiles.Location = new System.Drawing.Point(0, 0);
            this.stpFiles.Name = "stpFiles";
            this.stpFiles.NextText = null;
            this.stpFiles.Session = null;
            this.stpFiles.Size = new System.Drawing.Size(1042, 540);
            this.stpFiles.TabIndex = 8;
            this.stpFiles.Wizard = null;
            // 
            // stpFinish
            // 
            this.stpFinish.BackEnabled = false;
            this.stpFinish.CancelText = null;
            this.stpFinish.Context = null;
            this.stpFinish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stpFinish.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stpFinish.Location = new System.Drawing.Point(0, 0);
            this.stpFinish.Name = "stpFinish";
            this.stpFinish.NextText = "Start Over";
            this.stpFinish.Session = null;
            this.stpFinish.Size = new System.Drawing.Size(1042, 540);
            this.stpFinish.TabIndex = 2;
            this.stpFinish.Wizard = null;
            // 
            // stpAlbumSetup
            // 
            this.stpAlbumSetup.CancelText = null;
            this.stpAlbumSetup.Context = null;
            this.stpAlbumSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stpAlbumSetup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stpAlbumSetup.Location = new System.Drawing.Point(0, 0);
            this.stpAlbumSetup.Name = "stpAlbumSetup";
            this.stpAlbumSetup.NextText = "Finish";
            this.stpAlbumSetup.Session = null;
            this.stpAlbumSetup.Size = new System.Drawing.Size(1042, 540);
            this.stpAlbumSetup.TabIndex = 7;
            this.stpAlbumSetup.Wizard = null;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1042, 592);
            this.Controls.Add(this.pnlSteps);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rhapsody";
            this.pnlBottom.ResumeLayout(false);
            this.cmsOptions.ResumeLayout(false);
            this.pnlSteps.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblBottomBevel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.ContextMenuStrip cmsOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuOptionsNoPlaylist;
        private System.Windows.Forms.ToolStripMenuItem mnuOptionsNoSpellChecking;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Panel pnlSteps;
        private Steps.FinishStep stpFinish;
        private Steps.FilesStep stpFiles;
        private Steps.AlbumStep stpAlbumSetup;
        private System.Windows.Forms.ToolStripMenuItem mnuOptionsMarkDamagedAlbums;
    }
}

