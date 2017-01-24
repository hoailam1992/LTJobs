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
    public class BookingBusinessService : BusinessServiceBase<Booking>, IBookingBusinessService
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
        public ReturnType<Booking> GetBookingById(long id)
        {
            return GetSingle(c=>c.Id==id,c=>c.Client,c=>c.Delivery,c=>c.Product);
        }
        public ReturnType<IList<Booking>> GetBookingByClientId(long id)
        {
            return GetList(c => c.ClientId == id,c=>c.Product,c=>c.Delivery,c=>c.Client);
        }
        public ReturnType<IList<Booking>> GetBookingByProductId(long id)
        {
            return GetList(c => c.ProductId == id, c => c.Product, c => c.Delivery, c => c.Client);
        }
        public ReturnType<IList<Booking>> GetBookingByDeliveryId(long id)
        {
            return GetList(c => c.DeliveryId == id, c => c.Product, c => c.Delivery, c => c.Client);
        }
      
    }
}
