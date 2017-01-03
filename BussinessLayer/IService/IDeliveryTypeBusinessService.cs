using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IDeliveryTypeBusinessService : IBusinessServiceBase<deliverytype>
    {
        ReturnType<bool> DeleteDeliveryTypeById(long enity);        
    }
}
