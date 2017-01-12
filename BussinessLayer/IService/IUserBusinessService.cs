using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IUserBusinessService : IBusinessServiceBase<User>
    {
        ReturnType<User> LoginUser(string username, string password);
        ReturnType<bool> CheckUserName(string username);
    }
}
