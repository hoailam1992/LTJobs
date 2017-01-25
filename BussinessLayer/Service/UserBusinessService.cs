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
    public class UserBusinessService : BusinessServiceBase<User>, IUserBusinessService
    {
        public ReturnType<User> LoginUser(string username, string password)
        {
            var user = GetSingle(c => c.UserName == username && c.Password == password);
            if (user.IsSuccess && user.Result != null)
            {
                user.Result.Password = "";
                user.Result.SecurityAnswer = "";
                return user;
            }
            return new ReturnType<User>() { IsSuccess = false, Result = null, ErrorMessage = "Login Fails" };
        }

        public ReturnType<bool> CheckUserName(string username)
        {
            return new ReturnType<bool>() { IsSuccess = true, Result = GetSingle(c => c.UserName == username).Result == null };
        }
        public ReturnType<User> GetUserInfoById(long id)
        {
            var result = GetById(id);
            if (result.Result != null)
            {
                result.Result.Password = null;
                result.Result.SecurityAnswer = null;
                result.Result.SecurityQuestionId = 0;
                result.Result.GCMkey = null;
            }
            return result;
        }
    }
}
