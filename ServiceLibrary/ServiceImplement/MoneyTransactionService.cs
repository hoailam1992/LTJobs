using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Service;
using BusinessLayer.Common;
using Models;
namespace ServiceLibrary
{
    public partial class MasterService
    {
        public ReturnType<bool> DeleteMoneyTransactionById(long id)
        {
            return (new MoneyTransactionBusinessService()).DeleteById(id);
        }
        public ReturnType<moneytransaction> SaveMoneyTransaction(moneytransaction entity)
        {
            return (new MoneyTransactionBusinessService()).Save(entity);
        }
        public ReturnType<IList<moneytransaction>> GetMoneyTransactionByDestinationId(long id)
        {
            return (new MoneyTransactionBusinessService()).GetMoneyTransactionByDestinationId(id);
        }

        public ReturnType<moneytransaction> GetMoneyTransactionById(long id)
        {
            return (new MoneyTransactionBusinessService()).GetById(id);
        }

        public ReturnType<IList<moneytransaction>> GetMoneyTransactionBySourceId(long id)
        {
            return (new MoneyTransactionBusinessService()).GetMoneyTransactionBySourceId(id);
        }

    }
}
