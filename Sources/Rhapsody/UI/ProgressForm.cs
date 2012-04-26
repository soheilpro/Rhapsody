using System;
using System.Threading;
using System.Windows.Forms;

namespace Rhapsody.UI
{
    internal partial class ProgressForm : FormBase, IProgressUI
    {
        private CancellationTokenSource _cancellationTokenSource;
        private int _totalItems;
        private int _currentItemIndex;

        public string Title
        {
            get
            {
                return Text;
            }
            set
            {
                Invoke((MethodInvoker)delegate
                {
                    Text = value;
                });
            }
        }

        public ProgressForm()
        {
            InitializeComponent();
        }

        public ProgressForm(CancellationTokenSource cancellationTokenSource) : this()
        {
            _cancellationTokenSource = cancellationTokenSource;
            btnCancel.Visible = true;
            Height += btnCancel.Height + 6;
        }

        public void Begin(int totalItems)
        {
            _totalItems = totalItems;
            _currentItemIndex = 0;

            Invoke((MethodInvoker)delegate
            {
                if (totalItems > 0)
                {
                    pbProgress.Style = ProgressBarStyle.Continuous;
                    pbProgress.Maximum = totalItems;
                    pbProgress.Value = 0;
                }
                else
                {
                    pbProgress.Style = ProgressBarStyle.Marquee;
                    pbProgress.Maximum = 1;
                    pbProgress.Value = 1;
                }
            });
        }

        public void Advance(string itemName)
        {
            Invoke((MethodInvoker)delegate
            {
                lblCurrentItemName.Text = itemName;

                if (_totalItems > 0)
                    pbProgress.Value = ++_currentItemIndex;
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
