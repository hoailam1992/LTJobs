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
        ReturnType<ProductType> SaveProductType(ProductType entity);
        [OperationContract]
        ReturnType<bool> DeleteProductTypeById(long enity);
        [OperationContract]
        ReturnType<ProductType> GetProductTypeById(long id);
        [OperationContract]
        ReturnType<IList<ProductType>> GetAllProductType();

    }
}
