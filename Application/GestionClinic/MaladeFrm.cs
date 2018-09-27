using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class MaladeFrm : Form
    {
        public MaladeFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsmalade malade = new clsmalade();
        clspersonne personne = new clspersonne();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtNumero, cboCategorie, cboProfession, cboEtablissement, cboAireSante, cboGpSanguin, txtNumeroFiche };
            clearforbinding(tbcontrols);

            setbindingcls(txtNumero, "Numero", 0);
            setbindingcls(txtNumeroFiche, "Numero_fiche", 0);
            setbindingcls(cboCategorie, "Id_categoriemalade", 1);
            setbindingcls(cboProfession, "Id_profession", 1);
            setbindingcls(cboEtablissement, "Id_etablissement", 1);
            setbindingcls(cboAireSante, "Id_airsante", 1);
            //setbindingcls(txtPersonne, "Nom_complet", 0);
            setbindingcls(cboGpSanguin, "Id_groupesanguin", 1);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtNumero, txtPersonne, cboCategorie, cboProfession, cboEtablissement, cboAireSante, cboGpSanguin, txtNumeroFiche };
            pbPhotoPersonne.DataBindings.Clear();
            clearforbinding(tbcontrols);

            setbindinglst(txtNumero, "Numero", 0);
            setbindinglst(txtNumeroFiche, "Numero_fiche", 0);
            setbindinglst(cboCategorie, "Id_categoriemalade", 1);
            setbindinglst(cboProfession, "Id_profession", 1);
            setbindinglst(cboEtablissement, "Id_etablissement", 1);
            setbindinglst(cboAireSante, "Id_airsante", 1);
            setbindinglst(txtPersonne, "Nom_complet", 0);
            setbindinglst(cboGpSanguin, "Id_groupesanguin", 1);
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
            ((TextBox)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", malade, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", malade, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", malade, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", malade, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void New()
        {
            malade = new clsmalade();
            bln = false;
            bindingcls();

            btnAfficherDonnees.Enabled = false;
            txtNom.Clear();
            txtPNom.Clear();
            txtPrenom.Clear();
            txtTelephone.Clear();
            txtAdresse.Clear();
            txtSexe.Clear();
            txtEtatCivil.Clear();
            txtNumero.Clear();
            pbPhotoPersonne.Image = null;
            txtPersonne.Clear();
            txtAge.Clear();
            txtPersonne.Focus();

            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsmaladeDt2(-100);
                dgvMalade.DataSource = bsrc;

                if (cboCategorie.Items.Count > 0) cboCategorie.SelectedIndex = 0;
                if (cboEtablissement.Items.Count > 0) cboEtablissement.SelectedIndex = 0;
                if (cboProfession.Items.Count > 0) cboProfession.SelectedIndex = 0;
                if (cboAireSante.Items.Count > 0) cboAireSante.SelectedIndex = 0;
                if (cboGpSanguin.Items.Count > 0) cboGpSanguin.SelectedIndex = 0;
            }
            catch (Exception) { }

            RecherchePersonneFrm frm = new RecherchePersonneFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();
           
            if (clsDoTraitement.doubleclicRecherchePersonneDg)
            {
                btnSave.Enabled = true;
                clsDoTraitement.doubleclicRecherchePersonneDg = false;
                txtPersonne.Text = clsDoTraitement.FullNamePersonne;
            }
            else btnSave.Enabled = false;
        }

        private void refresh()
        {
            btnAfficherDonnees.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            txtNom.Clear();
            txtPNom.Clear();
            txtPrenom.Clear();
            txtTelephone.Clear();
            txtAdresse.Clear();
            txtSexe.Clear();
            txtEtatCivil.Clear();
            txtNumero.Clear();
            txtAge.Clear();
            pbPhotoPersonne.Image = null;
            txtPersonne.Clear();
            txtPersonne.Focus();

            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsmaladeDt(-100);
                dgvMalade.DataSource = bsrc;
            }
            catch (Exception) { }

            try
            {
                cboCategorie.DataSource = clsMetier.GetInstance().getAllClscategoriemalade();
                setMembersallcbo(cboCategorie, "Designation", "Id");
                cboProfession.DataSource = clsMetier.GetInstance().getAllClsprofession();
                setMembersallcbo(cboProfession, "Designation", "Id");
                cboEtablissement.DataSource = clsMetier.GetInstance().getAllClsetablissementpriseencharge();
                setMembersallcbo(cboEtablissement, "Denomination", "Id");
                cboAireSante.DataSource = clsMetier.GetInstance().getAllClsairsante();
                setMembersallcbo(cboAireSante, "Designation", "Id");
                cboGpSanguin.DataSource = clsMetier.GetInstance().getAllClsgroupesanguin();
                setMembersallcbo(cboGpSanguin, "Designation", "Id");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void FrmMalade_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgvMalade };
                ComboBox[] cbo = { cboProfession, cboCategorie, cboAireSante, cboGpSanguin, cboEtablissement };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg, cbo);
            }
            catch (Exception) { }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                New();
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void btnRefreh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    if (cboCategorie.Text == "Non abonné" && cboEtablissement.Text == "Privée")
                    {
                        malade.inserts();
                        MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (cboCategorie.Text == "Abonné" && cboEtablissement.Text != "Privée")
                    {
                        malade.inserts();
                        MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Un abonné ne peut pas être privé et Un non abonné ne peut pas avoir une entreprise de prise en charge. Sélectionnez Privée comme entreprise si ca n'exite pas,créez la avec cette écriture:'Privée' ", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsmalade s = new clsmalade();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("numero")) s.Numero = ((string)obj[i]);
                            else if (dtc.ToString().Equals("numero_fiche")) s.Numero_fiche = ((string)obj[i]);
                            else if (dtc.ToString().Equals("idMal")) s.Id = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_personne")) s.Id_personne = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_categoriemalade")) s.Id_categoriemalade = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_etablissement")) s.Id_etablissement = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_airsante")) s.Id_airsante = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_profession")) s.Id_profession = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_groupesanguin")) s.Id_groupesanguin = ((int)obj[i]);
                            i++;
                        }
                        if (cboCategorie.Text == "Non abonné" && cboEtablissement.Text == "Privée")
                        {
                            new clsmalade().update(s);
                            MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (cboCategorie.Text == "Abonné" && cboEtablissement.Text != "Privée")
                        {
                            new clsmalade().update(s);
                            //malade.inserts();
                            MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Un abonné ne peut pas être privé et Un non abonné ne peut pas avoir une entreprise de prise en charge. Sélectionnez Privée comme entreprise si ca n'exite pas,créez la avec cette écriture:'Privée' ", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
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
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //this.New();
            //refresh();
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
                        clsmalade s = new clsmalade();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("numero")) s.Numero = ((string)obj[i]);
                            else if (dtc.ToString().Equals("idMal")) s.Id = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_personne")) s.Id_personne = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_categoriemalade")) s.Id_categoriemalade = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_etablissement")) s.Id_etablissement = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_airsante")) s.Id_airsante = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_profession")) s.Id_profession = ((int)obj[i]);
                            else if (dtc.ToString().Equals("photo")) s.Photo = (obj[i] == DBNull.Value) ? ((Byte[])null) : ((Byte[])obj[i]);
                            i++;
                        }
                        new clsmalade().delete(s);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.New();
                        refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblAddCategorie_Click(object sender, EventArgs e)
        {
            CategorieMaladeFrm frm = new CategorieMaladeFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = this.Icon;
            frm.ShowDialog();
        }

        private void cboCategorie_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterFormCategorie)
            {
                try
                {
                    cboCategorie.DataSource = clsMetier.GetInstance().getAllClscategoriemalade();
                }
                catch (Exception) { }
            }
        }

        private void cboEtablissement_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterFormEtablissement)
            {
                try
                {
                    cboEtablissement.DataSource = clsMetier.GetInstance().getAllClsetablissementpriseencharge();
                }
                catch (Exception) { }
            }
        }

        private void lblOrganisationPriseCharge_Click(object sender, EventArgs e)
        {
            EtablissementDePriseEnchargeFrm frm = new EtablissementDePriseEnchargeFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = this.Icon;
            frm.ShowDialog();
        }

        private void lblAirSante_Click(object sender, EventArgs e)
        {
            AirSanteFrm frm = new AirSanteFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = this.Icon;
            frm.ShowDialog();
        }

        private void cboProfession_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormProfession)
            {
                try
                {
                    cboProfession.DataSource = clsMetier.GetInstance().getAllClsprofession();
                }
                catch (Exception) { }
            }
        }

        private void cboAireSante_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterFormAireSante)
            {
                try
                {
                    cboAireSante.DataSource = clsMetier.GetInstance().getAllClsairsante();
                }
                catch (Exception) { }
            }
        }

        private void lblAddProfession_Click(object sender, EventArgs e)
        {
            ProfessionFrm frm = new ProfessionFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = this.Icon;
            frm.ShowDialog();
        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bsrc.Filter = "Numero LIKE '%" + txtSeach.Text + "%' OR Nom LIKE '%" + txtSeach.Text + "%'";
            }
            catch { }
        }

        private void FrmMalade_Load(object sender, EventArgs e)
        {
            btnAfficherDonnees.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            bindingcls();
            dgvMalade.DataSource = bsrc;

            if (cboCategorie.Items.Count > 0) cboCategorie.SelectedIndex = 0;
            if (cboProfession.Items.Count > 0) cboProfession.SelectedIndex = 0;
            if (cboEtablissement.Items.Count > 0) cboEtablissement.SelectedIndex = 0;
            if (cboAireSante.Items.Count > 0) cboAireSante.SelectedIndex = 0;
            txtNumero.Enabled = false;

            try
            {
                cboCategorie.DataSource = clsMetier.GetInstance().getAllClscategoriemalade();
                setMembersallcbo(cboCategorie, "Designation", "Id");
                cboProfession.DataSource = clsMetier.GetInstance().getAllClsprofession();
                setMembersallcbo(cboProfession, "Designation", "Id");
                cboEtablissement.DataSource = clsMetier.GetInstance().getAllClsetablissementpriseencharge();
                setMembersallcbo(cboEtablissement, "Denomination", "Id");
                cboAireSante.DataSource = clsMetier.GetInstance().getAllClsairsante();
                setMembersallcbo(cboAireSante, "Designation", "Id");
                cboGpSanguin.DataSource = clsMetier.GetInstance().getAllClsgroupesanguin();
                setMembersallcbo(cboGpSanguin, "Designation", "Id");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors du chargement des listes déroulante", "Chargement des listes déroulante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                clsDoTraitement.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
            catch { }
        }

        private void loadData()
        {
            bsrc.DataSource = clsMetier.GetInstance().getAllClsmaladeDt(clsDoTraitement.IdMalade);

            try
            {
                personne = clsMetier.GetInstance().getClspersonne(clsDoTraitement.Identifiant_Personne);

                txtIdPers.Text = personne.IdPers.ToString();
                txtNom.Text = personne.Nom;
                txtPNom.Text = personne.Postnom;
                txtPrenom.Text = personne.Prenom;
                txtSexe.Text = personne.Sexe;
                txtTelephone.Text = personne.Telephone;
                txtDateNaissance.Text = personne.Datenaissance.ToString();
                txtEtatCivil.Text = personne.Etatcivil;
                txtAdresse.Text = personne.Adresse;
                txtAge.Text = personne.AgePers.ToString();

                txtPersonne.Text = personne.Nom + " " + (string.IsNullOrEmpty(personne.Postnom) ? "" : personne.Postnom) + " " + (string.IsNullOrEmpty(personne.Prenom) ? "" : personne.Prenom);

                try
                {
                    if (personne.Photo != null) pbPhotoPersonne.Image = (new clsDoTraitement()).getImageFromByte(personne.Photo);
                    else pbPhotoPersonne.Image = null;
                }
                catch (Exception) { pbPhotoPersonne.Image = null; }

                bindignlst();
                bln = true;
            }
            catch (Exception) { }
        }

        private void lblAddPersonne_Click(object sender, EventArgs e)
        {
            PersonneFrm frm = new PersonneFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();
        }

        private void lblGpSanguin_Click(object sender, EventArgs e)
        {
            GroupeSanguinFrm frm = new GroupeSanguinFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = this.Icon;
            frm.ShowDialog();
        }

        private void cboGpSanguin_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormGroupesanguin)
            {
                try
                {
                    cboGpSanguin.DataSource = clsMetier.GetInstance().getAllClsgroupesanguin();
                }
                catch (Exception) { }
            }
        }

        private void cboCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboCategorie.Text.Equals("Non abonné"))
                {
                    int nbrItem = cboEtablissement.Items.Count;
                    foreach (clsetablissementpriseencharge str in cboEtablissement.Items)
                    {
                        if (str.Denomination.Equals("Privée"))
                        {
                            cboEtablissement.Text = "Privée";
                            cboEtablissement.Enabled = false;
                            break;
                        }
                        else if (!str.Denomination.Equals("Privée")) nbrItem--;
                    }
                    if (nbrItem == 0) MessageBox.Show("Vous n'avez pas ajouté comme entréprise de prise en charge 'Privée' car vous avez choisi un non abonné", "Entreprise pour non Abonné", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cboEtablissement.Enabled = true;
                }
            }
            catch (Exception) { }

            try
            {
                txtPersonne.Text = clsDoTraitement.FullNamePersonne;
            }
            catch (Exception) { }
        }

        private void txtPersonne_DoubleClick(object sender, EventArgs e)
        {
            RecherchePersonneMaladeFrm frm = new RecherchePersonneMaladeFrm();
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

        private void btnAfficherDonnees_Click(object sender, EventArgs e)
        {
            try
            {
                loadData();
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                clsDoTraitement.doubleclicRecherchePersonneMaladeDg = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des informations du malade sélectionné =>" + ex.Message, "Affichage informations malade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
