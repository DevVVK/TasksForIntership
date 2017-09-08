using System;
using System.Windows.Forms;
using CheckArcanoidLibrary.Interfaces;

namespace CheckArcanoidLibrary.Forms
{
    public partial class ArcanoidMainForm : Form, IView  
    {
        public ArcanoidMainForm()
        {
            InitializeComponent();
        }

        public event EventHandler<CommandArgs> CommandGameKeyPress;
        public Control ControlLink { get; }
    }
}
