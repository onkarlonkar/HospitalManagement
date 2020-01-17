using Model;
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

namespace HospitalManagement.Forms
{
    public partial class Dashboard : Form
    {

        //Patients.TokenList frm = new Patients.TokenList();
        public Dashboard()
        {
            InitializeComponent(); try
            {
                CollapseAllMaster("Master");
                AddFormToPanel(new OPDDashboard());
                showHideMenu();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        #region Menu Design

        bool isIncrement = true;
        bool isCollaspe = true;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void pnlHeader_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (this.WindowState == FormWindowState.Normal)
                    {
                        Left = Top = 0;
                        Width = Screen.PrimaryScreen.WorkingArea.Width;
                        Height = Screen.PrimaryScreen.WorkingArea.Height;
                        pbMiximise.Visible = false;
                        pbRestore.Visible = true;
                    }
                    else if (this.WindowState == FormWindowState.Maximized)
                    {
                        this.WindowState = FormWindowState.Normal;
                        pbMiximise.Visible = true;
                        pbRestore.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.Clicks == 1)
                    {
                        ReleaseCapture();
                        SendMessage(this.Handle, 0x112, 0xf012, 0);
                        if (this.WindowState == FormWindowState.Maximized)
                        {
                            pbMiximise.Visible = false;
                            pbRestore.Visible = true;
                        }
                        else
                        {
                            pbMiximise.Visible = true;
                            pbRestore.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
        private void pbClose_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        int LY, LX;
        private void pbMiximise_Click(object sender, EventArgs e)
        {
            try
            {
                this.LY = this.Location.Y;
                this.LX = this.Location.X;
                //this.WindowState = FormWindowState.Maximized;
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                this.Location = Screen.PrimaryScreen.WorkingArea.Location;
                pbMiximise.Visible = false;
                pbRestore.Visible = true;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
        private void pbRestore_Click(object sender, EventArgs e)
        {
            try
            {
                //this.WindowState = FormWindowState.Normal;
                this.Size = new Size(1300, 650);
                this.Location = new Point(this.LX, this.LY);
                pbMiximise.Visible = true;
                pbRestore.Visible = false;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
        private void pbMinimise_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
        private void SlideAnimation()
        {
            try
            {
                if (isIncrement)
                {
                    //menubtnSettingPrnt.Image = Resources.Collapse_Arrow_18px;
                    pnlmainMenu.Width += 50;
                    pnlCmpTitle.Visible = true;
                    if (pnlmainMenu.Size.Width > -pnlmainMenu.MaximumSize.Width)
                    {

                        pnlmainMenu.Width = 200;
                        timerSlide.Stop();
                        isIncrement = false;
                    }

                }
                else
                {
                    //menubtnSettingPrnt.Image = Resources.Expand_Arrow_18px;
                    pnlCmpTitle.Visible = false;
                    pnlmainMenu.Width -= 50;
                    if (pnlmainMenu.Size.Width <= pnlmainMenu.MinimumSize.Width)
                    {
                        pnlmainMenu.Width = 50;
                        timerSlide.Stop();
                        isIncrement = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void pbMenu_Click(object sender, EventArgs e)
        {
            try
            {
                timerSlide.Start();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void timerSlide_Tick(object sender, EventArgs e)
        {
            try
            {
                SlideAnimation();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void pbClose_MouseHover(object sender, EventArgs e)
        {
            try
            {
                pbClose.BackColor = Color.Red;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void pbClose_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                pbClose.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void pbMiximise_MouseHover(object sender, EventArgs e)
        {
            try
            {

                pbMiximise.BackColor = Color.FromArgb(117, 200, 255);
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void pbMiximise_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                pbMiximise.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void pbRestore_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                pbRestore.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void pbRestore_MouseHover(object sender, EventArgs e)
        {
            try
            {
                pbRestore.BackColor = Color.FromArgb(117, 200, 255);
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void pbMinimise_MouseHover(object sender, EventArgs e)
        {
            try
            {
                pbMinimise.BackColor = Color.FromArgb(117, 200, 255);
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void pbMinimise_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                pbMinimise.BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void CollapseMenu(Panel pnlName)
        {
            try
            {
                if (isCollaspe)
                {
                    pnlName.Height += 10;
                    if (pnlName.Size == pnlName.MaximumSize)
                    {
                        tmrSubMenu.Stop();

                        isCollaspe = false;
                    }

                }
                else
                {
                    pnlName.Height -= 10;
                    if (pnlName.Size == pnlName.MinimumSize)
                    {
                        tmrSubMenu.Stop();

                        isCollaspe = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void tmrSubMenu_Tick(object sender, EventArgs e)
        {
            try
            {
                CollapseMenu(pnlSettings);
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                tmrSubMenu.Start();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }


        private void showHideMenu()
        {
            if (UserDetailSession.RoleCategoryName == "Admin")
            {
                pnlSettings.Visible = true;
                btnMenuReport.Visible = true;
                btnMenuIPDReport.Visible = true;
            }
            else
            {
                pnlSettings.Visible = false;
                btnMenuReport.Visible = false;
                btnMenuIPDReport.Visible = false;
            }
        }



        private void CollapseAllMaster(params string[] pnlName)
        {
            isCollaspe = false;

            foreach (string item in pnlName)
            {
                switch (item)
                {
                    case "Master":
                        tmrSubMenu.Start();

                        break;
                    default:
                        break;
                }
            }


        }
        #endregion

        private void AddFormToPanel(object form)
        {
            try
            {
                if (this.pnlFormContainer.Controls.Count > 0)
                    this.pnlFormContainer.Controls.RemoveAt(0);

                Form frm = form as Form;
                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                this.pnlFormContainer.Controls.Add(frm);
                this.pnlFormContainer.Tag = frm;
                this.pnlFormContainer.VerticalScroll.Visible = true;
                frm.Show();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }



        private void btnMenuOPD_Click(object sender, EventArgs e)
        {
            try
            {
                CollapseAllMaster("Master");
                AddFormToPanel(new Patients.PatientList());
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnMenuDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                CollapseAllMaster("Master");
                AddFormToPanel(new Lookup.DepartmentList());
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnMenuStatus_Click(object sender, EventArgs e)
        {
            try
            {
                CollapseAllMaster("Master");
                AddFormToPanel(new Lookup.StatusList());
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnMenuDoctor_Click(object sender, EventArgs e)
        {
            try
            {
                CollapseAllMaster("Master");
                AddFormToPanel(new Doctor.DoctorList());
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void lblCmpTitle_Click(object sender, EventArgs e)
        {
            try
            {
                CollapseAllMaster("Master");
                AddFormToPanel(new OPDDashboard());
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void pnlLogo_Click(object sender, EventArgs e)
        {
            try
            {
                CollapseAllMaster("Master");
                AddFormToPanel(new OPDDashboard());
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                Left = Top = 0;
                Width = Screen.PrimaryScreen.WorkingArea.Width;
                Height = Screen.PrimaryScreen.WorkingArea.Height;
                //AddFormToPanel(new OPDDashboard());
                //for (int i = 0; i < 4; i++)
                //{
                //    notifyIcon1.Icon = SystemIcons.Information;
                //    notifyIcon1.BalloonTipTitle = "Recent Changes" + i.ToString();
                //    notifyIcon1.BalloonTipText = "Welcome to Application";
                //    notifyIcon1.ShowBalloonTip(1000);
                //}


            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnMenuDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                CollapseAllMaster("Master");
                AddFormToPanel(new OPDDashboard());
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    // do something...
                    return true;
                case Keys.Control | Keys.Alt | Keys.S:
                    // do something...
                    return true;
                case Keys.F1:
                    try
                    {
                        CollapseAllMaster("Master");
                        AddFormToPanel(new Patients.PatientList());
                    }
                    catch (Exception ex)
                    {
                        Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
                    }
                    return true;
                case Keys.F2:
                    try
                    {
                        CollapseAllMaster("Master");
                        AddFormToPanel(new UserDetailList());

                    }
                    catch (Exception ex)
                    {
                        Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
                    }
                    return true;
                case Keys.F3:
                    try
                    {
                        CollapseAllMaster("Master");
                        AddFormToPanel(new Doctor.DoctorList());
                    }
                    catch (Exception ex)
                    {
                        Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
                    }
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void btnMenuReport_Click(object sender, EventArgs e)
        {
            try
            {
                CollapseAllMaster("Master");
                AddFormToPanel(new Reports.OPDReport());
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnMasterMenuLab_Click(object sender, EventArgs e)
        {
            try
            {
                CollapseAllMaster("Master");
                AddFormToPanel(new Lookup.LabDetailList());
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnMenuMasterRate_Click(object sender, EventArgs e)
        {
            try
            {
                CollapseAllMaster("Master");
                AddFormToPanel(new Lookup.OPDRateList());
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnMenuIPDReport_Click(object sender, EventArgs e)
        {
            try
            {

                CollapseAllMaster("Master");
                AddFormToPanel(new Reports.IPDReport());
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }


        private void btnRoomType_Click(object sender, EventArgs e)
        {
            try
            {
                CollapseAllMaster("Master");
                AddFormToPanel(new Lookup.RoomTypeList());
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnWard_Click(object sender, EventArgs e)
        {
            try
            {
                CollapseAllMaster("Master");
                AddFormToPanel(new Lookup.WardDetailList());
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnMenuDepartment_Click_1(object sender, EventArgs e)
        {
            try
            {
                CollapseAllMaster("Master");
                AddFormToPanel(new Lookup.DepartmentList());
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnMenuTokenList_Click(object sender, EventArgs e)
        {
            try
            {
                Patients.TokenList f = Patients.TokenList.Instance;
                
                //Patients.TokenList frm = new Patients.TokenList();
                f.Show();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnMenuUsers_Click(object sender, EventArgs e)
        {
            try
            {
                CollapseAllMaster("Master");
                AddFormToPanel(new UserDetailList());
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
    }
}
