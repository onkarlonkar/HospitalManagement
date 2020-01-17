using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;
using Utility;

namespace Service
{
    public interface IOPDHistoryService
    {
        List<OPDHistoryModel> Get();

        List<OPDHistoryModel> GetByStatus(params string[] status);
        OPDHistoryModel GetById(Guid id);

        bool Update(OPDHistoryModel model);

        bool UpdateStatus(List<OPDHistoryModel> model, OPD_STATUS status);
        bool Delete(Guid id);
        OPDHistoryModel GetByParentId(Guid id);
        List<OPDHistoryModel> AdvanceSearch(string searchText);
        List<OPDHistoryModel> GetHistoryByPatientId(Guid? id);
        #region Dashboard

        DashboardModel getDashboardCounts();

        List<LookupModel> getPatientByType(P_TYPE type);

        bool Print(Guid? id, string type);

        #endregion
    }
}
