using System;
using System.Drawing;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class ConsultationGynecoFrm : Form
    {
        public ConsultationGynecoFrm()
        {
            InitializeComponent();
        }

        clsmalade malade = new clsmalade();
        BindingSource bsc = new BindingSource();
        BindingSource bscra = new BindingSource();
        BindingSource bsrcl = new BindingSource();

        string strExamen = "";
        string strMedecinTraitant = "";

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        //Consultation
        clsdossierconsultationgynecologique dossierconsultation = new clsdossierconsultationgynecologique();
        private BindingSource bsrc1 = new BindingSource();
        private BindingSource bsrcRest = new BindingSource();
        private bool bln1 = false, blnOkResultat = false;

        //mouvement consultation
        clsconsultationgynecologique mvtconsultationgyneco = new clsconsultationgynecologique();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        //mouvement maladie
        clsmouvementmaladiegynecologique mvtmaladie = new clsmouvementmaladiegynecologique();
        private BindingSource bsrc2 = new BindingSource();
        private bool bln2 = false;

        //antecedentallergie

        clsantecedentallergie allergie = new clsantecedentallergie();
        private bool bln3 = false;
        private BindingSource bsrc3 = new BindingSource();

        //antecedentmaladie

        clsantecedentmaladie maladie = new clsantecedentmaladie();
        private bool bln4 = false;
        private BindingSource bsrc4 = new BindingSource();

        private void ConsultationMedecin_Load(object sender, EventArgs e)
        {
            clsDoTraitement.reinitialiseValue();
            try
            {
                cboMaladie.DataSource = clsMetier.GetInstance().getAllClsmaladiegynecologique();
                setMembersallcbo(cboMaladie, "Designation", "Id");
                cboExamen.DataSource = clsMetier.GetInstance().getAllClsexamen();
                setMembersallcbo(cboExamen, "Designation", "Id");
                cboEchographie.DataSource = clsMetier.GetInstance().getAllClscriterechographie();
                setMembersallcbo(cboEchographie, "Designation", "Id");
                txrIdDossier.Visible = false;
                txtIdMouvementCons.Visible = false;
                txtIdMAL.Visible = false;
                txtIdAntMal.Visible = false;

                lstArchive.DataSource = bsrcRest;
                //if (lstDossierEncCours.Items.Count > 0)
                //    setMembersalllst(lstDossierEncCours, "Date", "Id");
                //if (lstArchive.Items.Count > 0)
                //    setMembersalllst(lstArchive, "Date", "Id");
                refresh();
                if (cboService.Items.Count > 0) cboService.SelectedIndex = 0;
                cboService.AutoCompleteSource = AutoCompleteSource.ListItems;
                cboService.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                lblMedecinconnected.Text = clsMetier.GetInstance().getClsagent(clsDoTraitement.id_Agent_Connecte).Nom_complet;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de chargement de la liste des malades", "Erreur de Chargement");
            }
            finally
            {
                btnAddDossier.Enabled = false;
                btnSaveDossier.Enabled = false;
                btnRefreshDossier.Enabled = false;
            }

            //Recuperation du medecin traitant
            try
            {
                strMedecinTraitant = clsMetier.GetInstance().getClsagent(clsDoTraitement.id_Agent_Connecte).Nom_complet;
            }
            catch (Exception) { }
        }

        private void clearforbindings(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is Label) ((Label)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is RichTextBox) ((RichTextBox)ctrl[i]).DataBindings.Clear();
                //if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                //else if (ctrl[i] is DateTimePicker) ((DateTimePicker)ctrl[i]).DataBindings.Clear();
                //else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
        }

        private void setbindinglsts(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is Label) ctrl.DataBindings.Add("Text", bsc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is RichTextBox) ctrl.DataBindings.Add("Text", bsc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);

            //else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            //else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindignlst()
        {
            Control[] tbcontrols = { lblPoids, lblTaille, lblPression, lblPouls, lblTemprature, txtObservation };
            clearforbindings(tbcontrols);
            setbindinglsts(lblPoids, "Poid", 0);
            setbindinglsts(lblTemprature, "Temperature", 0);
            setbindinglsts(lblPression, "Pressionarterielle", 0);
            setbindinglsts(lblTaille, "Taille", 0);
            setbindinglsts(lblPouls, "Pouls", 0);
            setbindinglsts(txtObservation, "Observation", 0);
        }

        public void erg()
        {
            lblErgot.Text = "►";
            lblErgot.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            pnPreconsultation.Visible = false;
            lblErgot1.Location = new System.Drawing.Point(203, 122);
            lblInfoLabo.Location = new System.Drawing.Point(217, 122);
            lblLineLabo.Location = new System.Drawing.Point(426, 122);
            pnLabo.Location = new System.Drawing.Point(208, 153);
        }

        public void ergot()
        {

            if (lblErgot.Text == "▼")
            {
                erg();
            }
            else
            {
                lblErgot.Text = "▼";
                lblErgot1.Location = new System.Drawing.Point(203, 352);
                lblInfoLabo.Location = new System.Drawing.Point(217, 352);
                lblLineLabo.Location = new System.Drawing.Point(426, 352);
                pnLabo.Location = new System.Drawing.Point(208, 378);
                pnPreconsultation.Visible = true;
            }
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void setMembersalllst(ListBox lst, string displayMember, string valueMember)
        {
            lst.DisplayMember = displayMember;
            lst.ValueMember = valueMember;
        }

        void binding_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value != null)
            {
                Bitmap bb = new Bitmap(pbPhotoPersonne.Size.Width, pbPhotoPersonne.Size.Height);
                bb = (new clsDoTraitement()).getImageFromByte((byte[])e.Value);
                e.Value = bb;
                //btSupprimerPhoto.Enabled = false;
            }
        }

        private void bingImg(PictureBox pb, Object src, string ctrProp, string obj)
        {
            pb.DataBindings.Clear();
            Binding binding = new Binding(ctrProp, src, obj, true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Format += new ConvertEventHandler(binding_Format);
            pb.DataBindings.Add(binding);
        }

        private void clearforbindingDatePreconsultation(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is RichTextBox) ((RichTextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is Label) ((Label)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((Label)ctrl[0]).Focus();
        }

        private void setbindinglstDatePreconsultation(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is RichTextBox) ctrl.DataBindings.Add("Text", bscra, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is Label) ctrl.DataBindings.Add("Text", bscra, strValue, true, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void bindignlstDatePreconsultation()
        {
            Control[] tbcontrols = { lblPoids, lblTemprature, lblPression, lblTaille, lblPouls, txtObservation };
            clearforbindingDatePreconsultation(tbcontrols);

            setbindinglstDatePreconsultation(lblPoids, "Poid", 0);
            setbindinglstDatePreconsultation(lblTemprature, "Temperature", 0);
            setbindinglstDatePreconsultation(lblPression, "Pressionarterielle", 0);
            setbindinglstDatePreconsultation(lblTaille, "Taille", 0);
            setbindinglstDatePreconsultation(lblPouls, "Pouls", 0);
            setbindinglstDatePreconsultation(txtObservation, "Observation", 0);
        }

        private void clearforbindingDateLabo(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is RichTextBox) ((RichTextBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((RichTextBox)ctrl[0]).Focus();
        }

        private void setbindinglstDateLabo(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is RichTextBox) ctrl.DataBindings.Add("Text", bsrcl, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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

        private void lblErgot_Click(object sender, EventArgs e)
        {
            ergot();
        }

        private void cboDatePreconsultation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboDatePreconsultation.Items.Count > 0)
                {
                    bindignlstDatePreconsultation();
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void lblHospitalisation_Click(object sender, EventArgs e)
        {
            ergot();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            ergot();
        }

        private void lblErgot1_Click(object sender, EventArgs e)
        {
            ergo1();
        }

        private void ergo1()
        {
            if (lblErgot1.Text == "▼")
            {
                erg1();
            }
            else
            {
                lblErgot1.Text = "▼";
                pnLabo.Visible = true;
            }
        }

        private void erg1()
        {
            lblErgot1.Text = "►";
            lblErgot1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            pnLabo.Visible = false;
        }

        #region Dossier Consultation
        private void setbindingclsConsultationDossier(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", dossierconsultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", dossierconsultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", dossierconsultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", dossierconsultation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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
            ((ComboBox)ctrl[0]).Focus();
        }

        private void bindingclsConsultationDossier()
        {
            btnCloturer.Enabled = false;
            Control[] tbcontrols = { cboService, txtDateOuvertureDossier, txtEtatConsommation, txtIdMedecinCons, txtIdMalade };
            clearforbinding(tbcontrols);
            setbindingclsConsultationDossier(txtDateOuvertureDossier, "Date", 0);
            setbindingclsConsultationDossier(cboService, "Id_tarifconsultationgynecologique", 1);
            setbindingclsConsultationDossier(txtIdMalade, "Id_malade", 0);
            setbindingclsConsultationDossier(txtIdMedecinCons, "Id_agent", 0);
            setbindingclsConsultationDossier(txtEtatConsommation, "Etatpaiement", 0);
        }

        public void New()
        {
            dossierconsultation = new clsdossierconsultationgynecologique();
            bln1 = false;
            bindingclsConsultationDossier();
            txtIdMedecinCons.Text = clsDoTraitement.id_Agent_Connecte.ToString();
            txtIdMalade.Text = malade.Id.ToString();
        }

        public void refresh()
        {
            try
            {
                bsrc1.DataSource = clsMetier.GetInstance().getAllClsdossierconsultationgynecologique2(malade.Id, "Non cloturé non payé", "Payé non cloturé");
                lstDossierEncCours.DataSource = bsrc1;
                if (lstDossierEncCours.SelectedItems.Count > 0)
                {
                    showItemsDossierEncours();
                }
                else
                {
                    grpMouvement.Enabled = false;
                    dossierconsultation.Id = 0;
                    refreshmvtConsultation();
                }
                bsrcRest.DataSource = clsMetier.GetInstance().getAllClsconsultation2(malade.Id, "Cloturé non payé", "Cloturé");
                cboService.DataSource = clsMetier.GetInstance().getAllClstarifconsultationgynecologique();
                setMembersallcbo(cboService, "Designation", "Id");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void refresh2()
        {
            try
            {
                bsrc1.DataSource = clsMetier.GetInstance().getAllClsdossierconsultationgynecologique2(malade.Id, "Non cloturé non payé", "Payé non cloturé");
                lstDossierEncCours.DataSource = bsrc1;
                if (lstDossierEncCours.SelectedItems.Count > 0)
                {
                    showItemsDossierEncours();
                }
                else
                {
                    grpMouvement.Enabled = false;
                    dossierconsultation.Id = 0;
                    refreshmvtConsultation();
                }
                bsrcRest.DataSource = clsMetier.GetInstance().getAllClsconsultation2(malade.Id, "Cloturé non payé", "Cloturé");
                cboService.DataSource = clsMetier.GetInstance().getAllClstarifconsultationgynecologique();
                setMembersallcbo(cboService, "Designation", "Id");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (!blnOkResultat) dgvResultat.DataSource = null;
        }

        private void setbindinglstDossierConsultation(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindiglstDossierConsultation()
        {
            btnCloturer.Enabled = true;
            Control[] tbcontrols = { cboService, txtDateOuvertureDossier, txtEtatConsommation, txtIdMedecinCons, txtIdMalade };
            clearforbindingDossier(tbcontrols);
            setbindinglstDossierConsultation(cboService, "Id_tarifconsultationgynecologique", 1);
            setbindinglstDossierConsultation(txtDateOuvertureDossier, "Date", 0);
            setbindinglstDossierConsultation(txtEtatConsommation, "Etatpaiement", 0);
            setbindinglstDossierConsultation(txtIdMedecinCons, "Id_agent", 0);
            setbindinglstDossierConsultation(txtIdMalade, "Id_malade", 0);
        }

        public void showItemsDossierEncours()
        {
            dossierconsultation.Id = ((clsdossierconsultationgynecologique)lstDossierEncCours.SelectedItem).Id;
            bindiglstDossierConsultation();

            refreshmvtConsultation();
            bln1 = true;
            grpMouvement.Enabled = true;
        }
        #endregion

        private void btnAddDossier_Click(object sender, EventArgs e)
        {
            try
            {
                New();
                txtEtatConsommation.Text = "Non cloturé non payé";
            }
            catch (Exception)
            {
                btnSaveDossier.Enabled = false;
            }
        }

        private void btnRefreshDossier_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnSaveDossier_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln1)
                {
                    dossierconsultation.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc1.DataSource != null)
                    {
                        clsconsultationgynecologique c = (clsconsultationgynecologique)bsrc1.Current;
                        new clsconsultationgynecologique().update(c);
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
                DialogResult dr = MessageBox.Show("Voulez-vous vraiment clôturer ce dossier ?", "Modification-Clôture", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    if (((clsconsultation)lstDossierEncCours.SelectedItem).Etatpaiement.ToString() == "Non cloturé non payé")
                    {
                        txtEtatConsommation.Text = "Clôturé non payé";
                        clsconsultationgynecologique c = (clsconsultationgynecologique)bsrc1.Current;
                        new clsconsultationgynecologique().update(c);
                        MessageBox.Show("Dossier Clôturé avec succès!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                        refreshmvtConsultation();
                    }
                    else
                    {
                        txtEtatConsommation.Text = "Clôturé";
                        clsconsultationgynecologique c = (clsconsultationgynecologique)bsrc1.Current;
                        new clsconsultationgynecologique().update(c);
                        MessageBox.Show("Dossier Cloturé avec succès!", "Clôture", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                        refreshmvtConsultation();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ">>>" + "Erreur Inentendue!", "Cloture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lstDossierEncCours_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstDossierEncCours.SelectedItems.Count > 0)
                {
                    showItemsDossierEncours();
                }
                else
                {
                    grpMouvement.Enabled = false;
                    refreshmvtConsultation();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        #region Mouvement consultation
        private void NewmvtConsultation()
        {
            mvtconsultationgyneco = new clsconsultationgynecologique();
            bln = false;
            bindingclsmvtConsultation();
        }

        private void setbindingclsmvtConsultation(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", mvtconsultationgyneco, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", mvtconsultationgyneco, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", mvtconsultationgyneco, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", mvtconsultationgyneco, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void clearforbindingMvtConsultation(Control[] ctrl)
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

        private void bindingclsmvtConsultation()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtddr, txtdpa, txtDiagnostics, txtExamen, txtDate, txrIdDossier, cboEchographie };
            clearforbindingMvtConsultation(tbcontrols);

            setbindingclsmvtConsultation(txtddr, "Ddr", 0);
            setbindingclsmvtConsultation(txtdpa, "Dpa", 0);
            setbindingclsmvtConsultation(txtDiagnostics, "Diagnostic", 0);
            setbindingclsmvtConsultation(txtExamen, "Examengyneco", 0);
            setbindingclsmvtConsultation(txtDate, "Date_consultation", 0);
            setbindingclsmvtConsultation(txrIdDossier, "Id_dossierconsultationgynecologique", 0);
            setbindingclsmvtConsultation(cboEchographie, "Id_critereecho", 1);
        }

        private void refreshmvtConsultation()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsconsultationgynecologique1(dossierconsultation.Id);
                dgvConsultation.DataSource = bsrc;

                if (dgvConsultation.SelectedRows.Count > 0)
                {
                    bindignlsthmvtConsultation();
                    bln = true;
                    mvtconsultationgyneco.Id = ((clsconsultationgynecologique)dgvConsultation.SelectedRows[0].DataBoundItem).Id;
                    dgvMedoc.DataSource = bsrc2;
                    grpMaladie.Enabled = true;
                    refreshMouvementMaladie();
                }
                else
                {
                    mvtconsultationgyneco.Id = 0;
                    grpMaladie.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void setbindinglstmvtConsultation(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindignlsthmvtConsultation()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtddr, txtdpa, txtDiagnostics, txtExamen, txtDate, txrIdDossier, cboEchographie };
            clearforbindingMvtConsultation(tbcontrols);

            setbindinglstmvtConsultation(txtddr, "Ddr", 0);
            setbindinglstmvtConsultation(txtdpa, "Dpa", 0);
            setbindinglstmvtConsultation(txtDiagnostics, "Diagnostic", 0);
            setbindinglstmvtConsultation(txtExamen, "Examengyneco", 0);
            setbindinglstmvtConsultation(txtDate, "Date_consultation", 0);
            setbindinglstmvtConsultation(txrIdDossier, "Id_dossierconsultationgynecologique", 0);
            setbindinglstmvtConsultation(cboEchographie, "Id_critereecho", 1);

        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //try
            //{
            NewmvtConsultation();
            //txrIdDossier.Text
            txrIdDossier.Text = dossierconsultation.Id.ToString();
            txtMedecinTraitant.Text = strMedecinTraitant;
            //}
            //catch (Exception)
            //{
            //    btnSave.Enabled = false;
            //}
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshmvtConsultation();
        }

        private void dgvConsultation_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvConsultation.SelectedRows.Count > 0)
                {
                    bindignlsthmvtConsultation();
                    bln = true;
                    mvtconsultationgyneco.Id = ((clsconsultationgynecologique)dgvConsultation.SelectedRows[0].DataBoundItem).Id;
                    grpMaladie.Enabled = true;
                    refreshMouvementMaladie();

                    //Affichage du médecin ayant éffectué la consultation
                    try
                    {
                        txtMedecinTraitant.Text = strMedecinTraitant;
                    }
                    catch (Exception) { }
                }
                else
                {
                    grpMaladie.Enabled = false;
                    mvtconsultationgyneco.Id = 0;
                    txtMedecinTraitant.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(txtDate.Text) < Convert.ToDateTime(txtDateOuvertureDossier.Text)) throw new Exception("La date de consultation ne peut être inférieure à celle de la création du dossier de consultation");
                else
                {
                    if (!bln)
                    {
                        mvtconsultationgyneco.inserts();
                        MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (bsrc.DataSource != null)
                        {
                            clsconsultationgynecologique m = (clsconsultationgynecologique)bsrc.Current;
                            new clsconsultationgynecologique().update(m);
                            MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour " + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            refreshmvtConsultation();
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
                        clsmouvementconsultation m = (clsmouvementconsultation)bsrc.Current;
                        new clsmouvementconsultation().delete(m);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.NewmvtConsultation();
                        refreshmvtConsultation();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblAddTypeExamen_Click(object sender, EventArgs e)
        {
            ExamenFrm form = new ExamenFrm();
            form.setFormPrincipal(principal);
            form.Icon = principal.Icon;
            form.ShowDialog();
        }

        private void lstArchive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstArchive.SelectedItems.Count > 0)
            {
                txtEtatPaiement.Text = clsMetier.GetInstance().getClstarifconsultation(((clsconsultation)lstArchive.SelectedItem).Id_tarifconsultation).Designation;
            }
        }

        private void btnRestauration_Click(object sender, EventArgs e)
        {
            try
            {
                if (((clsconsultation)lstArchive.SelectedItem).Etatpaiement.ToString() == "Cloturé non payé")
                {
                    clsconsultation c = new clsconsultation();
                    c.Id_agent = ((clsconsultation)lstArchive.SelectedItem).Id_agent;
                    c.Id_malade = ((clsconsultation)lstArchive.SelectedItem).Id_malade;
                    c.Id = ((clsconsultation)lstArchive.SelectedItem).Id;
                    c.Id_tarifconsultation = ((clsconsultation)lstArchive.SelectedItem).Id_tarifconsultation;
                    c.Date = ((clsconsultation)lstArchive.SelectedItem).Date;
                    c.Etatpaiement = "Non cloturé non payé";
                    new clsconsultation().update(c);
                    MessageBox.Show("Dossier restauré avec succès!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                else
                {
                    clsconsultation c = new clsconsultation();
                    c.Id_agent = ((clsconsultation)lstArchive.SelectedItem).Id_agent;
                    c.Id_malade = ((clsconsultation)lstArchive.SelectedItem).Id_malade;
                    c.Id = ((clsconsultation)lstArchive.SelectedItem).Id;
                    c.Id_tarifconsultation = ((clsconsultation)lstArchive.SelectedItem).Id_tarifconsultation;
                    c.Date = ((clsconsultation)lstArchive.SelectedItem).Date;
                    c.Etatpaiement = "Non cloturé payé";
                    new clsconsultation().update(c);
                    refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ">>>" + "Erreur Inentendue!", "Cloture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblAddMaladie_Click(object sender, EventArgs e)
        {
            MaladieGynecologiqueFrm form = new MaladieGynecologiqueFrm();
            form.setFormPrincipal(principal);
            form.Icon = principal.Icon;
            form.ShowDialog();
        }

        private void cboMaladie_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterFormMaladieGynecologique)
            {
                try
                {
                    cboMaladie.DataSource = clsMetier.GetInstance().getAllClsmaladiegynecologique();
                }
                catch (Exception) { }
            }
        }

        private void btnAddMouvementMaladie_Click(object sender, EventArgs e)
        {
            try
            {
                NewMvtMaladie();
                txtIdMouvementCons.Text = mvtconsultationgyneco.Id.ToString();
            }
            catch (Exception)
            {
                btnSaveDossier.Enabled = false;
            }
        }

        private void NewMvtMaladie()
        {
            mvtmaladie = new clsmouvementmaladiegynecologique();
            bln2 = false;
            bindingclsMouvementMaladie();
        }

        private void setbindingclsMouvementMaladie(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", mvtmaladie, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", mvtmaladie, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", mvtmaladie, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", mvtmaladie, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingclsMouvementMaladie()
        {
            btnDeleteMouvementMaladie.Enabled = false;
            Control[] tbcontrols = { cboMaladie, txtDateMaladie, txtIdMouvementCons };
            clearforbinding(tbcontrols);

            setbindingclsMouvementMaladie(txtDateMaladie, "Date", 0);
            setbindingclsMouvementMaladie(cboMaladie, "Id_maladie", 1);
            setbindingclsMouvementMaladie(txtIdMouvementCons, "Id_consultationgynecologique", 0);
        }

        public void refreshMouvementMaladie()
        {
            try
            {
                bsrc2.DataSource = clsMetier.GetInstance().getAllClsmouvementmaladiegynecologique2(mvtconsultationgyneco.Id);
                dgvMedoc.DataSource = bsrc2;
                cboMaladie.AutoCompleteSource = AutoCompleteSource.ListItems;
                cboMaladie.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bindignlstMouvementMaladie()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { cboMaladie, txtDateMaladie, txtIdMouvementCons };
            clearforbinding(tbcontrols);

            setbindinglstMouvementMaladie(txtDateMaladie, "Date", 0);
            setbindinglstMouvementMaladie(cboMaladie, "Id_maladie", 1);
            setbindinglstMouvementMaladie(txtIdMouvementCons, "Id_consultationgynecologique", 0);
        }

        private void setbindinglstMouvementMaladie(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnRefreshMouvementMaladie_Click(object sender, EventArgs e)
        {
            refreshMouvementMaladie();
        }

        private void dgvMedoc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMedoc.SelectedRows.Count > 0)
                {
                    bindignlstMouvementMaladie();
                    bln2 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnSaveMouvementMaladie_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln2)
                {
                    mvtmaladie.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc2.DataSource != null)
                    {
                        clsmouvementmaladiegynecologique m = (clsmouvementmaladiegynecologique)bsrc2.Current;
                        new clsmouvementmaladiegynecologique().update(m);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            refreshMouvementMaladie();
        }

        private void btnDeleteMouvementMaladie_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc2.DataSource != null)
                    {
                        clsmouvementmaladiegynecologique m = (clsmouvementmaladiegynecologique)bsrc2.Current;
                        new clsmouvementmaladiegynecologique().delete(m);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.NewMvtMaladie();
                        refreshMouvementMaladie();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboDateExamen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboDateExamen.Items.Count > 0)
                {
                    //txtResultat.Text = clsMetier.GetInstance().getClsResultatExamen_mouvementconsultation(malade.Id, cboDateExamen.Text.Substring(0, 10));
                    dgvResultat.DataSource = clsMetier.GetInstance().getClsResultatExamen_mouvementconsultationt(malade.Id, cboDateExamen.Text.Substring(0, 10));
                    foreach (DataGridViewColumn dgvc in dgvResultat.Columns)
                    {
                        if (dgvc.DataPropertyName.Equals("Id")) dgvc.Visible = false;
                        if (dgvc.DataPropertyName.Equals("Id_operation_laboratoire")) dgvc.Visible = false;
                        if (dgvc.DataPropertyName.Equals("Date")) dgvc.Visible = false;
                        if (dgvc.DataPropertyName.Equals("Id_critere")) dgvc.Visible = false;
                    }
                    blnOkResultat = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur de Chargement des informations sur les résultats du labo");
            }
        }

        private void setbindingclsAllergie(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", allergie, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", allergie, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", allergie, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", allergie, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void bindingClsAllergie()
        {
            btnDeleteAl.Enabled = false;
            Control[] tbcontrols = { txtCommentaire, cboAllergie, txtIdMAL };
            clearforbindingAllergie(tbcontrols);

            setbindingclsAllergie(cboAllergie, "Id_allergie", 1);
            setbindingclsAllergie(txtCommentaire, "Commentaire", 0);
            setbindingclsAllergie(txtIdMAL, "Id_malade", 0);
        }

        private void clearforbindingAllergie(Control[] ctrl)
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

        private void NewAllergie()
        {
            allergie = new clsantecedentallergie();
            bln3 = false;
            bindingClsAllergie();
        }

        public void refreshAllergie()
        {
            try
            {
                bsrc3.DataSource = clsMetier.GetInstance().getAllClsantecedentallergie(malade.Id);
                lstAllergie.DataSource = bsrc3;
                if (cboAllergie.Items.Count > 0) cboAllergie.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void setbindinglstAllergie(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc3, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc3, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc3, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc3, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindignlstAllergie()
        {
            btnDeleteAl.Enabled = true;
            Control[] tbcontrols = { txtCommentaire, cboAllergie, txtIdMAL };
            clearforbindingAllergie(tbcontrols);
            setbindinglstAllergie(cboAllergie, "Id_allergie", 1);
            setbindinglstAllergie(txtCommentaire, "Commentaire", 0);
            setbindinglstAllergie(txtIdMAL, "Id_malade", 0);
        }

        private void lblAddAllergie_Click(object sender, EventArgs e)
        {
            AllergieFrm form = new AllergieFrm();
            form.setFormPrincipal(principal);
            form.Icon = principal.Icon;
            form.ShowDialog();
        }

        private void lstAllergie_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstAllergie.Items.Count > 0)
                {
                    bindignlstAllergie();
                    bln3 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void cboAllergie_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormAllergie)
            {
                try
                {
                    cboAllergie.DataSource = clsMetier.GetInstance().getAllClsallergie();
                    setMembersallcbo(cboAllergie, "Designation", "Id");
                }
                catch (Exception) { }
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                try
                {
                    cboAllergie.DataSource = clsMetier.GetInstance().getAllClsallergie();
                    setMembersallcbo(cboAllergie, "Designation", "Id");
                    cboMaladieA.DataSource = clsMetier.GetInstance().getAllClsmaladiegynecologique();
                    setMembersallcbo(cboMaladieA, "Designation", "Id");
                    refreshAntMal();
                    refreshAllergie();
                }
                catch (Exception) { }
            }
        }

        private void lblAddMaladieM_Click(object sender, EventArgs e)
        {
            MaladieGynecologiqueFrm form = new MaladieGynecologiqueFrm();
            form.setFormPrincipal(principal);
            form.Icon = principal.Icon;
            form.ShowDialog();
        }

        private void setbindingclsAntmaladie(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", maladie, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", maladie, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", maladie, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", maladie, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void bindingClsAntMal()
        {
            btnDeleteAntMal.Enabled = false;
            Control[] tbcontrols = { txtcommentaireMaladie, cboMaladieA, txtIdAntMal };
            clearforbindingAllergie(tbcontrols);

            setbindingclsAntmaladie(cboMaladieA, "Id_maladie", 1);
            setbindingclsAntmaladie(txtcommentaireMaladie, "Commentaire", 0);
            setbindingclsAntmaladie(txtIdAntMal, "Id_malade", 0);
        }

        private void NewAntMaladie()
        {
            maladie = new clsantecedentmaladie();
            bln4 = false;
            bindingClsAntMal();
        }

        public void refreshAntMal()
        {
            try
            {
                bsrc4.DataSource = clsMetier.GetInstance().getAllClsantecedentmaladie(malade.Id);
                lstAntecedentMaladie.DataSource = bsrc4;
                if (cboMaladieA.Items.Count > 0) cboMaladieA.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void setbindinglstAntMal(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc4, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc4, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc4, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc4, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindignlstAntMal()
        {
            btnDeleteAntMal.Enabled = true;
            Control[] tbcontrols = { txtcommentaireMaladie, cboMaladieA, txtIdAntMal };
            clearforbindingAllergie(tbcontrols);

            setbindinglstAntMal(cboMaladieA, "Id_maladie", 1);
            setbindinglstAntMal(txtcommentaireMaladie, "Commentaire", 0);
            setbindinglstAntMal(txtIdAntMal, "Id_malade", 0);
        }

        private void lstAntecedentMaladie_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstAntecedentMaladie.Items.Count > 0)
                {
                    bindignlstAntMal();
                    bln4 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void cboExamen_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (clsDoTraitement.EnterForFormExamen)
                {
                    cboExamen.DataSource = clsMetier.GetInstance().getAllClsexamen();
                }
            }
            catch (Exception) { }
        }

        private void lblAddExamenPhysique_Click(object sender, EventArgs e)
        {
            try
            {
                strExamen = txtDiagnostics.Text;
                int ok = 0;
                if (!string.IsNullOrEmpty(strExamen))
                {
                    string[] tbExams = strExamen.Split(';');
                    for (int i = 0; i < tbExams.Length; i++)
                    {
                        if (cboExamen.Text.Equals(tbExams[i])) { }
                        else ok++;
                    }
                    if (ok == tbExams.Length)
                    {
                        strExamen = strExamen + ";" + cboExamen.Text;
                        txtDiagnostics.Text = strExamen;
                    }
                }
                else
                {
                    strExamen = txtDiagnostics.Text + cboExamen.Text;
                    txtDiagnostics.Text = strExamen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout de l'examen, " + ex.Message, "Erreur d'ajout d'examen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblAddExamenPhysique_MouseEnter(object sender, EventArgs e)
        {
            ((Control)lblAddExamenPhysique).BackColor = Color.FromArgb(163, 185, 207);
            ((Control)lblAddExamenPhysique).ForeColor = Color.WhiteSmoke;
        }

        private void lblAddExamenPhysique_MouseLeave(object sender, EventArgs e)
        {
            ((Control)lblAddExamenPhysique).BackColor = Color.Empty;
            ((Control)lblAddExamenPhysique).ForeColor = Color.Black;
        }

        private void cmdClearExamen_Click(object sender, EventArgs e)
        {
            try
            {
                txtDiagnostics.Clear();
            }
            catch (Exception) { }
        }

        private void btnAddEchographie_Click(object sender, EventArgs e)
        {
            CritereEchographieFrm form = new CritereEchographieFrm();
            form.setFormPrincipal(principal);
            form.Icon = principal.Icon;
            form.ShowDialog();
        }

        private void cboEchographie_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForCritere)
            {
                try
                {
                    cboEchographie.DataSource = clsMetier.GetInstance().getAllClscriterechographie();
                }
                catch (Exception) { }
            }
        }

        private void lblRecherche_MouseEnter(object sender, EventArgs e)
        {
            ((Control)lblRecherche).ForeColor = Color.WhiteSmoke;
            ((Control)lblRecherche).BackColor = Color.FromArgb(163, 185, 207);
        }

        private void lblRecherche_MouseLeave(object sender, EventArgs e)
        {
            ((Control)lblRecherche).BackColor = Color.Empty;
            ((Control)lblRecherche).ForeColor = Color.Black;
        }

        private void lblRecherche_Click(object sender, EventArgs e)
        {
            RecherchePersonneFemmeFrm form = new RecherchePersonneFemmeFrm();
            form.setFormPrincipal(principal);
            form.Icon = principal.Icon;
            form.ShowDialog();
        }

        private void cmdLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                //blnactivRe = false;
                //MessageBox.Show("test");
                malade.Id = clsDoTraitement.IdMalade;
                lblNomMalade.Text = clsDoTraitement.doubleclic_nom_malade;

                try
                {
                    try
                    {
                        pbPhotoPersonne.Image = clsDoTraitement.GetInstance().getImageFromByte(clsMetier.GetInstance().getClsmalade1(malade.Id).Photo);
                    }
                    catch (Exception) { pbPhotoPersonne.Image = null; }

                    bscra.DataSource = clsMetier.GetInstance().getAllClspreconsultation2(malade.Id);
                    cboDateExamen.DataSource = clsMetier.GetInstance().getClsResultatExamen_mouvementconsultationtco(malade.Id);
                    cboDatePreconsultation.DataSource = bscra;
                    setMembersallcbo(cboDatePreconsultation, "Dateprecons", "Id");
                    try
                    {
                        if (cboDatePreconsultation.Items.Count > 0)
                        {
                            bindignlstDatePreconsultation();
                        }
                    }
                    catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }

                    refresh2();
                    blnOkResultat = false;
                    refreshmvtConsultation();
                    refreshMouvementMaladie();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception) { }
            finally
            {
                btnAddDossier.Enabled = false;
                btnSaveDossier.Enabled = false;
                btnRefreshDossier.Enabled = false;
            }
        }

        private void btnAddAntAl_Click(object sender, EventArgs e)
        {
            try
            {
                NewAllergie();
                txtIdMAL.Text = malade.Id.ToString();
                if (cboAllergie.Items.Count > 0) cboAllergie.SelectedIndex = 0;

            }
            catch (Exception)
            {
                btnSaveAntAl.Enabled = false;
            }
        }

        private void btnSaveAntAl_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln3)
                {
                    allergie.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc3.DataSource != null)
                    {
                        clsantecedentallergie a = (clsantecedentallergie)bsrc3.Current;
                        new clsantecedentallergie().update(a);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour " + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            refreshAllergie();
        }

        private void btnRefreshAntAl_Click(object sender, EventArgs e)
        {
            refreshAllergie();
        }

        private void btnDeleteAl_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc3.DataSource != null)
                    {
                        clsantecedentallergie a = (clsantecedentallergie)bsrc3.Current;
                        new clsantecedentallergie().delete(a);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.NewAllergie();
                        refreshAllergie();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAddAntMal_Click(object sender, EventArgs e)
        {
            try
            {
                NewAntMaladie();
                txtIdAntMal.Text = malade.Id.ToString();
                if (cboMaladieA.Items.Count > 0) cboMaladieA.SelectedIndex = 0;

            }
            catch (Exception)
            {
                btnSaveMal.Enabled = false;
            }
        }

        private void btnSaveMal_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln4)
                {
                    maladie.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc4.DataSource != null)
                    {
                        clsantecedentmaladie a = (clsantecedentmaladie)bsrc4.Current;
                        new clsantecedentmaladie().update(a);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour " + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            refreshAntMal();
        }

        private void btnRefreshAntMal_Click(object sender, EventArgs e)
        {
            refreshAntMal();
        }

        private void btnDeleteAntMal_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc4.DataSource != null)
                    {
                        clsantecedentmaladie a = (clsantecedentmaladie)bsrc4.Current;
                        new clsantecedentmaladie().delete(a);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.NewAntMaladie();
                        refreshAntMal();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmConsultationGyneco_Load(object sender, EventArgs e)
        {
            clsDoTraitement.reinitialiseValue();
            try
            {
                cboMaladie.DataSource = clsMetier.GetInstance().getAllClsmaladiegynecologique();
                setMembersallcbo(cboMaladie, "Designation", "Id");
                cboExamen.DataSource = clsMetier.GetInstance().getAllClsexamen();
                setMembersallcbo(cboExamen, "Designation", "Id");
                cboEchographie.DataSource = clsMetier.GetInstance().getAllClscriterechographie();
                setMembersallcbo(cboEchographie, "Designation", "Id");
                txrIdDossier.Visible = false;
                txtIdMouvementCons.Visible = false;
                txtIdMAL.Visible = false;
                txtIdAntMal.Visible = false;

                lstArchive.DataSource = bsrcRest;
                //if (lstDossierEncCours.Items.Count > 0)
                //    setMembersalllst(lstDossierEncCours, "Date", "Id");
                //if (lstArchive.Items.Count > 0)
                //    setMembersalllst(lstArchive, "Date", "Id");
                refresh();
                if (cboService.Items.Count > 0) cboService.SelectedIndex = 0;
                cboService.AutoCompleteSource = AutoCompleteSource.ListItems;
                cboService.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                lblMedecinconnected.Text = clsMetier.GetInstance().getClsagent(clsDoTraitement.id_Agent_Connecte).Nom_complet;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de chargement de la liste des malades", "Erreur de Chargement");
            }
            finally
            {
                btnAddDossier.Enabled = false;
                btnSaveDossier.Enabled = false;
                btnRefreshDossier.Enabled = false;
            }

            //Recuperation du medecin traitant
            try
            {
                strMedecinTraitant = clsMetier.GetInstance().getClsagent(clsDoTraitement.id_Agent_Connecte).Nom_complet;
            }
            catch (Exception) { }
        }

        private void cmdLoadData_Click_1(object sender, EventArgs e)
        {
            try
            {
                //blnactivRe = false;
                //MessageBox.Show("test");
                malade.Id = clsDoTraitement.IdMalade;
                lblNomMalade.Text = clsDoTraitement.doubleclic_nom_malade;

                try
                {
                    try
                    {
                        pbPhotoPersonne.Image = clsDoTraitement.GetInstance().getImageFromByte(clsMetier.GetInstance().getClsmalade1(malade.Id).Photo);
                    }
                    catch (Exception) { pbPhotoPersonne.Image = null; }

                    bscra.DataSource = clsMetier.GetInstance().getAllClspreconsultation2(malade.Id);
                    cboDateExamen.DataSource = clsMetier.GetInstance().getClsResultatExamen_mouvementconsultationtco(malade.Id);
                    cboDatePreconsultation.DataSource = bscra;
                    setMembersallcbo(cboDatePreconsultation, "Dateprecons", "Id");
                    try
                    {
                        if (cboDatePreconsultation.Items.Count > 0)
                        {
                            bindignlstDatePreconsultation();
                        }
                    }
                    catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }

                    refresh2();
                    blnOkResultat = false;
                    refreshmvtConsultation();
                    refreshMouvementMaladie();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception) { }
            finally
            {
                btnAddDossier.Enabled = false;
                btnSaveDossier.Enabled = false;
                btnRefreshDossier.Enabled = false;
            }
            try
            {
                refreshAllergie();
            }
            catch (Exception) { }

            try
            {
                refreshAntMal();
            }
            catch (Exception) { }
        }
    }
}
