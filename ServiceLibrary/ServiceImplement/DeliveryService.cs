using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Service;
using BusinessLayer.Common;
using Models;
namespace ServiceLibrary
{
    public partial class MasterService
    {
        public ReturnType<bool> DeleteDeliveryById(long id)
        {
            return (new DeliveryBusinessService()).DeleteById(id);
        }
        public ReturnType<delivery> GetDeliveryByUserId(long id)
        {
            return (new DeliveryBusinessService()).GetDeliveryByUserId(id);
        }
        public ReturnType<delivery> SaveDelivery(delivery entity)
        {
            return (new DeliveryBusinessService()).Save(entity);
        }
        public ReturnType<delivery> GetDeliveryById(long id)
        {
            return (new DeliveryBusinessService()).GetById(id);
        }
    }
}
