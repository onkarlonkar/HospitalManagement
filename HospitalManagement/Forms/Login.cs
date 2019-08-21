using BL;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace HospitalManagement.Forms
{
    public partial class Login : Form
    {
        IUserDetailService service = new UserDetailManager();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public Login()
        {
            InitializeComponent();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
          
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
           
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Login", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.Clicks == 1)
                    {
                        ReleaseCapture();
                        SendMessage(this.Handle, 0x112, 0xf012, 0);

                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Login", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void pbClose_MouseHover(object sender, EventArgs e)
        {
            pbClose.BackColor = Color.Red;
        }

        private void pbClose_MouseLeave(object sender, EventArgs e)
        {
            pbClose.BackColor = Color.Transparent;
        }

        private bool ValidateForm(out string errorMsg)
        {
            errorMsg = string.Empty;
            bool isValid = true;
            try
            {
                StringBuilder sbError = new StringBuilder();
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
                ErrorLog.Logging("Login", ex.Message.ToString(), ex.StackTrace.ToString());
                isValid = false;
            }

            return isValid;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string errorMessage = string.Empty;
                if (ValidateForm(out errorMessage))
                {

                    UserDetailModel model = service.Authenticate(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                    if (model.Id != null)
                    {
                        setUserDetailSession(model);
                        Dashboard frm = new Dashboard();
                        this.Hide();
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                        MessageBox.Show(ErrorMessages.incorrectuserpassword, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Login", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void setUserDetailSession(UserDetailModel model)
        {
            try
            {
                UserDetailSession.Id = model.Id;
                UserDetailSession.FullName = model.FullName;
                UserDetailSession.Address = model.Address;
                UserDetailSession.DepartmentId = model.DepartmentId;
                UserDetailSession.DepartmentName = model.DepartmentName;
                UserDetailSession.PhoneNumber = model.PhoneNumber;
                UserDetailSession.RoleCategoryId = model.RoleCategoryId;
                UserDetailSession.RoleCategoryName = model.RoleCategoryName;
                UserDetailSession.UserName = model.UserName;
                UserDetailSession.Password = model.Password;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Login", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
    }
}
