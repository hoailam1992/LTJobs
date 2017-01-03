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
        ReturnType<message> SaveMessage(message entity);
        [OperationContract]
        ReturnType<bool> DeleteMessageById(long id);     
        [OperationContract]
        ReturnType<IList<message>> GetMessageByUserId(long id);
        [OperationContract]
        ReturnType<message> GetMessageById(long id);
    }
}
