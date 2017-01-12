using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ServiceLibrary
{
    public partial interface IMasterService
    {
        [OperationContract]
        ReturnType<User> SaveUser(User entity);      
        [OperationContract]
        ReturnType<User> LoginUser(string user,string password);
        //[OperationContract]
        //ReturnType<user> GetUserByDeliveryId(long id);
        //[OperationContract]
        //ReturnType<user> GetUserByProductId(long id);
        [OperationContract]
        ReturnType<User> GetUserById(long id);
        [OperationContract]
        ReturnType<bool> CheckUserName(string username);
        [OperationContract]
        ReturnType<User> RegisterUser(User entity);
    }
}
