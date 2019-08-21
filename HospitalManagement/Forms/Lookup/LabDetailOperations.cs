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
    public partial class LabDetailOperations : Form
    {
        ILabDetailService service = new LabDetailManager();
        Guid? currentUserId = null;
        public LabDetailOperations()
        {
            InitializeComponent();
            try
            {
                ClearAll();
            }
            catch (Exception ex)
            {
                ErrorLog.Logging("Lab Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        public LabDetailOperations(Guid? id)
        {
            InitializeComponent();
            try
            {
                ClearAll();
                this.currentUserId = id;
            }
            catch (Exception ex)
            {
                ErrorLog.Logging("Lab Details", ex.Message.ToString(), ex.StackTrace.ToString());

            }
        }

        private void ClearAll()
        {
            try
            {
                this.currentUserId = null;
                txtFullName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtPathalogist.Text = string.Empty;
                txtPhoneNumber.Text = string.Empty;              
                chkInHouse.Checked = false;
            }
            catch (Exception ex)
            {
                ErrorLog.Logging("Lab Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private bool saveData()
        {
            try
            {
                LabDetailModel model = assignModel();
                if (model != null)
                {
                    if (this.currentUserId.HasValue)

                        return service.Update(model);
                    else
                        return service.Create(model);
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                ErrorLog.Logging("Lab Details", ex.Message.ToString(), ex.StackTrace.ToString());
                return false;
            }
        }

        private LabDetailModel assignModel()
        {
            LabDetailModel model = new LabDetailModel();
            try
            {
                model.Id = this.currentUserId;
                model.Name = txtFullName.Text;
                model.PathelogistName = txtPathalogist.Text;
                model.PhoneNumber = txtPhoneNumber.Text;
                model.Address = txtAddress.Text;              
                model.IsInHouse = chkInHouse.Checked;

                return model;
            }
            catch (Exception ex)
            {
                ErrorLog.Logging("Lab Details", ex.Message.ToString(), ex.StackTrace.ToString());
                return null;
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
                            LabDetailList.isSubmited = true;
                            ClearAll();
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
                ErrorLog.Logging("Lab Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearAll();
                LabDetailList.isSubmited = false;
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.Logging("Lab Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }



        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Form FatDetails", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private bool formValidation(out string errorMsg)
        {
            errorMsg = string.Empty;
            StringBuilder sbError = new StringBuilder();
            bool isValid = true;
            try
            {

                if (txtFullName.Text == string.Empty)
                {
                    sbError.Append(ErrorMessages.PleaseenterName + "\n");
                    isValid = false;
                }

                errorMsg = sbError.ToString();

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Lab Details Form", ex.Message.ToString(), ex.StackTrace.ToString());
            }
            return isValid;
        }

      
    }
}
