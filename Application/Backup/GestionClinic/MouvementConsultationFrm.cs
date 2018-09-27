using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class MouvementConsultationFrm : Form
    {
        public MouvementConsultationFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        clsetablissementpriseencharge etablissement = new clsetablissementpriseencharge();

        private void FrmOrganisationDePriseEncharge_Load(object sender, EventArgs e)
        {
        }

        private void refresh()
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }

        private void dgvOrganisation_SelectionChanged(object sender, EventArgs e)
        {
        }
    }
}
