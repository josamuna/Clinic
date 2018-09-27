using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class AntecedentMedicauxObsetricauxFrm : Form
    {
        public AntecedentMedicauxObsetricauxFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsentecedentmedicauxobsetricaux antecedentMedico = new clsentecedentmedicauxobsetricaux();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

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
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", antecedentMedico, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", antecedentMedico, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", antecedentMedico, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", antecedentMedico, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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
            Control[] tbcontrols = { txtNombreEnfantVivant, txtNbreEnfantMort,txtNombreEnfantMortNee, txtNbreAvant7Jour, txtDernierAcouchement, txtEutocine, txtDyntocine,
                                       txtNbreBebePoidSup4, txtNbreBebePoidInf4, txtGrossesseMulptiple, txtIdConsultationPrenatale };
            clearforbinding(tbcontrols);

            txtIdConsultationPrenatale.Text = clsDoTraitement.IdConsultationPreNatal.ToString();
            setbindingcls(txtNombreEnfantVivant, "Nombreenfantvivant", 0);
            setbindingcls(txtNbreEnfantMort, "Nombreenfantmort", 0);
            setbindingcls(txtNombreEnfantMortNee, "Nombreenfantmordnee", 0);
            setbindingcls(txtNbreAvant7Jour, "Mortavant7jour", 0);
            setbindingcls(txtDernierAcouchement, "Datedernieraccouchement", 0);
            setbindingcls(txtEutocine, "Eutocine", 0);
            setbindingcls(txtDyntocine, "Dynstocine", 0);
            setbindingcls(txtNbreBebePoidSup4, "Nbrebebepoidssuperieura4", 0);
            setbindingcls(txtNbreBebePoidInf4, "Nbrebebepoidsinferieura4", 0);
            setbindingcls(txtGrossesseMulptiple, "Nbregrossessemultiple", 0);
            setbindingcls(txtIdConsultationPrenatale, "Id_consultationprenatal", 0);
        }

        private void bindinglst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtNombreEnfantVivant, txtNbreEnfantMort,txtNombreEnfantMortNee, txtNbreAvant7Jour, txtDernierAcouchement, txtEutocine, txtDyntocine,
                                       txtNbreBebePoidSup4, txtNbreBebePoidInf4, txtGrossesseMulptiple, txtIdConsultationPrenatale };
            clearforbinding(tbcontrols);

            setbindinglst(txtNombreEnfantVivant, "Nombreenfantvivant", 0);
            setbindingcls(txtNbreEnfantMort, "Nombreenfantmort", 0);
            setbindinglst(txtNombreEnfantMortNee, "Nombreenfantmordnee", 0);
            setbindinglst(txtNbreAvant7Jour, "Mortavant7jour", 0);
            setbindinglst(txtDernierAcouchement, "Datedernieraccouchement", 0);
            setbindinglst(txtEutocine, "Eutocine", 0);
            setbindingcls(txtDyntocine, "Dynstocine", 0);
            setbindinglst(txtNbreBebePoidSup4, "Nbrebebepoidssuperieura4", 0);
            setbindinglst(txtNbreBebePoidInf4, "Nbrebebepoidsinferieura4", 0);
            setbindingcls(txtGrossesseMulptiple, "Nbregrossessemultiple", 0);
            setbindinglst(txtIdConsultationPrenatale, "Id_consultationprenatal", 0);
        }

        private void New()
        {
            antecedentMedico = new clsentecedentmedicauxobsetricaux();
            bln = false;
            bindingcls();
            txtIdConsultationPrenatale.Text = clsDoTraitement.IdConsultationPreNatal.ToString();
        }

        private void FrmEntecedentMedicauxObsetricaux_Load(object sender, EventArgs e)
        {
            txtIdConsultationPrenatale.Visible = false;
            try
            {
                if (!clsDoTraitement.doubleclicAntecedentMedicauxObstetriqueDg)
                {
                    bindingcls();
                    txtIdConsultationPrenatale.Text = clsDoTraitement.IdConsultationPreNatal.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsentecedentmedicauxobsetricaux();
                }
                else
                {
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsentecedentmedicauxobsetricaux2(clsDoTraitement.idAntecedentMedicauxObstetriqueDg);
                    bln = true;
                    bindinglst();
                    btnAdd.Enabled = false;

                    //On met les valeur correspondant a ceux de Antecedent Medico-Obstetric selectionee
                    if (bsrc.Count != 0)
                    {
                        txtNombreEnfantVivant.Text = ((clsentecedentmedicauxobsetricaux)bsrc.Current).Nombreenfantvivant.ToString();
                        txtNbreEnfantMort.Text = ((clsentecedentmedicauxobsetricaux)bsrc.Current).Nombreenfantmort.ToString();
                        txtNombreEnfantMortNee.Text = ((clsentecedentmedicauxobsetricaux)bsrc.Current).Nombreenfantmordnee.ToString();
                        txtNbreAvant7Jour.Text = ((clsentecedentmedicauxobsetricaux)bsrc.Current).Mortavant7jour.ToString();
                        txtDernierAcouchement.Text = ((clsentecedentmedicauxobsetricaux)bsrc.Current).Datedernieraccouchement.ToString();
                        txtEutocine.Text = ((clsentecedentmedicauxobsetricaux)bsrc.Current).Eutocine.ToString();
                        txtDyntocine.Text = ((clsentecedentmedicauxobsetricaux)bsrc.Current).Dynstocine.ToString();
                        txtNbreBebePoidSup4.Text = ((clsentecedentmedicauxobsetricaux)bsrc.Current).Nbrebebepoidssuperieura4.ToString();
                        txtNbreBebePoidInf4.Text = ((clsentecedentmedicauxobsetricaux)bsrc.Current).Nbrebebepoidssuperieura4.ToString();
                        txtGrossesseMulptiple.Text = ((clsentecedentmedicauxobsetricaux)bsrc.Current).Nbregrossessemultiple.ToString();
                    }
                }
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    antecedentMedico.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsentecedentmedicauxobsetricaux s = (clsentecedentmedicauxobsetricaux)bsrc.Current;
                        new clsentecedentmedicauxobsetricaux().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc.DataSource != null)
                    {
                        clsentecedentmedicauxobsetricaux d = (clsentecedentmedicauxobsetricaux)bsrc.Current;
                        new clsentecedentmedicauxobsetricaux().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    antecedentMedico.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsentecedentmedicauxobsetricaux s = (clsentecedentmedicauxobsetricaux)bsrc.Current;
                        new clsentecedentmedicauxobsetricaux().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
