namespace GestionClinic_WIN
{
    partial class DossierAvanceFrm
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
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.txtIdAgent = new System.Windows.Forms.TextBox();
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
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(568, 142);
            this.tabControl1.TabIndex = 438;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
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
            this.tabPage1.Size = new System.Drawing.Size(560, 116);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Avance";
            // 
            // lstDossierEncCours
            // 
            this.lstDossierEncCours.FormattingEnabled = true;
            this.lstDossierEncCours.Location = new System.Drawing.Point(320, 40);
            this.lstDossierEncCours.Name = "lstDossierEncCours";
            this.lstDossierEncCours.Size = new System.Drawing.Size(236, 69);
            this.lstDossierEncCours.TabIndex = 448;
            this.lstDossierEncCours.SelectedIndexChanged += new System.EventHandler(this.lstDossierEncCours_SelectedIndexChanged);
            // 
            // txtEtatConsommation
            // 
            this.txtEtatConsommation.Enabled = false;
            this.txtEtatConsommation.Location = new System.Drawing.Point(149, 89);
            this.txtEtatConsommation.Name = "txtEtatConsommation";
            this.txtEtatConsommation.Size = new System.Drawing.Size(166, 20);
            this.txtEtatConsommation.TabIndex = 447;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(3, 68);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(103, 13);
            this.label22.TabIndex = 441;
            this.label22.Text = "Service consommé :";
            // 
            // cboService
            // 
            this.cboService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboService.FormattingEnabled = true;
            this.cboService.Location = new System.Drawing.Point(149, 63);
            this.cboService.Name = "cboService";
            this.cboService.Size = new System.Drawing.Size(166, 21);
            this.cboService.TabIndex = 442;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(3, 43);
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
            this.label12.Location = new System.Drawing.Point(3, 92);
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
            this.label2.Location = new System.Drawing.Point(321, 22);
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
            this.btnDelete});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 3);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNavigator1.Size = new System.Drawing.Size(554, 27);
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
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::GestionClinic_WIN.Properties.Resources.mp_delete_md_n_lt_2x;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 24);
            this.btnDelete.Text = "Supprimer";
            // 
            // txtIdAgent
            // 
            this.txtIdAgent.Location = new System.Drawing.Point(401, 177);
            this.txtIdAgent.Name = "txtIdAgent";
            this.txtIdAgent.Size = new System.Drawing.Size(100, 20);
            this.txtIdAgent.TabIndex = 441;
            // 
            // txtIdMalade
            // 
            this.txtIdMalade.Location = new System.Drawing.Point(292, 177);
            this.txtIdMalade.Name = "txtIdMalade";
            this.txtIdMalade.Size = new System.Drawing.Size(100, 20);
            this.txtIdMalade.TabIndex = 440;
            // 
            // FrmDossierAvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.img_home_player_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(566, 144);
            this.Controls.Add(this.txtIdAgent);
            this.Controls.Add(this.txtIdMalade);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmDossierAvance";
            this.Text = "Dossier avance";
            this.Load += new System.EventHandler(this.FrmDossierAvance_Load);
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
        private System.Windows.Forms.ListBox lstDossierEncCours;
        private System.Windows.Forms.TextBox txtEtatConsommation;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cboService;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker txtDateOuvertureDossier;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.TextBox txtIdAgent;
        private System.Windows.Forms.TextBox txtIdMalade;
    }
}