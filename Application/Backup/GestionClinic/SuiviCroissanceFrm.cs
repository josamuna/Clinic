using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class FrmSuivieCroissance : Form
    {
        public FrmSuivieCroissance()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clssuivicroissance suiviCrois = new clssuivicroissance();
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
            ((TextBox)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", suiviCrois, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", suiviCrois, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", suiviCrois, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", suiviCrois, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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
            Control[] tbcontrols = { txtPoid, txtDate, cboMoisAnnee, txtIdEnfant };
            clearforbinding(tbcontrols);

            txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
            setbindingcls(txtDate, "Date", 0);
            setbindingcls(cboMoisAnnee, "Mois", 0);
            setbindingcls(txtPoid, "Poid", 0);
            setbindingcls(txtIdEnfant, "Id_maladeenconsultationpostnatal", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtPoid, txtDate, cboMoisAnnee, txtIdEnfant };
            clearforbinding(tbcontrols);

            setbindinglst(txtDate, "Date", 0);
            setbindinglst(cboMoisAnnee, "Mois", 0);
            setbindinglst(txtPoid, "Poid", 0);
            setbindinglst(txtIdEnfant, "Id_maladeenconsultationpostnatal", 0);
        }

        private void New()
        {
            suiviCrois = new clssuivicroissance();
            bln = false;
            bindingcls();
            txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
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
                if (!clsDoTraitement.doubleclicSuivicroissanceDg)
                {
                    bindingcls();
                    txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClssuivicroissance();

                    cboEnfant.DataSource = clsMetier.GetInstance().getAllClsmaladeenconsultationpostnatal2(clsDoTraitement.IdEnfant);
                    setMembersallcbo(cboEnfant, "Nom_complet", "IdEnfant");

                    //if (cboEnfant.Items.Count > 0) cboEnfant.SelectedIndex = 0;
                }
                else
                {
                    bsrc.DataSource = clsMetier.GetInstance().getAllClssuivicroissance2(clsDoTraitement.idSuivicroissanceDg);
                    bln = true;
                    bindignlst();
                    btnAdd.Enabled = false;
                    cboEnfant.DataSource = clsMetier.GetInstance().getAllClsmaladeenconsultationpostnatal2(clsDoTraitement.IdEnfant);
                    setMembersallcbo(cboEnfant, "Nom_complet", "IdEnfant");

                    //On met les valeur correspondant a ceux du suivi de croissance selectione
                    if (bsrc.Count != 0)
                    {
                        cboMoisAnnee.Text = ((clssuivicroissance)bsrc.Current).Mois.ToString();
                        txtDate.Text = ((clssuivicroissance)bsrc.Current).Date.ToString();
                        txtPoid.Text = ((clssuivicroissance)bsrc.Current).Poid.ToString();
                    }
                    //chkMoustiqaire.Checked = Boolean.Parse(clsMetier.GetInstance().getClssuivicroissance(clsDoTraitement.idSuivicroissanceDg).Dormersousmoustiquaire);
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
                    suiviCrois.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clssuivicroissance s = (clssuivicroissance)bsrc.Current;
                        new clssuivicroissance().update(s);
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
                        clssuivicroissance d = (clssuivicroissance)bsrc.Current;
                        new clssuivicroissance().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FrmSuivieCroissance_Load(object sender, EventArgs e)
        {
            lblEnfant.Enabled = false;
            txtIdEnfant.Visible = false;
            try
            {
                bindingcls();
                cboMoisAnnee.Items.Add(1);
                cboMoisAnnee.Items.Add(2);
                cboMoisAnnee.Items.Add(3);
                cboMoisAnnee.Items.Add(4);
                cboMoisAnnee.Items.Add(5);
                cboMoisAnnee.Items.Add(6);
                cboMoisAnnee.Items.Add(7);
                cboMoisAnnee.Items.Add(8);
                cboMoisAnnee.Items.Add(9);
                cboMoisAnnee.Items.Add(10);
                cboMoisAnnee.Items.Add(11);
                cboMoisAnnee.Items.Add(12);
                cboMoisAnnee.SelectedIndex = 0;
                refresh();
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
    }
}
