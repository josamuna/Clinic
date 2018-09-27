namespace GestionClinic_WIN
{
    partial class AgentFrm
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
            this.colDateangagement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPersonne = new System.Windows.Forms.TextBox();
            this.colDatenaissance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEtatcivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_personne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdPers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSexe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdAg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlgFile = new System.Windows.Forms.OpenFileDialog();
            this.dgvAgent = new System.Windows.Forms.DataGridView();
            this.colMatricule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumeroinss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_categorieagent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_qualification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_fonction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhoto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDateEngagement = new System.Windows.Forms.DateTimePicker();
            this.txtDateNaissance = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.cboService = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lblAjouterService = new System.Windows.Forms.Label();
            this.lblAddPersonne = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cboCategorieAgent = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lblCategorieAgent = new System.Windows.Forms.Label();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSexe = new System.Windows.Forms.TextBox();
            this.txtEtatCivil = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cboFonction = new System.Windows.Forms.ComboBox();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.bnvCandidat = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRefreh = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAfficherDonnees = new System.Windows.Forms.Button();
            this.txtSeach = new System.Windows.Forms.TextBox();
            this.cboQualification = new System.Windows.Forms.ComboBox();
            this.pbPhotoPersonne = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAjouterQualifaction = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumInss = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMatriculeAgent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.lblAjouterFonction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCandidat)).BeginInit();
            this.bnvCandidat.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhotoPersonne)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colDateangagement
            // 
            this.colDateangagement.DataPropertyName = "Dateangagement";
            this.colDateangagement.FillWeight = 200F;
            this.colDateangagement.HeaderText = "DateEngagement";
            this.colDateangagement.Name = "colDateangagement";
            this.colDateangagement.ReadOnly = true;
            this.colDateangagement.Width = 115;
            // 
            // txtPersonne
            // 
            this.txtPersonne.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtPersonne.Location = new System.Drawing.Point(13, 82);
            this.txtPersonne.Name = "txtPersonne";
            this.txtPersonne.Size = new System.Drawing.Size(199, 20);
            this.txtPersonne.TabIndex = 259;
            this.txtPersonne.DoubleClick += new System.EventHandler(this.txtPersonne_DoubleClick);
            // 
            // colDatenaissance
            // 
            this.colDatenaissance.DataPropertyName = "Datenaissance";
            this.colDatenaissance.FillWeight = 200F;
            this.colDatenaissance.HeaderText = "DateNaissance";
            this.colDatenaissance.Name = "colDatenaissance";
            this.colDatenaissance.ReadOnly = true;
            this.colDatenaissance.Width = 105;
            // 
            // colTelephone
            // 
            this.colTelephone.DataPropertyName = "Telephone";
            this.colTelephone.FillWeight = 150F;
            this.colTelephone.HeaderText = "Téléphone";
            this.colTelephone.Name = "colTelephone";
            this.colTelephone.ReadOnly = true;
            this.colTelephone.Width = 83;
            // 
            // colEtatcivil
            // 
            this.colEtatcivil.DataPropertyName = "Etatcivil";
            this.colEtatcivil.FillWeight = 150F;
            this.colEtatcivil.HeaderText = "Etatcivil";
            this.colEtatcivil.Name = "colEtatcivil";
            this.colEtatcivil.ReadOnly = true;
            this.colEtatcivil.Width = 70;
            // 
            // colId_personne
            // 
            this.colId_personne.DataPropertyName = "Id_personne";
            this.colId_personne.HeaderText = "Id_personne";
            this.colId_personne.Name = "colId_personne";
            this.colId_personne.ReadOnly = true;
            this.colId_personne.Visible = false;
            this.colId_personne.Width = 91;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "Id";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            this.colID.Width = 43;
            // 
            // colIdPers
            // 
            this.colIdPers.DataPropertyName = "IdPers";
            this.colIdPers.HeaderText = "IdPers";
            this.colIdPers.Name = "colIdPers";
            this.colIdPers.ReadOnly = true;
            this.colIdPers.Visible = false;
            this.colIdPers.Width = 62;
            // 
            // colSexe
            // 
            this.colSexe.DataPropertyName = "Sexe";
            this.colSexe.HeaderText = "Sexe";
            this.colSexe.Name = "colSexe";
            this.colSexe.ReadOnly = true;
            this.colSexe.Width = 56;
            // 
            // colIdAg
            // 
            this.colIdAg.DataPropertyName = "idAg";
            this.colIdAg.HeaderText = "idAg";
            this.colIdAg.Name = "colIdAg";
            this.colIdAg.ReadOnly = true;
            this.colIdAg.Visible = false;
            this.colIdAg.Width = 53;
            // 
            // colGrade
            // 
            this.colGrade.DataPropertyName = "Grade";
            this.colGrade.HeaderText = "Grade";
            this.colGrade.Name = "colGrade";
            this.colGrade.ReadOnly = true;
            this.colGrade.Width = 120;
            // 
            // dlgFile
            // 
            this.dlgFile.FileName = "openFileDialog1";
            // 
            // dgvAgent
            // 
            this.dgvAgent.BackgroundColor = System.Drawing.Color.White;
            this.dgvAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMatricule,
            this.colNom,
            this.colNumeroinss,
            this.colGrade,
            this.colSexe,
            this.colEtatcivil,
            this.colDatenaissance,
            this.colDateangagement,
            this.colTelephone,
            this.colID,
            this.colIdAg,
            this.colIdPers,
            this.colId_personne,
            this.colId_categorieagent,
            this.colId_service,
            this.colId_qualification,
            this.colId_fonction,
            this.colPhoto});
            this.dgvAgent.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvAgent.Location = new System.Drawing.Point(15, 315);
            this.dgvAgent.MultiSelect = false;
            this.dgvAgent.Name = "dgvAgent";
            this.dgvAgent.ReadOnly = true;
            this.dgvAgent.RowHeadersVisible = false;
            this.dgvAgent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgent.Size = new System.Drawing.Size(795, 178);
            this.dgvAgent.TabIndex = 246;
            // 
            // colMatricule
            // 
            this.colMatricule.DataPropertyName = "Matricule";
            this.colMatricule.FillWeight = 150F;
            this.colMatricule.HeaderText = "Matricule";
            this.colMatricule.Name = "colMatricule";
            this.colMatricule.ReadOnly = true;
            this.colMatricule.Width = 75;
            // 
            // colNom
            // 
            this.colNom.DataPropertyName = "Nom";
            this.colNom.FillWeight = 150F;
            this.colNom.HeaderText = "Nom";
            this.colNom.Name = "colNom";
            this.colNom.ReadOnly = true;
            this.colNom.Width = 300;
            // 
            // colNumeroinss
            // 
            this.colNumeroinss.DataPropertyName = "Numeroinss";
            this.colNumeroinss.FillWeight = 150F;
            this.colNumeroinss.HeaderText = "NumInss";
            this.colNumeroinss.Name = "colNumeroinss";
            this.colNumeroinss.ReadOnly = true;
            this.colNumeroinss.Width = 73;
            // 
            // colId_categorieagent
            // 
            this.colId_categorieagent.DataPropertyName = "Id_categorieagent";
            this.colId_categorieagent.HeaderText = "Id_categorieagent";
            this.colId_categorieagent.Name = "colId_categorieagent";
            this.colId_categorieagent.ReadOnly = true;
            this.colId_categorieagent.Visible = false;
            // 
            // colId_service
            // 
            this.colId_service.DataPropertyName = "Id_service";
            this.colId_service.HeaderText = "Id_service";
            this.colId_service.Name = "colId_service";
            this.colId_service.ReadOnly = true;
            this.colId_service.Visible = false;
            // 
            // colId_qualification
            // 
            this.colId_qualification.DataPropertyName = "Id_qualification";
            this.colId_qualification.HeaderText = "Id_qualification";
            this.colId_qualification.Name = "colId_qualification";
            this.colId_qualification.ReadOnly = true;
            this.colId_qualification.Visible = false;
            this.colId_qualification.Width = 103;
            // 
            // colId_fonction
            // 
            this.colId_fonction.DataPropertyName = "Id_fonction";
            this.colId_fonction.HeaderText = "Id_fonction";
            this.colId_fonction.Name = "colId_fonction";
            this.colId_fonction.ReadOnly = true;
            this.colId_fonction.Visible = false;
            this.colId_fonction.Width = 85;
            // 
            // colPhoto
            // 
            this.colPhoto.DataPropertyName = "Photo";
            this.colPhoto.HeaderText = "Photo";
            this.colPhoto.Name = "colPhoto";
            this.colPhoto.ReadOnly = true;
            this.colPhoto.Visible = false;
            this.colPhoto.Width = 60;
            // 
            // txtDateEngagement
            // 
            this.txtDateEngagement.Location = new System.Drawing.Point(16, 212);
            this.txtDateEngagement.Name = "txtDateEngagement";
            this.txtDateEngagement.Size = new System.Drawing.Size(196, 20);
            this.txtDateEngagement.TabIndex = 216;
            // 
            // txtDateNaissance
            // 
            this.txtDateNaissance.Enabled = false;
            this.txtDateNaissance.Location = new System.Drawing.Point(452, 121);
            this.txtDateNaissance.Name = "txtDateNaissance";
            this.txtDateNaissance.Size = new System.Drawing.Size(199, 20);
            this.txtDateNaissance.TabIndex = 224;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(367, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 23);
            this.label10.TabIndex = 245;
            this.label10.Text = "Agent";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboService
            // 
            this.cboService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboService.FormattingEnabled = true;
            this.cboService.Location = new System.Drawing.Point(579, 248);
            this.cboService.Name = "cboService";
            this.cboService.Size = new System.Drawing.Size(200, 21);
            this.cboService.TabIndex = 256;
            this.cboService.DropDown += new System.EventHandler(this.cboService_DropDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(576, 232);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 13);
            this.label20.TabIndex = 258;
            this.label20.Text = "Service";
            // 
            // lblAjouterService
            // 
            this.lblAjouterService.BackColor = System.Drawing.Color.Transparent;
            this.lblAjouterService.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAjouterService.Location = new System.Drawing.Point(781, 244);
            this.lblAjouterService.Name = "lblAjouterService";
            this.lblAjouterService.Size = new System.Drawing.Size(29, 29);
            this.lblAjouterService.TabIndex = 257;
            this.lblAjouterService.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblAjouterService.Click += new System.EventHandler(this.lblAjouterService_Click);
            // 
            // lblAddPersonne
            // 
            this.lblAddPersonne.BackColor = System.Drawing.Color.Transparent;
            this.lblAddPersonne.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAddPersonne.Location = new System.Drawing.Point(213, 82);
            this.lblAddPersonne.Name = "lblAddPersonne";
            this.lblAddPersonne.Size = new System.Drawing.Size(25, 21);
            this.lblAddPersonne.TabIndex = 255;
            this.lblAddPersonne.Click += new System.EventHandler(this.lblAddPersonne_Click);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.LightGray;
            this.label19.Location = new System.Drawing.Point(13, 185);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(639, 3);
            this.label19.TabIndex = 254;
            // 
            // cboCategorieAgent
            // 
            this.cboCategorieAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategorieAgent.FormattingEnabled = true;
            this.cboCategorieAgent.Location = new System.Drawing.Point(241, 82);
            this.cboCategorieAgent.Name = "cboCategorieAgent";
            this.cboCategorieAgent.Size = new System.Drawing.Size(177, 21);
            this.cboCategorieAgent.TabIndex = 251;
            this.cboCategorieAgent.DropDown += new System.EventHandler(this.cboCategorieAgent_DropDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(240, 66);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.label18.TabIndex = 253;
            this.label18.Text = "Catégorie :";
            // 
            // lblCategorieAgent
            // 
            this.lblCategorieAgent.BackColor = System.Drawing.Color.Transparent;
            this.lblCategorieAgent.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblCategorieAgent.Location = new System.Drawing.Point(420, 78);
            this.lblCategorieAgent.Name = "lblCategorieAgent";
            this.lblCategorieAgent.Size = new System.Drawing.Size(29, 29);
            this.lblCategorieAgent.TabIndex = 252;
            this.lblCategorieAgent.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblCategorieAgent.Click += new System.EventHandler(this.lblCategorieAgent_Click);
            // 
            // txtGrade
            // 
            this.txtGrade.Location = new System.Drawing.Point(452, 248);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(121, 20);
            this.txtGrade.TabIndex = 228;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(449, 233);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 250;
            this.label13.Text = "Grade :";
            // 
            // txtSexe
            // 
            this.txtSexe.Enabled = false;
            this.txtSexe.Location = new System.Drawing.Point(452, 160);
            this.txtSexe.Name = "txtSexe";
            this.txtSexe.Size = new System.Drawing.Size(88, 20);
            this.txtSexe.TabIndex = 249;
            // 
            // txtEtatCivil
            // 
            this.txtEtatCivil.Enabled = false;
            this.txtEtatCivil.Location = new System.Drawing.Point(243, 160);
            this.txtEtatCivil.Name = "txtEtatCivil";
            this.txtEtatCivil.Size = new System.Drawing.Size(175, 20);
            this.txtEtatCivil.TabIndex = 248;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.LavenderBlush;
            this.label17.ForeColor = System.Drawing.Color.Crimson;
            this.label17.Location = new System.Drawing.Point(14, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(136, 13);
            this.label17.TabIndex = 247;
            this.label17.Text = "Sélection agent/personne :";
            // 
            // cboFonction
            // 
            this.cboFonction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFonction.FormattingEnabled = true;
            this.cboFonction.Location = new System.Drawing.Point(241, 248);
            this.cboFonction.Name = "cboFonction";
            this.cboFonction.Size = new System.Drawing.Size(177, 21);
            this.cboFonction.TabIndex = 225;
            this.cboFonction.DropDown += new System.EventHandler(this.cboFonction_DropDown);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BackColor = System.Drawing.Color.Transparent;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bindingNavigator1.Size = new System.Drawing.Size(825, 25);
            this.bindingNavigator1.TabIndex = 244;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(287, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 18);
            this.label2.TabIndex = 140;
            this.label2.Text = "Liste des tous les agents";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(534, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 67;
            this.label14.Text = "Rechercher :";
            this.label14.Visible = false;
            // 
            // bnvCandidat
            // 
            this.bnvCandidat.AddNewItem = null;
            this.bnvCandidat.BackColor = System.Drawing.Color.Transparent;
            this.bnvCandidat.CountItem = null;
            this.bnvCandidat.DeleteItem = null;
            this.bnvCandidat.Dock = System.Windows.Forms.DockStyle.None;
            this.bnvCandidat.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bnvCandidat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnRefreh,
            this.btnSave,
            this.btnDelete});
            this.bnvCandidat.Location = new System.Drawing.Point(13, 11);
            this.bnvCandidat.MoveFirstItem = null;
            this.bnvCandidat.MoveLastItem = null;
            this.bnvCandidat.MoveNextItem = null;
            this.bnvCandidat.MovePreviousItem = null;
            this.bnvCandidat.Name = "bnvCandidat";
            this.bnvCandidat.PositionItem = null;
            this.bnvCandidat.Size = new System.Drawing.Size(95, 25);
            this.bnvCandidat.TabIndex = 70;
            this.bnvCandidat.Text = "bindingNavigator1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::GestionClinic_WIN.Properties.Resources.mp_addfolder_disabled_md_n_dk_2x;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRefreh
            // 
            this.btnRefreh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreh.Image = global::GestionClinic_WIN.Properties.Resources.update;
            this.btnRefreh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreh.Name = "btnRefreh";
            this.btnRefreh.Size = new System.Drawing.Size(23, 22);
            this.btnRefreh.Text = "Refresh";
            this.btnRefreh.Click += new System.EventHandler(this.btnRefreh_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::GestionClinic_WIN.Properties.Resources.check_2x;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Mis à jour";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::GestionClinic_WIN.Properties.Resources.mp_delete_md_n_lt_2x1;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 22);
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAfficherDonnees);
            this.groupBox1.Controls.Add(this.txtSeach);
            this.groupBox1.Controls.Add(this.bnvCandidat);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(0, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(828, 42);
            this.groupBox1.TabIndex = 243;
            this.groupBox1.TabStop = false;
            // 
            // btnAfficherDonnees
            // 
            this.btnAfficherDonnees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficherDonnees.ForeColor = System.Drawing.Color.Green;
            this.btnAfficherDonnees.Location = new System.Drawing.Point(153, 14);
            this.btnAfficherDonnees.Name = "btnAfficherDonnees";
            this.btnAfficherDonnees.Size = new System.Drawing.Size(59, 23);
            this.btnAfficherDonnees.TabIndex = 367;
            this.btnAfficherDonnees.Text = "Afficher";
            this.btnAfficherDonnees.UseVisualStyleBackColor = true;
            this.btnAfficherDonnees.Click += new System.EventHandler(this.btnAfficherDonnees_Click);
            // 
            // txtSeach
            // 
            this.txtSeach.Location = new System.Drawing.Point(602, 17);
            this.txtSeach.Name = "txtSeach";
            this.txtSeach.Size = new System.Drawing.Size(205, 20);
            this.txtSeach.TabIndex = 9;
            this.txtSeach.Visible = false;
            this.txtSeach.TextChanged += new System.EventHandler(this.txtSeach_TextChanged);
            // 
            // cboQualification
            // 
            this.cboQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQualification.FormattingEnabled = true;
            this.cboQualification.Location = new System.Drawing.Point(241, 210);
            this.cboQualification.Name = "cboQualification";
            this.cboQualification.Size = new System.Drawing.Size(177, 21);
            this.cboQualification.TabIndex = 218;
            this.cboQualification.DropDown += new System.EventHandler(this.cboQualification_DropDown);
            // 
            // pbPhotoPersonne
            // 
            this.pbPhotoPersonne.BackColor = System.Drawing.Color.Transparent;
            this.pbPhotoPersonne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhotoPersonne.InitialImage = null;
            this.pbPhotoPersonne.Location = new System.Drawing.Point(658, 83);
            this.pbPhotoPersonne.Name = "pbPhotoPersonne";
            this.pbPhotoPersonne.Size = new System.Drawing.Size(152, 146);
            this.pbPhotoPersonne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhotoPersonne.TabIndex = 237;
            this.pbPhotoPersonne.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(240, 194);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 242;
            this.label12.Text = "Qualification :";
            // 
            // lblAjouterQualifaction
            // 
            this.lblAjouterQualifaction.BackColor = System.Drawing.Color.Transparent;
            this.lblAjouterQualifaction.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAjouterQualifaction.Location = new System.Drawing.Point(420, 205);
            this.lblAjouterQualifaction.Name = "lblAjouterQualifaction";
            this.lblAjouterQualifaction.Size = new System.Drawing.Size(29, 29);
            this.lblAjouterQualifaction.TabIndex = 220;
            this.lblAjouterQualifaction.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblAjouterQualifaction.Click += new System.EventHandler(this.lblAjouterQualifaction_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(16, 276);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 33);
            this.panel1.TabIndex = 241;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(240, 233);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 13);
            this.label16.TabIndex = 240;
            this.label16.Text = "Fonction :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(243, 144);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 239;
            this.label15.Text = "Etat civil :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(450, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 238;
            this.label5.Text = "Sexe :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(14, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 236;
            this.label9.Text = "Date Engagement :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(17, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 235;
            this.label7.Text = "Numéro INSS :";
            // 
            // txtNumInss
            // 
            this.txtNumInss.Location = new System.Drawing.Point(17, 250);
            this.txtNumInss.Name = "txtNumInss";
            this.txtNumInss.Size = new System.Drawing.Size(196, 20);
            this.txtNumInss.TabIndex = 223;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(450, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 234;
            this.label6.Text = "Matricule :";
            // 
            // txtMatriculeAgent
            // 
            this.txtMatriculeAgent.Location = new System.Drawing.Point(452, 210);
            this.txtMatriculeAgent.Name = "txtMatriculeAgent";
            this.txtMatriculeAgent.Size = new System.Drawing.Size(199, 20);
            this.txtMatriculeAgent.TabIndex = 221;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 233;
            this.label1.Text = "Téléphone :";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Enabled = false;
            this.txtTelephone.Location = new System.Drawing.Point(13, 161);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(199, 20);
            this.txtTelephone.TabIndex = 226;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(453, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 232;
            this.label8.Text = "Date naissance :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(453, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 231;
            this.label11.Text = "Nom :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 230;
            this.label4.Text = "Prénom :";
            // 
            // txtNom
            // 
            this.txtNom.Enabled = false;
            this.txtNom.Location = new System.Drawing.Point(452, 82);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(199, 20);
            this.txtNom.TabIndex = 217;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 229;
            this.label3.Text = "Post - nom :";
            // 
            // txtPNom
            // 
            this.txtPNom.Enabled = false;
            this.txtPNom.Location = new System.Drawing.Point(13, 121);
            this.txtPNom.Name = "txtPNom";
            this.txtPNom.Size = new System.Drawing.Size(199, 20);
            this.txtPNom.TabIndex = 219;
            // 
            // txtPrenom
            // 
            this.txtPrenom.Enabled = false;
            this.txtPrenom.Location = new System.Drawing.Point(243, 120);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(175, 20);
            this.txtPrenom.TabIndex = 222;
            // 
            // lblAjouterFonction
            // 
            this.lblAjouterFonction.BackColor = System.Drawing.Color.Transparent;
            this.lblAjouterFonction.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAjouterFonction.Location = new System.Drawing.Point(419, 244);
            this.lblAjouterFonction.Name = "lblAjouterFonction";
            this.lblAjouterFonction.Size = new System.Drawing.Size(29, 29);
            this.lblAjouterFonction.TabIndex = 227;
            this.lblAjouterFonction.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblAjouterFonction.Click += new System.EventHandler(this.lblAjouterFonction_Click);
            // 
            // FrmAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.img_home_player_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(825, 490);
            this.Controls.Add(this.txtPersonne);
            this.Controls.Add(this.dgvAgent);
            this.Controls.Add(this.txtDateEngagement);
            this.Controls.Add(this.txtDateNaissance);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboService);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblAjouterService);
            this.Controls.Add(this.lblAddPersonne);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cboCategorieAgent);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblCategorieAgent);
            this.Controls.Add(this.txtGrade);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSexe);
            this.Controls.Add(this.txtEtatCivil);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cboFonction);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboQualification);
            this.Controls.Add(this.pbPhotoPersonne);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblAjouterQualifaction);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNumInss);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMatriculeAgent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPNom);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.lblAjouterFonction);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmAgent";
            this.Text = "Agent";
            this.Load += new System.EventHandler(this.FrmAgentcs_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAgentcs_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCandidat)).EndInit();
            this.bnvCandidat.ResumeLayout(false);
            this.bnvCandidat.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhotoPersonne)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colDateangagement;
        private System.Windows.Forms.TextBox txtPersonne;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatenaissance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEtatcivil;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_personne;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSexe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdAg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrade;
        private System.Windows.Forms.OpenFileDialog dlgFile;
        private System.Windows.Forms.DataGridView dgvAgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatricule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumeroinss;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_categorieagent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_service;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_qualification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_fonction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoto;
        private System.Windows.Forms.DateTimePicker txtDateEngagement;
        private System.Windows.Forms.DateTimePicker txtDateNaissance;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboService;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblAjouterService;
        private System.Windows.Forms.Label lblAddPersonne;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboCategorieAgent;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblCategorieAgent;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSexe;
        private System.Windows.Forms.TextBox txtEtatCivil;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboFonction;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.BindingNavigator bnvCandidat;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnRefreh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAfficherDonnees;
        private System.Windows.Forms.TextBox txtSeach;
        private System.Windows.Forms.ComboBox cboQualification;
        private System.Windows.Forms.PictureBox pbPhotoPersonne;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAjouterQualifaction;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumInss;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMatriculeAgent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPNom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label lblAjouterFonction;
    }
}