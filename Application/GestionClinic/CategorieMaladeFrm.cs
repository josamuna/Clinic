using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class CategorieMaladeFrm : Form
    {
        public CategorieMaladeFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clscategoriemalade catMalade = new clscategoriemalade();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            txtTaux.DataBindings.Clear();
            txtDesignCategorieMalade.DataBindings.Clear();
            txtTaux.Focus();
            txtDesignCategorieMalade.DataBindings.Add("Text", catMalade, "Designation", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTaux.DataBindings.Add("Text", catMalade, "Taux", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void bindignlst()
        {
            //btnDelete.Enabled = true;
            txtTaux.DataBindings.Clear();
            txtDesignCategorieMalade.DataBindings.Clear();
            txtTaux.Focus();
            txtDesignCategorieMalade.DataBindings.Add("Text", bsrc, "Designation", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTaux.DataBindings.Add("Text", bsrc, "Taux", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void New()
        {
            catMalade = new clscategoriemalade();
            bln = false;
            bindingcls();
        }
        private void btnAddCateg_Click(object sender, EventArgs e)
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

        private void refresh()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClscategoriemalade();
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
                    catMalade.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clscategoriemalade s = (clscategoriemalade)bsrc.Current;
                        new clscategoriemalade().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Permet l'actualisation des valeur des qualifications sur le formulair des Agents
                clsDoTraitement.EnterFormCategorie = true;
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
                        clscategoriemalade d = (clscategoriemalade)bsrc.Current;
                        new clscategoriemalade().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refresh();
                    }
                    //Permet l'actualisation des valeur des qualifications sur le formulair des Agents
                    clsDoTraitement.EnterFormCategorie = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CategorieMalade_Load(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            txtDesignCategorieMalade.Enabled = false;

            try
            {
                bindingcls();
                dgvCategorieMalade.DataSource = bsrc;
                refresh();
            }
            catch (Exception) { }
        }

        private void dgvCategorieMalade_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategorieMalade.SelectedRows.Count > 0)
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

        private void FrmCategorieMalade_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgvCategorieMalade };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg);
            }
            catch (Exception) { }
        }
    }
}
