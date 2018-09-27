using System;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class FrmConfigurationRepertoire : Form
    {
        public FrmConfigurationRepertoire()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        private void cmdEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                clsDoTraitement.GetInstance().saveParamRepertoire(txtCheminAcces.Text);
                MessageBox.Show("Enregistrement effectu� avec succ�s", "Enregistrement chemin d'acc�s pour photos WebCam", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Enregistrement chemin d'acc�s pour photo WebCam", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
            }
        }

        private void FrmConfigurationRepertoire_Load(object sender, EventArgs e)
        {
            try
            {
                txtCheminAcces.Text = clsDoTraitement.GetInstance().loadParamRepertoire();
            }
            catch (Exception)
            {
                MessageBox.Show("Echec dce la r�cup�ration du repertoire de sauvegarde des photo captur�e par WebCam", "R�cup�ration repertoire photos WebCam", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdLoadDirectory_Click(object sender, EventArgs e)
        {
            dlgOpen.Title = "Veuillez s�lectionner un emplacement pour la sauvegarde des photos � capturer";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                string cheminFichier = dlgOpen.FileName;
                dlgOpen.SupportMultiDottedExtensions = true;
                try
                {
                    txtCheminAcces.Text = dlgOpen.FileName;
                }
                catch (Exception)
                {
                    MessageBox.Show("L'emplacement | " + cheminFichier + " | n'est pas valide", "S�lection chemin d'acc�s pour photos WebCam", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}