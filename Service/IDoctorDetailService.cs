using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Service
{
    public interface IDoctorDetailService
    {
        List<DoctorDetailModel> Get();
        List<DoctorDetailModel> GetByType(bool isInHouse = false);
        DoctorDetailModel GetById(Guid id);
        bool Create(DoctorDetailModel model);
        bool Update(DoctorDetailModel model);
        bool Delete(Guid id);
        DoctorDetailModel GetByName(string name);
        DoctorDetailModel GetByParentId(Guid id);
        List<DoctorDetailModel> AdvanceSearch(string searchText);
        Guid? GetInHouse(string name);
    }
}
