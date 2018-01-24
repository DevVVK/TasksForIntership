using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Logon.Users.Data;
using Logon.Users.Data.MapBuilders;
using Logon.Users.ViewModels.Base;
using Logon.Users.ViewModels.Commands;
using Logon.Users.ViewModels.Exceptions;
using Logon.Windows;
using Users.BLL.Services;

namespace Logon.Users.ViewModels
{
    /// <inheritdoc />
    /// <summary>
    /// Моедль-представления окна аутентификации пользователя
    /// </summary>
    public class LogonViewModel : BaseViewModel
    {
        #region Открытые свойства

        /// <summary>
        /// Введенный логин пользователя (для binding)
        /// </summary>
        public string Login => UserList.FirstOrDefault(x => x.Id == Id)?.Login;

        /// <summary>
        /// Свойство для отображения ошибок ввода пароля
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Устанавливает статус отображения ошибки (для binding)
        /// </summary>
        public Visibility ErrorVisibility { get; set; } = Visibility.Collapsed;

        #endregion

        #region Закрытые поля

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        private int Id { get; }

        /// <summary>
        /// Список всех пользовалей(для удаления или редактирования)
        /// </summary>
        private ObservableCollection<UserContract> UserList { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Стандартный конструктор 
        /// </summary>
        /// <param name="users">списко пользователей</param>
        /// <param name="id">идентификатор пользователя для доступа к аккаунту</param>
        /// <param name="link">ссылка на форму ввод логина и пароля</param>
        public LogonViewModel(ObservableCollection<UserContract> users, int id, LogonWindow link)
        {
            Id = id;
            UserList = users;

            //Команды
            CloseWindowCommand = new BaseCommandRelay(parameter => link.Close());
        }

        #endregion

        #region Команды

        /// <summary>
        /// Команда закрытия окна входа в аккаунт
        /// </summary>
        public ICommand CloseWindowCommand { get; }

        #endregion

        #region Методы

        /// <summary>
        /// Проверка введенного пароля и в случае правильности вывести форму с основной информацией о пользователе
        /// </summary>
        /// <param name="password"></param>
        public void ShowInformationUserView(PasswordBox password)
        {
            ErrorVisibility = Visibility.Collapsed;

            try
            {
                var checkingPasswordUser = GetCheckingUserContract(password.Password);

                CloseWindowCommand.Execute(null);

                var informationView = new InformationUserWindow(UserList, checkingPasswordUser);
                informationView.ShowDialog();
            }
            catch (InvalidInputIncorrectPassword exception)
            {
                ErrorMessage = exception.Message;
                ErrorVisibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Обьект класса отображения данных см. <see cref="MapUserContract"/>
        /// </summary>
        private readonly MapUserContract _mapper = new MapUserContract();

        /// <summary>
        /// Проводит отображение данных
        /// </summary>
        /// <param name="password">введенный пароль пользователя</param>
        /// <returns></returns>
        private UserContract GetCheckingUserContract(string password)
        {
            UserContract user;

            using (var userService = new UserService())
            {
                if (!GetCheckPasswordContract(password))
                    throw new InvalidInputIncorrectPassword();

                user = _mapper.GetMapOne(userService.GetUserOne(Id));
            }

            return user;
        }

        /// <summary>
        /// Проверяет на совпадение пароля хранящегося в бд и пароля введенного пользователем
        /// </summary>
        /// <param name="password">введенный пароль пользовтеля</param>
        /// <returns></returns>
        private bool GetCheckPasswordContract(string password)
        {
            using (var userService = new UserService())
            {
                return userService.GetCheckResult(Id, Login, password);
            }
        }

        #endregion
    }
}