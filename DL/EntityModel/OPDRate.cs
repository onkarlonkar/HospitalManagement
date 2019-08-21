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
    [MetadataType(typeof(OPDRateMD))]
    public partial class OPDRate
    {
        #region --- Property Declaration ---
        public class OPDRateMD
        {
            public System.Guid Id { get; set; }
            public string Type { get; set; }
            public Nullable<decimal> Rate { get; set; }
            public Nullable<bool> IsDefault { get; set; }
            public Nullable<bool> IsActive { get; set; }
            public Nullable<bool> IsDeleted { get; set; }
            public Nullable<System.Guid> CreatedBy { get; set; }
            public Nullable<System.DateTime> CreatedOn { get; set; }
            public Nullable<System.Guid> ModifiedBy { get; set; }
            public Nullable<System.DateTime> ModifiedOn { get; set; }
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

                    list = db.OPDRates
                                .Where(t => t.IsActive == true && t.IsDeleted != true)
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new LookupModel()
                                {
                                    Id = t.Id,
                                    Name = t.Type,
                                    Rate = t.Rate,
                                    IsFlag = t.IsDefault,
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
                    OPDRate entity = db.OPDRates.Find(id);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.Name = entity.Type;
                        model.Rate = entity.Rate;
                        model.IsFlag = entity.IsDefault;
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
                    OPDRate entity = db.OPDRates.FirstOrDefault(t => t.Type == name);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.Name = entity.Type;
                        model.Rate = entity.Rate;
                        model.IsFlag = entity.IsDefault;
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
                        OPDRate entity = new OPDRate();

                        entity.Type = model.Name;
                        entity.Rate = (!model.Rate.HasValue) ? 0.00M : model.Rate;
                        entity.IsDefault = model.IsFlag;
                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.CreatedOn = DateTime.Now;
                        entity.CreatedBy = UserDetailSession.Id;

                        db.OPDRates.Add(entity);
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
                        //UpdateAllSequence(model.Id, model.Sequence.Value, model.PerentId);
                        OPDRate entity = db.OPDRates.Find(model.Id);
                        entity.Type = model.Name;
                        entity.Rate = (!model.Rate.HasValue) ? 0.00M : model.Rate;
                        entity.IsDefault = true;
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
                    //var query = db.Departments.Join(db.PatientDetails, dep => dep.Id, pa => pa.DepartmentId, (cl, or) => new { Department = cl, PatientDetail = or }).Where(x => x.PatientDetail.DepartmentId == new Guid("7683F25D-3441-4AD4-B704-10BD193A30E9")).ToList();
                    list = db.OPDRates
                              .Where(t => t.IsActive == true && t.IsDeleted != true && (t.Type.Contains(searchText)))
                             .OrderByDescending(c => c.CreatedOn)
                             .Select(t => new LookupModel()
                             {
                                 Id = t.Id,
                                 Name = t.Type,                              
                                 Rate = t.Rate,
                                 IsFlag = t.IsDefault,
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
                Expression<Func<OPDRate, bool>> predicate = null;

                using (var db = new HMSEntities())
                {
                    /* Build Predicate according to Create or Update */
                    if (!model.Id.HasValue)
                    {
                        predicate = o => o.Type == model.Name && o.IsDefault == model.IsFlag && o.IsActive == true && o.IsDeleted == false;//for Create Record
                    }
                    else
                    {
                        predicate = o => o.Type == model.Name && o.IsDefault == model.IsFlag && o.Id != model.Id && o.IsActive == true && o.IsDeleted == false;//for Update Record Record
                    }

                    /* return is Exist or not */
                    if (db.OPDRates.Any(predicate))
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
        public static List<LookupModel> GetOPDRates(Expression<Func<OPDRate, bool>> predicate)
        {
            try
            {
                List<LookupModel> list = new List<LookupModel>();
                using (var db = new HMSEntities())
                {
                    list = db.OPDRates
                                    .Where(t => t.IsActive == true && t.IsDeleted != true).Where(predicate)
                                   .Select(t => new LookupModel()
                                   {
                                       Id = t.Id,
                                       Name = t.Type,
                                       Rate = t.Rate,
                                       IsFlag = t.IsDefault,
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
        public static LookupModel GetRatesByType(string type)
        {
            try
            {
                LookupModel model = new LookupModel();
                using (var db = new HMSEntities())
                {
                    OPDRate entity = db.OPDRates.FirstOrDefault(t => t.IsActive == true && t.IsDeleted != true && t.Type == type && t.IsDefault == true);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.Name = entity.Type;
                        model.Rate = entity.Rate;
                        model.IsFlag = entity.IsDefault;
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


        #endregion
    }
}
