using System;
using System.Windows.Forms;
using GestionClinic_LIB;
//using GestionClinic_RPT;

namespace GestionClinic_WIN
{
    public partial class DictionnaireFrm : Form
    {
        public DictionnaireFrm()
        {
            InitializeComponent();
        }
        //SqlConnection connect;

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            //ReportLoad();
        }
        //private void ReportLoad()
//        {
//            try
//            {
//                FicheMalade rpt = new FicheMalade();
//                SqlCommand cmd = new SqlCommand(@"SELECT personne.nom, personne.postnom, personne.prenom, personne.sexe, aptitude.id_personne, personne.dateNaissance, 
//                categorieMalade.designation, profession.designation AS profession, preconsultation.poid, preconsultation.temperature, preconsultation.datePrecons, 
//                airSante.designation AS airsante, preconsultation.pressionArterielle, etablissementPriseEnCharge.denomination, aptitude.numero, 
//                etablissementPriseEnCharge.adresse FROM aptitude 
//                INNER JOIN personne ON aptitude.id_personne = personne.id 
//                INNER JOIN preconsultation ON aptitude.id = preconsultation.id_malade 
//                INNER JOIN categorieMalade ON aptitude.id_categorieMalade = categorieMalade.id 
//                INNER JOIN airSante ON aptitude.id_airSante = airSante.id 
//                INNER JOIN etablissementPriseEnCharge ON aptitude.id_etablissement = etablissementPriseEnCharge.id 
//                INNER JOIN profession ON aptitude.id_profession = profession.id where aptitude.id=@id", connect);

//                SqlDataAdapter sa = new SqlDataAdapter(cmd);

//                SqlParameter paramId = cmd.CreateParameter();
//                clsDoTraitement.GetInstance().createParamInt("", ((clsmalade)cboMalade.SelectedItem).Id, cmd);
//                cmd.ExecuteNonQuery();

//                DataSet ds = new DataSet();

//                sa.Fill(ds, "doc");
//                rpt.SetDataSource(ds.Tables["doc"]);
//                crvDictionnaire.ReportSource = rpt;
//                crvDictionnaire.Refresh();
//                sa.Dispose();
//                ds.Dispose();
//                cmd.Dispose();
//            }
//            catch (Exception exc)
//            {
//                MessageBox.Show(exc.Message, "Erreur de l'afichage du rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
//            }
//        }

        private void frmDctionnaire_Load(object sender, EventArgs e)
        {
            try
            {
                cboMalade.DataSource = clsMetier.GetInstance().getAllClsmalade();
            }
            catch (Exception) { }
        }
    }
}
