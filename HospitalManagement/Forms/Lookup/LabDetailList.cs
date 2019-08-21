using BL;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalManagement.Forms.Lookup
{
    public partial class LabDetailList : Form
    {
        ILabDetailService service = new LabDetailManager();
        public static bool isSubmited = false;
        public LabDetailList()
        {
            InitializeComponent();
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Lab List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("Lab List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("Lab List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void Search(string searchText = "")
        {
            try
            {
                List<LabDetailModel> list = service.AdvanceSearch(searchText);
                dgvList.AutoGenerateColumns = false;
                dgvList.DataSource = list;
                dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvList.Refresh();

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Lab List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                LabDetailOperations frm = new LabDetailOperations();
                frm.ShowDialog();

                if (isSubmited)
                    Search();

                isSubmited = false;
            }
            catch (Exception ex)
            {
                isSubmited = false;
                Utility.ErrorLog.Logging("Lab List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("Lab List", ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void FillFormData(Guid? id)
        {
            try
            {
                LabDetailModel model = service.GetById(id.Value);
                if (model != null)
                {
                    LabDetailOperations frm = new LabDetailOperations(model.Id);
                    frm.txtFullName.Text = model.Name;
                    frm.txtAddress.Text = model.Address;
                    frm.txtPathalogist.Text = model.PathelogistName;
                    frm.txtPhoneNumber.Text = model.PhoneNumber;               
                    frm.chkInHouse.Checked = model.IsInHouse.HasValue ? model.IsInHouse.Value : false;                    
                    frm.ShowDialog();
                    if (isSubmited)
                        Search();

                    isSubmited = false;
                }
            }
            catch (Exception ex)
            {
                isSubmited = false;
                Utility.ErrorLog.Logging("Lab List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("Lab List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
    }
}
