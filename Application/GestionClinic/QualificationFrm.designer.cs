﻿namespace GestionClinic_WIN
{
    partial class QualificationFrm
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
            this.txtDesignQualification = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvQualification = new System.Windows.Forms.DataGridView();
            this.colDesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label16 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.bnvFonction = new System.Windows.Forms.BindingNavigator(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQualification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnvFonction)).BeginInit();
            this.bnvFonction.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDesignQualification
            // 
            this.txtDesignQualification.Location = new System.Drawing.Point(80, 59);
            this.txtDesignQualification.Name = "txtDesignQualification";
            this.txtDesignQualification.Size = new System.Drawing.Size(157, 20);
            this.txtDesignQualification.TabIndex = 76;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Désignation:";
            // 
            // dgvQualification
            // 
            this.dgvQualification.BackgroundColor = System.Drawing.Color.White;
            this.dgvQualification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQualification.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDesignation,
            this.colID});
            this.dgvQualification.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvQualification.Location = new System.Drawing.Point(241, 28);
            this.dgvQualification.MultiSelect = false;
            this.dgvQualification.Name = "dgvQualification";
            this.dgvQualification.ReadOnly = true;
            this.dgvQualification.RowHeadersVisible = false;
            this.dgvQualification.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvQualification.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQualification.Size = new System.Drawing.Size(281, 90);
            this.dgvQualification.TabIndex = 79;
            this.dgvQualification.SelectionChanged += new System.EventHandler(this.dgvQualification_SelectionChanged);
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
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(237, 2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 23);
            this.label16.TabIndex = 190;
            this.label16.Text = "Qualification";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.bnvFonction.Size = new System.Drawing.Size(530, 25);
            this.bnvFonction.TabIndex = 78;
            this.bnvFonction.Text = "bindingNavigator1";
            // 
            // FrmQualification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(530, 130);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dgvQualification);
            this.Controls.Add(this.bnvFonction);
            this.Controls.Add(this.txtDesignQualification);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmQualification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Qualification";
            this.Load += new System.EventHandler(this.FrmQualification_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmQualification_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQualification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnvFonction)).EndInit();
            this.bnvFonction.ResumeLayout(false);
            this.bnvFonction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDesignQualification;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvQualification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesignation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.BindingNavigator bnvFonction;


    }
}