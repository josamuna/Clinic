using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class EtablissementExterneFrm : Form
    {
        public EtablissementExterneFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsetablissementexterne etablissement = new clsetablissementexterne();
        private BindingSource bsrc = new BindingSource();
        private bool bln = false;
        private void bindingcls()
        {
            btnDelete.Enabled = false;
            txtDenomination.DataBindings.Clear();
            txtAdresse.DataBindings.Clear();
            txtTelephone.DataBindings.Clear();
            txtDenomination.Focus();
            txtDenomination.DataBindings.Add("Text", etablissement, "Denomination", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAdresse.DataBindings.Add("Text", etablissement, "Adresse", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTelephone.DataBindings.Add("Text", etablissement, "Telephone", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void bindignlst()
        {
            btnDelete.Enabled = true;
            txtDenomination.DataBindings.Clear();
            txtAdresse.DataBindings.Clear();
            txtTelephone.DataBindings.Clear();
            txtDenomination.Focus();
            txtDenomination.DataBindings.Add("Text", bsrc, "Denomination", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAdresse.DataBindings.Add("Text", bsrc, "Adresse", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTelephone.DataBindings.Add("Text", bsrc, "Telephone", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void New()
        {
            etablissement = new clsetablissementexterne();
            bln = false;
            bindingcls();
        }

        private void refresh()
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsetablissementexterne();
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
                    etablissement.inserts();
                    MessageBox.Show("Enregistrement éffectué", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (bsrc.DataSource != null)
                    {
                        clsetablissementexterne s = (clsetablissementexterne)bsrc.Current;
                        new clsetablissementexterne().update(s);
                        MessageBox.Show("Modification effectuée!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Permet l'actualisation des valeur des qualifications sur le formulair des Agents
                clsDoTraitement.EnterFormEtablissementExterne = true;
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
                        clsetablissementexterne d = (clsetablissementexterne)bsrc.Current;
                        new clsetablissementexterne().delete(d);
                        MessageBox.Show("Suppression éffectuée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.New();
                        refresh();
                    }
                    //Permet l'actualisation des valeur des etablissements sur le formulair des Tarif
                    clsDoTraitement.EnterFormEtablissementExterne = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Echec de la suppression " + ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                bsrc.DataSource = clsMetier.GetInstance().getAllClsetablissementexterne();
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur lors de l'actualisation", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvEtablissement_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvEtablissement.SelectedRows.Count > 0)
                {
                    bindignlst();
                    bln = true;
                }
            }
            catch (Exception) { MessageBox.Show("Erreur dans la zone d'affichage", "Erreur d'affichage"); }
        }

        private void FrmEtablissementExterne_Load(object sender, EventArgs e)
        {
            try
            {
                bindingcls();
                dgvEtablissement.DataSource = bsrc;
                refresh();
            }
            catch (Exception) { }
        }

        private void FrmEtablissementExterne_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                BindingSource[] bdsrc = { bsrc };
                DataGridView[] dg = { dgvEtablissement };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg);
            }
            catch (Exception) { }
        }
    }
}
