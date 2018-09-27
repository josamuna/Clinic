namespace GestionClinic_WIN
{
    partial class RptAptitudePhysiqueFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptAptitudePhysiqueFrm));
            this.crvAptitudePhysique = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label3 = new System.Windows.Forms.Label();
            this.bnv = new System.Windows.Forms.BindingNavigator(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bnv)).BeginInit();
            this.SuspendLayout();
            // 
            // crvAptitudePhysique
            // 
            this.crvAptitudePhysique.ActiveViewIndex = -1;
            this.crvAptitudePhysique.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvAptitudePhysique.Location = new System.Drawing.Point(0, 25);
            this.crvAptitudePhysique.Name = "crvAptitudePhysique";
            this.crvAptitudePhysique.SelectionFormula = "";
            this.crvAptitudePhysique.Size = new System.Drawing.Size(1027, 582);
            this.crvAptitudePhysique.TabIndex = 56;
            this.crvAptitudePhysique.ViewTimeSelectionFormula = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(386, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Certificat d\'aptitude physique";
            // 
            // bnv
            // 
            this.bnv.AddNewItem = null;
            this.bnv.BackColor = System.Drawing.Color.Transparent;
            this.bnv.CountItem = null;
            this.bnv.DeleteItem = null;
            this.bnv.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bnv.Location = new System.Drawing.Point(0, 0);
            this.bnv.MoveFirstItem = null;
            this.bnv.MoveLastItem = null;
            this.bnv.MoveNextItem = null;
            this.bnv.MovePreviousItem = null;
            this.bnv.Name = "bnv";
            this.bnv.PositionItem = null;
            this.bnv.Size = new System.Drawing.Size(1027, 25);
            this.bnv.TabIndex = 58;
            this.bnv.Text = "bindingNavigator1";
            // 
            // FrmRptAptitudePhysique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestionClinic_WIN.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1027, 607);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.crvAptitudePhysique);
            this.Controls.Add(this.bnv);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmRptAptitudePhysique";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Certificat d\'aptitude physique";
            this.Load += new System.EventHandler(this.frmCertificatAptitudePhysique_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bnv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvAptitudePhysique;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingNavigator bnv;
    }
}