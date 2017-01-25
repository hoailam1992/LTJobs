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
    public class ProductBusinessService : BusinessServiceBase<Product>, IProductBusinessService
    {
        public ReturnType<Product> GetProductByUserId(long id) {
            return GetSingle(c => c.UserId == id,c=>c.ClientComments,c=>c.Videos);
        }
        public ReturnType<IList<Product>> GetActiveProduct() {
            return GetList(c => c.IsActive);
        }
        public ReturnType<Product> GetProductByPCode(string id)
        {
            return GetSingle(c => c.Code == id);
        }
        public ReturnType<IList<Product>> GetAllProductAndUser()
        {
            UserBusinessService temp = new UserBusinessService();
            var resultfinal = GetAll();
            foreach (var tempPro in resultfinal.Result)
            {
                tempPro.User = temp.GetUserInfoById(tempPro.UserId).Result;
            }
            return resultfinal;
        }  
    }
}
