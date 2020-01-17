using Model;
using Service;
using DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace BL
{
    public class PatientDetailManager : IPatientDetailService
    {

        public async Task<IPagedList<PatientDetailModel>> AdvanceSearch(string searchText, int pageIndex = 1, int pageSize = 40)
        {
            try
            {
                PatientDetail entity = new PatientDetail();
                return await entity.AdvanceSearch(searchText, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(PatientDetailModel model)
        {
            try
            {
                PatientDetail entity = new PatientDetail();
                return entity.Create(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CreateOPD(PatientDetailModel model)
        {
            try
            {
                PatientDetail entity = new PatientDetail();
                return entity.CreateOPD(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<PatientDetailModel> Get()
        {
            try
            {
                PatientDetail entity = new PatientDetail();
                return entity.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PatientDetailModel GetById(Guid id)
        {
            try
            {
                PatientDetail entity = new PatientDetail();
                return entity.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PatientDetailModel GetByName(string name)
        {
            try
            {
                PatientDetail entity = new PatientDetail();
                return entity.GetByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PatientDetailModel GetByParentId(Guid id)
        {
            try
            {
                PatientDetail entity = new PatientDetail();
                return entity.GetByParentId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getNewCasePaperNumber()
        {
            try
            {
                PatientDetail entity = new PatientDetail();
                return entity.getNewCasePaperNumber();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal? isFollowUpCheck(Guid? id)
        {
            try
            {                
                return PatientDetail.isFollowUpCheck(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(PatientDetailModel model)
        {
            try
            {
                PatientDetail entity = new PatientDetail();
                return entity.Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
