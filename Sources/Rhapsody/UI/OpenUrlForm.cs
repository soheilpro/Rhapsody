using System;
using System.Windows.Forms;

namespace Rhapsody.UI
{
    internal partial class OpenUrlForm : FormBase
    {
        public Uri Address
        {
            get;
            set;
        }

        public OpenUrlForm()
        {
            InitializeComponent();
        }
        
        public DialogResult ShowForm()
        {
            Uri address;

            if (Uri.TryCreate(Clipboard.GetText(), UriKind.Absolute, out address))
            {
                txtAddress.Text = address.ToString();
                txtAddress.SelectAll();
            }
            else
            {
                txtAddress.Text = "http://";
                txtAddress.SelectionStart = txtAddress.Text.Length;
            }

            return ShowDialog();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case Win32.WM_NCHITTEST:
                    var result = (Win32.HitTest)m.Result.ToInt32();

                    if (result == Win32.HitTest.Top || result == Win32.HitTest.Bottom)
                        m.Result = new IntPtr((int)Win32.HitTest.Caption);

                    if (result == Win32.HitTest.TopLeft || result == Win32.HitTest.BottomLeft)
                        m.Result = new IntPtr((int)Win32.HitTest.Left);

                    if (result == Win32.HitTest.TopRight || result == Win32.HitTest.BottomRight)
                        m.Result = new IntPtr((int)Win32.HitTest.Right);

                    break;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;

            textBox.Text = textBox.Text.Trim();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Uri address;

            if (!Uri.TryCreate(txtAddress.Text, UriKind.Absolute, out address))
            {
                MessageBox.Show("Please enter a correct URL.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();

                return;
            }

            Address = address;

            DialogResult = DialogResult.OK;
        }
    }
}
