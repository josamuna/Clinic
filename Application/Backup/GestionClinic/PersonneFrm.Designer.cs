namespace GestionClinic_WIN
{
    partial class PersonneFrm
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
            this.dlgFile = new System.Windows.Forms.OpenFileDialog();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSexe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEtatcivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatenaissance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comAdresse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhoto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSeach = new System.Windows.Forms.TextBox();
            this.btnRefreh = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.bnvCandidat = new System.Windows.Forms.BindingNavigator(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchPersonne = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtDateNaissance = new System.Windows.Forms.DateTimePicker();
            this.lblLoadPhoto = new System.Windows.Forms.LinkLabel();
            this.pbPhotoPersonne = new System.Windows.Forms.PictureBox();
            this.cboEtatCiv = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboSexe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.gpSupprimerRepertoire = new System.Windows.Forms.GroupBox();
            this.cmdDeleteItems = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdWebCamPicture = new System.Windows.Forms.RadioButton();
            this.rdLocalPicture = new System.Windows.Forms.RadioButton();
            this.gpWebCam = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdEffacer = new System.Windows.Forms.Button();
            this.cmdArreter = new System.Windows.Forms.Button();
            this.cmdRepertoire = new System.Windows.Forms.Button();
            this.cmdEnregistrer = new System.Windows.Forms.Button();
            this.cmdCapturer = new System.Windows.Forms.Button();
            this.pbCapture = new System.Windows.Forms.PictureBox();
            this.label18 = new System.Windows.Forms.Label();
            this.picturePreview = new System.Windows.Forms.PictureBox();
            this.cmdAppliquer = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cboAudioSource = new System.Windows.Forms.ComboBox();
            this.cboVideoSource = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAdresse = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCandidat)).BeginInit();
            this.bnvCandidat.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhotoPersonne)).BeginInit();
            this.gpSupprimerRepertoire.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gpWebCam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // dlgFile
            // 
            this.dlgFile.FileName = "openFileDialog1";
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
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNom,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.colSexe,
            this.colEtatcivil,
            this.colDatenaissance,
            this.colTelephone,
            this.comAdresse,
            this.dataGridViewTextBoxColumn3,
            this.colPhoto});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgv.Location = new System.Drawing.Point(0, 377);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(770, 178);
            this.dgv.TabIndex = 212;
            this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
            // 
            // colNom
            // 
            this.colNom.DataPropertyName = "Nom";
            this.colNom.HeaderText = "Nom";
            this.colNom.Name = "colNom";
            this.colNom.ReadOnly = true;
            this.colNom.Width = 120;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Postnom";
            this.dataGridViewTextBoxColumn1.HeaderText = "Postnom";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Prenom";
            this.dataGridViewTextBoxColumn2.HeaderText = "Prénom";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // colSexe
            // 
            this.colSexe.DataPropertyName = "Sexe";
            this.colSexe.HeaderText = "Sexe";
            this.colSexe.Name = "colSexe";
            this.colSexe.ReadOnly = true;
            this.colSexe.Width = 60;
            // 
            // colEtatcivil
            // 
            this.colEtatcivil.DataPropertyName = "Etatcivil";
            this.colEtatcivil.HeaderText = "Etat civil";
            this.colEtatcivil.Name = "colEtatcivil";
            this.colEtatcivil.ReadOnly = true;
            // 
            // colDatenaissance
            // 
            this.colDatenaissance.DataPropertyName = "Datenaissance";
            this.colDatenaissance.HeaderText = "Date de naissance";
            this.colDatenaissance.Name = "colDatenaissance";
            this.colDatenaissance.ReadOnly = true;
            this.colDatenaissance.Width = 120;
            // 
            // colTelephone
            // 
            this.colTelephone.DataPropertyName = "Telephone";
            this.colTelephone.HeaderText = "Telephone";
            this.colTelephone.Name = "colTelephone";
            this.colTelephone.ReadOnly = true;
            this.colTelephone.Visible = false;
            this.colTelephone.Width = 120;
            // 
            // comAdresse
            // 
            this.comAdresse.DataPropertyName = "Adresse";
            this.comAdresse.HeaderText = "Adresse";
            this.comAdresse.Name = "comAdresse";
            this.comAdresse.ReadOnly = true;
            this.comAdresse.Width = 300;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn3.HeaderText = "ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // colPhoto
            // 
            this.colPhoto.DataPropertyName = "Photo";
            this.colPhoto.HeaderText = "Photo";
            this.colPhoto.Name = "colPhoto";
            this.colPhoto.ReadOnly = true;
            this.colPhoto.Visible = false;
            // 
            // txtSeach
            // 
            this.txtSeach.Location = new System.Drawing.Point(238, 16);
            this.txtSeach.Name = "txtSeach";
            this.txtSeach.Size = new System.Drawing.Size(60, 20);
            this.txtSeach.TabIndex = 19;
            this.txtSeach.Visible = false;
            this.txtSeach.TextChanged += new System.EventHandler(this.txtSeach_TextChanged);
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnSearchPersonne);
            this.groupBox1.Controls.Add(this.txtSeach);
            this.groupBox1.Controls.Add(this.bnvCandidat);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(3, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 42);
            this.groupBox1.TabIndex = 209;
            this.groupBox1.TabStop = false;
            // 
            // btnSearchPersonne
            // 
            this.btnSearchPersonne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchPersonne.ForeColor = System.Drawing.Color.Green;
            this.btnSearchPersonne.Location = new System.Drawing.Point(460, 14);
            this.btnSearchPersonne.Name = "btnSearchPersonne";
            this.btnSearchPersonne.Size = new System.Drawing.Size(145, 23);
            this.btnSearchPersonne.TabIndex = 368;
            this.btnSearchPersonne.Text = "Rechercher une personne";
            this.btnSearchPersonne.UseVisualStyleBackColor = true;
            this.btnSearchPersonne.Click += new System.EventHandler(this.btnSearchPersonne_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(170, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 67;
            this.label14.Text = "Rechercher :";
            this.label14.Visible = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(345, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 20);
            this.label10.TabIndex = 211;
            this.label10.Text = "Personne";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.bindingNavigator1.Size = new System.Drawing.Size(770, 25);
            this.bindingNavigator1.TabIndex = 210;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(113, 81);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(179, 20);
            this.txtNom.TabIndex = 0;
            // 
            // txtDateNaissance
            // 
            this.txtDateNaissance.Location = new System.Drawing.Point(113, 158);
            this.txtDateNaissance.Name = "txtDateNaissance";
            this.txtDateNaissance.Size = new System.Drawing.Size(179, 20);
            this.txtDateNaissance.TabIndex = 3;
            // 
            // lblLoadPhoto
            // 
            this.lblLoadPhoto.BackColor = System.Drawing.Color.Transparent;
            this.lblLoadPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadPhoto.Image = global::GestionClinic_WIN.Properties.Resources.PhotoIcon;
            this.lblLoadPhoto.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblLoadPhoto.Location = new System.Drawing.Point(324, 204);
            this.lblLoadPhoto.Name = "lblLoadPhoto";
            this.lblLoadPhoto.Size = new System.Drawing.Size(103, 50);
            this.lblLoadPhoto.TabIndex = 10;
            this.lblLoadPhoto.TabStop = true;
            this.lblLoadPhoto.Text = "Ajouter une photo";
            this.lblLoadPhoto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblLoadPhoto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLoadPhoto_LinkClicked);
            // 
            // pbPhotoPersonne
            // 
            this.pbPhotoPersonne.BackColor = System.Drawing.SystemColors.Control;
            this.pbPhotoPersonne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhotoPersonne.InitialImage = null;
            this.pbPhotoPersonne.Location = new System.Drawing.Point(314, 81);
            this.pbPhotoPersonne.Name = "pbPhotoPersonne";
            this.pbPhotoPersonne.Size = new System.Drawing.Size(127, 120);
            this.pbPhotoPersonne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhotoPersonne.TabIndex = 206;
            this.pbPhotoPersonne.TabStop = false;
            // 
            // cboEtatCiv
            // 
            this.cboEtatCiv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEtatCiv.FormattingEnabled = true;
            this.cboEtatCiv.Location = new System.Drawing.Point(113, 216);
            this.cboEtatCiv.Name = "cboEtatCiv";
            this.cboEtatCiv.Size = new System.Drawing.Size(125, 21);
            this.cboEtatCiv.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(12, 219);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 208;
            this.label15.Text = "Etat civil :";
            // 
            // cboSexe
            // 
            this.cboSexe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSexe.FormattingEnabled = true;
            this.cboSexe.Location = new System.Drawing.Point(113, 186);
            this.cboSexe.Name = "cboSexe";
            this.cboSexe.Size = new System.Drawing.Size(58, 21);
            this.cboSexe.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(12, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 207;
            this.label5.Text = "Sexe :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 205;
            this.label1.Text = "Téléphone :";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(113, 246);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(179, 20);
            this.txtTelephone.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(12, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 204;
            this.label8.Text = "Date naissance :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(9, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 203;
            this.label11.Text = "Nom :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 202;
            this.label4.Text = "Prénom :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(10, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 201;
            this.label3.Text = "Post - nom :";
            // 
            // txtPNom
            // 
            this.txtPNom.Location = new System.Drawing.Point(113, 105);
            this.txtPNom.Name = "txtPNom";
            this.txtPNom.Size = new System.Drawing.Size(179, 20);
            this.txtPNom.TabIndex = 1;
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(113, 132);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(179, 20);
            this.txtPrenom.TabIndex = 2;
            // 
            // gpSupprimerRepertoire
            // 
            this.gpSupprimerRepertoire.Controls.Add(this.cmdDeleteItems);
            this.gpSupprimerRepertoire.Location = new System.Drawing.Point(298, 320);
            this.gpSupprimerRepertoire.Name = "gpSupprimerRepertoire";
            this.gpSupprimerRepertoire.Size = new System.Drawing.Size(159, 49);
            this.gpSupprimerRepertoire.TabIndex = 214;
            this.gpSupprimerRepertoire.TabStop = false;
            this.gpSupprimerRepertoire.Text = "Supprimer contenu repertoire";
            // 
            // cmdDeleteItems
            // 
            this.cmdDeleteItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDeleteItems.BackColor = System.Drawing.Color.Linen;
            this.cmdDeleteItems.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdDeleteItems.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.cmdDeleteItems.Location = new System.Drawing.Point(34, 19);
            this.cmdDeleteItems.Name = "cmdDeleteItems";
            this.cmdDeleteItems.Size = new System.Drawing.Size(92, 24);
            this.cmdDeleteItems.TabIndex = 20;
            this.cmdDeleteItems.Text = "Supprime&r items";
            this.cmdDeleteItems.UseVisualStyleBackColor = false;
            this.cmdDeleteItems.Click += new System.EventHandler(this.cmdDeleteItems_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdWebCamPicture);
            this.groupBox2.Controls.Add(this.rdLocalPicture);
            this.groupBox2.Location = new System.Drawing.Point(15, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 49);
            this.groupBox2.TabIndex = 213;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sélection mode pour photo";
            // 
            // rdWebCamPicture
            // 
            this.rdWebCamPicture.AutoSize = true;
            this.rdWebCamPicture.ForeColor = System.Drawing.Color.SaddleBrown;
            this.rdWebCamPicture.Location = new System.Drawing.Point(117, 21);
            this.rdWebCamPicture.Name = "rdWebCamPicture";
            this.rdWebCamPicture.Size = new System.Drawing.Size(150, 17);
            this.rdWebCamPicture.TabIndex = 9;
            this.rdWebCamPicture.TabStop = true;
            this.rdWebCamPicture.Text = "Photo à partir du WebCam";
            this.rdWebCamPicture.UseVisualStyleBackColor = true;
            this.rdWebCamPicture.CheckedChanged += new System.EventHandler(this.rdWebCamPicture_CheckedChanged);
            // 
            // rdLocalPicture
            // 
            this.rdLocalPicture.AutoSize = true;
            this.rdLocalPicture.ForeColor = System.Drawing.Color.DarkMagenta;
            this.rdLocalPicture.Location = new System.Drawing.Point(7, 21);
            this.rdLocalPicture.Name = "rdLocalPicture";
            this.rdLocalPicture.Size = new System.Drawing.Size(84, 17);
            this.rdLocalPicture.TabIndex = 8;
            this.rdLocalPicture.TabStop = true;
            this.rdLocalPicture.Text = "Photo locale";
            this.rdLocalPicture.UseVisualStyleBackColor = true;
            this.rdLocalPicture.CheckedChanged += new System.EventHandler(this.rdLocalPicture_CheckedChanged);
            // 
            // gpWebCam
            // 
            this.gpWebCam.BackColor = System.Drawing.Color.Transparent;
            this.gpWebCam.Controls.Add(this.label2);
            this.gpWebCam.Controls.Add(this.cmdEffacer);
            this.gpWebCam.Controls.Add(this.cmdArreter);
            this.gpWebCam.Controls.Add(this.cmdRepertoire);
            this.gpWebCam.Controls.Add(this.cmdEnregistrer);
            this.gpWebCam.Controls.Add(this.cmdCapturer);
            this.gpWebCam.Controls.Add(this.pbCapture);
            this.gpWebCam.Controls.Add(this.label18);
            this.gpWebCam.Controls.Add(this.picturePreview);
            this.gpWebCam.Controls.Add(this.cmdAppliquer);
            this.gpWebCam.Controls.Add(this.label19);
            this.gpWebCam.Controls.Add(this.label20);
            this.gpWebCam.Controls.Add(this.cboAudioSource);
            this.gpWebCam.Controls.Add(this.cboVideoSource);
            this.gpWebCam.Location = new System.Drawing.Point(463, 69);
            this.gpWebCam.Name = "gpWebCam";
            this.gpWebCam.Size = new System.Drawing.Size(297, 299);
            this.gpWebCam.TabIndex = 215;
            this.gpWebCam.TabStop = false;
            this.gpWebCam.Text = "Manipulation WebCam";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(151, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "Prévisualisation";
            // 
            // cmdEffacer
            // 
            this.cmdEffacer.BackColor = System.Drawing.Color.White;
            this.cmdEffacer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEffacer.ForeColor = System.Drawing.Color.Navy;
            this.cmdEffacer.Location = new System.Drawing.Point(225, 263);
            this.cmdEffacer.Name = "cmdEffacer";
            this.cmdEffacer.Size = new System.Drawing.Size(64, 25);
            this.cmdEffacer.TabIndex = 17;
            this.cmdEffacer.Text = "Ini&tialiser";
            this.cmdEffacer.UseVisualStyleBackColor = false;
            this.cmdEffacer.Click += new System.EventHandler(this.cmdEffacer_Click);
            // 
            // cmdArreter
            // 
            this.cmdArreter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdArreter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdArreter.ForeColor = System.Drawing.Color.Crimson;
            this.cmdArreter.Location = new System.Drawing.Point(226, 73);
            this.cmdArreter.Name = "cmdArreter";
            this.cmdArreter.Size = new System.Drawing.Size(61, 24);
            this.cmdArreter.TabIndex = 14;
            this.cmdArreter.Text = "Eteind&re";
            this.cmdArreter.UseVisualStyleBackColor = true;
            this.cmdArreter.Click += new System.EventHandler(this.cmdArreter_Click);
            // 
            // cmdRepertoire
            // 
            this.cmdRepertoire.BackColor = System.Drawing.Color.White;
            this.cmdRepertoire.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdRepertoire.ForeColor = System.Drawing.Color.Navy;
            this.cmdRepertoire.Location = new System.Drawing.Point(152, 263);
            this.cmdRepertoire.Name = "cmdRepertoire";
            this.cmdRepertoire.Size = new System.Drawing.Size(67, 25);
            this.cmdRepertoire.TabIndex = 18;
            this.cmdRepertoire.Text = "&Repertoire";
            this.cmdRepertoire.UseVisualStyleBackColor = false;
            this.cmdRepertoire.Click += new System.EventHandler(this.cmdRepertoire_Click);
            // 
            // cmdEnregistrer
            // 
            this.cmdEnregistrer.BackColor = System.Drawing.Color.White;
            this.cmdEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdEnregistrer.ForeColor = System.Drawing.Color.Green;
            this.cmdEnregistrer.Location = new System.Drawing.Point(80, 263);
            this.cmdEnregistrer.Name = "cmdEnregistrer";
            this.cmdEnregistrer.Size = new System.Drawing.Size(65, 25);
            this.cmdEnregistrer.TabIndex = 16;
            this.cmdEnregistrer.Text = "&Récupérer";
            this.cmdEnregistrer.UseVisualStyleBackColor = false;
            this.cmdEnregistrer.Click += new System.EventHandler(this.cmdEnregistrer_Click);
            // 
            // cmdCapturer
            // 
            this.cmdCapturer.BackColor = System.Drawing.Color.White;
            this.cmdCapturer.Enabled = false;
            this.cmdCapturer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdCapturer.ForeColor = System.Drawing.Color.Navy;
            this.cmdCapturer.Location = new System.Drawing.Point(9, 263);
            this.cmdCapturer.Name = "cmdCapturer";
            this.cmdCapturer.Size = new System.Drawing.Size(64, 25);
            this.cmdCapturer.TabIndex = 15;
            this.cmdCapturer.Text = "Capt&urer";
            this.cmdCapturer.UseVisualStyleBackColor = false;
            this.cmdCapturer.Click += new System.EventHandler(this.cmdCapturer_Click);
            // 
            // pbCapture
            // 
            this.pbCapture.BackColor = System.Drawing.Color.White;
            this.pbCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCapture.Location = new System.Drawing.Point(152, 125);
            this.pbCapture.Name = "pbCapture";
            this.pbCapture.Size = new System.Drawing.Size(136, 129);
            this.pbCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCapture.TabIndex = 69;
            this.pbCapture.TabStop = false;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(9, 108);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Photo à capturer";
            // 
            // picturePreview
            // 
            this.picturePreview.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picturePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturePreview.Location = new System.Drawing.Point(9, 125);
            this.picturePreview.Name = "picturePreview";
            this.picturePreview.Size = new System.Drawing.Size(136, 129);
            this.picturePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturePreview.TabIndex = 7;
            this.picturePreview.TabStop = false;
            // 
            // cmdAppliquer
            // 
            this.cmdAppliquer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAppliquer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdAppliquer.ForeColor = System.Drawing.Color.Navy;
            this.cmdAppliquer.Location = new System.Drawing.Point(160, 73);
            this.cmdAppliquer.Name = "cmdAppliquer";
            this.cmdAppliquer.Size = new System.Drawing.Size(60, 24);
            this.cmdAppliquer.TabIndex = 13;
            this.cmdAppliquer.Text = "All&umer";
            this.cmdAppliquer.UseVisualStyleBackColor = true;
            this.cmdAppliquer.Click += new System.EventHandler(this.cmdAppliquer_Click);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(7, 50);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 13);
            this.label19.TabIndex = 11;
            this.label19.Text = "Source Audio :";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(7, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "Source Vidéo :";
            // 
            // cboAudioSource
            // 
            this.cboAudioSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAudioSource.DropDownWidth = 200;
            this.cboAudioSource.FormattingEnabled = true;
            this.cboAudioSource.Location = new System.Drawing.Point(90, 46);
            this.cboAudioSource.Name = "cboAudioSource";
            this.cboAudioSource.Size = new System.Drawing.Size(197, 21);
            this.cboAudioSource.TabIndex = 12;
            // 
            // cboVideoSource
            // 
            this.cboVideoSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVideoSource.DropDownWidth = 200;
            this.cboVideoSource.FormattingEnabled = true;
            this.cboVideoSource.Location = new System.Drawing.Point(90, 19);
            this.cboVideoSource.Name = "cboVideoSource";
            this.cboVideoSource.Size = new System.Drawing.Size(197, 21);
            this.cboVideoSource.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(12, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 217;
            this.label6.Text = "Adresse :";
            // 
            // txtAdresse
            // 
            this.txtAdresse.Location = new System.Drawing.Point(113, 272);
            this.txtAdresse.Multiline = true;
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(179, 39);
            this.txtAdresse.TabIndex = 7;
            // 
            // FrmPersonne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.img_home_player_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(770, 555);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAdresse);
            this.Controls.Add(this.gpWebCam);
            this.Controls.Add(this.gpSupprimerRepertoire);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtDateNaissance);
            this.Controls.Add(this.lblLoadPhoto);
            this.Controls.Add(this.pbPhotoPersonne);
            this.Controls.Add(this.cboEtatCiv);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cboSexe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPNom);
            this.Controls.Add(this.txtPrenom);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmPersonne";
            this.Text = "Personne";
            this.Load += new System.EventHandler(this.FrmPersonne_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPersonne_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCandidat)).EndInit();
            this.bnvCandidat.ResumeLayout(false);
            this.bnvCandidat.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhotoPersonne)).EndInit();
            this.gpSupprimerRepertoire.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gpWebCam.ResumeLayout(false);
            this.gpWebCam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dlgFile;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txtSeach;
        private System.Windows.Forms.ToolStripButton btnRefreh;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.BindingNavigator bnvCandidat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.DateTimePicker txtDateNaissance;
        private System.Windows.Forms.LinkLabel lblLoadPhoto;
        private System.Windows.Forms.PictureBox pbPhotoPersonne;
        private System.Windows.Forms.ComboBox cboEtatCiv;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboSexe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPNom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.GroupBox gpSupprimerRepertoire;
        private System.Windows.Forms.Button cmdDeleteItems;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdWebCamPicture;
        private System.Windows.Forms.RadioButton rdLocalPicture;
        private System.Windows.Forms.GroupBox gpWebCam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdEffacer;
        private System.Windows.Forms.Button cmdArreter;
        private System.Windows.Forms.Button cmdRepertoire;
        private System.Windows.Forms.Button cmdEnregistrer;
        private System.Windows.Forms.Button cmdCapturer;
        private System.Windows.Forms.PictureBox pbCapture;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox picturePreview;
        private System.Windows.Forms.Button cmdAppliquer;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboAudioSource;
        private System.Windows.Forms.ComboBox cboVideoSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAdresse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSexe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEtatcivil;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatenaissance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn comAdresse;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoto;
        private System.Windows.Forms.Button btnSearchPersonne;
    }
}