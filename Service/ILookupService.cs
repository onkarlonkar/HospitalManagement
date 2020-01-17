using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Service
{
    public interface ILookupService
    {
        List<LookupModel> Get(LookUp lookUp);

        List<LookupModel> GetNextStatus(LookUp lookUp, int sequence);
        LookupModel GetById(LookUp lookUp, Guid id);
        bool Create(LookUp lookUp, LookupModel model);
        bool Update(LookUp lookUp, LookupModel model);
        bool Delete(LookUp lookUp, Guid id);
        LookupModel GetByName(LookUp lookUp, string name);
        LookupModel GetByParentId(LookUp lookUp, Guid id);
        List<LookupModel> AdvanceSearch(LookUp lookUp, string searchText);
        LookupModel GetRatesByType(string type);

        List<LookupModel> GetByOPDId(Guid id);
        bool CreateUpdate(List<LookupModel> model);

        decimal GetTPAmount(Guid id);
    }
}
