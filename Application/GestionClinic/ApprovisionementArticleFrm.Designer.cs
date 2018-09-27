namespace GestionClinic_WIN
{
    partial class ApprovisionementArticleFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bnvCandidat = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRefreh = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.lblConditionnement = new System.Windows.Forms.Label();
            this.cboConditionnement = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateExpiration = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.txtQuantite = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPUAchat = new System.Windows.Forms.TextBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedicament = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_article = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConditionnement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_fournisseur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.chkAfficheAll = new System.Windows.Forms.CheckBox();
            this.txtDateSortie = new System.Windows.Forms.DateTimePicker();
            this.PuAchat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateexpiration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Quantinte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAddArticle = new System.Windows.Forms.Label();
            this.cboFournisseur = new System.Windows.Forms.ComboBox();
            this.cboArticle = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCandidat)).BeginInit();
            this.bnvCandidat.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.bnvCandidat);
            this.groupBox1.Location = new System.Drawing.Point(2, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(719, 42);
            this.groupBox1.TabIndex = 206;
            this.groupBox1.TabStop = false;
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
            // lblConditionnement
            // 
            this.lblConditionnement.BackColor = System.Drawing.Color.Transparent;
            this.lblConditionnement.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblConditionnement.Location = new System.Drawing.Point(337, 91);
            this.lblConditionnement.Name = "lblConditionnement";
            this.lblConditionnement.Size = new System.Drawing.Size(25, 21);
            this.lblConditionnement.TabIndex = 8;
            this.lblConditionnement.Click += new System.EventHandler(this.lblConditionnement_Click);
            // 
            // cboConditionnement
            // 
            this.cboConditionnement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConditionnement.FormattingEnabled = true;
            this.cboConditionnement.Location = new System.Drawing.Point(143, 91);
            this.cboConditionnement.Name = "cboConditionnement";
            this.cboConditionnement.Size = new System.Drawing.Size(190, 21);
            this.cboConditionnement.TabIndex = 3;
            this.cboConditionnement.DropDown += new System.EventHandler(this.cboConditionnement_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(11, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 293;
            this.label3.Text = "Conditionnement :";
            // 
            // txtDateExpiration
            // 
            this.txtDateExpiration.Location = new System.Drawing.Point(532, 68);
            this.txtDateExpiration.Name = "txtDateExpiration";
            this.txtDateExpiration.Size = new System.Drawing.Size(163, 20);
            this.txtDateExpiration.TabIndex = 6;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(397, 71);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(89, 13);
            this.label19.TabIndex = 290;
            this.label19.Text = "Date d\'éxpiration:";
            // 
            // txtQuantite
            // 
            this.txtQuantite.Location = new System.Drawing.Point(532, 13);
            this.txtQuantite.Name = "txtQuantite";
            this.txtQuantite.Size = new System.Drawing.Size(126, 20);
            this.txtQuantite.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(397, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 287;
            this.label2.Text = "Quatinté :";
            // 
            // txtPUAchat
            // 
            this.txtPUAchat.Location = new System.Drawing.Point(532, 42);
            this.txtPUAchat.Name = "txtPUAchat";
            this.txtPUAchat.Size = new System.Drawing.Size(126, 20);
            this.txtPUAchat.TabIndex = 5;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "N°Lot";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 50;
            // 
            // colMedicament
            // 
            this.colMedicament.DataPropertyName = "Designation";
            this.colMedicament.HeaderText = "Médicament";
            this.colMedicament.Name = "colMedicament";
            this.colMedicament.ReadOnly = true;
            this.colMedicament.Width = 200;
            // 
            // Id_article
            // 
            this.Id_article.DataPropertyName = "Id_article";
            this.Id_article.HeaderText = "Id_article";
            this.Id_article.Name = "Id_article";
            this.Id_article.ReadOnly = true;
            this.Id_article.Visible = false;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date livraison";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 95;
            // 
            // colConditionnement
            // 
            this.colConditionnement.DataPropertyName = "Id_conditionnement";
            this.colConditionnement.HeaderText = "Id_conditionnement";
            this.colConditionnement.Name = "colConditionnement";
            this.colConditionnement.ReadOnly = true;
            this.colConditionnement.Visible = false;
            this.colConditionnement.Width = 110;
            // 
            // colStock_out
            // 
            this.colStock_out.DataPropertyName = "Stock_out";
            this.colStock_out.HeaderText = "Valeur stock";
            this.colStock_out.Name = "colStock_out";
            this.colStock_out.ReadOnly = true;
            this.colStock_out.Width = 95;
            // 
            // Id_fournisseur
            // 
            this.Id_fournisseur.DataPropertyName = "Id_fournisseur";
            this.Id_fournisseur.HeaderText = "Id_fournisseur";
            this.Id_fournisseur.Name = "Id_fournisseur";
            this.Id_fournisseur.ReadOnly = true;
            this.Id_fournisseur.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.chkAfficheAll);
            this.groupBox4.Controls.Add(this.txtDateSortie);
            this.groupBox4.Location = new System.Drawing.Point(14, 121);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(682, 57);
            this.groupBox4.TabIndex = 319;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sélection de la date pour affichage des approvisionnements";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Location = new System.Drawing.Point(286, 25);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(36, 13);
            this.label27.TabIndex = 318;
            this.label27.Text = "Date :";
            // 
            // chkAfficheAll
            // 
            this.chkAfficheAll.BackColor = System.Drawing.Color.AntiqueWhite;
            this.chkAfficheAll.ForeColor = System.Drawing.Color.Maroon;
            this.chkAfficheAll.Location = new System.Drawing.Point(184, 23);
            this.chkAfficheAll.Name = "chkAfficheAll";
            this.chkAfficheAll.Size = new System.Drawing.Size(88, 18);
            this.chkAfficheAll.TabIndex = 316;
            this.chkAfficheAll.Text = "Tous afficher";
            this.chkAfficheAll.UseVisualStyleBackColor = false;
            // 
            // txtDateSortie
            // 
            this.txtDateSortie.Location = new System.Drawing.Point(326, 21);
            this.txtDateSortie.Name = "txtDateSortie";
            this.txtDateSortie.Size = new System.Drawing.Size(167, 20);
            this.txtDateSortie.TabIndex = 317;
            // 
            // PuAchat
            // 
            this.PuAchat.DataPropertyName = "PuAchat";
            this.PuAchat.HeaderText = "PU achat";
            this.PuAchat.Name = "PuAchat";
            this.PuAchat.ReadOnly = true;
            this.PuAchat.Width = 75;
            // 
            // dateexpiration
            // 
            this.dateexpiration.DataPropertyName = "Dateexpiration";
            this.dateexpiration.HeaderText = "Date expiration";
            this.dateexpiration.Name = "dateexpiration";
            this.dateexpiration.ReadOnly = true;
            this.dateexpiration.Width = 103;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.colMedicament,
            this.Date,
            this.dateexpiration,
            this.Quantinte,
            this.PuAchat,
            this.colStock_out,
            this.Id_article,
            this.colConditionnement,
            this.Id_fournisseur});
            this.dgv.Location = new System.Drawing.Point(7, 20);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(668, 279);
            this.dgv.TabIndex = 213;
            this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
            // 
            // Quantinte
            // 
            this.Quantinte.DataPropertyName = "Quantinte";
            this.Quantinte.HeaderText = "Qté";
            this.Quantinte.Name = "Quantinte";
            this.Quantinte.ReadOnly = true;
            this.Quantinte.Width = 40;
            // 
            // lblAddArticle
            // 
            this.lblAddArticle.BackColor = System.Drawing.Color.Transparent;
            this.lblAddArticle.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAddArticle.Location = new System.Drawing.Point(337, 12);
            this.lblAddArticle.Name = "lblAddArticle";
            this.lblAddArticle.Size = new System.Drawing.Size(25, 21);
            this.lblAddArticle.TabIndex = 7;
            this.lblAddArticle.Click += new System.EventHandler(this.lblAddArticle_Click);
            // 
            // cboFournisseur
            // 
            this.cboFournisseur.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFournisseur.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFournisseur.FormattingEnabled = true;
            this.cboFournisseur.Items.AddRange(new object[] {
            "Masculin",
            "Feminin"});
            this.cboFournisseur.Location = new System.Drawing.Point(142, 38);
            this.cboFournisseur.Name = "cboFournisseur";
            this.cboFournisseur.Size = new System.Drawing.Size(216, 21);
            this.cboFournisseur.TabIndex = 1;
            // 
            // cboArticle
            // 
            this.cboArticle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboArticle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboArticle.FormattingEnabled = true;
            this.cboArticle.Location = new System.Drawing.Point(143, 12);
            this.cboArticle.Name = "cboArticle";
            this.cboArticle.Size = new System.Drawing.Size(190, 21);
            this.cboArticle.TabIndex = 0;
            this.cboArticle.DropDown += new System.EventHandler(this.cboArticle_DropDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(11, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 267;
            this.label10.Text = "Article:";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(142, 65);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(216, 20);
            this.txtDate.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(10, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 265;
            this.label12.Text = "Fourniseur :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(10, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 264;
            this.label13.Text = "Date :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(397, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 285;
            this.label18.Text = "Prix achat :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv);
            this.groupBox2.Location = new System.Drawing.Point(13, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(682, 309);
            this.groupBox2.TabIndex = 269;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Détails approvisionnement";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.lblConditionnement);
            this.tabPage1.Controls.Add(this.cboConditionnement);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtDateExpiration);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.txtQuantite);
            this.tabPage1.Controls.Add(this.txtPUAchat);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.lblAddArticle);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.cboFournisseur);
            this.tabPage1.Controls.Add(this.cboArticle);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtDate);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(704, 503);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Article";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(298, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(130, 23);
            this.label16.TabIndex = 207;
            this.label16.Text = "Approvisionnement";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(9, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(712, 529);
            this.tabControl1.TabIndex = 208;
            // 
            // FrmApprovisionementArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.img_home_player_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(723, 582);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmApprovisionementArticle";
            this.Text = "Approvisionnement";
            this.Load += new System.EventHandler(this.FrmApprovisionementArticle_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmApprovisionementArticle_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCandidat)).EndInit();
            this.bnvCandidat.ResumeLayout(false);
            this.bnvCandidat.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingNavigator bnvCandidat;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnRefreh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Label lblConditionnement;
        private System.Windows.Forms.ComboBox cboConditionnement;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtDateExpiration;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtQuantite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPUAchat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicament;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_article;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConditionnement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock_out;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_fournisseur;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox chkAfficheAll;
        private System.Windows.Forms.DateTimePicker txtDateSortie;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuAchat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateexpiration;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantinte;
        private System.Windows.Forms.Label lblAddArticle;
        private System.Windows.Forms.ComboBox cboFournisseur;
        private System.Windows.Forms.ComboBox cboArticle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabControl tabControl1;
    }
}