using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Rhapsody.UI
{
    internal class AdvancedPictureBox : Control, ISupportInitialize
    {
        private PictureBox _pictureBox;
        private Point _panStartLocation;
        private ZoomMode _zoomMode = ZoomMode.FitWidth;
        private double _zoomFactor = .1;

        public Image Image
        {
            get
            {
                return _pictureBox.Image;
            }
            set
            {
                _pictureBox.Image = value;

                SetImage(true);
            }
        }

        public AdvancedPictureBox()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);

            _pictureBox = new PictureBox();
            _pictureBox.Size = new Size(0, 0);
            _pictureBox.Anchor = AnchorStyles.None;
            _pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            _pictureBox.MouseDown += PictureBox_MouseDown;
            _pictureBox.MouseMove += PictureBox_MouseMove;
            _pictureBox.MouseUp += PictureBox_MouseUp;
            _pictureBox.MouseWheel += PictureBox_MouseWheel;

            Controls.Add(_pictureBox);

            ZoomFitWidth(true);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            SetImage(false);
        }

        private void SetImage(bool relocate)
        {
            if (_pictureBox.Image == null)
            {
                _pictureBox.Size = new Size(0, 0);
                return;
            }

            switch (_zoomMode)
            {
                case ZoomMode.OriginalSize:
                    ZoomOriginal(relocate);
                    break;

                case ZoomMode.FitAll:
                    ZoomFitAll(relocate);
                    break;

                case ZoomMode.FitWidth:
                    ZoomFitWidth(relocate);
                    break;

                case ZoomMode.Zoom:
                    break;

                default:
                    throw new NotSupportedException();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Dotted);

            base.OnPaint(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (e.Delta < 0)
                ZoomIn();
            else
                ZoomOut();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;

            _panStartLocation = e.Location;
            _pictureBox.Capture = true;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_pictureBox.Capture)
                return;

            var newX = _pictureBox.Location.X;
            var newY = _pictureBox.Location.Y;

            if (_pictureBox.Width > Width)
            {
                var panDeltaX = e.Location.X - _panStartLocation.X;
                newX += panDeltaX;

                if (newX < Width - _pictureBox.Width)
                    newX = Width - _pictureBox.Width;

                if (newX > 0)
                    newX = 0;
            }

            if (_pictureBox.Height > Height)
            {
                var panDeltaY = e.Location.Y - _panStartLocation.Y;
                newY += panDeltaY;

                if (newY < Height - _pictureBox.Height)
                    newY = Height - _pictureBox.Height;

                if (newY > 0)
                    newY = 0;
            }

            var newWidth = _pictureBox.Width;
            var newHeight = _pictureBox.Height;

            MoveImage(newX, newY, newWidth, newHeight);
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_pictureBox.Capture)
                return;

            _pictureBox.Capture = false;
        }

        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            OnMouseWheel(e);
        }

        public void ZoomIn()
        {
            Zoom(1 + _zoomFactor);
        }

        public void ZoomOut()
        {
            Zoom(1 - _zoomFactor);
        }

        private void Zoom(double factor)
        {
            // TODO: Focus

            var newWidth = (int)(_pictureBox.Width * factor);
            var newHeight = (int)(_pictureBox.Height * factor);
            var newX = _pictureBox.Left - (newWidth / 2 - _pictureBox.Width / 2);
            var newY = _pictureBox.Top - (newHeight / 2 - _pictureBox.Height / 2);

            if (newY > 0)
                newY = 0;

            MoveImage(newX, newY, newWidth, newHeight);

            _zoomMode = ZoomMode.Zoom;
        }

        public void ZoomOriginal(bool relocate)
        {
            if (Image != null)
            {
                var newWidth = Image.Size.Width;
                var newHeight = Image.Size.Height;
                var newX = Width / 2 - newWidth / 2;
                var newY = 0;

                MoveImage(newX, newY, newWidth, newHeight);
            }

            _zoomMode = ZoomMode.OriginalSize;
        }

        public void ZoomFitAll(bool relocate)
        {
            // TODO: Focus

            if (Image != null)
            {
                var ratio = Image.Width / (double)Image.Height;
                int newWidth;
                int newHeight;

                if (Image.Width > Image.Height)
                {
                    if (Width > Height)
                    {
                        newHeight = Height;
                        newWidth = (int)(newHeight * ratio);
                    }
                    else
                    {
                        newWidth = Width;
                        newHeight = (int)(newWidth / ratio);
                    }
                }
                else
                {
                    if (Width > Height)
                    {
                        newHeight = Height;
                        newWidth = (int)(newHeight * ratio);
                    }
                    else
                    {
                        newWidth = Width;
                        newHeight = (int)(newWidth / ratio);
                    }
                }

                var newX = Width / 2 - newWidth / 2;
                var newY = relocate ? Height / 2 - newHeight / 2 : _pictureBox.Top;

                MoveImage(newX, newY, newWidth, newHeight);
            }

            _zoomMode = ZoomMode.FitAll;
        }

        public void ZoomFitWidth(bool relocate)
        {
            if (Image != null)
            {
                var imageRatio = Image.Width / (double)Image.Height;
                var newWidth = Image.Width > Width ? Width : Image.Width;
                var newHeight = (int)(newWidth / imageRatio);
                var newX = Width / 2 - newWidth / 2;
                var newY = Image.Height > Height ? 0 : Height / 2 - newHeight / 2;

                MoveImage(newX, newY, newWidth, newHeight);
            }

            _zoomMode = ZoomMode.FitWidth;
        }

        private void MoveImage(int x, int y, int width, int height)
        {
            _pictureBox.Location = new Point(x, y);
            _pictureBox.Size = new Size(width, height);

            if (width > Width && height > Height)
                _pictureBox.Cursor = Cursors.SizeAll;
            else if (width > Width)
                _pictureBox.Cursor = Cursors.SizeWE;
            else if (height > Height)
                _pictureBox.Cursor = Cursors.SizeNS;
            else
                _pictureBox.Cursor = Cursors.Default;
        }

        public void BeginInit()
        {
        }

        public void EndInit()
        {
        }

        private enum ZoomMode
        {
            OriginalSize,
            FitAll,
            FitWidth,
            Zoom
        }
    }
}
