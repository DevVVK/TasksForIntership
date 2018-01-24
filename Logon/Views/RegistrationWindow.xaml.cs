using System.Collections.ObjectModel;
using System.Windows;
using Logon.Users.Data;
using Logon.Users.ViewModels;

namespace Logon
{
    /// <summary>
    /// Code-Behind
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        #region Конструторы

        /// <summary>
        /// Конструтор по умоланию
        /// </summary>
        /// <param name="users">список пользователей</param>
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор для добавления пользователя в бд
        /// </summary>
        /// <param name="users"></param>
        public RegistrationWindow(ObservableCollection<UserContract> users) : this()
        {
            DataContext = new RegistrationViewModel(users, this);
        }

        /// <summary>
        /// Конструктор для окна обновления данных пользователя в бд
        /// </summary>
        /// <param name="users">список пользователей для обновления на клиенте</param>
        /// <param name="user">пользователь которого нужно обновить</param> 
        public RegistrationWindow(ObservableCollection<UserContract> users, UserContract user) : this()
        {
            DataContext = new RegistrationViewModel(users, user, this);
        }

        #endregion
    }
}
