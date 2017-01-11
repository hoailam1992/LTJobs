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
        ReturnType<ClientComment> SaveClientComment(ClientComment entity);
        [OperationContract]
        ReturnType<bool> DeleteClientCommentById(long id);      
        [OperationContract]
        ReturnType<IList<ClientComment>> GetClientCommentByClientId(long id);
        [OperationContract]
        ReturnType<IList<ClientComment>> GetClientCommentByProductId(long id);
        [OperationContract]
        ReturnType<IList<ClientComment>> GetClientCommentByDeliveryId(long id);
        [OperationContract]
        ReturnType<ClientComment> GetClientCommentById(long id);
    }
}
