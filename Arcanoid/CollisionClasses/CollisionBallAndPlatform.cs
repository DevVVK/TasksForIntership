using System.Drawing;
using System.Windows.Forms;
using Arcanoid.GameObjectClasses;
using Arcanoid.Interfaces;

namespace Arcanoid.CollisionClasses
{
    public class CollisionBallAndPlatform : ICollisionBall
    {
        public bool IsCollision { get; set; }

        private Rectangle _intersectRectangle;

        public void DetectCollision(Control gameObject, Ball ball)
        {
            IsCollision = false;

            if (_intersectRectangle.IsEmpty) return;

            var pointCenterBall = new Point(ball.Position.X + ball.Size.Width / 2, ball.Position.Y + ball.Size.Height / 2);

            if (pointCenterBall.X > gameObject.Location.X)
            {
                ball.SpeedVector = new Point(-1 * ball.SpeedVector.X, ball.SpeedVector.Y);
            }

            if (pointCenterBall.Y < gameObject.Location.Y + gameObject.Size.Height)
            {
                ball.SpeedVector = new Point(ball.SpeedVector.X, -1 * ball.SpeedVector.Y);
            }

            if (pointCenterBall.X < gameObject.Location.X + gameObject.Size.Width)
            {
                ball.SpeedVector = new Point(-1 * ball.SpeedVector.X, ball.SpeedVector.Y);
            }

            IsCollision = false;
        }
    }
}