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
        ReturnType<Client> SaveClient(Client entity);
        [OperationContract]
        ReturnType<bool> DeleteClientById(long id);
        [OperationContract]
        ReturnType<Client> GetClientByUserId(long id);
        [OperationContract]
        ReturnType<Client> GetClientById(long id);
        [OperationContract]
        ReturnType<Client> GetClientByClientCode(string id);
    }
}
