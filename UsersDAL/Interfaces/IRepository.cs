using System;
using System.Collections.Generic;

namespace UsersDAL.Interfaces
{
    /// <summary>
    /// Интерфейс взаимодействия с бд
    /// </summary>
    /// <typeparam name="TEntity">сущность бд</typeparam>
    public interface IRepository <TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void AddRange(IList<TEntity> entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(int id);

        List<TEntity> GetAll();

        TEntity GetOne(int id);

        List<TEntity> SqlQueryExecute(string query);

        List<TEntity> SqlQueryExecute(string query, object[] sqlParameterObjects);

        List<TEntity> Find(Func<TEntity, Boolean> predicate);
    }
}