using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IMoneyTransactionBusinessService : IBusinessServiceBase<moneytransaction>
    {
        ReturnType<bool> DeleteMoneyTransactionById(long enity);
        ReturnType<IList<moneytransaction>> GetMoneyTransactionBySourceId(long id);
        ReturnType<IList<moneytransaction>> GetMoneyTransactionByDestinationId(long id);
        ReturnType<moneytransaction> GetMoneyTransactionById(long id);
    }
}
