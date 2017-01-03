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
        public ReturnType<report> SaveReport(report entity)
        {
            return (new ReportBusinessService()).Save(entity);
        }
        public ReturnType<bool> DeleteReportById(long id)
        {
            return (new ReportBusinessService()).DeleteById(id);
        }
        public ReturnType<report> GetReportByBookingId(long id)
        {
            return (new ReportBusinessService()).GetReportByBookingId(id);
        }
        public ReturnType<report> GetReportById(long id)
        {
            return (new ReportBusinessService()).GetById(id);
        }
    }
}
