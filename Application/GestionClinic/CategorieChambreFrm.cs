using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class CategorieChambreFrm : Form
    {
        public CategorieChambreFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clscategoriechambre categoriechambre = new clscategoriechambre();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            txtPrix.DataBindings.Clear();
            txtDesignation.DataBindings.Clear();
            txtDesignation.Focus();
            txtPrix.DataBindings.Add("Text", categoriechambre, "Prix", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDesignation.DataBindings.Add("Text", categoriechambre, "Designation", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            txtPrix.DataBindings.Clear();
            txtDesignation.DataBindings.Clear();
            txtDesignation.Focus();
            txtDesignation.DataBindings.Add("Text", bsrc, "Designation", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPrix.DataBindings.Add("Text", bsrc, "Prix", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            New();
        }
        
        private void refresh()
        {
            try
            {
            bsrc.DataSource = clsMetier.GetInstance().getAllClscategoriechambre();
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
                categoriechambre  = new clscategoriechambre();
                bln = false;
                bindingcls();
            }
            catch (Exception) { btnSave.Enabled = false; }
        }

        private void FrmCategorieChambre_Load(object sender, EventArgs e)
        {
            try
            {
                bindingcls();
                dgvCategorieChambre.DataSource = bsrc;
                refresh();
            }
            catch (Exception) { }
        }

        private void dgvCategorieChambre_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategorieChambre.SelectedRows.Count > 0)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bln)
                {
                    categoriechambre.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clscategoriechambre s = (clscategoriechambre)bsrc.Current;
                        new clscategoriechambre().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                clsDoTraitement.MAJ_Chambre = true;
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
                        clscategoriechambre c = (clscategoriechambre)bsrc.Current;
                        new clscategoriechambre().delete(c);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refresh();
                        clsDoTraitement.MAJ_Chambre = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void FrmCategorieChambre_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgvCategorieChambre };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg);
            }
            catch (Exception) { }
        }
    }
}
