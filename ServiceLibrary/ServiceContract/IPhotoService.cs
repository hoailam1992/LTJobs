using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
using System.ServiceModel;

namespace ServiceLibrary
{
    public partial interface IMasterService
    {
        [OperationContract]
        ReturnType<Photo> SavePhoto(Photo entity);
        [OperationContract]
        ReturnType<bool> DeletePhotoById(long id);    
        [OperationContract]
        ReturnType<IList<Photo>> GetPhotoByUserId(long id);
        [OperationContract]
        ReturnType<Photo> GetPhotoById(long id);
    }
}
