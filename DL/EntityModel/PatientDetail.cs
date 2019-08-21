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
    [MetadataType(typeof(PatientDetailMD))]
    public partial class PatientDetail
    {
        #region --- Property Declaration ---
        public class PatientDetailMD
        {
            public System.Guid Id { get; set; }
            public string CasePaperNumber { get; set; }
            public string FullName { get; set; }
            public Nullable<int> Gender { get; set; }
            public string PhoneNumber { get; set; }
            public Nullable<int> Age { get; set; }
            public string Address { get; set; }
            public Nullable<bool> IsAdmitted { get; set; }
            public Nullable<System.DateTime> AdmittedDate { get; set; }
            public Nullable<bool> IsDischarged { get; set; }
            public Nullable<System.DateTime> DischargedDate { get; set; }
            public Nullable<System.Guid> RefferedDoctor { get; set; }
            public Nullable<System.DateTime> CasePaperIssuedDate { get; set; }
            public Nullable<System.DateTime> CasePaperExpiryDate { get; set; }
            public Nullable<System.Guid> WardNumberId { get; set; }
            public string RoomNumber { get; set; }
            public Nullable<System.Guid> RoomTypeId { get; set; }
            public Nullable<System.Guid> DepartmentId { get; set; }
            public Nullable<bool> IsActive { get; set; }
            public Nullable<bool> IsDeleted { get; set; }
            public Nullable<System.DateTime> CreatedOn { get; set; }
            public Nullable<System.DateTime> ModifiedOn { get; set; }
            public Nullable<System.Guid> CreatedBy { get; set; }
            public Nullable<System.Guid> ModifiedBy { get; set; }
            public string AadharCard { get; set; }
            public string PanCard { get; set; }            
            public string MobileNumber { get; set; }
        }
        #endregion

        #region --- User Function ---

        public List<PatientDetailModel> Get()
        {
            try
            {
                List<PatientDetailModel> list = new List<PatientDetailModel>();

                using (var db = new HMSEntities())
                {
                    list = db.PatientDetails
                                .Where(t => t.IsActive == true && t.IsDeleted != true)
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new PatientDetailModel()
                                {
                                    Id = t.Id,
                                    FullName = t.FullName,
                                    Address = t.Address,
                                    CasePaperNumber = t.CasePaperNumber,
                                    Gender = t.Gender,
                                    PhoneNumber = t.PhoneNumber,
                                    MobileNumber = t.MobileNumber,
                                    Age = t.Age,
                                    IsAdmitted = t.IsAdmitted,
                                    AdmittedDate = t.AdmittedDate,
                                    IsDischarged = t.IsDischarged,
                                    DischargedDate = t.DischargedDate,
                                    RefferedDoctor = t.RefferedDoctor,
                                    RefferedDoctorName = t.DoctorDetail.FullName,
                                    CasePaperIssuedDate = t.CasePaperIssuedDate,
                                    CasePaperExpiryDate = t.CasePaperExpiryDate,
                                    WardNumberId = t.WardNumberId,
                                    WardName = t.WardDetail.Name,
                                    RoomNumber = t.RoomNumber,
                                    RoomTypeId = t.RoomTypeId,                                    
                                    RoomTypeName = t.RoomType.Name,
                                    DepartmentId = t.DepartmentId,
                                    DepartmentName = t.Department.Name,
                                    AadharCard = t.AadharCard,
                                    PanCard = t.PanCard,
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
        public PatientDetailModel GetById(Guid id)
        {
            try
            {
                PatientDetailModel model = new PatientDetailModel();
                using (var db = new HMSEntities())
                {
                    PatientDetail entity = db.PatientDetails.Find(id);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.FullName = entity.FullName;
                        model.Address = entity.Address;
                        model.CasePaperNumber = entity.CasePaperNumber;
                        model.Gender = entity.Gender;
                        model.PhoneNumber = entity.PhoneNumber;
                        model.MobileNumber = entity.MobileNumber;
                        model.Age = entity.Age;
                        model.IsAdmitted = entity.IsAdmitted;
                        model.AdmittedDate = entity.AdmittedDate;
                        model.IsDischarged = entity.IsDischarged;
                        model.DischargedDate = entity.DischargedDate;
                        model.RefferedDoctor = entity.RefferedDoctor;
                        model.RefferedDoctorName = entity.DoctorDetail != null ? entity.DoctorDetail.FullName : "";
                        model.CasePaperIssuedDate = entity.CasePaperIssuedDate;
                        model.CasePaperExpiryDate = entity.CasePaperExpiryDate;
                        model.WardNumberId = entity.WardNumberId;
                        model.WardName = entity.WardDetail != null ? entity.WardDetail.Name : "";
                        model.RoomNumber = entity.RoomNumber;
                        model.RoomTypeId = entity.RoomTypeId;
                        model.RoomTypeName = entity.RoomType != null ? entity.RoomType.Name : "";
                        model.DepartmentId = entity.DepartmentId;
                        model.DepartmentName = entity.Department != null ? entity.Department.Name : "";
                        model.AadharCard = entity.AadharCard;
                        model.PanCard = entity.PanCard;
                        model.IsActive = entity.IsActive;
                        model.IsDeleted = entity.IsDeleted;
                        model.CreatedOn = entity.CreatedOn;
                        model.CreatedBy = entity.CreatedBy;
                        model.ModifiedOn = entity.ModifiedOn;
                        model.ModifiedBy = entity.ModifiedBy;
                        model.IPDBillAmount = GetIPDHistory(model.Id);
                    }

                }

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PatientDetailModel GetByName(string name)
        {
            try
            {
                PatientDetailModel model = new PatientDetailModel();
                using (var db = new HMSEntities())
                {
                    PatientDetail entity = db.PatientDetails.FirstOrDefault(t => t.FullName == name);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.FullName = entity.FullName;
                        model.Address = entity.Address;
                        model.CasePaperNumber = entity.CasePaperNumber;
                        model.Gender = entity.Gender;
                        model.PhoneNumber = entity.PhoneNumber;
                        model.MobileNumber = entity.MobileNumber;
                        model.Age = entity.Age;
                        model.IsAdmitted = entity.IsAdmitted;
                        model.AdmittedDate = entity.AdmittedDate;
                        model.IsDischarged = entity.IsDischarged;
                        model.DischargedDate = entity.DischargedDate;
                        model.RefferedDoctor = entity.RefferedDoctor;
                        model.RefferedDoctorName = entity.DoctorDetail != null ? entity.DoctorDetail.FullName : "";
                        model.CasePaperIssuedDate = entity.CasePaperIssuedDate;
                        model.CasePaperExpiryDate = entity.CasePaperExpiryDate;
                        model.WardNumberId = entity.WardNumberId;
                        model.WardName = entity.WardDetail != null ? entity.WardDetail.Name : "";
                        model.RoomNumber = entity.RoomNumber;
                        model.RoomTypeId = entity.RoomTypeId;
                        model.RoomTypeName = entity.RoomType != null ? entity.RoomType.Name : "";
                        model.DepartmentId = entity.DepartmentId;
                        model.DepartmentName = entity.Department != null ? entity.Department.Name : "";
                        model.AadharCard = entity.AadharCard;
                        model.PanCard = entity.PanCard;
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

        public PatientDetailModel GetByParentId(Guid id)
        {
            try
            {
                PatientDetailModel model = new PatientDetailModel();
                using (var db = new HMSEntities())
                {
                    PatientDetail entity = db.PatientDetails.FirstOrDefault(t => t.DepartmentId == id);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.FullName = entity.FullName;
                        model.Address = entity.Address;
                        model.CasePaperNumber = entity.CasePaperNumber;
                        model.Gender = entity.Gender;
                        model.PhoneNumber = entity.PhoneNumber;
                        model.MobileNumber = entity.MobileNumber;
                        model.Age = entity.Age;
                        model.IsAdmitted = entity.IsAdmitted;
                        model.AdmittedDate = entity.AdmittedDate;
                        model.IsDischarged = entity.IsDischarged;
                        model.DischargedDate = entity.DischargedDate;
                        model.RefferedDoctor = entity.RefferedDoctor;
                        model.RefferedDoctorName = entity.DoctorDetail.FullName;
                        model.CasePaperIssuedDate = entity.CasePaperIssuedDate;
                        model.CasePaperExpiryDate = entity.CasePaperExpiryDate;
                        model.WardNumberId = entity.WardNumberId;
                        model.WardName = entity.WardDetail.Name;
                        model.RoomNumber = entity.RoomNumber;
                        model.RoomTypeId = entity.RoomTypeId;
                        model.RoomTypeName = entity.RoomType.Name;
                        model.DepartmentId = entity.DepartmentId;
                        model.DepartmentName = entity.Department.Name;
                        model.AadharCard = entity.AadharCard;
                        model.PanCard = entity.PanCard;
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
        public bool Create(PatientDetailModel model)
        {
            try
            {
                bool isSaved = false;

                if (!IsExist(model))
                {
                    using (var db = new HMSEntities())
                    {
                        PatientDetail entity = new PatientDetail();

                        entity.FullName = model.FullName;
                        entity.Address = model.Address;
                        entity.CasePaperNumber = model.CasePaperNumber;
                        entity.Gender = model.Gender;
                        entity.PhoneNumber = model.PhoneNumber;
                        entity.MobileNumber = model.MobileNumber;
                        entity.Age = model.Age;
                        entity.IsAdmitted = model.IsAdmitted;
                        entity.AdmittedDate = model.AdmittedDate;
                        entity.IsDischarged = model.IsDischarged.HasValue ? model.IsDischarged : false;
                        entity.DischargedDate = model.DischargedDate;
                        entity.RefferedDoctor = model.RefferedDoctor;
                        entity.CasePaperIssuedDate = model.CasePaperIssuedDate;
                        entity.CasePaperExpiryDate = model.CasePaperIssuedDate.HasValue ? model.CasePaperIssuedDate.Value.AddMonths(2) : model.CasePaperExpiryDate;
                        entity.WardNumberId = model.WardNumberId;
                        entity.RoomNumber = model.RoomNumber;
                        entity.RoomTypeId = model.RoomTypeId;
                        entity.DepartmentId = model.DepartmentId;
                        entity.AadharCard = model.AadharCard;
                        entity.PanCard = model.PanCard;
                        entity.IsActive = true;
                        entity.IsDeleted = false;
                        entity.CreatedOn = DateTime.Now;
                        entity.CreatedBy = UserDetailSession.Id;
                        entity.ModifiedOn = DateTime.Now;

                        db.PatientDetails.Add(entity);

                        db.SaveChanges();
                        if (!entity.IsDischarged.Value)
                        {
                            if (model.OPDHistory != null)
                            {
                                OPDHistory historyEntity = new OPDHistory();
                                model.OPDHistory.PatientId = entity.Id;
                                model.OPDHistory.CasePaperNumber = model.CasePaperNumber;
                                model.OPDHistory.ECGAmount = (model.OPDHistory.IsECG.Value) ? OPDRate.GetRatesByType("ECG").Rate : 0.00M;
                                model.OPDHistory.XRAYAmount = model.OPDHistory.XRAYAmount;

                                int isFollowUp = 0;
                                if (model.IsOldPatient && model.CasePaperIssuedDate.Value.Date < DateTime.Now.Date)
                                    isFollowUp = 1;

                                isSaved = historyEntity.Create(model.OPDHistory, isFollowUp);
                            }
                        }
                        else
                        {
                            isSaved = CreateIPDHistory(entity.Id, model.IPDBillAmount);

                        }
                    }
                }
                return isSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CreateOPD(PatientDetailModel model)
        {
            try
            {
                bool isSaved = false;


                using (var db = new HMSEntities())
                {
                    bool isExpire = UpdateCasePaperDate(model);

                    OPDHistoryModel historyEntity = new OPDHistoryModel();
                    historyEntity.PatientId = model.Id;
                    historyEntity.InTime = DateTime.Now;
                    historyEntity.IsCharity = false;
                    historyEntity.IsLabCharity = false;
                    historyEntity.IsECG = false;
                    historyEntity.IsXRAY = false;
                    historyEntity.CasePaperNumber = model.CasePaperNumber;
                    //historyEntity.Amount = isExpire ? OPDRate.GetRatesByType("New").Rate : OPDRate.GetRatesByType("FollowUP").Rate;
                    //historyEntity.DueAmount = isExpire ? OPDRate.GetRatesByType("New").Rate : OPDRate.GetRatesByType("FollowUP").Rate;
                    historyEntity.ECGAmount = 0.00M;
                    historyEntity.XRAYAmount = 0.00M;
                    historyEntity.ThirdPartyLabAmoumt = 0.00M;
                    historyEntity.ConsultingDoctorId = new DoctorDetail().GetName("SIR");
                    historyEntity.TotalAmount = historyEntity.PaidAmount = historyEntity.LabTestingAmount = Convert.ToDecimal(0.00);
                    historyEntity.PatientDetails = new PatientDetailModel();
                    historyEntity.PatientDetails = model;
                    historyEntity.NumberofXRAY = 0;

                    isSaved = new OPDHistory().Create(historyEntity, isExpire ? 0 : 1);
                }

                return isSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateCasePaperDate(PatientDetailModel model)
        {
            using (var db = new HMSEntities())
            {
                PatientDetail entity = db.PatientDetails.Find(model.Id);
                TimeSpan ts = DateTime.Now.Date - entity.CasePaperExpiryDate.Value.Date;
                if (ts.TotalDays > 0)
                {
                    entity.CasePaperIssuedDate = DateTime.Now;
                    entity.CasePaperExpiryDate = DateTime.Now.AddMonths(2);
                    entity.ModifiedBy = UserDetailSession.Id;
                    entity.ModifiedOn = DateTime.Now;
                    db.SaveChanges();
                    return true;
                }

            }
            return false;
        }

        public static bool UpdateCasePaperDate(Guid? id)
        {
            using (var db = new HMSEntities())
            {
                PatientDetail entity = db.PatientDetails.Find(id);
                if (entity != null)
                {
                    TimeSpan ts = DateTime.Now.Date - entity.CasePaperExpiryDate.Value.Date;
                    if (ts.TotalDays > 0)
                    {
                        entity.CasePaperIssuedDate = DateTime.Now;
                        entity.CasePaperExpiryDate = DateTime.Now.AddMonths(2);
                        entity.ModifiedBy = UserDetailSession.Id;
                        entity.ModifiedOn = DateTime.Now;
                        db.SaveChanges();
                        return true;
                    }
                }

            }
            return false;
        }

        public bool CreateIPDHistory(Guid? patientId, decimal? bill)
        {
            using (var db = new HMSEntities())
            {
                IPDHistory entity = new IPDHistory();

                entity.TotalAmount = bill;
                entity.PatientId = patientId;
                entity.ReceivedBy = UserDetailSession.Id;
                db.IPDHistories.Add(entity);
                db.SaveChanges();
                return true;
            }
        }

        public decimal? GetIPDHistory(Guid? patientId)
        {
            using (var db = new HMSEntities())
            {
                if (db.IPDHistories.Any(t => t.PatientId == patientId))
                {
                    return db.IPDHistories.FirstOrDefault(t => t.PatientId == patientId).TotalAmount;
                }
                return 0.00M;
            }
        }
        public bool Update(PatientDetailModel model)
        {
            try
            {
                bool isSaved = false;

                if (!IsExist(model))
                {
                    using (var db = new HMSEntities())
                    {
                        PatientDetail entity = db.PatientDetails.Find(model.Id);

                        entity.FullName = model.FullName;
                        entity.Address = model.Address;
                        entity.CasePaperNumber = model.CasePaperNumber;
                        entity.Gender = model.Gender;
                        entity.PhoneNumber = model.PhoneNumber;
                        entity.MobileNumber = model.MobileNumber;
                        entity.Age = model.Age;
                        entity.IsAdmitted = model.IsAdmitted;
                        entity.AdmittedDate = model.AdmittedDate;
                        entity.IsDischarged = model.IsDischarged;
                        entity.DischargedDate = model.DischargedDate;
                        entity.RefferedDoctor = model.RefferedDoctor;
                        entity.CasePaperIssuedDate = model.CasePaperIssuedDate;
                        entity.WardNumberId = model.WardNumberId;
                        entity.RoomNumber = model.RoomNumber;
                        entity.RoomTypeId = model.RoomTypeId;
                        entity.DepartmentId = model.DepartmentId;
                        entity.AadharCard = model.AadharCard;
                        entity.PanCard = model.PanCard;
                        entity.ModifiedOn = DateTime.Now;
                        entity.ModifiedBy = UserDetailSession.Id;

                        db.SaveChanges();

                        if (entity.IsDischarged.Value)
                        {
                            isSaved = CreateIPDHistory(entity.Id, model.IPDBillAmount);
                        }

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
        public List<PatientDetailModel> AdvanceSearch(string searchText, int pageIndex = 1, int pageSize = 40)
        {
            try
            {
                List<PatientDetailModel> list = new List<PatientDetailModel>();

                using (var db = new HMSEntities())
                {
                    list = db.PatientDetails
                                 .Where(t => t.IsActive == true && t.IsDeleted != true && (t.FullName.Contains(searchText)
                                 || t.Address.Contains(searchText) || t.Department.Name.Contains(searchText) || t.CasePaperNumber.Contains(searchText)
                                  || t.PhoneNumber.Contains(searchText)))
                                .OrderByDescending(c => c.CreatedOn)
                                .Select(t => new PatientDetailModel()
                                {
                                    Id = t.Id,
                                    FullName = t.FullName,
                                    Address = t.Address,
                                    CasePaperNumber = t.CasePaperNumber,
                                    Gender = t.Gender,
                                    PhoneNumber = t.PhoneNumber,
                                    MobileNumber = t.MobileNumber,
                                    Age = t.Age,
                                    IsAdmitted = t.IsAdmitted,
                                    AdmittedDate = t.AdmittedDate,
                                    IsDischarged = t.IsDischarged,
                                    DischargedDate = t.DischargedDate,
                                    RefferedDoctor = t.RefferedDoctor,
                                    RefferedDoctorName = t.DoctorDetail.FullName,
                                    CasePaperIssuedDate = t.CasePaperIssuedDate,
                                    CasePaperExpiryDate = t.CasePaperExpiryDate,
                                    WardNumberId = t.WardNumberId,
                                    WardName = t.WardDetail.Name,
                                    RoomNumber = t.RoomNumber,
                                    RoomTypeId = t.RoomTypeId,
                                    RoomTypeName = t.RoomType.Name,
                                    DepartmentId = t.DepartmentId,
                                    DepartmentName = t.Department.Name,
                                    AadharCard = t.AadharCard,
                                    PanCard = t.PanCard,
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
        private bool IsExist(PatientDetailModel model)
        {
            try
            {
                Expression<Func<PatientDetail, bool>> predicate = null;

                using (var db = new HMSEntities())
                {
                    /* Build Predicate according to Create or Update */
                    if (!model.Id.HasValue)
                    {
                        predicate = o => o.IsActive == true && o.CasePaperNumber == model.CasePaperNumber && o.IsDeleted == false;//for Create Record
                    }
                    else
                    {
                        predicate = o => o.Id != model.Id && o.CasePaperNumber == model.CasePaperNumber && o.IsActive == true && o.IsDeleted == false;//for Update Record Record
                    }

                    /* return is Exist or not */
                    if (db.PatientDetails.Any(predicate))
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
        public static decimal? isFollowUpCheck(Guid? id)
        {
            using (var db = new HMSEntities())
            {

                if (UpdateCasePaperDate(id))
                    return OPDRate.GetRatesByType("New").Rate;
                else
                    return OPDRate.GetRatesByType("FollowUP").Rate;
            }

        }
        public string getNewCasePaperNumber()
        {
            string casePaperNumber = string.Empty;
            using (var db = new HMSEntities())
            {

                DateTime date = new DateTime(DateTime.Now.Year + 1, 01, 01);
                string todatdate = DateTime.Today.Year.ToString() + "." + DateTime.Today.Month.ToString("D2");
                if (date == DateTime.Now.Date)
                {
                    if (db.PatientDetails.Any(t => t.CreatedOn.HasValue))
                    {
                        if (!db.PatientDetails.Any(t => t.CreatedOn.Value.Date == date))
                        {

                            var a = db.PatientDetails.Max(t => Convert.ToInt64(t.CasePaperNumber.Replace(".", "")));
                            casePaperNumber = db.PatientDetails.Where(t => t.CreatedOn.HasValue && t.CasePaperNumber.Contains(todatdate)).OrderByDescending(t => t.CasePaperIssuedDate).FirstOrDefault().CasePaperNumber;

                            if (!string.IsNullOrEmpty(casePaperNumber))
                            {
                                string[] number = casePaperNumber.Split('.');
                                int newCase = Convert.ToInt32(number[2]) + 1;
                                casePaperNumber = DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString("D4") + "." + newCase.ToString("D4");
                            }
                        }
                        else
                        {
                            casePaperNumber = DateTime.Now.Year.ToString("D4") + "." + DateTime.Now.Month.ToString() + ".01";
                        }
                    }
                    else
                    {
                        string currentCasepaperNumber = Utility.Util.getValueFromConfig("currentCasepaperNumber");
                        string[] number = !string.IsNullOrEmpty(currentCasepaperNumber) ? Utility.Util.getValueFromConfig("currentCasepaperNumber").Split('.') : new string[] { DateTime.Now.Year.ToString("D4"), DateTime.Now.Month.ToString(), "00" };
                        int newCase = Convert.ToInt32(number[2]) + 1;
                        casePaperNumber = DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString("D2") + "." + newCase.ToString("D2");
                    }
                }
                else
                {

                    casePaperNumber = db.PatientDetails.Any(t => t.CreatedOn.HasValue) ? db.PatientDetails.Where(t => t.CreatedOn.HasValue && t.CasePaperNumber.Contains(t.CreatedOn.Value.Year.ToString())).OrderByDescending(t => t.CreatedOn).FirstOrDefault().CasePaperNumber : string.Empty;

                    if (!string.IsNullOrEmpty(casePaperNumber))
                    {
                        string[] number = casePaperNumber.Split('.');
                        int newCase = Convert.ToInt32(number[2]) + 1;
                        casePaperNumber = DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString("D2") + "." + newCase.ToString("D2");
                    }
                    else
                    {
                        string currentCasepaperNumber = Utility.Util.getValueFromConfig("currentCasepaperNumber");
                        string[] number = !string.IsNullOrEmpty(currentCasepaperNumber) ? Utility.Util.getValueFromConfig("currentCasepaperNumber").Split('.') : new string[] { DateTime.Now.Year.ToString("D4"), DateTime.Now.Month.ToString(), "00" };
                        int newCase = Convert.ToInt32(number[2]) + 1;
                        casePaperNumber = DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString("D2") + "." + newCase.ToString("D2");
                    }
                }

            }
            return casePaperNumber;
        }
        #endregion

        #region Comman Funtion
        public static PatientDetailModel SetModel(PatientDetail entity)
        {
            try
            {
                PatientDetailModel model = new PatientDetailModel();
                using (var db = new HMSEntities())
                {
                    //PatientDetail entity = db.PatientDetails.FirstOrDefault(t => t.FullName == name);
                    if (entity != null)
                    {
                        model.Id = entity.Id;
                        model.FullName = entity.FullName;
                        model.Address = entity.Address;
                        model.CasePaperNumber = entity.CasePaperNumber;
                        model.Gender = entity.Gender;
                        model.PhoneNumber = entity.PhoneNumber;
                        model.MobileNumber = entity.MobileNumber;
                        model.Age = entity.Age;
                        model.IsAdmitted = entity.IsAdmitted;
                        model.AdmittedDate = entity.AdmittedDate;
                        model.IsDischarged = entity.IsDischarged;
                        model.DischargedDate = entity.DischargedDate;
                        model.RefferedDoctor = entity.RefferedDoctor;
                        model.RefferedDoctorName = entity.DoctorDetail != null ? entity.DoctorDetail.FullName : "";
                        model.CasePaperIssuedDate = entity.CasePaperIssuedDate;
                        model.CasePaperExpiryDate = entity.CasePaperExpiryDate;
                        model.WardNumberId = entity.WardNumberId;
                        model.WardName = entity.WardDetail != null ? entity.WardDetail.Name : "";
                        model.RoomNumber = entity.RoomNumber;
                        model.RoomTypeId = entity.RoomTypeId;
                        model.RoomTypeName = entity.RoomType != null ? entity.RoomType.Name : "";
                        model.DepartmentId = entity.DepartmentId;
                        model.DepartmentName = entity.Department != null ? entity.Department.Name : "";
                        model.AadharCard = entity.AadharCard;
                        model.PanCard = entity.PanCard;
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

        public List<PatientDetailModel> GetGenericReport(Expression<Func<PatientDetail, bool>> predicate)
        {
            try
            {
                List<PatientDetailModel> list = new List<PatientDetailModel>();

                using (var db = new HMSEntities())
                {
                    var data = db.PatientDetails.Where(t => t.IsDischarged == true).Where(predicate).OrderBy(t => t.CreatedOn).ToList();
                    foreach (PatientDetail t in data)
                    {
                        PatientDetailModel model = new PatientDetailModel();
                        model.Id = t.Id;
                        model.FullName = t.FullName;
                        model.Address = t.Address;
                        model.CasePaperNumber = t.CasePaperNumber;
                        model.Gender = t.Gender;
                        model.PhoneNumber = t.PhoneNumber;
                        model.MobileNumber = t.MobileNumber;
                        model.Age = t.Age;
                        model.IsAdmitted = t.IsAdmitted;
                        model.AdmittedDate = t.AdmittedDate;
                        model.IsDischarged = t.IsDischarged;
                        model.DischargedDate = t.DischargedDate;
                        model.RefferedDoctor = t.RefferedDoctor;
                        model.RefferedDoctorName = t.DoctorDetail.FullName;
                        model.CasePaperIssuedDate = t.CasePaperIssuedDate;
                        model.CasePaperExpiryDate = t.CasePaperExpiryDate;
                        model.WardNumberId = t.WardNumberId;
                        model.WardName = t.WardDetail != null ? t.WardDetail.Name : string.Empty;
                        model.RoomNumber = t.RoomNumber;
                        model.RoomTypeId = t.RoomTypeId;
                        model.RoomTypeName = t.RoomType != null ? t.RoomType.Name : string.Empty;
                        model.DepartmentId = t.DepartmentId;
                        model.DepartmentName = t.Department != null ? t.Department.Name : string.Empty;
                        model.AadharCard = t.AadharCard;
                        model.PanCard = t.PanCard;
                        model.IsActive = t.IsActive;
                        model.IsDeleted = t.IsDeleted;
                        model.CreatedOn = t.CreatedOn;
                        model.CreatedBy = t.CreatedBy;
                        model.ModifiedOn = t.ModifiedOn;
                        model.ModifiedBy = t.ModifiedBy;
                        model.IPDBillAmount = t.IPDHistories.Any(o => o.PatientId == t.Id) ? t.IPDHistories.FirstOrDefault(o => o.PatientId == t.Id).TotalAmount : 0.00M;
                        model.ReceivedBy = t.IPDHistories.Any(o => o.PatientId == t.Id) ? t.IPDHistories.FirstOrDefault(o => o.PatientId == t.Id).ReceivedBy : null;
                        model.ReceivedName = model.ReceivedBy.HasValue ? UserDetail.GetNameById(model.ReceivedBy.Value) : string.Empty;
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
    }
}
