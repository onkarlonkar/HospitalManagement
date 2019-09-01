﻿namespace HospitalManagement.Forms.Common
{
    partial class patientDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.dgvPatientInfo = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CasePaper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XRAYCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 8;
            this.bunifuElipse1.TargetControl = this;
            // 
            // dgvPatientInfo
            // 
            this.dgvPatientInfo.AllowUserToAddRows = false;
            this.dgvPatientInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPatientInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPatientInfo.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPatientInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPatientInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvPatientInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatientInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPatientInfo.ColumnHeadersHeight = 25;
            this.dgvPatientInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn15,
            this.CasePaper,
            this.dataGridViewTextBoxColumn19,
            this.XRAYCount});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatientInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPatientInfo.DoubleBuffered = false;
            this.dgvPatientInfo.EnableHeadersVisualStyles = false;
            this.dgvPatientInfo.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.dgvPatientInfo.HeaderForeColor = System.Drawing.Color.White;
            this.dgvPatientInfo.Location = new System.Drawing.Point(7, 38);
            this.dgvPatientInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPatientInfo.MultiSelect = false;
            this.dgvPatientInfo.Name = "dgvPatientInfo";
            this.dgvPatientInfo.ReadOnly = true;
            this.dgvPatientInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatientInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPatientInfo.RowHeadersVisible = false;
            this.dgvPatientInfo.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvPatientInfo.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvPatientInfo.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvPatientInfo.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvPatientInfo.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPatientInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatientInfo.Size = new System.Drawing.Size(504, 300);
            this.dgvPatientInfo.TabIndex = 13;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 8;
            this.bunifuElipse2.TargetControl = this.dgvPatientInfo;
            // 
            // pbClose
            // 
            this.pbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClose.Image = global::HospitalManagement.Properties.Resources.Close_30px;
            this.pbClose.Location = new System.Drawing.Point(486, 2);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(30, 30);
            this.pbClose.TabIndex = 14;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            this.pbClose.MouseLeave += new System.EventHandler(this.pbClose_MouseLeave);
            this.pbClose.MouseHover += new System.EventHandler(this.pbClose_MouseHover);
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn15.HeaderText = "Id";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // CasePaper
            // 
            this.CasePaper.DataPropertyName = "Description";
            this.CasePaper.HeaderText = "Case #";
            this.CasePaper.Name = "CasePaper";
            this.CasePaper.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn19.HeaderText = "Name";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // XRAYCount
            // 
            this.XRAYCount.DataPropertyName = "PerentName";
            this.XRAYCount.HeaderText = "Total";
            this.XRAYCount.Name = "XRAYCount";
            this.XRAYCount.ReadOnly = true;
            // 
            // patientDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(89)))), ((int)(((byte)(149)))));
            this.ClientSize = new System.Drawing.Size(519, 343);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.dgvPatientInfo);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "patientDialog";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient List";
            this.Load += new System.EventHandler(this.patientDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvPatientInfo;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn CasePaper;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn XRAYCount;
    }
}