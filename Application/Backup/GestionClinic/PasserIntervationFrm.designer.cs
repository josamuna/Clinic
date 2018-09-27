namespace GestionClinic_WIN
{
    partial class PasserIntervationFrm
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
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtObservation = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvSubit = new System.Windows.Forms.DataGridView();
            this.bnvCandidat = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRefreh = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnCloturer = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtId_malade = new System.Windows.Forms.TextBox();
            this.lblIntervention = new System.Windows.Forms.Label();
            this.cboIntervention = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPaiement = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRest = new System.Windows.Forms.Button();
            this.txtEtatPaiement = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lstArchive = new System.Windows.Forms.ListBox();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Etatpaiement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_malade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesignationComplete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_intervention = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCandidat)).BeginInit();
            this.bnvCandidat.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(77, 41);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(184, 20);
            this.txtDate.TabIndex = 184;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 195;
            this.label11.Text = "Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 193;
            this.label3.Text = "Observation :";
            // 
            // txtObservation
            // 
            this.txtObservation.Location = new System.Drawing.Point(343, 10);
            this.txtObservation.Multiline = true;
            this.txtObservation.Name = "txtObservation";
            this.txtObservation.Size = new System.Drawing.Size(183, 47);
            this.txtObservation.TabIndex = 182;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(202, 2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(140, 20);
            this.label16.TabIndex = 204;
            this.label16.Text = "Passation intervation ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.dgvSubit);
            this.groupBox3.Location = new System.Drawing.Point(5, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(521, 140);
            this.groupBox3.TabIndex = 216;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Intervention";
            // 
            // label5
            // 
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.label5.Location = new System.Drawing.Point(4, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 21);
            this.label5.TabIndex = 215;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(28, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 18);
            this.label7.TabIndex = 215;
            this.label7.Text = "Ajouter une nouvelle consultation";
            // 
            // dgvSubit
            // 
            this.dgvSubit.BackgroundColor = System.Drawing.Color.White;
            this.dgvSubit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Observation,
            this.Etatpaiement,
            this.Id,
            this.Id_malade,
            this.colDesignationComplete,
            this.Id_intervention});
            this.dgvSubit.Location = new System.Drawing.Point(13, 19);
            this.dgvSubit.Name = "dgvSubit";
            this.dgvSubit.RowHeadersVisible = false;
            this.dgvSubit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubit.Size = new System.Drawing.Size(498, 113);
            this.dgvSubit.TabIndex = 213;
            this.dgvSubit.SelectionChanged += new System.EventHandler(this.dgvSubit_SelectionChanged);
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
            this.btnDelete,
            this.btnCloturer});
            this.bnvCandidat.Location = new System.Drawing.Point(13, 11);
            this.bnvCandidat.MoveFirstItem = null;
            this.bnvCandidat.MoveLastItem = null;
            this.bnvCandidat.MoveNextItem = null;
            this.bnvCandidat.MovePreviousItem = null;
            this.bnvCandidat.Name = "bnvCandidat";
            this.bnvCandidat.PositionItem = null;
            this.bnvCandidat.Size = new System.Drawing.Size(118, 25);
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
            this.btnSave.Text = "Enregistrer";
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
            // btnCloturer
            // 
            this.btnCloturer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCloturer.Image = global::GestionClinic_WIN.Properties.Resources.BackUpDistant;
            this.btnCloturer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloturer.Name = "btnCloturer";
            this.btnCloturer.Size = new System.Drawing.Size(23, 22);
            this.btnCloturer.Text = "Cloturer Une Intervention";
            this.btnCloturer.Click += new System.EventHandler(this.btnCloturer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bnvCandidat);
            this.groupBox1.Location = new System.Drawing.Point(10, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 42);
            this.groupBox1.TabIndex = 158;
            this.groupBox1.TabStop = false;
            // 
            // txtId_malade
            // 
            this.txtId_malade.Location = new System.Drawing.Point(703, 84);
            this.txtId_malade.Multiline = true;
            this.txtId_malade.Name = "txtId_malade";
            this.txtId_malade.Size = new System.Drawing.Size(76, 47);
            this.txtId_malade.TabIndex = 261;
            // 
            // lblIntervention
            // 
            this.lblIntervention.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblIntervention.Location = new System.Drawing.Point(236, 10);
            this.lblIntervention.Name = "lblIntervention";
            this.lblIntervention.Size = new System.Drawing.Size(25, 21);
            this.lblIntervention.TabIndex = 264;
            this.lblIntervention.Click += new System.EventHandler(this.lblIntervention_Click);
            // 
            // cboIntervention
            // 
            this.cboIntervention.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIntervention.FormattingEnabled = true;
            this.cboIntervention.Location = new System.Drawing.Point(77, 10);
            this.cboIntervention.Name = "cboIntervention";
            this.cboIntervention.Size = new System.Drawing.Size(156, 21);
            this.cboIntervention.TabIndex = 262;
            this.cboIntervention.DropDown += new System.EventHandler(this.cboIntervention_DropDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 263;
            this.label15.Text = "Intervention :";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 73);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(538, 259);
            this.tabControl1.TabIndex = 436;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtPaiement);
            this.tabPage1.Controls.Add(this.txtObservation);
            this.tabPage1.Controls.Add(this.lblIntervention);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cboIntervention);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.txtDate);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(530, 233);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dossier d\'intervention en cours";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 266;
            this.label1.Text = "Etat du dossier Intervention :";
            // 
            // txtPaiement
            // 
            this.txtPaiement.Enabled = false;
            this.txtPaiement.Location = new System.Drawing.Point(340, 205);
            this.txtPaiement.Multiline = true;
            this.txtPaiement.Name = "txtPaiement";
            this.txtPaiement.Size = new System.Drawing.Size(183, 22);
            this.txtPaiement.TabIndex = 265;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRest);
            this.tabPage2.Controls.Add(this.txtEtatPaiement);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.lstArchive);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(530, 233);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Archives";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRest
            // 
            this.btnRest.Location = new System.Drawing.Point(68, 100);
            this.btnRest.Name = "btnRest";
            this.btnRest.Size = new System.Drawing.Size(208, 23);
            this.btnRest.TabIndex = 274;
            this.btnRest.Text = "Restaurer un Dossier d\'intervention";
            this.btnRest.UseVisualStyleBackColor = true;
            this.btnRest.Click += new System.EventHandler(this.btnRest_Click);
            // 
            // txtEtatPaiement
            // 
            this.txtEtatPaiement.Enabled = false;
            this.txtEtatPaiement.Location = new System.Drawing.Point(65, 74);
            this.txtEtatPaiement.Name = "txtEtatPaiement";
            this.txtEtatPaiement.Size = new System.Drawing.Size(211, 20);
            this.txtEtatPaiement.TabIndex = 445;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(281, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(127, 13);
            this.label19.TabIndex = 442;
            this.label19.Text = "Dates d\'ouverture dossier";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(10, 81);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(49, 13);
            this.label26.TabIndex = 435;
            this.label26.Text = "Chambre";
            // 
            // lstArchive
            // 
            this.lstArchive.FormattingEnabled = true;
            this.lstArchive.Location = new System.Drawing.Point(282, 59);
            this.lstArchive.Name = "lstArchive";
            this.lstArchive.Size = new System.Drawing.Size(233, 82);
            this.lstArchive.TabIndex = 434;
            this.lstArchive.SelectedIndexChanged += new System.EventHandler(this.lstArchive_SelectedIndexChanged);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.AutoSize = false;
            this.bindingNavigator1.BackColor = System.Drawing.Color.Transparent;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose});
            this.bindingNavigator1.Location = new System.Drawing.Point(469, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bindingNavigator1.Size = new System.Drawing.Size(83, 25);
            this.bindingNavigator1.TabIndex = 437;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // btnClose
            // 
            this.btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = global::GestionClinic_WIN.Properties.Resources.Close1;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 22);
            this.btnClose.Text = "Supprimer";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Observation
            // 
            this.Observation.DataPropertyName = "Observation";
            this.Observation.HeaderText = "Observation";
            this.Observation.Name = "Observation";
            this.Observation.ReadOnly = true;
            this.Observation.Width = 270;
            // 
            // Etatpaiement
            // 
            this.Etatpaiement.DataPropertyName = "Etatpaiement";
            this.Etatpaiement.HeaderText = "Etat paiement";
            this.Etatpaiement.Name = "Etatpaiement";
            this.Etatpaiement.Width = 120;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Id_malade
            // 
            this.Id_malade.DataPropertyName = "Id_malade";
            this.Id_malade.HeaderText = "Id_malade";
            this.Id_malade.Name = "Id_malade";
            this.Id_malade.Visible = false;
            // 
            // colDesignationComplete
            // 
            this.colDesignationComplete.DataPropertyName = "DesignationComplete";
            this.colDesignationComplete.HeaderText = "DesignationComplete";
            this.colDesignationComplete.Name = "colDesignationComplete";
            this.colDesignationComplete.Visible = false;
            // 
            // Id_intervention
            // 
            this.Id_intervention.DataPropertyName = "Id_intervention";
            this.Id_intervention.HeaderText = "Intervention";
            this.Id_intervention.Name = "Id_intervention";
            this.Id_intervention.Visible = false;
            this.Id_intervention.Width = 50;
            // 
            // FrmPasserIntervation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.img_home_player_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtId_malade);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "FrmPasserIntervation";
            this.Size = new System.Drawing.Size(556, 335);
            this.Load += new System.EventHandler(this.FrmPasserIntervation_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCandidat)).EndInit();
            this.bnvCandidat.ResumeLayout(false);
            this.bnvCandidat.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtObservation;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvSubit;
        private System.Windows.Forms.BindingNavigator bnvCandidat;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnRefreh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtId_malade;
        private System.Windows.Forms.Label lblIntervention;
        private System.Windows.Forms.ComboBox cboIntervention;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnRest;
        private System.Windows.Forms.TextBox txtEtatPaiement;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ListBox lstArchive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPaiement;
        private System.Windows.Forms.ToolStripButton btnCloturer;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Etatpaiement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_malade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesignationComplete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_intervention;
    }
}
