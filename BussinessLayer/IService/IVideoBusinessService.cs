using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IVideoBusinessService : IBusinessServiceBase<video>
    {
        ReturnType<IList<video>> GetVideoByProductId(long id);
    }
}
