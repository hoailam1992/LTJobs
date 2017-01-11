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
        ReturnType<Message> SaveMessage(Message entity);
        [OperationContract]
        ReturnType<bool> DeleteMessageById(long id);     
        [OperationContract]
        ReturnType<IList<Message>> GetMessageByUserId(long id);
        [OperationContract]
        ReturnType<Message> GetMessageById(long id);
    }
}
