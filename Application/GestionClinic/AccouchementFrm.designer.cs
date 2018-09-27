namespace GestionClinic_WIN
{
    partial class AccouchementFrm
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
            this.bnvFonction = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.txtVat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBCG = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLieu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDegree = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMalade = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbotype = new System.Windows.Forms.ComboBox();
            this.lblMalade = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtIdFemmeEnceintePers = new System.Windows.Forms.TextBox();
            this.dgvEnfant = new System.Windows.Forms.DataGridView();
            this.colPoid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSexe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaille = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSenn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoinsducordo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMiseausiendansheurquisuitaccouchement = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMalformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_accouchement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label27 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEnfant = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvAccouchement = new System.Windows.Forms.DataGridView();
            this.colLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTraitement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBcg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cloVat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDegree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_maladeenconsultationpostnatal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_typeaccouchement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdAccouchement = new System.Windows.Forms.TextBox();
            this.txtTraitement = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.txtEtatPaiement = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bnvFonction)).BeginInit();
            this.bnvFonction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnfant)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccouchement)).BeginInit();
            this.SuspendLayout();
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
            this.bnvFonction.Size = new System.Drawing.Size(763, 25);
            this.bnvFonction.TabIndex = 203;
            this.bnvFonction.Text = "bindingNavigator1";
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
            // txtVat
            // 
            this.txtVat.Location = new System.Drawing.Point(543, 108);
            this.txtVat.Name = "txtVat";
            this.txtVat.Size = new System.Drawing.Size(203, 20);
            this.txtVat.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(540, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 201;
            this.label4.Text = "VAT :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 199;
            this.label3.Text = "Date :";
            // 
            // txtBCG
            // 
            this.txtBCG.Location = new System.Drawing.Point(290, 108);
            this.txtBCG.Name = "txtBCG";
            this.txtBCG.Size = new System.Drawing.Size(206, 20);
            this.txtBCG.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(289, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 197;
            this.label2.Text = "BCG :";
            // 
            // txtLieu
            // 
            this.txtLieu.Location = new System.Drawing.Point(541, 68);
            this.txtLieu.Name = "txtLieu";
            this.txtLieu.Size = new System.Drawing.Size(206, 20);
            this.txtLieu.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(539, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 195;
            this.label1.Text = "Lieu :";
            // 
            // txtDegree
            // 
            this.txtDegree.Location = new System.Drawing.Point(17, 149);
            this.txtDegree.Name = "txtDegree";
            this.txtDegree.Size = new System.Drawing.Size(206, 20);
            this.txtDegree.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(17, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 207;
            this.label12.Text = "Degrée :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(16, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 209;
            this.label7.Text = "Malade :";
            // 
            // cboMalade
            // 
            this.cboMalade.Enabled = false;
            this.cboMalade.FormattingEnabled = true;
            this.cboMalade.Location = new System.Drawing.Point(17, 67);
            this.cboMalade.Name = "cboMalade";
            this.cboMalade.Size = new System.Drawing.Size(206, 21);
            this.cboMalade.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(287, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 211;
            this.label8.Text = "Type :";
            // 
            // cbotype
            // 
            this.cbotype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbotype.FormattingEnabled = true;
            this.cbotype.Location = new System.Drawing.Point(290, 67);
            this.cbotype.Name = "cbotype";
            this.cbotype.Size = new System.Drawing.Size(206, 21);
            this.cbotype.TabIndex = 2;
            // 
            // lblMalade
            // 
            this.lblMalade.BackColor = System.Drawing.Color.Transparent;
            this.lblMalade.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblMalade.Location = new System.Drawing.Point(228, 67);
            this.lblMalade.Name = "lblMalade";
            this.lblMalade.Size = new System.Drawing.Size(25, 21);
            this.lblMalade.TabIndex = 1;
            this.lblMalade.Click += new System.EventHandler(this.lblMalade_Click);
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(331, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 23);
            this.label16.TabIndex = 252;
            this.label16.Text = "Accouchement";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIdFemmeEnceintePers
            // 
            this.txtIdFemmeEnceintePers.Location = new System.Drawing.Point(609, 9);
            this.txtIdFemmeEnceintePers.Name = "txtIdFemmeEnceintePers";
            this.txtIdFemmeEnceintePers.Size = new System.Drawing.Size(55, 20);
            this.txtIdFemmeEnceintePers.TabIndex = 285;
            // 
            // dgvEnfant
            // 
            this.dgvEnfant.BackgroundColor = System.Drawing.Color.White;
            this.dgvEnfant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnfant.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPoid,
            this.colSexe,
            this.colTaille,
            this.colSenn,
            this.colSoinsducordo,
            this.colMiseausiendansheurquisuitaccouchement,
            this.colPc,
            this.colMalformation,
            this.colId_accouchement,
            this.dataGridViewTextBoxColumn1});
            this.dgvEnfant.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvEnfant.Location = new System.Drawing.Point(0, 0);
            this.dgvEnfant.Name = "dgvEnfant";
            this.dgvEnfant.ReadOnly = true;
            this.dgvEnfant.RowHeadersVisible = false;
            this.dgvEnfant.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEnfant.Size = new System.Drawing.Size(732, 157);
            this.dgvEnfant.TabIndex = 286;
            this.dgvEnfant.DoubleClick += new System.EventHandler(this.dgvEnfant_DoubleClick);
            // 
            // colPoid
            // 
            this.colPoid.DataPropertyName = "Poid";
            this.colPoid.HeaderText = "Poid";
            this.colPoid.Name = "colPoid";
            this.colPoid.ReadOnly = true;
            this.colPoid.Width = 60;
            // 
            // colSexe
            // 
            this.colSexe.DataPropertyName = "Sexe";
            this.colSexe.HeaderText = "Sexe";
            this.colSexe.Name = "colSexe";
            this.colSexe.ReadOnly = true;
            this.colSexe.Width = 50;
            // 
            // colTaille
            // 
            this.colTaille.DataPropertyName = "Taille";
            this.colTaille.HeaderText = "Taille";
            this.colTaille.Name = "colTaille";
            this.colTaille.ReadOnly = true;
            this.colTaille.Width = 70;
            // 
            // colSenn
            // 
            this.colSenn.DataPropertyName = "Senn";
            this.colSenn.HeaderText = "Senn";
            this.colSenn.Name = "colSenn";
            this.colSenn.ReadOnly = true;
            this.colSenn.Width = 170;
            // 
            // colSoinsducordo
            // 
            this.colSoinsducordo.DataPropertyName = "Soinsducordo";
            this.colSoinsducordo.HeaderText = "Soins_cordon";
            this.colSoinsducordo.Name = "colSoinsducordo";
            this.colSoinsducordo.ReadOnly = true;
            this.colSoinsducordo.Width = 150;
            // 
            // colMiseausiendansheurquisuitaccouchement
            // 
            this.colMiseausiendansheurquisuitaccouchement.DataPropertyName = "Miseausiendansheurquisuitaccouchement";
            this.colMiseausiendansheurquisuitaccouchement.HeaderText = "Mise_heur qui suit Accouchement";
            this.colMiseausiendansheurquisuitaccouchement.Name = "colMiseausiendansheurquisuitaccouchement";
            this.colMiseausiendansheurquisuitaccouchement.ReadOnly = true;
            this.colMiseausiendansheurquisuitaccouchement.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMiseausiendansheurquisuitaccouchement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colMiseausiendansheurquisuitaccouchement.Width = 85;
            // 
            // colPc
            // 
            this.colPc.DataPropertyName = "Pc";
            this.colPc.HeaderText = "PC";
            this.colPc.Name = "colPc";
            this.colPc.ReadOnly = true;
            // 
            // colMalformation
            // 
            this.colMalformation.DataPropertyName = "Malformation";
            this.colMalformation.HeaderText = "Malformation";
            this.colMalformation.Name = "colMalformation";
            this.colMalformation.ReadOnly = true;
            this.colMalformation.Width = 110;
            // 
            // colId_accouchement
            // 
            this.colId_accouchement.DataPropertyName = "Id_accouchement";
            this.colId_accouchement.HeaderText = "Id_accouchement";
            this.colId_accouchement.Name = "colId_accouchement";
            this.colId_accouchement.ReadOnly = true;
            this.colId_accouchement.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.White;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Blue;
            this.label27.Location = new System.Drawing.Point(265, 343);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(239, 19);
            this.label27.TabIndex = 355;
            this.label27.Text = "INFORMATIONS SUR LES ENFANTS";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(4, 349);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(258, 5);
            this.label11.TabIndex = 354;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lblEnfant);
            this.panel1.Controls.Add(this.dgvEnfant);
            this.panel1.Location = new System.Drawing.Point(17, 377);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 187);
            this.panel1.TabIndex = 356;
            // 
            // lblEnfant
            // 
            this.lblEnfant.AutoSize = true;
            this.lblEnfant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEnfant.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnfant.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblEnfant.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblEnfant.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEnfant.Location = new System.Drawing.Point(298, 162);
            this.lblEnfant.Name = "lblEnfant";
            this.lblEnfant.Size = new System.Drawing.Size(150, 18);
            this.lblEnfant.TabIndex = 11;
            this.lblEnfant.Text = "        Ajouter un enfant";
            this.lblEnfant.Click += new System.EventHandler(this.lblEnfant_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(506, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(259, 5);
            this.label5.TabIndex = 357;
            // 
            // dgvAccouchement
            // 
            this.dgvAccouchement.BackgroundColor = System.Drawing.Color.White;
            this.dgvAccouchement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccouchement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLieu,
            this.colTraitement,
            this.colBcg,
            this.cloVat,
            this.colDegree,
            this.colDate,
            this.colPrix,
            this.colId_maladeenconsultationpostnatal,
            this.colId_typeaccouchement,
            this.colId1});
            this.dgvAccouchement.Location = new System.Drawing.Point(19, 178);
            this.dgvAccouchement.Name = "dgvAccouchement";
            this.dgvAccouchement.RowHeadersVisible = false;
            this.dgvAccouchement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccouchement.Size = new System.Drawing.Size(728, 153);
            this.dgvAccouchement.TabIndex = 358;
            this.dgvAccouchement.DoubleClick += new System.EventHandler(this.dgvAccouchement_DoubleClick);
            this.dgvAccouchement.SelectionChanged += new System.EventHandler(this.dgvAccouchement_SelectionChanged);
            // 
            // colLieu
            // 
            this.colLieu.DataPropertyName = "Lieu";
            this.colLieu.HeaderText = "Lieu";
            this.colLieu.Name = "colLieu";
            this.colLieu.ReadOnly = true;
            this.colLieu.Width = 170;
            // 
            // colTraitement
            // 
            this.colTraitement.DataPropertyName = "Traitement";
            this.colTraitement.HeaderText = "Traitement";
            this.colTraitement.Name = "colTraitement";
            this.colTraitement.ReadOnly = true;
            this.colTraitement.Width = 164;
            // 
            // colBcg
            // 
            this.colBcg.DataPropertyName = "Bcg";
            this.colBcg.HeaderText = "BCG";
            this.colBcg.Name = "colBcg";
            this.colBcg.ReadOnly = true;
            this.colBcg.Width = 60;
            // 
            // cloVat
            // 
            this.cloVat.DataPropertyName = "Vat";
            this.cloVat.HeaderText = "VAT";
            this.cloVat.Name = "cloVat";
            this.cloVat.ReadOnly = true;
            this.cloVat.Width = 60;
            // 
            // colDegree
            // 
            this.colDegree.DataPropertyName = "Degree";
            this.colDegree.HeaderText = "Degrée";
            this.colDegree.Name = "colDegree";
            this.colDegree.ReadOnly = true;
            this.colDegree.Width = 80;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "Date";
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 110;
            // 
            // colPrix
            // 
            this.colPrix.DataPropertyName = "Prix";
            this.colPrix.HeaderText = "Prix";
            this.colPrix.Name = "colPrix";
            this.colPrix.ReadOnly = true;
            this.colPrix.Width = 80;
            // 
            // colId_maladeenconsultationpostnatal
            // 
            this.colId_maladeenconsultationpostnatal.DataPropertyName = "Id_maladegrosse";
            this.colId_maladeenconsultationpostnatal.HeaderText = "Id_maladegrosse";
            this.colId_maladeenconsultationpostnatal.Name = "colId_maladeenconsultationpostnatal";
            this.colId_maladeenconsultationpostnatal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colId_maladeenconsultationpostnatal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colId_maladeenconsultationpostnatal.Visible = false;
            // 
            // colId_typeaccouchement
            // 
            this.colId_typeaccouchement.DataPropertyName = "Id_typeaccouchement";
            this.colId_typeaccouchement.HeaderText = "Id_typeaccouchement";
            this.colId_typeaccouchement.Name = "colId_typeaccouchement";
            this.colId_typeaccouchement.ReadOnly = true;
            this.colId_typeaccouchement.Visible = false;
            // 
            // colId1
            // 
            this.colId1.DataPropertyName = "Id";
            this.colId1.HeaderText = "Id";
            this.colId1.Name = "colId1";
            this.colId1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colId1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colId1.Visible = false;
            // 
            // txtIdAccouchement
            // 
            this.txtIdAccouchement.Location = new System.Drawing.Point(541, 9);
            this.txtIdAccouchement.Name = "txtIdAccouchement";
            this.txtIdAccouchement.Size = new System.Drawing.Size(55, 20);
            this.txtIdAccouchement.TabIndex = 359;
            // 
            // txtTraitement
            // 
            this.txtTraitement.Location = new System.Drawing.Point(290, 149);
            this.txtTraitement.Name = "txtTraitement";
            this.txtTraitement.Size = new System.Drawing.Size(206, 20);
            this.txtTraitement.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(290, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 361;
            this.label6.Text = "Traitement :";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(17, 108);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(206, 20);
            this.txtDate.TabIndex = 4;
            // 
            // txtEtatPaiement
            // 
            this.txtEtatPaiement.Enabled = false;
            this.txtEtatPaiement.Location = new System.Drawing.Point(543, 147);
            this.txtEtatPaiement.Name = "txtEtatPaiement";
            this.txtEtatPaiement.Size = new System.Drawing.Size(203, 20);
            this.txtEtatPaiement.TabIndex = 362;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(542, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 363;
            this.label9.Text = "Etat paiement :";
            // 
            // FrmAccouchement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.img_home_player_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(763, 591);
            this.Controls.Add(this.txtEtatPaiement);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtTraitement);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIdAccouchement);
            this.Controls.Add(this.dgvAccouchement);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtIdFemmeEnceintePers);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblMalade);
            this.Controls.Add(this.cbotype);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboMalade);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDegree);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.bnvFonction);
            this.Controls.Add(this.txtVat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBCG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLieu);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "FrmAccouchement";
            this.Text = "Accouchement";
            this.Load += new System.EventHandler(this.FrmAccouchement_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAccouchement_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bnvFonction)).EndInit();
            this.bnvFonction.ResumeLayout(false);
            this.bnvFonction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnfant)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccouchement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnvFonction;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.TextBox txtVat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBCG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDegree;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMalade;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbotype;
        private System.Windows.Forms.Label lblMalade;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtIdFemmeEnceintePers;
        private System.Windows.Forms.DataGridView dgvEnfant;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblEnfant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvAccouchement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTraitement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBcg;
        private System.Windows.Forms.DataGridViewTextBoxColumn cloVat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDegree;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrix;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_maladeenconsultationpostnatal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_typeaccouchement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPoid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSexe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaille;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSenn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoinsducordo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMiseausiendansheurquisuitaccouchement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMalformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_accouchement;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.TextBox txtIdAccouchement;
        private System.Windows.Forms.TextBox txtTraitement;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.TextBox txtEtatPaiement;
        private System.Windows.Forms.Label label9;
    }
}