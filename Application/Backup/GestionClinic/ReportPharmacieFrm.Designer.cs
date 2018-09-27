namespace GestionClinic_WIN
{
    partial class ReportPharmacieFrm
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
            this.cboMois = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.rdEntreeSorties = new System.Windows.Forms.RadioButton();
            this.chkTous = new System.Windows.Forms.CheckBox();
            this.rdSortiesSeul = new System.Windows.Forms.RadioButton();
            this.rdMensuel = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAffTout = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rdJournalier = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gpSelection = new System.Windows.Forms.GroupBox();
            this.chkTousService = new System.Windows.Forms.CheckBox();
            this.btnAfficherService = new System.Windows.Forms.Button();
            this.rdEntreeSeul = new System.Windows.Forms.RadioButton();
            this.txtDateFin = new System.Windows.Forms.DateTimePicker();
            this.txtDateDebut = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.cboService = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAfficherExp = new System.Windows.Forms.Button();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bnvCateg = new System.Windows.Forms.BindingNavigator(this.components);
            this.crvSatistiquePharmacie = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.gpSelection.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCateg)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMois
            // 
            this.cboMois.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMois.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMois.FormattingEnabled = true;
            this.cboMois.Location = new System.Drawing.Point(16, 482);
            this.cboMois.Name = "cboMois";
            this.cboMois.Size = new System.Drawing.Size(148, 21);
            this.cboMois.TabIndex = 268;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(14, 467);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 267;
            this.label9.Text = "Sélectionner un mois :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(523, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 22);
            this.label3.TabIndex = 63;
            this.label3.Text = "Pharmacie";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(16, 524);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(148, 20);
            this.txtDate.TabIndex = 265;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(16, 505);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 13);
            this.label13.TabIndex = 266;
            this.label13.Text = "Sélectionner une date :";
            // 
            // rdEntreeSorties
            // 
            this.rdEntreeSorties.AutoSize = true;
            this.rdEntreeSorties.ForeColor = System.Drawing.Color.Lavender;
            this.rdEntreeSorties.Location = new System.Drawing.Point(13, 40);
            this.rdEntreeSorties.Name = "rdEntreeSorties";
            this.rdEntreeSorties.Size = new System.Drawing.Size(106, 17);
            this.rdEntreeSorties.TabIndex = 2;
            this.rdEntreeSorties.TabStop = true;
            this.rdEntreeSorties.Text = "Entrées et sorties";
            this.rdEntreeSorties.UseVisualStyleBackColor = true;
            // 
            // chkTous
            // 
            this.chkTous.AutoSize = true;
            this.chkTous.Location = new System.Drawing.Point(17, 306);
            this.chkTous.Name = "chkTous";
            this.chkTous.Size = new System.Drawing.Size(88, 17);
            this.chkTous.TabIndex = 10;
            this.chkTous.Text = "Tous afficher";
            this.chkTous.UseVisualStyleBackColor = true;
            this.chkTous.CheckedChanged += new System.EventHandler(this.chkTous_CheckedChanged);
            // 
            // rdSortiesSeul
            // 
            this.rdSortiesSeul.AutoSize = true;
            this.rdSortiesSeul.ForeColor = System.Drawing.Color.Yellow;
            this.rdSortiesSeul.Location = new System.Drawing.Point(80, 18);
            this.rdSortiesSeul.Name = "rdSortiesSeul";
            this.rdSortiesSeul.Size = new System.Drawing.Size(57, 17);
            this.rdSortiesSeul.TabIndex = 1;
            this.rdSortiesSeul.TabStop = true;
            this.rdSortiesSeul.Text = "Sorties";
            this.rdSortiesSeul.UseVisualStyleBackColor = true;
            // 
            // rdMensuel
            // 
            this.rdMensuel.AutoSize = true;
            this.rdMensuel.ForeColor = System.Drawing.Color.Honeydew;
            this.rdMensuel.Location = new System.Drawing.Point(37, 16);
            this.rdMensuel.Name = "rdMensuel";
            this.rdMensuel.Size = new System.Drawing.Size(65, 17);
            this.rdMensuel.TabIndex = 0;
            this.rdMensuel.TabStop = true;
            this.rdMensuel.Text = "Mensuel";
            this.rdMensuel.UseVisualStyleBackColor = true;
            this.rdMensuel.CheckedChanged += new System.EventHandler(this.rdMensuel_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(-3, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "-----------------------------------------";
            // 
            // btnAffTout
            // 
            this.btnAffTout.BackColor = System.Drawing.Color.Silver;
            this.btnAffTout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAffTout.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAffTout.Location = new System.Drawing.Point(16, 551);
            this.btnAffTout.Name = "btnAffTout";
            this.btnAffTout.Size = new System.Drawing.Size(147, 23);
            this.btnAffTout.TabIndex = 8;
            this.btnAffTout.Text = "Afficher";
            this.btnAffTout.UseVisualStyleBackColor = false;
            this.btnAffTout.Click += new System.EventHandler(this.btnAffTout_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(10, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Liste des articles expirés";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(-2, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "-----------------------------------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Liste des articles en stock";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(-2, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(213, 18);
            this.label8.TabIndex = 6;
            this.label8.Text = "-----------------------------------------";
            // 
            // rdJournalier
            // 
            this.rdJournalier.AutoSize = true;
            this.rdJournalier.ForeColor = System.Drawing.Color.Cornsilk;
            this.rdJournalier.Location = new System.Drawing.Point(36, 40);
            this.rdJournalier.Name = "rdJournalier";
            this.rdJournalier.Size = new System.Drawing.Size(70, 17);
            this.rdJournalier.TabIndex = 1;
            this.rdJournalier.TabStop = true;
            this.rdJournalier.Text = "Journalier";
            this.rdJournalier.UseVisualStyleBackColor = true;
            this.rdJournalier.CheckedChanged += new System.EventHandler(this.rdJournalier_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(45, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Fche de stock";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(-2, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "-----------------------------------------";
            // 
            // gpSelection
            // 
            this.gpSelection.BackColor = System.Drawing.Color.Silver;
            this.gpSelection.Controls.Add(this.rdJournalier);
            this.gpSelection.Controls.Add(this.rdMensuel);
            this.gpSelection.Location = new System.Drawing.Point(16, 396);
            this.gpSelection.Name = "gpSelection";
            this.gpSelection.Size = new System.Drawing.Size(148, 66);
            this.gpSelection.TabIndex = 269;
            this.gpSelection.TabStop = false;
            this.gpSelection.Text = "Sélection du type";
            // 
            // chkTousService
            // 
            this.chkTousService.AutoSize = true;
            this.chkTousService.Location = new System.Drawing.Point(13, 125);
            this.chkTousService.Name = "chkTousService";
            this.chkTousService.Size = new System.Drawing.Size(88, 17);
            this.chkTousService.TabIndex = 279;
            this.chkTousService.Text = "Tous afficher";
            this.chkTousService.UseVisualStyleBackColor = true;
            this.chkTousService.CheckedChanged += new System.EventHandler(this.chkTousService_CheckedChanged);
            // 
            // btnAfficherService
            // 
            this.btnAfficherService.BackColor = System.Drawing.Color.Silver;
            this.btnAfficherService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficherService.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAfficherService.Location = new System.Drawing.Point(21, 248);
            this.btnAfficherService.Name = "btnAfficherService";
            this.btnAfficherService.Size = new System.Drawing.Size(138, 23);
            this.btnAfficherService.TabIndex = 278;
            this.btnAfficherService.Text = "Afficher";
            this.btnAfficherService.UseVisualStyleBackColor = false;
            this.btnAfficherService.Click += new System.EventHandler(this.btnAfficherService_Click);
            // 
            // rdEntreeSeul
            // 
            this.rdEntreeSeul.AutoSize = true;
            this.rdEntreeSeul.ForeColor = System.Drawing.Color.Bisque;
            this.rdEntreeSeul.Location = new System.Drawing.Point(13, 17);
            this.rdEntreeSeul.Name = "rdEntreeSeul";
            this.rdEntreeSeul.Size = new System.Drawing.Size(61, 17);
            this.rdEntreeSeul.TabIndex = 0;
            this.rdEntreeSeul.TabStop = true;
            this.rdEntreeSeul.Text = "Entrées";
            this.rdEntreeSeul.UseVisualStyleBackColor = true;
            // 
            // txtDateFin
            // 
            this.txtDateFin.Location = new System.Drawing.Point(4, 222);
            this.txtDateFin.Name = "txtDateFin";
            this.txtDateFin.Size = new System.Drawing.Size(168, 20);
            this.txtDateFin.TabIndex = 277;
            // 
            // txtDateDebut
            // 
            this.txtDateDebut.Location = new System.Drawing.Point(4, 183);
            this.txtDateDebut.Name = "txtDateDebut";
            this.txtDateDebut.Size = new System.Drawing.Size(168, 20);
            this.txtDateDebut.TabIndex = 276;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 207);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 275;
            this.label14.Text = "Date fin :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkTousService);
            this.panel1.Controls.Add(this.btnAfficherService);
            this.panel1.Controls.Add(this.txtDateFin);
            this.panel1.Controls.Add(this.txtDateDebut);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cboService);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnAfficherExp);
            this.panel1.Controls.Add(this.btnAfficher);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.gpSelection);
            this.panel1.Controls.Add(this.cboMois);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtDate);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.chkTous);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnAffTout);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 582);
            this.panel1.TabIndex = 62;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 274;
            this.label12.Text = "Date début :";
            // 
            // cboService
            // 
            this.cboService.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboService.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboService.DropDownWidth = 240;
            this.cboService.FormattingEnabled = true;
            this.cboService.Location = new System.Drawing.Point(50, 143);
            this.cboService.Name = "cboService";
            this.cboService.Size = new System.Drawing.Size(121, 21);
            this.cboService.TabIndex = 273;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(-1, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 272;
            this.label11.Text = "Service :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(22, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 16);
            this.label10.TabIndex = 271;
            this.label10.Text = "Sorties pour services";
            // 
            // btnAfficherExp
            // 
            this.btnAfficherExp.BackColor = System.Drawing.Color.Silver;
            this.btnAfficherExp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficherExp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAfficherExp.Location = new System.Drawing.Point(21, 73);
            this.btnAfficherExp.Name = "btnAfficherExp";
            this.btnAfficherExp.Size = new System.Drawing.Size(138, 23);
            this.btnAfficherExp.TabIndex = 4;
            this.btnAfficherExp.Text = "Afficher";
            this.btnAfficherExp.UseVisualStyleBackColor = false;
            this.btnAfficherExp.Click += new System.EventHandler(this.btnAfficherExp_Click);
            // 
            // btnAfficher
            // 
            this.btnAfficher.BackColor = System.Drawing.Color.Silver;
            this.btnAfficher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficher.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAfficher.Location = new System.Drawing.Point(21, 21);
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Size = new System.Drawing.Size(138, 23);
            this.btnAfficher.TabIndex = 1;
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.UseVisualStyleBackColor = false;
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rdEntreeSorties);
            this.groupBox1.Controls.Add(this.rdSortiesSeul);
            this.groupBox1.Controls.Add(this.rdEntreeSeul);
            this.groupBox1.Location = new System.Drawing.Point(16, 325);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 66);
            this.groupBox1.TabIndex = 270;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entrées ou Sorties ";
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
            this.bnvCateg.TabIndex = 61;
            this.bnvCateg.Text = "bindingNavigator1";
            // 
            // crvSatistiquePharmacie
            // 
            this.crvSatistiquePharmacie.ActiveViewIndex = -1;
            this.crvSatistiquePharmacie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvSatistiquePharmacie.Location = new System.Drawing.Point(178, 26);
            this.crvSatistiquePharmacie.Name = "crvSatistiquePharmacie";
            this.crvSatistiquePharmacie.SelectionFormula = "";
            this.crvSatistiquePharmacie.Size = new System.Drawing.Size(977, 581);
            this.crvSatistiquePharmacie.TabIndex = 64;
            this.crvSatistiquePharmacie.ViewTimeSelectionFormula = "";
            // 
            // FrmReportPharmacie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1152, 607);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bnvCateg);
            this.Controls.Add(this.crvSatistiquePharmacie);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmReportPharmacie";
            this.Load += new System.EventHandler(this.FrmReportPharmacie_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmReportPharmacie_FormClosing);
            this.gpSelection.ResumeLayout(false);
            this.gpSelection.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCateg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMois;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rdEntreeSorties;
        private System.Windows.Forms.CheckBox chkTous;
        private System.Windows.Forms.RadioButton rdSortiesSeul;
        private System.Windows.Forms.RadioButton rdMensuel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAffTout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rdJournalier;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gpSelection;
        private System.Windows.Forms.CheckBox chkTousService;
        private System.Windows.Forms.Button btnAfficherService;
        private System.Windows.Forms.RadioButton rdEntreeSeul;
        private System.Windows.Forms.DateTimePicker txtDateFin;
        private System.Windows.Forms.DateTimePicker txtDateDebut;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboService;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAfficherExp;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingNavigator bnvCateg;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvSatistiquePharmacie;
    }
}