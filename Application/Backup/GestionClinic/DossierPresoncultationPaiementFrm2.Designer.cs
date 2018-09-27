namespace GestionClinic_WIN
{
    partial class FrmDossierPreconsultationPaiement2
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cboTypeFiche = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtEtatPaiement = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.lstDossierEncCours = new System.Windows.Forms.ListBox();
            this.bdNav = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAddDossier = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshDossier = new System.Windows.Forms.ToolStripButton();
            this.btnSaveDossier = new System.Windows.Forms.ToolStripButton();
            this.label39 = new System.Windows.Forms.Label();
            this.txtDateOuvertureDossier = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gpFicheSupple = new System.Windows.Forms.GroupBox();
            this.cmdDeleteFicheSup = new System.Windows.Forms.Button();
            this.txtEtatPaiement2 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.lstFicheAdd = new System.Windows.Forms.ListBox();
            this.cmdAjouter = new System.Windows.Forms.Button();
            this.txtDateAjout = new System.Windows.Forms.DateTimePicker();
            this.label31 = new System.Windows.Forms.Label();
            this.cboTypeFiche2 = new System.Windows.Forms.ComboBox();
            this.cmdSaveFicheSup = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAddTarif = new System.Windows.Forms.Label();
            this.cboTypeFiche1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEtatPaiement1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstDossierEncCours1 = new System.Windows.Forms.ListBox();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDateOuvertureDossier1 = new System.Windows.Forms.DateTimePicker();
            this.txtIdMalade = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bdNav)).BeginInit();
            this.bdNav.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gpFicheSupple.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboTypeFiche
            // 
            this.cboTypeFiche.FormattingEnabled = true;
            this.cboTypeFiche.Location = new System.Drawing.Point(316, 32);
            this.cboTypeFiche.Name = "cboTypeFiche";
            this.cboTypeFiche.Size = new System.Drawing.Size(160, 21);
            this.cboTypeFiche.TabIndex = 68;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(319, 16);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(60, 13);
            this.label40.TabIndex = 437;
            this.label40.Text = "Type Fiche";
            // 
            // txtEtatPaiement
            // 
            this.txtEtatPaiement.Enabled = false;
            this.txtEtatPaiement.Location = new System.Drawing.Point(482, 33);
            this.txtEtatPaiement.Name = "txtEtatPaiement";
            this.txtEtatPaiement.Size = new System.Drawing.Size(136, 20);
            this.txtEtatPaiement.TabIndex = 436;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.ForeColor = System.Drawing.Color.Black;
            this.label38.Location = new System.Drawing.Point(624, 1);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(134, 13);
            this.label38.TabIndex = 435;
            this.label38.Text = "Référence Date ouverture ";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(485, 17);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(101, 13);
            this.label37.TabIndex = 433;
            this.label37.Text = "Etat paiement Fiche";
            // 
            // lstDossierEncCours
            // 
            this.lstDossierEncCours.FormattingEnabled = true;
            this.lstDossierEncCours.Location = new System.Drawing.Point(621, 17);
            this.lstDossierEncCours.Name = "lstDossierEncCours";
            this.lstDossierEncCours.Size = new System.Drawing.Size(241, 43);
            this.lstDossierEncCours.TabIndex = 430;
            // 
            // bdNav
            // 
            this.bdNav.AddNewItem = null;
            this.bdNav.AutoSize = false;
            this.bdNav.BackColor = System.Drawing.Color.Transparent;
            this.bdNav.CountItem = null;
            this.bdNav.DeleteItem = null;
            this.bdNav.Dock = System.Windows.Forms.DockStyle.None;
            this.bdNav.Enabled = false;
            this.bdNav.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bdNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddDossier,
            this.btnRefreshDossier,
            this.btnSaveDossier});
            this.bdNav.Location = new System.Drawing.Point(3, -1);
            this.bdNav.MoveFirstItem = null;
            this.bdNav.MoveLastItem = null;
            this.bdNav.MoveNextItem = null;
            this.bdNav.MovePreviousItem = null;
            this.bdNav.Name = "bdNav";
            this.bdNav.PositionItem = null;
            this.bdNav.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bdNav.Size = new System.Drawing.Size(136, 27);
            this.bdNav.TabIndex = 297;
            this.bdNav.Text = "bdNav";
            // 
            // btnAddDossier
            // 
            this.btnAddDossier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddDossier.Image = global::GestionClinic_WIN.Properties.Resources.navBarAddIcon_2x;
            this.btnAddDossier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDossier.Name = "btnAddDossier";
            this.btnAddDossier.Size = new System.Drawing.Size(23, 24);
            this.btnAddDossier.Text = "Ajouter";
            // 
            // btnRefreshDossier
            // 
            this.btnRefreshDossier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshDossier.Image = global::GestionClinic_WIN.Properties.Resources.update;
            this.btnRefreshDossier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshDossier.Name = "btnRefreshDossier";
            this.btnRefreshDossier.Size = new System.Drawing.Size(23, 24);
            this.btnRefreshDossier.Text = "Refresh";
            this.btnRefreshDossier.ToolTipText = "Actualiser";
            // 
            // btnSaveDossier
            // 
            this.btnSaveDossier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveDossier.Image = global::GestionClinic_WIN.Properties.Resources.check_2x;
            this.btnSaveDossier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveDossier.Name = "btnSaveDossier";
            this.btnSaveDossier.Size = new System.Drawing.Size(23, 24);
            this.btnSaveDossier.Text = "Mis à jour";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(6, 35);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(143, 13);
            this.label39.TabIndex = 428;
            this.label39.Text = "Date d\'ouverture du dossier :";
            // 
            // txtDateOuvertureDossier
            // 
            this.txtDateOuvertureDossier.Location = new System.Drawing.Point(149, 33);
            this.txtDateOuvertureDossier.Name = "txtDateOuvertureDossier";
            this.txtDateOuvertureDossier.Size = new System.Drawing.Size(161, 20);
            this.txtDateOuvertureDossier.TabIndex = 429;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(2, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(617, 311);
            this.tabControl1.TabIndex = 436;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.gpFicheSupple);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtPrix);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lblAddTarif);
            this.tabPage1.Controls.Add(this.cboTypeFiche1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtEtatPaiement1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lstDossierEncCours1);
            this.tabPage1.Controls.Add(this.bindingNavigator1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtDateOuvertureDossier1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(609, 285);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Fiche";
            // 
            // gpFicheSupple
            // 
            this.gpFicheSupple.Controls.Add(this.cmdDeleteFicheSup);
            this.gpFicheSupple.Controls.Add(this.txtEtatPaiement2);
            this.gpFicheSupple.Controls.Add(this.label30);
            this.gpFicheSupple.Controls.Add(this.lstFicheAdd);
            this.gpFicheSupple.Controls.Add(this.cmdAjouter);
            this.gpFicheSupple.Controls.Add(this.txtDateAjout);
            this.gpFicheSupple.Controls.Add(this.label31);
            this.gpFicheSupple.Controls.Add(this.cboTypeFiche2);
            this.gpFicheSupple.Controls.Add(this.cmdSaveFicheSup);
            this.gpFicheSupple.Location = new System.Drawing.Point(6, 144);
            this.gpFicheSupple.Name = "gpFicheSupple";
            this.gpFicheSupple.Size = new System.Drawing.Size(595, 131);
            this.gpFicheSupple.TabIndex = 452;
            this.gpFicheSupple.TabStop = false;
            this.gpFicheSupple.Text = "Fiches supplémentaires";
            // 
            // cmdDeleteFicheSup
            // 
            this.cmdDeleteFicheSup.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.cmdDeleteFicheSup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDeleteFicheSup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdDeleteFicheSup.ForeColor = System.Drawing.Color.Crimson;
            this.cmdDeleteFicheSup.Location = new System.Drawing.Point(160, 27);
            this.cmdDeleteFicheSup.Name = "cmdDeleteFicheSup";
            this.cmdDeleteFicheSup.Size = new System.Drawing.Size(76, 24);
            this.cmdDeleteFicheSup.TabIndex = 451;
            this.cmdDeleteFicheSup.Text = "Supprimer";
            this.cmdDeleteFicheSup.UseVisualStyleBackColor = false;
            this.cmdDeleteFicheSup.Click += new System.EventHandler(this.cmdDeleteFicheSup_Click);
            // 
            // txtEtatPaiement2
            // 
            this.txtEtatPaiement2.BackColor = System.Drawing.Color.White;
            this.txtEtatPaiement2.ForeColor = System.Drawing.Color.Black;
            this.txtEtatPaiement2.Location = new System.Drawing.Point(153, 3);
            this.txtEtatPaiement2.Name = "txtEtatPaiement2";
            this.txtEtatPaiement2.Size = new System.Drawing.Size(95, 20);
            this.txtEtatPaiement2.TabIndex = 441;
            this.txtEtatPaiement2.Visible = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(5, 68);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(36, 13);
            this.label30.TabIndex = 449;
            this.label30.Text = "Date :";
            // 
            // lstFicheAdd
            // 
            this.lstFicheAdd.FormattingEnabled = true;
            this.lstFicheAdd.Location = new System.Drawing.Point(243, 25);
            this.lstFicheAdd.Name = "lstFicheAdd";
            this.lstFicheAdd.Size = new System.Drawing.Size(343, 95);
            this.lstFicheAdd.TabIndex = 448;
            this.lstFicheAdd.SelectedIndexChanged += new System.EventHandler(this.lstFicheAdd_SelectedIndexChanged);
            // 
            // cmdAjouter
            // 
            this.cmdAjouter.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.cmdAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAjouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdAjouter.ForeColor = System.Drawing.Color.Blue;
            this.cmdAjouter.Location = new System.Drawing.Point(4, 27);
            this.cmdAjouter.Name = "cmdAjouter";
            this.cmdAjouter.Size = new System.Drawing.Size(70, 24);
            this.cmdAjouter.TabIndex = 444;
            this.cmdAjouter.Text = "Ajouter";
            this.cmdAjouter.UseVisualStyleBackColor = false;
            this.cmdAjouter.Click += new System.EventHandler(this.cmdAjouter_Click);
            // 
            // txtDateAjout
            // 
            this.txtDateAjout.Location = new System.Drawing.Point(74, 64);
            this.txtDateAjout.Name = "txtDateAjout";
            this.txtDateAjout.Size = new System.Drawing.Size(163, 20);
            this.txtDateAjout.TabIndex = 445;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(4, 103);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(66, 13);
            this.label31.TabIndex = 450;
            this.label31.Text = "Type Fiche :";
            // 
            // cboTypeFiche2
            // 
            this.cboTypeFiche2.FormattingEnabled = true;
            this.cboTypeFiche2.Location = new System.Drawing.Point(74, 100);
            this.cboTypeFiche2.Name = "cboTypeFiche2";
            this.cboTypeFiche2.Size = new System.Drawing.Size(163, 21);
            this.cboTypeFiche2.TabIndex = 446;
            this.cboTypeFiche2.SelectedIndexChanged += new System.EventHandler(this.cboTypeFiche2_SelectedIndexChanged);
            // 
            // cmdSaveFicheSup
            // 
            this.cmdSaveFicheSup.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.cmdSaveFicheSup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSaveFicheSup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmdSaveFicheSup.ForeColor = System.Drawing.Color.DarkGreen;
            this.cmdSaveFicheSup.Location = new System.Drawing.Point(79, 27);
            this.cmdSaveFicheSup.Name = "cmdSaveFicheSup";
            this.cmdSaveFicheSup.Size = new System.Drawing.Size(76, 24);
            this.cmdSaveFicheSup.TabIndex = 447;
            this.cmdSaveFicheSup.Text = "Mettre à jour";
            this.cmdSaveFicheSup.UseVisualStyleBackColor = false;
            this.cmdSaveFicheSup.Click += new System.EventHandler(this.cmdSaveFicheSup_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(318, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 441;
            this.label6.Text = "$ US :";
            // 
            // txtPrix
            // 
            this.txtPrix.Enabled = false;
            this.txtPrix.Location = new System.Drawing.Point(157, 93);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(160, 20);
            this.txtPrix.TabIndex = 440;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 439;
            this.label5.Text = "Prix :";
            // 
            // lblAddTarif
            // 
            this.lblAddTarif.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAddTarif.Location = new System.Drawing.Point(320, 65);
            this.lblAddTarif.Name = "lblAddTarif";
            this.lblAddTarif.Size = new System.Drawing.Size(25, 22);
            this.lblAddTarif.TabIndex = 438;
            this.lblAddTarif.Click += new System.EventHandler(this.lblAddTarif_Click);
            // 
            // cboTypeFiche1
            // 
            this.cboTypeFiche1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTypeFiche1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTypeFiche1.FormattingEnabled = true;
            this.cboTypeFiche1.Location = new System.Drawing.Point(157, 66);
            this.cboTypeFiche1.Name = "cboTypeFiche1";
            this.cboTypeFiche1.Size = new System.Drawing.Size(160, 21);
            this.cboTypeFiche1.TabIndex = 68;
            this.cboTypeFiche1.SelectedIndexChanged += new System.EventHandler(this.cboTypeFiche1_SelectedIndexChanged);
            this.cboTypeFiche1.DropDown += new System.EventHandler(this.cboTypeFiche1_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 437;
            this.label1.Text = "Type Fiche :";
            // 
            // txtEtatPaiement1
            // 
            this.txtEtatPaiement1.Enabled = false;
            this.txtEtatPaiement1.Location = new System.Drawing.Point(157, 118);
            this.txtEtatPaiement1.Name = "txtEtatPaiement1";
            this.txtEtatPaiement1.Size = new System.Drawing.Size(160, 20);
            this.txtEtatPaiement1.TabIndex = 436;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(360, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 435;
            this.label2.Text = "Référence Date ouverture ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 433;
            this.label3.Text = "Etat paiement Fiche :";
            // 
            // lstDossierEncCours1
            // 
            this.lstDossierEncCours1.FormattingEnabled = true;
            this.lstDossierEncCours1.Location = new System.Drawing.Point(362, 41);
            this.lstDossierEncCours1.Name = "lstDossierEncCours1";
            this.lstDossierEncCours1.Size = new System.Drawing.Size(239, 95);
            this.lstDossierEncCours1.TabIndex = 430;
            this.lstDossierEncCours1.SelectedIndexChanged += new System.EventHandler(this.lstDossierEncCours1_SelectedIndexChanged);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.AutoSize = false;
            this.bindingNavigator1.BackColor = System.Drawing.Color.Transparent;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Enabled = false;
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnRefresh,
            this.btnSave,
            this.btnClose,
            this.btnDelete});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 3);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNavigator1.Size = new System.Drawing.Size(603, 27);
            this.bindingNavigator1.TabIndex = 297;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::GestionClinic_WIN.Properties.Resources.navBarAddIcon_2x;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 24);
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::GestionClinic_WIN.Properties.Resources.update;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 24);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.ToolTipText = "Actualiser";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::GestionClinic_WIN.Properties.Resources.check_2x;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 24);
            this.btnSave.Text = "Mis à jour";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = global::GestionClinic_WIN.Properties.Resources.Close1;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 24);
            this.btnClose.Text = "toolStripButton1";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::GestionClinic_WIN.Properties.Resources.mp_delete_md_n_lt_2x;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 24);
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 428;
            this.label4.Text = "Date d\'ouverture du dossier :";
            // 
            // txtDateOuvertureDossier1
            // 
            this.txtDateOuvertureDossier1.Location = new System.Drawing.Point(157, 40);
            this.txtDateOuvertureDossier1.Name = "txtDateOuvertureDossier1";
            this.txtDateOuvertureDossier1.Size = new System.Drawing.Size(161, 20);
            this.txtDateOuvertureDossier1.TabIndex = 429;
            // 
            // txtIdMalade
            // 
            this.txtIdMalade.Location = new System.Drawing.Point(564, 324);
            this.txtIdMalade.Name = "txtIdMalade";
            this.txtIdMalade.Size = new System.Drawing.Size(100, 20);
            this.txtIdMalade.TabIndex = 440;
            // 
            // FrmDossierPreconsultationPaiement2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.txtIdMalade);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Name = "FrmDossierPreconsultationPaiement2";
            this.Size = new System.Drawing.Size(619, 324);
            this.Load += new System.EventHandler(this.frmDossierPresoncultationPaiement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdNav)).EndInit();
            this.bdNav.ResumeLayout(false);
            this.bdNav.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gpFicheSupple.ResumeLayout(false);
            this.gpFicheSupple.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTypeFiche;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtEtatPaiement;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.ListBox lstDossierEncCours;
        private System.Windows.Forms.BindingNavigator bdNav;
        private System.Windows.Forms.ToolStripButton btnAddDossier;
        private System.Windows.Forms.ToolStripButton btnRefreshDossier;
        private System.Windows.Forms.ToolStripButton btnSaveDossier;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.DateTimePicker txtDateOuvertureDossier;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cboTypeFiche1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEtatPaiement1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstDossierEncCours1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtDateOuvertureDossier1;
        private System.Windows.Forms.TextBox txtIdMalade;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Label lblAddTarif;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gpFicheSupple;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DateTimePicker txtDateAjout;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox cboTypeFiche2;
        private System.Windows.Forms.Button cmdAjouter;
        private System.Windows.Forms.ListBox lstFicheAdd;
        private System.Windows.Forms.Button cmdSaveFicheSup;
        private System.Windows.Forms.TextBox txtEtatPaiement2;
        private System.Windows.Forms.Button cmdDeleteFicheSup;
    }
}
