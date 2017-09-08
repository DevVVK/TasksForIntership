using System.Windows.Forms;
using Arcanoid.GameObjectClasses;

namespace Arcanoid.Interfaces
{
    public interface ICollisionBall
    {
        bool IsCollision { get; set; }

        void DetectCollision(Control gameObject, Ball ball);
    }
}