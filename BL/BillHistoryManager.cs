using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DL.Entity;

namespace BL
{
    public class BillHistoryManager : IBillHistoryService
    {
        public bool Create(BillHistoryModel model)
        {
            try
            {
                BillHistory entity = new BillHistory();
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

        public List<BillHistoryModel> Get()
        {
            try
            {
                BillHistory entity = new BillHistory();
                return entity.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        public BillHistoryModel GetByOPDId(Guid id)
        {
            try
            {
                BillHistory entity = new BillHistory();
                return entity.GetByOPDId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BillHistoryModel GetByParentId(Guid id)
        {
            try
            {
                BillHistory entity = new BillHistory();
                return entity.GetByParentId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Guid? id)
        {
            try
            {
                BillHistory entity = new BillHistory();
                return entity.Update(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
