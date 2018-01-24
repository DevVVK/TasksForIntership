using UsersDAL.Entities;

namespace UsersDAL.EF
{
    using System.Data.Entity;

    /// <summary>
    /// Контекст взаимодействия с бд
    /// </summary>
    public class UserEntities : DbContext
    {
        #region Открытые поля

        /// <summary>
        /// Свойсвто возвращающее набор данных <see cref="User"/>>
        /// </summary>
        public DbSet<User> Users { get; set; }

        #endregion

        #region Конструторы

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public UserEntities() : base("name=UsersConnection")
        {
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод построения модели
        /// </summary>
        /// <param name="modelBuilder">строитель модели</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //заменить тип столбца DateBirth на "datetime2" для корректного отображения столбцов
            modelBuilder.Entity<User>().Property(p => p.DateBirth).HasColumnType("datetime2").IsRequired();
        }

        #endregion
    }
}