using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
using System.ServiceModel;
using System.Linq.Expressions;

namespace ServiceLibrary
{
    public partial interface IMasterService
    {
        [OperationContract]
        ReturnType<Product> SaveProduct(Product entity);
        [OperationContract]
        ReturnType<bool> DeleteProductById(long enity);
        [OperationContract]
        ReturnType<Product> GetProductByUserId(long id);
        [OperationContract]
        ReturnType<Product> GetProductById(long id);
        [OperationContract]
        ReturnType<Product> GetProductByCode(string id);
        [OperationContract]
        ReturnType<IList<Product>> GetAllProduct();
        //[OperationContract]
        //ReturnType<IList<product>> GetProductFilter(Expression<Func<product, bool>> where, params Expression<Func<product, object>>[] navigationProperties);
    }
}
