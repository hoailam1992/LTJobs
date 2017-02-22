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
            if (entity.Id != 0)
            {
                if (entity.DeliveryRespond == "A" && (entity.ProductRespond == "A" || entity.DeliveryId != null))
                {
                    UserBusinessService tempUserBusi = new UserBusinessService();
                    ClientBusinessService tempClient = new ClientBusinessService();
                    ProductBusinessService tempProduct = new ProductBusinessService();
                    DeliveryBusinessService tempDelivery = new DeliveryBusinessService();
                    MoneyTransactionBusinessService tempMoney = new MoneyTransactionBusinessService();
                    TrackingBusinessService tempTrack = new TrackingBusinessService();
                    Tracking trackingBook = new Tracking();
                    trackingBook.BookingId = entity.Id;
                    trackingBook.ProductConfirm = "O";
                    if (entity.DeliveryId != null)
                        trackingBook.DeliveryConfirm = "O";
                    else
                        trackingBook.DeliveryConfirm = "NULL";
                    trackingBook.ClientConfirm = "O";
                    trackingBook.DateTime = entity.DateTime.Value;
                    var returnedtracking = SaveTracking(trackingBook);
                    if (returnedtracking.IsSuccess && returnedtracking.Result != null)
                    {
                        entity.TrackingId = returnedtracking.Result.Id;
                        entity.Status = "P";
                        var trandate = DateTime.Now;
                        var Client = tempClient.GetById(entity.ClientId);
                        var Product = tempProduct.GetById(entity.ProductId);
                        MoneyTransaction tempMoneyTransaction = new MoneyTransaction();
                        tempMoneyTransaction.Trandate = trandate;
                        tempMoneyTransaction.Remark = "Transaction for Product Id " + entity.ProductId;
                        tempMoneyTransaction.PaymentDate = trandate;
                        tempMoneyTransaction.SourceId = Client.Result.UserId;
                        tempMoneyTransaction.DestinationId = Product.Result.UserId;
                        tempMoneyTransaction.Code = "BK" + entity.Id;
                        tempMoneyTransaction.Status = "O";
                        tempMoneyTransaction.Value = entity.ProductValue.Value;
                        tempMoneyTransaction.CreatedDate = DateTime.Now;
                        tempMoneyTransaction.Id = 0;
                        if (entity.PaymentMode == "2")
                        {
                            tempMoneyTransaction.CCExpiredYear = Client.Result.CCExpiredYear;
                            tempMoneyTransaction.CCExpiredMonth = Client.Result.CCExpiredMonth;
                            tempMoneyTransaction.CCName = Client.Result.CCHolder;
                            tempMoneyTransaction.CCNumber = Client.Result.CCNumber;
                            tempMoneyTransaction.CCPin = Client.Result.CCPin;
                        }
                        tempMoneyTransaction.TrackingId = returnedtracking.Result.Id;
                        var result1 = tempMoney.Save(tempMoneyTransaction);
                        if (entity.DeliveryId != null)
                        {
                            var Delivery = tempDelivery.GetById(entity.DeliveryId.Value);
                            MoneyTransaction deliverypaye = new MoneyTransaction();
                            deliverypaye.Id = 0;
                            deliverypaye.Trandate = trandate;
                            deliverypaye.Remark = "Transaction for Delivery Id " + entity.DeliveryId;
                            deliverypaye.PaymentDate = trandate;
                            deliverypaye.SourceId = Client.Result.UserId;
                            deliverypaye.DestinationId = Delivery.Result.UserId;
                            deliverypaye.Code = "BK" + entity.Id;
                            deliverypaye.Status = "O";
                            deliverypaye.Value = entity.DeliveryValue.Value;
                            deliverypaye.CreatedDate = DateTime.Now;
                            if (entity.PaymentMode == "2")
                            {
                                deliverypaye.CCExpiredYear = Client.Result.CCExpiredYear;
                                deliverypaye.CCExpiredMonth = Client.Result.CCExpiredMonth;
                                deliverypaye.CCName = Client.Result.CCHolder;
                                deliverypaye.CCNumber = Client.Result.CCNumber;
                                deliverypaye.CCPin = Client.Result.CCPin;
                            }
                            deliverypaye.TrackingId = returnedtracking.Result.Id;
                            var result2 = tempMoney.Save(deliverypaye);
                        }
                    }
                    else {
                        return new ReturnType<Booking>() { IsSuccess = false, ErrorMessage = "Fails to save tracking", Result = null };
                    }
                }
            }
            
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
        public ReturnType<IList<Booking>> GetNewBookingByProductId(long id)
        {
            var temp = (new BookingBusinessService()).GetBookingByProductId(id);
            ReturnType<IList<Booking>> result = new ReturnType<IList<Booking>>();
            if (temp.Result != null)
            {
                result.Result =new List<Booking>(temp.Result.Where(c => c.ProductRespond == "O" && c.Status!="F"));
                result.IsSuccess = temp.IsSuccess;
                result.ErrorMessage = temp.ErrorMessage;
            }
            return result;
        }
        public ReturnType<IList<Booking>> GetNewBookingByDeliveryId(long id)
        {
            var temp = (new BookingBusinessService()).GetBookingByDeliveryId(id);
            ReturnType<IList<Booking>> result = new ReturnType<IList<Booking>>();
            if (temp.Result != null)
            {
                result.Result = new List<Booking>(temp.Result.Where(c => c.DeliveryRespond == "O" && c.ProductRespond=="A" && c.Status != "F"));
                result.IsSuccess = temp.IsSuccess;
                result.ErrorMessage = temp.ErrorMessage;
            }
            return result;
        }
        public ReturnType<IList<Booking>> GetBookingByDeliveryId(long id)
        {
            return (new BookingBusinessService()).GetBookingByDeliveryId(id); 
        }
    }
}
