using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PatientDetailModel
    {
        public Nullable<System.Guid> Id { get; set; }
        public string CasePaperNumber { get; set; }
        public string FullName { get; set; }
        public Nullable<int> Gender { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> Age { get; set; }
        public string Address { get; set; }
        public Nullable<bool> IsAdmitted { get; set; }
        public Nullable<System.DateTime> AdmittedDate { get; set; }
        public Nullable<bool> IsDischarged { get; set; }
        public Nullable<System.DateTime> DischargedDate { get; set; }
        public Nullable<System.Guid> RefferedDoctor { get; set; }
        public string RefferedDoctorName { get; set; }
        public Nullable<System.DateTime> CasePaperIssuedDate { get; set; }
        public Nullable<System.DateTime> CasePaperExpiryDate { get; set; }
        public Nullable<System.Guid> WardNumberId { get; set; }
        public string WardName { get; set; }
        public string RoomNumber { get; set; }
        public Nullable<System.Guid> RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public Nullable<System.Guid> DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public string AadharCard { get; set; }
        public string PanCard { get; set; }
        public string MobileNumber { get; set; }
        public OPDHistoryModel OPDHistory { get; set; }
        public decimal? IPDBillAmount { get; set; }

        public Guid? ReceivedBy { get; set; }
        public string ReceivedName { get; set; }
        public bool IsOldPatient { get; set; }       

    }
}
