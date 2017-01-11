using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public interface IGenericRepository<TEntity>
    where TEntity : ModelBase
    {
        void Add(TEntity entity);

        void Delete(TEntity entities);

        //IList<TEntity> ExecuteStoreQuery(string storeProc, params object[] parameters);

        IList<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties);

        TEntity GetById(object id);

        IList<TEntity> GetList(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties);

        IQueryable<TEntity> GetQuery(params Expression<Func<TEntity, object>>[] navigationProperties);

        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties);

        TEntity GetSingle(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties);

        void Update(TEntity entities);
    }
}