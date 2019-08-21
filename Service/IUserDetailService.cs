using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserDetailService
    {
        List<UserDetailModel> Get();
        UserDetailModel GetById(Guid id);
        bool Create(UserDetailModel model);
        bool Update(UserDetailModel model);
        bool Delete(Guid id);
        UserDetailModel GetByName(string name);
        UserDetailModel GetByParentId(Guid id);
        List<UserDetailModel> AdvanceSearch(string searchText);

        UserDetailModel Authenticate(string userName,string password);
    }
}
