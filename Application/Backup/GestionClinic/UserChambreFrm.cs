using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class UserChambreFrm : UserControl
    {
        public UserChambreFrm()
        {
            InitializeComponent();
        }
        clschambre chambre = new clschambre();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", chambre, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", chambre, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", chambre, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", chambre, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is DateTimePicker) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 0) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is ComboBox && valueForCombo == 1) ctrl.DataBindings.Add("SelectedValue", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
            else if (ctrl is CheckBox) ctrl.DataBindings.Add("Checked", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

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

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtNumero, txtDesignation, cboCategorie };
            clearforbinding(tbcontrols);

            setbindingcls(txtNumero, "Numero", 0);
            setbindingcls(txtDesignation, "Designation", 0);
            setbindingcls(cboCategorie, "Id_categoriechambre", 1);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtNumero, txtDesignation, cboCategorie };
            clearforbinding(tbcontrols);

            setbindinglst(txtNumero, "Numero", 0);
            setbindinglst(txtDesignation, "Designation", 0);
            setbindinglst(cboCategorie, "Id_categoriechambre", 1);

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
                cboCategorie.DataSource = clsMetier.GetInstance().getAllClscategoriechambre();
                setMembersallcbo(cboCategorie, "Designation", "Id");
                if (cboCategorie.Items.Count > 0) cboCategorie.SelectedIndex = 0;

                bsrc.DataSource = clsMetier.GetInstance().getAllClschambre();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void New()
        {
            try
            {
                chambre = new clschambre();
                bln = false;
                bindingcls();
                if (cboCategorie.Items.Count > 0) cboCategorie.SelectedIndex = 0;
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            New();
        }

        private void FrmUserChambre_Load(object sender, EventArgs e)
        {
            try
            {
                bindingcls();
                dgvChambre.DataSource = bsrc;
                refresh();
            }
            catch (Exception) { }
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
                        clschambre c = (clschambre)bsrc.Current;
                        new clschambre().delete(c);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    chambre.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clschambre c = (clschambre)bsrc.Current;
                        new clschambre().update(c);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New();
            refresh();
        }

        private void dgvChambre_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvChambre.SelectedRows.Count > 0)
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void cboCategorie_DropDown(object sender, EventArgs e)
        {
                try
                {
                    cboCategorie.DataSource = clsMetier.GetInstance().getAllClscategoriechambre();
                }
                catch (Exception) { }
        }

        private void lblAddCategorie_Click(object sender, EventArgs e)
        {
            CategorieChambreFrm categorie = new CategorieChambreFrm();
            categorie.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgvChambre };
                ComboBox[] cbo = { cboCategorie };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg, cbo);
            }
            catch (Exception) { }

            this.Dispose();
        }
    }
}
