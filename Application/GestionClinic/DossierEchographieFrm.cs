﻿using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class DossierEchographieFrm : Form
    {
        public DossierEchographieFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsdossierechographie consultation = new clsdossierechographie();
        bool bln = false;
        BindingSource bsrc = new BindingSource();

        private void clearforbinding(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is DateTimePicker) ((DateTimePicker)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((DateTimePicker)ctrl[0]).Focus();
        }

        private void setbindingclsEchographieDossier(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", consultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", consultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", consultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", consultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingclsEchographieDossier()
        {
            Control[] tbcontrols = { txtDateOuvertureDossier, cboService, txtEtatConsommation, txtIdMedecin, txtIdMalade };
            clearforbinding(tbcontrols);
            setbindingclsEchographieDossier(txtDateOuvertureDossier, "Date", 0);
            setbindingclsEchographieDossier(cboService, "Id_tarifechographie", 1);
            setbindingclsEchographieDossier(txtIdMalade, "Id_malade", 0);
            setbindingclsEchographieDossier(txtIdMedecin, "Id_agent", 0);
            setbindingclsEchographieDossier(txtEtatConsommation, "Etatpaiement", 0);
        }

        public void New()
        {
            consultation = new clsdossierechographie();
            bln = false;
            bindingclsEchographieDossier();
            txtIdMedecin.Text = clsDoTraitement.id_Agent_Connecte.ToString();
            txtIdMalade.Text = clsDoTraitement.idMaladeDossierPre.ToString();
        }

        private void setbindinglstDossierEchographie(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindiglstDossierEchographie()
        {
            Control[] tbcontrols = { txtDateOuvertureDossier, cboService, txtEtatConsommation, txtIdMedecin, txtIdMalade };
            clearforbinding(tbcontrols);
            setbindinglstDossierEchographie(cboService, "Id_tarifechographie", 1);
            setbindinglstDossierEchographie(txtDateOuvertureDossier, "Date", 0);
            setbindinglstDossierEchographie(txtEtatConsommation, "Etatpaiement", 0);
            setbindinglstDossierEchographie(txtIdMedecin, "Id_agent", 0);
            setbindinglstDossierEchographie(txtIdMalade, "Id_malade", 0);
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        public void refresh()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsdossierechographie2(clsDoTraitement.idMaladeDossierPre, "Non cloturé non payé", "Payé non cloturé");
                cboService.DataSource = clsMetier.GetInstance().getAllClstarifechographie();
                setMembersallcbo(cboService, "Designation", "Id");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                New();
                txtEtatConsommation.Text = "Non cloturé non payé";
            }
            catch (Exception)
            {
                btnSave.Enabled = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (((clsmalade)clsMetier.GetInstance().getClsmalade(consultation.Id_malade)).Sexe == "F")
                {
                    if (!bln)
                    {
                        consultation.inserts();
                        MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (bsrc.DataSource != null)
                        {
                            clsdossierechographie c = (clsdossierechographie)bsrc.Current;
                            new clsdossierechographie().update(c);
                            MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Impossible d'enregistrer un homme pour une consultation prénatale", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsdossierechographie2(clsDoTraitement.idMaladeDossierPre, "Non cloturé non payé", "Payé non cloturé");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lstDossierEncCours_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstDossierEncCours.Items.Count > 0)
                {
                    bindiglstDossierEchographie();
                    btnDelete.Enabled = true;
                    bln = true;

                    try
                    {
                        txtPrix.Text = clsMetier.GetInstance().getClstarifechographie(((clstarifechographie)cboService.SelectedItem).Id).Montant.ToString();
                    }
                    catch (Exception) { txtPrix.Clear(); }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void cboService_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtPrix.Text = clsMetier.GetInstance().getClstarifechographie(((clstarifechographie)cboService.SelectedItem).Id).Montant.ToString();
            }
            catch (Exception) { txtPrix.Clear(); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc.DataSource != null)
                    {
                        clsdossierechographie a = (clsdossierechographie)bsrc.Current;
                        new clsdossierechographie().delete(a);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.refresh();
                        btnDelete.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmDossierEchographie_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;

            bindingNavigator1.Enabled = true;
            try
            {
                lstDossierEncCours.DataSource = bsrc;
                refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de chargement de la liste", "Erreur de Chargement");
            }
        }

        private void cboService_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.MAJ_Echographie)
            {
                try
                {
                    cboService.DataSource = clsMetier.GetInstance().getAllClstarifechographie();
                    setMembersallcbo(cboService, "Designation", "Id");
                }
                catch (Exception) { }
            }
        }

        private void lblAddTarif_Click(object sender, EventArgs e)
        {
            TarifsFrm fr = new TarifsFrm();
            fr.setFormPrincipal(principal);
            fr.Icon = principal.Icon;
            fr.ShowDialog();
        }
    }
}
