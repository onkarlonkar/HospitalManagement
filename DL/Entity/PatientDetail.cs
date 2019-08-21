//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatientDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PatientDetail()
        {
            this.PatientHistories = new HashSet<PatientHistory>();
            this.OPDHistories = new HashSet<OPDHistory>();
            this.BillHistories = new HashSet<BillHistory>();
            this.IPDHistories = new HashSet<IPDHistory>();
        }
    
        public System.Guid Id { get; set; }
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
        public Nullable<System.DateTime> CasePaperIssuedDate { get; set; }
        public Nullable<System.DateTime> CasePaperExpiryDate { get; set; }
        public Nullable<System.Guid> WardNumberId { get; set; }
        public string RoomNumber { get; set; }
        public Nullable<System.Guid> RoomTypeId { get; set; }
        public Nullable<System.Guid> DepartmentId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public string AadharCard { get; set; }
        public string PanCard { get; set; }
        public string MobileNumber { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual WardDetail WardDetail { get; set; }
        public virtual DoctorDetail DoctorDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientHistory> PatientHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OPDHistory> OPDHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillHistory> BillHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IPDHistory> IPDHistories { get; set; }
    }
}