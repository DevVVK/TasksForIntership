using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Logon.Users.Data;
using Logon.Users.Data.MapBuilders;
using Logon.Users.ViewModels.Commands;
using Logon.Users.ViewModels.Interfaces;
using Logon.Users.ViewModels.ViewUpdaters;
using Users.BLL.Services;

namespace Logon.Users.ViewModels
{
    /// <summary>
    /// Модель-представления окна информации о полльзователе 
    /// </summary>
    public class InformationUserViewModel
    {
        #region Открытые свойства

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName => User.FirstName;

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName => User.LastName;

        /// <summary>
        /// Пол пользователя
        /// </summary>
        public string Gender => User.Gender;

        /// <summary>
        /// Дата рождения пользователя
        /// </summary>
        public DateTime DateBirth => User.DateBirth;

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login => User.Login;

        /// <summary>
        /// Аватар пользователя
        /// </summary>
        public BitmapSource Avatar => User.Avatar;

        #endregion

        #region Закрытые поля

        /// <summary>
        /// Список пользователей 
        /// </summary>
        private ObservableCollection<UserContract> UserList { get; }

        /// <summary>
        /// Свойство для отображения данных пользователя (для binding)
        /// </summary>
        private UserContract User { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Стандартный конструктор
        /// </summary>
        /// <param name="users">списко пользователей для удаления или редактирования</param>
        /// <param name="user">пользователь для отображения</param>
        /// <param name="link">ссылка на окно регистрации</param>
        public InformationUserViewModel(ObservableCollection<UserContract> users, UserContract user, InformationUserWindow link)
        {
            UserList = users;
            User = user;

            //Команды
            CloseWindowCommand = new BaseCommandRelay(parameter => link.Close());
            ShowAsseccQuestionCommmand = new BaseCommandRelay(ShowAsseccQuestionWindow);
            ShowReaderUserWindowCommand = new BaseCommandRelay(ShowReaderUserWindow);
        }

        #endregion

        #region Команды

        /// <summary>
        /// Команда закрытия окна
        /// </summary>
        public ICommand CloseWindowCommand { get; }

        /// <summary>
        /// Команда открытия окна редактирования данных пользователя
        /// </summary>
        public ICommand ShowReaderUserWindowCommand { get; }

        /// <summary>
        /// Команда подтверждения удаления данных пользователя
        /// </summary>
        public ICommand ShowAsseccQuestionCommmand { get; }

        #endregion

        #region Методы

        /// <summary>
        /// Вызывает окно редактирования данных пользователя
        /// </summary>
        /// <param name="parameter"></param>
        private void ShowReaderUserWindow(object parameter)
        {
            CloseWindowCommand.Execute(null);

            var updateWindow = new RegistrationWindow(UserList, User);
            var viewUpdater = new UpdateViewUpdater(updateWindow);
            viewUpdater.Update();

            updateWindow.ShowDialog();
        }

        /// <summary>
        /// Объект отображения см. <see cref="MapUserDto"/>
        /// </summary>
        private readonly MapUserDto _mapper = new MapUserDto();

        /// <summary>
        /// Удаляет выбранного пользователя
        /// </summary>
        private void ShowAsseccQuestionWindow(object parameter)
        {
            if (MessageBox.Show(@"Вы действительно хотите удалить данных данного пользователя ?", 
                @"Подтверждение", MessageBoxButtons.OKCancel) != DialogResult.OK) return;

            CloseWindowCommand.Execute(null);

            using (var dataBase = new UserService())
            {
                dataBase.DeleteUser(User.Id);
            }

            var removedElement = UserList.FirstOrDefault(x => x.Id == User.Id);

            UserList.Remove(removedElement);
        }

        #endregion
    }
}