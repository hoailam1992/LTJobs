using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.IService;
using BusinessLayer.Common;
using Models;
namespace BusinessLayer.Service
{
    public class MoneyTransactionBusinessService : BusinessServiceBase<MoneyTransaction>, IMoneyTransactionBusinessService
    {
        public ReturnType<bool> DeleteMoneyTransactionById(long enity)
        {
            ReturnType<bool> result = new ReturnType<bool>() { IsSuccess = false, Result = false };
            var temp = GetById(enity);
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
        public ReturnType<MoneyTransaction> SaveMoneyTransaction(MoneyTransaction entity)
        {
            if (entity.Id > 0)
            {
                entity.ModifiedDate = DateTime.Now;
            }
            return this.Save(entity);
        }
        public ReturnType<MoneyTransaction> GetTransactionById(long id)
        {
            return GetSingle(c => c.Id == id, c => c.User, c => c.User1,c=>c.Tracking);
        }
        public ReturnType<IList<MoneyTransaction>> GetMoneyTransactionByDestinationId(long id)
        {
            return GetList(c => c.DestinationId == id,c=>c.User,c=>c.User1);
        }
        public ReturnType<IList<MoneyTransaction>> GetMoneyTransactionByTrackingId(long id)
        {
            return GetList(c => c.TrackingId == id, c => c.User, c => c.User1);
        }
        public ReturnType<MoneyTransaction> GetMoneyTransactionById(long id)
        {
            return GetSingle(c => c.Id == id, c => c.User, c => c.User1);
        }

        public ReturnType<IList<MoneyTransaction>> GetMoneyTransactionBySourceId(long id)
        {
            return GetList(c => c.SourceId == id, c => c.User, c => c.User1);
        }
             
    }
}
