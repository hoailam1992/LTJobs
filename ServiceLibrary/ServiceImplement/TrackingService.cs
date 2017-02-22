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

        public ReturnType<IList<Tracking>> GetAllTracking() {
            return (new TrackingBusinessService()).GetAll();
        }
        public ReturnType<Tracking> GetTrackingByBookingId(long id)
        {
            return (new TrackingBusinessService()).GetTrackingByBookingId(id);
        }
        public ReturnType<Tracking> SaveTracking(Tracking entity)
        {
            if (entity.Id != 0)
            {
                entity.ModifiedDate = DateTime.Now;
                
            }
            else {
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;
            }
            if (entity.ClientConfirm == "Cancel" || entity.DeliveryConfirm == "Cancel" || entity.ProductConfirm == "Cancel")
            {
                BookingBusinessService bookingservice = new BookingBusinessService();
                MessageBusinessService messservice = new MessageBusinessService();
                
                var BookingInfo = bookingservice.GetBookingById(entity.BookingId);
                if (BookingInfo.IsSuccess && BookingInfo.Result != null)
                {
                    Message tempMessage = new Message();
                    tempMessage.From = "Admin";
                    tempMessage.To = BookingInfo.Result.Client.UserId;
                    tempMessage.Subject = "Booking Has Been Canceled By " + entity.ClientConfirm == "Cancel" ? "Client" : entity.ProductConfirm == "Cancel" ? "Product" : "Delivery";
                    tempMessage.Body = "Your Booking "+entity.BookingId+" Has Been canceled \n Reason : " + entity.ClientConfirm == "Cancel" ? entity.RemarkClient : entity.ProductConfirm == "Cancel" ? entity.RemarkProduct : entity.RemarkDelivery;
                    tempMessage.DateTime = DateTime.Now;
                    tempMessage.Status = false;
                    messservice.Save(tempMessage);
                    Message tempMessage1 = new Message();
                    tempMessage1.From = "Admin";
                    tempMessage1.To = BookingInfo.Result.Product.UserId;
                    tempMessage1.Subject = "Booking Has Been Canceled By " + entity.ClientConfirm == "Cancel" ? "Client" : entity.ProductConfirm == "Cancel" ? "Product" : "Delivery";
                    tempMessage1.Body = "Your Booking " + entity.BookingId + " Has Been canceled \n Reason : " + entity.ClientConfirm == "Cancel" ? entity.RemarkClient : entity.ProductConfirm == "Cancel" ? entity.RemarkProduct : entity.RemarkDelivery;
                    tempMessage1.DateTime = DateTime.Now;
                    tempMessage1.Status = false;
                    messservice.Save(tempMessage1);
                    if (BookingInfo.Result.DeliveryId.HasValue)
                    {
                        Message tempMessage2 = new Message();
                        tempMessage2.From = "Admin";
                        tempMessage2.To = BookingInfo.Result.Delivery.UserId;
                        tempMessage2.Subject = "Booking Has Been Canceled By " + entity.ClientConfirm == "Cancel" ? "Client" : entity.ProductConfirm == "Cancel" ? "Product" : "Delivery";
                        tempMessage2.Body = "Your Booking " + entity.BookingId + " Has Been canceled \n Reason : " + entity.ClientConfirm == "Cancel" ? entity.RemarkClient : entity.ProductConfirm == "Cancel" ? entity.RemarkProduct : entity.RemarkDelivery;
                        tempMessage2.DateTime = DateTime.Now;
                        tempMessage2.Status = false;
                        messservice.Save(tempMessage2);
                    }
                }
                if (entity.ClientConfirm == "Cancel")
                {
                    ClientBusinessService cltService = new ClientBusinessService();
                    BookingInfo.Result.Client.CancelCount++;
                    cltService.Save(BookingInfo.Result.Client);
                }
                if (entity.ProductConfirm == "Cancel")
                {
                    ProductBusinessService cltService = new ProductBusinessService();
                    BookingInfo.Result.Product.CancelCount++;
                    cltService.Save(BookingInfo.Result.Product);
                }
                BookingInfo.Result.Status = "C";
                bookingservice.Save(BookingInfo.Result);
                MoneyTransactionBusinessService moneytran = new MoneyTransactionBusinessService();
                var tempMoney = moneytran.GetMoneyTransactionByTrackingId(entity.Id);
                if (tempMoney.IsSuccess && tempMoney.Result.Count > 0)
                {
                    foreach (var t in tempMoney.Result)
                    {
                        t.Status = "C";
                        moneytran.Save(t);
                    }
                }
            }
            return (new TrackingBusinessService()).Save(entity);
        }

        public ReturnType<bool> DeleteTrackingById(long id) {
            return (new TrackingBusinessService()).DeleteById(id);
        }
        public ReturnType<Tracking> GetTrackingById(long id) {
            return (new TrackingBusinessService()).GetTrackingById(id);
        }     
    }
}
