using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class PasserIntervationFrm : UserControl
    {
        public PasserIntervationFrm()
        {
            InitializeComponent();
        }
        #region Declaration

        clssubit subit = new clssubit();
        BindingSource bsrc = new BindingSource();
        BindingSource bsrcRest = new BindingSource();
        private bool bln = false;

        #endregion

        #region Binding 

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

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", subit, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", subit, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", subit, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", subit, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { cboIntervention, txtDate, txtObservation, txtId_malade, txtPaiement };
            clearforbinding(tbcontrols);
            txtId_malade.Text = clsDoTraitement.idMalade_Intervention.ToString();
            setbindingcls(txtDate, "Date", 0);
            setbindingcls(cboIntervention, "Id_intervention", 1);
            setbindingcls(txtObservation, "Observation", 0);
            setbindingcls(txtId_malade, "Id_malade", 0);
            setbindingcls(txtPaiement, "Etatpaiement", 0);

        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { cboIntervention, txtDate, txtObservation, txtId_malade, txtPaiement };
            clearforbinding(tbcontrols);

            setbindinglst(txtDate, "Date", 0);
            setbindinglst(cboIntervention, "Id_intervention", 1);
            setbindinglst(txtObservation, "Observation", 0);
            setbindinglst(txtId_malade, "Id_malade", 0);
            setbindinglst(txtPaiement, "Etatpaiement", 0);
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        #endregion

        #region Traitement

        private void New()
        {
            try
            {
                subit = new clssubit();
                bln = false;
                bindingcls();
                txtId_malade.Text = clsDoTraitement.idMalade_hospitalisation.ToString();
                txtPaiement.Text = "Non cloturé non payé";
                if (cboIntervention.Items.Count > 0) cboIntervention.SelectedIndex = 0;
            }
            catch (Exception) { btnSave.Enabled = false; }

        }

        private void refresh()
        {
            try
            {
                txtId_malade.Text = clsDoTraitement.idMalade_Intervention.ToString();
                bsrc.DataSource = clsMetier.GetInstance().getAllClssubit1(clsDoTraitement.idMalade_Intervention, "Non cloturé non payé", "Payé non cloturé");
                bsrcRest.DataSource = clsMetier.GetInstance().getAllClssubit1(clsDoTraitement.idMalade_Intervention, "Cloturé non payé", "Cloturé");
                cboIntervention.DataSource = clsMetier.GetInstance().getAllClsintervention();
                setMembersallcbo(cboIntervention, "Designation", "Id");
                if (cboIntervention.Items.Count > 0) cboIntervention.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            New();
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
                        clssubit s = (clssubit)bsrc.Current;
                        new clssubit().delete(s);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvSubit_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvSubit.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage");
            }
        }

        private void FrmPasserIntervation_Load(object sender, EventArgs e)
        {
            lblIntervention.Enabled = false;
            try
            {
                bindingcls();
                dgvSubit.DataSource = bsrc;
                lstArchive.DataSource = bsrcRest;
                //setMembersalllst(lstArchive, "Date", "Id");
                refresh();
            }
            catch (Exception) { }
        }

        private void setMembersalllst(ListBox lst, string displayMember, string valueMember)
        {
            lst.DisplayMember = displayMember;
            lst.ValueMember = valueMember;
        }

        #endregion

        private void lblIntervention_Click(object sender, EventArgs e)
        {
            IntervationFrm frm = new IntervationFrm();
            frm.ShowDialog();
        }

        private void btnCloturer_Click(object sender, EventArgs e)
        {
            try
            {
                if (((clssubit)dgvSubit.SelectedRows[0].DataBoundItem).Etatpaiement.ToString() == "Non cloturé non payé")
                {
                    clssubit s = new clssubit();
                    s.Date = ((clssubit)dgvSubit.SelectedRows[0].DataBoundItem).Date;
                    s.Id = ((clssubit)dgvSubit.SelectedRows[0].DataBoundItem).Id;
                    s.Id_intervention = ((clssubit)dgvSubit.SelectedRows[0].DataBoundItem).Id_intervention;
                    s.Id_malade = ((clssubit)dgvSubit.SelectedRows[0].DataBoundItem).Id_malade;
                    s.Observation = ((clssubit)dgvSubit.SelectedRows[0].DataBoundItem).Observation;
                    s.Etatpaiement = "Cloturé non payé";
                    new clssubit().update(s);
                    MessageBox.Show("Dossier Cloturé avec succès!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                else
                {
                    clssubit s = new clssubit();
                    s.Date = ((clssubit)dgvSubit.SelectedRows[0].DataBoundItem).Date;
                    s.Id = ((clssubit)dgvSubit.SelectedRows[0].DataBoundItem).Id;
                    s.Id_intervention = ((clssubit)dgvSubit.SelectedRows[0].DataBoundItem).Id_intervention;
                    s.Id_malade = ((clssubit)dgvSubit.SelectedRows[0].DataBoundItem).Id_malade;
                    s.Observation = ((clssubit)dgvSubit.SelectedRows[0].DataBoundItem).Observation;
                    s.Etatpaiement = "Cloturé";
                    new clssubit().update(s);
                    MessageBox.Show("Dossier Cloturé avec succès!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ">>>" + "Erreur Inentendue!", "Cloture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            try
            {
                if (((clssubit)lstArchive.SelectedItem).Etatpaiement.ToString() == "Cloturé non payé")
                {
                    clssubit s = new clssubit();
                    s.Date = ((clssubit)lstArchive.SelectedItem).Date;
                    s.Id = ((clssubit)lstArchive.SelectedItem).Id;
                    s.Id_intervention = ((clssubit)lstArchive.SelectedItem).Id_intervention;
                    s.Id_malade = ((clssubit)lstArchive.SelectedItem).Id_malade;
                    s.Observation = ((clssubit)lstArchive.SelectedItem).Observation;
                    s.Etatpaiement = "Non cloturé non payé";
                    new clssubit().update(s);
                    MessageBox.Show("Dossier restauré avec succès!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                else
                {
                    clssubit s = new clssubit();
                    s.Date = ((clssubit)lstArchive.SelectedItem).Date;
                    s.Id = ((clssubit)lstArchive.SelectedItem).Id;
                    s.Id_intervention = ((clssubit)lstArchive.SelectedItem).Id_intervention;
                    s.Id_malade = ((clssubit)lstArchive.SelectedItem).Id_malade;
                    s.Observation = ((clssubit)lstArchive.SelectedItem).Observation;
                    s.Etatpaiement = "Non cloturé payé";
                    new clssubit().update(s);
                    MessageBox.Show("Dossier restauré avec succès!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ">>>" + "Erreur Inentendue!", "Cloture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lstArchive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstArchive.SelectedItems.Count > 0)
            {
                txtEtatPaiement.Text = clsMetier.GetInstance().getClsintervention(((clssubit)lstArchive.SelectedItem).Id_intervention).Designation;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboIntervention_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterFormIntervention)
            {
                try
                {
                    cboIntervention.DataSource = clsMetier.GetInstance().getAllClsintervention();
                }
                catch (Exception) { }
            }
        }   
    }
}
