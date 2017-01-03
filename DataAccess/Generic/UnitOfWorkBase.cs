using Models.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DataAccess
{
    public abstract class UnitOfWorkBase : IUnitOfWorkBase, IDisposable
    {
        private DbContext dbContext;

        private Dictionary<Type, object> genericRepositories = new Dictionary<Type, object>();

        private bool disposed = false;

        public string ConnString
        {
            get;
            set;
        }

        public DbContext DbContext
        {
            get
            {
                return this.dbContext;
            }
            set
            {
                this.dbContext = value;
            }
        }

        public UnitOfWorkBase(string Name = "")
        {
            this.ConnString = Name;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.dbContext != null)
                    {
                        this.dbContext.Dispose();
                        this.dbContext = null;
                    }
                }
            }
            this.disposed = true;
        }

        public IGenericRepository<TEntity> GetGenericRepository<TEntity>()
        where TEntity : ModelBase
        {
            IGenericRepository<TEntity> item;
            if (!this.genericRepositories.Keys.Contains<Type>(typeof(TEntity)))
            {
                GenericRepository<TEntity> genericRepository = new GenericRepository<TEntity>(this.dbContext);
                this.genericRepositories.Add(typeof(TEntity), genericRepository);
                item = genericRepository;
            }
            else
            {
                item = this.genericRepositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }
            return item;
        }

        public virtual void OnSavingChanges(object sender, EventArgs e)
        {
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}