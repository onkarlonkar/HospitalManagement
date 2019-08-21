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
    public partial class PrintOptions : Form
    {
        public PrintOptions()
        {
            InitializeComponent();
            loadPrintOptions();
            ddlOptions.SelectedIndex = 0;

        }

        public PrintOptions(bool isShowPriscription = true)
        {
            InitializeComponent();
            loadPrintOptions(isShowPriscription);
            ddlOptions.SelectedIndex = 0;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                OPDHistory.isPrint = false;
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Print Option", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlOptions.SelectedIndex == 0)
                {
                    MessageBox.Show(ErrorMessages.selectPrintOption, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    OPDHistory.isPrint = true;
                    OPDHistory.printOption = ddlOptions.SelectedValue.ToString();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Print Option", ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void loadPrintOptions(bool isShowPriscription = true)
        {
            try
            {
                Dictionary<string, string> options = new Dictionary<string, string>();
                options.Add("select", "-- Select Option --");
                options.Add("Bill", "Bill");
                if (isShowPriscription)
                {
                    options.Add("Prescription", "Prescription");
                    options.Add("Both", "Bill & Prescription");
                }

                ddlOptions.DataSource = new BindingSource(options, null); ;
                ddlOptions.DisplayMember = "Value";
                ddlOptions.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Print Option", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
    }
}
