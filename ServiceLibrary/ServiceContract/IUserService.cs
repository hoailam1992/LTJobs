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
        ReturnType<user> SaveUser(user entity);      
        [OperationContract]
        ReturnType<user> LoginUser(string user,string password);
        //[OperationContract]
        //ReturnType<user> GetUserByDeliveryId(long id);
        //[OperationContract]
        //ReturnType<user> GetUserByProductId(long id);
        [OperationContract]
        ReturnType<user> GetUserById(long id);
    }
}
