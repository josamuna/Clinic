namespace GestionClinic_WIN
{
    partial class HospitalisationFrm
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
            this.lblTraitHospitalisation = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblIntervention = new System.Windows.Forms.Label();
            this.lblHospitalisation = new System.Windows.Forms.Label();
            this.lblErgot = new System.Windows.Forms.Label();
            this.lblNomMalade = new System.Windows.Forms.Label();
            this.Affichage = new System.Windows.Forms.Panel();
            this.pbPhotoPersonne = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MenTriage = new System.Windows.Forms.GroupBox();
            this.rdIntervention = new System.Windows.Forms.RadioButton();
            this.rdHospitalisation = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmdLoadData = new System.Windows.Forms.Button();
            this.lblRecherche = new System.Windows.Forms.Label();
            this.bnvCateg = new System.Windows.Forms.BindingNavigator(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhotoPersonne)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.MenTriage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCateg)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTraitHospitalisation
            // 
            this.lblTraitHospitalisation.AutoSize = true;
            this.lblTraitHospitalisation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTraitHospitalisation.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblTraitHospitalisation.Location = new System.Drawing.Point(87, 22);
            this.lblTraitHospitalisation.Name = "lblTraitHospitalisation";
            this.lblTraitHospitalisation.Size = new System.Drawing.Size(91, 13);
            this.lblTraitHospitalisation.TabIndex = 9;
            this.lblTraitHospitalisation.Text = "______________";
            this.lblTraitHospitalisation.DoubleClick += new System.EventHandler(this.lblTraitHospitalisation_DoubleClick);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(451, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(198, 23);
            this.label16.TabIndex = 266;
            this.label16.Text = "Hospitalisation et Interventions";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIntervention
            // 
            this.lblIntervention.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblIntervention.Location = new System.Drawing.Point(7, 64);
            this.lblIntervention.Name = "lblIntervention";
            this.lblIntervention.Size = new System.Drawing.Size(171, 17);
            this.lblIntervention.TabIndex = 7;
            this.lblIntervention.Text = "► Intervention";
            this.lblIntervention.MouseLeave += new System.EventHandler(this.lblIntervention_MouseLeave);
            this.lblIntervention.Click += new System.EventHandler(this.lblIntervention_Click);
            this.lblIntervention.MouseEnter += new System.EventHandler(this.lblIntervention_MouseEnter);
            // 
            // lblHospitalisation
            // 
            this.lblHospitalisation.AutoSize = true;
            this.lblHospitalisation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHospitalisation.Location = new System.Drawing.Point(17, 27);
            this.lblHospitalisation.Name = "lblHospitalisation";
            this.lblHospitalisation.Size = new System.Drawing.Size(75, 13);
            this.lblHospitalisation.TabIndex = 6;
            this.lblHospitalisation.Text = "Hospitalisation";
            this.lblHospitalisation.DoubleClick += new System.EventHandler(this.lblHospitalisation_DoubleClick);
            this.lblHospitalisation.Click += new System.EventHandler(this.lblHospitalisation_Click);
            // 
            // lblErgot
            // 
            this.lblErgot.AutoSize = true;
            this.lblErgot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblErgot.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblErgot.Location = new System.Drawing.Point(4, 27);
            this.lblErgot.Name = "lblErgot";
            this.lblErgot.Size = new System.Drawing.Size(19, 13);
            this.lblErgot.TabIndex = 10;
            this.lblErgot.Text = "▼";
            this.lblErgot.Click += new System.EventHandler(this.lblErgot_Click);
            // 
            // lblNomMalade
            // 
            this.lblNomMalade.AutoSize = true;
            this.lblNomMalade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomMalade.ForeColor = System.Drawing.Color.Silver;
            this.lblNomMalade.Location = new System.Drawing.Point(46, 15);
            this.lblNomMalade.Name = "lblNomMalade";
            this.lblNomMalade.Size = new System.Drawing.Size(0, 20);
            this.lblNomMalade.TabIndex = 1;
            // 
            // Affichage
            // 
            this.Affichage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Affichage.Location = new System.Drawing.Point(178, 43);
            this.Affichage.Name = "Affichage";
            this.Affichage.Size = new System.Drawing.Size(697, 418);
            this.Affichage.TabIndex = 266;
            // 
            // pbPhotoPersonne
            // 
            this.pbPhotoPersonne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPhotoPersonne.Location = new System.Drawing.Point(7, 4);
            this.pbPhotoPersonne.Name = "pbPhotoPersonne";
            this.pbPhotoPersonne.Size = new System.Drawing.Size(33, 33);
            this.pbPhotoPersonne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhotoPersonne.TabIndex = 0;
            this.pbPhotoPersonne.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Affichage);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(209, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 463);
            this.panel1.TabIndex = 267;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblTraitHospitalisation);
            this.panel3.Controls.Add(this.lblIntervention);
            this.panel3.Controls.Add(this.lblHospitalisation);
            this.panel3.Controls.Add(this.lblErgot);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(178, 418);
            this.panel3.TabIndex = 265;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblNomMalade);
            this.panel2.Controls.Add(this.pbPhotoPersonne);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(875, 43);
            this.panel2.TabIndex = 264;
            // 
            // MenTriage
            // 
            this.MenTriage.BackColor = System.Drawing.Color.Transparent;
            this.MenTriage.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.img_home_news_background;
            this.MenTriage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MenTriage.Controls.Add(this.rdIntervention);
            this.MenTriage.Controls.Add(this.rdHospitalisation);
            this.MenTriage.Controls.Add(this.label1);
            this.MenTriage.Controls.Add(this.pictureBox1);
            this.MenTriage.Controls.Add(this.cmdLoadData);
            this.MenTriage.Controls.Add(this.lblRecherche);
            this.MenTriage.Location = new System.Drawing.Point(4, 36);
            this.MenTriage.Name = "MenTriage";
            this.MenTriage.Size = new System.Drawing.Size(199, 540);
            this.MenTriage.TabIndex = 265;
            this.MenTriage.TabStop = false;
            // 
            // rdIntervention
            // 
            this.rdIntervention.AutoSize = true;
            this.rdIntervention.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.rdIntervention.Location = new System.Drawing.Point(9, 58);
            this.rdIntervention.Name = "rdIntervention";
            this.rdIntervention.Size = new System.Drawing.Size(81, 17);
            this.rdIntervention.TabIndex = 453;
            this.rdIntervention.TabStop = true;
            this.rdIntervention.Text = "Intervention";
            this.rdIntervention.UseVisualStyleBackColor = true;
            // 
            // rdHospitalisation
            // 
            this.rdHospitalisation.AutoSize = true;
            this.rdHospitalisation.ForeColor = System.Drawing.Color.Indigo;
            this.rdHospitalisation.Location = new System.Drawing.Point(9, 38);
            this.rdHospitalisation.Name = "rdHospitalisation";
            this.rdHospitalisation.Size = new System.Drawing.Size(93, 17);
            this.rdHospitalisation.TabIndex = 452;
            this.rdHospitalisation.TabStop = true;
            this.rdHospitalisation.Text = "Hospitalisation";
            this.rdHospitalisation.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 56);
            this.label1.TabIndex = 451;
            this.label1.Text = "CENTRE DE SANTE DE REFERENCE NOTRE DAME DU  CARMEL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Image = global::GestionClinic_WIN.Properties.Resources.LogoCarmel_PNG1;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(3, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 385);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 450;
            this.pictureBox1.TabStop = false;
            // 
            // cmdLoadData
            // 
            this.cmdLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdLoadData.ForeColor = System.Drawing.Color.SeaGreen;
            this.cmdLoadData.Location = new System.Drawing.Point(109, 45);
            this.cmdLoadData.Name = "cmdLoadData";
            this.cmdLoadData.Size = new System.Drawing.Size(77, 26);
            this.cmdLoadData.TabIndex = 449;
            this.cmdLoadData.Text = "Charge&r info.";
            this.cmdLoadData.UseVisualStyleBackColor = true;
            this.cmdLoadData.Click += new System.EventHandler(this.cmdLoadData_Click);
            // 
            // lblRecherche
            // 
            this.lblRecherche.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRecherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecherche.ForeColor = System.Drawing.Color.Maroon;
            this.lblRecherche.Location = new System.Drawing.Point(3, 5);
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(187, 25);
            this.lblRecherche.TabIndex = 448;
            this.lblRecherche.Text = "Rechercher un malade";
            this.lblRecherche.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRecherche.MouseLeave += new System.EventHandler(this.lblRecherche_MouseLeave);
            this.lblRecherche.Click += new System.EventHandler(this.lblRecherche_Click);
            this.lblRecherche.MouseEnter += new System.EventHandler(this.lblRecherche_MouseEnter);
            // 
            // bnvCateg
            // 
            this.bnvCateg.AddNewItem = null;
            this.bnvCateg.BackColor = System.Drawing.Color.Transparent;
            this.bnvCateg.CountItem = null;
            this.bnvCateg.DeleteItem = null;
            this.bnvCateg.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bnvCateg.Location = new System.Drawing.Point(0, 0);
            this.bnvCateg.MoveFirstItem = null;
            this.bnvCateg.MoveLastItem = null;
            this.bnvCateg.MoveNextItem = null;
            this.bnvCateg.MovePreviousItem = null;
            this.bnvCateg.Name = "bnvCateg";
            this.bnvCateg.PositionItem = null;
            this.bnvCateg.Size = new System.Drawing.Size(1084, 25);
            this.bnvCateg.TabIndex = 268;
            this.bnvCateg.Text = "bindingNavigator1";
            // 
            // FrmHospitalisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.img_home_player_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1084, 581);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MenTriage);
            this.Controls.Add(this.bnvCateg);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmHospitalisation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospitalisation et Interventions";
            this.Load += new System.EventHandler(this.FrmHospitalisation_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHospitalisation_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhotoPersonne)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.MenTriage.ResumeLayout(false);
            this.MenTriage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCateg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTraitHospitalisation;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblIntervention;
        private System.Windows.Forms.Label lblHospitalisation;
        private System.Windows.Forms.Label lblErgot;
        private System.Windows.Forms.Label lblNomMalade;
        private System.Windows.Forms.Panel Affichage;
        private System.Windows.Forms.PictureBox pbPhotoPersonne;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox MenTriage;
        private System.Windows.Forms.RadioButton rdIntervention;
        private System.Windows.Forms.RadioButton rdHospitalisation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cmdLoadData;
        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.BindingNavigator bnvCateg;
    }
}