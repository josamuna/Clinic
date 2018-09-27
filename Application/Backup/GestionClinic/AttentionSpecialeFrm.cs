using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class AttentionSpecialeFrm : Form
    {
        public AttentionSpecialeFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsattention_speciale attSpec = new clsattention_speciale();
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
            ((ComboBox)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", attSpec, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", attSpec, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", attSpec, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", attSpec, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", attSpec, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
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
            Control[] tbcontrols = { cboAttention, chkMoustiqaire, txtIdEnfant };
            clearforbinding(tbcontrols);

            txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
            setbindingcls(cboAttention, "Id_attention", 1);
            setbindingcls(chkMoustiqaire, "Dort_sous_moust", 0);
            setbindingcls(txtIdEnfant, "Id_malade", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { cboAttention, chkMoustiqaire, txtIdEnfant };
            clearforbinding(tbcontrols);

            setbindinglst(cboAttention, "Id_attention", 1);
            setbindinglst(chkMoustiqaire, "Dort_sous_moust", 0);
            setbindinglst(txtIdEnfant, "Id_malade", 0);
        }

        private void New()
        {
            attSpec = new clsattention_speciale();
            bln = false;
            bindingcls();
            txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
            if (cboAttention.Items.Count > 0) cboAttention.SelectedIndex = 0;
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
                if (!clsDoTraitement.doubleclicAttentionSpecialeDg)
                {
                    bindingcls();
                    txtIdEnfant.Text = clsDoTraitement.IdEnfant.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsattention_speciale();

                    cboEnfant.DataSource = clsMetier.GetInstance().getAllClsmaladeenconsultationpostnatal2(clsDoTraitement.IdEnfant);
                    setMembersallcbo(cboEnfant, "Nom_complet", "IdEnfant");
                    cboAttention.DataSource = clsMetier.GetInstance().getAllClsattention();
                    setMembersallcbo(cboAttention, "Designation", "Id");

                    if (cboEnfant.Items.Count > 0) cboEnfant.SelectedIndex = 0;
                    if (cboAttention.Items.Count > 0) cboAttention.SelectedIndex = 0;
                }
                else
                {
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsattention_speciale3(clsDoTraitement.idAttentionSpecialeDg);
                    bln = true;
                    bindignlst();
                    btnAdd.Enabled = false;
                    cboEnfant.DataSource = clsMetier.GetInstance().getAllClsmaladeenconsultationpostnatal2(clsDoTraitement.IdEnfant);
                    setMembersallcbo(cboEnfant, "Nom_complet", "IdEnfant");
                    cboAttention.DataSource = clsMetier.GetInstance().getAllClsattention();
                    setMembersallcbo(cboAttention, "Designation", "Id");

                    //On met les valeur correspondant a ceux de l'attention speciale selectionee
                    if (bsrc.Count != 0)
                    {
                        chkMoustiqaire.Checked = (bool)((clsattention_speciale)bsrc.Current).Dort_sous_moust;
                        cboAttention.Text = clsMetier.GetInstance().getAllClsattention1(clsDoTraitement.idAttentionSpecialeDg).Designation.ToString();
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
                    attSpec.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    if (bsrc.DataSource != null)
                    {
                        clsattention_speciale s = (clsattention_speciale)bsrc.Current;
                        new clsattention_speciale().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.EnterFormAttentionSpeciale = true;
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
                        clsattention_speciale d = (clsattention_speciale)bsrc.Current;
                        new clsattention_speciale().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clsDoTraitement.EnterFormAttentionSpeciale = true;
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

        private void cboEnfant_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.IdEnfant = ((clsmaladeenconsultationpostnatal)cboEnfant.SelectedItem).IdEnfant;
            }
            catch (Exception) { }
        }

        private void FrmAttentionSpeciale_Load(object sender, EventArgs e)
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

        private void lblAttention_Click(object sender, EventArgs e)
        {
            AttentionFrm frm = new AttentionFrm();
            frm.ShowDialog();
        }

        private void cboAttention_DropDown(object sender, EventArgs e)
        {
            if (clsDoTraitement.EnterForFormAttention)
            {
                try
                {
                    cboAttention.DataSource = clsMetier.GetInstance().getAllClsattention();
                }
                catch (Exception) { }
            }
        }
    }
}
