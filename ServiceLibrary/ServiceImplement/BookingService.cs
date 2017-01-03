using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Service;
using BusinessLayer.Common;
using Models;
using ServiceLibrary;
namespace ServiceLibrary
{
    public partial class MasterService
    {

        public ReturnType<IList<booking>> GetAllBooking() {
            return (new BookingBusinessService()).GetAll();
        }
        public ReturnType<IList<booking>> GetBookingByClientId(long id)
        {
            return (new BookingBusinessService()).GetBookingByClientId(id);
        }
        public ReturnType<booking> SaveBooking(booking entity)
        {
            return (new BookingBusinessService()).Save(entity);
        }
        public ReturnType<bool> DeleteBookingById(long id) {
            return (new BookingBusinessService()).DeleteById(id);
        }
        public ReturnType<booking> GetBookingById(long id) {
            return (new BookingBusinessService()).GetById(id);
        }
        public ReturnType<IList<booking>> GetBookingByProductId(long id)
        {
            return (new BookingBusinessService()).GetBookingByProductId(id);
        }
        public ReturnType<IList<booking>> GetBookingByDeliveryId(long id)
        {
            return (new BookingBusinessService()).GetBookingByDeliveryId(id);
        }
    }
}
