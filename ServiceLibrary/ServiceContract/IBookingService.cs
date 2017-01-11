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
        ReturnType<IList<Booking>> GetAllBooking();
        [OperationContract]
        ReturnType<IList<Booking>> GetBookingByClientId(long id);
        [OperationContract]
        ReturnType<IList<Booking>> GetBookingByDeliveryId(long id);
        [OperationContract]
        ReturnType<IList<Booking>> GetBookingByProductId(long id);
        [OperationContract]
        ReturnType<Booking> SaveBooking(Booking entity);
        [OperationContract]
        ReturnType<bool> DeleteBookingById(long enity);       
        [OperationContract]
        ReturnType<Booking> GetBookingById(long id);
    }
}
