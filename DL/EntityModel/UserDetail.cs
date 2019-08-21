using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entity
{
    [MetadataType(typeof(UserDetailMD))]
    public partial class UserDetail
    {
        #region --- Property Declaration ---
        public class UserDetailMD
        {
            public System.Guid Id { get; set; }
            public string FullName { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public Nullable<System.Guid> DepartmentId { get; set; }
            public Nullable<System.Guid> RoleCategoryId { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public Nullable<bool> IsActive { get; set; }
            public Nullable<bool> IsDeleted { get; set; }
            public Nullable<System.DateTime> CreatedOn { get; set; }
            public Nullable<System.DateTime> ModifiedOn { get; set; }
            public Nullable<System.Guid> CreatedBy { get; set; }
            public Nullable<System.Guid> ModifiedBy { get; set; }
        }
        #endregion

        #region --- User Function ---

        public List<UserDetailModel> Get()
        {
            try
            {
                List<UserDetailModel> list = new List<UserDetailModel>();
                Expression<Func<UserDetail, bool>> predicate = t => t.IsActive == true && t.IsDeleted == false;


                using (var db = new HMSEntities())
                {

                    //string role = db.RoleCategories.Find(UserDetailSession.RoleCategoryId).Name;
                    //if (role != "Admin" || role != "Super Admin")
                    //    predicate = t => t.IsActive == true && t.IsDeleted == false && t.Id == UserDetailSession.Id;

                    list = db.UserDetails
                                .Where(predicate)
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new UserDetailModel()
                                {
                                    Id = t.Id,
                                    FullName = t.FullName,
                                    Address = t.Address,
                                    DepartmentId = t.DepartmentId,
                                    PhoneNumber = t.PhoneNumber,
                                    DepartmentName = t.Department.Name,
                                    RoleCategoryId = t.RoleCategoryId,
                                    RoleCategoryName = t.RoleCategory.Name,
                                    UserName = t.UserName,
                                    Password = t.Password,
                                    IsActive = t.IsActive,
                                    IsDeleted = t.IsDeleted,
                                    CreatedOn = t.CreatedOn,
                                    CreatedBy = t.CreatedBy,
                                    ModifiedOn = t.ModifiedOn,
                                    ModifiedBy = t.ModifiedBy
                                }).ToList();
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserDetailModel GetById(Guid id)
        {
            try
            {
                UserDetailModel model = new UserDetailModel();
                using (var db = new HMSEntities())
                {
                    UserDetail entity = db.UserDetails.Find(id);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.FullName = entity.FullName;
                        model.Address = entity.Address;
                        model.PhoneNumber = entity.PhoneNumber;
                        model.DepartmentId = entity.DepartmentId;
                        model.DepartmentName = entity.Department.Name;
                        model.RoleCategoryId = entity.RoleCategoryId;
                        model.RoleCategoryName = entity.RoleCategory.Name;
                        model.UserName = entity.UserName;
                        model.Password = entity.Password;
                        model.IsActive = entity.IsActive;
                        model.IsDeleted = entity.IsDeleted;
                        model.CreatedOn = entity.CreatedOn;
                        model.CreatedBy = entity.CreatedBy;
                        model.ModifiedOn = entity.ModifiedOn;
                        model.ModifiedBy = entity.ModifiedBy;
                    }

                }

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserDetailModel GetByUsernamePassword(string username, string password)
        {
            try
            {
                UserDetailModel model = new UserDetailModel();
                using (var db = new HMSEntities())
                {
                    UserDetail entity = db.UserDetails.FirstOrDefault(t => t.UserName.ToLower() == username.ToLower() && t.Password == password);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.FullName = entity.FullName;
                        model.Address = entity.Address;
                        model.PhoneNumber = entity.PhoneNumber;
                        model.DepartmentId = entity.DepartmentId;
                        model.DepartmentName = entity.Department.Name;
                        model.RoleCategoryId = entity.RoleCategoryId;
                        model.RoleCategoryName = entity.RoleCategory.Name;
                        model.UserName = entity.UserName;
                        model.Password = entity.Password;
                        model.IsActive = entity.IsActive;
                        model.IsDeleted = entity.IsDeleted;
                        model.CreatedOn = entity.CreatedOn;
                        model.CreatedBy = entity.CreatedBy;
                        model.ModifiedOn = entity.ModifiedOn;
                        model.ModifiedBy = entity.ModifiedBy;
                    }

                }

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserDetailModel GetByName(string name)
        {
            try
            {
                UserDetailModel model = new UserDetailModel();
                using (var db = new HMSEntities())
                {
                    UserDetail entity = db.UserDetails.FirstOrDefault(t => t.FullName == name);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.FullName = entity.FullName;
                        model.Address = entity.Address;
                        model.PhoneNumber = entity.PhoneNumber;
                        model.DepartmentId = entity.DepartmentId;
                        model.DepartmentName = entity.Department.Name;
                        model.RoleCategoryId = entity.RoleCategoryId;
                        model.RoleCategoryName = entity.RoleCategory.Name;
                        model.UserName = entity.UserName;
                        model.Password = entity.Password;
                        model.IsActive = entity.IsActive;
                        model.IsDeleted = entity.IsDeleted;
                        model.CreatedOn = entity.CreatedOn;
                        model.CreatedBy = entity.CreatedBy;
                        model.ModifiedOn = entity.ModifiedOn;
                        model.ModifiedBy = entity.ModifiedBy;
                    }

                }

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserDetailModel GetByParentId(Guid id)
        {
            try
            {
                UserDetailModel model = new UserDetailModel();
                using (var db = new HMSEntities())
                {
                    UserDetail entity = db.UserDetails.FirstOrDefault(t => t.DepartmentId == id);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.FullName = entity.FullName;
                        model.Address = entity.Address;
                        model.PhoneNumber = entity.PhoneNumber;
                        model.DepartmentId = entity.DepartmentId;
                        model.DepartmentName = entity.Department.Name;
                        model.RoleCategoryId = entity.RoleCategoryId;
                        model.RoleCategoryName = entity.RoleCategory.Name;
                        model.UserName = entity.UserName;
                        model.Password = entity.Password;
                        model.IsActive = entity.IsActive;
                        model.IsDeleted = entity.IsDeleted;
                        model.CreatedOn = entity.CreatedOn;
                        model.CreatedBy = entity.CreatedBy;
                        model.ModifiedOn = entity.ModifiedOn;
                        model.ModifiedBy = entity.ModifiedBy;
                    }

                }

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(UserDetailModel model)
        {
            try
            {
                bool isSaved = false;

                if (!IsExist(model))
                {
                    using (var db = new HMSEntities())
                    {
                        UserDetail entity = new UserDetail();

                        entity.FullName = model.FullName;
                        entity.Address = model.Address;
                        entity.PhoneNumber = model.PhoneNumber;
                        entity.DepartmentId = Department.GetByName("OPD").Id;
                        entity.RoleCategoryId = RoleCategory.GetByName("Genaral").Id;
                        entity.UserName = model.UserName;
                        entity.Password = model.Password;
                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.CreatedOn = DateTime.Now;
                        entity.CreatedBy = UserDetailSession.Id;

                        db.UserDetails.Add(entity);
                        db.SaveChanges();

                        isSaved = true;
                    }
                }


                return isSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(UserDetailModel model)
        {
            try
            {
                bool isSaved = false;

                if (!IsExist(model))
                {
                    using (var db = new HMSEntities())
                    {
                        UserDetail entity = db.UserDetails.Find(model.Id);

                        entity.FullName = model.FullName;
                        entity.Address = model.Address;
                        entity.PhoneNumber = model.PhoneNumber;
                        entity.DepartmentId = UserDetailSession.DepartmentId;
                        entity.RoleCategoryId = UserDetailSession.RoleCategoryId;
                        entity.UserName = model.UserName;
                        entity.Password = model.Password;
                        entity.ModifiedOn = DateTime.Now;
                        entity.ModifiedBy = UserDetailSession.Id;

                        db.SaveChanges();

                        isSaved = true;
                    }
                }


                return isSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(Guid id)
        {
            return true;
        }

        public List<UserDetailModel> AdvanceSearch(string searchText)
        {
            try
            {
                List<UserDetailModel> list = new List<UserDetailModel>();
                Expression<Func<UserDetail, bool>> predicate = t => t.IsActive == true && t.IsDeleted == false;

                using (var db = new HMSEntities())
                {
                    string role = db.RoleCategories.Find(UserDetailSession.RoleCategoryId).Name;
                    if (role != "Admin")
                        predicate = t => t.IsActive == true && t.IsDeleted == false && t.Id == UserDetailSession.Id;

                    list = db.UserDetails.Where(predicate)
                                 .Where(t => (t.FullName.Contains(searchText)
                                 || t.Address.Contains(searchText) || t.Department.Name.Contains(searchText)
                                 || t.RoleCategory.Name.Contains(searchText) || t.PhoneNumber.Contains(searchText)))
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new UserDetailModel()
                                {
                                    Id = t.Id,
                                    FullName = t.FullName,
                                    Address = t.Address,
                                    DepartmentId = t.DepartmentId,
                                    PhoneNumber = t.PhoneNumber,
                                    DepartmentName = t.Department.Name,
                                    RoleCategoryId = t.RoleCategoryId,
                                    RoleCategoryName = t.RoleCategory.Name,
                                    UserName = t.UserName,
                                    Password = t.Password,
                                    IsActive = t.IsActive,
                                    IsDeleted = t.IsDeleted,
                                    CreatedOn = t.CreatedOn,
                                    CreatedBy = t.CreatedBy,
                                    ModifiedOn = t.ModifiedOn,
                                    ModifiedBy = t.ModifiedBy
                                }).ToList();
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool IsExist(UserDetailModel model)
        {
            try
            {
                Expression<Func<UserDetail, bool>> predicate = null;

                using (var db = new HMSEntities())
                {
                    /* Build Predicate according to Create or Update */
                    if (!model.Id.HasValue)
                    {
                        predicate = o => o.UserName == model.UserName && o.IsActive == true && o.IsDeleted == false;//for Create Record
                    }
                    else
                    {
                        predicate = o => o.UserName == model.UserName && o.Id != model.Id && o.IsActive == true && o.IsDeleted == false;//for Update Record Record
                    }

                    /* return is Exist or not */
                    if (db.UserDetails.Any(predicate))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static string GetNameById(Guid id)
        {
            try
            {
                UserDetailModel model = new UserDetailModel();
                using (var db = new HMSEntities())
                {
                    UserDetail entity = db.UserDetails.Find(id);
                    if (entity != null)
                    {
                        return entity.FullName;
                    }


                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
