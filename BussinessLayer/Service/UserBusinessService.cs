using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.IService;
using BusinessLayer.Common;
using Models;
namespace BusinessLayer.Service
{
    public class UserBusinessService : BusinessServiceBase<user>, IUserBusinessService
    {
        public ReturnType<user> LoginUser(string username, string password)
        {
            var user = GetSingle(c => c.username == username && c.password == password);
            if (user.IsSuccess && user.Result!=null)
            {
                user.Result.password = "";
                user.Result.securityanswer = "";
                return user;                
            }
            return new ReturnType<Models.user>() { IsSuccess = false, Result = null, ErrorMessage = "Login Fails" };
        }
    }
}
