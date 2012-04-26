using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rhapsody.Core;
using Rhapsody.Core.AlbumInfoProviders;
using Rhapsody.Properties;
using Rhapsody.UI.InfoProviders;
using Rhapsody.Utilities;

namespace Rhapsody.UI.Steps
{
    internal partial class AlbumStep : Step
    {
        private string[] _albumTypes = new[] {"", "EP", "Single", "Live", "OST", "Demo", "Compilation", "Fan Club", "Split", "Bootleg", "B-Sides"};
        private string[] _appendTexts = new[] {"Bonus", "Live", "Instrumental", "Demo", "Single", "Edited", "Re-recorded", "Previously Unreleased"};
        private IInfoProvider[] _infoProviders = new IInfoProvider[] {new LastFmInfoProvider(), new MusicBrainzInfoProvider(), new WikipediaInfoProvider(), new GoogleInfoProvider()};
        private IAlbumInfoProvider[] _albumInfoProviders = new IAlbumInfoProvider[] {new Id3V2TagAlbumInfoProvider(), new FileNameAlbumInfoProvider()};

        public AlbumStep()
        {
            InitializeComponent();
        }

        public override void InitializeStep()
        {
            base.InitializeStep();

            SysImageListHelper.SetListViewImageList(lvwTracks, SystemImageListHelper.Instance, false);

            foreach (var albumInfoProvider in _albumInfoProviders)
            {
                var infoProviderItem = new ToolStripMenuItem(string.Format("By {0}", albumInfoProvider.Name), albumInfoProvider.Icon, mnuAutoSet_Click);
                infoProviderItem.Tag = albumInfoProvider;

                cmsAutoSet.Items.Add(infoProviderItem);
            }

            foreach (var infoProvider in _infoProviders)
            {
                var infoProviderItem = new ToolStripMenuItem(string.Format("View at {0}", infoProvider.Name), infoProvider.Icon, mnuInfoProvider_Click);
                infoProviderItem.Tag = infoProvider;

                cmsText.Items.Add(infoProviderItem);
            }

            for (var i = 1970; i <= DateTime.Now.Year + 1; i++)
                cboReleaseYear.Items.Insert(0, i.ToString(CultureInfo.InvariantCulture));

            foreach (var albumType in _albumTypes)
                cboType.Items.Add(albumType);

            foreach (var appendText in _appendTexts)
                mnuTrackAppend.DropDownItems.Add(new ToolStripMenuItem(appendText, null, mnuTrackAppendText_Click));

            foreach (var albumCoverProvider in Context.GetAlbumCoverProviders())
            {
                var albumCoverProviderItem = new ToolStripMenuItem(albumCoverProvider.Name, albumCoverProvider.Icon, mnuLoadCoverFromProvider_Click);
                albumCoverProviderItem.Tag = albumCoverProvider;

                cmsLoadCover.Items.Insert(0, albumCoverProviderItem);
            }
        }

        public override void OnActivating()
        {
            base.OnActivating();

            PopulateArtistNameAutoCompleteItems();

            txtArtistName.Text = Session.Album.ArtistName;
            txtAlbumName.Text = Session.Album.Name;
            cboReleaseYear.Text = Session.Album.ReleaseYear;
            cboType.Text = Session.Album.Type;
            PopulateTracks();
            PopulateMoveToDiscs();
            SetCover();
            lblTotalRunningTime.Text = Session.Album.Duration.ToMinuteString();
            txtDestinationDirectory.Text = Session.DestinationDirectory != null ? Session.DestinationDirectory.FullName : null;
            NextEnabled = CanContinue();

            AttachEventHandlers();
        }

        public override void OnActivated()
        {
            base.OnActivated();

            txtArtistName.Select();
        }

        public override void OnDeactivated()
        {
            base.OnDeactivated();

            DetachEventHandlers();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            lvwTracks.ResizeColumnToFit(chName);
        }

        private void PopulateArtistNameAutoCompleteItems()
        {
            txtArtistName.AutoCompleteCustomSource.Clear();

            foreach (var artistName in Settings.Default.RecentArtistNames)
                txtArtistName.AutoCompleteCustomSource.Add(artistName);
        }

