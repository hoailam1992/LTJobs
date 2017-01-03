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
    public class BookingBusinessService : BusinessServiceBase<booking>, IBookingBusinessService
    {
        public ReturnType<bool> DeleteBookingById(long enity)
        {
            ReturnType<bool> result = new ReturnType<bool>() {IsSuccess = false,Result=false };
            var temp = GetById(enity);
            if (temp.IsSuccess && temp.Result !=null)
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
        public ReturnType<booking> GetBookingById(long id)
        {
            return GetById(id);
        }
        public ReturnType<IList<booking>> GetBookingByClientId(long id)
        {
            return GetList(c => c.clientid == id,c=>c.product,c=>c.delivery,c=>c.client);
        }
        public ReturnType<IList<booking>> GetBookingByProductId(long id)
        {
            return GetList(c => c.productid == id, c => c.product, c => c.delivery, c => c.client);
        }
        public ReturnType<IList<booking>> GetBookingByDeliveryId(long id)
        {
            return GetList(c => c.deliveryid == id, c => c.product, c => c.delivery, c => c.client);
        }
      
    }
}
