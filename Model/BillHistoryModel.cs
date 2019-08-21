using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BillHistoryModel
    {
        public Nullable<System.Guid> Id { get; set; }
        public System.Guid PatientId { get; set; }
        public string PatientName { get; set; }
        public System.Guid OPDHistoryId { get; set; }   
        public int ReceiptNumber { get; set; }
        public Nullable<int> PrintCopys { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> LastPrintedBy { get; set; }
        public Nullable<System.DateTime> LastPrintedOn { get; set; }
    }

   
}
