using System;

namespace Model
{
    public class LookupModel
    {
        public Nullable<System.Guid> Id { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> PerentId { get; set; }
        public string PerentName { get; set; }
        public string Description { get; set; }
        public decimal? Rate { get; set; }
        public Nullable<bool> IsFlag { get; set; }
        public Nullable<int> Sequence { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }

        public string ReceivedBy { get; set; }
        public string updatedColumn { get; set; }
    }
}
