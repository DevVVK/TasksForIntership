using System.Drawing;
using System.Windows.Forms;
using Arcanoid.Interfaces;

namespace Arcanoid.GameObjectClasses
{
    public abstract class GameObject
    {
        protected ICollisionBall HandlerCollisionBall { get; set; }

        public bool IsCollision => HandlerCollisionBall.IsCollision;

        public Size Size
        {
            get => RenderGameObject().Size;
            set => RenderGameObject().Size = value;
        }

        public Point Position
        {
            get => RenderGameObject().Location;
            set => RenderGameObject().Location = value;
        }

        public virtual Color Color
        {
            get => RenderGameObject().BackColor;
            set => RenderGameObject().BackColor = value;
        }

        public Point SpeedVector { get; set; }

        public int CountLives { get; set; }

        public abstract Control RenderGameObject();

        public abstract void ReactionToCollisions(Ball gameObject);

        public abstract void MovementGameObject();
    }
}