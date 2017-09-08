using System.Drawing;
using System.Windows.Forms;
using Arcanoid.Enums;

namespace Arcanoid.ClassesArcanoid
{
    public sealed class Ball : GameObject
    {
        public override Size SizeObject
        {
            get => _ballPictureBox.Size;
            set => _ballPictureBox.Size = value;
        }

        public override Point PointObject
        {
            get => _ballPictureBox.Location;
            set => _ballPictureBox.Location = value;
        }

        public override Color ColorObject
        {
            get => _ballBrush.Color;
            set
            {
                _ballBrush.Color = value;
                _ballGraphics.FillEllipse(_ballBrush, _ballRectangle);
                _ballPictureBox.Image = _ballBitmap;
            }
        }
       
        public override int SpeedMoveGameObject
        {
            get => _speedMoveBall;
            set => _speedMoveBall = value;
        }

        public override Point VectorMove
        {
            get => _vectorMoveBall;
            set => _vectorMoveBall = value;
        }

        private Point _vectorMoveBall;

        private int _speedMoveBall;

        private readonly PictureBox _ballPictureBox;
        private readonly SolidBrush _ballBrush;
        private readonly Graphics   _ballGraphics;
        private readonly Bitmap     _ballBitmap;
        private readonly Rectangle  _ballRectangle;

        public Ball(Size sizeBall, Point pointBall, Color colorBall, int speedMoveBall)
        {
            _ballBitmap =    new Bitmap(sizeBall.Width, sizeBall.Height);
            _ballGraphics =  Graphics.FromImage(_ballBitmap);
            _ballRectangle = new Rectangle(0, 0, sizeBall.Width, sizeBall.Height);
            _ballBrush =     new SolidBrush(colorBall);

            _ballGraphics.FillEllipse(_ballBrush, _ballRectangle);

            _ballPictureBox = new PictureBox
            {
                Location = pointBall,
                Image = _ballBitmap,
                Size = sizeBall
            };

            _speedMoveBall = speedMoveBall;

            _vectorMoveBall.X = 1;
            _vectorMoveBall.Y = 1;
        }

        protected override Control RenderGameObject()
        {
            return _ballPictureBox;
        }

        public override void DetectCollisions(GameObject ball)
        {
           
        }

        public override void MovementGameObject()
        {
            _ballPictureBox.Location = new Point(_ballPictureBox.Location.X + _vectorMoveBall.X * _speedMoveBall, 
                                                 _ballPictureBox.Location.Y + _vectorMoveBall.Y * _speedMoveBall);
        }
    }
}
