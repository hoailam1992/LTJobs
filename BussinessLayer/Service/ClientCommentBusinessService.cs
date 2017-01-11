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
    public class ClientCommentBusinessService : BusinessServiceBase<ClientComment>, IClientCommentBusinessService
    {
        public ReturnType<bool> DeleteClientCommentById(long enity)
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
        public ReturnType<IList<ClientComment>> GetClientCommentByClientId(long id)
        {
            return GetList(c => c.ClientId == id);
        }
        public ReturnType<IList<ClientComment>> GetClientCommentByProductId(long id)
        {
            return GetList(c => c.ProductId == id);
        }
        public ReturnType<IList<ClientComment>> GetClientCommentByDeliveryId(long id)
        {
            return GetList(c => c.DeliveryId == id);
        }

    }
}
