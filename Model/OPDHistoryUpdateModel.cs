using System;

namespace Model
{
    public class OPDHistoryUpdateModel
    {
        public System.Guid Id { get; set; }
        public System.Guid OPDHistoryId { get; set; }
        public Nullable<System.Guid> UpdatedBy { get; set; }
        public string UpdatedName { get; set; }
        public string UpdatedField { get; set; }
        public string UpdatedValue { get; set; }
        public string PreviousValue { get; set; }
        public string CasePaper { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    }
}
