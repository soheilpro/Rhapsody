using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Rhapsody.Core;

namespace Rhapsody.UI
{
    internal partial class IssuesForm : FormBase
    {
        public IssuesForm()
        {
            InitializeComponent();
        }

        public IssuesForm(IEnumerable<Issue> issues) : this()
        {
            foreach (var issue in issues)
            {
                var listItem = new ListViewItem();
                listItem.Text = issue.Item;
                listItem.SubItems.Add(issue.ItemValue);
                listItem.SubItems.Add(issue.Description);
                listItem.UseItemStyleForSubItems = false;

                if (issue.Type == IssueType.Warning)
                {
                    listItem.ImageIndex = 0;
                }
                else if (issue.Type == IssueType.Error)
                {
                    listItem.ImageIndex = 1;
                    btnContinue.Enabled = false;
                }

                if (issue.Fixer != null)
                {
                    var listSubItem = new ListViewItem.ListViewSubItem();
                    listSubItem.Text = "Fix";
                    listSubItem.Font = new Font(listSubItem.Font, FontStyle.Underline);
                    listSubItem.ForeColor = Color.Blue;
                    listSubItem.Tag = issue.Fixer;

                    listItem.SubItems.Add(listSubItem);
                }

                lvwIssues.Items.Add(listItem);
            }

            lvwIssues.AutoResizeColumn(chIssue.Index, ColumnHeaderAutoResizeStyle.ColumnContent);
            OnResize(EventArgs.Empty);

            btnCancel.Select();
        }

        protected override sealed void OnResize(EventArgs e)
        {
            base.OnResize(e);

            lvwIssues.ResizeColumnToFit(chItemValue);
        }

        private void lvwIssues_MouseMove(object sender, MouseEventArgs e)
        {
            var hitTestInfo = lvwIssues.HitTest(e.X, e.Y);
            var isOnFix = (hitTestInfo.SubItem != null && hitTestInfo.SubItem.Tag != null);

            lvwIssues.Cursor = isOnFix ? Cursors.Hand : Cursors.Default;
        }

        private void lvwIssues_Click(object sender, EventArgs e)
        {
            var cursorPosition = lvwIssues.PointToClient(Cursor.Position);

            var hitTestInfo = lvwIssues.HitTest(cursorPosition.X, cursorPosition.Y);
            var isOnFix = (hitTestInfo.SubItem != null && hitTestInfo.SubItem.Tag != null);

            if (!isOnFix)
                return;

            var fixer = (IssueFixer)hitTestInfo.SubItem.Tag;

            if (fixer())
            {
                hitTestInfo.Item.Remove();
            }
            else
            {
                MessageBox.Show("This issue cannot be fixed automatically.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
