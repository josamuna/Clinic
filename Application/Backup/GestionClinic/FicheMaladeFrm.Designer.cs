namespace GestionClinic_WIN
{
    partial class FicheMaladeFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRecherche = new System.Windows.Forms.Label();
            this.cmdAfficher = new System.Windows.Forms.Button();
            this.bindingNavigator2 = new System.Windows.Forms.BindingNavigator(this.components);
            this.crvRapport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRecherche);
            this.groupBox1.Controls.Add(this.cmdAfficher);
            this.groupBox1.Location = new System.Drawing.Point(792, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 45);
            this.groupBox1.TabIndex = 382;
            this.groupBox1.TabStop = false;
            // 
            // lblRecherche
            // 
            this.lblRecherche.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRecherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecherche.ForeColor = System.Drawing.Color.Maroon;
            this.lblRecherche.Location = new System.Drawing.Point(3, 12);
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(132, 25);
            this.lblRecherche.TabIndex = 378;
            this.lblRecherche.Text = "Rechercher malade";
            this.lblRecherche.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRecherche.MouseLeave += new System.EventHandler(this.lblRecherche_MouseLeave);
            this.lblRecherche.Click += new System.EventHandler(this.lblRecherche_Click);
            this.lblRecherche.MouseEnter += new System.EventHandler(this.lblRecherche_MouseEnter);
            // 
            // cmdAfficher
            // 
            this.cmdAfficher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdAfficher.ForeColor = System.Drawing.Color.Green;
            this.cmdAfficher.Location = new System.Drawing.Point(144, 14);
            this.cmdAfficher.Name = "cmdAfficher";
            this.cmdAfficher.Size = new System.Drawing.Size(70, 23);
            this.cmdAfficher.TabIndex = 1;
            this.cmdAfficher.Text = "Afficher";
            this.cmdAfficher.UseVisualStyleBackColor = true;
            this.cmdAfficher.Click += new System.EventHandler(this.cmdAfficher_Click);
            // 
            // bindingNavigator2
            // 
            this.bindingNavigator2.AddNewItem = null;
            this.bindingNavigator2.BackColor = System.Drawing.Color.Transparent;
            this.bindingNavigator2.CountItem = null;
            this.bindingNavigator2.DeleteItem = null;
            this.bindingNavigator2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator2.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator2.MoveFirstItem = null;
            this.bindingNavigator2.MoveLastItem = null;
            this.bindingNavigator2.MoveNextItem = null;
            this.bindingNavigator2.MovePreviousItem = null;
            this.bindingNavigator2.Name = "bindingNavigator2";
            this.bindingNavigator2.PositionItem = null;
            this.bindingNavigator2.Size = new System.Drawing.Size(1022, 25);
            this.bindingNavigator2.TabIndex = 380;
            this.bindingNavigator2.Text = "bindingNavigator2";
            // 
            // crvRapport
            // 
            this.crvRapport.ActiveViewIndex = -1;
            this.crvRapport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvRapport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvRapport.Location = new System.Drawing.Point(0, 0);
            this.crvRapport.Name = "crvRapport";
            this.crvRapport.SelectionFormula = "";
            this.crvRapport.Size = new System.Drawing.Size(1022, 591);
            this.crvRapport.TabIndex = 381;
            this.crvRapport.ViewTimeSelectionFormula = "";
            // 
            // FrmFicheMalade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.img_home_player_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1022, 591);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bindingNavigator2);
            this.Controls.Add(this.crvRapport);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmFicheMalade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiche du malade";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.Button cmdAfficher;
        private System.Windows.Forms.BindingNavigator bindingNavigator2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvRapport;
    }
}