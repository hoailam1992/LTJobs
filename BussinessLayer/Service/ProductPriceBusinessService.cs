using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.IService;
using BusinessLayer.Common;
using Models;
namespace BusinessLayer.Service
{
    public class ProductPriceBusinessService : BusinessServiceBase<ProductPrice>, IProductPriceBusinessService
    {
        public ReturnType<IList<ProductPrice>> GetProductPriceByProductAndTypeId(long idProduct, long idType)
        {
            return GetList(c => c.ProductId == idProduct && c.ProductTypeId == idType);
        }

        public ReturnType<IList<ProductPrice>> GetProductPriceByProductId(long id)
        {
            return GetList(c => c.ProductId == id);
        }

        public ReturnType<IList<ProductPrice>> GetProductPriceByProductTypeId(long id)
        {
            return GetList(c => c.ProductTypeId == id);
        }
    }
}
