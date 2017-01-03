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
        ReturnType<client> SaveClient(client entity);
        [OperationContract]
        ReturnType<bool> DeleteClientById(long id);
        [OperationContract]
        ReturnType<client> GetClientByUserId(long id);
        [OperationContract]
        ReturnType<client> GetClientById(long id);
        [OperationContract]
        ReturnType<client> GetClientByClientCode(string id);
    }
}
