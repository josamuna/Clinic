using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class DossierAccouchementFrm2 : UserControl
    {
        public DossierAccouchementFrm2()
        {
            InitializeComponent();
        }
        clsdossierconsultationaccouchement consultation = new clsdossierconsultationaccouchement();
        bool bln = false;
        BindingSource bsrc = new BindingSource();

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

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

        private void setbindingclsConsultationDossier(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", consultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", consultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", consultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", consultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingclsConsultationDossier()
        {
            Control[] tbcontrols = { txtDateOuvertureDossier,cboService,  txtEtatConsommation, txtIdMedecinCons, txtIdMalade };
            clearforbinding(tbcontrols);
            setbindingclsConsultationDossier(txtDateOuvertureDossier, "Date", 0);
            setbindingclsConsultationDossier(cboService, "Id_typeaccouchement", 1);
            setbindingclsConsultationDossier(txtIdMalade, "Id_malade", 0);
            setbindingclsConsultationDossier(txtIdMedecinCons, "Id_agent", 0);
            setbindingclsConsultationDossier(txtEtatConsommation, "Etatpaiement", 0);
        }

        public void New()
        {
            consultation = new clsdossierconsultationaccouchement();
            bln = false;
            bindingclsConsultationDossier();
            txtIdMedecinCons.Text = clsDoTraitement.id_Agent_Connecte.ToString();
            txtIdMalade.Text = clsDoTraitement.idMaladeDossierPre.ToString();
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

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        public void refresh()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsdossierconsultationaccouchement2(clsDoTraitement.idMaladeDossierPre, "Non cloturé non payé", "Payé non cloturé");
                cboService.DataSource = clsMetier.GetInstance().getAllClstypeaccouchement();
                setMembersallcbo(cboService, "Designation", "Id");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            clsdossierconsultationaccouchement c = (clsdossierconsultationaccouchement)bsrc.Current;
                            new clsdossierconsultationaccouchement().update(c);
                            MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    } 
                }
                else
                {
                    MessageBox.Show("Impossible d'enregistrer un homme pour un accouchement", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsdossierconsultationaccouchement2(clsDoTraitement.idMaladeDossierPre, "Non cloturé non payé", "Payé non cloturé");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void setbindinglstDossierConsultation(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindiglstDossierConsultation()
        {
            Control[] tbcontrols = { txtDateOuvertureDossier, cboService,  txtEtatConsommation, txtIdMedecinCons, txtIdMalade };
            clearforbinding(tbcontrols);
            setbindinglstDossierConsultation(cboService, "Id_typeaccouchement", 1);
            setbindinglstDossierConsultation(txtDateOuvertureDossier, "Date", 0);
            setbindinglstDossierConsultation(txtEtatConsommation, "Etatpaiement", 0);
            setbindinglstDossierConsultation(txtIdMedecinCons, "Id_agent", 0);
            setbindinglstDossierConsultation(txtIdMalade, "Id_malade", 0);
        }

        private void frmDossierConsultationPaiement_Load(object sender, EventArgs e)
        {
            bindingNavigator1.Enabled = true;
            btnDelete.Enabled = false;
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

        private void lstDossierEncCours_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (lstDossierEncCours.Items.Count > 0)
                {
                    bindiglstDossierConsultation();
                    btnDelete.Enabled = true;
                    bln = true;

                    try
                    {
                        txtPrix.Text = clsMetier.GetInstance().getClstypeaccouchement(((clstypeaccouchement)cboService.SelectedItem).Id).Prix.ToString();
                    }
                    catch (Exception) { txtPrix.Clear(); }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
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
                        clsdossierconsultationaccouchement a = (clsdossierconsultationaccouchement)bsrc.Current;
                        new clsdossierconsultationaccouchement().delete(a);
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

        private void lblAddTarif_Click(object sender, EventArgs e)
        {
            TarifsFrm fr = new TarifsFrm();
            fr.setFormPrincipal(principal);
            fr.Icon = principal.Icon;
            fr.ShowDialog();
        }

        private void cboService_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtPrix.Text = clsMetier.GetInstance().getClstypeaccouchement(((clstypeaccouchement)cboService.SelectedItem).Id).Prix.ToString();
            }
            catch (Exception) { txtPrix.Clear(); }
        }

        private void cboService_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.MAJ_Acouchement)
            {
                try
                {
                    cboService.DataSource = clsMetier.GetInstance().getAllClstypeaccouchement();
                    setMembersallcbo(cboService, "Designation", "Id");
                }
                catch (Exception) { }
            }
        }
    }
}
