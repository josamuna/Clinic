namespace GestionClinic_WIN
{
    partial class VaccinationFrm
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
            this.bnvVaccination = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblEnfant = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cboVaccin = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPeriode = new System.Windows.Forms.Label();
            this.lblVaccin = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.lblPriseVitamine = new System.Windows.Forms.Label();
            this.cboPriseVitamine = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboEnfant = new System.Windows.Forms.ComboBox();
            this.txtIdEnfant = new System.Windows.Forms.TextBox();
            this.cboPeriode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bnvVaccination)).BeginInit();
            this.bnvVaccination.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnvVaccination
            // 
            this.bnvVaccination.AddNewItem = null;
            this.bnvVaccination.BackColor = System.Drawing.Color.Transparent;
            this.bnvVaccination.CountItem = null;
            this.bnvVaccination.DeleteItem = null;
            this.bnvVaccination.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bnvVaccination.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnSave,
            this.btnDelete});
            this.bnvVaccination.Location = new System.Drawing.Point(0, 0);
            this.bnvVaccination.MoveFirstItem = null;
            this.bnvVaccination.MoveLastItem = null;
            this.bnvVaccination.MoveNextItem = null;
            this.bnvVaccination.MovePreviousItem = null;
            this.bnvVaccination.Name = "bnvVaccination";
            this.bnvVaccination.PositionItem = null;
            this.bnvVaccination.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bnvVaccination.Size = new System.Drawing.Size(329, 25);
            this.bnvVaccination.TabIndex = 203;
            this.bnvVaccination.Text = "bindingNavigator1";
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
            this.label1.Location = new System.Drawing.Point(14, 80);
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
            this.label7.Location = new System.Drawing.Point(14, 52);
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
            this.label8.Location = new System.Drawing.Point(15, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 211;
            this.label8.Text = "Période :";
            // 
            // lblEnfant
            // 
            this.lblEnfant.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblEnfant.Location = new System.Drawing.Point(292, 47);
            this.lblEnfant.Name = "lblEnfant";
            this.lblEnfant.Size = new System.Drawing.Size(25, 21);
            this.lblEnfant.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(119, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 21);
            this.label16.TabIndex = 253;
            this.label16.Text = "Vaccination";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboVaccin
            // 
            this.cboVaccin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaccin.FormattingEnabled = true;
            this.cboVaccin.Location = new System.Drawing.Point(91, 154);
            this.cboVaccin.Name = "cboVaccin";
            this.cboVaccin.Size = new System.Drawing.Size(193, 21);
            this.cboVaccin.TabIndex = 5;
            this.cboVaccin.DropDown += new System.EventHandler(this.cboVaccin_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 254;
            this.label2.Text = "Vaccin :";
            // 
            // lblPeriode
            // 
            this.lblPeriode.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblPeriode.Location = new System.Drawing.Point(291, 102);
            this.lblPeriode.Name = "lblPeriode";
            this.lblPeriode.Size = new System.Drawing.Size(25, 21);
            this.lblPeriode.TabIndex = 4;
            this.lblPeriode.Click += new System.EventHandler(this.lblPeriode_Click);
            // 
            // lblVaccin
            // 
            this.lblVaccin.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblVaccin.Location = new System.Drawing.Point(289, 154);
            this.lblVaccin.Name = "lblVaccin";
            this.lblVaccin.Size = new System.Drawing.Size(25, 21);
            this.lblVaccin.TabIndex = 6;
            this.lblVaccin.Click += new System.EventHandler(this.lblVaccin_Click);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(91, 76);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(195, 20);
            this.txtDate.TabIndex = 2;
            // 
            // lblPriseVitamine
            // 
            this.lblPriseVitamine.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblPriseVitamine.Location = new System.Drawing.Point(290, 128);
            this.lblPriseVitamine.Name = "lblPriseVitamine";
            this.lblPriseVitamine.Size = new System.Drawing.Size(25, 21);
            this.lblPriseVitamine.TabIndex = 259;
            this.lblPriseVitamine.Click += new System.EventHandler(this.lblPriseVitamine_Click);
            // 
            // cboPriseVitamine
            // 
            this.cboPriseVitamine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPriseVitamine.FormattingEnabled = true;
            this.cboPriseVitamine.Location = new System.Drawing.Point(91, 128);
            this.cboPriseVitamine.Name = "cboPriseVitamine";
            this.cboPriseVitamine.Size = new System.Drawing.Size(194, 21);
            this.cboPriseVitamine.TabIndex = 258;
            this.cboPriseVitamine.DropDown += new System.EventHandler(this.cboPriseVitamine_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 260;
            this.label4.Text = "Prise Vitamine :";
            // 
            // cboEnfant
            // 
            this.cboEnfant.Enabled = false;
            this.cboEnfant.FormattingEnabled = true;
            this.cboEnfant.Location = new System.Drawing.Point(93, 48);
            this.cboEnfant.Name = "cboEnfant";
            this.cboEnfant.Size = new System.Drawing.Size(193, 21);
            this.cboEnfant.TabIndex = 257;
            this.cboEnfant.SelectedIndexChanged += new System.EventHandler(this.cboEnfant_SelectedIndexChanged);
            // 
            // txtIdEnfant
            // 
            this.txtIdEnfant.Location = new System.Drawing.Point(224, 6);
            this.txtIdEnfant.Name = "txtIdEnfant";
            this.txtIdEnfant.Size = new System.Drawing.Size(55, 20);
            this.txtIdEnfant.TabIndex = 261;
            // 
            // cboPeriode
            // 
            this.cboPeriode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriode.FormattingEnabled = true;
            this.cboPeriode.Location = new System.Drawing.Point(91, 101);
            this.cboPeriode.Name = "cboPeriode";
            this.cboPeriode.Size = new System.Drawing.Size(194, 21);
            this.cboPeriode.TabIndex = 262;
            this.cboPeriode.DropDown += new System.EventHandler(this.cboPeriode_DropDown);
            // 
            // FrmVaccination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(329, 195);
            this.Controls.Add(this.cboPeriode);
            this.Controls.Add(this.txtIdEnfant);
            this.Controls.Add(this.lblPriseVitamine);
            this.Controls.Add(this.cboPriseVitamine);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboEnfant);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblVaccin);
            this.Controls.Add(this.lblPeriode);
            this.Controls.Add(this.cboVaccin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblEnfant);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bnvVaccination);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmVaccination";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vaccination";
            this.Load += new System.EventHandler(this.FrmVaccination_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnvVaccination)).EndInit();
            this.bnvVaccination.ResumeLayout(false);
            this.bnvVaccination.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnvVaccination;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblEnfant;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboVaccin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPeriode;
        private System.Windows.Forms.Label lblVaccin;
        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.Label lblPriseVitamine;
        private System.Windows.Forms.ComboBox cboPriseVitamine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboEnfant;
        private System.Windows.Forms.TextBox txtIdEnfant;
        private System.Windows.Forms.ComboBox cboPeriode;
    }
}