using System.Drawing;
using System.Windows.Forms;
using Arcanoid.CollisionClasses;

namespace Arcanoid.GameObjectClasses
{
    public sealed class Platform : GameObject
    {
        private readonly PictureBox _platformPictureBox;

        public Platform(Size sizePlatform, Point pointPlatform, Color colorPlatform)
        {
            _platformPictureBox = new PictureBox
            {
                Location = pointPlatform,
                BackColor = colorPlatform,
                Size = sizePlatform
            };

            SpeedVector = new Point(10, 0);

            CountLives = 0;

            HandlerCollisionBall = new CollisionBallAndPlatform();
        }

        public override Control RenderGameObject()
        {
            return _platformPictureBox;
        }

        public override void ReactionToCollisions(Ball ball)
        {
            HandlerCollisionBall.DetectCollision(_platformPictureBox, ball);
        }

        public override void MovementGameObject()
        {
            _platformPictureBox.Location = new Point(_platformPictureBox.Location.X + SpeedVector.X, 
                                                     _platformPictureBox.Location.Y + SpeedVector.Y);
        }
    }
}