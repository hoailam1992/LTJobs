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
        public ReturnType<producttype> SaveProductType(producttype entity)
        {
            return (new ProductTypeBusinessService()).Save(entity);
        }
        public ReturnType<bool> DeleteProductTypeById(long id)
        {
            return (new ProductTypeBusinessService()).DeleteById(id);
        }
        public ReturnType<producttype> GetProductTypeById(long id)
        {
            return (new ProductTypeBusinessService()).GetById(id);
        }
        public ReturnType<IList<producttype>> GetAllProductType()
        {
            return (new ProductTypeBusinessService()).GetAll();
        }
    }
}
