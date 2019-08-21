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
    [MetadataType(typeof(StatusMD))]
    public partial class Status
    {
        #region --- Property Declaration ---
        public class StatusMD
        {
            public System.Guid Id { get; set; }
            public Nullable<System.Guid> DepartmentId { get; set; }
            public string Name { get; set; }
            public Nullable<int> Sequence { get; set; }
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
                    list = db.Status
                                .Where(t => t.IsActive == true && t.IsDeleted != true)
                                .OrderBy(c => c.Sequence)
                                .Select(t => new LookupModel()
                                {
                                    Id = t.Id,
                                    Name = t.Name,
                                    Description = t.Description,
                                    Sequence = t.Sequence,
                                    PerentId = t.DepartmentId,
                                    PerentName = t.Department.Name,
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

        public List<LookupModel> GetNextStatus(int sequence)
        {
            try
            {
                List<LookupModel> list = new List<LookupModel>();

                using (var db = new HMSEntities())
                {
                    list = db.Status
                                .Where(t => t.IsActive == true && t.IsDeleted != true && t.Sequence == sequence + 1)
                                .OrderByDescending(c => c.Sequence)
                                .Select(t => new LookupModel()
                                {
                                    Id = t.Id,
                                    Name = t.Name,
                                    Description = t.Description,
                                    Sequence = t.Sequence,
                                    PerentId = t.DepartmentId,
                                    PerentName = t.Department.Name,
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
                    Status entity = db.Status.Find(id);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.Name = entity.Name;
                        model.Description = entity.Description;
                        model.Sequence = entity.Sequence;
                        model.PerentId = entity.DepartmentId;
                        model.PerentName = entity.Department.Name;
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
                    Status entity = db.Status.FirstOrDefault(t => t.Name == name);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.Name = entity.Name;
                        model.Description = entity.Description;
                        model.Sequence = entity.Sequence;
                        model.PerentId = entity.DepartmentId;
                        model.PerentName = entity.Department.Name;
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
        public LookupModel GetByParentId(Guid id)
        {
            try
            {
                LookupModel model = new LookupModel();
                using (var db = new HMSEntities())
                {
                    Status entity = db.Status.FirstOrDefault(t => t.DepartmentId == id);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.Name = entity.Name;
                        model.Description = entity.Description;
                        model.Sequence = entity.Sequence;
                        model.PerentId = entity.DepartmentId;
                        model.PerentName = entity.Department.Name;
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
                        Status entity = new Status();

                        entity.Name = model.Name;
                        entity.DepartmentId = model.PerentId;
                        entity.Description = model.Description;
                        entity.Sequence = model.Sequence;
                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.CreatedOn = DateTime.Now;
                        entity.CreatedBy = UserDetailSession.Id;

                        db.Status.Add(entity);
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
                        UpdateAllSequence(model.Id, model.Sequence.Value, model.PerentId);
                        Status entity = db.Status.Find(model.Id);

                        entity.Name = model.Name;
                        entity.DepartmentId = model.PerentId;
                        entity.Description = model.Description;
                        entity.Sequence = model.Sequence;
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

        private void UpdateAllSequence(Guid? id, int sequence, Guid? departmentId)
        {
            try
            {
                using (var db = new HMSEntities())
                {
                    List<Status> entity = db.Status.Where(t => t.Sequence >= sequence && t.DepartmentId == departmentId.Value && t.Id != id).OrderBy(t => t.Sequence).ToList();
                    foreach (Status item in entity)
                    {
                        item.Sequence = sequence + 1;
                        sequence++;
                    }
                    db.SaveChanges();
                }
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
                    list = db.Status
                                 .Where(t => t.IsActive == true && t.IsDeleted != true && (t.Name.Contains(searchText) || t.Description.Contains(searchText) || t.Department.Name.Contains(searchText)))
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new LookupModel()
                                {
                                    Id = t.Id,
                                    Name = t.Name,
                                    Description = t.Description,
                                    Sequence = t.Sequence,
                                    PerentId = t.DepartmentId,
                                    PerentName = t.Department.Name,
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
                Expression<Func<Status, bool>> predicate = null;

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
                    if (db.Status.Any(predicate))
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

        public static List<LookupModel> GetStatus(Expression<Func<Status, bool>> predicate)
        {
            try
            {
                List<LookupModel> list = new List<LookupModel>();
                using (var db = new HMSEntities())
                {
                    list = db.Status
                                    .Where(t => t.IsActive == true && t.IsDeleted != true).Where(predicate)
                                   .Select(t => new LookupModel()
                                   {
                                       Id = t.Id,
                                       Name = t.Name,
                                       Description = t.Description,
                                       Sequence = t.Sequence,
                                       PerentId = t.DepartmentId,
                                       PerentName = t.Department.Name,
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

        public static Guid? GetIdByName(string name)
        {
            try
            {
                using (var db = new HMSEntities())
                {
                    return db.Status.FirstOrDefault(t => t.Name == name).Id;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static string GetNameById(Guid? id)
        {
            try
            {
                using (var db = new HMSEntities())
                {
                    return db.Status.Find(id).Name;
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
