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
        public ReturnType<IList<clientcomment>> GetClientCommentByClientId(long id)
        {
            return (new ClientCommentBusinessService()).GetClientCommentByClientId(id);
        }
        public ReturnType<IList<clientcomment>> GetClientCommentByProductId(long id)
        {
            return (new ClientCommentBusinessService()).GetClientCommentByProductId(id);
        }
        public ReturnType<IList<clientcomment>> GetClientCommentByDeliveryId(long id)
        {
            return (new ClientCommentBusinessService()).GetClientCommentByDeliveryId(id);
        }
        public ReturnType<clientcomment> SaveClientComment(clientcomment entity)
        {
            return (new ClientCommentBusinessService()).Save(entity);
        }
        public ReturnType<clientcomment> GetClientCommentById(long id)
        {
            return (new ClientCommentBusinessService()).GetById(id);
        }
    }
}
