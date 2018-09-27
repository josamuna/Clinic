namespace GestionClinic_WIN
{
    partial class EnfantFrm
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
            this.txtTaille = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMalformation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPoids = new System.Windows.Forms.TextBox();
            this.cboSexe = new System.Windows.Forms.ComboBox();
            this.txtIdFemmeEnceinte = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboSoinDuCordo = new System.Windows.Forms.ComboBox();
            this.cboSenn = new System.Windows.Forms.ComboBox();
            this.chkMiseAuSein = new System.Windows.Forms.CheckBox();
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
            this.bnvFonction.Size = new System.Drawing.Size(455, 25);
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
            // txtTaille
            // 
            this.txtTaille.Location = new System.Drawing.Point(18, 160);
            this.txtTaille.Name = "txtTaille";
            this.txtTaille.Size = new System.Drawing.Size(174, 20);
            this.txtTaille.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(17, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 199;
            this.label3.Text = "Senn :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(206, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 197;
            this.label2.Text = "Soin du cordo  :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(17, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 195;
            this.label1.Text = "Taille :";
            // 
            // txtMalformation
            // 
            this.txtMalformation.Location = new System.Drawing.Point(18, 199);
            this.txtMalformation.Name = "txtMalformation";
            this.txtMalformation.Size = new System.Drawing.Size(175, 20);
            this.txtMalformation.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(20, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 207;
            this.label5.Text = "Malformation :";
            // 
            // txtPC
            // 
            this.txtPC.Location = new System.Drawing.Point(212, 200);
            this.txtPC.Name = "txtPC";
            this.txtPC.Size = new System.Drawing.Size(89, 20);
            this.txtPC.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(212, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 206;
            this.label6.Text = "PC :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(17, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 209;
            this.label7.Text = "poids :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(209, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 211;
            this.label8.Text = "Sexe :";
            // 
            // txtPoids
            // 
            this.txtPoids.Location = new System.Drawing.Point(18, 79);
            this.txtPoids.Name = "txtPoids";
            this.txtPoids.Size = new System.Drawing.Size(177, 20);
            this.txtPoids.TabIndex = 0;
            // 
            // cboSexe
            // 
            this.cboSexe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSexe.FormattingEnabled = true;
            this.cboSexe.Location = new System.Drawing.Point(211, 159);
            this.cboSexe.Name = "cboSexe";
            this.cboSexe.Size = new System.Drawing.Size(90, 21);
            this.cboSexe.TabIndex = 5;
            // 
            // txtIdFemmeEnceinte
            // 
            this.txtIdFemmeEnceinte.Location = new System.Drawing.Point(245, 226);
            this.txtIdFemmeEnceinte.Name = "txtIdFemmeEnceinte";
            this.txtIdFemmeEnceinte.Size = new System.Drawing.Size(121, 20);
            this.txtIdFemmeEnceinte.TabIndex = 221;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(212, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 20);
            this.label9.TabIndex = 261;
            this.label9.Text = "Enfant";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboSoinDuCordo
            // 
            this.cboSoinDuCordo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSoinDuCordo.FormattingEnabled = true;
            this.cboSoinDuCordo.Location = new System.Drawing.Point(208, 79);
            this.cboSoinDuCordo.Name = "cboSoinDuCordo";
            this.cboSoinDuCordo.Size = new System.Drawing.Size(178, 21);
            this.cboSoinDuCordo.TabIndex = 1;
            // 
            // cboSenn
            // 
            this.cboSenn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSenn.FormattingEnabled = true;
            this.cboSenn.Location = new System.Drawing.Point(18, 118);
            this.cboSenn.Name = "cboSenn";
            this.cboSenn.Size = new System.Drawing.Size(178, 21);
            this.cboSenn.TabIndex = 2;
            // 
            // chkMiseAuSein
            // 
            this.chkMiseAuSein.AutoSize = true;
            this.chkMiseAuSein.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkMiseAuSein.Location = new System.Drawing.Point(208, 121);
            this.chkMiseAuSein.Name = "chkMiseAuSein";
            this.chkMiseAuSein.Size = new System.Drawing.Size(239, 17);
            this.chkMiseAuSein.TabIndex = 3;
            this.chkMiseAuSein.Text = "Mise au sain dans aui suivent accouchement";
            this.chkMiseAuSein.UseVisualStyleBackColor = false;
            // 
            // FrmEnfant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(455, 252);
            this.Controls.Add(this.chkMiseAuSein);
            this.Controls.Add(this.cboSenn);
            this.Controls.Add(this.cboSoinDuCordo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtIdFemmeEnceinte);
            this.Controls.Add(this.cboSexe);
            this.Controls.Add(this.txtPoids);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMalformation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPC);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bnvFonction);
            this.Controls.Add(this.txtTaille);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmEnfant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enfant";
            this.Load += new System.EventHandler(this.FrmEnfant_Load);
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
        private System.Windows.Forms.TextBox txtTaille;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMalformation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPoids;
        private System.Windows.Forms.ComboBox cboSexe;
        private System.Windows.Forms.TextBox txtIdFemmeEnceinte;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboSoinDuCordo;
        private System.Windows.Forms.ComboBox cboSenn;
        private System.Windows.Forms.CheckBox chkMiseAuSein;
    }
}