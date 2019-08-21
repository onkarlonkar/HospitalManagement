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
    [MetadataType(typeof(DoctorDetailMD))]
    public partial class DoctorDetail
    {
        #region --- Property Declaration ---
        public class DoctorDetailMD
        {
            public System.Guid Id { get; set; }
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
        #endregion

        #region --- User Function ---

        public List<DoctorDetailModel> Get()
        {
            try
            {
                List<DoctorDetailModel> list = new List<DoctorDetailModel>();

                using (var db = new HMSEntities())
                {
                    list = db.DoctorDetails
                                .Where(t => t.IsActive == true && t.IsDeleted != true)
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new DoctorDetailModel()
                                {
                                    Id = t.Id,
                                    FullName = t.FullName,
                                    Address = t.Address,
                                    Gender = t.Gender,
                                    PhoneNumber = t.PhoneNumber,
                                    MobileNumber = t.MobileNumber,
                                    Age = t.Age,
                                    IsInHouse = t.IsInHouse,
                                    Qualification = t.Qualification,
                                    ClinicName = t.ClinicName,
                                    ClinicContact = t.ClinicContact,
                                    IsCounsalting = t.IsCounsalting,
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
        public DoctorDetailModel GetById(Guid id)
        {
            try
            {
                DoctorDetailModel model = new DoctorDetailModel();
                using (var db = new HMSEntities())
                {
                    DoctorDetail entity = db.DoctorDetails.Find(id);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.FullName = entity.FullName;
                        model.Address = entity.Address;
                        model.Gender = entity.Gender;
                        model.PhoneNumber = entity.PhoneNumber;
                        model.MobileNumber = entity.MobileNumber;
                        model.Age = entity.Age;
                        model.IsInHouse = entity.IsInHouse;
                        model.IsCounsalting = entity.IsCounsalting;
                        model.Qualification = entity.Qualification;
                        model.ClinicName = entity.ClinicName;
                        model.ClinicContact = entity.ClinicContact;
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
        public DoctorDetailModel GetByName(string name)
        {
            try
            {
                DoctorDetailModel model = new DoctorDetailModel();
                using (var db = new HMSEntities())
                {
                    DoctorDetail entity = db.DoctorDetails.FirstOrDefault(t => t.FullName == name);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.FullName = entity.FullName;
                        model.Address = entity.Address;
                        model.Gender = entity.Gender;
                        model.PhoneNumber = entity.PhoneNumber;
                        model.MobileNumber = entity.MobileNumber;
                        model.Age = entity.Age;
                        model.IsInHouse = entity.IsInHouse;
                        model.IsCounsalting = entity.IsCounsalting;
                        model.Qualification = entity.Qualification;
                        model.ClinicName = entity.ClinicName;
                        model.ClinicContact = entity.ClinicContact;
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
        public DoctorDetailModel GetByParentId(Guid id)
        {
            try
            {
                DoctorDetailModel model = new DoctorDetailModel();
                using (var db = new HMSEntities())
                {
                    DoctorDetail entity = db.DoctorDetails.FirstOrDefault();
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.FullName = entity.FullName;
                        model.Address = entity.Address;
                        model.Gender = entity.Gender;
                        model.PhoneNumber = entity.PhoneNumber;
                        model.MobileNumber = entity.MobileNumber;
                        model.Age = entity.Age;
                        model.IsInHouse = entity.IsInHouse;
                        model.IsCounsalting = entity.IsCounsalting;
                        model.Qualification = entity.Qualification;
                        model.ClinicName = entity.ClinicName;
                        model.ClinicContact = entity.ClinicContact;
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
        public bool Create(DoctorDetailModel model)
        {
            try
            {
                bool isSaved = false;

                //if (!IsExist(model))
                //{
                using (var db = new HMSEntities())
                {
                    DoctorDetail entity = new DoctorDetail();

                    entity.FullName = model.FullName;
                    entity.Address = model.Address;
                    entity.Gender = model.Gender;
                    entity.PhoneNumber = model.PhoneNumber;
                    entity.MobileNumber = model.MobileNumber;
                    entity.Age = model.Age;
                    entity.IsInHouse = model.IsInHouse;
                    entity.IsCounsalting = model.IsCounsalting;
                    entity.Qualification = model.Qualification;
                    entity.ClinicName = model.ClinicName;
                    entity.ClinicContact = model.ClinicContact;
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.CreatedOn = DateTime.Now;
                    entity.CreatedBy = UserDetailSession.Id;

                    db.DoctorDetails.Add(entity);
                    db.SaveChanges();

                    isSaved = true;
                }
                // }


                return isSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(DoctorDetailModel model)
        {
            try
            {
                bool isSaved = false;

                //if (!IsExist(model))
                //{
                using (var db = new HMSEntities())
                {
                    DoctorDetail entity = db.DoctorDetails.Find(model.Id);

                    entity.FullName = model.FullName;
                    entity.Address = model.Address;
                    entity.Gender = model.Gender;
                    entity.PhoneNumber = model.PhoneNumber;
                    entity.MobileNumber = model.MobileNumber;
                    entity.Age = model.Age;
                    entity.IsInHouse = model.IsInHouse;
                    entity.IsCounsalting = model.IsCounsalting;
                    entity.Qualification = model.Qualification;
                    entity.ClinicName = model.ClinicName;
                    entity.ClinicContact = model.ClinicContact;
                    entity.ModifiedOn = DateTime.Now;
                    entity.ModifiedBy = UserDetailSession.Id;

                    db.SaveChanges();

                    isSaved = true;
                }
                //}


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
        public List<DoctorDetailModel> AdvanceSearch(string searchText)
        {
            try
            {
                List<DoctorDetailModel> list = new List<DoctorDetailModel>();

                using (var db = new HMSEntities())
                {
                    list = db.DoctorDetails
                                 .Where(t => t.IsActive == true && t.IsDeleted != true && (t.FullName.Contains(searchText)
                                 || t.Address.Contains(searchText) || t.PhoneNumber.Contains(searchText)))
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new DoctorDetailModel()
                                {
                                    Id = t.Id,
                                    FullName = t.FullName,
                                    Address = t.Address,
                                    Gender = t.Gender,
                                    PhoneNumber = t.PhoneNumber,
                                    MobileNumber = t.MobileNumber,
                                    Age = t.Age,
                                    IsInHouse = t.IsInHouse,
                                    Qualification = t.Qualification,
                                    ClinicName = t.ClinicName,
                                    ClinicContact = t.ClinicContact,
                                    IsCounsalting = t.IsCounsalting,
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
        private bool IsExist(DoctorDetailModel model)
        {
            try
            {
                Expression<Func<DoctorDetail, bool>> predicate = null;

                using (var db = new HMSEntities())
                {
                    /* Build Predicate according to Create or Update */
                    if (!model.Id.HasValue)
                    {
                        predicate = o => o.IsActive == true && o.IsDeleted == false;//for Create Record
                    }
                    else
                    {
                        predicate = o => o.Id != model.Id && o.IsActive == true && o.IsDeleted == false;//for Update Record Record
                    }

                    /* return is Exist or not */
                    if (db.DoctorDetails.Any(predicate))
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
        public List<DoctorDetailModel> GetByType(bool isInHouse = false)
        {
            Expression<Func<DoctorDetail, bool>> predicate = t => t.IsActive == true && t.IsDeleted != true;

            if (isInHouse)
                predicate = t => t.IsActive == true && t.IsDeleted != true && t.IsInHouse == true;

            try
            {
                List<DoctorDetailModel> list = new List<DoctorDetailModel>();

                using (var db = new HMSEntities())
                {
                    list = db.DoctorDetails
                                .Where(predicate)
                                .OrderBy(c => c.CreatedOn)
                                .Select(t => new DoctorDetailModel()
                                {
                                    Id = t.Id,
                                    FullName = t.FullName,
                                    Address = t.Address,
                                    Gender = t.Gender,
                                    PhoneNumber = t.PhoneNumber,
                                    MobileNumber = t.MobileNumber,
                                    Age = t.Age,
                                    IsInHouse = t.IsInHouse,
                                    Qualification = t.Qualification,
                                    ClinicName = t.ClinicName,
                                    ClinicContact = t.ClinicContact,
                                    IsCounsalting = t.IsCounsalting,
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


        public static Guid? GetInHouse(string name)
        {
            using (var db = new HMSEntities())
            {
                return db.DoctorDetails.FirstOrDefault(t => t.FullName == name).Id;
            }
        }

        public  Guid? GetName(string name)
        {
            try
            {
                DoctorDetailModel model = new DoctorDetailModel();
                using (var db = new HMSEntities())
                {
                    return db.DoctorDetails.FirstOrDefault(t => t.FullName == name).Id;

                }

               
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
            return null;
        }


        #endregion
    }
}
