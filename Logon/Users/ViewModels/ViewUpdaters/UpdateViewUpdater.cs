using Logon.Users.ViewModels.Interfaces;

namespace Logon.Users.ViewModels.ViewUpdaters
{
    public class UpdateViewUpdater : IViewUpdater
    {
        #region Закрытые свойства

        /// <summary>
        /// Свойство для настройки окна регистрации под окно обновления данных пользователя
        /// </summary>
        private RegistrationWindow Link { get; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="link">Ссылка на окно регистрации</param>
        public UpdateViewUpdater(RegistrationWindow link)
        {
            Link = link;
        }

        #endregion

        #region Методы
         
        /// <summary>
        /// Метод настройки окна регистрации под окно обновления данных пользователя
        /// </summary>
        public void Update()
        {
            Link.BtnRegistration.Content = "Обновить";
            Link.BtnAddAvatar.Content = "Заменить фото";
        }

        #endregion
    }
}