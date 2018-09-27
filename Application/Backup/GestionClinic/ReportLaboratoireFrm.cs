using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GestionClinic_LIB;
using GestionClinic_WIN.Reports;

namespace GestionClinic_WIN
{
    public partial class ReportLaboratoireFrm : Form
    {
        public ReportLaboratoireFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        SqlConnection con = null;

        public void connection()
        {
            if (con.State.ToString().Equals("Open")) { }
            else
            {
                con = new SqlConnection(clsMetier.strChaineConnection);
                con.Open();
            }
        }

        public void loadReport()
        {
            try
            {

                StatistiqueExamenLabo rpt = new StatistiqueExamenLabo();
                SqlCommand cmd = null;
                cmd = new SqlCommand(@"SELECT     TOP (100) PERCENT COUNT(dbo.mouvementoperation_laboratoire.id_operation_laboratoire) AS nb, dbo.examen.designation, 
                      dbo.critereresultat.designation AS critereResult, dbo.typeexamen.designation AS typeExamen, dbo.mouvementoperation_laboratoire.date
FROM         dbo.mouvementoperation_laboratoire INNER JOIN
                      dbo.operation_laboratoire ON dbo.operation_laboratoire.id = dbo.mouvementoperation_laboratoire.id_operation_laboratoire LEFT OUTER JOIN
                      dbo.examen ON dbo.examen.id = dbo.operation_laboratoire.id_examen LEFT OUTER JOIN
                      dbo.critereresultat ON dbo.mouvementoperation_laboratoire.id_critere = dbo.critereresultat.id LEFT OUTER JOIN
                      dbo.typeexamen ON dbo.examen.id_typeexamen = dbo.typeexamen.id
GROUP BY dbo.mouvementoperation_laboratoire.id_operation_laboratoire, dbo.examen.designation, dbo.critereresultat.designation, dbo.typeexamen.designation, 
                      dbo.mouvementoperation_laboratoire.date
ORDER BY dbo.examen.designation", clsMetier.GetInstance().InitializeReport());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "doc");
                rpt.SetDataSource(ds.Tables["doc"]);
                crvSatistiqueLaboratoire.ReportSource = rpt;
                crvSatistiqueLaboratoire.Refresh();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + ">> Erreur lors de l'ouverture du rapport", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void loadReport2()
        {
            try
            {
                string t = dtdateExmalade.Value.ToString(), g;
                g = t.Substring(0, 10);

                ExamenResultatPatient rpt = new ExamenResultatPatient();
                SqlCommand cmd = null;
                cmd = new SqlCommand(@"SELECT mouvementoperation_laboratoire.date as datePassationExamen, operation_laboratoire.date as dateOperation, examen.designation as designationExamen,  malade.numero, personne.nom, personne.postnom, personne.prenom, critereresultat.designation as designationCritere,mouvementoperation_laboratoire.resultat,groupesanguin.designation as designationgroupesanguin
                    from mouvementoperation_laboratoire inner join operation_laboratoire on mouvementoperation_laboratoire.id_operation_laboratoire=operation_laboratoire.id
                    left outer join examen on operation_laboratoire.id_examen=examen.id
                    left outer join malade on operation_laboratoire.id_malade=malade.id
                    left outer join groupesanguin on malade.id_groupesanguin=groupesanguin.id
                    left outer join personne on malade.id_personne=personne.id
                    left outer join critereresultat on mouvementoperation_laboratoire.id_critere= critereresultat.id
                    where operation_laboratoire.id_malade='" + ((clsmalade)cboMalade.SelectedItem).Id + "' and convert(date,mouvementoperation_laboratoire.date,100) = '" + g + "' ", clsMetier.GetInstance().InitializeReport());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "doc");
                rpt.SetDataSource(ds.Tables["doc"]);
                crvSatistiqueLaboratoire.ReportSource = rpt;
                crvSatistiqueLaboratoire.Refresh();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + ">> Erreur lors de l'ouverture du rapport", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void loadreport3()
        {
            try
            {
                string s = dtDebut.Value.ToString(), k;
                string v = dtFin.Value.ToString(), l;
                k = s.Substring(0, 10);
                l = v.Substring(0, 10);
                StatistiqueExamenLabo rpt = new StatistiqueExamenLabo();
                SqlCommand cmd = null;
                cmd = new SqlCommand(@"SELECT     TOP (100) PERCENT COUNT(dbo.mouvementoperation_laboratoire.id_operation_laboratoire) AS nb, dbo.examen.designation, 
                      dbo.critereresultat.designation AS critereResult, dbo.typeexamen.designation AS typeExamen, dbo.mouvementoperation_laboratoire.date
FROM         dbo.mouvementoperation_laboratoire INNER JOIN
                      dbo.operation_laboratoire ON dbo.operation_laboratoire.id = dbo.mouvementoperation_laboratoire.id_operation_laboratoire LEFT OUTER JOIN
                      dbo.examen ON dbo.examen.id = dbo.operation_laboratoire.id_examen LEFT OUTER JOIN
                      dbo.critereresultat ON dbo.mouvementoperation_laboratoire.id_critere = dbo.critereresultat.id LEFT OUTER JOIN
                      dbo.typeexamen ON dbo.examen.id_typeexamen = dbo.typeexamen.id
where convert(date,mouvementoperation_laboratoire.date,100) between '" + k + "' and '" + l + "' GROUP BY dbo.mouvementoperation_laboratoire.id_operation_laboratoire, dbo.examen.designation, dbo.critereresultat.designation, dbo.typeexamen.designation, dbo.mouvementoperation_laboratoire.date ORDER BY dbo.examen.designation", clsMetier.GetInstance().InitializeReport());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "doc");
                rpt.SetDataSource(ds.Tables["doc"]);
                crvSatistiqueLaboratoire.ReportSource = rpt;
                crvSatistiqueLaboratoire.Refresh();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + ">> Erreur lors de l'ouverture du rapport", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void loadreport4()
        {
            try
            {
                string s = dtDebut.Text;
                string v = dtFin.Text;
                s.Substring(0, 10);
                v.Substring(0, 10);
                StatistiqueExamenLabo rpt = new StatistiqueExamenLabo();
                SqlCommand cmd = null;
                cmd = new SqlCommand(@"SELECT     TOP (100) PERCENT COUNT(dbo.operation_laboratoire.id_examen) AS nb, dbo.examen.designation, dbo.critereresultat.designation AS critereResult, 
                      dbo.typeexamen.designation AS typeExamen, dbo.mouvementoperation_laboratoire.date
FROM         dbo.mouvementoperation_laboratoire INNER JOIN
                      dbo.operation_laboratoire ON dbo.operation_laboratoire.id = dbo.mouvementoperation_laboratoire.id_operation_laboratoire LEFT OUTER JOIN
                      examen on examen.id=operation_laboratoire.id_examen left outer join
                      dbo.critereresultat ON dbo.mouvementoperation_laboratoire.id_critere = dbo.critereresultat.id LEFT OUTER JOIN
                      dbo.typeexamen ON dbo.examen.id_typeexamen = dbo.typeexamen.id
where convert(date,mouvementoperation_laboratoire.date,100) between '" + s + "' and '" + v + "' GROUP BY dbo.mouvementoperation_laboratoire.id_operation_laboratoire, dbo.examen.designation, dbo.critereresultat.designation, dbo.typeexamen.designation,dbo.mouvementoperation_laboratoire.date ORDER BY dbo.examen.designation", clsMetier.GetInstance().InitializeReport());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "doc");
                rpt.SetDataSource(ds.Tables["doc"]);
                crvSatistiqueLaboratoire.ReportSource = rpt;
                crvSatistiqueLaboratoire.Refresh();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + ">> Erreur lors de l'ouverture du rapport", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void loadreport5()
        {
            try
            {
                string s = dtDateMax.Value.ToString(), l;
                string f = dtdateMin.Value.ToString(), j;
                l = s.Substring(0, 10);
                j = f.Substring(0, 10);
                int x = ((clsexamen)cboExamen.SelectedItem).Id;
                StatistiqueExamenCritereDate rpt = new StatistiqueExamenCritereDate();
                SqlCommand cmd = null;
                cmd = new SqlCommand(@"SELECT     TOP (100) PERCENT COUNT(dbo.operation_laboratoire.id_examen) AS nb, dbo.examen.designation, dbo.critereresultat.designation AS critereResult, 
                      dbo.typeexamen.designation AS typeExamen, dbo.mouvementoperation_laboratoire.date
FROM         dbo.mouvementoperation_laboratoire INNER JOIN
                      dbo.operation_laboratoire ON dbo.operation_laboratoire.id = dbo.mouvementoperation_laboratoire.id_operation_laboratoire LEFT OUTER JOIN
                      examen on examen.id=operation_laboratoire.id_examen left outer join
                      dbo.critereresultat ON dbo.mouvementoperation_laboratoire.id_critere = dbo.critereresultat.id LEFT OUTER JOIN
                      dbo.typeexamen ON dbo.examen.id_typeexamen = dbo.typeexamen.id
where convert(date,mouvementoperation_laboratoire.date,100) between '" + j + "' and '" + l + "' and examen.id='" + x + "' GROUP BY dbo.mouvementoperation_laboratoire.id_operation_laboratoire, dbo.examen.designation, dbo.critereresultat.designation, dbo.typeexamen.designation, dbo.mouvementoperation_laboratoire.date ORDER BY dbo.examen.designation", clsMetier.GetInstance().InitializeReport());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "doc");
                rpt.SetDataSource(ds.Tables["doc"]);
                crvSatistiqueLaboratoire.ReportSource = rpt;
                crvSatistiqueLaboratoire.Refresh();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + ">> Erreur lors de l'ouverture du rapport", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmReportLaboratoire_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ComboBox[] cbo = { cboExamen, cboMalade };
                clsDoTraitement.GetInstance().unloadData(cbo);
            }
            catch (Exception) { }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            loadReport();
        }

        private void FrmReportLaboratoire_Load(object sender, EventArgs e)
        {
            try
            {
                //Chargement des combobox
                cboMalade.DataSource = clsMetier.GetInstance().getAllClsmalade();
                cboExamen.DataSource = clsMetier.GetInstance().getAllClsexamen();

                cboExamen.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboExamen.AutoCompleteSource = AutoCompleteSource.ListItems;

                cboMalade.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboMalade.AutoCompleteSource = AutoCompleteSource.ListItems;

            }
            catch (Exception) { } 
        }

        private void btnAfficherExm_Click(object sender, EventArgs e)
        {
            loadReport2();
        }

        private void btnAffichersP_Click(object sender, EventArgs e)
        {
            loadreport3();
        }

        private void btnAffic_Click(object sender, EventArgs e)
        {
            loadreport5();
        }
    }
}
