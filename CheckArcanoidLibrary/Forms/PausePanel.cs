using System;
using System.Windows.Forms;
using CheckArcanoidLibrary.Enumerables;
using CheckArcanoidLibrary.Interfaces;

namespace CheckArcanoidLibrary.Forms
{
    public partial class PausePanel : UserControl, IViewArcanoid
    {
        public PausePanel()
        {
            InitializeComponent();
            
            btnReplay.Tag = new CommandArgs(CommandEnum.Replay);
            btnContinue.Tag = new CommandArgs(CommandEnum.StartGame);
            btnReturnMainForm.Tag = new CommandArgs(CommandEnum.ReturnMainForm);

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void ClickButton(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button?.Tag is CommandArgs)
            {
                OnCommandGameKeyPress((CommandArgs) button.Tag);
            }
        }

        public event EventHandler<CommandArgs> CommandGameKeyPress;

        protected virtual void OnCommandGameKeyPress(CommandArgs e)
        {
            CommandGameKeyPress?.Invoke(this, e);
        }
        
    }
}
