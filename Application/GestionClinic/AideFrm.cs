using System;
using System.IO;
using System.Windows.Forms;
using GestionClinic_LIB;

namespace GestionClinic_WIN
{
    public partial class AideFrm : Form
    {
        public AideFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        private void FrmAide_Load(object sender, EventArgs e)
        {
            //assembly = Assembly.GetExecutingAssembly();
            try
            {
                //string appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                //webBrowser.Url = new Uri(Path.Combine(appDir, @"Documentation\Aide.htm"));
                //rtfText.LoadFile(Path.GetFullPath(@"Documentation\Aide.rtf"), RichTextBoxStreamType.RichText);
                rtfText.LoadFile(@"\\" + clsDoTraitement.GetInstance().loadParamFileAide() + @"\Deployment\Aide.rtf", RichTextBoxStreamType.RichText);

                //rtfText.LoadFile(assembly.CodeBase);
                //rtfText.LoadFile(global::GestionClinic_WIN.Properties.Resources.Aide, RichTextBoxStreamType.RichText);
                //rtfText.LoadFile(assembly.GetManifestResourceStream("GestionClinic_WIN.Aide.rtf"), RichTextBoxStreamType.RichText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement du fichier d'aide, " + ex.Message, "Manuel de l'utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
