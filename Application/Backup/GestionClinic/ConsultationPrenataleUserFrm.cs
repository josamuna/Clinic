using System;
using System.Data;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class ConsultationPrenataleUserFrm : UserControl
    {
        public ConsultationPrenataleUserFrm()
        {
            InitializeComponent();
        }
        clsconsultationprenatal consPrenatal = new clsconsultationprenatal();
        private BindingSource bsrc = new BindingSource();
        private BindingSource bsrcRest = new BindingSource();
        private bool bln = false;

        clsdossierconsultationprenatale dosssierconsultationprenatale = new clsdossierconsultationprenatale();
        private BindingSource bsrc1 = new BindingSource();
        bool bln1 = false;

        #region consultationprenatale

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            lblAntecedents.Enabled = false;
            lblExamenGynecoObs.Enabled = false;
            lblConselling.Enabled = false;
            Control[] tbcontrols = { txtDDR,txtDPR,  txtAntecedent, txtMotif, txtHistorique,txtGpSanguin, txtRH, txtGesteTtt,txtParite, txtStatutHemogl,
                                       chkConseille,chkTeste,chkOedeme,cboConjonctivite, txtPrix,txtTaille, txtTemperature,txtPoids,txtPouls,txtPressionArt,
                                       txtDate,txtIdFemmeEnceinte,txtIdCPN,txtIdDossier };
            clearforbinding(tbcontrols);

            txtIdFemmeEnceinte.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
            txtIdCPN.Text = clsDoTraitement.IdConsultationPreNatal.ToString();
            setbindingcls(txtDPR, "Ddr", 0);
            setbindingcls(txtDDR, "Drp", 0);
            setbindingcls(txtAntecedent, "Entecedent", 0);
            setbindingcls(txtMotif, "Motif", 0);
            setbindingcls(txtHistorique, "Historiquegrossesse", 0);
            setbindingcls(txtGpSanguin, "Gropesanguin", 0);
            setbindingcls(txtRH, "Rh", 0);
            setbindingcls(txtGesteTtt, "Gesttte", 0);
            setbindingcls(txtParite, "Parite", 0);
            setbindingcls(txtStatutHemogl, "Statuthemoglobique", 0);
            setbindingcls(chkConseille, "Conseiller", 0);
            setbindingcls(chkTeste, "Testee", 0);
            setbindingcls(chkOedeme, "Oedeme", 1);
            setbindingcls(cboConjonctivite, "Conjoctivepalpebrale", 0);
            setbindingcls(txtDate, "Date", 0);
            setbindingcls(txtIdFemmeEnceinte, "Id_maladegrosse", 0);
            setbindingcls(txtIdDossier, "Id_dossierconsultationprenatale", 0);

            //Consultation
            setbindingcls(txtTaille, "Taille", 0);
            setbindingcls(txtTemperature, "Temperature", 0);
            setbindingcls(txtPoids, "Poid", 0);
            setbindingcls(txtPouls, "Pouls", 0);
            setbindingcls(txtPressionArt, "Pressionarterielle", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtDDR,txtDPR,  txtAntecedent, txtMotif, txtHistorique,txtGpSanguin, txtRH, txtGesteTtt,txtParite, txtStatutHemogl,
                                       chkConseille,chkTeste,chkOedeme,cboConjonctivite, txtPrix,txtTaille, txtTemperature,txtPoids,txtPouls,txtPressionArt,
                                       txtDate,txtIdFemmeEnceinte,txtIdCPN };
            clearforbinding(tbcontrols);

            setbindinglst(txtDPR, "Ddr", 0);
            setbindinglst(txtDDR, "Drp", 0);
            setbindinglst(txtAntecedent, "Entecedent", 0);
            setbindinglst(txtMotif, "Motif", 0);
            setbindinglst(txtHistorique, "Historiquegrossesse", 0);
            setbindinglst(txtGpSanguin, "Gropesanguin", 0);
            setbindinglst(txtRH, "Rh", 0);
            setbindinglst(txtGesteTtt, "Gesttte", 0);
            setbindinglst(txtParite, "Parite", 0);
            setbindinglst(txtStatutHemogl, "Statuthemoglobique", 0);
            setbindinglst(chkConseille, "Conseiller", 0);
            setbindinglst(chkTeste, "Testee", 0);
            setbindinglst(chkOedeme, "Oedeme", 1);
            setbindinglst(cboConjonctivite, "Conjoctivepalpebrale", 0);
            setbindinglst(txtDate, "Date", 0);
            setbindinglst(txtPrix, "Prix", 0);

            //Recuperation de l'Id de la Femme enceinte
            setbindinglst(txtIdFemmeEnceinte, "Id_maladegrosse", 0);
            clsDoTraitement.IdFemmeEnceinte = Convert.ToInt32(txtIdFemmeEnceinte.Text);

            //Recuperation de l'Id de la CPN
            setbindinglst(txtIdCPN, "Id", 0);
            clsDoTraitement.IdConsultationPreNatal = Convert.ToInt32(txtIdCPN.Text);
        }

        private void clearforbinding(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is DateTimePicker) ((DateTimePicker)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is CheckBox) ((CheckBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((TextBox)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", consPrenatal, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", consPrenatal, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", consPrenatal, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", consPrenatal, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", consPrenatal, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void ChargementCombo()
        {
            cboConjonctivite.Items.Add("Colorée");
            cboConjonctivite.Items.Add("Pâle");
            cboConjonctivite.SelectedIndex = 0;
        }

        private void New()
        {
            consPrenatal = new clsconsultationprenatal();
            bln = false;
            bindingcls();
            if (cboConjonctivite.Items.Count > 0) cboConjonctivite.SelectedIndex = 0;
            txtIdFemmeEnceinte.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
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
                if (!clsDoTraitement.doubleclicCPNDg)
                {
                    bindingcls();
                    //txtIdFemmeEnceinte.Text = clsDoTraitement.IdFemmeEnceinte.ToString();

                    bsrc.DataSource = clsMetier.GetInstance().getAllClsconsultationprenatal();

                    cboMaladeGrosse.DataSource = clsMetier.GetInstance().getAllClsmaladegrosse2(clsDoTraitement.IdFemmeEnceinte);
                    setMembersallcbo(cboMaladeGrosse, "Nom_complet", "Id_maladegrosse");

                    if (cboMaladeGrosse.Items.Count > 0) cboMaladeGrosse.SelectedIndex = 0;
                }
                else
                {
                    txtIdCPN.Text = clsDoTraitement.idCPNDg.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsconsultationprenatal2(clsDoTraitement.idCPNDg);
                    bln = true;
                    bindignlst();
                    btnAdd.Enabled = false;


                    cboMaladeGrosse.DataSource = clsMetier.GetInstance().getAllClsmaladegrosse2(clsDoTraitement.IdFemmeEnceinte);
                    setMembersallcbo(cboMaladeGrosse, "Nom_complet", "Id_maladegrosse");

                    //On met les valeurs correspondantes a ceux de la consultation prénatale selectionee
                    if (bsrc.Count != 0)
                    {
                        txtDDR.Text = ((clsconsultationprenatal)bsrc.Current).Ddr;
                        txtDPR.Text = ((clsconsultationprenatal)bsrc.Current).Drp;
                        txtAntecedent.Text = ((clsconsultationprenatal)bsrc.Current).Entecedent;
                        txtMotif.Text = ((clsconsultationprenatal)bsrc.Current).Motif;
                        txtHistorique.Text = ((clsconsultationprenatal)bsrc.Current).Historiquegrossesse;
                        txtGpSanguin.Text = ((clsconsultationprenatal)bsrc.Current).Gropesanguin;
                        txtRH.Text = ((clsconsultationprenatal)bsrc.Current).Rh;
                        txtGesteTtt.Text = ((clsconsultationprenatal)bsrc.Current).Gesttte;
                        txtParite.Text = ((clsconsultationprenatal)bsrc.Current).Parite;
                        txtStatutHemogl.Text = ((clsconsultationprenatal)bsrc.Current).Statuthemoglobique;
                        chkConseille.Checked = (bool)((clsconsultationprenatal)bsrc.Current).Conseiller;
                        chkTeste.Checked = (bool)((clsconsultationprenatal)bsrc.Current).Testee;
                        chkOedeme.Checked = (bool)((clsconsultationprenatal)bsrc.Current).Oedeme;
                        cboConjonctivite.Text = ((clsconsultationprenatal)bsrc.Current).Conjoctivepalpebrale;
                        txtTaille.Text = ((clsconsultationprenatal)bsrc.Current).Taille.ToString();
                        txtTemperature.Text = ((clsconsultationprenatal)bsrc.Current).Temperature.ToString();
                        txtPoids.Text = ((clsconsultationprenatal)bsrc.Current).Poid.ToString();
                        txtPouls.Text = ((clsconsultationprenatal)bsrc.Current).Pouls.ToString();
                        txtPressionArt.Text = ((clsconsultationprenatal)bsrc.Current).Pressionarterielle.ToString();
                        txtDate.Text = ((clsconsultationprenatal)bsrc.Current).Date.ToString();
                    }
                }

                clsDoTraitement.doubleclicExamenGynecoObstetriqueDg = false;
                clsDoTraitement.doubleclicAntecedentMedicauxObstetriqueDg = false;
                clsDoTraitement.doubleclicConcellingEtTestRapideDg = false;

                clsDoTraitement.idExamenGynecoObstetriqueDg = 0;
                clsDoTraitement.idAntecedentMedicauxObstetriqueDg = 0;
                clsDoTraitement.idConcellingEtTestRapideDg = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //Actualisation des DataGrid du bas suivant la consultation Pré Natale choisi
            try
            {
                dgvAntecedent.DataSource = clsMetier.GetInstance().getAllClsentecedentmedicauxobsetricaux1(clsDoTraitement.IdConsultationPreNatal);
                dgvExamen.DataSource = clsMetier.GetInstance().getAllClsexamengynecoobsetrical1(clsDoTraitement.IdConsultationPreNatal);
                dgvConcelling.DataSource = clsMetier.GetInstance().getAllClsconsellingettestrapide1(clsDoTraitement.IdConsultationPreNatal);

                lblAntecedents.Enabled = true;
                lblExamenGynecoObs.Enabled = true;
                lblConselling.Enabled = true;
            }
            catch (Exception) { MessageBox.Show("Erreur d'affichage des informations complémentaires du aptitude", "Erreur d'affichage"); }
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
                    consPrenatal.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsconsultationprenatal s = (clsconsultationprenatal)bsrc.Current;
                        new clsconsultationprenatal().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                //Permet l'actualisation des valeur des CPN sur le formulaire appelant
                clsDoTraitement.EnterFormConsultationPreNatale = true;
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
                        clsconsultationprenatal s = (clsconsultationprenatal)bsrc.Current;
                        new clsconsultationprenatal().update(s);
                        MessageBox.Show("Suppression effectuée!", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.New();
                    refresh();
                }
                //Permet l'actualisation des valeur des CPN sur le formulaire appelant
                clsDoTraitement.EnterFormConsultationPreNatale = true;
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
                bsrc.Filter = "Ddr LIKE '%" + txtSeach.Text + "%' OR Motif LIKE '%" + txtSeach.Text + "%' OR Drp LIKE '%" + txtSeach.Text + "%' OR Entecedent LIKE '%" + txtSeach.Text + "%' OR Entecedent LIKE '%" + txtSeach.Text + "%' OR Historiquegrossesse LIKE '%" + txtSeach.Text + "%' OR Gropesanguin LIKE '%" + txtSeach.Text + "%' OR Rh LIKE '%" + txtSeach.Text + "%' OR Gesttte LIKE '%" + txtSeach.Text + "%' OR Parite LIKE '%" + txtSeach.Text + "%' OR Statuthemoglobique LIKE '%" + txtSeach.Text + "%'";
            }
            catch { }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgvAntecedent };
                ComboBox[] cbo = { cboConjonctivite, cboMaladeGrosse, cboService };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg, cbo);
            }
            catch (Exception) { }
            this.Dispose();
            //Reinitialisation de la variable permettant de prendre en charge le doble clic sur le DataGrid de CPN
            clsDoTraitement.doubleclicCPNDg = false;
        }

        private void lblExamenGynecoObs_Click(object sender, EventArgs e)
        {
            clsDoTraitement.doubleclicExamenGynecoObstetriqueDg = false;
            clsDoTraitement.idExamenGynecoObstetriqueDg = 0;

            ExamenGynecoObsetricalFrm frm = new ExamenGynecoObsetricalFrm();
            frm.ShowDialog();
        }

        private void lblAntecedents_Click(object sender, EventArgs e)
        {
            clsDoTraitement.doubleclicAntecedentMedicauxObstetriqueDg = false;
            clsDoTraitement.idAntecedentMedicauxObstetriqueDg = 0;

            AntecedentMedicauxObsetricauxFrm frm = new AntecedentMedicauxObsetricauxFrm();
            frm.ShowDialog();
        }

        private void lblConselling_Click(object sender, EventArgs e)
        {
            clsDoTraitement.doubleclicConcellingEtTestRapideDg = false;
            clsDoTraitement.idConcellingEtTestRapideDg = 0;

            ConsellingEtTestRapideFrm frm = new ConsellingEtTestRapideFrm();
            frm.ShowDialog();
        }

        private void dgvExamen_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.doubleclicExamenGynecoObstetriqueDg = true;
                clsDoTraitement.idExamenGynecoObstetriqueDg = ((clsexamengynecoobsetrical)dgvExamen.SelectedRows[0].DataBoundItem).Id;
                ExamenGynecoObsetricalFrm frm = new ExamenGynecoObsetricalFrm();
                frm.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage, veuillez actualiser svp !!", "Erreur d'affichage"); }
        }

        private void dgvAntecedent_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.doubleclicAntecedentMedicauxObstetriqueDg = true;
                clsDoTraitement.idAntecedentMedicauxObstetriqueDg = ((clsentecedentmedicauxobsetricaux)dgvAntecedent.SelectedRows[0].DataBoundItem).Id;
                AntecedentMedicauxObsetricauxFrm frm = new AntecedentMedicauxObsetricauxFrm();
                frm.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage, veuillez actualiser svp !!", "Erreur d'affichage"); }
        }

        private void dgvConcelling_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.doubleclicConcellingEtTestRapideDg = true;
                clsDoTraitement.idConcellingEtTestRapideDg = ((clsconsellingettestrapide)dgvConcelling.SelectedRows[0].DataBoundItem).Id;
                ConsellingEtTestRapideFrm frm = new ConsellingEtTestRapideFrm();
                frm.ShowDialog();
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage, veuillez actualiser svp !!", "Erreur d'affichage"); }
        
        }

        private void FrmConsultationPrenataleUser_Load(object sender, EventArgs e)
        {
            lblAntecedents.Enabled = false;
            lblExamenGynecoObs.Enabled = false;
            lblConselling.Enabled = false;
            txtIdCPN.Visible = false;
            txtIdDossier.Visible = false;
            txtIdFemmeEnceinte.Visible = false;

            //try
            //{
                lstDossierEncCours.DataSource = bsrc1;
                lstArchive.DataSource = bsrcRest;

                bindingcls();
                txtIdFemmeEnceinte.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
                txtIdCPN.Text = clsDoTraitement.IdConsultationPreNatal.ToString();
                ChargementCombo();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void btnSysteme_Click(object sender, EventArgs e)
        {
            SystemeFrm frm = new SystemeFrm();
            frm.ShowDialog();
        }

        private void cboMaladeGrosse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.IdFemmeEnceinte = ((clsmaladegrosse)cboMaladeGrosse.SelectedItem).IdFemmeEnceinte;
            }
            catch (Exception) { }
        }

        private void dgvCPN_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvCPN.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                    clsDoTraitement.IdConsultationPreNatal = Convert.ToInt32(txtIdCPN.Text);
                    //Chargement des DataGrid du bas suivant la consultation choisie
                    dgvAntecedent.DataSource = clsMetier.GetInstance().getAllClsentecedentmedicauxobsetricaux1(clsDoTraitement.IdConsultationPreNatal);
                    dgvExamen.DataSource = clsMetier.GetInstance().getAllClsexamengynecoobsetrical1(clsDoTraitement.IdConsultationPreNatal);
                    dgvConcelling.DataSource = clsMetier.GetInstance().getAllClsconsellingettestrapide1(clsDoTraitement.IdConsultationPreNatal);

                    lblConselling.Enabled = true;
                    lblExamenGynecoObs.Enabled = true;
                    lblAntecedents.Enabled = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void dgvCPN_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCPN.RowCount > 0)
                {
                    clsDoTraitement.IdConsultationPreNatal = Convert.ToInt32(txtIdCPN.Text);
                    clsDoTraitement.IdFemmeEnceinte = Convert.ToInt32(txtIdFemmeEnceinte.Text);
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region Dossier Consultation Prenatale

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
        private void setbindingclsConsultationDossier(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", dosssierconsultationprenatale, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", dosssierconsultationprenatale, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", dosssierconsultationprenatale, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", dosssierconsultationprenatale, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void bindingclsConsultationDossier()
        {
            btnCloturer.Enabled = false;
            Control[] tbcontrols = { txtDateOuvertureDossier,cboService,  txtEtatConsommation, txtIdMalade };
            clearforbindingDossier(tbcontrols);
            setbindingclsConsultationDossier(txtDateOuvertureDossier, "Date", 0);
            setbindingclsConsultationDossier(cboService, "Id_tarifconsultation", 1);
            setbindingclsConsultationDossier(txtIdMalade, "Id_malade", 0);           
            setbindingclsConsultationDossier(txtEtatConsommation, "Etatpaiement", 0);
        }
        public void NewDossier()
        {
            dosssierconsultationprenatale = new clsdossierconsultationprenatale();
            bln1 = false;
            bindingclsConsultationDossier();
            txtIdMalade.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
        }
        private void btnAddDossier_Click(object sender, EventArgs e)
        {
            try
            {
                NewDossier();
                txtEtatConsommation.Text = "Non cloturé non payé";
            }
            catch (Exception)
            {
                btnSaveDossier.Enabled = false;
            }
        }

        public void refreshDossier()
        {
            try
            {
                bsrc1.DataSource = clsMetier.GetInstance().getAllClsdossierconsultationprenatale2(clsDoTraitement.IdFemmeEnceinte, "Non cloturé non payé", "Payé non cloturé");
                bsrcRest.DataSource = clsMetier.GetInstance().getAllClsdossierconsultationprenatale2(clsDoTraitement.IdFemmeEnceinte, "Cloturé non payé", "Cloturé");
                cboService.DataSource = clsMetier.GetInstance().getAllClstarifconsultationprenatal();
                setMembersallcbo(cboService, "Designation", "Id");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnRefreshDossier_Click(object sender, EventArgs e)
        {
            refreshDossier();
        }

        private void btnSaveDossier_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln1)
                {
                    dosssierconsultationprenatale.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    if (bsrc1.DataSource != null)
                    {
                        clsdossierconsultationprenatale d = (clsdossierconsultationprenatale)bsrc1.Current;
                        new clsdossierconsultationprenatale().update(d);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            refresh();
        }

        private void btnCloturer_Click(object sender, EventArgs e)
        {
            try
            {
                if (((clsdossierconsultationprenatale)lstDossierEncCours.SelectedItem).Etatpaiement.ToString() == "Non cloturé non payé")
                {
                    txtEtatConsommation.Text = "Cloturé non payé";
                    clsdossierconsultationprenatale d = (clsdossierconsultationprenatale)bsrc1.Current;
                    new clsdossierconsultationprenatale().update(d);
                    MessageBox.Show("Dossir Cloturé avec succès!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshDossier();
                    refresh();
                }
                else
                {
                    txtEtatConsommation.Text = "Cloturé";
                    clsdossierconsultationprenatale d = (clsdossierconsultationprenatale)bsrc1.Current;
                    new clsdossierconsultationprenatale().update(d);
                    MessageBox.Show("Dossir Cloturé avec succès!", "Cloture", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshDossier();
                    refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ">>>" + "Erreur Inentendue!", "Cloture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        #endregion 
        private void setbindinglstDossierConsultation(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void bindiglstDossier()
        {
            btnCloturer.Enabled = true;
            Control[] tbcontrols = { txtDateOuvertureDossier,cboService,  txtEtatConsommation, txtIdMalade };
            clearforbindingDossier(tbcontrols);
            setbindinglstDossierConsultation(cboService, "Id_tarifconsultation", 1);
            setbindinglstDossierConsultation(txtDateOuvertureDossier, "Date", 0);
            setbindinglstDossierConsultation(txtEtatConsommation, "Etatpaiement", 0);
            setbindinglstDossierConsultation(txtIdMalade, "Id_malade", 0);
        }

        private void lstDossierEncCours_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstDossierEncCours.SelectedItems.Count > 0)
                {
                    dosssierconsultationprenatale.Id = ((clsdossierconsultationprenatale)lstDossierEncCours.SelectedItem).Id;
                    bindiglstDossier();
                    dgvCPN.DataSource = bsrc;
                    refresh();
                    bln1 = true;
                    grp.Enabled = true;
                }
                else
                {
                    grp.Enabled = false;
                    refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        


       



    }
}
