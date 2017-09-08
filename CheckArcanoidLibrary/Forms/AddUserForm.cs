using System;
using System.Windows.Forms;
using CheckArcanoidLibrary.ExceptionClasses;

namespace CheckArcanoidLibrary.Forms
{
    public partial class AddUserForm : Form
    {
        #region Инициализация

        private string UserName
        {
            get
            {
                if (string.IsNullOrEmpty(tbxUserName.Text))
                    throw new InvalidEnterNameException();

                return tbxUserName.Text;
            }
        }

        public AddUserForm()
        {
            InitializeComponent();
        }

        private readonly MainPanel _linkMainPanel;

        public AddUserForm(MainPanel linkMainPanel) : this()
        {
            _linkMainPanel = linkMainPanel;
        }

        #endregion

        #region Обработчики событий

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                AddUserConfigurationFile(UserName);

                Close();
            }
            catch (InvalidEnterNameException exception)
            {
                erpInvalidName.SetError(tbxUserName, exception.Message);
            }
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Вспомогательные функции

        private void AddUserConfigurationFile(string user)
        {
            Properties.Settings.Default.User = DelLastSpace(user);
            Properties.Settings.Default.Save();

            _linkMainPanel.lblUser.Text = user;
        }

        private string DelLastSpace(string str)
        {
            var val = str.Trim();
            return val;
        }

        #endregion
    }
}