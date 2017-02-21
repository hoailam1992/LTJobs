using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IMoneyTransactionBusinessService : IBusinessServiceBase<MoneyTransaction>
    {
        ReturnType<bool> DeleteMoneyTransactionById(long enity);
        ReturnType<IList<MoneyTransaction>> GetMoneyTransactionBySourceId(long id);
        ReturnType<IList<MoneyTransaction>> GetMoneyTransactionByDestinationId(long id);
        ReturnType<MoneyTransaction> GetMoneyTransactionById(long id);
        ReturnType<MoneyTransaction> SaveMoneyTransaction(MoneyTransaction entity);
    }
}
