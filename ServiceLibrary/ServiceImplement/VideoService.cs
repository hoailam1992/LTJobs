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
        public ReturnType<bool> DeleteVideoById(long id)
        {
            return (new VideoBusinessService()).DeleteById(id);
        }

        public ReturnType<video> GetVideoById(long id)
        {
            return (new VideoBusinessService()).GetById(id);
        }

        public ReturnType<IList<video>> GetVideoByProductId(long id)
        {
            return (new VideoBusinessService()).GetVideoByProductId(id);
        }

        public ReturnType<video> SaveVideo(video entity)
        {
            return (new VideoBusinessService()).Save(entity);
        }

      
    }
}
