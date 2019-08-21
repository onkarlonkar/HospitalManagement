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
    public partial class OPDRateOperations : Form
    {
        ILookupService service = new LookUpManager();
        Guid? currentUserId = null;
        public OPDRateOperations()
        {
            InitializeComponent();
            try
            {               
                ClearAll();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPDRate Operations", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        public OPDRateOperations(Guid? userId)
        {
            InitializeComponent();
            try
            {
                ClearAll();               
                this.currentUserId = userId;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPDRate Operations", ex.Message.ToString(), ex.StackTrace.ToString());
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
                        return service.Update(LookUp.OPDRate, model);
                    else
                        return service.Create(LookUp.OPDRate, model);
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPDRate Operations", ex.Message.ToString(), ex.StackTrace.ToString());
                return false;
            }
        }

        private LookupModel assignModel()
        {
            try
            {
                LookupModel model = new LookupModel();
                model.Id = this.currentUserId;               
                model.Name = txtName.Text;
                model.Rate = Convert.ToDecimal(txtRate.Text);               

                return model;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPDRate Operations", ex.Message.ToString(), ex.StackTrace.ToString());
                return null;
            }
        }



        private void ClearAll()
        {
            try
            {
                txtRate.Text = "0.00";
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPDRate Operations", ex.Message.ToString(), ex.StackTrace.ToString());
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
                        OPDRateList.isSubmited = true;
                        ClearAll();
                        this.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPDRate Operations", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearAll();
                OPDRateList.isSubmited = false;
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPDRate Operations", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

      

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("OPDRate Operations", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
    }
}
