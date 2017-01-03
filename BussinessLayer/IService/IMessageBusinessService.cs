using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IMessageService : IBusinessServiceBase<message>
    {
        ReturnType<bool> DeleteMessageById(long enity);
        ReturnType<IList<message>> GetMessageByToId(long id);
    }
}
