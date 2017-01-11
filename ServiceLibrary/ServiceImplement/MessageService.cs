using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Service;
using BusinessLayer.Common;
using Models;
namespace ServiceLibrary
{
    public partial class MasterService
    {
        public ReturnType<bool> DeleteMessageById(long id)
        {
            return (new MessageBusinessService()).DeleteById(id);
        }
        public ReturnType<IList<Message>> GetMessageByUserId(long id)
        {
            return (new MessageBusinessService()).GetMessageByToId(id);
        }
        public ReturnType<Message> GetMessageById(long id)
        {
            return (new MessageBusinessService()).GetById(id);
        }
        public ReturnType<Message> SaveMessage(Message entity)
        {
            return (new MessageBusinessService()).Save(entity);
        }

    }
}
