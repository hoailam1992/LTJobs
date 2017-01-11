using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IClientCommentBusinessService : IBusinessServiceBase<ClientComment>
    {
        ReturnType<bool> DeleteClientCommentById(long enity);
        ReturnType<IList<ClientComment>> GetClientCommentByProductId(long id);
        ReturnType<IList<ClientComment>> GetClientCommentByClientId(long id);
        ReturnType<IList<ClientComment>> GetClientCommentByDeliveryId(long id);


    }
}
