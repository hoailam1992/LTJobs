using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Service;
using BusinessLayer.Common;
using Models;
using System.ServiceModel.Activation;

namespace ServiceLibrary
{
    [AspNetCompatibilityRequirements(RequirementsMode =AspNetCompatibilityRequirementsMode.Allowed)]
    public partial class MasterService
    {
        public ReturnType<User> SaveUser(User entity)
        {
            return (new UserBusinessService()).Save(entity);
        }
        public ReturnType<User> GetUserById(long id)
        {
            return (new UserBusinessService()).GetById(id);
        }
        public ReturnType<User> LoginUser(string user, string password)
        {
            return (new UserBusinessService()).LoginUser(user, password);
        }
    }
}
