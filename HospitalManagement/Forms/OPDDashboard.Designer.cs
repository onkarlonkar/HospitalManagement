namespace HospitalManagement.Forms
{
    partial class OPDDashboard
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitleDues = new System.Windows.Forms.Label();
            this.lblTitleTotal = new System.Windows.Forms.Label();
            this.lblTitlePaid = new System.Windows.Forms.Label();
            this.lblTitleXRAY = new System.Windows.Forms.Label();
            this.lblTitleECG = new System.Windows.Forms.Label();
            this.lblTitleLab = new System.Windows.Forms.Label();
            this.lblTitleOPD = new System.Windows.Forms.Label();
            this.lblMadam = new System.Windows.Forms.Label();
            this.Sir = new System.Windows.Forms.Label();
            this.lblTitleDone = new System.Windows.Forms.Label();
            this.lblTitleWating = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlContainerLeft = new System.Windows.Forms.Panel();
            this.tblContainerLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tblpnlContainerLeftR1 = new System.Windows.Forms.Panel();
            this.dgvInCabin = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CasePaperNumberW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PCDueAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblpnlContainerLeftR2 = new System.Windows.Forms.Panel();
            this.tblpnlContainerLeftR3 = new System.Windows.Forms.Panel();
            this.pnlContainerRight = new System.Windows.Forms.Panel();
            this.tblContainerRight = new System.Windows.Forms.TableLayoutPanel();
            this.tblpnlContainerRightR1 = new System.Windows.Forms.Panel();
            this.btnTokenPageRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlNextPatients = new System.Windows.Forms.ComboBox();
            this.lblPNo = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tblpnlContainerRightR2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvWaiting = new System.Windows.Forms.DataGridView();
            this.OPDId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CasePaperNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LabTestingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LabFree = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Free = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DueAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTPLabCollection = new HospitalManagement.RoundedButton();
            this.lblDuesCollection = new HospitalManagement.RoundedButton();
            this.lblTotalCollection = new HospitalManagement.RoundedButton();
            this.lblReceivedCollection = new HospitalManagement.RoundedButton();
            this.lblXRAY = new HospitalManagement.RoundedButton();
            this.lblECG = new HospitalManagement.RoundedButton();
            this.lblLabCollection = new HospitalManagement.RoundedButton();
            this.lblOPDCollection = new HospitalManagement.RoundedButton();
            this.lblMadamPatient = new HospitalManagement.RoundedButton();
            this.lblSIRPatient = new HospitalManagement.RoundedButton();
            this.lblDonePatient = new HospitalManagement.RoundedButton();
            this.lblWaitingPatient = new HospitalManagement.RoundedButton();
            this.lbl5 = new HospitalManagement.RoundedButton();
            this.lbl4 = new HospitalManagement.RoundedButton();
            this.lbl6 = new HospitalManagement.RoundedButton();
            this.lbl3 = new HospitalManagement.RoundedButton();
            this.lbl2 = new HospitalManagement.RoundedButton();
            this.lbl1 = new HospitalManagement.RoundedButton();
            this.pnlMain.SuspendLayout();
            this.tblMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlContainerLeft.SuspendLayout();
            this.tblContainerLeft.SuspendLayout();
            this.tblpnlContainerLeftR1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInCabin)).BeginInit();
            this.tblpnlContainerLeftR2.SuspendLayout();
            this.pnlContainerRight.SuspendLayout();
            this.tblContainerRight.SuspendLayout();
            this.tblpnlContainerRightR1.SuspendLayout();
            this.tblpnlContainerRightR2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaiting)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tblMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1004, 749);
            this.pnlMain.TabIndex = 0;
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.pnlHeader, 0, 0);
            this.tblMain.Controls.Add(this.pnlContainer, 0, 1);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 2;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82F));
            this.tblMain.Size = new System.Drawing.Size(1004, 749);
            this.tblMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(128)))), ((int)(((byte)(117)))));
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.lblTPLabCollection);
            this.pnlHeader.Controls.Add(this.lblTitleDues);
            this.pnlHeader.Controls.Add(this.lblTitleTotal);
            this.pnlHeader.Controls.Add(this.lblTitlePaid);
            this.pnlHeader.Controls.Add(this.lblTitleXRAY);
            this.pnlHeader.Controls.Add(this.lblTitleECG);
            this.pnlHeader.Controls.Add(this.lblTitleLab);
            this.pnlHeader.Controls.Add(this.lblTitleOPD);
            this.pnlHeader.Controls.Add(this.lblMadam);
            this.pnlHeader.Controls.Add(this.Sir);
            this.pnlHeader.Controls.Add(this.lblTitleDone);
            this.pnlHeader.Controls.Add(this.lblTitleWating);
            this.pnlHeader.Controls.Add(this.lblDuesCollection);
            this.pnlHeader.Controls.Add(this.lblTotalCollection);
            this.pnlHeader.Controls.Add(this.lblReceivedCollection);
            this.pnlHeader.Controls.Add(this.lblXRAY);
            this.pnlHeader.Controls.Add(this.lblECG);
            this.pnlHeader.Controls.Add(this.lblLabCollection);
            this.pnlHeader.Controls.Add(this.lblOPDCollection);
            this.pnlHeader.Controls.Add(this.lblMadamPatient);
            this.pnlHeader.Controls.Add(this.lblSIRPatient);
            this.pnlHeader.Controls.Add(this.lblDonePatient);
            this.pnlHeader.Controls.Add(this.lblWaitingPatient);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(998, 128);
            this.pnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(446, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 66;
            this.label1.Text = "TP Lab";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitleDues
            // 
            this.lblTitleDues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleDues.AutoSize = true;
            this.lblTitleDues.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleDues.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleDues.ForeColor = System.Drawing.Color.White;
            this.lblTitleDues.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitleDues.Location = new System.Drawing.Point(35, 93);
            this.lblTitleDues.Name = "lblTitleDues";
            this.lblTitleDues.Size = new System.Drawing.Size(38, 18);
            this.lblTitleDues.TabIndex = 64;
            this.lblTitleDues.Text = "DUES";
            this.lblTitleDues.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitleTotal
            // 
            this.lblTitleTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleTotal.AutoSize = true;
            this.lblTitleTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleTotal.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleTotal.ForeColor = System.Drawing.Color.White;
            this.lblTitleTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitleTotal.Location = new System.Drawing.Point(118, 93);
            this.lblTitleTotal.Name = "lblTitleTotal";
            this.lblTitleTotal.Size = new System.Drawing.Size(42, 18);
            this.lblTitleTotal.TabIndex = 63;
            this.lblTitleTotal.Text = "TOTAL";
            this.lblTitleTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitlePaid
            // 
            this.lblTitlePaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitlePaid.AutoSize = true;
            this.lblTitlePaid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitlePaid.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlePaid.ForeColor = System.Drawing.Color.White;
            this.lblTitlePaid.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitlePaid.Location = new System.Drawing.Point(204, 93);
            this.lblTitlePaid.Name = "lblTitlePaid";
            this.lblTitlePaid.Size = new System.Drawing.Size(35, 18);
            this.lblTitlePaid.TabIndex = 62;
            this.lblTitlePaid.Text = "PAID";
            this.lblTitlePaid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitleXRAY
            // 
            this.lblTitleXRAY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleXRAY.AutoSize = true;
            this.lblTitleXRAY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleXRAY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitleXRAY.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleXRAY.ForeColor = System.Drawing.Color.White;
            this.lblTitleXRAY.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitleXRAY.Location = new System.Drawing.Point(283, 93);
            this.lblTitleXRAY.Name = "lblTitleXRAY";
            this.lblTitleXRAY.Size = new System.Drawing.Size(42, 18);
            this.lblTitleXRAY.TabIndex = 61;
            this.lblTitleXRAY.Text = "X-RAY";
            this.lblTitleXRAY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitleXRAY.DoubleClick += new System.EventHandler(this.lblTitleXRAY_DoubleClick);
            // 
            // lblTitleECG
            // 
            this.lblTitleECG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleECG.AutoSize = true;
            this.lblTitleECG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleECG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitleECG.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleECG.ForeColor = System.Drawing.Color.White;
            this.lblTitleECG.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitleECG.Location = new System.Drawing.Point(370, 93);
            this.lblTitleECG.Name = "lblTitleECG";
            this.lblTitleECG.Size = new System.Drawing.Size(35, 18);
            this.lblTitleECG.TabIndex = 60;
            this.lblTitleECG.Text = "ECG";
            this.lblTitleECG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitleECG.DoubleClick += new System.EventHandler(this.lblTitleECG_DoubleClick);
            // 
            // lblTitleLab
            // 
            this.lblTitleLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleLab.AutoSize = true;
            this.lblTitleLab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleLab.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleLab.ForeColor = System.Drawing.Color.White;
            this.lblTitleLab.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitleLab.Location = new System.Drawing.Point(536, 93);
            this.lblTitleLab.Name = "lblTitleLab";
            this.lblTitleLab.Size = new System.Drawing.Size(28, 18);
            this.lblTitleLab.TabIndex = 59;
            this.lblTitleLab.Text = "LAB";
            this.lblTitleLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleOPD
            // 
            this.lblTitleOPD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleOPD.AutoSize = true;
            this.lblTitleOPD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleOPD.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleOPD.ForeColor = System.Drawing.Color.White;
            this.lblTitleOPD.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitleOPD.Location = new System.Drawing.Point(612, 93);
            this.lblTitleOPD.Name = "lblTitleOPD";
            this.lblTitleOPD.Size = new System.Drawing.Size(35, 18);
            this.lblTitleOPD.TabIndex = 58;
            this.lblTitleOPD.Text = "OPD";
            this.lblTitleOPD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMadam
            // 
            this.lblMadam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMadam.AutoSize = true;
            this.lblMadam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMadam.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMadam.ForeColor = System.Drawing.Color.White;
            this.lblMadam.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMadam.Location = new System.Drawing.Point(687, 93);
            this.lblMadam.Name = "lblMadam";
            this.lblMadam.Size = new System.Drawing.Size(54, 18);
            this.lblMadam.TabIndex = 57;
            this.lblMadam.Text = "MADAM";
            this.lblMadam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Sir
            // 
            this.Sir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Sir.AutoSize = true;
            this.Sir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Sir.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sir.ForeColor = System.Drawing.Color.White;
            this.Sir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Sir.Location = new System.Drawing.Point(782, 93);
            this.Sir.Name = "Sir";
            this.Sir.Size = new System.Drawing.Size(26, 18);
            this.Sir.TabIndex = 56;
            this.Sir.Text = "SIR";
            this.Sir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitleDone
            // 
            this.lblTitleDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleDone.AutoSize = true;
            this.lblTitleDone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleDone.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleDone.ForeColor = System.Drawing.Color.White;
            this.lblTitleDone.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitleDone.Location = new System.Drawing.Point(856, 93);
            this.lblTitleDone.Name = "lblTitleDone";
            this.lblTitleDone.Size = new System.Drawing.Size(39, 18);
            this.lblTitleDone.TabIndex = 55;
            this.lblTitleDone.Text = "Done";
            this.lblTitleDone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitleWating
            // 
            this.lblTitleWating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleWating.AutoSize = true;
            this.lblTitleWating.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleWating.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleWating.ForeColor = System.Drawing.Color.White;
            this.lblTitleWating.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitleWating.Location = new System.Drawing.Point(928, 93);
            this.lblTitleWating.Name = "lblTitleWating";
            this.lblTitleWating.Size = new System.Drawing.Size(51, 18);
            this.lblTitleWating.TabIndex = 54;
            this.lblTitleWating.Text = "Waiting";
            this.lblTitleWating.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.tableLayoutPanel1);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(3, 137);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(998, 609);
            this.pnlContainer.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.pnlContainerLeft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlContainerRight, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(998, 609);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlContainerLeft
            // 
            this.pnlContainerLeft.Controls.Add(this.tblContainerLeft);
            this.pnlContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainerLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlContainerLeft.Name = "pnlContainerLeft";
            this.pnlContainerLeft.Size = new System.Drawing.Size(293, 603);
            this.pnlContainerLeft.TabIndex = 0;
            // 
            // tblContainerLeft
            // 
            this.tblContainerLeft.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblContainerLeft.ColumnCount = 1;
            this.tblContainerLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblContainerLeft.Controls.Add(this.tblpnlContainerLeftR1, 0, 0);
            this.tblContainerLeft.Controls.Add(this.tblpnlContainerLeftR2, 0, 1);
            this.tblContainerLeft.Controls.Add(this.tblpnlContainerLeftR3, 0, 2);
            this.tblContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.tblContainerLeft.Name = "tblContainerLeft";
            this.tblContainerLeft.RowCount = 3;
            this.tblContainerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblContainerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblContainerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblContainerLeft.Size = new System.Drawing.Size(293, 603);
            this.tblContainerLeft.TabIndex = 0;
            // 
            // tblpnlContainerLeftR1
            // 
            this.tblpnlContainerLeftR1.Controls.Add(this.dgvInCabin);
            this.tblpnlContainerLeftR1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpnlContainerLeftR1.Location = new System.Drawing.Point(4, 4);
            this.tblpnlContainerLeftR1.Name = "tblpnlContainerLeftR1";
            this.tblpnlContainerLeftR1.Size = new System.Drawing.Size(285, 293);
            this.tblpnlContainerLeftR1.TabIndex = 0;
            // 
            // dgvInCabin
            // 
            this.dgvInCabin.AllowUserToDeleteRows = false;
            this.dgvInCabin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInCabin.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInCabin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.dgvInCabin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInCabin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInCabin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.CasePaperNumberW,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.PCDueAmount});
            this.dgvInCabin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInCabin.Location = new System.Drawing.Point(0, 0);
            this.dgvInCabin.MultiSelect = false;
            this.dgvInCabin.Name = "dgvInCabin";
            this.dgvInCabin.ReadOnly = true;
            this.dgvInCabin.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInCabin.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInCabin.RowHeadersVisible = false;
            this.dgvInCabin.RowHeadersWidth = 20;
            this.dgvInCabin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInCabin.Size = new System.Drawing.Size(285, 293);
            this.dgvInCabin.TabIndex = 3;
            this.dgvInCabin.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInCabin_CellDoubleClick);
            this.dgvInCabin.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvInCabin_CellFormatting);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PatientId";
            this.dataGridViewTextBoxColumn1.HeaderText = "PatientId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Sequence";
            this.dataGridViewTextBoxColumn2.FillWeight = 76.14214F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Sr #";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // CasePaperNumberW
            // 
            this.CasePaperNumberW.DataPropertyName = "CasePaperNumber";
            this.CasePaperNumberW.FillWeight = 105.9645F;
            this.CasePaperNumberW.HeaderText = "CasePaper #";
            this.CasePaperNumberW.Name = "CasePaperNumberW";
            this.CasePaperNumberW.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PatientName";
            this.dataGridViewTextBoxColumn3.FillWeight = 105.9645F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "InTime";
            this.dataGridViewTextBoxColumn4.HeaderText = "InTime";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "StatusName";
            this.dataGridViewTextBoxColumn5.FillWeight = 105.9645F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Status";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "OutTime";
            this.dataGridViewTextBoxColumn6.HeaderText = "OutTime";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "StatusId";
            this.dataGridViewTextBoxColumn7.HeaderText = "StatusId";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn8.HeaderText = "OPD";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "LabTestingAmount";
            this.dataGridViewTextBoxColumn9.HeaderText = "Lab";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TotalAmount";
            this.dataGridViewTextBoxColumn10.HeaderText = "Total";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ReceivedByName";
            this.dataGridViewTextBoxColumn11.HeaderText = "ReceivedBy";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsLabCharity";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Lab Free";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "IsCharity";
            this.dataGridViewCheckBoxColumn2.FillWeight = 105.9645F;
            this.dataGridViewCheckBoxColumn2.HeaderText = "Free";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Visible = false;
            // 
            // PCDueAmount
            // 
            this.PCDueAmount.DataPropertyName = "DueAmount";
            this.PCDueAmount.HeaderText = "DueAmount";
            this.PCDueAmount.Name = "PCDueAmount";
            this.PCDueAmount.ReadOnly = true;
            this.PCDueAmount.Visible = false;
            // 
            // tblpnlContainerLeftR2
            // 
            this.tblpnlContainerLeftR2.Controls.Add(this.tableLayoutPanel2);
            this.tblpnlContainerLeftR2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpnlContainerLeftR2.Location = new System.Drawing.Point(4, 304);
            this.tblpnlContainerLeftR2.Name = "tblpnlContainerLeftR2";
            this.tblpnlContainerLeftR2.Size = new System.Drawing.Size(285, 173);
            this.tblpnlContainerLeftR2.TabIndex = 1;
            // 
            // tblpnlContainerLeftR3
            // 
            this.tblpnlContainerLeftR3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.tblpnlContainerLeftR3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpnlContainerLeftR3.Location = new System.Drawing.Point(4, 484);
            this.tblpnlContainerLeftR3.Name = "tblpnlContainerLeftR3";
            this.tblpnlContainerLeftR3.Size = new System.Drawing.Size(285, 115);
            this.tblpnlContainerLeftR3.TabIndex = 2;
            // 
            // pnlContainerRight
            // 
            this.pnlContainerRight.Controls.Add(this.tblContainerRight);
            this.pnlContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainerRight.Location = new System.Drawing.Point(302, 3);
            this.pnlContainerRight.Name = "pnlContainerRight";
            this.pnlContainerRight.Size = new System.Drawing.Size(693, 603);
            this.pnlContainerRight.TabIndex = 1;
            // 
            // tblContainerRight
            // 
            this.tblContainerRight.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblContainerRight.ColumnCount = 1;
            this.tblContainerRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblContainerRight.Controls.Add(this.tblpnlContainerRightR1, 0, 0);
            this.tblContainerRight.Controls.Add(this.tblpnlContainerRightR2, 0, 1);
            this.tblContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblContainerRight.Location = new System.Drawing.Point(0, 0);
            this.tblContainerRight.Name = "tblContainerRight";
            this.tblContainerRight.RowCount = 2;
            this.tblContainerRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tblContainerRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tblContainerRight.Size = new System.Drawing.Size(693, 603);
            this.tblContainerRight.TabIndex = 0;
            // 
            // tblpnlContainerRightR1
            // 
            this.tblpnlContainerRightR1.Controls.Add(this.btnTokenPageRefresh);
            this.tblpnlContainerRightR1.Controls.Add(this.label2);
            this.tblpnlContainerRightR1.Controls.Add(this.ddlNextPatients);
            this.tblpnlContainerRightR1.Controls.Add(this.lblPNo);
            this.tblpnlContainerRightR1.Controls.Add(this.txtSearch);
            this.tblpnlContainerRightR1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpnlContainerRightR1.Location = new System.Drawing.Point(4, 4);
            this.tblpnlContainerRightR1.Name = "tblpnlContainerRightR1";
            this.tblpnlContainerRightR1.Size = new System.Drawing.Size(685, 36);
            this.tblpnlContainerRightR1.TabIndex = 0;
            // 
            // btnTokenPageRefresh
            // 
            this.btnTokenPageRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTokenPageRefresh.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTokenPageRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnTokenPageRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTokenPageRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTokenPageRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTokenPageRefresh.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTokenPageRefresh.ForeColor = System.Drawing.Color.Transparent;
            this.btnTokenPageRefresh.Image = global::HospitalManagement.Properties.Resources.Refresh_16px;
            this.btnTokenPageRefresh.Location = new System.Drawing.Point(654, 4);
            this.btnTokenPageRefresh.Name = "btnTokenPageRefresh";
            this.btnTokenPageRefresh.Size = new System.Drawing.Size(27, 26);
            this.btnTokenPageRefresh.TabIndex = 61;
            this.btnTokenPageRefresh.UseVisualStyleBackColor = false;
            this.btnTokenPageRefresh.Click += new System.EventHandler(this.btnTokenPageRefresh_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "patients";
            // 
            // ddlNextPatients
            // 
            this.ddlNextPatients.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlNextPatients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlNextPatients.FormattingEnabled = true;
            this.ddlNextPatients.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.ddlNextPatients.Location = new System.Drawing.Point(542, 6);
            this.ddlNextPatients.Name = "ddlNextPatients";
            this.ddlNextPatients.Size = new System.Drawing.Size(48, 25);
            this.ddlNextPatients.TabIndex = 5;
            this.ddlNextPatients.SelectedIndexChanged += new System.EventHandler(this.ddlNextPatients_SelectedIndexChanged);
            // 
            // lblPNo
            // 
            this.lblPNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPNo.AutoSize = true;
            this.lblPNo.Location = new System.Drawing.Point(502, 9);
            this.lblPNo.Name = "lblPNo";
            this.lblPNo.Size = new System.Drawing.Size(37, 17);
            this.lblPNo.TabIndex = 4;
            this.lblPNo.Text = "Next";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(6, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(437, 19);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.Text = "Search...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // tblpnlContainerRightR2
            // 
            this.tblpnlContainerRightR2.Controls.Add(this.groupBox1);
            this.tblpnlContainerRightR2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpnlContainerRightR2.Location = new System.Drawing.Point(4, 47);
            this.tblpnlContainerRightR2.Name = "tblpnlContainerRightR2";
            this.tblpnlContainerRightR2.Size = new System.Drawing.Size(685, 552);
            this.tblpnlContainerRightR2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvWaiting);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 552);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Waiting/Done";
            // 
            // dgvWaiting
            // 
            this.dgvWaiting.AllowUserToDeleteRows = false;
            this.dgvWaiting.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWaiting.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvWaiting.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.dgvWaiting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWaiting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWaiting.ColumnHeadersHeight = 30;
            this.dgvWaiting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OPDId,
            this.PatientId,
            this.Sequence,
            this.CasePaperNumber,
            this.PatientName,
            this.InTime,
            this.Status,
            this.OutTime,
            this.StatusId,
            this.Amount,
            this.LabTestingAmount,
            this.TotalAmount,
            this.ReceivedBy,
            this.LabFree,
            this.Free,
            this.DueAmount});
            this.dgvWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWaiting.Location = new System.Drawing.Point(3, 19);
            this.dgvWaiting.MultiSelect = false;
            this.dgvWaiting.Name = "dgvWaiting";
            this.dgvWaiting.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWaiting.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvWaiting.RowHeadersVisible = false;
            this.dgvWaiting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWaiting.Size = new System.Drawing.Size(679, 530);
            this.dgvWaiting.TabIndex = 3;
            this.dgvWaiting.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWaiting_CellDoubleClick);
            this.dgvWaiting.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvWaiting_CellFormatting);
            // 
            // OPDId
            // 
            this.OPDId.DataPropertyName = "Id";
            this.OPDId.HeaderText = "Id";
            this.OPDId.Name = "OPDId";
            this.OPDId.ReadOnly = true;
            this.OPDId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OPDId.Visible = false;
            // 
            // PatientId
            // 
            this.PatientId.DataPropertyName = "PatientId";
            this.PatientId.HeaderText = "PatientId";
            this.PatientId.Name = "PatientId";
            this.PatientId.ReadOnly = true;
            this.PatientId.Visible = false;
            // 
            // Sequence
            // 
            this.Sequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Sequence.DataPropertyName = "Sequence";
            this.Sequence.FillWeight = 117.7665F;
            this.Sequence.HeaderText = "Sr #";
            this.Sequence.Name = "Sequence";
            this.Sequence.ReadOnly = true;
            this.Sequence.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sequence.Width = 40;
            // 
            // CasePaperNumber
            // 
            this.CasePaperNumber.DataPropertyName = "CasePaperNumber";
            this.CasePaperNumber.FillWeight = 97.46193F;
            this.CasePaperNumber.HeaderText = "CasePaper #";
            this.CasePaperNumber.Name = "CasePaperNumber";
            this.CasePaperNumber.ReadOnly = true;
            // 
            // PatientName
            // 
            this.PatientName.DataPropertyName = "PatientName";
            this.PatientName.FillWeight = 97.46193F;
            this.PatientName.HeaderText = "Name";
            this.PatientName.Name = "PatientName";
            this.PatientName.ReadOnly = true;
            // 
            // InTime
            // 
            this.InTime.DataPropertyName = "InTime";
            this.InTime.HeaderText = "InTime";
            this.InTime.Name = "InTime";
            this.InTime.ReadOnly = true;
            this.InTime.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "StatusName";
            this.Status.FillWeight = 97.46193F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // OutTime
            // 
            this.OutTime.DataPropertyName = "OutTime";
            this.OutTime.HeaderText = "OutTime";
            this.OutTime.Name = "OutTime";
            this.OutTime.ReadOnly = true;
            this.OutTime.Visible = false;
            // 
            // StatusId
            // 
            this.StatusId.DataPropertyName = "StatusId";
            this.StatusId.HeaderText = "StatusId";
            this.StatusId.Name = "StatusId";
            this.StatusId.ReadOnly = true;
            this.StatusId.Visible = false;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.FillWeight = 97.46193F;
            this.Amount.HeaderText = "OPD";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // LabTestingAmount
            // 
            this.LabTestingAmount.DataPropertyName = "LabTestingAmount";
            this.LabTestingAmount.FillWeight = 97.46193F;
            this.LabTestingAmount.HeaderText = "Lab";
            this.LabTestingAmount.Name = "LabTestingAmount";
            this.LabTestingAmount.ReadOnly = true;
            // 
            // TotalAmount
            // 
            this.TotalAmount.DataPropertyName = "TotalAmount";
            this.TotalAmount.FillWeight = 97.46193F;
            this.TotalAmount.HeaderText = "Total";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            // 
            // ReceivedBy
            // 
            this.ReceivedBy.DataPropertyName = "ReceivedByName";
            this.ReceivedBy.HeaderText = "ReceivedBy";
            this.ReceivedBy.Name = "ReceivedBy";
            this.ReceivedBy.ReadOnly = true;
            this.ReceivedBy.Visible = false;
            // 
            // LabFree
            // 
            this.LabFree.DataPropertyName = "IsLabCharity";
            this.LabFree.HeaderText = "Lab Free";
            this.LabFree.Name = "LabFree";
            this.LabFree.ReadOnly = true;
            this.LabFree.Visible = false;
            // 
            // Free
            // 
            this.Free.DataPropertyName = "IsCharity";
            this.Free.FillWeight = 97.46193F;
            this.Free.HeaderText = "Free";
            this.Free.Name = "Free";
            this.Free.ReadOnly = true;
            // 
            // DueAmount
            // 
            this.DueAmount.DataPropertyName = "DueAmount";
            this.DueAmount.HeaderText = "DueAmount";
            this.DueAmount.Name = "DueAmount";
            this.DueAmount.ReadOnly = true;
            this.DueAmount.Visible = false;
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Interval = 300000;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(285, 173);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 28);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.panel2.Controls.Add(this.lbl5);
            this.panel2.Controls.Add(this.lbl4);
            this.panel2.Controls.Add(this.lbl6);
            this.panel2.Controls.Add(this.lbl3);
            this.panel2.Controls.Add(this.lbl2);
            this.panel2.Controls.Add(this.lbl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(277, 130);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Current Displayed  Number";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTPLabCollection
            // 
            this.lblTPLabCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTPLabCollection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(147)))), ((int)(((byte)(173)))));
            this.lblTPLabCollection.BorderColor = System.Drawing.Color.White;
            this.lblTPLabCollection.BorderDownColor = System.Drawing.Color.Empty;
            this.lblTPLabCollection.BorderDownWidth = 0F;
            this.lblTPLabCollection.BorderOverColor = System.Drawing.Color.Empty;
            this.lblTPLabCollection.BorderOverWidth = 0F;
            this.lblTPLabCollection.BorderRadius = 100;
            this.lblTPLabCollection.BorderWidth = 1.75F;
            this.lblTPLabCollection.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTPLabCollection.ForeColor = System.Drawing.Color.White;
            this.lblTPLabCollection.Location = new System.Drawing.Point(428, 11);
            this.lblTPLabCollection.Margin = new System.Windows.Forms.Padding(0);
            this.lblTPLabCollection.Name = "lblTPLabCollection";
            this.lblTPLabCollection.Size = new System.Drawing.Size(77, 79);
            this.lblTPLabCollection.TabIndex = 65;
            this.lblTPLabCollection.Text = "999";
            this.toolTip1.SetToolTip(this.lblTPLabCollection, "ECG Collection");
            this.lblTPLabCollection.UseVisualStyleBackColor = false;
            // 
            // lblDuesCollection
            // 
            this.lblDuesCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDuesCollection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(78)))), ((int)(((byte)(65)))));
            this.lblDuesCollection.BorderColor = System.Drawing.Color.White;
            this.lblDuesCollection.BorderDownColor = System.Drawing.Color.Empty;
            this.lblDuesCollection.BorderDownWidth = 0F;
            this.lblDuesCollection.BorderOverColor = System.Drawing.Color.Empty;
            this.lblDuesCollection.BorderOverWidth = 0F;
            this.lblDuesCollection.BorderRadius = 100;
            this.lblDuesCollection.BorderWidth = 1.75F;
            this.lblDuesCollection.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuesCollection.ForeColor = System.Drawing.Color.White;
            this.lblDuesCollection.Location = new System.Drawing.Point(15, 11);
            this.lblDuesCollection.Margin = new System.Windows.Forms.Padding(0);
            this.lblDuesCollection.Name = "lblDuesCollection";
            this.lblDuesCollection.Size = new System.Drawing.Size(77, 79);
            this.lblDuesCollection.TabIndex = 53;
            this.lblDuesCollection.Text = "999";
            this.toolTip1.SetToolTip(this.lblDuesCollection, "DUES Collection");
            this.lblDuesCollection.UseVisualStyleBackColor = false;
            // 
            // lblTotalCollection
            // 
            this.lblTotalCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCollection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTotalCollection.BorderColor = System.Drawing.Color.White;
            this.lblTotalCollection.BorderDownColor = System.Drawing.Color.Empty;
            this.lblTotalCollection.BorderDownWidth = 0F;
            this.lblTotalCollection.BorderOverColor = System.Drawing.Color.Empty;
            this.lblTotalCollection.BorderOverWidth = 0F;
            this.lblTotalCollection.BorderRadius = 100;
            this.lblTotalCollection.BorderWidth = 1.75F;
            this.lblTotalCollection.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCollection.ForeColor = System.Drawing.Color.White;
            this.lblTotalCollection.Location = new System.Drawing.Point(98, 11);
            this.lblTotalCollection.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalCollection.Name = "lblTotalCollection";
            this.lblTotalCollection.Size = new System.Drawing.Size(77, 79);
            this.lblTotalCollection.TabIndex = 52;
            this.lblTotalCollection.Text = "999";
            this.toolTip1.SetToolTip(this.lblTotalCollection, "TOTAL Collection");
            this.lblTotalCollection.UseVisualStyleBackColor = false;
            // 
            // lblReceivedCollection
            // 
            this.lblReceivedCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReceivedCollection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(210)))), ((int)(((byte)(97)))));
            this.lblReceivedCollection.BorderColor = System.Drawing.Color.White;
            this.lblReceivedCollection.BorderDownColor = System.Drawing.Color.Empty;
            this.lblReceivedCollection.BorderDownWidth = 0F;
            this.lblReceivedCollection.BorderOverColor = System.Drawing.Color.Empty;
            this.lblReceivedCollection.BorderOverWidth = 0F;
            this.lblReceivedCollection.BorderRadius = 100;
            this.lblReceivedCollection.BorderWidth = 1.75F;
            this.lblReceivedCollection.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceivedCollection.ForeColor = System.Drawing.Color.White;
            this.lblReceivedCollection.Location = new System.Drawing.Point(181, 11);
            this.lblReceivedCollection.Margin = new System.Windows.Forms.Padding(0);
            this.lblReceivedCollection.Name = "lblReceivedCollection";
            this.lblReceivedCollection.Size = new System.Drawing.Size(77, 79);
            this.lblReceivedCollection.TabIndex = 51;
            this.lblReceivedCollection.Text = "99999.00";
            this.toolTip1.SetToolTip(this.lblReceivedCollection, "PAID Collection");
            this.lblReceivedCollection.UseVisualStyleBackColor = false;
            // 
            // lblXRAY
            // 
            this.lblXRAY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblXRAY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(224)))), ((int)(((byte)(170)))));
            this.lblXRAY.BorderColor = System.Drawing.Color.White;
            this.lblXRAY.BorderDownColor = System.Drawing.Color.Empty;
            this.lblXRAY.BorderDownWidth = 0F;
            this.lblXRAY.BorderOverColor = System.Drawing.Color.Empty;
            this.lblXRAY.BorderOverWidth = 0F;
            this.lblXRAY.BorderRadius = 100;
            this.lblXRAY.BorderWidth = 1.75F;
            this.lblXRAY.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXRAY.ForeColor = System.Drawing.Color.White;
            this.lblXRAY.Location = new System.Drawing.Point(264, 11);
            this.lblXRAY.Margin = new System.Windows.Forms.Padding(0);
            this.lblXRAY.Name = "lblXRAY";
            this.lblXRAY.Size = new System.Drawing.Size(77, 79);
            this.lblXRAY.TabIndex = 50;
            this.lblXRAY.Text = "999";
            this.toolTip1.SetToolTip(this.lblXRAY, "X-RAY Collection");
            this.lblXRAY.UseVisualStyleBackColor = false;
            // 
            // lblECG
            // 
            this.lblECG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblECG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(66)))));
            this.lblECG.BorderColor = System.Drawing.Color.White;
            this.lblECG.BorderDownColor = System.Drawing.Color.Empty;
            this.lblECG.BorderDownWidth = 0F;
            this.lblECG.BorderOverColor = System.Drawing.Color.Empty;
            this.lblECG.BorderOverWidth = 0F;
            this.lblECG.BorderRadius = 100;
            this.lblECG.BorderWidth = 1.75F;
            this.lblECG.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblECG.ForeColor = System.Drawing.Color.White;
            this.lblECG.Location = new System.Drawing.Point(347, 11);
            this.lblECG.Margin = new System.Windows.Forms.Padding(0);
            this.lblECG.Name = "lblECG";
            this.lblECG.Size = new System.Drawing.Size(77, 79);
            this.lblECG.TabIndex = 49;
            this.lblECG.Text = "999";
            this.toolTip1.SetToolTip(this.lblECG, "ECG Collection");
            this.lblECG.UseVisualStyleBackColor = false;
            // 
            // lblLabCollection
            // 
            this.lblLabCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLabCollection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(147)))), ((int)(((byte)(173)))));
            this.lblLabCollection.BorderColor = System.Drawing.Color.White;
            this.lblLabCollection.BorderDownColor = System.Drawing.Color.Empty;
            this.lblLabCollection.BorderDownWidth = 0F;
            this.lblLabCollection.BorderOverColor = System.Drawing.Color.Empty;
            this.lblLabCollection.BorderOverWidth = 0F;
            this.lblLabCollection.BorderRadius = 100;
            this.lblLabCollection.BorderWidth = 1.75F;
            this.lblLabCollection.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabCollection.ForeColor = System.Drawing.Color.White;
            this.lblLabCollection.Location = new System.Drawing.Point(509, 11);
            this.lblLabCollection.Margin = new System.Windows.Forms.Padding(0);
            this.lblLabCollection.Name = "lblLabCollection";
            this.lblLabCollection.Size = new System.Drawing.Size(77, 79);
            this.lblLabCollection.TabIndex = 48;
            this.lblLabCollection.Text = "999";
            this.toolTip1.SetToolTip(this.lblLabCollection, "LAB Collection");
            this.lblLabCollection.UseVisualStyleBackColor = false;
            // 
            // lblOPDCollection
            // 
            this.lblOPDCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOPDCollection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(33)))), ((int)(((byte)(122)))));
            this.lblOPDCollection.BorderColor = System.Drawing.Color.White;
            this.lblOPDCollection.BorderDownColor = System.Drawing.Color.Empty;
            this.lblOPDCollection.BorderDownWidth = 0F;
            this.lblOPDCollection.BorderOverColor = System.Drawing.Color.Empty;
            this.lblOPDCollection.BorderOverWidth = 0F;
            this.lblOPDCollection.BorderRadius = 100;
            this.lblOPDCollection.BorderWidth = 1.75F;
            this.lblOPDCollection.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOPDCollection.ForeColor = System.Drawing.Color.White;
            this.lblOPDCollection.Location = new System.Drawing.Point(590, 11);
            this.lblOPDCollection.Margin = new System.Windows.Forms.Padding(0);
            this.lblOPDCollection.Name = "lblOPDCollection";
            this.lblOPDCollection.Size = new System.Drawing.Size(77, 79);
            this.lblOPDCollection.TabIndex = 47;
            this.lblOPDCollection.Text = "999";
            this.toolTip1.SetToolTip(this.lblOPDCollection, "OPD Collection");
            this.lblOPDCollection.UseVisualStyleBackColor = false;
            this.lblOPDCollection.Click += new System.EventHandler(this.lblOPDCollection_Click);
            this.lblOPDCollection.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblOPDCollection_MouseClick);
            // 
            // lblMadamPatient
            // 
            this.lblMadamPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMadamPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(171)))), ((int)(((byte)(232)))));
            this.lblMadamPatient.BorderColor = System.Drawing.Color.White;
            this.lblMadamPatient.BorderDownColor = System.Drawing.Color.Empty;
            this.lblMadamPatient.BorderDownWidth = 0F;
            this.lblMadamPatient.BorderOverColor = System.Drawing.Color.Empty;
            this.lblMadamPatient.BorderOverWidth = 0F;
            this.lblMadamPatient.BorderRadius = 100;
            this.lblMadamPatient.BorderWidth = 1.75F;
            this.lblMadamPatient.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMadamPatient.ForeColor = System.Drawing.Color.White;
            this.lblMadamPatient.Location = new System.Drawing.Point(672, 11);
            this.lblMadamPatient.Margin = new System.Windows.Forms.Padding(0);
            this.lblMadamPatient.Name = "lblMadamPatient";
            this.lblMadamPatient.Size = new System.Drawing.Size(77, 79);
            this.lblMadamPatient.TabIndex = 46;
            this.lblMadamPatient.Text = "999";
            this.toolTip1.SetToolTip(this.lblMadamPatient, "Madam");
            this.lblMadamPatient.UseVisualStyleBackColor = false;
            // 
            // lblSIRPatient
            // 
            this.lblSIRPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSIRPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(138)))), ((int)(((byte)(232)))));
            this.lblSIRPatient.BorderColor = System.Drawing.Color.White;
            this.lblSIRPatient.BorderDownColor = System.Drawing.Color.Empty;
            this.lblSIRPatient.BorderDownWidth = 0F;
            this.lblSIRPatient.BorderOverColor = System.Drawing.Color.Empty;
            this.lblSIRPatient.BorderOverWidth = 0F;
            this.lblSIRPatient.BorderRadius = 100;
            this.lblSIRPatient.BorderWidth = 1.75F;
            this.lblSIRPatient.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSIRPatient.ForeColor = System.Drawing.Color.White;
            this.lblSIRPatient.Location = new System.Drawing.Point(753, 11);
            this.lblSIRPatient.Margin = new System.Windows.Forms.Padding(0);
            this.lblSIRPatient.Name = "lblSIRPatient";
            this.lblSIRPatient.Size = new System.Drawing.Size(77, 79);
            this.lblSIRPatient.TabIndex = 45;
            this.lblSIRPatient.Text = "999";
            this.toolTip1.SetToolTip(this.lblSIRPatient, "Sir");
            this.lblSIRPatient.UseVisualStyleBackColor = false;
            // 
            // lblDonePatient
            // 
            this.lblDonePatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDonePatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(156)))), ((int)(((byte)(0)))));
            this.lblDonePatient.BorderColor = System.Drawing.Color.White;
            this.lblDonePatient.BorderDownColor = System.Drawing.Color.Empty;
            this.lblDonePatient.BorderDownWidth = 0F;
            this.lblDonePatient.BorderOverColor = System.Drawing.Color.Empty;
            this.lblDonePatient.BorderOverWidth = 0F;
            this.lblDonePatient.BorderRadius = 100;
            this.lblDonePatient.BorderWidth = 1.75F;
            this.lblDonePatient.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonePatient.ForeColor = System.Drawing.Color.White;
            this.lblDonePatient.Location = new System.Drawing.Point(834, 11);
            this.lblDonePatient.Margin = new System.Windows.Forms.Padding(0);
            this.lblDonePatient.Name = "lblDonePatient";
            this.lblDonePatient.Size = new System.Drawing.Size(77, 79);
            this.lblDonePatient.TabIndex = 44;
            this.lblDonePatient.Text = "999";
            this.toolTip1.SetToolTip(this.lblDonePatient, "Done");
            this.lblDonePatient.UseVisualStyleBackColor = false;
            // 
            // lblWaitingPatient
            // 
            this.lblWaitingPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWaitingPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(135)))), ((int)(((byte)(13)))));
            this.lblWaitingPatient.BorderColor = System.Drawing.Color.White;
            this.lblWaitingPatient.BorderDownColor = System.Drawing.Color.Empty;
            this.lblWaitingPatient.BorderDownWidth = 0F;
            this.lblWaitingPatient.BorderOverColor = System.Drawing.Color.Empty;
            this.lblWaitingPatient.BorderOverWidth = 0F;
            this.lblWaitingPatient.BorderRadius = 100;
            this.lblWaitingPatient.BorderWidth = 1.75F;
            this.lblWaitingPatient.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaitingPatient.ForeColor = System.Drawing.Color.White;
            this.lblWaitingPatient.Location = new System.Drawing.Point(913, 11);
            this.lblWaitingPatient.Margin = new System.Windows.Forms.Padding(0);
            this.lblWaitingPatient.Name = "lblWaitingPatient";
            this.lblWaitingPatient.Size = new System.Drawing.Size(77, 79);
            this.lblWaitingPatient.TabIndex = 43;
            this.lblWaitingPatient.Text = "999";
            this.toolTip1.SetToolTip(this.lblWaitingPatient, "Waiting");
            this.lblWaitingPatient.UseVisualStyleBackColor = false;
            // 
            // lbl5
            // 
            this.lbl5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(132)))));
            this.lbl5.BorderColor = System.Drawing.Color.White;
            this.lbl5.BorderDownColor = System.Drawing.Color.Empty;
            this.lbl5.BorderDownWidth = 0F;
            this.lbl5.BorderOverColor = System.Drawing.Color.Empty;
            this.lbl5.BorderOverWidth = 0F;
            this.lbl5.BorderRadius = 100;
            this.lbl5.BorderWidth = 1F;
            this.lbl5.ForeColor = System.Drawing.Color.White;
            this.lbl5.Location = new System.Drawing.Point(3, 63);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(59, 55);
            this.lbl5.TabIndex = 11;
            this.lbl5.Text = "111";
            this.lbl5.UseVisualStyleBackColor = false;
            // 
            // lbl4
            // 
            this.lbl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(132)))));
            this.lbl4.BorderColor = System.Drawing.Color.White;
            this.lbl4.BorderDownColor = System.Drawing.Color.Empty;
            this.lbl4.BorderDownWidth = 0F;
            this.lbl4.BorderOverColor = System.Drawing.Color.Empty;
            this.lbl4.BorderOverWidth = 0F;
            this.lbl4.BorderRadius = 100;
            this.lbl4.BorderWidth = 1F;
            this.lbl4.ForeColor = System.Drawing.Color.White;
            this.lbl4.Location = new System.Drawing.Point(188, 5);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(59, 55);
            this.lbl4.TabIndex = 10;
            this.lbl4.Text = "111";
            this.lbl4.UseVisualStyleBackColor = false;
            // 
            // lbl6
            // 
            this.lbl6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(132)))));
            this.lbl6.BorderColor = System.Drawing.Color.White;
            this.lbl6.BorderDownColor = System.Drawing.Color.Empty;
            this.lbl6.BorderDownWidth = 0F;
            this.lbl6.BorderOverColor = System.Drawing.Color.Empty;
            this.lbl6.BorderOverWidth = 0F;
            this.lbl6.BorderRadius = 100;
            this.lbl6.BorderWidth = 1F;
            this.lbl6.ForeColor = System.Drawing.Color.White;
            this.lbl6.Location = new System.Drawing.Point(65, 63);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(59, 55);
            this.lbl6.TabIndex = 9;
            this.lbl6.Text = "111";
            this.lbl6.UseVisualStyleBackColor = false;
            this.lbl6.Click += new System.EventHandler(this.roundedButton3_Click);
            // 
            // lbl3
            // 
            this.lbl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(132)))));
            this.lbl3.BorderColor = System.Drawing.Color.White;
            this.lbl3.BorderDownColor = System.Drawing.Color.Empty;
            this.lbl3.BorderDownWidth = 0F;
            this.lbl3.BorderOverColor = System.Drawing.Color.Empty;
            this.lbl3.BorderOverWidth = 0F;
            this.lbl3.BorderRadius = 100;
            this.lbl3.BorderWidth = 1F;
            this.lbl3.ForeColor = System.Drawing.Color.White;
            this.lbl3.Location = new System.Drawing.Point(127, 5);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(59, 55);
            this.lbl3.TabIndex = 8;
            this.lbl3.Text = "111";
            this.lbl3.UseVisualStyleBackColor = false;
            // 
            // lbl2
            // 
            this.lbl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(132)))));
            this.lbl2.BorderColor = System.Drawing.Color.White;
            this.lbl2.BorderDownColor = System.Drawing.Color.Empty;
            this.lbl2.BorderDownWidth = 0F;
            this.lbl2.BorderOverColor = System.Drawing.Color.Empty;
            this.lbl2.BorderOverWidth = 0F;
            this.lbl2.BorderRadius = 100;
            this.lbl2.BorderWidth = 1F;
            this.lbl2.ForeColor = System.Drawing.Color.White;
            this.lbl2.Location = new System.Drawing.Point(65, 5);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(59, 55);
            this.lbl2.TabIndex = 7;
            this.lbl2.Text = "111";
            this.lbl2.UseVisualStyleBackColor = false;
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(94)))), ((int)(((byte)(132)))));
            this.lbl1.BorderColor = System.Drawing.Color.White;
            this.lbl1.BorderDownColor = System.Drawing.Color.Empty;
            this.lbl1.BorderDownWidth = 0F;
            this.lbl1.BorderOverColor = System.Drawing.Color.Empty;
            this.lbl1.BorderOverWidth = 0F;
            this.lbl1.BorderRadius = 100;
            this.lbl1.BorderWidth = 1F;
            this.lbl1.ForeColor = System.Drawing.Color.White;
            this.lbl1.Location = new System.Drawing.Point(4, 5);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(59, 55);
            this.lbl1.TabIndex = 6;
            this.lbl1.Text = "111";
            this.lbl1.UseVisualStyleBackColor = false;
            // 
            // OPDDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1004, 749);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "OPDDashboard";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OPDDashboard";
            this.Load += new System.EventHandler(this.OPDDashboard_Load);
            this.pnlMain.ResumeLayout(false);
            this.tblMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlContainerLeft.ResumeLayout(false);
            this.tblContainerLeft.ResumeLayout(false);
            this.tblpnlContainerLeftR1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInCabin)).EndInit();
            this.tblpnlContainerLeftR2.ResumeLayout(false);
            this.pnlContainerRight.ResumeLayout(false);
            this.tblContainerRight.ResumeLayout(false);
            this.tblpnlContainerRightR1.ResumeLayout(false);
            this.tblpnlContainerRightR1.PerformLayout();
            this.tblpnlContainerRightR2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaiting)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.Panel pnlHeader;
        private RoundedButton lblDuesCollection;
        private RoundedButton lblTotalCollection;
        private RoundedButton lblReceivedCollection;
        private RoundedButton lblXRAY;
        private RoundedButton lblECG;
        private RoundedButton lblLabCollection;
        private RoundedButton lblOPDCollection;
        private RoundedButton lblMadamPatient;
        private RoundedButton lblSIRPatient;
        private RoundedButton lblDonePatient;
        private RoundedButton lblWaitingPatient;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlContainerLeft;
        private System.Windows.Forms.Panel pnlContainerRight;
        private System.Windows.Forms.TableLayoutPanel tblContainerRight;
        private System.Windows.Forms.TableLayoutPanel tblContainerLeft;
        private System.Windows.Forms.Panel tblpnlContainerLeftR1;
        private System.Windows.Forms.Panel tblpnlContainerLeftR2;
        private System.Windows.Forms.Panel tblpnlContainerLeftR3;
        private System.Windows.Forms.Panel tblpnlContainerRightR1;
        private System.Windows.Forms.Panel tblpnlContainerRightR2;
        private System.Windows.Forms.DataGridView dgvInCabin;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvWaiting;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPDId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn CasePaperNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn LabTestingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedBy;
        private System.Windows.Forms.DataGridViewCheckBoxColumn LabFree;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Free;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueAmount;
        private System.Windows.Forms.Label lblTitleWating;
        private System.Windows.Forms.Label lblTitleDone;
        private System.Windows.Forms.Label Sir;
        private System.Windows.Forms.Label lblMadam;
        private System.Windows.Forms.Label lblTitleOPD;
        private System.Windows.Forms.Label lblTitleLab;
        private System.Windows.Forms.Label lblTitleECG;
        private System.Windows.Forms.Label lblTitleXRAY;
        private System.Windows.Forms.Label lblTitlePaid;
        private System.Windows.Forms.Label lblTitleTotal;
        private System.Windows.Forms.Label lblTitleDues;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CasePaperNumberW;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PCDueAmount;
        private System.Windows.Forms.Label label1;
        private RoundedButton lblTPLabCollection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlNextPatients;
        private System.Windows.Forms.Label lblPNo;
        private System.Windows.Forms.Button btnTokenPageRefresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private RoundedButton lbl1;
        private RoundedButton lbl5;
        private RoundedButton lbl4;
        private RoundedButton lbl6;
        private RoundedButton lbl3;
        private RoundedButton lbl2;
    }
}