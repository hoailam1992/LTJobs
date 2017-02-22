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
        ReturnType<Tracking> GetTrackingByBookingId(long id);
        ReturnType<bool> DeleteTrackingById(long enity);
        ReturnType<Tracking> GetTrackingById(long id);       
    }
}
