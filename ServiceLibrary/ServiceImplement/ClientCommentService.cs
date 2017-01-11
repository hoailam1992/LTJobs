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
        public ReturnType<bool> DeleteClientCommentById(long id)
        {
            return (new ClientCommentBusinessService()).DeleteById(id);
        }
        public ReturnType<IList<ClientComment>> GetClientCommentByClientId(long id)
        {
            return (new ClientCommentBusinessService()).GetClientCommentByClientId(id);
        }
        public ReturnType<IList<ClientComment>> GetClientCommentByProductId(long id)
        {
            return (new ClientCommentBusinessService()).GetClientCommentByProductId(id);
        }
        public ReturnType<IList<ClientComment>> GetClientCommentByDeliveryId(long id)
        {
            return (new ClientCommentBusinessService()).GetClientCommentByDeliveryId(id);
        }
        public ReturnType<ClientComment> SaveClientComment(ClientComment entity)
        {
            return (new ClientCommentBusinessService()).Save(entity);
        }
        public ReturnType<ClientComment> GetClientCommentById(long id)
        {
            return (new ClientCommentBusinessService()).GetById(id);
        }
    }
}
