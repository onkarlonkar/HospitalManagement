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
    public partial class PatientList : Form
    {

        IPatientDetailService service = new PatientDetailManager();
        IOPDHistoryService opdService = new OPDHistoryManager();
        public static bool isSubmited = false;
        int pageIndex = 1;
        int PageSize = 40;
        public PatientList()
        {
            InitializeComponent();
            Search();
            txtSearch.Focus();
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
                    Search();
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void Search(string searchText = "")
        {
            try
            {
                List<PatientDetailModel> list = service.AdvanceSearch(searchText, pageIndex, PageSize);
                dgvList.AutoGenerateColumns = false;
                dgvList.DataSource = list;
                //dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                dgvList.Refresh();
                ///pageIndex++;

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                PatientDetails frm = new PatientDetails();
                frm.ShowDialog();

                if (isSubmited)
                    Search();

                isSubmited = false;
            }
            catch (Exception ex)
            {
                isSubmited = false;
                Utility.ErrorLog.Logging("Patient List", ex.Message.ToString(), ex.StackTrace.ToString());

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvList.SelectedRows.Count > 0)
                {
                    FillFormData(new Guid(dgvList.CurrentRow.Cells[0].Value.ToString()));

                }
                else
                {
                    MessageBox.Show("Please select row");
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void FillFormData(Guid? id)
        {
            try
            {
                PatientDetailModel model = service.GetById(id.Value);
                if (model != null)
                {
                    PatientDetails frm = new PatientDetails(model.Id);
                    frm.dtpIssueDate.Enabled = true;
                    frm.txtCasePaper.Text = model.CasePaperNumber;
                    frm.dtpIssueDate.Value = model.CasePaperIssuedDate.Value;
                    frm.txtFullName.Text = model.FullName;
                    frm.txtAadharcard.Text = model.AadharCard;
                    frm.txtPanCard.Text = model.PanCard;
                    frm.chkIsDischarged.Checked = model.IsDischarged.HasValue ? model.IsDischarged.Value : false;
                    frm.txtDepartment.Text = model.RoomNumber;
                    frm.txtMobileNumber.Text = model.MobileNumber;
                    frm.txtPhoneNumber.Text = model.PhoneNumber;
                    frm.txtAge.Text = Convert.ToString(model.Age);
                    frm.txtAddress.Text = model.Address;
                    setGender(ref frm, model.Gender.Value);
                    frm.ddlDepartment.SelectedValue = model.DepartmentId.HasValue ? model.DepartmentId : Guid.Empty;
                    frm.ddlRefDoctor.SelectedValue = model.RefferedDoctor.HasValue ? model.RefferedDoctor : Guid.Empty;
                    frm.dtpInTime.Enabled = false;
                    frm.chkCharity.Enabled = false;
                    frm.chkLabCharity.Enabled = false;
                    frm.chkXRay.Enabled = false;
                    frm.chkECG.Enabled = false;
                    frm.txtDischargeAmount.Text = Convert.ToString(model.IPDBillAmount);
                    frm.ShowDialog();
                    if (isSubmited)
                        Search();

                    isSubmited = false;
                }
            }
            catch (Exception ex)
            {
                isSubmited = false;
                Utility.ErrorLog.Logging("Patient List", ex.InnerException.ToString(), ex.StackTrace.ToString());
            }
        }

        private void setGender(ref PatientDetails frm, int value)
        {
            try
            {
                switch (value)
                {
                    case 1:
                        frm.rdoMale.Checked = true;
                        break;
                    case 2:
                        frm.rdoFemale.Checked = true;
                        break;
                    case 3:
                        frm.rdoTransGender.Checked = true;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgvList.SelectedRows.Count > 0)
                    {

                        DialogResult result = MessageBox.Show(Messages.AddPatientToOPDQueue, "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            if (service.CreateOPD(service.GetById(new Guid(dgvList.CurrentRow.Cells[0].Value.ToString()))))
                            {
                                MessageBox.Show(Messages.AddedPatientToOPDQueue, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //this.Close();
                            }
                            else
                            {
                                MessageBox.Show(Messages.alreadyExistsinQueue, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }


                        }
                        else if (result == DialogResult.No)
                        {
                            FillFormData(new Guid(dgvList.CurrentRow.Cells[0].Value.ToString()));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select row");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Patient List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }


        private void dgvList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult result = MessageBox.Show(Messages.AddPatientToOPDQueue, "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (service.CreateOPD(service.GetById(new Guid(dgvList.CurrentRow.Cells[0].Value.ToString()))))
                    {
                        MessageBox.Show(Messages.AddedPatientToOPDQueue, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Close();
                    }
                    else
                    {
                        MessageBox.Show(Messages.alreadyExistsinQueue, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
                else if (result == DialogResult.No)
                {
                    FillFormData(new Guid(dgvList.CurrentRow.Cells[0].Value.ToString()));
                }
            }
        }

        private void PatientList_Load(object sender, EventArgs e)
        {
            dgvList.Focus();
        }

        //private void dgvList_Scroll(object sender, ScrollEventArgs e)
        //{
        //    int display = dgvList.Rows.Count - dgvList.DisplayedRowCount(false);
        //    if (e.Type == ScrollEventType.SmallIncrement || e.Type == ScrollEventType.LargeIncrement)
        //    {
        //        if (e.NewValue >= dgvList.Rows.Count - GetDisplayedRowsCount())
        //        {
        //            Search();
        //            dgvList.ClearSelection();
        //            dgvList.FirstDisplayedScrollingRowIndex = display;
        //            pageIndex++;
        //        }
        //    }
        //}

        //private int GetDisplayedRowsCount()
        //{
        //    int count = dgvList.Rows[dgvList.FirstDisplayedScrollingRowIndex].Height;
        //    count = dgvList.Height / count;
        //    return count;
        //}
    }
}
