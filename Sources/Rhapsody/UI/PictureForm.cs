using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rhapsody.UI
{
    internal partial class PictureForm : FormBase
    {
        public PictureForm()
        {
            InitializeComponent();
            MaximumSize = new Size(SystemInformation.WorkingArea.Width - 40, SystemInformation.WorkingArea.Height - 40);
        }

        public void ShowForm(Image image)
        {
            picPicture.Image = image;
            picPicture.ZoomOriginal(true);

            var width = Math.Min(MaximumSize.Width, image.Width + (ClientSize.Width - picPicture.Width));
            var height = Math.Min(MaximumSize.Height, image.Height + (ClientSize.Height - picPicture.Height));
            ClientSize = new Size(width, height);

            ShowDialog();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                case Keys.Enter:
                    Close();
                    break;
            }
        }
    }
}
