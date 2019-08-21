using BL;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalManagement.Forms.Doctor
{
    public partial class DoctorList : Form
    {
        IDoctorDetailService service = new DoctorDetailManager();
        public static bool isSubmited = false;
        public DoctorList()
        {
            InitializeComponent();
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Doctor List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("Doctor List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("Doctor List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void Search(string searchText = "")
        {
            try
            {
                List<DoctorDetailModel> list = service.AdvanceSearch(searchText);
                dgvList.AutoGenerateColumns = false;
                dgvList.DataSource = list;
                dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvList.Refresh();

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Doctor List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("Investigation Category List Form", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                DoctorDetails frm = new DoctorDetails();
                frm.ShowDialog();

                if (isSubmited)
                    Search();

                isSubmited = false;
            }
            catch (Exception ex)
            {
                isSubmited = false;
                Utility.ErrorLog.Logging("Doctor List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("Doctor List", ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void FillFormData(Guid? id)
        {
            try
            {
                DoctorDetailModel model = service.GetById(id.Value);
                if (model != null)
                {
                    DoctorDetails frm = new DoctorDetails(model.Id);
                    if (model.FullName.ToUpper() == "SIR" || model.FullName.ToUpper() == "MADAM")
                        frm.txtFullName.ReadOnly = true;
                    frm.txtFullName.Text = model.FullName;
                    frm.txtAddress.Text = model.Address;
                    frm.txtMobileNumber.Text = model.MobileNumber;
                    frm.txtPhoneNumber.Text = model.PhoneNumber;
                    frm.txtQualification.Text = model.Qualification;
                    frm.txtClinic.Text = model.ClinicName;
                    frm.txtClinicContact.Text = model.ClinicContact;
                    frm.txtAge.Text = Convert.ToString(model.Age);
                    frm.chkConsultant.Checked = model.IsCounsalting.HasValue ? model.IsCounsalting.Value : false;
                    frm.chkInHouse.Checked = model.IsInHouse.HasValue ? model.IsInHouse.Value : false;
                    setGender(ref frm, model.Gender.Value);
                    frm.ShowDialog();
                    if (isSubmited)
                        Search();

                    isSubmited = false;
                }
            }
            catch (Exception ex)
            {
                isSubmited = false;
                Utility.ErrorLog.Logging("Doctor List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }


        private void setGender(ref DoctorDetails frm, int value)
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

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
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
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Doctor List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
    }
}
