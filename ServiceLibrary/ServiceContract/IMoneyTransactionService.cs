using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
using System.ServiceModel;

namespace ServiceLibrary
{
    public partial interface IMasterService
    {
        [OperationContract]
        ReturnType<MoneyTransaction> SaveMoneyTransaction(MoneyTransaction entity);
        [OperationContract]
        ReturnType<bool> DeleteMoneyTransactionById(long enity);   
        [OperationContract]
        ReturnType<IList<MoneyTransaction>> GetMoneyTransactionBySourceId(long id);
        [OperationContract]
        ReturnType<IList<MoneyTransaction>> GetMoneyTransactionByDestinationId(long id);
        [OperationContract]
        ReturnType<MoneyTransaction> GetMoneyTransactionById(long id);
      
    }
}
