using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Model;
using Service;
using Utility;

namespace HospitalManagement.Forms
{
    public partial class OPDDashboard : Form
    {
        Patients.TokenList frm = new Patients.TokenList();
        IOPDHistoryService service = new OPDHistoryManager();
        IDoctorDetailService docService = new DoctorDetailManager();
        public static bool isSubmited = false;
        public OPDDashboard()
        {
            InitializeComponent();
        }



        private void OPDDashboard_Load(object sender, EventArgs e)
        {
            getPandingPatient();
            getWaitingPatient();
            getDashboardCounts();
            //tmrRefresh.Enabled = true;
            //tmrRefresh.Start();
            dgvInCabin.ClearSelection();
            dgvWaiting.ClearSelection();
            getNextPatients();
            firstLoad();
        }

        private void refreshPage()
        {
            getPandingPatient();
            getWaitingPatient();
            getDashboardCounts();
            dgvInCabin.ClearSelection();
            dgvWaiting.ClearSelection();
        }


        private void Search(string searchText = "")
        {
            try
            {
                List<OPDHistoryModel> list = service.AdvanceSearch(searchText);
                dgvWaiting.AutoGenerateColumns = false;
                dgvWaiting.DataSource = list;
                //dgvWaiting.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvWaiting.Refresh();

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Main Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void getWaitingPatient()
        {
            try
            {
                List<OPDHistoryModel> list = service.GetByStatus(OPD_STATUS.Waiting.ToString(), OPD_STATUS.Complete.ToString(), OPD_STATUS.Done.ToString());
                dgvWaiting.AutoGenerateColumns = false;
                dgvWaiting.DataSource = list;
                //dgvWaiting.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvWaiting.Refresh();
                dgvWaiting.ClearSelection();

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Main Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void getPandingPatient()
        {
            try
            {
                List<OPDHistoryModel> list = service.GetByStatus(OPD_STATUS.Pending.ToString());
                dgvInCabin.AutoGenerateColumns = false;
                dgvInCabin.DataSource = list;
                //dgvInCabin.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvInCabin.Refresh();
                dgvInCabin.ClearSelection();


            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Main Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void firstLoad()
        {
            List<OPDHistoryModel> list = service.GetByStatus(OPD_STATUS.Pending.ToString());
            if (list.Count > 0)
            {
                ChangeToken(false);
                Patients.TokenList frm = Patients.TokenList.Instance;
                frm.setNextPatients(false);
            }
        }

        private void FillFormData(Guid? id)
        {
            try
            {
                OPDHistoryModel model = service.GetById(id.Value);
                if (model != null)
                {
                    Patients.OPDHistory frm = new Patients.OPDHistory(model.Id);
                    Patients.OPDHistory.isControlsEnabled = true;
                    frm.sequence = model.Sequence;
                    frm.patientId = model.PatientId;
                    frm.lblName.Text = model.PatientDetails.FullName;
                    frm.lblCasePaper.Text = model.PatientDetails.CasePaperNumber;
                    frm.lblMobile.Text = model.PatientDetails.MobileNumber;
                    frm.lblDepartment.Text = model.PatientDetails.DepartmentName;
                    frm.lblExpDate.Text = model.PatientDetails.CasePaperExpiryDate.HasValue ? model.PatientDetails.CasePaperExpiryDate.Value.ToShortDateString() : "--";
                    frm.lblRefDr.Text = model.PatientDetails.RefferedDoctor.HasValue ? model.PatientDetails.RefferedDoctorName : "--";
                    frm.dtpInTime.Value = model.InTime.Value;
                    frm.chkCharity.Checked = model.IsCharity.HasValue ? model.IsCharity.Value : false;
                    frm.chkXRay.Checked = model.IsXRAY.HasValue ? model.IsXRAY.Value : false;
                    frm.chkECG.Checked = model.IsECG.HasValue ? model.IsECG.Value : false;
                    frm.chkLabCharity.Checked = model.IsLabCharity.HasValue ? model.IsLabCharity.Value : false;
                    string diagnose = !string.IsNullOrEmpty(model.Diagnose) ? model.Diagnose.Trim() : string.Empty;
                    frm.rtxtDiagnose.Text = setRichTextbox(diagnose);
                    string madicines = !string.IsNullOrEmpty(model.Madicines) ? model.Madicines : string.Empty;
                    frm.rtxtMedicine.Text = setRichTextbox(madicines);
                    frm.txtOPDAmount.Text = model.Amount.HasValue ? Convert.ToString(model.Amount) : "0.00";
                    frm.txtLabAmount.Text = model.LabTestingAmount.HasValue ? Convert.ToString(model.LabTestingAmount) : "0.00";
                    frm.txtECG.Text = model.ECGAmount.HasValue ? Convert.ToString(model.ECGAmount) : "0.00";
                    frm.txtXRay.Text = model.XRAYAmount.HasValue ? Convert.ToString(model.XRAYAmount) : "0.00";
                    frm.initialPaid = model.PaidAmount.HasValue ? model.PaidAmount.Value : Convert.ToDecimal(0.00);
                    frm.txtPaidAmount.Text = model.PaidAmount.HasValue ? Convert.ToString(model.PaidAmount) : "0.00";
                    frm.initialDues = model.DueAmount.HasValue ? model.DueAmount.Value : Convert.ToDecimal(0.00);
                    frm.txtDueAmount.Text = model.DueAmount.HasValue ? Convert.ToString(model.DueAmount) : "0.00";
                    frm.lblTotalAmount.Text = Convert.ToString(model.TotalAmount);
                    frm.getStatus(model.StatusId);
                    frm.ddlStatus.SelectedValue = model.StatusId;
                    frm.ddlConsulting.SelectedValue = model.ConsultingDoctorId.HasValue ? model.ConsultingDoctorId : docService.GetInHouse("SIR");
                    frm.txtThirdPartyAmount.Text = model.ThirdPartyLabAmoumt.HasValue ? Convert.ToString(model.ThirdPartyLabAmoumt) : "0.00";
                    frm.ddlThirdParty.SelectedValue = model.ThirdPartyLabId.HasValue ? model.ThirdPartyLabId : Guid.Empty;
                    frm.txtNumberOfXRay.Text = model.NumberofXRAY.HasValue ? Convert.ToString(model.NumberofXRAY) : "0";
                    tmrRefresh.Stop();
                    tmrRefresh.Enabled = false;

                    frm.ShowDialog();
                    if (isSubmited)
                    {
                        getPandingPatient();
                        getWaitingPatient();
                    }
                    getDashboardCounts();
                    tmrRefresh.Enabled = true;
                    tmrRefresh.Start();

                    isSubmited = false;
                }
            }
            catch (Exception ex)
            {
                isSubmited = false;
                Utility.ErrorLog.Logging("Main Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private string setRichTextbox(string strValue)
        {
            StringBuilder sbText = new StringBuilder();
            try
            {
                string[] valuearray = strValue.Split(new string[] { @"\line" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string line in valuearray)
                {
                    string linevalue = line.Trim();
                    if (!string.IsNullOrEmpty(linevalue))
                    {
                        sbText.Append(linevalue);
                        sbText.Append(Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Main Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
            return sbText != null ? sbText.ToString() : "";

        }

        private void getDashboardCounts()
        {
            try
            {
                DashboardModel model = service.getDashboardCounts();
                lblWaitingPatient.Text = Convert.ToString(model.WaitingPatient);
                lblDonePatient.Text = Convert.ToString(model.InprogressPending);
                lblMadamPatient.Text = Convert.ToString(model.MadamPatient);
                lblSIRPatient.Text = Convert.ToString(model.SirPatient);
                lblOPDCollection.Text = Convert.ToString(model.OPDCollection);
                lblLabCollection.Text = Convert.ToString(model.LabCollection);
                lblTPLabCollection.Text = Convert.ToString(model.ThirePartyLabCollection);
                lblECG.Text = Convert.ToString(model.ECGCollection);
                lblXRAY.Text = Convert.ToString(model.XRAYCollection);
                lblDuesCollection.Text = Convert.ToString(model.DuesCollection);
                lblTotalCollection.Text = Convert.ToString(model.TotalCollection);
                lblReceivedCollection.Text = Convert.ToString(model.ReceivedCollection);
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Main Dashboard", ex.InnerException.ToString(), ex.StackTrace.ToString());
            }
        }

        private void dgvInCabin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgvInCabin.SelectedRows.Count > 0)
                    {
                        Patients.OPDHistory.isControlsEnabled = false;
                        FillFormData(new Guid(dgvInCabin.CurrentRow.Cells[0].Value.ToString()));

                    }
                    else
                    {
                        MessageBox.Show("Please select row");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Main Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void dgvWaiting_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.RowIndex != getRowIndexForSelection() && dgvWaiting.CurrentRow.Cells[6].Value.ToString()!=OPD_STATUS.Complete.ToString())
                    {
                        Patients.OPDHistory.isControlsEnabled = false;
                        FillFormData(new Guid(dgvWaiting.CurrentRow.Cells[0].Value.ToString()));
                    }
                    else
                    {
                        if (dgvWaiting.SelectedRows.Count > 0)
                        {
                            FillFormData(new Guid(dgvWaiting.CurrentRow.Cells[0].Value.ToString()));

                        }
                        else
                        {
                            MessageBox.Show("Please select row");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Main Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private int getRowIndexForSelection()
        {
            int index = -1;
            foreach (DataGridViewRow row in dgvWaiting.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Convert.ToString(row.Cells[6].Value) == OPD_STATUS.Waiting.ToString())
                {
                    index = row.Index;
                    break;
                }
                //else if (Convert.ToString(row.Cells[6].Value) == OPD_STATUS.Complete.ToString())
                //{
                //    index = row.Index;
                //    break;
                //}
            }
            return index;
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            try
            {
                getPandingPatient();
                getWaitingPatient();
                getDashboardCounts();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Main Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text == "")
                {
                    txtSearch.Text = "Search...";
                    txtSearch.ForeColor = Color.FromArgb(0, 64, 64);
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Main Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text == "Search...")
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.FromArgb(0, 64, 64);
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Main Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text != "Search...")
                {
                    Search(txtSearch.Text.Trim());
                }
                else
                {
                    getPandingPatient();
                    getWaitingPatient();
                    getDashboardCounts();
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Main Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void dgvWaiting_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvWaiting.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Convert.ToString(row.Cells[6].Value) == OPD_STATUS.Done.ToString())// Or your condition 
                {
                    if (Convert.ToDecimal(row.Cells[15].Value) > 0M)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(220, 78, 65);
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(101, 156, 0);
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
                else
                {
                    if (Convert.ToDecimal(row.Cells[15].Value) > 0M)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(220, 78, 65);
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 135, 13);
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }


            }
        }

        private void dgvInCabin_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvInCabin.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Convert.ToString(row.Cells[6].Value) == OPD_STATUS.Done.ToString())// Or your condition 
                {
                    if (Convert.ToDecimal(row.Cells[15].Value) > 0M)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(220, 78, 65);
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(101, 156, 0);
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
                else
                {
                    if (Convert.ToDecimal(row.Cells[15].Value) > 0M)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(220, 78, 65);
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 135, 13);
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        private void lblOPDCollection_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hi");
        }

        private void lblOPDCollection_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("hi");
        }

        private void lblTitleXRAY_DoubleClick(object sender, EventArgs e)
        {
            Common.patientDialog frm = new Common.patientDialog(P_TYPE.XRAY);
            frm.ShowDialog();
        }

        private void lblTitleECG_DoubleClick(object sender, EventArgs e)
        {
            Common.patientDialog frm = new Common.patientDialog(P_TYPE.ECG);
            frm.ShowDialog();
        }

        private void getNextPatients()
        {

            try
            {
                List<LookupModel> model = new List<LookupModel>();
                LookupModel m = new LookupModel();
                for (int i = 1; i <= 6; i++)
                {
                    m = new LookupModel();
                    m.Sequence = i;
                    m.Name = i.ToString();
                    model.Add(m);
                }


                model.Insert(0, new LookupModel() { Sequence = 0, Name = "--" });
                ddlNextPatients.DataSource = model;
                ddlNextPatients.DisplayMember = "Name";
                ddlNextPatients.ValueMember = "Sequence";

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void ddlNextPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNextPatients.SelectedIndex > 0)
            {
                //LookupModel m = (LookupModel);
                List<OPDHistoryModel> list = service.GetByStatus(OPD_STATUS.Pending.ToString());
                service.UpdateStatus(list, OPD_STATUS.Complete);
                UserDetailSession.NumberPatientCount = Convert.ToInt32(ddlNextPatients.SelectedValue);
                ChangeToken();
                Patients.TokenList frm = Patients.TokenList.Instance;
                frm.setNextPatients();

                refreshPage();

            }
            else
            {
                UserDetailSession.NumberPatientCount = 0;
                for (int i = 0; i < 6; i++)
                {
                    RoundedButton tbx = this.Controls.Find("lbl" + (i + 1), true).FirstOrDefault() as RoundedButton;
                    tbx.Visible = false;
                    tbx.Update();
                }
            }

        }

        private void ChangeToken(bool isFirstTime = true)
        {

            List<OPDHistoryModel> list = isFirstTime ? service.GetByStatus(OPD_STATUS.Waiting.ToString()).Take(UserDetailSession.NumberPatientCount).ToList()
                : service.GetByStatus(OPD_STATUS.Pending.ToString());
            //service.UpdateStatus(list, OPD_STATUS.Pending);

            for (int i = 0; i < 6; i++)
            {
                if (list.Count > i)
                {
                    RoundedButton tbx = this.Controls.Find("lbl" + (i + 1), true).FirstOrDefault() as RoundedButton;
                    tbx.Visible = true;
                    tbx.Text = Convert.ToString(list[i].Sequence);
                    tbx.Update();
                }
                else
                {
                    RoundedButton tbx = this.Controls.Find("lbl" + (i + 1).ToString(), true).FirstOrDefault() as RoundedButton;
                    tbx.Text = "--";
                    tbx.Visible = false;
                    tbx.Update();
                }

            }
        }

        internal void removeSequence()
        {
            List<OPDHistoryModel> list = service.GetByStatus(OPD_STATUS.Pending.ToString());
            for (int i = 0; i < 6; i++)
            {
                RoundedButton tbx = this.Controls.Find("lbl" + (i + 1), true).FirstOrDefault() as RoundedButton;
                if (tbx.Text == list[i].Sequence.ToString())
                {
                    tbx.Text = "--";
                    tbx.Visible = false;
                }
                tbx.Update();
            }
        }

        private void btnTokenPageRefresh_Click(object sender, EventArgs e)
        {
            List<OPDHistoryModel> list = service.GetByStatus(OPD_STATUS.Pending.ToString());
            service.UpdateStatus(list, OPD_STATUS.Complete);
            ChangeToken();
            Patients.TokenList frm = Patients.TokenList.Instance;
            frm.setNextPatients();

            refreshPage();
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {

        }
    }
}

