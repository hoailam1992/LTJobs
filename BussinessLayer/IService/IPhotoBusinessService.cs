using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IPhotoBusinessService : IBusinessServiceBase<Photo>
    {
      
        ReturnType<bool> DeletePhotoById(long enity);
        ReturnType<IList<Photo>> GetPhotoByUserId(long id);
        
    }
}
