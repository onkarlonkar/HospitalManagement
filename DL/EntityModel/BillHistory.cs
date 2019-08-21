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
    [MetadataType(typeof(BillHistoryMD))]
    public partial class BillHistory
    {
        #region --- Property Declaration ---
        public class BillHistoryMD
        {
            public System.Guid Id { get; set; }
            public System.Guid PatientId { get; set; }
            public System.Guid OPDHistoryId { get; set; }
            public int ReceiptNumber { get; set; }
            public Nullable<int> PrintCopys { get; set; }
            public Nullable<System.Guid> CreatedBy { get; set; }
            public Nullable<System.DateTime> CreatedOn { get; set; }
            public Nullable<System.Guid> LastPrintedBy { get; set; }
            public Nullable<System.DateTime> LastPrintedOn { get; set; }
        }
        #endregion

        #region --- User Function ---

        public List<BillHistoryModel> Get()
        {
            try
            {
                List<BillHistoryModel> list = new List<BillHistoryModel>();

                using (var db = new HMSEntities())
                {
                    list = db.BillHistories
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new BillHistoryModel()
                                {
                                    Id = t.Id,
                                    PatientId = t.PatientId,
                                    OPDHistoryId = t.OPDHistoryId,
                                    ReceiptNumber = t.ReceiptNumber,
                                    PrintCopys = t.PrintCopys,
                                    LastPrintedOn = t.LastPrintedOn,
                                    CreatedOn = t.CreatedOn,
                                    CreatedBy = t.CreatedBy,
                                    LastPrintedBy = t.LastPrintedBy
                                }).ToList();
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BillHistoryModel GetByOPDId(Guid id)
        {
            try
            {
                BillHistoryModel model = new BillHistoryModel();
                using (var db = new HMSEntities())
                {
                    BillHistory entity = db.BillHistories.Find(id);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.PatientId = entity.PatientId;
                        model.OPDHistoryId = entity.OPDHistoryId;
                        model.ReceiptNumber = entity.ReceiptNumber;
                        model.PrintCopys = entity.PrintCopys;
                        model.CreatedOn = entity.CreatedOn;
                        model.CreatedBy = entity.CreatedBy;
                        model.LastPrintedOn = entity.LastPrintedOn;
                        model.LastPrintedBy = entity.LastPrintedBy;
                    }

                }

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public BillHistoryModel GetByParentId(Guid id)
        {
            try
            {
                BillHistoryModel model = new BillHistoryModel();
                using (var db = new HMSEntities())
                {
                    BillHistory entity = db.BillHistories.FirstOrDefault(t => t.OPDHistoryId == id);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.PatientId = entity.PatientId;
                        model.OPDHistoryId = entity.OPDHistoryId;
                        model.ReceiptNumber = entity.ReceiptNumber;
                        model.PrintCopys = entity.PrintCopys;
                        model.CreatedOn = entity.CreatedOn;
                        model.CreatedBy = entity.CreatedBy;
                        model.LastPrintedOn = entity.LastPrintedOn;
                        model.LastPrintedBy = entity.LastPrintedBy;
                    }

                }

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(BillHistoryModel model)
        {
            try
            {
                bool isSaved = false;

                if (!IsExist(model))
                {
                    using (var db = new HMSEntities())
                    {
                        BillHistory entity = new BillHistory();

                        entity.PatientId = model.PatientId;
                        entity.OPDHistoryId = model.OPDHistoryId;
                        entity.PrintCopys = 1;
                        int? recpNumber = db.BillHistories.Select(t => t.ReceiptNumber).DefaultIfEmpty(0).Max();
                        entity.ReceiptNumber = recpNumber == null ? 1 : recpNumber.Value + 1;
                        entity.CreatedOn = DateTime.Now;
                        entity.CreatedBy = UserDetailSession.Id;

                        db.BillHistories.Add(entity);
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
        public bool Update(Guid? id)
        {
            try
            {
                bool isSaved = false;

               
                    using (var db = new HMSEntities())
                    {
                        BillHistory entity = db.BillHistories.FirstOrDefault(t => t.OPDHistoryId == id);

                        entity.PrintCopys = entity.PrintCopys + 1;
                        entity.LastPrintedOn = DateTime.Now;
                        entity.LastPrintedBy = UserDetailSession.Id;

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
        private bool IsExist(BillHistoryModel model)
        {
            try
            {
                Expression<Func<BillHistory, bool>> predicate = null;

                using (var db = new HMSEntities())
                {
                    /* Build Predicate according to Create or Update */
                    if (!model.Id.HasValue)
                    {
                        predicate = o => o.OPDHistoryId == model.OPDHistoryId;//for Create Record
                    }
                    else
                    {
                        predicate = o => o.OPDHistoryId == model.OPDHistoryId && o.Id != model.Id;//for Update Record Record
                    }

                    /* return is Exist or not */
                    if (db.BillHistories.Any(predicate))
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
