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
    public class MoneyTransactionBusinessService : BusinessServiceBase<moneytransaction>, IMoneyTransactionBusinessService
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

        public ReturnType<IList<moneytransaction>> GetMoneyTransactionByDestinationId(long id)
        {
            return GetList(c => c.destinationid == id,c=>c.user,c=>c.user1);
        }

        public ReturnType<moneytransaction> GetMoneyTransactionById(long id)
        {
            return GetSingle(c => c.id == id, c => c.user, c => c.user1);
        }

        public ReturnType<IList<moneytransaction>> GetMoneyTransactionBySourceId(long id)
        {
            return GetList(c => c.sourceid == id, c => c.user, c => c.user1);
        }
             
    }
}
