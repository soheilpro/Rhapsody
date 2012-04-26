using System;

namespace Rhapsody.UI.Steps
{
    partial class AlbumStep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlbumStep));
            this.cmsTrack = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuTrackPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrackSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTrackRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrackMakeProperCase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrackRemoveDiacritics = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrackAppend = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrackSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTrackRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrackSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTrackMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrackMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrackSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTrackMoveToDisc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrackMoveToDiscSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTrackMoveToDiscNewDisc = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsText = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuTextUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTextCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTextSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTextMakeProperCase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextRemoveDiacritics = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTextSetTo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextSetToArtist = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextSetToAlbum = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextSetToYear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsDirectory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDirectoryExplore = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotalRunningTime = new System.Windows.Forms.Label();
            this.lblTotalRunningTimeLabel = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.btnBrowseDestinationDirectory = new System.Windows.Forms.Button();
            this.lblDestinationDirectory = new System.Windows.Forms.Label();
            this.lblTracks = new System.Windows.Forms.Label();
            this.txtArtistName = new System.Windows.Forms.TextBox();
            this.txtAlbumName = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblReleaseYear = new System.Windows.Forms.Label();
            this.lblArtistName = new System.Windows.Forms.Label();
            this.lblAlbumName = new System.Windows.Forms.Label();
            this.lvwTracks = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTrackFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtDestinationDirectory = new System.Windows.Forms.TextBox();
            this.btnAutoSet = new System.Windows.Forms.Button();
            this.btnDiscs = new System.Windows.Forms.Button();
            this.picCover = new AdvancedPictureBox();
            this.cmsCover = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCoverViewFullSize = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCoverSaveToDisc = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearCover = new System.Windows.Forms.Button();
            this.cmsLoadCover = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuLoadCoverSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLoadCoverOpenUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadCoverBrowse = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAutoSet = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblCoverInfo = new System.Windows.Forms.Label();
            this.cboReleaseYear = new System.Windows.Forms.ComboBox();
            this.btnLoadCover = new System.Windows.Forms.Button();
            this.cmsTrack.SuspendLayout();
            this.cmsText.SuspendLayout();
            this.cmsDirectory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            this.cmsCover.SuspendLayout();
            this.cmsLoadCover.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsTrack
            // 
            this.cmsTrack.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTrackPlay,
            this.mnuTrackSeparator1,
            this.mnuTrackRename,
            this.mnuTrackMakeProperCase,
            this.mnuTrackRemoveDiacritics,
            this.mnuTrackAppend,
            this.mnuTrackSeparator2,
            this.mnuTrackRemove,
            this.mnuTrackSeparator3,
            this.mnuTrackMoveUp,
            this.mnuTrackMoveDown,
            this.mnuTrackSeparator4,
            this.mnuTrackMoveToDisc});
            this.cmsTrack.Name = "cmsTrack";
            this.cmsTrack.Size = new System.Drawing.Size(200, 226);
            this.cmsTrack.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTrack_Opening);
            // 
            // mnuTrackPlay
            // 
            this.mnuTrackPlay.Image = ((System.Drawing.Image)(resources.GetObject("mnuTrackPlay.Image")));
            this.mnuTrackPlay.Name = "mnuTrackPlay";
            this.mnuTrackPlay.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuTrackPlay.Size = new System.Drawing.Size(199, 22);
            this.mnuTrackPlay.Text = "&Play";
            this.mnuTrackPlay.Click += new System.EventHandler(this.mnuTrackPlay_Click);
            // 
            // mnuTrackSeparator1
            // 
            this.mnuTrackSeparator1.Name = "mnuTrackSeparator1";
            this.mnuTrackSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // mnuTrackRename
            // 
            this.mnuTrackRename.Image = ((System.Drawing.Image)(resources.GetObject("mnuTrackRename.Image")));
            this.mnuTrackRename.Name = "mnuTrackRename";
            this.mnuTrackRename.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuTrackRename.Size = new System.Drawing.Size(199, 22);
            this.mnuTrackRename.Text = "&Rename";
            this.mnuTrackRename.Click += new System.EventHandler(this.mnuTrackRename_Click);
            // 
            // mnuTrackMakeProperCase
            // 
            this.mnuTrackMakeProperCase.Image = ((System.Drawing.Image)(resources.GetObject("mnuTrackMakeProperCase.Image")));
            this.mnuTrackMakeProperCase.Name = "mnuTrackMakeProperCase";
            this.mnuTrackMakeProperCase.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mnuTrackMakeProperCase.Size = new System.Drawing.Size(199, 22);
            this.mnuTrackMakeProperCase.Text = "Make Proper &Case";
            this.mnuTrackMakeProperCase.Click += new System.EventHandler(this.mnuTrackMakeProperCase_Click);
            // 
            // mnuTrackRemoveDiacritics
            // 
            this.mnuTrackRemoveDiacritics.Name = "mnuTrackRemoveDiacritics";
            this.mnuTrackRemoveDiacritics.Size = new System.Drawing.Size(199, 22);
            this.mnuTrackRemoveDiacritics.Text = "Remove &Diacritics";
            this.mnuTrackRemoveDiacritics.Click += new System.EventHandler(this.mnuTrackRemoveDiacritics_Click);
            // 
            // mnuTrackAppend
            // 
            this.mnuTrackAppend.Name = "mnuTrackAppend";
            this.mnuTrackAppend.Size = new System.Drawing.Size(199, 22);
            this.mnuTrackAppend.Text = "&Append";
            // 
            // mnuTrackSeparator2
            // 
            this.mnuTrackSeparator2.Name = "mnuTrackSeparator2";
            this.mnuTrackSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // mnuTrackRemove
            // 
            this.mnuTrackRemove.Image = ((System.Drawing.Image)(resources.GetObject("mnuTrackRemove.Image")));
            this.mnuTrackRemove.Name = "mnuTrackRemove";
            this.mnuTrackRemove.Size = new System.Drawing.Size(199, 22);
            this.mnuTrackRemove.Text = "Remove";
            this.mnuTrackRemove.Click += new System.EventHandler(this.mnuTrackRemove_Click);
            // 
            // mnuTrackSeparator3
            // 
            this.mnuTrackSeparator3.Name = "mnuTrackSeparator3";
            this.mnuTrackSeparator3.Size = new System.Drawing.Size(196, 6);
            // 
            // mnuTrackMoveUp
            // 
            this.mnuTrackMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("mnuTrackMoveUp.Image")));
            this.mnuTrackMoveUp.Name = "mnuTrackMoveUp";
            this.mnuTrackMoveUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up)));
            this.mnuTrackMoveUp.Size = new System.Drawing.Size(199, 22);
            this.mnuTrackMoveUp.Text = "Move &Up";
            this.mnuTrackMoveUp.Click += new System.EventHandler(this.mnuTrackMoveUp_Click);
            // 
            // mnuTrackMoveDown
            // 
            this.mnuTrackMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("mnuTrackMoveDown.Image")));
            this.mnuTrackMoveDown.Name = "mnuTrackMoveDown";
            this.mnuTrackMoveDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
            this.mnuTrackMoveDown.Size = new System.Drawing.Size(199, 22);
            this.mnuTrackMoveDown.Text = "Move &Down";
            this.mnuTrackMoveDown.Click += new System.EventHandler(this.mnuTrackMoveDown_Click);
            // 
            // mnuTrackSeparator4
            // 
            this.mnuTrackSeparator4.Name = "mnuTrackSeparator4";
            this.mnuTrackSeparator4.Size = new System.Drawing.Size(196, 6);
            // 
            // mnuTrackMoveToDisc
            // 
            this.mnuTrackMoveToDisc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTrackMoveToDiscSeparator1,
            this.mnuTrackMoveToDiscNewDisc});
            this.mnuTrackMoveToDisc.Image = ((System.Drawing.Image)(resources.GetObject("mnuTrackMoveToDisc.Image")));
            this.mnuTrackMoveToDisc.Name = "mnuTrackMoveToDisc";
            this.mnuTrackMoveToDisc.Size = new System.Drawing.Size(199, 22);
            this.mnuTrackMoveToDisc.Text = "Move &to Disc";
            // 
            // mnuTrackMoveToDiscSeparator1
            // 
            this.mnuTrackMoveToDiscSeparator1.Name = "mnuTrackMoveToDiscSeparator1";
            this.mnuTrackMoveToDiscSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // mnuTrackMoveToDiscNewDisc
            // 
            this.mnuTrackMoveToDiscNewDisc.Image = ((System.Drawing.Image)(resources.GetObject("mnuTrackMoveToDiscNewDisc.Image")));
            this.mnuTrackMoveToDiscNewDisc.Name = "mnuTrackMoveToDiscNewDisc";
            this.mnuTrackMoveToDiscNewDisc.Size = new System.Drawing.Size(123, 22);
            this.mnuTrackMoveToDiscNewDisc.Text = "New Disc";
            this.mnuTrackMoveToDiscNewDisc.Click += new System.EventHandler(this.mnuTrackMoveToDiscNewDisc_Click);
            // 
            // cmsText
            // 
            this.cmsText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTextUndo,
            this.mnuTextSeparator1,
            this.mnuTextCut,
            this.mnuTextCopy,
            this.mnuTextPaste,
            this.mnuTextDelete,
            this.mnuTextSeparator2,
            this.mnuTextSelectAll,
            this.mnuTextSeparator3,
            this.mnuTextMakeProperCase,
            this.mnuTextRemoveDiacritics,
            this.mnuTextSeparator4,
            this.mnuTextSetTo,
            this.mnuTextSeparator5});
            this.cmsText.Name = "cmsTextBox";
            this.cmsText.Size = new System.Drawing.Size(189, 254);
            this.cmsText.Opening += new System.ComponentModel.CancelEventHandler(this.cmsText_Opening);
            // 
            // mnuTextUndo
            // 
            this.mnuTextUndo.Name = "mnuTextUndo";
            this.mnuTextUndo.Size = new System.Drawing.Size(188, 22);
            this.mnuTextUndo.Text = "&Undo";
            this.mnuTextUndo.Click += new System.EventHandler(this.mnuTextUndo_Click);
            // 
            // mnuTextSeparator1
            // 
            this.mnuTextSeparator1.Name = "mnuTextSeparator1";
            this.mnuTextSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // mnuTextCut
            // 
            this.mnuTextCut.Name = "mnuTextCut";
            this.mnuTextCut.Size = new System.Drawing.Size(188, 22);
            this.mnuTextCut.Text = "Cu&t";
            this.mnuTextCut.Click += new System.EventHandler(this.mnuTextCut_Click);
            // 
            // mnuTextCopy
            // 
            this.mnuTextCopy.Name = "mnuTextCopy";
            this.mnuTextCopy.Size = new System.Drawing.Size(188, 22);
            this.mnuTextCopy.Text = "&Copy";
            this.mnuTextCopy.Click += new System.EventHandler(this.mnuTextCopy_Click);
            // 
            // mnuTextPaste
            // 
            this.mnuTextPaste.Name = "mnuTextPaste";
            this.mnuTextPaste.Size = new System.Drawing.Size(188, 22);
            this.mnuTextPaste.Text = "&Paste";
            this.mnuTextPaste.Click += new System.EventHandler(this.mnuTextPaste_Click);
            // 
            // mnuTextDelete
            // 
            this.mnuTextDelete.Name = "mnuTextDelete";
            this.mnuTextDelete.Size = new System.Drawing.Size(188, 22);
            this.mnuTextDelete.Text = "&Delete";
            this.mnuTextDelete.Click += new System.EventHandler(this.mnuTextDelete_Click);
            // 
            // mnuTextSeparator2
            // 
            this.mnuTextSeparator2.Name = "mnuTextSeparator2";
            this.mnuTextSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // mnuTextSelectAll
            // 
            this.mnuTextSelectAll.Name = "mnuTextSelectAll";
            this.mnuTextSelectAll.Size = new System.Drawing.Size(188, 22);
            this.mnuTextSelectAll.Text = "Select &All";
            this.mnuTextSelectAll.Click += new System.EventHandler(this.mnuTextSelectAll_Click);
            // 
            // mnuTextSeparator3
            // 
            this.mnuTextSeparator3.Name = "mnuTextSeparator3";
            this.mnuTextSeparator3.Size = new System.Drawing.Size(185, 6);
            // 
            // mnuTextMakeProperCase
            // 
            this.mnuTextMakeProperCase.Image = ((System.Drawing.Image)(resources.GetObject("mnuTextMakeProperCase.Image")));
            this.mnuTextMakeProperCase.Name = "mnuTextMakeProperCase";
            this.mnuTextMakeProperCase.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mnuTextMakeProperCase.Size = new System.Drawing.Size(188, 22);
            this.mnuTextMakeProperCase.Text = "Make Proper &Case";
            this.mnuTextMakeProperCase.Click += new System.EventHandler(this.mnuTextMakeProperCase_Click);
            // 
            // mnuTextRemoveDiacritics
            // 
            this.mnuTextRemoveDiacritics.Name = "mnuTextRemoveDiacritics";
            this.mnuTextRemoveDiacritics.Size = new System.Drawing.Size(188, 22);
            this.mnuTextRemoveDiacritics.Text = "Remove &Diacritics";
            this.mnuTextRemoveDiacritics.Click += new System.EventHandler(this.mnuTextRemoveDiacritics_Click);
            // 
            // mnuTextSeparator4
            // 
            this.mnuTextSeparator4.Name = "mnuTextSeparator4";
            this.mnuTextSeparator4.Size = new System.Drawing.Size(185, 6);
            // 
            // mnuTextSetTo
            // 
            this.mnuTextSetTo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTextSetToArtist,
            this.mnuTextSetToAlbum,
            this.mnuTextSetToYear});
            this.mnuTextSetTo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuTextSetTo.Name = "mnuTextSetTo";
            this.mnuTextSetTo.Size = new System.Drawing.Size(188, 22);
            this.mnuTextSetTo.Text = "&Set To";
            // 
            // mnuTextSetToArtist
            // 
            this.mnuTextSetToArtist.Name = "mnuTextSetToArtist";
            this.mnuTextSetToArtist.Size = new System.Drawing.Size(110, 22);
            this.mnuTextSetToArtist.Text = "&Artist";
            this.mnuTextSetToArtist.Click += new System.EventHandler(this.mnuTextSetToArtist_Click);
            // 
            // mnuTextSetToAlbum
            // 
            this.mnuTextSetToAlbum.Name = "mnuTextSetToAlbum";
            this.mnuTextSetToAlbum.Size = new System.Drawing.Size(110, 22);
            this.mnuTextSetToAlbum.Text = "A&lbum";
            this.mnuTextSetToAlbum.Click += new System.EventHandler(this.mnuTextSetToAlbum_Click);
            // 
            // mnuTextSetToYear
            // 
            this.mnuTextSetToYear.Name = "mnuTextSetToYear";
            this.mnuTextSetToYear.Size = new System.Drawing.Size(110, 22);
            this.mnuTextSetToYear.Text = "&Year";
            this.mnuTextSetToYear.Click += new System.EventHandler(this.mnuTextSetToYear_Click);
            // 
            // mnuTextSeparator5
            // 
            this.mnuTextSeparator5.Name = "mnuTextSeparator5";
            this.mnuTextSeparator5.Size = new System.Drawing.Size(185, 6);
            // 
            // cmsDirectory
            // 
            this.cmsDirectory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDirectoryExplore});
            this.cmsDirectory.Name = "cmsFile";
            this.cmsDirectory.Size = new System.Drawing.Size(113, 26);
            this.cmsDirectory.Opening += new System.ComponentModel.CancelEventHandler(this.cmsDirectory_Opening);
            // 
            // mnuDirectoryExplore
            // 
            this.mnuDirectoryExplore.Image = ((System.Drawing.Image)(resources.GetObject("mnuDirectoryExplore.Image")));
            this.mnuDirectoryExplore.Name = "mnuDirectoryExplore";
            this.mnuDirectoryExplore.Size = new System.Drawing.Size(112, 22);
            this.mnuDirectoryExplore.Text = "&Explore";
            this.mnuDirectoryExplore.Click += new System.EventHandler(this.mnuDirectoryExplore_Click);
            // 
            // lblTotalRunningTime
            // 
            this.lblTotalRunningTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRunningTime.AutoSize = true;
            this.lblTotalRunningTime.Location = new System.Drawing.Point(65, 390);
            this.lblTotalRunningTime.Name = "lblTotalRunningTime";
            this.lblTotalRunningTime.Size = new System.Drawing.Size(51, 13);
            this.lblTotalRunningTime.TabIndex = 12;
            this.lblTotalRunningTime.Text = "00:00:00";
            // 
            // lblTotalRunningTimeLabel
            // 
            this.lblTotalRunningTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRunningTimeLabel.AutoSize = true;
            this.lblTotalRunningTimeLabel.Location = new System.Drawing.Point(12, 390);
            this.lblTotalRunningTimeLabel.Name = "lblTotalRunningTimeLabel";
            this.lblTotalRunningTimeLabel.Size = new System.Drawing.Size(52, 13);
            this.lblTotalRunningTimeLabel.TabIndex = 11;
            this.lblTotalRunningTimeLabel.Text = "Duration:";
            // 
            // cboType
            // 
            this.cboType.DropDownHeight = 200;
            this.cboType.FormattingEnabled = true;
            this.cboType.IntegralHeight = false;
            this.cboType.Location = new System.Drawing.Point(598, 61);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(90, 21);
            this.cboType.TabIndex = 7;
            this.cboType.TextChanged += new System.EventHandler(this.cboType_TextChanged);
            // 
            // btnBrowseDestinationDirectory
            // 
            this.btnBrowseDestinationDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDestinationDirectory.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseDestinationDirectory.Image")));
            this.btnBrowseDestinationDirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseDestinationDirectory.Location = new System.Drawing.Point(948, 435);
            this.btnBrowseDestinationDirectory.Name = "btnBrowseDestinationDirectory";
            this.btnBrowseDestinationDirectory.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.btnBrowseDestinationDirectory.Size = new System.Drawing.Size(75, 25);
            this.btnBrowseDestinationDirectory.TabIndex = 20;
            this.btnBrowseDestinationDirectory.Text = "B&rowse";
            this.btnBrowseDestinationDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowseDestinationDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseDestinationDirectory.Click += new System.EventHandler(this.btnBrowseDestinationDirectory_Click);
            // 
            // lblDestinationDirectory
            // 
            this.lblDestinationDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDestinationDirectory.AutoSize = true;
            this.lblDestinationDirectory.Location = new System.Drawing.Point(12, 441);
            this.lblDestinationDirectory.Name = "lblDestinationDirectory";
            this.lblDestinationDirectory.Size = new System.Drawing.Size(48, 13);
            this.lblDestinationDirectory.TabIndex = 18;
            this.lblDestinationDirectory.Text = "Save to:";
            // 
            // lblTracks
            // 
            this.lblTracks.AutoSize = true;
            this.lblTracks.Location = new System.Drawing.Point(12, 104);
            this.lblTracks.Name = "lblTracks";
            this.lblTracks.Size = new System.Drawing.Size(42, 13);
            this.lblTracks.TabIndex = 9;
            this.lblTracks.Text = "Tracks:";
            // 
            // txtArtistName
            // 
            this.txtArtistName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtArtistName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtArtistName.ContextMenuStrip = this.cmsText;
            this.txtArtistName.Location = new System.Drawing.Point(80, 35);
            this.txtArtistName.Name = "txtArtistName";
            this.txtArtistName.Size = new System.Drawing.Size(300, 21);
            this.txtArtistName.TabIndex = 1;
            this.txtArtistName.TextChanged += new System.EventHandler(this.txtArtistName_TextChanged);
            this.txtArtistName.Leave += new System.EventHandler(this.txtArtistName_Leave);
            // 
            // txtAlbumName
            // 
            this.txtAlbumName.ContextMenuStrip = this.cmsText;
            this.txtAlbumName.Location = new System.Drawing.Point(80, 61);
            this.txtAlbumName.Name = "txtAlbumName";
            this.txtAlbumName.Size = new System.Drawing.Size(300, 21);
            this.txtAlbumName.TabIndex = 3;
            this.txtAlbumName.TextChanged += new System.EventHandler(this.txtAlbumName_TextChanged);
            this.txtAlbumName.Leave += new System.EventHandler(this.txtAlbumName_Leave);
            // 
            // lblType
            // 
            this.lblType.Image = ((System.Drawing.Image)(resources.GetObject("lblType.Image")));
            this.lblType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblType.Location = new System.Drawing.Point(539, 63);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(53, 17);
            this.lblType.TabIndex = 6;
            this.lblType.Text = "&Type";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReleaseYear
            // 
            this.lblReleaseYear.Image = ((System.Drawing.Image)(resources.GetObject("lblReleaseYear.Image")));
            this.lblReleaseYear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReleaseYear.Location = new System.Drawing.Point(402, 63);
            this.lblReleaseYear.Name = "lblReleaseYear";
            this.lblReleaseYear.Size = new System.Drawing.Size(53, 17);
            this.lblReleaseYear.TabIndex = 4;
            this.lblReleaseYear.Text = "&Year:";
            this.lblReleaseYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblArtistName
            // 
            this.lblArtistName.Image = ((System.Drawing.Image)(resources.GetObject("lblArtistName.Image")));
            this.lblArtistName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblArtistName.Location = new System.Drawing.Point(12, 37);
            this.lblArtistName.Name = "lblArtistName";
            this.lblArtistName.Size = new System.Drawing.Size(59, 17);
            this.lblArtistName.TabIndex = 0;
            this.lblArtistName.Text = "&Artist:";
            this.lblArtistName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAlbumName
            // 
            this.lblAlbumName.Image = ((System.Drawing.Image)(resources.GetObject("lblAlbumName.Image")));
            this.lblAlbumName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAlbumName.Location = new System.Drawing.Point(12, 63);
            this.lblAlbumName.Name = "lblAlbumName";
            this.lblAlbumName.Size = new System.Drawing.Size(62, 17);
            this.lblAlbumName.TabIndex = 2;
            this.lblAlbumName.Text = "A&lbum:";
            this.lblAlbumName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lvwTracks
            // 
            this.lvwTracks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTracks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chIndex,
            this.chDuration,
            this.chTrackFile});
            this.lvwTracks.ContextMenuStrip = this.cmsTrack;
            this.lvwTracks.FullRowSelect = true;
            this.lvwTracks.LabelEdit = true;
            this.lvwTracks.Location = new System.Drawing.Point(12, 122);
            this.lvwTracks.Name = "lvwTracks";
            this.lvwTracks.Size = new System.Drawing.Size(748, 257);
            this.lvwTracks.TabIndex = 10;
            this.lvwTracks.UseCompatibleStateImageBehavior = false;
            this.lvwTracks.View = System.Windows.Forms.View.Details;
            this.lvwTracks.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvwTracks_AfterLabelEdit);
            // 
            // chName
            // 
            this.chName.DisplayIndex = 1;
            this.chName.Text = "Name";
            this.chName.Width = 316;
            // 
            // chIndex
            // 
            this.chIndex.DisplayIndex = 0;
            this.chIndex.Text = "Index";
            this.chIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chIndex.Width = 40;
            // 
            // chDuration
            // 
            this.chDuration.Text = "Duration";
            this.chDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chDuration.Width = 56;
            // 
            // chTrackFile
            // 
            this.chTrackFile.Text = "File";
            this.chTrackFile.Width = 316;
            // 
            // txtDestinationDirectory
            // 
            this.txtDestinationDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinationDirectory.ContextMenuStrip = this.cmsDirectory;
            this.txtDestinationDirectory.Location = new System.Drawing.Point(66, 437);
            this.txtDestinationDirectory.Name = "txtDestinationDirectory";
            this.txtDestinationDirectory.ReadOnly = true;
            this.txtDestinationDirectory.Size = new System.Drawing.Size(876, 21);
            this.txtDestinationDirectory.TabIndex = 19;
            // 
            // btnAutoSet
            // 
            this.btnAutoSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoSet.Location = new System.Drawing.Point(948, 60);
            this.btnAutoSet.Name = "btnAutoSet";
            this.btnAutoSet.Size = new System.Drawing.Size(75, 23);
            this.btnAutoSet.TabIndex = 8;
            this.btnAutoSet.Text = "Auto Set";
            this.btnAutoSet.UseVisualStyleBackColor = true;
            this.btnAutoSet.Click += new System.EventHandler(this.btnAutoSet_Click);
            // 
            // btnDiscs
            // 
            this.btnDiscs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiscs.Location = new System.Drawing.Point(685, 385);
            this.btnDiscs.Name = "btnDiscs";
            this.btnDiscs.Size = new System.Drawing.Size(75, 23);
            this.btnDiscs.TabIndex = 13;
            this.btnDiscs.Text = "Discs...";
            this.btnDiscs.UseVisualStyleBackColor = true;
            this.btnDiscs.Click += new System.EventHandler(this.btnDiscs_Click);
            // 
            // picCover
            // 
            this.picCover.AllowDrop = true;
            this.picCover.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCover.ContextMenuStrip = this.cmsCover;
            this.picCover.Image = null;
            this.picCover.Location = new System.Drawing.Point(768, 122);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(255, 257);
            this.picCover.TabIndex = 14;
            this.picCover.TabStop = false;
            this.picCover.DragDrop += new System.Windows.Forms.DragEventHandler(this.picCover_DragDrop);
            this.picCover.DragEnter += new System.Windows.Forms.DragEventHandler(this.picCover_DragEnter);
            // 
            // cmsCover
            // 
            this.cmsCover.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCoverViewFullSize,
            this.mnuCoverSaveToDisc});
            this.cmsCover.Name = "cmsCover";
            this.cmsCover.Size = new System.Drawing.Size(153, 70);
            this.cmsCover.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCover_Opening);
            // 
            // mnuCoverViewFullSize
            // 
            this.mnuCoverViewFullSize.Name = "mnuCoverViewFullSize";
            this.mnuCoverViewFullSize.Size = new System.Drawing.Size(152, 22);
            this.mnuCoverViewFullSize.Text = "View full size...";
            this.mnuCoverViewFullSize.Click += new System.EventHandler(this.mnuCoverViewFullSize_Click);
            // 
            // mnuCoverSaveToDisc
            // 
            this.mnuCoverSaveToDisc.Name = "mnuCoverSaveToDisc";
            this.mnuCoverSaveToDisc.Size = new System.Drawing.Size(152, 22);
            this.mnuCoverSaveToDisc.Text = "Save to disc...";
            this.mnuCoverSaveToDisc.Click += new System.EventHandler(this.mnuCoverSaveToDisc_Click);
            // 
            // btnClearCover
            // 
            this.btnClearCover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCover.Location = new System.Drawing.Point(948, 385);
            this.btnClearCover.Name = "btnClearCover";
            this.btnClearCover.Size = new System.Drawing.Size(75, 23);
            this.btnClearCover.TabIndex = 17;
            this.btnClearCover.Text = "Clear";
            this.btnClearCover.UseVisualStyleBackColor = true;
            this.btnClearCover.Click += new System.EventHandler(this.btnClearCover_Click);
            // 
            // cmsLoadCover
            // 
            this.cmsLoadCover.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLoadCoverSeparator,
            this.mnuLoadCoverOpenUrl,
            this.mnuLoadCoverBrowse});
            this.cmsLoadCover.Name = "cmsLoadCover";
            this.cmsLoadCover.Size = new System.Drawing.Size(153, 76);
            // 
            // mnuLoadCoverSeparator
            // 
            this.mnuLoadCoverSeparator.Name = "mnuLoadCoverSeparator";
            this.mnuLoadCoverSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuLoadCoverOpenUrl
            // 
            this.mnuLoadCoverOpenUrl.Name = "mnuLoadCoverOpenUrl";
            this.mnuLoadCoverOpenUrl.Size = new System.Drawing.Size(152, 22);
            this.mnuLoadCoverOpenUrl.Text = "Open URL...";
            this.mnuLoadCoverOpenUrl.Click += new System.EventHandler(this.mnuLoadCoverOpenUrl_Click);
            // 
            // mnuLoadCoverBrowse
            // 
            this.mnuLoadCoverBrowse.Name = "mnuLoadCoverBrowse";
            this.mnuLoadCoverBrowse.Size = new System.Drawing.Size(152, 22);
            this.mnuLoadCoverBrowse.Text = "Browse...";
            this.mnuLoadCoverBrowse.Click += new System.EventHandler(this.mnuLoadCoverBrowse_Click);
            // 
            // cmsAutoSet
            // 
            this.cmsAutoSet.Name = "cmsAlbumInfo";
            this.cmsAutoSet.Size = new System.Drawing.Size(61, 4);
            // 
            // lblCoverInfo
            // 
            this.lblCoverInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCoverInfo.AutoSize = true;
            this.lblCoverInfo.Location = new System.Drawing.Point(766, 390);
            this.lblCoverInfo.Name = "lblCoverInfo";
            this.lblCoverInfo.Size = new System.Drawing.Size(0, 13);
            this.lblCoverInfo.TabIndex = 15;
            // 
            // cboReleaseYear
            // 
            this.cboReleaseYear.FormattingEnabled = true;
            this.cboReleaseYear.Location = new System.Drawing.Point(461, 61);
            this.cboReleaseYear.Name = "cboReleaseYear";
            this.cboReleaseYear.Size = new System.Drawing.Size(55, 21);
            this.cboReleaseYear.TabIndex = 5;
            this.cboReleaseYear.Text = "1999";
            this.cboReleaseYear.TextChanged += new System.EventHandler(this.cboReleaseYear_TextChanged);
            // 
            // btnLoadCover
            // 
            this.btnLoadCover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadCover.Location = new System.Drawing.Point(867, 385);
            this.btnLoadCover.Name = "btnLoadCover";
            this.btnLoadCover.Size = new System.Drawing.Size(75, 23);
            this.btnLoadCover.TabIndex = 16;
            this.btnLoadCover.Text = "Load...";
            this.btnLoadCover.UseVisualStyleBackColor = true;
            this.btnLoadCover.Click += new System.EventHandler(this.btnLoadCover_Click);
            // 
            // AlbumStep
            // 
            this.Controls.Add(this.btnClearCover);
            this.Controls.Add(this.picCover);
            this.Controls.Add(this.btnBrowseDestinationDirectory);
            this.Controls.Add(this.txtDestinationDirectory);
            this.Controls.Add(this.btnDiscs);
            this.Controls.Add(this.lblTotalRunningTime);
            this.Controls.Add(this.lblTotalRunningTimeLabel);
            this.Controls.Add(this.btnAutoSet);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.lblDestinationDirectory);
            this.Controls.Add(this.lblCoverInfo);
            this.Controls.Add(this.lblTracks);
            this.Controls.Add(this.txtArtistName);
            this.Controls.Add(this.txtAlbumName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblReleaseYear);
            this.Controls.Add(this.lblArtistName);
            this.Controls.Add(this.lblAlbumName);
            this.Controls.Add(this.lvwTracks);
            this.Controls.Add(this.cboReleaseYear);
            this.Controls.Add(this.btnLoadCover);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AlbumStep";
            this.Size = new System.Drawing.Size(1035, 482);
            this.cmsTrack.ResumeLayout(false);
            this.cmsText.ResumeLayout(false);
            this.cmsDirectory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            this.cmsCover.ResumeLayout(false);
            this.cmsLoadCover.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalRunningTime;
        private System.Windows.Forms.Label lblTotalRunningTimeLabel;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Button btnBrowseDestinationDirectory;
        private System.Windows.Forms.Label lblDestinationDirectory;
        private System.Windows.Forms.Label lblTracks;
        private System.Windows.Forms.TextBox txtArtistName;
        private System.Windows.Forms.TextBox txtAlbumName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblReleaseYear;
        private System.Windows.Forms.Label lblArtistName;
        private System.Windows.Forms.Label lblAlbumName;
        private System.Windows.Forms.ListView lvwTracks;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chIndex;
        private System.Windows.Forms.ColumnHeader chDuration;
        private System.Windows.Forms.ColumnHeader chTrackFile;
        private System.Windows.Forms.ContextMenuStrip cmsTrack;
        private System.Windows.Forms.ToolStripMenuItem mnuTrackPlay;
        private System.Windows.Forms.ToolStripSeparator mnuTrackSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuTrackRename;
        private System.Windows.Forms.ToolStripMenuItem mnuTrackMakeProperCase;
        private System.Windows.Forms.ToolStripMenuItem mnuTrackRemoveDiacritics;
        private System.Windows.Forms.ToolStripMenuItem mnuTrackAppend;
        private System.Windows.Forms.ToolStripSeparator mnuTrackSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuTrackRemove;
        private System.Windows.Forms.ToolStripSeparator mnuTrackSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuTrackMoveUp;
        private System.Windows.Forms.ToolStripMenuItem mnuTrackMoveDown;
        private System.Windows.Forms.ToolStripSeparator mnuTrackSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuTrackMoveToDisc;
        private System.Windows.Forms.ToolStripSeparator mnuTrackMoveToDiscSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuTrackMoveToDiscNewDisc;
        private System.Windows.Forms.ContextMenuStrip cmsText;
        private System.Windows.Forms.ToolStripMenuItem mnuTextUndo;
        private System.Windows.Forms.ToolStripSeparator mnuTextSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuTextCut;
        private System.Windows.Forms.ToolStripMenuItem mnuTextCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuTextPaste;
        private System.Windows.Forms.ToolStripMenuItem mnuTextDelete;
        private System.Windows.Forms.ToolStripSeparator mnuTextSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuTextSelectAll;
        private System.Windows.Forms.ToolStripSeparator mnuTextSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuTextMakeProperCase;
        private System.Windows.Forms.ToolStripMenuItem mnuTextRemoveDiacritics;
        private System.Windows.Forms.ToolStripSeparator mnuTextSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuTextSetTo;
        private System.Windows.Forms.ToolStripMenuItem mnuTextSetToArtist;
        private System.Windows.Forms.ToolStripMenuItem mnuTextSetToAlbum;
        private System.Windows.Forms.ToolStripMenuItem mnuTextSetToYear;
        private System.Windows.Forms.ToolStripSeparator mnuTextSeparator5;
        private System.Windows.Forms.ContextMenuStrip cmsDirectory;
        private System.Windows.Forms.ToolStripMenuItem mnuDirectoryExplore;
        private System.Windows.Forms.TextBox txtDestinationDirectory;
        private System.Windows.Forms.Button btnAutoSet;
        private System.Windows.Forms.Button btnDiscs;
        private AdvancedPictureBox picCover;
        private System.Windows.Forms.Button btnClearCover;
        private System.Windows.Forms.ContextMenuStrip cmsLoadCover;
        private System.Windows.Forms.ToolStripSeparator mnuLoadCoverSeparator;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadCoverBrowse;
        private System.Windows.Forms.ContextMenuStrip cmsAutoSet;
        private System.Windows.Forms.Label lblCoverInfo;
        private System.Windows.Forms.ComboBox cboReleaseYear;
        private System.Windows.Forms.ContextMenuStrip cmsCover;
        private System.Windows.Forms.ToolStripMenuItem mnuCoverSaveToDisc;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadCoverOpenUrl;
        private System.Windows.Forms.ToolStripMenuItem mnuCoverViewFullSize;
        private System.Windows.Forms.Button btnLoadCover;
    }
}
