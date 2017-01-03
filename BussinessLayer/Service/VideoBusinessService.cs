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
    public class VideoBusinessService : BusinessServiceBase<video>, IVideoBusinessService
    {
        public ReturnType<IList<video>> GetVideoByProductId(long id)
        {
            return GetList(c => c.memberid == id);
        }
    }
}
