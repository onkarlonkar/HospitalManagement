using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DoctorDetailModel
    {
        public Nullable<System.Guid> Id { get; set; }
        public string FullName { get; set; }
        public Nullable<int> Gender { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> Age { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public Nullable<bool> IsCounsalting { get; set; }
        public Nullable<bool> IsInHouse { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public string MobileNumber { get; set; }
        public string ClinicName { get; set; }
        public string ClinicContact { get; set; }
    }
}
