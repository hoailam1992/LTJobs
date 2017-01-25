using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IProductBusinessService : IBusinessServiceBase<Product>
    {
        ReturnType<Product> GetProductByUserId(long id);
        ReturnType<IList<Product>> GetActiveProduct();
        ReturnType<Product> GetProductByPCode(string code);

        ReturnType<IList<Product>> GetAllProductAndUser();
    }
}
