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
    [MetadataType(typeof(LabDetailMD))]
    public partial class LabDetail
    {
        #region --- Property Declaration ---
        public class LabDetailMD
        {
            public System.Guid Id { get; set; }
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
        #endregion

        #region --- User Function ---

        public List<LabDetailModel> Get()
        {
            try
            {
                List<LabDetailModel> list = new List<LabDetailModel>();

                using (var db = new HMSEntities())
                {
                    list = db.LabDetails
                                .Where(t => t.IsActive == true && t.IsDeleted != true)
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new LabDetailModel()
                                {
                                    Id = t.Id,
                                    Name = t.Name,
                                    PathelogistName = t.PathelogistName,
                                    Address = t.Address,
                                    PhoneNumber = t.PhoneNumber,
                                    IsInHouse = t.IsInHouse,
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
        public LabDetailModel GetById(Guid id)
        {
            try
            {
                LabDetailModel model = new LabDetailModel();
                using (var db = new HMSEntities())
                {
                    LabDetail entity = db.LabDetails.Find(id);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.Name = entity.Name;
                        model.PathelogistName = entity.PathelogistName;
                        model.Address = entity.Address;
                        model.PhoneNumber = entity.PhoneNumber;
                        model.IsInHouse = entity.IsInHouse;
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
        public LabDetailModel GetByName(string name)
        {
            try
            {
                LabDetailModel model = new LabDetailModel();
                using (var db = new HMSEntities())
                {
                    LabDetail entity = db.LabDetails.FirstOrDefault(t => t.Name == name);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.Name = entity.Name;
                        model.PathelogistName = entity.PathelogistName;
                        model.Address = entity.Address;
                        model.PhoneNumber = entity.PhoneNumber;
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
        public bool Create(LabDetailModel model)
        {
            try
            {
                bool isSaved = false;

                if (!IsExist(model))
                {
                    using (var db = new HMSEntities())
                    {
                        LabDetail entity = new LabDetail();

                        entity.Name = model.Name;
                        entity.PathelogistName = model.PathelogistName;
                        entity.Address = model.Address;
                        entity.PhoneNumber = model.PhoneNumber;
                        entity.IsInHouse = model.IsInHouse.HasValue ? model.IsInHouse.Value : false;
                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.CreatedOn = DateTime.Now;
                        entity.CreatedBy = UserDetailSession.Id;

                        db.LabDetails.Add(entity);
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
        public bool Update(LabDetailModel model)
        {
            try
            {
                bool isSaved = false;

                if (!IsExist(model))
                {
                    using (var db = new HMSEntities())
                    {
                        //UpdateAllSequence(model.Id, model.Sequence.Value, model.PerentId);
                        LabDetail entity = db.LabDetails.Find(model.Id);
                        entity.Name = model.Name;
                        entity.PathelogistName = model.PathelogistName;
                        entity.Address = model.Address;
                        entity.PhoneNumber = model.PhoneNumber;
                        entity.IsInHouse = model.IsInHouse.HasValue ? model.IsInHouse.Value : false;
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
        public List<LabDetailModel> AdvanceSearch(string searchText)
        {
            try
            {
                List<LabDetailModel> list = new List<LabDetailModel>();

                using (var db = new HMSEntities())
                {
                    list = db.LabDetails
                                 .Where(t => t.IsActive == true && t.IsDeleted != true && (t.Name.Contains(searchText)))
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new LabDetailModel()
                                {
                                    Id = t.Id,
                                    Name = t.Name,
                                    PathelogistName = t.PathelogistName,
                                    Address = t.Address,
                                    PhoneNumber = t.PhoneNumber,
                                    IsInHouse = t.IsInHouse,
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
        private bool IsExist(LabDetailModel model)
        {
            try
            {
                Expression<Func<LabDetail, bool>> predicate = null;

                using (var db = new HMSEntities())
                {
                    /* Build Predicate according to Create or Update */
                    if (!model.Id.HasValue)
                    {
                        predicate = o => o.Name == model.Name && o.IsActive == true && o.IsDeleted == false;//for Create Record
                    }
                    else
                    {
                        predicate = o => o.Name == model.Name && o.Id != model.Id && o.IsActive == true && o.IsDeleted == false;//for Update Record Record
                    }

                    /* return is Exist or not */
                    if (db.LabDetails.Any(predicate))
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
        public static List<LabDetailModel> GetLabDetails(Expression<Func<LabDetail, bool>> predicate)
        {
            try
            {
                List<LabDetailModel> list = new List<LabDetailModel>();
                using (var db = new HMSEntities())
                {
                    list = db.LabDetails
                                    .Where(t => t.IsActive == true && t.IsDeleted != true).Where(predicate)
                                   .Select(t => new LabDetailModel()
                                   {
                                       Id = t.Id,
                                       Name = t.Name,
                                       PathelogistName = t.PathelogistName,
                                       Address = t.Address,
                                       PhoneNumber = t.PhoneNumber,
                                       IsInHouse = t.IsInHouse,
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
        public  List<LabDetailModel> GetNonInHouse()
        {
            try
            {
                List<LabDetailModel> list = new List<LabDetailModel>();
                using (var db = new HMSEntities())
                {
                    list = db.LabDetails.Where(t => t.IsActive == true && t.IsDeleted != true && t.IsInHouse == false).Select(t => new LabDetailModel()
                    {
                        Id = t.Id,
                        Name = t.Name,
                        PathelogistName = t.PathelogistName,
                        Address = t.Address,
                        PhoneNumber = t.PhoneNumber,
                        IsInHouse = t.IsInHouse,
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


        #endregion
    }
}
