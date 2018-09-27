using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class RecherchePersonneFrm : Form
    {
        public RecherchePersonneFrm()
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
            try
            {
                dgvPersonne.DataSource = bsrc_mal;
                bsrc_mal.DataSource = clsMetier.GetInstance().getAllClspersonneDt();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Erreur lors du chargement des personnes, " + ex.Message, "Chargement des personnes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtSearch.Focus();
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

        private void dgvPersonne_DoubleClick(object sender, EventArgs e)
        {
            #region Chargement Data
            try
            {
                clsDoTraitement.Identifiant_Personne = Convert.ToInt32(dgvPersonne["colid", dgvPersonne.CurrentRow.Index].Value);
                clsDoTraitement.FullNamePersonne = dgvPersonne["colNom_complet", dgvPersonne.CurrentRow.Index].Value.ToString();
                clsDoTraitement.NomPersonne = dgvPersonne["colnom", dgvPersonne.CurrentRow.Index].Value.ToString();
                clsDoTraitement.PostnomPersonne = dgvPersonne["colpostnom", dgvPersonne.CurrentRow.Index].Value.ToString();
                clsDoTraitement.PrenomPersonne = dgvPersonne["colprenom", dgvPersonne.CurrentRow.Index].Value.ToString();
                clsDoTraitement.SexePersonne = dgvPersonne["colsexe", dgvPersonne.CurrentRow.Index].Value.ToString();
                clsDoTraitement.TelPersonne = dgvPersonne["coltelephone", dgvPersonne.CurrentRow.Index].Value.ToString();
                clsDoTraitement.EtatCivPersonne = dgvPersonne["coletatcivil", dgvPersonne.CurrentRow.Index].Value.ToString();
                clsDoTraitement.AdressePersonne = dgvPersonne["coladresse", dgvPersonne.CurrentRow.Index].Value.ToString();
                clsDoTraitement.DatenaissancePersonne = (dgvPersonne["coldatenaissance", dgvPersonne.CurrentRow.Index].Value == DBNull.Value) ? Convert.ToDateTime(null) : Convert.ToDateTime(dgvPersonne["coldatenaissance", dgvPersonne.CurrentRow.Index].Value);

                clsDoTraitement.doubleclicRecherchePersonneDg = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " >>>> Erreur lors de la récupération des informations", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            #endregion Fin Chargement Data

            //Déchargement du BindingSource et DataGrid
            bsrc_mal.Dispose();
            dgvPersonne.Dispose();

            this.Dispose();
        }

        private void FrmRecherchePersonne_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Déchargement du BindingSource et DataGrid
                BindingSource[] bdsrc = { bsrc_mal };
                DataGridView[] dg = { dgvPersonne };
                clsDoTraitement.GetInstance().unloadData(bdsrc, dg);
            }
            catch (Exception) { }
        }
    }
}
