
using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Reflection;

namespace DataAccess
{
    public class UnitOfWorkFactory<TUnitOfWork>
    where TUnitOfWork : UnitOfWorkBase, new()
    {
  
        public UnitOfWorkFactory()
        {          
        }

        private static ReturnType<TEntity> DoExecute<TEntity>(Func<IUnitOfWorkBase, TEntity> func, bool isSaveChange)
        where TEntity : ModelBase
        {
            IUnitOfWorkBase unitOfWorkHbf;
            string allValidationErrors;
            ReturnType<TEntity> returnType = new ReturnType<TEntity>();           
                unitOfWorkHbf = Activator.CreateInstance<TUnitOfWork>();            
            try
            {
                try
                {
                    returnType.Result=(func(unitOfWorkHbf));
                    if (isSaveChange)
                    {
                        unitOfWorkHbf.SaveChanges();
                    }
                    returnType.IsSuccess = (true);
                }
                catch (DbEntityValidationException dbEntityValidationException)
                {
                    allValidationErrors = dbEntityValidationException.EntityValidationErrors.ToString();
                    returnType.ErrorMessage = (allValidationErrors);
                    
                }
                catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
                {
                    allValidationErrors = dbUpdateConcurrencyException.Message;
                    returnType.ErrorMessage =(allValidationErrors);
                    
                }
                catch (DbUpdateException dbUpdateException)
                {
                    allValidationErrors = dbUpdateException.Message;
                    returnType.ErrorMessage = (allValidationErrors);
                    
                }
                catch (Exception exception)
                {
                    allValidationErrors = exception.Message;
                    returnType.ErrorMessage =allValidationErrors;                    
                }
            }
            finally
            {
                unitOfWorkHbf.Dispose();
                unitOfWorkHbf = null;
            }
            return returnType;
        }

        private static ReturnType<IList<TEntity>> DoExecute<TEntity>(Func<IUnitOfWorkBase, IList<TEntity>> func, bool isSaveChange)
        where TEntity : ModelBase
        {
            IUnitOfWorkBase unitOfWorkHbf;
            string allValidationErrors;
            ReturnType<IList<TEntity>> returnType = new ReturnType<IList<TEntity>>();           
                unitOfWorkHbf = Activator.CreateInstance<TUnitOfWork>();            
            try
            {
                try
                {
                    returnType.Result = (func(unitOfWorkHbf));
                    if (isSaveChange)
                    {
                        unitOfWorkHbf.SaveChanges();
                    }
                    returnType.IsSuccess=(true);
                }
                catch (DbEntityValidationException dbEntityValidationException)
                {
                    allValidationErrors = dbEntityValidationException.EntityValidationErrors.ToString();
                    returnType.ErrorMessage = (allValidationErrors);

                }
                catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
                {
                    allValidationErrors = dbUpdateConcurrencyException.Message;
                    returnType.ErrorMessage = (allValidationErrors);

                }
                catch (DbUpdateException dbUpdateException)
                {
                    allValidationErrors = dbUpdateException.Message;
                    returnType.ErrorMessage = (allValidationErrors);

                }
                catch (Exception exception)
                {
                    allValidationErrors = exception.Message;
                    returnType.ErrorMessage = allValidationErrors;
                }
            }
            finally
            {
                unitOfWorkHbf.Dispose();
                unitOfWorkHbf = null;
            }
            return returnType;
        }

        public static ReturnType<TEntity> Execute<TEntity>(Func<IUnitOfWorkBase, TEntity> func)
        where TEntity : ModelBase
        {
            return UnitOfWorkFactory<TUnitOfWork>.DoExecute<TEntity>(func, false);
        }

        public static ReturnType<IList<TEntity>> Execute<TEntity>(Func<IUnitOfWorkBase, IList<TEntity>> func)
        where TEntity : ModelBase
        {
            return UnitOfWorkFactory<TUnitOfWork>.DoExecute<TEntity>(func, false);
        }

        public static ReturnType<TEntity> ExecuteAndSaveChange<TEntity>(Func<IUnitOfWorkBase, TEntity> func)
        where TEntity : ModelBase
        {
            return UnitOfWorkFactory<TUnitOfWork>.DoExecute<TEntity>(func, true);
        }

        public static ReturnType<IList<TEntity>> ExecuteAndSaveChange<TEntity>(Func<IUnitOfWorkBase, IList<TEntity>> func)
        where TEntity : ModelBase
        {
            return UnitOfWorkFactory<TUnitOfWork>.DoExecute<TEntity>(func, false);
        }
    }
}