using System.Drawing;
using Arcanoid.Interfaces;

namespace Arcanoid.GameObjects
{
    public abstract class GameObject<TObjectCollision>
    {
        protected ICollisionBall<TObjectCollision> HanlderObjectCollisionBall { get; set; }

        public Point Position { get; set; }

        public Size Size { get; set; }

        protected GameObject(Point position, Size size)
        {
            Position = position;

            Size = size;
        }

        public abstract void ReactionCollisionBall(Ball ball);
    }
}