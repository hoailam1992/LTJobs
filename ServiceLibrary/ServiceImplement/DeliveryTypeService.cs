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
        public ReturnType<bool> DeleteDeliveryTypeById(long id)
        {
            return (new DeliveryTypeBusinessService()).DeleteById(id);
        }
        public ReturnType<deliverytype> SaveDeliveryType(deliverytype entity)
        {
            return (new DeliveryTypeBusinessService()).Save(entity);
        }
        public ReturnType<deliverytype> GetDeliveryTypeById(long id)
        {
            return (new DeliveryTypeBusinessService()).GetById(id);
        }
    }
}
