using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Logon.Users.Data;
using Logon.Users.Data.MapBuilders;
using Logon.Users.ViewModels.Base;
using Logon.Users.ViewModels.Commands;
using Logon.Users.ViewModels.Exceptions;
using Users.BLL.Services;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Logon.Users.ViewModels
{
    /// <summary>
    /// Класс модель-представления (окно регистрации)
    /// </summary>
    public class RegistrationViewModel : BaseViewModel
    {
        #region Окрытые свойства

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Пол пользователя
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Дата рождения пользователя 
        /// </summary>
        public DateTime DateBirth { get; set; } = DateTime.Now;

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Название фото (генерируется)
        /// </summary>
        public string PictureName { get; set; }

        /// <summary>
        /// Фото отбражаемое пользователю
        /// </summary>
        public BitmapSource Avatar { get; set; }

        /// <summary>
        /// Свойство статуса отображения текста ошибки заполнения обязательных полей
        /// </summary>
        public Visibility ErrorAllFieldsVisibility { get; set; }

        /// <summary>
        /// Свойство для отображения сообщения ошибки для всех полей
        /// </summary>
        public string ErrorMessage { get; set; }
        
        /// <summary>
        /// Свойство ошибки для ToolType в PasswordBox
        /// </summary>
        public string ToolTypePasswordErrorMessage { get; set; }

        #endregion

        #region Проверка достоверности

        /// <summary>
        /// Проверка достоверности
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(FirstName):

                        if (string.IsNullOrEmpty(FirstName))
                        {
                            HasErrorsFields = true; return IsNullOrEmptyError;
                        }
                        if (FirstName.Length < 1)
                        {
                            HasErrorsFields = true; return IsFiveSymbols;
                        }

                        HasErrorsFields = false;

                        break;

                    case nameof(LastName):

                        if (string.IsNullOrEmpty(LastName))
                        {
                            HasErrorsFields = true; return IsNullOrEmptyError;
                        }
                        if (LastName.Length < 1)
                        {
                            HasErrorsFields = true; return IsFiveSymbols;
                        }

                        HasErrorsFields = false;

                        break;

                    case nameof(Login):

                        if (string.IsNullOrEmpty(Login))
                        {
                            HasErrorsFields = true; return IsNullOrEmptyError;
                        }
                        if (Login.Length < 1)
                        {
                            HasErrorsFields = true; return IsFiveSymbols;
                        }

                        HasErrorsFields = false;

                        break;
                }

                return string.Empty;
            }
        }

        #endregion

        #region Закрытые поля

        /// <summary>
        /// Проверка на существования ошибок
        /// </summary>
        private bool HasErrorsFields { get; set; }

        /// <summary>
        /// Список пользователей для добавления нового обьекта - User
        /// </summary>
        private ObservableCollection<UserContract> UserList { get; }

        /// <summary>
        /// Делегат для хранения ссылки на добавление или обновления данных пользователя
        /// </summary>
        private readonly Action<PasswordBox, PasswordBox> _currentMethod;

        /// <summary>
        /// Данные пользователя, которые нужно редаиктировать
        /// </summary>
        private UserContract User { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчнию
        /// </summary>
        /// <param name="link">ссылка на окно регистрации для зарытия</param>
        public RegistrationViewModel(RegistrationWindow link)
        {
            //Команды
            AddPhotoCommand = new BaseCommandRelay(AddPhoto);
            CloseWindowCommand = new BaseCommandRelay(parameter => link.Close());
        }

        /// <summary>
        /// Конструктор для окна регистрации пользователя
        /// </summary>
        /// <param name="userList">список пользователей на клиенте</param>
        /// <param name="link">ссылка на окно регистрации пользователя</param>
        public RegistrationViewModel(ObservableCollection<UserContract> userList, RegistrationWindow link) : this(link)
        {
            UserList = userList;

            _currentMethod = AddUser;
        }

        /// <summary>
        /// Конструктор для окна обновления данных пользователя
        /// </summary>
        /// <param name="userList">список пользователей на клиенте</param>
        /// <param name="user">данные пользователя, которого требуется обновить</param>
        /// <param name="link">ссылка для закрытия окна обновления данных пользователя</param>
        public RegistrationViewModel(ObservableCollection<UserContract> userList, UserContract user, RegistrationWindow link) : this(userList ,link)
        {
            User = user;

            //Инициализация полей
            InitializationFields(User);

            _currentMethod = UpdateUser;
        }

        #endregion

        #region Команды

        /// <summary>
        /// Команда добавления фотографии пользователя
        /// </summary>
        public ICommand AddPhotoCommand { get; }

        /// <summary>
        /// Команда закрывающая окно регистрации пользователя
        /// </summary>
        public ICommand CloseWindowCommand { get; }

        #endregion

        #region Методы

        /// <summary>
        /// Отображает данные с формы на объект см. <see cref="UserContract"/>
        /// </summary>
        /// <returns></returns>
        private UserContract GetMapUserContract()
        {
            return new UserContract
            {
                FirstName = FirstName,
                LastName = LastName,
                Login = Login,
                Avatar = Avatar,
                DateBirth = DateBirth,
                Gender = Gender,
                Password = Password,
                ExtensionPicture = PictureName
            };
        }

        /// <summary>
        /// Устанавливает начальные значения полей (для редактирования)
        /// </summary>
        private void InitializationFields(UserContract user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Gender = user.Gender;
            DateBirth = user.DateBirth;
            Login = user.Login;
            Avatar = user.Avatar;
        }

        /// <summary>
        /// Обьект класса отображения модели см. <see cref="MapUserDto"/>
        /// </summary>
        private readonly MapUserDto _mapperDto = new MapUserDto();

        /// <summary>
        /// Вызывает выбранный метод (добавление данных пользователя, либо удаление данных пользователя)
        /// </summary>
        /// <param name="password">пароль</param>
        /// <param name="confirmPassword">подтверждение пароля</param>
        public void ExecuteCurrentMethod(PasswordBox password, PasswordBox confirmPassword)
        {
            _currentMethod(password, confirmPassword);
        }

        /// <summary>
        /// Проводит проверку всех полей на правильность заполнения, 
        /// в случае успешной проверки, данные пользователя обновляются в бд
        /// </summary>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        private void UpdateUser(PasswordBox password, PasswordBox confirmPassword)
        {
        }

        /// <summary>
        /// Проиводит проверку всех полей на правильность заполнения, 
        /// в случае успешной проверки добаляет данные в бд
        /// </summary>
        /// <param name="password">passwordbox пароля</param>
        /// <param name="confirmPassword">passwordbox подтверждения пароля</param>
        private void AddUser(PasswordBox password, PasswordBox confirmPassword)
        {
            CheckOnExceptions(password.Password, confirmPassword.Password);
        }

        /// <summary>
        /// Добавляет данные пользователя в бд
        /// </summary>
        /// <param name="password"></param>
        private void AddUserInDatabase(string password)
        {
            Password = password;

            var userContract = GetMapUserContract();
            UserList.Add(userContract);

            using (var userService = new UserService())
            {
                userService.AddUser(_mapperDto.GetMapOne(userContract));
            }

            UpdateObservableList();
            CloseWindowCommand.Execute(null);
        }

        /// <summary>
        /// Вызывает openFileDialog для вывода изображения в окно регистрации 
        /// </summary>
        /// <param name="parameter"></param>
        private void AddPhoto(object parameter)
        {
            var openFileDialog = new OpenFileDialog { Filter = @"Файлы изображений |*.png; *.jpg" };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (var stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    Avatar = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }

                PictureName = Path.GetExtension(openFileDialog.FileName);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, @"Ошибка");
            }
        }

        #endregion

        #region Методы проверки данных passwordboxes

        /// <summary>
        /// Проверка паролей главный метод
        /// </summary>
        private void CheckOnExceptions(string password, string confirmPassword)
        {
            ErrorAllFieldsVisibility = Visibility.Collapsed;

            try
            {
                GetCheckFieldsResult(password, confirmPassword);
            }
            catch (InvalidInputFieldException exception)
            {
                ErrorMessage = exception.Message;
                ErrorAllFieldsVisibility = Visibility.Visible;
            }
            catch (InvalidInputPassword exception)
            {
                ToolTypePasswordErrorMessage = exception.Message;
                ErrorMessage = exception.Message;
                ErrorAllFieldsVisibility = Visibility.Visible;
            }
        }

        private void UpdateUserInDatabase(string password, string confirmPassword)
        {
            
        }

        /// <summary>
        /// Проверяет все поля на правильность ввода данных,
        /// в случае прохождения проверки введенные данные добавляются в бд
        /// </summary>
        /// <param name="password">пароль</param>
        /// <param name="confirmPasssword">подтверждающий пароль</param>
        /// <returns></returns>
        private void GetCheckFieldsResult(string password, string confirmPasssword)
        {
            if (Equals(password, string.Empty) || Equals(confirmPasssword, string.Empty) || HasErrorsFields)
                 throw new InvalidInputFieldException();

            if (!Equals(password, confirmPasssword))
                 throw new InvalidInputPassword();

            AddUserInDatabase(password);
        }

        #endregion

        #region Методы (helpers)

        /// <summary>
        /// Объект для отображения данных см. <see cref="MapUserContract"/>
        /// </summary>
        private readonly MapUserContract _mapperUserContract = new MapUserContract();

        /// <summary>
        /// Обновляет список пользователей
        /// </summary>
        private void UpdateObservableList()
        {
            UserList.Clear();

            using (var dataBase = new UserService())
            {
                foreach (var item in _mapperUserContract.GetMapList(dataBase.GetAllUsers()))
                {
                    UserList.Add(item);
                }
            }
        }

        #endregion
    }
}