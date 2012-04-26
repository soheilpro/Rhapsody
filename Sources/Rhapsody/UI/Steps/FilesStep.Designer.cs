using System;

namespace Rhapsody.UI.Steps
{
    partial class FilesStep
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilesStep));
            this.chkReEncodeFiles = new System.Windows.Forms.CheckBox();
            this.chkIgnoreInconsistentFiles = new System.Windows.Forms.CheckBox();
            this.chkIgnoreLowQualityFiles = new System.Windows.Forms.CheckBox();
            this.chkIgnoreDamagedFiles = new System.Windows.Forms.CheckBox();
            this.btnBrowseSourceDirectory = new System.Windows.Forms.Button();
            this.lblSourceDirectory = new System.Windows.Forms.Label();
            this.lvwFiles = new System.Windows.Forms.ListView();
            this.chFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLayer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBitrate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSampleRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuFilePlay = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDirectory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDirectoryOpenFormClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDirectorySeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDirectoryExplore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDirectoryReload = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSourceDirectory = new System.Windows.Forms.TextBox();
            this.cmsFile.SuspendLayout();
            this.cmsDirectory.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkReEncodeFiles
            // 
            this.chkReEncodeFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkReEncodeFiles.AutoSize = true;
            this.chkReEncodeFiles.Location = new System.Drawing.Point(657, 409);
            this.chkReEncodeFiles.Name = "chkReEncodeFiles";
            this.chkReEncodeFiles.Size = new System.Drawing.Size(100, 17);
            this.chkReEncodeFiles.TabIndex = 7;
            this.chkReEncodeFiles.Text = "Re-&encode files";
            this.chkReEncodeFiles.UseVisualStyleBackColor = true;
            this.chkReEncodeFiles.CheckedChanged += new System.EventHandler(this.chkReEncodeFiles_CheckedChanged);
            // 
            // chkIgnoreInconsistentFiles
            // 
            this.chkIgnoreInconsistentFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIgnoreInconsistentFiles.AutoSize = true;
            this.chkIgnoreInconsistentFiles.Location = new System.Drawing.Point(12, 449);
            this.chkIgnoreInconsistentFiles.Name = "chkIgnoreInconsistentFiles";
            this.chkIgnoreInconsistentFiles.Size = new System.Drawing.Size(140, 17);
            this.chkIgnoreInconsistentFiles.TabIndex = 6;
            this.chkIgnoreInconsistentFiles.Text = "Ignore &inconsistent files";
            this.chkIgnoreInconsistentFiles.UseVisualStyleBackColor = true;
            this.chkIgnoreInconsistentFiles.CheckedChanged += new System.EventHandler(this.chkIgnoreInconsistentFiles_CheckedChanged);
            // 
            // chkIgnoreLowQualityFiles
            // 
            this.chkIgnoreLowQualityFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIgnoreLowQualityFiles.AutoSize = true;
            this.chkIgnoreLowQualityFiles.Location = new System.Drawing.Point(12, 429);
            this.chkIgnoreLowQualityFiles.Name = "chkIgnoreLowQualityFiles";
            this.chkIgnoreLowQualityFiles.Size = new System.Drawing.Size(168, 17);
            this.chkIgnoreLowQualityFiles.TabIndex = 5;
            this.chkIgnoreLowQualityFiles.Text = "Ignore &low/invalid quality files";
            this.chkIgnoreLowQualityFiles.CheckedChanged += new System.EventHandler(this.chkIgnoreLowQualityFiles_CheckedChanged);
            // 
            // chkIgnoreDamagedFiles
            // 
            this.chkIgnoreDamagedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIgnoreDamagedFiles.AutoSize = true;
            this.chkIgnoreDamagedFiles.Location = new System.Drawing.Point(12, 409);
            this.chkIgnoreDamagedFiles.Name = "chkIgnoreDamagedFiles";
            this.chkIgnoreDamagedFiles.Size = new System.Drawing.Size(127, 17);
            this.chkIgnoreDamagedFiles.TabIndex = 4;
            this.chkIgnoreDamagedFiles.Text = "Ignore &damaged files";
            this.chkIgnoreDamagedFiles.CheckedChanged += new System.EventHandler(this.chkIgnoreDamagedFiles_CheckedChanged);
            // 
            // btnBrowseSourceDirectory
            // 
            this.btnBrowseSourceDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSourceDirectory.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseSourceDirectory.Image")));
            this.btnBrowseSourceDirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseSourceDirectory.Location = new System.Drawing.Point(685, 34);
            this.btnBrowseSourceDirectory.Name = "btnBrowseSourceDirectory";
            this.btnBrowseSourceDirectory.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.btnBrowseSourceDirectory.Size = new System.Drawing.Size(75, 25);
            this.btnBrowseSourceDirectory.TabIndex = 2;
            this.btnBrowseSourceDirectory.Text = "B&rowse";
            this.btnBrowseSourceDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowseSourceDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseSourceDirectory.Click += new System.EventHandler(this.btnBrowseSourceDirectory_Click);
            // 
            // lblSourceDirectory
            // 
            this.lblSourceDirectory.AutoSize = true;
            this.lblSourceDirectory.Location = new System.Drawing.Point(12, 40);
            this.lblSourceDirectory.Name = "lblSourceDirectory";
            this.lblSourceDirectory.Size = new System.Drawing.Size(59, 13);
            this.lblSourceDirectory.TabIndex = 0;
            this.lblSourceDirectory.Text = "Load from:";
            // 
            // lvwFiles
            // 
            this.lvwFiles.AllowDrop = true;
            this.lvwFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFile,
            this.chVersion,
            this.chLayer,
            this.chBitrate,
            this.chSampleRate,
            this.chMode,
            this.chTags});
            this.lvwFiles.ContextMenuStrip = this.cmsFile;
            this.lvwFiles.FullRowSelect = true;
            this.lvwFiles.Location = new System.Drawing.Point(12, 72);
            this.lvwFiles.Name = "lvwFiles";
            this.lvwFiles.ShowItemToolTips = true;
            this.lvwFiles.Size = new System.Drawing.Size(748, 331);
            this.lvwFiles.TabIndex = 3;
            this.lvwFiles.UseCompatibleStateImageBehavior = false;
            this.lvwFiles.View = System.Windows.Forms.View.Details;
            this.lvwFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.Control_DragDrop);
            this.lvwFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.Control_DragEnter);
            // 
            // chFile
            // 
            this.chFile.Text = "File";
            this.chFile.Width = 370;
            // 
            // chVersion
            // 
            this.chVersion.Text = "Version";
            this.chVersion.Width = 58;
            // 
            // chLayer
            // 
            this.chLayer.Text = "Layer";
            this.chLayer.Width = 54;
            // 
            // chBitrate
            // 
            this.chBitrate.Text = "Bitrate";
            this.chBitrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chBitrate.Width = 44;
            // 
            // chSampleRate
            // 
            this.chSampleRate.Text = "Sample Rate";
            this.chSampleRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chSampleRate.Width = 75;
            // 
            // chMode
            // 
            this.chMode.Text = "Mode";
            this.chMode.Width = 70;
            // 
            // chTags
            // 
            this.chTags.Text = "Tags";
            this.chTags.Width = 50;
            // 
            // cmsFile
            // 
            this.cmsFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFilePlay});
            this.cmsFile.Name = "cmsFile";
            this.cmsFile.Size = new System.Drawing.Size(116, 26);
            this.cmsFile.Opening += new System.ComponentModel.CancelEventHandler(this.cmsFile_Opening);
            // 
            // mnuFilePlay
            // 
            this.mnuFilePlay.Image = ((System.Drawing.Image)(resources.GetObject("mnuFilePlay.Image")));
            this.mnuFilePlay.Name = "mnuFilePlay";
            this.mnuFilePlay.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuFilePlay.Size = new System.Drawing.Size(115, 22);
            this.mnuFilePlay.Text = "&Play";
            this.mnuFilePlay.Click += new System.EventHandler(this.mnuFilePlay_Click);
            // 
            // cmsDirectory
            // 
            this.cmsDirectory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDirectoryOpenFormClipboard,
            this.mnuDirectorySeparator1,
            this.mnuDirectoryExplore,
            this.mnuDirectoryReload});
            this.cmsDirectory.Name = "cmsFile";
            this.cmsDirectory.Size = new System.Drawing.Size(188, 98);
            this.cmsDirectory.Opening += new System.ComponentModel.CancelEventHandler(this.cmsDirectory_Opening);
            // 
            // mnuDirectoryOpenFormClipboard
            // 
            this.mnuDirectoryOpenFormClipboard.Image = ((System.Drawing.Image)(resources.GetObject("mnuDirectoryOpenFormClipboard.Image")));
            this.mnuDirectoryOpenFormClipboard.Name = "mnuDirectoryOpenFormClipboard";
            this.mnuDirectoryOpenFormClipboard.Size = new System.Drawing.Size(187, 22);
            this.mnuDirectoryOpenFormClipboard.Text = "&Open from Clipboard";
            this.mnuDirectoryOpenFormClipboard.Click += new System.EventHandler(this.mnuDirectoryOpenFormClipboard_Click);
            // 
            // mnuDirectorySeparator1
            // 
            this.mnuDirectorySeparator1.Name = "mnuDirectorySeparator1";
            this.mnuDirectorySeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // mnuDirectoryExplore
            // 
            this.mnuDirectoryExplore.Image = ((System.Drawing.Image)(resources.GetObject("mnuDirectoryExplore.Image")));
            this.mnuDirectoryExplore.Name = "mnuDirectoryExplore";
            this.mnuDirectoryExplore.Size = new System.Drawing.Size(187, 22);
            this.mnuDirectoryExplore.Text = "&Explore";
            this.mnuDirectoryExplore.Click += new System.EventHandler(this.mnuDirectoryExplore_Click);
            // 
            // mnuDirectoryReload
            // 
            this.mnuDirectoryReload.Image = ((System.Drawing.Image)(resources.GetObject("mnuDirectoryReload.Image")));
            this.mnuDirectoryReload.Name = "mnuDirectoryReload";
            this.mnuDirectoryReload.Size = new System.Drawing.Size(187, 22);
            this.mnuDirectoryReload.Text = "&Reload";
            this.mnuDirectoryReload.Click += new System.EventHandler(this.mnuDirectoryReload_Click);
            // 
            // txtSourceDirectory
            // 
            this.txtSourceDirectory.AllowDrop = true;
            this.txtSourceDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceDirectory.ContextMenuStrip = this.cmsDirectory;
            this.txtSourceDirectory.Location = new System.Drawing.Point(77, 36);
            this.txtSourceDirectory.Name = "txtSourceDirectory";
            this.txtSourceDirectory.ReadOnly = true;
            this.txtSourceDirectory.Size = new System.Drawing.Size(602, 21);
            this.txtSourceDirectory.TabIndex = 1;
            this.txtSourceDirectory.DragDrop += new System.Windows.Forms.DragEventHandler(this.Control_DragDrop);
            this.txtSourceDirectory.DragEnter += new System.Windows.Forms.DragEventHandler(this.Control_DragEnter);
            // 
            // FilesStep
            // 
            this.Controls.Add(this.chkReEncodeFiles);
            this.Controls.Add(this.chkIgnoreInconsistentFiles);
            this.Controls.Add(this.chkIgnoreLowQualityFiles);
            this.Controls.Add(this.chkIgnoreDamagedFiles);
            this.Controls.Add(this.btnBrowseSourceDirectory);
            this.Controls.Add(this.lblSourceDirectory);
            this.Controls.Add(this.txtSourceDirectory);
            this.Controls.Add(this.lvwFiles);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FilesStep";
            this.Size = new System.Drawing.Size(772, 482);
            this.cmsFile.ResumeLayout(false);
            this.cmsDirectory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkReEncodeFiles;
        private System.Windows.Forms.CheckBox chkIgnoreInconsistentFiles;
        private System.Windows.Forms.CheckBox chkIgnoreLowQualityFiles;
        private System.Windows.Forms.CheckBox chkIgnoreDamagedFiles;
        private System.Windows.Forms.Button btnBrowseSourceDirectory;
        private System.Windows.Forms.Label lblSourceDirectory;
        private System.Windows.Forms.ListView lvwFiles;
        public System.Windows.Forms.ColumnHeader chFile;
        private System.Windows.Forms.ColumnHeader chVersion;
        private System.Windows.Forms.ColumnHeader chLayer;
        private System.Windows.Forms.ColumnHeader chBitrate;
        private System.Windows.Forms.ColumnHeader chSampleRate;
        private System.Windows.Forms.ColumnHeader chMode;
        private System.Windows.Forms.ContextMenuStrip cmsFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFilePlay;
        private System.Windows.Forms.ContextMenuStrip cmsDirectory;
        private System.Windows.Forms.ToolStripMenuItem mnuDirectoryOpenFormClipboard;
        private System.Windows.Forms.ToolStripSeparator mnuDirectorySeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuDirectoryExplore;
        private System.Windows.Forms.ToolStripMenuItem mnuDirectoryReload;
        private System.Windows.Forms.TextBox txtSourceDirectory;
        private System.Windows.Forms.ColumnHeader chTags;
    }
}
