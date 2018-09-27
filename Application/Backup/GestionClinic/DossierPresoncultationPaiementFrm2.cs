using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class FrmDossierPreconsultationPaiement2 : UserControl
    {

        public FrmDossierPreconsultationPaiement2()
        {
            InitializeComponent();
        }


        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsdossierpreconsultation dossierPreconsultation = new clsdossierpreconsultation();
        clssortie fichesupp = new clssortie();
        private BindingSource bsrc1 = new BindingSource();
        bool bln = false, bln2 = false;
        BindingSource bsrc = new BindingSource();

        private void setbindinglstDossierFicheSupp(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

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

        private void NewFicheSupp()
        {
            fichesupp = new clssortie();
            bln2 = false;
        }

        private void RefreshDossierFicheSupp()
        {
            try
            {
                bsrc1.DataSource = clsMetier.GetInstance().getAllClssortieFicheSeul(clsDoTraitement.IdMalade);
                lstFicheAdd.DataSource = clsMetier.GetInstance().getAllClssortieFicheSeul(clsDoTraitement.IdMalade);
                setMembersalllst(lstFicheAdd, "Date", "Id");

                if (lstDossierEncCours1.Items.Count > 0) activeFiche(true);
                else activeFiche(false);

                if (lstFicheAdd.Items.Count == 0)
                {
                    cmdSaveFicheSup.Enabled = false;
                    cmdDeleteFicheSup.Enabled = false;
                    cmdAjouter.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation des fiches supplémentaires", "Fiche supplémentairess", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            try
            {
                RefreshDossierFicheSupp();
            }
            catch (Exception) { }

            try
            {
                cboTypeFiche2.DataSource = clsMetier.GetInstance().getAllClsarticleFicheSeul();
                setMembersallcbo(cboTypeFiche2, "Desination", "Id");

            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de chargement des fiches supplémentaires", "Erreur de Chargement");
            }
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
                RefreshDossier();

                RefreshDossierFicheSupp();
            }
            catch (Exception) { }

            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsdossierpreconsultation1(clsDoTraitement.idMaladeDossierPre);
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void activeFiche(bool value)
        {
            gpFicheSupple.Enabled = value;
        }

        private void frmDossierPresoncultationPaiement_Load(object sender, EventArgs e)
        {
            bindingNavigator1.Enabled = true;
            btnDelete.Enabled = false;
            cmdSaveFicheSup.Enabled = false;
            cmdDeleteFicheSup.Enabled = false;

            activeFiche(false);
            try
            {
                lstDossierEncCours1.DataSource = bsrc;
                RefreshDossier();

                RefreshDossierFicheSupp();

                cboTypeFiche2.DataSource = clsMetier.GetInstance().getAllClsarticleFicheSeul();
                setMembersallcbo(cboTypeFiche2, "Desination", "Id");
                
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de chargement de la liste", "Erreur de Chargement");
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    BindingSource[] bdsrc = { bsrc };
            //    ComboBox[] cbo = { cboTypeFiche1 };
            //    clsDoTraitement.GetInstance().unloadData(bdsrc, cbo);
            //}
            //catch (Exception) { }

            this.Dispose();
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
                        btnDelete.Enabled = false;
                    }
                }

                try
                {
                    RefreshDossier();

                    RefreshDossierFicheSupp();
                }
                catch (Exception) { }
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
                    activeFiche(true);
                }
                else activeFiche(false);
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void cmdAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                NewFicheSupp();
                txtEtatPaiement2.Text = "Non payé";
                cmdSaveFicheSup.Enabled = true;
                cmdDeleteFicheSup.Enabled = true;
            }
            catch (Exception) { cmdSaveFicheSup.Enabled = false; }
        }

        private void cmdSaveFicheSup_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln2)
                {
                    fichesupp.Date = Convert.ToDateTime(txtDateAjout.Text);
                    fichesupp.Etatpaiement = txtEtatPaiement2.Text;
                    //fichesupp.Id_article = Convert.ToInt32(((clsarticle)cboTypeFiche2.SelectedItem).Id);
                    fichesupp.Id_service = null;
                    fichesupp.Id_malade = clsDoTraitement.IdMalade;
                    fichesupp.Quantinte = 1;
                    fichesupp.Designation = cboTypeFiche2.Text;
                    fichesupp.Montant = Convert.ToInt32(((clsarticle)cboTypeFiche2.SelectedItem).Pu);
                    fichesupp.Stock_in = 0;
                    fichesupp.Sortiemalade = true;

                    fichesupp.insertion();

                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc1.DataSource != null)
                    {
                        //clssortie d = (clssortie)bsrc4.Current;
                        //new clssortie().updatage(d);
                        fichesupp.Date = Convert.ToDateTime(txtDateAjout.Text);
                        fichesupp.Montant = Convert.ToInt32(((clsarticle)cboTypeFiche2.SelectedItem).Pu);
                        fichesupp.Designation = cboTypeFiche2.Text;

                        fichesupp.updatage(fichesupp);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            RefreshDossierFicheSupp();
            RefreshDossier();
        }

        private void lstFicheAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFicheAdd.SelectedItems.Count > 0)
            {
                fichesupp.Id = ((clssortie)lstFicheAdd.SelectedItem).Id;
                fichesupp.Date = ((clssortie)lstFicheAdd.SelectedItem).Date;
                fichesupp.Etatpaiement = ((clssortie)lstFicheAdd.SelectedItem).Etatpaiement;
                fichesupp.Id_article = ((clssortie)lstFicheAdd.SelectedItem).Id_article;
                fichesupp.Id_service = ((clssortie)lstFicheAdd.SelectedItem).Id_service;
                fichesupp.Id_malade = ((clssortie)lstFicheAdd.SelectedItem).Id_malade;
                fichesupp.Quantinte = ((clssortie)lstFicheAdd.SelectedItem).Quantinte;
                fichesupp.Designation = ((clssortie)lstFicheAdd.SelectedItem).Designation;
                fichesupp.Montant = ((clssortie)lstFicheAdd.SelectedItem).Montant;
                fichesupp.Stock_in = ((clssortie)lstFicheAdd.SelectedItem).Stock_in;
                fichesupp.Sortiemalade = ((clssortie)lstFicheAdd.SelectedItem).Sortiemalade;

                txtDateAjout.Text = fichesupp.Date.Value.ToLongDateString();
                cboTypeFiche2.Text = clsMetier.GetInstance().getClsarticleFicheSeul(fichesupp.Id_article).Desination;
                bln2 = true;
                cmdSaveFicheSup.Enabled = true;
                cmdDeleteFicheSup.Enabled = true;
            }
        }

        private void cmdDeleteFicheSup_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc1.DataSource != null)
                    {
                        fichesupp.Id = ((clssortie)lstFicheAdd.SelectedItem).Id;

                        fichesupp.delete(fichesupp);

                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                try
                {
                    RefreshDossier();

                    RefreshDossierFicheSupp();
                }
                catch (Exception) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboTypeFiche2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fichesupp.Id_article = Convert.ToInt32(((clsarticle)cboTypeFiche2.SelectedItem).Id);
            }
            catch (Exception) { }
        }
    }
}
