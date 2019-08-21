using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FilterSearchModel
    {
    }

    public class OPDFilterSearchModel
    {
        public string searchText { get; set; }
        public DateTime? from { get; set; }
        public DateTime? to { get; set; }

        public List<Nullable<System.Guid>> ConsultingId { get; set; }
        public List<Nullable<System.Guid>> StatusId { get; set; }
    }
}
