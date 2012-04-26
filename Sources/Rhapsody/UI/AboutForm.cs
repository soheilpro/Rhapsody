using System;
using System.Diagnostics;
using System.Windows.Forms;
using Rhapsody.Utilities;

namespace Rhapsody.UI
{
    internal partial class AboutForm : FormBase
    {
        public AboutForm()
        {
            InitializeComponent();

            lblTitle.Text = lblTitle.Text.Replace("{version}", VersionHelper.GetAppVersion());
            chkCredits_CheckedChanged(chkCredits, EventArgs.Empty);
        }

        private void chkCredits_CheckedChanged(object sender, EventArgs e)
        {
            pnlAbout.Visible = !chkCredits.Checked;
            pnlCredits.Visible = chkCredits.Checked;
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(((LinkLabel)sender).Text);
        }
    }
}
