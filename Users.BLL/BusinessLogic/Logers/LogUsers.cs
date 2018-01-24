using System.IO;
using Users.BLL.DTOModels.DTOForDataBase;

namespace Users.BLL.BusinessLogic.Logers
{
    /// <summary>
    /// Класс регистрирующий логины и пароли в файле
    /// </summary>
    public class LogUsers
    {
        #region Закрытые поля

        /// <summary>
        /// Поле содержащее полный путь к файлу
        /// </summary>
        private readonly string _filePath;

        #endregion

        #region Конструторы

        /// <summary>
        /// Стандартный конструктор
        /// </summary>
        /// <param name="filePath">полный путь к файлу</param>
        public LogUsers(string filePath)
        {
            _filePath = filePath;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Добавляет запись в файл
        /// </summary>
        /// <param name="user">добавляемая запись</param>
        public void Add(UserDto user)
        {
            using (var streamWriter = new StreamWriter(_filePath, true))
            {
                streamWriter.WriteLine($"{user.FirstName} {user.LastName} - логин {user.Login} - пароль {user.Password}");
            }
        }

        /// <summary>
        /// Добавляет запись в файл (перегруженный метод Add)
        /// </summary>
        /// <param name="firstName">имя пользователя</param>
        /// <param name="lastName">фамилия пользователя</param>
        /// <param name="login">логин пользователя</param>
        /// <param name="password">пароль пользователя</param>
        public void Add(string firstName, string lastName, string login, string password)
        {
            using (var streamWriter = new StreamWriter(_filePath, true))
            {
                streamWriter.WriteLine($"{firstName} {lastName} - логин {login} - пароль {password}");
            }
        }

        #endregion
    }
}