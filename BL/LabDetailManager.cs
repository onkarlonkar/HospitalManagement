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
    public class LabDetailManager : ILabDetailService
    {

        public List<LabDetailModel> AdvanceSearch(string searchText)
        {
            try
            {
                LabDetail entity = new LabDetail();
                return entity.AdvanceSearch(searchText);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(LabDetailModel model)
        {
            try
            {
                LabDetail entity = new LabDetail();
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

        public List<LabDetailModel> Get()
        {
            try
            {
                LabDetail entity = new LabDetail();
                return entity.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LabDetailModel GetById(Guid id)
        {
            try
            {
                LabDetail entity = new LabDetail();
                return entity.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LabDetailModel GetByName(string name)
        {
            try
            {
                LabDetail entity = new LabDetail();
                return entity.GetByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<LabDetailModel> GetNonInHouse()
        {
            try
            {
                LabDetail entity = new LabDetail();
                return entity.GetNonInHouse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(LabDetailModel model)
        {
            try
            {
                LabDetail entity = new LabDetail();
                return entity.Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
