using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class TypeExamenFrm : Form
    {
        public TypeExamenFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clstypeexamen tpExamen = new clstypeexamen();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;

        private void bindingcls()
        {
            btnDelete.Enabled = false;
            txtDesignTypeExamen.DataBindings.Clear();
            txtDesignTypeExamen.Focus();
            txtDesignTypeExamen.DataBindings.Add("Text", tpExamen, "Designation", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bindignlst()
        {
            btnDelete.Enabled = true;
            txtDesignTypeExamen.DataBindings.Clear();
            txtDesignTypeExamen.DataBindings.Add("Text", bsrc, "Designation", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void New()
        {
            tpExamen = new clstypeexamen();
            bln = false;
            bindingcls();
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
                    tpExamen.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clstypeexamen s = (clstypeexamen)bsrc.Current;
                        new clstypeexamen().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Permet l'actualisation des valeur des type d'examens sur le formulair des examens
                clsDoTraitement.EnterForFormTypeExamen = true;
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
                        clstypeexamen d = (clstypeexamen)bsrc.Current;
                        new clstypeexamen().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refresh();
                    }
                }
                //Permet l'actualisation des valeur des professions sur le formulair des malades
                clsDoTraitement.EnterForFormTypeExamen = true;
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

        private void refresh()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClstypeexamen();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmTypeExamen_Load(object sender, EventArgs e)
        {
            try
            {
                bindingcls();
                dgvTypeExamen.DataSource = bsrc;
                refresh();
            }
            catch (Exception) { MessageBox.Show("Erreur lors du chargement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }  
        }

        private void dgvTypeExamen_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvTypeExamen.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void FrmTypeExamen_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgvTypeExamen };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg);
            }
            catch (Exception) { }
        }
    }
}
