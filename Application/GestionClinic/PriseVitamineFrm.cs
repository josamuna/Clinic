using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class PriseVitamineFrm : Form
    {
        public PriseVitamineFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsprise_vitamine priseVitamine = new clsprise_vitamine();
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
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", priseVitamine, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", priseVitamine, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", priseVitamine, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", priseVitamine, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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
            Control[] tbcontrols = { txtDate, txtIdEnfant, cboPeriode, cboVitamine };
            clearforbinding(tbcontrols);

            txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
            setbindingcls(txtDate, "Date_operation", 0);
            setbindingcls(txtIdEnfant, "Id_malade", 0);
            setbindingcls(cboPeriode, "Id_periode", 1);
            setbindingcls(cboVitamine, "Id_vitamine", 1);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtDate, txtIdEnfant, cboPeriode, cboVitamine };
            clearforbinding(tbcontrols);

            setbindinglst(txtDate, "Date_operation", 0);
            setbindinglst(txtIdEnfant, "Id_malade", 0);
            setbindinglst(cboPeriode, "Id_periode", 1);
            setbindinglst(cboVitamine, "Id_vitamine", 1);
        }

        private void New()
        {
            priseVitamine = new clsprise_vitamine();
            bln = false; 
            bindingcls(); 
            txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
            if (cboPeriode.Items.Count > 0) cboPeriode.SelectedIndex = 0;
            if (cboVitamine.Items.Count > 0) cboVitamine.SelectedIndex = 0;
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
                if (!clsDoTraitement.doubleclicPriseVitamineDg)
                {
                    bindingcls();
                    txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsprise_vitamine();

                    cboEnfant.DataSource = clsMetier.GetInstance().getAllClsmaladeenconsultationpostnatal2(clsDoTraitement.IdEnfant);
                    setMembersallcbo(cboEnfant, "Nom_complet", "IdEnfant");
                    cboPeriode.DataSource = clsMetier.GetInstance().getAllClsperiode();
                    setMembersallcbo(cboPeriode, "Designation", "Id");
                    cboVitamine.DataSource = clsMetier.GetInstance().getAllClsvitamine();
                    setMembersallcbo(cboVitamine, "Designation", "Id");

                    if (cboEnfant.Items.Count > 0) cboEnfant.SelectedIndex = 0;
                    if (cboPeriode.Items.Count > 0) cboPeriode.SelectedIndex = 0;
                    if (cboVitamine.Items.Count > 0) cboVitamine.SelectedIndex = 0;
                }
                else
                {
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsprise_vitamine4(clsDoTraitement.idPriseVitamineDg);
                    bln = true;
                    bindignlst();
                    btnAdd.Enabled = false;
                    cboEnfant.DataSource = clsMetier.GetInstance().getAllClsmaladeenconsultationpostnatal2(clsDoTraitement.IdEnfant);
                    setMembersallcbo(cboEnfant, "Nom_complet", "IdEnfant");
                    cboPeriode.DataSource = clsMetier.GetInstance().getAllClsperiode();
                    setMembersallcbo(cboPeriode, "Designation", "Id");
                    cboVitamine.DataSource = clsMetier.GetInstance().getAllClsvitamine();
                    setMembersallcbo(cboVitamine, "Designation", "Id");

                    //On met les valeur correspondant a ceux de la prise de vitamine selectionee
                    if (bsrc.Count != 0)
                    {
                        txtDate.Text = ((clsprise_vitamine)bsrc.Current).Date_operation.ToString();
                        cboPeriode.Text = clsMetier.GetInstance().getAllClsperiode1(clsDoTraitement.idPriseVitamineDg).Designation.ToString();
                        cboVitamine.Text = clsMetier.GetInstance().getAllClsvitamine1(clsDoTraitement.idPriseVitamineDg).Designation.ToString();
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
            //MessageBox.Show("Id_malade = " + priseVitamine.Id_malade.ToString() + " et priseVitamine.Id_periode =  " + priseVitamine.Id_periode.ToString());
            try
            {
                if (!bln)
                {
                    priseVitamine.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsprise_vitamine s = (clsprise_vitamine)bsrc.Current;
                        new clsprise_vitamine().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.EnterFormPriseVitamine = true;
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
                        clsprise_vitamine d = (clsprise_vitamine)bsrc.Current;
                        new clsprise_vitamine().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clsDoTraitement.EnterFormPriseVitamine = true;
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

        private void cboVitamine_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormVitamine)
            {
                try
                {
                    cboVitamine.DataSource = clsMetier.GetInstance().getAllClsvitamine();
                }
                catch (Exception) { }
            }
        }

        private void cboPeriode_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormPeriodeVitamine)
            {
                try
                {
                    cboPeriode.DataSource = clsMetier.GetInstance().getAllClsperiode();
                }
                catch (Exception) { }
            }
        }

        private void lblVitamine_Click(object sender, EventArgs e)
        {
            VitamineFrm frm = new VitamineFrm();
            frm.ShowDialog();
        }

        private void lblPeriode_Click(object sender, EventArgs e)
        {
            PeriodeVitamineFrm frm = new PeriodeVitamineFrm();
            frm.ShowDialog();
        }

        private void FrmPriseVitamine_Load(object sender, EventArgs e)
        {
            lblEnfant.Enabled = false;
            txtIdEnfant.Visible = false;
            try
            {
                bindingcls();
                refresh();
            }
            catch (Exception) 
            {
                MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
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
    }
}
