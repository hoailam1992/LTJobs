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
        ReturnType<productprice> SaveProductPrice(productprice entity);
        [OperationContract]
        ReturnType<bool> DeleteProductPriceById(long enity);
        [OperationContract]
        ReturnType<IList<productprice>> GetProductPriceByProductId(long id);
        [OperationContract]
        ReturnType<IList<productprice>> GetProductPriceByProductTypeId(long id);
        [OperationContract]
        ReturnType<IList<productprice>> GetProductPriceByProductAndTypeId(long idProduct,long idType);
        [OperationContract]
        ReturnType<productprice> GetProductPriceById(long id);
    }
}
