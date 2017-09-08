using System.Windows.Forms;

namespace Arcanoid.GameObjectClasses
{
    public class KeyListener
    {
        private readonly GameLoop _arcanoid;

        public KeyListener(GameLoop arcanoid)
        {
            _arcanoid = arcanoid;
        }

        public void KeyPress(object sender, KeyEventArgs e)
        {
            _arcanoid.KeyPressed = e.KeyCode;
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            _arcanoid.KeyPressed = null;
        }
    }
}