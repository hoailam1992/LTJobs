using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IDeliveryBusinessService : IBusinessServiceBase<delivery>
    {       
        ReturnType<bool> DeleteDeliveryById(long enity);
        ReturnType<delivery> GetDeliveryByUserId(long id);
    }
}
