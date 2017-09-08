using System;
using System.Windows.Forms;
using CheckArcanoidLibrary.Enumerables;
using CheckArcanoidLibrary.Interfaces;

namespace CheckArcanoidLibrary.Forms
{
    public partial class MainPanel : UserControl, IView
    {
        public MainPanel()
        {
            InitializeComponent();

            btnStartGame.Tag = new CommandArgs(CommandEnum.StartGame);

            lblUser.Text = Properties.Settings.Default.User;
        }

        public event EventHandler<CommandArgs> CommandGameKeyPress;

        public Control ControlLink => this;

        private void ClickButton(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button?.Tag is CommandArgs)
            {
                OnCommandGameKeyPress((CommandArgs) button.Tag);
            }
        }

        protected virtual void OnCommandGameKeyPress(CommandArgs e)
        {
            CommandGameKeyPress?.Invoke(this, e);
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            var addUserForm = new AddUserForm(this);

            addUserForm.ShowDialog();
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            var statisticForm = new StatisticForm();

            statisticForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}