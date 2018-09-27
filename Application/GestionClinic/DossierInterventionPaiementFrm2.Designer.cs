namespace GestionClinic_WIN
{
    partial class DossierInterventionPaiementFrm2
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
            this.label2 = new System.Windows.Forms.Label();
            this.lstDossierEncCours1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPaiement = new System.Windows.Forms.TextBox();
            this.cboIntervention = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.txtId_malade = new System.Windows.Forms.TextBox();
            this.txtObservation = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(621, 173);
            this.tabControl1.TabIndex = 437;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtPrix);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lblAddTarif);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lstDossierEncCours1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtPaiement);
            this.tabPage1.Controls.Add(this.cboIntervention);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.txtDate);
            this.tabPage1.Controls.Add(this.bindingNavigator1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(613, 147);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Intervention";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(295, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 464;
            this.label6.Text = "$ US";
            // 
            // txtPrix
            // 
            this.txtPrix.Enabled = false;
            this.txtPrix.Location = new System.Drawing.Point(102, 90);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(183, 20);
            this.txtPrix.TabIndex = 463;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(13, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 462;
            this.label5.Text = "Prix :";
            // 
            // lblAddTarif
            // 
            this.lblAddTarif.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAddTarif.Location = new System.Drawing.Point(289, 62);
            this.lblAddTarif.Name = "lblAddTarif";
            this.lblAddTarif.Size = new System.Drawing.Size(25, 22);
            this.lblAddTarif.TabIndex = 461;
            this.lblAddTarif.Click += new System.EventHandler(this.lblAddTarif_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(335, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 436;
            this.label2.Text = "Référence Date ouverture ";
            // 
            // lstDossierEncCours1
            // 
            this.lstDossierEncCours1.FormattingEnabled = true;
            this.lstDossierEncCours1.Location = new System.Drawing.Point(338, 37);
            this.lstDossierEncCours1.Name = "lstDossierEncCours1";
            this.lstDossierEncCours1.Size = new System.Drawing.Size(264, 95);
            this.lstDossierEncCours1.TabIndex = 431;
            this.lstDossierEncCours1.SelectedIndexChanged += new System.EventHandler(this.lstDossierEncCours1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 266;
            this.label1.Text = "Etat du dossier :";
            // 
            // txtPaiement
            // 
            this.txtPaiement.Enabled = false;
            this.txtPaiement.Location = new System.Drawing.Point(102, 114);
            this.txtPaiement.Multiline = true;
            this.txtPaiement.Name = "txtPaiement";
            this.txtPaiement.Size = new System.Drawing.Size(183, 22);
            this.txtPaiement.TabIndex = 265;
            // 
            // cboIntervention
            // 
            this.cboIntervention.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboIntervention.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboIntervention.FormattingEnabled = true;
            this.cboIntervention.Location = new System.Drawing.Point(102, 64);
            this.cboIntervention.Name = "cboIntervention";
            this.cboIntervention.Size = new System.Drawing.Size(184, 21);
            this.cboIntervention.TabIndex = 262;
            this.cboIntervention.SelectedIndexChanged += new System.EventHandler(this.cboIntervention_SelectedIndexChanged);
            this.cboIntervention.DropDown += new System.EventHandler(this.cboIntervention_DropDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 195;
            this.label11.Text = "Date :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 263;
            this.label15.Text = "Intervention :";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(102, 37);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(184, 20);
            this.txtDate.TabIndex = 184;
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
            this.bindingNavigator1.Size = new System.Drawing.Size(607, 27);
            this.bindingNavigator1.TabIndex = 432;
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
            // txtId_malade
            // 
            this.txtId_malade.Location = new System.Drawing.Point(232, 207);
            this.txtId_malade.Name = "txtId_malade";
            this.txtId_malade.Size = new System.Drawing.Size(100, 20);
            this.txtId_malade.TabIndex = 438;
            // 
            // txtObservation
            // 
            this.txtObservation.Location = new System.Drawing.Point(338, 207);
            this.txtObservation.Name = "txtObservation";
            this.txtObservation.Size = new System.Drawing.Size(100, 20);
            this.txtObservation.TabIndex = 439;
            // 
            // frmDossierInterventionPaiement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.txtObservation);
            this.Controls.Add(this.txtId_malade);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Name = "frmDossierInterventionPaiement";
            this.Size = new System.Drawing.Size(627, 187);
            this.Load += new System.EventHandler(this.frmDossierInterventionPaiement_Load);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPaiement;
        private System.Windows.Forms.ComboBox cboIntervention;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.ListBox lstDossierEncCours1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId_malade;
        private System.Windows.Forms.TextBox txtObservation;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Label lblAddTarif;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.Label label5;
    }
}
