using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class RecherchePersonneAgentFrm : Form
    {
        public RecherchePersonneAgentFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        //Déclarations
        private BindingSource bsrc_mal = new BindingSource();

        private void FrmRecherchePersonne_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            try
            {
                dgvAgent.DataSource = bsrc_mal;
                bsrc_mal.DataSource = clsMetier.GetInstance().getAllClsagent1();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Erreur lors du chargement des agents, " + ex.Message, "Chargement des agents", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bsrc_mal.Filter = "nom LIKE '%" + txtSearch.Text + "%'";
            }
            catch (Exception)
            {
                ////MessageBox.Show("Erreur de lors de la récupération du malade", "Erreur de récupération du malade");
            }
        }

        private void dgvAgent_DoubleClick(object sender, EventArgs e)
        {
            #region Chargement Data
            try
            {
                clsDoTraitement.Identifiant_Personne = Convert.ToInt32(dgvAgent["colid", dgvAgent.CurrentRow.Index].Value);
                clsDoTraitement.Identifiant_Agent = Convert.ToInt32(dgvAgent["colidAg", dgvAgent.CurrentRow.Index].Value);

                clsDoTraitement.doubleclicRecherchePersonneAgentDg = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " >>>> Erreur lors de la récupération des informations", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            #endregion Fin Chargement Data

            //Déchargement du BindingSource et DataGrid
            bsrc_mal.Dispose();
            dgvAgent.Dispose();

            this.Dispose();
        }

        private void FrmRecherchePersonneAgent_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Déchargement du BindingSource et DataGrid
                BindingSource[] bdsrc = { bsrc_mal };
                DataGridView[] dg = { dgvAgent };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg);
            }
            catch (Exception) { }
        }
    }
}
