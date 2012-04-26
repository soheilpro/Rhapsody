using System;
using System.Diagnostics;

namespace Rhapsody.UI.Steps
{
    internal partial class FinishStep : Step
    {
        private SystemImageList _systemImageList = new SystemImageList();

        public FinishStep()
        {
            InitializeComponent();
        }

        public override void OnActivating()
        {
            base.OnActivating();

            btnPlay.Image = _systemImageList.Icon(_systemImageList.IconIndex(".m3u")).ToBitmap();
            btnPlay.Enabled = Session.Album.PlaylistFile != null && Session.Album.PlaylistFile.Exists;
        }

        public override void OnActivated()
        {
            base.OnActivated();

            Wizard.FocusNextButton();
        }

        private void btnExplore_Click(object sender, EventArgs e)
        {
            Process.Start(Session.Album.AlbumDirectory.FullName);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Process.Start(Session.Album.PlaylistFile.FullName);
        }
    }
}
