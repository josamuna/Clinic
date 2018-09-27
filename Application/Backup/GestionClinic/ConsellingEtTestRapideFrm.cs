using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class ConsellingEtTestRapideFrm : Form
    {
        public ConsellingEtTestRapideFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsconsellingettestrapide consellingTestRapide = new clsconsellingettestrapide();
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
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", consellingTestRapide, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", consellingTestRapide, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", consellingTestRapide, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", consellingTestRapide, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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
            Control[] tbcontrols = { txtRVRRegine, txtDateDebutTTT, txtDateDebutTravail, txtHeure, txtIdConsultationPrenatale };
            clearforbinding(tbcontrols);

            txtIdConsultationPrenatale.Text = clsDoTraitement.IdConsultationPreNatal.ToString();
            setbindingcls(txtRVRRegine, "Rvtregine", 0);
            setbindingcls(txtDateDebutTTT, "Datedebutttt", 0);
            setbindingcls(txtDateDebutTravail, "Datedebuttravail", 0);
            setbindingcls(txtHeure, "Heure", 0);
            setbindingcls(txtIdConsultationPrenatale, "Id_consultationprenatal", 0);
        }

        private void bindinglst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtRVRRegine, txtDateDebutTTT, txtDateDebutTravail, txtHeure, txtIdConsultationPrenatale };
            clearforbinding(tbcontrols);

            setbindinglst(txtRVRRegine, "Rvtregine", 0);
            setbindinglst(txtDateDebutTTT, "Datedebutttt", 0);
            setbindinglst(txtDateDebutTravail, "Datedebuttravail", 0);
            setbindinglst(txtHeure, "Heure", 0);
            setbindinglst(txtIdConsultationPrenatale, "Id_consultationprenatal", 0);
        }

        private void New()
        {
            consellingTestRapide = new clsconsellingettestrapide();
            bln = false;
            bindingcls();
            txtIdConsultationPrenatale.Text = clsDoTraitement.IdConsultationPreNatal.ToString();
        }

        private void FrmConsellingEtTestRapide_Load(object sender, EventArgs e)
        {
            txtIdConsultationPrenatale.Visible = false;

            try
            {
                if (!clsDoTraitement.doubleclicConcellingEtTestRapideDg)
                {
                    bindingcls();
                    txtIdConsultationPrenatale.Text = clsDoTraitement.IdConsultationPreNatal.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsconsellingettestrapide();
                }
                else
                {
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsconsellingettestrapide2(clsDoTraitement.idConcellingEtTestRapideDg);
                    bln = true;
                    bindinglst();
                    btnAdd.Enabled = false;

                    //On met les valeur correspondant a ceux de Conselling et Test Rapide selectione
                    if (bsrc.Count != 0)
                    {
                        txtRVRRegine.Text = ((clsconsellingettestrapide)bsrc.Current).Rvtregine;
                        txtDateDebutTTT.Text = ((clsconsellingettestrapide)bsrc.Current).Datedebutttt.ToString();
                        txtDateDebutTravail.Text = ((clsconsellingettestrapide)bsrc.Current).Datedebuttravail.ToString();
                        txtHeure.Text = ((clsconsellingettestrapide)bsrc.Current).Heure.ToString(); 
                    }
                }
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                New();
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    consellingTestRapide.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsconsellingettestrapide s = (clsconsellingettestrapide)bsrc.Current;
                        new clsconsellingettestrapide().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                        clsconsellingettestrapide d = (clsconsellingettestrapide)bsrc.Current;
                        new clsconsellingettestrapide().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
