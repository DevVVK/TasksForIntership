using Arcanoid.GameObjects;

namespace Arcanoid.CollisionClasses
{
    public class Collision
    {
        public static bool DetectCollision<TObjectCollision>(GameObject<TObjectCollision> gameObject, Ball ball)
        {
            return gameObject.Position.X < ball.Position.X + ball.Size.Width &&
                   gameObject.Position.X + gameObject.Size.Width > ball.Position.X &&
                   gameObject.Position.Y < ball.Position.Y + ball.Size.Height &&
                   gameObject.Position.Y + gameObject.Size.Height > ball.Position.Y;
        }
    }
}