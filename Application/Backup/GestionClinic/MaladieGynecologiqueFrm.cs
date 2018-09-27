using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class MaladieGynecologiqueFrm : Form
    {
        public MaladieGynecologiqueFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsmaladiegynecologique maladie = new clsmaladiegynecologique();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            Control[] tbcontrols = { txtDesignation };
            clearforbinding(tbcontrols);

            setbindingcls(txtDesignation, "Designation", 0);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            Control[] tbcontrols = { txtDesignation, txtIdMaladie };
            clearforbinding(tbcontrols);

            setbindinglst(txtDesignation, "Designation", 0);

            //Recuperation de l'Id de la maladie
            setbindinglst(txtIdMaladie, "Id", 0);
            //clsDoTraitement.IdMaladie = Convert.ToInt32(txtIdMaladie.Text);
        }

        private void clearforbinding(Control[] ctrl)
        {
            int i = 0;
            foreach (Control x in ctrl)
            {
                if (ctrl[i] is TextBox) ((TextBox)ctrl[i]).DataBindings.Clear();
                else if (ctrl[i] is CheckBox) ((CheckBox)ctrl[i]).DataBindings.Clear();
                i++;
            }
            ((TextBox)ctrl[0]).Focus();
        }

        private void setbindingcls(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", maladie, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setbindinglst(Control ctrl, string strValue, int valueForCombo)
        {
            if (ctrl is TextBox) ctrl.DataBindings.Add("Text", bsrc, strValue, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void New()
        {
            maladie = new clsmaladiegynecologique();
            bln = false;
            bindingcls();
        }

        private void refresh()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsmaladiegynecologique();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    maladie.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsmaladiegynecologique s = (clsmaladiegynecologique)bsrc.Current;
                        new clsmaladiegynecologique().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Permet l'actualisation des valeur des maladie sur le formulair appelant
                clsDoTraitement.EnterFormMaladieGynecologique = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la mise à jour" + ex.Message, "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.New();
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
                        clsmaladiegynecologique d = (clsmaladiegynecologique)bsrc.Current;
                        new clsmaladiegynecologique().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refresh();
                    }
                }
                //Permet l'actualisation des valeur des maladie sur le formulair appelant
                clsDoTraitement.EnterFormMaladieGynecologique = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void FrmMaladie_Load(object sender, EventArgs e)
        {
            txtIdMaladie.Visible = false;
            try
            {
                bindingcls();
                dgv.DataSource = bsrc;
                refresh();
            }
            catch (Exception) { }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv.RowCount > 0) clsDoTraitement.IdMaladie = Convert.ToInt32(txtIdMaladie.Text);
            }
            catch (Exception) { }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void FrmMaladiegynecologique_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgv };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg);
            }
            catch (Exception) { }
        }
    }
}
