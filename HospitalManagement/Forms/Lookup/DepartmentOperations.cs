﻿using BL;
using Service;
using Model;

using Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagement.Forms.Lookup
{
    public partial class DepartmentOperations : Form
    {
        ILookupService service = new LookUpManager();
        Guid? currentUserId = null;
        public DepartmentOperations()
        {
            InitializeComponent();
            try
            {
                ClearAll();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Department Operations", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        public DepartmentOperations(Guid? userId)
        {
            InitializeComponent();
            try
            {
                ClearAll();
                this.currentUserId = userId;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Department Operations", ex.Message.ToString(), ex.StackTrace.ToString());
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
                        return service.Update(LookUp.Department, model);
                    else
                        return service.Create(LookUp.Department, model);
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Department Operations", ex.Message.ToString(), ex.StackTrace.ToString());
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
                model.Description = txtDescription.Text;
                return model;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Department Operations", ex.Message.ToString(), ex.StackTrace.ToString());
                return null;
            }
        }
        private void ClearAll()
        {
            try
            {
                this.currentUserId = null;
                txtName.Text = string.Empty;
                txtDescription.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Department Operations", ex.Message.ToString(), ex.StackTrace.ToString());
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
                        DepartmentList.isSubmited = true;
                        ClearAll();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Department Operations", ex.Message.ToString(), ex.StackTrace.ToString());

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearAll();
                DepartmentList.isSubmited = false;
                this.Close();
            }
            catch (Exception ex)
            {
                Utility.ErrorLog.Logging("Department Operations", ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
    }
}