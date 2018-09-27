using System;
using System.Drawing;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class PreconsultationFrm : Form
    {
        public PreconsultationFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clspreconsultation preconsult = new clspreconsultation();
        private BindingSource bsrc = new BindingSource();
        clsmalade personne = new clsmalade();

        //Dossier de Preconsultation
        clsdossierpreconsultation d = new clsdossierpreconsultation();
        clsdossierpreconsultation dossierPreconsultation = new clsdossierpreconsultation();
        private BindingSource bsrc3 = new BindingSource();
        private bool bln = false, bln1 = false;
        //min: 1037; 459; max: 1037; 663

        private void setMembersalllst(ListBox lst, string displayMember, string valueMember)
        {
            lst.DisplayMember = displayMember;
            lst.ValueMember = valueMember;
        }

        #region consultation
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
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", preconsult, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", preconsult, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", preconsult, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", preconsult, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtPoids, txtTemperature, txtPressionArt, txtTaille, txtPouls, txtDatePreconsultation, txtObservation, txtidDossier };
            clearforbinding(tbcontrols);

            setbindingcls(txtPoids, "Poid", 0);
            setbindingcls(txtTemperature, "Temperature", 0);
            setbindingcls(txtPressionArt, "Pressionarterielle", 0);
            setbindingcls(txtTaille, "Taille", 0);
            setbindingcls(txtPouls, "Pouls", 0);
            setbindingcls(txtDatePreconsultation, "Dateprecons", 0);
            setbindingcls(txtObservation, "Observation", 0);
            setbindingcls(txtidDossier, "Id_dossierpreconsultation", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtPoids, txtTemperature, txtPressionArt, txtTaille, txtPouls, txtDatePreconsultation, txtObservation, txtidDossier };
            clearforbinding(tbcontrols);

            setbindinglst(txtPoids, "Poid", 0);
            setbindinglst(txtTemperature, "Temperature", 0);
            setbindinglst(txtPressionArt, "Pressionarterielle", 0);
            setbindinglst(txtTaille, "Taille", 0);
            setbindinglst(txtPouls, "Pouls", 0);
            setbindinglst(txtDatePreconsultation, "Dateprecons", 0);
            setbindinglst(txtObservation, "Observation", 0);
            setbindinglst(txtidDossier, "Id_dossierpreconsultation", 0);
        }

        private void New()
        {
            preconsult = new clspreconsultation();
            bln1 = false;
            bindingcls();
            txtidDossier.Text = dossierPreconsultation.Id.ToString();
            txtObservation.Text = "RAS";
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void refresh()
        {
            try
            {
                cboTypeFiche.DataSource = clsMetier.GetInstance().getAllClstarifpreconsultation();
                setMembersallcbo(cboTypeFiche, "Designation", "Id");
                bsrc.DataSource = clsMetier.GetInstance().getAllClspreconsultation1(dossierPreconsultation.Id);
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region Dossier consultation
        private void NewDossier()
        {
            dossierPreconsultation = new clsdossierpreconsultation();
            bln = false;
            bindingclsdossier();
            txtIdMalade.Text = personne.Id.ToString();
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
            Control[] tbcontrols = { txtDateOuvertureDossier, txtIdMalade, txtEtatPaiement, cboTypeFiche };
            clearforbindingDossier(tbcontrols);
            setbindingclsDossier(txtIdMalade, "Id_malade", 0);
            setbindingclsDossier(txtDateOuvertureDossier, "Date", 0);
            setbindingclsDossier(txtEtatPaiement, "Etatpaiement", 0);
            setbindingclsDossier(cboTypeFiche, "Id_tarifpreconsultation", 1);
        }

        private void RefreshDossier()
        {
            try
            {
                bsrc3.DataSource = clsMetier.GetInstance().getAllClsdossierpreconsultation();
                loadData();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            Control[] tbcontrols = { txtDateOuvertureDossier, txtEtatPaiement, txtIdMalade, cboTypeFiche };
            clearforbindingDossier(tbcontrols);

            setbindinglstDossier(txtDateOuvertureDossier, "Date", 0);
            setbindinglstDossier(txtEtatPaiement, "Etatpaiement", 0);
            setbindinglstDossier(cboTypeFiche, "Id_tarifpreconsultation", 1);
            //setbindinglstDossier(cboMalade, "Id_malade", 1);
        }
        #endregion  

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                New();
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void btnRefreshDossier_Click(object sender, EventArgs e)
        {
            RefreshDossier();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void FrmPreconsultation_Load(object sender, EventArgs e)
        {
            txtIdMalade.Visible = false;
            txtidDossier.Visible = false;
            txtMalade.Focus();

            try
            {
                bindingclsdossier();
                RefreshDossier();

                cboTypeFiche.DataSource = clsMetier.GetInstance().getAllClstarifpreconsultation();
                setMembersallcbo(cboTypeFiche, "Designation", "Id");
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            //this.Height = 459;
            if (bdNav.Enabled == false) grpDossier.Enabled = false;
        }

        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bsrc.Filter = "Observation LIKE '%" + txtSeach.Text + "%'";
            }
            catch { }
        }

        private void dgvPreconsultation_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvPreconsultation.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln1 = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(txtDatePreconsultation.Text) < Convert.ToDateTime(txtDateOuvertureDossier.Text)) throw new Exception("La date de préconsultation ne peut être inférieure à celle de la création du dossier de préconsultation");
                else
                {
                    if (!bln1)
                    {
                        preconsult.inserts();

                        MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        if (bsrc.DataSource != null)
                        {
                            clspreconsultation p = (clspreconsultation)bsrc.Current;
                            new clspreconsultation().update(p);
                            MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            refresh();
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
                        clspreconsultation p = (clspreconsultation)bsrc.Current;
                        new clspreconsultation().delete(p);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAddDossier_Click(object sender, EventArgs e)
        {
            try
            {

                NewDossier();
                //MessageBox.Show(dossierPreconsultation.Id.ToString());
                txtEtatPaiement.Text = "Fiche non payée";
            }
            catch (Exception) { btnSaveDossier.Enabled = false; }
        }

        private void btnSaveDossier_Click(object sender, EventArgs e)
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
                    if (bsrc3.DataSource != null)
                    {
                        clsdossierpreconsultation d = (clsdossierpreconsultation)bsrc3.Current;
                        new clsdossierpreconsultation().update(d);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            RefreshDossier();
        }

        private void lstDossierEncCours_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDossierEncCours.SelectedItems.Count > 0)
            {
                dossierPreconsultation.Id = ((clsdossierpreconsultation)lstDossierEncCours.SelectedItem).Id;
                dgvPreconsultation.DataSource = bsrc;
                refresh();
            }
        }

        private void txtTemperature_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtTemperature.Text) == 25)
                {
                    //Rouge fort
                    //Température minimale du corps humain
                    ((Control)txtTemperature).BackColor = Color.FromArgb(255, 0, 0);
                }
                else if (Convert.ToDouble(txtTemperature.Text) == 42)
                {
                    //Rouge fort
                    //Température maximale du corps humain
                    ((Control)txtTemperature).BackColor = Color.FromArgb(255, 0, 0);
                }
                else if (Convert.ToDouble(txtTemperature.Text) > 25 && Convert.ToDouble(txtTemperature.Text) < 36.1)
                {
                    //Champ en rouge faible
                    //Températures normales du corps humain
                    ((Control)txtTemperature).BackColor = Color.FromArgb(252, 165, 158);
                }
                else if (Convert.ToDouble(txtTemperature.Text) >= 36.1 && Convert.ToDouble(txtTemperature.Text) <= 37.8)
                {
                    //Champ en vert
                    //Températures normales du corps humain
                    ((Control)txtTemperature).BackColor = Color.FromArgb(194, 214, 155);
                }
                else if (Convert.ToDouble(txtTemperature.Text) > 37.8 && Convert.ToDouble(txtTemperature.Text) < 42)
                {
                    //Champ en rouge faible
                    //Températures normales du corps humain
                    ((Control)txtTemperature).BackColor = Color.FromArgb(252, 165, 158);
                }
                else ((Control)txtTemperature).BackColor = Color.FromArgb(150, 148, 152);
            }
            catch (Exception) { }
        }

        private void txtTemperature_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtTemperature.Text) < 25)
                {
                    //Température extra-minimale du corps humain
                    MessageBox.Show("T° invalide et extrême inférieure", "T° invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTemperature.Focus();
                }
                else if (Convert.ToDouble(txtTemperature.Text) > 42)
                {
                    //Température extra-minimale du corps humain
                    MessageBox.Show("T° invalide et extrême supérieure", "T° invalide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTemperature.Focus();
                }
            }
            catch (Exception) { }
        }

        private void btnLoadPreconsultation_Click(object sender, EventArgs e)
        {
            try
            {
                loadData();
                //btnSave.Enabled = true;
                //btnDelete.Enabled = true;
                clsDoTraitement.doubleclicRecherchePersonneMaladeDg = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des informations de préconsultation du malade sélectionné =>" + ex.Message, "Affichage informations préconsultation pour malade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtMalade_DoubleClick(object sender, EventArgs e)
        {
            RecherchePersonneMaladeFrm frm = new RecherchePersonneMaladeFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();

            if (clsDoTraitement.doubleclicRecherchePersonneMaladeDg)
            {
                btnLoadPreconsultation.Enabled = true;
                clsDoTraitement.doubleclicRecherchePersonneMaladeDg = false;
                txtMalade.Text = clsDoTraitement.doubleclic_nom_malade;
            }
            else btnLoadPreconsultation.Enabled = false;
        }

        private void loadData()
        {
            //bsrc.DataSource = clsMetier.GetInstance().getAllClsmaladeDt(clsDoTraitement.IdMalade);

            try
            {
                personne = clsMetier.GetInstance().getClsmalade(clsDoTraitement.IdMalade);

                d = clsMetier.GetInstance().getClsdossierpreconsultation(clsDoTraitement.IdMalade);
                personne.Id = clsDoTraitement.IdMalade;
                lstDossierEncCours.DataSource = clsMetier.GetInstance().getAllClsdossierpreconsultation1(clsDoTraitement.IdMalade);
                setMembersalllst(lstDossierEncCours, "Date", "Id");

                txtNom.Text = personne.Nom;
                txtPNom.Text = personne.Postnom;
                txtPrenom.Text = personne.Prenom;
                txtSexe.Text = personne.Sexe;
                txtTelephone.Text = personne.Telephone;
                txtDateNaissance.Text = personne.Datenaissance.ToString();
                txtEtatCivil.Text = personne.Etatcivil;
                txtNumero.Text = personne.Numero;
                txtNumeroFiche.Text = personne.Numero_fiche;

                txtProfession.Text = clsMetier.GetInstance().getClsprofession(personne.Id_profession.ToString()).Designation;
                txtEntreprise.Text = clsMetier.GetInstance().getClsetablissementpriseencharge(Convert.ToInt32(personne.Id)).Denomination;
                txtAirSante.Text = clsMetier.GetInstance().getClsairsante(personne.Id_airsante.ToString()).Designation;
                try
                {
                    if (personne.Photo != null) pbPhotoPersonne.Image = (new clsDoTraitement()).getImageFromByte(personne.Photo);
                    else pbPhotoPersonne.Image = null;
                }
                catch (Exception) { pbPhotoPersonne.Image = null; }

                if (clsMetier.GetInstance().getAllClsdossierpreconsultation1(clsDoTraitement.IdMalade).Count == 0)
                {
                    bdNav.Enabled = true;
                    grpDossier.Enabled = false;
                    tabControl1.Enabled = true;

                    //S'il n'ya aucune donné concernant la préconsultation
                    dgvPreconsultation.DataSource = null;
                    //refresh();
                    try
                    {
                        New();
                    }
                    catch (Exception) { btnSave.Enabled = false; }
                }
                else
                {
                    if (lstDossierEncCours.Items.Count == 0) { }
                    else
                    {
                        bindignlst();
                        bln = true;

                        txtDateOuvertureDossier.Text = ((clsdossierpreconsultation)lstDossierEncCours.SelectedItem).Date.ToString();
                        txtEtatPaiement.Text = ((clsdossierpreconsultation)lstDossierEncCours.SelectedItem).Etatpaiement.ToString();
                        bdNav.Enabled = false;
                        grpDossier.Enabled = true;
                    }
                }
            }
            catch (Exception) { }
        }

        private void lblAddMalade_Click(object sender, EventArgs e)
        {
            MaladeFrm frm = new MaladeFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();
        }
    }
}
