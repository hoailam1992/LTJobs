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
    
    public interface IBookingBusinessService : IBusinessServiceBase<booking>
    {
        ReturnType<IList<booking>> GetBookingByClientId(long id);
        ReturnType<bool> DeleteBookingById(long enity);
        ReturnType<booking> GetBookingById(long id);
        ReturnType<IList<booking>> GetBookingByProductId(long id);
        ReturnType<IList<booking>> GetBookingByDeliveryId(long id);
    }
}
