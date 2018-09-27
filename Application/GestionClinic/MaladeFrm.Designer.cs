namespace GestionClinic_WIN
{
    partial class MaladeFrm
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
            this.colTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPersonne = new System.Windows.Forms.TextBox();
            this.colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatenaissance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdPers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_etablissement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_categoriemalade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEtatcivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colidMal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSexe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlgFile = new System.Windows.Forms.OpenFileDialog();
            this.dgvMalade = new System.Windows.Forms.DataGridView();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nom_complet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumero_fiche = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_airsante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_personne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_profession = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_groupesanguin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colid1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhoto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAddProfession = new System.Windows.Forms.Label();
            this.cboProfession = new System.Windows.Forms.ComboBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtAdresse = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lblGpSanguin = new System.Windows.Forms.Label();
            this.cboGpSanguin = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblAddPersonne = new System.Windows.Forms.Label();
            this.txtIdPers = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSexe = new System.Windows.Forms.TextBox();
            this.txtEtatCivil = new System.Windows.Forms.TextBox();
            this.txtDateNaissance = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.label14 = new System.Windows.Forms.Label();
            this.lblOrganisationPriseCharge = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.lblAirSante = new System.Windows.Forms.Label();
            this.cboAireSante = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAddCategorie = new System.Windows.Forms.Label();
            this.cboEtablissement = new System.Windows.Forms.ComboBox();
            this.btnAfficherDonnees = new System.Windows.Forms.Button();
            this.btnRefreh = new System.Windows.Forms.ToolStripButton();
            this.label20 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSeach = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.txtNumeroFiche = new System.Windows.Forms.TextBox();
            this.bnvCandidat = new System.Windows.Forms.BindingNavigator(this.components);
            this.pbPhotoPersonne = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboCategorie = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCandidat)).BeginInit();
            this.bnvCandidat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhotoPersonne)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // txtPersonne
            // 
            this.txtPersonne.BackColor = System.Drawing.Color.AntiqueWhite;
            this.txtPersonne.Location = new System.Drawing.Point(157, 94);
            this.txtPersonne.Name = "txtPersonne";
            this.txtPersonne.Size = new System.Drawing.Size(214, 20);
            this.txtPersonne.TabIndex = 250;
            this.txtPersonne.DoubleClick += new System.EventHandler(this.txtPersonne_DoubleClick);
            // 
            // colAge
            // 
            this.colAge.DataPropertyName = "AgePers";
            this.colAge.HeaderText = "Age";
            this.colAge.Name = "colAge";
            this.colAge.ReadOnly = true;
            this.colAge.Visible = false;
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
            // colIdPers
            // 
            this.colIdPers.DataPropertyName = "IdPers";
            this.colIdPers.HeaderText = "IdPers";
            this.colIdPers.Name = "colIdPers";
            this.colIdPers.ReadOnly = true;
            this.colIdPers.Visible = false;
            this.colIdPers.Width = 62;
            // 
            // colId_etablissement
            // 
            this.colId_etablissement.DataPropertyName = "Id_etablissement";
            this.colId_etablissement.HeaderText = "Id_etablissement";
            this.colId_etablissement.Name = "colId_etablissement";
            this.colId_etablissement.ReadOnly = true;
            this.colId_etablissement.Visible = false;
            this.colId_etablissement.Width = 111;
            // 
            // colId_categoriemalade
            // 
            this.colId_categoriemalade.DataPropertyName = "Id_categoriemalade";
            this.colId_categoriemalade.HeaderText = "Id_categoriemalade";
            this.colId_categoriemalade.Name = "colId_categoriemalade";
            this.colId_categoriemalade.ReadOnly = true;
            this.colId_categoriemalade.Visible = false;
            this.colId_categoriemalade.Width = 125;
            // 
            // colEtatcivil
            // 
            this.colEtatcivil.DataPropertyName = "Etatcivil";
            this.colEtatcivil.FillWeight = 150F;
            this.colEtatcivil.HeaderText = "Etatcivil";
            this.colEtatcivil.Name = "colEtatcivil";
            this.colEtatcivil.ReadOnly = true;
            this.colEtatcivil.Width = 69;
            // 
            // colidMal
            // 
            this.colidMal.DataPropertyName = "idMal";
            this.colidMal.HeaderText = "idMal";
            this.colidMal.Name = "colidMal";
            this.colidMal.ReadOnly = true;
            this.colidMal.Visible = false;
            this.colidMal.Width = 57;
            // 
            // colSexe
            // 
            this.colSexe.DataPropertyName = "Sexe";
            this.colSexe.HeaderText = "Sexe";
            this.colSexe.Name = "colSexe";
            this.colSexe.ReadOnly = true;
            this.colSexe.Width = 56;
            // 
            // colNom
            // 
            this.colNom.DataPropertyName = "Nom";
            this.colNom.FillWeight = 150F;
            this.colNom.HeaderText = "Nom";
            this.colNom.Name = "colNom";
            this.colNom.ReadOnly = true;
            this.colNom.Width = 200;
            // 
            // dlgFile
            // 
            this.dlgFile.FileName = "openFileDialog1";
            // 
            // dgvMalade
            // 
            this.dgvMalade.BackgroundColor = System.Drawing.Color.White;
            this.dgvMalade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMalade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumero,
            this.Nom_complet,
            this.colNumero_fiche,
            this.colNom,
            this.colSexe,
            this.colEtatcivil,
            this.colDatenaissance,
            this.colTelephone,
            this.colAge,
            this.colIdPers,
            this.colId_categoriemalade,
            this.colidMal,
            this.colId_etablissement,
            this.colId_airsante,
            this.colId_personne,
            this.colId_profession,
            this.colId_groupesanguin,
            this.colID,
            this.colid1,
            this.colPhoto});
            this.dgvMalade.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvMalade.Location = new System.Drawing.Point(539, 133);
            this.dgvMalade.MultiSelect = false;
            this.dgvMalade.Name = "dgvMalade";
            this.dgvMalade.ReadOnly = true;
            this.dgvMalade.RowHeadersVisible = false;
            this.dgvMalade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMalade.Size = new System.Drawing.Size(367, 371);
            this.dgvMalade.TabIndex = 239;
            // 
            // colNumero
            // 
            this.colNumero.DataPropertyName = "Numero";
            this.colNumero.FillWeight = 150F;
            this.colNumero.HeaderText = "Numéro";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 75;
            // 
            // Nom_complet
            // 
            this.Nom_complet.DataPropertyName = "Nom_complet";
            this.Nom_complet.HeaderText = "colNom_complet";
            this.Nom_complet.Name = "Nom_complet";
            this.Nom_complet.ReadOnly = true;
            this.Nom_complet.Visible = false;
            // 
            // colNumero_fiche
            // 
            this.colNumero_fiche.DataPropertyName = "Numero_fiche";
            this.colNumero_fiche.HeaderText = "Numéro Fiche";
            this.colNumero_fiche.Name = "colNumero_fiche";
            this.colNumero_fiche.ReadOnly = true;
            // 
            // colId_airsante
            // 
            this.colId_airsante.DataPropertyName = "Id_airsante";
            this.colId_airsante.HeaderText = "Id_airsante";
            this.colId_airsante.Name = "colId_airsante";
            this.colId_airsante.ReadOnly = true;
            this.colId_airsante.Visible = false;
            this.colId_airsante.Width = 84;
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
            // colId_profession
            // 
            this.colId_profession.DataPropertyName = "Id_profession";
            this.colId_profession.HeaderText = "Id_profession";
            this.colId_profession.Name = "colId_profession";
            this.colId_profession.ReadOnly = true;
            this.colId_profession.Visible = false;
            this.colId_profession.Width = 95;
            // 
            // colId_groupesanguin
            // 
            this.colId_groupesanguin.DataPropertyName = "Id_groupesanguin";
            this.colId_groupesanguin.HeaderText = "Id_groupesanguin";
            this.colId_groupesanguin.Name = "colId_groupesanguin";
            this.colId_groupesanguin.ReadOnly = true;
            this.colId_groupesanguin.Visible = false;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "IdMal";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            this.colID.Width = 43;
            // 
            // colid1
            // 
            this.colid1.DataPropertyName = "id";
            this.colid1.HeaderText = "id";
            this.colid1.Name = "colid1";
            this.colid1.ReadOnly = true;
            this.colid1.Visible = false;
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
            // lblAddProfession
            // 
            this.lblAddProfession.BackColor = System.Drawing.Color.Transparent;
            this.lblAddProfession.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAddProfession.Location = new System.Drawing.Point(374, 403);
            this.lblAddProfession.Name = "lblAddProfession";
            this.lblAddProfession.Size = new System.Drawing.Size(25, 21);
            this.lblAddProfession.TabIndex = 214;
            this.lblAddProfession.Click += new System.EventHandler(this.lblAddProfession_Click);
            // 
            // cboProfession
            // 
            this.cboProfession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfession.FormattingEnabled = true;
            this.cboProfession.Location = new System.Drawing.Point(156, 403);
            this.cboProfession.Name = "cboProfession";
            this.cboProfession.Size = new System.Drawing.Size(217, 21);
            this.cboProfession.TabIndex = 213;
            this.cboProfession.DropDown += new System.EventHandler(this.cboProfession_DropDown);
            // 
            // txtAge
            // 
            this.txtAge.Enabled = false;
            this.txtAge.Location = new System.Drawing.Point(156, 352);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(216, 20);
            this.txtAge.TabIndex = 249;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(9, 356);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 13);
            this.label19.TabIndex = 248;
            this.label19.Text = "Age :";
            // 
            // txtAdresse
            // 
            this.txtAdresse.Enabled = false;
            this.txtAdresse.Location = new System.Drawing.Point(157, 312);
            this.txtAdresse.Multiline = true;
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(215, 35);
            this.txtAdresse.TabIndex = 247;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(8, 314);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 246;
            this.label18.Text = "Adresse :";
            // 
            // lblGpSanguin
            // 
            this.lblGpSanguin.BackColor = System.Drawing.Color.Transparent;
            this.lblGpSanguin.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblGpSanguin.Location = new System.Drawing.Point(375, 483);
            this.lblGpSanguin.Name = "lblGpSanguin";
            this.lblGpSanguin.Size = new System.Drawing.Size(25, 21);
            this.lblGpSanguin.TabIndex = 221;
            this.lblGpSanguin.Click += new System.EventHandler(this.lblGpSanguin_Click);
            // 
            // cboGpSanguin
            // 
            this.cboGpSanguin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGpSanguin.FormattingEnabled = true;
            this.cboGpSanguin.Location = new System.Drawing.Point(157, 483);
            this.cboGpSanguin.Name = "cboGpSanguin";
            this.cboGpSanguin.Size = new System.Drawing.Size(216, 21);
            this.cboGpSanguin.TabIndex = 220;
            this.cboGpSanguin.DropDown += new System.EventHandler(this.cboGpSanguin_DropDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(7, 488);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 245;
            this.label13.Text = "Groupe sanguin :";
            // 
            // lblAddPersonne
            // 
            this.lblAddPersonne.BackColor = System.Drawing.Color.Transparent;
            this.lblAddPersonne.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAddPersonne.Location = new System.Drawing.Point(377, 93);
            this.lblAddPersonne.Name = "lblAddPersonne";
            this.lblAddPersonne.Size = new System.Drawing.Size(25, 21);
            this.lblAddPersonne.TabIndex = 244;
            this.lblAddPersonne.Click += new System.EventHandler(this.lblAddPersonne_Click);
            // 
            // txtIdPers
            // 
            this.txtIdPers.Location = new System.Drawing.Point(407, 262);
            this.txtIdPers.Name = "txtIdPers";
            this.txtIdPers.Size = new System.Drawing.Size(111, 20);
            this.txtIdPers.TabIndex = 243;
            this.txtIdPers.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.LavenderBlush;
            this.label17.ForeColor = System.Drawing.Color.Crimson;
            this.label17.Location = new System.Drawing.Point(7, 97);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(143, 13);
            this.label17.TabIndex = 242;
            this.label17.Text = "Sélection malade/personne :";
            // 
            // txtSexe
            // 
            this.txtSexe.Enabled = false;
            this.txtSexe.Location = new System.Drawing.Point(157, 288);
            this.txtSexe.Name = "txtSexe";
            this.txtSexe.Size = new System.Drawing.Size(215, 20);
            this.txtSexe.TabIndex = 241;
            // 
            // txtEtatCivil
            // 
            this.txtEtatCivil.Enabled = false;
            this.txtEtatCivil.Location = new System.Drawing.Point(157, 265);
            this.txtEtatCivil.Name = "txtEtatCivil";
            this.txtEtatCivil.Size = new System.Drawing.Size(216, 20);
            this.txtEtatCivil.TabIndex = 240;
            // 
            // txtDateNaissance
            // 
            this.txtDateNaissance.Enabled = false;
            this.txtDateNaissance.Location = new System.Drawing.Point(157, 218);
            this.txtDateNaissance.Name = "txtDateNaissance";
            this.txtDateNaissance.Size = new System.Drawing.Size(216, 20);
            this.txtDateNaissance.TabIndex = 212;
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(591, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 67;
            this.label14.Text = "Rechercher :";
            this.label14.Visible = false;
            // 
            // lblOrganisationPriseCharge
            // 
            this.lblOrganisationPriseCharge.BackColor = System.Drawing.Color.Transparent;
            this.lblOrganisationPriseCharge.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblOrganisationPriseCharge.Location = new System.Drawing.Point(375, 430);
            this.lblOrganisationPriseCharge.Name = "lblOrganisationPriseCharge";
            this.lblOrganisationPriseCharge.Size = new System.Drawing.Size(25, 21);
            this.lblOrganisationPriseCharge.TabIndex = 217;
            this.lblOrganisationPriseCharge.Click += new System.EventHandler(this.lblOrganisationPriseCharge_Click);
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
            // lblAirSante
            // 
            this.lblAirSante.BackColor = System.Drawing.Color.Transparent;
            this.lblAirSante.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAirSante.Location = new System.Drawing.Point(375, 456);
            this.lblAirSante.Name = "lblAirSante";
            this.lblAirSante.Size = new System.Drawing.Size(25, 21);
            this.lblAirSante.TabIndex = 219;
            this.lblAirSante.Click += new System.EventHandler(this.lblAirSante_Click);
            // 
            // cboAireSante
            // 
            this.cboAireSante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAireSante.FormattingEnabled = true;
            this.cboAireSante.Location = new System.Drawing.Point(157, 456);
            this.cboAireSante.Name = "cboAireSante";
            this.cboAireSante.Size = new System.Drawing.Size(216, 21);
            this.cboAireSante.TabIndex = 218;
            this.cboAireSante.DropDown += new System.EventHandler(this.cboAireSante_DropDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(7, 460);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 237;
            this.label12.Text = "Aire de santé :";
            // 
            // lblAddCategorie
            // 
            this.lblAddCategorie.BackColor = System.Drawing.Color.Transparent;
            this.lblAddCategorie.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAddCategorie.Location = new System.Drawing.Point(374, 377);
            this.lblAddCategorie.Name = "lblAddCategorie";
            this.lblAddCategorie.Size = new System.Drawing.Size(25, 21);
            this.lblAddCategorie.TabIndex = 210;
            this.lblAddCategorie.Click += new System.EventHandler(this.lblAddCategorie_Click);
            // 
            // cboEtablissement
            // 
            this.cboEtablissement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEtablissement.FormattingEnabled = true;
            this.cboEtablissement.Location = new System.Drawing.Point(157, 429);
            this.cboEtablissement.Name = "cboEtablissement";
            this.cboEtablissement.Size = new System.Drawing.Size(216, 21);
            this.cboEtablissement.TabIndex = 216;
            this.cboEtablissement.DropDown += new System.EventHandler(this.cboEtablissement_DropDown);
            // 
            // btnAfficherDonnees
            // 
            this.btnAfficherDonnees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficherDonnees.ForeColor = System.Drawing.Color.Green;
            this.btnAfficherDonnees.Location = new System.Drawing.Point(157, 16);
            this.btnAfficherDonnees.Name = "btnAfficherDonnees";
            this.btnAfficherDonnees.Size = new System.Drawing.Size(59, 23);
            this.btnAfficherDonnees.TabIndex = 366;
            this.btnAfficherDonnees.Text = "Afficher";
            this.btnAfficherDonnees.UseVisualStyleBackColor = true;
            this.btnAfficherDonnees.Click += new System.EventHandler(this.btnAfficherDonnees_Click);
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
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(229, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 13);
            this.label20.TabIndex = 207;
            this.label20.Text = "Numéro Fiche :";
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(436, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 23);
            this.label16.TabIndex = 238;
            this.label16.Text = "Malade";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSeach
            // 
            this.txtSeach.Location = new System.Drawing.Point(666, 16);
            this.txtSeach.Name = "txtSeach";
            this.txtSeach.Size = new System.Drawing.Size(240, 20);
            this.txtSeach.TabIndex = 9;
            this.txtSeach.Visible = false;
            this.txtSeach.TextChanged += new System.EventHandler(this.txtSeach_TextChanged);
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
            // txtNumeroFiche
            // 
            this.txtNumeroFiche.Enabled = false;
            this.txtNumeroFiche.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroFiche.ForeColor = System.Drawing.Color.Black;
            this.txtNumeroFiche.Location = new System.Drawing.Point(313, 17);
            this.txtNumeroFiche.Name = "txtNumeroFiche";
            this.txtNumeroFiche.Size = new System.Drawing.Size(216, 21);
            this.txtNumeroFiche.TabIndex = 206;
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
            // pbPhotoPersonne
            // 
            this.pbPhotoPersonne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhotoPersonne.InitialImage = null;
            this.pbPhotoPersonne.Location = new System.Drawing.Point(406, 94);
            this.pbPhotoPersonne.Name = "pbPhotoPersonne";
            this.pbPhotoPersonne.Size = new System.Drawing.Size(124, 138);
            this.pbPhotoPersonne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhotoPersonne.TabIndex = 230;
            this.pbPhotoPersonne.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(7, 432);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(151, 13);
            this.label10.TabIndex = 236;
            this.label10.Text = "Entreprise de prise en charge :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(8, 407);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 235;
            this.label7.Text = "Profession :";
            // 
            // cboCategorie
            // 
            this.cboCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategorie.FormattingEnabled = true;
            this.cboCategorie.Location = new System.Drawing.Point(156, 377);
            this.cboCategorie.Name = "cboCategorie";
            this.cboCategorie.Size = new System.Drawing.Size(217, 21);
            this.cboCategorie.TabIndex = 209;
            this.cboCategorie.SelectedIndexChanged += new System.EventHandler(this.cboCategorie_SelectedIndexChanged);
            this.cboCategorie.DropDown += new System.EventHandler(this.cboCategorie_DropDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(8, 380);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 234;
            this.label9.Text = "Catégorie :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 140;
            this.label2.Text = "Affichage du malade";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(539, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 33);
            this.panel1.TabIndex = 233;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(8, 267);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 232;
            this.label15.Text = "Etat civil :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(8, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 231;
            this.label5.Text = "Sexe :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(8, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 229;
            this.label6.Text = "Numéro :";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(157, 120);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(216, 20);
            this.txtNumero.TabIndex = 222;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(8, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 228;
            this.label1.Text = "Télephone :";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Enabled = false;
            this.txtTelephone.Location = new System.Drawing.Point(157, 242);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(216, 20);
            this.txtTelephone.TabIndex = 215;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(8, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 227;
            this.label8.Text = "Date naissance :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(8, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 226;
            this.label11.Text = "Nom :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(8, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 225;
            this.label4.Text = "Prénom :";
            // 
            // txtNom
            // 
            this.txtNom.Enabled = false;
            this.txtNom.Location = new System.Drawing.Point(157, 145);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(216, 20);
            this.txtNom.TabIndex = 207;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(8, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 224;
            this.label3.Text = "Post - nom :";
            // 
            // txtPNom
            // 
            this.txtPNom.Enabled = false;
            this.txtPNom.Location = new System.Drawing.Point(156, 170);
            this.txtPNom.Name = "txtPNom";
            this.txtPNom.Size = new System.Drawing.Size(217, 20);
            this.txtPNom.TabIndex = 208;
            // 
            // txtPrenom
            // 
            this.txtPrenom.Enabled = false;
            this.txtPrenom.Location = new System.Drawing.Point(157, 194);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(216, 20);
            this.txtPrenom.TabIndex = 211;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAfficherDonnees);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtSeach);
            this.groupBox1.Controls.Add(this.txtNumeroFiche);
            this.groupBox1.Controls.Add(this.bnvCandidat);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(0, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 42);
            this.groupBox1.TabIndex = 223;
            this.groupBox1.TabStop = false;
            // 
            // FrmMalade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.img_home_player_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(915, 542);
            this.Controls.Add(this.txtPersonne);
            this.Controls.Add(this.dgvMalade);
            this.Controls.Add(this.lblAddProfession);
            this.Controls.Add(this.cboProfession);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtAdresse);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblGpSanguin);
            this.Controls.Add(this.cboGpSanguin);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblAddPersonne);
            this.Controls.Add(this.txtIdPers);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtSexe);
            this.Controls.Add(this.txtEtatCivil);
            this.Controls.Add(this.txtDateNaissance);
            this.Controls.Add(this.lblOrganisationPriseCharge);
            this.Controls.Add(this.lblAirSante);
            this.Controls.Add(this.cboAireSante);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblAddCategorie);
            this.Controls.Add(this.cboEtablissement);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.pbPhotoPersonne);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboCategorie);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPNom);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmMalade";
            this.Text = "Malade";
            this.Load += new System.EventHandler(this.FrmMalade_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMalade_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCandidat)).EndInit();
            this.bnvCandidat.ResumeLayout(false);
            this.bnvCandidat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhotoPersonne)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colTelephone;
        private System.Windows.Forms.TextBox txtPersonne;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatenaissance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_etablissement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_categoriemalade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEtatcivil;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidMal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSexe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.OpenFileDialog dlgFile;
        private System.Windows.Forms.DataGridView dgvMalade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom_complet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero_fiche;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_airsante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_personne;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_profession;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_groupesanguin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoto;
        private System.Windows.Forms.Label lblAddProfession;
        private System.Windows.Forms.ComboBox cboProfession;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtAdresse;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblGpSanguin;
        private System.Windows.Forms.ComboBox cboGpSanguin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblAddPersonne;
        private System.Windows.Forms.TextBox txtIdPers;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtSexe;
        private System.Windows.Forms.TextBox txtEtatCivil;
        private System.Windows.Forms.DateTimePicker txtDateNaissance;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblOrganisationPriseCharge;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.Label lblAirSante;
        private System.Windows.Forms.ComboBox cboAireSante;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAddCategorie;
        private System.Windows.Forms.ComboBox cboEtablissement;
        private System.Windows.Forms.Button btnAfficherDonnees;
        private System.Windows.Forms.ToolStripButton btnRefreh;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSeach;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.TextBox txtNumeroFiche;
        private System.Windows.Forms.BindingNavigator bnvCandidat;
        private System.Windows.Forms.PictureBox pbPhotoPersonne;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboCategorie;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPNom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}