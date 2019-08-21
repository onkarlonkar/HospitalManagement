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

namespace HospitalManagement.Forms
{
    public partial class UserDetailList : Form
    {
        /* implementing service */
        IUserDetailService service = new UserDetailManager();
        public static bool isSubmited = false;
        public UserDetailList()
        {
            InitializeComponent();
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("User List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void Search(string searchText = "")
        {
            try
            {
                List<UserDetailModel> list = service.AdvanceSearch(searchText);
                dgvList.AutoGenerateColumns = false;
                dgvList.DataSource = list;
                dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvList.Refresh();

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("User List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                UserDetails frm = new UserDetails();
                frm.ShowDialog();

                if (isSubmited)
                    Search();

                isSubmited = false;
            }
            catch (Exception ex)
            {
                isSubmited = false;
                Utility.ErrorLog.Logging("User List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void FillFormData(Guid? id)
        {
            try
            {
                UserDetailModel model = service.GetById(id.Value);
                if (model != null)
                {
                    UserDetails frm = new UserDetails(model.Id);
                    frm.txtFullName.Text = model.FullName;
                    frm.txtAddress.Text = model.Address;
                    frm.txtMobile.Text = model.PhoneNumber;
                    frm.txtUsername.Text = model.UserName;
                    frm.txtPassword.Text = model.Password;
                    frm.ShowDialog();
                    if (isSubmited)
                        Search();

                    isSubmited = false;
                }
            }
            catch (Exception ex)
            {
                isSubmited = false;
                Utility.ErrorLog.Logging("User List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("User List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("User List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("User List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("User List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("User List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

    }

}
