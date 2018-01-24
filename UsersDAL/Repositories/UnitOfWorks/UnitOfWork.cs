using System;

namespace UsersDAL.Repositories.UnitOfWorks
{
    /// <summary>
    /// Класс объединяющий все классы репозитории (паттерн UnitOfWork(Единица работы))
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Закрытые поля

        /// <summary>
        /// Класс-репозиторий для сущности см. <see cref="User"/>
        /// </summary>
        private UserRepository _userRepository;

        #endregion

        #region Открытые поля

        /// <summary>
        /// Свойство возвращающее обьект репозиторий для работы с сущностью <see cref="User"/>
        /// </summary>
        public UserRepository Users => _userRepository ?? (_userRepository = new UserRepository());

        #endregion

        #region Методы

        /// <summary>
        /// Очистка памяти
        /// </summary>
        public void Dispose()
        {
            _userRepository?.Dispose();
        }

        #endregion
    }
}