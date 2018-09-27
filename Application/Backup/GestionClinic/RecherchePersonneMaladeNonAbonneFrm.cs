using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class RecherchePersonneMaladeNonAbonneFrm : Form
    {
        public RecherchePersonneMaladeNonAbonneFrm()
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

        private void dgvMalade_DoubleClick(object sender, EventArgs e)
        {
            #region Chargement Data
            try
            {
                clsDoTraitement.Identifiant_Personne = Convert.ToInt32(dgvMalade["colid", dgvMalade.CurrentRow.Index].Value);
                clsDoTraitement.IdMalade = Convert.ToInt32(dgvMalade["colidMal", dgvMalade.CurrentRow.Index].Value);
                clsDoTraitement.idMaladeDossierPre = clsDoTraitement.IdMalade;
                clsDoTraitement.doubleclic_categorie_malade = clsMetier.GetInstance().getClscategoriemalade1(clsDoTraitement.IdMalade).Designation;
                clsDoTraitement.doubleclic_nom_malade = dgvMalade["colNom_complet", dgvMalade.CurrentRow.Index].Value.ToString();
                clsDoTraitement.doubleclic_entreprise = clsMetier.GetInstance().getClsetablissementpriseencharge(clsDoTraitement.IdMalade).Denomination;
                clsDoTraitement.doubleclic_taux = clsMetier.GetInstance().getClscategoriemalade1(clsDoTraitement.IdMalade).Taux;

                clsDoTraitement.doubleclicRecherchePersonneMaladeDg = true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message + " >>>> Erreur lors de la récupération des informations", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }
            #endregion Fin Chargement Data

            //Déchargement du BindingSource et DataGrid
            bsrc_mal.Dispose();
            dgvMalade.Dispose();

            this.Dispose();
        }

        private void FrmRecherchePersonne_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            try
            {
                dgvMalade.DataSource = bsrc_mal;
                bsrc_mal.DataSource = clsMetier.GetInstance().getAllClsmaladeDtNonAb();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Erreur lors du chargement des malades, " + ex.Message, "Chargement des malades", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void FrmRecherchePersonneMaladeNonAbonne_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Déchargement du BindingSource et DataGrid
                BindingSource[] bdsrc = { bsrc_mal };
                DataGridView[] dg = { dgvMalade };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg);
            }
            catch (Exception) { }
        }
    }
}
