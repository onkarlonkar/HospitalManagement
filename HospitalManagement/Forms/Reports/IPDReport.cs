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

namespace HospitalManagement.Forms.Reports
{
    public partial class IPDReport : Form
    {


        IReportingService service = new ReportingManager();        
        public static bool isSubmited = false;
        public IPDReport()
        {
            InitializeComponent();           
            Search();
            txtSearch.Focus();

        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search...";
                txtSearch.ForeColor = Color.FromArgb(0, 64, 64);
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.FromArgb(0, 64, 64);
            }
        }



        private void Search()
        {
            try
            {
                OPDFilterSearchModel model = getSearchModel();
                if (model != null)
                {
                    List<PatientDetailModel> list = service.GetIPDReport(model);
                    dgvList.AutoGenerateColumns = false;
                    dgvList.DataSource = list;
                    //dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    dgvList.Refresh();

                }

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Report List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

       

        private OPDFilterSearchModel getSearchModel()
        {
            OPDFilterSearchModel model = new OPDFilterSearchModel();         
            if (!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text != "Search...")
            {
                model.searchText = txtSearch.Text;
            } 
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageBox.Show(ErrorMessages.FromDateToDate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                model.from = Convert.ToDateTime(dtpFrom.Value.ToShortDateString());
                model.to = Convert.ToDateTime(dtpTo.Value.AddDays(1).ToShortDateString());
            }

            return model;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                OPDFilterSearchModel model = getSearchModel();
                if (model != null)
                {
                    string path = service.DownloadIPDReport(model);
                    MessageBox.Show(Messages.reportCompleted + path, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Report List", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
      
    }
}
