using System.Collections.Generic;
using System.Windows.Forms;

namespace CheckArcanoidLibrary.Logic
{
    public class KeyListener
    {
        public readonly List<Keys> ListKeys;

        public KeyListener()
        {
            ListKeys = new List<Keys>();
        }

        public void PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ListKeys.Add(e.KeyCode);
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            ListKeys.Clear();
        }
    }
}