namespace GestionClinic_WIN
{
    partial class ReportLaboratoireFrm
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
            this.dtdateExmalade = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.dtdateMin = new System.Windows.Forms.DateTimePicker();
            this.dtDateMax = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.btnAffic = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboExamen = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnAffichersP = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.dtDebut = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAfficherExm = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cboMalade = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.bnvCateg = new System.Windows.Forms.BindingNavigator(this.components);
            this.crvSatistiqueLaboratoire = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCateg)).BeginInit();
            this.SuspendLayout();
            // 
            // dtdateExmalade
            // 
            this.dtdateExmalade.Location = new System.Drawing.Point(1, 340);
            this.dtdateExmalade.Name = "dtdateExmalade";
            this.dtdateExmalade.Size = new System.Drawing.Size(174, 20);
            this.dtdateExmalade.TabIndex = 86;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label18.Location = new System.Drawing.Point(70, 319);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 18);
            this.label18.TabIndex = 85;
            this.label18.Text = "Date";
            // 
            // dtdateMin
            // 
            this.dtdateMin.Location = new System.Drawing.Point(-1, 481);
            this.dtdateMin.Name = "dtdateMin";
            this.dtdateMin.Size = new System.Drawing.Size(174, 20);
            this.dtdateMin.TabIndex = 84;
            // 
            // dtDateMax
            // 
            this.dtDateMax.Location = new System.Drawing.Point(-1, 529);
            this.dtDateMax.Name = "dtDateMax";
            this.dtDateMax.Size = new System.Drawing.Size(174, 20);
            this.dtDateMax.TabIndex = 83;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label17.Location = new System.Drawing.Point(53, 504);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 18);
            this.label17.TabIndex = 82;
            this.label17.Text = "Date max :";
            // 
            // btnAffic
            // 
            this.btnAffic.BackColor = System.Drawing.Color.Silver;
            this.btnAffic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAffic.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAffic.Location = new System.Drawing.Point(19, 559);
            this.btnAffic.Name = "btnAffic";
            this.btnAffic.Size = new System.Drawing.Size(138, 27);
            this.btnAffic.TabIndex = 80;
            this.btnAffic.Text = "Afficher";
            this.btnAffic.UseVisualStyleBackColor = false;
            this.btnAffic.Click += new System.EventHandler(this.btnAffic_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label16.Location = new System.Drawing.Point(56, 460);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 18);
            this.label16.TabIndex = 79;
            this.label16.Text = "Date min";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label15.Location = new System.Drawing.Point(60, 413);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 18);
            this.label15.TabIndex = 77;
            this.label15.Text = "Examen";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtdateExmalade);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.dtdateMin);
            this.panel1.Controls.Add(this.dtDateMax);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.btnAffic);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.cboExamen);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.btnAffichersP);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.dtFin);
            this.panel1.Controls.Add(this.dtDebut);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.btnAfficherExm);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboMalade);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnAfficher);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 596);
            this.panel1.TabIndex = 66;
            // 
            // cboExamen
            // 
            this.cboExamen.FormattingEnabled = true;
            this.cboExamen.Location = new System.Drawing.Point(1, 433);
            this.cboExamen.Name = "cboExamen";
            this.cboExamen.Size = new System.Drawing.Size(171, 21);
            this.cboExamen.TabIndex = 76;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(-26, 402);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(213, 18);
            this.label14.TabIndex = 75;
            this.label14.Text = "-----------------------------------------";
            // 
            // btnAffichersP
            // 
            this.btnAffichersP.BackColor = System.Drawing.Color.Silver;
            this.btnAffichersP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAffichersP.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAffichersP.Location = new System.Drawing.Point(19, 207);
            this.btnAffichersP.Name = "btnAffichersP";
            this.btnAffichersP.Size = new System.Drawing.Size(138, 27);
            this.btnAffichersP.TabIndex = 74;
            this.btnAffichersP.Text = "Afficher";
            this.btnAffichersP.UseVisualStyleBackColor = false;
            this.btnAffichersP.Click += new System.EventHandler(this.btnAffichersP_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(72, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 18);
            this.label13.TabIndex = 73;
            this.label13.Text = "Au";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(72, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 18);
            this.label12.TabIndex = 72;
            this.label12.Text = "Du";
            // 
            // dtFin
            // 
            this.dtFin.Location = new System.Drawing.Point(-1, 181);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(174, 20);
            this.dtFin.TabIndex = 71;
            // 
            // dtDebut
            // 
            this.dtDebut.Location = new System.Drawing.Point(-1, 140);
            this.dtDebut.Name = "dtDebut";
            this.dtDebut.Size = new System.Drawing.Size(174, 20);
            this.dtDebut.TabIndex = 65;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(-19, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(213, 18);
            this.label9.TabIndex = 70;
            this.label9.Text = "-----------------------------------------";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(27, 244);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 18);
            this.label10.TabIndex = 69;
            this.label10.Text = "Examen et résulat";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(-17, 229);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(213, 18);
            this.label11.TabIndex = 68;
            this.label11.Text = "-----------------------------------------";
            // 
            // btnAfficherExm
            // 
            this.btnAfficherExm.BackColor = System.Drawing.Color.Silver;
            this.btnAfficherExm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficherExm.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAfficherExm.Location = new System.Drawing.Point(19, 375);
            this.btnAfficherExm.Name = "btnAfficherExm";
            this.btnAfficherExm.Size = new System.Drawing.Size(138, 27);
            this.btnAfficherExm.TabIndex = 67;
            this.btnAfficherExm.Text = "Afficher";
            this.btnAfficherExm.UseVisualStyleBackColor = false;
            this.btnAfficherExm.Click += new System.EventHandler(this.btnAfficherExm_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(61, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 18);
            this.label8.TabIndex = 66;
            this.label8.Text = "Malade";
            // 
            // cboMalade
            // 
            this.cboMalade.FormattingEnabled = true;
            this.cboMalade.Location = new System.Drawing.Point(2, 293);
            this.cboMalade.Name = "cboMalade";
            this.cboMalade.Size = new System.Drawing.Size(171, 21);
            this.cboMalade.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Statistique générale";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(-6, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "-----------------------------------------";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(-4, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "-----------------------------------------";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(-4, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "-----------------------------------------";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(23, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Statistique partielle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(-2, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "-----------------------------------------";
            // 
            // btnAfficher
            // 
            this.btnAfficher.BackColor = System.Drawing.Color.Silver;
            this.btnAfficher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficher.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAfficher.Location = new System.Drawing.Point(21, 54);
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Size = new System.Drawing.Size(138, 27);
            this.btnAfficher.TabIndex = 1;
            this.btnAfficher.Text = "Afficher Tout";
            this.btnAfficher.UseVisualStyleBackColor = false;
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
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
            this.bnvCateg.Size = new System.Drawing.Size(1152, 25);
            this.bnvCateg.TabIndex = 65;
            this.bnvCateg.Text = "bindingNavigator1";
            // 
            // crvSatistiqueLaboratoire
            // 
            this.crvSatistiqueLaboratoire.ActiveViewIndex = -1;
            this.crvSatistiqueLaboratoire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvSatistiqueLaboratoire.Location = new System.Drawing.Point(179, 28);
            this.crvSatistiqueLaboratoire.Name = "crvSatistiqueLaboratoire";
            this.crvSatistiqueLaboratoire.SelectionFormula = "";
            this.crvSatistiqueLaboratoire.Size = new System.Drawing.Size(976, 593);
            this.crvSatistiqueLaboratoire.TabIndex = 67;
            this.crvSatistiqueLaboratoire.ViewTimeSelectionFormula = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(544, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 22);
            this.label4.TabIndex = 68;
            this.label4.Text = "Laboratoire";
            // 
            // FrmReportLaboratoire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1152, 621);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crvSatistiqueLaboratoire);
            this.Controls.Add(this.bnvCateg);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmReportLaboratoire";
            this.Load += new System.EventHandler(this.FrmReportLaboratoire_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmReportLaboratoire_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCateg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtdateExmalade;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtdateMin;
        private System.Windows.Forms.DateTimePicker dtDateMax;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnAffic;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboExamen;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnAffichersP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.DateTimePicker dtDebut;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAfficherExm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboMalade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.BindingNavigator bnvCateg;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvSatistiqueLaboratoire;
        private System.Windows.Forms.Label label4;
    }
}