using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class EntecedentMedicauxObsetricauxFrm : Form
    {
        public EntecedentMedicauxObsetricauxFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsentecedentmedicauxobsetricaux E = new clsentecedentmedicauxobsetricaux();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;
        private void bindingcls()
        {
            Clear();

            txtDernierAcouchement.DataBindings.Add("Text", E, "Datedernieraccouchement", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDyntocine.DataBindings.Add("Text", E, "Dynstocine", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEutocine.DataBindings.Add("Text", E, "Eutocine", true, DataSourceUpdateMode.OnPropertyChanged);
            txtGrossesseMulptiple.DataBindings.Add("Text", E, "Nbregrossessemultiple", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNbreAvant7Jour.DataBindings.Add("Text", E, "Mortavant7jour", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNbreBebePoidInf4.DataBindings.Add("Text", E, "Nbrebebepoidsinferieura4", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNbreBebePoidSup4.DataBindings.Add("Text", E, "Nbrebebepoidssuperieura4", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNbreEnfantMort.DataBindings.Add("Text", E, "Nombreenfantmort", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNombreEnfantMortNee.DataBindings.Add("Text", E, "Nombreenfantmordnee", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNombreEnfantVivant.DataBindings.Add("Text", E, "Nombreenfantvivant", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void Clear()
        {
            //btnDelete.Enabled = false;
            txtDernierAcouchement.DataBindings.Clear();
            txtDyntocine.DataBindings.Clear();
            txtEutocine.DataBindings.Clear();
            txtGrossesseMulptiple.Clear();
            txtNbreAvant7Jour.DataBindings.Clear();
            txtNbreBebePoidInf4.DataBindings.Clear();
            txtNbreBebePoidSup4.DataBindings.Clear();
            txtNbreEnfantMort.DataBindings.Clear();
            txtNombreEnfantMortNee.DataBindings.Clear();
            txtNombreEnfantVivant.DataBindings.Clear();
            txtNombreEnfantVivant.Focus();
        }
        private void bindignlst()
        {
            Clear();

            txtDernierAcouchement.DataBindings.Add("Text", bsrc, "Datedernieraccouchement", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDyntocine.DataBindings.Add("Text", bsrc, "Dynstocine", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEutocine.DataBindings.Add("Text", bsrc, "Eutocine", true, DataSourceUpdateMode.OnPropertyChanged);
            txtGrossesseMulptiple.DataBindings.Add("Text", bsrc, "Nbregrossessemultiple", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNbreAvant7Jour.DataBindings.Add("Text", bsrc, "Mortavant7jour", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNbreBebePoidInf4.DataBindings.Add("Text", bsrc, "Nbrebebepoidsinferieura4", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNbreBebePoidSup4.DataBindings.Add("Text", bsrc, "Nbrebebepoidssuperieura4", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNbreEnfantMort.DataBindings.Add("Text", bsrc, "Nombreenfantmort", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNombreEnfantMortNee.DataBindings.Add("Text", bsrc, "Nombreenfantmordnee", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNombreEnfantVivant.DataBindings.Add("Text", bsrc, "Nombreenfantvivant", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void New()
        {
            E = new clsentecedentmedicauxobsetricaux();
            bln = false;
            bindingcls();
        }
        private void refresh()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsentecedentmedicauxobsetricaux();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmEntecedentMedicauxObsetricaux_Load(object sender, EventArgs e)
        {
            try
            {

                bindingcls();
                refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    E.inserts();
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
            this.New();
            refresh();
        }

        private void btSupprimer_Click(object sender, EventArgs e)
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
    }
}
