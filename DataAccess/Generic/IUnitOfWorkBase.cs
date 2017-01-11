using Models;
using System;

namespace DataAccess
{
    public interface IUnitOfWorkBase : IDisposable
    {
      
        IGenericRepository<TEntity> GetGenericRepository<TEntity>()
        where TEntity : ModelBase;

        void SaveChanges();
    }
}