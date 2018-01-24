using System;
using System.Windows.Media.Imaging;

namespace Users.BLL.DTOModels.DTOForDataBase
{
    /// <summary>
    /// Класс модель отображения для см. <see cref="User"/>
    /// </summary>
    public class UserDto
    {
        #region Открытые свойства

        /// <summary>
        /// Идентификатор пользователя 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Дата рождения пользователя
        /// </summary>
        public DateTime DateBirth { get; set; }

        /// <summary>
        /// Пол пользователя
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Имя файла фотографии
        /// </summary>
        public string ExtensionPicture { get; set; }

        /// <summary>
        /// Фото пользователя
        /// </summary>
        public BitmapSource Avatar { get; set; }

        #endregion
    }
}