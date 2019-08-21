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
    public partial class StatusOperations : Form
    {
        ILookupService service = new LookUpManager();
        Guid? currentUserId = null;
        public StatusOperations()
        {
            InitializeComponent();
            try
            {
                GetPerent();
                ClearAll();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Status Operations", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        public StatusOperations(Guid? userId)
        {
            InitializeComponent();
            try
            {
                ClearAll();
                GetPerent();
                this.currentUserId = userId;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Status Operations", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private bool saveData()
        {
            try
            {
                LookupModel model = assignModel();
                if (model != null)
                {
                    if (this.currentUserId.HasValue)
                        return service.Update(LookUp.Status, model);
                    else
                        return service.Create(LookUp.Status, model);
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Status Operations", ex.Message.ToString(), ex.StackTrace.ToString());
                return false;
            }
        }

        private LookupModel assignModel()
        {
            try
            {
                LookupModel model = new LookupModel();
                model.Id = this.currentUserId;
                model.PerentId = new Guid(ddlDepartment.SelectedValue.ToString());
                model.Name = txtName.Text;
                model.Sequence = Convert.ToInt32(txtSequence.Text);
                model.Description = txtDescription.Text;

                return model;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Status Operations", ex.Message.ToString(), ex.StackTrace.ToString());
                return null;
            }
        }

        private void GetPerent()
        {
            try
            {
                List<LookupModel> model = service.Get(LookUp.Department);
                model.Insert(0, new LookupModel() { Id = Guid.Empty, Name = "--Select Department--" });
                ddlDepartment.DataSource = model;
                ddlDepartment.DisplayMember = "Name";
                ddlDepartment.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Status Operations", ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void ClearAll()
        {
            try
            {
                this.currentUserId = null;
                txtName.Text = string.Empty;
                txtDescription.Text = string.Empty;
                GetPerent();
                ddlDepartment.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Status Operations", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(Messages.DoYouWantToSave, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (this.saveData())
                    {
                        MessageBox.Show(Messages.savedSuccessfully, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        StatusList.isSubmited = true;
                        ClearAll();
                        this.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Status Operations", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearAll();
                StatusList.isSubmited = false;
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Status Operations", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtSequence_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Status Operations", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
    }
}
