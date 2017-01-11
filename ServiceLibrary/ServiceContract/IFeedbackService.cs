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
        ReturnType<FeedBack> SaveFeedBack(FeedBack entity);
        [OperationContract]
        ReturnType<bool> DeleteFeedbackById(long enity);       
        [OperationContract]
        ReturnType<FeedBack> GetFeedBackById(long id);
        
    }
}
