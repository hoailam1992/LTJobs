using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;
using Models.Common;

namespace BusinessLayer.Common
{
    public interface IBusinessServiceBase<TEntity>
        where TEntity : ModelBase
    {
        ReturnType<IList<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties);
        ReturnType<IList<TEntity>> GetList(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties);
        ReturnType<TEntity> GetSingle(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties);
        ReturnType<TEntity> GetById(long id);

        ReturnType<TEntity> Add(TEntity entity);
        ReturnType<TEntity> Update(TEntity entity);
        ReturnType<TEntity> Delete(TEntity entity);
        ReturnType<TEntity> Save(TEntity entity);
    }
}
