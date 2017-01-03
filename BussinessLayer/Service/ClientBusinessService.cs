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
    public class ClientBusinessService : BusinessServiceBase<client>, IClientBusinessService
    {
        public ReturnType<bool> DeleteClientById(long enity)
        {
            ReturnType<bool> result = new ReturnType<bool>() { IsSuccess = false, Result = false };
            var temp = GetById(enity);
            if (temp.IsSuccess && temp.Result != null)
            {
                var resultTemp = Delete(temp.Result);
                if (resultTemp.IsSuccess)
                {
                    result.IsSuccess = true;
                    result.Result = true;
                }
            }
            return result;
        }     
        public ReturnType<client> GetClientByUserId(long id)
        {
            return GetSingle(c => c.userid == id);
        }
        public ReturnType<client> GetClientByClientCode(string id)
        {
            return GetSingle(c => c.clientcode == id);
        }

    }
}
