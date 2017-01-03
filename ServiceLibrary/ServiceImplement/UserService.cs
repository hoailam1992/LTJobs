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
        public ReturnType<user> SaveUser(user entity)
        {
            return (new UserBusinessService()).Save(entity);
        }
        public ReturnType<user> GetUserById(long id)
        {
            return (new UserBusinessService()).GetById(id);
        }
        public ReturnType<user> LoginUser(string user, string password)
        {
            return (new UserBusinessService()).LoginUser(user, password);
        }
    }
}
