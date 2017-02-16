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
        public ReturnType<DeliveryType> SaveDeliveryType(DeliveryType entity)
        {
            return (new DeliveryTypeBusinessService()).Save(entity);
        }
        public ReturnType<DeliveryType> GetDeliveryTypeById(long id)
        {
            return (new DeliveryTypeBusinessService()).GetById(id);
        }
        public ReturnType<IList<DeliveryType>> GetAllDeliveryTypeByDeliveryId(long id)
        {
            return (new DeliveryTypeBusinessService()).GetList(c => c.DeliveryId == id);
        }
    }
}
