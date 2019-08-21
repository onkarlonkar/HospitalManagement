using Model;
using Service;
using DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DoctorDetailManager : IDoctorDetailService
    {

        public List<DoctorDetailModel> AdvanceSearch(string searchText)
        {
            try
            {
                DoctorDetail entity = new DoctorDetail();
                return entity.AdvanceSearch(searchText);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(DoctorDetailModel model)
        {
            try
            {
                DoctorDetail entity = new DoctorDetail();
                return entity.Create(model);
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

        public List<DoctorDetailModel> Get()
        {
            try
            {
                DoctorDetail entity = new DoctorDetail();
                return entity.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DoctorDetailModel GetById(Guid id)
        {
            try
            {
                DoctorDetail entity = new DoctorDetail();
                return entity.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Guid? GetInHouse(string name)
        {
            try
            {
               return DoctorDetail.GetInHouse(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DoctorDetailModel GetByName(string name)
        {
            try
            {
                DoctorDetail entity = new DoctorDetail();
                return entity.GetByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DoctorDetailModel GetByParentId(Guid id)
        {
            try
            {
                DoctorDetail entity = new DoctorDetail();
                return entity.GetByParentId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DoctorDetailModel> GetByType(bool isInHouse = false)
        {
            try
            {
                DoctorDetail entity = new DoctorDetail();
                return entity.GetByType(isInHouse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(DoctorDetailModel model)
        {
            try
            {
                DoctorDetail entity = new DoctorDetail();
                return entity.Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
