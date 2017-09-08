using System.Drawing;
using Microsoft.Xna.Framework;
using Point = System.Drawing.Point;

namespace Arcanoid.GameObjects
{
    public abstract class GameMoveObject<TObjectCollision> : GameObject<TObjectCollision>
    {
        protected GameMoveObject(Point position, Size size) : base(position, size) { }

        public abstract override void ReactionCollisionBall(Ball ball);

        public void Move(Vector2 speedVector)
        {
            Position = new Point((int) (Position.X + speedVector.X), (int) (Position.Y + speedVector.Y));
        }
    }
}