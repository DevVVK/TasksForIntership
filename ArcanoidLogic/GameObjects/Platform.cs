using System.Drawing;
using Arcanoid.CollisionClasses;
using Microsoft.Xna.Framework;
using Point = System.Drawing.Point;

namespace Arcanoid.GameObjects
{
    public class Platform : GameMoveObject<Platform>
    {
        public Vector2 SpeedVector { get; set; }

        public Platform(Point position, Size size, Vector2 speedVector) : base(position, size)
        {
            SpeedVector = speedVector;

            HanlderObjectCollisionBall = new ReactionCollisionBallAndPlatform();
        }

        public void Move()
        {
            Move(SpeedVector);
        }

        public override void ReactionCollisionBall(Ball ball)
        {
            HanlderObjectCollisionBall.ReactionToCollision(this, ball);
        }
    }
}