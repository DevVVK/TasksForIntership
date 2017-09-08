using Arcanoid.GameObjects;

namespace Arcanoid.Interfaces
{
    public interface ICollisionBall<in TObjectCollsion>
    {
        bool IsCollision { get; set; }

        void ReactionToCollision(TObjectCollsion objectCollision, Ball ball);
    }
}