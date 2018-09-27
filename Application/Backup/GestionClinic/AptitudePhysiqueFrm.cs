using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class FrmAptitudePhysique : Form
    {
        public FrmAptitudePhysique()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsaptitudephysique aptitude = new clsaptitudephysique();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { cboProvince, txtIndicePigment, cboDistrictVille, cboTerritoireCommune, cboCollectiviteQuartier, txtAge1, txtPoids, txtPerimetre, txtQuotient, txtTaille, txtRemarque, txtDate };
            clearforbinding(tbcontrols);

            setbindingcls(txtRemarque, "Remarque", 0);
            setbindingcls(cboProvince, "Id_province", 1);
            setbindingcls(cboDistrictVille, "Id_districtville", 1);
            setbindingcls(cboTerritoireCommune, "Id_territoirecommune", 1);
            setbindingcls(cboCollectiviteQuartier, "Id_collectivitequartier", 1);
            //setbindingcls(txtPersonne, "Nom_complet", 0);
            setbindingcls(txtAge1, "Age", 0);
            setbindingcls(txtTaille, "Taille", 0);
            setbindingcls(txtPoids, "Poid", 0);
            setbindingcls(txtIndicePigment, "Indicepigment", 0);
            setbindingcls(txtPerimetre, "Perimetrethoracique", 0);
            setbindingcls(txtQuotient, "Quotientvervaeck", 0);
            setbindingcls(txtDate, "Dateexamen", 0);
            txtAge1.Text = txtAge.Text;
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = {  cboProvince,txtPersonne, txtIndicePigment, cboDistrictVille, cboTerritoireCommune, cboCollectiviteQuartier, txtAge1, txtPoids, txtPerimetre, txtQuotient, txtTaille, txtRemarque, txtDate };
            pbPhotoPersonne.DataBindings.Clear();
            clearforbinding(tbcontrols);

            setbindinglst(txtRemarque, "Remarque", 0);
            setbindinglst(cboProvince, "Id_province", 1);
            setbindinglst(cboDistrictVille, "Id_districtville", 1);
            setbindinglst(cboTerritoireCommune, "Id_territoirecommune", 1);
            setbindinglst(cboCollectiviteQuartier, "Id_collectivitequartier", 1);
            setbindinglst(txtPersonne, "Nom_complet", 0);
            setbindinglst(txtAge1, "Age", 0);
            setbindinglst(txtTaille, "Taille", 0);
            setbindinglst(txtPoids, "Poid", 0);
            setbindinglst(txtIndicePigment, "Indicepigment", 0);
            setbindinglst(txtPerimetre, "Perimetrethoracique", 0);
            setbindinglst(txtQuotient, "Quotientvervaeck", 0);
            setbindinglst(txtDate, "Dateexamen", 0);

            //Recupération des valeurs permettant l'affichage du certificat d'aptitude physique
            clsDoTraitement.id_personne_certificat = clsDoTraitement.Identifiant_Personne;
            clsDoTraitement.dateCerticifat = Convert.ToDateTime(txtDate.Text);
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
            ((ComboBox)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", aptitude, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", aptitude, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", aptitude, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", aptitude, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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
            aptitude = new clsaptitudephysique();
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
            pbPhotoPersonne.Image = null;
            txtPersonne.Clear();
            txtAge.Clear();
            txtPersonne.Focus();

            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsaptitudephysiqueDt(-100);
                dgv.DataSource = bsrc;

                if (cboProvince.Items.Count > 0) cboProvince.SelectedIndex = 0;
                if (cboTerritoireCommune.Items.Count > 0) cboTerritoireCommune.SelectedIndex = 0;
                if (cboDistrictVille.Items.Count > 0) cboDistrictVille.SelectedIndex = 0;
                if (cboCollectiviteQuartier.Items.Count > 0) cboCollectiviteQuartier.SelectedIndex = 0;
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
            txtAge.Clear();
            pbPhotoPersonne.Image = null;
            txtPersonne.Clear();
            txtPersonne.Focus();

            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsaptitudephysiqueDt(-100);
                dgv.DataSource = bsrc;
            }
            catch (Exception) { }

            try
            {
                cboProvince.DataSource = clsMetier.GetInstance().getAllClsprovince();
                setMembersallcbo(cboProvince, "Designation", "Id");
                cboDistrictVille.DataSource = clsMetier.GetInstance().getAllClsdistrictville();
                setMembersallcbo(cboDistrictVille, "Designation", "Id");
                cboTerritoireCommune.DataSource = clsMetier.GetInstance().getAllClsterritoirecommune();
                setMembersallcbo(cboTerritoireCommune, "Designation", "Id");
                cboCollectiviteQuartier.DataSource = clsMetier.GetInstance().getAllClscollectivitequartier();
                setMembersallcbo(cboCollectiviteQuartier, "Designation", "Id");
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

        private void FrmAptitudePhysique_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgv };
                ComboBox[] cbo = { cboProvince, cboCollectiviteQuartier, cboDistrictVille, cboTerritoireCommune };
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
                    aptitude.inserts();
                    cmdAfficherFiche.Enabled = true;
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsaptitudephysique s = new clsaptitudephysique();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("remarque")) s.Remarque = ((string)obj[i]);
                            else if (dtc.ToString().Equals("idApt")) s.Id = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_personne")) s.Id_personne = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_province")) s.Id_province = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_districtville")) s.Id_districtville = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_territoirecommune")) s.Id_territoirecommune = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_collectivitequartier")) s.Id_collectivitequartier = ((int)obj[i]);
                            else if (dtc.ToString().Equals("age")) s.AgePers = ((int)obj[i]);
                            else if (dtc.ToString().Equals("taille")) s.Taille = ((double)obj[i]);
                            else if (dtc.ToString().Equals("poid")) s.Poid = ((double)obj[i]);
                            else if (dtc.ToString().Equals("indicepigment")) s.Indicepigment = ((double)obj[i]);
                            else if (dtc.ToString().Equals("perimetrethoracique")) s.Perimetrethoracique = ((double)obj[i]);
                            else if (dtc.ToString().Equals("quotientvervaeck")) s.Quotientvervaeck = ((double)obj[i]);
                            else if (dtc.ToString().Equals("dateexamen")) s.Dateexamen = ((DateTime)obj[i]);
                            if (dtc.ToString().Equals("remarque")) s.Remarque = ((string)obj[i]);
                            i++;
                        }

                        new clsaptitudephysique().update(s);
                        cmdAfficherFiche.Enabled = true;
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                try
                {
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des informations de la personne sélectionnée =>" + ex.Message, "Affichage informations malade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        clsaptitudephysique s = new clsaptitudephysique();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("remarque")) s.Remarque = ((string)obj[i]);
                            else if (dtc.ToString().Equals("idApt")) s.Id = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_personne")) s.Id_personne = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_province")) s.Id_province = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_districtville")) s.Id_districtville = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_territoirecommune")) s.Id_territoirecommune = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_collectivitequartier")) s.Id_collectivitequartier = ((int)obj[i]);
                            else if (dtc.ToString().Equals("age")) s.AgePers = ((int)obj[i]);
                            else if (dtc.ToString().Equals("taille")) s.Taille = ((double)obj[i]);
                            else if (dtc.ToString().Equals("poid")) s.Poid = ((double)obj[i]);
                            else if (dtc.ToString().Equals("indicepigment")) s.Indicepigment = ((double)obj[i]);
                            else if (dtc.ToString().Equals("perimetrethoracique")) s.Perimetrethoracique = ((double)obj[i]);
                            else if (dtc.ToString().Equals("quotientvervaeck")) s.Quotientvervaeck = ((double)obj[i]);
                            else if (dtc.ToString().Equals("dateexamen")) s.Dateexamen = ((DateTime)obj[i]);
                            if (dtc.ToString().Equals("remarque")) s.Remarque = ((string)obj[i]);
                            else if (dtc.ToString().Equals("photo")) s.Photo = (obj[i] == DBNull.Value) ? ((Byte[])null) : ((Byte[])obj[i]);
                            i++;
                        }
                        new clsaptitudephysique().delete(s);
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

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bsrc.Filter = "Remarque LIKE '%" + txtSeach.Text + "%'";
            }
            catch { }
        }

        private void lblAddPersonne_Click(object sender, EventArgs e)
        {
            PersonneFrm frm = new PersonneFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();
        }

        private void cboProvince_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterFormProvince)
            {
                try
                {
                    cboProvince.DataSource = clsMetier.GetInstance().getAllClsprovince();
                }
                catch (Exception) { }
            }
        }

        private void cboCollectiviteQuartier_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterFormCollectivitequartier)
            {
                try
                {
                    cboCollectiviteQuartier.DataSource = clsMetier.GetInstance().getAllClscollectivitequartier();
                }
                catch (Exception) { }
            }
        }

        private void cboProvince_MouseDown(object sender, MouseEventArgs e)
        {
            if (clsDoTraitement.EnterFormDistrictville)
            {
                try
                {
                    cboDistrictVille.DataSource = clsMetier.GetInstance().getAllClsdistrictville();
                }
                catch (Exception) { }
            }
        }

        private void cboTerritoireCommune_MouseDown(object sender, MouseEventArgs e)
        {
            if (clsDoTraitement.EnterFormTerritoirecommune)
            {
                try
                {
                    cboTerritoireCommune.DataSource = clsMetier.GetInstance().getAllClsterritoirecommune();
                }
                catch (Exception) { }
            }
        }

        private void lblAddProvince_Click(object sender, EventArgs e)
        {
            ProvinceFrm frm = new ProvinceFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();
        }

        private void lblAddDistrictVille_Click(object sender, EventArgs e)
        {
            DistrictvilleFrm frm = new DistrictvilleFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();
        }

        private void lblAddTerritoireCommune_Click(object sender, EventArgs e)
        {
            TerritoirecommuneFrm frm = new TerritoirecommuneFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();
        }

        private void lblAddCollectiviteQuartier_Click(object sender, EventArgs e)
        {
            CollectivitequartierFrm frm = new CollectivitequartierFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();
        }

        private void FrmAptitudePhysique_Load(object sender, EventArgs e)
        {
            btnAfficherDonnees.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            bindingcls();
            dgv.DataSource = bsrc;

            if (cboProvince.Items.Count > 0) cboProvince.SelectedIndex = 0;
            if (cboDistrictVille.Items.Count > 0) cboDistrictVille.SelectedIndex = 0;
            if (cboTerritoireCommune.Items.Count > 0) cboTerritoireCommune.SelectedIndex = 0;
            if (cboCollectiviteQuartier.Items.Count > 0) cboCollectiviteQuartier.SelectedIndex = 0;

            cmdAfficherFiche.Enabled = false;

            try
            {
                cboProvince.DataSource = clsMetier.GetInstance().getAllClsprovince();
                setMembersallcbo(cboProvince, "Designation", "Id");
                cboDistrictVille.DataSource = clsMetier.GetInstance().getAllClsdistrictville();
                setMembersallcbo(cboDistrictVille, "Designation", "Id");
                cboTerritoireCommune.DataSource = clsMetier.GetInstance().getAllClsterritoirecommune();
                setMembersallcbo(cboTerritoireCommune, "Designation", "Id");
                cboCollectiviteQuartier.DataSource = clsMetier.GetInstance().getAllClscollectivitequartier();
                setMembersallcbo(cboCollectiviteQuartier, "Designation", "Id");
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

        private void cmdAfficherFiche_Click(object sender, EventArgs e)
        {
            RptAptitudePhysiqueFrm frm = new RptAptitudePhysiqueFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = this.Icon;
            frm.ShowDialog();
        }

        private void txtPersonne_DoubleClick(object sender, EventArgs e)
        {
            RecherchePersonneFrm frm = new RecherchePersonneFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();

            if (clsDoTraitement.doubleclicRecherchePersonneDg)
            {
                btnAfficherDonnees.Enabled = true;
                clsDoTraitement.doubleclicRecherchePersonneDg = false;
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
                clsDoTraitement.doubleclicRecherchePersonneDg = false;
                cmdAfficherFiche.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des informations du malade sélectionné =>" + ex.Message, "Affichage informations malade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void loadData()
        {
            bsrc.DataSource = clsMetier.GetInstance().getAllClsaptitudephysiqueDt(clsDoTraitement.Identifiant_Personne);

            try
            {
                clspersonne personne = new clspersonne();

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
                txtAge1.Text = personne.AgePers.ToString();

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
    }
}
