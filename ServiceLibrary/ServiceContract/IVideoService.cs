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
        ReturnType<Video> SaveVideo(Video entity);
        [OperationContract]
        ReturnType<bool> DeleteVideoById(long id);      
        [OperationContract]
        ReturnType<IList<Video>> GetVideoByProductId(long id);
        [OperationContract]
        ReturnType<Video> GetVideoById(long id);
    }
}
