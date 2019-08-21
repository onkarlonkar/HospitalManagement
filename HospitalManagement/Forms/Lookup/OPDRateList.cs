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

namespace HospitalManagement.Forms.Lookup
{
    public partial class OPDRateList : Form
    {
        ILookupService service = new LookUpManager();
        public static bool isSubmited = false;
        public OPDRateList()
        {
            InitializeComponent();
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPDRate List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("OPDRate List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("OPDRate List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void Search(string searchText = "")
        {
            try
            {
                List<LookupModel> list = service.AdvanceSearch(LookUp.OPDRate, searchText);
                dgvList.AutoGenerateColumns = false;
                dgvList.DataSource = list;
                dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvList.Refresh();

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPDRate List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                OPDRateOperations frm = new OPDRateOperations();
                frm.ShowDialog();

                if (isSubmited)
                    Search();

                isSubmited = false;
            }
            catch (Exception ex)
            {
                isSubmited = false;
                Utility.ErrorLog.Logging("OPDRate List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void FillFormData(Guid? id)
        {
            try
            {
                LookupModel model = service.GetById(LookUp.OPDRate, id.Value);
                if (model != null)
                {
                    Lookup.OPDRateOperations frm = new Lookup.OPDRateOperations(model.Id);                   
                    frm.txtName.Text = model.Name;                  
                    frm.txtRate.Text = Convert.ToString(model.Rate);
                    frm.ShowDialog();
                    if (isSubmited)
                        Search();

                    isSubmited = false;
                }
            }
            catch (Exception ex)
            {
                isSubmited = false;
                Utility.ErrorLog.Logging("OPDRate List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("OPDRate List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("OPDRate List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                Utility.ErrorLog.Logging("OPDRate List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
    }
}
