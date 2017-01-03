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
    public class ClientCommentBusinessService : BusinessServiceBase<clientcomment>, IClientCommentBusinessService
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
        public ReturnType<IList<clientcomment>> GetClientCommentByClientId(long id)
        {
            return GetList(c => c.clientid == id);
        }
        public ReturnType<IList<clientcomment>> GetClientCommentByProductId(long id)
        {
            return GetList(c => c.memberid == id);
        }
        public ReturnType<IList<clientcomment>> GetClientCommentByDeliveryId(long id)
        {
            return GetList(c => c.deliveryid == id);
        }

    }
}
