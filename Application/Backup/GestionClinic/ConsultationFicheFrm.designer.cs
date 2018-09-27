namespace GestionClinic_WIN
{
    partial class ConsultationFicheFrm
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
            this.btClose = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboSuivieCroissance = new System.Windows.Forms.ComboBox();
            this.lblEnfant = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cboRdv = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboVaccination = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSuivieCroissance = new System.Windows.Forms.Label();
            this.lblRdv = new System.Windows.Forms.Label();
            this.lblVaccination = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.cboEnfant = new System.Windows.Forms.ComboBox();
            this.chkMoustiqaire = new System.Windows.Forms.CheckBox();
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
            this.btnDelete,
            this.btClose});
            this.bnvFonction.Location = new System.Drawing.Point(0, 0);
            this.bnvFonction.MoveFirstItem = null;
            this.bnvFonction.MoveLastItem = null;
            this.bnvFonction.MoveNextItem = null;
            this.bnvFonction.MovePreviousItem = null;
            this.bnvFonction.Name = "bnvFonction";
            this.bnvFonction.PositionItem = null;
            this.bnvFonction.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bnvFonction.Size = new System.Drawing.Size(388, 25);
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
            // btClose
            // 
            this.btClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btClose.Image = global::GestionClinic_WIN.Properties.Resources.Close1;
            this.btClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(23, 22);
            this.btClose.Text = "Fermer";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(17, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 195;
            this.label1.Text = "Date consultation :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(14, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 209;
            this.label7.Text = "Enfant :";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(15, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 37);
            this.label8.TabIndex = 211;
            this.label8.Text = "Suivie /  Croissance :";
            // 
            // cboSuivieCroissance
            // 
            this.cboSuivieCroissance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSuivieCroissance.FormattingEnabled = true;
            this.cboSuivieCroissance.Location = new System.Drawing.Point(118, 80);
            this.cboSuivieCroissance.Name = "cboSuivieCroissance";
            this.cboSuivieCroissance.Size = new System.Drawing.Size(226, 21);
            this.cboSuivieCroissance.TabIndex = 3;
            this.cboSuivieCroissance.DropDown += new System.EventHandler(this.cboSuivieCroissance_DropDown);
            // 
            // lblEnfant
            // 
            this.lblEnfant.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblEnfant.Location = new System.Drawing.Point(349, 53);
            this.lblEnfant.Name = "lblEnfant";
            this.lblEnfant.Size = new System.Drawing.Size(25, 21);
            this.lblEnfant.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(117, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(148, 21);
            this.label16.TabIndex = 253;
            this.label16.Text = "Consultation Fiche";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboRdv
            // 
            this.cboRdv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRdv.FormattingEnabled = true;
            this.cboRdv.Location = new System.Drawing.Point(118, 108);
            this.cboRdv.Name = "cboRdv";
            this.cboRdv.Size = new System.Drawing.Size(225, 21);
            this.cboRdv.TabIndex = 5;
            this.cboRdv.DropDown += new System.EventHandler(this.cboRdv_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 254;
            this.label2.Text = "Rendez-vous :";
            // 
            // cboVaccination
            // 
            this.cboVaccination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaccination.FormattingEnabled = true;
            this.cboVaccination.Location = new System.Drawing.Point(118, 137);
            this.cboVaccination.Name = "cboVaccination";
            this.cboVaccination.Size = new System.Drawing.Size(225, 21);
            this.cboVaccination.TabIndex = 7;
            this.cboVaccination.DropDown += new System.EventHandler(this.cboVaccination_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 256;
            this.label3.Text = "Vaccination :";
            // 
            // lblSuivieCroissance
            // 
            this.lblSuivieCroissance.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblSuivieCroissance.Location = new System.Drawing.Point(348, 81);
            this.lblSuivieCroissance.Name = "lblSuivieCroissance";
            this.lblSuivieCroissance.Size = new System.Drawing.Size(25, 21);
            this.lblSuivieCroissance.TabIndex = 4;
            this.lblSuivieCroissance.Click += new System.EventHandler(this.lblSuivieCroissance_Click);
            // 
            // lblRdv
            // 
            this.lblRdv.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblRdv.Location = new System.Drawing.Point(348, 108);
            this.lblRdv.Name = "lblRdv";
            this.lblRdv.Size = new System.Drawing.Size(25, 21);
            this.lblRdv.TabIndex = 6;
            this.lblRdv.Click += new System.EventHandler(this.lblRdv_Click);
            // 
            // lblVaccination
            // 
            this.lblVaccination.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblVaccination.Location = new System.Drawing.Point(348, 137);
            this.lblVaccination.Name = "lblVaccination";
            this.lblVaccination.Size = new System.Drawing.Size(25, 21);
            this.lblVaccination.TabIndex = 8;
            this.lblVaccination.Click += new System.EventHandler(this.lblVaccination_Click);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(119, 168);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(178, 20);
            this.txtDate.TabIndex = 2;
            // 
            // cboEnfant
            // 
            this.cboEnfant.Enabled = false;
            this.cboEnfant.FormattingEnabled = true;
            this.cboEnfant.Location = new System.Drawing.Point(118, 53);
            this.cboEnfant.Name = "cboEnfant";
            this.cboEnfant.Size = new System.Drawing.Size(226, 21);
            this.cboEnfant.TabIndex = 257;
            this.cboEnfant.SelectedIndexChanged += new System.EventHandler(this.cboEnfant_SelectedIndexChanged);
            // 
            // chkMoustiqaire
            // 
            this.chkMoustiqaire.AutoSize = true;
            this.chkMoustiqaire.ForeColor = System.Drawing.Color.ForestGreen;
            this.chkMoustiqaire.Location = new System.Drawing.Point(118, 205);
            this.chkMoustiqaire.Name = "chkMoustiqaire";
            this.chkMoustiqaire.Size = new System.Drawing.Size(149, 17);
            this.chkMoustiqaire.TabIndex = 261;
            this.chkMoustiqaire.Text = "Dormez sous moustiquaire";
            this.chkMoustiqaire.UseVisualStyleBackColor = true;
            // 
            // txtIdEnfant
            // 
            this.txtIdEnfant.Location = new System.Drawing.Point(318, 202);
            this.txtIdEnfant.Name = "txtIdEnfant";
            this.txtIdEnfant.Size = new System.Drawing.Size(55, 20);
            this.txtIdEnfant.TabIndex = 263;
            // 
            // FrmConsultationFiche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(388, 240);
            this.Controls.Add(this.txtIdEnfant);
            this.Controls.Add(this.chkMoustiqaire);
            this.Controls.Add(this.cboEnfant);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblVaccination);
            this.Controls.Add(this.lblRdv);
            this.Controls.Add(this.lblSuivieCroissance);
            this.Controls.Add(this.cboVaccination);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboRdv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblEnfant);
            this.Controls.Add(this.cboSuivieCroissance);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bnvFonction);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConsultationFiche";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmConsultationFiche_Load);
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
        private System.Windows.Forms.ToolStripButton btClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboSuivieCroissance;
        private System.Windows.Forms.Label lblEnfant;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboRdv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboVaccination;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSuivieCroissance;
        private System.Windows.Forms.Label lblRdv;
        private System.Windows.Forms.Label lblVaccination;
        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.ComboBox cboEnfant;
        private System.Windows.Forms.CheckBox chkMoustiqaire;
        private System.Windows.Forms.TextBox txtIdEnfant;
    }
}