using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Service;
using BusinessLayer.Common;
using Models;
namespace ServiceLibrary
{
    public partial class MasterService
    {
        public ReturnType<ProductPrice> SaveProductPrice(ProductPrice entity)
        {
            return (new ProductPriceBusinessService()).Save(entity);
        }
        public ReturnType<ProductPrice> GetProductPriceById(long id)
        {
            return (new ProductPriceBusinessService()).GetById(id);
        }
        public ReturnType<bool> DeleteProductPriceById(long id)
        {
            return (new ProductPriceBusinessService()).DeleteById(id);
        }
        public ReturnType<IList<ProductPrice>> GetProductPriceByProductId(long id)
        {
            return (new ProductPriceBusinessService()).GetProductPriceByProductId(id);
        }
        public ReturnType<IList<ProductPrice>> GetProductPriceByProductTypeId(long id)
        {
            return (new ProductPriceBusinessService()).GetProductPriceByProductTypeId(id);
        }
        public ReturnType<IList<ProductPrice>> GetProductPriceByProductAndTypeId(long idProduct, long idType)
        {
            return (new ProductPriceBusinessService()).GetProductPriceByProductAndTypeId(idProduct,idType);
        }
    }
}
