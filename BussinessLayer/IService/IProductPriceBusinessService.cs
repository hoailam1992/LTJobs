using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IProductPriceBusinessService : IBusinessServiceBase<productprice>
    {
        ReturnType<IList<productprice>> GetProductPriceByProductId(long id);
        ReturnType<IList<productprice>> GetProductPriceByProductTypeId(long id);
        ReturnType<IList<productprice>> GetProductPriceByProductAndTypeId(long idProduct, long idType);
    }
}
