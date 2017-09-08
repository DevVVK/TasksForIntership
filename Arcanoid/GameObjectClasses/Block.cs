using System.Drawing;
using System.Windows.Forms;
using Arcanoid.CollisionClasses;

namespace Arcanoid.GameObjectClasses
{
    public sealed class Block : GameObject
    {
        private readonly PictureBox _blockPictureBox;

        public Block(Size sizeBlock, Point pointBlock, Color colorBlock)
        {
            _blockPictureBox = new PictureBox
            {
                Location = pointBlock,
                Size = sizeBlock,
                BackColor = colorBlock
            };

            SpeedVector = new Point(0, 0);

            CountLives = 1;

            HandlerCollisionBall = new CollisionBallAndBlock();
        }

        public override Control RenderGameObject()
        {
            return _blockPictureBox;
        }

        public override void ReactionToCollisions(Ball ball)
        {
            HandlerCollisionBall.DetectCollision(_blockPictureBox, ball);

            if (HandlerCollisionBall.IsCollision)
            {
                CountLives--;
            }
        }

        public override void MovementGameObject()
        {

        }
    }
}
