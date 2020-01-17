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
    public partial class TokenList : Form
    {
        private static TokenList instance;
        IOPDHistoryService service = new OPDHistoryManager();
        public TokenList()
        {
            InitializeComponent();
        }

        public static TokenList Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TokenList();
                    instance.Show();
                }
                return instance;
            }
        }


        internal void removeSequence(int sequence)
        {
            getPatient();
            labelSize();
            for (int i = 0; i < 6; i++)
            {
                RoundedButton tbx = this.Controls.Find("lbl" + (i + 1), true).FirstOrDefault() as RoundedButton;
                if (tbx.Text == sequence.ToString())
                {
                    tbx.Text = "--";
                    tbx.Visible = false;
                }
                tbx.Update();
            }
        }

        private void ChangeToken(bool isUpdateStatus = true)
        {
            List<OPDHistoryModel> list = isUpdateStatus ? service.GetByStatus(OPD_STATUS.Waiting.ToString(), OPD_STATUS.Pending.ToString()).Take(UserDetailSession.NumberPatientCount).ToList()
                : service.GetByStatus(OPD_STATUS.Pending.ToString());
            if (isUpdateStatus)
                service.UpdateStatus(list, OPD_STATUS.Pending);

            for (int i = 0; i < 6; i++)
            {
                if (list.Count > i)
                {
                    RoundedButton tbx = this.Controls.Find("lbl" + (i + 1), true).FirstOrDefault() as RoundedButton;
                    tbx.Text = Convert.ToString(list[i].Sequence);
                    tbx.Visible = true;
                    tbx.Update();
                }
                else
                {
                    RoundedButton tbx = this.Controls.Find("lbl" + (i + 1).ToString(), true).FirstOrDefault() as RoundedButton;
                    tbx.Text = "--";
                    tbx.Visible = false;
                    tbx.Update();
                }

            }
        }



        public void labelSize()
        {
            lbl1.Font = new Font("Times New Roman", (pnl1.Width + pnl1.Height) / 12, FontStyle.Bold);
            lbl2.Font = new Font("Times New Roman", (pnl2.Width + pnl2.Height) / 12, FontStyle.Bold);
            lbl3.Font = new Font("Times New Roman", (pnl3.Width + pnl3.Height) / 12, FontStyle.Bold);
            lbl4.Font = new Font("Times New Roman", (pnl4.Width + pnl4.Height) / 12, FontStyle.Bold);
            lbl5.Font = new Font("Times New Roman", (pnl5.Width + pnl5.Height) / 12, FontStyle.Bold);
            lbl6.Font = new Font("Times New Roman", (pnl6.Width + pnl6.Height) / 12, FontStyle.Bold);
            dgvList.DefaultCellStyle.Font = new Font("Century Gothic", (pnl1.Width + pnl1.Height) / 35);

        }

        public void setNextPatients(bool isUpdateStatus = true)
        {
            ChangeToken(isUpdateStatus);
            getPatient();
            labelSize();
        }

        private void TokenList_Load(object sender, EventArgs e)
        {
            //var primaryDisplay = Screen.AllScreens.ElementAtOrDefault(0);
            //var extendedDisplay = Screen.AllScreens.FirstOrDefault(s => s != primaryDisplay) ?? primaryDisplay;

            //this.Left = extendedDisplay.WorkingArea.Left + (extendedDisplay.Bounds.Size.Width / 2) - (this.Size.Width / 2);
            //this.Top = extendedDisplay.WorkingArea.Top + (extendedDisplay.Bounds.Size.Height / 2) - (this.Size.Height / 2);
            showOnMonitor(1);
            ChangeToken();
            getPatient();
            labelSize();
        }

        private void showOnMonitor(int showOnMonitor)
        {
            Screen[] sc;
            sc = Screen.AllScreens;
            if (showOnMonitor >= sc.Length)
            {
                showOnMonitor = 0;
            }

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(sc[showOnMonitor].Bounds.Left, sc[showOnMonitor].Bounds.Top);
            // If you intend the form to be maximized, change it to normal then maximized.
            this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
        }


        private void getPatient()
        {
            try
            {
                List<OPDHistoryModel> list = service.GetByStatus(OPD_STATUS.Waiting.ToString());
                dgvList.AutoGenerateColumns = false;
                dgvList.DataSource = list;
                dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvList.Refresh();
                dgvList.ClearSelection();

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Main Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void TokenList_SizeChanged(object sender, EventArgs e)
        {
            labelSize();
        }

        private void TokenList_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }
    }
}
