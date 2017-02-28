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
        public ReturnType<MoneyTransaction> SaveMoneyTransaction(MoneyTransaction entity)
        {
            return (new MoneyTransactionBusinessService()).SaveMoneyTransaction(entity);
        }
        public ReturnType<IList<MoneyTransaction>> GetMoneyTransactionByDestinationId(long id)
        {
            return (new MoneyTransactionBusinessService()).GetMoneyTransactionByDestinationId(id);
        }

        public ReturnType<MoneyTransaction> GetMoneyTransactionById(long id)
        {
            return (new MoneyTransactionBusinessService()).GetMoneyTransactionById(id);
        }

        public ReturnType<IList<MoneyTransaction>> GetMoneyTransactionBySourceId(long id)
        {
            return (new MoneyTransactionBusinessService()).GetMoneyTransactionBySourceId(id);
        }
        public ReturnType<IList<MoneyTransaction>> GetMoneyTransactionByTrackingId(long id) {
            return (new MoneyTransactionBusinessService()).GetMoneyTransactionByTrackingId(id);
        }
        public ReturnType<MoneyTransaction> SaveMoneyTransactionDeposit(MoneyTransaction entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.Code = "DP" + entity.CreatedDate;
            entity.ModifiedDate = DateTime.Now;
            entity.PaymentDate = DateTime.Now;
            entity.Remark = "Deposit from client";
            entity.DestinationId = entity.SourceId;
            entity.Trandate = DateTime.Now;
            entity.Status = "O";
            return (new MoneyTransactionBusinessService()).Save(entity);
        }
    }
}
