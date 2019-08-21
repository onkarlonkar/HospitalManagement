using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IBillHistoryService
    {
        List<BillHistoryModel> Get();

        BillHistoryModel GetByParentId(Guid id);
        BillHistoryModel GetByOPDId(Guid id);
        bool Create(BillHistoryModel model);
        bool Update(Guid? id);
        bool Delete(Guid id);

    }
}
