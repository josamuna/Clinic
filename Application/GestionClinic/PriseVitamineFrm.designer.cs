namespace GestionClinic_WIN
{
    partial class PriseVitamineFrm
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
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPeriode = new System.Windows.Forms.ComboBox();
            this.lblEnfant = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cboVitamine = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPeriode = new System.Windows.Forms.Label();
            this.lblVitamine = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.cboEnfant = new System.Windows.Forms.ComboBox();
            this.txtIdEnfant = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bnvFonction)).BeginInit();
            this.bnvFonction.SuspendLayout();
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
            this.bnvFonction.Size = new System.Drawing.Size(356, 25);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 195;
            this.label1.Text = "Date :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(9, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 209;
            this.label7.Text = "Enfant :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(9, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 211;
            this.label8.Text = "Période :";
            // 
            // cboPeriode
            // 
            this.cboPeriode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriode.FormattingEnabled = true;
            this.cboPeriode.Location = new System.Drawing.Point(63, 78);
            this.cboPeriode.Name = "cboPeriode";
            this.cboPeriode.Size = new System.Drawing.Size(245, 21);
            this.cboPeriode.TabIndex = 3;
            this.cboPeriode.DropDown += new System.EventHandler(this.cboPeriode_DropDown);
            // 
            // lblEnfant
            // 
            this.lblEnfant.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblEnfant.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblEnfant.Location = new System.Drawing.Point(318, 48);
            this.lblEnfant.Name = "lblEnfant";
            this.lblEnfant.Size = new System.Drawing.Size(25, 21);
            this.lblEnfant.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(126, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 21);
            this.label16.TabIndex = 253;
            this.label16.Text = "Prise vitamine";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboVitamine
            // 
            this.cboVitamine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVitamine.FormattingEnabled = true;
            this.cboVitamine.Location = new System.Drawing.Point(63, 107);
            this.cboVitamine.Name = "cboVitamine";
            this.cboVitamine.Size = new System.Drawing.Size(243, 21);
            this.cboVitamine.TabIndex = 7;
            this.cboVitamine.DropDown += new System.EventHandler(this.cboVitamine_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 256;
            this.label3.Text = "Vitamine :";
            // 
            // lblPeriode
            // 
            this.lblPeriode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPeriode.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblPeriode.Location = new System.Drawing.Point(317, 79);
            this.lblPeriode.Name = "lblPeriode";
            this.lblPeriode.Size = new System.Drawing.Size(25, 21);
            this.lblPeriode.TabIndex = 4;
            this.lblPeriode.Click += new System.EventHandler(this.lblPeriode_Click);
            // 
            // lblVitamine
            // 
            this.lblVitamine.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblVitamine.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblVitamine.Location = new System.Drawing.Point(316, 107);
            this.lblVitamine.Name = "lblVitamine";
            this.lblVitamine.Size = new System.Drawing.Size(25, 21);
            this.lblVitamine.TabIndex = 8;
            this.lblVitamine.Click += new System.EventHandler(this.lblVitamine_Click);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(62, 136);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(244, 20);
            this.txtDate.TabIndex = 2;
            // 
            // cboEnfant
            // 
            this.cboEnfant.Enabled = false;
            this.cboEnfant.FormattingEnabled = true;
            this.cboEnfant.Location = new System.Drawing.Point(63, 48);
            this.cboEnfant.Name = "cboEnfant";
            this.cboEnfant.Size = new System.Drawing.Size(245, 21);
            this.cboEnfant.TabIndex = 257;
            this.cboEnfant.SelectedIndexChanged += new System.EventHandler(this.cboEnfant_SelectedIndexChanged);
            // 
            // txtIdEnfant
            // 
            this.txtIdEnfant.Location = new System.Drawing.Point(247, 162);
            this.txtIdEnfant.Name = "txtIdEnfant";
            this.txtIdEnfant.Size = new System.Drawing.Size(55, 20);
            this.txtIdEnfant.TabIndex = 262;
            // 
            // FrmPriseVitamine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(356, 184);
            this.Controls.Add(this.txtIdEnfant);
            this.Controls.Add(this.cboEnfant);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblVitamine);
            this.Controls.Add(this.lblPeriode);
            this.Controls.Add(this.cboVitamine);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblEnfant);
            this.Controls.Add(this.cboPeriode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bnvFonction);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmPriseVitamine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prise vitamine";
            this.Load += new System.EventHandler(this.FrmPriseVitamine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnvFonction)).EndInit();
            this.bnvFonction.ResumeLayout(false);
            this.bnvFonction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnvFonction;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboPeriode;
        private System.Windows.Forms.Label lblEnfant;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboVitamine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPeriode;
        private System.Windows.Forms.Label lblVitamine;
        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.ComboBox cboEnfant;
        private System.Windows.Forms.TextBox txtIdEnfant;
    }
}