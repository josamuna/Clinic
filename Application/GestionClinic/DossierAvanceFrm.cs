using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class DossierAvanceFrm : Form
    {
        public DossierAvanceFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsdossieravance avance = new clsdossieravance();
        bool bln = false;
        BindingSource bsrc = new BindingSource();

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
            ((DateTimePicker)ctrl[0]).Focus();
        }

        private void setbindingclsAvanceDossier(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", avance, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", avance, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", avance, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", avance, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingclsAvanceDossier()
        {
            Control[] tbcontrols = { txtDateOuvertureDossier, cboService, txtEtatConsommation, txtIdAgent, txtIdMalade };
            clearforbinding(tbcontrols);
            setbindingclsAvanceDossier(txtDateOuvertureDossier, "Date", 0);
            setbindingclsAvanceDossier(cboService, "Id_tarifavance", 1);
            setbindingclsAvanceDossier(txtIdMalade, "Id_malade", 0);
            setbindingclsAvanceDossier(txtIdAgent, "Id_agent", 0);
            setbindingclsAvanceDossier(txtEtatConsommation, "Etatpaiement", 0);
        }

        public void New()
        {
            avance = new clsdossieravance();
            bln = false;
            bindingclsAvanceDossier();
            txtIdAgent.Text = clsDoTraitement.id_Agent_Connecte.ToString();
            txtIdMalade.Text = clsDoTraitement.idMaladeDossierPre.ToString();
        }

        private void setbindinglstDossierAvance(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindiglstDossierAvance()
        {
            Control[] tbcontrols = { txtDateOuvertureDossier, cboService, txtEtatConsommation, txtIdAgent, txtIdMalade };
            clearforbinding(tbcontrols);
            setbindinglstDossierAvance(cboService, "Id_tarifavance", 1);
            setbindinglstDossierAvance(txtDateOuvertureDossier, "Date", 0);
            setbindinglstDossierAvance(txtEtatConsommation, "Etatpaiement", 0);
            setbindinglstDossierAvance(txtIdAgent, "Id_agent", 0);
            setbindinglstDossierAvance(txtIdMalade, "Id_malade", 0);
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        public void refresh()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsdossieravance2(clsDoTraitement.idMaladeDossierPre, "Non cloturé non payé", "Payé non cloturé");
                cboService.DataSource = clsMetier.GetInstance().getAllClstarifavance();
                setMembersallcbo(cboService, "Designation", "Id");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                New();
                txtEtatConsommation.Text = "Non cloturé non payé";
            }
            catch (Exception)
            {
                btnSave.Enabled = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            try
            {
                DialogResult result = MessageBox.Show("Voulez - vous vraiment supprimer cet enregistrement ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (bsrc.DataSource != null)
                    {
                        clsdossieravance a = (clsdossieravance)bsrc.Current;
                        new clsdossieravance().delete(a);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.refresh();
                        btnDelete.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } try
            {
                if (!bln)
                {
                    avance.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsdossieravance c = (clsdossieravance)bsrc.Current;
                        new clsdossieravance().update(c);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsdossieravance2(clsDoTraitement.idMaladeDossierPre, "Non cloturé non payé", "Payé non cloturé");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lstDossierEncCours_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstDossierEncCours.Items.Count > 0)
                {
                    bindiglstDossierAvance();
                    btnDelete.Enabled = true;
                    bln = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void FrmDossierAvance_Load(object sender, EventArgs e)
        {
            bindingNavigator1.Enabled = true;
            try
            {
                lstDossierEncCours.DataSource = bsrc;
                refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de chargement de la liste", "Erreur de Chargement");
            }
        }
    }
}
