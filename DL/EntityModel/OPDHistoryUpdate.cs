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
    [MetadataType(typeof(OPDHistoryUpdateMD))]
    public partial class OPDHistoryUpdate
    {
        #region --- Property Declaration ---
        public class OPDHistoryUpdateMD
        {
            public System.Guid Id { get; set; }
            public System.Guid OPDHistoryId { get; set; }
            public Nullable<System.Guid> UpdatedBy { get; set; }
            public string UpdatedField { get; set; }
            public string UpdatedValue { get; set; }
            public string PreviousValue { get; set; }
            public Nullable<System.DateTime> CreatedOn { get; set; }
        }
        #endregion

        #region --- User Function ---

        public List<OPDHistoryUpdateModel> Get()
        {
            try
            {
                List<OPDHistoryUpdateModel> list = new List<OPDHistoryUpdateModel>();

                using (var db = new HMSEntities())
                {
                    list = db.OPDHistoryUpdates
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new OPDHistoryUpdateModel()
                                {
                                    Id = t.Id,
                                    OPDHistoryId = t.OPDHistoryId,
                                    UpdatedBy = t.UpdatedBy,
                                    UpdatedField = t.UpdatedField,
                                    UpdatedValue = t.UpdatedValue,
                                    PreviousValue = t.PreviousValue,
                                    CreatedOn = t.CreatedOn

                                }).ToList();
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OPDHistoryUpdateModel> GetByParentId(Guid? opdHistoryId)
        {
            try
            {
                List<OPDHistoryUpdateModel> list = new List<OPDHistoryUpdateModel>();

                using (var db = new HMSEntities())
                {
                    list = db.OPDHistoryUpdates
                                .Where(t => t.OPDHistoryId == opdHistoryId)
                                .OrderBy(c => c.CreatedOn)
                                .Select(t => new OPDHistoryUpdateModel()
                                {
                                    Id = t.Id,
                                    OPDHistoryId = t.OPDHistoryId,
                                    UpdatedBy = t.UpdatedBy,
                                    UpdatedField = t.UpdatedField,
                                    UpdatedValue = t.UpdatedValue,
                                    PreviousValue = t.PreviousValue,
                                    CreatedOn = t.CreatedOn
                                }).ToList();
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<OPDHistoryUpdateModel> GetPayingPatient(Guid? opdHistoryId)
        {
            try
            {
                List<OPDHistoryUpdateModel> list = new List<OPDHistoryUpdateModel>();

                using (var db = new HMSEntities())
                {
                    var data = db.OPDHistoryUpdates
                                 .Where(t => t.OPDHistoryId == opdHistoryId && t.UpdatedField== "PayingAmount")
                                 .OrderBy(c => c.CreatedOn).ToList();
                    foreach (OPDHistoryUpdate t in data)
                    {
                        OPDHistoryUpdateModel model = new OPDHistoryUpdateModel();
                        model.Id = t.Id;
                        model.OPDHistoryId = t.OPDHistoryId;
                        model.UpdatedBy = t.UpdatedBy;
                        model.UpdatedName = t.UpdatedBy.HasValue ? UserDetail.GetNameById(t.UpdatedBy.Value) : string.Empty;
                        model.UpdatedField = t.UpdatedField;
                        model.UpdatedValue = t.UpdatedValue;
                        model.PreviousValue = t.PreviousValue;
                        model.CreatedOn = t.CreatedOn;
                        list.Add(model);
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(OPDHistoryUpdateModel model)
        {
            try
            {
                bool isSaved = false;
                using (var db = new HMSEntities())
                {
                    OPDHistoryUpdate entity = new OPDHistoryUpdate();

                    entity.OPDHistoryId = model.OPDHistoryId;
                    entity.UpdatedBy = UserDetailSession.Id;
                    entity.UpdatedField = model.UpdatedField;
                    entity.UpdatedValue = model.UpdatedValue;
                    entity.PreviousValue = model.PreviousValue;
                    entity.CreatedOn = DateTime.Now;


                    db.OPDHistoryUpdates.Add(entity);
                    db.SaveChanges();

                    isSaved = true;

                }


                return isSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(List<OPDHistoryUpdateModel> model)
        {
            try
            {
                bool isSaved = false;
                using (var db = new HMSEntities())
                {
                    foreach (OPDHistoryUpdateModel item in model)
                    {
                        OPDHistoryUpdate entity = new OPDHistoryUpdate();

                        entity.OPDHistoryId = item.OPDHistoryId;
                        entity.UpdatedBy = UserDetailSession.Id;
                        entity.UpdatedField = item.UpdatedField;
                        entity.UpdatedValue = item.UpdatedValue;
                        entity.PreviousValue = item.PreviousValue;
                        entity.CreatedOn = DateTime.Now;

                        db.OPDHistoryUpdates.Add(entity);
                    }


                    db.SaveChanges();

                    isSaved = true;

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


        #endregion
    }
}
