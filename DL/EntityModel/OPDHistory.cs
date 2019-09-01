using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utility;
using System.Data.Entity;
using System.Reflection;

namespace DL.Entity
{
    [MetadataType(typeof(OPDHistoryMD))]
    public partial class OPDHistory
    {
        #region --- Property Declaration ---
        public class OPDHistoryMD
        {
            public System.Guid Id { get; set; }
            public Nullable<System.Guid> PatientId { get; set; }
            public Nullable<int> Sequence { get; set; }
            public Nullable<System.DateTime> InTime { get; set; }
            public Nullable<System.DateTime> OutTime { get; set; }
            public Nullable<bool> IsCharity { get; set; }
            public Nullable<System.Guid> StatusId { get; set; }
            public Nullable<decimal> Amount { get; set; }
            public Nullable<decimal> PaidAmount { get; set; }
            public Nullable<decimal> DueAmount { get; set; }
            public Nullable<System.Guid> ReceivedBy { get; set; }
            public Nullable<System.Guid> CreatedBy { get; set; }
            public Nullable<System.Guid> ModifiedBy { get; set; }
            public Nullable<bool> IsLabCharity { get; set; }
            public string Diagnose { get; set; }
            public string Madicines { get; set; }
            public Nullable<decimal> LabTestingAmount { get; set; }
            public Nullable<decimal> TotalAmount { get; set; }
            public Nullable<decimal> ECGAmount { get; set; }
            public Nullable<decimal> XRAYAmount { get; set; }
            public Nullable<System.Guid> ConsultingDoctorId { get; set; }
            public Nullable<System.Guid> ThirdPartyLabId { get; set; }
            public Nullable<decimal> ThirdPartyLabAmoumt { get; set; }
            public Nullable<bool> IsECG { get; set; }
            public Nullable<bool> IsXRAY { get; set; }
            public Nullable<int> NumberofXRAY { get; set; }
        }
        #endregion

        #region --- User Function ---

