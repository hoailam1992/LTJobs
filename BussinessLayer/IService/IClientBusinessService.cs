using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IClientBusinessService : IBusinessServiceBase<Client>
    {
        ReturnType<bool> DeleteClientById(long enity);
        ReturnType<Client> GetClientByUserId(long id);
        ReturnType<Client> GetClientByClientCode(string id);
    }
}
