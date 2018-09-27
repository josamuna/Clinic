using System;
using System.Drawing;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class AvanceFrm : Form
    {
        public AvanceFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsmalade_avance mal_avance = new clsmalade_avance();
        private BindingSource bsrc = new BindingSource();
        clsmalade personne = new clsmalade();
        double cumul_avance = 0;
        //DateTime dateRecuperee;

        //Dossier Avance
        clsdossieravance a = new clsdossieravance();
        clsdossieravance dossierAvance = new clsdossieravance();
        private BindingSource bsrc3 = new BindingSource();
        private bool bln = false;
        short okDropDownCboTarif = 0;

        private void setMembersalllst(ListBox lst, string displayMember, string valueMember)
        {
            lst.DisplayMember = displayMember;
            lst.ValueMember = valueMember;
        }

        #region avance

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
            ((TextBox)ctrl[0]).Focus();
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtMontant, txtDate, txtIdMalade, txtIdAvance, txtSolde, txtId_dossieravance };
            clearforbinding(tbcontrols);

            //setbindinglst(txtAvance, "Avance", 0);
            setbindinglst(txtMontant, "Montant", 0);
            setbindinglst(txtDate, "Date", 0);
            setbindinglst(txtIdMalade, "Id_malade", 0);
            setbindinglst(txtIdAvance, "Id", 0);
            setbindinglst(txtSolde, "Solde", 0);
            setbindinglst(txtId_dossieravance, "Id_dossieravance", 0);
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bsrc.Filter = "Date LIKE '%" + txtSeach.Text + "%'";
            }
            catch { }
        }

        #endregion

        #region Dossier avance
        private void NewDossier()
        {
            dossierAvance = new clsdossieravance();
            bln = false;
            bindingclsdossier();
            txtIdMalade.Text = personne.Id.ToString();
        }

        private void setbindingclsDossier(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", dossierAvance, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", dossierAvance, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", dossierAvance, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", dossierAvance, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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
            Control[] tbcontrols = { txtDateOuvertureDossier, txtIdMalade, txtEtatPaiement, cboTypeAvance };
            clearforbindingDossier(tbcontrols);
            setbindingclsDossier(txtIdMalade, "Id_malade", 0);
            setbindingclsDossier(txtDateOuvertureDossier, "Date", 0);
            setbindingclsDossier(txtEtatPaiement, "Etatpaiement", 0);
            setbindingclsDossier(cboTypeAvance, "Id_tarifavance", 1);
        }

        private void RefreshDossier()
        {
            try
            {
                okDropDownCboTarif = 2;
                //bsrc3.DataSource = clsMetier.GetInstance().getAllClsdossieravance();
                lstDossierEncCours.DataSource = bsrc3;
                bsrc3.DataSource = clsMetier.GetInstance().getAllClsdossieravance1(clsDoTraitement.IdMalade);

                //Avance
                cboTypeAvance.DataSource = clsMetier.GetInstance().getAllClstarifavance();
                setMembersallcbo(cboTypeAvance, "Designation", "Id");
                bsrc.DataSource = clsMetier.GetInstance().getAllClsmalade_avance1(personne.Id);
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation des dossiers", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void setbindinglstDossier(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc3, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc3, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc3, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc3, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindinglstDossier()
        {
            Control[] tbcontrols = { txtDateOuvertureDossier, txtEtatPaiement, txtIdMalade, cboTypeAvance };
            clearforbindingDossier(tbcontrols);

            setbindinglstDossier(txtDateOuvertureDossier, "Date", 0);
            setbindinglstDossier(txtEtatPaiement, "Etatpaiement", 0);
            setbindinglstDossier(cboTypeAvance, "Id_tarifavance", 1);
            setbindinglstDossier(txtIdMalade, "Id_malade", 0);
        }

        private void lstDossierEncCours_SelectedIndexChanged(object sender, EventArgs e)
        {
            //okDropDownCboTarif = true;
            if (lstDossierEncCours.SelectedItems.Count > 0)
            {
                bindinglstDossier();
                bln = true;

                try
                {
                    dossierAvance.Id = ((clsdossieravance)lstDossierEncCours.SelectedItem).Id;
                    cboTypeAvance.Text = clsMetier.GetInstance().getClstarifavance(((clsdossieravance)lstDossierEncCours.SelectedItem).Id_tarifavance).Designation;
                    txtDateOuvertureDossier.Text = ((clsdossieravance)lstDossierEncCours.SelectedItem).Date.ToString();
                }
                catch (Exception) { }
            }
        }
        #endregion

        private void FrmAvance_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc, bsrc3 };
                DataGridView[] dg = { dgvAvance };
                ComboBox[] cbo = { cboTypeAvance };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg, cbo);
            }
            catch (Exception) { }
        }

        private void FrmAvance_Load(object sender, EventArgs e)
        {
            //txtIdMalade.Visible = false;
            btnAfficherDonnees.Enabled = false;
            txtDate.Enabled = false;
            txtMontant.Enabled = false;

            try
            {
                //bindingcls();
                bindingclsdossier();
                //RefreshDossier();

                cboTypeAvance.DataSource = clsMetier.GetInstance().getAllClstarifavance();
                setMembersallcbo(cboTypeAvance, "Designation", "Id");
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void dgvAvance_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvAvance.SelectedRows.Count > 0)
                {
                    okDropDownCboTarif = 2;
                    bindignlst();
                    clsDoTraitement.intIdDossierAvance = string.IsNullOrEmpty(txtId_dossieravance.Text) ? 0 : Convert.ToInt32(txtId_dossieravance.Text);
                    //btnSave.Enabled = true;
                    //bln1 = true;
                    try
                    {
                        txtMaxCumul.Text = clsMetier.GetInstance().getClsmalade_avanceMontantCumulMax(personne.Id).ToString();
                    }
                    catch (Exception) { }

                    //Chargement des dossiers pour l'avance sélectiionnée suivant le malade choisi et la date
                    //try
                    //{
                    //lstDossierEncCours.DataSource = bsrc3;
                    //    bsrc3.DataSource = clsMetier.GetInstance().getAllClsdossieravance3(personne.Id, (DateTime)((clsdossieravance)bsrc3.Current).Date);
                    //    //dateRecuperee = Convert.ToDateTime(txtDateOuvertureDossier.Text);
                    //    //txtDate.Text = dateRecuperee.ToString();
                    //}
                    //catch (Exception) { }
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void cboTypeAvance_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (okDropDownCboTarif > 1) txtAvance.Text = clsMetier.GetInstance().getClstarifavance(((clstarifavance)cboTypeAvance.SelectedItem).Id).Montant.ToString();
            }
            catch (Exception) { }
        }

        private void lstDossierEncCours_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dgvAvance.SelectedRows.Count > 0) okDropDownCboTarif++;
        }

        private void txtPersonne_DoubleClick(object sender, EventArgs e)
        {
            RecherchePersonneMaladeNonAbonneFrm frm = new RecherchePersonneMaladeNonAbonneFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();

            if (clsDoTraitement.doubleclicRecherchePersonneMaladeDg)
            {
                btnAfficherDonnees.Enabled = true;
                clsDoTraitement.doubleclicRecherchePersonneMaladeDg = false;
            }
            else btnAfficherDonnees.Enabled = false;
        }

        private void loadData()
        {
            //bsrc.DataSource = clsMetier.GetInstance().getAllClsmaladeDt(clsDoTraitement.IdMalade);

            try
            {
                personne = clsMetier.GetInstance().getClsmalade(clsDoTraitement.IdMalade);
                a = clsMetier.GetInstance().getClsdossieravance(clsDoTraitement.IdMalade);
                personne.Id = clsDoTraitement.IdMalade;
                bsrc.DataSource = clsMetier.GetInstance().getAllClsmalade_avance1(personne.Id);

                dgvAvance.DataSource = bsrc;
                txtNom.Text = personne.Nom;
                txtPNom.Text = personne.Postnom;
                txtPrenom.Text = personne.Prenom;
                txtSexe.Text = personne.Sexe;
                txtTelephone.Text = personne.Telephone;
                txtDateNaissance.Text = personne.Datenaissance.ToString();
                txtEtatCivil.Text = personne.Etatcivil;
                txtNumero.Text = personne.Numero;
                txtIdMalade.Text = personne.Id.ToString();
                string pnom = string.IsNullOrEmpty(personne.Postnom) ? "" : " " + personne.Postnom;
                string prenom = string.IsNullOrEmpty(personne.Prenom) ? "" : " " + personne.Prenom;
                string nom_complet = personne.Nom + pnom + prenom;

                txtPersonne.Text = nom_complet;

                txtProfession.Text = clsMetier.GetInstance().getClsprofession(personne.Id_profession.ToString()).Designation;
                txtEntreprise.Text = clsMetier.GetInstance().getClsetablissementpriseencharge(Convert.ToInt32(personne.Id)).Denomination;
                txtAirSante.Text = clsMetier.GetInstance().getClsairsante(personne.Id_airsante.ToString()).Designation;
                try
                {
                    if (personne.Photo != null) pbPhotoPersonne.Image = (new clsDoTraitement()).getImageFromByte(personne.Photo);
                    else pbPhotoPersonne.Image = null;
                }
                catch (Exception) { pbPhotoPersonne.Image = null; }

                bindignlst();
                bln = true;

                try
                {
                    ////Recupération du cumul actuel de l'avance du malade sélectionné
                    cumul_avance = clsMetier.GetInstance().getClsmalade_avanceMontantCumul(personne.Id);
                    txtCumulMontant.Text = cumul_avance.ToString();
                }
                catch (Exception) { }

                RefreshDossier();
            }
            catch (Exception) { }
        }

        private void btnAfficherDonnees_Click(object sender, EventArgs e)
        {
            try
            {
                loadData();
                //btnSave.Enabled = true;
                btnDelete.Enabled = true;
                clsDoTraitement.doubleclicRecherchePersonneMaladeDg = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des informations du malade sélectionné =>" + ex.Message, "Affichage informations malade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvAvance_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                lstDossierEncCours.DataSource = bsrc3;
                bsrc3.DataSource = clsMetier.GetInstance().getAllClsdossieravance3(personne.Id, Convert.ToDateTime(dgvAvance["ColDate", dgvAvance.CurrentRow.Index].Value.ToString()));
                //bsrc3.DataSource = clsMetier.GetInstance().getAllClsdossieravance3(personne.Id, (DateTime)((clsdossieravance)bsrc3.Current).Date);
                //dateRecuperee = Convert.ToDateTime(txtDateOuvertureDossier.Text);clsMetier.GetInstance().getClscategoriemalade1(clsDoTraitement.IdMalade).Designation
                //txtDate.Text = dateRecuperee.ToString();
            }
            catch (Exception) { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc3.DataSource != null)
                    {
                        clsdossieravance p = (clsdossieravance)bsrc3.Current;
                        new clsdossieravance().delete(p);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.NewDossier();
                        RefreshDossier();
                    }

                    try
                    {
                        //Recupération du cumul actuel de l'avance du malade sélectionné
                        cumul_avance = clsMetier.GetInstance().getClsmalade_avanceMontantCumul(personne.Id);
                        txtCumulMontant.Text = cumul_avance.ToString();
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSaveDossier_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    clsDoTraitement.dblMontant = Convert.ToInt32(txtAvance.Text) + Convert.ToInt32(txtCumulMontant.Text);
                    clsDoTraitement.dblAvance = Convert.ToDouble(txtAvance.Text);

                    dossierAvance.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clsDoTraitement.dblMontant = 0;
                    clsDoTraitement.dblAvance = 0;
                }
                else
                {
                    if (bsrc3.DataSource != null)
                    {
                        clsDoTraitement.dblAvance = Convert.ToDouble(txtAvance.Text);
                        clsDoTraitement.intIdAvance = Convert.ToInt32(txtIdAvance.Text);
                        clsdossieravance d = (clsdossieravance)bsrc3.Current;
                        new clsdossieravance().update(d);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        clsDoTraitement.dblMontant = 0;
                        clsDoTraitement.dblAvance = 0;
                    }
                }

                try
                {
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des informations du malade sélectionné =>" + ex.Message, "Affichage informations malade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //RefreshDossier();
        }

        private void btnAddDossier_Click(object sender, EventArgs e)
        {
            //Dossier
            try
            {
                NewDossier();
                txtEtatPaiement.Text = "Non cloturé payé";

                //Avance
                //Recupération du cumul actuel de l'avance du malade sélectionné
                cumul_avance = clsMetier.GetInstance().getClsmalade_avanceMontantCumul(personne.Id);
                txtCumulMontant.Text = cumul_avance.ToString();
                txtAvance.Clear();
            }
            catch (Exception) { btnSaveDossier.Enabled = false; }
        }

        private void btnRefreshDossier_Click(object sender, EventArgs e)
        {
            RefreshDossier();
        }
    }
}
