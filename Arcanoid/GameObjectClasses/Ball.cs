using System.Drawing;
using System.Windows.Forms;

namespace Arcanoid.GameObjectClasses
{
    public sealed class Ball : GameObject
    {
        public override Color Color
        {
            get => _ballBrush.Color;
            set
            {
                _ballBrush.Color = value;
                _ballGraphics.FillEllipse(_ballBrush, _ballRectangle);
                _ballPictureBox.Image = _ballBitmap;
            }
        }

        private readonly PictureBox _ballPictureBox;
        private readonly SolidBrush _ballBrush;
        private readonly Graphics   _ballGraphics;
        private readonly Bitmap     _ballBitmap;
        private readonly Rectangle  _ballRectangle;

        public Ball(Size sizeBall, Point pointBall, Color colorBall, int countLives)
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

            SpeedVector = new Point(5,5);

            CountLives = countLives;
        }

        public override Control RenderGameObject()
        {
            return _ballPictureBox;
        }

        public override void ReactionToCollisions(Ball ball)
        {
            
        }

        public override void MovementGameObject()
        {
            _ballPictureBox.Location = new Point(_ballPictureBox.Location.X + SpeedVector.X, 
                                                 _ballPictureBox.Location.Y + SpeedVector.Y);
        }
    }
}
