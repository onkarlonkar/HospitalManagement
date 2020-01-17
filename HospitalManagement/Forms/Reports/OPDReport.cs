using BL;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace HospitalManagement.Forms.Reports
{
    public partial class OPDReport : Form
    {


        IReportingService service = new ReportingManager();
        IDoctorDetailService refDoctorService = new DoctorDetailManager();
        ILookupService lookupService = new LookUpManager();
        public static bool isSubmited = false;
        bool isSearch = false;
        public OPDReport()
        {
            InitializeComponent();
            isSearch = true;
            getInHouseDoctor();
            getPatientType();
            getStatus();
            Search();
            txtSearch.Focus();
            isSearch = false;

        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search...";
                txtSearch.ForeColor = Color.FromArgb(0, 64, 64);
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.FromArgb(0, 64, 64);
            }
        }



        private void Search()
        {
            try
            {
                OPDFilterSearchModel model = getSearchModel();
                if (model != null)
                {
                    List<OPDHistoryModel> list = service.GetGenericReport(model);
                    dgvList.AutoGenerateColumns = false;
                    dgvList.DataSource = list;
                    //dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    dgvList.Refresh();

                }

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Report List", ex.InnerException.ToString(), ex.StackTrace.ToString());
            }
        }

        private void getInHouseDoctor()
        {
            try
            {
                List<DoctorDetailModel> model = refDoctorService.GetByType(true);
                model.Insert(0, new DoctorDetailModel() { Id = Guid.Empty, FullName = "All" });
                ddlConsulting.DataSource = model;
                ddlConsulting.DisplayMember = "FullName";
                ddlConsulting.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void getPatientType()
        {
            try
            {
                List<LookupModel> model = new List<LookupModel>();
                LookupModel m = new LookupModel();
                m.Sequence = 0;
                m.Name = "New";
                model.Add(m);
                m = new LookupModel();
                m.Sequence = 1;
                m.Name = "Follow-Up";
                model.Add(m);
                model.Insert(0, new LookupModel() { Sequence = null, Name = "All" });
                ddlFollowUp.DataSource = model;
                ddlFollowUp.DisplayMember = "Name";
                ddlFollowUp.ValueMember = "Sequence";

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void getStatus(Guid? id = null)
        {
            try
            {
                List<LookupModel> model = new List<LookupModel>();
                model = lookupService.Get(LookUp.Status);
                model.Insert(0, new LookupModel() { Id = Guid.Empty, Name = "ALL" });
                ddlStatus.DataSource = model;
                ddlStatus.DisplayMember = "Name";
                ddlStatus.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPD History", ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private OPDFilterSearchModel getSearchModel()
        {
            OPDFilterSearchModel model = new OPDFilterSearchModel();
            model.ConsultingId = new List<Guid?>();
            model.StatusId = new List<Guid?>();
            model.type = new List<int?>();
            if (!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text != "Search...")
            {
                model.searchText = txtSearch.Text;
            }

            if (ddlConsulting.SelectedIndex == 0)
            {

                if (model.ConsultingId.Any())
                    model.ConsultingId.Clear();
                List<DoctorDetailModel> docModel = refDoctorService.GetByType(true);
                foreach (DoctorDetailModel item in docModel)
                {
                    model.ConsultingId.Add(item.Id);
                }
            }
            else
            {
                if (model.ConsultingId.Any())
                    model.ConsultingId.Clear();
                model.ConsultingId.Add(new Guid(ddlConsulting.SelectedValue.ToString()));
            }

            if (ddlStatus.SelectedIndex == 0)
            {

                if (model.StatusId.Any())
                    model.StatusId.Clear();
                List<LookupModel> statusModel = lookupService.Get(LookUp.Status);
                foreach (LookupModel item in statusModel)
                {
                    model.StatusId.Add(item.Id);
                }
            }
            else
            {
                if (model.StatusId.Any())
                    model.StatusId.Clear();
                model.StatusId.Add(new Guid(ddlStatus.SelectedValue.ToString()));
            }

            if (ddlFollowUp.SelectedIndex == 0)
            {

                if (model.type.Any())
                    model.type.Clear();

                model.type.Add(1);
                model.type.Add(0);

            }
            else
            {
                if (model.type.Any())
                    model.type.Clear();
                model.type.Add(Convert.ToInt32(ddlFollowUp.SelectedValue));
            }


            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageBox.Show(ErrorMessages.FromDateToDate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                model.from = Convert.ToDateTime(dtpFrom.Value.ToShortDateString());
                model.to = Convert.ToDateTime(dtpTo.Value.AddDays(1).ToShortDateString());
            }

            return model;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                OPDFilterSearchModel model = getSearchModel();
                if (model != null)
                {
                    string path = service.DownloadReport(model);
                    MessageBox.Show(Messages.reportCompleted + path, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Report List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void ddlConsulting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isSearch)
            {
                Search();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text != "Search...")
                {
                    Search();
                }
                else
                {
                    Search();
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isSearch)
            {
                Search();
            }
        }

        private void ddlFollowUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isSearch)
            {
                Search();
            }
        }
    }
}
