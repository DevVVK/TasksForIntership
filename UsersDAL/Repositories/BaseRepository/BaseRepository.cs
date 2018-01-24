using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using UsersDAL.EF;

namespace UsersDAL.Repositories.BaseRepository
{
    /// <summary>
    /// Базовый класс для работы с базой данных. Реализованы операции CRUD
    /// </summary>
    /// <typeparam name="TEntity">тип сущности</typeparam>
    public class BaseRepository<TEntity> : IDisposable where TEntity : class, new()
    {
        #region Открытые поля

        /// <summary>
        /// Свойство возвращающее контекст для работы с бд
        /// </summary>
        public UserEntities UserContext { get; } = new UserEntities();

        #endregion

        #region Поля для наследников

        /// <summary>
        /// Поле сущности бд(для наследуемых классов)
        /// </summary>
        protected DbSet<TEntity> Table;

        #endregion

        #region Методы

        /// <summary>
        /// Добавляет <see cref="TEntity"/> в бд
        /// </summary>
        /// <param name="entity">сущность</param>
        public void Add(TEntity entity)
        {
            Table.Add(entity);
            SaveChanges();
        }

        /// <summary>
        /// Добавляет список <see cref="TEntity"/>> в бд
        /// </summary>
        /// <param name="entity">список <see cref="TEntity"/>></param>
        public void AddRange(IList<TEntity> entity)
        {
            Table.AddRange(entity);
            SaveChanges();
        }

        /// <summary>
        /// Обновляет <see cref="TEntity"/> в бд
        /// </summary>
        /// <param name="entity">сущность</param>
        public void Update(TEntity entity)
        {
            UserContext.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Удаляет <see cref="TEntity"/>
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            UserContext.Entry(entity).State = EntityState.Deleted;
            SaveChanges();
        }

        /// <summary>
        /// Получает список всех <see cref="TEntity"/>
        /// </summary>
        /// <returns><see cref="TEntity"/></returns>
        public List<TEntity> GetAll() => Table.ToList();

        /// <summary>
        /// Получает <see cref="TEntity"/>>
        /// </summary>
        /// <param name="id"><see cref="TEntity"/></param>
        /// <returns></returns>
        public TEntity GetOne(int id) => Table.Find(id);

        /// <summary>
        /// Получает <see cref="TEntity"/> посредством sql запроса
        /// </summary>
        /// <param name="query">sql запрос</param>
        /// <returns><see cref="TEntity"/></returns>
        public List<TEntity> SqlQueryExecute(string query) => Table.SqlQuery(query).ToList();

        /// <summary>
        /// Получает <see cref="TEntity"/> посредством sql запроса с параметрами
        /// </summary>
        /// <param name="query">sql запрос</param>
        /// <param name="sqlParameterObjects">параметры sql запроса</param>
        /// <returns><see cref="TEntity"/>></returns>
        public List<TEntity> SqlQueryExecute(string query, object[] sqlParameterObjects) => Table.SqlQuery(query, sqlParameterObjects).ToList();

        /// <summary>
        /// Получает список <see cref="TEntity"/> удовлетворяющих условию поиска
        /// </summary>
        /// <param name="predicate">условие поиска</param>
        /// <returns>список <see cref="TEntity"/></returns>
        public List<TEntity> Find(Func<TEntity, bool> predicate) => Table.Where(predicate).ToList();

        #endregion

        #region Методы (helpers)

        /// <summary>
        /// Сохраняет данные в базе
        /// </summary>
        internal void SaveChanges()
        {
            try
            {
                UserContext.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.Message, "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private bool _disposing = false;

        /// <summary>
        /// Очищает ресурсы
        /// </summary>
        /// <param name="disposed">true - если ощищает пользователь, false - если очищает GC</param>
        public virtual void Dispose(bool disposed)
        {
            if (!_disposing)
            {
                if (disposed)
                {
                    UserContext.Dispose();
                }

                _disposing = true;
            }
        }

        /// <summary>
        /// Очищает ресурсы
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        #endregion
    }
}