        private void AttachEventHandlers()
        {
            Session.Album.ArtistNameChanged += Album_ArtistNameChanged;
            Session.Album.YearChanged += Album_YearChanged;
            Session.Album.NameChanged += Album_NameChanged;
            Session.Album.TypeChanged += Album_TypeChanged;
            Session.Album.CoverChanged += Album_CoverChanged;

            foreach (var disc in Session.Album.Discs)
            {
                disc.NameChanged += Disc_NameChanged;

                foreach (var track in disc.Tracks)
                    track.NameChanged += Track_NameChanged;
            }
        }

        private void DetachEventHandlers()
        {
            Session.Album.ArtistNameChanged -= Album_ArtistNameChanged;
            Session.Album.YearChanged -= Album_YearChanged;
            Session.Album.NameChanged -= Album_NameChanged;
            Session.Album.TypeChanged -= Album_TypeChanged;
            Session.Album.CoverChanged -= Album_CoverChanged;

            foreach (var disc in Session.Album.Discs)
            {
                disc.NameChanged -= Disc_NameChanged;

                foreach (var track in disc.Tracks)
                    track.NameChanged -= Track_NameChanged;
            }
        }

        private void PopulateTracks(ICollection<Track> selectedTracks = null)
        {
            lvwTracks.BeginUpdate();
            lvwTracks.Items.Clear();
            lvwTracks.Groups.Clear();

            foreach (var disc in Session.Album.Discs)
            {
                var discGroup = new ListViewGroup();
                discGroup.Header = disc.FullName;
                discGroup.Tag = disc;
                lvwTracks.Groups.Add(discGroup);

                foreach (var track in disc.Tracks)
                {
                    var item = new ListViewItem();
                    item.Text = track.Name;
                    item.SubItems.Add(track.Index.ToString(CultureInfo.InvariantCulture));
                    item.SubItems.Add(track.MpegFileInfo.Duration.ToMinuteString());
                    item.SubItems.Add(track.SourceFile.Name);
                    item.ImageIndex = SystemImageListHelper.Instance.IconIndex(track.SourceFile.FullName);
                    item.Group = discGroup;
                    item.Tag = track;
                    item.Selected = selectedTracks != null && selectedTracks.Contains(track);
                    lvwTracks.Items.Add(item);
                }
            }

            if (lvwTracks.SelectedItems.Count != 0)
                lvwTracks.EnsureVisible(lvwTracks.SelectedItems[0].Index);

            lvwTracks.EndUpdate();
        }

        private void PopulateMoveToDiscs()
        {
            while (mnuTrackMoveToDisc.DropDownItems.Count > 2)
                mnuTrackMoveToDisc.DropDownItems.RemoveAt(0);

            foreach (var disc in Session.Album.Discs)
            {
                var mnuMoveToDiscDisc = new ToolStripMenuItem();
                mnuMoveToDiscDisc.Text = disc.FullName;
                mnuMoveToDiscDisc.Tag = disc;
                mnuMoveToDiscDisc.Click += mnuTrackMoveToDiscDisc_Click;
                mnuTrackMoveToDisc.DropDownItems.Insert(mnuTrackMoveToDisc.DropDownItems.Count - 2, mnuMoveToDiscDisc);
            }
        }

        private void SetCover()
        {
            var cover = Session.Album.Cover;
            picCover.Image = cover != null ? cover.ToImage() : null;
            lblCoverInfo.Text = cover != null ? string.Format("{0}x{1} ({2})", picCover.Image.Width, picCover.Image.Height, Picture.GetExtensionByMimeType(cover.MimeType)) : null;
            btnClearCover.Enabled = cover != null;
        }

        private void Album_ArtistNameChanged(object sender, EventArgs e)
        {
            txtArtistName.Text = Session.Album.ArtistName;
        }

        private void Album_YearChanged(object sender, EventArgs e)
        {
            cboReleaseYear.Text = Session.Album.ReleaseYear;
        }

        private void Album_NameChanged(object sender, EventArgs e)
        {
            txtAlbumName.Text = Session.Album.Name;
        }

