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
        ReturnType<report> SaveReport(report entity);
        [OperationContract]
        ReturnType<bool> DeleteReportById(long enity);        
        [OperationContract]
        ReturnType<report> GetReportByBookingId(long id);
        [OperationContract]
        ReturnType<report> GetReportById(long id);
    }
}
