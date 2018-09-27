namespace GestionClinic_WIN
{
    partial class IntervationFrm
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
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.txtDesignationIntervention = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bnvFonction = new System.Windows.Forms.BindingNavigator(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.cboBloc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAddBloc = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbBloc = new System.Windows.Forms.TabPage();
            this.btnService = new System.Windows.Forms.Label();
            this.cboService = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvBloc = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Designation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDesignationBloc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bdnBloc = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAddBloc = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshBloc = new System.Windows.Forms.ToolStripButton();
            this.btnSaveBloc = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteBloc = new System.Windows.Forms.ToolStripButton();
            this.tbService = new System.Windows.Forms.TabPage();
            this.dgvService = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDesignationService = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bdnService = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAddService = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshService = new System.Windows.Forms.ToolStripButton();
            this.btnSaveService = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteService = new System.Windows.Forms.ToolStripButton();
            this.dgvIntervention = new System.Windows.Forms.DataGridView();
            this.colDesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_bloc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bnvFonction)).BeginInit();
            this.bnvFonction.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbBloc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBloc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdnBloc)).BeginInit();
            this.bdnBloc.SuspendLayout();
            this.tbService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdnService)).BeginInit();
            this.bdnService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntervention)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::GestionClinic_WIN.Properties.Resources.mp_delete_md_n_lt_2x;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 22);
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::GestionClinic_WIN.Properties.Resources.update;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::GestionClinic_WIN.Properties.Resources.check_2x;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Enregistrer";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::GestionClinic_WIN.Properties.Resources.navBarAddIcon_2x;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDesignationIntervention
            // 
            this.txtDesignationIntervention.Location = new System.Drawing.Point(84, 62);
            this.txtDesignationIntervention.Name = "txtDesignationIntervention";
            this.txtDesignationIntervention.Size = new System.Drawing.Size(209, 20);
            this.txtDesignationIntervention.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Désignation:";
            // 
            // bnvFonction
            // 
            this.bnvFonction.AddNewItem = null;
            this.bnvFonction.BackColor = System.Drawing.Color.Transparent;
            this.bnvFonction.CountItem = null;
            this.bnvFonction.DeleteItem = null;
            this.bnvFonction.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bnvFonction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnRefresh,
            this.btnSave,
            this.btnDelete});
            this.bnvFonction.Location = new System.Drawing.Point(0, 0);
            this.bnvFonction.MoveFirstItem = null;
            this.bnvFonction.MoveLastItem = null;
            this.bnvFonction.MoveNextItem = null;
            this.bnvFonction.MovePreviousItem = null;
            this.bnvFonction.Name = "bnvFonction";
            this.bnvFonction.PositionItem = null;
            this.bnvFonction.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bnvFonction.Size = new System.Drawing.Size(643, 25);
            this.bnvFonction.TabIndex = 60;
            this.bnvFonction.Text = "bindingNavigator1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Prix :";
            // 
            // txtPrix
            // 
            this.txtPrix.Location = new System.Drawing.Point(84, 90);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(130, 20);
            this.txtPrix.TabIndex = 56;
            // 
            // cboBloc
            // 
            this.cboBloc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBloc.FormattingEnabled = true;
            this.cboBloc.Location = new System.Drawing.Point(84, 114);
            this.cboBloc.Name = "cboBloc";
            this.cboBloc.Size = new System.Drawing.Size(209, 21);
            this.cboBloc.TabIndex = 259;
            this.cboBloc.DropDown += new System.EventHandler(this.cboBloc_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 258;
            this.label3.Text = "Sous service :";
            // 
            // lblAddBloc
            // 
            this.lblAddBloc.BackColor = System.Drawing.Color.Transparent;
            this.lblAddBloc.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAddBloc.Location = new System.Drawing.Point(299, 114);
            this.lblAddBloc.Name = "lblAddBloc";
            this.lblAddBloc.Size = new System.Drawing.Size(25, 21);
            this.lblAddBloc.TabIndex = 260;
            this.lblAddBloc.Click += new System.EventHandler(this.lblAddBloc_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbBloc);
            this.tabControl1.Controls.Add(this.tbService);
            this.tabControl1.Location = new System.Drawing.Point(333, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(302, 196);
            this.tabControl1.TabIndex = 261;
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            // 
            // tbBloc
            // 
            this.tbBloc.Controls.Add(this.btnService);
            this.tbBloc.Controls.Add(this.cboService);
            this.tbBloc.Controls.Add(this.label5);
            this.tbBloc.Controls.Add(this.dgvBloc);
            this.tbBloc.Controls.Add(this.txtDesignationBloc);
            this.tbBloc.Controls.Add(this.label6);
            this.tbBloc.Controls.Add(this.bdnBloc);
            this.tbBloc.Location = new System.Drawing.Point(4, 22);
            this.tbBloc.Name = "tbBloc";
            this.tbBloc.Padding = new System.Windows.Forms.Padding(3);
            this.tbBloc.Size = new System.Drawing.Size(294, 170);
            this.tbBloc.TabIndex = 0;
            this.tbBloc.Text = "Sous service";
            this.tbBloc.UseVisualStyleBackColor = true;
            // 
            // btnService
            // 
            this.btnService.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.btnService.Location = new System.Drawing.Point(261, 59);
            this.btnService.Name = "btnService";
            this.btnService.Size = new System.Drawing.Size(25, 21);
            this.btnService.TabIndex = 265;
            this.btnService.Click += new System.EventHandler(this.btnService_Click);
            // 
            // cboService
            // 
            this.cboService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboService.FormattingEnabled = true;
            this.cboService.Location = new System.Drawing.Point(80, 59);
            this.cboService.Name = "cboService";
            this.cboService.Size = new System.Drawing.Size(175, 21);
            this.cboService.TabIndex = 264;
            this.cboService.DropDown += new System.EventHandler(this.cboService_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(10, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 263;
            this.label5.Text = "Service :";
            // 
            // dgvBloc
            // 
            this.dgvBloc.BackgroundColor = System.Drawing.Color.White;
            this.dgvBloc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBloc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.colId_service,
            this.Designation});
            this.dgvBloc.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvBloc.Location = new System.Drawing.Point(10, 87);
            this.dgvBloc.MultiSelect = false;
            this.dgvBloc.Name = "dgvBloc";
            this.dgvBloc.ReadOnly = true;
            this.dgvBloc.RowHeadersVisible = false;
            this.dgvBloc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBloc.Size = new System.Drawing.Size(273, 79);
            this.dgvBloc.TabIndex = 262;
            this.dgvBloc.DoubleClick += new System.EventHandler(this.dgvBloc_DoubleClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // colId_service
            // 
            this.colId_service.DataPropertyName = "Id_service";
            this.colId_service.HeaderText = "Id_service";
            this.colId_service.Name = "colId_service";
            this.colId_service.ReadOnly = true;
            this.colId_service.Visible = false;
            // 
            // Designation
            // 
            this.Designation.DataPropertyName = "Designation";
            this.Designation.HeaderText = "Désignation";
            this.Designation.Name = "Designation";
            this.Designation.ReadOnly = true;
            this.Designation.Width = 250;
            // 
            // txtDesignationBloc
            // 
            this.txtDesignationBloc.Location = new System.Drawing.Point(80, 33);
            this.txtDesignationBloc.Name = "txtDesignationBloc";
            this.txtDesignationBloc.Size = new System.Drawing.Size(175, 20);
            this.txtDesignationBloc.TabIndex = 261;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(10, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 260;
            this.label6.Text = "Designation :";
            // 
            // bdnBloc
            // 
            this.bdnBloc.AddNewItem = null;
            this.bdnBloc.BackColor = System.Drawing.Color.Transparent;
            this.bdnBloc.CountItem = null;
            this.bdnBloc.DeleteItem = null;
            this.bdnBloc.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bdnBloc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddBloc,
            this.btnRefreshBloc,
            this.btnSaveBloc,
            this.btnDeleteBloc});
            this.bdnBloc.Location = new System.Drawing.Point(3, 3);
            this.bdnBloc.MoveFirstItem = null;
            this.bdnBloc.MoveLastItem = null;
            this.bdnBloc.MoveNextItem = null;
            this.bdnBloc.MovePreviousItem = null;
            this.bdnBloc.Name = "bdnBloc";
            this.bdnBloc.PositionItem = null;
            this.bdnBloc.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bdnBloc.Size = new System.Drawing.Size(288, 25);
            this.bdnBloc.TabIndex = 61;
            this.bdnBloc.Text = "bindingNavigator1";
            // 
            // btnAddBloc
            // 
            this.btnAddBloc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddBloc.Image = global::GestionClinic_WIN.Properties.Resources.navBarAddIcon_2x;
            this.btnAddBloc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddBloc.Name = "btnAddBloc";
            this.btnAddBloc.Size = new System.Drawing.Size(23, 22);
            this.btnAddBloc.Text = "Ajouter";
            this.btnAddBloc.Click += new System.EventHandler(this.btnAddBloc_Click);
            // 
            // btnRefreshBloc
            // 
            this.btnRefreshBloc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshBloc.Image = global::GestionClinic_WIN.Properties.Resources.update;
            this.btnRefreshBloc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshBloc.Name = "btnRefreshBloc";
            this.btnRefreshBloc.Size = new System.Drawing.Size(23, 22);
            this.btnRefreshBloc.Text = "Refresh";
            this.btnRefreshBloc.Click += new System.EventHandler(this.btnRefreshBloc_Click);
            // 
            // btnSaveBloc
            // 
            this.btnSaveBloc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveBloc.Image = global::GestionClinic_WIN.Properties.Resources.check_2x;
            this.btnSaveBloc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveBloc.Name = "btnSaveBloc";
            this.btnSaveBloc.Size = new System.Drawing.Size(23, 22);
            this.btnSaveBloc.Text = "Enregistrer";
            this.btnSaveBloc.Click += new System.EventHandler(this.btnSaveBloc_Click);
            // 
            // btnDeleteBloc
            // 
            this.btnDeleteBloc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteBloc.Image = global::GestionClinic_WIN.Properties.Resources.mp_delete_md_n_lt_2x;
            this.btnDeleteBloc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteBloc.Name = "btnDeleteBloc";
            this.btnDeleteBloc.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteBloc.Text = "Supprimer";
            this.btnDeleteBloc.Click += new System.EventHandler(this.btnDeleteBloc_Click);
            // 
            // tbService
            // 
            this.tbService.Controls.Add(this.dgvService);
            this.tbService.Controls.Add(this.txtDesignationService);
            this.tbService.Controls.Add(this.label8);
            this.tbService.Controls.Add(this.bdnService);
            this.tbService.Location = new System.Drawing.Point(4, 22);
            this.tbService.Name = "tbService";
            this.tbService.Padding = new System.Windows.Forms.Padding(3);
            this.tbService.Size = new System.Drawing.Size(294, 170);
            this.tbService.TabIndex = 1;
            this.tbService.Text = "Service";
            this.tbService.UseVisualStyleBackColor = true;
            // 
            // dgvService
            // 
            this.dgvService.BackgroundColor = System.Drawing.Color.White;
            this.dgvService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.colId2});
            this.dgvService.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvService.Location = new System.Drawing.Point(7, 63);
            this.dgvService.MultiSelect = false;
            this.dgvService.Name = "dgvService";
            this.dgvService.ReadOnly = true;
            this.dgvService.RowHeadersVisible = false;
            this.dgvService.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvService.Size = new System.Drawing.Size(279, 100);
            this.dgvService.TabIndex = 267;
            this.dgvService.SelectionChanged += new System.EventHandler(this.dgvService_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Designation";
            this.dataGridViewTextBoxColumn1.HeaderText = "Désignation";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 275;
            // 
            // colId2
            // 
            this.colId2.DataPropertyName = "Id";
            this.colId2.HeaderText = "Id";
            this.colId2.Name = "colId2";
            this.colId2.ReadOnly = true;
            this.colId2.Visible = false;
            // 
            // txtDesignationService
            // 
            this.txtDesignationService.Location = new System.Drawing.Point(83, 38);
            this.txtDesignationService.Name = "txtDesignationService";
            this.txtDesignationService.Size = new System.Drawing.Size(203, 20);
            this.txtDesignationService.TabIndex = 266;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(13, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 265;
            this.label8.Text = "Designation :";
            // 
            // bdnService
            // 
            this.bdnService.AddNewItem = null;
            this.bdnService.BackColor = System.Drawing.Color.Transparent;
            this.bdnService.CountItem = null;
            this.bdnService.DeleteItem = null;
            this.bdnService.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bdnService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddService,
            this.btnRefreshService,
            this.btnSaveService,
            this.btnDeleteService});
            this.bdnService.Location = new System.Drawing.Point(3, 3);
            this.bdnService.MoveFirstItem = null;
            this.bdnService.MoveLastItem = null;
            this.bdnService.MoveNextItem = null;
            this.bdnService.MovePreviousItem = null;
            this.bdnService.Name = "bdnService";
            this.bdnService.PositionItem = null;
            this.bdnService.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bdnService.Size = new System.Drawing.Size(288, 25);
            this.bdnService.TabIndex = 62;
            this.bdnService.Text = "bindingNavigator2";
            // 
            // btnAddService
            // 
            this.btnAddService.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddService.Image = global::GestionClinic_WIN.Properties.Resources.navBarAddIcon_2x;
            this.btnAddService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(23, 22);
            this.btnAddService.Text = "Ajouter";
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnRefreshService
            // 
            this.btnRefreshService.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshService.Image = global::GestionClinic_WIN.Properties.Resources.update;
            this.btnRefreshService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshService.Name = "btnRefreshService";
            this.btnRefreshService.Size = new System.Drawing.Size(23, 22);
            this.btnRefreshService.Text = "Refresh";
            this.btnRefreshService.Click += new System.EventHandler(this.btnRefreshService_Click);
            // 
            // btnSaveService
            // 
            this.btnSaveService.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveService.Image = global::GestionClinic_WIN.Properties.Resources.check_2x;
            this.btnSaveService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveService.Name = "btnSaveService";
            this.btnSaveService.Size = new System.Drawing.Size(23, 22);
            this.btnSaveService.Text = "Enregistrer";
            this.btnSaveService.Click += new System.EventHandler(this.btnSaveService_Click);
            // 
            // btnDeleteService
            // 
            this.btnDeleteService.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteService.Image = global::GestionClinic_WIN.Properties.Resources.mp_delete_md_n_lt_2x;
            this.btnDeleteService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteService.Name = "btnDeleteService";
            this.btnDeleteService.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteService.Text = "Supprimer";
            this.btnDeleteService.Click += new System.EventHandler(this.btnDeleteService_Click);
            // 
            // dgvIntervention
            // 
            this.dgvIntervention.BackgroundColor = System.Drawing.Color.White;
            this.dgvIntervention.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIntervention.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDesignation,
            this.ColPrix,
            this.ColId,
            this.colId_bloc});
            this.dgvIntervention.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvIntervention.Location = new System.Drawing.Point(7, 146);
            this.dgvIntervention.MultiSelect = false;
            this.dgvIntervention.Name = "dgvIntervention";
            this.dgvIntervention.ReadOnly = true;
            this.dgvIntervention.RowHeadersVisible = false;
            this.dgvIntervention.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvIntervention.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIntervention.Size = new System.Drawing.Size(319, 108);
            this.dgvIntervention.TabIndex = 262;
            this.dgvIntervention.DoubleClick += new System.EventHandler(this.dgvIntervention_DoubleClick);
            // 
            // colDesignation
            // 
            this.colDesignation.DataPropertyName = "Designation";
            this.colDesignation.HeaderText = "Désignation";
            this.colDesignation.Name = "colDesignation";
            this.colDesignation.ReadOnly = true;
            this.colDesignation.Width = 220;
            // 
            // ColPrix
            // 
            this.ColPrix.DataPropertyName = "Prix";
            this.ColPrix.HeaderText = "Prix";
            this.ColPrix.Name = "ColPrix";
            this.ColPrix.ReadOnly = true;
            this.ColPrix.Width = 150;
            // 
            // ColId
            // 
            this.ColId.DataPropertyName = "Id";
            this.ColId.HeaderText = "Id";
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            this.ColId.Visible = false;
            // 
            // colId_bloc
            // 
            this.colId_bloc.DataPropertyName = "Id_bloc";
            this.colId_bloc.HeaderText = "Id_bloc";
            this.colId_bloc.Name = "colId_bloc";
            this.colId_bloc.ReadOnly = true;
            this.colId_bloc.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(220, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 265;
            this.label4.Text = "$";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(270, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 20);
            this.label16.TabIndex = 278;
            this.label16.Text = "Intervention ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmIntervation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(643, 267);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvIntervention);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblAddBloc);
            this.Controls.Add(this.cboBloc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDesignationIntervention);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnvFonction);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmIntervation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intervention ";
            this.Load += new System.EventHandler(this.FrmIntervation_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmIntervation_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bnvFonction)).EndInit();
            this.bnvFonction.ResumeLayout(false);
            this.bnvFonction.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tbBloc.ResumeLayout(false);
            this.tbBloc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBloc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdnBloc)).EndInit();
            this.bdnBloc.ResumeLayout(false);
            this.bdnBloc.PerformLayout();
            this.tbService.ResumeLayout(false);
            this.tbService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdnService)).EndInit();
            this.bdnService.ResumeLayout(false);
            this.bdnService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntervention)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.TextBox txtDesignationIntervention;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingNavigator bnvFonction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.ComboBox cboBloc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAddBloc;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbBloc;
        private System.Windows.Forms.TabPage tbService;
        private System.Windows.Forms.BindingNavigator bdnBloc;
        private System.Windows.Forms.ToolStripButton btnAddBloc;
        private System.Windows.Forms.ToolStripButton btnRefreshBloc;
        private System.Windows.Forms.ToolStripButton btnSaveBloc;
        private System.Windows.Forms.ToolStripButton btnDeleteBloc;
        private System.Windows.Forms.BindingNavigator bdnService;
        private System.Windows.Forms.ToolStripButton btnAddService;
        private System.Windows.Forms.ToolStripButton btnRefreshService;
        private System.Windows.Forms.ToolStripButton btnSaveService;
        private System.Windows.Forms.ToolStripButton btnDeleteService;
        private System.Windows.Forms.ComboBox cboService;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvBloc;
        private System.Windows.Forms.TextBox txtDesignationBloc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDesignationService;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvIntervention;
        private System.Windows.Forms.Label btnService;
        private System.Windows.Forms.DataGridView dgvService;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesignation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrix;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_bloc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_service;
        private System.Windows.Forms.DataGridViewTextBoxColumn Designation;
    }
}