using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserDetailModel
    {
        public Nullable<System.Guid> Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<System.Guid> DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<System.Guid> RoleCategoryId { get; set; }
        public string RoleCategoryName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
    }

    public static class UserDetailSession
    {
        public static Nullable<System.Guid> Id { get; set; }
        public static string FullName { get; set; }
        public static string Address { get; set; }
        public static string PhoneNumber { get; set; }
        public static Nullable<System.Guid> DepartmentId { get; set; }
        public static string DepartmentName { get; set; }
        public static Nullable<System.Guid> RoleCategoryId { get; set; }
        public static string RoleCategoryName { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static int lastPatientCount { get; set; }

        public static int NumberPatientCount { get; set; }
    }
}