        public List<OPDHistoryModel> Get()
        {
            try
            {
                List<OPDHistoryModel> list = new List<OPDHistoryModel>();

                using (var db = new HMSEntities())
                {
                    list = db.OPDHistories
                                .OrderByDescending(c => c.ModifiedBy)
                                .Select(t => new OPDHistoryModel()
                                {
                                    Id = t.Id,
                                    PatientId = t.PatientId,
                                    PatientName = t.PatientDetail != null ? t.PatientDetail.FullName : "",
                                    CasePaperNumber = t.PatientDetail != null ? t.PatientDetail.CasePaperNumber : "",
                                    Sequence = t.Sequence,
                                    InTime = t.InTime,
                                    OutTime = t.OutTime,
                                    IsCharity = t.IsCharity,
                                    IsLabCharity = t.IsLabCharity,
                                    ConsultingDoctorId = t.ConsultingDoctorId,
                                    IsECG = t.IsECG.HasValue ? t.IsECG : false,
                                    IsXRAY = t.IsXRAY.HasValue ? t.IsXRAY : false,
                                    StatusId = t.StatusId,
                                    StatusName = t.Status != null ? t.Status.Name : "",
                                    Amount = t.Amount,
                                    PaidAmount = t.PaidAmount,
                                    DueAmount = t.DueAmount,
                                    TotalAmount = t.TotalAmount,
                                    LabTestingAmount = t.LabTestingAmount,
                                    ECGAmount = t.ECGAmount,
                                    XRAYAmount = t.XRAYAmount,
                                    NumberofXRAY = t.NumberofXRAY.HasValue ? t.NumberofXRAY : 0,
                                    ThirdPartyLabId = t.ThirdPartyLabId,
                                    ThirdPartyLabAmoumt = t.ThirdPartyLabAmoumt,
                                    ReceivedBy = t.ReceivedBy,
                                    Diagnose = t.Diagnose,
                                    Madicines = t.Madicines,
                                    CreatedBy = t.CreatedBy,
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
        public OPDHistoryModel GetById(Guid id)
        {
            try
            {
                OPDHistoryModel model = new OPDHistoryModel();
                using (var db = new HMSEntities())
                {
                    OPDHistory entity = db.OPDHistories.Find(id);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.PatientId = entity.PatientId;
                        model.PatientName = entity.PatientDetail != null ? entity.PatientDetail.FullName : "";
                        model.CasePaperNumber = entity.PatientDetail != null ? entity.PatientDetail.CasePaperNumber : "";
                        model.Sequence = entity.Sequence;
                        model.InTime = entity.InTime;
                        model.OutTime = entity.OutTime;
                        model.IsCharity = entity.IsCharity;
                        model.IsLabCharity = entity.IsLabCharity;
                        model.IsECG = entity.IsECG.HasValue ? entity.IsECG : false;
                        model.IsXRAY = entity.IsXRAY.HasValue ? entity.IsXRAY : false;
                        model.StatusId = entity.StatusId;
                        model.StatusName = entity.Status != null ? entity.Status.Name : "";
                        model.Amount = entity.Amount;
                        model.PaidAmount = entity.PaidAmount;
                        model.DueAmount = entity.DueAmount;
                        model.TotalAmount = entity.TotalAmount;
                        model.LabTestingAmount = entity.LabTestingAmount;
                        model.ECGAmount = entity.ECGAmount;
                        model.XRAYAmount = entity.XRAYAmount;
                        model.NumberofXRAY = entity.NumberofXRAY.HasValue ? entity.NumberofXRAY : 0;
                        model.ReceivedBy = entity.ReceivedBy;
                        model.ConsultingDoctorId = entity.ConsultingDoctorId;
                        model.ThirdPartyLabId = entity.ThirdPartyLabId;
                        model.ThirdPartyLabAmoumt = entity.ThirdPartyLabAmoumt;
                        model.Diagnose = entity.Diagnose;
                        model.Madicines = entity.Madicines;
                        model.CreatedBy = entity.CreatedBy;
                        model.ModifiedBy = entity.ModifiedBy;
                        model.PatientDetails = PatientDetail.SetModel(entity.PatientDetail);
                    }

                }

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OPDHistoryModel GetByParentId(Guid id)
        {
            try
            {
                OPDHistoryModel model = new OPDHistoryModel();
                using (var db = new HMSEntities())
                {
                    OPDHistory entity = db.OPDHistories.FirstOrDefault(t => t.PatientId == id);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.PatientId = entity.PatientId;
                        model.PatientName = entity.PatientDetail != null ? entity.PatientDetail.FullName : "";
                        model.CasePaperNumber = entity.PatientDetail != null ? entity.PatientDetail.CasePaperNumber : "";
                        model.Sequence = entity.Sequence;
                        model.InTime = entity.InTime;
                        model.OutTime = entity.OutTime;
                        model.IsCharity = entity.IsCharity;
                        model.IsLabCharity = entity.IsLabCharity;
                        model.ConsultingDoctorId = entity.ConsultingDoctorId;
                        model.IsECG = entity.IsECG.HasValue ? entity.IsECG : false;
                        model.IsXRAY = entity.IsXRAY.HasValue ? entity.IsXRAY : false;
                        model.StatusId = entity.StatusId;
                        model.StatusName = entity.Status != null ? entity.Status.Name : "";
                        model.Amount = entity.Amount;
                        model.PaidAmount = entity.PaidAmount;
                        model.DueAmount = entity.DueAmount;
                        model.TotalAmount = entity.TotalAmount;
                        model.LabTestingAmount = entity.LabTestingAmount;
                        model.ECGAmount = entity.ECGAmount;
                        model.XRAYAmount = entity.XRAYAmount;
                        model.NumberofXRAY = entity.NumberofXRAY.HasValue ? entity.NumberofXRAY : 0;
                        model.ReceivedBy = entity.ReceivedBy;
                        model.Diagnose = entity.Diagnose;
                        model.Madicines = entity.Madicines;
                        model.CreatedBy = entity.CreatedBy;
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
        public bool Create(OPDHistoryModel model, int isFollowUp = 0)
        {
            try
            {
                bool isSaved = false;

                if (!IsExist(model.CasePaperNumber))
                {
                    using (var db = new HMSEntities())
                    {
                        OPDHistory entity = new OPDHistory();
                        entity.PatientId = model.PatientId;
                        entity.Sequence = getLastSerial();
                        entity.InTime = model.InTime;
                        entity.OutTime = model.OutTime;
                        entity.IsCharity = model.IsCharity.HasValue ? model.IsCharity : false;
                        entity.IsLabCharity = model.IsLabCharity;
                        entity.ConsultingDoctorId = model.ConsultingDoctorId;
                        entity.IsECG = model.IsECG.HasValue ? model.IsECG : false;
                        entity.IsXRAY = model.IsXRAY.HasValue ? model.IsXRAY : false;
                        entity.StatusId = Status.GetStatus(t => t.Name == OPD_STATUS.Waiting.ToString()).FirstOrDefault().Id;
                        if (!entity.IsCharity.Value)
                        {
                            if (isFollowUp == 0)
                                entity.Amount = OPDRate.GetRatesByType("New").Rate;
                            else if (isFollowUp == 1)
                                entity.Amount = OPDRate.GetRatesByType("FollowUP").Rate;
                        }
                        else
                        {
                            entity.Amount = 0.00M;
                            entity.LabTestingAmount = 0.00M;
                            entity.XRAYAmount = 0.00M;
                            entity.ECGAmount = 0.00M;
                        }
                        model.PayingAmount = entity.Amount;
                        entity.PaidAmount = entity.Amount;
                        entity.DueAmount = model.ECGAmount + model.XRAYAmount; //model.DueAmount != null ? model.DueAmount : Convert.ToDecimal(0.00);
                        entity.TotalAmount = entity.Amount + model.ECGAmount + model.XRAYAmount;
                        entity.LabTestingAmount = model.LabTestingAmount != null ? model.LabTestingAmount : Convert.ToDecimal(0.00);
                        entity.ECGAmount = model.ECGAmount.HasValue ? model.ECGAmount : 0.00M;
                        entity.XRAYAmount = model.XRAYAmount.HasValue ? model.XRAYAmount : 0.00M;
                        entity.NumberofXRAY = model.NumberofXRAY.HasValue ? model.NumberofXRAY : 0;
                        entity.ThirdPartyLabId = model.ThirdPartyLabId;
                        entity.ThirdPartyLabAmoumt = model.ThirdPartyLabAmoumt.HasValue ? model.ThirdPartyLabAmoumt : 0.00M;
                        entity.ReceivedBy = model.ReceivedBy;
                        entity.Diagnose = model.Diagnose;
                        entity.Madicines = model.Madicines;
                        entity.CreatedBy = UserDetailSession.Id;

                        db.OPDHistories.Add(entity);
                        db.SaveChanges();
                        model.Id = entity.Id;
                        List<OPDHistoryUpdateModel> listUpdateModel = new List<OPDHistoryUpdateModel>();
                        listUpdateModel = OPDHistoryModifications(model);
                        OPDHistoryUpdate opdHistoryUpdate = new OPDHistoryUpdate();
                        opdHistoryUpdate.Create(listUpdateModel);
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
        public bool Update(OPDHistoryModel model)
        {
            try
            {
                bool isSaved = false;
                List<OPDHistoryUpdateModel> listUpdateModel = new List<OPDHistoryUpdateModel>();

                using (var db = new HMSEntities())
                {
                    OPDHistory entity = db.OPDHistories.Find(model.Id);
                    listUpdateModel = OPDHistoryModifications(entity, model);
                    entity.PatientId = model.PatientId;
                    entity.InTime = model.InTime;
                    entity.OutTime = model.OutTime;
                    entity.IsCharity = model.IsCharity;
                    entity.IsLabCharity = model.IsLabCharity;
                    entity.IsECG = model.IsECG.HasValue ? model.IsECG : false;
                    entity.IsXRAY = model.IsXRAY.HasValue ? model.IsXRAY : false;
                    entity.ConsultingDoctorId = model.ConsultingDoctorId;
                    entity.StatusId = model.StatusId;
                    entity.Amount = model.Amount;
                    entity.PaidAmount = model.PaidAmount;
                    entity.DueAmount = model.DueAmount;
                    entity.TotalAmount = model.TotalAmount;
                    entity.LabTestingAmount = model.LabTestingAmount;
                    entity.ECGAmount = model.ECGAmount.HasValue ? model.ECGAmount : 0.00M;
                    entity.XRAYAmount = model.XRAYAmount.HasValue ? model.XRAYAmount : 0.00M;
                    entity.NumberofXRAY = model.NumberofXRAY.HasValue ? model.NumberofXRAY : 0;
                    entity.ThirdPartyLabId = model.ThirdPartyLabId;
                    entity.ThirdPartyLabAmoumt = model.ThirdPartyLabAmoumt.HasValue ? model.ThirdPartyLabAmoumt : 0.00M;
                    string status = Status.GetNameById(model.StatusId);
                    if (status == OPD_STATUS.Done.ToString())
                        entity.ReceivedBy = UserDetailSession.Id;
                    else
                        entity.ReceivedBy = model.ReceivedBy;
                    entity.Diagnose = model.Diagnose;
                    entity.Madicines = model.Madicines;
                    entity.ModifiedBy = UserDetailSession.Id;

                    db.SaveChanges();

                    OPDHistoryUpdate opdHistoryUpdate = new OPDHistoryUpdate();
                    opdHistoryUpdate.Create(listUpdateModel);

                    if (status == OPD_STATUS.Done.ToString())
                    {
                        BillHistoryModel billModel = new BillHistoryModel();
                        billModel.PatientId = model.PatientId.Value;
                        billModel.OPDHistoryId = model.Id.Value;
                        new BillHistory().Create(billModel);
                    }

                    isSaved = true;
                }



                return isSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool IsExist(string casePaperNumber)
        {
            try
            {
                Expression<Func<OPDHistory, bool>> predicate = null;

                using (var db = new HMSEntities())
                {
                    /* Build Predicate according to Create or Update */

                    predicate = o => o.PatientDetail.CasePaperNumber == casePaperNumber && DbFunctions.TruncateTime(o.InTime.Value) == DateTime.Today;
                    //for Create Record
                    //}
                    //else
                    //{
                    //    predicate = o => o.Id != model.Id && o.PatientDetail.CasePaperNumber == model.CasePaperNumber && DbFunctions.TruncateTime(o.InTime.Value) == DateTime.Today;//for Update Record Record
                    //}

                    /* return is Exist or not */
                    if (db.OPDHistories.Any(predicate))
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
        public bool Delete(Guid id)
        {
            return true;
        }
        public List<OPDHistoryModel> AdvanceSearch(string searchText)
        {
            try
            {
                List<OPDHistoryModel> list = new List<OPDHistoryModel>();

                using (var db = new HMSEntities())
                {
                    list = db.OPDHistories.Where(t => DbFunctions.TruncateTime(t.InTime.Value) == DateTime.Today && (t.PatientDetail.FullName.Contains(searchText)
                    || t.PatientDetail.CasePaperNumber.Contains(searchText) || t.Status.Name.Contains(searchText)))
                                .Select(t => new OPDHistoryModel()
                                {
                                    Id = t.Id,
                                    PatientId = t.PatientId,
                                    PatientName = t.PatientDetail != null ? t.PatientDetail.FullName : "",
                                    CasePaperNumber = t.PatientDetail != null ? t.PatientDetail.CasePaperNumber : "",
                                    Sequence = t.Sequence,
                                    InTime = t.InTime,
                                    OutTime = t.OutTime,
                                    IsCharity = t.IsCharity,
                                    IsLabCharity = t.IsLabCharity,
                                    ConsultingDoctorId = t.ConsultingDoctorId,
                                    IsECG = t.IsECG.HasValue ? t.IsECG : false,
                                    IsXRAY = t.IsXRAY.HasValue ? t.IsXRAY : false,
                                    StatusId = t.StatusId,
                                    StatusName = t.Status != null ? t.Status.Name : "",
                                    Amount = t.Amount,
                                    PaidAmount = t.PaidAmount,
                                    DueAmount = t.DueAmount,
                                    TotalAmount = t.TotalAmount,
                                    LabTestingAmount = t.LabTestingAmount,
                                    ECGAmount = t.ECGAmount,
                                    XRAYAmount = t.XRAYAmount,
                                    NumberofXRAY = t.NumberofXRAY.HasValue ? t.NumberofXRAY : 0,
                                    ThirdPartyLabId = t.ThirdPartyLabId,
                                    ThirdPartyLabAmoumt = t.ThirdPartyLabAmoumt,
                                    ReceivedBy = t.ReceivedBy,
                                    Diagnose = t.Diagnose,
                                    Madicines = t.Madicines,
                                    CreatedBy = t.CreatedBy,
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
        public List<OPDHistoryModel> GetByStatus(Expression<Func<OPDHistory, bool>> predicate)
        {
            try
            {
                List<OPDHistoryModel> list = new List<OPDHistoryModel>();

                using (var db = new HMSEntities())
                {

                    DateTime today = DateTime.Today;
                    //var vvv = db.OPDHistories.Where(t => DbFunctions.TruncateTime(t.InTime.Value) == today).Where(predicate).OrderBy(t => t.Sequence).OrderByDescending(t => t.Status.Name).ToList();
                    list = db.OPDHistories.Where(t => DbFunctions.TruncateTime(t.InTime.Value) == today).Where(predicate).OrderBy(t => t.Sequence).Select(t => new OPDHistoryModel()
                    {
                        Id = t.Id,
                        PatientId = t.PatientId,
                        PatientName = t.PatientDetail != null ? t.PatientDetail.FullName : "",
                        CasePaperNumber = t.PatientDetail != null ? t.PatientDetail.CasePaperNumber : "",
                        Sequence = t.Sequence,
                        InTime = t.InTime,
                        OutTime = t.OutTime,
                        IsCharity = t.IsCharity,
                        IsLabCharity = t.IsLabCharity,
                        ConsultingDoctorId = t.ConsultingDoctorId,
                        IsECG = t.IsECG.HasValue ? t.IsECG : false,
                        IsXRAY = t.IsXRAY.HasValue ? t.IsXRAY : false,
                        StatusId = t.StatusId,
                        StatusName = t.Status != null ? t.Status.Name : "",
                        Amount = t.Amount,
                        PaidAmount = t.PaidAmount,
                        DueAmount = t.DueAmount,
                        TotalAmount = t.TotalAmount,
                        LabTestingAmount = t.LabTestingAmount,
                        ECGAmount = t.ECGAmount,
                        XRAYAmount = t.XRAYAmount,
                        NumberofXRAY = t.NumberofXRAY.HasValue ? t.NumberofXRAY : 0,
                        ThirdPartyLabId = t.ThirdPartyLabId,
                        ThirdPartyLabAmoumt = t.ThirdPartyLabAmoumt,
                        ReceivedBy = t.ReceivedBy,
                        Diagnose = t.Diagnose,
                        Madicines = t.Madicines,
                        CreatedBy = t.CreatedBy,
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
        public List<OPDHistoryModel> GetHistoryByPatientId(Guid? id)
        {
            try
            {
                List<OPDHistoryModel> list = new List<OPDHistoryModel>();

                using (var db = new HMSEntities())
                {
                    Guid? patientId = db.OPDHistories.Find(id).PatientId;
                    list = db.OPDHistories.AsEnumerable().Where(t => t.PatientId == patientId && t.Status.Name == OPD_STATUS.Done.ToString()).OrderByDescending(t => t.InTime)
                                .Select(t => new OPDHistoryModel()
                                {
                                    Id = t.Id,
                                    PatientId = t.PatientId,
                                    PatientName = t.PatientDetail != null ? t.PatientDetail.FullName : "",
                                    CasePaperNumber = t.PatientDetail != null ? t.PatientDetail.CasePaperNumber : "",
                                    Sequence = t.Sequence,
                                    InTime = t.InTime,
                                    OutTime = t.OutTime,
                                    IsCharity = t.IsCharity,
                                    IsLabCharity = t.IsLabCharity,
                                    ConsultingDoctorId = t.ConsultingDoctorId,
                                    DoctorNames = t.DoctorDetail.FullName,
                                    IsECG = t.IsECG.HasValue ? t.IsECG : false,
                                    IsXRAY = t.IsXRAY.HasValue ? t.IsXRAY : false,
                                    StatusId = t.StatusId,
                                    StatusName = t.Status != null ? t.Status.Name : "",
                                    Amount = t.Amount,
                                    PaidAmount = t.PaidAmount,
                                    DueAmount = t.DueAmount,
                                    TotalAmount = t.TotalAmount,
                                    LabTestingAmount = t.LabTestingAmount,
                                    ECGAmount = t.ECGAmount,
                                    XRAYAmount = t.XRAYAmount,
                                    NumberofXRAY = t.NumberofXRAY.HasValue ? t.NumberofXRAY : 0,
                                    ThirdPartyLabId = t.ThirdPartyLabId,
                                    ThirdPartyLabAmoumt = t.ThirdPartyLabAmoumt,
                                    ReceivedBy = t.ReceivedBy,
                                    Diagnose = t.Diagnose,
                                    Madicines = t.Madicines,
                                    CreatedBy = t.CreatedBy,
                                    ModifiedBy = t.ModifiedBy,
                                    PatientDetails = PatientDetail.SetModel(t.PatientDetail)
                                }).ToList();
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int getLastSerial()
        {
            try
            {
                int? sequence = 0;
                DateTime today = DateTime.Today;
                using (var db = new HMSEntities())
                {
                    if (db.OPDHistories.Any())
                    {
                        var list = db.OPDHistories.Where(t => DbFunctions.TruncateTime(t.InTime.Value) == today).OrderByDescending(x => x.InTime.Value).ToList();
                        sequence = list.Count;
                    }
                }

                return sequence.Value + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private List<OPDHistoryUpdateModel> OPDHistoryModifications(object entityEntry, object modelEntry)
        {

            string[] arrayColumns = new string[] { "ECGAmount", "XRAYAmount", "ThirdPartyLabAmoumt", "Amount", "PaidAmount", "IsCharity", "StatusId", "IsECG", "IsXRAY", "IsLabCharity", "LabTestingAmount" };

            //Getting Type of Generic Class Model
            var entityType = entityEntry.GetType();
            var modelType = modelEntry.GetType();

            PropertyInfo[] entityProperty = entityType.GetProperties();
            PropertyInfo[] modelProperties = modelType.GetProperties();
            List<OPDHistoryUpdateModel> list = new List<OPDHistoryUpdateModel>();

            foreach (PropertyInfo property in entityProperty)
            {
                if (modelType.GetProperty(property.Name) != null)
                {
                    if (arrayColumns.Contains(property.Name))
                    {
                        var newValue = modelType.GetProperty(property.Name).GetValue(modelEntry, null);
                        var oldValue = entityType.GetProperty(property.Name).GetValue(entityEntry, null);
                        if (newValue.ToString() != oldValue.ToString())
                        {
                            if (property.Name == "PaidAmount")
                            {
                                OPDHistoryUpdateModel objPaying = new OPDHistoryUpdateModel();

                                decimal? payingAmount = Convert.ToDecimal(modelType.GetProperty("PayingAmount").GetValue(modelEntry, null).ToString());
                                objPaying.OPDHistoryId = new Guid(modelType.GetProperty("Id").GetValue(modelEntry, null).ToString());
                                // objPaying.PreviousValue = Convert.ToString("");
                                objPaying.UpdatedBy = UserDetailSession.Id;
                                objPaying.UpdatedValue = Convert.ToString(payingAmount);
                                objPaying.UpdatedField = "PayingAmount";
                                objPaying.CreatedOn = DateTime.Now.Date;
                                list.Add(objPaying);
                            }
                            else
                            {
                                OPDHistoryUpdateModel obj = new OPDHistoryUpdateModel();
                                obj.OPDHistoryId = new Guid(modelType.GetProperty("Id").GetValue(modelEntry, null).ToString());
                                obj.PreviousValue = Convert.ToString(oldValue);
                                obj.UpdatedBy = UserDetailSession.Id;
                                obj.UpdatedValue = Convert.ToString(newValue);
                                obj.UpdatedField = Convert.ToString(property.Name);
                                obj.CreatedOn = DateTime.Now.Date;
                                list.Add(obj);
                            }

                        }
                    }
                }
            }

            return list;
        }

        private List<OPDHistoryUpdateModel> OPDHistoryModifications(object modelEntry)
        {
            string[] arrayColumns = new string[] { "XRAYAmount", "PaidAmount", "IsCharity", "IsECG", "IsXRAY" };

            //Getting Type of Generic Class Model

            var modelType = modelEntry.GetType();


            PropertyInfo[] modelProperties = modelType.GetProperties();
            List<OPDHistoryUpdateModel> list = new List<OPDHistoryUpdateModel>();

            foreach (PropertyInfo property in modelProperties)
            {

                if (arrayColumns.Contains(property.Name))
                {
                    if (property.Name == "PaidAmount")
                    {
                        OPDHistoryUpdateModel objPaying = new OPDHistoryUpdateModel();

                        decimal? payingAmount = Convert.ToDecimal(modelType.GetProperty("PayingAmount").GetValue(modelEntry, null).ToString());
                        objPaying.OPDHistoryId = new Guid(modelType.GetProperty("Id").GetValue(modelEntry, null).ToString());
                        // objPaying.PreviousValue = Convert.ToString("");
                        objPaying.UpdatedBy = UserDetailSession.Id;
                        objPaying.UpdatedValue = Convert.ToString(payingAmount);
                        objPaying.UpdatedField = "PayingAmount";
                        objPaying.CreatedOn = DateTime.Now.Date;
                        list.Add(objPaying);
                    }
                    else
                    {
                        OPDHistoryUpdateModel obj = new OPDHistoryUpdateModel();
                        obj.OPDHistoryId = new Guid(modelType.GetProperty("Id").GetValue(modelEntry, null).ToString());
                        obj.PreviousValue = null;
                        obj.UpdatedBy = UserDetailSession.Id;
                        obj.UpdatedValue = Convert.ToString(modelType.GetProperty(property.Name).GetValue(modelEntry, null));
                        obj.UpdatedField = Convert.ToString(property.Name);
                        obj.CreatedOn = DateTime.Now.Date;
                        list.Add(obj);
                    }

                    //}
                }
                //}
            }

            return list;
        }
        #endregion

        #region --- Dashboard ---

        public DashboardModel getDashboardCounts()
        {
            try
            {
                DashboardModel model = new DashboardModel();
                Guid? StatusId = Status.GetIdByName(OPD_STATUS.Waiting.ToString());
                using (var db = new HMSEntities())
                {
                    DateTime today = DateTime.Today;
                    model.WaitingPatient = db.OPDHistories.AsEnumerable().Where(t => t.InTime.Value.Date == today && t.StatusId == Status.GetIdByName(OPD_STATUS.Waiting.ToString())).Count();
                    model.InprogressPending = db.OPDHistories.AsEnumerable().Where(t => t.InTime.Value.Date == today && t.StatusId == Status.GetIdByName(OPD_STATUS.Done.ToString())).Count();

                    model.MadamPatient = db.OPDHistories.AsEnumerable().Where(t => t.InTime.Value.Date == today && t.ConsultingDoctorId == DoctorDetail.GetInHouse("MADAM")).Count();
                    model.SirPatient = db.OPDHistories.AsEnumerable().Where(t => t.InTime.Value.Date == today && t.ConsultingDoctorId == DoctorDetail.GetInHouse("SIR")).Count();

                    decimal? opdCollection = db.OPDHistories.AsEnumerable().Where(t => t.InTime.Value.Date == today).Sum(t => t.Amount);
                    decimal? labCollection = db.OPDHistories.AsEnumerable().Where(t => t.InTime.Value.Date == today).Sum(t => t.LabTestingAmount);
                    decimal? ecgCollection = db.OPDHistories.AsEnumerable().Where(t => t.InTime.Value.Date == today).Sum(t => t.ECGAmount);
                    decimal? xrayCollection = db.OPDHistories.AsEnumerable().Where(t => t.InTime.Value.Date == today).Sum(t => t.XRAYAmount);
                    decimal? thirdPartyLab = db.OPDHistories.AsEnumerable().Where(t => t.InTime.Value.Date == today).Sum(t => t.ThirdPartyLabAmoumt);

                    model.OPDCollection = opdCollection != null ? Convert.ToDecimal(opdCollection) : Convert.ToDecimal(0.00);
                    model.LabCollection = labCollection != null ? Convert.ToDecimal(labCollection) : Convert.ToDecimal(0.00);
                    model.ECGCollection = ecgCollection != null ? Convert.ToDecimal(ecgCollection) : Convert.ToDecimal(0.00);
                    model.XRAYCollection = xrayCollection != null ? Convert.ToDecimal(xrayCollection) : Convert.ToDecimal(0.00);
                    model.ThirePartyLabCollection = thirdPartyLab != null ? Convert.ToDecimal(thirdPartyLab) : Convert.ToDecimal(0.00);

                    model.TotalCollection = model.OPDCollection + model.LabCollection + model.ECGCollection + model.XRAYCollection + model.ThirePartyLabCollection;
                    decimal? paidCollection = db.OPDHistories.AsEnumerable().Where(t => t.InTime.Value.Date == today).Sum(t => t.PaidAmount);
                    decimal? duesCollection = db.OPDHistories.AsEnumerable().Where(t => t.InTime.Value.Date == today).Sum(t => t.DueAmount);
                    model.DuesCollection = duesCollection != null ? duesCollection : Convert.ToDecimal(0.00);
                    model.ReceivedCollection = paidCollection != null ? paidCollection : Convert.ToDecimal(0.00);

                    #region User Collection
                    var list = db.UserDetails.Where(u => u.IsActive == true);
                    model.UsreCollection = new List<LookupModel>();
                    foreach (var users in list)
                    {
                        Guid? prevoiusid = null;
                        LookupModel md = new LookupModel();
                        var hislist = db.OPDHistoryUpdates.AsEnumerable().Where(h => h.UpdatedBy == users.Id && h.UpdatedField == "PayingAmount" && h.CreatedOn.Value.Date == today);
                        int records = hislist.Count();
                        int index = 0;
                        foreach (var item in hislist)
                        {
                            index++;
                            if (prevoiusid == null)
                            {
                                prevoiusid = item.UpdatedBy;
                                md.Rate = md.Rate == null ? Convert.ToDecimal(item.UpdatedValue) : md.Rate + Convert.ToDecimal(item.UpdatedValue);
                            }
                            else
                            {
                                md.Rate = md.Rate == null ? Convert.ToDecimal(item.UpdatedValue) : md.Rate + Convert.ToDecimal(item.UpdatedValue);
                            }

                            if (records == index)
                            {
                                md.Id = item.UpdatedBy.Value;
                                md.Name = UserDetail.GetNameById(item.UpdatedBy.Value);
                                model.UsreCollection.Add(md);
                                md = new LookupModel();
                            }

                        }
                    }

                    #endregion

                    #region Recent Activity

                    model.RecentActivity = new List<OPDHistoryUpdateModel>();
                    var activities = db.OPDHistoryUpdates.AsEnumerable().Where(h => h.CreatedOn.Value.Date == today).OrderByDescending(t => t.CreatedOn);
                    foreach (var item in activities)
                    {
                        OPDHistoryUpdateModel lookup = new OPDHistoryUpdateModel();
                        lookup.Id = item.Id;
                        lookup.CasePaper = GetById(item.OPDHistoryId).CasePaperNumber;
                        lookup.UpdatedName = UserDetail.GetNameById(item.UpdatedBy.Value);
                        lookup.UpdatedField = item.UpdatedField;
                        switch (item.UpdatedField)
                        {
                            case "XRAYAmount":
                            case "ECGAmount":
                            case "PayingAmount":
                            case "ThirdPartyLabAmoumt":
                            case "LabTestingAmount":
                                lookup.PreviousValue = item.PreviousValue != null ? Convert.ToString(item.PreviousValue) : "";
                                lookup.UpdatedValue = item.UpdatedValue != null ? Convert.ToString(item.UpdatedValue) : "";
                                break;
                            case "IsCharity":
                            case "IsXRAY":
                            case "IsECG":
                            case "IsLabCharity":
                                lookup.PreviousValue = item.PreviousValue != null ? Convert.ToBoolean(item.PreviousValue) ? "Yes" : "No" : "";
                                lookup.UpdatedValue = item.UpdatedValue != null ? Convert.ToBoolean(item.UpdatedValue) ? "Yes" : "No" : "";
                                break;
                            case "StatusId":
                                lookup.PreviousValue = item.PreviousValue != null ? Status.GetNameById(new Guid(item.PreviousValue)) : "";
                                lookup.UpdatedValue = item.UpdatedValue != null ? Status.GetNameById(new Guid(item.UpdatedValue)) : "";
                                break;
                            default:
                                break;
                        }

                        model.RecentActivity.Add(lookup);
                    }
                    #endregion                   
                }

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LookupModel> getPatientByType(P_TYPE type)
        {
            List<LookupModel> list = new List<LookupModel>();
            DateTime today = DateTime.Today;
            bool isXRAY = false;
            Expression<Func<OPDHistory, bool>> predicate = null;
            switch (type)
            {
                case P_TYPE.ECG:
                    predicate = t => t.IsECG == true && DbFunctions.TruncateTime(t.InTime.Value) == today;
                    
                    break;
                case P_TYPE.XRAY:
                    predicate = t => t.IsXRAY == true && DbFunctions.TruncateTime(t.InTime.Value) == today;
                    isXRAY = true;
                    break;
                case P_TYPE.CHARITY:
                    predicate = t => t.IsCharity == true && DbFunctions.TruncateTime(t.InTime.Value) == today;
                    break;
                case P_TYPE.LABCHARITY:
                    predicate = t => t.IsLabCharity == true && DbFunctions.TruncateTime(t.InTime.Value) == today;
                    break;
                default:
                    break;
            }

            using (var db = new HMSEntities())
            {
                var val = db.OPDHistories.Where(predicate);
                foreach (var item in val)
                {
                    LookupModel md = new LookupModel();
                    md.Name = item.PatientDetail != null ? item.PatientDetail.FullName : "";
                    md.Id = item.PatientId;
                    md.Description = item.PatientDetail.CasePaperNumber;
                    md.PerentName = isXRAY == true ? Convert.ToString(item.NumberofXRAY) : "";
                    list.Add(md);
                }
            }

            return list;

        }

        #endregion

        #region --- OPD Reporting Data ---

        public List<OPDHistoryModel> GetByCasePaper(string casePaperNo)
        {
            throw new NotImplementedException();
        }

        public List<OPDHistoryModel> GetByDate(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public List<OPDHistoryModel> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<OPDHistoryModel> GetGenericReport(Expression<Func<OPDHistory, bool>> predicate)
        {
            try
            {
                List<OPDHistoryModel> list = new List<OPDHistoryModel>();

                using (var db = new HMSEntities())
                {
                    var data = db.OPDHistories.Where(predicate).OrderBy(t => t.InTime).ToList();
                    foreach (OPDHistory t in data)
                    {
                        OPDHistoryModel model = new OPDHistoryModel();
                        model.Id = t.Id;
                        model.PatientId = t.PatientId;
                        model.PatientName = t.PatientDetail != null ? t.PatientDetail.FullName : "";
                        model.CasePaperNumber = t.PatientDetail != null ? t.PatientDetail.CasePaperNumber : "";
                        model.Sequence = t.Sequence;
                        model.InTime = t.InTime;
                        model.OutTime = t.OutTime;
                        model.IsCharity = t.IsCharity;
                        model.IsLabCharity = t.IsLabCharity;
                        model.ECGAmount = t.ECGAmount;
                        model.ConsultingDoctorId = t.ConsultingDoctorId;
                        model.DoctorNames = t.DoctorDetail.FullName;
                        model.IsECG = t.IsECG.HasValue ? t.IsECG : false;
                        model.IsXRAY = t.IsXRAY.HasValue ? t.IsXRAY : false;
                        model.XRAYAmount = t.XRAYAmount;
                        model.NumberofXRAY = t.NumberofXRAY.HasValue ? t.NumberofXRAY : 0;
                        model.ThirdPartyLabId = t.ThirdPartyLabId;
                        model.ThirdPartyLabAmoumt = t.ThirdPartyLabAmoumt;
                        model.StatusId = t.StatusId;
                        model.StatusName = t.Status != null ? t.Status.Name : "";
                        model.Amount = t.Amount;
                        model.PaidAmount = t.PaidAmount;
                        model.DueAmount = t.DueAmount;
                        model.TotalAmount = t.TotalAmount;
                        model.LabTestingAmount = t.LabTestingAmount;
                        model.ReceivedBy = t.ReceivedBy;
                        model.Diagnose = t.Diagnose;
                        model.Madicines = t.Madicines;
                        model.CreatedBy = t.CreatedBy;
                        model.ModifiedBy = t.ModifiedBy;
                        model.OPDHistoryUpdates = new List<OPDHistoryUpdateModel>();
                        model.OPDHistoryUpdates.AddRange(OPDHistoryUpdate.GetPayingPatient(model.Id.Value));
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



        #endregion
    }
}
