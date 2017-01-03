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
        ReturnType<delivery> SaveDelivery(delivery entity);
        [OperationContract]
        ReturnType<bool> DeleteDeliveryById(long enity);       
        [OperationContract]
        ReturnType<delivery> GetDeliveryByUserId(long id);
        [OperationContract]
        ReturnType<delivery> GetDeliveryById(long id);
    }
}
