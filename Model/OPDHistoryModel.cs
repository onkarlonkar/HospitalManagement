using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OPDHistoryModel
    {
        public Nullable<System.Guid> Id { get; set; }
        public Nullable<System.Guid> PatientId { get; set; }

        public string PatientName { get; set; }

        public string CasePaperNumber { get; set; }
        public Nullable<int> Sequence { get; set; }
        public Nullable<System.DateTime> InTime { get; set; }
        public Nullable<System.DateTime> OutTime { get; set; }
        public Nullable<bool> IsCharity { get; set; }
        public Nullable<System.Guid> StatusId { get; set; }
        public Nullable<bool> IsECG { get; set; }
        public Nullable<bool> IsXRAY { get; set; }

        public string StatusName { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<decimal> PayingAmount { get; set; }
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
        public Nullable<int> NumberofXRAY { get; set; }
        public string DoctorNames { get; set; }
        public Nullable<System.Guid> ThirdPartyLabId { get; set; }
        public Nullable<decimal> ThirdPartyLabAmoumt { get; set; }
        public PatientDetailModel PatientDetails { get; set; }
        public List<OPDHistoryUpdateModel> OPDHistoryUpdates { get; set; }
        public BillHistoryModel BillHistory { get; set; }
    }
    public class DashboardModel
    {
        public Nullable<int> WaitingPatient { get; set; }
        public Nullable<int> InprogressPending { get; set; }

        public Nullable<int> MadamPatient { get; set; }
        public Nullable<int> SirPatient { get; set; }
        public Nullable<decimal> LabCollection { get; set; }
        public Nullable<decimal> OPDCollection { get; set; }
        public Nullable<decimal> ECGCollection { get; set; }
        public Nullable<decimal> XRAYCollection { get; set; }
        public Nullable<decimal> ThirePartyLabCollection { get; set; }
        public Nullable<decimal> ReceivedCollection { get; set; }
        public Nullable<decimal> TotalCollection { get; set; }
        public Nullable<decimal> DuesCollection { get; set; }

        public List<LookupModel> UsreCollection { get; set; }
        public List<OPDHistoryUpdateModel> RecentActivity { get; set; }
    }

    
}
