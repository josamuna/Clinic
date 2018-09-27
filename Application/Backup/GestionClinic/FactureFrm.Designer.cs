namespace GestionClinic_WIN
{
    partial class frmFacture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacture));
            this.bnvCateg = new System.Windows.Forms.BindingNavigator(this.components);
            this.crvFacture = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkFactureDetaille = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdSolde = new System.Windows.Forms.RadioButton();
            this.rdNonSolde = new System.Windows.Forms.RadioButton();
            this.cmdSoldeFacture = new System.Windows.Forms.Button();
            this.pnMalade = new System.Windows.Forms.Panel();
            this.cboMalade = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDate = new System.Windows.Forms.ComboBox();
            this.pnMituelle = new System.Windows.Forms.Panel();
            this.txtDateFin = new System.Windows.Forms.DateTimePicker();
            this.txtDateDebut = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboDateMituelle = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkMensuel = new System.Windows.Forms.CheckBox();
            this.cboEntreprise = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdMituelle = new System.Windows.Forms.RadioButton();
            this.rdMalade = new System.Windows.Forms.RadioButton();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bnvCateg)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnMalade.SuspendLayout();
            this.pnMituelle.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
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
            this.bnvCateg.Size = new System.Drawing.Size(877, 25);
            this.bnvCateg.TabIndex = 55;
            this.bnvCateg.Text = "bindingNavigator1";
            // 
            // crvFacture
            // 
            this.crvFacture.ActiveViewIndex = -1;
            this.crvFacture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvFacture.Location = new System.Drawing.Point(172, 25);
            this.crvFacture.Name = "crvFacture";
            this.crvFacture.SelectionFormula = "";
            this.crvFacture.Size = new System.Drawing.Size(705, 547);
            this.crvFacture.TabIndex = 56;
            this.crvFacture.ViewTimeSelectionFormula = "";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chkFactureDetaille);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.cmdSoldeFacture);
            this.groupBox1.Controls.Add(this.pnMalade);
            this.groupBox1.Controls.Add(this.pnMituelle);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.btnAfficher);
            this.groupBox1.Location = new System.Drawing.Point(2, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 453);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            // 
            // chkFactureDetaille
            // 
            this.chkFactureDetaille.AutoSize = true;
            this.chkFactureDetaille.BackColor = System.Drawing.Color.Transparent;
            this.chkFactureDetaille.ForeColor = System.Drawing.Color.DarkMagenta;
            this.chkFactureDetaille.Location = new System.Drawing.Point(7, 393);
            this.chkFactureDetaille.Name = "chkFactureDetaille";
            this.chkFactureDetaille.Size = new System.Drawing.Size(106, 17);
            this.chkFactureDetaille.TabIndex = 444;
            this.chkFactureDetaille.Text = "Facture Detaillée";
            this.chkFactureDetaille.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 13);
            this.label8.TabIndex = 443;
            this.label8.Text = "Catégorie des factures :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdSolde);
            this.panel1.Controls.Add(this.rdNonSolde);
            this.panel1.Location = new System.Drawing.Point(5, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(159, 23);
            this.panel1.TabIndex = 436;
            // 
            // rdSolde
            // 
            this.rdSolde.AutoSize = true;
            this.rdSolde.ForeColor = System.Drawing.Color.Red;
            this.rdSolde.Location = new System.Drawing.Point(91, 3);
            this.rdSolde.Name = "rdSolde";
            this.rdSolde.Size = new System.Drawing.Size(63, 17);
            this.rdSolde.TabIndex = 1;
            this.rdSolde.TabStop = true;
            this.rdSolde.Text = "Soldées";
            this.rdSolde.UseVisualStyleBackColor = true;
            this.rdSolde.CheckedChanged += new System.EventHandler(this.rdSolde_CheckedChanged);
            // 
            // rdNonSolde
            // 
            this.rdNonSolde.AutoSize = true;
            this.rdNonSolde.ForeColor = System.Drawing.Color.Green;
            this.rdNonSolde.Location = new System.Drawing.Point(2, 3);
            this.rdNonSolde.Name = "rdNonSolde";
            this.rdNonSolde.Size = new System.Drawing.Size(84, 17);
            this.rdNonSolde.TabIndex = 0;
            this.rdNonSolde.TabStop = true;
            this.rdNonSolde.Text = "Non soldées";
            this.rdNonSolde.UseVisualStyleBackColor = true;
            // 
            // cmdSoldeFacture
            // 
            this.cmdSoldeFacture.BackColor = System.Drawing.Color.Plum;
            this.cmdSoldeFacture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSoldeFacture.Location = new System.Drawing.Point(8, 419);
            this.cmdSoldeFacture.Name = "cmdSoldeFacture";
            this.cmdSoldeFacture.Size = new System.Drawing.Size(75, 23);
            this.cmdSoldeFacture.TabIndex = 437;
            this.cmdSoldeFacture.Text = "So&lder";
            this.cmdSoldeFacture.UseVisualStyleBackColor = false;
            this.cmdSoldeFacture.Click += new System.EventHandler(this.cmdSoldeFacture_Click);
            // 
            // pnMalade
            // 
            this.pnMalade.Controls.Add(this.cboMalade);
            this.pnMalade.Controls.Add(this.label1);
            this.pnMalade.Controls.Add(this.label2);
            this.pnMalade.Controls.Add(this.cboDate);
            this.pnMalade.Location = new System.Drawing.Point(6, 294);
            this.pnMalade.Name = "pnMalade";
            this.pnMalade.Size = new System.Drawing.Size(159, 93);
            this.pnMalade.TabIndex = 436;
            // 
            // cboMalade
            // 
            this.cboMalade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMalade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMalade.DropDownWidth = 230;
            this.cboMalade.FormattingEnabled = true;
            this.cboMalade.Location = new System.Drawing.Point(3, 21);
            this.cboMalade.Name = "cboMalade";
            this.cboMalade.Size = new System.Drawing.Size(153, 21);
            this.cboMalade.TabIndex = 2;
            this.cboMalade.SelectedIndexChanged += new System.EventHandler(this.cboMalade_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom du malade :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date :";
            // 
            // cboDate
            // 
            this.cboDate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDate.FormattingEnabled = true;
            this.cboDate.Location = new System.Drawing.Point(3, 65);
            this.cboDate.Name = "cboDate";
            this.cboDate.Size = new System.Drawing.Size(152, 21);
            this.cboDate.TabIndex = 3;
            // 
            // pnMituelle
            // 
            this.pnMituelle.Controls.Add(this.txtDateFin);
            this.pnMituelle.Controls.Add(this.txtDateDebut);
            this.pnMituelle.Controls.Add(this.label7);
            this.pnMituelle.Controls.Add(this.label6);
            this.pnMituelle.Controls.Add(this.cboDateMituelle);
            this.pnMituelle.Controls.Add(this.label5);
            this.pnMituelle.Controls.Add(this.chkMensuel);
            this.pnMituelle.Controls.Add(this.cboEntreprise);
            this.pnMituelle.Controls.Add(this.label4);
            this.pnMituelle.Location = new System.Drawing.Point(6, 97);
            this.pnMituelle.Name = "pnMituelle";
            this.pnMituelle.Size = new System.Drawing.Size(159, 191);
            this.pnMituelle.TabIndex = 436;
            // 
            // txtDateFin
            // 
            this.txtDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDateFin.Location = new System.Drawing.Point(6, 163);
            this.txtDateFin.Name = "txtDateFin";
            this.txtDateFin.Size = new System.Drawing.Size(148, 20);
            this.txtDateFin.TabIndex = 444;
            // 
            // txtDateDebut
            // 
            this.txtDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDateDebut.Location = new System.Drawing.Point(6, 120);
            this.txtDateDebut.Name = "txtDateDebut";
            this.txtDateDebut.Size = new System.Drawing.Size(148, 20);
            this.txtDateDebut.TabIndex = 443;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(4, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 442;
            this.label7.Text = "Date fin :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(4, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 440;
            this.label6.Text = "Date début :";
            // 
            // cboDateMituelle
            // 
            this.cboDateMituelle.FormattingEnabled = true;
            this.cboDateMituelle.Location = new System.Drawing.Point(4, 79);
            this.cboDateMituelle.Name = "cboDateMituelle";
            this.cboDateMituelle.Size = new System.Drawing.Size(152, 21);
            this.cboDateMituelle.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(4, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 437;
            this.label5.Text = "Date :";
            // 
            // chkMensuel
            // 
            this.chkMensuel.AutoSize = true;
            this.chkMensuel.Location = new System.Drawing.Point(5, 44);
            this.chkMensuel.Name = "chkMensuel";
            this.chkMensuel.Size = new System.Drawing.Size(74, 17);
            this.chkMensuel.TabIndex = 3;
            this.chkMensuel.Text = "Mensuelle";
            this.chkMensuel.UseVisualStyleBackColor = true;
            this.chkMensuel.CheckedChanged += new System.EventHandler(this.chkMensuel_CheckedChanged);
            // 
            // cboEntreprise
            // 
            this.cboEntreprise.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEntreprise.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEntreprise.DropDownWidth = 230;
            this.cboEntreprise.FormattingEnabled = true;
            this.cboEntreprise.Location = new System.Drawing.Point(4, 20);
            this.cboEntreprise.Name = "cboEntreprise";
            this.cboEntreprise.Size = new System.Drawing.Size(152, 21);
            this.cboEntreprise.TabIndex = 2;
            this.cboEntreprise.SelectedIndexChanged += new System.EventHandler(this.cboNomEntreprise_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(2, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 437;
            this.label4.Text = "Nom de l\'entreprise :";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdMituelle);
            this.panel4.Controls.Add(this.rdMalade);
            this.panel4.Location = new System.Drawing.Point(6, 69);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(159, 23);
            this.panel4.TabIndex = 435;
            // 
            // rdMituelle
            // 
            this.rdMituelle.AutoSize = true;
            this.rdMituelle.ForeColor = System.Drawing.Color.Maroon;
            this.rdMituelle.Location = new System.Drawing.Point(85, 3);
            this.rdMituelle.Name = "rdMituelle";
            this.rdMituelle.Size = new System.Drawing.Size(65, 17);
            this.rdMituelle.TabIndex = 1;
            this.rdMituelle.TabStop = true;
            this.rdMituelle.Text = "Mutuelle";
            this.rdMituelle.UseVisualStyleBackColor = true;
            this.rdMituelle.CheckedChanged += new System.EventHandler(this.rdMituelle_CheckedChanged);
            // 
            // rdMalade
            // 
            this.rdMalade.AutoSize = true;
            this.rdMalade.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rdMalade.Location = new System.Drawing.Point(14, 3);
            this.rdMalade.Name = "rdMalade";
            this.rdMalade.Size = new System.Drawing.Size(60, 17);
            this.rdMalade.TabIndex = 0;
            this.rdMalade.TabStop = true;
            this.rdMalade.Text = "Malade";
            this.rdMalade.UseVisualStyleBackColor = true;
            this.rdMalade.CheckedChanged += new System.EventHandler(this.rdMalade_CheckedChanged);
            // 
            // btnAfficher
            // 
            this.btnAfficher.BackColor = System.Drawing.Color.LightBlue;
            this.btnAfficher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficher.Location = new System.Drawing.Point(89, 419);
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Size = new System.Drawing.Size(75, 23);
            this.btnAfficher.TabIndex = 7;
            this.btnAfficher.Text = "A&fficher";
            this.btnAfficher.UseVisualStyleBackColor = false;
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(389, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Facturation";
            // 
            // frmFacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(877, 572);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crvFacture);
            this.Controls.Add(this.bnvCateg);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmFacture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturation";
            this.Load += new System.EventHandler(this.frmFacture_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFacture_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bnvCateg)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnMalade.ResumeLayout(false);
            this.pnMalade.PerformLayout();
            this.pnMituelle.ResumeLayout(false);
            this.pnMituelle.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnvCateg;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvFacture;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMalade;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.ComboBox cboDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rdMituelle;
        private System.Windows.Forms.RadioButton rdMalade;
        private System.Windows.Forms.Panel pnMituelle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboDateMituelle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkMensuel;
        private System.Windows.Forms.ComboBox cboEntreprise;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnMalade;
        private System.Windows.Forms.Button cmdSoldeFacture;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdSolde;
        private System.Windows.Forms.RadioButton rdNonSolde;
        private System.Windows.Forms.CheckBox chkFactureDetaille;
        private System.Windows.Forms.DateTimePicker txtDateDebut;
        private System.Windows.Forms.DateTimePicker txtDateFin;
    }
}