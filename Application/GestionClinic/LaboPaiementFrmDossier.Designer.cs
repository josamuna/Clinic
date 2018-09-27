namespace GestionClinic_WIN
{
    partial class LaboPaiementFrmDossier
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAddTarif = new System.Windows.Forms.Label();
            this.cboExamen = new System.Windows.Forms.ComboBox();
            this.txtetatPaiement = new System.Windows.Forms.TextBox();
            this.txtDateOuvertureDossier = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lstDossierEncCours = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdMedecinCons = new System.Windows.Forms.TextBox();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAddDossier = new System.Windows.Forms.ToolStripButton();
            this.btnRefreshDossier = new System.Windows.Forms.ToolStripButton();
            this.btnSaveDossier = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.txtIdMalade = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
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
            this.tabPage1.Controls.Add(this.cboExamen);
            this.tabPage1.Controls.Add(this.txtetatPaiement);
            this.tabPage1.Controls.Add(this.txtDateOuvertureDossier);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.lstDossierEncCours);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtIdMedecinCons);
            this.tabPage1.Controls.Add(this.bindingNavigator1);
            this.tabPage1.Controls.Add(this.txtIdMalade);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(613, 147);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Laboratoire";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(318, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 463;
            this.label6.Text = "$ US";
            // 
            // txtPrix
            // 
            this.txtPrix.Enabled = false;
            this.txtPrix.Location = new System.Drawing.Point(152, 92);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(164, 20);
            this.txtPrix.TabIndex = 462;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(7, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 461;
            this.label5.Text = "Prix :";
            // 
            // lblAddTarif
            // 
            this.lblAddTarif.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAddTarif.Location = new System.Drawing.Point(318, 64);
            this.lblAddTarif.Name = "lblAddTarif";
            this.lblAddTarif.Size = new System.Drawing.Size(25, 22);
            this.lblAddTarif.TabIndex = 460;
            this.lblAddTarif.Click += new System.EventHandler(this.lblAddTarif_Click);
            // 
            // cboExamen
            // 
            this.cboExamen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboExamen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboExamen.FormattingEnabled = true;
            this.cboExamen.Location = new System.Drawing.Point(152, 65);
            this.cboExamen.Name = "cboExamen";
            this.cboExamen.Size = new System.Drawing.Size(164, 21);
            this.cboExamen.TabIndex = 459;
            this.cboExamen.SelectedIndexChanged += new System.EventHandler(this.cboExamen_SelectedIndexChanged);
            this.cboExamen.DropDown += new System.EventHandler(this.cboExamen_DropDown);
            // 
            // txtetatPaiement
            // 
            this.txtetatPaiement.Enabled = false;
            this.txtetatPaiement.Location = new System.Drawing.Point(152, 118);
            this.txtetatPaiement.Name = "txtetatPaiement";
            this.txtetatPaiement.Size = new System.Drawing.Size(164, 20);
            this.txtetatPaiement.TabIndex = 458;
            // 
            // txtDateOuvertureDossier
            // 
            this.txtDateOuvertureDossier.Location = new System.Drawing.Point(152, 35);
            this.txtDateOuvertureDossier.Name = "txtDateOuvertureDossier";
            this.txtDateOuvertureDossier.Size = new System.Drawing.Size(164, 20);
            this.txtDateOuvertureDossier.TabIndex = 457;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(6, 68);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 13);
            this.label22.TabIndex = 451;
            this.label22.Text = "Service consommé :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(6, 44);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(143, 13);
            this.label23.TabIndex = 453;
            this.label23.Text = "Date d\'ouverture du dossier :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(6, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 455;
            this.label12.Text = "Etat du dossier";
            // 
            // lstDossierEncCours
            // 
            this.lstDossierEncCours.FormattingEnabled = true;
            this.lstDossierEncCours.Location = new System.Drawing.Point(358, 42);
            this.lstDossierEncCours.Name = "lstDossierEncCours";
            this.lstDossierEncCours.Size = new System.Drawing.Size(246, 95);
            this.lstDossierEncCours.TabIndex = 450;
            this.lstDossierEncCours.SelectedIndexChanged += new System.EventHandler(this.lstDossierEncCours_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(356, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 448;
            this.label2.Text = "Référence Date ouverture ";
            // 
            // txtIdMedecinCons
            // 
            this.txtIdMedecinCons.Location = new System.Drawing.Point(624, 39);
            this.txtIdMedecinCons.Name = "txtIdMedecinCons";
            this.txtIdMedecinCons.Size = new System.Drawing.Size(43, 20);
            this.txtIdMedecinCons.TabIndex = 425;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.AutoSize = false;
            this.bindingNavigator1.BackColor = System.Drawing.Color.Transparent;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddDossier,
            this.btnRefreshDossier,
            this.btnSaveDossier,
            this.btnDelete});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 3);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bindingNavigator1.Size = new System.Drawing.Size(607, 27);
            this.bindingNavigator1.TabIndex = 297;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // btnAddDossier
            // 
            this.btnAddDossier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddDossier.Image = global::GestionClinic_WIN.Properties.Resources.navBarAddIcon_2x;
            this.btnAddDossier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDossier.Name = "btnAddDossier";
            this.btnAddDossier.Size = new System.Drawing.Size(23, 24);
            this.btnAddDossier.Text = "Ajouter";
            this.btnAddDossier.Click += new System.EventHandler(this.btnAddDossier_Click);
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
            this.btnRefreshDossier.Click += new System.EventHandler(this.btnRefreshDossier_Click);
            // 
            // btnSaveDossier
            // 
            this.btnSaveDossier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveDossier.Image = global::GestionClinic_WIN.Properties.Resources.check_2x;
            this.btnSaveDossier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveDossier.Name = "btnSaveDossier";
            this.btnSaveDossier.Size = new System.Drawing.Size(23, 24);
            this.btnSaveDossier.Text = "Mis à jour";
            this.btnSaveDossier.Click += new System.EventHandler(this.btnSaveDossier_Click);
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
            this.txtIdMalade.Location = new System.Drawing.Point(614, 15);
            this.txtIdMalade.Name = "txtIdMalade";
            this.txtIdMalade.Size = new System.Drawing.Size(38, 20);
            this.txtIdMalade.TabIndex = 424;
            // 
            // FrmDossierLaboPaiement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.img_home_player_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(622, 176);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "FrmDossierLaboPaiement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dossier laboratoire";
            this.Load += new System.EventHandler(this.FrmDossierLaboPaiement_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAddTarif;
        private System.Windows.Forms.ComboBox cboExamen;
        private System.Windows.Forms.TextBox txtetatPaiement;
        private System.Windows.Forms.DateTimePicker txtDateOuvertureDossier;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lstDossierEncCours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdMedecinCons;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton btnAddDossier;
        private System.Windows.Forms.ToolStripButton btnRefreshDossier;
        private System.Windows.Forms.ToolStripButton btnSaveDossier;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.TextBox txtIdMalade;
    }
}