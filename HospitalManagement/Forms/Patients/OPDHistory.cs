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
    public partial class OPDHistory : Form
    {

        IOPDHistoryService service = new OPDHistoryManager();
        ILookupService lookupService = new LookUpManager();
        IPatientDetailService patientService = new PatientDetailManager();
        IDoctorDetailService refDoctorService = new DoctorDetailManager();
        ILabDetailService labService = new LabDetailManager();
        Guid? primaryId = null;
        // Guid? patientId = null;
        string formatStartRichtextbox = @"{\rtf1\ansi";
        string formatEndRichtextbox = @"}";
        internal decimal initialPaid, initialDues;
        public static bool isControlsEnabled = true;

        public Guid? patientId { get; set; }

        decimal? prevOPD = 0.00M;
        decimal? prevLab = 0.00M;

        bool isStatusHasInProgress = false;
        public int? sequence = null;



        public static bool isPrint = false;
        public static string printOption = string.Empty;
        public OPDHistory()
        {
            InitializeComponent();
            this.clearAll();
            clearStaticText();
            getPatientHistory();
            getStatus();
            getInHouseDoctor();
            //getThirdPartyLab();
            setNumberofXRAYVisibility();
        }

        public OPDHistory(Guid? id)
        {
            InitializeComponent();
            this.clearAll();
            clearStaticText();
            getStatus();
            getInHouseDoctor();
            //getThirdPartyLab();
            this.primaryId = id;
            getPatientHistory(id);
            disablePrintButton();
            initialPaid = Convert.ToDecimal(txtPaidAmount.Text);
            initialDues = Convert.ToDecimal(txtDueAmount.Text);
            disableControls();
            setNumberofXRAYVisibility();
            //setThirdPartyLabAmount();
        }

        private void disableControls()
        {
            ddlStatus.Enabled = isControlsEnabled;
            btnPrint.Enabled = false;

        }


        public void getPatientHistory(Guid? id = null)
        {
            try
            {

                List<OPDHistoryModel> list = service.GetHistoryByPatientId(id);

                StringBuilder sb = new StringBuilder();
                string tabSpace = @"         ";
                sb.Append(formatStartRichtextbox);
                foreach (OPDHistoryModel model in list)
                {

                    sb.Append(@" \line ");
                    sb.Append(@" \line ");
                    sb.Append(@"\b\i Case Paper Number: \i\b0 ");
                    sb.Append(model.CasePaperNumber);
                    sb.Append(@" \line ");
                    sb.Append(@"\b\i Name: \i\b0 ");
                    sb.Append(model.PatientDetails.FullName);
                    sb.Append(@" \line ");
                    sb.Append(@"\b Age: \b0 ");
                    sb.Append(model.PatientDetails.Age.ToString());
                    sb.Append(tabSpace);
                    sb.Append(tabSpace);
                    sb.Append(@"\b\i Date: \i\b0 ");
                    sb.Append(model.InTime.Value.ToShortDateString() + "  " + dtpInTime.Value.ToShortTimeString());
                    sb.Append(@" \line ");
                    sb.Append(@"\b Diagnose: \b0 ");
                    sb.Append(@" \line ");
                    sb.Append(model.Diagnose);
                    sb.Append(@" \line ");
                    sb.Append(@"\b Medicines: \b0 ");
                    sb.Append(@" \line ");
                    sb.Append(model.Madicines);

                }

                sb.Append(formatEndRichtextbox);

                richTextBox1.Rtf = sb.ToString();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPD History", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        public void disablePrintButton()
        {
            try
            {
                string status = service.GetById(this.primaryId.Value).StatusName;
                if (status == OPD_STATUS.Done.ToString())
                    btnPrint.Enabled = true;
                else
                    btnPrint.Enabled = false;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPD History", ex.Message.ToString(), ex.StackTrace.ToString());
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
                            MessageBox.Show(Messages.savedSuccessfully, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            OPDDashboard.isSubmited = true;
                            clearAll();
                            clearStaticText();
                            disablePrintButton();
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
                Utility.ErrorLog.Logging("OPD History", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.clearAll();
                clearStaticText();
                OPDDashboard.isSubmited = false;
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPD History", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void clearStaticText()
        {
            try
            {
                lblName.Text = "--";
                lblCasePaper.Text = "--";
                lblMobile.Text = "--";
                lblDepartment.Text = "--";
                lblExpDate.Text = "--";
                lblRefDr.Text = "--";
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPD History", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void clearAll()
        {

            chkCharity.Checked = false;
            chkLabCharity.Checked = false;
            rtxtDiagnose.Text = string.Empty;
            rtxtMedicine.Text = string.Empty;
            txtDueAmount.Text = "0.00";
            lblTotalAmount.Text = "0.00";
            txtOPDAmount.Text = "0.00";
            txtLabAmount.Text = "0.00";
            txtPayingAmount.Text = "0.00";
            txtPaidAmount.Text = "0.00";
            sequence = null;

        }

        private bool saveData()
        {
            try
            {
                bool isSave = false;
                OPDHistoryModel model = assignModel();
                if (model != null)
                {
                    isSave = service.Update(assignModel());
                    if (isSave)
                    {
                        //if (isStatusHasInProgress)
                        //{
                            if (sequence != null)
                            {
                                TokenList frm = TokenList.Instance;
                                frm.removeSequence(sequence.Value);
                            }

                        //}
                        return isSave;
                    }
                    else
                        return isSave;

                }
                else
                    return isSave;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPD History", ex.Message.ToString(), ex.StackTrace.ToString());
                return false;
            }
        }

        private string readRichTextbox(string[] valuearray)
        {
            StringBuilder sbText = new StringBuilder();
            try
            {
                foreach (string line in valuearray)
                {
                    string linevalue = line.Trim();
                    if (!string.IsNullOrEmpty(linevalue))
                    {
                        sbText.Append(linevalue);
                        sbText.Append(@" \line ");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPD History", ex.Message.ToString(), ex.StackTrace.ToString());
            }
            return sbText != null ? Util.TrimEnd(sbText.ToString(), @" \line ", StringComparison.OrdinalIgnoreCase) : "";

        }

        private OPDHistoryModel assignModel()
        {
            try
            {
                OPDHistoryModel model = new OPDHistoryModel();
                model.Id = this.primaryId;
                model.Diagnose = !string.IsNullOrEmpty(rtxtDiagnose.Text) ? readRichTextbox(rtxtDiagnose.Lines) : "";
                model.Madicines = !string.IsNullOrEmpty(rtxtMedicine.Text) ? readRichTextbox(rtxtMedicine.Lines) : "";
                model.StatusId = new Guid(ddlStatus.SelectedValue.ToString());
                model.Amount = !string.IsNullOrEmpty(txtOPDAmount.Text) ? Convert.ToDecimal(txtOPDAmount.Text) : Convert.ToDecimal(0.00);
                model.LabTestingAmount = !string.IsNullOrEmpty(txtLabAmount.Text) ? Convert.ToDecimal(txtLabAmount.Text) : Convert.ToDecimal(0.00);
                model.PayingAmount = !string.IsNullOrEmpty(txtPayingAmount.Text) ? Convert.ToDecimal(txtPayingAmount.Text) : Convert.ToDecimal(0.00);
                model.PaidAmount = !string.IsNullOrEmpty(txtPaidAmount.Text) ? Convert.ToDecimal(txtPaidAmount.Text) : Convert.ToDecimal(0.00);
                initialPaid = model.PaidAmount.Value;
                model.DueAmount = !string.IsNullOrEmpty(txtDueAmount.Text) ? Convert.ToDecimal(txtDueAmount.Text) : Convert.ToDecimal(0.00);
                initialDues = model.DueAmount.Value;
                model.TotalAmount = !string.IsNullOrEmpty(lblTotalAmount.Text) ? Convert.ToDecimal(lblTotalAmount.Text) : Convert.ToDecimal(0.00);
                model.PatientId = patientId;
                model.InTime = dtpInTime.Value;
                model.IsCharity = chkCharity.Checked;
                model.IsLabCharity = chkLabCharity.Checked;
                model.IsECG = chkECG.Checked;
                model.IsXRAY = chkXRay.Checked;
                model.ECGAmount = !string.IsNullOrEmpty(txtECG.Text) ? Convert.ToDecimal(txtECG.Text) : Convert.ToDecimal(0.00);
                model.XRAYAmount = !string.IsNullOrEmpty(txtXRay.Text) ? Convert.ToDecimal(txtXRay.Text) : Convert.ToDecimal(0.00);
                model.Sequence = sequence;
                //if (ddlThirdParty.SelectedIndex > 0)
                //    model.ThirdPartyLabId = new Guid(ddlThirdParty.SelectedValue.ToString());

                model.ThirdPartyLabAmoumt = !string.IsNullOrEmpty(txtThirdPartyAmount.Text) ? Convert.ToDecimal(txtThirdPartyAmount.Text) : Convert.ToDecimal(0.00);
                //if (ddlConsulting.SelectedIndex > 0)
                model.ConsultingDoctorId = new Guid(ddlConsulting.SelectedValue.ToString());
                model.NumberofXRAY = chkXRay.Checked && txtNumberOfXRay.Text != string.Empty ? Convert.ToInt32(txtNumberOfXRay.Text) : 0;
                return model;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPD History", ex.Message.ToString(), ex.StackTrace.ToString());
                return null;
            }
        }



        public void getStatus(Guid? id = null)
        {
            try
            {
                List<LookupModel> model = new List<LookupModel>();
                model = lookupService.Get(LookUp.Status);
                if (id.HasValue)
                {
                    LookupModel m = model.FirstOrDefault(t => t.Id == id.Value);
                    if (m != null)
                    {
                        if (m.Name == OPD_STATUS.Pending.ToString())
                        {
                            model = model.Where(t => t.Name != OPD_STATUS.Complete.ToString()).ToList();
                            //isStatusHasInProgress = false;
                        }
                        if (m.Name == OPD_STATUS.Complete.ToString())
                        {
                            model = model.Where(t => t.Name != OPD_STATUS.Pending.ToString()).ToList();
                            //isStatusHasInProgress = false;
                        }

                    }
                }
                else
                {
                    //isStatusHasInProgress = true;
                }

                model.Insert(0, new LookupModel() { Id = Guid.Empty, Name = "--Select Status--" });
                ddlStatus.DataSource = model;
                ddlStatus.DisplayMember = "Name";
                ddlStatus.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPD History", ex.Message.ToString(), ex.StackTrace.ToString());
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

        private void getThirdPartyLab()
        {
            try
            {
                List<LabDetailModel> model = labService.GetNonInHouse();
                model.Insert(0, new LabDetailModel() { Id = Guid.Empty, Name = "--Select Lab--" });
                ddlThirdParty.DataSource = model;
                ddlThirdParty.DisplayMember = "Name";
                ddlThirdParty.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void txtOPDAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Form Transaction", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintOptions frm = new PrintOptions(string.IsNullOrEmpty(rtxtMedicine.Text) || string.IsNullOrWhiteSpace(rtxtMedicine.Text) ? false : true);
                frm.ShowDialog();

                if (isPrint)
                {
                    if (service.Print(this.primaryId, printOption))
                    {
                        MessageBox.Show(Messages.printCompleted, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OPDDashboard.isSubmited = true;
                        clearAll();
                        clearStaticText();
                        disablePrintButton();
                        this.Close();
                    }
                }

                isPrint = false;
            }
            catch (Exception ex)
            {
                isPrint = false;
                Utility.ErrorLog.Logging("OPD History", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void calculateTotalAmount()
        {
            if (txtOPDAmount.Text != string.Empty)
            {
                decimal amount = Convert.ToDecimal(txtOPDAmount.Text);
                if (txtLabAmount.Text != string.Empty)
                {
                    decimal labamount = Convert.ToDecimal(txtLabAmount.Text);
                    amount = amount + labamount;
                    lblTotalAmount.Text = Convert.ToString(amount);
                    decimal paidAmount = txtPaidAmount.Text != string.Empty ? Convert.ToDecimal(txtPaidAmount.Text) : Convert.ToDecimal("0.00");
                    txtDueAmount.Text = Convert.ToString(amount - paidAmount);

                }
                else
                    lblTotalAmount.Text = Convert.ToString(amount);

                if (txtThirdPartyAmount.Text != string.Empty)
                {
                    decimal thirdPartyamount = Convert.ToDecimal(txtThirdPartyAmount.Text);
                    amount = amount + thirdPartyamount;
                    lblTotalAmount.Text = Convert.ToString(amount);
                    decimal paidAmount = txtPaidAmount.Text != string.Empty ? Convert.ToDecimal(txtPaidAmount.Text) : Convert.ToDecimal("0.00");
                    txtDueAmount.Text = Convert.ToString(amount - paidAmount);

                }
                else
                    lblTotalAmount.Text = Convert.ToString(amount);

                if (txtECG.Text != string.Empty)
                {
                    decimal ecgAmount = Convert.ToDecimal(txtECG.Text);
                    amount = amount + ecgAmount;
                    lblTotalAmount.Text = Convert.ToString(amount);
                    decimal paidAmount = txtPaidAmount.Text != string.Empty ? Convert.ToDecimal(txtPaidAmount.Text) : Convert.ToDecimal("0.00");
                    txtDueAmount.Text = Convert.ToString(amount - paidAmount);

                }
                else
                    lblTotalAmount.Text = Convert.ToString(amount);

                if (txtXRay.Text != string.Empty)
                {
                    decimal xRayAmount = Convert.ToDecimal(txtXRay.Text);
                    amount = amount + xRayAmount;
                    lblTotalAmount.Text = Convert.ToString(amount);
                    decimal paidAmount = txtPaidAmount.Text != string.Empty ? Convert.ToDecimal(txtPaidAmount.Text) : Convert.ToDecimal("0.00");
                    txtDueAmount.Text = Convert.ToString(amount - paidAmount);

                }
                else
                    lblTotalAmount.Text = Convert.ToString(amount);
            }
            else
                lblTotalAmount.Text = "0.00";
        }

        private void txtOPDAmount_Leave(object sender, EventArgs e)
        {
            if (txtOPDAmount.Text != string.Empty)
                calculateTotalAmount();
            else
                txtOPDAmount.Text = "0.00";
        }

        private void txtOPDAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtOPDAmount.Text != string.Empty)
                calculateTotalAmount();
        }

        private void txtLabAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtLabAmount.Text != string.Empty)
                calculateTotalAmount();
        }

        private void txtLabAmount_Leave(object sender, EventArgs e)
        {
            if (txtLabAmount.Text != string.Empty)
                calculateTotalAmount();
            else
                txtLabAmount.Text = "0.00";
        }

        private void calculateDuesAmount()
        {
            if (txtPaidAmount.Text != string.Empty && txtDueAmount.Text != string.Empty)
            {
                if (initialDues == Convert.ToDecimal(0.00))
                    initialDues = Convert.ToDecimal(txtDueAmount.Text);

                decimal paidAmount = Convert.ToDecimal(txtPaidAmount.Text);
                decimal duesAmount = Convert.ToDecimal(txtDueAmount.Text);
                if (txtPayingAmount.Text != string.Empty)
                {
                    decimal payingAmount = Convert.ToDecimal(txtPayingAmount.Text);
                    decimal totalPaid, totalDues;
                    if (payingAmount > initialDues && initialDues > 0)
                    {
                        MessageBox.Show("Paying amount should not be greater than Dues amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPaidAmount.Text = Convert.ToString(initialPaid);
                        txtDueAmount.Text = Convert.ToString(duesAmount);
                        txtPayingAmount.Text = "0.00";
                    }
                    else
                    {
                        totalDues = initialDues - payingAmount;
                        totalPaid = initialPaid + payingAmount;
                        txtPaidAmount.Text = Convert.ToString(totalPaid);
                        txtDueAmount.Text = Convert.ToString(totalDues);
                    }

                }
            }
        }

        private void OPDHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                try
                {
                    if (MessageBox.Show(Messages.DoYouWantToSave, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        if (this.saveData())
                        {
                            MessageBox.Show(Messages.savedSuccessfully, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            OPDDashboard.isSubmited = true;
                            clearAll();
                            clearStaticText();
                            disablePrintButton();
                            this.Close();
                        }

                    }
                }
                catch (Exception ex)
                {
                    Utility.ErrorLog.Logging("OPD History", ex.Message.ToString(), ex.StackTrace.ToString());
                }
            }
        }

        private void txtPayingAmount_TextChanged(object sender, EventArgs e)
        {
            calculateDuesAmount();
        }

        //private void ddlThirdParty_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlThirdParty.SelectedIndex > 0)
        //    {
        //        txtThirdPartyAmount.Enabled = true;
        //        if (txtThirdPartyAmount.Text == string.Empty)
        //            txtThirdPartyAmount.Text = "0.00";
        //    }
        //    else
        //    {
        //        txtThirdPartyAmount.Text = "0.00";
        //        txtThirdPartyAmount.Enabled = false;
        //    }
        //}

        private void txtXRay_TextChanged(object sender, EventArgs e)
        {
            if (txtXRay.Text != string.Empty)
                calculateTotalAmount();
        }

        private void txtECG_TextChanged(object sender, EventArgs e)
        {
            if (txtECG.Text != string.Empty)
                calculateTotalAmount();
        }

        private void txtThirdPartyAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtThirdPartyAmount.Text != string.Empty)
                calculateTotalAmount();
        }

        private void chkECG_CheckedChanged(object sender, EventArgs e)
        {
            if (chkECG.Checked)
                txtECG.Text = Convert.ToString(lookupService.GetByName(LookUp.OPDRate, "ECG").Rate);
            else
                txtECG.Text = "0.00";
        }

        private void chkXRay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkXRay.Checked)
            {
                setNumberofXRAYVisibility();
                txtXRay.Text = Convert.ToString(lookupService.GetByName(LookUp.OPDRate, "XRAY").Rate * Convert.ToInt32(txtNumberOfXRay.Text));

            }
            else
            {
                txtXRay.Text = "0.00";
                setNumberofXRAYVisibility();
            }
        }

        private void setNumberofXRAYVisibility()
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

        private void chkCharity_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCharity.Checked)
            {
                chkCharity.Enabled = false;
                chkLabCharity.Enabled = false;
                chkECG.Enabled = false;
                chkXRay.Enabled = false;
                //prevOPD = Convert.ToDecimal(txtOPDAmount.Text);
                txtOPDAmount.Text = "0.00";
                txtLabAmount.Text = "0.00";
                txtECG.Text = "0.00";
                txtXRay.Text = "0.00";
            }
            //else
            //    txtOPDAmount.Text = prevOPD.HasValue ? Convert.ToString(prevOPD) : "0.00";
        }

        private void chkLabCharity_CheckedChanged(object sender, EventArgs e)
        {
            txtLabAmount.Text = "0.00";
        }

        private void OPDHistory_Load(object sender, EventArgs e)
        {
            this.Focus();
            calculateTotalAmount();
            if (UserDetailSession.RoleCategoryName == "Admin")
                enableControlsForAdmin();
        }

        //private void txtThirdPartyAmount_Leave(object sender, EventArgs e)
        //{
        //    if (txtThirdPartyAmount.Text != string.Empty)
        //        calculateTotalAmount();
        //    else
        //        txtThirdPartyAmount.Text = "0.00";
        //}

        private void txtNumberOfXRay_TextChanged(object sender, EventArgs e)
        {
            if (txtNumberOfXRay.Text == string.Empty && chkXRay.Checked)
                txtNumberOfXRay.Text = "1";
            else
            {
                txtXRay.Text = Convert.ToString(lookupService.GetByName(LookUp.OPDRate, "XRAY").Rate * Convert.ToInt32(txtNumberOfXRay.Text));
            }
        }

        private bool formValidation(out string errorMsg)
        {
            errorMsg = string.Empty;
            StringBuilder sbError = new StringBuilder();
            bool isValid = true;
            try
            {
                if (ddlStatus.SelectedIndex == 5)
                {
                    //if (rtxtDiagnose.Text == string.Empty)
                    //{
                    //    sbError.Append(ErrorMessages.PleaseenterDiagnose + "\n");
                    //    isValid = false;
                    //}

                    //if (rtxtMedicine.Text == string.Empty)
                    //{
                    //    sbError.Append(ErrorMessages.PleaseenterMedicine + "\n");
                    //    isValid = false;
                    //}
                    decimal? dueAmount = Convert.ToDecimal(txtDueAmount.Text);
                    if (dueAmount > 0.00M)
                    {
                        sbError.Append(ErrorMessages.DueAmountShouldBeZero + "\n");
                        isValid = false;
                    }

                    errorMsg = sbError.ToString();
                }

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPD History Form", ex.Message.ToString(), ex.StackTrace.ToString());
            }
            return isValid;
        }

        private void btnLab_Click(object sender, EventArgs e)
        {
            AddLabToPatient frm = new AddLabToPatient(this.primaryId.Value);
            DialogResult r = frm.ShowDialog();
            setThirdPartyLabAmount();
            //txtThirdPartyAmount.Text = Convert.ToString(lookupService.GetTPAmount(this.primaryId.Value));
        }

        private void setThirdPartyLabAmount()
        {
            txtThirdPartyAmount.Text = Convert.ToString(lookupService.GetTPAmount(this.primaryId.Value));
        }

        private void enableControlsForAdmin()
        {
            chkCharity.Enabled = true;
            chkLabCharity.Enabled = true;
            chkXRay.Enabled = true;
            chkECG.Enabled = true;
            txtDueAmount.ReadOnly = false;
            txtPaidAmount.ReadOnly = false;
            txtOPDAmount.ReadOnly = false;
            ddlStatus.Enabled = true;

        }

    }
}
