using System;
using System.Windows.Forms;
using GestionClinic_LIB;
namespace GestionClinic_WIN
{
    public partial class AvortementFrm : Form
    {
        public AvortementFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsavortement avortement = new clsavortement();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void clearforbinding(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is DateTimePicker) ((DateTimePicker)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is ComboBox) ((ComboBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is CheckBox) ((CheckBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((DateTimePicker)ctrl[0]).Focus();
        }

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtDate, txtIdFemmeEnceinte };
            clearforbinding(tbcontrols);

            txtIdFemmeEnceinte.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
            setbindingcls(txtDate, "Date", 0);
            setbindingcls(txtIdFemmeEnceinte, "Id_maladegrosse", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtDate, txtIdFemmeEnceinte };
            clearforbinding(tbcontrols);

            setbindinglst(txtDate, "Date", 0);
            setbindinglst(txtIdFemmeEnceinte, "Id_maladegrosse", 0);
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", avortement, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is TextBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", avortement, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", avortement, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", avortement, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is TextBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void New()
        {
            avortement = new clsavortement();
            bln = false;
            bindingcls();
            txtIdFemmeEnceinte.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
        }

        private void refresh()
        {
            try
            {
                if (!clsDoTraitement.doubleclicAvortementDg)
                {
                    bindingcls();
                    txtIdFemmeEnceinte.Text = clsDoTraitement.IdFemmeEnceinte.ToString();
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsavortement();

                    cboMalade.DataSource = clsMetier.GetInstance().getAllClsmaladegrosse4(clsDoTraitement.IdFemmeEnceinte);
                    setMembersallcbo(cboMalade, "Nom_complet", "IdFemmeEnceinte");

                    //if (cboMalade.Items.Count > 0) cboMalade.SelectedIndex = 0;
                }
                else
                {
                    bsrc.DataSource = clsMetier.GetInstance().getAllClsavortement1(clsDoTraitement.idAvortementDg);
                    bln = true;
                    bindignlst();
                    btnAdd.Enabled = false;
                    cboMalade.DataSource = clsMetier.GetInstance().getAllClsmaladegrosse4(clsDoTraitement.IdFemmeEnceinte);
                    setMembersallcbo(cboMalade, "Nom_complet", "IdFemmeEnceinte");

                    //On met les valeurs correspondant a ceux de l'avortement selectionee
                    if (bsrc.Count != 0)
                    {
                        //On met les valeurs correspondantes a ceux de l'accouchement selectionee
                        txtDate.Text = ((clsavortement)bsrc.Current).Date.ToString(); 
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
                    avortement.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsavortement s = (clsavortement)bsrc.Current;
                        new clsavortement().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //clsDoTraitement.EnterFormAvortement = true;
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
                        clsavortement d = (clsavortement)bsrc.Current;
                        new clsavortement().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clsDoTraitement.EnterFormAvortement = true;
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

        private void FrmAvortement_Load(object sender, EventArgs e)
        {
            lblMalade.Enabled = false;
            txtIdFemmeEnceinte.Visible = false;

            try
            {
                bindingcls();
                refresh();
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement des listes déroulantes", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void cboMalade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.IdFemmeEnceinte = ((clsmaladegrosse)cboMalade.SelectedItem).IdFemmeEnceinte;
            }
            catch (Exception) { }
        }
    }
}
