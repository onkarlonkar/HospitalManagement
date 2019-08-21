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

namespace HospitalManagement.Forms.Common
{
    public partial class patientDialog : Form
    {
        IOPDHistoryService service = new OPDHistoryManager();
        public patientDialog()
        {
            InitializeComponent();
        }

        public patientDialog(P_TYPE type)
        {
            InitializeComponent();
            getPatientList(type);

        }

        private void pbClose_MouseHover(object sender, EventArgs e)
        {
            pbClose.BackColor = Color.Red;
        }

        private void pbClose_MouseLeave(object sender, EventArgs e)
        {
            pbClose.BackColor = Color.Transparent;
        }

        private void patientDialog_Load(object sender, EventArgs e)
        {

        }

        private void getPatientList(P_TYPE type)
        {
            try
            {
                List<LookupModel> list = service.getPatientByType(type);
                dgvPatientInfo.AutoGenerateColumns = false;
                dgvPatientInfo.DataSource = list;
                dgvPatientInfo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvPatientInfo.Refresh();
                dgvPatientInfo.ClearSelection();

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Main Dashboard", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {

            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Login", ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }
    }
}
