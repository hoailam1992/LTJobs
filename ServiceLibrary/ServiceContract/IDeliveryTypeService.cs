using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
using System.ServiceModel;

namespace ServiceLibrary
{
    public partial interface IMasterService
    {
        [OperationContract]
        ReturnType<DeliveryType> SaveDeliveryType(DeliveryType entity);
        [OperationContract]
        ReturnType<bool> DeleteDeliveryTypeById(long id);       
        [OperationContract]
        ReturnType<DeliveryType> GetDeliveryTypeById(long id);
        [OperationContract]
        ReturnType<IList<DeliveryType>> GetAllDeliveryTypeByDeliveryId(long id);
    }
}
