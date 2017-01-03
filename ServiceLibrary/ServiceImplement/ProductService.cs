using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Service;
using BusinessLayer.Common;
using Models;
using System.Linq.Expressions;

namespace ServiceLibrary
{
    public partial class MasterService
    {
        public ReturnType<product> SaveProduct(product entity)
        {
            return (new ProductBusinessService()).Save(entity);
        }
        public ReturnType<bool> DeleteProductById(long id)
        {
            return (new ProductBusinessService()).DeleteById(id);
        }
        public ReturnType<product> GetProductByUserId(long id)
        {
            return (new ProductBusinessService()).GetProductByUserId(id);
        }
        public ReturnType<product> GetProductById(long id)
        {
            return (new ProductBusinessService()).GetById(id);
        }
        public ReturnType<product> GetProductByCode(string id)
        {
            return (new ProductBusinessService()).GetProductByPCode(id);
        }
        //public ReturnType<IList<product>> GetProductFilter(Expression<Func<product, bool>> where, params Expression<Func<product, object>>[] navigationProperties)
        //{
        //    return (new ProductBusinessService()).GetList(where, navigationProperties);
        //}
    }
}
