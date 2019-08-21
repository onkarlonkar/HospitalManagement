using System;

namespace Model
{
    public class LabDetailModel
    {
        public Nullable<System.Guid> Id { get; set; }
        public string Name { get; set; }
        public string PathelogistName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<bool> IsInHouse { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
    }
}
