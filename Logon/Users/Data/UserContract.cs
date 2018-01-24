using System;
using System.Windows.Media.Imaging;

namespace Logon.Users.Data
{
    /// <summary>
    /// Класс модель для отображения данных в представлении 
    /// </summary>
    public class UserContract
    {
        #region Открытые свойства

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Password { get; set; }

        public string Gender { get; set; }

        public DateTime DateBirth { get; set; }

        public string Login { get; set; }

        public string ExtensionPicture { get; set; }

        public BitmapSource Avatar { get; set; }

        #endregion
    }
}