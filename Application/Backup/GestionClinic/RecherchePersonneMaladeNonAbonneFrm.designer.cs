namespace GestionClinic_WIN
{
    partial class RecherchePersonneMaladeNonAbonneFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dlgFile = new System.Windows.Forms.OpenFileDialog();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.dgvMalade = new System.Windows.Forms.DataGridView();
            this.colnom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_fiche = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAgePers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Postnom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdPers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom_complet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colsexe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coletatcivil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldatenaissance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coladresse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colphoto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colidMal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colid_personne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colid_airsante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colid_categoriemalade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colid_etablissement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colid_profession = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colnumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colid_groupesanguin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalade)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlgFile
            // 
            this.dlgFile.FileName = "openFileDialog1";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(250, 9);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(201, 20);
            this.txtSearch.TabIndex = 19;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(6, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(243, 13);
            this.label14.TabIndex = 67;
            this.label14.Text = "Elément à rechercher (Nom,Postnom ou Prénom) :";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(105, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(254, 20);
            this.label10.TabIndex = 211;
            this.label10.Text = "Rechercher un malade (Privé seulement)";
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
            this.bindingNavigator1.Size = new System.Drawing.Size(458, 25);
            this.bindingNavigator1.TabIndex = 210;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // dgvMalade
            // 
            this.dgvMalade.BackgroundColor = System.Drawing.Color.White;
            this.dgvMalade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMalade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colnom,
            this.numero_fiche,
            this.colAgePers,
            this.Postnom,
            this.colPrenom,
            this.colIdPers,
            this.colNom_complet,
            this.colid,
            this.colsexe,
            this.coletatcivil,
            this.coldatenaissance,
            this.coladresse,
            this.coltelephone,
            this.colphoto,
            this.colidMal,
            this.colid_personne,
            this.colid_airsante,
            this.colid_categoriemalade,
            this.colid_etablissement,
            this.colid_profession,
            this.colnumero,
            this.colid_groupesanguin});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMalade.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMalade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMalade.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvMalade.Location = new System.Drawing.Point(0, 0);
            this.dgvMalade.MultiSelect = false;
            this.dgvMalade.Name = "dgvMalade";
            this.dgvMalade.ReadOnly = true;
            this.dgvMalade.RowHeadersVisible = false;
            this.dgvMalade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMalade.Size = new System.Drawing.Size(458, 426);
            this.dgvMalade.TabIndex = 212;
            this.dgvMalade.DoubleClick += new System.EventHandler(this.dgvMalade_DoubleClick);
            // 
            // colnom
            // 
            this.colnom.DataPropertyName = "nom";
            this.colnom.HeaderText = "Nom complet de la personne";
            this.colnom.Name = "colnom";
            this.colnom.ReadOnly = true;
            this.colnom.Width = 435;
            // 
            // numero_fiche
            // 
            this.numero_fiche.DataPropertyName = "numero_fiche";
            this.numero_fiche.HeaderText = "colnumero_fiche";
            this.numero_fiche.Name = "numero_fiche";
            this.numero_fiche.ReadOnly = true;
            this.numero_fiche.Visible = false;
            // 
            // colAgePers
            // 
            this.colAgePers.DataPropertyName = "AgePers";
            this.colAgePers.HeaderText = "AgePers";
            this.colAgePers.Name = "colAgePers";
            this.colAgePers.ReadOnly = true;
            this.colAgePers.Visible = false;
            // 
            // Postnom
            // 
            this.Postnom.DataPropertyName = "Postnom";
            this.Postnom.HeaderText = "Postnom";
            this.Postnom.Name = "Postnom";
            this.Postnom.ReadOnly = true;
            this.Postnom.Visible = false;
            // 
            // colPrenom
            // 
            this.colPrenom.DataPropertyName = "Prenom";
            this.colPrenom.HeaderText = "Prenom";
            this.colPrenom.Name = "colPrenom";
            this.colPrenom.ReadOnly = true;
            this.colPrenom.Visible = false;
            // 
            // colIdPers
            // 
            this.colIdPers.DataPropertyName = "IdPers";
            this.colIdPers.HeaderText = "IdPers";
            this.colIdPers.Name = "colIdPers";
            this.colIdPers.ReadOnly = true;
            this.colIdPers.Visible = false;
            // 
            // colNom_complet
            // 
            this.colNom_complet.DataPropertyName = "Nom_complet";
            this.colNom_complet.HeaderText = "Nom_complet";
            this.colNom_complet.Name = "colNom_complet";
            this.colNom_complet.ReadOnly = true;
            this.colNom_complet.Visible = false;
            // 
            // colid
            // 
            this.colid.DataPropertyName = "id";
            this.colid.HeaderText = "id";
            this.colid.Name = "colid";
            this.colid.ReadOnly = true;
            this.colid.Visible = false;
            // 
            // colsexe
            // 
            this.colsexe.DataPropertyName = "sexe";
            this.colsexe.HeaderText = "sexe";
            this.colsexe.Name = "colsexe";
            this.colsexe.ReadOnly = true;
            this.colsexe.Visible = false;
            // 
            // coletatcivil
            // 
            this.coletatcivil.DataPropertyName = "etatcivil";
            this.coletatcivil.HeaderText = "etatcivil";
            this.coletatcivil.Name = "coletatcivil";
            this.coletatcivil.ReadOnly = true;
            this.coletatcivil.Visible = false;
            // 
            // coldatenaissance
            // 
            this.coldatenaissance.DataPropertyName = "datenaissance";
            this.coldatenaissance.HeaderText = "datenaissance";
            this.coldatenaissance.Name = "coldatenaissance";
            this.coldatenaissance.ReadOnly = true;
            this.coldatenaissance.Visible = false;
            // 
            // coladresse
            // 
            this.coladresse.DataPropertyName = "adresse";
            this.coladresse.HeaderText = "adresse";
            this.coladresse.Name = "coladresse";
            this.coladresse.ReadOnly = true;
            this.coladresse.Visible = false;
            // 
            // coltelephone
            // 
            this.coltelephone.DataPropertyName = "telephone";
            this.coltelephone.HeaderText = "telephone";
            this.coltelephone.Name = "coltelephone";
            this.coltelephone.ReadOnly = true;
            this.coltelephone.Visible = false;
            // 
            // colphoto
            // 
            this.colphoto.DataPropertyName = "photo";
            this.colphoto.HeaderText = "photo";
            this.colphoto.Name = "colphoto";
            this.colphoto.ReadOnly = true;
            this.colphoto.Visible = false;
            // 
            // colidMal
            // 
            this.colidMal.DataPropertyName = "idMal";
            this.colidMal.HeaderText = "idMal";
            this.colidMal.Name = "colidMal";
            this.colidMal.ReadOnly = true;
            this.colidMal.Visible = false;
            // 
            // colid_personne
            // 
            this.colid_personne.DataPropertyName = "id_personne";
            this.colid_personne.HeaderText = "id_personne";
            this.colid_personne.Name = "colid_personne";
            this.colid_personne.ReadOnly = true;
            this.colid_personne.Visible = false;
            // 
            // colid_airsante
            // 
            this.colid_airsante.DataPropertyName = "id_airsante";
            this.colid_airsante.HeaderText = "id_airsante";
            this.colid_airsante.Name = "colid_airsante";
            this.colid_airsante.ReadOnly = true;
            this.colid_airsante.Visible = false;
            // 
            // colid_categoriemalade
            // 
            this.colid_categoriemalade.DataPropertyName = "id_categoriemalade";
            this.colid_categoriemalade.HeaderText = "id_categoriemalade";
            this.colid_categoriemalade.Name = "colid_categoriemalade";
            this.colid_categoriemalade.ReadOnly = true;
            this.colid_categoriemalade.Visible = false;
            // 
            // colid_etablissement
            // 
            this.colid_etablissement.DataPropertyName = "id_etablissement";
            this.colid_etablissement.HeaderText = "id_etablissement";
            this.colid_etablissement.Name = "colid_etablissement";
            this.colid_etablissement.ReadOnly = true;
            this.colid_etablissement.Visible = false;
            // 
            // colid_profession
            // 
            this.colid_profession.DataPropertyName = "id_profession";
            this.colid_profession.HeaderText = "id_profession";
            this.colid_profession.Name = "colid_profession";
            this.colid_profession.ReadOnly = true;
            this.colid_profession.Visible = false;
            // 
            // colnumero
            // 
            this.colnumero.DataPropertyName = "numero";
            this.colnumero.HeaderText = "numero";
            this.colnumero.Name = "colnumero";
            this.colnumero.ReadOnly = true;
            this.colnumero.Visible = false;
            // 
            // colid_groupesanguin
            // 
            this.colid_groupesanguin.DataPropertyName = "id_groupesanguin";
            this.colid_groupesanguin.HeaderText = "id_groupesanguin";
            this.colid_groupesanguin.Name = "colid_groupesanguin";
            this.colid_groupesanguin.ReadOnly = true;
            this.colid_groupesanguin.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvMalade);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 426);
            this.panel1.TabIndex = 213;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(458, 38);
            this.panel2.TabIndex = 214;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Image = global::GestionClinic_WIN.Properties.Resources.search_page_glyph_night1;
            this.label1.Location = new System.Drawing.Point(425, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 18);
            this.label1.TabIndex = 68;
            // 
            // FrmRecherchePersonneMaladeNonAbonne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.img_home_player_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(458, 500);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.bindingNavigator1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmRecherchePersonneMaladeNonAbonne";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rechercher un malade (Privé seulement)";
            this.Load += new System.EventHandler(this.FrmRecherchePersonne_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRecherchePersonneMaladeNonAbonne_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMalade)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dlgFile;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.DataGridView dgvMalade;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnom;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_fiche;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAgePers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Postnom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom_complet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colsexe;
        private System.Windows.Forms.DataGridViewTextBoxColumn coletatcivil;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldatenaissance;
        private System.Windows.Forms.DataGridViewTextBoxColumn coladresse;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colphoto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidMal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid_personne;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid_airsante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid_categoriemalade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid_etablissement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid_profession;
        private System.Windows.Forms.DataGridViewTextBoxColumn colnumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid_groupesanguin;
    }
}