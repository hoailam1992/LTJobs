using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ServiceLibrary
{
    
    public partial interface IMasterService
    {
        [OperationContract]        
        ReturnType<IList<Tracking>> GetAllTracking();       
        [OperationContract]
        ReturnType<Tracking> GetTrackingByBookingId(long id);
        [OperationContract]
        ReturnType<Tracking> SaveTracking(Tracking entity);
        [OperationContract]
        ReturnType<bool> DeleteTrackingById(long enity);       
        [OperationContract]
        ReturnType<Tracking> GetTrackingById(long id);       
    }
}
