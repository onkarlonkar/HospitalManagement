using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace Service
{
    public interface ILabDetailService
    {
        List<LabDetailModel> Get();
        LabDetailModel GetById(Guid id);
        bool Create(LabDetailModel model);

      
        bool Update(LabDetailModel model);
        bool Delete(Guid id);
        LabDetailModel GetByName(string name);       
        List<LabDetailModel> GetNonInHouse();
        List<LabDetailModel> AdvanceSearch(string searchText);

    }
}
