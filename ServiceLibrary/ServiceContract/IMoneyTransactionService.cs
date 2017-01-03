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
        ReturnType<moneytransaction> SaveMoneyTransaction(moneytransaction entity);
        [OperationContract]
        ReturnType<bool> DeleteMoneyTransactionById(long enity);   
        [OperationContract]
        ReturnType<IList<moneytransaction>> GetMoneyTransactionBySourceId(long id);
        [OperationContract]
        ReturnType<IList<moneytransaction>> GetMoneyTransactionByDestinationId(long id);
        [OperationContract]
        ReturnType<moneytransaction> GetMoneyTransactionById(long id);
    }
}
