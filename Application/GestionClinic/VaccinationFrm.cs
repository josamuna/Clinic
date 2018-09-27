using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class VaccinationFrm : Form
    {
        public VaccinationFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsvaccination vaccination = new clsvaccination();
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
            ((DateTimePicker)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", vaccination, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", vaccination, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", vaccination, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", vaccination, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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
            Control[] tbcontrols = { txtDate, cboPeriode, cboVaccin, cboPriseVitamine, txtIdEnfant };
            clearforbinding(tbcontrols);

            txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
            setbindingcls(txtDate, "Date", 0);
            setbindingcls(cboPeriode, "Id_periodevaccination", 1);
            setbindingcls(cboVaccin, "Id_vaccin", 1);
            setbindingcls(cboPriseVitamine, "Id_prise_vitamine", 1);
            setbindingcls(txtIdEnfant, "Id_maladeenconsultationpostnatal", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtDate, cboPeriode, cboVaccin, cboPriseVitamine, txtIdEnfant };
            clearforbinding(tbcontrols);

            setbindinglst(txtDate, "Date", 0);
            setbindinglst(cboPeriode, "Id_periodevaccination", 1);
            setbindinglst(cboVaccin, "Id_vaccin", 1);
            setbindinglst(cboPriseVitamine, "Id_prise_vitamine", 1);
            setbindinglst(txtIdEnfant, "Id_maladeenconsultationpostnatal", 0);
        }

        private void New()
        {
            vaccination = new clsvaccination();
            bln = false;
            bindingcls();
            txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
            if (cboPeriode.Items.Count > 0) cboPeriode.SelectedIndex = 0;
            if (cboVaccin.Items.Count > 0) cboVaccin.SelectedIndex = 0;
            if (cboPriseVitamine.Items.Count > 0) cboPriseVitamine.SelectedIndex = 0;
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
                if (!clsDoTraitement.doubleclicVaccinationDg)
                {
                    bindingcls();
                    txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsvaccination();

                    cboEnfant.DataSource = clsMetier.GetInstance().getAllClsmaladeenconsultationpostnatal2(clsDoTraitement.IdEnfant);
                    setMembersallcbo(cboEnfant, "Nom_complet", "IdEnfant");
                    cboPeriode.DataSource = clsMetier.GetInstance().getAllClsperiodevaccination();
                    setMembersallcbo(cboPeriode, "Designation", "Id");
                    cboVaccin.DataSource = clsMetier.GetInstance().getAllClsvaccin();
                    setMembersallcbo(cboVaccin, "Designation", "Id");
                    cboPriseVitamine.DataSource = clsMetier.GetInstance().getAllClsprise_vitamine();
                    setMembersallcbo(cboPriseVitamine, "Designation", "Id");

                    if (cboEnfant.Items.Count > 0) cboEnfant.SelectedIndex = 0;
                    if (cboPeriode.Items.Count > 0) cboPeriode.SelectedIndex = 0;
                    if (cboVaccin.Items.Count > 0) cboVaccin.SelectedIndex = 0;
                    if (cboPriseVitamine.Items.Count > 0) cboPriseVitamine.SelectedIndex = 0;
                }
                else
                {
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsvaccination3(clsDoTraitement.idVaccinationDg);
                    bln = true;
                    bindignlst();
                    btnAdd.Enabled = false;
                    cboEnfant.DataSource = clsMetier.GetInstance().getAllClsmaladeenconsultationpostnatal2(clsDoTraitement.IdEnfant);
                    setMembersallcbo(cboEnfant, "Nom_complet", "IdEnfant");
                    cboPeriode.DataSource = clsMetier.GetInstance().getAllClsperiodevaccination();
                    setMembersallcbo(cboPeriode, "Designation", "Id");
                    cboVaccin.DataSource = clsMetier.GetInstance().getAllClsvaccin();
                    setMembersallcbo(cboVaccin, "Designation", "Id");
                    cboPriseVitamine.DataSource = clsMetier.GetInstance().getAllClsprise_vitamine();
                    setMembersallcbo(cboPriseVitamine, "Designation", "Id");

                    //On met les valeur correspondant a ceux de la vaccination selectionee
                    if (bsrc.Count != 0)
                    {
                        txtDate.Text = ((clsvaccination)bsrc.Current).Date.ToString();
                        cboPeriode.Text = clsMetier.GetInstance().getAllClsperiodevaccination1(clsDoTraitement.idVaccinationDg).Designation.ToString();
                        cboVaccin.Text = clsMetier.GetInstance().getAllClsvaccin1(clsDoTraitement.idVaccinationDg).Designation.ToString();
                        cboPriseVitamine.Text = clsMetier.GetInstance().getClsprise_vitamine3(clsDoTraitement.idVaccinationDg).Designation.ToString();
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
            //MessageBox.Show("Id_maladeenconsultationpostnatal = " + vaccination.Id_maladeenconsultationpostnatal.ToString() + " et vaccination.Id_vaccin =  " + vaccination.Id_vaccin.ToString());
            try
            {
                if (!bln)
                {
                    vaccination.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsvaccination s = (clsvaccination)bsrc.Current;
                        new clsvaccination().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.EnterFormVaccination = true;
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
                        clsvaccination d = (clsvaccination)bsrc.Current;
                        new clsvaccination().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clsDoTraitement.EnterFormVaccination = true;
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

        private void FrmVaccination_Load(object sender, EventArgs e)
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

        private void lblVaccin_Click(object sender, EventArgs e)
        {
            VaccinFrm frm = new VaccinFrm();
            frm.ShowDialog();
        }

        private void lblVitamine_Click(object sender, EventArgs e)
        {
            VitamineFrm frm = new VitamineFrm();
            frm.ShowDialog();
        }

        private void lblPeriode_Click(object sender, EventArgs e)
        {
            PeriodeVaccinationFrm frm = new PeriodeVaccinationFrm();
            frm.ShowDialog();
        }

        private void cboVaccin_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormVaccin)
            {
                try
                {
                    cboVaccin.DataSource = clsMetier.GetInstance().getAllClsvaccin();
                }
                catch (Exception) { }
            }
        }

        private void cboEnfant_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.IdEnfant = ((clsmaladeenconsultationpostnatal)cboEnfant.SelectedItem).IdEnfant;
            }
            catch (Exception) { }
        }

        private void lblPriseVitamine_Click(object sender, EventArgs e)
        {
            PriseVitamineFrm frm = new PriseVitamineFrm();
            frm.ShowDialog();
        }

        private void cboPriseVitamine_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterFormPriseVitamine)
            {
                try
                {
                    cboPriseVitamine.DataSource = clsMetier.GetInstance().getAllClsprise_vitamine();
                }
                catch (Exception) { }
            }
        }

        private void cboPeriode_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormPeriodeVaccination)
            {
                try
                {
                    cboPeriode.DataSource = clsMetier.GetInstance().getAllClsperiodevaccination();
                }
                catch (Exception) { }
            }
        }
    }
}
