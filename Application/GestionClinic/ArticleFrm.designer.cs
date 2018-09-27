namespace GestionClinic_WIN
{
    partial class ArticleFrm
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
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bnvFonction = new System.Windows.Forms.BindingNavigator(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtPU = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCaracteristique = new System.Windows.Forms.TextBox();
            this.dgvMedicament = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtStkAlert = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.colDesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cloStock_alert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clCaracteristique = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_de_sortie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantite_de_sortie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom_classe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesignationComplete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFiche_supplementaire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkFicheSupplementaire = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bnvFonction)).BeginInit();
            this.bnvFonction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicament)).BeginInit();
            this.SuspendLayout();
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
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::GestionClinic_WIN.Properties.Resources.navBarAddIcon_2x;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.Click += new System.EventHandler(this.btnAddFonction_Click);
            // 
            // txtDesignation
            // 
            this.txtDesignation.Location = new System.Drawing.Point(100, 43);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(157, 20);
            this.txtDesignation.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "PU:";
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
            this.bnvFonction.Size = new System.Drawing.Size(820, 25);
            this.bnvFonction.TabIndex = 60;
            this.bnvFonction.Text = "bindingNavigator1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Designation :";
            // 
            // txtPU
            // 
            this.txtPU.Location = new System.Drawing.Point(100, 69);
            this.txtPU.Name = "txtPU";
            this.txtPU.Size = new System.Drawing.Size(120, 20);
            this.txtPU.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(4, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 258;
            this.label3.Text = "Caractèristique :";
            // 
            // txtCaracteristique
            // 
            this.txtCaracteristique.Location = new System.Drawing.Point(100, 95);
            this.txtCaracteristique.Multiline = true;
            this.txtCaracteristique.Name = "txtCaracteristique";
            this.txtCaracteristique.Size = new System.Drawing.Size(157, 57);
            this.txtCaracteristique.TabIndex = 2;
            // 
            // dgvMedicament
            // 
            this.dgvMedicament.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicament.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicament.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDesignation,
            this.colStock,
            this.ColPu,
            this.cloStock_alert,
            this.clCaracteristique,
            this.ColId,
            this.colId_de_sortie,
            this.colQuantite_de_sortie,
            this.colNom_classe,
            this.colDesignationComplete,
            this.colFiche_supplementaire});
            this.dgvMedicament.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvMedicament.Location = new System.Drawing.Point(267, 43);
            this.dgvMedicament.MultiSelect = false;
            this.dgvMedicament.Name = "dgvMedicament";
            this.dgvMedicament.ReadOnly = true;
            this.dgvMedicament.RowHeadersVisible = false;
            this.dgvMedicament.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicament.Size = new System.Drawing.Size(540, 157);
            this.dgvMedicament.TabIndex = 260;
            this.dgvMedicament.SelectionChanged += new System.EventHandler(this.dgvMedicament_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(221, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 264;
            this.label4.Text = "$ US";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(403, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(86, 20);
            this.label16.TabIndex = 347;
            this.label16.Text = "Articles";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 349;
            this.label5.Text = "Valeur en stock :";
            // 
            // txtStock
            // 
            this.txtStock.Enabled = false;
            this.txtStock.ForeColor = System.Drawing.Color.Red;
            this.txtStock.Location = new System.Drawing.Point(101, 180);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(119, 20);
            this.txtStock.TabIndex = 355;
            // 
            // txtStkAlert
            // 
            this.txtStkAlert.Location = new System.Drawing.Point(101, 154);
            this.txtStkAlert.Name = "txtStkAlert";
            this.txtStkAlert.Size = new System.Drawing.Size(157, 20);
            this.txtStkAlert.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 357;
            this.label6.Text = "Valeur stock alert :";
            // 
            // colDesignation
            // 
            this.colDesignation.DataPropertyName = "Desination";
            this.colDesignation.HeaderText = "Désignation";
            this.colDesignation.Name = "colDesignation";
            this.colDesignation.ReadOnly = true;
            this.colDesignation.Width = 180;
            // 
            // colStock
            // 
            this.colStock.DataPropertyName = "Stock";
            this.colStock.HeaderText = "Stock";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            this.colStock.Width = 90;
            // 
            // ColPu
            // 
            this.ColPu.DataPropertyName = "Pu";
            this.ColPu.HeaderText = "PU";
            this.ColPu.Name = "ColPu";
            this.ColPu.ReadOnly = true;
            this.ColPu.Width = 70;
            // 
            // cloStock_alert
            // 
            this.cloStock_alert.DataPropertyName = "Stock_alert";
            this.cloStock_alert.HeaderText = "Stock d\'alert";
            this.cloStock_alert.Name = "cloStock_alert";
            this.cloStock_alert.ReadOnly = true;
            // 
            // clCaracteristique
            // 
            this.clCaracteristique.DataPropertyName = "Caracteristique";
            this.clCaracteristique.HeaderText = "Caractéristique";
            this.clCaracteristique.Name = "clCaracteristique";
            this.clCaracteristique.ReadOnly = true;
            this.clCaracteristique.Width = 110;
            // 
            // ColId
            // 
            this.ColId.DataPropertyName = "Id";
            this.ColId.HeaderText = "Id";
            this.ColId.Name = "ColId";
            this.ColId.ReadOnly = true;
            this.ColId.Visible = false;
            // 
            // colId_de_sortie
            // 
            this.colId_de_sortie.DataPropertyName = "Id_de_sortie";
            this.colId_de_sortie.HeaderText = "Id_de_sortie";
            this.colId_de_sortie.Name = "colId_de_sortie";
            this.colId_de_sortie.ReadOnly = true;
            this.colId_de_sortie.Visible = false;
            // 
            // colQuantite_de_sortie
            // 
            this.colQuantite_de_sortie.DataPropertyName = "Quantite_de_sortie";
            this.colQuantite_de_sortie.HeaderText = "Quantite_de_sortie";
            this.colQuantite_de_sortie.Name = "colQuantite_de_sortie";
            this.colQuantite_de_sortie.ReadOnly = true;
            this.colQuantite_de_sortie.Visible = false;
            // 
            // colNom_classe
            // 
            this.colNom_classe.DataPropertyName = "Nom_classe";
            this.colNom_classe.HeaderText = "Nom_classe";
            this.colNom_classe.Name = "colNom_classe";
            this.colNom_classe.ReadOnly = true;
            this.colNom_classe.Visible = false;
            // 
            // colDesignationComplete
            // 
            this.colDesignationComplete.DataPropertyName = "DesignationComplete";
            this.colDesignationComplete.HeaderText = "DesignationComplete";
            this.colDesignationComplete.Name = "colDesignationComplete";
            this.colDesignationComplete.ReadOnly = true;
            this.colDesignationComplete.Visible = false;
            // 
            // colFiche_supplementaire
            // 
            this.colFiche_supplementaire.DataPropertyName = "Fiche_supplementaire";
            this.colFiche_supplementaire.HeaderText = "Fiche_supplementaire";
            this.colFiche_supplementaire.Name = "colFiche_supplementaire";
            this.colFiche_supplementaire.ReadOnly = true;
            this.colFiche_supplementaire.Visible = false;
            // 
            // chkFicheSupplementaire
            // 
            this.chkFicheSupplementaire.AutoSize = true;
            this.chkFicheSupplementaire.BackColor = System.Drawing.Color.MistyRose;
            this.chkFicheSupplementaire.ForeColor = System.Drawing.Color.DarkGreen;
            this.chkFicheSupplementaire.Location = new System.Drawing.Point(204, 7);
            this.chkFicheSupplementaire.Name = "chkFicheSupplementaire";
            this.chkFicheSupplementaire.Size = new System.Drawing.Size(179, 17);
            this.chkFicheSupplementaire.TabIndex = 361;
            this.chkFicheSupplementaire.Text = "Ajout pour fiche supplémentaires";
            this.chkFicheSupplementaire.UseVisualStyleBackColor = false;
            this.chkFicheSupplementaire.Visible = false;
            // 
            // FrmArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(820, 211);
            this.Controls.Add(this.chkFicheSupplementaire);
            this.Controls.Add(this.txtStkAlert);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvMedicament);
            this.Controls.Add(this.txtCaracteristique);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDesignation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPU);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnvFonction);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmArticle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Articles";
            this.Load += new System.EventHandler(this.FrmMedicament_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmArticle_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bnvFonction)).EndInit();
            this.bnvFonction.ResumeLayout(false);
            this.bnvFonction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicament)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingNavigator bnvFonction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPU;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCaracteristique;
        private System.Windows.Forms.DataGridView dgvMedicament;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtStkAlert;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesignation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPu;
        private System.Windows.Forms.DataGridViewTextBoxColumn cloStock_alert;
        private System.Windows.Forms.DataGridViewTextBoxColumn clCaracteristique;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_de_sortie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantite_de_sortie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom_classe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesignationComplete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFiche_supplementaire;
        private System.Windows.Forms.CheckBox chkFicheSupplementaire;
    }
}