using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IMessageService : IBusinessServiceBase<Message>
    {
        ReturnType<bool> DeleteMessageById(long enity);
        ReturnType<IList<Message>> GetMessageByToId(long id);
    }
}
