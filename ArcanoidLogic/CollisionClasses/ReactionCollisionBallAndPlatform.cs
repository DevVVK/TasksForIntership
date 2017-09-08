using Arcanoid.GameObjects;
using Arcanoid.Interfaces;
using Microsoft.Xna.Framework;

namespace Arcanoid.CollisionClasses
{
    public class ReactionCollisionBallAndPlatform : ICollisionBall<Platform>
    {
        public bool IsCollision { get; set; }

        public void ReactionToCollision(Platform platform, Ball ball)
        {
            IsCollision = false;

            if (!Collision.DetectCollision(platform, ball)) return;

            var pointCenterBall = new Point(ball.Position.X + ball.Size.Width / 2, ball.Position.Y + ball.Size.Height);

            if (pointCenterBall.X >= platform.Position.X)
            {
                ball.SpeedVector = new Vector2((float)10 * (pointCenterBall.X - (platform.Position.X + platform.Size.Width / 2)) / platform.Size.Width, -ball.SpeedVector.Y);
            }

            IsCollision = false;
        }
    }
}