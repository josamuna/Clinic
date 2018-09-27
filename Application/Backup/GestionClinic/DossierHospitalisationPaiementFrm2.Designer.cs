namespace GestionClinic_WIN
{
    partial class DossierHospitalisationPaiementFrm2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtId_malade = new System.Windows.Forms.TextBox();
            this.Affiche1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmdAddCatChambre = new System.Windows.Forms.Button();
            this.valider = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpSortie = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDateFin = new System.Windows.Forms.DateTimePicker();
            this.txtPaiement = new System.Windows.Forms.TextBox();
            this.lblAddChambre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboChambre = new System.Windows.Forms.ComboBox();
            this.dgvHospitalisation = new System.Windows.Forms.DataGridView();
            this.txtDateDebut = new System.Windows.Forms.DateTimePicker();
            this.bnvCandidat = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRefreh = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btClose = new System.Windows.Forms.ToolStripButton();
            this.txtIdHospitalisation = new System.Windows.Forms.TextBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datedebut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datefin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Etatpaiement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_chambre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_malade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Affiche1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpSortie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospitalisation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCandidat)).BeginInit();
            this.bnvCandidat.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtId_malade
            // 
            this.txtId_malade.Location = new System.Drawing.Point(768, 56);
            this.txtId_malade.Name = "txtId_malade";
            this.txtId_malade.Size = new System.Drawing.Size(100, 20);
            this.txtId_malade.TabIndex = 274;
            // 
            // Affiche1
            // 
            this.Affiche1.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.bg;
            this.Affiche1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Affiche1.Controls.Add(this.tabControl1);
            this.Affiche1.Controls.Add(this.bnvCandidat);
            this.Affiche1.Location = new System.Drawing.Point(11, 3);
            this.Affiche1.Name = "Affiche1";
            this.Affiche1.Size = new System.Drawing.Size(702, 194);
            this.Affiche1.TabIndex = 282;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(5, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(695, 157);
            this.tabControl1.TabIndex = 435;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.cmdAddCatChambre);
            this.tabPage1.Controls.Add(this.valider);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.grpSortie);
            this.tabPage1.Controls.Add(this.txtPaiement);
            this.tabPage1.Controls.Add(this.lblAddChambre);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cboChambre);
            this.tabPage1.Controls.Add(this.dgvHospitalisation);
            this.tabPage1.Controls.Add(this.txtDateDebut);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(687, 131);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dossier d\'hospitalisation en cours";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmdAddCatChambre
            // 
            this.cmdAddCatChambre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAddCatChambre.ForeColor = System.Drawing.Color.Green;
            this.cmdAddCatChambre.Location = new System.Drawing.Point(283, 31);
            this.cmdAddCatChambre.Name = "cmdAddCatChambre";
            this.cmdAddCatChambre.Size = new System.Drawing.Size(107, 26);
            this.cmdAddCatChambre.TabIndex = 286;
            this.cmdAddCatChambre.Text = "&Catégorie Chambre";
            this.cmdAddCatChambre.UseVisualStyleBackColor = true;
            this.cmdAddCatChambre.Click += new System.EventHandler(this.cmdAddCatChambre_Click);
            // 
            // valider
            // 
            this.valider.Enabled = false;
            this.valider.Location = new System.Drawing.Point(573, 83);
            this.valider.Name = "valider";
            this.valider.Size = new System.Drawing.Size(108, 42);
            this.valider.TabIndex = 273;
            this.valider.Text = "Valider et Clôturer";
            this.valider.UseVisualStyleBackColor = true;
            this.valider.Click += new System.EventHandler(this.valider_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(8, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 264;
            this.label7.Text = "Date Entée:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 284;
            this.label2.Text = "Etat Paiement :";
            // 
            // grpSortie
            // 
            this.grpSortie.BackColor = System.Drawing.Color.Transparent;
            this.grpSortie.Controls.Add(this.label4);
            this.grpSortie.Controls.Add(this.txtDateFin);
            this.grpSortie.Location = new System.Drawing.Point(7, 79);
            this.grpSortie.Name = "grpSortie";
            this.grpSortie.Size = new System.Drawing.Size(557, 49);
            this.grpSortie.TabIndex = 285;
            this.grpSortie.TabStop = false;
            this.grpSortie.Text = "Clôturer un Dossier d\'Hospitalisation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 271;
            this.label4.Text = "Date Sortie :";
            // 
            // txtDateFin
            // 
            this.txtDateFin.Enabled = false;
            this.txtDateFin.Location = new System.Drawing.Point(83, 23);
            this.txtDateFin.Name = "txtDateFin";
            this.txtDateFin.Size = new System.Drawing.Size(161, 20);
            this.txtDateFin.TabIndex = 272;
            // 
            // txtPaiement
            // 
            this.txtPaiement.Enabled = false;
            this.txtPaiement.Location = new System.Drawing.Point(92, 59);
            this.txtPaiement.Name = "txtPaiement";
            this.txtPaiement.Size = new System.Drawing.Size(162, 20);
            this.txtPaiement.TabIndex = 283;
            // 
            // lblAddChambre
            // 
            this.lblAddChambre.BackColor = System.Drawing.Color.Transparent;
            this.lblAddChambre.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAddChambre.Location = new System.Drawing.Point(255, 34);
            this.lblAddChambre.Name = "lblAddChambre";
            this.lblAddChambre.Size = new System.Drawing.Size(25, 21);
            this.lblAddChambre.TabIndex = 269;
            this.lblAddChambre.Click += new System.EventHandler(this.lblAddChambre_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 267;
            this.label1.Text = "Chambre :";
            // 
            // cboChambre
            // 
            this.cboChambre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboChambre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboChambre.FormattingEnabled = true;
            this.cboChambre.Location = new System.Drawing.Point(92, 35);
            this.cboChambre.Name = "cboChambre";
            this.cboChambre.Size = new System.Drawing.Size(162, 21);
            this.cboChambre.TabIndex = 275;
            this.cboChambre.SelectedIndexChanged += new System.EventHandler(this.cboChambre_SelectedIndexChanged);
            this.cboChambre.DropDown += new System.EventHandler(this.cboChambre_DropDown);
            // 
            // dgvHospitalisation
            // 
            this.dgvHospitalisation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvHospitalisation.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHospitalisation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHospitalisation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHospitalisation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Datedebut,
            this.Datefin,
            this.Etatpaiement,
            this.Id_chambre,
            this.Id_malade});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHospitalisation.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHospitalisation.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvHospitalisation.Location = new System.Drawing.Point(396, 9);
            this.dgvHospitalisation.MultiSelect = false;
            this.dgvHospitalisation.Name = "dgvHospitalisation";
            this.dgvHospitalisation.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHospitalisation.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHospitalisation.RowHeadersVisible = false;
            this.dgvHospitalisation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHospitalisation.Size = new System.Drawing.Size(284, 68);
            this.dgvHospitalisation.TabIndex = 273;
            this.dgvHospitalisation.SelectionChanged += new System.EventHandler(this.dgvHospitalisation_SelectionChanged);
            // 
            // txtDateDebut
            // 
            this.txtDateDebut.Location = new System.Drawing.Point(92, 9);
            this.txtDateDebut.Name = "txtDateDebut";
            this.txtDateDebut.Size = new System.Drawing.Size(162, 20);
            this.txtDateDebut.TabIndex = 270;
            // 
            // bnvCandidat
            // 
            this.bnvCandidat.AddNewItem = null;
            this.bnvCandidat.BackColor = System.Drawing.Color.Transparent;
            this.bnvCandidat.CountItem = null;
            this.bnvCandidat.DeleteItem = null;
            this.bnvCandidat.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bnvCandidat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnRefreh,
            this.btnSave,
            this.btnDelete,
            this.btClose});
            this.bnvCandidat.Location = new System.Drawing.Point(0, 0);
            this.bnvCandidat.MoveFirstItem = null;
            this.bnvCandidat.MoveLastItem = null;
            this.bnvCandidat.MoveNextItem = null;
            this.bnvCandidat.MovePreviousItem = null;
            this.bnvCandidat.Name = "bnvCandidat";
            this.bnvCandidat.PositionItem = null;
            this.bnvCandidat.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bnvCandidat.Size = new System.Drawing.Size(702, 25);
            this.bnvCandidat.TabIndex = 281;
            this.bnvCandidat.Text = "bindingNavigator1";
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
            // btClose
            // 
            this.btClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btClose.Image = global::GestionClinic_WIN.Properties.Resources.Close1;
            this.btClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(23, 22);
            this.btClose.Text = "Fermer";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // txtIdHospitalisation
            // 
            this.txtIdHospitalisation.Location = new System.Drawing.Point(768, 113);
            this.txtIdHospitalisation.Name = "txtIdHospitalisation";
            this.txtIdHospitalisation.Size = new System.Drawing.Size(100, 20);
            this.txtIdHospitalisation.TabIndex = 283;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 22;
            // 
            // Datedebut
            // 
            this.Datedebut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Datedebut.DataPropertyName = "Datedebut";
            this.Datedebut.HeaderText = "Date début";
            this.Datedebut.Name = "Datedebut";
            this.Datedebut.ReadOnly = true;
            this.Datedebut.Width = 90;
            // 
            // Datefin
            // 
            this.Datefin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Datefin.DataPropertyName = "Datefin";
            this.Datefin.HeaderText = "Date fin";
            this.Datefin.Name = "Datefin";
            this.Datefin.ReadOnly = true;
            this.Datefin.Width = 80;
            // 
            // Etatpaiement
            // 
            this.Etatpaiement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Etatpaiement.DataPropertyName = "Etatpaiement";
            this.Etatpaiement.HeaderText = "Etat paiement";
            this.Etatpaiement.Name = "Etatpaiement";
            this.Etatpaiement.ReadOnly = true;
            this.Etatpaiement.Width = 105;
            // 
            // Id_chambre
            // 
            this.Id_chambre.DataPropertyName = "Id_chambre";
            this.Id_chambre.HeaderText = "Id_chambre";
            this.Id_chambre.Name = "Id_chambre";
            this.Id_chambre.ReadOnly = true;
            this.Id_chambre.Visible = false;
            this.Id_chambre.Width = 88;
            // 
            // Id_malade
            // 
            this.Id_malade.DataPropertyName = "Id_malade";
            this.Id_malade.HeaderText = "Id_malade";
            this.Id_malade.Name = "Id_malade";
            this.Id_malade.ReadOnly = true;
            this.Id_malade.Visible = false;
            this.Id_malade.Width = 81;
            // 
            // FrmDossierHospitalisationPaiement2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.txtIdHospitalisation);
            this.Controls.Add(this.Affiche1);
            this.Controls.Add(this.txtId_malade);
            this.DoubleBuffered = true;
            this.Name = "FrmDossierHospitalisationPaiement2";
            this.Size = new System.Drawing.Size(721, 207);
            this.Load += new System.EventHandler(this.Hospitalisation_Load);
            this.Affiche1.ResumeLayout(false);
            this.Affiche1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpSortie.ResumeLayout(false);
            this.grpSortie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospitalisation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCandidat)).EndInit();
            this.bnvCandidat.ResumeLayout(false);
            this.bnvCandidat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId_malade;
        private System.Windows.Forms.Panel Affiche1;
        private System.Windows.Forms.BindingNavigator bnvCandidat;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnRefreh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btClose;
        private System.Windows.Forms.TextBox txtIdHospitalisation;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button valider;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpSortie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtDateFin;
        private System.Windows.Forms.TextBox txtPaiement;
        private System.Windows.Forms.Label lblAddChambre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboChambre;
        private System.Windows.Forms.DataGridView dgvHospitalisation;
        private System.Windows.Forms.DateTimePicker txtDateDebut;
        private System.Windows.Forms.Button cmdAddCatChambre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datedebut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datefin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Etatpaiement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_chambre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_malade;
    }
}
