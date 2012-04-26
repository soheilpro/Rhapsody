using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Rhapsody.Core;
using Rhapsody.Properties;
using Rhapsody.Utilities;

namespace Rhapsody.UI
{
    internal partial class MainForm : FormBase, IWizard
    {
        private Context _context;
        private Session _session;
        private Step _currentStep;

        public MainForm()
        {
            InitializeComponent();

            base.Text += " " + VersionHelper.GetAppVersion();
            btnNext.Tag = btnNext.Text;
            btnCancel.Tag = btnCancel.Text;
        }

        public MainForm(Context context) : this()
        {
            _context = context;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CreateNewSession();

            InitializeSteps();
            ShowStep(stpFiles);
        }

        private void CreateNewSession()
        {
            _session = new Session();
            _session.DestinationDirectory = !string.IsNullOrEmpty(Settings.Default.LastDestinationDirectory) ? new DirectoryInfo(Settings.Default.LastDestinationDirectory) : null;
        }

        private void InitializeSteps()
        {
            var steps = new Step[]
            {
                stpFiles,
                stpAlbumSetup,
                stpFinish
            };

            foreach (var step in steps)
            {
                step.Wizard = this;
                step.Context = _context;
                step.Hide();
                step.Dock = DockStyle.Fill;
                step.InitializeStep();
            }
        }

        private void ShowStep(Step step)
        {
            SuspendLayout();

            if (_currentStep != null)
            {
                _currentStep.OnDeactivating();
                _currentStep.Hide();
                _currentStep.OnDeactivated();
                _currentStep.BackEnabledChanged -= Step_BackEnabledChanged;
                _currentStep.NextEnabledChanged -= Step_NextEnabledChanged;
            }

            step.Session = _session;
            step.OnActivating();
            step.Show();
            step.Select();
            step.OnActivated();
            step.BackEnabledChanged += Step_BackEnabledChanged;
            step.NextEnabledChanged += Step_NextEnabledChanged;

            btnBack.Enabled = step.BackEnabled;
            btnNext.Enabled = step.NextEnabled;
            btnNext.Text = step.NextText ?? (string)btnNext.Tag;
            btnCancel.Text = step.CancelText ?? (string)btnCancel.Tag;

            ResumeLayout();

            _currentStep = step;
        }

        public void GoBack()
        {
            if (_currentStep == stpAlbumSetup)
            {
                ShowStep(stpFiles);
            }
        }

        public void GoNext()
        {
            if (_currentStep == stpFiles)
            {
                ShowStep(stpAlbumSetup);
            }
            else if (_currentStep == stpAlbumSetup)
            {
                ShowStep(stpFinish);
            }
            else if (_currentStep == stpFinish)
            {
                CreateNewSession();
                ShowStep(stpFiles);
            }
        }

        public void FocusNextButton()
        {
            btnNext.Select();
        }

        public IProgressUI StartProgress()
        {
            var progressForm = new ProgressForm();
            progressForm.Show(this);
            Enabled = false;

            return progressForm;
        }

        public IProgressUI StartProgress(CancellationTokenSource cancellationTokenSource)
        {
            var progressForm = new ProgressForm(cancellationTokenSource);
            progressForm.Show(this);
            Enabled = false;

            return progressForm;
        }

        public void StopProgress(IProgressUI progressUI)
        {
            Enabled = true;
            ((ProgressForm)progressUI).Close();
        }

        private void Step_BackEnabledChanged(object sender, EventArgs e)
        {
            btnBack.Enabled = ((Step)sender).BackEnabled;
        }

        private void Step_NextEnabledChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = ((Step)sender).NextEnabled;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            cmsOptions.Show(btnOptions, 0, btnOptions.Height);
        }

        private void cmsOptions_Opening(object sender, CancelEventArgs e)
        {
            mnuOptionsNoPlaylist.Checked = Settings.Default.NoPlaylist;
            mnuOptionsNoSpellChecking.Checked = Settings.Default.NoSpellChecking;
            mnuOptionsMarkDamagedAlbums.Checked = Settings.Default.MarkDamagedAlbums;
        }

        private void mnuOptionsNoPlaylist_Click(object sender, EventArgs e)
        {
            Settings.Default.NoPlaylist = !Settings.Default.NoPlaylist;
            mnuOptionsNoPlaylist.Checked = Settings.Default.NoPlaylist;
        }

        private void mnuOptionsNoSpellChecking_Click(object sender, EventArgs e)
        {
            Settings.Default.NoSpellChecking = !Settings.Default.NoSpellChecking;
            mnuOptionsNoSpellChecking.Checked = Settings.Default.NoSpellChecking;
        }

        private void mnuOptionsMarkDamagedAlbums_Click(object sender, EventArgs e)
        {
            Settings.Default.MarkDamagedAlbums = !Settings.Default.MarkDamagedAlbums;
            mnuOptionsMarkDamagedAlbums.Checked = Settings.Default.MarkDamagedAlbums;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _currentStep.OnBackClick();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _currentStep.OnNextClick();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_currentStep == stpFinish)
                return;

            if (_session.Album == null)
                return;

            if (MessageBox.Show("Are you sure to exit?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                e.Cancel = true;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
