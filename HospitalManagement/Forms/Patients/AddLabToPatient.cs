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
    public partial class AddLabToPatient : Form
    {
        ILabDetailService labService = new LabDetailManager();
        ILookupService service = new LookUpManager();
        Guid? pId = null;
        Guid? opdId = null;
        public AddLabToPatient()
        {
            InitializeComponent();
            getThirdPartyLab();
        }

        public AddLabToPatient(Guid id)
        {
            InitializeComponent();
            this.opdId = id;
            getThirdPartyLab();
            getTPIssuedLab(id);

        }

        private bool saveData()
        {
            try
            {
                LookupModel model = assignModel();
                if (model != null)
                {
                    if (this.pId.HasValue)
                        return service.Update(LookUp.TPLab, model);
                    else
                        return service.Create(LookUp.TPLab, model);
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Department Operations", ex.Message.ToString(), ex.StackTrace.ToString());
                return false;
            }
        }


        private LookupModel assignModel()
        {
            try
            {
                LookupModel model = new LookupModel();
                model.Id = this.pId.HasValue ? this.pId : null;
                model.SubPerentId = new Guid(ddlThirdParty.SelectedValue.ToString());
                model.PerentId = this.opdId;
                model.Rate = Convert.ToDecimal(txtThirdPartyAmount.Text);
                return model;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Department Operations", ex.Message.ToString(), ex.StackTrace.ToString());
                return null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

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

        private void clearAll()
        {
            ddlThirdParty.SelectedIndex = 0;
            txtThirdPartyAmount.Text = "0.00";
        }

        private void ddlThirdParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlThirdParty.SelectedIndex > 0)
            {
                txtThirdPartyAmount.Enabled = true;
                if (txtThirdPartyAmount.Text == string.Empty)
                    txtThirdPartyAmount.Text = "0.00";
            }
            else
            {
                txtThirdPartyAmount.Text = "0.00";
                txtThirdPartyAmount.Enabled = false;
            }
        }

        private void getTPIssuedLab(Guid id)
        {
            List<LookupModel> lm = service.GetByOPDId(id);
            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = lm;
            dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvList.Refresh();

        }

        private void txtThirdPartyAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FillFormData(Guid? id)
        {
            try
            {

            }
            catch (Exception ex)
            {

                Utility.ErrorLog.Logging("Doctor List", ex.Message.ToString(), ex.StackTrace.ToString());
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
                        this.pId = new Guid(dgvList.CurrentRow.Cells[0].Value.ToString());
                        LookupModel m = service.GetById(LookUp.TPLab, this.pId.Value);
                        ddlThirdParty.SelectedValue = m.SubPerentId;
                        txtThirdPartyAmount.Text = Convert.ToString(m.Rate);
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

        private void btnSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

                if (this.saveData())
                {
                    //MessageBox.Show(Messages.savedSuccessfully, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //DepartmentList.isSubmited = true;
                    getTPIssuedLab(this.opdId.Value);
                    clearAll();
                    //this.Close();
                }

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Department Operations", ex.Message.ToString(), ex.StackTrace.ToString());

            }
        }
    }
}
