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
        public ReturnType<Client> GetClientByUserId(long id)
        {
            return (new ClientBusinessService()).GetClientByUserId(id);
        }
        public ReturnType<Client> GetClientByClientCode(string id)
        {
            return (new ClientBusinessService()).GetClientByClientCode(id);
        }
        public ReturnType<Client> SaveClient(Client entity)
        {
            entity.Code = entity.Code ?? "CLT" + DateTime.Now;
            return (new ClientBusinessService()).Save(entity);
        }
        public ReturnType<Client> GetClientById(long id)
        {
            return (new ClientBusinessService()).GetById(id);
        }
    }
}
