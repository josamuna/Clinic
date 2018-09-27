using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class TarifsFrm : Form
    {
        public TarifsFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        #region Déclarations
        //Préconsultation
        clstarifpreconsultation tarif1 = new clstarifpreconsultation();
        private BindingSource bsrc1 = new BindingSource();
        private bool bln1 = false;

        //Consultation
        clstarifconsultation tarif2 = new clstarifconsultation();
        private BindingSource bsrc2 = new BindingSource();
        private bool bln2 = false;

        //CPN
        clstarifconsultationprenatal tarif3 = new clstarifconsultationprenatal();
        private BindingSource bsrc3 = new BindingSource();
        private bool bln3 = false;

        //CPOS
        clstarifconsultationpostnatal tarif4 = new clstarifconsultationpostnatal();
        private BindingSource bsrc4 = new BindingSource();
        private bool bln4 = false;

        //Examen
        clsexamen examen = new clsexamen();
        private BindingSource bsrc5 = new BindingSource();
        private bool bln5 = false;

        //Médicament
        clsarticle medicament = new clsarticle();
        private BindingSource bsrc6 = new BindingSource();
        private bool bln6 = false;

        //Intervention
        clsintervention intervention = new clsintervention();
        clsbloc bloc = new clsbloc();
        clsservice service = new clsservice();
        private BindingSource bsrc7 = new BindingSource();
        private BindingSource bsrcBloc = new BindingSource();
        private BindingSource bsrcService = new BindingSource();
        private bool blnBloc = false, bln7 = false, blnService = false;

        //Type Accouchement
        clstypeaccouchement typeAcouchement = new clstypeaccouchement();
        private BindingSource bsrc8 = new BindingSource();
        private bool bln8 = false;

        //Autres frais
        clsmalade personne = new clsmalade();

        clsautrefraie autresfrais = new clsautrefraie();
        BindingSource bsrc9 = new BindingSource();
        bool bln9 = false;

        //Details Autres frais
        clsdetailsautrefraie detailsautresfrais = new clsdetailsautrefraie();
        BindingSource bsrcdetails = new BindingSource();
        //bool blndetails = false;

        //Catégorie chambre
        clscategoriechambre categoriechambre = new clscategoriechambre();
        private BindingSource bsrc10 = new BindingSource();
        private bool bln10 = false;

        //Consultation gynecologique
        clstarifconsultationgynecologique tarif11 = new clstarifconsultationgynecologique();
        private BindingSource bsrc11 = new BindingSource();
        private bool bln11 = false;

        //Echographie
        clstarifechographie tarif12 = new clstarifechographie();
        private BindingSource bsrc12 = new BindingSource();
        private bool bln12 = false;

        //CSoins
        clstarifsoin tarif13 = new clstarifsoin();
        private BindingSource bsrc13 = new BindingSource();
        private bool bln13 = false;

        //Nursing
        clstarifnursing tarif14 = new clstarifnursing();
        private BindingSource bsrc14 = new BindingSource();
        private bool bln14 = false;

        //Avance
        clstarifavance tarif15 = new clstarifavance();
        private BindingSource bsrc15 = new BindingSource();
        private bool bln15 = false;
        #endregion

        #region Bindings
        #region Preconsultation
        private void setbindingcls1(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", tarif1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst1(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc1, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls1()
        {
            btnDelete1.Enabled = false;
            Control[] tbcontrols = { txtDesignation1, txtMontant1 };
            clearforbinding(tbcontrols);

            setbindingcls1(txtDesignation1, "Designation", 0);
            setbindingcls1(txtMontant1, "Montant", 0);
        }

        private void bindignlst1()
        {
            btnDelete1.Enabled = true;
            Control[] tbcontrols = { txtDesignation1, txtMontant1 };
            clearforbinding(tbcontrols);

            setbindinglst1(txtDesignation1, "Designation", 0);
            setbindinglst1(txtMontant1, "Montant", 0);

        }
        #endregion

        #region Consultation
        private void setbindingcls2(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", tarif2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst2(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc2, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls2()
        {
            btnDelete2.Enabled = false;
            Control[] tbcontrols = { txtDesignation2, txtMontant2 };
            clearforbinding(tbcontrols);

            setbindingcls2(txtDesignation2, "Designation", 0);
            setbindingcls2(txtMontant2, "Montant", 0);
        }

        private void bindignlst2()
        {
            btnDelete2.Enabled = true;
            Control[] tbcontrols = { txtDesignation2, txtMontant2 };
            clearforbinding(tbcontrols);

            setbindinglst2(txtDesignation2, "Designation", 0);
            setbindinglst2(txtMontant2, "Montant", 0);

        }
        #endregion

        #region CPN
        private void setbindingcls3(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", tarif3, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst3(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc3, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls3()
        {
            btnDelete3.Enabled = false;
            Control[] tbcontrols = { txtDesignation3, txtMontant3 };
            clearforbinding(tbcontrols);

            setbindingcls3(txtDesignation3, "Designation", 0);
            setbindingcls3(txtMontant3, "Montant", 0);
        }

        private void bindignlst3()
        {
            btnDelete3.Enabled = true;
            Control[] tbcontrols = { txtDesignation3, txtMontant3 };
            clearforbinding(tbcontrols);

            setbindinglst3(txtDesignation3, "Designation", 0);
            setbindinglst3(txtMontant3, "Montant", 0);

        }
        #endregion

        #region CPOS
        private void setbindingcls4(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", tarif4, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst4(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc4, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls4()
        {
            btnDelete4.Enabled = false;
            Control[] tbcontrols = { txtDesignation4, txtMontant4 };
            clearforbinding(tbcontrols);

            setbindingcls4(txtDesignation4, "Designation", 0);
            setbindingcls4(txtMontant4, "Montant", 0);
        }

        private void bindignlst4()
        {
            btnDelete4.Enabled = true;
            Control[] tbcontrols = { txtDesignation4, txtMontant4 };
            clearforbinding(tbcontrols);

            setbindinglst4(txtDesignation4, "Designation", 0);
            setbindinglst4(txtMontant4, "Montant", 0);

        }

        private void clearforbinding(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is Label) ((Label)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is DateTimePicker) ((DateTimePicker)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is CheckBox) ((CheckBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((TextBox)ctrl[0]).Focus();
        }

        private void clearforbinding5(Control[] ctrl)
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
        #endregion

        #region Examen
        private void setbindingcls5(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", examen, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", examen, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", examen, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", examen, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst5(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc5, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc5, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc5, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc5, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls5()
        {
            btnDelete5.Enabled = false;
            Control[] tbcontrols = { txtDesignation5, cboTypeExamen, txtPrix };
            clearforbinding5(tbcontrols);

            setbindingcls5(txtDesignation5, "Designation", 0);
            setbindingcls5(cboTypeExamen, "Id_typeexamen", 1);
            setbindingcls5(txtPrix, "Prix", 0);
        }

        private void bindignlst5()
        {
            btnDelete5.Enabled = true;
            Control[] tbcontrols = { txtDesignation5, cboTypeExamen, txtPrix };
            clearforbinding5(tbcontrols);

            setbindinglst5(txtDesignation5, "Designation", 0);
            setbindinglst5(cboTypeExamen, "Id_typeexamen", 1);
            setbindinglst5(txtPrix, "Prix", 0);
        }
        #endregion

        #region Médicaments
        private void setbindingcls6(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", medicament, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", medicament, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst6(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc6, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrc6, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls6()
        {
            btnDelete6.Enabled = false;
            Control[] tbcontrols = { txtDesignation6, txtPU, txtStkAlert, txtCaracteristique, chkFicheSupplementaire };
            clearforbinding(tbcontrols);

            setbindingcls6(txtDesignation6, "Desination", 0);
            setbindingcls6(txtPU, "Pu", 0);
            setbindingcls6(txtCaracteristique, "Caracteristique", 0);
            setbindingcls6(txtStkAlert, "Stock_alert", 0);
            setbindingcls6(chkFicheSupplementaire, "Fiche_supplementaire", 0);
        }

        private void bindignlst6()
        {
            btnDelete6.Enabled = true;
            Control[] tbcontrols = { txtDesignation6, txtPU, txtStkAlert, txtCaracteristique, txtStock, chkFicheSupplementaire };
            clearforbinding(tbcontrols);

            setbindinglst6(txtDesignation6, "Desination", 0);
            setbindinglst6(txtPU, "Pu", 0);
            setbindinglst6(txtCaracteristique, "Caracteristique", 0);
            setbindinglst6(txtStock, "Stock", 0);
            setbindinglst6(txtStkAlert, "Stock_alert", 0);
            setbindinglst6(chkFicheSupplementaire, "Fiche_supplementaire", 0);
        }
        #endregion

        #region Intervention
        private void setbindingclsIntervention(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", intervention, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", intervention, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", intervention, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", intervention, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindingclsService(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", service, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", service, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", service, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", service, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindingclsBloc(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglstIntervetion(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc7, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc7, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc7, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc7, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrc7, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglstService(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrcService, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrcService, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrcService, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrcService, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrcService, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglstBloc(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrcBloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrcBloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrcBloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrcBloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrcBloc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void clearforbinding7(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((TextBox)ctrl[0]).Focus();
        }

        private void bindingcls7()
        {
            btnDelete7.Enabled = false;
            Control[] tbcontrols = { txtDesignation7, txtPrixInterv, cboBloc };
            clearforbinding7(tbcontrols);

            setbindingclsIntervention(txtDesignation7, "Designation", 0);
            setbindingclsIntervention(txtPrixInterv, "Prix", 0);
            setbindingclsIntervention(cboBloc, "Id_bloc", 1);
        }

        public void bindignlst7()
        {
            btnDelete7.Enabled = true;
            Control[] tbcontrols = { txtDesignation7, txtPrixInterv, cboBloc };
            clearforbinding7(tbcontrols);

            setbindinglstIntervetion(txtDesignation7, "Designation", 0);
            setbindinglstIntervetion(txtPrixInterv, "Prix", 0);
            setbindinglstIntervetion(cboBloc, "Id_bloc", 1);
        }

        private void bindingclsBloc()
        {
            btnDeleteBloc.Enabled = false;
            Control[] tbcontrols = { txtDesignationBloc, cboService };
            clearforbinding7(tbcontrols);

            setbindingclsBloc(txtDesignationBloc, "Designation", 0);
            setbindingclsBloc(cboService, "Id_service", 1);
        }

        public void bindignlstBloc()
        {
            btnDeleteBloc.Enabled = true;
            Control[] tbcontrols = { txtDesignationBloc, cboService };
            clearforbinding7(tbcontrols);

            setbindinglstBloc(txtDesignationBloc, "Designation", 0);
            setbindinglstBloc(cboService, "Id_service", 1);
        }

        private void bindingclsService()
        {
            btnDeleteService.Enabled = false;
            Control[] tbcontrols = { txtDesignationService };
            clearforbinding7(tbcontrols);
            setbindingclsService(txtDesignationService, "Designation", 0);
        }

        private void bindignlstService()
        {
            btnDeleteService.Enabled = true;
            Control[] tbcontrols = { txtDesignationService };
            clearforbinding7(tbcontrols);

            setbindinglstService(txtDesignationService, "Designation", 0);
        }
        #endregion

        #region Type Accouchement
        private void setbindingcls8(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", typeAcouchement, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst8(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc8, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls8()
        {
            btnDelete8.Enabled = false;
            Control[] tbcontrols = { txtDesignation8, txtPrix8 };
            clearforbinding(tbcontrols);

            setbindingcls8(txtDesignation8, "Designation", 0);
            setbindingcls8(txtPrix8, "Prix", 0);
        }

        private void bindignlst8()
        {
            btnDelete8.Enabled = true;
            Control[] tbcontrols = { txtDesignation8, txtPrix8 };
            clearforbinding(tbcontrols);

            setbindinglst8(txtDesignation8, "Designation", 0);
            setbindinglst8(txtPrix8, "Prix", 0);
        }
        #endregion

        #region Autres frais
        private void setbindingcls9(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", autresfrais, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", autresfrais, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", autresfrais, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst9(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc9, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc9, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc9, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls9()
        {
            btnDelete9.Enabled = false;
            Control[] tbcontrols = { txtNumeroFacture, txtDateEnregistrement, txtDatePaiement, txtNetAPayer, cboEntrepriseProvenance, cboMalade, txtEtatPaiementAutre };
            clearforbinding(tbcontrols);

            setbindingcls9(txtDateEnregistrement, "Dateenregistrement", 0);
            setbindingcls9(txtDatePaiement, "Datepaiement", 0);
            setbindingcls9(txtNumeroFacture, "Numerofacture", 0);
            setbindingcls9(txtNetAPayer, "Montant", 0);
            setbindingcls9(cboEntrepriseProvenance, "Id_etablissementexterne", 1);
            setbindingcls9(cboMalade, "Id_malade", 1);
            setbindingcls9(txtEtatPaiementAutre, "Etatpaiement", 0);
        }

        private void bindignlst9()
        {
            btnDelete9.Enabled = true;
            Control[] tbcontrols = { txtNumeroFacture, txtIdAutreFrais, txtDateEnregistrement, txtDatePaiement, txtNetAPayer, cboEntrepriseProvenance, cboMalade, txtEtatPaiementAutre };
            clearforbinding(tbcontrols);

            txtEtatPaiementAutre.Text = "Non payé";
            setbindinglst9(txtDateEnregistrement, "Dateenregistrement", 0);
            setbindinglst9(txtDatePaiement, "Datepaiement", 0);
            setbindinglst9(txtNumeroFacture, "Numerofacture", 0);
            setbindinglst9(txtNetAPayer, "Montant", 0);
            setbindinglst9(cboEntrepriseProvenance, "Id_etablissementexterne", 1);
            setbindinglst9(cboMalade, "Id_malade", 1);
            setbindinglst9(txtEtatPaiementAutre, "Etatpaiement", 0);
            setbindinglst9(txtIdAutreFrais, "Id", 0);
        }
        #endregion

        #region Details AutresFrais
        private void setbindingclsdetails(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", detailsautresfrais, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", detailsautresfrais, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", detailsautresfrais, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglstdetails(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrcdetails, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrcdetails, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrcdetails, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingclsdetails()
        {
            //btnDelete9.Enabled = false;
            Control[] tbcontrols = { txtMontant, cboDesignation, txtQuantite };
            clearforbinding(tbcontrols);

            setbindingclsdetails(cboDesignation, "Designation", 0);
            setbindingclsdetails(txtMontant, "Prix", 0);
            setbindingclsdetails(txtQuantite, "Quantinte", 0);
        }

        private void bindignlstdetails()
        {
            //btnDelete9.Enabled = true;
            Control[] tbcontrols = { txtMontant, cboDesignation, txtQuantite };
            clearforbinding(tbcontrols);

            setbindinglstdetails(cboDesignation, "Designation", 0);
            setbindinglstdetails(txtMontant, "Prix", 0);
            setbindinglstdetails(txtQuantite, "Quantinte", 0);
        }
        #endregion

        #region Catégorie chambre
        private void bindingcls10()
        {
            btnDelete10.Enabled = false;
            btnSave10.Enabled = true;
            txtPrix10.DataBindings.Clear();
            txtDesignation10.DataBindings.Clear();
            txtDesignation10.Focus();
            txtPrix10.DataBindings.Add("Text", categoriechambre, "Prix", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDesignation10.DataBindings.Add("Text", categoriechambre, "Designation", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindignlst10()
        {
            btnDelete10.Enabled = true;
            txtPrix10.DataBindings.Clear();
            txtDesignation10.DataBindings.Clear();
            txtDesignation10.Focus();
            txtDesignation10.DataBindings.Add("Text", bsrc10, "Designation", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPrix10.DataBindings.Add("Text", bsrc10, "Prix", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        #endregion

        #region Consultation gynécologique
        private void setbindingcls11(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", tarif11, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst11(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc11, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls11()
        {
            btnDelete11.Enabled = false;
            Control[] tbcontrols = { txtDesignation11, txtMontant11 };
            clearforbinding(tbcontrols);

            setbindingcls11(txtDesignation11, "Designation", 0);
            setbindingcls11(txtMontant11, "Montant", 0);
        }

        private void bindignlst11()
        {
            btnDelete11.Enabled = true;
            Control[] tbcontrols = { txtDesignation11, txtMontant11 };
            clearforbinding(tbcontrols);

            setbindinglst11(txtDesignation11, "Designation", 0);
            setbindinglst11(txtMontant11, "Montant", 0);
        }
        #endregion

        #region Echographie
        private void setbindingcls12(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", tarif12, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst12(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc12, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls12()
        {
            btnDelete12.Enabled = false;
            Control[] tbcontrols = { txtDesignation12, txtPrix12 };
            clearforbinding(tbcontrols);

            setbindingcls12(txtDesignation12, "Designation", 0);
            setbindingcls12(txtPrix12, "Montant", 0);
        }

        private void bindignlst12()
        {
            btnDelete12.Enabled = true;
            Control[] tbcontrols = { txtDesignation12, txtPrix12 };
            clearforbinding(tbcontrols);

            setbindinglst12(txtDesignation12, "Designation", 0);
            setbindinglst12(txtPrix12, "Montant", 0);
        }
        #endregion

        #region Soins
        private void setbindingcls13(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", tarif13, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst13(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc13, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls13()
        {
            btnDelete13.Enabled = false;
            Control[] tbcontrols = { txtDesignation13, txtPrix13 };
            clearforbinding(tbcontrols);

            setbindingcls13(txtDesignation13, "Designation", 0);
            setbindingcls13(txtPrix13, "Montant", 0);
        }

        private void bindignlst13()
        {
            btnDelete13.Enabled = true;
            Control[] tbcontrols = { txtDesignation13, txtPrix13 };
            clearforbinding(tbcontrols);

            setbindinglst13(txtDesignation13, "Designation", 0);
            setbindinglst13(txtPrix13, "Montant", 0);

        }
        #endregion

        #region Nursing
        private void setbindingcls14(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", tarif14, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst14(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc14, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls14()
        {
            btnDelete14.Enabled = false;
            Control[] tbcontrols = { txtDesignation14, txtPrix14 };
            clearforbinding(tbcontrols);

            setbindingcls14(txtDesignation14, "Designation", 0);
            setbindingcls14(txtPrix14, "Montant", 0);
        }

        private void bindignlst14()
        {
            btnDelete14.Enabled = true;
            Control[] tbcontrols = { txtDesignation14, txtPrix14 };
            clearforbinding(tbcontrols);

            setbindinglst14(txtDesignation14, "Designation", 0);
            setbindinglst14(txtPrix14, "Montant", 0);

        }
        #endregion

        #region Avance
        private void setbindingcls15(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", tarif15, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst15(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc15, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls15()
        {
            btnDelete15.Enabled = false;
            Control[] tbcontrols = { txtDesignation15, txtPrix15 };
            clearforbinding(tbcontrols);

            setbindingcls15(txtDesignation15, "Designation", 0);
            setbindingcls15(txtPrix15, "Montant", 0);
        }

        private void bindignlst15()
        {
            btnDelete15.Enabled = true;
            Control[] tbcontrols = { txtDesignation15, txtPrix15 };
            clearforbinding(tbcontrols);

            setbindinglst15(txtDesignation15, "Designation", 0);
            setbindinglst15(txtPrix15, "Montant", 0);
        }
        #endregion
        #endregion

        #region New
        //Préconsultation
        private void New1()
        {
            try
            {
                tarif1 = new clstarifpreconsultation();
                bln1 = false;
                bindingcls1();
            }
            catch (Exception) { btnSave1.Enabled = false; }
        }

        //Consultation
        private void New2()
        {
            try
            {
                tarif2 = new clstarifconsultation();
                bln2 = false;
                bindingcls2();
            }
            catch (Exception) { btnSave2.Enabled = false; }
        }

        //CPN
        private void New3()
        {
            try
            {
                tarif3 = new clstarifconsultationprenatal();
                bln3 = false;
                bindingcls3();
            }
            catch (Exception) { btnSave3.Enabled = false; }
        }

        //CPOS
        private void New4()
        {
            try
            {
                tarif4 = new clstarifconsultationpostnatal();
                bln4 = false;
                bindingcls4();
            }
            catch (Exception) { btnSave4.Enabled = false; }
        }

        //Examen
        private void New5()
        {
            examen = new clsexamen();
            bln5 = false;
            bindingcls5();
            if (cboTypeExamen.Items.Count > 0) cboTypeExamen.SelectedIndex = 0;
        }

        //Examen
        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        //Médicament
        private void New6()
        {
            try
            {
                medicament = new clsarticle();
                bln6 = false;
                bindingcls6();
                txtStock.Text = "0";
            }
            catch (Exception) { btnSave6.Enabled = false; }
        }

        //Intervention
        private void New7()
        {
            try
            {
                intervention = new clsintervention();
                bln7 = false;
                bindingcls7();
                if (cboBloc.Items.Count > 0) cboBloc.SelectedIndex = 0;
            }
            catch (Exception) { btnSave7.Enabled = false; }
        }

        private void newBloc()
        {
            bloc = new clsbloc();
            blnBloc = false;
            bindingclsBloc();
            if (cboService.Items.Count > 0) cboService.SelectedIndex = 0;
        }

        private void newService()
        {
            service = new clsservice();
            blnService = false;
            bindingclsService();
        }

        //Type Accouchement
        private void New8()
        {
            typeAcouchement = new clstypeaccouchement();
            bln8 = false;
            bindingcls8();
            txtPrix8.Text = "";
        }

        //Autres frais
        private void New()
        {
            autresfrais = new clsautrefraie();
            detailsautresfrais = new clsdetailsautrefraie();
            lblCumulMontant.Text = "0";
            lstItems.Items.Clear();
            bln9 = false;
            bindingcls9();
        }

        //Catégorie chambre
        private void New10()
        {
            try
            {
                categoriechambre = new clscategoriechambre();
                bln10 = false;
                bindingcls10();
            }
            catch (Exception) { btnSave10.Enabled = false; }
        }

        //Consultation gynécologique
        private void New11()
        {
            try
            {
                tarif11 = new clstarifconsultationgynecologique();
                bln11 = false;
                bindingcls11();
            }
            catch (Exception) { btnSave11.Enabled = false; }
        }

        //Echographie
        private void New12()
        {
            try
            {
                tarif12 = new clstarifechographie();
                bln12 = false;
                bindingcls12();
            }
            catch (Exception) { btnSave12.Enabled = false; }
        }

        //Soin
        private void New13()
        {
            try
            {
                tarif13 = new clstarifsoin();
                bln13 = false;
                bindingcls13();
            }
            catch (Exception) { btnSave13.Enabled = false; }
        }

        //Nursing
        private void New14()
        {
            try
            {
                tarif14 = new clstarifnursing();
                bln14 = false;
                bindingcls14();
            }
            catch (Exception) { btnSave14.Enabled = false; }
        }

        //Avance
        private void New15()
        {
            try
            {
                tarif15 = new clstarifavance();
                bln15 = false;
                bindingcls15();
            }
            catch (Exception) { btnSave15.Enabled = false; }
        }
        #endregion

        #region Refresh
        //Préconsultation
        private void refresh1()
        {
            try
            {
                bsrc1.DataSource = clsMetier.GetInstance().getAllClstarifpreconsultation();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Consultation
        private void refresh2()
        {
            try
            {
                bsrc2.DataSource = clsMetier.GetInstance().getAllClstarifconsultation();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //CPN
        private void refresh3()
        {
            try
            {
                bsrc3.DataSource = clsMetier.GetInstance().getAllClstarifconsultationprenatal();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //CPOS
        private void refresh4()
        {
            try
            {
                bsrc4.DataSource = clsMetier.GetInstance().getAllClstarifconsultationpostnatal();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Examen
        private void refresh5()
        {
            try
            {
                bsrc5.DataSource = clsMetier.GetInstance().getAllClsexamen();

                cboTypeExamen.DataSource = clsMetier.GetInstance().getAllClstypeexamen();
                setMembersallcbo(cboTypeExamen, "Designation", "Id");

                if (cboTypeExamen.Items.Count > 0) cboTypeExamen.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Médicament
        private void refresh6()
        {
            try
            {
                bsrc6.DataSource = clsMetier.GetInstance().getAllClsarticleFiche();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Intervention
        private void refresh7()
        {
            try
            {
                bsrc7.DataSource = clsMetier.GetInstance().getAllClsintervention();
                cboBloc.DataSource = clsMetier.GetInstance().getAllClsbloc();
                setMembersallcbo(cboBloc, "Designation", "Id");
                if (cboBloc.Items.Count > 0) cboBloc.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void refreshBloc()
        {
            try
            {
                bsrcBloc.DataSource = clsMetier.GetInstance().getAllClsbloc();
                cboService.DataSource = clsMetier.GetInstance().getAllClsservice();
                setMembersallcbo(cboService, "Designation", "Id");
                if (cboService.Items.Count > 0) cboService.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void refreshService()
        {
            try
            {
                bsrcService.DataSource = clsMetier.GetInstance().getAllClsservice();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Type Accouchement
        private void refresh8()
        {
            try
            {
                bsrc8.DataSource = clsMetier.GetInstance().getAllClstypeaccouchement();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Autres frais
        private void refresh()
        {
            try
            {
                bsrc9.DataSource = clsMetier.GetInstance().getAllClsautrefraie();
                //bsrcdetails.DataSource = clsMetier.GetInstance().getAllClsautrefraie1();
                cboEntrepriseProvenance.DataSource = clsMetier.GetInstance().getAllClsetablissementexterne();
                setMembersallcbo(cboEntrepriseProvenance, "Denomination", "Id");

                cboMalade.DataSource = clsMetier.GetInstance().getAllClsmaladeAb();
                setMembersallcbo(cboMalade, "Nom_complet", "Id");

                try
                {
                    cboDesignation.DataSource = clsMetier.GetInstance().getAllClsdetailsautrefraieEntrepriseex(((clsetablissementexterne)cboEntrepriseProvenance.SelectedItem).Id);
                    setMembersallcbo(cboDesignation, "Designation", "Id");
                }
                catch (Exception) { }

                if (dgv9.RowCount > 0)
                {
                    if (cboEntrepriseProvenance.Items.Count > 0) cboEntrepriseProvenance.SelectedIndex = 1;
                    if (cboMalade.Items.Count > 0) cboMalade.SelectedIndex = 1;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Catégorie chambre
        private void refresh10()
        {
            try
            {
                bsrc10.DataSource = clsMetier.GetInstance().getAllClscategoriechambre();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Consultation gynécologique
        private void refresh11()
        {
            try
            {
                bsrc11.DataSource = clsMetier.GetInstance().getAllClstarifconsultationgynecologique();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Echographie
        private void refresh12()
        {
            try
            {
                bsrc12.DataSource = clsMetier.GetInstance().getAllClstarifechographie();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Soins
        private void refresh13()
        {
            try
            {
                bsrc13.DataSource = clsMetier.GetInstance().getAllClstarifsoin();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Nursing
        private void refresh14()
        {
            try
            {
                bsrc14.DataSource = clsMetier.GetInstance().getAllClstarifnursing();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Avance
        private void refresh15()
        {
            try
            {
                bsrc15.DataSource = clsMetier.GetInstance().getAllClstarifavance();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            New1();
        }

        private void Tarif_Load(object sender, EventArgs e)
        {
            //Reinitialisation des variables 
            clsDoTraitement.MAJ_fiche = false;
            clsDoTraitement.MAJ_consultation = false;
            clsDoTraitement.MAJ_CPN = false;
            clsDoTraitement.MAJ_CPOS = false;
            clsDoTraitement.MAJ_Labo = false;
            clsDoTraitement.MAJ_Interventions = false;
            clsDoTraitement.MAJ_consultationGyn = false;
            clsDoTraitement.MAJ_Acouchement = false;
            clsDoTraitement.MAJ_Echographie = false;
            clsDoTraitement.MAJ_Soins = false;
            clsDoTraitement.MAJ_Nursing = false;
            clsDoTraitement.MAJ_Chambre = false;

            chkFicheSupplementaire.Checked = false;

            //Preconsultation
            try
            {
                bindingcls1();
                dgv1.DataSource = bsrc1;
                refresh1();
            }
            catch (Exception) { }

            //Consultation
            try
            {
                bindingcls2();
                dgv2.DataSource = bsrc2;
                refresh2();
            }
            catch (Exception) { }

            //CPN
            try
            {
                bindingcls3();
                dgv3.DataSource = bsrc3;
                refresh3();
            }
            catch (Exception) { }

            //CPOS
            try
            {
                bindingcls4();
                dgv4.DataSource = bsrc4;
                refresh4();
            }
            catch (Exception) { }

            //Examen
            try
            {
                bindingcls5();
                dgv5.DataSource = bsrc5;
                refresh5();
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            //Médicament
            try
            {
                bindingcls6();
                dgv6.DataSource = bsrc6;
                refresh6();
            }
            catch (Exception) { }

            //Intervention
            try
            {
                bindingclsBloc();
                bindingcls7();
                bindingclsService();
                dgv7.DataSource = bsrc7;
                dgvBloc.DataSource = bsrcBloc;
                dgvService.DataSource = bsrcService;
                refreshBloc();
                refreshService();
                refresh7();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            bdnBloc.Enabled = false;
            bdnService.Enabled = false;

            if (clsDoTraitement.blnBloc)
            {
                bdnBloc.Enabled = true;
                tabControl1.SelectTab(tbBloc);
                clsDoTraitement.blnBloc = false;
            }
            if (clsDoTraitement.blnService)
            {
                bdnService.Enabled = true;
                tabControl1.SelectTab(tbService);
                clsDoTraitement.blnService = false;
            }

            //Type Accouchement
            try
            {
                bindingcls8();
                dgv8.DataSource = bsrc8;
                refresh8();
                txtPrix8.Text = "";
            }
            catch (Exception) { }

            //Autres frais
            try
            {
                lblCumulMontant.Text = "0";
                bindingcls9();
                dgv9.DataSource = bsrc9;
                dgv99.DataSource = bsrcdetails;
                refresh();
            }
            catch (Exception) { }

            //Catégorie chambre
            try
            {
                bindingcls10();
                dgv10.DataSource = bsrc10;
                refresh10();
            }
            catch (Exception) { }

            //Consultation gynécologique
            try
            {
                bindingcls11();
                dgv11.DataSource = bsrc11;
                refresh11();
            }
            catch (Exception) { }

            //Echographie
            try
            {
                bindingcls12();
                dgv12.DataSource = bsrc12;
                refresh12();
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            //Soins
            try
            {
                bindingcls13();
                dgv13.DataSource = bsrc13;
                refresh13();
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            //Nursing
            try
            {
                bindingcls14();
                dgv14.DataSource = bsrc14;
                refresh14();
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            //Avance
            try
            {
                bindingcls15();
                dgv15.DataSource = bsrc15;
                refresh15();
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            refresh1();
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln1)
                {
                    tarif1.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc1.DataSource != null)
                    {
                        clstarifpreconsultation c = (clstarifpreconsultation)bsrc1.Current;
                        new clstarifpreconsultation().update(c);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.MAJ_fiche = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New1();
            refresh1();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc1.DataSource != null)
                    {
                        clstarifpreconsultation c = (clstarifpreconsultation)bsrc1.Current;
                        new clstarifpreconsultation().delete(c);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New1();
                        refresh1();
                    }
                    clsDoTraitement.MAJ_fiche = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv1.SelectedRows.Count > 0)
                {
                    bindignlst1();
                    bln1 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            New2();
        }

        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            refresh2();
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln2)
                {
                    tarif2.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc2.DataSource != null)
                    {
                        clstarifconsultation c = (clstarifconsultation)bsrc2.Current;
                        new clstarifconsultation().update(c);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New2();
            refresh2();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc2.DataSource != null)
                    {
                        clstarifconsultation c = (clstarifconsultation)bsrc2.Current;
                        new clstarifconsultation().delete(c);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New2();
                        refresh2();
                    }
                    clsDoTraitement.MAJ_consultation = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv2.SelectedRows.Count > 0)
                {
                    bindignlst2();
                    bln2 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnAdd3_Click(object sender, EventArgs e)
        {
            New3();
        }

        private void btnRefresh3_Click(object sender, EventArgs e)
        {
            refresh3();
        }

        private void btnSave3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln3)
                {
                    tarif3.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc3.DataSource != null)
                    {
                        clstarifconsultationprenatal c = (clstarifconsultationprenatal)bsrc3.Current;
                        new clstarifconsultationprenatal().update(c);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.MAJ_CPN = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New3();
            refresh3();
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc3.DataSource != null)
                    {
                        clstarifconsultationprenatal c = (clstarifconsultationprenatal)bsrc3.Current;
                        new clstarifconsultationprenatal().delete(c);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New3();
                        refresh3();
                    }
                    clsDoTraitement.MAJ_CPN = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv3.SelectedRows.Count > 0)
                {
                    bindignlst3();
                    bln3 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnAdd4_Click(object sender, EventArgs e)
        {
            New4();
        }

        private void btnRefresh4_Click(object sender, EventArgs e)
        {
            refresh4();
        }

        private void btnSave4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln4)
                {
                    tarif4.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc4.DataSource != null)
                    {
                        clstarifconsultationpostnatal c = (clstarifconsultationpostnatal)bsrc4.Current;
                        new clstarifconsultationpostnatal().update(c);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.MAJ_CPOS = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New4();
            refresh4();
        }

        private void btnDelete4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc4.DataSource != null)
                    {
                        clstarifconsultationpostnatal c = (clstarifconsultationpostnatal)bsrc4.Current;
                        new clstarifconsultationpostnatal().delete(c);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New4();
                        refresh4();
                    }
                    clsDoTraitement.MAJ_CPOS = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv4_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv4.SelectedRows.Count > 0)
                {
                    bindignlst4();
                    bln4 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnAdd5_Click(object sender, EventArgs e)
        {
            try
            {
                New5();
            }
            catch (Exception) { btnSave5.Enabled = false; }
        }

        private void btnRefresh5_Click(object sender, EventArgs e)
        {
            refresh5();
        }

        private void btnSave5_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln5)
                {
                    examen.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc5.DataSource != null)
                    {
                        clsexamen s = (clsexamen)bsrc5.Current;
                        new clsexamen().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.MAJ_Labo = true;
                //Permet l'actualisation des valeur des examen sur le formulaire appelant
                clsDoTraitement.EnterForFormExamen = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New5();
            refresh5();
        }

        private void btnDelete5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc5.DataSource != null)
                    {
                        clsexamen d = (clsexamen)bsrc5.Current;
                        new clsexamen().delete(d);
                        //Permet l'actualisation des valeur des examen sur le formulaire appelant
                        clsDoTraitement.EnterForFormExamen = true;
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New5();
                        refresh5();
                        clsDoTraitement.MAJ_Labo = true;
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
            TypeExamenFrm frm = new TypeExamenFrm();
            frm.ShowDialog();
        }

        private void cboTypeExamen_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormTypeExamen)
            {
                try
                {
                    cboTypeExamen.DataSource = clsMetier.GetInstance().getAllClstypeexamen();
                }
                catch (Exception) { }
            }
        }

        private void dgv5_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv5.SelectedRows.Count > 0)
                {
                    bindignlst5();
                    bln5 = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void btnAdd6_Click(object sender, EventArgs e)
        {
            New6();
        }

        private void btnRefresh6_Click(object sender, EventArgs e)
        {
            refresh6();
        }

        private void btnSave6_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln6)
                {
                    medicament.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clsDoTraitement.EnterFormArticle = true;
                }
                else
                {
                    if (bsrc6.DataSource != null)
                    {
                        clsarticle m = (clsarticle)bsrc6.Current;
                        new clsarticle().update(m);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New6();
            refresh6();
        }

        private void btnDelete6_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc6.DataSource != null)
                    {
                        clsarticle m = (clsarticle)bsrc6.Current;
                        new clsarticle().delete(m);
                        clsDoTraitement.EnterFormArticle = true;
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New6();
                        refresh6();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv6_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv6.SelectedRows.Count > 0)
                {
                    bindignlst6();
                    bln6 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnAdd7_Click(object sender, EventArgs e)
        {
            New7();
        }

        private void btnRefresh7_Click(object sender, EventArgs e)
        {
            refresh7();
        }

        private void btnSave7_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln7)
                {
                    intervention.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc7.DataSource != null)
                    {
                        clsintervention i = (clsintervention)bsrc7.Current;
                        new clsintervention().update(i);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.MAJ_Interventions = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New7();
            refresh7();
        }

        private void btnDelete7_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc7.DataSource != null)
                    {
                        clsintervention i = (clsintervention)bsrc7.Current;
                        new clsintervention().delete(i);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New7();
                        refresh7();
                        clsDoTraitement.MAJ_Interventions = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblAddBloc_Click(object sender, EventArgs e)
        {
            bdnBloc.Enabled = true;
            tabControl1.SelectTab(tbBloc);
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            bdnService.Enabled = true;
            tabControl1.SelectTab(tbService);
        }

        private void cboBloc_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboBloc.DataSource = clsMetier.GetInstance().getAllClsbloc();
            }
            catch (Exception) { }
        }

        private void btnAddBloc_Click(object sender, EventArgs e)
        {
            newBloc();
        }

        private void btnRefreshBloc_Click(object sender, EventArgs e)
        {
            refreshBloc();
        }

        private void btnSaveBloc_Click(object sender, EventArgs e)
        {
            try
            {
                if (!blnBloc)
                {
                    bloc.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrcBloc.DataSource != null)
                    {
                        clsbloc b = (clsbloc)bsrcBloc.Current;
                        new clsbloc().update(b);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            refreshBloc();
        }

        private void btnDeleteBloc_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrcBloc.DataSource != null)
                    {
                        clsbloc b = (clsbloc)bsrc7.Current;
                        new clsbloc().delete(b);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshBloc();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv7_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv7.SelectedRows.Count > 0)
                {
                    bindignlst7();
                    bln7 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void dgvBloc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBloc.SelectedRows.Count > 0)
                {
                    bindignlstBloc();
                    blnBloc = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            newService();
        }

        private void btnRefreshService_Click(object sender, EventArgs e)
        {
            refreshService();
        }

        private void btnSaveService_Click(object sender, EventArgs e)
        {
            try
            {
                if (!blnService)
                {
                    service.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrcService.DataSource != null)
                    {
                        clsservice s = (clsservice)bsrcService.Current;
                        new clsservice().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            refreshService();
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrcBloc.DataSource != null)
                    {
                        clsservice s = (clsservice)bsrc7.Current;
                        new clsservice().delete(s);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshService();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvService_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvService.SelectedRows.Count > 0)
                {
                    bindignlstService();
                    blnService = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
            try
            {
                if (dgvService.SelectedRows.Count > 0)
                {
                    bindignlstService();
                    blnService = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
            try
            {
                if (dgvService.SelectedRows.Count > 0)
                {
                    bindignlstService();
                    blnService = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void btnAdd8_Click(object sender, EventArgs e)
        {
            try
            {
                New8();
            }
            catch (Exception) { btnSave8.Enabled = false; }
        }

        private void btnRefresh8_Click(object sender, EventArgs e)
        {
            refresh8();
        }

        private void btnSave8_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln8)
                {
                    typeAcouchement.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc8.DataSource != null)
                    {
                        clstypeaccouchement s = (clstypeaccouchement)bsrc8.Current;
                        new clstypeaccouchement().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.MAJ_Acouchement = true;
                //Permet l'actualisation des valeur des qualifications sur le formulair des Agents
                clsDoTraitement.EnterFormTypeAcouchement = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New8();
            refresh8();
        }

        private void btnDelete8_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc8.DataSource != null)
                    {
                        clstypeaccouchement d = (clstypeaccouchement)bsrc8.Current;
                        new clstypeaccouchement().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New8();
                        refresh8();
                    }
                    clsDoTraitement.MAJ_Acouchement = true;
                    //Permet l'actualisation des valeur des qualifications sur le formulair des Agents
                    clsDoTraitement.EnterFormTypeAcouchement = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv8_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv8.SelectedRows.Count > 0)
                {
                    bindignlst8();
                    bln8 = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void btnAdd10_Click(object sender, EventArgs e)
        {
            try
            {
                New10();
            }
            catch (Exception) { btnSave10.Enabled = false; }
        }

        private void btnRefresh10_Click(object sender, EventArgs e)
        {
            refresh10();
        }

        private void btnSave10_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln10)
                {
                    categoriechambre.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc10.DataSource != null)
                    {
                        clscategoriechambre s = (clscategoriechambre)bsrc10.Current;
                        new clscategoriechambre().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //clsDoTraitement.MAJ_Chambre = true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New10();
            refresh10();
        }

        private void btnDelete10_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc10.DataSource != null)
                    {
                        clscategoriechambre c = (clscategoriechambre)bsrc10.Current;
                        new clscategoriechambre().delete(c);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New10();
                        refresh10();
                        clsDoTraitement.MAJ_Chambre = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv10_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv10.SelectedRows.Count > 0)
                {
                    bindignlst10();
                    bln10 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnAdd11_Click(object sender, EventArgs e)
        {
            New11();
        }

        private void btnRefresh11_Click(object sender, EventArgs e)
        {
            refresh11();
        }

        private void btnSave11_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln11)
                {
                    tarif11.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc11.DataSource != null)
                    {
                        clstarifconsultationgynecologique c = (clstarifconsultationgynecologique)bsrc11.Current;
                        new clstarifconsultationgynecologique().update(c);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.MAJ_consultationGyn = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New11();
            refresh11();
        }

        private void btnDelete11_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc1.DataSource != null)
                    {
                        clstarifconsultationgynecologique c = (clstarifconsultationgynecologique)bsrc11.Current;
                        new clstarifconsultationgynecologique().delete(c);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New11();
                        refresh11();
                        clsDoTraitement.MAJ_consultationGyn = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv11_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv11.SelectedRows.Count > 0)
                {
                    bindignlst11();
                    bln11 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnAdd12_Click(object sender, EventArgs e)
        {
            New12();
        }

        private void btnRefresh12_Click(object sender, EventArgs e)
        {
            refresh12();
        }

        private void btnSave12_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln12)
                {
                    tarif12.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc12.DataSource != null)
                    {
                        clstarifechographie c = (clstarifechographie)bsrc12.Current;
                        new clstarifechographie().update(c);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.MAJ_Echographie = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New12();
            refresh12();
        }

        private void btnDelete12_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc12.DataSource != null)
                    {
                        clstarifechographie c = (clstarifechographie)bsrc12.Current;
                        new clstarifechographie().delete(c);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New12();
                        refresh12();
                        clsDoTraitement.MAJ_Echographie = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv12_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv12.SelectedRows.Count > 0)
                {
                    bindignlst12();
                    bln12 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnAdd13_Click(object sender, EventArgs e)
        {
            New13();
        }

        private void btnRefresh13_Click(object sender, EventArgs e)
        {
            refresh13();
        }

        private void btnSave13_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln13)
                {
                    tarif13.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc13.DataSource != null)
                    {
                        clstarifsoin c = (clstarifsoin)bsrc13.Current;
                        new clstarifsoin().update(c);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.MAJ_Soins = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New13();
            refresh13();
        }

        private void btnDelete13_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc13.DataSource != null)
                    {
                        clstarifsoin c = (clstarifsoin)bsrc13.Current;
                        new clstarifsoin().delete(c);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New13();
                        refresh13();
                        clsDoTraitement.MAJ_Soins = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv13_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv13.SelectedRows.Count > 0)
                {
                    bindignlst13();
                    bln13 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnAdd14_Click(object sender, EventArgs e)
        {
            New14();
        }

        private void btnRefresh14_Click(object sender, EventArgs e)
        {
            refresh14();
        }

        private void btnSave14_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln14)
                {
                    tarif14.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc14.DataSource != null)
                    {
                        clstarifnursing c = (clstarifnursing)bsrc14.Current;
                        new clstarifnursing().update(c);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.MAJ_Nursing = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New14();
            refresh14();
        }

        private void btnDelete14_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc14.DataSource != null)
                    {
                        clstarifnursing c = (clstarifnursing)bsrc14.Current;
                        new clstarifnursing().delete(c);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New14();
                        refresh14();
                        clsDoTraitement.MAJ_Nursing = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv14_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv14.SelectedRows.Count > 0)
                {
                    bindignlst14();
                    bln14 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnAdd15_Click(object sender, EventArgs e)
        {
            New15();
        }

        private void btnRefresh15_Click(object sender, EventArgs e)
        {
            refresh15();
        }

        private void btnSave15_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln15)
                {
                    tarif15.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc15.DataSource != null)
                    {
                        clstarifavance c = (clstarifavance)bsrc15.Current;
                        new clstarifavance().update(c);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New15();
            refresh15();
        }

        private void btnDelete15_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc15.DataSource != null)
                    {
                        clstarifavance c = (clstarifavance)bsrc15.Current;
                        new clstarifavance().delete(c);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New15();
                        refresh15();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv15_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv15.SelectedRows.Count > 0)
                {
                    bindignlst15();
                    bln15 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void btnAdd9_Click(object sender, EventArgs e)
        {
            try
            {
                New();
                txtEtatPaiementAutre.Text = "Non payé";
            }
            catch (Exception) { btnSave9.Enabled = false; }
        }

        private void btnRefresh9_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnSave9_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln9)
                {
                    if (lstItems.Items.Count == 0) throw new Exception("Veuillez ajouter un article, une quantité et un montant valide svp !!!");
                    else
                    {
                        //Récuperation des attributs pour détails paiement
                        for (int i = 0; i < lstItems.Items.Count; i++)
                        {
                            string[] tab1 = (lstItems.Items[i]).ToString().Split('>');
                            string[] tab2 = tab1[0].Split('=');//Quantite
                            string[] tab3 = tab1[1].Split('=');//Designation

                            //Settage des valeurs
                            detailsautresfrais.Designation = tab3[0].ToString();
                            detailsautresfrais.Prix = Convert.ToDouble(tab1[2].ToString());
                            detailsautresfrais.Quantinte = Convert.ToInt32(tab2[0].ToString());

                            clsMetier.lstDesignationAutreDetails.Add(detailsautresfrais.Designation);
                            clsMetier.lstPrixAutreDetails.Add((double)detailsautresfrais.Prix);
                            clsMetier.lstQuantiteAutreDetails.Add((int)detailsautresfrais.Quantinte);
                        }
                        //Insertion dans la table autrefraie
                        autresfrais.inserts();
                        MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //On vide les liste contenant les valeurs
                    clsMetier.lstDesignationAutreDetails.Clear();
                    clsMetier.lstPrixAutreDetails.Clear();
                    clsMetier.lstQuantiteAutreDetails.Clear();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Voulez n'allez pouvoir modifier que les éléments principaux et non les détails, pour modifier les détails, veuillez supprimer l'enregistrement et ajouté le de nouveau =>>>>> Voulez - vous continuer ?", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (bsrc9.DataSource != null)
                        {
                            clsautrefraie a = (clsautrefraie)bsrc9.Current;
                            new clsautrefraie().update(a);
                            MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New();
            refresh();
        }

        private void btnDelete9_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc9.DataSource != null)
                    {
                        clsautrefraie a = (clsautrefraie)bsrc9.Current;
                        new clsautrefraie().delete(a);
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

        private void cboMalade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                personne = clsMetier.GetInstance().getClsmalade(((clsmalade)cboMalade.SelectedItem).Id);
                personne.Id = ((clsmalade)cboMalade.SelectedItem).Id;
                txtSexe.Text = personne.Sexe;
                txtTelephone.Text = personne.Telephone;
                txtDateNaissance.Text = personne.Datenaissance.ToString();
                txtEtatCivil.Text = personne.Etatcivil;
                txtNumero.Text = personne.Numero;

                txtProfession.Text = clsMetier.GetInstance().getClsprofession(personne.Id_profession.ToString()).Designation;
                txtEntreprise.Text = clsMetier.GetInstance().getClsetablissementpriseencharge(Convert.ToInt32(personne.Id)).Denomination;
                txtAirSante.Text = clsMetier.GetInstance().getClsairsante(personne.Id_airsante.ToString()).Designation;
                try
                {
                    pbPhotoPersonne.Image = (new clsDoTraitement()).getImageFromByte(personne.Photo);
                }
                catch (Exception) { pbPhotoPersonne.Image = null; }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message + ">>>>> " + "Erreur lors de la sélection du malade", "Erreur de sélection"); 
            }
        }

        private void cboEntrepriseProvenance_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboDesignation.DataSource = clsMetier.GetInstance().getAllClsdetailsautrefraieEntrepriseex(((clsetablissementexterne)cboEntrepriseProvenance.SelectedItem).Id);
                setMembersallcbo(cboDesignation, "Designation", "Id");
            }
            catch (Exception)
            { }
        }

        private void dgv9_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv9.SelectedRows.Count > 0)
                {
                    bindignlst9();
                    //bindignlstdetails();
                    try
                    {
                        lblCumulMontant.Text = "0";
                        bsrcdetails.DataSource = clsMetier.GetInstance().getAllClsdetailsautrefraie1(Convert.ToInt32(txtIdAutreFrais.Text));//((clsautrefraie)bsrc9.Current).Id

                        //Chargement de la liste des details
                        List<string> valeurs = clsMetier.GetInstance().getAllClsdetailsautrefraie2(((clsautrefraie)bsrc9.Current).Id, (int)((clsautrefraie)bsrc9.Current).Id_etablissementexterne);
                        int nbrItem = lstItems.Items.Count;

                        lstItems.Items.Clear();

                        foreach (string str in valeurs)
                        {
                            string[] tbItems = str.Split('|');
                            lstItems.Items.Add(tbItems[0]);
                            lblCumulMontant.Text = recalculateMontant(Convert.ToDouble(lblCumulMontant.Text), Convert.ToDouble(tbItems[3]), Convert.ToDouble(tbItems[1])).ToString();
                        }
                    }
                    catch (Exception) { }
                    bln9 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void lblAddEntreprise_Click(object sender, EventArgs e)
        {
            new EtablissementExterneFrm().Show();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboDesignation.Text.Equals("") || txtMontant.Text.Equals("") || txtQuantite.Text.Equals("")) MessageBox.Show("Veuillez spécifier un article, un montant de l'article ainsi que la quantité", "Ajout éléments", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    //Ajout des items formatés dans la liste
                    lstItems.Items.Add(txtQuantite.Text + "=>" + cboDesignation.Text + "=>" + txtMontant.Text);
                    lblCumulMontant.Text = recalculateMontant(Convert.ToDouble(lblCumulMontant.Text), Convert.ToDouble(txtMontant.Text), Convert.ToDouble(txtQuantite.Text)).ToString();
                    txtNetAPayer.Text = lblCumulMontant.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout de l'élément, " + ex.Message, "Ajout éléments", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private double recalculateMontant(double oldValue, double prix, double qte)
        {
            return oldValue + prix * qte;
        }

        private double recalculateMontant1(double oldValue, double prix, double qte)
        {
            return oldValue - prix * qte;
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            try
            {
                //Suppression items de la liste
                if (lstItems.Items.Count > 0)
                {
                    lstItems.Items.RemoveAt(lstItems.SelectedIndex);
                    lblCumulMontant.Text = recalculateMontant1(Convert.ToDouble(lblCumulMontant.Text), Convert.ToDouble(txtMontant.Text), Convert.ToDouble(txtQuantite.Text)).ToString();
                    txtNetAPayer.Text = lblCumulMontant.Text;
                }
                else MessageBox.Show("Il n'ya rien à supprimer", "Sppression éléments", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression de l'élément, " + ex.Message, "Sppression éléments", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgv99_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv99.SelectedRows.Count > 0)
                {
                    bindignlstdetails();
                    //bln9 = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage des détails", "Erreur d'affichage");
            }
        }

        private void cboEntrepriseProvenance_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterFormEtablissementExterne)
            {
                try
                {
                    cboEntrepriseProvenance.DataSource = clsMetier.GetInstance().getAllClsetablissementexterne();
                    setMembersallcbo(cboMalade, "Denomination", "Id");
                }
                catch (Exception) { }
            }
        }

        private void cboService_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboService.DataSource = clsMetier.GetInstance().getAllClsservice();
            }
            catch (Exception) { }
        }

        private void Tarif_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc1, bsrc2, bsrc3, bsrc4, bsrc5, bsrc6, bsrc7, bsrc8, bsrc9, bsrcBloc, bsrcdetails, bsrcService, bsrc10, bsrc11, bsrc12, bsrc13, bsrc14, bsrc15 };
                DataGridView[] dg = { dgv1, dgv2, dgv3, dgv4, dgv5, dgv6, dgv7, dgv8, dgv9, dgvBloc, dgvService, dgv99, dgv10, dgv11, dgv12, dgv13, dgv14, dgv15 };
                ComboBox[] cbo = { cboBloc, cboDesignation, cboEntrepriseProvenance, cboMalade, cboService, cboTypeExamen };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg, cbo);
            }
            catch (Exception) { }
        }
    }
}
