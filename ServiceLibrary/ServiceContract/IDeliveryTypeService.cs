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
        ReturnType<deliverytype> SaveDeliveryType(deliverytype entity);
        [OperationContract]
        ReturnType<bool> DeleteDeliveryTypeById(long id);       
        [OperationContract]
        ReturnType<deliverytype> GetDeliveryTypeById(long id);
    }
}