        private void Album_TypeChanged(object sender, EventArgs e)
        {
            cboType.Text = Session.Album.Type;
        }

        private void Album_CoverChanged(object sender, EventArgs e)
        {
            SetCover();
        }

        private void Disc_NameChanged(object sender, EventArgs e)
        {
            var disc = (Disc)sender;

            foreach (ListViewGroup listGroup in lvwTracks.Groups)
                if (listGroup.Tag == disc)
                    listGroup.Header = disc.FullName;

            // ListView Bug Fix
            SysImageListHelper.SetListViewImageList(lvwTracks, SystemImageListHelper.Instance, false);
        }

        private void Track_NameChanged(object sender, EventArgs e)
        {
            var track = (Track)sender;

            foreach (ListViewItem listItem in lvwTracks.Items)
                if (listItem.Tag == track)
                    listItem.Text = track.Name;
        }

        private void btnAutoSet_Click(object sender, EventArgs e)
        {
            cmsAutoSet.Show(btnAutoSet, new Point(btnAutoSet.Width, btnAutoSet.Height), ToolStripDropDownDirection.BelowLeft);
        }

        private void mnuAutoSet_Click(object sender, EventArgs e)
        {
            var albumInfoProvider = (IAlbumInfoProvider)((ToolStripMenuItem)sender).Tag;
            var albumInfo = albumInfoProvider.GetAlbumInfo(Session.Album, Session, Context);

            if (albumInfo == null)
            {
                MessageBox.Show("Failed.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Session.Album.ArtistName = albumInfo.ArtistName;
            Session.Album.OnArtistNameChanged();

            Session.Album.Name = albumInfo.Name;
            Session.Album.OnNameChanged();

            Session.Album.ReleaseYear = albumInfo.ReleaseYear;
            Session.Album.OnYearChanged();

            Session.Album.Type = albumInfo.Type;
            Session.Album.OnTypeChanged();

            Session.Album.Cover = albumInfo.Cover;
            Session.Album.OnCoverChanged();

            foreach (var disc in Session.Album.Discs)
            {
                disc.Name = albumInfo.DiscNames[disc];
                disc.OnNameChanged();
            }

            foreach (var item in albumInfo.TrackNames)
            {
                item.Key.Name = item.Value;
                item.Key.OnNameChanged();
            }

            NextEnabled = CanContinue();

            MessageBox.Show("OK.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtArtistName_TextChanged(object sender, EventArgs e)
        {
            Session.Album.ArtistName = StringHelper.Trim(txtArtistName.Text);
            NextEnabled = CanContinue();
        }

        private void txtArtistName_Leave(object sender, EventArgs e)
        {
            txtArtistName.Text = Session.Album.ArtistName;
        }

        private void txtAlbumName_TextChanged(object sender, EventArgs e)
        {
            Session.Album.Name = StringHelper.Trim(txtAlbumName.Text);
            NextEnabled = CanContinue();
        }

        private void txtAlbumName_Leave(object sender, EventArgs e)
        {
            txtAlbumName.Text = Session.Album.Name;
        }

        private void cboReleaseYear_TextChanged(object sender, EventArgs e)
        {
            Session.Album.ReleaseYear = StringHelper.Trim(cboReleaseYear.Text);
            NextEnabled = CanContinue();
        }

        private void cboType_TextChanged(object sender, EventArgs e)
        {
            Session.Album.Type = cboType.Text;
        }

        private void cmsText_Opening(object sender, CancelEventArgs e)
        {
            var textBox = (TextBox)cmsText.SourceControl;
            textBox.Select();

            mnuTextUndo.Enabled = textBox.CanUndo;
            mnuTextCut.Enabled = textBox.SelectionLength > 0;
            mnuTextCopy.Enabled = textBox.SelectionLength > 0;
            mnuTextDelete.Enabled = textBox.SelectionLength > 0;
            mnuTextSelectAll.Enabled = textBox.Text.Length > 0;
            mnuTextSetTo.Enabled = textBox.SelectionLength > 0;
            mnuTextMakeProperCase.Enabled = textBox.Text.Length > 0;
            mnuTextRemoveDiacritics.Enabled = textBox.Text.Length > 0;

            foreach (var item in cmsText.Items.Cast<ToolStripItem>().Where(item => item.Tag is IInfoProvider))
                item.Enabled = textBox.Text.Length > 0;
        }

        private void mnuTextUndo_Click(object sender, EventArgs e)
        {
            var textBox = (TextBox)cmsText.SourceControl;
            textBox.Undo();
        }

        private void mnuTextCut_Click(object sender, EventArgs e)
        {
            var textBox = (TextBox)cmsText.SourceControl;
            textBox.Cut();
        }

        private void mnuTextCopy_Click(object sender, EventArgs e)
        {
            var textBox = (TextBox)cmsText.SourceControl;
            textBox.Copy();
        }

        private void mnuTextPaste_Click(object sender, EventArgs e)
        {
            var textBox = (TextBox)cmsText.SourceControl;
            textBox.Paste();
        }

        private void mnuTextDelete_Click(object sender, EventArgs e)
        {
            var textBox = (TextBox)cmsText.SourceControl;
            textBox.SelectedText = string.Empty;
        }

        private void mnuTextSelectAll_Click(object sender, EventArgs e)
        {
            var textBox = (TextBox)cmsText.SourceControl;
            textBox.SelectAll();
        }

        private void mnuTextMakeProperCase_Click(object sender, EventArgs e)
        {
            var textBox = (TextBox)(cmsText.SourceControl ?? ActiveControl);
            textBox.Text = StringHelper.MakeProperCase(textBox.Text);
        }

        private void mnuTextRemoveDiacritics_Click(object sender, EventArgs e)
        {
            var textBox = (TextBox)(cmsText.SourceControl ?? ActiveControl);
            textBox.Text = StringHelper.RemoveDiacritics(textBox.Text);
        }

        private void mnuTextSetToArtist_Click(object sender, EventArgs e)
        {
            var textBox = (TextBox)(cmsText.SourceControl ?? ActiveControl);
            txtArtistName.Text = StringHelper.Trim(textBox.SelectedText, true);
            textBox.Text = StringHelper.Trim(textBox.Text.Substring(0, textBox.SelectionStart), true) + StringHelper.Trim(textBox.Text.Substring(textBox.SelectionStart + textBox.SelectionLength), true);
        }

        private void mnuTextSetToAlbum_Click(object sender, EventArgs e)
        {
            var textBox = (TextBox)(cmsText.SourceControl ?? ActiveControl);
            txtAlbumName.Text = StringHelper.Trim(textBox.SelectedText, true);
            textBox.Text = StringHelper.Trim(textBox.Text.Substring(0, textBox.SelectionStart), true) + StringHelper.Trim(textBox.Text.Substring(textBox.SelectionStart + textBox.SelectionLength), true);
        }

        private void mnuTextSetToYear_Click(object sender, EventArgs e)
        {
            var textBox = (TextBox)(cmsText.SourceControl ?? ActiveControl);
            cboReleaseYear.Text = StringHelper.Trim(textBox.SelectedText, true);
            textBox.Text = StringHelper.Trim(textBox.Text.Substring(0, textBox.SelectionStart), true) + StringHelper.Trim(textBox.Text.Substring(textBox.SelectionStart + textBox.SelectionLength), true);
        }

        private void mnuInfoProvider_Click(object sender, EventArgs e)
        {
            var infoProvider = (IInfoProvider)((ToolStripMenuItem)sender).Tag;
            var textBox = (TextBox)(cmsText.SourceControl ?? ActiveControl);
            var text = textBox.Text.Trim();

            if (textBox == txtArtistName)
            {
                infoProvider.ShowArtistInfo(text);
            }
            else if (textBox == txtAlbumName)
            {
                infoProvider.ShowAlbumInfo(text);
            }
        }

        private void lvwTracks_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == null)
                return;

            var newName = StringHelper.Trim(e.Label);

            var track = (Track)lvwTracks.Items[e.Item].Tag;
            track.Name = newName;

            NextEnabled = CanContinue();

            // Since e.Label is read only, this trick is needed to reflect the new track name
            new System.Threading.Timer(state => Invoke((MethodInvoker)(() => lvwTracks.Items[e.Item].Text = track.Name)), null, 10, Timeout.Infinite);
        }

        private void cmsTrack_Opening(object sender, CancelEventArgs e)
        {
            var isAnyTrackSelected = lvwTracks.SelectedItems.Count != 0;
            var isAnyFirstTrackSelected = false;
            var isAnyLastTrackSelected = false;

            foreach (ListViewItem item in lvwTracks.SelectedItems)
            {
                if (item.Group.Items.IndexOf(item) == 0)
                    isAnyFirstTrackSelected = true;

                if (item.Group.Items.IndexOf(item) == item.Group.Items.Count - 1)
                    isAnyLastTrackSelected = true;
            }

            mnuTrackPlay.Enabled = isAnyTrackSelected;
            mnuTrackRename.Enabled = isAnyTrackSelected;
            mnuTrackMakeProperCase.Enabled = isAnyTrackSelected;
            mnuTrackRemoveDiacritics.Enabled = isAnyTrackSelected;
            mnuTrackAppend.Enabled = isAnyTrackSelected;
            mnuTrackRemove.Enabled = isAnyTrackSelected;
            mnuTrackMoveUp.Enabled = isAnyTrackSelected && !isAnyFirstTrackSelected;
            mnuTrackMoveDown.Enabled = isAnyTrackSelected && !isAnyLastTrackSelected;
            mnuTrackMoveToDisc.Enabled = isAnyTrackSelected;
        }

        private void mnuTrackPlay_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvwTracks.SelectedItems)
                Process.Start(((Track)item.Tag).SourceFile.FullName);
        }

