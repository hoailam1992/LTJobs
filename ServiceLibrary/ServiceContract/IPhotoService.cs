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
        ReturnType<photo> SavePhoto(photo entity);
        [OperationContract]
        ReturnType<bool> DeletePhotoById(long id);    
        [OperationContract]
        ReturnType<IList<photo>> GetPhotoByUserId(long id);
        [OperationContract]
        ReturnType<photo> GetPhotoById(long id);
    }
}
