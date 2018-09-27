namespace GestionClinic_WIN
{
    partial class DictionnaireFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DictionnaireFrm));
            this.crvDictionnaire = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.cboMalade = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crvDictionnaire
            // 
            this.crvDictionnaire.ActiveViewIndex = -1;
            this.crvDictionnaire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvDictionnaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvDictionnaire.Location = new System.Drawing.Point(0, 25);
            this.crvDictionnaire.Name = "crvDictionnaire";
            this.crvDictionnaire.SelectionFormula = "";
            this.crvDictionnaire.Size = new System.Drawing.Size(1116, 496);
            this.crvDictionnaire.TabIndex = 4;
            this.crvDictionnaire.ViewTimeSelectionFormula = "";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BackColor = System.Drawing.Color.Transparent;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNavigator1.Size = new System.Drawing.Size(1116, 25);
            this.bindingNavigator1.TabIndex = 7;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnAfficher);
            this.groupBox1.Controls.Add(this.cboMalade);
            this.groupBox1.Location = new System.Drawing.Point(11, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 111);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choisir un aptitude";
            // 
            // btnAfficher
            // 
            this.btnAfficher.Location = new System.Drawing.Point(26, 64);
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Size = new System.Drawing.Size(146, 27);
            this.btnAfficher.TabIndex = 5;
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.UseVisualStyleBackColor = true;
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
            // 
            // cboMalade
            // 
            this.cboMalade.FormattingEnabled = true;
            this.cboMalade.Location = new System.Drawing.Point(6, 37);
            this.cboMalade.Name = "cboMalade";
            this.cboMalade.Size = new System.Drawing.Size(178, 21);
            this.cboMalade.TabIndex = 5;
            // 
            // frmDictionnaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.img_home_player_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1116, 521);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crvDictionnaire);
            this.Controls.Add(this.bindingNavigator1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDictionnaire";
            this.Load += new System.EventHandler(this.frmDctionnaire_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvDictionnaire;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.ComboBox cboMalade;
    }
}