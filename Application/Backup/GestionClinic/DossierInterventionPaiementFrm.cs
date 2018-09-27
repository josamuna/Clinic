using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class DossierInterventionPaiementFrm : Form
    {
        public DossierInterventionPaiementFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clssubit subit = new clssubit();
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

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", subit, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", subit, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", subit, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", subit, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls()
        {
            Control[] tbcontrols = { txtDate, cboIntervention, txtObservation, txtId_malade, txtPaiement };
            clearforbinding(tbcontrols);
            setbindingcls(txtDate, "Date", 0);
            setbindingcls(cboIntervention, "Id_intervention", 1);
            setbindingcls(txtObservation, "Observation", 0);
            setbindingcls(txtId_malade, "Id_malade", 0);
            setbindingcls(txtPaiement, "Etatpaiement", 0);

        }

        private void New()
        {
            try
            {
                subit = new clssubit();
                bln = false;
                bindingcls();
                txtId_malade.Text = clsDoTraitement.idMaladeDossierPre.ToString();
                txtPaiement.Text = "Non cloturé non payé";
            }
            catch (Exception) { btnSave.Enabled = false; }
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
                bsrc.DataSource = clsMetier.GetInstance().getAllClssubit1(clsDoTraitement.idMaladeDossierPre, "Non cloturé non payé", "Non payé cloturé");
                cboIntervention.DataSource = clsMetier.GetInstance().getAllClsintervention();
                setMembersallcbo(cboIntervention, "Designation", "Id");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindignlst()
        {
            Control[] tbcontrols = { txtDate, cboIntervention, txtObservation, txtId_malade, txtPaiement };
            clearforbinding(tbcontrols);

            setbindinglst(txtDate, "Date", 0);
            setbindinglst(cboIntervention, "Id_intervention", 1);
            setbindinglst(txtObservation, "Observation", 0);
            setbindinglst(txtId_malade, "Id_malade", 0);
            setbindinglst(txtPaiement, "Etatpaiement", 0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            New();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    subit.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clssubit s = (clssubit)bsrc.Current;
                        new clssubit().update(s);
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
                bsrc.DataSource = clsMetier.GetInstance().getAllClssubit1(clsDoTraitement.idMaladeDossierPre, "Non cloturé non payé", "Non payé cloturé");
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmDossierInterventionPaiement_Load(object sender, EventArgs e)
        {
            try
            {
                bindingcls();
                lstDossierEncCours1.DataSource = bsrc;
                refresh();
                bindingNavigator1.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de chargement de la liste", "Erreur de Chargement");
            }
        }

        private void lstDossierEncCours1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstDossierEncCours1.Items.Count > 0)
                {
                    bindignlst();
                    btnDelete.Enabled = true;
                    bln = true;

                    try
                    {
                        txtPrix.Text = clsMetier.GetInstance().getClsintervention(((clsintervention)cboIntervention.SelectedItem).Id).Prix.ToString();
                    }
                    catch (Exception) { txtPrix.Clear(); }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void cboIntervention_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtPrix.Text = clsMetier.GetInstance().getClsintervention(((clsintervention)cboIntervention.SelectedItem).Id).Prix.ToString();
            }
            catch (Exception) { txtPrix.Clear(); }
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
                        clssubit a = (clssubit)bsrc.Current;
                        new clssubit().delete(a);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.refresh();
                        btnDelete.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboIntervention_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.MAJ_Interventions)
            {
                try
                {
                    cboIntervention.DataSource = clsMetier.GetInstance().getAllClsintervention();
                    setMembersallcbo(cboIntervention, "Designation", "Id");
                }
                catch (Exception) { }
            }
        }

        private void lblAddTarif_Click(object sender, EventArgs e)
        {
            TarifsFrm fr = new TarifsFrm();
            fr.setFormPrincipal(principal);
            fr.Icon = principal.Icon;
            fr.ShowDialog();
        }
    }
}
