using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;

namespace BusinessLayer.Common
{
    public abstract class BusinessServiceBase<TEntity> : IBusinessServiceBase<TEntity>
        where TEntity : ModelBase
    {

        public BusinessServiceBase()
        {

        }

        public ReturnType<IList<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            return UnitOfWorkFactory<UnitOfWorkDB>.Execute(uow =>
            {
                return uow.GetGenericRepository<TEntity>().GetAll(navigationProperties);
            });
        }

        public ReturnType<IList<TEntity>> GetList(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            return UnitOfWorkFactory<UnitOfWorkDB>.Execute(uow =>
            {
                return uow.GetGenericRepository<TEntity>().GetList(where, navigationProperties);
            });
        }

        public ReturnType<TEntity> GetSingle(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            return UnitOfWorkFactory<UnitOfWorkDB>.Execute(uow =>
            {
                return uow.GetGenericRepository<TEntity>().GetSingle(where, navigationProperties);
            });
        }

        public ReturnType<TEntity> GetById(long id)
        {
            return UnitOfWorkFactory<UnitOfWorkDB>.Execute(uow =>
            {
                return uow.GetGenericRepository<TEntity>().GetById(id);
            });
        }

        public ReturnType<TEntity> Add(TEntity entity)
        {
            return UnitOfWorkFactory<UnitOfWorkDB>.ExecuteAndSaveChange(uow =>
            {
                uow.GetGenericRepository<TEntity>().Add(entity);

                return entity;
            });
        }

        public ReturnType<TEntity> Update(TEntity entity)
        {
            return UnitOfWorkFactory<UnitOfWorkDB>.ExecuteAndSaveChange(uow =>
            {
                uow.GetGenericRepository<TEntity>().Update(entity);
                return entity;
            });
        }

        public ReturnType<bool> DeleteById(long id)
        {
            ReturnType<bool> result = new ReturnType<bool>() { IsSuccess = false, Result = false };
            var temp = GetById(id);
            if (temp.IsSuccess && temp.Result != null)
            {
                var resultTemp = Delete(temp.Result);
                if (resultTemp.IsSuccess)
                {
                    result.IsSuccess = true;
                    result.Result = true;
                }
            }
            return result;
        }

        public virtual ReturnType<TEntity> Delete(TEntity entity)
        {
            entity = IncludeEntityBeforeDelete(entity);
            var checkRuleResult = CheckBusinessRuleBeforeDelete(entity);
            if (!checkRuleResult.IsSuccess)
                return checkRuleResult;

            RemoveRelationshipBeforeDelete(entity);

            return UnitOfWorkFactory<UnitOfWorkDB>.ExecuteAndSaveChange<TEntity>(uow =>
            {
                uow.GetGenericRepository<TEntity>().Delete(entity);
                return entity;
            });
        }

        public virtual ReturnType<TEntity> Save(TEntity entity)
        {
            var checkRuleResult = CheckBusinessRuleBeforeSave(entity);
            if (!checkRuleResult.IsSuccess)
                return checkRuleResult;

            return entity.Id > 0 ? Update(entity) : Add(entity);
        }

        public virtual ReturnType<TEntity> CheckBusinessRuleBeforeSave(TEntity bpaym)
        {
            var result = new ReturnType<TEntity> { IsSuccess = true };

            return result;
        }

        public virtual TEntity IncludeEntityBeforeDelete(TEntity entity)
        {
            return entity;
        }

        public virtual ReturnType<TEntity> CheckBusinessRuleBeforeDelete(TEntity entity)
        {
            var result = new ReturnType<TEntity>();
            result.IsSuccess = true;

            foreach (var property in entity.GetType().GetProperties())
            {
                var type = property.PropertyType.Namespace;
                if (type == "System.Collections.Generic")
                {
                    var value = property.GetValue(entity, null);
                    try
                    {
                        var list = ((ICollection)value);
                        if (list != null && list.Count > 0)
                        {
                            result.ErrorMessage = entity.GetType().Name + " has used.";
                            result.IsSuccess = false;
                            break;
                        }
                    }
                    catch
                    {
                    }
                }
            }

            return result;
        }

        public virtual void RemoveRelationshipBeforeDelete(TEntity entity) { }
        public virtual List<Dictionary<string, object>> ExecuteStoreQuery(string storeProc, Dictionary<string, object> paras)
        {
            UnitOfWorkBase unitOfWork = new UnitOfWorkDB();
            DbContext dbContext = unitOfWork.DbContext;
            return ExecuteSelectSqlQuery(dbContext.Database, storeProc, paras);
        }

        private List<Dictionary<string, object>> ExecuteSelectSqlQuery(Database db, string sqlSelect,
           Dictionary<string, object> paras)
        {
            var table = new List<Dictionary<string, object>>();
            db.Connection.Open();
            using (var cmd = db.Connection.CreateCommand())
            {
                cmd.CommandText = sqlSelect;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var param in paras)
                {
                    DbParameter dbp = new SqlParameter(param.Key, param.GetType());
                    dbp.Value = param.Value;
                    cmd.Parameters.Add(dbp);
                }

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (!reader.IsDBNull(i))
                                row[reader.GetName(i)] = reader[i];
                            else
                                row[reader.GetName(i)] = string.Empty;
                        }
                        table.Add(row);
                    }
                }
            }
            return table;
        }
        public virtual List<Dictionary<string, object>> ExecuteQuery(string storeProc)
        {
            UnitOfWorkBase unitOfWork = new UnitOfWorkDB();
            DbContext dbContext = unitOfWork.DbContext;
            return ExecuteSqlQuery(dbContext.Database, storeProc);
        }

        private List<Dictionary<string, object>> ExecuteSqlQuery(Database db, string sqlSelect)
        {
            var table = new List<Dictionary<string, object>>();
            db.Connection.Open();
            using (var cmd = db.Connection.CreateCommand())
            {
                cmd.CommandText = sqlSelect;
                cmd.CommandType = CommandType.Text;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (!reader.IsDBNull(i))
                                row[reader.GetName(i)] = reader[i];
                            else
                                row[reader.GetName(i)] = string.Empty;
                        }
                        table.Add(row);
                    }
                }
            }
            return table;
        }
    }
}
