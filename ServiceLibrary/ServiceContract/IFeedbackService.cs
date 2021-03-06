﻿using System;
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
        ReturnType<feedback> SaveFeedBack(feedback entity);
        [OperationContract]
        ReturnType<bool> DeleteFeedbackById(long enity);       
        [OperationContract]
        ReturnType<feedback> GetFeedBackById(long id);
        
    }
}
