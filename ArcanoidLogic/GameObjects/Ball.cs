using System.Drawing;
using Microsoft.Xna.Framework;
using Point = System.Drawing.Point;

namespace Arcanoid.GameObjects
{
    public class Ball : GameMoveObject<Ball>
    {
        public Vector2 SpeedVector { get; set; }

        public int CountLives { get; set; }

        public Ball(Point position, Size size, Vector2 speedVector, int countLives) : base(position, size)
        {
            SpeedVector = speedVector;

            CountLives = countLives;
        }

        public void Move()
        {
            Move(SpeedVector);
        }

        public override void ReactionCollisionBall(Ball ball)
        {
            
        }
    }
}