using System;
using System.Data;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class ConsultationPreNataleFrm : Form
    {
        public ConsultationPreNataleFrm()
        {
            InitializeComponent(); 
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsconsultationprenatal consPrenatal = new clsconsultationprenatal();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            lblAntecedents.Enabled = false;
            lblExamenGynecoObs.Enabled = false;
            lblConselling.Enabled = false;
            Control[] tbcontrols = { txtDDR,txtDPR,  txtAntecedent, txtMotif, txtHistorique,txtGpSanguin, txtRH, txtGesteTtt,txtParite, txtStatutHemogl,
                                       chkConseille,chkTeste,chkOedeme,cboConjonctivite,txtTaille, txtTemperature,txtPoids,txtPouls,txtPressionArt,
                                       txtDate,txtIdFemmeEnceinte,txtIdCPN };
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
                                       chkConseille,chkTeste,chkOedeme,cboConjonctivite,txtTaille, txtTemperature,txtPoids,txtPouls,txtPressionArt,
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
            cboConjonctivite.Items.Add("Pâle");
            cboConjonctivite.Items.Add("Colorée");
            cboConjonctivite.SelectedIndex = 0;
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
                    cboMaladeGrosse.DataSource = clsMetier.GetInstance().getAllClsmaladegrosse4(clsDoTraitement.IdFemmeEnceinte);
                    setMembersallcbo(cboMaladeGrosse, "Nom_complet", "IdFemmeEnceinte");

                    if (cboMaladeGrosse.Items.Count > 0) cboMaladeGrosse.SelectedIndex = 0;
                }
                else
                {
                    txtIdCPN.Text = clsDoTraitement.idCPNDg.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsconsultationprenatal2(clsDoTraitement.idCPNDg);
                    bln = true;
                    bindignlst();
                    btnAdd.Enabled = false;

                    
                    cboMaladeGrosse.DataSource = clsMetier.GetInstance().getAllClsmaladegrosse4(clsDoTraitement.IdFemmeEnceinte);
                    setMembersallcbo(cboMaladeGrosse, "Nom_complet", "IdFemmeEnceinte");

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
            catch (Exception)
            {
                MessageBox.Show("Erreur d'affichage des informations complémentaires du aptitude", "Erreur d'affichage");
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
                    //if (bsrc.DataSource != null)
                    //{
                    //    clsconsultationprenatal s = new clsconsultationprenatal();
                    //    Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                    //    int i = 0;
                    //    foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                    //    {
                    //        if (dtc.ToString().Equals("Ddr")) s.Ddr = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Drp")) s.Drp = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Entecedent")) s.Entecedent = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Motif")) s.Motif = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Historiquegrossesse")) s.Historiquegrossesse = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Gropesanguin")) s.Gropesanguin = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Rh")) s.Rh = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Gesttte")) s.Gesttte = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Parite")) s.Parite = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Statuthemoglobique")) s.Statuthemoglobique = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Conseiller")) s.Conseiller = ((bool)obj[i]);
                    //        else if (dtc.ToString().Equals("Testee")) s.Testee = ((bool)obj[i]);
                    //        else if (dtc.ToString().Equals("Oedeme")) s.Oedeme = ((bool)obj[i]);
                    //        else if (dtc.ToString().Equals("Conjoctivepalpebrale")) s.Conjoctivepalpebrale = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Prix")) s.Prix = ((double)obj[i]);
                    //        else if (dtc.ToString().Equals("Date")) s.Date = ((DateTime)obj[i]);
                    //        else if (dtc.ToString().Equals("id")) s.Id = ((int)obj[i]);
                    //        else if (dtc.ToString().Equals("Id_maladegrosse")) s.Id_maladegrosse = ((int)obj[i]);

                    //        //Consultation
                    //        else if (dtc.ToString().Equals("Poid")) s.Poid = ((double)obj[i]);
                    //        else if (dtc.ToString().Equals("Temperature")) s.Temperature = ((double)obj[i]);
                    //        else if (dtc.ToString().Equals("Pressionarterielle")) s.Pressionarterielle = ((double)obj[i]);
                    //        else if (dtc.ToString().Equals("Pouls")) s.Pouls = ((int)obj[i]);
                    //        else if (dtc.ToString().Equals("Taille")) s.Taille = ((double)obj[i]);
                    //        i++;
                    //    }
                    //    new clsconsultationprenatal().update(s);
                    //    MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
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
                    //if (bsrc.DataSource != null)
                    //{
                    //    clsconsultationprenatal s = new clsconsultationprenatal();
                    //    Object[] obj = ((DataRowView)bsrc.Current).Row.ItemArray;
                    //    int i = 0;
                    //    foreach (DataColumn dtc in ((DataRowView)bsrc.Current).Row.Table.Columns)
                    //    {
                    //        if (dtc.ToString().Equals("Ddr")) s.Ddr = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Drp")) s.Drp = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Entecedent")) s.Entecedent = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Motif")) s.Motif = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Historiquegrossesse")) s.Historiquegrossesse = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Gropesanguin")) s.Gropesanguin = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Rh")) s.Rh = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Gesttte")) s.Gesttte = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Parite")) s.Parite = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Statuthemoglobique")) s.Statuthemoglobique = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Conseiller")) s.Conseiller = ((bool)obj[i]);
                    //        else if (dtc.ToString().Equals("Testee")) s.Testee = ((bool)obj[i]);
                    //        else if (dtc.ToString().Equals("Oedeme")) s.Oedeme = ((bool)obj[i]);
                    //        else if (dtc.ToString().Equals("Conjoctivepalpebrale")) s.Conjoctivepalpebrale = ((string)obj[i]);
                    //        else if (dtc.ToString().Equals("Prix")) s.Prix = ((double)obj[i]);
                    //        else if (dtc.ToString().Equals("Date")) s.Date = ((DateTime)obj[i]);
                    //        else if (dtc.ToString().Equals("id")) s.Id = ((int)obj[i]);
                    //        else if (dtc.ToString().Equals("Id_maladegrosse")) s.Id_maladegrosse = ((int)obj[i]);

                    //        //Consultation
                    //        else if (dtc.ToString().Equals("Poid")) s.Poid = ((double)obj[i]);
                    //        else if (dtc.ToString().Equals("Temperature")) s.Temperature = ((double)obj[i]);
                    //        else if (dtc.ToString().Equals("Pressionarterielle")) s.Pressionarterielle = ((double)obj[i]);
                    //        else if (dtc.ToString().Equals("Pouls")) s.Pouls = ((int)obj[i]);
                    //        else if (dtc.ToString().Equals("Taille")) s.Taille = ((double)obj[i]);
                    //        i++;
                    //    }
                    //    new clsconsultationprenatal().delete(s);
                    //    MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refresh();
                    //}
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

        private void btnSysteme_Click(object sender, EventArgs e)
        {
            SystemeFrm frm = new SystemeFrm();
            frm.ShowDialog();
        }

        private void FrmConsultationPreNatale_Load(object sender, EventArgs e)
        {
            lblAntecedents.Enabled = false;
            lblExamenGynecoObs.Enabled = false;
            lblConselling.Enabled = false;
            txtIdCPN.Visible = false;
            txtIdFemmeEnceinte.Visible = false;

            try
            {
                bindingcls();
                txtIdFemmeEnceinte.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
                txtIdCPN.Text = clsDoTraitement.IdConsultationPreNatal.ToString();
                //txtIdPersonne.Text = clsDoTraitement.idPersonne.ToString();
                ChargementCombo();
                dgvCPN.DataSource = bsrc;
                refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboMaladeGrosse_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.IdFemmeEnceinte = ((clsmaladegrosse)cboMaladeGrosse.SelectedItem).IdFemmeEnceinte;
            }
            catch (Exception) { }
        }

        private void FrmConsultationPreNatale_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgvAntecedent };
                ComboBox[] cbo = { cboConjonctivite, cboMaladeGrosse };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg, cbo);
            }
            catch (Exception) { }
            //Reinitialisation de la variable permettant de prendre en charge le doble clic sur le DataGrid de CPN
            clsDoTraitement.doubleclicCPNDg = false;
        }
    }
}
