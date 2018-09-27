using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GestionClinic_LIB;
using GestionClinic_WIN.Reports;

namespace GestionClinic_WIN
{
    public partial class PaimentFrm : Form
    {
        public PaimentFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        private BindingSource bsrc = new BindingSource();
        private BindingSource bsrc1 = new BindingSource();
        private BindingSource bsrc2 = new BindingSource();
        private BindingSource bsrc3 = new BindingSource();
        clsmalade malade = new clsmalade();
        clspaiement paiement = new clspaiement();
        clsarticle_paye article_paye = new clsarticle_paye();
        clsfacturation facturation = new clsfacturation();
        int? id_op, id_cons, id_pre, id_sub, id_sort, id_sort_ext, id_hosp, id_cons_gyn, id_cons_pre, id_cons_post, id_echographi, id_soin, id_accouchement, id_nursing;
        //string m;
        private bool bln = false, bln1 = false, okLoadCloture = false;
        public static bool blnPassationInstervention = false;
        private List<int> listIdArticle = new List<int>();
        private List<int> listQteArticle = new List<int>();
        private List<string> listGetArticleDesignation = new List<string>();
        private List<double> listMontantArticle = new List<double>();
        private double dblMontantPaye = 0, dblMontantMituelle = 0, dblMontantAvance = 0, dblMontantDette = 0;
        private List<object> listObjectArticle = new List<object>();

        double montantdu = 0, taux = 0, montantMituel = 0, montantClient = 0, montantAvance = 0, oldMontantDette = 0, totMontantDu = 0, montant_mituel = 0;
        string categorie_malade = "";
        int identifiantMalade = 0;
        DateTime dateFacturation = Convert.ToDateTime(DateTime.Today.ToShortDateString().Substring(0, 10));//DateTime.Today;
        bool blnDataSourceDefine = false, is_AutreFrais = false;

