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
        public ReturnType<Product> SaveProduct(Product entity)
        {
            entity.Code = entity.Code ?? "PRD" + DateTime.Now;
            return (new ProductBusinessService()).Save(entity);
        }
        public ReturnType<bool> DeleteProductById(long id)
        {
            return (new ProductBusinessService()).DeleteById(id);
        }
        public ReturnType<Product> GetProductByUserId(long id)
        {
            return (new ProductBusinessService()).GetProductByUserId(id);
        }
        public ReturnType<Product> GetProductById(long id)
        {
            return (new ProductBusinessService()).GetById(id);
        }
        public ReturnType<Product> GetProductByCode(string id)
        {
            return (new ProductBusinessService()).GetProductByPCode(id);
        }
        public ReturnType<IList<Product>> GetAllProduct()
        {
            return (new ProductBusinessService()).GetAll();
        }
        public ReturnType<IList<Product>> GetAllProductAndUser()
        {
            return (new ProductBusinessService()).GetAllProductAndUser();
        }
        //public ReturnType<IList<product>> GetProductFilter(Expression<Func<product, bool>> where, params Expression<Func<product, object>>[] navigationProperties)
        //{
        //    return (new ProductBusinessService()).GetList(where, navigationProperties);
        //}
    }
}
