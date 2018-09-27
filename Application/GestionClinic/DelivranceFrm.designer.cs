namespace GestionClinic_WIN
{
    partial class DelivranceFrm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAspectDuPlanceta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMaladeGrosse = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMalade = new System.Windows.Forms.Label();
            this.txtHemoragie = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.bnvFonction = new System.Windows.Forms.BindingNavigator(this.components);
            this.cboPlacenta = new System.Windows.Forms.ComboBox();
            this.cboMembrane = new System.Windows.Forms.ComboBox();
            this.txtOcytocine = new System.Windows.Forms.TextBox();
            this.chkTraction = new System.Windows.Forms.CheckBox();
            this.chkMassage = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.txtDateDelivranceArtificiel = new System.Windows.Forms.DateTimePicker();
            this.txtIdFemmeEnceinte = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bnvFonction)).BeginInit();
            this.bnvFonction.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 201;
            this.label4.Text = "Plancenta :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 197;
            this.label2.Text = "Date délivrance artficiel :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(14, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 207;
            this.label5.Text = "Membranes :";
            // 
            // txtAspectDuPlanceta
            // 
            this.txtAspectDuPlanceta.Location = new System.Drawing.Point(139, 264);
            this.txtAspectDuPlanceta.Name = "txtAspectDuPlanceta";
            this.txtAspectDuPlanceta.Size = new System.Drawing.Size(224, 20);
            this.txtAspectDuPlanceta.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(14, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 206;
            this.label6.Text = "Aspect du planceta :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(15, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 209;
            this.label7.Text = "Femme enceinte :";
            // 
            // cboMaladeGrosse
            // 
            this.cboMaladeGrosse.Enabled = false;
            this.cboMaladeGrosse.FormattingEnabled = true;
            this.cboMaladeGrosse.Location = new System.Drawing.Point(138, 72);
            this.cboMaladeGrosse.Name = "cboMaladeGrosse";
            this.cboMaladeGrosse.Size = new System.Drawing.Size(225, 21);
            this.cboMaladeGrosse.TabIndex = 0;
            this.cboMaladeGrosse.SelectedIndexChanged += new System.EventHandler(this.cboMaladeGrosse_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(16, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 211;
            this.label8.Text = "Ocytocine 10UIM :";
            // 
            // lblMalade
            // 
            this.lblMalade.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblMalade.Image = global::GestionClinic_WIN.Properties.Resources.AddFonct12;
            this.lblMalade.Location = new System.Drawing.Point(365, 71);
            this.lblMalade.Name = "lblMalade";
            this.lblMalade.Size = new System.Drawing.Size(25, 21);
            this.lblMalade.TabIndex = 249;
            // 
            // txtHemoragie
            // 
            this.txtHemoragie.Location = new System.Drawing.Point(138, 319);
            this.txtHemoragie.Name = "txtHemoragie";
            this.txtHemoragie.Size = new System.Drawing.Size(225, 20);
            this.txtHemoragie.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(14, 323);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 253;
            this.label12.Text = "Hemoragie :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(15, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 255;
            this.label10.Text = "Date :";
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
            this.bnvFonction.Size = new System.Drawing.Size(404, 25);
            this.bnvFonction.TabIndex = 203;
            this.bnvFonction.Text = "bindingNavigator1";
            // 
            // cboPlacenta
            // 
            this.cboPlacenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlacenta.FormattingEnabled = true;
            this.cboPlacenta.Location = new System.Drawing.Point(139, 237);
            this.cboPlacenta.Name = "cboPlacenta";
            this.cboPlacenta.Size = new System.Drawing.Size(224, 21);
            this.cboPlacenta.TabIndex = 6;
            // 
            // cboMembrane
            // 
            this.cboMembrane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMembrane.FormattingEnabled = true;
            this.cboMembrane.Location = new System.Drawing.Point(139, 290);
            this.cboMembrane.Name = "cboMembrane";
            this.cboMembrane.Size = new System.Drawing.Size(224, 21);
            this.cboMembrane.TabIndex = 8;
            // 
            // txtOcytocine
            // 
            this.txtOcytocine.Location = new System.Drawing.Point(138, 98);
            this.txtOcytocine.Name = "txtOcytocine";
            this.txtOcytocine.Size = new System.Drawing.Size(225, 20);
            this.txtOcytocine.TabIndex = 1;
            // 
            // chkTraction
            // 
            this.chkTraction.AutoSize = true;
            this.chkTraction.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkTraction.Location = new System.Drawing.Point(140, 127);
            this.chkTraction.Name = "chkTraction";
            this.chkTraction.Size = new System.Drawing.Size(157, 17);
            this.chkTraction.TabIndex = 2;
            this.chkTraction.Text = "Traction contrôle du cordon";
            this.chkTraction.UseVisualStyleBackColor = false;
            // 
            // chkMassage
            // 
            this.chkMassage.AutoSize = true;
            this.chkMassage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkMassage.Location = new System.Drawing.Point(139, 151);
            this.chkMassage.Name = "chkMassage";
            this.chkMassage.Size = new System.Drawing.Size(179, 17);
            this.chkMassage.TabIndex = 3;
            this.chkMassage.Text = "Massage uterin après delivrance";
            this.chkMassage.UseVisualStyleBackColor = false;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(170, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 23);
            this.label16.TabIndex = 283;
            this.label16.Text = "Délivrance";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(138, 180);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(225, 20);
            this.txtDate.TabIndex = 4;
            // 
            // txtDateDelivranceArtificiel
            // 
            this.txtDateDelivranceArtificiel.Location = new System.Drawing.Point(139, 208);
            this.txtDateDelivranceArtificiel.Name = "txtDateDelivranceArtificiel";
            this.txtDateDelivranceArtificiel.Size = new System.Drawing.Size(224, 20);
            this.txtDateDelivranceArtificiel.TabIndex = 5;
            // 
            // txtIdFemmeEnceinte
            // 
            this.txtIdFemmeEnceinte.Location = new System.Drawing.Point(284, 16);
            this.txtIdFemmeEnceinte.Name = "txtIdFemmeEnceinte";
            this.txtIdFemmeEnceinte.Size = new System.Drawing.Size(55, 20);
            this.txtIdFemmeEnceinte.TabIndex = 284;
            // 
            // FrmDelivrance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(404, 358);
            this.Controls.Add(this.txtIdFemmeEnceinte);
            this.Controls.Add(this.txtDateDelivranceArtificiel);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.chkMassage);
            this.Controls.Add(this.chkTraction);
            this.Controls.Add(this.txtOcytocine);
            this.Controls.Add(this.cboMembrane);
            this.Controls.Add(this.cboPlacenta);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtHemoragie);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblMalade);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboMaladeGrosse);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAspectDuPlanceta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bnvFonction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmDelivrance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Délivrance";
            this.Load += new System.EventHandler(this.FrmDelivrance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnvFonction)).EndInit();
            this.bnvFonction.ResumeLayout(false);
            this.bnvFonction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAspectDuPlanceta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMaladeGrosse;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMalade;
        private System.Windows.Forms.TextBox txtHemoragie;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.BindingNavigator bnvFonction;
        private System.Windows.Forms.ComboBox cboPlacenta;
        private System.Windows.Forms.ComboBox cboMembrane;
        private System.Windows.Forms.TextBox txtOcytocine;
        private System.Windows.Forms.CheckBox chkTraction;
        private System.Windows.Forms.CheckBox chkMassage;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.DateTimePicker txtDateDelivranceArtificiel;
        private System.Windows.Forms.TextBox txtIdFemmeEnceinte;
    }
}