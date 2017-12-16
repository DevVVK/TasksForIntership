using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using UsersDAL.EF;
using UsersDAL.Interfaces;

namespace UsersDAL.Repositories.BaseRepository
{
    public class BaseRepository<TEntity> : IDisposable where TEntity : class, new()
    {
        public UserEntities UserContext { get; } = new UserEntities();

        protected DbSet<TEntity> Table;

        public void Add(TEntity entity)
        {
            Table.Add(entity);
            SaveChanges();
        }

        public void AddRange(IList<TEntity> entity)
        {
            Table.AddRange(entity);
            SaveChanges();
        }

        public void Update(TEntity entity)
        {
            UserContext.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            UserContext.Entry(entity).State = EntityState.Deleted;
            SaveChanges();
        }

        public List<TEntity> GetAll() => Table.ToList();

        public TEntity GetOne(int id) => Table.Find(id);

        public List<TEntity> SqlQueryExecute(string query) => Table.SqlQuery(query).ToList();

        public List<TEntity> SqlQueryExecute(string query, object[] sqlParameterObjects) => Table.SqlQuery(query, sqlParameterObjects).ToList();

        public List<TEntity> Find(Func<TEntity, bool> predicate) => Table.Where(predicate).ToList();

        internal void SaveChanges()
        {
            try
            {
                UserContext.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private bool _disposing = false;

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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }
    }
}