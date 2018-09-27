using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GestionClinic_LIB;
using GestionClinic_WIN.Reports;

namespace GestionClinic_WIN
{
    public partial class RptAptitudePhysiqueFrm : Form
    {
        public RptAptitudePhysiqueFrm()
        {
            InitializeComponent();
        }


        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        private void frmCertificatAptitudePhysique_Load(object sender, EventArgs e)
        {
            try
            {
                CertificatAptitudePhysique rpt = new CertificatAptitudePhysique();
                SqlCommand cmd = null;
                string str = @"SELECT province.designation AS province,districtville.designation AS district,territoirecommune.designation AS territoire,collectivitequartier.designation AS collectivite,isnull(personne.adresse,'-') AS adresse,isnull(personne.nom,'') + ' ' + isnull(personne.postnom,'') + ' ' + isnull(personne.prenom,'') AS nom,personne.sexe,personne.photo,aptitudephysique.age,aptitudephysique.id AS IdApt,('CSRC_' + CONVERT(varchar(50),aptitudephysique.id) + '_' + CONVERT(varchar(50),YEAR(aptitudephysique.dateexamen))) AS NumApt,ROUND(aptitudephysique.taille,2) AS taille,ROUND(aptitudephysique.poid,2) AS poid,
                ROUND(aptitudephysique.perimetrethoracique,2) AS perimetrethoracique,ROUND(aptitudephysique.quotientvervaeck,2) AS quotientvervaeck,ROUND(aptitudephysique.indicepigment,2) AS indicepigment,aptitudephysique.remarque,aptitudephysique.dateexamen FROM personne
                INNER JOIN aptitudephysique ON personne.id=aptitudephysique.id_personne 
                INNER JOIN province ON province.id=aptitudephysique.id_province
                INNER JOIN districtville ON districtville.id=aptitudephysique.id_districtville
                INNER JOIN territoirecommune ON territoirecommune.id=aptitudephysique.id_territoirecommune  
                INNER JOIN collectivitequartier ON collectivitequartier.id=aptitudephysique.id_collectivitequartier WHERE personne.id=" + clsDoTraitement.id_personne_certificat + " AND aptitudephysique.dateexamen='" + clsDoTraitement.dateCerticifat.ToString().Substring(0, 10) + "'";

                cmd = new SqlCommand(@"SELECT province.designation AS province,districtville.designation AS district,territoirecommune.designation AS territoire,collectivitequartier.designation AS collectivite,isnull(personne.adresse,'-') AS adresse,isnull(personne.nom,'') + ' ' + isnull(personne.postnom,'') + ' ' + isnull(personne.prenom,'') AS nom,personne.sexe,personne.photo,aptitudephysique.age,aptitudephysique.id AS IdApt,('CSRC_' + CONVERT(varchar(50),aptitudephysique.id) + '_' + CONVERT(varchar(50),YEAR(aptitudephysique.dateexamen))) AS NumApt,ROUND(aptitudephysique.taille,2) AS taille,ROUND(aptitudephysique.poid,2) AS poid,
                ROUND(aptitudephysique.perimetrethoracique,2) AS perimetrethoracique,ROUND(aptitudephysique.quotientvervaeck,2) AS quotientvervaeck,ROUND(aptitudephysique.indicepigment,2) AS indicepigment,aptitudephysique.remarque,aptitudephysique.dateexamen FROM personne
                INNER JOIN aptitudephysique ON personne.id=aptitudephysique.id_personne 
                INNER JOIN province ON province.id=aptitudephysique.id_province
                INNER JOIN districtville ON districtville.id=aptitudephysique.id_districtville
                INNER JOIN territoirecommune ON territoirecommune.id=aptitudephysique.id_territoirecommune  
                INNER JOIN collectivitequartier ON collectivitequartier.id=aptitudephysique.id_collectivitequartier WHERE personne.id=" + clsDoTraitement.id_personne_certificat + " AND aptitudephysique.dateexamen='" + clsDoTraitement.dateCerticifat.ToString().Substring(0, 10) + "'", clsMetier.GetInstance().InitializeReport());
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "doc");
                rpt.SetDataSource(ds.Tables["doc"]);
                crvAptitudePhysique.ReportSource = rpt;
                crvAptitudePhysique.Refresh();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ">> Erreur lors de l'ouverture du certificat d'aptitude physique, veuillez sélectionner une personne et réessayez svp", "Fiche d'aptitude physique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                clsMetier.GetInstance().InitializeReport().Close();
            }
        }
    }
}
