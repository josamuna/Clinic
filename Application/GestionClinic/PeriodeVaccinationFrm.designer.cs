﻿namespace GestionClinic_WIN
{
    partial class PeriodeVaccinationFrm
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
            this.bnvFonction = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvPeriodeVaccination = new System.Windows.Forms.DataGridView();
            this.colDesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bnvFonction)).BeginInit();
            this.bnvFonction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodeVaccination)).BeginInit();
            this.SuspendLayout();
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
            this.bnvFonction.Size = new System.Drawing.Size(528, 25);
            this.bnvFonction.TabIndex = 203;
            this.bnvFonction.Text = "bindingNavigator1";
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
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(189, 2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(155, 21);
            this.label16.TabIndex = 253;
            this.label16.Text = "Période de vaccination";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPeriodeVaccination
            // 
            this.dgvPeriodeVaccination.BackgroundColor = System.Drawing.Color.White;
            this.dgvPeriodeVaccination.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriodeVaccination.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDesignation,
            this.colID});
            this.dgvPeriodeVaccination.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvPeriodeVaccination.Location = new System.Drawing.Point(238, 25);
            this.dgvPeriodeVaccination.MultiSelect = false;
            this.dgvPeriodeVaccination.Name = "dgvPeriodeVaccination";
            this.dgvPeriodeVaccination.ReadOnly = true;
            this.dgvPeriodeVaccination.RowHeadersVisible = false;
            this.dgvPeriodeVaccination.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPeriodeVaccination.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeriodeVaccination.Size = new System.Drawing.Size(281, 90);
            this.dgvPeriodeVaccination.TabIndex = 256;
            this.dgvPeriodeVaccination.SelectionChanged += new System.EventHandler(this.dgvPeriodeVaccination_SelectionChanged);
            // 
            // colDesignation
            // 
            this.colDesignation.DataPropertyName = "Designation";
            this.colDesignation.HeaderText = "Désignation";
            this.colDesignation.Name = "colDesignation";
            this.colDesignation.ReadOnly = true;
            this.colDesignation.Width = 270;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "Id";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // txtDesignation
            // 
            this.txtDesignation.Location = new System.Drawing.Point(77, 56);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(157, 20);
            this.txtDesignation.TabIndex = 255;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 254;
            this.label2.Text = "Désignation:";
            // 
            // FrmPeriodeVaccination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(528, 141);
            this.Controls.Add(this.dgvPeriodeVaccination);
            this.Controls.Add(this.txtDesignation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.bnvFonction);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmPeriodeVaccination";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmPeriodeVaccination_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPeriodeVaccination_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bnvFonction)).EndInit();
            this.bnvFonction.ResumeLayout(false);
            this.bnvFonction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodeVaccination)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnvFonction;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgvPeriodeVaccination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesignation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton btnRefresh;
    }
}