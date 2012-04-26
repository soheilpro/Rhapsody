using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Rhapsody.Core;

namespace Rhapsody.UI
{
    internal partial class DiscsForm : FormBase
    {
        private List<Disc> _discs;

        public DiscsForm(List<Disc> discs)
        {
            InitializeComponent();

            _discs = discs;

            foreach (var disc in discs)
            {
                var item = new ListViewItem();
                item.ImageIndex = 0;
                item.Text = disc.Name;
                item.SubItems.Add(disc.Index.ToString(CultureInfo.InvariantCulture));
                item.Tag = disc;

                lvwDiscs.Items.Add(item);
            }

            lvwDiscs_SelectedIndexChanged(lvwDiscs, EventArgs.Empty);
        }

        private void lvwIssues_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F2)
                if (lvwDiscs.SelectedItems.Count > 0)
                    lvwDiscs.SelectedItems[0].BeginEdit();
        }

        private void lvwDiscs_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRename.Enabled = lvwDiscs.SelectedItems.Count > 0;
            btnMoveUp.Enabled = lvwDiscs.SelectedItems.Count > 0 && lvwDiscs.SelectedItems[0].Index > 0;
            btnMoveDown.Enabled = lvwDiscs.SelectedItems.Count > 0 && lvwDiscs.SelectedItems[0].Index < lvwDiscs.Items.Count - 1;
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            lvwDiscs.SelectedItems[0].BeginEdit();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            var listItem = lvwDiscs.SelectedItems[0];
            var index = listItem.Index;

            lvwDiscs.Items.Remove(listItem);
            lvwDiscs.Items.Insert(index - 1, listItem);

            listItem.Focused = true;
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            var listItem = lvwDiscs.SelectedItems[0];
            var index = listItem.Index;

            lvwDiscs.Items.Remove(listItem);
            lvwDiscs.Items.Insert(index + 1, listItem);

            listItem.Focused = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _discs.Clear();

            foreach (ListViewItem item in lvwDiscs.Items)
            {
                var disc = (Disc)item.Tag;
                disc.Name = item.Text;

                _discs.Add(disc);
            }

            DialogResult = DialogResult.OK;
        }
    }
}
