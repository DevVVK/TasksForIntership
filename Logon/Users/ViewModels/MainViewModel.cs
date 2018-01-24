using System.Collections.ObjectModel;
using System.Windows.Input;
using Logon.Users.Data;
using Logon.Users.Data.MapBuilders;
using Logon.Users.ViewModels.Commands;
using Logon.Windows;
using Users.BLL.Services;

namespace Logon.Users.ViewModels
{
    /// <summary>
    /// Модель-представления главного окна
    /// </summary>
    public class MainViewModel
    {
        #region Свойства

        /// <summary>
        /// Список пользователей
        /// </summary>
        public ObservableCollection<UserContract> UserDataProfiles { get; set; }

        #endregion

        #region Конструкторы 

        /// <summary>
        /// Обьект класса для отображения данных см. <see cref="MapUserContract"/>
        /// </summary>
        private readonly MapUserContract _mapperUserContract = new MapUserContract();

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainViewModel()
        {
            using (var userService = new UserService())
            {
                UserDataProfiles = new ObservableCollection<UserContract>(_mapperUserContract.GetMapList(userService.GetAllUsers()));
            }

            //Команды
            ShowRegistrationViewCommand = new BaseCommandRelay(ShowRegistrationView);
            ShowLogonViewCommand = new BaseCommandRelay(ShowLogonView);
        }

        #endregion

        #region Команды

        /// <summary>
        /// Команда выводит окно регистрации 
        /// </summary>
        public ICommand ShowRegistrationViewCommand { get; }

        /// <summary>
        /// Команда выводит окно ввода логина и пароля 
        /// </summary>
        public ICommand ShowLogonViewCommand { get; }

        #endregion

        #region Методы 

        /// <summary>
        /// Вывод окна регистрации пользователя
        /// </summary>
        /// <param name="parameter"></param>
        private void ShowRegistrationView(object parameter)
        {
            var registerView = new RegistrationWindow(UserDataProfiles);
            registerView.ShowDialog();
        }

        /// <summary>
        /// Вывод окна ввода логина и пароля
        /// </summary>
        /// <param name="parameter"></param>
        private void ShowLogonView(object parameter)
        {
            if (!(parameter is int id)) return;

            var logonView = new LogonWindow(UserDataProfiles, id);
            logonView.ShowDialog();
        }

        #endregion

        #region Методы (helpers)

        #endregion
    }
}