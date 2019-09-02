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

namespace HospitalManagement.Forms.Patients
{
    public partial class IPDHistory : Form
    {
        IPatientDetailService service = new PatientDetailManager();
        ILookupService lookupService = new LookUpManager();
        IDoctorDetailService refDoctorService = new DoctorDetailManager();
        string casePaperNumber = "";
        //IAppDomainSetu service = new PatientDetailManager();
        Guid? currentUserId = null;
        public IPDHistory()
        {
            InitializeComponent();
            getDepartment();
            getRefDoctor();
            getInHouseDoctor();
            clearAll();
            getNewCasePaperNumber();
            chkIsDischarged.Checked = false;
            txtDepartment.Visible = false;
            txtDepartment.Text = string.Empty;
            txtNumberOfXRay.Visible = false;
            lblXRayText.Visible = false;
            txtNumberOfXRay.Text = "0";
        }

        private void getNewCasePaperNumber()
        {
            txtCasePaper.Text = service.getNewCasePaperNumber();
        }

        public IPDHistory(Guid? userId)
        {
            InitializeComponent();
            getDepartment();
            getRefDoctor();
            getInHouseDoctor();
            clearAll();
            this.currentUserId = userId;
            VisibleIPDSection();
        }

        private bool saveData()
        {
            try
            {
                PatientDetailModel model = assignModel();
                if (model != null)
                {
                    if (this.currentUserId.HasValue)
                        return service.Update(assignModel());
                    else
                        return service.Create(assignModel());
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
                return false;
            }
        }

        private PatientDetailModel assignModel()
        {
            try
            {
                PatientDetailModel model = new PatientDetailModel();
                model.Id = this.currentUserId;
                model.CasePaperNumber = txtCasePaper.Text;
                model.FullName = txtFullName.Text;
                model.CasePaperIssuedDate = dtpIssueDate.Value;
                model.AadharCard = txtAadharcard.Text;
                model.PanCard = txtPanCard.Text;
                model.IsDischarged = chkIsDischarged.Checked;
                model.RoomNumber = txtDepartment.Text;
                model.RefferedDoctor = new Guid(ddlRefDoctor.SelectedValue.ToString());
                model.MobileNumber = txtMobileNumber.Text;
                model.PhoneNumber = txtPhoneNumber.Text;
                model.DepartmentId = new Guid(ddlDepartment.SelectedValue.ToString());
                model.Address = txtAddress.Text;
                model.Age = Convert.ToInt32(txtAge.Text);
                model.Gender = getGender();
                model.OPDHistory = new OPDHistoryModel();
                model.OPDHistory.InTime = dtpInTime.Value;
                //model.OPDHistory.Amount = Convert.ToDecimal(txtOPDAmount.Text);
                //model.OPDHistory.LabTestingAmount = 0.00M;
                //model.OPDHistory.TotalAmount = model.OPDHistory.Amount;
                //model.OPDHistory.PaidAmount = model.OPDHistory.PayingAmount;
                //model.OPDHistory.DueAmount = model.OPDHistory.Amount - model.OPDHistory.PayingAmount;
                model.OPDHistory.IsCharity = chkCharity.Checked;
                model.OPDHistory.IsLabCharity = chkLabCharity.Checked;
                model.OPDHistory.IsECG = chkECG.Checked;
                model.OPDHistory.XRAYAmount = chkXRay.Checked ? lookupService.GetRatesByType("XRAY").Rate * Convert.ToDecimal(txtNumberOfXRay.Text) : 0.00M;
                model.OPDHistory.NumberofXRAY = txtNumberOfXRay.Text != string.Empty ? Convert.ToInt32(txtNumberOfXRay.Text) : 0;
                model.OPDHistory.IsXRAY = chkXRay.Checked;
                model.IPDBillAmount = txtDischargeAmount.Text != string.Empty ? Convert.ToDecimal(txtDischargeAmount.Text) : 0.00M;
                model.IsOldPatient = chkOldPatient.Checked;
                model.OPDHistory.ConsultingDoctorId = new Guid(ddlConsulting.SelectedValue.ToString());
                return model;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient Details", ex.Message.ToString(), ex.StackTrace.ToString());
                return null;
            }
        }

        private void clearAll()
        {
            try
            {
                this.currentUserId = null;
                txtCasePaper.Text = string.Empty;
                dtpIssueDate.Value = DateTime.Now;
                txtFullName.Text = string.Empty;
                txtAadharcard.Text = string.Empty;
                txtPanCard.Text = string.Empty;
                txtMobileNumber.Text = string.Empty;
                txtPhoneNumber.Text = string.Empty;
                txtAge.Text = string.Empty;
                txtAddress.Text = string.Empty;
                rdoMale.Checked = true;
                ddlDepartment.SelectedIndex = 0;
                ddlRefDoctor.SelectedIndex = 0;
                dtpInTime.Value = DateTime.Now;
                chkCharity.Checked = false;
                chkLabCharity.Checked = false;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private int? getGender()
        {
            try
            {
                if (rdoMale.Checked)
                    return 1;
                else if (rdoFemale.Checked)
                    return 2;
                else
                    return 3;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient Details", ex.Message.ToString(), ex.StackTrace.ToString());
                return null;
            }
        }

        private void getRefDoctor()
        {
            try
            {
                List<DoctorDetailModel> model = refDoctorService.Get();
                model.Insert(0, new DoctorDetailModel() { Id = Guid.Empty, FullName = "--Select Doctor--" });
                ddlRefDoctor.DataSource = model;
                ddlRefDoctor.DisplayMember = "FullName";
                ddlRefDoctor.ValueMember = "Id";

                if (model.Count <= 2)
                {
                    ddlRefDoctor.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void getInHouseDoctor()
        {
            try
            {
                List<DoctorDetailModel> model = refDoctorService.GetByType(true);
                //model.Insert(0, new DoctorDetailModel() { Id = Guid.Empty, FullName = "--Select Doctor--" });
                ddlConsulting.DataSource = model;
                ddlConsulting.DisplayMember = "FullName";
                ddlConsulting.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void getDepartment()
        {
            try
            {
                List<LookupModel> model = lookupService.Get(LookUp.Department);
                //model.Insert(0, new LookupModel() { Id = Guid.Empty, Name = "--Select Department--" });
                ddlDepartment.DataSource = model;
                ddlDepartment.DisplayMember = "Name";
                ddlDepartment.ValueMember = "Id";

                if (model.Count <= 2)
                {
                    ddlDepartment.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string errorMessage = string.Empty;
                if (formValidation(out errorMessage))
                {
                    if (MessageBox.Show(Messages.DoYouWantToSave, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        if (this.saveData())
                        {
                            //MessageBox.Show(Messages.savedSuccessfully, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PatientList.isSubmited = true;
                            clearAll();
                            this.Close();
                        }

                    }
                }
                else
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.clearAll();
                PatientList.isSubmited = false;
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient Details", ex.Message.ToString(), ex.StackTrace.ToString());

            }
        }

        private void txtAadharcard_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private bool formValidation(out string errorMsg)
        {
            errorMsg = string.Empty;
            StringBuilder sbError = new StringBuilder();
            bool isValid = true;
            try
            {
                if (txtCasePaper.Text.Trim() == string.Empty)
                {
                    sbError.Append(ErrorMessages.PleaseenterCasePaperNumber + "\n");
                    isValid = false;
                }

                if (txtFullName.Text.Trim() == string.Empty)
                {
                    sbError.Append(ErrorMessages.PleaseenterName + "\n");
                    isValid = false;
                }

                if (txtAge.Text.Trim() == string.Empty)
                {
                    sbError.Append(ErrorMessages.PleaseenterAge + "\n");
                    isValid = false;
                }
                if (txtMobileNumber.Text.Trim() == string.Empty)
                {
                    sbError.Append(ErrorMessages.PleaseenterMobileNumber + "\n");
                    isValid = false;
                }


                errorMsg = sbError.ToString();

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient Details Form", ex.Message.ToString(), ex.StackTrace.ToString());
            }
            return isValid;
        }



        private void visibleIPDSection()
        {
            //ddlConsulting.SelectedIndex = 0;
            chkCharity.Checked = false;
            chkLabCharity.Checked = false;
            chkECG.Checked = false;
            chkXRay.Checked = false;
            opdSection.Visible = false;
            IPDSection.Visible = true;
        }

        private void visibleOPDSection()
        {
            txtDischargeAmount.Text = "0.00";
            opdSection.Visible = true;
            IPDSection.Visible = false;
        }

        private void VisibleIPDSection()
        {
            if (chkIsDischarged.Checked)
            {
                visibleIPDSection();
                ddlDepartment.Visible = false;
                txtDepartment.Visible = true;
                ddlDepartment.SelectedIndex = 0;
                chkOldPatient.Checked = false;
                chkOldPatient.Enabled = false;
            }
            else
            {
                visibleOPDSection();
                txtDepartment.Visible = false;
                ddlDepartment.Visible = true;
                txtDepartment.Text = string.Empty;
                chkOldPatient.Enabled = true;

            }
        }

        private void chkIsDischarged_CheckedChanged(object sender, EventArgs e)
        {
            VisibleIPDSection();
        }

        private void chkCharity_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCharity.Checked)
            {
                chkLabCharity.Enabled = false;
                chkECG.Enabled = false;
                chkXRay.Enabled = false;
            }
            else
            {
                chkLabCharity.Enabled = true;
                chkECG.Enabled = true;
                chkXRay.Enabled = true;
            }
        }

        private void chkOldPatient_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOldPatient.Checked)
            {
                dtpIssueDate.Enabled = true;
                dtpIssueDate.MaxDate = DateTime.Now;
                dtpIssueDate.MinDate = DateTime.Now.AddMonths(-2);
                txtCasePaper.Text = string.Empty;
                MessageBox.Show(ErrorMessages.pleaseSelectCasepaperIssueDate, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dtpIssueDate.MaxDate = DateTime.Now.AddDays(1);
                dtpIssueDate.MinDate = DateTime.Now.AddMonths(-2);
                dtpIssueDate.Value = DateTime.Now;
                dtpIssueDate.Enabled = false;
                getNewCasePaperNumber();
            }
        }

        private void chkXRay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkXRay.Checked)
            {
                txtNumberOfXRay.Visible = true;
                lblXRayText.Visible = true;
                txtNumberOfXRay.Text = "1";
            }
            else
            {
                txtNumberOfXRay.Visible = false;
                lblXRayText.Visible = false;
                txtNumberOfXRay.Text = "0";
            }

        }

        private void txtNumberOfXRay_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Form Transaction", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
    }
}
