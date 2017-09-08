using System.Drawing;
using Arcanoid.CollisionClasses;

namespace Arcanoid.GameObjects
{
    public class Block : GameObject<Block>
    {
        public bool IsCollision => HanlderObjectCollisionBall.IsCollision; 

        public Block(Point position, Size size) : base(position, size)
        {
            HanlderObjectCollisionBall = new ReactionCollisionBallAndBlock();
        }

        public override void ReactionCollisionBall(Ball ball)
        {
            HanlderObjectCollisionBall.ReactionToCollision(this, ball);
        }
    }
}