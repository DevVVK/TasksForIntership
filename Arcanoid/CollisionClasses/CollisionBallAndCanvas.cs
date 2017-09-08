using System.Drawing;
using System.Windows.Forms;
using Arcanoid.GameObjectClasses;
using Arcanoid.Interfaces;

namespace Arcanoid.CollisionClasses
{
    public class CollisionBallAndCanvas : ICollisionBall
    {
        public bool IsCollision { get; set; }

        public void DetectCollision(Control gameObject, Ball ball)
        {
            IsCollision = false;

            if (ball.Position.X + ball.Size.Width > gameObject.Width)
            {
                ball.SpeedVector = new Point(-1 * ball.SpeedVector.X, ball.SpeedVector.Y);
                IsCollision = true;
            }

            if (ball.Position.X < gameObject.Location.X)
            {
                ball.SpeedVector = new Point(-1 * ball.SpeedVector.X, ball.SpeedVector.Y);
                IsCollision = true;
            }

            if (ball.Position.Y < gameObject.Location.Y)
            {
                ball.SpeedVector = new Point(ball.SpeedVector.X, -1 * ball.SpeedVector.Y);
                IsCollision = true;
            }

            if (ball.Position.Y + ball.Size.Height <= gameObject.Location.Y + gameObject.Height) return;

            ball.CountLives--;

            IsCollision = true;
        }
    }
}