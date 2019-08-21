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
    public class UserDetailManager : IUserDetailService
    {
        public List<UserDetailModel> AdvanceSearch(string searchText)
        {
            try
            {
                UserDetail entity = new UserDetail();
                return entity.AdvanceSearch(searchText);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(UserDetailModel model)
        {
            try
            {
                UserDetail entity = new UserDetail();
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

        public List<UserDetailModel> Get()
        {
            try
            {
                UserDetail entity = new UserDetail();
                return entity.Get();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserDetailModel GetById(Guid id)
        {
            try
            {
                UserDetail entity = new UserDetail();
                return entity.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserDetailModel GetByName(string name)
        {
            try
            {
                UserDetail entity = new UserDetail();
                return entity.GetByName(name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserDetailModel GetByParentId(Guid id)
        {
            try
            {
                UserDetail entity = new UserDetail();
                return entity.GetByParentId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(UserDetailModel model)
        {
            try
            {
                UserDetail entity = new UserDetail();
                return entity.Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserDetailModel Authenticate(string userName, string password)
        {
            try
            {
                UserDetail entity = new UserDetail();
                return entity.GetByUsernamePassword(userName, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
