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
    [MetadataType(typeof(TPLabPatientMappingMD))]
    public partial class TPLabPatientMapping
    {
        #region --- Property Declaration ---
        public class TPLabPatientMappingMD
        {
            public System.Guid Id { get; set; }
            public Nullable<System.Guid> OPDHistoryId { get; set; }
            public Nullable<System.Guid> LabId { get; set; }
            public Nullable<decimal> Amount { get; set; }
            public Nullable<System.Guid> Createdby { get; set; }
            public Nullable<System.DateTime> CreatedOn { get; set; }
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

                    list = db.TPLabPatientMappings
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new LookupModel()
                                {
                                    Id = t.Id,
                                    Name = t.LabDetail.Name,
                                    Rate = t.Amount,
                                    PerentId = t.OPDHistoryId,
                                    CreatedOn = t.CreatedOn,
                                    CreatedBy = t.Createdby,
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

        public List<LookupModel> GetByOPDId(Guid id)
        {
            try
            {
                List<LookupModel> list = new List<LookupModel>();

                using (var db = new HMSEntities())
                {

                    list = db.TPLabPatientMappings.Where(t => t.OPDHistoryId == id)
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new LookupModel()
                                {
                                    Id = t.Id,
                                    Name = t.LabDetail.Name,
                                    Rate = t.Amount,
                                    PerentId = t.OPDHistoryId,
                                    CreatedOn = t.CreatedOn,
                                    CreatedBy = t.Createdby,
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
                    TPLabPatientMapping entity = db.TPLabPatientMappings.Find(id);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.PerentId = entity.OPDHistoryId;
                        model.Name = entity.LabDetail.Name;
                        model.SubPerentId = entity.LabId;
                        model.Rate = entity.Amount; ;
                        model.CreatedOn = entity.CreatedOn;
                        model.CreatedBy = entity.Createdby;
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

        public bool CreateUpdate(List<LookupModel> model)
        {
            try
            {

                foreach (LookupModel item in model)
                {
                    if (item.Id != null)
                        return Update(item);
                    else
                        return Create(item);
                }
                return false;

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


                using (var db = new HMSEntities())
                {
                    TPLabPatientMapping entity = new TPLabPatientMapping();
                    entity.LabId = model.SubPerentId;
                    entity.OPDHistoryId = model.PerentId;
                    entity.Amount = (!model.Rate.HasValue) ? 0.00M : model.Rate;
                    entity.CreatedOn = DateTime.Now;
                    entity.Createdby = UserDetailSession.Id;
                    db.TPLabPatientMappings.Add(entity);
                    db.SaveChanges();

                    isSaved = true;
                    UpdateTPOPDAmount(model.PerentId.Value);
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


                using (var db = new HMSEntities())
                {
                    //UpdateAllSequence(model.Id, model.Sequence.Value, model.PerentId);
                    TPLabPatientMapping entity = db.TPLabPatientMappings.Find(model.Id);
                    entity.LabId = model.SubPerentId;
                    entity.OPDHistoryId = model.PerentId;
                    entity.Amount = (!model.Rate.HasValue) ? 0.00M : model.Rate;
                    entity.ModifiedOn = DateTime.Now;
                    entity.ModifiedBy = UserDetailSession.Id;

                    db.SaveChanges();

                    isSaved = true;
                    UpdateTPOPDAmount(model.PerentId.Value);
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
                    list = db.TPLabPatientMappings
                              .Where(t => (t.LabDetail.Name.Contains(searchText)))
                             .OrderByDescending(c => c.CreatedOn)
                             .Select(t => new LookupModel()
                             {
                                 Id = t.Id,
                                 Name = t.LabDetail.Name,
                                 Rate = t.Amount,
                                 PerentId = t.OPDHistoryId,
                                 CreatedOn = t.CreatedOn,
                                 CreatedBy = t.Createdby,
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
        public static decimal GetTPAmount(Guid id)
        {
            try
            {
                using (var db = new HMSEntities())
                {
                    return db.TPLabPatientMappings.Where(t => t.OPDHistoryId == id).Sum(t => t.Amount.Value);
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void UpdateTPOPDAmount(Guid id)
        {
            using (var db = new HMSEntities())
            {
                decimal? amount = db.TPLabPatientMappings.Where(t => t.OPDHistoryId == id).Sum(t => t.Amount.Value);
                if (amount != null)
                {
                    OPDHistory e = db.OPDHistories.Find(id);
                    e.ThirdPartyLabAmoumt = amount;
                    db.SaveChanges();
                }
            }
        }


        #endregion
    }
}
