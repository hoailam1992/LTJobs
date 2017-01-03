using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IClientBusinessService : IBusinessServiceBase<client>
    {
        ReturnType<bool> DeleteClientById(long enity);
        ReturnType<client> GetClientByUserId(long id);
        ReturnType<client> GetClientByClientCode(string id);
    }
}
