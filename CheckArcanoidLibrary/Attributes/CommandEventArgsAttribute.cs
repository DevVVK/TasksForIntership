using System;
using System.Windows.Forms;

namespace CheckArcanoidLibrary.Attributes
{
    public class CommandEventArgsAttribute : Attribute
    {
        public Keys KeyArg { get; set; }

        public CommandEventArgsAttribute(Keys key)
        {
            KeyArg = key;
        }
    }
}