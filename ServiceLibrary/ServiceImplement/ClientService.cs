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
        public ReturnType<bool> DeleteClientById(long id)
        {
            return (new ClientBusinessService()).DeleteById(id);
        }     
        public ReturnType<client> GetClientByUserId(long id)
        {
            return (new ClientBusinessService()).GetClientByUserId(id);
        }
        public ReturnType<client> GetClientByClientCode(string id)
        {
            return (new ClientBusinessService()).GetClientByClientCode(id);
        }
        public ReturnType<client> SaveClient(client entity)
        {
            return (new ClientBusinessService()).Save(entity);
        }
        public ReturnType<client> GetClientById(long id)
        {
            return (new ClientBusinessService()).GetById(id);
        }
    }
}
