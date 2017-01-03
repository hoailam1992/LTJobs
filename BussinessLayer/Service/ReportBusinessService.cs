using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.IService;
using BusinessLayer.Common;
using Models;
namespace BusinessLayer.Service
{
    public class ReportBusinessService : BusinessServiceBase<report>, IReportBusinessService
    {
        public ReturnType<report> GetReportByBookingId(long id)
        {
            return GetSingle(c => c.bookingid == id);
        }
    }
}
