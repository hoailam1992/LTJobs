using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IProductPriceBusinessService : IBusinessServiceBase<ProductPrice>
    {
        ReturnType<IList<ProductPrice>> GetProductPriceByProductId(long id);
        ReturnType<IList<ProductPrice>> GetProductPriceByProductTypeId(long id);
        ReturnType<IList<ProductPrice>> GetProductPriceByProductAndTypeId(long idProduct, long idType);
    }
}