        private void mnuTrackRename_Click(object sender, EventArgs e)
        {
            cmsTrack_Opening(cmsTrack, new CancelEventArgs());

            if (!mnuTrackRename.Enabled)
                return;

            lvwTracks.SelectedItems[0].BeginEdit();
        }

        private void mnuTrackMakeProperCase_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvwTracks.SelectedItems)
            {
                var track = (Track)item.Tag;
                track.Name = StringHelper.MakeProperCase(track.Name);
                item.Text = track.Name;
            }
        }

        private void mnuTrackRemoveDiacritics_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvwTracks.SelectedItems)
            {
                var track = (Track)item.Tag;
                track.Name = StringHelper.RemoveDiacritics(track.Name);
                item.Text = track.Name;
            }
        }

        private void mnuTrackAppendText_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvwTracks.SelectedItems)
            {
                var track = (Track)item.Tag;
                track.Name = string.Format("{0} ({1})", Regex.Replace(track.Name, @" \(.*\)$", string.Empty), ((ToolStripMenuItem)sender).Text);
                item.Text = track.Name;
            }
        }

        private void mnuTrackRemove_Click(object sender, EventArgs e)
        {
            lvwTracks.BeginUpdate();

            while (lvwTracks.SelectedItems.Count > 0)
            {
                var selectedItem = lvwTracks.SelectedItems[0];
                ((Track)selectedItem.Tag).Remove();
                lvwTracks.Items.Remove(selectedItem);
            }

            lvwTracks.EndUpdate();

            lblTotalRunningTime.Text = Session.Album.Duration.ToMinuteString();

            NextEnabled = CanContinue();
        }

        private void mnuTrackMoveUp_Click(object sender, EventArgs e)
        {
            cmsTrack_Opening(cmsTrack, new CancelEventArgs());

            if (!mnuTrackMoveUp.Enabled)
                return;

            var selectedTracks = new List<Track>();

            for (var i = 0; i < lvwTracks.SelectedIndices.Count; i++)
            {
                var track = (Track)lvwTracks.Items[lvwTracks.SelectedIndices[i]].Tag;
                var index = track.Index;
                track.Disc.Tracks.Remove(track);
                track.Disc.Tracks.Insert(index - 2, track);

                selectedTracks.Add(track);
            }

            var focusedItemIndex = lvwTracks.FocusedItem != null ? lvwTracks.FocusedItem.Index : -1;

            PopulateTracks(selectedTracks);

            if (focusedItemIndex != -1)
                lvwTracks.Items[focusedItemIndex - 1].Focused = true;
        }

        private void mnuTrackMoveDown_Click(object sender, EventArgs e)
        {
            cmsTrack_Opening(cmsTrack, new CancelEventArgs());

            if (!mnuTrackMoveDown.Enabled)
                return;

            var selectedTracks = new List<Track>();

            for (var i = lvwTracks.SelectedIndices.Count - 1; i >= 0; i--)
            {
                var track = (Track)lvwTracks.Items[lvwTracks.SelectedIndices[i]].Tag;
                var index = track.Index;
                track.Disc.Tracks.Remove(track);
                track.Disc.Tracks.Insert(index, track);

                selectedTracks.Add(track);
            }

            var focusedItemIndex = lvwTracks.FocusedItem != null ? lvwTracks.FocusedItem.Index : -1;

            PopulateTracks(selectedTracks);

            if (focusedItemIndex != -1)
                lvwTracks.Items[focusedItemIndex + 1].Focused = true;
        }

        private void mnuTrackMoveToDiscDisc_Click(object sender, EventArgs e)
        {
            var destinationDisc = (Disc)((ToolStripMenuItem)sender).Tag;
            var selectedTracks = new List<Track>();

            foreach (ListViewItem item in lvwTracks.SelectedItems)
            {
                var track = (Track)item.Tag;
                selectedTracks.Add(track);

                if (track.Disc == destinationDisc)
                    continue;

                track.Disc.Tracks.Remove(track);
                destinationDisc.Tracks.Add(track);
                track.Disc = destinationDisc;
            }

            for (var i = 0; i < Session.Album.Discs.Count; i++)
            {
                var disc = Session.Album.Discs[i];

                if (disc.Tracks.Count == 0)
                {
                    Session.Album.Discs.Remove(disc);
                    i--;
                }
            }

            PopulateTracks(selectedTracks);
            PopulateMoveToDiscs();
        }

        private void mnuTrackMoveToDiscNewDisc_Click(object sender, EventArgs e)
        {
            var newDisc = new Disc(Session.Album, Session, Context);
            newDisc.NameChanged += Disc_NameChanged;

            Session.Album.Discs.Add(newDisc);

            var selectedTracks = new List<Track>();

            foreach (ListViewItem item in lvwTracks.SelectedItems)
            {
                var track = (Track)item.Tag;
                selectedTracks.Add(track);

                track.Disc.Tracks.Remove(track);
                newDisc.Tracks.Add(track);
                track.Disc = newDisc;
            }

            for (var i = 0; i < Session.Album.Discs.Count; i++)
            {
                var disc = Session.Album.Discs[i];

                if (disc.Tracks.Count != 0)
                    continue;

                Session.Album.Discs.Remove(disc);
                i--;
            }

            PopulateTracks(selectedTracks);
            PopulateMoveToDiscs();
        }

        private void btnDiscs_Click(object sender, EventArgs e)
        {
            if (new DiscsForm(Session.Album.Discs).ShowDialog() != DialogResult.OK)
                return;

            PopulateTracks();
            PopulateMoveToDiscs();
        }

        private void picCover_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop, false))
                return;

            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length != 1)
                return;

            if (!File.Exists(files[0]))
                return;

            e.Effect = DragDropEffects.All;
        }

        private void picCover_DragDrop(object sender, DragEventArgs e)
        {
            var file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            var albumCover = Picture.Load(file);

            Session.Album.Cover = albumCover;
            SetCover();
        }

        private void cmsCover_Opening(object sender, CancelEventArgs e)
        {
            mnuCoverViewFullSize.Enabled = Session.Album.Cover != null;
            mnuCoverSaveToDisc.Enabled = Session.Album.Cover != null;
        }

        private void mnuCoverViewFullSize_Click(object sender, EventArgs e)
        {
            new PictureForm().ShowForm(Session.Album.Cover.ToImage());
        }

        private void mnuCoverSaveToDisc_Click(object sender, EventArgs e)
        {
            var filename = string.Format("Cover{0}", Picture.GetExtensionByMimeType(Session.Album.Cover.MimeType));

            var dialog = new SaveFileDialog();
            dialog.FileName = filename;
            dialog.Filter = "All Files (*.*)|*.*";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            File.WriteAllBytes(dialog.FileName, Session.Album.Cover.Data);
        }

        private void btnLoadCover_Click(object sender, EventArgs e)
        {
            cmsLoadCover.Show(btnLoadCover, 0, btnLoadCover.Height);
        }

        private void mnuLoadCoverFromProvider_Click(object sender, EventArgs e)
        {
            var uiContext = TaskScheduler.FromCurrentSynchronizationContext();
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            var progressUI = Wizard.StartProgress(cancellationTokenSource);
            progressUI.Title = "Loading album cover...";
            progressUI.Begin(0);

            Task.Factory.StartNew(
                () =>
                {
                    var albumCoverProvider = (IAlbumCoverProvider)((ToolStripMenuItem)sender).Tag;
                    progressUI.Advance(albumCoverProvider.Name);

                    try
                    {
                        return albumCoverProvider.GetCover(Session.Album.ArtistName, Session.Album.Name, Session, Context);
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

                        var albumCover = task.Result;

                        if (albumCover == null)
                        {
                            MessageBox.Show("Not found.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        Session.Album.Cover = albumCover;
                        SetCover();
                    },
                    uiContext);
        }

        private void mnuLoadCoverOpenUrl_Click(object sender, EventArgs e)
        {
            var dialog = new OpenUrlForm();

            if (dialog.ShowForm() != DialogResult.OK)
                return;

            var address = dialog.Address;

            var uiContext = TaskScheduler.FromCurrentSynchronizationContext();
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            var progressUI = Wizard.StartProgress(cancellationTokenSource);
            progressUI.Title = "Loading image...";
            progressUI.Begin(0);

            Task.Factory.StartNew(
                () =>
                {
                    try
                    {
                        progressUI.Advance(address.Authority);

                        using (var webClient = new WebClient())
                        {
                            var data = webClient.DownloadData(address);
                            var mimeType = webClient.ResponseHeaders["Content-Type"];

                            return new Picture(data, mimeType);
                        }
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

                        var albumCover = task.Result;
                
                        Session.Album.Cover = albumCover;
                        SetCover();
                    },
                    uiContext);
        }

        private void mnuLoadCoverBrowse_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.png; *.jpg; *.gif)|*.png;*.jpg;*.jpeg;*.gif|All Files (*.*)|*.*";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var albumCover = Picture.Load(dialog.FileName);

            Session.Album.Cover = albumCover;
            SetCover();
        }

        private void btnClearCover_Click(object sender, EventArgs e)
        {
            Session.Album.Cover = null;
            SetCover();
        }

        private void cmsDirectory_Opening(object sender, CancelEventArgs e)
        {
            var directoryExists = Session.DestinationDirectory != null && Session.DestinationDirectory.Exists;
            mnuDirectoryExplore.Enabled = directoryExists;
        }

        private void mnuDirectoryExplore_Click(object sender, EventArgs e)
        {
            Process.Start(Session.DestinationDirectory.FullName);
        }

        private void btnBrowseDestinationDirectory_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            dialog.SelectedPath = Session.DestinationDirectory != null ? Session.DestinationDirectory.FullName : null;

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            Settings.Default.LastDestinationDirectory = dialog.SelectedPath;

            Session.DestinationDirectory = new DirectoryInfo(dialog.SelectedPath);
            txtDestinationDirectory.Text = dialog.SelectedPath;
            NextEnabled = CanContinue();
        }

        private bool CanContinue()
        {
            if (!Session.Album.Validate())
                return false;

            if (Session.DestinationDirectory == null)
                return false;

            return true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F8:
                    btnAutoSet.PerformClick();
                    break;

                case Keys.F3:
                    if (ActiveControl == txtArtistName)
                    {
                        if (!e.Shift)
                        {
                            txtAlbumName.Select();
                        }
                        else
                        {
                            lvwTracks.Select();
                            lvwTracks.SelectedItems.Clear();
                            lvwTracks.Items[lvwTracks.Items.Count - 1].Selected = true;
                            lvwTracks.Items[lvwTracks.Items.Count - 1].Focused = true;
                            lvwTracks.Items[lvwTracks.Items.Count - 1].EnsureVisible();
                        }
                    }
                    else if (ActiveControl == txtAlbumName)
                    {
                        if (!e.Shift)
                            cboReleaseYear.Select();
                        else
                            txtArtistName.Select();
                    }
                    else if (ActiveControl == cboReleaseYear)
                    {
                        if (!e.Shift)
                            cboType.Select();
                        else
                            txtAlbumName.Select();
                    }
                    else if (ActiveControl == cboType)
                    {
                        if (!e.Shift)
                        {
                            lvwTracks.Select();
                            lvwTracks.SelectedItems.Clear();
                            lvwTracks.Items[0].Selected = true;
                            lvwTracks.Items[0].Focused = true;
                            lvwTracks.Items[0].EnsureVisible();
                        }
                        else
                        {
                            cboReleaseYear.Select();
                        }
                    }
                    else if (ActiveControl == lvwTracks)
                    {
                        if (!e.Shift)
                        {
                            var indexToSelect = (lvwTracks.SelectedItems.Count > 0 ? lvwTracks.SelectedItems[0].Index + 1 : 0);

                            if (indexToSelect < lvwTracks.Items.Count)
                            {
                                lvwTracks.SelectedItems.Clear();
                                lvwTracks.Items[indexToSelect].Selected = true;
                                lvwTracks.Items[indexToSelect].Focused = true;
                                lvwTracks.Items[indexToSelect].EnsureVisible();
                            }
                            else
                            {
                                txtArtistName.Select();
                            }
                        }
                        else
                        {
                            var indexToSelect = (lvwTracks.SelectedItems.Count > 0 ? lvwTracks.SelectedItems[0].Index - 1 : lvwTracks.Items.Count - 1);

                            if (indexToSelect >= 0)
                            {
                                lvwTracks.SelectedItems.Clear();
                                lvwTracks.Items[indexToSelect].Selected = true;
                                lvwTracks.Items[indexToSelect].Focused = true;
                                lvwTracks.Items[indexToSelect].EnsureVisible();
                            }
                            else
                            {
                                cboType.Select();
                            }
                        }
                    }
                    else
                    {
                        txtArtistName.Select();
                    }
                    break;
            }
        }

        public override void OnNextClick()
        {
            var uiContext = TaskScheduler.FromCurrentSynchronizationContext();
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            var progressUI = Wizard.StartProgress(cancellationTokenSource);

            Task.Factory.StartNew(
                () =>
                {
                    progressUI.Title = "Detecting issues...";

                    try
                    {
                        return Session.Album.DetectIssues(progressUI, cancellationToken).ToList();
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

                        var issues = task.Result;

                        if (issues.Count > 0)
                            if (new IssuesForm(issues).ShowDialog(this) != DialogResult.OK)
                                return;

                        progressUI = Wizard.StartProgress(cancellationTokenSource);

                        Task.Factory.StartNew(
                            () =>
                            {
                                progressUI.Title = "Saving album...";

                                Session.Album.SaveTo(Session.DestinationDirectory, progressUI, cancellationToken);
                            },
                            cancellationToken, TaskCreationOptions.None, TaskScheduler.Default
                            ).ContinueWith(
                                task2 =>
                                {
                                    Wizard.StopProgress(progressUI);

                                    if (task2.IsCanceled)
                                        return;

                                    if (task2.IsFaulted)
                                    {
                                        MessageBox.Show(task2.Exception.InnerException.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }

                                    if (!Settings.Default.RecentArtistNames.Contains(Session.Album.ArtistName))
                                        Settings.Default.RecentArtistNames.Add(Session.Album.ArtistName);

                                    Wizard.GoNext();
                                },
                                uiContext);
                    },
                    uiContext);
        }
    }
}
