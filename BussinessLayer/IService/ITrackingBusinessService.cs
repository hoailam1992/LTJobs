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
    
    public interface ITrackingBusinessService : IBusinessServiceBase<Tracking>
    {
        ReturnType<IList<Tracking>> GetTrackingByClientId(long id);
        ReturnType<IList<Tracking>> GetTrackingByBookingId(long id);
        ReturnType<bool> DeleteTrackingById(long enity);
        ReturnType<Tracking> GetTrackingById(long id);
        ReturnType<IList<Tracking>> GetTrackingByProductId(long id);
        ReturnType<IList<Tracking>> GetTrackingByDeliveryId(long id);
    }
}
