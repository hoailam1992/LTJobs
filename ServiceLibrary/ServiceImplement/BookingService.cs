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

        public ReturnType<IList<Booking>> GetAllBooking() {
            return (new BookingBusinessService()).GetAll();
        }
        public ReturnType<IList<Booking>> GetBookingByClientId(long id)
        {
            return (new BookingBusinessService()).GetBookingByClientId(id);
        }
        public ReturnType<Booking> SaveBooking(Booking entity)
        {
            return (new BookingBusinessService()).Save(entity);
        }
        public ReturnType<bool> DeleteBookingById(long id) {
            return (new BookingBusinessService()).DeleteById(id);
        }
        public ReturnType<Booking> GetBookingById(long id) {
            return (new BookingBusinessService()).GetBookingById(id);
        }
        public ReturnType<IList<Booking>> GetBookingByProductId(long id)
        {
            return (new BookingBusinessService()).GetBookingByProductId(id);
        }
        public ReturnType<IList<Booking>> GetBookingByDeliveryId(long id)
        {
            return (new BookingBusinessService()).GetBookingByDeliveryId(id); 
        }
    }
}
