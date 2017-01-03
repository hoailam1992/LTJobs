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
        public ReturnType<bool> DeleteFeedbackById(long id)
        {
            return (new FeedbackBusinessService()).DeleteById(id);
        }
        public ReturnType<feedback> SaveFeedBack(feedback entity)
        {
            return (new FeedbackBusinessService()).Save(entity);
        }
        public ReturnType<feedback> GetFeedBackById(long id)
        {
            return (new FeedbackBusinessService()).GetById(id);
        }
    }
}
