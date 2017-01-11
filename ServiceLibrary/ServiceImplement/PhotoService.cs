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
        public ReturnType<bool> DeletePhotoById(long id)
        {
            return (new PhotoBusinessService()).DeleteById(id);
        }       

        public ReturnType<IList<Photo>> GetPhotoByUserId(long id)
        {
            return (new PhotoBusinessService()).GetPhotoByUserId(id);
        }
        public ReturnType<Photo> SavePhoto(Photo entity)
        {
            return (new PhotoBusinessService()).Save(entity);
        }
        public ReturnType<Photo> GetPhotoById(long id)
        {
            return (new PhotoBusinessService()).GetById(id);
        }
    }
}
