using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class DossierPresoncultationPaiementFrm : Form
    {
        public DossierPresoncultationPaiementFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsdossierpreconsultation dossierPreconsultation = new clsdossierpreconsultation();
        bool bln = false;
        BindingSource bsrc = new BindingSource();

        private void setMembersalllst(ListBox lst, string displayMember, string valueMember)
        {
            lst.DisplayMember = displayMember;
            lst.ValueMember = valueMember;
        }

        private void setbindingclsDossier(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", dossierPreconsultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", dossierPreconsultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", dossierPreconsultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", dossierPreconsultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void clearforbindingDossier(Control[] ctrl)
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

        private void bindingclsdossier()
        {
            Control[] tbcontrols = { txtDateOuvertureDossier1, txtIdMalade, txtEtatPaiement1, cboTypeFiche1 };
            clearforbindingDossier(tbcontrols);
            setbindingclsDossier(txtIdMalade, "Id_malade", 0);
            setbindingclsDossier(txtDateOuvertureDossier1, "Date", 0);
            setbindingclsDossier(txtEtatPaiement1, "Etatpaiement", 0);
            setbindingclsDossier(cboTypeFiche1, "Id_tarifpreconsultation", 1);
        }

        private void NewDossier()
        {
            dossierPreconsultation = new clsdossierpreconsultation();
            bln = false;
            bindingclsdossier();
            txtIdMalade.Text = clsDoTraitement.idMaladeDossierPre.ToString();
        }

        private void setbindinglstDossier(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindinglstDossier()
        {
            Control[] tbcontrols = { txtDateOuvertureDossier1, txtEtatPaiement1, txtIdMalade, cboTypeFiche1 };
            clearforbindingDossier(tbcontrols);

            setbindinglstDossier(txtDateOuvertureDossier1, "Date", 0);
            setbindinglstDossier(txtEtatPaiement1, "Etatpaiement", 0);
            setbindinglstDossier(cboTypeFiche1, "Id_tarifpreconsultation", 1);
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void RefreshDossier()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsdossierpreconsultation1(clsDoTraitement.idMaladeDossierPre);
                cboTypeFiche1.DataSource = clsMetier.GetInstance().getAllClstarifpreconsultation();
                setMembersalllst(lstDossierEncCours1, "DesignationComplete", "Id");
                setMembersallcbo(cboTypeFiche1, "Designation", "Id");
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
                NewDossier();
                txtEtatPaiement1.Text = "Fiche non payée";
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDossier();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    dossierPreconsultation.inserts();

                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsdossierpreconsultation d = (clsdossierpreconsultation)bsrc.Current;
                        new clsdossierpreconsultation().update(d);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsdossierpreconsultation1(clsDoTraitement.idMaladeDossierPre);
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmDossierPresoncultationPaiement_Load(object sender, EventArgs e)
        {
            bindingNavigator1.Enabled = true;
            btnDelete.Enabled = false;
            try
            {
                lstDossierEncCours1.DataSource = bsrc;
                RefreshDossier();

            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de chargement de la liste", "Erreur de Chargement");
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
                        clsdossierpreconsultation a = (clsdossierpreconsultation)bsrc.Current;
                        new clsdossierpreconsultation().delete(a);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.RefreshDossier();
                        btnDelete.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboTypeFiche1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstDossierEncCours1.Items.Count > 0)
                {
                    btnAdd.Enabled = false;
                    bindinglstDossier();
                    btnDelete.Enabled = true;
                    bln = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }

            try
            {
                txtPrix.Text = clsMetier.GetInstance().getClstarifpreconsultation(((clstarifpreconsultation)cboTypeFiche1.SelectedItem).Id).Montant.ToString();
            }
            catch (Exception) { txtPrix.Clear(); }
        }

        private void lstDossierEncCours1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstDossierEncCours1.Items.Count > 0)
                {
                    bindinglstDossier();
                    bln = true;
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void cboTypeFiche1_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.MAJ_fiche)
            {
                try
                {
                    cboTypeFiche1.DataSource = clsMetier.GetInstance().getAllClstarifpreconsultation();
                    setMembersallcbo(cboTypeFiche1, "Designation", "Id");
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
