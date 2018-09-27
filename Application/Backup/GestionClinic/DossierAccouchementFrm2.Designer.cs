namespace GestionClinic_WIN
{
    partial class DossierAccouchementFrm2
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAddTarif = new System.Windows.Forms.Label();
            this.lstDossierEncCours = new System.Windows.Forms.ListBox();
            this.txtEtatConsommation = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cboService = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDateOuvertureDossier = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.txtIdMalade = new System.Windows.Forms.TextBox();
            this.txtIdMedecinCons = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(2, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(622, 173);
            this.tabControl1.TabIndex = 437;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtPrix);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lblAddTarif);
            this.tabPage1.Controls.Add(this.lstDossierEncCours);
            this.tabPage1.Controls.Add(this.txtEtatConsommation);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.cboService);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.txtDateOuvertureDossier);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.bindingNavigator1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(614, 147);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Accouchement";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(321, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 453;
            this.label6.Text = "$ US";
            // 
            // txtPrix
            // 
            this.txtPrix.Enabled = false;
            this.txtPrix.Location = new System.Drawing.Point(149, 93);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(166, 20);
            this.txtPrix.TabIndex = 452;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(4, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 451;
            this.label5.Text = "Prix :";
            // 
            // lblAddTarif
            // 
            this.lblAddTarif.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAddTarif.Location = new System.Drawing.Point(317, 67);
            this.lblAddTarif.Name = "lblAddTarif";
            this.lblAddTarif.Size = new System.Drawing.Size(25, 22);
            this.lblAddTarif.TabIndex = 450;
            this.lblAddTarif.Click += new System.EventHandler(this.lblAddTarif_Click);
            // 
            // lstDossierEncCours
            // 
            this.lstDossierEncCours.FormattingEnabled = true;
            this.lstDossierEncCours.Location = new System.Drawing.Point(361, 40);
            this.lstDossierEncCours.Name = "lstDossierEncCours";
            this.lstDossierEncCours.Size = new System.Drawing.Size(243, 95);
            this.lstDossierEncCours.TabIndex = 448;
            this.lstDossierEncCours.SelectedIndexChanged += new System.EventHandler(this.lstDossierEncCours_SelectedIndexChanged_1);
            // 
            // txtEtatConsommation
            // 
            this.txtEtatConsommation.Enabled = false;
            this.txtEtatConsommation.Location = new System.Drawing.Point(149, 116);
            this.txtEtatConsommation.Name = "txtEtatConsommation";
            this.txtEtatConsommation.Size = new System.Drawing.Size(166, 20);
            this.txtEtatConsommation.TabIndex = 447;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(3, 70);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 13);
            this.label22.TabIndex = 441;
            this.label22.Text = "Service consommé :";
            // 
            // cboService
            // 
            this.cboService.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboService.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboService.FormattingEnabled = true;
            this.cboService.Location = new System.Drawing.Point(149, 67);
            this.cboService.Name = "cboService";
            this.cboService.Size = new System.Drawing.Size(166, 21);
            this.cboService.TabIndex = 442;
            this.cboService.SelectedIndexChanged += new System.EventHandler(this.cboService_SelectedIndexChanged);
            this.cboService.DropDown += new System.EventHandler(this.cboService_DropDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(6, 46);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(143, 13);
            this.label23.TabIndex = 443;
            this.label23.Text = "Date d\'ouverture du dossier :";
            // 
            // txtDateOuvertureDossier
            // 
            this.txtDateOuvertureDossier.Location = new System.Drawing.Point(149, 39);
            this.txtDateOuvertureDossier.Name = "txtDateOuvertureDossier";
            this.txtDateOuvertureDossier.Size = new System.Drawing.Size(166, 20);
            this.txtDateOuvertureDossier.TabIndex = 444;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(5, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 445;
            this.label12.Text = "Etat du dossier";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(360, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 435;
            this.label2.Text = "Référence Date ouverture ";
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
            this.bindingNavigator1.Size = new System.Drawing.Size(608, 27);
            this.bindingNavigator1.TabIndex = 439;
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
            // txtIdMalade
            // 
            this.txtIdMalade.Location = new System.Drawing.Point(217, 211);
            this.txtIdMalade.Name = "txtIdMalade";
            this.txtIdMalade.Size = new System.Drawing.Size(100, 20);
            this.txtIdMalade.TabIndex = 438;
            // 
            // txtIdMedecinCons
            // 
            this.txtIdMedecinCons.Location = new System.Drawing.Point(326, 211);
            this.txtIdMedecinCons.Name = "txtIdMedecinCons";
            this.txtIdMedecinCons.Size = new System.Drawing.Size(100, 20);
            this.txtIdMedecinCons.TabIndex = 439;
            // 
            // FrmDossierAccouchement2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.txtIdMedecinCons);
            this.Controls.Add(this.txtIdMalade);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Name = "FrmDossierAccouchement2";
            this.Size = new System.Drawing.Size(627, 187);
            this.Load += new System.EventHandler(this.frmDossierConsultationPaiement_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.TextBox txtEtatConsommation;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cboService;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker txtDateOuvertureDossier;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIdMalade;
        private System.Windows.Forms.TextBox txtIdMedecinCons;
        private System.Windows.Forms.ListBox lstDossierEncCours;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Label lblAddTarif;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.Label label5;
    }
}
