using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using PagedList;

namespace Service
{
    public interface IPatientDetailService
    {
        List<PatientDetailModel> Get();
        PatientDetailModel GetById(Guid id);
        bool Create(PatientDetailModel model);

        bool CreateOPD(PatientDetailModel model);
        bool Update(PatientDetailModel model);
        bool Delete(Guid id);
        PatientDetailModel GetByName(string name);
        PatientDetailModel GetByParentId(Guid id);
        Task<IPagedList<PatientDetailModel>> AdvanceSearch(string searchText, int pageIndex = 1, int pageSize = 40);
        decimal? isFollowUpCheck(Guid? id);
        string getNewCasePaperNumber();
    }
}
