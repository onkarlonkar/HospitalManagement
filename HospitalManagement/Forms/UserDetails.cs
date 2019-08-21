using BL;
using Service;
using Model;
using System;
using Utility;
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

    public partial class UserDetails : Form
    {
        IUserDetailService service = new UserDetailManager();
        Guid? currentUserId = null;
        public UserDetails()
        {
            InitializeComponent();
            try
            {
                ClearAll();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("User Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
        public UserDetails(Guid? userId)
        {
            InitializeComponent();
            try
            {
                ClearAll();
                this.currentUserId = userId;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("User Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearAll();
                UserDetailList.isSubmited = false;
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("User Details", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private bool saveData()
        {
            try
            {
                UserDetailModel model = assignModel();
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
                Utility.ErrorLog.Logging("User Details", ex.Message.ToString(), ex.StackTrace.ToString());
                return false;
            }

        }

        private UserDetailModel assignModel()
        {
            UserDetailModel model = new UserDetailModel();
            try
            {
                model.Id = this.currentUserId;
                model.FullName = txtFullName.Text;
                model.Address = txtAddress.Text;
                model.PhoneNumber = txtMobile.Text;
                model.UserName = txtUsername.Text;
                model.Password = txtPassword.Text;

                return model;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("User Details", ex.Message.ToString(), ex.StackTrace.ToString());
                return null;
            }
        }
        private void ClearAll()
        {
            try
            {
                this.currentUserId = null;
                txtFullName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtMobile.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("User Details", ex.Message.ToString(), ex.StackTrace.ToString());

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
                            UserDetailList.isSubmited = true;
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
                Utility.ErrorLog.Logging("User Details", ex.Message.ToString(), ex.StackTrace.ToString());

            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
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

                if (txtUsername.Text == string.Empty)
                {
                    sbError.Append(ErrorMessages.PleaseenterUserName + "\n");
                    isValid = false;
                }

                if (txtPassword.Text == string.Empty)
                {
                    sbError.Append(ErrorMessages.PleaseenterPassword + "\n");
                    isValid = false;
                }
                errorMsg = sbError.ToString();

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("User Details Form", ex.Message.ToString(), ex.StackTrace.ToString());
            }
            return isValid;
        }
    }
}
