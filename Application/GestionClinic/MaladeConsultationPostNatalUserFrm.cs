using System;
using System.Data;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class MaladeConsultationPostNatalUserFrm : UserControl
    {
        public MaladeConsultationPostNatalUserFrm()
        {
            InitializeComponent();
        }
        clsmaladeenconsultationpostnatal maladeConsPostnatal = new clsmaladeenconsultationpostnatal();
        clsmalade personne = new clsmalade();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            lblRendezVous.Enabled = false;
            lblSuiviCroissance.Enabled = false;
            lblVaccination.Enabled = false;
            Control[] tbcontrols = { txtLieuNaissance,cboMalade,txtNumeroNaissance, txtPoidNaissance, txtPere, txtMere };
            clearforbinding(tbcontrols);

            //Malade
            setbindingcls(cboMalade, "Id_malade", 1);
            setbindingcls(txtLieuNaissance, "Lieunaissance", 0);
            setbindingcls(txtNumeroNaissance, "Numeronaissance", 0);
            setbindingcls(txtPoidNaissance, "Poidsnaisance", 0);
            setbindingcls(txtPere, "Nompere", 0);
            setbindingcls(txtMere, "Nommere", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtLieuNaissance,txtNumero, cboMalade,txtNumeroNaissance, txtPoidNaissance, txtPere, txtMere, txtAdresse ,txtIdEnfant};
            clearforbinding(tbcontrols);

            //Malade
            setbindinglst(cboMalade, "Id_malade", 1);
            setbindinglst(txtLieuNaissance, "Lieunaissance", 0);
            setbindinglst(txtNumeroNaissance, "Numeronaissance", 0);
            setbindinglst(txtPoidNaissance, "Poidsnaisance", 0);
            setbindinglst(txtPere, "Nompere", 0);
            setbindinglst(txtMere, "Nommere", 0);
            //Recuperation de l'Id de l'enfant
            setbindinglst(txtIdEnfant, "idMalPostNatal", 0);
            clsDoTraitement.IdEnfant = Convert.ToInt32(txtIdEnfant.Text);
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
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", maladeConsPostnatal, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", maladeConsPostnatal, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", maladeConsPostnatal, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", maladeConsPostnatal, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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
            maladeConsPostnatal = new clsmaladeenconsultationpostnatal();
            bln = false;
            bindingcls();
            txtNumeroNaissance.Text = clsMetier.GetInstance().generatenumeronaissance().ToString();
            if (cboMalade.Items.Count > 0) cboMalade.SelectedIndex = 0;
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
                cboMalade.DataSource = clsMetier.GetInstance().getAllClsmalade();
                setMembersallcbo(cboMalade, "Nom_complet", "Id");

                bsrc.DataSource = clsMetier.GetInstance().getAllClsmaladeenconsultationpostnatal1();

                clsDoTraitement.doubleclicVaccinationDg = false;
                clsDoTraitement.doubleclicRendezvousDg = false;
                clsDoTraitement.doubleclicSuivicroissanceDg = false;
                clsDoTraitement.doubleclicPriseVitamineDg = false;
                clsDoTraitement.doubleclicConsultationFicheDg = false;
                clsDoTraitement.doubleclicAttentionSpecialeDg = false;

                clsDoTraitement.idVaccinationDg = 0;
                clsDoTraitement.idRendezvousDg = 0;
                clsDoTraitement.idSuivicroissanceDg = 0;
                clsDoTraitement.idPriseVitamineDg = 0;
                clsDoTraitement.idConsultationFicheDg = 0;
                clsDoTraitement.idAttentionSpecialeDg = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Actualisation des DataGrid du bas suivant le aptitude choisi
            try
            {
                dgvRendezVous.DataSource = clsMetier.GetInstance().getAllClsrendezvous1(clsDoTraitement.IdEnfant);
                dgvCroissance.DataSource = clsMetier.GetInstance().getAllClssuivicroissance1(clsDoTraitement.IdEnfant);
                dgvvaccination.DataSource = clsMetier.GetInstance().getAllClsvaccination1(clsDoTraitement.IdEnfant);
                dgvprisevitamine.DataSource = clsMetier.GetInstance().getAllClsprise_vitamine1(clsDoTraitement.IdEnfant);
                dgvAttentionSpeciale.DataSource = clsMetier.GetInstance().getAllClsattention_speciale1(clsDoTraitement.IdEnfant);
                dgvconsultationFiche.DataSource = clsMetier.GetInstance().getAllClsconsultation_fiche1(clsDoTraitement.IdEnfant);
            }
            catch (Exception) { MessageBox.Show("Erreur d'affichage des informations complémentaires du aptitude", "Erreur d'affichage"); }
        }

        private void FrmMaladeConsultationPostNatalUser_Load(object sender, EventArgs e)
        {
            lblRendezVous.Enabled = false;
            lblSuiviCroissance.Enabled = false;
            lblVaccination.Enabled = false;
            lblPriseVitamine.Enabled = false;
            lblAttentionSp.Enabled = false;
            lblConsFiche.Enabled = false;
            txtIdEnfant.Visible = false;

            try
            {
                bindingcls();
                txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
                dgvMaladeConsPost.DataSource = bsrc;
                refresh();
                if (cboMalade.Items.Count > 0) cboMalade.SelectedIndex = 0;
                txtNumero.Enabled = false;
                txtNumeroNaissance.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                    maladeConsPostnatal.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsmaladeenconsultationpostnatal s = new clsmaladeenconsultationpostnatal();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("poidsnaisance")) s.Poidsnaisance = ((obj[i]) == DBNull.Value) ? Convert.ToDouble("0") : ((double)obj[i]);
                            else if (dtc.ToString().Equals("lieunaissance")) s.Lieunaissance = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("nommere")) s.Nommere = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("nompere")) s.Nompere = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("numeronaissance")) s.Numeronaissance = ((obj[i]) == DBNull.Value) ? Convert.ToInt32("0") : ((int)obj[i]);
                            else if (dtc.ToString().Equals("id")) s.IdEnfant = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_malade")) s.Id_malade = ((int)obj[i]);
                            i++;
                        }
                        new clsmaladeenconsultationpostnatal().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Permet l'actualisation des valeur des professions sur le formulaire appelant
                clsDoTraitement.EnterFormMalEnConsPostNatale = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New();
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
                        clsmaladeenconsultationpostnatal s = new clsmaladeenconsultationpostnatal();
                        Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                        int i = 0;
                        foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                        {
                            if (dtc.ToString().Equals("poidsnaisance")) s.Poidsnaisance = ((obj[i]) == DBNull.Value) ? Convert.ToDouble("0") : ((double)obj[i]);
                            else if (dtc.ToString().Equals("lieunaissance")) s.Lieunaissance = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("nommere")) s.Nommere = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("nompere")) s.Nompere = ((obj[i]) == DBNull.Value) ? null : ((string)obj[i]);
                            else if (dtc.ToString().Equals("numeronaissance")) s.Numeronaissance = ((obj[i]) == DBNull.Value) ? Convert.ToInt32("0") : ((int)obj[i]);
                            else if (dtc.ToString().Equals("id")) s.IdEnfant = ((int)obj[i]);
                            else if (dtc.ToString().Equals("id_malade")) s.Id_personne = ((int)obj[i]);
                            i++;
                        }
                        new clsmaladeenconsultationpostnatal().delete(s);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refresh();
                    }
                }
                //Permet l'actualisation des valeur des professions sur le formulaire appelant
                clsDoTraitement.EnterFormMalEnConsPostNatale = true;
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
                bsrc.Filter = "Numero LIKE '%" + txtSeach.Text + "OR Numeronaissance LIKE '%" + txtSeach.Text + "%'";
            }
            catch { }
        }

        private void lblVaccination_Click(object sender, EventArgs e)
        {
            clsDoTraitement.doubleclicVaccinationDg = false;
            clsDoTraitement.idVaccinationDg = 0;

            VaccinationFrm frm = new VaccinationFrm();
            frm.ShowDialog();
        }

        private void lblRendezVous_Click(object sender, EventArgs e)
        {
            clsDoTraitement.doubleclicRendezvousDg = false;
            clsDoTraitement.idRendezvousDg = 0;

            RendezVousFrm frm = new RendezVousFrm();
            frm.ShowDialog();
        }

        private void lblSuiviCroissance_Click(object sender, EventArgs e)
        {
            clsDoTraitement.doubleclicSuivicroissanceDg = false;
            clsDoTraitement.idSuivicroissanceDg = 0;

            FrmSuivieCroissance frm = new FrmSuivieCroissance();
            frm.ShowDialog();
        }

        private void dgvMaladeConsPost_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvMaladeConsPost.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                    //Chargement des DataGrid du bas suivant le aptitude (Enfant) choisie 
                    dgvRendezVous.DataSource = clsMetier.GetInstance().getAllClsrendezvous1(clsDoTraitement.IdEnfant);
                    dgvCroissance.DataSource = clsMetier.GetInstance().getAllClssuivicroissance1(clsDoTraitement.IdEnfant);
                    dgvvaccination.DataSource = clsMetier.GetInstance().getAllClsvaccination1(clsDoTraitement.IdEnfant);
                    dgvprisevitamine.DataSource = clsMetier.GetInstance().getAllClsprise_vitamine1(clsDoTraitement.IdEnfant);
                    dgvAttentionSpeciale.DataSource = clsMetier.GetInstance().getAllClsattention_speciale1(clsDoTraitement.IdEnfant);
                    dgvconsultationFiche.DataSource = clsMetier.GetInstance().getAllClsconsultation_fiche1(clsDoTraitement.IdEnfant);

                    lblVaccination.Enabled = true;
                    lblSuiviCroissance.Enabled = true;
                    lblRendezVous.Enabled = true;
                    lblPriseVitamine.Enabled = true;
                    lblAttentionSp.Enabled = true;
                    lblConsFiche.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); 
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvMaladeConsPost_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMaladeConsPost.RowCount > 0) clsDoTraitement.IdEnfant = Convert.ToInt32(txtIdEnfant.Text);
            }
            catch (Exception) { }
        }

        private void dgvvaccination_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.doubleclicVaccinationDg = true;
                clsDoTraitement.idVaccinationDg = ((clsutilisateur_groupe)dgvvaccination.SelectedRows[0].DataBoundItem).Id;
                VaccinationFrm frm = new VaccinationFrm();
                frm.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage, veuillez actualiser svp !!", "Erreur d'affichage"); }
        
        }

        private void dgvRendezVous_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.doubleclicRendezvousDg = true;
                clsDoTraitement.idRendezvousDg = ((clsrendezvous)dgvRendezVous.SelectedRows[0].DataBoundItem).Id;
                RendezVousFrm frm = new RendezVousFrm();
                frm.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage, veuillez actualiser svp !!", "Erreur d'affichage"); }
        
        }

        private void dgvprisevitamine_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.doubleclicPriseVitamineDg = true;
                clsDoTraitement.idPriseVitamineDg = ((clsprise_vitamine)dgvprisevitamine.SelectedRows[0].DataBoundItem).Id;
                PriseVitamineFrm frm = new PriseVitamineFrm();
                frm.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage, veuillez actualiser svp !!", "Erreur d'affichage"); }
        
        }

        private void lblPriseVitamine_Click(object sender, EventArgs e)
        {
            clsDoTraitement.doubleclicPriseVitamineDg = false;
            clsDoTraitement.idPriseVitamineDg = 0;

            PriseVitamineFrm frm = new PriseVitamineFrm();
            frm.ShowDialog();
        }

        private void dgvAttentionSpeciale_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.doubleclicAttentionSpecialeDg = true;
                clsDoTraitement.idAttentionSpecialeDg = ((clsattention_speciale)dgvAttentionSpeciale.SelectedRows[0].DataBoundItem).Id;
                AttentionSpecialeFrm frm = new AttentionSpecialeFrm();
                frm.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage, veuillez actualiser svp !!", "Erreur d'affichage"); }
        
        }

        private void dgvconsultationFiche_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.doubleclicConsultationFicheDg = true;
                clsDoTraitement.idConsultationFicheDg = ((clsconsultation_fiche)dgvconsultationFiche.SelectedRows[0].DataBoundItem).Id;
                ConsultationFicheFrm frm = new ConsultationFicheFrm();
                frm.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage, veuillez actualiser svp !!", "Erreur d'affichage"); }
        
        }

        private void lblAttentionSp_Click(object sender, EventArgs e)
        {
            clsDoTraitement.doubleclicAttentionSpecialeDg = false;
            clsDoTraitement.idAttentionSpecialeDg = 0;

            AttentionSpecialeFrm frm = new AttentionSpecialeFrm();
            frm.ShowDialog();
        }

        private void lblConsFiche_Click(object sender, EventArgs e)
        {
            clsDoTraitement.doubleclicConsultationFicheDg = false;
            clsDoTraitement.idConsultationFicheDg = 0;

            ConsultationFicheFrm frm = new ConsultationFicheFrm();
            frm.ShowDialog();
        }

        private void dgvCroissance_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.doubleclicSuivicroissanceDg = true;
                clsDoTraitement.idSuivicroissanceDg = ((clssuivicroissance)dgvCroissance.SelectedRows[0].DataBoundItem).Id;
                FrmSuivieCroissance frm = new FrmSuivieCroissance();
                frm.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage, veuillez actualiser svp !!", "Erreur d'affichage"); }
        
        }

        private void cboMalade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                personne = clsMetier.GetInstance().getClsmalade(((clsmalade)cboMalade.SelectedItem).Id);

                txtIdPers.Text = personne.IdPers.ToString();
                txtNumero.Text = personne.Numero;
                txtNom.Text = personne.Nom;
                txtPNom.Text = personne.Postnom;
                txtPrenom.Text = personne.Prenom;
                txtSexe.Text = personne.Sexe;
                txtTelephone.Text = personne.Telephone;
                txtAdresse.Text = personne.Adresse;
                txtDateNaissance.Text = personne.Datenaissance.ToString();
                txtEtatCivil.Text = personne.Etatcivil;
                txtCategorie.Text = clsMetier.GetInstance().getClscategoriemalade(Convert.ToInt32(personne.Id_categoriemalade)).Designation;
                txtProfession.Text = clsMetier.GetInstance().getClsprofession(Convert.ToInt32(personne.Id_profession)).Designation;
                txtEtablissement.Text = clsMetier.GetInstance().getClsetablissementpriseencharge(Convert.ToInt32(personne.Id_etablissement)).Denomination;
                txtAireSante.Text = clsMetier.GetInstance().getClsairsante(Convert.ToInt32(personne.Id_airsante)).Designation;
                pbPhotoPersonne.Image = (new clsDoTraitement()).getImageFromByte(personne.Photo);
            }
            catch (Exception) { }
        }
    }
}
