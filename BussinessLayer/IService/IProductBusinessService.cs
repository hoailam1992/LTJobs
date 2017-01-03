using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IProductBusinessService : IBusinessServiceBase<product>
    {
        ReturnType<product> GetProductByUserId(long id);
        ReturnType<IList<product>> GetActiveProduct();
        ReturnType<product> GetProductByPCode(string code);
    }
}
