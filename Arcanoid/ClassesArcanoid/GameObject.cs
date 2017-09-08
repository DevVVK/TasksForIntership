using System.Drawing;
using System.Windows.Forms;

namespace Arcanoid.ClassesArcanoid
{
    public abstract class GameObject
    {
        public abstract Size SizeObject { get; set; }

        public abstract Point PointObject { get; set; }

        public abstract Color ColorObject { get; set; }

        public abstract int SpeedMoveGameObject { get; set; }
        
        public abstract Point VectorMove { get; set; }

        protected abstract Control RenderGameObject();

        public abstract void DetectCollisions(GameObject gameObject);

        public abstract void MovementGameObject();


        public void SetGameObjectToCanvas(Control canvasForObject)
        {
            canvasForObject.Controls.Add(RenderGameObject());
        }

        public void RemoveGameObject(Control canvaForObkject, Control removeGameObject)
        {
            canvaForObkject.Controls.Remove(removeGameObject);
        }
    }
}