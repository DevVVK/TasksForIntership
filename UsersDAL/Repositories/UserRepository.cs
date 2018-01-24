using System.Data.Entity;
using UsersDAL.Entities;
using UsersDAL.Interfaces;
using UsersDAL.Repositories.BaseRepository;

namespace UsersDAL.Repositories
{
    /// <summary>
    /// Класс репозитория для сущности User
    /// </summary>
    public class UserRepository : BaseRepository<User>, IRepository<User>
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public UserRepository()
        {
            Table = UserContext.Users;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Удаляет пользователя из базы
        /// </summary>
        /// <param name="id">идентификатор пользователя</param>
        public void Delete(int id)
        {
            UserContext.Entry(new User {Id = id}).State = EntityState.Deleted;
            SaveChanges();
        }

        #endregion
    }
}