        #region Binding
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
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", paiement, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", paiement, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst1(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls()
        {
            Control[] tbcontrols = { txtMontantPaye, txtMontantDu, txtDate, txtId_DuMalade, txtId_sortie, txtId_preconsultation, txtId_consultationGyn, txtId_consultation, txtId_dossierconsultationprenatale, txtId_dossierconsultationpostnatal, txtId_operation_laboratoire, txtId_hospitalisation, txtId_autrefraie, txtId_accouchement, txtMontantDette, txtMontant_mituelle, txtGetDette, txtId_subit, txtId_dossiersoins, txtId_dossierechographie, txtId_dossiernursing };
            clearforbinding(tbcontrols);
            setbindingcls(txtDate, "Date", 0);
            setbindingcls(txtId_DuMalade, "Id_malade", 0);
            setbindingcls(txtId_sortie, "Id_sortie", 0);
            setbindingcls(txtId_preconsultation, "Id_dossierpreconsultation", 0);
            setbindingcls(txtId_consultationGyn, "Id_consultationgyn", 0);
            setbindingcls(txtId_consultation, "Id_consultation", 0);
            setbindingcls(txtId_dossierconsultationprenatale, "Id_dossierconsultationprenatale", 0);
            setbindingcls(txtId_dossierconsultationpostnatal, "Id_dossierconsultationpostnatal", 0);
            setbindingcls(txtId_dossierechographie, "Id_dossierechographie", 0);
            setbindingcls(txtId_dossiersoins, "Id_dossiersoin", 0);
            setbindingcls(txtId_dossiernursing, "Id_dossiernursing", 0);
            setbindingcls(txtId_operation_laboratoire, "Id_operation_laboratoire", 0);
            setbindingcls(txtId_hospitalisation, "Id_hospitalisation", 0);
            setbindingcls(txtId_autrefraie, "Id_autrefraie", 0);
            setbindingcls(txtId_accouchement, "Id_accouchement", 0);
            setbindingcls(txtId_subit, "Id_subit", 0);
            setbindingcls(txtMontantDu, "Montantdu", 0);
            setbindingcls(txtMontantPaye, "Montantpaye", 0);
            setbindingcls(txtMontant_mituelle, "Montantmituelle", 0);
            setbindingcls(txtGetDette, "Dette", 0);
        }

        private void bindignlst()
        {
            Control[] tbcontrols = { txtMontantPaye, txtMontantDu, txtDate, txtId_DuMalade, txtId_sortie, txtId_preconsultation, txtId_consultationGyn, txtId_consultation, txtId_dossierconsultationprenatale, txtId_dossierconsultationpostnatal, txtId_operation_laboratoire, txtId_hospitalisation, txtId_autrefraie, txtId_accouchement, txtMontantDette, txtMontant_mituelle, txtGetDette, txtId_subit, txtId_dossiersoins, txtId_dossierechographie, txtId_dossiernursing };
            clearforbinding(tbcontrols);
            setbindinglst(txtDate, "Date", 0);
            setbindinglst(txtId_DuMalade, "Id_malade", 0);
            setbindinglst(txtId_sortie, "Id_sortie", 0);
            setbindinglst(txtId_preconsultation, "Id_dossierpreconsultation", 0);
            setbindinglst(txtId_consultationGyn, "Id_consultationgyn", 0);
            setbindinglst(txtId_consultation, "Id_consultation", 0);
            setbindinglst(txtId_dossierconsultationprenatale, "Id_dossierconsultationprenatale", 0);
            setbindinglst(txtId_dossierconsultationpostnatal, "Id_dossierconsultationpostnatal", 0);
            setbindinglst(txtId_dossierechographie, "Id_dossierechographie", 0);
            setbindinglst(txtId_dossiersoins, "Id_dossiersoin", 0);
            setbindinglst(txtId_dossiernursing, "Id_dossiernursing", 0);
            setbindinglst(txtId_operation_laboratoire, "Id_operation_laboratoire", 0);
            setbindinglst(txtId_hospitalisation, "Id_hospitalisation", 0);
            setbindinglst(txtId_autrefraie, "Id_autrefraie", 0);
            setbindinglst(txtId_accouchement, "Id_accouchement", 0);
            setbindinglst(txtMontantDu, "Montantdu", 0);
            setbindinglst(txtId_subit, "Id_subit", 0);
            setbindinglst(txtMontantPaye, "Montantpaye", 0);
            setbindinglst(txtMontantDette, "Dette", 0);
            setbindinglst(txtMontant_mituelle, "Montantmituelle", 0);
        }

        private void bindingcls1()
        {
            Control[] tbcontrols = { txtMontantPaye, txtMontantDu, txtDate, txtId_DuMalade, txtId_sortie, txtId_preconsultation, txtId_consultationGyn, txtId_consultation, txtId_dossierconsultationprenatale, txtId_dossierconsultationpostnatal, txtId_operation_laboratoire, txtId_hospitalisation, txtId_autrefraie, txtId_accouchement, txtMontantDette, txtGetDette, txtId_subit, txtId_dossiersoins, txtId_dossierechographie, txtId_dossiernursing };
            clearforbinding(tbcontrols);
            setbindingcls(txtDate, "Date", 0);
            setbindingcls(txtId_DuMalade, "Id_malade", 0);
            setbindingcls(txtId_sortie, "Id_sortie", 0);
            setbindingcls(txtId_preconsultation, "Id_dossierpreconsultation", 0);
            setbindingcls(txtId_consultationGyn, "Id_consultationgyn", 0);
            setbindingcls(txtId_consultation, "Id_consultation", 0);
            setbindingcls(txtId_dossierconsultationprenatale, "Id_dossierconsultationprenatale", 0);
            setbindingcls(txtId_dossierconsultationpostnatal, "Id_dossierconsultationpostnatal", 0);
            setbindingcls(txtId_dossierechographie, "Id_dossierechographie", 0);
            setbindingcls(txtId_dossiersoins, "Id_dossiersoin", 0);
            setbindingcls(txtId_dossiernursing, "Id_dossiernursing", 0);
            setbindingcls(txtId_operation_laboratoire, "Id_operation_laboratoire", 0);
            setbindingcls(txtId_hospitalisation, "Id_hospitalisation", 0);
            setbindingcls(txtId_autrefraie, "Id_autrefraie", 0);
            setbindingcls(txtId_accouchement, "Id_accouchement", 0);
            setbindingcls(txtId_subit, "Id_subit", 0);
            setbindingcls(txtMontantDu, "Montantdu", 0);
            setbindingcls(txtMontantPaye, "Montantpaye", 0);
            //setbindingcls(txtMontant_mituelle, "Montantmituelle", 0);
            setbindingcls(txtGetDette, "Dette", 0);
        }

        private void bindignlst1()
        {
            Control[] tbcontrols = { txtMontantPaye, txtMontantDu, txtDate, txtId_DuMalade, txtId_sortie, txtId_preconsultation, txtId_consultationGyn, txtId_consultation, txtId_dossierconsultationprenatale, txtId_dossierconsultationpostnatal, txtId_operation_laboratoire, txtId_hospitalisation, txtId_autrefraie, txtId_accouchement, txtMontantDette, txtId_subit, txtId_dossiersoins, txtId_dossierechographie, txtId_dossiernursing };
            clearforbinding(tbcontrols);
            setbindinglst1(txtDate, "Date", 0);
            setbindinglst1(txtId_DuMalade, "Id_malade", 0);
            setbindinglst1(txtId_sortie, "Id_sortie", 0);
            setbindinglst1(txtId_preconsultation, "Id_dossierpreconsultation", 0);
            setbindinglst1(txtId_consultationGyn, "Id_consultationgyn", 0);
            setbindinglst1(txtId_consultation, "Id_consultation", 0);
            setbindinglst1(txtId_dossierconsultationprenatale, "Id_dossierconsultationprenatale", 0);
            setbindinglst1(txtId_dossierconsultationpostnatal, "Id_dossierconsultationpostnatal", 0);
            setbindinglst1(txtId_dossierechographie, "Id_dossierechographie", 0);
            setbindinglst1(txtId_dossiersoins, "Id_dossiersoin", 0);
            setbindinglst1(txtId_dossiernursing, "Id_dossiernursing", 0);
            setbindinglst1(txtId_operation_laboratoire, "Id_operation_laboratoire", 0);
            setbindinglst1(txtId_hospitalisation, "Id_hospitalisation", 0);
            setbindinglst1(txtId_autrefraie, "Id_autrefraie", 0);
            setbindinglst1(txtId_accouchement, "Id_accouchement", 0);
            setbindinglst1(txtId_subit, "Id_subit", 0);
            setbindinglst1(txtMontantDu, "Montantdu", 0);
            setbindinglst1(txtMontantPaye, "Montantpaye", 0);
            setbindinglst1(txtMontantDette, "Dette", 0);
            //setbindinglst1(txtMontant_mituelle, "Montantmituelle", 0);
        }
        #endregion

        #region Traitement

        private void New()
        {
            paiement = new clspaiement();
            txtId_DuMalade.Text = malade.Id.ToString();
            if ((rdMalade.Checked == false && rdMituelle.Checked == false) || rdMalade.Checked == true)
            {
                bln = false;
                bindingcls();
                txtMontantMituelle.Clear();
                txtMontantClient.Clear();
                txtMontantDette.Text = "0";
                txtMontantAvance.Text = "0";
                txtGetDette.Text = "0";
                listIdArticle.Clear();
                listMontantArticle.Clear();
                listObjectArticle.Clear();
                int t = lstArticles.Items.Count;
                if (blnDataSourceDefine)
                {
                    //lstArticles.DataSource = clsMetier.GetInstance().getAllClsarticle_nothing();
                    //for (int f = 0; f < t; f++) lstArticles.Items.RemoveAt(0);
                    try
                    {
                        //bsrc_mal.DataSource = clsMetier.GetInstance().getAllClsmaladeDt();
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show("Erreur de chargement de la liste des malades", "Chargement des malades");
                    }
                }
                else
                {
                    for (int f = 0; f < t; f++) lstArticles.Items.Remove(lstArticles.Items[0]);
                }
            }
            else if (rdMituelle.Checked == true)
            {
                bln1 = false;
                bindingcls1();
                txtMontantDette.Text = "0";
                txtMontantAvance.Text = "0";
                txtGetDette.Text = "0";
            }
        }

        private void refresh()
        {
            //try
            //{
            //    bsrc_mal.DataSource = clsMetier.GetInstance().getAllClsmaladeDt();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Erreur de chargement de la liste des malades", "Chargement des malades");
            //}

            if ((rdMalade.Checked == false && rdMalade.Checked == true) || (rdMalade.Checked == true && rdMituelle.Checked == false))
            {
                try
                {
                    bindingcls();
                    txtId_DuMalade.Text = malade.Id.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClspaiement();
                    bsrc1.DataSource = clsMetier.GetInstance().getAllClspaiement1();

                    lstArticles.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " >>>> Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (rdMalade.Checked == false && rdMituelle.Checked == true)
            {
                try
                {
                    bindingcls1();
                    txtId_DuMalade.Text = malade.Id.ToString();
                    bsrc2.DataSource = clsMetier.GetInstance().getAllClspaiement_mut1();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " >>>> Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            try
            {
                New();
                int t = listIdArticle.Count;
                lstArticles.DataSource = null;
                blnDataSourceDefine = true;
            }
            catch (Exception) { btEnregistrer.Enabled = false; }
            lblCodeAutreFrais.Text = "";
        }
        #endregion

        private void commonSavePaiement()
        {
            if (rdMalade.Checked == false && rdMituelle.Checked == false)
            {
                MessageBox.Show("Vous devez choisir une rubrique svp");
            }
            else if (rdMalade.Checked == true)
            {
                #region Paiement malade
                if (!bln)
                {
                    #region Avant d'insérer le paiement on effectue des updates suivant les items sélectionnés
                    //On commence par vérifier s'il ya un AutreFraie et si tous les article de la facture externe sont pris sinon on lève une execption
                    //car on voudra payer une seul partie de la facture or il faut tous payer
                    int id_autrefraie = 0, ok = 0;
                    List<int> lstIdentifiant_autrefrais = new List<int>();
                    bool good = false;

                    if (is_AutreFrais)
                    {
                        for (int i = 0; i < lstArticles.Items.Count; i++)
                        {
                            if (listObjectArticle[i] is clsdetailsautrefraie)
                            {
                                ok++;
                                //Autres Frais
                                if (ok == 1) id_autrefraie = clsMetier.GetInstance().getClsautrefraie_Autrefraie(listIdArticle[i]);

                                lstIdentifiant_autrefrais.Add(clsMetier.GetInstance().getClsautrefraie2(listIdArticle[i]).Id);
                            }
                        }

                        foreach (int v in lstIdentifiant_autrefrais)
                        {
                            if (v == id_autrefraie) good = true;
                            else good = false;
                        }

                        if (!good) throw new Exception("Vous devez choisir tous les articles correspondante à la facture concernée pour Autres frais");
                    }

                    for (int i = 0; i < lstArticles.Items.Count; i++)
                    {
                        if (listObjectArticle[i] is clsarticle)
                        {
                            //Article
                            clsMetier.GetInstance().insertClspaiementforetatpaiement(new clsarticle(), listIdArticle[i], clsMetier.GetInstance().getClssortie(listIdArticle[i]).Etatpaiement);
                            txtId_sortie.Text = listIdArticle[i].ToString();
                        }
                        else if (listObjectArticle[i] is clsoperation_laboratoire)
                        {
                            //Laboratoire
                            clsMetier.GetInstance().insertClspaiementforetatpaiement(new clsoperation_laboratoire(), listIdArticle[i], clsMetier.GetInstance().getClsoperation_laboratoire(listIdArticle[i]).Etatpaiement);
                            txtId_operation_laboratoire.Text = listIdArticle[i].ToString();
                        }
                        else if (listObjectArticle[i] is clstarifconsultationpostnatal)
                        {
                            //CPOS
                            clsMetier.GetInstance().insertClspaiementforetatpaiement(new clstarifconsultationpostnatal(), listIdArticle[i], clsMetier.GetInstance().getClsdossierconsultationpostnatale(listIdArticle[i]).Etatpaiement);
                            txtId_dossierconsultationpostnatal.Text = listIdArticle[i].ToString();
                        }
                        else if (listObjectArticle[i] is clstarifconsultationprenatal)
                        {
                            //CPN
                            clsMetier.GetInstance().insertClspaiementforetatpaiement(new clstarifconsultationprenatal(), listIdArticle[i], clsMetier.GetInstance().getClsdossierconsultationprenatale(listIdArticle[i]).Etatpaiement);
                            txtId_dossierconsultationprenatale.Text = listIdArticle[i].ToString();
                        }
                        else if (listObjectArticle[i] is clstarifconsultation)
                        {
                            //Consultation
                            clsMetier.GetInstance().insertClspaiementforetatpaiement(new clstarifconsultation(), listIdArticle[i], clsMetier.GetInstance().getClsconsultation(listIdArticle[i]).Etatpaiement);
                            txtId_consultation.Text = listIdArticle[i].ToString();
                        }
                        else if (listObjectArticle[i] is clstarifpreconsultation)
                        {
                            //Preconsultation
                            clsMetier.GetInstance().insertClspaiementforetatpaiement(new clstarifpreconsultation(), listIdArticle[i], clsMetier.GetInstance().getClsdossierpreconsultation(listIdArticle[i]).Etatpaiement);
                            txtId_preconsultation.Text = listIdArticle[i].ToString();
                        }
                        else if (listObjectArticle[i] is clstarifconsultationgynecologique)
                        {
                            //Consultation gynecologique
                            clsMetier.GetInstance().insertClspaiementforetatpaiement(new clstarifconsultationgynecologique(), listIdArticle[i], clsMetier.GetInstance().getClsdossierconsultationgynecologique(listIdArticle[i]).Etatpaiement);
                            txtId_consultationGyn.Text = listIdArticle[i].ToString();
                        }
                        else if (listObjectArticle[i] is clsintervention)
                        {
                            //Intervention
                            clsMetier.GetInstance().insertClspaiementforetatpaiement(new clsintervention(), listIdArticle[i], clsMetier.GetInstance().getClssubit(listIdArticle[i]).Etatpaiement);
                            txtId_subit.Text = listIdArticle[i].ToString();
                        }
                        else if (listObjectArticle[i] is clschambre)
                        {
                            //Chambre
                            clsMetier.GetInstance().insertClspaiementforetatpaiement(new clschambre(), listIdArticle[i], clsMetier.GetInstance().getClshospitalisation(listIdArticle[i]).Etatpaiement);
                            txtId_hospitalisation.Text = listIdArticle[i].ToString();
                        }
                        //else if (listObjectArticle[i] is clsautrefraie)
                        //{
                        //    //Autres Frais
                        //    clsMetier.GetInstance().insertClspaiementforetatpaiement(new clsautrefraie(), listIdArticle[i], clsMetier.GetInstance().getClsautrefraie(listIdArticle[i]).Etatpaiement);
                        //    txtId_autrefraie.Text = listIdArticle[i].ToString();
                        //}
                        else if (listObjectArticle[i] is clsdetailsautrefraie)
                        {
                            //Autres Frais
                            clsautrefraie ObjEtaPaiement_IdAutrefraie = clsMetier.GetInstance().getClsautrefraie2(listIdArticle[i]);

                            clsMetier.GetInstance().insertClspaiementforetatpaiement(new clsdetailsautrefraie(), listIdArticle[i], ObjEtaPaiement_IdAutrefraie.Etatpaiement);
                            txtId_autrefraie.Text = ObjEtaPaiement_IdAutrefraie.Id.ToString();//listIdArticle[i].ToString();
                        }
                        else if (listObjectArticle[i] is clstypeaccouchement)
                        {
                            //Type accouchement
                            clsMetier.GetInstance().insertClspaiementforetatpaiement(new clstypeaccouchement(), listIdArticle[i], clsMetier.GetInstance().getClsdossierconsultationaccouchement(listIdArticle[i]).Etatpaiement);
                            txtId_accouchement.Text = listIdArticle[i].ToString();
                        }
                        else if (listObjectArticle[i] is clstarifechographie)
                        {
                            //Echographie
                            clsMetier.GetInstance().insertClspaiementforetatpaiement(new clstarifechographie(), listIdArticle[i], clsMetier.GetInstance().getClsdossierechographie(listIdArticle[i]).Etatpaiement);
                            txtId_dossierechographie.Text = listIdArticle[i].ToString();
                        }
                        else if (listObjectArticle[i] is clstarifsoin)
                        {
                            //Soins
                            clsMetier.GetInstance().insertClspaiementforetatpaiement(new clstarifsoin(), listIdArticle[i], clsMetier.GetInstance().getClsdossiersoin(listIdArticle[i]).Etatpaiement);
                            txtId_dossiersoins.Text = listIdArticle[i].ToString();
                        }
                        else if (listObjectArticle[i] is clstarifnursing)
                        {
                            //Nursing
                            clsMetier.GetInstance().insertClspaiementforetatpaiement(new clstarifnursing(), listIdArticle[i], clsMetier.GetInstance().getClsdossiernursing(listIdArticle[i]).Etatpaiement);
                            txtId_dossiernursing.Text = listIdArticle[i].ToString();
                        }
                    }
                    #endregion

                    if (string.IsNullOrEmpty(txtMontantPaye.Text)) dblMontantPaye = 0;
                    else dblMontantPaye = Convert.ToDouble(txtMontantPaye.Text);
                    if (string.IsNullOrEmpty(txtMontantMituelle.Text)) dblMontantMituelle = 0;
                    else dblMontantMituelle = Convert.ToDouble(txtMontantMituelle.Text);
                    if (string.IsNullOrEmpty(txtGetDette.Text)) dblMontantDette = 0;
                    else dblMontantDette = Convert.ToDouble(txtGetDette.Text);
                    if (string.IsNullOrEmpty(txtMontantAvance.Text)) dblMontantAvance = 0;
                    else dblMontantAvance = Convert.ToDouble(txtMontantAvance.Text);
                    txtId_DuMalade.Text = malade.Id.ToString();
                    paiement.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Enregistrement des valeurs des articles avec leurs détails pour un éventuel retrouvaille lors 
                    //de la sélection d'un item du Dgv des paiements
                    int idFactureTemp = clsMetier.GetInstance().generateIdFacture();
                    if (idFactureTemp == 1) facturation.Numero_facture = 1;
                    else if (idFactureTemp > 1) facturation.Numero_facture = clsMetier.GetInstance().generateIdFacture2();

                    for (int i = 0; i < lstArticles.Items.Count; i++)
                    {
                        article_paye.Id_article = listIdArticle[i];
                        article_paye.Designation = listGetArticleDesignation[i];//lstArticles.Items[i].ToString();
                        article_paye.Designation_classe = listObjectArticle[i].GetType().Name;
                        if (listObjectArticle[i].GetType().Name.Equals("clsarticle")) facturation.Ismedicament = true;
                        else facturation.Ismedicament = false;
                        if (listObjectArticle[i].GetType().Name.Equals("clsoperation_laboratoire")) facturation.Isexamen = true;
                        else facturation.Isexamen = false;
                        article_paye.inserts();

                        //Insertions dans la table facturation
                        //On commence par donner une valeur au champ designation_service qui servira à afficher le nom
                        //du service pour une marmaille des produits consommés (Cfr Formulaire Tarifs pour les rubriques des onglets)

                        if (listObjectArticle[i].GetType().Name.Equals("clstarifconsultation")) facturation.Designation_service = "Consultation";
                        else if (listObjectArticle[i].GetType().Name.Equals("clstarifconsultationgynecologique")) facturation.Designation_service = "Consultation gynécologique";
                        else if (listObjectArticle[i].GetType().Name.Equals("clstarifconsultationpostnatal")) facturation.Designation_service = "CPOS";
                        else if (listObjectArticle[i].GetType().Name.Equals("clstarifconsultationprenatal")) facturation.Designation_service = "CPN";
                        else if (listObjectArticle[i].GetType().Name.Equals("clstarifechographie")) facturation.Designation_service = "Echographie";
                        else if (listObjectArticle[i].GetType().Name.Equals("clstarifnursing")) facturation.Designation_service = "Nursing";
                        else if (listObjectArticle[i].GetType().Name.Equals("clstarifpreconsultation")) facturation.Designation_service = "Fiche";
                        else if (listObjectArticle[i].GetType().Name.Equals("clstarifsoin")) facturation.Designation_service = "Soins";
                        else if (listObjectArticle[i].GetType().Name.Equals("clsintervention")) facturation.Designation_service = "Intervention";
                        else if (listObjectArticle[i].GetType().Name.Equals("clsarticle")) facturation.Designation_service = "Article";
                        else if (listObjectArticle[i].GetType().Name.Equals("clschambre")) facturation.Designation_service = "Catégorie chambre";
                        else if (listObjectArticle[i].GetType().Name.Equals("clstypeaccouchement")) facturation.Designation_service = "Type accouchement";
                        else if (listObjectArticle[i].GetType().Name.Equals("clsdetailsautrefraie")) facturation.Designation_service = "Autres frais";
                        else if (listObjectArticle[i].GetType().Name.Equals("clsoperation_laboratoire")) facturation.Designation_service = "Laboratoire";

                        facturation.Id = listIdArticle[i];
                        facturation.Id_article = listIdArticle[i];
                        facturation.Id_malade = malade.Id;
                        string[] tb1 = listGetArticleDesignation[i].Split('=');//lstArticles.Items[i].ToString().Split('=');
                        string[] tb2 = tb1[1].ToString().Split('>');
                        string[] tb3 = tb2[1].ToString().Split(' ');
                        facturation.Designation = tb1[0].ToString();
                        facturation.Pu = Convert.ToDouble(tb3[0]);
                        facturation.Quantite = listQteArticle[i];
                        facturation.Montantmituelle = dblMontantMituelle;
                        facturation.Montantpaye = dblMontantPaye;
                        facturation.Dette = dblMontantDette;
                        facturation.Avance = dblMontantAvance;
                        facturation.Date = dateFacturation;//txtDate.Value;
                        facturation.Id_paiement = clsMetier.id_du_paiement;
                        facturation.Ispaiementmalade = true;
                        facturation.inserts();
                    }

                    dblMontantPaye = 0;
                    dblMontantMituelle = 0;
                    dblMontantDette = 0;
                    dblMontantAvance = 0;

                    refresh();
                    int t = lstArticles.Items.Count;
                    try
                    {
                        for (int f = 0; f < t; f++) lstArticles.Items.Remove(lstArticles.Items[0]);
                    }
                    catch (Exception) { }
                }
                else
                {
                    //Pour une modification du paiement on ne change pas les valeurs mise à jour pour les différents tarifs
                    if (bsrc.DataSource != null)
                    {
                        clspaiement s = (clspaiement)bsrc.Current;
                        new clspaiement().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Actualisation en exécutant le code dou double clic du DataGrid

                #region Remplissage de la liste des malades (Remplace le selection change du DataGrid)
                try
                {
                    //Réinitialisation des valeurs contenant le montant et les Id pour paiement
                    listIdArticle.Clear();
                    listMontantArticle.Clear();
                    txtMontantDu.Clear();
                    //Réinitialisation du montant total
                    montantdu = 0;
                    //lstArticles.Items.Clear();
                    if (lstArticles.Items.Count > 0)
                    {
                        lstArticles.DataSource = null;
                        blnDataSourceDefine = true;
                    }

                    if (tabPaiement.SelectedIndex == 0)
                    {
                        if (categorie_malade.Equals("Non abonné"))
                        {
                            rdMituelle.Checked = false;
                            rdMituelle.Enabled = false;
                        }
                        else
                        {
                            rdMituelle.Enabled = true;
                        }
                        if (rdMalade.Checked == false && rdMituelle.Checked == false)
                        {
                            MessageBox.Show("Veuillez séléctionner une rubrique svp", "Affichage des paiements", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgv.Enabled = false;
                            dgv1.Enabled = false;
                        }
                        else if ((categorie_malade.Equals("Abonné") && rdMalade.Checked == true) || categorie_malade.Equals("Non abonné"))
                        {
                            dgv.Enabled = true;
                            dgv1.Enabled = true;

                            #region Chargement paiement pour malade

                            try
                            {
                                //bindingcls();
                                if ((categorie_malade.Equals("Abonné") && rdMalade.Checked == true) || categorie_malade.Equals("Non abonné"))
                                {
                                    bsrc.DataSource = clsMetier.GetInstance().getAllClspaiement(malade.Id);
                                    bsrc1.DataSource = clsMetier.GetInstance().getAllClspaiement1(malade.Id);

                                    dgv.DataSource = bsrc;
                                    dgv1.DataSource = bsrc1;

                                    #region Chargement des tarifs pour les produits consomés par le malade
                                    try
                                    {
                                        lstTarifConsultation.DataSource = clsMetier.GetInstance().getAllClsconsultationtarifpaiement(malade.Id);
                                        lstChambreOccupe.DataSource = clsMetier.GetInstance().getAllClschambretarifpaiement(malade.Id);
                                        lstIntervention.DataSource = clsMetier.GetInstance().getAllClstarifinterventionpaiement(malade.Id);
                                        lstMedicament.DataSource = clsMetier.GetInstance().getAllClsmedicamenttarifpaiement(malade.Id);
                                        lstconsultationgynecologique.DataSource = clsMetier.GetInstance().getAllClsconsultationgynecologiquetarifpaiement(malade.Id);
                                        lstCPN.DataSource = clsMetier.GetInstance().getAllCltarifconsultationprenataltarifpaiement(malade.Id);
                                        lstCPOS.DataSource = clsMetier.GetInstance().getAllClstarifconsultationpostnataltarifpaiement(malade.Id);
                                        lstLaboratoire.DataSource = clsMetier.GetInstance().getAllClsoperation_laboratoiretarifpaiement(malade.Id);
                                        lstPreconsultation.DataSource = clsMetier.GetInstance().getAllClspreconsultationtarifpaiement(malade.Id);
                                        lstAutresFrais.DataSource = clsMetier.GetInstance().getAllClstarifautrespaiement(malade.Id);
                                        lstTypeAccouchement.DataSource = clsMetier.GetInstance().getAllClstypeaccouchementPaiement(malade.Id);
                                        lstEchographie.DataSource = clsMetier.GetInstance().getAllCltarifechographietarifpaiement(malade.Id);
                                        lstSoins.DataSource = clsMetier.GetInstance().getAllClstarifsointarifpaiement(malade.Id);
                                        lstNursing.DataSource = clsMetier.GetInstance().getAllClstarifnursingtarifpaiement(malade.Id);
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Erreur de chargement de la liste des tarifs", "Erreur de Chargement");
                                    }

                                    try
                                    {
                                        ActivateListItems(lstIntervention);
                                        ActivateListItems(lstChambreOccupe);
                                        ActivateListItems(lstTarifConsultation);
                                        ActivateListItems(lstMedicament);
                                        ActivateListItems(lstconsultationgynecologique);
                                        ActivateListItems(lstLaboratoire);
                                        ActivateListItems(lstCPOS);
                                        ActivateListItems(lstCPN);
                                        ActivateListItems(lstPreconsultation);
                                        ActivateListItems(lstAutresFrais);
                                        ActivateListItems(lstTypeAccouchement);

                                        ActivateListItems(lstEchographie);
                                        ActivateListItems(lstSoins);
                                        ActivateListItems(lstNursing);
                                    }
                                    catch (Exception) { }
                                    #endregion Fin Chargement des tarifs pour les produits consomés par le malade

                                    #region Recalculage du sous total
                                    try
                                    {
                                        lblSousTotChambre.Text = recalculateSoustotal(lstChambreOccupe).ToString();
                                        lblSousTotIntervention.Text = recalculateSoustotal(lstIntervention).ToString();
                                        lblSousTotConsultation.Text = recalculateSoustotal(lstTarifConsultation).ToString();
                                        lblsoustotalgynecologique.Text = recalculateSoustotal(lstconsultationgynecologique).ToString();
                                        lblSousTotMedicament.Text = recalculateSoustotal(lstMedicament).ToString();
                                        lblSousTotLaboratoire.Text = recalculateSoustotal(lstLaboratoire).ToString();
                                        lblSousTotCPOS.Text = recalculateSoustotal(lstCPOS).ToString();
                                        lblSousTotCPN.Text = recalculateSoustotal(lstCPN).ToString();
                                        lblSousTotPreconsultation.Text = recalculateSoustotal(lstPreconsultation).ToString();
                                        lblSousTotAutresFrais.Text = recalculateSoustotal(lstAutresFrais).ToString();
                                        lblSousTotTypeAccouchement.Text = recalculateSoustotal(lstTypeAccouchement).ToString();
                                        lblSousTotEchographie.Text = recalculateSoustotal(lstEchographie).ToString();
                                        lblSousTotSoins.Text = recalculateSoustotal(lstSoins).ToString();
                                        lblSousTotNursing.Text = recalculateSoustotal(lstNursing).ToString();

                                        //Calcul du montant du en faisant la somme des tous les sous totaux
                                        if (!categorie_malade.Equals("Abonné") || categorie_malade.Equals("Abonné") && (Convert.ToDouble(((clspaiement)(clsMetier.GetInstance().getClspaiement2(identifiantMalade))).Dette) == 0))
                                        {
                                            montantdu = (((Convert.ToDouble(lblSousTotChambre.Text)) +
                                                        (Convert.ToDouble(lblSousTotIntervention.Text)) +
                                                        (Convert.ToDouble(lblSousTotConsultation.Text)) +
                                                        (Convert.ToDouble(lblSousTotMedicament.Text)) +
                                                        (Convert.ToDouble(lblSousTotLaboratoire.Text)) +
                                                        (Convert.ToDouble(lblSousTotCPOS.Text)) +
                                                        (Convert.ToDouble(lblSousTotCPN.Text)) +
                                                        (Convert.ToDouble(lblsoustotalgynecologique.Text)) +
                                                        (Convert.ToDouble(lblSousTotPreconsultation.Text)) +
                                                        (Convert.ToDouble(lblSousTotAutresFrais.Text)) +
                                                        (Convert.ToDouble(lblSousTotEchographie.Text)) +
                                                        (Convert.ToDouble(lblSousTotSoins.Text)) +
                                                        (Convert.ToDouble(lblSousTotNursing.Text)) +
                                                        (Convert.ToDouble(lblSousTotTypeAccouchement.Text))) * taux);

                                            txtMontantDu.Text = Math.Round(montantdu, 2).ToString();
                                            totMontantDu = montantdu;
                                            txtMontantPaye.Text = txtMontantDu.Text;
                                        }
                                        else
                                        {
                                            montantdu = Convert.ToDouble(((clspaiement)(clsMetier.GetInstance().getClspaiement2(identifiantMalade))).Montantdu);
                                            txtMontantDu.Text = Math.Round(montantdu, 2).ToString();
                                            totMontantDu = montantdu;
                                        }

                                        //Recalculage des valeur pour mituel et malade abonne
                                        if (categorie_malade.Equals("Abonné"))
                                        {
                                            if (dgv.RowCount > 0)
                                            {
                                                montantMituel = (clsMetier.GetInstance().getClsetablissementpriseencharge(identifiantMalade).Taux) * ((clspaiement)dgv.SelectedRows[0].DataBoundItem).Montantdu;
                                                txtMontantMituelle.Text = Math.Round(montantMituel, 2).ToString();
                                                montantClient = ((clspaiement)dgv.SelectedRows[0].DataBoundItem).Montantdu - montantMituel;
                                                oldMontantDette = Math.Round((montantClient - clsMetier.GetInstance().getTotmontantpaiement(identifiantMalade)), 2);
                                                txtMontantDetteRestante.Text = oldMontantDette.ToString();
                                            }
                                            else
                                            {
                                                montantMituel = (clsMetier.GetInstance().getClsetablissementpriseencharge(identifiantMalade).Taux) * montantdu;
                                                txtMontantMituelle.Text = Math.Round(montantMituel, 2).ToString();
                                                montantClient = montantdu - montantMituel;
                                                oldMontantDette = Math.Round((montantClient - clsMetier.GetInstance().getTotmontantpaiement(identifiantMalade)), 2);
                                                txtMontantDetteRestante.Text = oldMontantDette.ToString();
                                            }
                                            //chkAvance.Enabled = true;
                                            //txtMontantAvance.Enabled = true;
                                            //txtMontantAvance.Text = "0";
                                            txtMontantClient.Text = Math.Round(montantClient, 2).ToString();
                                        }
                                        else
                                        {
                                            gpAvance.Enabled = false;
                                            //chkAvance.Enabled = false;
                                            //chkAvance.Checked = false;
                                            txtMontantMituelle.Clear();
                                            txtMontantClient.Clear();
                                            txtMontantDette.Clear();
                                            txtMontantDetteRestante.Clear();
                                        }

                                        //S'il n'ya pas d'enregistrement de paiement pour le malade sélectionné, on vide le datagridview
                                        filDgvPaiement();
                                    }
                                    catch (Exception) { MessageBox.Show("Erreur lors du calcul du sous total", "Calcul du sous total d'une rubrique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                                    #endregion Fin Recalculage du sous total

                                }
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message + " >>>> Erreur lors du chargement des paiements du malade", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                            #endregion Fin chargement paiemnt pour malade
                        }
                        else if (categorie_malade.Equals("Abonné") && rdMituelle.Checked == true)
                        {
                            dgv.Enabled = true;
                            dgv1.Enabled = true;

                            #region Chargement paiment pour mituelle
                            montant_mituel = Math.Round(clsMetier.GetInstance().getMontantMituellepaiement(malade.Id), 2);
                            txtMontantDu.Text = montant_mituel.ToString();
                            oldMontantDette = Math.Round((montant_mituel - clsMetier.GetInstance().getTotmontantpaiement1(identifiantMalade)), 2);
                            txtMontantPaye.Text = "0";

                            #endregion Fin chargement paiement pour mituelle

                            try
                            {
                                bsrc2.DataSource = clsMetier.GetInstance().getAllClspaiement1(malade.Id);
                                bsrc1.DataSource = clsMetier.GetInstance().getAllClspaiement2(malade.Id);

                                dgv.DataSource = bsrc2;
                                dgv1.DataSource = bsrc1;

                                filDgvPaiement1();
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message + " >>>> Erreur lors du chargement des paiements du malade", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                        }
                    }
                }
                catch (Exception) { }
                #endregion Fin Remplissage de la liste des malades

                #endregion Fin paiement malade
            }
            else if (rdMituelle.Checked == true)
            {
                #region Paiement mituelle
                if (!bln1)
                {
                    if (string.IsNullOrEmpty(txtMontantPaye.Text)) dblMontantPaye = 0;
                    else dblMontantPaye = Convert.ToDouble(txtMontantPaye.Text);
                    if (string.IsNullOrEmpty(txtMontantMituelle.Text)) dblMontantMituelle = 0;
                    else dblMontantMituelle = Convert.ToDouble(txtMontantMituelle.Text);
                    if (string.IsNullOrEmpty(txtGetDette.Text)) dblMontantDette = 0;
                    else dblMontantDette = Convert.ToDouble(txtGetDette.Text);
                    if (string.IsNullOrEmpty(txtMontantAvance.Text)) dblMontantAvance = 0;
                    else dblMontantAvance = Convert.ToDouble(txtMontantAvance.Text);

                    paiement.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Enregistrement des valeurs des articles avec leurs détails pour un éventuel retrouvaille lors 
                    //de la sélection d'un item du Dgv des paiements
                    int idFactureTemp = clsMetier.GetInstance().generateIdFacture();
                    if (idFactureTemp == 1) facturation.Numero_facture = 1;
                    else if (idFactureTemp > 1) facturation.Numero_facture = clsMetier.GetInstance().generateIdFacture2();

                    //Insertions dans la table facturation_mituelle
                    facturation.Id = clsMetier.GetInstance().getIdfromtable("facturation");
                    facturation.Id_malade = malade.Id;
                    facturation.Montantmituelle = dblMontantPaye;
                    facturation.Dette = dblMontantDette;
                    facturation.Avance = dblMontantAvance;
                    facturation.Date = txtDate.Value;
                    facturation.Id_paiement = clsMetier.id_du_paiement;

                    //Valeurs
                    facturation.Pu = 0;
                    facturation.Quantite = 0;
                    facturation.Solde = false;
                    facturation.Soldemituelle = false;
                    facturation.Montantpaye = 0;
                    facturation.Id_article = -1;
                    facturation.Id_article_f = -1;
                    facturation.Ismedicament = false;
                    facturation.Isexamen = false;
                    facturation.Ispaiementmalade = false;
                    facturation.Designation = "Paiement mituelle";
                    facturation.inserts();

                    dblMontantPaye = 0;
                    dblMontantDette = 0;
                    dblMontantAvance = 0;

                    refresh();
                }
                else
                {
                    //Pour une modification du paiement on ne change pas les valeurs mise à jour pour les différents tarifs
                    if (bsrc2.DataSource != null)
                    {
                        clspaiement s = (clspaiement)bsrc.Current;
                        new clspaiement().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                #endregion Fin paiement mituelle
            }
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        //Methode permettant de verifier l'existance ou non d'un item dans la liste des articles consomés
        //pour y ajouter l'item selectione ou non
        private void VerifieExistItemList(Control ctrl, bool isAutreFraie)
        {
            ////Si on a choisi dans la liste des medicaments
            if (((ListBox)ctrl).Name.Equals("lstChambreOccupe"))
            {
                clschambre objclschambre = new clschambre();
                if (lstArticles.Items.Count == 0)
                {
                    string[] tab1 = (((ListBox)ctrl).SelectedItem).ToString().Split('>');
                    string[] tab2 = tab1[1].Split(' ');
                    string[] tab3 = tab1[0].Split('=');
                    string designation = tab3[0].ToString() + "=>" + tab2[0].ToString() + " $US";
                    lstArticles.Items.Add(designation);
                    listGetArticleDesignation.Add(designation);
                    listIdArticle.Add(((clschambre)lstChambreOccupe.SelectedItem).Id_de_hospitalisation);
                    listObjectArticle.Add(objclschambre);
                    int nbrJr = Convert.ToInt32(((clschambre)lstChambreOccupe.SelectedItem).Nbrjour);
                    listQteArticle.Add(nbrJr);
                    listMontantArticle.Add(((clschambre)lstChambreOccupe.SelectedItem).Prix_de_chambre * Convert.ToDouble(nbrJr));
                }
                else
                {
                    for (int i = 0; i < lstArticles.Items.Count; i++)
                    {
                        string[] tab0 = new string[2];
                        tab0 = lstArticles.Items[i].ToString().Split('>');
                        //---------------------
                        string[] tab1 = (((ListBox)ctrl).SelectedItem).ToString().Split('>');
                        string[] tab2 = tab1[1].Split(' ');
                        string[] tab3 = tab1[0].Split('=');
                        string designation = tab3[0].ToString() + "=>" + tab2[0].ToString() + " $US";

                        if (listIdArticle[i] == ((clschambre)lstChambreOccupe.SelectedItem).Id_de_hospitalisation && listObjectArticle[i] is clschambre)
                        {
                            break;
                        }
                        if (i == lstArticles.Items.Count - 1)
                        {
                            string[] tb1 = (((ListBox)ctrl).SelectedItem).ToString().Split('>');
                            string[] tb2 = tb1[1].Split(' ');
                            string[] tb3 = tb1[0].Split('=');
                            string designation1 = tb3[0].ToString() + "=>" + tb2[0].ToString() + " $US";
                            lstArticles.Items.Add(designation1);
                            listGetArticleDesignation.Add(designation1);
                            listIdArticle.Add(((clschambre)lstChambreOccupe.SelectedItem).Id_de_hospitalisation);
                            listObjectArticle.Add(objclschambre);
                            int nbrJr = Convert.ToInt32(((clschambre)lstChambreOccupe.SelectedItem).Nbrjour);
                            listQteArticle.Add(nbrJr);
                            listMontantArticle.Add(((clschambre)lstChambreOccupe.SelectedItem).Prix_de_chambre * Convert.ToDouble(nbrJr));
                            break;
                        }
                    }
                }
            }
            else if (((ListBox)ctrl).Name.Equals("lstIntervention") ||
                ((ListBox)ctrl).Name.Equals("lstTarifConsultation") ||
                ((ListBox)ctrl).Name.Equals("lstCPN") ||
                ((ListBox)ctrl).Name.Equals("lstCPOS") ||
                ((ListBox)ctrl).Name.Equals("lstEchographie") ||
                ((ListBox)ctrl).Name.Equals("lstSoins") ||
                ((ListBox)ctrl).Name.Equals("lstNursing") ||
                ((ListBox)ctrl).Name.Equals("lstLaboratoire") ||
                ((ListBox)ctrl).Name.Equals("lstconsultationgynecologique") ||
                ((ListBox)ctrl).Name.Equals("lstPreconsultation") ||
                ((ListBox)ctrl).Name.Equals("lstTypeAccouchement"))
            {
                if (((ListBox)ctrl).Name.Equals("lstIntervention"))
                {
                    clsintervention objclsintervention = new clsintervention();
                    if (lstArticles.Items.Count == 0)
                    {
                        lstArticles.Items.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listIdArticle.Add(((clsintervention)lstIntervention.SelectedItem).Id_de_subit);
                        listObjectArticle.Add(objclsintervention);
                        listQteArticle.Add(1);
                        listMontantArticle.Add((double)((clsintervention)lstIntervention.SelectedItem).Prix);
                    }
                    else
                    {
                        for (int i = 0; i < lstArticles.Items.Count; i++)
                        {
                            if (listIdArticle[i] == ((clsintervention)lstIntervention.SelectedItem).Id_de_subit && listObjectArticle[i] is clsintervention)
                            {
                                break;
                            }
                            else
                            {
                                if (i == lstArticles.Items.Count - 1)
                                {
                                    lstArticles.Items.Add(((ListBox)ctrl).SelectedItem).ToString();

                                    //Chargement des liste pour montant et id
                                    if (((ListBox)ctrl).Name.Equals("lstIntervention"))
                                    {
                                        listIdArticle.Add(((clsintervention)lstIntervention.SelectedItem).Id_de_subit);
                                        listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                                        listObjectArticle.Add(objclsintervention);
                                        listQteArticle.Add(1);
                                        listMontantArticle.Add((double)((clsintervention)lstIntervention.SelectedItem).Prix);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (((ListBox)ctrl).Name.Equals("lstTarifConsultation"))
                {
                    clstarifconsultation objclstarifconsultation = new clstarifconsultation();
                    if (lstArticles.Items.Count == 0)
                    {
                        lstArticles.Items.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listIdArticle.Add(((clstarifconsultation)lstTarifConsultation.SelectedItem).Id_de_consultation);
                        listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listObjectArticle.Add(objclstarifconsultation);
                        listQteArticle.Add(1);
                        listMontantArticle.Add((double)((clstarifconsultation)lstTarifConsultation.SelectedItem).Montant);
                    }
                    else
                    {
                        for (int i = 0; i < lstArticles.Items.Count; i++)
                        {
                            if (listIdArticle[i] == ((clstarifconsultation)lstTarifConsultation.SelectedItem).Id_de_consultation && listObjectArticle[i] is clstarifconsultation)
                            {
                                break;
                            }
                            if (i == lstArticles.Items.Count - 1)
                            {
                                lstArticles.Items.Add(((ListBox)ctrl).SelectedItem).ToString();

                                //Chargement des liste pour montant et id
                                if (((ListBox)ctrl).Name.Equals("lstTarifConsultation"))
                                {
                                    listIdArticle.Add(((clstarifconsultation)lstTarifConsultation.SelectedItem).Id_de_consultation);
                                    listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                                    listObjectArticle.Add(objclstarifconsultation);
                                    listQteArticle.Add(1);
                                    listMontantArticle.Add((double)((clstarifconsultation)lstTarifConsultation.SelectedItem).Montant);
                                }
                                break;
                            }
                        }
                    }
                }
                else if (((ListBox)ctrl).Name.Equals("lstPreconsultation"))
                {
                    clstarifpreconsultation objclstarifpreconsultation = new clstarifpreconsultation();
                    if (lstArticles.Items.Count == 0)
                    {
                        lstArticles.Items.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listIdArticle.Add(((clstarifpreconsultation)lstPreconsultation.SelectedItem).Id_de_dossierpreconsultation);
                        listObjectArticle.Add(objclstarifpreconsultation);
                        listQteArticle.Add(1);
                        listMontantArticle.Add((double)((clstarifpreconsultation)lstPreconsultation.SelectedItem).Montant);
                    }
                    else
                    {
                        for (int i = 0; i < lstArticles.Items.Count; i++)
                        {
                            if (listIdArticle[i] == ((clstarifpreconsultation)lstPreconsultation.SelectedItem).Id_de_dossierpreconsultation && listObjectArticle[i] is clstarifpreconsultation)
                            {
                                break;
                            }
                            if (i == lstArticles.Items.Count - 1)
                            {
                                lstArticles.Items.Add(((ListBox)ctrl).SelectedItem).ToString();

                                //Chargement des liste pour montant et id
                                if (((ListBox)ctrl).Name.Equals("lstPreconsultation"))
                                {
                                    listIdArticle.Add(((clstarifpreconsultation)lstPreconsultation.SelectedItem).Id_de_dossierpreconsultation);
                                    listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                                    listObjectArticle.Add(objclstarifpreconsultation);
                                    listQteArticle.Add(1);
                                    listMontantArticle.Add((double)((clstarifpreconsultation)lstPreconsultation.SelectedItem).Montant);
                                }
                                break;
                            }
                        }
                    }
                }
                else if (((ListBox)ctrl).Name.Equals("lstconsultationgynecologique"))
                {
                    clstarifconsultationgynecologique objclstarifconsultationgynecologique = new clstarifconsultationgynecologique();
                    if (lstArticles.Items.Count == 0)
                    {
                        lstArticles.Items.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listIdArticle.Add(((clstarifconsultationgynecologique)lstconsultationgynecologique.SelectedItem).Id_de_dossierconsultationgynecologique);
                        listObjectArticle.Add(objclstarifconsultationgynecologique);
                        listQteArticle.Add(1);
                        listMontantArticle.Add((double)((clstarifconsultationgynecologique)lstconsultationgynecologique.SelectedItem).Montant);
                    }
                    else
                    {
                        for (int i = 0; i < lstArticles.Items.Count; i++)
                        {
                            if (listIdArticle[i] == ((clstarifconsultationgynecologique)lstconsultationgynecologique.SelectedItem).Id_de_dossierconsultationgynecologique && listObjectArticle[i] is clstarifconsultationgynecologique)
                            {
                                break;
                            }
                            if (i == lstArticles.Items.Count - 1)
                            {
                                lstArticles.Items.Add(((ListBox)ctrl).SelectedItem).ToString();

                                //Chargement des liste pour montant et id
                                if (((ListBox)ctrl).Name.Equals("lstconsultationgynecologique"))
                                {
                                    listIdArticle.Add(((clstarifconsultationgynecologique)lstconsultationgynecologique.SelectedItem).Id_de_dossierconsultationgynecologique);
                                    listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                                    listObjectArticle.Add(objclstarifconsultationgynecologique);
                                    listQteArticle.Add(1);
                                    listMontantArticle.Add((double)((clstarifconsultationgynecologique)lstconsultationgynecologique.SelectedItem).Montant);
                                }
                                break;
                            }
                        }
                    }
                }
                else if (((ListBox)ctrl).Name.Equals("lstCPN"))
                {
                    clstarifconsultationprenatal objclstarifconsultationprenatal = new clstarifconsultationprenatal();
                    if (lstArticles.Items.Count == 0)
                    {
                        lstArticles.Items.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listIdArticle.Add(((clstarifconsultationprenatal)lstCPN.SelectedItem).Id_de_dossierconsultationprenatale);
                        listObjectArticle.Add(objclstarifconsultationprenatal);
                        listQteArticle.Add(1);
                        listMontantArticle.Add((double)((clstarifconsultationprenatal)lstCPN.SelectedItem).Montant);
                    }
                    else
                    {
                        for (int i = 0; i < lstArticles.Items.Count; i++)
                        {
                            if (listIdArticle[i] == ((clstarifconsultationprenatal)lstCPN.SelectedItem).Id_de_dossierconsultationprenatale && listObjectArticle[i] is clstarifconsultationprenatal)
                            {
                                break;
                            }
                            if (i == lstArticles.Items.Count - 1)
                            {
                                lstArticles.Items.Add(((ListBox)ctrl).SelectedItem).ToString();

                                //Chargement des liste pour montant et id 
                                if (((ListBox)ctrl).Name.Equals("lstCPN"))
                                {
                                    listIdArticle.Add(((clstarifconsultationprenatal)lstCPN.SelectedItem).Id_de_dossierconsultationprenatale);
                                    listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                                    listObjectArticle.Add(objclstarifconsultationprenatal);
                                    listQteArticle.Add(1);
                                    listMontantArticle.Add((double)((clstarifconsultationprenatal)lstCPN.SelectedItem).Montant);
                                }
                                break;
                            }
                        }
                    }
                }
                else if (((ListBox)ctrl).Name.Equals("lstCPOS"))
                {
                    clstarifconsultationpostnatal objclstarifconsultationpostnatal = new clstarifconsultationpostnatal();
                    if (lstArticles.Items.Count == 0)
                    {
                        lstArticles.Items.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listIdArticle.Add(((clstarifconsultationpostnatal)lstCPOS.SelectedItem).Id_de_dossierconsultationpostnatal);
                        listObjectArticle.Add(objclstarifconsultationpostnatal);
                        listQteArticle.Add(1);
                        listMontantArticle.Add((double)((clstarifconsultationpostnatal)lstCPOS.SelectedItem).Montant);
                    }
                    else
                    {
                        for (int i = 0; i < lstArticles.Items.Count; i++)
                        {
                            if (listIdArticle[i] == ((clstarifconsultationpostnatal)lstCPOS.SelectedItem).Id_de_dossierconsultationpostnatal && listObjectArticle[i] is clstarifconsultationpostnatal)
                            {
                                break;
                            }
                            if (i == lstArticles.Items.Count - 1)
                            {
                                lstArticles.Items.Add(((ListBox)ctrl).SelectedItem).ToString();

                                //Chargement des liste pour montant et id
                                if (((ListBox)ctrl).Name.Equals("lstCPOS"))
                                {
                                    listIdArticle.Add(((clstarifconsultationpostnatal)lstCPOS.SelectedItem).Id_de_dossierconsultationpostnatal);
                                    listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                                    listObjectArticle.Add(objclstarifconsultationpostnatal);
                                    listQteArticle.Add(1);
                                    listMontantArticle.Add((double)((clstarifconsultationpostnatal)lstCPOS.SelectedItem).Montant);
                                }
                                break;
                            }
                        }
                    }
                }
                else if (((ListBox)ctrl).Name.Equals("lstSoins"))
                {
                    clstarifsoin objclstarifsoins = new clstarifsoin();
                    if (lstArticles.Items.Count == 0)
                    {
                        lstArticles.Items.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listIdArticle.Add(((clstarifsoin)lstSoins.SelectedItem).Id_de_dossiersoin);
                        listObjectArticle.Add(objclstarifsoins);
                        listQteArticle.Add(1);
                        listMontantArticle.Add((double)((clstarifsoin)lstSoins.SelectedItem).Montant);
                    }
                    else
                    {
                        for (int i = 0; i < lstArticles.Items.Count; i++)
                        {
                            if (listIdArticle[i] == ((clstarifsoin)lstSoins.SelectedItem).Id_de_dossiersoin && listObjectArticle[i] is clstarifsoin)
                            {
                                break;
                            }
                            if (i == lstArticles.Items.Count - 1)
                            {
                                lstArticles.Items.Add(((ListBox)ctrl).SelectedItem).ToString();

                                //Chargement des liste pour montant et id 
                                if (((ListBox)ctrl).Name.Equals("lstSoins"))
                                {
                                    listIdArticle.Add(((clstarifsoin)lstSoins.SelectedItem).Id_de_dossiersoin);
                                    listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                                    listObjectArticle.Add(objclstarifsoins);
                                    listQteArticle.Add(1);
                                    listMontantArticle.Add((double)((clstarifsoin)lstSoins.SelectedItem).Montant);
                                }
                                break;
                            }
                        }
                    }
                }
                else if (((ListBox)ctrl).Name.Equals("lstEchographie"))
                {
                    clstarifechographie objclstarifechographie = new clstarifechographie();
                    if (lstArticles.Items.Count == 0)
                    {
                        lstArticles.Items.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listIdArticle.Add(((clstarifechographie)lstEchographie.SelectedItem).Id_de_dossierechographie);
                        listObjectArticle.Add(objclstarifechographie);
                        listQteArticle.Add(1);
                        listMontantArticle.Add((double)((clstarifechographie)lstEchographie.SelectedItem).Montant);
                    }
                    else
                    {
                        for (int i = 0; i < lstArticles.Items.Count; i++)
                        {
                            if (listIdArticle[i] == ((clstarifechographie)lstEchographie.SelectedItem).Id_de_dossierechographie && listObjectArticle[i] is clstarifechographie)
                            {
                                break;
                            }
                            if (i == lstArticles.Items.Count - 1)
                            {
                                lstArticles.Items.Add(((ListBox)ctrl).SelectedItem).ToString();

                                //Chargement des liste pour montant et id
                                if (((ListBox)ctrl).Name.Equals("lstEchographie"))
                                {
                                    listIdArticle.Add(((clstarifechographie)lstEchographie.SelectedItem).Id_de_dossierechographie);
                                    listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                                    listObjectArticle.Add(objclstarifechographie);
                                    listQteArticle.Add(1);
                                    listMontantArticle.Add((double)((clstarifechographie)lstEchographie.SelectedItem).Montant);
                                }
                                break;
                            }
                        }
                    }
                }
                else if (((ListBox)ctrl).Name.Equals("lstNursing"))
                {
                    clstarifnursing objclstarifnursing = new clstarifnursing();
                    if (lstArticles.Items.Count == 0)
                    {
                        lstArticles.Items.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listIdArticle.Add(((clstarifnursing)lstNursing.SelectedItem).Id_de_dossiernursing);
                        listObjectArticle.Add(objclstarifnursing);
                        listQteArticle.Add(1);
                        listMontantArticle.Add((double)((clstarifnursing)lstNursing.SelectedItem).Montant);
                    }
                    else
                    {
                        for (int i = 0; i < lstArticles.Items.Count; i++)
                        {
                            if (listIdArticle[i] == ((clstarifnursing)lstNursing.SelectedItem).Id_de_dossiernursing && listObjectArticle[i] is clstarifnursing)
                            {
                                break;
                            }
                            if (i == lstArticles.Items.Count - 1)
                            {
                                lstArticles.Items.Add(((ListBox)ctrl).SelectedItem).ToString();

                                //Chargement des liste pour montant et id 
                                if (((ListBox)ctrl).Name.Equals("lstNursing"))
                                {
                                    listIdArticle.Add(((clstarifnursing)lstNursing.SelectedItem).Id_de_dossiernursing);
                                    listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                                    listObjectArticle.Add(objclstarifnursing);
                                    listQteArticle.Add(1);
                                    listMontantArticle.Add((double)((clstarifnursing)lstNursing.SelectedItem).Montant);
                                }
                                break;
                            }
                        }
                    }
                }
                else if (((ListBox)ctrl).Name.Equals("lstLaboratoire"))
                {
                    clsoperation_laboratoire objclsoperation_laboratoire = new clsoperation_laboratoire();
                    if (lstArticles.Items.Count == 0)
                    {
                        lstArticles.Items.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listIdArticle.Add(((clsoperation_laboratoire)lstLaboratoire.SelectedItem).Id);
                        listObjectArticle.Add(objclsoperation_laboratoire);
                        listQteArticle.Add(1);
                        listMontantArticle.Add((double)((clsoperation_laboratoire)lstLaboratoire.SelectedItem).Prix_de_laboratoire);
                    }
                    else
                    {
                        for (int i = 0; i < lstArticles.Items.Count; i++)
                        {
                            if (listIdArticle[i] == ((clsoperation_laboratoire)lstLaboratoire.SelectedItem).Id && listObjectArticle[i] is clsoperation_laboratoire)
                            {
                                break;
                            }
                            if (i == lstArticles.Items.Count - 1)
                            {
                                lstArticles.Items.Add(((ListBox)ctrl).SelectedItem).ToString();

                                //Chargement des liste pour montant et id
                                if (((ListBox)ctrl).Name.Equals("lstLaboratoire"))
                                {
                                    listIdArticle.Add(((clsoperation_laboratoire)lstLaboratoire.SelectedItem).Id);
                                    listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                                    listObjectArticle.Add(objclsoperation_laboratoire);
                                    listQteArticle.Add(1);
                                    listMontantArticle.Add((double)((clsoperation_laboratoire)lstLaboratoire.SelectedItem).Prix_de_laboratoire);
                                }
                                break;
                            }
                        }
                    }
                }
                else if (((ListBox)ctrl).Name.Equals("lstTypeAccouchement"))
                {
                    clstypeaccouchement objclsaccouchement = new clstypeaccouchement();
                    if (lstArticles.Items.Count == 0)
                    {
                        lstArticles.Items.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                        listIdArticle.Add(((clstypeaccouchement)lstTypeAccouchement.SelectedItem).Id_de_dossieraccouchement);
                        listObjectArticle.Add(objclsaccouchement);
                        listQteArticle.Add(1);
                        listMontantArticle.Add((double)((clstypeaccouchement)lstTypeAccouchement.SelectedItem).Prix);
                    }
                    else
                    {
                        for (int i = 0; i < lstArticles.Items.Count; i++)
                        {
                            if (listIdArticle[i] == ((clstypeaccouchement)lstTypeAccouchement.SelectedItem).Id_de_dossieraccouchement && listObjectArticle[i] is clstypeaccouchement)
                            {
                                break;
                            }
                            if (i == lstArticles.Items.Count - 1)
                            {
                                lstArticles.Items.Add(((ListBox)ctrl).SelectedItem).ToString();

                                //Chargement des liste pour montant et id
                                if (((ListBox)ctrl).Name.Equals("lstTypeAccouchement"))
                                {
                                    listIdArticle.Add(((clstypeaccouchement)lstTypeAccouchement.SelectedItem).Id_de_dossieraccouchement);
                                    listGetArticleDesignation.Add((((ListBox)ctrl).SelectedItem).ToString());
                                    listObjectArticle.Add(objclsaccouchement);
                                    listQteArticle.Add(1);
                                    listMontantArticle.Add((double)((clstypeaccouchement)lstTypeAccouchement.SelectedItem).Prix);
                                }
                                break;
                            }
                        }
                    }
                }
            }
            else if (((ListBox)ctrl).Name.Equals("lstMedicament"))
            {
                clsarticle objclsarticle = new clsarticle();
                if (lstArticles.Items.Count == 0)
                {
                    string[] tab1 = (((ListBox)ctrl).SelectedItem).ToString().Split('>');
                    string designation = tab1[1].ToString() + ">" + tab1[2].ToString();
                    lstArticles.Items.Add(designation);
                    listGetArticleDesignation.Add(designation);
                    listIdArticle.Add(((clsarticle)lstMedicament.SelectedItem).Id_de_sortie);
                    facturation.Id_article_f = ((clsarticle)lstMedicament.SelectedItem).Id;
                    listObjectArticle.Add(objclsarticle);
                    int qte = (int)((clsarticle)lstMedicament.SelectedItem).Quantite_de_sortie;
                    listQteArticle.Add(qte);
                    listMontantArticle.Add(((double)qte) * (double)((clsarticle)lstMedicament.SelectedItem).Pu);
                }
                else
                {
                    for (int i = 0; i < lstArticles.Items.Count; i++)
                    {
                        string[] tab1 = new string[2];
                        tab1 = lstArticles.Items[i].ToString().Split('>');
                        string[] tbTemp = ((ListBox)ctrl).SelectedItem.ToString().Split('>');

                        if (listIdArticle[i] == ((clsarticle)lstMedicament.SelectedItem).Id_de_sortie && listObjectArticle[i] is clsarticle)//(tbTemp[1].ToString() + ">" + tbTemp[2].ToString()).Equals(tab1[0] + ">" + tab1[1]))
                        {
                            break;
                        }
                        if (i == lstArticles.Items.Count - 1)
                        {
                            string[] tb = (((ListBox)ctrl).SelectedItem).ToString().Split('>');
                            lstArticles.Items.Add(tb[1].ToString() + ">" + tb[2].ToString());
                            listGetArticleDesignation.Add(tb[1].ToString() + ">" + tb[2].ToString());
                            listIdArticle.Add(((clsarticle)lstMedicament.SelectedItem).Id_de_sortie);
                            listObjectArticle.Add(objclsarticle);
                            int qte = (int)((clsarticle)lstMedicament.SelectedItem).Quantite_de_sortie;
                            listQteArticle.Add(qte);
                            listMontantArticle.Add(((double)qte) * (double)((clsarticle)lstMedicament.SelectedItem).Pu);
                            break;
                        }
                    }
                }
            }
            else if (((ListBox)ctrl).Name.Equals("lstAutresFrais"))
            {
                clsdetailsautrefraie objclsdetailsautresfrais = new clsdetailsautrefraie();
                if (lstArticles.Items.Count == 0)
                {
                    string[] tab1 = (((ListBox)ctrl).SelectedItem).ToString().Split('>');
                    string designation = tab1[1].ToString() + ">" + tab1[2].ToString();
                    lstArticles.Items.Add(designation);
                    listGetArticleDesignation.Add(designation);
                    listIdArticle.Add(((clsdetailsautrefraie)lstAutresFrais.SelectedItem).Id);
                    listObjectArticle.Add(objclsdetailsautresfrais);
                    int qte = (int)((clsdetailsautrefraie)lstAutresFrais.SelectedItem).Quantite_de_detailsautrefraie;
                    listQteArticle.Add(qte);
                    listMontantArticle.Add(((double)qte) * (double)((clsdetailsautrefraie)lstAutresFrais.SelectedItem).Prix);
                    is_AutreFrais = true;
                }
                else
                {
                    for (int i = 0; i < lstArticles.Items.Count; i++)
                    {
                        string[] tab1 = new string[2];
                        tab1 = lstArticles.Items[i].ToString().Split('>');
                        string[] tbTemp = ((ListBox)ctrl).SelectedItem.ToString().Split('>');

                        if (listIdArticle[i] == ((clsdetailsautrefraie)lstAutresFrais.SelectedItem).Id && listObjectArticle[i] is clsdetailsautrefraie)
                        {
                            break;
                        }
                        if (i == lstArticles.Items.Count - 1)
                        {
                            string[] tb = (((ListBox)ctrl).SelectedItem).ToString().Split('>');
                            lstArticles.Items.Add(tb[1].ToString() + ">" + tb[2].ToString());
                            listGetArticleDesignation.Add(tb[1].ToString() + ">" + tb[2].ToString());
                            listIdArticle.Add(((clsdetailsautrefraie)lstAutresFrais.SelectedItem).Id);
                            listObjectArticle.Add(objclsdetailsautresfrais);
                            int qte = (int)((clsdetailsautrefraie)lstAutresFrais.SelectedItem).Quantite_de_detailsautrefraie;
                            listQteArticle.Add(qte);
                            listMontantArticle.Add(((double)qte) * (double)((clsdetailsautrefraie)lstAutresFrais.SelectedItem).Prix);
                            is_AutreFrais = true;
                            break;
                        }
                    }
                }
            }

            if (isAutreFraie) CalculTarif_Autre_fraie(listMontantArticle);
            else CalculTarif(listMontantArticle);
        }

        //Methode permettant de recalculer le sous total pour une rubrique de la liste
        private double recalculateSoustotal(Control ctrl)
        {
            double result = 0;
            //Si on a au moin un item dans la liste on recalcule et dans le cas contraire on retourne 0
            if (((ListBox)ctrl).Items.Count > 0 && !((ListBox)ctrl).Name.Equals("lstMedicament") && !((ListBox)ctrl).Name.Equals("lstAutresFrais"))
            {
                result = 0;
                for (int i = 0; i < ((ListBox)ctrl).Items.Count; i++)
                {
                    string[] tab1 = new string[2];
                    string x = ((ListBox)ctrl).Items[i].ToString();
                    tab1 = x.Split('>');
                    string[] tabDesitarif = new string[1];
                    tabDesitarif = tab1[1].Split(' ');//Montant
                    result += Math.Round(Convert.ToDouble(tabDesitarif[0]), 2);//Montant correspondant au sous total
                }
            }
            else if (((ListBox)ctrl).Items.Count > 0 && (((ListBox)ctrl).Name.Equals("lstMedicament") || ((ListBox)ctrl).Name.Equals("lstAutresFrais")))
            {
                result = 0;
                for (int i = 0; i < ((ListBox)ctrl).Items.Count; i++)
                {
                    string[] tab1 = new string[3];
                    string[] tabQte = new string[1];
                    string[] tabMontant = new string[1];
                    string x = ((ListBox)ctrl).Items[i].ToString();
                    tab1 = x.Split('>');
                    tabQte = tab1[0].Split('=');//Quantité
                    tabMontant = tab1[2].Split(' ');//Montant unitaire ;
                    result += Math.Round((Convert.ToDouble(tabMontant[0]) * Convert.ToDouble(tabQte[0])), 2);//Montant unitaire * Quantité pour un produit
                }
            }
            if (((ListBox)ctrl).Items.Count > 0 && ((ListBox)ctrl).Name.Equals("lstChambreOccupe"))
            {
                result = 0;
                for (int i = 0; i < ((ListBox)ctrl).Items.Count; i++)
                {
                    string[] tab1 = new string[2];
                    string x = ((ListBox)ctrl).Items[i].ToString();
                    tab1 = x.Split('>');
                    string[] tabDesitarif = new string[1];
                    string[] tabNbrjour = new string[1];
                    tabDesitarif = tab1[1].Split(' ');//Montant
                    tabNbrjour = tab1[2].Split(' ');//Nombre des jours
                    result += Math.Round(Convert.ToDouble(tabDesitarif[0]) * Convert.ToDouble(tabNbrjour[0]), 2);//Montant correspondant au sous total
                }
            }
            return result;
        }

        private double CalculTarif(List<double> liste)
        {
            double montant = 0;
            foreach (double dbl in liste)
            {
                montant += dbl;
            }
            txtMontantDu.Text = (montant * taux).ToString();
            return montant * taux;
        }

        private double CalculTarif_Autre_fraie(List<double> liste)
        {
            double montant = 0;
            foreach (double dbl in liste)
            {
                montant += dbl;
            }
            txtMontantDu.Text = montant.ToString();
            return montant;
        }

        private void ActivateListItems(Control ctrl)
        {
            if (ctrl is ListBox)
            {
                //Deselectionne tous les items de la liste
                ((ListBox)ctrl).SelectedIndex = -1;
            }
        }

        private void filDgvPaiement()
        {
            if (Convert.ToInt32(((clspaiement)clsMetier.GetInstance().getClspaiement3(identifiantMalade)).Id) > 0)
            {
                dgv.DataSource = bsrc;
                //dgv.se
                foreach (DataGridViewColumn dgvc in dgv.Columns)
                {
                    if (dgvc.DataPropertyName.Equals("Id")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_malade")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_sortie")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierpreconsultation")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_consultation")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierconsultationprenatale")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierconsultationpostnatal")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierechographie")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossiersoin")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_operation_laboratoire")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_consultationgyn")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_hospitalisation")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_autrefraie")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_subit")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_accouchement")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierechographie")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossiersoin")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossiernursing")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Archive")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Mutuelle")) dgvc.Visible = false;
                }
            }
            else
            {
                dgv.DataSource = null;
                lstArticles.DataSource = null;
                blnDataSourceDefine = true;
            }

            if (Convert.ToInt32(((clspaiement)clsMetier.GetInstance().getClspaiement4(identifiantMalade)).Id) > 0)
            {
                dgv1.DataSource = bsrc1;
                foreach (DataGridViewColumn dgvc in dgv1.Columns)
                {
                    if (dgvc.DataPropertyName.Equals("Id")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_malade")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_sortie")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierpreconsultation")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_consultation")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierconsultationprenatale")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierconsultationpostnatal")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_operation_laboratoire")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_consultationgyn")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_hospitalisation")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_autrefraie")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_subit")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_accouchement")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierechographie")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossiersoin")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossiernursing")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Archive")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Mutuelle")) dgvc.Visible = false;
                }
            }
            else dgv1.DataSource = null;
        }

        private void filDgvPaiement1()
        {
            if (Convert.ToInt32(((clspaiement)clsMetier.GetInstance().getClspaiement5(identifiantMalade)).Id) > 0)
            {
                dgv.DataSource = bsrc2;
                foreach (DataGridViewColumn dgvc in dgv.Columns)
                {
                    if (dgvc.DataPropertyName.Equals("Id")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_malade")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_sortie")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierpreconsultation")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_consultation")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierconsultationprenatale")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierconsultationpostnatal")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierechographie")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossiersoin")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_operation_laboratoire")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_consultationgyn")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_hospitalisation")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_autrefraie")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_subit")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_accouchement")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_nursing")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Archive")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Mutuelle")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Montantmituelle")) dgvc.Visible = false;
                }
            }
            else
            {
                dgv.DataSource = null;
                lstArticles.DataSource = null;
                blnDataSourceDefine = true;
            }

            if (Convert.ToInt32(((clspaiement)clsMetier.GetInstance().getClspaiement6(identifiantMalade)).Id) > 0)
            {
                dgv1.DataSource = bsrc1;
                foreach (DataGridViewColumn dgvc in dgv1.Columns)
                {
                    if (dgvc.DataPropertyName.Equals("Id")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_malade")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_sortie")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierpreconsultation")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_consultation")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierconsultationprenatale")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_dossierconsultationpostnatal")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_operation_laboratoire")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_consultationgyn")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_hospitalisation")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_autrefraie")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_subit")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_accouchement")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Id_nursing")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Archive")) dgvc.Visible = false;
                    else if (dgvc.DataPropertyName.Equals("Mutuelle")) dgvc.Visible = false;
                }
            }
            else dgv1.DataSource = null;
        }

        private void lstIntervention_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateListItems(lstTarifConsultation);
                ActivateListItems(lstChambreOccupe);
                ActivateListItems(lstMedicament);
                ActivateListItems(lstCPOS);
                ActivateListItems(lstCPN);
                ActivateListItems(lstEchographie);
                ActivateListItems(lstSoins);
                ActivateListItems(lstconsultationgynecologique);
                ActivateListItems(lstLaboratoire);
                ActivateListItems(lstPreconsultation);
                ActivateListItems(lstAutresFrais);
                ActivateListItems(lstTypeAccouchement);
                ActivateListItems(lstNursing);
            }
            catch (Exception) { }
        }

        private void lstMedicament_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateListItems(lstIntervention);
                ActivateListItems(lstChambreOccupe);
                ActivateListItems(lstTarifConsultation);
                ActivateListItems(lstconsultationgynecologique);
                ActivateListItems(lstCPOS);
                ActivateListItems(lstCPN);
                ActivateListItems(lstEchographie);
                ActivateListItems(lstSoins);
                ActivateListItems(lstLaboratoire);
                ActivateListItems(lstPreconsultation);
                ActivateListItems(lstAutresFrais);
                ActivateListItems(lstTypeAccouchement);
                ActivateListItems(lstNursing);
            }
            catch (Exception) { }
        }

        private void lstTarifConsultation_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateListItems(lstIntervention);
                ActivateListItems(lstChambreOccupe);
                ActivateListItems(lstMedicament);
                ActivateListItems(lstCPOS);
                ActivateListItems(lstCPN);
                ActivateListItems(lstEchographie);
                ActivateListItems(lstSoins);
                ActivateListItems(lstLaboratoire);
                ActivateListItems(lstPreconsultation);
                ActivateListItems(lstAutresFrais);
                ActivateListItems(lstTypeAccouchement);
                ActivateListItems(lstconsultationgynecologique);
                ActivateListItems(lstNursing);

            }
            catch (Exception) { }
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            try
            {
                New();
                blnDataSourceDefine = false;
                //lstArticles.DataSource = null;
            }
            catch (Exception) { btEnregistrer.Enabled = false; }
        }

        private void btEnregistrer_Click(object sender, EventArgs e)
        {
            if ((rdMalade.Checked == false && rdMituelle.Checked == false))
            {
                MessageBox.Show("Vous n'avez sélectionné aucune rubrique svp", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (rdMalade.Checked == true)
            {
                #region Paiement pour malade
                try
                {
                    paiement.Mituelle = false;
                    double somTarif = (Convert.ToDouble(lblSousTotChambre.Text) + Convert.ToDouble(lblSousTotIntervention.Text) + Convert.ToDouble(lblSousTotConsultation.Text) + Convert.ToDouble(lblSousTotMedicament.Text) + Convert.ToDouble(lblSousTotLaboratoire.Text) + Convert.ToDouble(lblSousTotEchographie.Text) + Convert.ToDouble(lblSousTotSoins.Text) + Convert.ToDouble(lblSousTotNursing.Text) + Convert.ToDouble(lblSousTotCPOS.Text) + Convert.ToDouble(lblSousTotCPN.Text) + Convert.ToDouble(lblSousTotPreconsultation.Text)  + Convert.ToDouble(lblSousTotTypeAccouchement.Text)) * taux + Convert.ToDouble(lblSousTotAutresFrais.Text);

                    if (lstArticles.Items.Count != 0 || (lstArticles.Items.Count == 0 && somTarif == 0))
                    {
                        if (chkAvance.Checked == true)
                        {
                            #region Paiement avec avance
                            if (Convert.ToDouble(txtMontantAvance.Text) > Convert.ToDouble(txtMontantClient.Text)) MessageBox.Show("Le malade ne peut avancer plus que ce qu'il doit payer", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            else if (Convert.ToDouble(txtMontantAvance.Text) == Convert.ToDouble(txtMontantClient.Text))
                            {
                                if (Convert.ToDouble(txtMontantDu.Text) == (Convert.ToDouble(txtMontantClient.Text) + Convert.ToDouble(txtMontantMituelle.Text)))
                                {
                                    DialogResult msg = MessageBox.Show("Il ne s'agit plus d'une avance, mais le malade paye la totalité, voulez-vous continuer ?", "Mise à jour", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    if (msg == DialogResult.Yes)
                                    {
                                        #region Paiement abonné avec cas d'avance
                                        if (Convert.ToDouble(txtMontantPaye.Text) == Convert.ToDouble(txtMontantClient.Text) && Convert.ToDouble(txtMontantDu.Text) == (Convert.ToDouble(txtMontantClient.Text) + Convert.ToDouble(txtMontantMituelle.Text)))
                                        {
                                            commonSavePaiement();
                                        }
                                        else MessageBox.Show("Le montant que le malade doit ne correspond pas au montant réel et rassurez-vous que le montant du correspond au total réelement dû par le malade", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        #endregion Fin Paiement abonné
                                    }
                                    else MessageBox.Show("Aucune mise à jour n'a été éffectuée", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else MessageBox.Show("Aucune mise à jour n'a été éffectuée, vous devez absolument ajouter tous les articles consommés", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (Convert.ToDouble(txtMontantAvance.Text) < Convert.ToDouble(txtMontantClient.Text))
                            {
                                #region Paiement abonné avec avance obligatoire
                                //Effectuer le paiement en notifiant le reste de la dette
                                if (Convert.ToDouble(txtMontantDu.Text) == (Convert.ToDouble(txtMontantClient.Text) + Convert.ToDouble(txtMontantMituelle.Text)))
                                {
                                    commonSavePaiement();
                                }
                                else if ((lstArticles.Items.Count == 0 && somTarif == 0))
                                {
                                    if (Convert.ToDouble(txtMontantDette.Text) < 0) MessageBox.Show("Aucune mise à jour n'a été éffectuée, le malade ne peut payer plus que ce qu'il doit", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    else if (Convert.ToDouble(txtMontantDette.Text) > 0)
                                    {
                                        //On fait une insertion d'un nouveau paiement tout en diminuant la dette du malade
                                        paiement.inserts();
                                    }
                                    else if (Convert.ToDouble(txtMontantDette.Text) == 0)
                                    {
                                        //On fait une insertion d'un nouveau paiement tout en diminuant la dette du malade
                                        paiement.inserts();
                                        MessageBox.Show("Le malade a fini sa dette", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else MessageBox.Show("Aucune mise à jour n'a été éffectuée, vous devez absolument ajouter tous les articles consommés", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                #endregion Fin Paiement abonné avec avec avance obligatoire
                            }
                            #endregion Fin Paiement avec avance
                        }
                        else
                        {
                            #region Paiement Sans avance
                            if (categorie_malade.Equals("Abonné"))
                            {
                                #region Paiement abonné
                                if (Convert.ToDouble(txtMontantPaye.Text) == Convert.ToDouble(txtMontantClient.Text))
                                {
                                    commonSavePaiement();
                                }
                                else if (Convert.ToDouble(txtMontantPaye.Text) == (Convert.ToDouble(txtMontantClient.Text) + Convert.ToDouble(txtMontantMituelle.Text)))
                                {
                                    commonSavePaiement();
                                }
                                else
                                {
                                    if (Convert.ToDouble(txtMontantDu.Text) == Convert.ToDouble(txtMontantPaye.Text) && Convert.ToDouble(txtMontantDu.Text) < totMontantDu)
                                    {
                                        DialogResult msg = MessageBox.Show("Le montant que le malade doit ne correspond pas au montant global réel, voulez-vous continuer pour une partie à payer sans avancer ?", "Mise à jour", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (msg == DialogResult.Yes)
                                        {
                                            commonSavePaiement();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Paiement non éffectué", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else MessageBox.Show("Le montatnt dû et celui à payer ne correspondent pas", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                #endregion Fin Paiement abonné
                            }
                            else if (categorie_malade.Equals("Non abonné"))
                            {
                                #region Paiement non abonné
                                if (Convert.ToDouble(txtMontantDu.Text) == Convert.ToDouble(txtMontantPaye.Text))
                                {
                                    commonSavePaiement();
                                }
                                else MessageBox.Show("Les montant dû et à payer ne correspondent pas", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                #endregion Fin Paiement non abonné
                            }
                            #endregion Fin Paiement sans avance
                        }
                    }
                    else MessageBox.Show("Vous n'avez rien ajouter pour un quelconque paiement", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                #endregion
                is_AutreFrais = false;
            }
            else if (rdMituelle.Checked == true)
            {
                #region Paiement pour Mutuelle
                try
                {
                    if (Convert.ToDouble(txtMontantDu.Text) <= 0) throw new Exception("l'entreprise n'a plus des dettes ou que le montant dû est invalide");
                    else
                    {
                        paiement.Mituelle = true;
                        if (chkAvance.Checked == false)
                        {
                            #region Paiement Sans avance
                            if (categorie_malade.Equals("Abonné"))
                            {
                                #region Paiement abonné
                                if (Convert.ToDouble(txtMontantPaye.Text) == Convert.ToDouble(txtMontantDu.Text))
                                {
                                    commonSavePaiement();
                                }
                                else
                                {
                                    if (Convert.ToDouble(txtMontantDu.Text) == Convert.ToDouble(txtMontantPaye.Text) && Convert.ToDouble(txtMontantDu.Text) < totMontantDu)
                                    {
                                        DialogResult msg = MessageBox.Show("Le montant que l'entreprise doit ne correspond pas au montant global réel, voulez-vous continuer pour une partie à payer sans avancer ?", "Mise à jour", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        if (msg == DialogResult.Yes)
                                        {
                                            commonSavePaiement();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Paiement non éffectué", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else MessageBox.Show("Le montatnt dû et celui à payer ne correspondent pas", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                #endregion Fin Paiement entreprise
                            }
                            #endregion Fin Paiement sans avance
                        }
                        else if (chkAvance.Checked == true)
                        {
                            #region Paiement avec avance
                            if (Convert.ToDouble(txtMontantAvance.Text) > Convert.ToDouble(txtMontantDu.Text)) MessageBox.Show("L'entreprise ne peut avancer plus que ce qu'elle doit", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            else if (Convert.ToDouble(txtMontantAvance.Text) < Convert.ToDouble(txtMontantDu.Text))
                            {
                                #region Paiement entreprise avec avance obligatoire
                                //Effectuer le paiement en notifiant le reste de la dette
                                if (Convert.ToDouble(txtMontantDette.Text) < 0) MessageBox.Show("Aucune mise à jour n'a été éffectuée, l'entreprise ne peut payer plus que ce qu'elle doit", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                else if (Convert.ToDouble(txtMontantDette.Text) > 0)
                                {
                                    //On fait une insertion d'un nouveau paiement tout en diminuant la dette du malade
                                    commonSavePaiement();
                                }
                                else if (Convert.ToDouble(txtMontantDette.Text) == 0)
                                {
                                    //On fait une insertion d'un nouveau paiement tout en diminuant la dette du malade
                                    commonSavePaiement();
                                    MessageBox.Show("L'entreprise a fini sa dette", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                #endregion Fin Paiement entreprise avec avance obligatoire
                            }
                            else if (Convert.ToDouble(txtMontantAvance.Text) == Convert.ToDouble(txtMontantDu.Text))
                            {
                                if (Convert.ToDouble(txtMontantDu.Text) == Convert.ToDouble(txtMontantPaye.Text))
                                {
                                    DialogResult msg = MessageBox.Show("Il ne s'agit plus d'une avance, mais l'entreprise paye la totalité, voulez-vous continuer ?", "Mise à jour", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                    if (msg == DialogResult.Yes)
                                    {
                                        #region Paiement entreprise avec cas d'avance
                                        commonSavePaiement();
                                        #endregion Fin Paiement abonné
                                    }
                                    else MessageBox.Show("Le montant que le malade doit ne correspond pas au montant réel et rassurez-vous que le montant du correspond au total réelement dû par le malade", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            #endregion Fin Paiement avec avance
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Echec de la mise à jour " + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                #endregion
            }
            //Initialisation des toutes les listes temporaires pour différentes actions
            listIdArticle.Clear();
            listQteArticle.Clear();
            listGetArticleDesignation.Clear();
            listMontantArticle.Clear();
            listObjectArticle.Clear();
            lblCodeAutreFrais.Text = "";
        }

        private void FrmPaiment_Load(object sender, EventArgs e)
        {
            //Chargement pour le rapport
            chkEntreprise.Checked = true;
            rdConsommation.Checked = true;
            rdAbonne.Checked = true;

            //rdNonAbonne.Checked = false;

            rdInterne.Checked = true;

            gpConsommationNonAbonne.Enabled = false;
            gpRecetteJournaliereGlobale.Enabled = false;
            gpRecetteJournaliere.Enabled = false;
            gpEntreprise.Enabled = true;

            clsDoTraitement.reinitialiseValue();
            //rdMalade.Checked = true;
            cmdArchiver.Enabled = false;
            txtid_paiement.Visible = false;

            #region Set Location
            panel10.Location = new System.Drawing.Point(0, 0);
            panel10.Size = new System.Drawing.Size(309, 110);
            panel8.Location = new System.Drawing.Point(0, 110);
            panel8.Size = new System.Drawing.Size(309, 110);
            panel12.Location = new System.Drawing.Point(0, 220);
            panel12.Size = new System.Drawing.Size(309, 110);
            panel6.Location = new System.Drawing.Point(0, 330);
            panel6.Size = new System.Drawing.Size(309, 110);
            panel13.Location = new System.Drawing.Point(0, 440);
            panel13.Size = new System.Drawing.Size(309, 110);
            panel14.Location = new System.Drawing.Point(0, 550);
            panel14.Size = new System.Drawing.Size(309, 110);
            panel15.Location = new System.Drawing.Point(0, 660);
            panel15.Size = new System.Drawing.Size(309, 110);
            panel16.Location = new System.Drawing.Point(0, 770);
            panel16.Size = new System.Drawing.Size(309, 110);
            panel17.Location = new System.Drawing.Point(0, 880);
            panel17.Size = new System.Drawing.Size(309, 110);
            panel18.Location = new System.Drawing.Point(0, 990);
            panel18.Size = new System.Drawing.Size(309, 110);
            panel19.Location = new System.Drawing.Point(0, 1100);
            panel19.Size = new System.Drawing.Size(309, 110);
            panel20.Location = new System.Drawing.Point(0, 1210);
            panel20.Size = new System.Drawing.Size(309, 110);
            panel7.Location = new System.Drawing.Point(0, 1320);
            panel7.Size = new System.Drawing.Size(309, 110);
            panel11.Location = new System.Drawing.Point(0, 1430);
            panel11.Size = new System.Drawing.Size(309, 110);
            #endregion Fin Set Location

            try
            {
                bindingcls();
                refresh();
                dgv.DataSource = bsrc;
                dgv1.DataSource = bsrc1;

                //if (clear == 0) dgv.DataSource = null;
                //clear = 3;

                if ((rdMalade.Checked == false && rdMituelle.Checked == false) || rdMalade.Checked == true)
                {
                    //S'il n'ya pas d'enregistrement de paiement pour le malade sélectionné, on vide le datagridview
                    filDgvPaiement();
                }
                else if (rdMituelle.Checked == true)
                {
                    //S'il n'ya pas d'enregistrement de paiement pour le malade correspondant a la mituelle, on vide le datagridview
                    filDgvPaiement1();
                }
            }
            catch (Exception) { }

            #region Item pour le rapport et autres
            try
            {
                //Chargement des combobox
                cboEntreprise.DataSource = clsMetier.GetInstance().getAllClsetablissementpriseencharge();
                setMembersallcbo(cboEntreprise, "Denomination", "Id");

            }
            catch (Exception) { }

            if (cboEntreprise.Items.Count > 0) cboEntreprise.SelectedIndex = 0;

            chkAvance.Checked = false;
            txtMontantAvance.Enabled = false;
            txtMontantDette.Enabled = false;
            txtMontantDetteRestante.Enabled = false;
            if (dgv.RowCount == 0) cmdArchiver.Enabled = false;
            if (dgv1.RowCount == 0) cmdRestaurer.Enabled = false;
            #endregion Fin Item pour le rapport et autres

            rdMalade.Checked = true;
        }

        private void lstChambreOccupe_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateListItems(lstTarifConsultation);
                ActivateListItems(lstIntervention);
                ActivateListItems(lstMedicament);
                ActivateListItems(lstLaboratoire);
                ActivateListItems(lstCPN);
                ActivateListItems(lstCPOS);
                ActivateListItems(lstEchographie);
                ActivateListItems(lstSoins);
                ActivateListItems(lstPreconsultation);
                ActivateListItems(lstAutresFrais);
                ActivateListItems(lstTypeAccouchement);
                ActivateListItems(lstconsultationgynecologique);
                ActivateListItems(lstNursing);
            }
            catch (Exception) { }
        }

        private void lstCPN_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateListItems(lstTarifConsultation);
                ActivateListItems(lstIntervention);
                ActivateListItems(lstMedicament);
                ActivateListItems(lstChambreOccupe);
                ActivateListItems(lstLaboratoire);
                ActivateListItems(lstCPOS);
                ActivateListItems(lstEchographie);
                ActivateListItems(lstSoins);
                ActivateListItems(lstPreconsultation);
                ActivateListItems(lstAutresFrais);
                ActivateListItems(lstTypeAccouchement);
                ActivateListItems(lstconsultationgynecologique);
                ActivateListItems(lstNursing);
            }
            catch (Exception) { }
        }

        private void lstCPOS_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateListItems(lstTarifConsultation);
                ActivateListItems(lstIntervention);
                ActivateListItems(lstMedicament);
                ActivateListItems(lstChambreOccupe);
                ActivateListItems(lstCPN);
                ActivateListItems(lstEchographie);
                ActivateListItems(lstSoins);
                ActivateListItems(lstLaboratoire);
                ActivateListItems(lstPreconsultation);
                ActivateListItems(lstAutresFrais);
                ActivateListItems(lstTypeAccouchement);
                ActivateListItems(lstconsultationgynecologique);
                ActivateListItems(lstNursing);

            }
            catch (Exception) { }
        }

        private void lstLaboratoire_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateListItems(lstTarifConsultation);
                ActivateListItems(lstIntervention);
                ActivateListItems(lstMedicament);
                ActivateListItems(lstChambreOccupe);
                ActivateListItems(lstCPN);
                ActivateListItems(lstCPOS);
                ActivateListItems(lstEchographie);
                ActivateListItems(lstSoins);
                ActivateListItems(lstPreconsultation);
                ActivateListItems(lstAutresFrais);
                ActivateListItems(lstTypeAccouchement);
                ActivateListItems(lstconsultationgynecologique);
                ActivateListItems(lstNursing);
            }
            catch (Exception) { }
        }

        private void lblAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstChambreOccupe.SelectedIndex > -1)
                {
                    VerifieExistItemList(lstChambreOccupe, false);
                }
                else if (lstPreconsultation.SelectedIndex > -1)
                {
                    VerifieExistItemList(lstPreconsultation, false);
                }
                else if (lstTarifConsultation.SelectedIndex > -1)
                {
                    VerifieExistItemList(lstTarifConsultation, false);
                }
                else if (lstIntervention.SelectedIndex > -1)
                {
                    VerifieExistItemList(lstIntervention, false);
                }
                if (lstMedicament.SelectedIndex > -1)
                {
                    VerifieExistItemList(lstMedicament, false);
                }
                if (lstconsultationgynecologique.SelectedIndex > -1)
                {
                    VerifieExistItemList(lstconsultationgynecologique, false);
                }
                else if (lstCPN.SelectedIndex > -1)
                {
                    VerifieExistItemList(lstCPN, false);
                }
                else if (lstCPOS.SelectedIndex > -1)
                {
                    VerifieExistItemList(lstCPOS, false);
                }
                else if (lstEchographie.SelectedIndex > -1)
                {
                    VerifieExistItemList(lstEchographie, false);
                }
                else if (lstSoins.SelectedIndex > -1)
                {
                    VerifieExistItemList(lstSoins, false);
                }
                else if (lstLaboratoire.SelectedIndex > -1)
                {
                    VerifieExistItemList(lstLaboratoire, false);
                }
                else if (lstAutresFrais.SelectedIndex > -1)
                {
                    VerifieExistItemList(lstAutresFrais, true);
                }
                else if (lstTypeAccouchement.SelectedIndex > -1)
                {
                    VerifieExistItemList(lstTypeAccouchement, false);
                }
                else if (lstNursing.SelectedIndex > -1)
                {
                    VerifieExistItemList(lstNursing, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération des produits à payer, " + ex.Message, "Récupération des valeurs des produits à payer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (categorie_malade == "Non abonné")
            {
                txtMontantPaye.Text = txtMontantDu.Text;
            }
            else
            {
                //if (chkAvance.Checked)
                //{
                //    montantMituel = (clsMetier.GetInstance().getClsetablissementpriseencharge(identifiantMalade).Taux) * Convert.ToDouble(txtMontantDu.Text);
                //    txtMontantMituelle.Text = Math.Round(montantMituel, 2).ToString();
                //    txtMontantClient.Text = (Convert.ToDouble(txtMontantDu.Text) - montantMituel).ToString();
                //    oldMontantDette = Math.Round((montantClient - clsMetier.GetInstance().getTotmontantpaiement(identifiantMalade)), 2);
                //    txtMontantDetteRestante.Text = oldMontantDette.ToString();
                //}
                //else 
                //{
                montantMituel = (clsMetier.GetInstance().getClsetablissementpriseencharge(identifiantMalade).Taux) * Convert.ToDouble(txtMontantDu.Text);
                txtMontantMituelle.Text = Math.Round(montantMituel, 2).ToString();
                txtMontantClient.Text = Math.Round((Convert.ToDouble(txtMontantDu.Text) - montantMituel), 2).ToString();
                oldMontantDette = Math.Round((montantClient - clsMetier.GetInstance().getTotmontantpaiement(identifiantMalade)), 2);
                txtMontantDetteRestante.Text = oldMontantDette.ToString();
                txtMontantPaye.Text = txtMontantClient.Text;
                //}
            }
        }

        private void lblRemove_Click(object sender, EventArgs e)
        {
            try
            {
                listIdArticle.RemoveAt(lstArticles.SelectedIndex);
                listMontantArticle.RemoveAt(lstArticles.SelectedIndex);
                listObjectArticle.RemoveAt(lstArticles.SelectedIndex);
                lstArticles.Items.RemoveAt(lstArticles.SelectedIndex);
                txtMontantDu.Text = CalculTarif(listMontantArticle).ToString();
                if (categorie_malade == "Non abonné")//(!chkAvance.Checked)
                {
                    txtMontantPaye.Text = txtMontantDu.Text;
                }
            }
            catch (Exception) { }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.RowCount != 0)
            {
                try
                {
                    cboDateFacturation.DataSource = clsMetier.GetInstance().getAllClsfacturationPersonne(clsDoTraitement.IdMalade);
                    setMembersallcbo(cboDateFacturation, "Date", "Id_malade");
                }
                catch (Exception)
                {
                    MessageBox.Show("Erreur de chargement des dates", "Erreur de chargement");
                }
            }
            else
            {
                cboDateFacturation.DataSource = null;
                cboDateFacturation.Text = "Date Facturation";
            }
        }

        private void lstPreconsultation_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateListItems(lstTarifConsultation);
                ActivateListItems(lstIntervention);
                ActivateListItems(lstMedicament);
                ActivateListItems(lstChambreOccupe);
                ActivateListItems(lstCPN);
                ActivateListItems(lstCPOS);
                ActivateListItems(lstEchographie);
                ActivateListItems(lstSoins);
                ActivateListItems(lstLaboratoire);
                ActivateListItems(lstAutresFrais);
                ActivateListItems(lstTypeAccouchement);
                ActivateListItems(lstconsultationgynecologique);
                ActivateListItems(lstNursing);
            }
            catch (Exception) { }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            refresh();

            try
            {
                if ((rdMalade.Checked == false && rdMituelle.Checked == false) || rdMalade.Checked == true)
                {
                    //S'il n'ya pas d'enregistrement de paiement pour le malade sélectionné, on vide le datagridview
                    filDgvPaiement();
                }
                else if (rdMituelle.Checked == true)
                {
                    //S'il n'ya pas d'enregistrement de paiement pour le malade sélectionné pour la mituelle, on vide le datagridview
                    filDgvPaiement1();
                }
            }
            catch (Exception) { }
        }

        private void lblAccouchement_Click(object sender, EventArgs e)
        {
            pnAffichage.Controls.Clear();
            DossierAccouchementFrm2 frm = new DossierAccouchementFrm2();
            frm.Parent = pnAffichage;
        }

        private void lstTypeAccouchement_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateListItems(lstTarifConsultation);
                ActivateListItems(lstIntervention);
                ActivateListItems(lstMedicament);
                ActivateListItems(lstChambreOccupe);
                ActivateListItems(lstCPN);
                ActivateListItems(lstCPOS);
                ActivateListItems(lstEchographie);
                ActivateListItems(lstSoins);
                ActivateListItems(lstPreconsultation);
                ActivateListItems(lstAutresFrais);
                ActivateListItems(lstLaboratoire);
                ActivateListItems(lstconsultationgynecologique);
                ActivateListItems(lstNursing);
            }
            catch (Exception) { }
        }

        private void lblDosssierPreconsultation_Click(object sender, EventArgs e)
        {
            pnAffichage.Controls.Clear();
            FrmDossierPreconsultationPaiement2 frm = new FrmDossierPreconsultationPaiement2();
            frm.Parent = pnAffichage;
        }

        private void lblDossierConsultation_Click(object sender, EventArgs e)
        {
            pnAffichage.Controls.Clear();
            DossierConsultationPaiementFrm2 frm = new DossierConsultationPaiementFrm2();
            frm.Parent = pnAffichage;
        }

        private void lblDossierLaboratoire_Click(object sender, EventArgs e)
        {
            pnAffichage.Controls.Clear();
            DossierLaboPaiementFrm2 frm = new DossierLaboPaiementFrm2();
            frm.Parent = pnAffichage;
        }

        private void lblDossierIntervention_Click(object sender, EventArgs e)
        {
            pnAffichage.Controls.Clear();
            DossierInterventionPaiementFrm2 frm = new DossierInterventionPaiementFrm2();
            frm.Parent = pnAffichage;
        }

        private void lblPharmacie_Click(object sender, EventArgs e)
        {
            pnAffichage.Controls.Clear();
            SortieArticleCaissePaiementFrm frm = new SortieArticleCaissePaiementFrm();
            frm.Parent = pnAffichage;
        }

        private void chkAvance_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAvance.Checked)
            {
                gpAvance.Enabled = true;
                gpMontantPaye.Enabled = false;
                txtMontantAvance.Enabled = false;
                //txtMontantPaye.Enabled = true;
                txtMontantPaye.Clear();
            }
            else
            {
                gpMontantPaye.Enabled = true;
                gpAvance.Enabled = false;
                txtMontantPaye.Enabled = false;
                txtMontantAvance.Clear();
                txtMontantPaye.Text = txtMontantDu.Text;
            }
        }

        private void txtMontantAvance_TextChanged(object sender, EventArgs e)
        {
            if (rdMalade.Checked)
            {
                #region Paiement pour malade
                if (chkAvance.Checked)
                {
                    try
                    {
                        double u = Convert.ToDouble(txtMontantAvance.Text);
                        if (txtMontantAvance.Text.Equals(""))
                        {
                            //txtMontantDette.Clear();
                            txtMontantPaye.Text = "";
                        }
                        else
                        {
                            if (clsMetier.GetInstance().getClscategoriemalade1(malade.Id).Designation.Equals("Abonné"))
                            {
                                txtMontantPaye.Text = txtMontantAvance.Text;
                                montantAvance = Convert.ToDouble(txtMontantAvance.Text);
                                //txtMontantClient.Text = Math.Round(montantClient, 2).ToString();
                                txtMontantDette.Text = (oldMontantDette - montantAvance).ToString();
                                txtGetDette.Text = (oldMontantDette - montantAvance).ToString();
                            }
                            else
                            {
                                txtMontantMituelle.Clear();
                                txtMontantClient.Clear();
                                txtMontantAvance.Clear();
                                txtMontantDette.Clear();
                            }
                        }
                    }
                    catch (Exception) { }
                }
                #endregion Fin paiement malade
            }
            else if (rdMituelle.Checked)
            {
                #region Paiement pour mituel
                if (chkAvance.Checked)
                {
                    try
                    {
                        double u = Convert.ToDouble(txtMontantAvance.Text);
                        if (txtMontantAvance.Text.Equals(""))
                        {
                            txtMontantPaye.Text = "";
                        }
                        else
                        {
                            if (clsMetier.GetInstance().getClscategoriemalade1(malade.Id).Designation.Equals("Abonné"))
                            {
                                txtMontantPaye.Text = txtMontantAvance.Text;
                                montantAvance = Convert.ToDouble(txtMontantAvance.Text);
                                txtMontantDette.Text = (oldMontantDette - montantAvance).ToString();
                                txtGetDette.Text = (oldMontantDette - montantAvance).ToString();
                            }
                            //else
                            //{
                            //    txtMontantMituelle.Clear();
                            //    txtMontantClient.Clear();
                            //    txtMontantAvance.Clear();
                            //    txtMontantDette.Clear();
                            //}
                        }
                    }
                    catch (Exception) { }
                }
                #endregion Fin paiement pour mituelle
            }
        }

        private void cmdArchiver_Click(object sender, EventArgs e)
        {
            try
            {
                if (categorie_malade.Equals("Abonné") && Convert.ToDouble(txtMontantDetteRestante.Text) > 0) MessageBox.Show("Ce paiement ne peut être archivé car le malade possède encore une dette !", "Archivage paiement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (categorie_malade.Equals("Non abonné") || categorie_malade.Equals("Abonné") && Convert.ToDouble(txtMontantDetteRestante.Text) == 0)
                {
                    clsMetier.GetInstance().updateClspaiementarchive(((clspaiement)dgv.SelectedRows[0].DataBoundItem).Id);
                    MessageBox.Show("Paiement archivé avec succès!", "Archivage paiement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ">>>" + "Erreur Inentendue!", "Archivage paiement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdRestaurer_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Voulez vous vraiment restaurer ce paiement ?", "Restauration archive paiement", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (msg == DialogResult.Yes)
            {
                try
                {
                    clsMetier.GetInstance().updateClspaiementarchiverestore(((clspaiement)dgv1.SelectedRows[0].DataBoundItem).Id);
                    MessageBox.Show("Paiement restauré avec succès!", "Restauration paiement archivé", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ">>>" + "Erreur Inentendue!", "Restauration paiement archivé", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else MessageBox.Show("Restauration paiement non éffectuée!", "Restauration paiement archivé", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgv1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv1.SelectedRows.Count > 0)
                {
                    clsDoTraitement.IdPaiementArchive = ((clspaiement)dgv1.SelectedRows[0].DataBoundItem).Id;
                    cmdRestaurer.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage des archives des paiements", "Erreur d'affichage des archives des paiements");
            }
        }

        private void lstAutresFrais_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateListItems(lstTarifConsultation);
                ActivateListItems(lstChambreOccupe);
                ActivateListItems(lstMedicament);
                ActivateListItems(lstCPOS);
                ActivateListItems(lstCPN);
                ActivateListItems(lstEchographie);
                ActivateListItems(lstSoins);
                ActivateListItems(lstLaboratoire);
                ActivateListItems(lstPreconsultation);
                ActivateListItems(lstTypeAccouchement);
                ActivateListItems(lstIntervention);
                ActivateListItems(lstconsultationgynecologique);
                ActivateListItems(lstNursing);
            }
            catch (Exception) { }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    txtid_paiement.Text = ((clspaiement)dgv.SelectedRows[0].DataBoundItem).Id.ToString();
                    if (((clspaiement)dgv.SelectedRows[0].DataBoundItem).Mituelle == false)
                    {
                        #region Affichage paiement malade
                        bindignlst();
                        bln = true;
                        cmdArchiver.Enabled = true;

                        try
                        {
                            if (Convert.ToDouble(txtMontantDette.Text) > 0)
                            {
                                //chkAvance.Enabled = true;
                                txtMontantAvance.Enabled = false;
                            }
                            else
                            {
                                txtMontantAvance.Enabled = false;
                                chkAvance.Enabled = false;
                            }
                        }
                        catch (Exception) { }
                        //Attribution de la valeur de l'avance prrapport à la dette
                        //////if (((clspaiement)dgv.SelectedRows[0].DataBoundItem).Dette > 0) txtMontantAvance.Text = ((clspaiement)dgv.SelectedRows[0].DataBoundItem).Dette.ToString();
                        //Chargement de la liste des article avec le produit quon a payé ulterieurement
                        lstArticles.DataSource = clsMetier.GetInstance().getAllClsarticle_paye1(((clspaiement)dgv.SelectedRows[0].DataBoundItem).Id);
                        blnDataSourceDefine = true;
                        #endregion
                    }
                    else if (((clspaiement)dgv.SelectedRows[0].DataBoundItem).Mituelle == true)
                    {
                        #region Affichage paiement mituelle
                        bindignlst1();
                        bln1 = true;

                        //txtMontantDetteRestante.Text = clsMetier.GetInstance().getMontantResteDettepaiement(((clspaiement)dgv.SelectedRows[0].DataBoundItem).Id_malade, ((clspaiement)dgv.SelectedRows[0].DataBoundItem).Id).ToString();
                        try
                        {
                            if (Convert.ToDouble(txtMontantDette.Text) > 0)
                            {
                                //chkAvance.Enabled = true;
                                txtMontantAvance.Enabled = false;
                            }
                            else
                            {
                                txtMontantAvance.Enabled = false;
                                chkAvance.Enabled = false;
                            }
                        }
                        catch (Exception) { }
                        lstArticles.DataSource = null;
                        blnDataSourceDefine = true;
                        #endregion Fin Affichage paiement mituelle
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage des paiements", "Erreur d'affichage des paiements");
            }
        }

        private void txtMontantMituelle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMontant_mituelle.Text = txtMontantMituelle.Text;
            }
            catch (Exception) { }
        }

        private void loadReportF()
        {
            if (rdMalade.Checked == false && rdMituelle.Checked == false)
            {
                MessageBox.Show("Veuillez sélectionner une rubrique pour afficher la facture (Malade ou Mutuelle)");
            }
            else if (rdMalade.Checked == true)
            {
                #region Facture pour malade
                SqlConnection conn = null;
                List<int> numerofacture = new List<int>();
                bool isOnlyMedicament = false;

                try
                {
                    string s;
                    s = cboDateFacturation.Text.Substring(0, 10);
                    #region Traitement Malade pour factures non encores soldées
                    string requete1 = "", requete2 = "", requete3 = "";
                    int query = 0;
                    bool ok3 = false, ok2 = false;

                    requete2 = @"SELECT facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu, facturation.avance,ROUND(facturation.dette,2) AS dette,
facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS medicament,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS labo,(SELECT ISNULL(MAX(cumul),0) from malade_avance INNER JOIN facturation ON facturation.id_malade=malade_avance.id_malade WHERE facturation.id_malade=" + malade.Id + @"  AND malade_avance.solde=0) AS avance,(ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) - (SELECT ROUND(SUM(facturation.montantmituelle),2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux)-(SELECT ISNULL(MAX(cumul),0) from malade_avance INNER JOIN facturation ON facturation.id_malade=malade_avance.id_malade WHERE facturation.id_malade=" + malade.Id + @"  AND malade_avance.solde=0)) AS TotGen,(SELECT ROUND(SUM(facturation.montantmituelle),2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1  GROUP BY categoriemalade.taux) AS mituelle
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 AND facturation.solde=0 AND facturation.ispaiementmalade=1 ORDER BY facturation.designation ASC";

                    requete3 = @"SELECT facturation.designation,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet, facturation.date, facturation.pu, facturation.avance,ROUND(facturation.dette,2) AS dette,
facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS medicament,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS labo,(SELECT ISNULL(MAX(cumul),0) from malade_avance INNER JOIN facturation ON facturation.id_malade=malade_avance.id_malade WHERE facturation.id_malade=" + malade.Id + @"  AND malade_avance.solde=0) AS avance,(ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) - ISNULL((SELECT ROUND(SUM(facturation.montantmituelle),2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0)-(SELECT ISNULL(MAX(cumul),0) from malade_avance INNER JOIN facturation ON facturation.id_malade=malade_avance.id_malade WHERE facturation.id_malade=" + malade.Id + @"  AND malade_avance.solde=0)) AS TotGen,(SELECT ROUND(SUM(facturation.montantmituelle),2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux) AS mituelle
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=0 AND facturation.ispaiementmalade=1 ORDER BY facturation.designation ASC";
                    //facturation.designation AS de,facturation.id AS idFacturation,
                    requete1 = @"SELECT DISTINCT facturation.designation AS designation,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,personne.sexe,malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, 
                                facturation.pu,facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,facturation.id_malade,facturation.numero_facture,(SELECT SUM(facturation.montantmituelle)
                                           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                            where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1
                                 GROUP BY categoriemalade.taux) AS mituelle,(SELECT ISNULL(MAX(cumul),0) from malade_avance INNER JOIN facturation ON facturation.id_malade=malade_avance.id_malade WHERE facturation.id_malade=" + malade.Id + @"  AND malade_avance.solde=0) AS avance,((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
                                           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                            where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1
                                 GROUP BY categoriemalade.taux)-(SELECT SUM(facturation.montantmituelle)
                                           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                            where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1
                                 GROUP BY categoriemalade.taux)-(SELECT ISNULL(MAX(cumul),0) from malade_avance INNER JOIN facturation ON facturation.id_malade=malade_avance.id_malade WHERE facturation.id_malade=" + malade.Id + @"  AND malade_avance.solde=0)) AS TotGen
                                           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                                                            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                where facturation.id_malade=" + malade.Id + @" and convert (date,facturation.date,100)  ='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1";//ORDER BY facturation.designation ASC

                    //On execute les requetes de test pour avoir la bonne requete pour le report
                    //Pour medicaments et autres article (Tous)
                    SqlCommand cmd3 = null;
                    conn = new SqlConnection(clsMetier.strChaineConnection);
                    conn.Open();
                    cmd3 = conn.CreateCommand();
                    cmd3.CommandText = requete3;
                    SqlDataReader rd3 = cmd3.ExecuteReader();
                    while (rd3.Read())
                    {
                        query = 3;
                        numerofacture.Add(Convert.ToInt32(rd3["numero_facture"].ToString()));
                    }
                    if (numerofacture.Count == 0) ok3 = true;
                    rd3.Dispose();
                    cmd3.Dispose();

                    //Pour les autres type d'article seulement
                    if (ok3)
                    {
                        SqlCommand cmd2 = null;
                        cmd2 = conn.CreateCommand();
                        cmd2.CommandText = requete2;
                        SqlDataReader rd2 = cmd2.ExecuteReader();
                        while (rd2.Read())
                        {
                            query = 2;
                            numerofacture.Add(Convert.ToInt32(rd2["numero_facture"].ToString()));
                        }
                        if (numerofacture.Count == 0) ok2 = true;
                        rd2.Dispose();
                        cmd2.Dispose();
                    }

                    //Pour medicaments seulement
                    if (ok2)
                    {
                        SqlCommand cmd1 = null;
                        cmd1 = conn.CreateCommand();
                        cmd1.CommandText = requete1;
                        SqlDataReader rd1 = cmd1.ExecuteReader();
                        while (rd1.Read())
                        {
                            query = 1;
                            numerofacture.Add(Convert.ToInt32(rd1["numero_facture"].ToString()));
                        }
                        rd1.Dispose();
                        cmd1.Dispose();
                    }

                    //FactureClient1 rpt = new FactureClient1();
                    SqlCommand cmd = null;
                    if (query == 3)
                    {
                        cmd = new SqlCommand(requete3, clsMetier.GetInstance().InitializeReport());//Tous les articles
                        isOnlyMedicament = false;
                    }
                    else if (query == 2)
                    {
                        cmd = new SqlCommand(requete2, clsMetier.GetInstance().InitializeReport());//Autres articles seulement
                        isOnlyMedicament = false;
                    }
                    else if (query == 1)
                    {
                        cmd = new SqlCommand(requete1, clsMetier.GetInstance().InitializeReport());//Médicaments seulement
                        isOnlyMedicament = true;
                    }
                    else
                    {
                        MessageBox.Show("Il n'ya aucune information à afficher", "Facture du client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //cmd = new SqlCommand(requete3, clsMetier.GetInstance().InitializeReport());//Tous les articles par defaut
                    }
                    if ((query == 1 || query == 2 || query == 3) && isOnlyMedicament == false)
                    {
                        FactureClient1 rpt = new FactureClient1();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "doc");
                        rpt.SetDataSource(ds.Tables["doc"]);
                        crvFacture.ReportSource = rpt;
                        crvFacture.Refresh();
                        da.Dispose();
                        ds.Dispose();
                        cmd.Dispose();
                        conn.Close();
                    }
                    else if (query == 1 && isOnlyMedicament == true)
                    {
                        FactureClient1 rpt = new FactureClient1();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "doc");
                        rpt.SetDataSource(ds.Tables["doc"]);
                        crvFacture.ReportSource = rpt;
                        crvFacture.Refresh();
                        da.Dispose();
                        ds.Dispose();
                        cmd.Dispose();
                        conn.Close();
                    }
                    #endregion


                    //                    FactureClient rpt = new FactureClient();
                    //                    SqlCommand cmd = null;
                    //                    cmd = new SqlCommand(@"SELECT ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet, facturation.designation, facturation.date, facturation.pu, facturation.avance,ROUND(facturation.dette,2) AS dette,
                    //                                       ROUND(facturation.montantmituelle,2) AS mituelle,facturation.quantite,facturation.pu*facturation.quantite AS PT,personne.sexe, 
                    //                                       malade.numero, categoriemalade.designation AS TypeMalade, categoriemalade.taux, etablissementpriseencharge.denomination, facturation.id_malade
                    //                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                    //                                                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                    //                                                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                    //                                                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                    //                                    where facturation.id_malade='" + malade.Id + "' and convert (date,facturation.date,100)  = '" + s + "'", clsMetier.GetInstance().InitializeReport());
                    //                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //                    DataSet ds = new DataSet();
                    //                    da.Fill(ds, "doc");
                    //                    rpt.SetDataSource(ds.Tables["doc"]);
                    //                    crvFacture.ReportSource = rpt;
                    //                    crvFacture.Refresh();
                    //                    da.Dispose();
                    //                    ds.Dispose();
                    //                    cmd.Dispose();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + ">> Erreur lors de l'ouverture du rapport", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                #endregion Fin Facture pour malade
            }
            else if (rdMituelle.Checked == true)
            {
                #region Facture pour mituelle
                MessageBox.Show("Reports has not benn set");
                //                try
                //                {
                //                    string s;
                //                    s = cboDateFacturation.Text.Substring(0, 10);
                //                    FactureClient rpt = new FactureClient();
                //                    SqlCommand cmd = null;
                //                    cmd = new SqlCommand(@"SELECT ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet, facturationmituelle.date, facturationmituelle.avance,ROUND(facturationmituelle.dette,2) AS dette,
                //                                       facturationmituelle.montantpaye,personne.sexe, 
                //                                       malade.numero, categoriemalade.designation AS TypeMalade, categoriemalade.taux, etablissementpriseencharge.denomination, facturationmituelle.id_malade
                //                                   FROM facturationmituelle INNER JOIN malade ON facturationmituelle.id_malade = malade.id 
                //                                                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                //                                                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                //                                                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                //                                    where facturationmituelle.id_malade='" + malade.Id + "' and convert (date,facturationmituelle.date,100)  = '" + s + "'", clsMetier.GetInstance().InitializeReport());
                //                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                //                    DataSet ds = new DataSet();
                //                    da.Fill(ds, "doc");
                //                    rpt.SetDataSource(ds.Tables["doc"]);
                //                    crvFacture.ReportSource = rpt;
                //                    crvFacture.Refresh();
                //                    da.Dispose();
                //                    ds.Dispose();
                //                    cmd.Dispose();
                //                }
                //                catch (Exception e)
                //                {
                //                    MessageBox.Show(e.Message + ">> Erreur lors de l'ouverture du rapport", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //                }
                #endregion Fin Facture pour mituelle
            }
        }

        private void btnAfficherFacture_Click(object sender, EventArgs e)
        {
            frmFacture fr = new frmFacture();
            fr.setFormPrincipal(principal);
            //fr.Icon = principal.Icon;
            fr.ShowDialog();
            //try
            //{

            //    loadReportF();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Erreur lors de l'affichage de la facture, " + ex.Message,"Affichage Facture",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            //}
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            frmFacture fr = new frmFacture();
            fr.setFormPrincipal(principal);
            fr.Icon = this.Icon;
            fr.ShowDialog();
        }

        #region Toutes les méthode qui chargent les différents rapports
        //Appel rapport pour Entreprise Interne
        public void loadReportEntrepriseInterneAbonne()
        {
            string s, v, t, x;
            t = txtDateDuConsAbonne.Value.ToString();
            x = txtDateAuConsAbonne.Value.ToString();
            s = t.Substring(0, 10);
            v = x.Substring(0, 10);
            rptEntrepriseInterneAbonne rpt = new rptEntrepriseInterneAbonne();
            SqlCommand cmd = null;
            cmd = new SqlCommand(@"SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom, numero AS numero, designEntreprise, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, 
                  SUM(isnull([ConsultationP], 0)) AS resultatConsult, SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, 
                  SUM(isnull([ConsultationPrenatale], 0)) AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, 
                  SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_Fraie], 0)) 
                  AS resultAutreFraie, SUM(isnull([Hospitalisation], 0)) AS resultHospitalisation, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([Accouchement], 0)) 
                  AS resultAccouchement, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) 
                  + SUM(isnull([ConsultationPrenatale], 0)) + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) 
                  + SUM(isnull([Autre_Fraie], 0)) + SUM(isnull([Hospitalisation], 0)) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0)) + SUM(isnull([Accouchement], 0)) 
                  AS somme
FROM         (SELECT     SUM(dbo.examen.prix*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                          operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id INNER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade LEFT OUTER JOIN 
                                          dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id 
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,operation_laboratoire.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                          operation_laboratoire.date, etablissementpriseencharge.denomination
                   UNION
                   SELECT     SUM(dbo.intervention.prix*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'    and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,subit.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, subit.date
                   UNION
                   SELECT     SUM(tarifpreconsultation.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade LEFT OUTER JOIN
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                         hospitalisation ON dbo.malade.id=dbo.hospitalisation.id_malade RIGHT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id INNER JOIN
                                         dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     dossierpreconsultation.etatpaiement = 'Fiche payée' AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,dossierpreconsultation.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossierpreconsultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultation.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,consultation.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         consultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade LEFT OUTER JOIN
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,dossierconsultationprenatale.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossierconsultationprenatale.date
                   UNION
                   SELECT     SUM(dbo.tarifechographie.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,dossierechographie.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossierechographie.date
                   UNION
                   SELECT     SUM(dbo.tarifsoin.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id INNER JOIN 
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,dossiersoin.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossiersoin.date
                   UNION
                   SELECT     SUM(dbo.tarifnursing.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,dossiernursing.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossiernursing.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"'  and (convert(date,dossierconsultationgynecologique.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossierconsultationgynecologique.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,dossierconsultationpostnatal.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossierconsultationpostnatal.date
                   UNION
                   SELECT     SUM(dbo.typeaccouchement.prix*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossieraccouchement.date AS dateEvent, 'Accouchement' AS DIMENSION
                   FROM         dbo.typeaccouchement INNER JOIN
                                         dbo.dossieraccouchement ON dbo.typeaccouchement.id = dbo.dossieraccouchement.id_typeaccouchement INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossieraccouchement.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossieraccouchement.etatpaiement = 'Non cloturé payé') OR (dbo.dossieraccouchement.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"') 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossieraccouchement.date
                   UNION
                   SELECT     SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,sortie.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, sortie.date
                   UNION
                   SELECT     SUM(dbo.detailsautrefraie.prix*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             etablissementpriseencharge.denomination AS designEntreprise,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade LEFT OUTER JOIN
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,autrefraie.dateenregistrement,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         autrefraie.dateenregistrement
                   UNION
                   SELECT     SUM(dbo.categoriechambre.prix*ISNULL(DATEDIFF(DAY,hospitalisation.datedebut,hospitalisation.datefin),0)*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         hospitalisation.datefin AS dateEvent, 'Hospitalisation' AS DIMENSION
                   FROM         dbo.hospitalisation INNER JOIN
                                         dbo.chambre INNER JOIN
                                         dbo.categoriechambre ON dbo.chambre.id_categoriechambre = dbo.categoriechambre.id ON 
                                         dbo.hospitalisation.id_chambre = dbo.chambre.id INNER JOIN
                                         dbo.personne INNER JOIN
                                         dbo.malade ON dbo.personne.id = dbo.malade.id_personne ON dbo.hospitalisation.id_malade = dbo.malade.id INNER JOIN
                                         dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.hospitalisation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.hospitalisation.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         hospitalisation.datefin) MES_UNIONS PIVOT (sum(VALEUR) FOR dimension IN ([examenP], [ConsultationP], [ConsultationGP], [peconsult], 
                  [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Hospitalisation], [Nursing], [InterventionP], [Accouchement])) 
                  AS MON_PIVOT
GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent, numero, designEntreprise ", clsMetier.GetInstance().InitializeReport());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "doc");
            rpt.SetDataSource(ds.Tables["doc"]);
            crvRapport.ReportSource = rpt;
            crvRapport.Refresh();
            da.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }

        //Appel rapport pour Entreprise Externe
        public void loadReportEntrepriseExterneAbonne()
        {
            string s, v, t, x;
            t = txtDateDuConsAbonne.Value.ToString();
            x = txtDateAuConsAbonne.Value.ToString();
            s = t.Substring(0, 10);
            v = x.Substring(0, 10);
            rptEntrepriseExterneAbonne rpt = new rptEntrepriseExterneAbonne();
            SqlCommand cmd = null;
            cmd = new SqlCommand(@"SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom, numero AS numero, designEntreprise, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, 
                  SUM(isnull([ConsultationP], 0)) AS resultatConsult, SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, 
                  SUM(isnull([ConsultationPrenatale], 0)) AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, 
                  SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_Fraie], 0)) 
                  AS resultAutreFraie, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) 
                  + SUM(isnull([ConsultationPrenatale], 0)) + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) 
                  + SUM(isnull([Autre_Fraie], 0)) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0))
                  AS somme
                FROM         (SELECT     SUM(dbo.examen.prix*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                                          etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                                          operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                                   FROM          dbo.examen INNER JOIN
                                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id INNER JOIN
                                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade INNER JOIN 
                                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id 
                                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,operation_laboratoire.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')))))
                                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                                          operation_laboratoire.date, etablissementpriseencharge.denomination
                                   UNION
                                   SELECT     SUM(dbo.intervention.prix*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                                         subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                                   FROM         dbo.intervention INNER JOIN
                                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id INNER JOIN
                                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade INNER JOIN 
                                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                                         (dbo.subit.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'    and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,subit.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')))))
                                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, subit.date
                                   UNION
                                   SELECT     SUM(tarifpreconsultation.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                                         dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                                   FROM         dossierpreconsultation INNER JOIN
                                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade INNER JOIN
                                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id INNER JOIN
                                                         dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id INNER JOIN
                                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                                   WHERE     dossierpreconsultation.etatpaiement = 'Fiche payée' AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,dossierpreconsultation.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')))))
                                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                                         dossierpreconsultation.date
                                   UNION
                                   SELECT     SUM(dbo.tarifconsultation.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                                         consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                                   FROM         dbo.tarifconsultation INNER JOIN
                                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id INNER JOIN
                                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade INNER JOIN 
                                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,consultation.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')))))
                                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                                         consultation.date
                                   UNION
                                   SELECT     SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                                         dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id INNER JOIN
                                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade INNER JOIN 
                                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,dossierconsultationprenatale.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')))))
                                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                                         dossierconsultationprenatale.date
                                   UNION
                                   SELECT     SUM(dbo.tarifechographie.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                                         dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                                   FROM         dbo.tarifechographie INNER JOIN
                                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id INNER JOIN
                                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade INNER JOIN 
                                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,dossierechographie.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')))))
                                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                                         dossierechographie.date
                                   UNION
                                   SELECT     SUM(dbo.tarifsoin.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                                         dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                                   FROM         dbo.tarifsoin INNER JOIN
                                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id INNER JOIN 
                                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade INNER JOIN 
                                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,dossiersoin.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')))))
                                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                                         dossiersoin.date
                                   UNION
                                   SELECT     SUM(dbo.tarifnursing.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                                         dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                                   FROM         dbo.tarifnursing INNER JOIN
                                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id INNER JOIN
                                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade INNER JOIN 
                                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,dossiernursing.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')))))
                                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                                         dossiernursing.date
                                   UNION
                                   SELECT     SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                                         dbo.dossierconsultationgynecologique ON 
                                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id INNER JOIN
                                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade INNER JOIN 
                                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"'  and (convert(date,dossierconsultationgynecologique.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')))))
                                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                                         dossierconsultationgynecologique.date
                                   UNION
                                   SELECT     SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                                         dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id INNER JOIN
                                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade INNER JOIN 
                                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,dossierconsultationpostnatal.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')))))
                                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                                         dossierconsultationpostnatal.date
                                   UNION
                                   SELECT     SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                                         sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                                   FROM         dbo.article INNER JOIN
                                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id INNER JOIN
                                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE     (dbo.sortie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,sortie.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')))))
                                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, sortie.date
                                   UNION
                                   SELECT     SUM(dbo.detailsautrefraie.prix*etablissementpriseencharge.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                             etablissementpriseencharge.denomination AS designEntreprise,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade INNER JOIN 
                                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='" + cboEntreprise.Text + @"' and (convert(date,autrefraie.dateenregistrement,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')))))
                                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                                         autrefraie.dateenregistrement) MES_UNIONS PIVOT (sum(VALEUR) FOR dimension IN ([examenP], [ConsultationP], [ConsultationGP], [peconsult], 
                                  [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Nursing], [InterventionP])) 
                                  AS MON_PIVOT
                GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent, numero, designEntreprise ", clsMetier.GetInstance().InitializeReport());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "doc");
            rpt.SetDataSource(ds.Tables["doc"]);
            crvRapport.ReportSource = rpt;
            crvRapport.Refresh();
            da.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }

        //Appel rapport pour Non abonné Interne
        public void loadConsommationNonAbonneInterne()
        {
            string s, v, t, x;
            t = txtDateConsNonAbonneDu.Value.ToString();
            x = txtDateConsAu.Value.ToString();
            s = t.Substring(0, 10);
            v = x.Substring(0, 10);
            rptConsommationNonAbonneInterne rpt = new rptConsommationNonAbonneInterne();
            SqlCommand cmd = null;
            cmd = new SqlCommand(@"
           SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom,numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, SUM(isnull([ConsultationP], 0)) 
              AS resultatConsult,SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, SUM(isnull([ConsultationPrenatale], 0)) 
              AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_fraie], 0)) 
              AS resultAutreFraie, SUM(isnull([Hospitalisation], 0)) AS resultHospitalisation, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([Accouchement], 0)) 
              AS resultAccouchement, isnull([Avance],0) AS resultAvance, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) + SUM(isnull([ConsultationPrenatale], 0)) 
              + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) + SUM(isnull([Autre_fraie], 0)) + SUM(isnull([Hospitalisation], 0)) + isnull([Avance],0) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0)) + SUM(isnull([Accouchement], 0))  
                  AS somme
            FROM         (SELECT     SUM(dbo.examen.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero,operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id INNER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade LEFT OUTER JOIN 
                                          dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and (convert(date,operation_laboratoire.date,100) between '" + s + @"' and '" + v + @"')  and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, operation_laboratoire.date
                   UNION
                   SELECT     SUM(dbo.intervention.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                         hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) and (convert(date,subit.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, subit.date
                   UNION
                   SELECT     SUM(tarifpreconsultation.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN 
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dossierpreconsultation.etatpaiement = 'Fiche payée') and (convert(date,dossierpreconsultation.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierpreconsultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultation.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) and (convert(date,consultation.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, consultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationprenatale.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationprenatale.date
                   
                   UNION
                   SELECT     SUM(dbo.tarifechographie.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade LEFT OUTER JOIN
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and (convert(date,dossierechographie.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierechographie.date
                   UNION
                   SELECT     SUM(dbo.tarifsoin.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and (convert(date,dossiersoin.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiersoin.date    
                   UNION
                   SELECT     SUM(dbo.tarifnursing.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and (convert(date,dossiernursing.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiernursing.date               
                   UNION
                   SELECT     SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationgynecologique.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationgynecologique.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationpostnatal.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationpostnatal.date
                   UNION
                   SELECT     SUM(dbo.typeaccouchement.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero,dossieraccouchement.date AS dateEvent, 'Accouchement' AS DIMENSION
                   FROM         dbo.typeaccouchement INNER JOIN
                                         dbo.dossieraccouchement ON dbo.typeaccouchement.id = dbo.dossieraccouchement.id_typeaccouchement INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossieraccouchement.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id RIGHT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieraccouchement.etatpaiement = 'Non cloturé payé') OR (dbo.dossieraccouchement.etatpaiement = 'Cloturé payé')) and (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"') and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossieraccouchement.date
                   UNION
                   SELECT     SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') and (convert(date,sortie.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
                   UNION
                   SELECT     SUM(dbo.detailsautrefraie.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and (convert(date,autrefraie.dateenregistrement,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, autrefraie.dateenregistrement
                   UNION
                   SELECT     SUM(dbo.categoriechambre.prix*ISNULL(DATEDIFF(DAY,hospitalisation.datedebut,hospitalisation.datefin),0)*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, hospitalisation.datefin AS dateEvent, 'Hospitalisation' AS DIMENSION
                   FROM         dbo.hospitalisation INNER JOIN
                                         dbo.chambre ON dbo.chambre.id=dbo.hospitalisation.id_chambre INNER JOIN
                                         dbo.categoriechambre ON dbo.categoriechambre.id=dbo.chambre.id_categoriechambre INNER JOIN 
                                         dbo.malade ON dbo.malade.id=dbo.hospitalisation.id_malade INNER JOIN
                                         dbo.categoriemalade ON dbo.categoriemalade.id=dbo.malade.id_categoriemalade INNER JOIN
                                         dbo.personne ON dbo.personne.id = dbo.malade.id_personne
                   WHERE     ((dbo.hospitalisation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.hospitalisation.etatpaiement = 'Cloturé payé')) and (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, hospitalisation.datefin
                   UNION
                   SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
                   FROM         dbo.malade_avance INNER JOIN											 
                                         dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossieravance.etatpaiement = 'Cloturé payé')) and (convert(date,dossieravance.date,100) between '" + s + @"' and '" + v + @"') and ((convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"') or (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date) MES_UNIONS PIVOT (sum(VALEUR) FOR 
                   dimension IN ([examenP], [ConsultationP],[ConsultationGP],[peconsult], [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Hospitalisation],[Nursing], 
                   [InterventionP],[Accouchement],[Avance])) AS MON_PIVOT  
            GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent,numero,Avance", clsMetier.GetInstance().InitializeReport());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "doc");
            rpt.SetDataSource(ds.Tables["doc"]);
            crvRapport.ReportSource = rpt;
            crvRapport.Refresh();
            da.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }

        //Appel rapport pour Non abonné Externe
        public void loadConsommationNonAbonneExterne()
        {
            string s, v, t, x;
            t = txtDateConsNonAbonneDu.Value.ToString();
            x = txtDateConsAu.Value.ToString();
            s = t.Substring(0, 10);
            v = x.Substring(0, 10);
            rptConsommationNonAbonneExterne rpt = new rptConsommationNonAbonneExterne();
            SqlCommand cmd = null;
            cmd = new SqlCommand(@"
            
           
           SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom,numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, SUM(isnull([ConsultationP], 0)) 
              AS resultatConsult,SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, SUM(isnull([ConsultationPrenatale], 0)) 
              AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_fraie], 0)) 
              AS resultAutreFraie, SUM(isnull([InterventionP], 0)) AS resultIntervention, isnull([Avance],0) AS resultAvance, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) + SUM(isnull([ConsultationPrenatale], 0)) 
              + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) + SUM(isnull([Autre_fraie], 0)) + isnull([Avance],0) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0))   
                  AS somme
            FROM         (SELECT     SUM(dbo.examen.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero,operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id INNER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and (convert(date,operation_laboratoire.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, operation_laboratoire.date
                   UNION
                   SELECT     SUM(dbo.intervention.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade INNER JOIN 
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) and (convert(date,subit.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, subit.date
                   UNION
                   SELECT     SUM(tarifpreconsultation.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN 
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dossierpreconsultation.etatpaiement = 'Fiche payée') and (convert(date,dossierpreconsultation.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierpreconsultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultation.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) and (convert(date,consultation.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, consultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id RIGHT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationprenatale.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationprenatale.date
                   
                   UNION
                   SELECT     SUM(dbo.tarifechographie.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and (convert(date,dossierechographie.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierechographie.date
                   UNION
                   SELECT     SUM(dbo.tarifsoin.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and (convert(date,dossiersoin.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiersoin.date    
                   UNION
                   SELECT     SUM(dbo.tarifnursing.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and (convert(date,dossiernursing.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiernursing.date               
                   UNION
                   SELECT     SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationgynecologique.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationgynecologique.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationpostnatal.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationpostnatal.date
                   UNION
                   SELECT     SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') and (convert(date,sortie.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
                   UNION
                   SELECT     SUM(dbo.detailsautrefraie.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and (convert(date,autrefraie.dateenregistrement,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, autrefraie.dateenregistrement
                   UNION
                   SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
                   FROM         dbo.malade_avance INNER JOIN											 
                                         dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossieravance.etatpaiement = 'Cloturé payé')) and (convert(date,dossieravance.date,100) between '" + s + @"' and '" + v + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100) between '" + s + @"' and '" + v + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100) between '" + s + @"' and '" + v + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date) MES_UNIONS PIVOT (sum(VALEUR) FOR 
                   dimension IN ([examenP], [ConsultationP],[ConsultationGP],[peconsult], [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Nursing], 
                   [InterventionP],[Avance])) AS MON_PIVOT  
            GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent,numero,Avance", clsMetier.GetInstance().InitializeReport());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "doc");
            rpt.SetDataSource(ds.Tables["doc"]);
            crvRapport.ReportSource = rpt;
            crvRapport.Refresh();
            da.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }

        //Appel rapport pour recettes journalière des Abonne Interne
        public void loadRecetteJournaliereAbonneInterne()
        {
            string s, t;
            t = dtDateInt.Value.ToString();
            s = t.Substring(0, 10);
            rptRecetteJournaliereAbonneInterne rpt = new rptRecetteJournaliereAbonneInterne();
            SqlCommand cmd = null;
            cmd = new SqlCommand(@"
           
           SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom,numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, SUM(isnull([ConsultationP], 0)) 
              AS resultatConsult,SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, SUM(isnull([ConsultationPrenatale], 0)) 
              AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_fraie], 0)) 
              AS resultAutreFraie, SUM(isnull([Hospitalisation], 0)) AS resultHospitalisation, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([Accouchement], 0)) 
              AS resultAccouchement, isnull([Avance],0) AS resultAvance, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) + SUM(isnull([ConsultationPrenatale], 0)) 
              + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) + SUM(isnull([Autre_fraie], 0)) + SUM(isnull([Hospitalisation], 0)) + isnull([Avance],0) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0)) + SUM(isnull([Accouchement], 0))  
                  AS somme
            FROM         (SELECT     (SUM(dbo.examen.prix*categoriemalade.taux)-SUM(dbo.examen.prix*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero,operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id INNER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade LEFT OUTER JOIN 
                                          dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and (convert(date,operation_laboratoire.date,100)='" + s + @"')  and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, operation_laboratoire.date
                   UNION
                   SELECT     (SUM(dbo.intervention.prix*categoriemalade.taux)-SUM(dbo.intervention.prix*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                         hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) and (convert(date,subit.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, subit.date
                   UNION
                   SELECT     (SUM(tarifpreconsultation.montant*categoriemalade.taux)-SUM(tarifpreconsultation.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN 
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dossierpreconsultation.etatpaiement = 'Fiche payée') and (convert(date,dossierpreconsultation.date,100) ='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierpreconsultation.date
                   UNION
                   SELECT     (SUM(dbo.tarifconsultation.montant*categoriemalade.taux)-SUM(dbo.tarifconsultation.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) and (convert(date,consultation.date,100) ='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, consultation.date
                   UNION
                   SELECT     (SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux)-SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationprenatale.date,100) ='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationprenatale.date
                   
                   UNION
                   SELECT     (SUM(dbo.tarifechographie.montant*categoriemalade.taux)-SUM(dbo.tarifechographie.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade LEFT OUTER JOIN
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and (convert(date,dossierechographie.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierechographie.date
                   UNION
                   SELECT     (SUM(dbo.tarifsoin.montant*categoriemalade.taux)-SUM(dbo.tarifsoin.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and (convert(date,dossiersoin.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiersoin.date    
                   UNION
                   SELECT     (SUM(dbo.tarifnursing.montant*categoriemalade.taux)-SUM(dbo.tarifnursing.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and (convert(date,dossiernursing.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiernursing.date               
                   UNION
                   SELECT     (SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux)-SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id 
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationgynecologique.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationgynecologique.date
                   UNION
                   SELECT     (SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux)-SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationpostnatal.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationpostnatal.date
                   UNION
                   SELECT     (SUM(dbo.typeaccouchement.prix*categoriemalade.taux)-SUM(dbo.typeaccouchement.prix*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero,dossieraccouchement.date AS dateEvent, 'Accouchement' AS DIMENSION
                   FROM         dbo.typeaccouchement INNER JOIN
                                         dbo.dossieraccouchement ON dbo.typeaccouchement.id = dbo.dossieraccouchement.id_typeaccouchement INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossieraccouchement.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id RIGHT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossieraccouchement.etatpaiement = 'Non cloturé payé') OR (dbo.dossieraccouchement.etatpaiement = 'Cloturé payé')) and convert(date,dossieraccouchement.date,100)='" + s + @"' and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossieraccouchement.date
                   UNION
                   SELECT     (SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux)-SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') and (convert(date,sortie.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
                   UNION
                   SELECT     (SUM(dbo.detailsautrefraie.prix)-SUM(dbo.detailsautrefraie.prix*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and (convert(date,autrefraie.dateenregistrement,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, autrefraie.dateenregistrement
                   UNION
                   SELECT     (SUM(dbo.categoriechambre.prix*ISNULL(DATEDIFF(DAY,hospitalisation.datedebut,hospitalisation.datefin),0)*categoriemalade.taux)-SUM(dbo.categoriechambre.prix*ISNULL(DATEDIFF(DAY,hospitalisation.datedebut,hospitalisation.datefin),0)*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, hospitalisation.datefin AS dateEvent, 'Hospitalisation' AS DIMENSION
                   FROM         dbo.hospitalisation INNER JOIN
                                         dbo.chambre ON dbo.chambre.id=dbo.hospitalisation.id_chambre INNER JOIN
                                         dbo.categoriechambre ON dbo.categoriechambre.id=dbo.chambre.id_categoriechambre INNER JOIN 
                                         dbo.malade ON dbo.malade.id=dbo.hospitalisation.id_malade INNER JOIN
                                         dbo.categoriemalade ON dbo.categoriemalade.id=dbo.malade.id_categoriemalade INNER JOIN
                                         dbo.personne ON dbo.personne.id = dbo.malade.id_personne INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.hospitalisation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.hospitalisation.etatpaiement = 'Cloturé payé')) and (convert(date,hospitalisation.datefin,100)='" + s + @"') and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, hospitalisation.datefin
                   UNION
                   SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
                   FROM         dbo.malade_avance INNER JOIN											 
                                         dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossieravance.etatpaiement = 'Cloturé payé')) and (convert(date,dossieravance.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date) MES_UNIONS PIVOT (sum(VALEUR) FOR 
                   dimension IN ([examenP], [ConsultationP],[ConsultationGP],[peconsult], [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Hospitalisation],[Nursing], 
                   [InterventionP],[Accouchement],[Avance])) AS MON_PIVOT  
            GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent,numero,Avance", clsMetier.GetInstance().InitializeReport());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "doc");
            rpt.SetDataSource(ds.Tables["doc"]);
            crvRapport.ReportSource = rpt;
            crvRapport.Refresh();
            da.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }

        //Appel rapport recette journalière des Non abonne Interne 
        public void loadRecetteJournaliereNonAbonneInterne()
        {
            string s, t;
            t = dtDateInt.Value.ToString();
            s = t.Substring(0, 10);
            rptRecetteJournaliereNonAbonneInterne rpt = new rptRecetteJournaliereNonAbonneInterne();
            SqlCommand cmd = null;
            cmd = new SqlCommand(@"
           
           
           SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom,numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, SUM(isnull([ConsultationP], 0)) 
              AS resultatConsult,SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, SUM(isnull([ConsultationPrenatale], 0)) 
              AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_fraie], 0)) 
              AS resultAutreFraie, SUM(isnull([Hospitalisation], 0)) AS resultHospitalisation, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([Accouchement], 0)) 
              AS resultAccouchement, isnull([Avance],0) AS resultAvance, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) + SUM(isnull([ConsultationPrenatale], 0)) 
              + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) + SUM(isnull([Autre_fraie], 0)) + SUM(isnull([Hospitalisation], 0)) + isnull([Avance],0) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0)) + SUM(isnull([Accouchement], 0))  
                  AS somme
            FROM         (SELECT     SUM(dbo.examen.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero,operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id INNER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade LEFT OUTER JOIN 
                                          dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and (convert(date,operation_laboratoire.date,100)='" + s + @"')  and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, operation_laboratoire.date
                   UNION
                   SELECT     SUM(dbo.intervention.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                         hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) and (convert(date,subit.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, subit.date
                   UNION
                   SELECT     SUM(tarifpreconsultation.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN 
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dossierpreconsultation.etatpaiement = 'Fiche payée') and (convert(date,dossierpreconsultation.date,100) ='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierpreconsultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultation.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) and (convert(date,consultation.date,100) ='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, consultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationprenatale.date,100) ='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationprenatale.date
                   
                   UNION
                   SELECT     SUM(dbo.tarifechographie.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade LEFT OUTER JOIN
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and (convert(date,dossierechographie.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierechographie.date
                   UNION
                   SELECT     SUM(dbo.tarifsoin.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and (convert(date,dossiersoin.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiersoin.date    
                   UNION
                   SELECT     SUM(dbo.tarifnursing.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and (convert(date,dossiernursing.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiernursing.date               
                   UNION
                   SELECT     SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationgynecologique.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationgynecologique.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationpostnatal.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationpostnatal.date
                   UNION
                   SELECT     SUM(dbo.typeaccouchement.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero,dossieraccouchement.date AS dateEvent, 'Accouchement' AS DIMENSION
                   FROM         dbo.typeaccouchement INNER JOIN
                                         dbo.dossieraccouchement ON dbo.typeaccouchement.id = dbo.dossieraccouchement.id_typeaccouchement INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossieraccouchement.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id RIGHT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieraccouchement.etatpaiement = 'Non cloturé payé') OR (dbo.dossieraccouchement.etatpaiement = 'Cloturé payé')) and convert(date,dossieraccouchement.date,100)='" + s + @"' and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossieraccouchement.date
                   UNION
                   SELECT     SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') and (convert(date,sortie.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
                   UNION
                   SELECT     SUM(dbo.detailsautrefraie.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and (convert(date,autrefraie.dateenregistrement,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, autrefraie.dateenregistrement
                   UNION
                   SELECT     SUM(dbo.categoriechambre.prix*ISNULL(DATEDIFF(DAY,hospitalisation.datedebut,hospitalisation.datefin),0)*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, hospitalisation.datefin AS dateEvent, 'Hospitalisation' AS DIMENSION
                   FROM         dbo.hospitalisation INNER JOIN
                                         dbo.chambre ON dbo.chambre.id=dbo.hospitalisation.id_chambre INNER JOIN
                                         dbo.categoriechambre ON dbo.categoriechambre.id=dbo.chambre.id_categoriechambre INNER JOIN 
                                         dbo.malade ON dbo.malade.id=dbo.hospitalisation.id_malade INNER JOIN
                                         dbo.categoriemalade ON dbo.categoriemalade.id=dbo.malade.id_categoriemalade INNER JOIN
                                         dbo.personne ON dbo.personne.id = dbo.malade.id_personne
                   WHERE     ((dbo.hospitalisation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.hospitalisation.etatpaiement = 'Cloturé payé')) and (convert(date,hospitalisation.datefin,100)='" + s + @"') and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, hospitalisation.datefin
                   UNION
                   SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
                   FROM         dbo.malade_avance INNER JOIN											 
                                         dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossieravance.etatpaiement = 'Cloturé payé')) and (convert(date,dossieravance.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date) MES_UNIONS PIVOT (sum(VALEUR) FOR 
                   dimension IN ([examenP], [ConsultationP],[ConsultationGP],[peconsult], [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Hospitalisation],[Nursing], 
                   [InterventionP],[Accouchement],[Avance])) AS MON_PIVOT  
            GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent,numero,Avance", clsMetier.GetInstance().InitializeReport());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "doc");
            rpt.SetDataSource(ds.Tables["doc"]);
            crvRapport.ReportSource = rpt;
            crvRapport.Refresh();
            da.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }

        //Appel rapport recette journalière des Non abonne Interne
        public void loadRecetteJournaliereAbonneExterne()
        {
            string s, t;
            t = dtDateInt.Value.ToString();
            s = t.Substring(0, 10);
            rptRecetteJournaliereAbonneExterne rpt = new rptRecetteJournaliereAbonneExterne();
            SqlCommand cmd = null;
            cmd = new SqlCommand(@"     
           
           
           SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom,numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, SUM(isnull([ConsultationP], 0)) 
              AS resultatConsult,SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, SUM(isnull([ConsultationPrenatale], 0)) 
              AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_fraie], 0)) 
              AS resultAutreFraie, SUM(isnull([InterventionP], 0)) AS resultIntervention, isnull([Avance],0) AS resultAvance, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) + SUM(isnull([ConsultationPrenatale], 0)) 
              + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) + SUM(isnull([Autre_fraie], 0)) + isnull([Avance],0) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0))   
                  AS somme
            FROM         (SELECT     (SUM(dbo.examen.prix*categoriemalade.taux)-SUM(dbo.examen.prix*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero,operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id INNER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and (convert(date,operation_laboratoire.date,100)='" + s + @"')  and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, operation_laboratoire.date
                   UNION
                   SELECT     (SUM(dbo.intervention.prix*categoriemalade.taux)-SUM(dbo.intervention.prix*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade INNER JOIN 
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) and (convert(date,subit.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, subit.date
                   UNION
                   SELECT     (SUM(dbo.tarifpreconsultation.montant*categoriemalade.taux)-SUM(dbo.tarifpreconsultation.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN 
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dossierpreconsultation.etatpaiement = 'Fiche payée') and (convert(date,dossierpreconsultation.date,100) ='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierpreconsultation.date
                   UNION
                   SELECT    (SUM(dbo.tarifconsultation.montant*categoriemalade.taux)-SUM(dbo.tarifconsultation.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) and (convert(date,consultation.date,100) ='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, consultation.date
                   UNION
                   SELECT     (SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux)-SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id RIGHT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationprenatale.date,100) ='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationprenatale.date
                   
                   UNION
                   SELECT     (SUM(dbo.tarifechographie.montant*categoriemalade.taux)-SUM(dbo.tarifechographie.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and (convert(date,dossierechographie.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierechographie.date
                   UNION
                   SELECT     (SUM(dbo.tarifsoin.montant*categoriemalade.taux)-SUM(dbo.tarifsoin.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and (convert(date,dossiersoin.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiersoin.date    
                   UNION
                   SELECT     (SUM(dbo.tarifnursing.montant*categoriemalade.taux)-SUM(dbo.tarifnursing.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and (convert(date,dossiernursing.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiernursing.date               
                   UNION
                   SELECT     (SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux)-SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id  INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationgynecologique.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationgynecologique.date
                   UNION
                   SELECT     (SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux)-SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationpostnatal.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationpostnatal.date
                   UNION
                   SELECT     (SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux)-SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') and (convert(date,sortie.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
                   UNION
                   SELECT     (SUM(dbo.detailsautrefraie.prix)-SUM(dbo.detailsautrefraie.prix*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and (convert(date,autrefraie.dateenregistrement,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, autrefraie.dateenregistrement
                   UNION
                   SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
                   FROM         dbo.malade_avance INNER JOIN											 
                                         dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossieravance.etatpaiement = 'Cloturé payé')) and (convert(date,dossieravance.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date) MES_UNIONS PIVOT (sum(VALEUR) FOR 
                   dimension IN ([examenP], [ConsultationP],[ConsultationGP],[peconsult], [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Nursing], 
                   [InterventionP],[Avance])) AS MON_PIVOT  
            GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent,numero,Avance", clsMetier.GetInstance().InitializeReport());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "doc");
            rpt.SetDataSource(ds.Tables["doc"]);
            crvRapport.ReportSource = rpt;
            crvRapport.Refresh();
            da.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }

        //Appel rapport recette journalière des Non abonne Externe
        public void loadRecetteJournaliereNonAbonneExterne()
        {
            string s, t;
            t = dtDateInt.Value.ToString();
            s = t.Substring(0, 10);
            rptRecetteJournaliereNonAbonneExterne rpt = new rptRecetteJournaliereNonAbonneExterne();
            SqlCommand cmd = null;
            cmd = new SqlCommand(@"
           SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom,numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, SUM(isnull([ConsultationP], 0)) 
              AS resultatConsult,SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, SUM(isnull([ConsultationPrenatale], 0)) 
              AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_fraie], 0)) 
              AS resultAutreFraie, SUM(isnull([InterventionP], 0)) AS resultIntervention, isnull([Avance],0) AS resultAvance, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) + SUM(isnull([ConsultationPrenatale], 0)) 
              + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) + SUM(isnull([Autre_fraie], 0)) + isnull([Avance],0) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0))   
                  AS somme
            FROM         (SELECT     SUM(dbo.examen.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero,operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id INNER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and (convert(date,operation_laboratoire.date,100)='" + s + @"')  and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, operation_laboratoire.date
                   UNION
                   SELECT     SUM(dbo.intervention.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade INNER JOIN 
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) and (convert(date,subit.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, subit.date
                   UNION
                   SELECT     SUM(tarifpreconsultation.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN 
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dossierpreconsultation.etatpaiement = 'Fiche payée') and (convert(date,dossierpreconsultation.date,100) ='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierpreconsultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultation.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) and (convert(date,consultation.date,100) ='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, consultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id RIGHT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationprenatale.date,100) ='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationprenatale.date
                   
                   UNION
                   SELECT     SUM(dbo.tarifechographie.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and (convert(date,dossierechographie.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierechographie.date
                   UNION
                   SELECT     SUM(dbo.tarifsoin.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and (convert(date,dossiersoin.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiersoin.date    
                   UNION
                   SELECT     SUM(dbo.tarifnursing.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and (convert(date,dossiernursing.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiernursing.date               
                   UNION
                   SELECT     SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationgynecologique.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationgynecologique.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationpostnatal.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationpostnatal.date
                   UNION
                   SELECT     SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') and (convert(date,sortie.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
                   UNION
                   SELECT     SUM(dbo.detailsautrefraie.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and (convert(date,autrefraie.dateenregistrement,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, autrefraie.dateenregistrement
                   UNION
                   SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
                   FROM         dbo.malade_avance INNER JOIN											 
                                         dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossieravance.etatpaiement = 'Cloturé payé')) and (convert(date,dossieravance.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date) MES_UNIONS PIVOT (sum(VALEUR) FOR 
                   dimension IN ([examenP], [ConsultationP],[ConsultationGP],[peconsult], [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Nursing], 
                   [InterventionP],[Avance])) AS MON_PIVOT  
            GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent,numero,Avance", clsMetier.GetInstance().InitializeReport());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "doc");
            rpt.SetDataSource(ds.Tables["doc"]);
            crvRapport.ReportSource = rpt;
            crvRapport.Refresh();
            da.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }

        //Appel rapport recette globale des abonne Interne et Externe
        public void loadRecetteGlobaleAbonneInterneExterne()
        {
            string s, t;
            t = txtDateRecette.Value.ToString();
            s = t.Substring(0, 10);
            rptRecetteGlobaleAbonneInterneExterne rpt = new rptRecetteGlobaleAbonneInterneExterne();
            SqlCommand cmd = null;
            cmd = new SqlCommand(@"
            
           
           SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom,numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, SUM(isnull([ConsultationP], 0)) 
              AS resultatConsult,SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, SUM(isnull([ConsultationPrenatale], 0)) 
              AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_fraie], 0)) 
              AS resultAutreFraie, SUM(isnull([Hospitalisation], 0)) AS resultHospitalisation, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([Accouchement], 0)) 
              AS resultAccouchement, isnull([Avance],0) AS resultAvance, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) + SUM(isnull([ConsultationPrenatale], 0)) 
              + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) + SUM(isnull([Autre_fraie], 0)) + SUM(isnull([Hospitalisation], 0)) + isnull([Avance],0) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0)) + SUM(isnull([Accouchement], 0))  
                  AS somme
            FROM         (SELECT     (SUM(dbo.examen.prix*categoriemalade.taux)-SUM(dbo.examen.prix*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero,operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id INNER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade LEFT OUTER JOIN 
                                          dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and (convert(date,operation_laboratoire.date,100)='" + s + @"')  and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, operation_laboratoire.date
                   UNION
                   SELECT     (SUM(dbo.examen.prix*categoriemalade.taux)-SUM(dbo.examen.prix*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero,operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id INNER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and (convert(date,operation_laboratoire.date,100)='" + s + @"')  and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, operation_laboratoire.date
                   UNION
                   SELECT     (SUM(dbo.intervention.prix*categoriemalade.taux)-SUM(dbo.intervention.prix*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                         hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) and (convert(date,subit.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, subit.date
                   UNION
                   SELECT     (SUM(dbo.intervention.prix*categoriemalade.taux)-SUM(dbo.intervention.prix*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade INNER JOIN 
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) and (convert(date,subit.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, subit.date
                   UNION
                   SELECT     (SUM(dbo.tarifpreconsultation.montant*categoriemalade.taux)-SUM(dbo.tarifpreconsultation.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN 
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dossierpreconsultation.etatpaiement = 'Fiche payée') and (convert(date,dossierpreconsultation.date,100) ='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierpreconsultation.date
                   UNION
                   SELECT     (SUM(dbo.tarifpreconsultation.montant*categoriemalade.taux)-SUM(dbo.tarifpreconsultation.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN 
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dossierpreconsultation.etatpaiement = 'Fiche payée') and (convert(date,dossierpreconsultation.date,100) ='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierpreconsultation.date
                   UNION
                   SELECT     (SUM(dbo.tarifconsultation.montant*categoriemalade.taux)-SUM(dbo.tarifconsultation.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) and (convert(date,consultation.date,100) ='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, consultation.date
                   UNION
                   SELECT     (SUM(dbo.tarifconsultation.montant*categoriemalade.taux)-SUM(dbo.tarifconsultation.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) and (convert(date,consultation.date,100) ='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, consultation.date
                   UNION
                   SELECT     (SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux)-SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationprenatale.date,100) ='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationprenatale.date
                   UNION
                   SELECT     (SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux)-SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id RIGHT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationprenatale.date,100) ='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationprenatale.date
                   UNION
                   SELECT     (SUM(dbo.tarifechographie.montant*categoriemalade.taux)-SUM(dbo.tarifechographie.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade LEFT OUTER JOIN
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and (convert(date,dossierechographie.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierechographie.date
                   UNION
                   SELECT     (SUM(dbo.tarifechographie.montant*categoriemalade.taux)-SUM(dbo.tarifechographie.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and (convert(date,dossierechographie.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierechographie.date
                   UNION
                   SELECT     (SUM(dbo.tarifsoin.montant*categoriemalade.taux)-SUM(dbo.tarifsoin.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and (convert(date,dossiersoin.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiersoin.date  
                   UNION
                   SELECT     (SUM(dbo.tarifsoin.montant*categoriemalade.taux)-SUM(dbo.tarifsoin.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and (convert(date,dossiersoin.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiersoin.date  
                   UNION
                   SELECT     (SUM(dbo.tarifnursing.montant*categoriemalade.taux)-SUM(dbo.tarifnursing.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and (convert(date,dossiernursing.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiernursing.date    
                   UNION
                   SELECT     (SUM(dbo.tarifnursing.montant*categoriemalade.taux)-SUM(dbo.tarifnursing.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and (convert(date,dossiernursing.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiernursing.date            
                   UNION
                   SELECT     (SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux)-SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationgynecologique.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationgynecologique.date
                   UNION
                   SELECT     (SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux)-SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationgynecologique.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationgynecologique.date
                   UNION
                   SELECT     (SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux)-SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationpostnatal.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationpostnatal.date
                   UNION
                   SELECT     (SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux)-SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationpostnatal.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationpostnatal.date
                   UNION
                   SELECT     (SUM(dbo.typeaccouchement.prix*categoriemalade.taux)-SUM(dbo.typeaccouchement.prix*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero,dossieraccouchement.date AS dateEvent, 'Accouchement' AS DIMENSION
                   FROM         dbo.typeaccouchement INNER JOIN
                                         dbo.dossieraccouchement ON dbo.typeaccouchement.id = dbo.dossieraccouchement.id_typeaccouchement INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossieraccouchement.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id RIGHT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossieraccouchement.etatpaiement = 'Non cloturé payé') OR (dbo.dossieraccouchement.etatpaiement = 'Cloturé payé')) and convert(date,dossieraccouchement.date,100)='" + s + @"' and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossieraccouchement.date
                   UNION
                   SELECT     (SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux)-SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') and (convert(date,sortie.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
                   UNION
                   SELECT     (SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux)-SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') and (convert(date,sortie.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
                   UNION
                   SELECT     (SUM(dbo.detailsautrefraie.prix)-SUM(dbo.detailsautrefraie.prix*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and (convert(date,autrefraie.dateenregistrement,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, autrefraie.dateenregistrement
                   UNION
                   SELECT     (SUM(dbo.detailsautrefraie.prix)-SUM(dbo.detailsautrefraie.prix*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and (convert(date,autrefraie.dateenregistrement,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, autrefraie.dateenregistrement
                   UNION
                   SELECT     (SUM(dbo.categoriechambre.prix*ISNULL(DATEDIFF(DAY,hospitalisation.datedebut,hospitalisation.datefin),0)*categoriemalade.taux)-SUM(dbo.categoriechambre.prix*ISNULL(DATEDIFF(DAY,hospitalisation.datedebut,hospitalisation.datefin),0)*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, hospitalisation.datefin AS dateEvent, 'Hospitalisation' AS DIMENSION
                   FROM         dbo.hospitalisation INNER JOIN
                                         dbo.chambre ON dbo.chambre.id=dbo.hospitalisation.id_chambre INNER JOIN
                                         dbo.categoriechambre ON dbo.categoriechambre.id=dbo.chambre.id_categoriechambre INNER JOIN 
                                         dbo.malade ON dbo.malade.id=dbo.hospitalisation.id_malade INNER JOIN
                                         dbo.categoriemalade ON dbo.categoriemalade.id=dbo.malade.id_categoriemalade INNER JOIN
                                         dbo.personne ON dbo.personne.id = dbo.malade.id_personne INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.hospitalisation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.hospitalisation.etatpaiement = 'Cloturé payé')) and (convert(date,hospitalisation.datefin,100)='" + s + @"') and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, hospitalisation.datefin
                   UNION
                   SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
                   FROM         dbo.malade_avance INNER JOIN											 
                                         dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossieravance.etatpaiement = 'Cloturé payé')) and (convert(date,dossieravance.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date
                   UNION
                   SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
                   FROM         dbo.malade_avance INNER JOIN											 
                                         dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossieravance.etatpaiement = 'Cloturé payé')) and (convert(date,dossieravance.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date) MES_UNIONS PIVOT (sum(VALEUR) FOR 
                   dimension IN ([examenP], [ConsultationP],[ConsultationGP],[peconsult], [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Hospitalisation],[Nursing], 
                   [InterventionP],[Accouchement],[Avance])) AS MON_PIVOT  
            GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent,numero,Avance", clsMetier.GetInstance().InitializeReport());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "doc");
            rpt.SetDataSource(ds.Tables["doc"]);
            crvRapport.ReportSource = rpt;
            crvRapport.Refresh();
            da.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }

        //Appel rapport recette globale des non abonne Interne et Externe
        public void loadRecetteGlobaleNonAbonneInterneExterne()
        {
            string s, t;
            t = txtDateRecette.Value.ToString();
            s = t.Substring(0, 10);
            rptRecetteGlobaleNonAbonneInterneExterne rpt = new rptRecetteGlobaleNonAbonneInterneExterne();
            SqlCommand cmd = null;
            cmd = new SqlCommand(@"
            
           
           SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom,numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, SUM(isnull([ConsultationP], 0)) 
              AS resultatConsult,SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, SUM(isnull([ConsultationPrenatale], 0)) 
              AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_fraie], 0)) 
              AS resultAutreFraie, SUM(isnull([Hospitalisation], 0)) AS resultHospitalisation, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([Accouchement], 0)) 
              AS resultAccouchement, isnull([Avance],0) AS resultAvance, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) + SUM(isnull([ConsultationPrenatale], 0)) 
              + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) + SUM(isnull([Autre_fraie], 0)) + SUM(isnull([Hospitalisation], 0)) + isnull([Avance],0) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0)) + SUM(isnull([Accouchement], 0))  
                  AS somme
            FROM         (SELECT     SUM(dbo.examen.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero,operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id INNER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade LEFT OUTER JOIN 
                                          dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and (convert(date,operation_laboratoire.date,100)='" + s + @"')  and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, operation_laboratoire.date
                   UNION
                   SELECT     SUM(dbo.examen.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero,operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id INNER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and (convert(date,operation_laboratoire.date,100)='" + s + @"')  and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, operation_laboratoire.date
                   UNION
                   SELECT     SUM(dbo.intervention.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                         hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) and (convert(date,subit.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, subit.date
                   UNION
                   SELECT     SUM(dbo.intervention.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade INNER JOIN 
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) and (convert(date,subit.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, subit.date
                   UNION
                   SELECT     SUM(tarifpreconsultation.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN 
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dossierpreconsultation.etatpaiement = 'Fiche payée') and (convert(date,dossierpreconsultation.date,100) ='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierpreconsultation.date
                   UNION
                   SELECT     SUM(tarifpreconsultation.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN 
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dossierpreconsultation.etatpaiement = 'Fiche payée') and (convert(date,dossierpreconsultation.date,100) ='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierpreconsultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultation.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) and (convert(date,consultation.date,100) ='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, consultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultation.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) and (convert(date,consultation.date,100) ='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, consultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationprenatale.date,100) ='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationprenatale.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id RIGHT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationprenatale.date,100) ='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationprenatale.date
                   UNION
                   SELECT     SUM(dbo.tarifechographie.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade LEFT OUTER JOIN
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and (convert(date,dossierechographie.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierechographie.date
                   UNION
                   SELECT     SUM(dbo.tarifechographie.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and (convert(date,dossierechographie.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierechographie.date
                   UNION
                   SELECT     SUM(dbo.tarifsoin.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and (convert(date,dossiersoin.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiersoin.date   
                   UNION
                   SELECT     SUM(dbo.tarifsoin.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and (convert(date,dossiersoin.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiersoin.date 
                   UNION
                   SELECT     SUM(dbo.tarifnursing.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and (convert(date,dossiernursing.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiernursing.date  
                   UNION
                   SELECT     SUM(dbo.tarifnursing.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and (convert(date,dossiernursing.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiernursing.date             
                   UNION
                   SELECT     SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationgynecologique.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationgynecologique.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationgynecologique.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationgynecologique.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationpostnatal.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationpostnatal.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) and (convert(date,dossierconsultationpostnatal.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationpostnatal.date
                   UNION
                   SELECT     SUM(dbo.typeaccouchement.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero,dossieraccouchement.date AS dateEvent, 'Accouchement' AS DIMENSION
                   FROM         dbo.typeaccouchement INNER JOIN
                                         dbo.dossieraccouchement ON dbo.typeaccouchement.id = dbo.dossieraccouchement.id_typeaccouchement INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossieraccouchement.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id RIGHT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieraccouchement.etatpaiement = 'Non cloturé payé') OR (dbo.dossieraccouchement.etatpaiement = 'Cloturé payé')) and convert(date,dossieraccouchement.date,100)='" + s + @"' and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossieraccouchement.date
                   UNION
                   SELECT     SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') and (convert(date,sortie.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
                   UNION
                   SELECT     SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') and (convert(date,sortie.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
                   UNION
                   SELECT     SUM(dbo.detailsautrefraie.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and (convert(date,autrefraie.dateenregistrement,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, autrefraie.dateenregistrement
                   UNION
                   SELECT     SUM(dbo.detailsautrefraie.prix*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and (convert(date,autrefraie.dateenregistrement,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, autrefraie.dateenregistrement
                   UNION
                   SELECT     SUM(dbo.categoriechambre.prix*ISNULL(DATEDIFF(DAY,hospitalisation.datedebut,hospitalisation.datefin),0)*categoriemalade.taux) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, hospitalisation.datefin AS dateEvent, 'Hospitalisation' AS DIMENSION
                   FROM         dbo.hospitalisation INNER JOIN
                                         dbo.chambre ON dbo.chambre.id=dbo.hospitalisation.id_chambre INNER JOIN
                                         dbo.categoriechambre ON dbo.categoriechambre.id=dbo.chambre.id_categoriechambre INNER JOIN 
                                         dbo.malade ON dbo.malade.id=dbo.hospitalisation.id_malade INNER JOIN
                                         dbo.categoriemalade ON dbo.categoriemalade.id=dbo.malade.id_categoriemalade INNER JOIN
                                         dbo.personne ON dbo.personne.id = dbo.malade.id_personne
                   WHERE     ((dbo.hospitalisation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.hospitalisation.etatpaiement = 'Cloturé payé')) and (convert(date,hospitalisation.datefin,100)='" + s + @"') and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, hospitalisation.datefin
                   UNION
                   SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
                   FROM         dbo.malade_avance INNER JOIN											 
                                         dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade LEFT OUTER JOIN 
                                         dbo.dossieraccouchement ON dbo.malade.id = dbo.dossieraccouchement.id_malade FULL OUTER JOIN
                                          hospitalisation on malade.id=hospitalisation.id_malade RIGHT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossieravance.etatpaiement = 'Cloturé payé')) and (convert(date,dossieravance.date,100)='" + s + @"') and ((convert(date,hospitalisation.datefin,100)='" + s + @"') or (convert(date,dossieraccouchement.date,100)='" + s + @"')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date
                   UNION
                   SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
                   FROM         dbo.malade_avance INNER JOIN											 
                                         dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossieravance.etatpaiement = 'Cloturé payé')) and (convert(date,dossieravance.date,100)='" + s + @"') and (malade.id not in(SELECT hospitalisation.id_malade FROM hospitalisation where (hospitalisation.id_malade in (select hospitalisation.id_malade from hospitalisation where (convert(date,hospitalisation.datefin,100)='" + s + @"'))))) and (malade.id not in(SELECT dossieraccouchement.id_malade FROM dossieraccouchement where (dossieraccouchement.id_malade in (select dossieraccouchement.id_malade from dossieraccouchement where (convert(date,dossieraccouchement.date,100)='" + s + @"'))))) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date) MES_UNIONS PIVOT (sum(VALEUR) FOR 
                   dimension IN ([examenP], [ConsultationP],[ConsultationGP],[peconsult], [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Hospitalisation],[Nursing], 
                   [InterventionP],[Accouchement],[Avance])) AS MON_PIVOT  
            GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent,numero,Avance", clsMetier.GetInstance().InitializeReport());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "doc");
            rpt.SetDataSource(ds.Tables["doc"]);
            crvRapport.ReportSource = rpt;
            crvRapport.Refresh();
            da.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }
        #endregion

        private void rdMalade_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMalade.Checked)
            {
                txtMontantClient.Visible = true;
                txtMontantMituelle.Visible = true;
                label7.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
            }
        }

        private void rdMituelle_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMituelle.Checked)
            {
                txtMontantClient.Visible = false;
                txtMontantMituelle.Visible = false;
                label7.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
            }
        }

        private void btnAnnulerPayement_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment annuler ce paiement?", "Annulation du paiement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc.DataSource != null)
                    {
                        lstArticles.DataSource = clsMetier.GetInstance().getAllClsarticle_paye1(((clspaiement)dgv.SelectedRows[0].DataBoundItem).Id);
                        blnDataSourceDefine = true;
                        for (int i = 0; i < lstArticles.Items.Count; i++)
                        {
                            if (((clsarticle_paye)lstArticles.Items[i]).Designation_classe == "clsoperation_laboratoire")
                            {
                                id_op = ((clsarticle_paye)lstArticles.Items[i]).Id_article;
                                clsMetier.GetInstance().updateClsoperation_laboratoire(id_op, clsMetier.GetInstance().getClsoperation_laboratoire1(id_op).Etatpaiement);
                            }
                            if (((clsarticle_paye)lstArticles.Items[i]).Designation_classe == "clschambre")
                            {
                                id_hosp = ((clsarticle_paye)lstArticles.Items[i]).Id_article;
                                clsMetier.GetInstance().updateClshospitalisation(id_hosp, clsMetier.GetInstance().getClshospitalisation1(id_hosp).Etatpaiement);
                            }
                            if (((clsarticle_paye)lstArticles.Items[i]).Designation_classe == "clstarifpreconsultation")
                            {
                                id_pre = ((clsarticle_paye)lstArticles.Items[i]).Id_article;
                                clsMetier.GetInstance().updateClsdossierpreconsultation(id_pre);
                            }
                            if (((clsarticle_paye)lstArticles.Items[i]).Designation_classe == "clstarifconsultation")
                            {
                                id_cons = ((clsarticle_paye)lstArticles.Items[i]).Id_article;
                                clsMetier.GetInstance().updateClsconsultation(id_cons, clsMetier.GetInstance().getClsconsultation1(id_cons).Etatpaiement);
                            }
                            if (((clsarticle_paye)lstArticles.Items[i]).Designation_classe == "clstarifconsultationgynecologique")
                            {
                                id_cons_gyn = ((clsarticle_paye)lstArticles.Items[i]).Id_article;
                                clsMetier.GetInstance().updateClsdossierconsultationgynecologique(id_cons_gyn, clsMetier.GetInstance().getClsdossierconsultationgynecologique1(id_cons_gyn).Etatpaiement);
                            }
                            if (((clsarticle_paye)lstArticles.Items[i]).Designation_classe == "clstarifconsultationprenatal")
                            {
                                id_cons_pre = ((clsarticle_paye)lstArticles.Items[i]).Id_article;
                                clsMetier.GetInstance().updateClsdossierconsultationprenatale(id_cons_pre, clsMetier.GetInstance().getClsdossierconsultationprenatale1(id_cons_pre).Etatpaiement);
                            }
                            if (((clsarticle_paye)lstArticles.Items[i]).Designation_classe == "clstarifconsultationpostnatal")
                            {
                                id_cons_post = ((clsarticle_paye)lstArticles.Items[i]).Id_article;
                                clsMetier.GetInstance().updateClsdossierconsultationpostnatale(id_cons_post, clsMetier.GetInstance().getClsdossierconsultationpostnatale1(id_cons_post).Etatpaiement);
                            }
                            if (((clsarticle_paye)lstArticles.Items[i]).Designation_classe == "clstarifechographie")
                            {
                                id_echographi = ((clsarticle_paye)lstArticles.Items[i]).Id_article;
                                clsMetier.GetInstance().updateClsdossierechographie(id_echographi, clsMetier.GetInstance().getClsdossierechographie1(id_echographi).Etatpaiement);
                            }
                            if (((clsarticle_paye)lstArticles.Items[i]).Designation_classe == "clstarifsoin")
                            {
                                id_soin = ((clsarticle_paye)lstArticles.Items[i]).Id_article;
                                clsMetier.GetInstance().updateClsdossiersoin(id_soin, clsMetier.GetInstance().getClsdossiersoin1(id_soin).Etatpaiement);
                            }
                            if (((clsarticle_paye)lstArticles.Items[i]).Designation_classe == "clstypeaccouchement")
                            {
                                id_accouchement = ((clsarticle_paye)lstArticles.Items[i]).Id_article;
                                clsMetier.GetInstance().updateClsdossierconsultationaccouchement(id_accouchement, clsMetier.GetInstance().getClsdossierconsultationaccouchement1(id_accouchement).Etatpaiement);
                            }

                            if (((clsarticle_paye)lstArticles.Items[i]).Designation_classe == "clsintervention")
                            {
                                id_sub = ((clsarticle_paye)lstArticles.Items[i]).Id_article;
                                clsMetier.GetInstance().updateClssubit(id_sub, clsMetier.GetInstance().getClssubit1(id_sub).Etatpaiement);
                            }
                            if (((clsarticle_paye)lstArticles.Items[i]).Designation_classe == "clsarticle")
                            {
                                id_sort = ((clsarticle_paye)lstArticles.Items[i]).Id_article;
                                clsMetier.GetInstance().updateClssortie(id_sort);
                            }
                            if (((clsarticle_paye)lstArticles.Items[i]).Designation_classe == "clsautrefraie")
                            {
                                id_sort_ext = ((clsarticle_paye)lstArticles.Items[i]).Id_article;
                                clsMetier.GetInstance().updateClsautrefraie(id_sort_ext);
                            }
                            if (((clsarticle_paye)lstArticles.Items[i]).Designation_classe == "clstarifnursing")
                            {
                                id_nursing = ((clsarticle_paye)lstArticles.Items[i]).Id_article;
                                clsMetier.GetInstance().updateClsdossiernursing(id_nursing, clsMetier.GetInstance().getClsdossiernursing1(id_nursing).Etatpaiement);
                            }
                        }
                        clsMetier.GetInstance().deleteClsarticle_paye_paiement(((clspaiement)dgv.SelectedRows[0].DataBoundItem).Id);
                        clsMetier.GetInstance().deleteClsfacturation(((clspaiement)dgv.SelectedRows[0].DataBoundItem).Id);

                        //clspaiement p = (clspaiement)bsrc.Current;
                        new clspaiement().delete((clspaiement)bsrc.Current);
                        MessageBox.Show("Votre paiement a été annulé avec succès !!", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de l'annulation de paiment" + ex.Message, "Annulation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblConsultationGyneco_Click(object sender, EventArgs e)
        {
            pnAffichage.Controls.Clear();
            DossierConsultationGynecoPaiementFrm2 frm = new DossierConsultationGynecoPaiementFrm2();
            frm.Parent = pnAffichage;
        }

        private void lstconsultationgynecologique_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateListItems(lstTarifConsultation);
                ActivateListItems(lstIntervention);
                ActivateListItems(lstMedicament);
                ActivateListItems(lstChambreOccupe);
                ActivateListItems(lstCPN);
                ActivateListItems(lstCPOS);
                ActivateListItems(lstEchographie);
                ActivateListItems(lstSoins);
                ActivateListItems(lstPreconsultation);
                ActivateListItems(lstAutresFrais);
                ActivateListItems(lstLaboratoire);
                ActivateListItems(lstTypeAccouchement);
                ActivateListItems(lstNursing);
            }
            catch (Exception) { }
        }

        private void lblDossierConsultationPre_Click(object sender, EventArgs e)
        {
            pnAffichage.Controls.Clear();
            DossierConsultationPrenataleFrm2 frm = new DossierConsultationPrenataleFrm2();
            frm.Parent = pnAffichage;
        }

        private void txtDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dateFacturation = Convert.ToDateTime(txtDate.Value.ToString().Substring(0, 10));//Convert.ToDateTime(txtDate.Text);
            }
            catch (Exception) { }
        }

        private void lblSoins_Click(object sender, EventArgs e)
        {
            pnAffichage.Controls.Clear();
            DossierSoinsFrm2 frm = new DossierSoinsFrm2();
            frm.Parent = pnAffichage;
        }

        private void lstEchographie_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateListItems(lstTarifConsultation);
                ActivateListItems(lstIntervention);
                ActivateListItems(lstMedicament);
                ActivateListItems(lstChambreOccupe);
                ActivateListItems(lstCPN);
                ActivateListItems(lstCPOS);
                ActivateListItems(lstSoins);
                ActivateListItems(lstPreconsultation);
                ActivateListItems(lstAutresFrais);
                ActivateListItems(lstTypeAccouchement);
                ActivateListItems(lstconsultationgynecologique);
                ActivateListItems(lstNursing);
            }
            catch (Exception) { }
        }

        private void lblEchographie_Click(object sender, EventArgs e)
        {
            pnAffichage.Controls.Clear();
            DossierEchographieFrm2 frm = new DossierEchographieFrm2();
            frm.Parent = pnAffichage;
        }

        private void lstSoins_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateListItems(lstTarifConsultation);
                ActivateListItems(lstIntervention);
                ActivateListItems(lstMedicament);
                ActivateListItems(lstChambreOccupe);
                ActivateListItems(lstCPN);
                ActivateListItems(lstCPOS);
                ActivateListItems(lstEchographie);
                ActivateListItems(lstPreconsultation);
                ActivateListItems(lstAutresFrais);
                ActivateListItems(lstTypeAccouchement);
                ActivateListItems(lstconsultationgynecologique);
                ActivateListItems(lstNursing);
            }
            catch (Exception) { }
        }

        private void lstNursing_Click(object sender, EventArgs e)
        {
            try
            {
                ActivateListItems(lstTarifConsultation);
                ActivateListItems(lstChambreOccupe);
                ActivateListItems(lstMedicament);
                ActivateListItems(lstCPOS);
                ActivateListItems(lstCPN);
                ActivateListItems(lstEchographie);
                ActivateListItems(lstSoins);
                ActivateListItems(lstLaboratoire);
                ActivateListItems(lstPreconsultation);
                ActivateListItems(lstTypeAccouchement);
                ActivateListItems(lstIntervention);
                ActivateListItems(lstconsultationgynecologique);
            }
            catch (Exception) { }
        }

        private void lblNursing_Click(object sender, EventArgs e)
        {
            pnAffichage.Controls.Clear();
            DossierNursingFrm2 frm = new DossierNursingFrm2();
            frm.Parent = pnAffichage;
        }

        private void lblChambre_Click(object sender, EventArgs e)
        {
            pnAffichage.Controls.Clear();
            DossierHospitalisationPaiementFrm2 frm = new DossierHospitalisationPaiementFrm2();
            frm.Parent = pnAffichage;
        }

        private void lstAutresFrais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblCodeAutreFrais.Text = clsMetier.GetInstance().getClsautrefraie_Autrefraie(((clsdetailsautrefraie)lstAutresFrais.SelectedItem).Id).ToString();
            }
            catch (Exception) { }
        }

        private void lblAutreFrais_Click(object sender, EventArgs e)
        {
            TarifsFrm fr = new TarifsFrm();
            fr.setFormPrincipal(principal);
            fr.Icon = principal.Icon;
            fr.ShowDialog();
        }

        private void lblRecherche_Click(object sender, EventArgs e)
        {
            RecherchePersonneMaladeFrm fr = new RecherchePersonneMaladeFrm();
            fr.setFormPrincipal(principal);
            fr.Icon = principal.Icon;
            fr.ShowDialog();
        }

        private void cmdLoadData_Click(object sender, EventArgs e)
        {
            #region Chargement Data
            try
            {
                lblCodeAutreFrais.Text = "";
                identifiantMalade = clsDoTraitement.IdMalade;
                clsDoTraitement.idMaladeDossierPre = clsDoTraitement.IdMalade;
                malade.Id = clsDoTraitement.IdMalade;
                categorie_malade = clsDoTraitement.doubleclic_categorie_malade;
                lblCategorie.Text = categorie_malade;
                lblNomMalade.Text = clsDoTraitement.doubleclic_nom_malade;
                lblEntreprise.Text = clsDoTraitement.doubleclic_entreprise;
                taux = clsDoTraitement.doubleclic_taux;
                txtId_DuMalade.Text = malade.Id.ToString();

                //Réinitialisation des valeurs contenant le montant et les Id pour paiement
                listIdArticle.Clear();
                listMontantArticle.Clear();
                txtMontantDu.Clear();
                //Réinitialisation du montant total
                montantdu = 0;
                //lstArticles.Items.Clear();
                if (lstArticles.Items.Count > 0)
                {
                    lstArticles.DataSource = null;
                    blnDataSourceDefine = true;
                }

                try
                {
                    pbPhotoPersonne.Image = clsDoTraitement.GetInstance().getImageFromByte(clsMetier.GetInstance().getClsmalade1(malade.Id).Photo);
                }
                catch (Exception) { }

                if (tabPaiement.SelectedIndex == 0)
                {
                    if (categorie_malade.Equals("Non abonné"))
                    {
                        rdMituelle.Checked = false;
                        rdMituelle.Enabled = false;
                    }
                    else
                    {
                        rdMituelle.Enabled = true;
                    }
                    if (rdMalade.Checked == false && rdMituelle.Checked == false)
                    {
                        MessageBox.Show("Veuillez séléctionner une rubrique svp", "Affichage des paiements", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv.Enabled = false;
                        dgv1.Enabled = false;
                    }
                    else if ((categorie_malade.Equals("Abonné") && rdMalade.Checked == true) || categorie_malade.Equals("Non abonné"))
                    {
                        dgv.Enabled = true;
                        dgv1.Enabled = true;

                        #region Chargement paiement pour malade

                        try
                        {
                            //bindingcls();
                            if ((categorie_malade.Equals("Abonné") && rdMalade.Checked == true) || categorie_malade.Equals("Non abonné"))
                            {
                                bsrc.DataSource = clsMetier.GetInstance().getAllClspaiement(malade.Id);
                                bsrc1.DataSource = clsMetier.GetInstance().getAllClspaiement1(malade.Id);

                                dgv.DataSource = bsrc;
                                dgv1.DataSource = bsrc1;

                                #region Chargement des tarifs pour les produits consomés par le malade
                                try
                                {
                                    lstTarifConsultation.DataSource = clsMetier.GetInstance().getAllClsconsultationtarifpaiement(malade.Id);
                                    lstChambreOccupe.DataSource = clsMetier.GetInstance().getAllClschambretarifpaiement(malade.Id);
                                    lstIntervention.DataSource = clsMetier.GetInstance().getAllClstarifinterventionpaiement(malade.Id);
                                    lstMedicament.DataSource = clsMetier.GetInstance().getAllClsmedicamenttarifpaiement(malade.Id);
                                    lstconsultationgynecologique.DataSource = clsMetier.GetInstance().getAllClsconsultationgynecologiquetarifpaiement(malade.Id);
                                    lstCPN.DataSource = clsMetier.GetInstance().getAllCltarifconsultationprenataltarifpaiement(malade.Id);
                                    lstCPOS.DataSource = clsMetier.GetInstance().getAllClstarifconsultationpostnataltarifpaiement(malade.Id);
                                    lstLaboratoire.DataSource = clsMetier.GetInstance().getAllClsoperation_laboratoiretarifpaiement(malade.Id);
                                    lstPreconsultation.DataSource = clsMetier.GetInstance().getAllClspreconsultationtarifpaiement(malade.Id);
                                    lstAutresFrais.DataSource = clsMetier.GetInstance().getAllClstarifautrespaiement(malade.Id);
                                    lstTypeAccouchement.DataSource = clsMetier.GetInstance().getAllClstypeaccouchementPaiement(malade.Id);
                                    lstEchographie.DataSource = clsMetier.GetInstance().getAllCltarifechographietarifpaiement(malade.Id);
                                    lstSoins.DataSource = clsMetier.GetInstance().getAllClstarifsointarifpaiement(malade.Id);
                                    lstNursing.DataSource = clsMetier.GetInstance().getAllClstarifnursingtarifpaiement(malade.Id);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Erreur de chargement de la liste des tarifs", "Erreur de Chargement");
                                }

                                try
                                {
                                    ActivateListItems(lstIntervention);
                                    ActivateListItems(lstChambreOccupe);
                                    ActivateListItems(lstTarifConsultation);
                                    ActivateListItems(lstMedicament);
                                    ActivateListItems(lstconsultationgynecologique);
                                    ActivateListItems(lstLaboratoire);
                                    ActivateListItems(lstCPOS);
                                    ActivateListItems(lstCPN);
                                    ActivateListItems(lstPreconsultation);
                                    ActivateListItems(lstAutresFrais);
                                    ActivateListItems(lstTypeAccouchement);
                                    ActivateListItems(lstEchographie);
                                    ActivateListItems(lstSoins);
                                    ActivateListItems(lstNursing);
                                }
                                catch (Exception) { }
                                #endregion Fin Chargement des tarifs pour les produits consomés par le malade

                                #region Recalculage du sous total
                                try
                                {
                                    lblSousTotChambre.Text = recalculateSoustotal(lstChambreOccupe).ToString();
                                    lblSousTotIntervention.Text = recalculateSoustotal(lstIntervention).ToString();
                                    lblSousTotConsultation.Text = recalculateSoustotal(lstTarifConsultation).ToString();
                                    lblsoustotalgynecologique.Text = recalculateSoustotal(lstconsultationgynecologique).ToString();
                                    lblSousTotMedicament.Text = recalculateSoustotal(lstMedicament).ToString();
                                    lblSousTotLaboratoire.Text = recalculateSoustotal(lstLaboratoire).ToString();
                                    lblSousTotCPOS.Text = recalculateSoustotal(lstCPOS).ToString();
                                    lblSousTotCPN.Text = recalculateSoustotal(lstCPN).ToString();
                                    lblSousTotPreconsultation.Text = recalculateSoustotal(lstPreconsultation).ToString();
                                    lblSousTotAutresFrais.Text = recalculateSoustotal(lstAutresFrais).ToString();
                                    lblSousTotTypeAccouchement.Text = recalculateSoustotal(lstTypeAccouchement).ToString();
                                    lblSousTotEchographie.Text = recalculateSoustotal(lstEchographie).ToString();
                                    lblSousTotSoins.Text = recalculateSoustotal(lstSoins).ToString();
                                    lblSousTotNursing.Text = recalculateSoustotal(lstNursing).ToString();

                                    //Calcul du montant du en faisant la somme des tous les sous totaux
                                    if (!categorie_malade.Equals("Abonné") || categorie_malade.Equals("Abonné") && (Convert.ToDouble(((clspaiement)(clsMetier.GetInstance().getClspaiement2(identifiantMalade))).Dette) == 0))
                                    {
                                        montantdu = (((Convert.ToDouble(lblSousTotChambre.Text)) +
                                                    (Convert.ToDouble(lblSousTotIntervention.Text)) +
                                                    (Convert.ToDouble(lblSousTotConsultation.Text)) +
                                                    (Convert.ToDouble(lblSousTotMedicament.Text)) +
                                                    (Convert.ToDouble(lblSousTotLaboratoire.Text)) +
                                                    (Convert.ToDouble(lblSousTotCPOS.Text)) +
                                                    (Convert.ToDouble(lblSousTotCPN.Text)) +
                                                    (Convert.ToDouble(lblsoustotalgynecologique.Text)) +
                                                    (Convert.ToDouble(lblSousTotPreconsultation.Text))  +
                                                    (Convert.ToDouble(lblSousTotEchographie.Text)) +
                                                    (Convert.ToDouble(lblSousTotSoins.Text)) +
                                                    (Convert.ToDouble(lblSousTotNursing.Text)) +
                                                    (Convert.ToDouble(lblSousTotTypeAccouchement.Text))) * taux) +
                                                    (Convert.ToDouble(lblSousTotAutresFrais.Text));

                                        txtMontantDu.Text = Math.Round(montantdu, 2).ToString();
                                        totMontantDu = montantdu;
                                        txtMontantPaye.Text = txtMontantDu.Text;
                                    }
                                    else
                                    {
                                        montantdu = Convert.ToDouble(((clspaiement)(clsMetier.GetInstance().getClspaiement2(identifiantMalade))).Montantdu);
                                        txtMontantDu.Text = Math.Round(montantdu, 2).ToString();
                                        totMontantDu = montantdu;
                                    }

                                    //Recalculage des valeur pour mituel et malade abonne
                                    if (categorie_malade.Equals("Abonné"))
                                    {
                                        if (dgv.RowCount > 0)
                                        {
                                            montantMituel = (clsMetier.GetInstance().getClsetablissementpriseencharge(identifiantMalade).Taux) * ((clspaiement)dgv.SelectedRows[0].DataBoundItem).Montantdu;
                                            txtMontantMituelle.Text = Math.Round(montantMituel, 2).ToString();
                                            montantClient = ((clspaiement)dgv.SelectedRows[0].DataBoundItem).Montantdu - montantMituel;
                                            oldMontantDette = Math.Round((montantClient - clsMetier.GetInstance().getTotmontantpaiement(identifiantMalade)), 2);
                                            txtMontantDetteRestante.Text = oldMontantDette.ToString();
                                        }
                                        else
                                        {
                                            montantMituel = (clsMetier.GetInstance().getClsetablissementpriseencharge(identifiantMalade).Taux) * montantdu;
                                            txtMontantMituelle.Text = Math.Round(montantMituel, 2).ToString();
                                            montantClient = montantdu - montantMituel;
                                            oldMontantDette = Math.Round((montantClient - clsMetier.GetInstance().getTotmontantpaiement(identifiantMalade)), 2);
                                            txtMontantDetteRestante.Text = oldMontantDette.ToString();
                                        }
                                        //chkAvance.Enabled = true;
                                        //txtMontantAvance.Enabled = true;
                                        //txtMontantAvance.Text = "0";
                                        txtMontantClient.Text = Math.Round(montantClient, 2).ToString();
                                    }
                                    else
                                    {
                                        gpAvance.Enabled = false;
                                        //chkAvance.Enabled = false;
                                        //chkAvance.Checked = false;
                                        txtMontantMituelle.Clear();
                                        txtMontantClient.Clear();
                                        txtMontantDette.Clear();
                                        txtMontantDetteRestante.Clear();
                                    }

                                    //S'il n'ya pas d'enregistrement de paiement pour le malade sélectionné, on vide le datagridview
                                    filDgvPaiement();
                                }
                                catch (Exception) { MessageBox.Show("Erreur lors du calcul du sous total", "Calcul du sous total d'une rubrique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                                #endregion Fin Recalculage du sous total

                            }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message + " >>>> Erreur lors du chargement des paiements du malade", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                        #endregion Fin chargement paiemnt pour malade
                    }
                    else if (categorie_malade.Equals("Abonné") && rdMituelle.Checked == true)
                    {
                        dgv.Enabled = true;
                        dgv1.Enabled = true;

                        #region Chargement paiment pour mituelle
                        montant_mituel = Math.Round(clsMetier.GetInstance().getMontantMituellepaiement(malade.Id), 2);
                        txtMontantDu.Text = montant_mituel.ToString();
                        oldMontantDette = Math.Round((montant_mituel - clsMetier.GetInstance().getTotmontantpaiement1(identifiantMalade)), 2);
                        txtMontantPaye.Text = "0";

                        #endregion Fin chargement paiement pour mituelle

                        try
                        {
                            bsrc2.DataSource = clsMetier.GetInstance().getAllClspaiement1(malade.Id);
                            bsrc1.DataSource = clsMetier.GetInstance().getAllClspaiement2(malade.Id);

                            dgv.DataSource = bsrc2;
                            dgv1.DataSource = bsrc1;

                            filDgvPaiement1();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message + " >>>> Erreur lors du chargement des paiements du malade", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    }
                }
            }
            catch (Exception) { }
            #endregion Fin Chargement Data

            #region Actualisation
            try
            {
                if ((rdMalade.Checked == false && rdMituelle.Checked == false) || rdMalade.Checked == true)
                {
                    //S'il n'ya pas d'enregistrement de paiement pour le malade sélectionné, on vide le datagridview
                    filDgvPaiement();
                }
                else if (rdMituelle.Checked == true)
                {
                    //S'il n'ya pas d'enregistrement de paiement pour le malade sélectionné pour la mituelle, on vide le datagridview
                    filDgvPaiement1();
                }
            }
            catch (Exception) { }
            #endregion

            //#region Reinitialisation comme pour nouveau
            //try
            //{
            //    New();
            //    //blnDataSourceDefine = false;
            //}
            //catch (Exception) { }
            //#endregion
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

        private void cmdClotureJournee_Click(object sender, EventArgs e)
        {
            try
            {
                clsMetier.GetInstance().cloture_journee(Convert.ToDateTime(txtDateClotureJournee.Text));
                MessageBox.Show("Journée clôturée avec succès", "Clôture de la journée", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ">> Erreur lors de la clôture de la journée, veuillez recommencer", "Clôture de la journée", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tabControl2_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //Se produit lorsque l'on change un onglet
            if (tabControl2.SelectedIndex == 1)
            {
                txtDateClotureJournee.Text = DateTime.Today.ToShortDateString();
            }
            else if (tabControl2.SelectedIndex == 2 && okLoadCloture)
            {
                try
                {
                    if (bsrc3 != null) bsrc3.Dispose();
                    if (dgvCloture.RowCount != 0) dgvCloture.Dispose();
                }
                catch (Exception) { }
            }
        }

        private void cmdAfficheDataCloture_Click(object sender, EventArgs e)
        {
            try
            {
                bsrc3.DataSource = clsMetier.GetInstance().getAllClspaiementCloture(Convert.ToDateTime(txtDateElmCloture.Text));
                dgvCloture.DataSource = bsrc3;
                okLoadCloture = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ">> Erreur lors de l'affichage des informations de clôture", "Affichage clôture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Activation des items 
        private void verifieActivateItems()
        {
            if (chkEntreprise.Checked && rdAbonne.Checked)
            {
                //rdNonAbonne.Enabled = false;

                //Rapport pour entreprise
                if (rdInterne.Checked && rdConsommation.Checked)
                {
                    //Consommation entreprise pour Internes=>1
                    gpEntreprise.Enabled = true;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = false;
                }
                else if (rdInterne.Checked && rdGlobal.Checked)
                {
                    MessageBox.Show("Choississez consommation seulemenet", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdGlobal.Checked = false;
                }
                else if (rdInterne.Checked && rdJournalier.Checked)
                {
                    MessageBox.Show("Choississez consommation svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdJournalier.Checked = false;
                }
                else if (rdExterne.Checked && rdConsommation.Checked)
                {
                    //Consommation entreprise pour Externe=>2
                    gpEntreprise.Enabled = true;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = false;
                }
                else if (rdExterne.Checked && rdGlobal.Checked)
                {
                    MessageBox.Show("Choississez consommation seulemenet", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdGlobal.Checked = false;
                }
                else if (rdExterne.Checked && rdJournalier.Checked)
                {
                    MessageBox.Show("Choississez consommation seulemenet", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdJournalier.Checked = false;
                }
                else if (rdTous.Checked && (rdJournalier.Checked || rdGlobal.Checked || rdConsommation.Checked))
                {
                    MessageBox.Show("Choississez Interne ou Externe seulemenet", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdJournalier.Checked = false;
                    rdGlobal.Checked = false;
                    rdConsommation.Checked = false;
                }
            }
            else if (!chkEntreprise.Checked && rdAbonne.Checked)
            {
                //Rapport non entreprise

                rdNonAbonne.Enabled = true;
                gpEntreprise.Enabled = false;

                if (rdInterne.Checked && rdConsommation.Checked)
                {
                    MessageBox.Show("Choississez recette globale ou recette journalière svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdConsommation.Checked = false;
                }
                else if (rdInterne.Checked && rdGlobal.Checked)
                {
                    MessageBox.Show("Choississez Tous svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdGlobal.Checked = false;
                }
                else if (rdInterne.Checked && rdJournalier.Checked)
                {
                    //Recette des Abonne pour Internes=>7
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = true;
                }
                else if (rdExterne.Checked && rdConsommation.Checked)
                {
                    MessageBox.Show("Choississez recette globale ou recette journalière svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdConsommation.Checked = false;
                }
                else if (rdExterne.Checked && rdGlobal.Checked)
                {
                    MessageBox.Show("Choississez Tous svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdGlobal.Checked = false;
                }
                else if (rdExterne.Checked && rdJournalier.Checked)
                {
                    //Recette des Abonne pour Externes=>8
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = true;
                }
                else if (rdTous.Checked && rdConsommation.Checked)
                {
                    MessageBox.Show("Choississez recette globale ou recette journalière svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdConsommation.Checked = false;
                }
                else if (rdTous.Checked && rdGlobal.Checked)
                {
                    //Recette des Abonne pour Interne et Externes=>5
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = true;
                    gpRecetteJournaliere.Enabled = false;
                }
                else if (rdTous.Checked && rdJournalier.Checked)
                {
                    MessageBox.Show("Choississez recette globale et Interne et ou Externe svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdJournalier.Checked = false;
                }
            }
            //Non abonne
            else if (!chkEntreprise.Checked && rdNonAbonne.Checked)
            {
                //Rapport non entreprise

                if (rdInterne.Checked && rdConsommation.Checked)
                {
                    //Consommation des non Abonne pour Internes=>3
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = true;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = false;
                }
                else if (rdInterne.Checked && rdGlobal.Checked)
                {
                    MessageBox.Show("Choississez Tous svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdGlobal.Checked = false;
                }
                else if (rdInterne.Checked && rdJournalier.Checked)
                {
                    //Recette des non Abonne pour Internes=>9
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = true;
                }
                else if (rdExterne.Checked && rdConsommation.Checked)
                {
                    //Consommation des non Abonne pour Externes=>4
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = true;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = false;
                }
                else if (rdExterne.Checked && rdGlobal.Checked)
                {
                    MessageBox.Show("Choississez Tous svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdGlobal.Checked = false;
                }
                else if (rdExterne.Checked && rdJournalier.Checked)
                {
                    //Recette des non Abonne pour Externes=>8
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = true;
                }
                else if (rdTous.Checked && rdConsommation.Checked)
                {
                    MessageBox.Show("Choississez recette globale ou recette journalière svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdConsommation.Checked = false;
                }
                else if (rdTous.Checked && rdGlobal.Checked)
                {
                    //Recette des non Abonne pour Interne et Externes=>6
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = true;
                    gpRecetteJournaliere.Enabled = false;
                }
                else if (rdTous.Checked && rdJournalier.Checked)
                {
                    MessageBox.Show("Choississez recette globale et Interne et ou Externe svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdJournalier.Checked = false;
                }
            }
        }

        private void rdAbonne_CheckedChanged(object sender, EventArgs e)
        {
            verifieActivateItems();
        }

        private void rdNonAbonne_CheckedChanged(object sender, EventArgs e)
        {
            verifieActivateItems();
        }

        private void chkEntreprise_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEntreprise.Checked)
            {
                rdNonAbonne.Enabled = false;
                gpEntreprise.Enabled = true;
                rdConsommation.Checked = true;

                gpConsommationNonAbonne.Enabled = false;
                gpRecetteJournaliereGlobale.Enabled = false;
                gpRecetteJournaliere.Enabled = false;

                verifieActivateItems();
            }
            else
            {
                rdNonAbonne.Enabled = true;
                gpEntreprise.Enabled = false;
                rdJournalier.Checked = true;

                gpConsommationNonAbonne.Enabled = false;
                gpRecetteJournaliereGlobale.Enabled = false;
                gpRecetteJournaliere.Enabled = false;

                verifieActivateItems();
            }
        }

        private void rdConsommation_CheckedChanged(object sender, EventArgs e)
        {
            verifieActivateItems();
        }

        private void rdGlobal_CheckedChanged(object sender, EventArgs e)
        {
            verifieActivateItems();
        }

        private void rdJournalier_CheckedChanged(object sender, EventArgs e)
        {
            verifieActivateItems();
        }

        private void rdInterne_CheckedChanged(object sender, EventArgs e)
        {
            verifieActivateItems();
        }

        private void rdExterne_CheckedChanged(object sender, EventArgs e)
        {
            verifieActivateItems();
        }

        private void rdTous_CheckedChanged(object sender, EventArgs e)
        {
            verifieActivateItems();
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            try
            {
                if (!rdConsommation.Checked && !rdGlobal.Checked && !rdJournalier.Checked) MessageBox.Show("Vérifiez votre séléction svp !!", "Sélection ambigue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (rdConsommation.Checked || rdGlobal.Checked || rdJournalier.Checked) callAllReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ">> Erreur lors de l'ouverture du rapport", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //try
            //{
            //    loadRecetteInt();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + ">> Erreur lors de l'ouverture du rapport", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void callAllReport()
        {
            if (chkEntreprise.Checked && rdAbonne.Checked)
            {
                //rdNonAbonne.Enabled = false;

                //Rapport pour entreprise
                if (rdInterne.Checked && rdConsommation.Checked)
                {
                    //Consommation entreprise pour Internes=>1
                    gpEntreprise.Enabled = true;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = false;

                    loadReportEntrepriseInterneAbonne();
                }
                else if (rdInterne.Checked && rdGlobal.Checked)
                {
                    MessageBox.Show("Choississez consommation seulemenet", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdGlobal.Checked = false;
                }
                else if (rdInterne.Checked && rdJournalier.Checked)
                {
                    MessageBox.Show("Choississez consommation svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdJournalier.Checked = false;
                }
                else if (rdExterne.Checked && rdConsommation.Checked)
                {
                    //Consommation entreprise pour Externe=>2
                    gpEntreprise.Enabled = true;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = false;

                    loadReportEntrepriseExterneAbonne();
                }
                else if (rdExterne.Checked && rdGlobal.Checked)
                {
                    MessageBox.Show("Choississez consommation seulemenet", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdGlobal.Checked = false;
                }
                else if (rdExterne.Checked && rdJournalier.Checked)
                {
                    MessageBox.Show("Choississez consommation seulemenet", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdJournalier.Checked = false;
                }
                else if (rdTous.Checked && (rdJournalier.Checked || rdGlobal.Checked || rdConsommation.Checked))
                {
                    MessageBox.Show("Choississez Interne ou Externe seulemenet", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdJournalier.Checked = false;
                    rdGlobal.Checked = false;
                    rdConsommation.Checked = false;
                }
            }
            else if (!chkEntreprise.Checked && rdAbonne.Checked)
            {
                //Rapport non entreprise

                rdNonAbonne.Enabled = true;
                gpEntreprise.Enabled = false;

                if (rdInterne.Checked && rdConsommation.Checked)
                {
                    MessageBox.Show("Choississez recette globale ou recette journalière svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdConsommation.Checked = false;
                }
                else if (rdInterne.Checked && rdGlobal.Checked)
                {
                    MessageBox.Show("Choississez Tous svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdGlobal.Checked = false;
                }
                else if (rdInterne.Checked && rdJournalier.Checked)
                {
                    //Recette des Abonne pour Internes=>7
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = true;

                    loadRecetteJournaliereAbonneInterne();
                }
                else if (rdExterne.Checked && rdConsommation.Checked)
                {
                    MessageBox.Show("Choississez recette globale ou recette journalière svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdConsommation.Checked = false;
                }
                else if (rdExterne.Checked && rdGlobal.Checked)
                {
                    MessageBox.Show("Choississez Tous svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdGlobal.Checked = false;
                }
                else if (rdExterne.Checked && rdJournalier.Checked)
                {
                    //Recette des Abonne pour Externes=>8
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = true;

                    loadRecetteJournaliereAbonneExterne();
                }
                else if (rdTous.Checked && rdConsommation.Checked)
                {
                    MessageBox.Show("Choississez recette globale ou recette journalière svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdConsommation.Checked = false;
                }
                else if (rdTous.Checked && rdGlobal.Checked)
                {
                    //Recette des Abonne pour Interne et Externes=>5
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = true;
                    gpRecetteJournaliere.Enabled = false;

                    loadRecetteGlobaleAbonneInterneExterne();
                }
                else if (rdTous.Checked && rdJournalier.Checked)
                {
                    MessageBox.Show("Choississez recette globale et Interne et ou Externe svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdJournalier.Checked = false;
                }
            }
            //Non abonne
            else if (!chkEntreprise.Checked && rdNonAbonne.Checked)
            {
                //Rapport non entreprise

                if (rdInterne.Checked && rdConsommation.Checked)
                {
                    //Consommation des non Abonne pour Internes=>3
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = true;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = false;

                    loadConsommationNonAbonneInterne();
                }
                else if (rdInterne.Checked && rdGlobal.Checked)
                {
                    MessageBox.Show("Choississez Tous svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdGlobal.Checked = false;
                }
                else if (rdInterne.Checked && rdJournalier.Checked)
                {
                    //Recette des non Abonne pour Internes=>9
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = true;

                    loadRecetteJournaliereNonAbonneInterne();
                }
                else if (rdExterne.Checked && rdConsommation.Checked)
                {
                    //Consommation des non Abonne pour Externes=>4
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = true;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = false;

                    loadConsommationNonAbonneExterne();
                }
                else if (rdExterne.Checked && rdGlobal.Checked)
                {
                    MessageBox.Show("Choississez Tous svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdGlobal.Checked = false;
                }
                else if (rdExterne.Checked && rdJournalier.Checked)
                {
                    //Recette des non Abonne pour Externes=>10
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = false;
                    gpRecetteJournaliere.Enabled = true;

                    loadRecetteJournaliereNonAbonneExterne();
                }
                else if (rdTous.Checked && rdConsommation.Checked)
                {
                    MessageBox.Show("Choississez recette globale ou recette journalière svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdConsommation.Checked = false;
                }
                else if (rdTous.Checked && rdGlobal.Checked)
                {
                    //Recette des non Abonne pour Interne et Externes=>6
                    gpEntreprise.Enabled = false;
                    gpConsommationNonAbonne.Enabled = false;
                    gpRecetteJournaliereGlobale.Enabled = true;
                    gpRecetteJournaliere.Enabled = false;

                    loadRecetteGlobaleNonAbonneInterneExterne();
                }
                else if (rdTous.Checked && rdJournalier.Checked)
                {
                    MessageBox.Show("Choississez recette globale et Interne et ou Externe svp", "Mauvaise sélection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rdJournalier.Checked = false;
                }
            }
        }

        private void lblConsultationPostscolaire_Click(object sender, EventArgs e)
        {
            pnAffichage.Controls.Clear();
            DossierConsultationPostscolaireFrm2 frm = new DossierConsultationPostscolaireFrm2();
            frm.Parent = pnAffichage;
        }

        private void lblAdd_MouseDown(object sender, MouseEventArgs e)
        {
            ((Control)lblAdd).ForeColor = Color.WhiteSmoke;
            ((Control)lblAdd).BackColor = Color.FromArgb(163, 185, 207);
        }

        private void lblAdd_MouseLeave(object sender, EventArgs e)
        {
            ((Control)lblAdd).BackColor = Color.Empty;
            ((Control)lblAdd).ForeColor = Color.Black;
        }

        private void lblRemove_MouseDown(object sender, MouseEventArgs e)
        {
            ((Control)lblRemove).ForeColor = Color.WhiteSmoke;
            ((Control)lblRemove).BackColor = Color.FromArgb(163, 185, 207);
            //lblRemove.Image = global::GestionClinic_WIN.Properties.Resources.context_icon_small_itinerary_ipad_2x;
        }

        private void lblRemove_MouseLeave(object sender, EventArgs e)
        {
            ((Control)lblRemove).BackColor = Color.Empty;
            ((Control)lblRemove).ForeColor = Color.Black;
        }

        private void lblAdd_MouseHover(object sender, EventArgs e)
        {
            ((Control)lblAdd).ForeColor = Color.DarkSeaGreen;
            ((Control)lblAdd).BackColor = Color.DarkSeaGreen;
        }

        private void lblRemove_MouseHover(object sender, EventArgs e)
        {
            ((Control)lblRemove).ForeColor = Color.DarkSeaGreen;
            ((Control)lblRemove).BackColor = Color.DarkSeaGreen;
        }
    }
}
