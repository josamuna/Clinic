namespace GestionClinic_WIN
{
    partial class CategorieMaladeFrm
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
            this.txtTaux = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesignCategorieMalade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bnvCateg = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.dgvCategorieMalade = new System.Windows.Forms.DataGridView();
            this.colTaux = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCateg)).BeginInit();
            this.bnvCateg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorieMalade)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTaux
            // 
            this.txtTaux.Location = new System.Drawing.Point(82, 45);
            this.txtTaux.Name = "txtTaux";
            this.txtTaux.Size = new System.Drawing.Size(110, 20);
            this.txtTaux.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Taux :";
            // 
            // txtDesignCategorieMalade
            // 
            this.txtDesignCategorieMalade.Location = new System.Drawing.Point(82, 77);
            this.txtDesignCategorieMalade.Name = "txtDesignCategorieMalade";
            this.txtDesignCategorieMalade.Size = new System.Drawing.Size(176, 20);
            this.txtDesignCategorieMalade.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Désignation:";
            // 
            // bnvCateg
            // 
            this.bnvCateg.AddNewItem = null;
            this.bnvCateg.BackColor = System.Drawing.Color.Transparent;
            this.bnvCateg.CountItem = null;
            this.bnvCateg.DeleteItem = null;
            this.bnvCateg.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bnvCateg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnRefresh,
            this.btnSave,
            this.btnDelete});
            this.bnvCateg.Location = new System.Drawing.Point(0, 0);
            this.bnvCateg.MoveFirstItem = null;
            this.bnvCateg.MoveLastItem = null;
            this.bnvCateg.MoveNextItem = null;
            this.bnvCateg.MovePreviousItem = null;
            this.bnvCateg.Name = "bnvCateg";
            this.bnvCateg.PositionItem = null;
            this.bnvCateg.Size = new System.Drawing.Size(549, 25);
            this.bnvCateg.TabIndex = 62;
            this.bnvCateg.Text = "bindingNavigator1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::GestionClinic_WIN.Properties.Resources.navBarAddIcon_2x;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.Click += new System.EventHandler(this.btnAddCateg_Click);
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
            this.btnSave.Text = "Mis à jour";
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
            // dgvCategorieMalade
            // 
            this.dgvCategorieMalade.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategorieMalade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorieMalade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTaux,
            this.colDesignation,
            this.colID});
            this.dgvCategorieMalade.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvCategorieMalade.Location = new System.Drawing.Point(273, 32);
            this.dgvCategorieMalade.MultiSelect = false;
            this.dgvCategorieMalade.Name = "dgvCategorieMalade";
            this.dgvCategorieMalade.ReadOnly = true;
            this.dgvCategorieMalade.RowHeadersVisible = false;
            this.dgvCategorieMalade.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCategorieMalade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategorieMalade.Size = new System.Drawing.Size(264, 90);
            this.dgvCategorieMalade.TabIndex = 81;
            this.dgvCategorieMalade.SelectionChanged += new System.EventHandler(this.dgvCategorieMalade_SelectionChanged);
            // 
            // colTaux
            // 
            this.colTaux.DataPropertyName = "Taux";
            this.colTaux.HeaderText = "Taux";
            this.colTaux.Name = "colTaux";
            this.colTaux.ReadOnly = true;
            this.colTaux.Width = 80;
            // 
            // colDesignation
            // 
            this.colDesignation.DataPropertyName = "Designation";
            this.colDesignation.HeaderText = "Désignation";
            this.colDesignation.Name = "colDesignation";
            this.colDesignation.ReadOnly = true;
            this.colDesignation.Width = 180;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "Id";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(222, 2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(123, 23);
            this.label16.TabIndex = 189;
            this.label16.Text = "Catégorie Malade";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmCategorieMalade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(549, 134);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dgvCategorieMalade);
            this.Controls.Add(this.txtTaux);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDesignCategorieMalade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bnvCateg);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmCategorieMalade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catégorie malade";
            this.Load += new System.EventHandler(this.CategorieMalade_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCategorieMalade_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bnvCateg)).EndInit();
            this.bnvCateg.ResumeLayout(false);
            this.bnvCateg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorieMalade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.TextBox txtTaux;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesignCategorieMalade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingNavigator bnvCateg;
        private System.Windows.Forms.DataGridView dgvCategorieMalade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaux;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesignation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.Label label16;
    }
}