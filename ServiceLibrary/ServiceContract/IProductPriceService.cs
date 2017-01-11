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
        ReturnType<ProductPrice> SaveProductPrice(ProductPrice entity);
        [OperationContract]
        ReturnType<bool> DeleteProductPriceById(long enity);
        [OperationContract]
        ReturnType<IList<ProductPrice>> GetProductPriceByProductId(long id);
        [OperationContract]
        ReturnType<IList<ProductPrice>> GetProductPriceByProductTypeId(long id);
        [OperationContract]
        ReturnType<IList<ProductPrice>> GetProductPriceByProductAndTypeId(long idProduct,long idType);
        [OperationContract]
        ReturnType<ProductPrice> GetProductPriceById(long id);
    }
}
