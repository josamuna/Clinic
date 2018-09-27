using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class ConsultationFicheFrm : Form
    {
        public ConsultationFicheFrm()
        {
            InitializeComponent();
        }

        clsconsultation_fiche consFiche = new clsconsultation_fiche();
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
                else if (ctrl[i] is CheckBox) ((CheckBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((DateTimePicker)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", consFiche, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", consFiche, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", consFiche, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", consFiche, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", consFiche, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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
            Control[] tbcontrols = { txtDate, cboSuivieCroissance, cboRdv, cboVaccination, chkMoustiqaire, txtIdEnfant };
            clearforbinding(tbcontrols);

            setbindingcls(txtDate, "Date_consultaion", 0);
            setbindingcls(txtIdEnfant, "Id_malade", 0);
            setbindingcls(cboSuivieCroissance, "Id_suivicroissance", 1);
            setbindingcls(cboRdv, "Id_rendezvous", 1);
            setbindingcls(cboVaccination, "Id_vaccination", 1);
            setbindingcls(chkMoustiqaire, "Dort_sous_moust", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtDate, cboSuivieCroissance, cboRdv, cboVaccination, chkMoustiqaire, txtIdEnfant };
            clearforbinding(tbcontrols);

            setbindinglst(txtDate, "Date_consultaion", 0);
            setbindinglst(txtIdEnfant, "Id_malade", 0);
            setbindinglst(cboSuivieCroissance, "Id_suivicroissance", 1);
            setbindinglst(cboRdv, "Id_rendezvous", 1);
            setbindinglst(cboVaccination, "Id_vaccination", 1);
            setbindinglst(chkMoustiqaire, "Dort_sous_moust", 0);
        }

        private void New()
        {
            consFiche = new clsconsultation_fiche();
            bln = false;
            bindingcls();
            txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
            if (cboSuivieCroissance.Items.Count > 0) cboSuivieCroissance.SelectedIndex = 0;
            if (cboRdv.Items.Count > 0) cboRdv.SelectedIndex = 0;
            if (cboVaccination.Items.Count > 0) cboVaccination.SelectedIndex = 0;
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
                if (!clsDoTraitement.doubleclicConsultationFicheDg)
                {
                    bindingcls();
                    txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsconsultation_fiche();

                    cboEnfant.DataSource = clsMetier.GetInstance().getAllClsmaladeenconsultationpostnatal2(clsDoTraitement.IdEnfant);
                    setMembersallcbo(cboEnfant, "Nom_complet", "IdEnfant");
                    cboSuivieCroissance.DataSource = clsMetier.GetInstance().getAllClssuivicroissance();
                    setMembersallcbo(cboSuivieCroissance, "Date", "Id");
                    cboRdv.DataSource = clsMetier.GetInstance().getAllClsrendezvous();
                    setMembersallcbo(cboRdv, "Date", "Id");
                    cboVaccination.DataSource = clsMetier.GetInstance().getAllClsvaccination();
                    setMembersallcbo(cboVaccination, "Date", "Id");

                    if (cboEnfant.Items.Count > 0) cboEnfant.SelectedIndex = 0;
                    if (cboSuivieCroissance.Items.Count > 0) cboSuivieCroissance.SelectedIndex = 0;
                    if (cboVaccination.Items.Count > 0) cboVaccination.SelectedIndex = 0;
                    if (cboRdv.Items.Count > 0) cboRdv.SelectedIndex = 0;
                }
                else
                {
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsconsultation_fiche3(clsDoTraitement.idConsultationFicheDg);
                    bln = true;
                    bindignlst();
                    btnAdd.Enabled = false;
                    cboEnfant.DataSource = clsMetier.GetInstance().getAllClsmaladeenconsultationpostnatal2(clsDoTraitement.IdEnfant);
                    setMembersallcbo(cboEnfant, "Nom_complet", "IdEnfant");
                    cboSuivieCroissance.DataSource = clsMetier.GetInstance().getAllClssuivicroissance();
                    setMembersallcbo(cboSuivieCroissance, "Date", "Id");
                    cboRdv.DataSource = clsMetier.GetInstance().getAllClsrendezvous();
                    setMembersallcbo(cboRdv, "Date", "Id");
                    cboVaccination.DataSource = clsMetier.GetInstance().getAllClsvaccination();
                    setMembersallcbo(cboVaccination, "Date", "Id");

                    //On met les valeur correspondant a ceux de la Consultation de fiche selectionee
                    if (bsrc.Count != 0)
                    {
                        txtDate.Text = ((clsconsultation_fiche)bsrc.Current).Date_consultaion.ToString();
                        chkMoustiqaire.Checked = (bool)((clsconsultation_fiche)bsrc.Current).Dort_sous_moust;
                        cboRdv.Text = clsMetier.GetInstance().getClsrendezvous3(clsDoTraitement.idConsultationFicheDg).Date.ToString();
                        cboVaccination.Text = clsMetier.GetInstance().getAllClsvaccination4(clsDoTraitement.idConsultationFicheDg).Date.ToString();
                        cboSuivieCroissance.Text = clsMetier.GetInstance().getClssuivicroissance3(clsDoTraitement.idConsultationFicheDg).Date.ToString();
                    }
                }
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
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    consFiche.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    if (bsrc.DataSource != null)
                    {
                        clsconsultation_fiche s = (clsconsultation_fiche)bsrc.Current;
                        new clsconsultation_fiche().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.EnterFormConsultationFiche = true;
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
                        clsconsultation_fiche d = (clsconsultation_fiche)bsrc.Current;
                        new clsconsultation_fiche().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clsDoTraitement.EnterFormConsultationFiche = true;
                        //this.New();
                        //refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       

        private void cboEnfant_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    clsDoTraitement.IdEnfant = ((clsmaladeenconsultationpostnatal)cboEnfant.SelectedItem).IdEnfant;
            //}
            //catch (Exception) { }
        }

        private void lblSuivieCroissance_Click(object sender, EventArgs e)
        {
            FrmSuivieCroissance frm = new FrmSuivieCroissance();
            frm.ShowDialog();
        }

        private void lblRdv_Click(object sender, EventArgs e)
        {
            RendezVousFrm frm = new RendezVousFrm();
            frm.ShowDialog();
        }

        private void lblVaccination_Click(object sender, EventArgs e)
        {
            VaccinationFrm frm = new VaccinationFrm();
            frm.ShowDialog();
        }

        private void FrmConsultationFiche_Load(object sender, EventArgs e)
        {
            lblEnfant.Enabled = false;
            txtIdEnfant.Visible = false;
            try
            {
                bindingcls();
                refresh();
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void cboSuivieCroissance_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormSuiviCroissance)
            {
                try
                {
                    cboSuivieCroissance.DataSource = clsMetier.GetInstance().getAllClssuivicroissance();
                }
                catch (Exception) { }
            }
        }

        private void cboRdv_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormRendezVous)
            {
                try
                {
                    cboRdv.DataSource = clsMetier.GetInstance().getAllClsrendezvous();
                }
                catch (Exception) { }
            }
        }

        private void cboVaccination_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterFormVaccination)
            {
                try
                {
                    cboVaccination.DataSource = clsMetier.GetInstance().getAllClsvaccination();
                }
                catch (Exception) { }
            }
        }
    }
}
