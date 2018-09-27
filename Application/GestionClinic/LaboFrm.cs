using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class LaboFrm : Form
    {
        public LaboFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsmalade malade = new clsmalade();
        int recupeIdDossierLabo = 0;
        List<int> idDossierLabo = new List<int>();
        bool okSelectionItemListDossier = false;

        //operation laboratoire
        clsoperation_laboratoire operation = new clsoperation_laboratoire();
        BindingSource bsrc = new BindingSource();
        BindingSource bsrc2 = new BindingSource();
        BindingSource bsrc3 = new BindingSource();
        BindingSource bsrc4 = new BindingSource();

        BindingSource bsrcRest = new BindingSource();
        bool bln = false;
        //Labo
        clsmouvementoperation_laboratoire labo = new clsmouvementoperation_laboratoire();
        bool bln1 = false;
        BindingSource bsrc1 = new BindingSource();

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        void binding_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value != null)
            {
                Bitmap bb = new Bitmap(pbPhotoPersonne.Size.Width, pbPhotoPersonne.Size.Height);
                bb = (new clsDoTraitement()).getImageFromByte((byte[])e.Value);
                e.Value = bb;
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

        private void clearforbindingDignostic(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is RichTextBox) ((RichTextBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((RichTextBox)ctrl[0]).Focus();
        }

        private void setbindinglstDatePreconsultation(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is RichTextBox) ctrl.DataBindings.Add("Text", bsrc2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is Label) ctrl.DataBindings.Add("Text", bsrc2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglstDignostic(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is RichTextBox) ctrl.DataBindings.Add("Text", bsrc3, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindignlstDignosticGyneco(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is RichTextBox) ctrl.DataBindings.Add("Text", bsrc4, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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

        private void bindignlstDignostic()
        {
            Control[] tbcontrols = { txtDiagnostic };
            clearforbindingDignostic(tbcontrols);
            setbindinglstDignostic(txtDiagnostic, "Diagnostics", 0);
        }

        private void bindignlstDiagnosticGyneco()
        {
            Control[] tbcontrols = { txtDignosticGyneco };
            clearforbindingDignostic(tbcontrols);
            setbindignlstDignosticGyneco(txtDignosticGyneco, "Diagnostic", 0);
        }

        private void setMembersalllst(ListBox lst, string displayMember, string valueMember)
        {
            lst.DisplayMember = displayMember;
            lst.ValueMember = valueMember;
        }

        public void getObject()
        {
            lstArchive.DataSource = clsMetier.GetInstance().getAllClsoperation_laboratoire2(malade.Id, "Cloturé non payé", "Cloturé");
            setMembersalllst(lstArchive, "Date", "Id");
            refreshOperation();
            setMembersalllst(lstDossierEncCours, "Date", "Id");
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

        private void cbocboDateDignostic_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbocboDateDignostic.Items.Count > 0)
                {
                    bindignlstDignostic();
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void FrmLabo_Load(object sender, EventArgs e)
        {
            clsDoTraitement.reinitialiseValue();
            btnAddDossier.Enabled = false;
            btnSaveDossier.Enabled = false;
            txtIdOperation.Visible = false;
            lblAddTypeExamen.Enabled = false;

            try
            {
                cboExamen.DataSource = clsMetier.GetInstance().getAllClsexamen();
                setMembersallcbo(cboExamen, "Designation", "Id");
                cboCritere.DataSource = clsMetier.GetInstance().getAllClscritereresultat();
                setMembersallcbo(cboCritere, "Designation", "Id");
                if (cboCritere.Items.Count > 0) cboCritere.SelectedIndex = 0;
                if (cboExamen.Items.Count > 0) cboExamen.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de chargement des listes", "Erreur de Chargement");
            }
            refreshOperation();
        }

        #region operationlabo
        private void clearforbindingOperation(Control[] ctrl)
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

        private void setbindingclsOperation(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", operation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", operation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", operation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", operation, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingclsOperation()
        {
            Control[] tbcontrols = { cboExamen, txtDateOuvertureDossier, txtIdMalade, txtetatPaiement };
            clearforbindingOperation(tbcontrols);

            setbindingclsOperation(txtDateOuvertureDossier, "Date", 0);
            setbindingclsOperation(cboExamen, "Id_examen", 1);
            setbindingclsOperation(txtIdMalade, "Id_malade", 0);
            setbindingclsOperation(txtetatPaiement, "Etatpaiement", 0);
        }

        private void New()
        {
            operation = new clsoperation_laboratoire();
            bln = false;
            bindingclsOperation();
            txtIdMalade.Text = malade.Id.ToString();
        }

        private void refreshOperation()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsoperation_laboratoire2(malade.Id, "Non cloturé non payé", "Payé non cloturé");
                lstDossierEncCours.DataSource = bsrc;
                if (lstDossierEncCours.SelectedItems.Count > 0)
                {
                    bindiglstLabo();
                    bln1 = true;
                    operation.Id = ((clsoperation_laboratoire)lstDossierEncCours.SelectedItem).Id;
                    refreshLabo();
                    grpLabo.Enabled = true;
                }
                else
                {
                    grpLabo.Enabled = false;
                    operation.Id = 0;
                    refreshLabo();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void setbindinglstOperation(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindiglstOperation()
        {
            btnCloturer.Enabled = true;
            Control[] tbcontrols = { cboExamen, txtDateOuvertureDossier, txtIdMalade, txtetatPaiement };
            clearforbindingOperation(tbcontrols);

            setbindinglstOperation(txtDateOuvertureDossier, "Date", 0);
            setbindinglstOperation(cboExamen, "Id_examen", 1);
            setbindinglstOperation(txtIdMalade, "Id_malade", 0);
            setbindinglstOperation(txtetatPaiement, "Etatpaiement", 0);
        }
        #endregion

        #region Laboratoire
        //Methode permettant de verifier l'existance ou non d'un item dans la liste des examens
        //pour y ajouter l'item selectione ou non
        private void VerifieExistItemList(string ctrl1, string ctrl2)
        {
            if (lstExamen.Items.Count == 0 && lstExamen.Items.Count == 0)
            {
                lstExamen.Items.Add(ctrl1);
                lstResultat.Items.Add(ctrl2);
            }
            else
            {
                string[] tabResult = ctrl2.Split(';');
                string strResult = tabResult[0];
                for (int i = 0; i < lstExamen.Items.Count; i++)
                {
                    if (lstExamen.Items[i].ToString().Equals(ctrl1.ToString()) && lstResultat.Items[i].ToString().Equals(ctrl2.ToString()))
                    {
                        break;
                    }
                    if (i == lstExamen.Items.Count - 1 && i == lstResultat.Items.Count - 1)
                    {
                        lstExamen.Items.Add(ctrl1);
                        lstResultat.Items.Add(ctrl2);
                        break;
                    }
                }
            }
        }

        //Methode permettant de verifier l'existance ou non d'un item dans la liste des Résultats
        //pour y ajouter l'item selectione ou non
        private void VerifieExistItemListResultat(string ctrl)
        {
            if (lstResultat.Items.Count == 0)
            {
                lstResultat.Items.Add(ctrl);
            }
            else
            {
                for (int i = 0; i < lstResultat.Items.Count; i++)
                {
                    if (lstResultat.Items[i].ToString().Equals(ctrl.ToString()))
                    {
                        break;
                    }
                    if (i == lstResultat.Items.Count - 1)
                    {
                        lstResultat.Items.Add(ctrl);
                        break;
                    }
                }
            }
        }

        private void clearforbindingLabo(Control[] ctrl)
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

        private void setbindingclsLabo(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", labo, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", labo, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", labo, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", labo, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void refreshLabo()
        {
            try
            {
                bsrc1.DataSource = clsMetier.GetInstance().getAllClsmouvementoperation_laboratoire2(operation.Id);
                dgvExamen.DataSource = bsrc1;
                //lstExamen.Items.Clear();
                //lstResultat.Items.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void setbindinglstLabo(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindiglstLabo()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtDateLabo, txtResultat, txtIdOperation, cboCritere };
            clearforbindingLabo(tbcontrols);

            setbindinglstLabo(txtDateLabo, "Date", 0);
            setbindinglstLabo(txtResultat, "Resultat", 0);
            setbindinglstLabo(txtIdOperation, "Id_operation_laboratoire", 0);
            setbindinglstLabo(cboCritere, "Id_critere", 1);
        }
        #endregion

        private void btnAddDossier_Click(object sender, EventArgs e)
        {
            try
            {
                New();
                txtetatPaiement.Text = "Non cloturé non payé";
            }
            catch (Exception)
            {
                btnSaveDossier.Enabled = false;
            }
        }

        private void btnRefreshDossier_Click(object sender, EventArgs e)
        {
            refreshOperation();
        }

        private void btnSaveDossier_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    operation.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsoperation_laboratoire o = (clsoperation_laboratoire)bsrc.Current;
                        new clsoperation_laboratoire().update(o);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            refreshOperation();
            refreshLabo();
        }

        private void lstDossierEncCours_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstDossierEncCours.SelectedItems.Count > 0)
                {
                    bindiglstOperation();
                    bln = true;
                    operation.Id = ((clsoperation_laboratoire)lstDossierEncCours.SelectedItem).Id;
                    //On recupère l'Id du dossier 
                    recupeIdDossierLabo = operation.Id;
                    //Chargement de l'xamendans le cbo
                    cboExamen.Text = clsMetier.GetInstance().getClsexamen1(operation.Id).Designation;
                    setMembersallcbo(cboExamen, "Designation", "Id");

                    refreshLabo();
                    grpLabo.Enabled = true;
                    okSelectionItemListDossier = true;
                }
                else
                {
                    grpLabo.Enabled = false;
                    operation.Id = 0;
                    refreshLabo();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnCloturer_Click(object sender, EventArgs e)
        {
            try
            {
                if (((clsoperation_laboratoire)lstDossierEncCours.SelectedItem).Etatpaiement.ToString() == "Non cloturé non payé")
                {
                    txtetatPaiement.Text = "Cloturé non payé";
                    clsoperation_laboratoire o = (clsoperation_laboratoire)bsrc.Current;
                    new clsoperation_laboratoire().update(o);
                    MessageBox.Show("Dossier Cloturé avec succès!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getObject();
                    refreshOperation();
                    refreshLabo();
                }
                else
                {
                    txtetatPaiement.Text = "Cloturé";
                    clsoperation_laboratoire o = (clsoperation_laboratoire)bsrc.Current;
                    new clsoperation_laboratoire().update(o);
                    MessageBox.Show("Dossier Cloturé avec succès!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getObject();
                    refreshOperation();
                    refreshLabo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ">>>" + "Erreur Inentendue!", "Cloture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblAddTypeExamen_Click(object sender, EventArgs e)
        {
            ExamenFrm frm = new ExamenFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                VerifieExistItemList(cboExamen.Text, txtResultat.Text + ";" + txtDateLabo.Text + ";" + cboCritere.Text);
                idDossierLabo.Add(recupeIdDossierLabo);
                //okResultat = true;
                bln1 = false;

                txtResultat.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur inattendue lors de l'ajout, veuillez vérifier votre sélection svp !!", "Ajout résultat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshLabo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (okSelectionItemListDossier)
                {
                    //Autorisant la MAJ car on a reelement selectionner un dossierdans la Liste des dossiers
                    if (!bln1)
                    {
                        string[] tbContentLstResultat = null;

                        for (int i = 0; i < lstResultat.Items.Count; i++)
                        {
                            tbContentLstResultat = lstResultat.Items[i].ToString().Split(';');
                            labo.Resultat = tbContentLstResultat[0];
                            labo.Date = Convert.ToDateTime(tbContentLstResultat[1]);
                            labo.Id_critere = clsMetier.GetInstance().getClscritereresultat(tbContentLstResultat[2]).Id;
                            labo.Id_operation_laboratoire = Convert.ToInt32(idDossierLabo[i]);
                            labo.inserts();
                        }
                        MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        idDossierLabo.Clear();
                        lstResultat.Items.Clear();
                        lstExamen.Items.Clear();
                        okSelectionItemListDossier = false;
                    }
                    else
                    {
                        if (bsrc1.DataSource != null)
                        {
                            clsmouvementoperation_laboratoire m = (clsmouvementoperation_laboratoire)bsrc1.Current;
                            new clsmouvementoperation_laboratoire().update(m);
                            okSelectionItemListDossier = false;
                            MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else MessageBox.Show("Veuillez sélectionner un dossier dans la liste des dossiers svp !", "Mise à jour informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            refreshLabo();
        }

        private void dgvExamen_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvExamen.SelectedRows.Count > 0)
                {
                    bindiglstLabo();
                    //bln1 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }

            //Chargement du DataGrid des détails avec examens-critere-resultat

            try
            {
                if (dgvExamen.SelectedRows.Count > 0)
                {
                    dgvSynthese.DataSource = clsMetier.GetInstance().getResultat_Examen_Critere_OperationLabo(((clsmouvementoperation_laboratoire)dgvExamen.SelectedRows[0].DataBoundItem).Id_operation_laboratoire, ((clsmouvementoperation_laboratoire)dgvExamen.SelectedRows[0].DataBoundItem).Date.ToString().Substring(0, 10));
                }
                else
                {
                    dgvSynthese.DataSource = clsMetier.GetInstance().getResultat_Examen_Critere_OperationLabo(0, "10/10/1990");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc1.DataSource != null)
                    {
                        clsmouvementoperation_laboratoire l = (clsmouvementoperation_laboratoire)bsrc1.Current;
                        new clsmouvementoperation_laboratoire().delete(l);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.NewLabo();
                        refreshLabo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lstArchive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstArchive.SelectedItems.Count > 0)
            {
                txtExamenP.Text = clsMetier.GetInstance().getClsexamen(((clsoperation_laboratoire)lstArchive.SelectedItem).Id_examen).Designation;
            }
        }

        private void btnRestauration_Click(object sender, EventArgs e)
        {
            try
            {
                if (((clsoperation_laboratoire)lstArchive.SelectedItem).Etatpaiement.ToString() == "Cloturé non payé")
                {
                    clsoperation_laboratoire o = new clsoperation_laboratoire();
                    o.Id_examen = ((clsoperation_laboratoire)lstArchive.SelectedItem).Id_examen;
                    o.Id_malade = ((clsoperation_laboratoire)lstArchive.SelectedItem).Id_malade;
                    o.Id = ((clsoperation_laboratoire)lstArchive.SelectedItem).Id;
                    o.Date = ((clsoperation_laboratoire)lstArchive.SelectedItem).Date;
                    o.Etatpaiement = "Non cloturé non payé";
                    new clsoperation_laboratoire().update(o);
                    MessageBox.Show("Dossier restauré avec succès!", "Restauration Dossier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getObject();
                    refreshOperation();
                    refreshLabo();
                }
                else
                {
                    clsoperation_laboratoire o = new clsoperation_laboratoire();
                    o.Id_examen = ((clsoperation_laboratoire)lstArchive.SelectedItem).Id_examen;
                    o.Id_malade = ((clsoperation_laboratoire)lstArchive.SelectedItem).Id_malade;
                    o.Id = ((clsoperation_laboratoire)lstArchive.SelectedItem).Id;
                    o.Date = ((clsoperation_laboratoire)lstArchive.SelectedItem).Date;
                    o.Etatpaiement = "Non cloturé payé";
                    new clsoperation_laboratoire().update(o);
                    getObject();
                    refreshOperation();
                    refreshLabo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ">>>" + "Erreur Inentendue!", "Cloture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboCritere_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboCritere.DataSource = clsMetier.GetInstance().getAllClscritereresultat();
                setMembersallcbo(cboCritere, "Designation", "Id");
            }
            catch (Exception) { }
        }

        private void lblAjouterCritere_Click(object sender, EventArgs e)
        {
            CritereResultatFrm frm = new CritereResultatFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();
        }

        private void cboDiagnosticGyneco_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboDiagnosticGyneco.Items.Count > 0)
                {
                    bindignlstDiagnosticGyneco();
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                //if(lstExamem)
                lstResultat.Items.RemoveAt(lstExamen.SelectedIndex);
                idDossierLabo.RemoveAt(lstExamen.SelectedIndex);
                lstExamen.Items.RemoveAt(lstExamen.SelectedIndex);
            }
            catch (Exception) { MessageBox.Show("Erreur Lors de la suppresion des éléments. Vérifier que vous avez réellement sélectionné un élément dans la liste de(s) examens passé(s)", "supression des éléments", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
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

        private void cmdLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                malade.Id = clsDoTraitement.IdMalade;
                lblNomMalade.Text = clsDoTraitement.doubleclic_nom_malade;
                getObject();

                try
                {
                    try
                    {
                        pbPhotoPersonne.Image = clsDoTraitement.GetInstance().getImageFromByte(clsMetier.GetInstance().getClsmalade1(malade.Id).Photo);
                    }
                    catch (Exception) { pbPhotoPersonne.Image = null; }

                    bsrc2.DataSource = clsMetier.GetInstance().getAllClspreconsultation2(malade.Id);
                    cboDatePreconsultation.DataSource = bsrc2;
                    setMembersallcbo(cboDatePreconsultation, "Dateprecons", "Id");
                    if (cboDatePreconsultation.Items.Count > 0)
                    {
                        bindignlstDatePreconsultation();
                    }
                    bsrc3.DataSource = clsMetier.GetInstance().getAllClsmouvementconsultation3(malade.Id);
                    cbocboDateDignostic.DataSource = bsrc3;
                    setMembersallcbo(cbocboDateDignostic, "Date", "Id");
                    if (cbocboDateDignostic.Items.Count > 0)
                    {
                        bindignlstDignostic();
                    }

                    bsrc4.DataSource = clsMetier.GetInstance().getAllClsconsultationgynecologique3(malade.Id);
                    cboDiagnosticGyneco.DataSource = bsrc4;
                    setMembersallcbo(cboDiagnosticGyneco, "Date_consultation", "Id");
                    if (cboDiagnosticGyneco.Items.Count > 0)
                    {
                        bindignlstDiagnosticGyneco();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                refreshOperation();
                refreshLabo();
                lstResultat.Items.Clear();
                lstExamen.Items.Clear();

                //On charge l'examen correspondant au dossier
                try
                {
                    if (lstDossierEncCours.Items.Count > 0)
                    {
                        cboExamen.Text = clsMetier.GetInstance().getClsexamen1(((clsoperation_laboratoire)lstDossierEncCours.SelectedItem).Id).Designation;
                    }
                    else cboExamen.Text = "";
                }
                catch (Exception)
                {
                    MessageBox.Show("Erreur de chargement des listes", "Erreur de Chargement");
                }
            }
            catch (Exception) { }
        }

        private void lblRecherche_Click(object sender, EventArgs e)
        {
            RecherchePersonneMaladeFrm frm = new RecherchePersonneMaladeFrm();
            frm.setFormPrincipal(principal);
            frm.Icon = principal.Icon;
            frm.ShowDialog();
        }
    }
}
