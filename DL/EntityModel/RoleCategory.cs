using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace DL.Entity
{
    [MetadataType(typeof(RoleCategoryMD))]
    public partial class RoleCategory
    {
        #region --- Property Declaration ---
        public class RoleCategoryMD
        {
            public System.Guid Id { get; set; }
            public string Name { get; set; }         
            public string Description { get; set; }
            public Nullable<bool> IsActive { get; set; }
            public Nullable<bool> IsDeleted { get; set; }
            public Nullable<System.DateTime> CreatedOn { get; set; }
            public Nullable<System.Guid> CreatedBy { get; set; }
            public Nullable<System.DateTime> ModifiedOn { get; set; }
            public Nullable<System.Guid> ModifiedBy { get; set; }
        }
        #endregion

        #region --- User Function ---

        public List<LookupModel> Get()
        {
            try
            {
                List<LookupModel> list = new List<LookupModel>();

                using (var db = new HMSEntities())
                {
                    list = db.RoleCategories
                                .Where(t => t.IsActive == true && t.IsDeleted != true)
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new LookupModel()
                                {
                                    Id = t.Id,
                                    Name = t.Name,
                                    Description = t.Description,                                   
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

        public LookupModel GetById(Guid id)
        {
            try
            {
                LookupModel model = new LookupModel();
                using (var db = new HMSEntities())
                {
                    RoleCategory entity = db.RoleCategories.Find(id);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.Name = entity.Name;
                        model.Description = entity.Description;                       
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

        public LookupModel GetByName(string name)
        {
            try
            {
                LookupModel model = new LookupModel();
                using (var db = new HMSEntities())
                {
                    RoleCategory entity = db.RoleCategories.FirstOrDefault(t => t.Name == name);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.Name = entity.Name;
                        model.Description = entity.Description;                       
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
  
        public bool Create(LookupModel model)
        {
            try
            {
                bool isSaved = false;

                if (!IsExist(model))
                {
                    using (var db = new HMSEntities())
                    {
                        RoleCategory entity = new RoleCategory();

                        entity.Name = model.Name;                     
                        entity.Description = model.Description;                      
                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.CreatedOn = DateTime.Now;
                        entity.CreatedBy = UserDetailSession.Id;

                        db.RoleCategories.Add(entity);
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
        public bool Update(LookupModel model)
        {
            try
            {
                bool isSaved = false;

                if (!IsExist(model))
                {
                    using (var db = new HMSEntities())
                    {
                        RoleCategory entity = db.RoleCategories.Find(model.Id);

                        entity.Name = model.Name;                      
                        entity.Description = model.Description;                       
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

        public List<LookupModel> AdvanceSearch(string searchText)
        {
            try
            {
                List<LookupModel> list = new List<LookupModel>();

                using (var db = new HMSEntities())
                {
                    list = db.RoleCategories
                                 .Where(t => t.IsActive == true && t.IsDeleted != true && (t.Name.Contains(searchText) || t.Description.Contains(searchText)))
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new LookupModel()
                                {
                                    Id = t.Id,
                                    Name = t.Name,
                                    Description = t.Description,                                   
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

        private bool IsExist(LookupModel model)
        {
            try
            {
                Expression<Func<RoleCategory, bool>> predicate = null;

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
                    if (db.RoleCategories.Any(predicate))
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
        #endregion  
    }
}
