using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace ServiceLibrary
{
    
    public partial interface IMasterService
    {
        [OperationContract]
        ReturnType<IList<booking>> GetAllBooking();
        [OperationContract]
        ReturnType<IList<booking>> GetBookingByClientId(long id);
        [OperationContract]
        ReturnType<IList<booking>> GetBookingByDeliveryId(long id);
        [OperationContract]
        ReturnType<IList<booking>> GetBookingByProductId(long id);
        [OperationContract]
        ReturnType<booking> SaveBooking(booking entity);
        [OperationContract]
        ReturnType<bool> DeleteBookingById(long enity);       
        [OperationContract]
        ReturnType<booking> GetBookingById(long id);
    }
}
