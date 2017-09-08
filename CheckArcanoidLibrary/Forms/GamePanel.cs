using System;
using System.Windows.Forms;
using CheckArcanoidLibrary.Attributes;
using CheckArcanoidLibrary.Enumerables;
using CheckArcanoidLibrary.Interfaces;

namespace CheckArcanoidLibrary.Forms
{
    public sealed partial class GamePanel : UserControl, IViewArcanoid
    {
        public GamePanel()
        {
            InitializeComponent();
        }

        public event EventHandler<CommandArgs> CommandGameKeyPress;

        private void ClickButton(object sender, KeyEventArgs e)
        {
            if (EnumAttributesBaseLogic.GetAttributeValue(CommandEnum.PauseGame).KeyArg == e.KeyCode)
            {
                OnCommandGameKeyPress(new CommandArgs(CommandEnum.PauseGame));
            }

            if (EnumAttributesBaseLogic.GetAttributeValue(CommandEnum.StartGame).KeyArg == e.KeyCode)
            {
                OnCommandGameKeyPress(new CommandArgs(CommandEnum.StartGame));
            }
        }

        private void OnCommandGameKeyPress(CommandArgs e)
        {
            CommandGameKeyPress?.Invoke(this, e);
        }
    }
}
