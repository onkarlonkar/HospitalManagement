using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IReportingService
    {
        List<OPDHistoryModel> GetByDate(DateTime from, DateTime to);
        List<OPDHistoryModel> GetByName(string Name);
        List<OPDHistoryModel> GetByCasePaper(string casePaperNo);
        List<OPDHistoryModel> GetGenericReport(OPDFilterSearchModel model);

        string DownloadReport(OPDFilterSearchModel model);

        List<PatientDetailModel> GetIPDReport(OPDFilterSearchModel model);

        string DownloadIPDReport(OPDFilterSearchModel model);

    }
}
