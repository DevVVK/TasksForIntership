using Arcanoid.GameObjects;
using Arcanoid.Interfaces;
using Microsoft.Xna.Framework;

namespace Arcanoid.CollisionClasses
{
    public class ReactionCollisionBallAndCanva : ICollisionBall<Canvas>
    {
        public bool IsCollision { get; set; }

        public void ReactionToCollision(Canvas objectCollision, Ball ball)
        {
            IsCollision = false;

            if (ball.Position.X + ball.Size.Width > objectCollision.Size.Width)
            {
                ball.SpeedVector = new Vector2(-1 * ball.SpeedVector.X, ball.SpeedVector.Y);
                IsCollision = true;
            }

            if (ball.Position.X < objectCollision.Position.X)
            {
                ball.SpeedVector = new Vector2(-1 * ball.SpeedVector.X, ball.SpeedVector.Y);
                IsCollision = true;
            }

            if (ball.Position.Y < objectCollision.Position.Y)
            {
                ball.SpeedVector = new Vector2(ball.SpeedVector.X, -1 * ball.SpeedVector.Y);
                IsCollision = true;
            }

            if (ball.Position.Y + ball.Size.Height > objectCollision.Position.Y + objectCollision.Size.Height)
            {
                ball.SpeedVector = new Vector2(ball.SpeedVector.X, -1 * ball.SpeedVector.Y);
                ball.CountLives--;
            }

            IsCollision = true;
        }
    }
}