using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
using System.Collections.ObjectModel;

namespace BusinessLayer.IService
{
    
    public interface IBookingBusinessService : IBusinessServiceBase<Booking>
    {
        ReturnType<IList<Booking>> GetBookingByClientId(long id);
        ReturnType<bool> DeleteBookingById(long enity);
        ReturnType<Booking> GetBookingById(long id);
        ReturnType<IList<Booking>> GetBookingByProductId(long id);
        ReturnType<IList<Booking>> GetBookingByDeliveryId(long id);
    }
}
