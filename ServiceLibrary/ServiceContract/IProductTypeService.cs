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
        ReturnType<producttype> SaveProductType(producttype entity);
        [OperationContract]
        ReturnType<bool> DeleteProductTypeById(long enity);
        [OperationContract]
        ReturnType<producttype> GetProductTypeById(long id);
        [OperationContract]
        ReturnType<IList<producttype>> GetAllProductType();

    }
}
