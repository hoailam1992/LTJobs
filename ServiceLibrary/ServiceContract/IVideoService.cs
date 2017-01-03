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
        ReturnType<video> SaveVideo(video entity);
        [OperationContract]
        ReturnType<bool> DeleteVideoById(long id);      
        [OperationContract]
        ReturnType<IList<video>> GetVideoByProductId(long id);
        [OperationContract]
        ReturnType<video> GetVideoById(long id);
    }
}
