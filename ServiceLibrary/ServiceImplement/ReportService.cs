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
        public ReturnType<Report> SaveReport(Report entity)
        {
            return (new ReportBusinessService()).Save(entity);
        }
        public ReturnType<bool> DeleteReportById(long id)
        {
            return (new ReportBusinessService()).DeleteById(id);
        }
        public ReturnType<Report> GetReportByBookingId(long id)
        {
            return (new ReportBusinessService()).GetReportByBookingId(id);
        }
        public ReturnType<Report> GetReportById(long id)
        {
            return (new ReportBusinessService()).GetById(id);
        }
    }
}
