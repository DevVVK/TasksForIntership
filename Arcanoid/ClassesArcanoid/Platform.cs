using System.Drawing;
using System.Windows.Forms;

namespace Arcanoid.ClassesArcanoid
{
    public sealed class Platform : GameObject
    {
        public override Size SizeObject
        {
            get => _platformPictureBox.Size;
            set => _platformPictureBox.Size = value;
        }

        public override Point PointObject
        {
            get => _platformPictureBox.Location;
            set => _platformPictureBox.Location = value;
        }

        public override Color ColorObject
        {
            get => _platformPictureBox.BackColor;
            set => _platformPictureBox.BackColor = value;
        }

        public override int SpeedMoveGameObject
        {
            get => _speedMovePlatform;
            set => _speedMovePlatform = value;
        }

        public override Point VectorMove
        {
            get => _vectorMovePlatform;
            set => _vectorMovePlatform = value;
        }

        private int _speedMovePlatform;

        private Point _vectorMovePlatform;

        private readonly PictureBox _platformPictureBox;

        public Platform(Size sizePlatform, Point pointPlatform, Color colorPlatform, int speedMovePlatform)
        {
            _platformPictureBox = new PictureBox
            {
                Location = pointPlatform,
                BackColor = colorPlatform,
                Size = sizePlatform
            };

            _speedMovePlatform = speedMovePlatform;

            _vectorMovePlatform.X = 0;
            _vectorMovePlatform.Y = 0;
        }
        
        protected override Control RenderGameObject()
        {
            return _platformPictureBox;
        }

        private Rectangle _intersectRectangle;

        public override void DetectCollisions(GameObject gameObject)
        {
            _intersectRectangle = Rectangle.Intersect(new Rectangle(gameObject.PointObject, gameObject.SizeObject), new Rectangle(PointObject, SizeObject));

            if (_intersectRectangle.IsEmpty) return;

            // top
            if (gameObject.VectorMove.Y > 0 && gameObject.PointObject.Y + gameObject.SizeObject.Height > PointObject.Y)
            {
                gameObject.VectorMove = new Point(gameObject.VectorMove.X, -1 * gameObject.VectorMove.Y);
                return;
            }

            // left
            if (gameObject.VectorMove.X > 0 && gameObject.PointObject.X + gameObject.SizeObject.Width > PointObject.X)
            {
                gameObject.VectorMove = new Point(-1 * gameObject.VectorMove.X, gameObject.VectorMove.Y);
                return;
            }

            // right
            if (gameObject.VectorMove.X < 0 && gameObject.PointObject.X < PointObject.X + SizeObject.Width)
            {
                gameObject.VectorMove = new Point(-1 * gameObject.VectorMove.X, gameObject.VectorMove.Y);
            }
        }

        public override void MovementGameObject()
        {
            _platformPictureBox.Location = new Point(_platformPictureBox.Location.X + _vectorMovePlatform.X * _speedMovePlatform, 
                                                     _platformPictureBox.Location.Y + _vectorMovePlatform.Y * _speedMovePlatform);
        }
    }
}