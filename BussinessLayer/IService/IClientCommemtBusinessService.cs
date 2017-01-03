using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using BusinessLayer.Common;
namespace BusinessLayer.IService
{
    public interface IClientCommentBusinessService : IBusinessServiceBase<clientcomment>
    {
        ReturnType<bool> DeleteClientCommentById(long enity);
        ReturnType<IList<clientcomment>> GetClientCommentByProductId(long id);
        ReturnType<IList<clientcomment>> GetClientCommentByClientId(long id);
        ReturnType<IList<clientcomment>> GetClientCommentByDeliveryId(long id);


    }
}
