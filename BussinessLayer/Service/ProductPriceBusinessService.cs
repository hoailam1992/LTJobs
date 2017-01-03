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
    public class ProductPriceBusinessService : BusinessServiceBase<productprice>, IProductPriceBusinessService
    {
        public ReturnType<IList<productprice>> GetProductPriceByProductAndTypeId(long idProduct, long idType)
        {
            return GetList(c => c.productid == idProduct && c.producttypeid == idType);
        }

        public ReturnType<IList<productprice>> GetProductPriceByProductId(long id)
        {
            return GetList(c => c.productid == id);
        }

        public ReturnType<IList<productprice>> GetProductPriceByProductTypeId(long id)
        {
            return GetList(c => c.producttypeid == id);
        }
    }
}
