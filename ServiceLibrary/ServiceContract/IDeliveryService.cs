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
        ReturnType<Delivery> SaveDelivery(Delivery entity);
        [OperationContract]
        ReturnType<bool> DeleteDeliveryById(long enity);       
        [OperationContract]
        ReturnType<Delivery> GetDeliveryByUserId(long id);
        [OperationContract]
        ReturnType<Delivery> GetDeliveryById(long id);
    }
}
