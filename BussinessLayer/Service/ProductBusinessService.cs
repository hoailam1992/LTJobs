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
    public class ProductBusinessService : BusinessServiceBase<product>, IProductBusinessService
    {
        public ReturnType<product> GetProductByUserId(long id) {
            return GetSingle(c => c.userid == id,c=>c.clientcomments,c=>c.videos);
        }
        public ReturnType<IList<product>> GetActiveProduct() {
            return GetList(c => c.isactive);
        }
        public ReturnType<product> GetProductByPCode(string id)
        {
            return GetSingle(c => c.productcode == id);
        }       
    }
}
