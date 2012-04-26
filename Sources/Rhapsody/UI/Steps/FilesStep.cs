using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rhapsody.Core;
using Rhapsody.Core.AlbumInfoProviders;
using Rhapsody.Core.Mpeg;
using Rhapsody.Properties;
using Rhapsody.Utilities;

namespace Rhapsody.UI.Steps
{
    internal partial class FilesStep : Step
    {
        public FilesStep()
        {
            InitializeComponent();
        }

        public override void InitializeStep()
        {
            base.InitializeStep();

            SysImageListHelper.SetListViewImageList(lvwFiles, SystemImageListHelper.Instance, false);
        }

        public override void OnActivating()
        {
            base.OnActivating();

            txtSourceDirectory.Text = Session.SourceDirectory != null ? Session.SourceDirectory.FullName : null;
            PopulateFiles();
            SetControls();
            NextEnabled = CanContinue();
        }

        public override void OnActivated()
        {
            base.OnActivated();

            if (Session.Album == null)
            {
                btnBrowseSourceDirectory.Select();
            }
            else
            {
                Wizard.FocusNextButton();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            lvwFiles.ResizeColumnToFit(chFile);
        }

        private void cmsDirectory_Opening(object sender, CancelEventArgs e)
        {
            var clipboardText = Clipboard.GetText().Trim(' ', '\"');
            var directoryOnClipboardExists = Directory.Exists(clipboardText);
            mnuDirectorySeparator1.Visible = directoryOnClipboardExists;
            mnuDirectoryOpenFormClipboard.Visible = directoryOnClipboardExists;
            mnuDirectoryOpenFormClipboard.Text = directoryOnClipboardExists ? string.Format("Open '{0}'", clipboardText) : null;

            var directoryExists = Session.SourceDirectory != null && Session.SourceDirectory.Exists;
            mnuDirectoryExplore.Enabled = directoryExists;
            mnuDirectoryReload.Enabled = directoryExists;
        }

        private void mnuDirectoryExplore_Click(object sender, EventArgs e)
        {
            Process.Start(Session.SourceDirectory.FullName);
        }

        private void mnuDirectoryOpenFormClipboard_Click(object sender, EventArgs e)
        {
            var clipboardText = Clipboard.GetText().Trim(' ', '\"');
            var directory = new DirectoryInfo(clipboardText);
            
            LoadAlbumFromDirectory(directory);
        }

        private void mnuDirectoryReload_Click(object sender, EventArgs e)
        {
            LoadAlbumFromDirectory(Session.SourceDirectory);
        }

        private void btnBrowseSourceDirectory_Click(object sender, EventArgs e)
        {
            var defaultDirectory = Settings.Default.LastSourceDirectory;

            while (true)
            {
                if (string.IsNullOrEmpty(defaultDirectory))
                    break;

                if (Directory.Exists(defaultDirectory))
                    break;

                defaultDirectory = Path.GetDirectoryName(defaultDirectory);
            }

            var dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = false;
            dialog.SelectedPath = defaultDirectory;

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            var sourceRootDirectory = new DirectoryInfo(dialog.SelectedPath);
            LoadAlbumFromDirectory(sourceRootDirectory);
        }

        private void Control_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop, false))
                return;

            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length != 1)
                return;

            if (!Directory.Exists(files[0]))
                return;

            e.Effect = DragDropEffects.All;
        }

        private void Control_DragDrop(object sender, DragEventArgs e)
        {
            var directory = new DirectoryInfo(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
            LoadAlbumFromDirectory(directory);
        }

        private void LoadAlbumFromDirectory(DirectoryInfo directory)
        {
            var uiContext = TaskScheduler.FromCurrentSynchronizationContext();
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            var progressUI = Wizard.StartProgress(cancellationTokenSource);
            progressUI.Title = "Loading files...";

            Task.Factory.StartNew(
                () =>
                {
                    try
                    {
                        return new Album(directory, progressUI, cancellationToken, Session, Context);
                    }
                    finally
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                },
                cancellationToken
                ).ContinueWith(
                    task =>
                    {
                        Wizard.StopProgress(progressUI);

                        if (task.IsCanceled)
                            return;

                        if (task.IsFaulted)
                        {
                            MessageBox.Show(task.Exception.InnerException.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var album = task.Result;

                        var albumInfo = new FileNameAlbumInfoProvider().GetAlbumInfo(album, Session, Context);
                        album.ArtistName = albumInfo.ArtistName;
                        album.Name = albumInfo.Name;
                        album.ReleaseYear = albumInfo.ReleaseYear;
                        album.Type = albumInfo.Type;
                        album.Cover = albumInfo.Cover;

                        foreach (var track in album.Discs.SelectMany(disc => disc.Tracks))
                            track.Name = albumInfo.TrackNames[track];

                        Session.Album = album;
                        Session.SourceDirectory = directory;
                        Session.IgnoreDamagedFiled = false;
                        Session.IgnoreInconsistencies = false;
                        Session.IgnoreLowQualityFiles = false;
                        Session.ReEncodeFiles = false;

                        txtSourceDirectory.Text = directory.FullName;
                        PopulateFiles();
                        SetControls();
                        NextEnabled = CanContinue();

                        lvwFiles.Select();

                        Settings.Default.LastSourceDirectory = directory.FullName;
                    },
                    uiContext);
        }

        private void PopulateFiles()
        {
            lvwFiles.BeginUpdate();
            lvwFiles.Items.Clear();

            if (Session.Album != null)
            {
                foreach (var disc in Session.Album.Discs)
                {
                    foreach (var track in disc.Tracks)
                    {
                        var item = new ListViewItem();
                        item.Text = track.SourceFile.FullName.Replace(Session.Album.SourceDirectory.FullName + @"\", string.Empty);

                        if (track.MpegFileInfo.Exists)
                        {
                            if (track.IsTruncated)
                            {
                                if (item.ToolTipText.Length > 0)
                                    item.ToolTipText += Environment.NewLine;

                                item.ToolTipText += string.Format("Truncated at {0}", track.MpegFileInfo.Duration);
                                item.ForeColor = Color.DarkRed;
                            }

                            foreach (var glitch in track.Glitches)
                            {
                                if (item.ToolTipText.Length > 0)
                                    item.ToolTipText += Environment.NewLine;

                                item.ToolTipText += string.Format("Glitch at {0}", glitch.ToMinuteString());
                                item.ForeColor = Color.Red;
                            }

                            if (track.IsInvalidVbr)
                            {
                                if (item.ToolTipText.Length > 0)
                                    item.ToolTipText += Environment.NewLine;

                                item.ToolTipText += "No VBR Header";
                                item.ForeColor = Color.Red;
                            }

                            item.ImageIndex = SystemImageListHelper.Instance.IconIndex(track.SourceFile.FullName);
                            item.UseItemStyleForSubItems = false;
                            item.Tag = track;

                            item.SubItems.Add(MpegHelper.GetAudioVersionString(track.MpegFileInfo));
                            if (!track.IsAudioVersionValid)
                                item.SubItems[item.SubItems.Count - 1].ForeColor = Color.Red;

                            item.SubItems.Add(MpegHelper.GetLayerString(track.MpegFileInfo));
                            if (!track.IsLayerValid)
                                item.SubItems[item.SubItems.Count - 1].ForeColor = Color.Red;

                            item.SubItems.Add(MpegHelper.GetBitrateString(track.MpegFileInfo));
                            if (!track.IsBitrateValid)
                                item.SubItems[item.SubItems.Count - 1].ForeColor = Color.Red;

                            item.SubItems.Add(MpegHelper.GetSampleRateString(track.MpegFileInfo));
                            if (!track.IsSampleRateValid)
                                item.SubItems[item.SubItems.Count - 1].ForeColor = Color.Red;

                            item.SubItems.Add(MpegHelper.GetChannelModeString(track.MpegFileInfo));
                            if (!track.IsChannelModeValid)
                                item.SubItems[item.SubItems.Count - 1].ForeColor = Color.Red;

                            item.SubItems.Add(string.Join(", ", track.Tags.Select(tag => tag.ToString()).Distinct()));
                        }
                        else
                        {
                            for (var i = 0; i < lvwFiles.Columns.Count - 1; i++)
                                item.SubItems.Add(string.Empty);
                        }

                        lvwFiles.Items.Add(item);
                    }
                }

                // Highlight inconsistent items
                var columnHeadersToHighlightDefferences = new[] {chVersion, chLayer, chBitrate, chSampleRate, chMode};

                foreach (var columnHeader in columnHeadersToHighlightDefferences)
                {
                    var mostCommonText = lvwFiles.Items.Cast<ListViewItem>().MostCommon(item => item.SubItems[columnHeader.Index].Text);

                    foreach (ListViewItem item in lvwFiles.Items)
                        if (item.SubItems[columnHeader.Index].Text != mostCommonText)
                            item.SubItems[columnHeader.Index].BackColor = Color.Yellow;
                }
            }

            lvwFiles.AutoResizeColumn(chTags.Index, ColumnHeaderAutoResizeStyle.ColumnContent);
            chTags.Width = Math.Max(chTags.Width, 50);
            OnResize(EventArgs.Empty);

            lvwFiles.EndUpdate();
        }

        private void SetControls()
        {
            chkIgnoreDamagedFiles.Enabled = Session.Album != null && Session.Album.AreFilesDamaged;
            chkIgnoreDamagedFiles.Checked = Session.IgnoreDamagedFiled;
            chkIgnoreLowQualityFiles.Enabled = Session.Album != null && Session.Album.AreFilesOfLowQuality;
            chkIgnoreLowQualityFiles.Checked = Session.IgnoreLowQualityFiles;
            chkIgnoreInconsistentFiles.Enabled = Session.Album != null && Session.Album.AreFilesInconsistent;
            chkIgnoreInconsistentFiles.Checked = Session.IgnoreInconsistencies;
            chkReEncodeFiles.Enabled = Session.Album != null && (Session.Album.AreFilesDamaged || Session.Album.AreFilesOfLowQuality || Session.Album.AreFilesInconsistent);
            chkReEncodeFiles.Checked = Session.ReEncodeFiles;
        }

        private bool CanContinue()
        {
            if (Session.Album == null)
                return false;

            if (Session.Album.Discs.Count == 0)
                return false;

            if (Session.Album.AreFilesDamaged && !Session.IgnoreDamagedFiled)
                return false;

            if (Session.Album.AreFilesOfLowQuality && !Session.IgnoreLowQualityFiles)
                return false;

            if (Session.Album.AreFilesInconsistent && !Session.IgnoreInconsistencies)
                return false;

            return true;
        }

        private void cmsFile_Opening(object sender, CancelEventArgs e)
        {
            var isAnyFileSelected = lvwFiles.SelectedItems.Count != 0;

            mnuFilePlay.Enabled = isAnyFileSelected;
        }

        private void mnuFilePlay_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvwFiles.SelectedItems)
                Process.Start(((Track)item.Tag).SourceFile.FullName);
        }

        private void chkIgnoreDamagedFiles_CheckedChanged(object sender, EventArgs e)
        {
            Session.IgnoreDamagedFiled = chkIgnoreDamagedFiles.Checked;
            NextEnabled = CanContinue();
        }

        private void chkIgnoreLowQualityFiles_CheckedChanged(object sender, EventArgs e)
        {
            Session.IgnoreLowQualityFiles = chkIgnoreLowQualityFiles.Checked;
            NextEnabled = CanContinue();
        }

        private void chkIgnoreInconsistentFiles_CheckedChanged(object sender, EventArgs e)
        {
            Session.IgnoreInconsistencies = chkIgnoreInconsistentFiles.Checked;
            NextEnabled = CanContinue();
        }

        private void chkReEncodeFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReEncodeFiles.Checked)
            {
                var encoder = Context.GetEncoder();

                if (!encoder.IsPresent())
                {
                    MessageBox.Show(string.Format("{1} not found.{0}{0}{2}", Environment.NewLine, encoder.Name, encoder.SetupInstructions), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkReEncodeFiles.Checked = false;
                    return;
                }
            }

            Session.ReEncodeFiles = chkReEncodeFiles.Checked;
            NextEnabled = CanContinue();
        }
    }
}
