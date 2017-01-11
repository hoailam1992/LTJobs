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
    public class ReportBusinessService : BusinessServiceBase<Report>, IReportBusinessService
    {
        public ReturnType<Report> GetReportByBookingId(long id)
        {
            return GetSingle(c => c.BookingId == id);
        }
    }
}
