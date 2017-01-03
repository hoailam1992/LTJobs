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
        ReturnType<clientcomment> SaveClientComment(clientcomment entity);
        [OperationContract]
        ReturnType<bool> DeleteClientCommentById(long id);      
        [OperationContract]
        ReturnType<IList<clientcomment>> GetClientCommentByClientId(long id);
        [OperationContract]
        ReturnType<IList<clientcomment>> GetClientCommentByProductId(long id);
        [OperationContract]
        ReturnType<IList<clientcomment>> GetClientCommentByDeliveryId(long id);
        [OperationContract]
        ReturnType<clientcomment> GetClientCommentById(long id);
    }
}
