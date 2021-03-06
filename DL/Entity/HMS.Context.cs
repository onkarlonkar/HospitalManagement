﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HMSEntities : DbContext
    {
        public HMSEntities()
            : base("name=HMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<LabDetail> LabDetails { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<MedicineCategory> MedicineCategories { get; set; }
        public virtual DbSet<MedicineTiming> MedicineTimings { get; set; }
        public virtual DbSet<MedicineType> MedicineTypes { get; set; }
        public virtual DbSet<RoleCategory> RoleCategories { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<WardDetail> WardDetails { get; set; }
        public virtual DbSet<DoctorDetail> DoctorDetails { get; set; }
        public virtual DbSet<PatientDetail> PatientDetails { get; set; }
        public virtual DbSet<OPDHistory> OPDHistories { get; set; }
        public virtual DbSet<PatientHistory> PatientHistories { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<BillHistory> BillHistories { get; set; }
        public virtual DbSet<OPDRate> OPDRates { get; set; }
        public virtual DbSet<OPDHistoryUpdate> OPDHistoryUpdates { get; set; }
        public virtual DbSet<IPDHistory> IPDHistories { get; set; }
        public virtual DbSet<TPLabPatientMapping> TPLabPatientMappings { get; set; }
    }
}
