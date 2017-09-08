using System.Drawing;
using System.Windows.Forms;

namespace Arcanoid.ClassesArcanoid
{
    public sealed class Block : GameObject
    {
        private readonly PictureBox _blockPictureBox;

        public override Size SizeObject
        {
            get => _blockPictureBox.Size;
            set => _blockPictureBox.Size = value;
        }

        public override Point PointObject
        {
            get => _blockPictureBox.Location;
            set => _blockPictureBox.Location = value;
        }

        public override Color ColorObject
        {
            get => _blockPictureBox.BackColor;
            set => _blockPictureBox.BackColor = value;
        }

        public override int SpeedMoveGameObject { get; set; }

        public override Point VectorMove { get; set; }

        public Block(Size sizeBlock, Point pointBlock, Color colorBlock)
        {
            _blockPictureBox = new PictureBox
            {
                Location = pointBlock,
                Size = sizeBlock,
                BackColor = colorBlock
            };

            SpeedMoveGameObject = 0;
        }

        protected override Control RenderGameObject()
        {
            return _blockPictureBox;
        }

        private Rectangle _intersectRectangle;

        public override void DetectCollisions(GameObject gameObject)
        {
            _intersectRectangle = Rectangle.Intersect(new Rectangle(gameObject.PointObject, gameObject.SizeObject), new Rectangle(PointObject, SizeObject));

            if (_intersectRectangle.IsEmpty) return;

            // left
            if (gameObject.PointObject.X + gameObject.SizeObject.Width + gameObject.SpeedMoveGameObject > PointObject.X)
            {
                gameObject.VectorMove = new Point(-1 * gameObject.VectorMove.X, gameObject.VectorMove.Y);
            }

            // right
            if (gameObject.PointObject.X - gameObject.SpeedMoveGameObject < PointObject.X + SizeObject.Width)
            {
                gameObject.VectorMove = new Point(-1 * gameObject.VectorMove.X, gameObject.VectorMove.Y);
            }

            // bottom
            if (gameObject.PointObject.Y  - gameObject.SpeedMoveGameObject < PointObject.Y + SizeObject.Height)
            {
                gameObject.VectorMove = new Point(gameObject.VectorMove.X, -1 * gameObject.VectorMove.Y);
            }

            // top
            if (gameObject.PointObject.Y + gameObject.SizeObject.Height + gameObject.SpeedMoveGameObject > PointObject.Y)
            {
                gameObject.VectorMove = new Point(gameObject.VectorMove.X, -1 * gameObject.VectorMove.Y);
            }
        }

        public override void MovementGameObject()
        {

        }
    }
}
