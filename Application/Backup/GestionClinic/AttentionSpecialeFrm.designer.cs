namespace GestionClinic_WIN
{
    partial class AttentionSpecialeFrm
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
            this.label7 = new System.Windows.Forms.Label();
            this.lblEnfant = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cboAttention = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAttention = new System.Windows.Forms.Label();
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
            this.btnDelete});
            this.bnvFonction.Location = new System.Drawing.Point(0, 0);
            this.bnvFonction.MoveFirstItem = null;
            this.bnvFonction.MoveLastItem = null;
            this.bnvFonction.MoveNextItem = null;
            this.bnvFonction.MovePreviousItem = null;
            this.bnvFonction.Name = "bnvFonction";
            this.bnvFonction.PositionItem = null;
            this.bnvFonction.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bnvFonction.Size = new System.Drawing.Size(319, 25);
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
            // lblEnfant
            // 
            this.lblEnfant.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblEnfant.Location = new System.Drawing.Point(284, 52);
            this.lblEnfant.Name = "lblEnfant";
            this.lblEnfant.Size = new System.Drawing.Size(25, 21);
            this.lblEnfant.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(105, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(140, 21);
            this.label16.TabIndex = 253;
            this.label16.Text = "Attention Spéciale";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboAttention
            // 
            this.cboAttention.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAttention.FormattingEnabled = true;
            this.cboAttention.Location = new System.Drawing.Point(79, 81);
            this.cboAttention.Name = "cboAttention";
            this.cboAttention.Size = new System.Drawing.Size(198, 21);
            this.cboAttention.TabIndex = 5;
            this.cboAttention.DropDown += new System.EventHandler(this.cboAttention_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 254;
            this.label2.Text = "Attention :";
            // 
            // lblAttention
            // 
            this.lblAttention.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblAttention.Location = new System.Drawing.Point(283, 81);
            this.lblAttention.Name = "lblAttention";
            this.lblAttention.Size = new System.Drawing.Size(25, 21);
            this.lblAttention.TabIndex = 6;
            this.lblAttention.Click += new System.EventHandler(this.lblAttention_Click);
            // 
            // cboEnfant
            // 
            this.cboEnfant.Enabled = false;
            this.cboEnfant.FormattingEnabled = true;
            this.cboEnfant.Location = new System.Drawing.Point(79, 52);
            this.cboEnfant.Name = "cboEnfant";
            this.cboEnfant.Size = new System.Drawing.Size(198, 21);
            this.cboEnfant.TabIndex = 257;
            this.cboEnfant.SelectedIndexChanged += new System.EventHandler(this.cboEnfant_SelectedIndexChanged);
            // 
            // chkMoustiqaire
            // 
            this.chkMoustiqaire.AutoSize = true;
            this.chkMoustiqaire.ForeColor = System.Drawing.Color.DarkGreen;
            this.chkMoustiqaire.Location = new System.Drawing.Point(79, 121);
            this.chkMoustiqaire.Name = "chkMoustiqaire";
            this.chkMoustiqaire.Size = new System.Drawing.Size(143, 17);
            this.chkMoustiqaire.TabIndex = 261;
            this.chkMoustiqaire.Text = "Dormir sous moustiquaire";
            this.chkMoustiqaire.UseVisualStyleBackColor = true;
            // 
            // txtIdEnfant
            // 
            this.txtIdEnfant.Location = new System.Drawing.Point(233, 123);
            this.txtIdEnfant.Name = "txtIdEnfant";
            this.txtIdEnfant.Size = new System.Drawing.Size(55, 20);
            this.txtIdEnfant.TabIndex = 262;
            // 
            // FrmAttentionSpeciale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(319, 155);
            this.Controls.Add(this.txtIdEnfant);
            this.Controls.Add(this.chkMoustiqaire);
            this.Controls.Add(this.cboEnfant);
            this.Controls.Add(this.lblAttention);
            this.Controls.Add(this.cboAttention);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblEnfant);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bnvFonction);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmAttentionSpeciale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attention spéciale";
            this.Load += new System.EventHandler(this.FrmAttentionSpeciale_Load);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEnfant;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboAttention;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAttention;
        private System.Windows.Forms.ComboBox cboEnfant;
        private System.Windows.Forms.CheckBox chkMoustiqaire;
        private System.Windows.Forms.TextBox txtIdEnfant;
    }
}