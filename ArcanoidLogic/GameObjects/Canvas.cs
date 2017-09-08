using System.Drawing;
using Arcanoid.CollisionClasses;

namespace Arcanoid.GameObjects
{
    public class Canvas : GameObject<Canvas>
    {
        public Canvas(Point position, Size size) : base(position, size)
        {
            HanlderObjectCollisionBall = new ReactionCollisionBallAndCanva();
        }
        
        public override void ReactionCollisionBall(Ball ball)
        {
            HanlderObjectCollisionBall.ReactionToCollision(this, ball);
        }
    }
}