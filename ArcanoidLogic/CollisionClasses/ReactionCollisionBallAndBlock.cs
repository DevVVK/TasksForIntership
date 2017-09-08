using Arcanoid.GameObjects;
using Arcanoid.Interfaces;
using Microsoft.Xna.Framework;
using Point = System.Drawing.Point;

namespace Arcanoid.CollisionClasses
{
    public class ReactionCollisionBallAndBlock : ICollisionBall<Block>
    {
        public bool IsCollision { get; set; }

        public void ReactionToCollision(Block block, Ball ball)
        {
            IsCollision = false;

            if (!Collision.DetectCollision(block, ball)) return;

            var pointCenterBall = new Point(ball.Position.X + ball.Size.Width / 2, ball.Position.Y + ball.Size.Height / 2);

            if (pointCenterBall.X > block.Position.X)
            {
                ball.SpeedVector = new Vector2(-1 * ball.SpeedVector.X, ball.SpeedVector.Y);
            }

            if (pointCenterBall.Y < block.Position.Y + block.Size.Height)
            {
                ball.SpeedVector = new Vector2(ball.SpeedVector.X, -1 * ball.SpeedVector.Y);
            }

            if (pointCenterBall.X < block.Position.X + block.Size.Width)
            {
                ball.SpeedVector = new Vector2(-1 * ball.SpeedVector.X, ball.SpeedVector.Y);
            }

            if (pointCenterBall.Y > block.Position.Y)
            {
                ball.SpeedVector = new Vector2(ball.SpeedVector.X, -1 * ball.SpeedVector.Y);
            }

            IsCollision = true;
        }
    }
}