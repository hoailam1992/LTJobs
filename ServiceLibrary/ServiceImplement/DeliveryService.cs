using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Service;
using BusinessLayer.Common;
using Models;
using System.Collections.ObjectModel;

namespace ServiceLibrary
{
    public partial class MasterService
    {
        public ReturnType<bool> DeleteDeliveryById(long id)
        {
            return (new DeliveryBusinessService()).DeleteById(id);
        }
        public ReturnType<Delivery> GetDeliveryByUserId(long id)
        {
            return (new DeliveryBusinessService()).GetDeliveryByUserId(id);
        }
        public ReturnType<Delivery> SaveDelivery(Delivery entity)
        {
            entity.Code = entity.Code ?? "DLR" + DateTime.Now.ToShortDateString();
            return (new DeliveryBusinessService()).Save(entity);
        }
        public ReturnType<Delivery> GetDeliveryById(long id)
        {
            return (new DeliveryBusinessService()).GetById(id);
        }
        public ReturnType<IList<Delivery>> GetAllDelivery()
        {
            return (new DeliveryBusinessService()).GetAll();
        }
    }
}
