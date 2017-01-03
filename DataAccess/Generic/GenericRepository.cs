using Models.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;


namespace DataAccess
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : ModelBase
    {
        private readonly DbSet<TEntity> dbSet;

        private readonly DbContext dbContext;

        public GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            this.dbSet.Attach(entity);
            this.dbSet.Remove(entity);
        }
        //public IList<TEntity> ExecuteStoreQuery(string storeProc, params object[] parameters) {
        //    ObjectContext objectcontext = this.dbContext.GetType().;
        //}
        public IList<TEntity> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IList<TEntity> list = QueryableExtensions.AsNoTracking<TEntity>(this.GetQuery(navigationProperties)).ToList<TEntity>();
            return list;
        }

        public TEntity GetById(object id)
        {
            return this.dbSet.Find(new object[] { id });
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IList<TEntity> list = QueryableExtensions.AsNoTracking<TEntity>(this.GetQuery(navigationProperties)).Where<TEntity>(where).ToList<TEntity>();
            return list;
        }

        public IQueryable<TEntity> GetQuery(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> tEntities = this.dbSet;
            Expression<Func<TEntity, object>>[] expressionArray = navigationProperties;
            for (int i = 0; i < (int)expressionArray.Length; i++)
            {
                tEntities = QueryableExtensions.Include<TEntity, object>(tEntities, expressionArray[i]);
            }
            return tEntities;
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            return this.GetQuery(navigationProperties).Where<TEntity>(where);
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            TEntity tEntity = QueryableExtensions.AsNoTracking<TEntity>(this.GetQuery(navigationProperties)).FirstOrDefault<TEntity>(where);
            return tEntity;
        }

        public void Update(TEntity entity)
        {
            DbEntityEntry<TEntity> dbEntityEntry = this.dbContext.Entry<TEntity>(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet<TEntity> dbSet = this.dbContext.Set<TEntity>();
                object[] id = new object[] { entity.id };
                TEntity tEntity = dbSet.Find(id);
                if (tEntity == null)
                {
                    dbEntityEntry.State = EntityState.Modified;
                }
                else
                {
                    DbEntityEntry<TEntity> dbEntityEntry1 = this.dbContext.Entry<TEntity>(tEntity);
                    dbEntityEntry1.CurrentValues.SetValues(entity);                    
                }
            }
        }
    }
}