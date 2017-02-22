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
    public class TrackingBusinessService : BusinessServiceBase<Tracking>, ITrackingBusinessService
    {
        public ReturnType<bool> DeleteTrackingById(long enity)
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
        public ReturnType<Tracking> GetTrackingById(long id)
        {
            return GetSingle(c=>c.Id==id,c=>c.Booking);
        }
        public ReturnType<Tracking> GetTrackingByBookingId(long id)
        {
            return GetSingle(c => c.BookingId == id,c=>c.Booking);
        }       

    }
}
