using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GestionClinic_LIB;
using GestionClinic_WIN.Reports;

namespace GestionClinic_WIN
{
    public partial class frmFacture : Form
    {
        SqlConnection conn = null;
        private List<int> numerofacture = new List<int>();
        bool isOnlyMedicament = false, isOnlyLabo = false;

        public frmFacture()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        private void loadReport()
        {
            try
            {
                if (chkFactureDetaille.Checked)
                {
                    if (rdMalade.Checked & rdNonSolde.Checked)
                    {
                        int id_malade = ((clsfacturation)cboMalade.SelectedItem).Id_malade;

                        //On commence par mettre à jour la table temporaire
                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        SqlCommand cmdTemp = conn.CreateCommand();                       
                        string req = @"UPDATE tempAvance SET montant=(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @" AND malade_avance.solde=0),id_malade=" + id_malade;
                        cmdTemp.CommandText = req;
                        int t = cmdTemp.ExecuteNonQuery();
                        conn.Close();

                        //Facture non encore soldées
                        #region Traitement Malade pour factures non encores soldées
                        string s, requete1 = "", requete2 = "", requete3 = "", requete4 = "";
                        int query = 0;
                        bool ok3 = false, ok2 = false;
                        numerofacture.Clear();
                        
                        s = cboDate.Text.Substring(0, 10);

                        requete2 = @"SELECT facturation.designation_service,facturation.id AS idFacturation,tempAvance.montant AS avance2,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu,ROUND(facturation.dette,2) AS dette,
facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS medicament,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS labo,(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=0) AS avance,(ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) - (SELECT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY facturation.montantmituelle)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=0)) AS TotGen,(SELECT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1  GROUP BY facturation.montantmituelle) AS mituelle
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 AND facturation.solde=0 AND facturation.ispaiementmalade=1 ORDER BY facturation.designation ASC";

                        requete3 = @"SELECT facturation.designation_service,facturation.designation,tempAvance.montant AS avance2,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet, facturation.date, facturation.pu,ROUND(facturation.dette,2) AS dette,
facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS medicament,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS labo,(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=0) AS avance,(ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) - ISNULL((SELECT DISTINCT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY facturation.montantmituelle),0)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=0)) AS TotGen,(SELECT DISTINCT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1) AS mituelle
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY facturation.designation_service,facturation.id,facturation.montantmituelle,facturation.designation,facturation.date,facturation.pu,
facturation.avance,facturation.id_malade,facturation.numero_facture,facturation.dette,facturation.quantite,personne.nom,personne.postnom,personne.prenom,personne.sexe,categoriemalade.taux,malade.numero,categoriemalade.designation,etablissementpriseencharge.denomination,tempAvance.id_malade,tempAvance.montant ORDER BY facturation.designation ASC";

                        requete4 = @"SELECT facturation.designation_service,facturation.designation,facturation.id AS idFacturation,tempAvance.montant AS avance2,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet, facturation.date, facturation.pu,ROUND(facturation.dette,2) AS dette,
facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS medicament,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS labo,(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=0) AS avance,(ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) - ISNULL((SELECT SUM(ROUND(facturation.montantmituelle,2))
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1),0)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=0)) AS TotGen,(SELECT SUM(ROUND(facturation.montantmituelle,2))
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1) AS mituelle
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY facturation.designation_service,facturation.id,facturation.montantmituelle,facturation.designation,facturation.date,facturation.pu,
facturation.avance,facturation.id_malade,facturation.numero_facture,facturation.dette,facturation.quantite,personne.nom,personne.postnom,personne.prenom,personne.sexe,categoriemalade.taux,malade.numero,categoriemalade.designation,etablissementpriseencharge.denomination,tempAvance.id_malade,tempAvance.montant ORDER BY facturation.designation ASC";

                        requete1 = @"SELECT DISTINCT facturation.designation_service,facturation.designation AS designation,tempAvance.montant AS avance2,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,personne.sexe,malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, 
                        facturation.pu,facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,facturation.id_malade,facturation.numero_facture,(SELECT SUM(facturation.montantmituelle)
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                    where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1
                         GROUP BY categoriemalade.taux) AS mituelle,((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                    where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1
                         GROUP BY categoriemalade.taux)-(SELECT SUM(facturation.montantmituelle)
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                    where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1
                         GROUP BY categoriemalade.taux)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=0)) AS TotGen
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                                                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                        INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
                        where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)  ='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1";//ORDER BY facturation.designation ASC

                        //Cette requete permet de choisir s'il faut requete3 ou requete4 au cas ou il s'agit d'un abonnéet suivant le cas ou
                        //C'est requete3 qui devrait être appele
                        bool getQuery = false;
                        SqlCommand cmdReq = null;
                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        cmdReq = conn.CreateCommand();
                        cmdReq.CommandText = @"SELECT COUNT(DISTINCT ROUND(facturation.montantmituelle,2)) AS nbrRec
                        FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                        where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1";
                        
                        SqlDataReader rdReq = cmdReq.ExecuteReader();

                        if (rdReq.Read())
                        {
                            if (Convert.ToInt32(rdReq["nbrRec"].ToString()) > 1) getQuery = true;
                            else getQuery = false;
                        }
                        rdReq.Dispose();
                        cmdReq.Dispose();

                        //On execute les requetes de test pour avoir la bonne requete pour le report
                        //Pour medicaments et autres article (Tous)
                        SqlCommand cmd3 = null;
                        cmd3 = conn.CreateCommand();
                        if (!getQuery) cmd3.CommandText = requete3;
                        else cmd3.CommandText = requete4;

                        SqlDataReader rd3 = cmd3.ExecuteReader();
                        while (rd3.Read())
                        {
                            query = 3;
                            numerofacture.Add(Convert.ToInt32(rd3["numero_facture"].ToString()));
                        }
                        if (numerofacture.Count == 0) ok3 = true;
                        rd3.Dispose();
                        cmd3.Dispose();

                        //Pour les autres type d'article seulement
                        if (ok3)
                        {
                            SqlCommand cmd2 = null;
                            cmd2 = conn.CreateCommand();
                            cmd2.CommandText = requete2;
                            SqlDataReader rd2 = cmd2.ExecuteReader();
                            while (rd2.Read())
                            {
                                query = 2;
                                numerofacture.Add(Convert.ToInt32(rd2["numero_facture"].ToString()));
                            }
                            if (numerofacture.Count == 0) ok2 = true;
                            rd2.Dispose();
                            cmd2.Dispose();
                        }

                        //Pour medicaments seulement
                        if (ok2)
                        {
                            SqlCommand cmd1 = null;
                            cmd1 = conn.CreateCommand();
                            cmd1.CommandText = requete1;
                            SqlDataReader rd1 = cmd1.ExecuteReader();
                            while (rd1.Read())
                            {
                                query = 1;
                                numerofacture.Add(Convert.ToInt32(rd1["numero_facture"].ToString()));
                            }
                            rd1.Dispose();
                            cmd1.Dispose();
                        }

                        #region On execute la query pour savoir s'il s'agit d'un article de Labo seulement ou non (Sinon solde)
                        SqlCommand cmdLabo = null, cmdLabo1 = null;
                        bool rec = false;
                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        cmdLabo = conn.CreateCommand();
                        //On compte le nombre des record correspondant aux labo pour le malade choisi à la date choisi pour la comparer au total des records 
                        //en vu de savoir si la facture ne concerne que le labo on non
                        //Si ça concerne uniquement le labo, on appelle FactureClient3
                        cmdLabo.CommandText = "SELECT COUNT(id)AS nbrRecord FROM facturation WHERE facturation.isexamen=1 AND facturation.id_malade=" + id_malade + @" AND facturation.date='" + s + @"' AND facturation.solde=0";
                        SqlDataReader rdLabo = cmdLabo.ExecuteReader();
                        int record = -1;
                        if (rdLabo.Read())
                        {
                            record = Convert.ToInt32(rdLabo["nbrRecord"]);
                            rec = true;
                        }
                        else isOnlyLabo = false;
                        rdLabo.Dispose();
                        cmdLabo.Dispose();

                        if (rec)
                        {
                            cmdLabo1 = conn.CreateCommand();
                            cmdLabo1.CommandText = "SELECT COUNT(id) AS nbrRecord FROM facturation WHERE facturation.id_malade=" + id_malade + @" AND facturation.date='" + s + @"' AND facturation.solde=0";
                            SqlDataReader rdLabo1 = cmdLabo1.ExecuteReader();
                            if (rdLabo1.Read())
                            {
                                if (record == Convert.ToInt32(rdLabo1["nbrRecord"])) isOnlyLabo = true;
                                else isOnlyLabo = false;
                            }
                            rdLabo1.Dispose();
                            cmdLabo1.Dispose();
                        }
                        #endregion

                        //FactureClient1 rpt = new FactureClient1();
                        SqlCommand cmd = null;
                        if (query == 3)
                        {
                            if (!getQuery) cmd = new SqlCommand(requete3, clsMetier.GetInstance().InitializeReport());//Tous les articles
                            else cmd = new SqlCommand(requete4, clsMetier.GetInstance().InitializeReport());//Tous les articles
                            cmdSoldeFacture.Enabled = true;
                            isOnlyMedicament = false;
                        }
                        else if (query == 2)
                        {
                            cmd = new SqlCommand(requete2, clsMetier.GetInstance().InitializeReport());//Autres articles seulement
                            cmdSoldeFacture.Enabled = true;
                            isOnlyMedicament = false;
                        }
                        else if (query == 1)
                        {
                            cmd = new SqlCommand(requete1, clsMetier.GetInstance().InitializeReport());//Médicaments seulement
                            cmdSoldeFacture.Enabled = true;
                            isOnlyMedicament = true;
                        }
                        else
                        {
                            MessageBox.Show("Il n'ya aucune information à afficher", "Facture du client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //cmd = new SqlCommand(requete3, clsMetier.GetInstance().InitializeReport());//Tous les articles par defaut
                            cmdSoldeFacture.Enabled = false;
                        }
                        if ((query == 1 || query == 2 || query == 3) && isOnlyLabo == true)
                        {
                            FactureClient4 rpt = new FactureClient4();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }
                        else if ((query == 1 || query == 2 || query == 3) && isOnlyMedicament == false)
                        {
                            FactureClient1 rpt = new FactureClient1();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }
                        else if (query == 1 && isOnlyMedicament == true)
                        {
                            FactureClient1 rpt = new FactureClient1();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }

                        //Réinitialisation des valeurs pour medicament et labo
                        isOnlyLabo = false;
                        isOnlyMedicament = false;
                        #endregion
                    }
                    else if (rdMituelle.Checked & rdNonSolde.Checked)
                    {
                        //Facture mituelle non encore soldées
                        #region Traitement Mutuelle pour factures non encores soldées
                        string s, requete = "", denominationEntreprise = "", date1, date2;
                        bool okFacture = false;
                        int id_malade = ((clsfacturation)cboMalade.SelectedItem).Id_malade;
                        s = cboDateMituelle.Text.Substring(0, 10);
                        date1 = txtDateDebut.Text.Substring(0, 10);
                        date2 = txtDateFin.Text.Substring(0, 10);
                        denominationEntreprise = cboEntreprise.Text;
                        numerofacture.Clear();
                        FactureMituelle rpt = new FactureMituelle();
                        if (chkMensuel.Checked)
                        {
                            //Echeance
                            requete = @"SELECT ROUND(etablissementpriseencharge.taux,2) AS taux,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu,facturation.quantite,facturation.montantmituelle,personne.sexe, 
                                   malade.numero,etablissementpriseencharge.id AS idEtablissement,malade.id,facturation.numero_facture,etablissementpriseencharge.denomination, (SELECT ROUND(SUM(facturation.montantmituelle),2)
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE facturation.date BETWEEN '" + date1 + @"' AND '" + date2 + @"' and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND etablissementpriseencharge.denomination='" + denominationEntreprise + @"' AND facturation.soldemituelle=0) AS mituelle
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                                                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement=etablissementpriseencharge.id
                                   WHERE facturation.date BETWEEN '" + date1 + @"' AND '" + date2 + @"' and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND facturation.soldemituelle=0 AND etablissementpriseencharge.denomination='" + denominationEntreprise + "' ORDER BY facturation.designation ASC";
                        }
                        else
                        {
                            //Mensuelle
                            requete = @"SELECT ROUND(etablissementpriseencharge.taux,2) AS taux,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu,facturation.quantite,facturation.montantmituelle,personne.sexe, 
                                   malade.numero,etablissementpriseencharge.id AS idEtablissement,malade.id,facturation.numero_facture,etablissementpriseencharge.denomination, (SELECT ROUND(SUM(facturation.montantmituelle),2)
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE MONTH(facturation.date)=(SELECT DISTINCT MONTH(facturation.date) from facturation WHERE convert(date,facturation.date,100)='" + s + @"') and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND etablissementpriseencharge.denomination='" + denominationEntreprise + @"' AND facturation.soldemituelle=0) AS mituelle
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement=etablissementpriseencharge.id
                                   WHERE MONTH(facturation.date)=(SELECT DISTINCT MONTH(facturation.date) from facturation WHERE convert(date,facturation.date,100)='" + s + @"') and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND facturation.soldemituelle=0 AND etablissementpriseencharge.denomination='" + denominationEntreprise + "' ORDER BY facturation.designation ASC";
                        }

                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        SqlCommand cmd1 = conn.CreateCommand();
                        cmd1.CommandText = requete;
                        SqlDataReader rd3 = cmd1.ExecuteReader();
                        while (rd3.Read())
                        {
                            cmdSoldeFacture.Enabled = true; ;
                            numerofacture.Add(Convert.ToInt32(rd3["numero_facture"].ToString()));
                            okFacture = true;
                        }

                        if (okFacture)
                        {
                            SqlCommand cmd = null;
                            cmd = new SqlCommand(requete, clsMetier.GetInstance().InitializeReport());
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Il n'ya aucune information à afficher", "Facture de la mituelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmdSoldeFacture.Enabled = false;
                        }
                        #endregion
                    }
                    else if (rdMalade.Checked & rdSolde.Checked)
                    {
                        int id_malade = ((clsfacturation)cboMalade.SelectedItem).Id_malade;
                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        //On commence par mettre à jour la table temporaire
                        SqlCommand cmdTemp = conn.CreateCommand();
                        string req = @"UPDATE tempAvance SET montant=(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @" AND malade_avance.solde=1),id_malade=" + id_malade;
                        cmdTemp.CommandText = req;
                        int t = cmdTemp.ExecuteNonQuery();
                        conn.Close();

                        //Facture déjà soldées des clients 
                        #region Traitement Malade pour factures déjà soldées
                        string s, requete1 = "", requete2 = "", requete3 = "", requete4 = "";
                        int query = 0;
                        bool ok3 = false, ok2 = false;
                        numerofacture.Clear();
                        
                        s = cboDate.Text.Substring(0, 10);

                        requete2 = @"SELECT facturation.designation_service,facturation.id AS idFacturation,tempAvance.montant AS avance2,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu,ROUND(facturation.dette,2) AS dette,
facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
    where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS medicament,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
    where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS labo,(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @" AND malade_avance.solde=1) AS avance,(ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) - (SELECT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY facturation.montantmituelle)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=1)) AS TotGen,(SELECT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1  GROUP BY facturation.montantmituelle) AS mituelle
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
    INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 AND facturation.solde=1 AND facturation.ispaiementmalade=1 ORDER BY facturation.designation_service,facturation.designation ASC";

        requete3 = @"SELECT facturation.designation_service,facturation.designation,tempAvance.montant AS avance2,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet, facturation.date, facturation.pu,ROUND(facturation.dette,2) AS dette,
facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS medicament,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS labo,(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=1) AS avance,(ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) - ISNULL((SELECT DISTINCT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY facturation.montantmituelle),0)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=1)) AS TotGen,(SELECT DISTINCT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1) AS mituelle
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY facturation.designation_service,facturation.id,facturation.montantmituelle,facturation.designation,facturation.date,facturation.pu,
facturation.avance,facturation.id_malade,facturation.numero_facture,facturation.dette,facturation.quantite,personne.nom,personne.postnom,personne.prenom,personne.sexe,categoriemalade.taux,malade.numero,categoriemalade.designation,etablissementpriseencharge.denomination,tempAvance.id_malade,tempAvance.montant ORDER BY facturation.designation ASC";//and facturation.ismedicament=0 and facturation.isexamen=0

        requete4 = @"SELECT facturation.designation_service,facturation.designation,tempAvance.montant AS avance2,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet, facturation.date, facturation.pu,ROUND(facturation.dette,2) AS dette,
facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS medicament,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS labo,(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=1) AS avance,(ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) - ISNULL((SELECT SUM(ROUND(facturation.montantmituelle,2))
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1),0)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=1)) AS TotGen,(SELECT SUM(ROUND(facturation.montantmituelle,2))
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1) AS mituelle
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY facturation.designation_service,facturation.id,facturation.montantmituelle,facturation.designation,facturation.date,facturation.pu,
facturation.avance,facturation.id_malade,facturation.numero_facture,facturation.dette,facturation.quantite,personne.nom,personne.postnom,personne.prenom,personne.sexe,categoriemalade.taux,malade.numero,categoriemalade.designation,etablissementpriseencharge.denomination,tempAvance.id_malade,tempAvance.montant ORDER BY facturation.designation ASC";

        requete1 = @"SELECT DISTINCT facturation.designation_service,facturation.designation AS de,tempAvance.montant AS avance2,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,personne.sexe,malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, 
facturation.id_malade,facturation.numero_facture,(SELECT ROUND(SUM(facturation.montantmituelle),2)
       FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
        where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1) AS mituelle,(SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux) AS medicament,((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
       FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
        where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1
GROUP BY categoriemalade.taux)-(SELECT SUM(facturation.montantmituelle)
       FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
        where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1
GROUP BY categoriemalade.taux)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=1)) AS TotGen
       FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                        INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)  ='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1 ORDER BY facturation.designation ASC";

                        #region On execute la query pour savoir s'il s'agit d'un article de Labo seulement ou non (Si deja solde)
                        SqlCommand cmdLabo = null, cmdLabo1 = null;
                        bool rec = false;
                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        cmdLabo = conn.CreateCommand();
                        //On compte le nombre des record correspondant aux labo pour le malade choisi à la date choisi pour la comparer au total des records 
                        //en vu de savoir si la facture ne concerne que le labo on non
                        //Si ça concerne uniquement le labo, on appelle FactureClient3
                        cmdLabo.CommandText = "SELECT COUNT(id)AS nbrRecord FROM facturation WHERE facturation.isexamen=1 AND facturation.id_malade=" + id_malade + @" AND facturation.date='" + s + @"' AND facturation.solde=1";
                        SqlDataReader rdLabo = cmdLabo.ExecuteReader();
                        int record = -1;
                        if (rdLabo.Read())
                        {
                            record = Convert.ToInt32(rdLabo["nbrRecord"]);
                            rec = true;
                        }
                        else isOnlyLabo = false;
                        rdLabo.Dispose();
                        cmdLabo.Dispose();

                        if (rec)
                        {
                            cmdLabo1 = conn.CreateCommand();
                            cmdLabo1.CommandText = "SELECT COUNT(id) AS nbrRecord FROM facturation WHERE facturation.id_malade=" + id_malade + @" AND facturation.date='" + s + @"' AND facturation.solde=1";
                            SqlDataReader rdLabo1 = cmdLabo1.ExecuteReader();
                            if (rdLabo1.Read())
                            {
                                if (record == Convert.ToInt32(rdLabo1["nbrRecord"])) isOnlyLabo = true;
                                else isOnlyLabo = false;
                            }
                            rdLabo1.Dispose();
                            cmdLabo1.Dispose();
                        }
                        #endregion

                        #region Cette requete permet de choisir s'il faut requete3 ou requete4 au cas ou il s'agit d'un abonnéet suivant le cas ou c'est requete3 qui devrait être appele
                        bool getQuery = false;
                        SqlCommand cmdReq = null;
                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        cmdReq = conn.CreateCommand();
                        cmdReq.CommandText = @"SELECT COUNT(DISTINCT ROUND(facturation.montantmituelle,2)) AS nbrRec
                        FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                        where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1";

                        SqlDataReader rdReq = cmdReq.ExecuteReader();

                        if (rdReq.Read())
                        {
                            if (Convert.ToInt32(rdReq["nbrRec"].ToString()) > 1) getQuery = true;
                            else getQuery = false;
                        }
                        rdReq.Dispose();
                        cmdReq.Dispose();
                        #endregion

                        //On execute les requetes de test pour avoir la bonne requete pour le report
                        //Pour medicaments et autres article (Tous)
                        SqlCommand cmd3 = null;
                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        cmd3 = conn.CreateCommand();
                        if (!getQuery) cmd3.CommandText = requete3;
                        else cmd3.CommandText = requete4;
                        SqlDataReader rd3 = cmd3.ExecuteReader();
                        if (rd3.Read()) query = 3;
                        else ok3 = true;
                        rd3.Dispose();
                        cmd3.Dispose();

                        //Pour les autres type d'article seulement
                        if (ok3)
                        {
                            SqlCommand cmd2 = null;
                            cmd2 = conn.CreateCommand();
                            cmd2.CommandText = requete2;
                            SqlDataReader rd2 = cmd2.ExecuteReader();
                            if (rd2.Read()) query = 2;
                            else ok2 = true;
                            rd2.Dispose();
                            cmd2.Dispose();
                        }

                        //Pour medicaments seulement
                        if (ok2)
                        {
                            SqlCommand cmd1 = null;
                            cmd1 = conn.CreateCommand();
                            cmd1.CommandText = requete1;
                            SqlDataReader rd1 = cmd1.ExecuteReader();
                            if (rd1.Read()) query = 1;
                            rd1.Dispose();
                            cmd1.Dispose();
                        }

                        //FactureClient1 rpt = new FactureClient1();
                        SqlCommand cmd = null;
                        if (query == 3)
                        {
                            if(!getQuery) cmd = new SqlCommand(requete3, clsMetier.GetInstance().InitializeReport());//Tous les articles
                            else cmd = new SqlCommand(requete4, clsMetier.GetInstance().InitializeReport());//Tous les articles
                            cmdSoldeFacture.Enabled = true;
                            isOnlyMedicament = false;
                        }
                        else if (query == 2)
                        {
                            cmd = new SqlCommand(requete2, clsMetier.GetInstance().InitializeReport());//Autres articles seulement
                            cmdSoldeFacture.Enabled = true;
                            isOnlyMedicament = false;
                        }
                        else if (query == 1)
                        {
                            cmd = new SqlCommand(requete1, clsMetier.GetInstance().InitializeReport());//Médicaments seulement
                            cmdSoldeFacture.Enabled = true;
                            isOnlyMedicament = true;
                        }
                        else
                        {
                            MessageBox.Show("Il n'ya aucune information à afficher", "Facture déjà soldé pour le client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmdSoldeFacture.Enabled = false;
                        }
                        if ((query == 1 || query == 2 || query == 3) && isOnlyLabo == true)
                        {
                            FactureClient4 rpt = new FactureClient4();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }
                        else if ((query == 2 || query == 3) && isOnlyMedicament == false)
                        {
                            FactureClient1 rpt = new FactureClient1();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }
                        else if (query == 1 && isOnlyMedicament == true)
                        {
                            FactureClient1 rpt = new FactureClient1();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }
                        isOnlyLabo = false;
                        isOnlyMedicament = false;
                        #endregion
                    }
                    else if (rdMituelle.Checked & rdSolde.Checked)
                    {
                        //Facture déjà soldées des mituelles
                        #region Traitement Mutuelle pour factures déjà soldées
                        string s, requete = "", denominationEntreprise = "", date1, date2;
                        bool okFacture = false;
                        int id_malade = ((clsfacturation)cboMalade.SelectedItem).Id_malade;
                        s = cboDateMituelle.Text.Substring(0, 10);
                        date1 = txtDateDebut.Text.Substring(0, 10);
                        date2 = txtDateFin.Text.Substring(0, 10);
                        denominationEntreprise = cboEntreprise.Text;
                        numerofacture.Clear();
                        FactureMituelle rpt = new FactureMituelle();
                        if (chkMensuel.Checked)
                        {
                            //Echeance
                            requete = @"SELECT ROUND(etablissementpriseencharge.taux,2) AS taux,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu,facturation.quantite,facturation.montantmituelle,personne.sexe, 
                                   malade.numero,etablissementpriseencharge.id AS idEtablissement,malade.id,facturation.numero_facture,etablissementpriseencharge.denomination, (SELECT ROUND(SUM(facturation.montantmituelle),2)
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE facturation.date BETWEEN '" + date1 + @"' AND '" + date2 + @"' and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND etablissementpriseencharge.denomination='" + denominationEntreprise + @"' AND facturation.soldemituelle=1) AS mituelle
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                                                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement=etablissementpriseencharge.id
                                   WHERE facturation.date BETWEEN '" + date1 + @"' AND '" + date2 + @"' and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND facturation.soldemituelle=1 AND etablissementpriseencharge.denomination='" + denominationEntreprise + "' ORDER BY facturation.designation ASC";
                        }
                        else
                        {
                            //Mensuelle
                            requete = @"SELECT ROUND(etablissementpriseencharge.taux,2) AS taux,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu,facturation.quantite,facturation.montantmituelle,personne.sexe, 
                                   malade.numero,etablissementpriseencharge.id AS idEtablissement,malade.id,facturation.numero_facture,etablissementpriseencharge.denomination, (SELECT ROUND(SUM(facturation.montantmituelle),2)
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE MONTH(facturation.date)=(SELECT DISTINCT MONTH(facturation.date) from facturation WHERE convert(date,facturation.date,100)='" + s + @"') and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND etablissementpriseencharge.denomination='" + denominationEntreprise + @"' AND facturation.soldemituelle=1) AS mituelle
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement=etablissementpriseencharge.id
                                   WHERE MONTH(facturation.date)=(SELECT DISTINCT MONTH(facturation.date) from facturation WHERE convert(date,facturation.date,100)='" + s + @"') and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND facturation.soldemituelle=1 AND etablissementpriseencharge.denomination='" + denominationEntreprise + "' ORDER BY facturation.designation ASC";
                        }

                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        SqlCommand cmd1 = conn.CreateCommand();
                        cmd1.CommandText = requete;
                        SqlDataReader rd3 = cmd1.ExecuteReader();
                        while (rd3.Read())
                        {
                            cmdSoldeFacture.Enabled = true; ;
                            numerofacture.Add(Convert.ToInt32(rd3["numero_facture"].ToString()));
                            okFacture = true;
                        }

                        if (okFacture)
                        {
                            SqlCommand cmd = null;
                            cmd = new SqlCommand(requete, clsMetier.GetInstance().InitializeReport());
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Il n'ya aucune information à afficher", "Facture de la mituelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmdSoldeFacture.Enabled = false;
                        }
                        #endregion
                    }
                }
                else
                {
                    if (rdMalade.Checked & rdNonSolde.Checked)
                    {
                        int id_malade = ((clsfacturation)cboMalade.SelectedItem).Id_malade;
                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        //On commence par mettre à jour la table temporaire
                        SqlCommand cmdTemp = conn.CreateCommand();
                        string req = @"UPDATE tempAvance SET montant=(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @" AND malade_avance.solde=0),id_malade=" + id_malade;
                        cmdTemp.CommandText = req;
                        int t = cmdTemp.ExecuteNonQuery();
                        conn.Close();

                        //Facture non encore soldées
                        #region Traitement Malade pour factures non encores soldées
                        string s, requete1 = "", requete2 = "", requete3 = "",requete4 = "";
                        int query = 0;
                        bool ok3 = false, ok2 = false;
                        numerofacture.Clear();
                        
                        s = cboDate.Text.Substring(0, 10);

                        requete2 = @"SELECT facturation.designation_service,facturation.id AS idFacturation,tempAvance.montant AS avance2,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu,ROUND(facturation.dette,2) AS dette,
facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS medicament,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS labo,(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=0) AS avance,(ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) - (SELECT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY facturation.montantmituelle)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=0)) AS TotGen,(SELECT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1  GROUP BY facturation.montantmituelle) AS mituelle
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 AND facturation.solde=0 AND facturation.ispaiementmalade=1 ORDER BY facturation.designation ASC";

                requete3 = @"SELECT facturation.designation_service,facturation.designation,tempAvance.montant AS avance2,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet, facturation.date, facturation.pu,ROUND(facturation.dette,2) AS dette,
facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS medicament,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS labo,(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=0) AS avance,(ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) - ISNULL((SELECT DISTINCT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY facturation.montantmituelle),0)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=0)) AS TotGen,(SELECT DISTINCT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1) AS mituelle
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY facturation.designation_service,facturation.id,facturation.montantmituelle,facturation.designation,facturation.date,facturation.pu,
facturation.avance,facturation.id_malade,facturation.numero_facture,facturation.dette,facturation.quantite,personne.nom,personne.postnom,personne.prenom,personne.sexe,categoriemalade.taux,malade.numero,categoriemalade.designation,etablissementpriseencharge.denomination,tempAvance.id_malade,tempAvance.montant ORDER BY facturation.designation ASC";

                requete4 = @"SELECT facturation.designation_service,facturation.designation,tempAvance.montant AS avance2,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet, facturation.date, facturation.pu,ROUND(facturation.dette,2) AS dette,
facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS medicament,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS labo,(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=0) AS avance,(ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) - ISNULL((SELECT SUM(ROUND(facturation.montantmituelle,2))
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1),0)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=0)) AS TotGen,(SELECT SUM(ROUND(facturation.montantmituelle,2))
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1) AS mituelle
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY facturation.designation_service,facturation.id,facturation.montantmituelle,facturation.designation,facturation.date,facturation.pu,
facturation.avance,facturation.id_malade,facturation.numero_facture,facturation.dette,facturation.quantite,personne.nom,personne.postnom,personne.prenom,personne.sexe,categoriemalade.taux,malade.numero,categoriemalade.designation,etablissementpriseencharge.denomination,tempAvance.id_malade,tempAvance.montant ORDER BY facturation.designation ASC";

                        //
                requete1 = @"SELECT DISTINCT facturation.designation_service,facturation.designation AS de,tempAvance.montant AS avance2,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,personne.sexe,malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, 
facturation.id_malade,facturation.numero_facture,(SELECT ROUND(SUM(facturation.montantmituelle),2)
       FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
        where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1) AS mituelle,(SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux) AS medicament,((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
       FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
        where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1
GROUP BY categoriemalade.taux)-(SELECT ROUND(SUM(facturation.montantmituelle),2)
       FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
        where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=0 AND facturation.ispaiementmalade=1)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=0)) AS TotGen
       FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                        INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)  ='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1";

                        #region On execute la query pour savoir s'il s'agit d'un article de Labo seulement ou non (Si non solde)
                        SqlCommand cmdLabo = null, cmdLabo1 = null;
                        bool rec = false;
                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        cmdLabo = conn.CreateCommand();
                        //On compte le nombre des record correspondant aux labo pour le malade choisi à la date choisi pour la comparer au total des records 
                        //en vu de savoir si la facture ne concerne que le labo on non
                        //Si ça concerne uniquement le labo, on appelle FactureClient3
                        cmdLabo.CommandText = "SELECT COUNT(id)AS nbrRecord FROM facturation WHERE facturation.isexamen=1 AND facturation.id_malade=" + id_malade + @" AND facturation.date='" + s + @"' AND facturation.solde=0";
                        SqlDataReader rdLabo = cmdLabo.ExecuteReader();
                        int record = -1;
                        if (rdLabo.Read())
                        {
                            record = Convert.ToInt32(rdLabo["nbrRecord"]);
                            if(record >0) rec = true;
                        }
                        else isOnlyLabo = false;
                        rdLabo.Dispose();
                        cmdLabo.Dispose();

                        if (rec)
                        {
                            cmdLabo1 = conn.CreateCommand();
                            cmdLabo1.CommandText = "SELECT COUNT(id) AS nbrRecord FROM facturation WHERE facturation.id_malade=" + id_malade + @" AND facturation.date='" + s + @"' AND facturation.solde=0";
                            SqlDataReader rdLabo1 = cmdLabo1.ExecuteReader();
                            if (rdLabo1.Read())
                            {
                                if (record == Convert.ToInt32(rdLabo1["nbrRecord"])) isOnlyLabo = true;
                                else isOnlyLabo = false;
                            }
                            rdLabo1.Dispose();
                            cmdLabo1.Dispose();
                        }
                        #endregion

                        #region Cette requete permet de choisir s'il faut requete3 ou requete4 au cas ou il s'agit d'un abonné et suivant le cas ou c'est requete3 qui devrait être appele
                        bool getQuery = false;
                        SqlCommand cmdReq = null;
                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        cmdReq = conn.CreateCommand();
                        cmdReq.CommandText = @"SELECT COUNT(DISTINCT ROUND(facturation.montantmituelle,2)) AS nbrRec
                        FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                        where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1";

                        SqlDataReader rdReq = cmdReq.ExecuteReader();

                        if (rdReq.Read())
                        {
                            if (Convert.ToInt32(rdReq["nbrRec"].ToString()) > 1) getQuery = true;
                            else getQuery = false;
                        }
                        rdReq.Dispose();
                        cmdReq.Dispose();
                        #endregion

                        //On execute les requetes de test pour avoir la bonne requete pour le report
                        //Pour medicaments et autres article (Tous)
                        SqlCommand cmd3 = null;
                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        cmd3 = conn.CreateCommand();
                        if(!getQuery) cmd3.CommandText = requete3;
                        else cmd3.CommandText = requete4;
                        SqlDataReader rd3 = cmd3.ExecuteReader();
                        while (rd3.Read())
                        {
                            query = 3;
                            numerofacture.Add(Convert.ToInt32(rd3["numero_facture"].ToString()));
                        }
                        if (numerofacture.Count == 0) ok3 = true;
                        rd3.Dispose();
                        cmd3.Dispose();

                        //Pour les autres type d'article seulement
                        if (ok3)
                        {
                            SqlCommand cmd2 = null;
                            cmd2 = conn.CreateCommand();
                            cmd2.CommandText = requete2;
                            SqlDataReader rd2 = cmd2.ExecuteReader();
                            while (rd2.Read())
                            {
                                query = 2;
                                numerofacture.Add(Convert.ToInt32(rd2["numero_facture"].ToString()));
                            }
                            if (numerofacture.Count == 0) ok2 = true;
                            rd2.Dispose();
                            cmd2.Dispose();
                        }

                        //Pour medicaments seulement
                        if (ok2)
                        {
                            SqlCommand cmd1 = null;
                            cmd1 = conn.CreateCommand();
                            cmd1.CommandText = requete1;
                            SqlDataReader rd1 = cmd1.ExecuteReader();
                            while (rd1.Read())
                            {
                                query = 1;
                                numerofacture.Add(Convert.ToInt32(rd1["numero_facture"].ToString()));
                            }
                            rd1.Dispose();
                            cmd1.Dispose();
                        }

                        //FactureClient rpt = new FactureClient();
                        SqlCommand cmd = null;
                        if (query == 3)
                        {
                            if(!getQuery) cmd = new SqlCommand(requete3, clsMetier.GetInstance().InitializeReport());//Tous les articles
                            else cmd = new SqlCommand(requete4, clsMetier.GetInstance().InitializeReport());//Tous les articles
                            cmdSoldeFacture.Enabled = true;
                            isOnlyMedicament = false;
                        }
                        else if (query == 2)
                        {
                            cmd = new SqlCommand(requete2, clsMetier.GetInstance().InitializeReport());//Autres articles seulement
                            cmdSoldeFacture.Enabled = true;
                            isOnlyMedicament = false;
                        }
                        else if (query == 1)
                        {
                            cmd = new SqlCommand(requete1, clsMetier.GetInstance().InitializeReport());//Médicaments seulement
                            cmdSoldeFacture.Enabled = true;
                            isOnlyMedicament = true;
                        }
                        else
                        {
                            MessageBox.Show("Il n'ya aucune information à afficher", "Facture du client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //cmd = new SqlCommand(requete3, clsMetier.GetInstance().InitializeReport());//Tous les articles par defaut
                            cmdSoldeFacture.Enabled = false;
                        }
                        if ((query == 1 || query == 2 || query == 3) && isOnlyLabo == true)
                        {
                            //FactureClient3 rpt = new FactureClient3();
                            FactureClient_Labo rpt = new FactureClient_Labo();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }
                        else if ((query == 2 || query == 3) && isOnlyMedicament == false)
                        {
                            FactureClient rpt = new FactureClient();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }
                        else if (query == 1 && isOnlyMedicament == true)
                        {
                            //FactureClient2 rpt = new FactureClient2();
                            FactureClient_Mdct rpt = new FactureClient_Mdct();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }
                        #endregion
                    }
                    else if (rdMituelle.Checked & rdNonSolde.Checked)
                    {
                        //Facture mituelle non encore soldées
                        #region Traitement Mutuelle pour factures non encores soldées
                        string s, requete = "", denominationEntreprise = "", date1, date2;
                        bool okFacture = false;
                        int id_malade = ((clsfacturation)cboMalade.SelectedItem).Id_malade;
                        date1 = txtDateDebut.Text.Substring(0, 10);
                        date2 = txtDateFin.Text.Substring(0, 10);
                        denominationEntreprise = cboEntreprise.Text;
                        numerofacture.Clear();
                        FactureMituelle rpt = new FactureMituelle();
                        if (chkMensuel.Checked)
                        {
                            //Echeance
                            requete = @"SELECT ROUND(etablissementpriseencharge.taux,2) AS taux,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu,facturation.quantite,facturation.montantmituelle,personne.sexe, 
                                   malade.numero,etablissementpriseencharge.id AS idEtablissement,malade.id,facturation.numero_facture,etablissementpriseencharge.denomination, (SELECT ROUND(SUM(facturation.montantmituelle),2)
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE facturation.date BETWEEN '" + date1 + @"' AND '" + date2 + @"' and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND etablissementpriseencharge.denomination='" + denominationEntreprise + @"' AND facturation.soldemituelle=0) AS mituelle
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                                                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement=etablissementpriseencharge.id
                                   WHERE facturation.date BETWEEN '" + date1 + @"' AND '" + date2 + @"' and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND facturation.soldemituelle=0 AND etablissementpriseencharge.denomination='" + denominationEntreprise + "' ORDER BY facturation.designation ASC";
                        }
                        else
                        {
                            //Mensuelle
                            if (string.IsNullOrEmpty(cboDateMituelle.Text)) throw new Exception("Il n'ya aucune information à afficher");
                            else 
                            {
                                s = cboDateMituelle.Text.Substring(0, 10);

                            requete = @"SELECT ROUND(etablissementpriseencharge.taux,2) AS taux,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu,facturation.quantite,facturation.montantmituelle,personne.sexe, 
                                   malade.numero,etablissementpriseencharge.id AS idEtablissement,malade.id,facturation.numero_facture,etablissementpriseencharge.denomination, (SELECT ROUND(SUM(facturation.montantmituelle),2)
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE MONTH(facturation.date)=(SELECT DISTINCT MONTH(facturation.date) from facturation WHERE convert(date,facturation.date,100)='" + s + @"') and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND etablissementpriseencharge.denomination='" + denominationEntreprise + @"' AND facturation.soldemituelle=0) AS mituelle
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement=etablissementpriseencharge.id
                                   WHERE MONTH(facturation.date)=(SELECT DISTINCT MONTH(facturation.date) from facturation WHERE convert(date,facturation.date,100)='" + s + @"') and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND facturation.soldemituelle=0 AND etablissementpriseencharge.denomination='" + denominationEntreprise + "' ORDER BY facturation.designation ASC";
                                }
                        }

                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        SqlCommand cmd1 = conn.CreateCommand();
                        cmd1.CommandText = requete;
                        SqlDataReader rd3 = cmd1.ExecuteReader();
                        while (rd3.Read())
                        {
                            cmdSoldeFacture.Enabled = true; 
                            numerofacture.Add(Convert.ToInt32(rd3["numero_facture"].ToString()));
                            okFacture = true;
                        }

                        if (okFacture)
                        {
                            SqlCommand cmd = null;
                            cmd = new SqlCommand(requete, clsMetier.GetInstance().InitializeReport());
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Il n'ya aucune information à afficher", "Facture de la mituelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmdSoldeFacture.Enabled = false;
                        }
                        #endregion
                    }
                    else if (rdMalade.Checked & rdSolde.Checked)
                    {
                        int id_malade = ((clsfacturation)cboMalade.SelectedItem).Id_malade;
                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        //On commence par mettre à jour la table temporaire
                        SqlCommand cmdTemp = conn.CreateCommand();
                        string req = @"UPDATE tempAvance SET montant=(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @" AND malade_avance.solde=1),id_malade=" + id_malade;
                        cmdTemp.CommandText = req;
                        int t = cmdTemp.ExecuteNonQuery();
                        conn.Close();

                        //Facture déjà soldées des clients 
                        #region Traitement Malade pour factures déjà soldées
                        string s, requete1 = "", requete2 = "", requete3 = "", requete4 = "";
                        int query = 0;
                        bool ok3 = false, ok2 = false;
                        numerofacture.Clear();
                        
                        s = cboDate.Text.Substring(0, 10);

                        requete2 = @"SELECT facturation.designation_service,facturation.id AS idFacturation,tempAvance.montant AS avance2,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu,ROUND(facturation.dette,2) AS dette,
facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS medicament,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS labo,(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=1) AS avance,(ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) - (SELECT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY facturation.montantmituelle)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=1)) AS TotGen,(SELECT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1  GROUP BY facturation.montantmituelle) AS mituelle
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 AND facturation.solde=1 AND facturation.ispaiementmalade=1 ORDER BY facturation.designation ASC";//facturation.designation,

                        requete3 = @"SELECT facturation.designation_service,facturation.designation,tempAvance.montant AS avance2,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet, facturation.date, facturation.pu,ROUND(facturation.dette,2) AS dette,
facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS medicament,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS labo,(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=1) AS avance,(ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) - ISNULL((SELECT DISTINCT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY facturation.montantmituelle),0)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=1)) AS TotGen,(SELECT DISTINCT ROUND(facturation.montantmituelle,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1) AS mituelle
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY facturation.designation_service,facturation.id,facturation.montantmituelle,facturation.designation,facturation.date,facturation.pu,
facturation.avance,facturation.id_malade,facturation.numero_facture,facturation.dette,facturation.quantite,personne.nom,personne.postnom,personne.prenom,personne.sexe,categoriemalade.taux,malade.numero,categoriemalade.designation,etablissementpriseencharge.denomination,tempAvance.id_malade,tempAvance.montant ORDER BY facturation.designation ASC";

                requete4 = @"SELECT facturation.designation_service,facturation.designation,tempAvance.montant AS avance2,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet, facturation.date, facturation.pu,ROUND(facturation.dette,2) AS dette,
facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS medicament,ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) AS labo,(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=1) AS avance,(ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) + ISNULL((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.isexamen=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux),0) - ISNULL((SELECT SUM(ROUND(facturation.montantmituelle,2))
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1),0)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=1)) AS TotGen,(SELECT SUM(ROUND(facturation.montantmituelle,2))
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1) AS mituelle
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=0 and facturation.isexamen=0 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY facturation.designation_service,facturation.id,facturation.montantmituelle,facturation.designation,facturation.date,facturation.pu,
facturation.avance,facturation.id_malade,facturation.numero_facture,facturation.dette,facturation.quantite,personne.nom,personne.postnom,personne.prenom,personne.sexe,categoriemalade.taux,malade.numero,categoriemalade.designation,etablissementpriseencharge.denomination,tempAvance.id_malade,tempAvance.montant ORDER BY facturation.designation ASC";

                requete1 = @"SELECT DISTINCT facturation.designation_service,facturation.designation AS de,tempAvance.montant AS avance2,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,personne.sexe,malade.numero, categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, etablissementpriseencharge.denomination, 
facturation.id_malade,facturation.numero_facture,(SELECT ROUND(SUM(facturation.montantmituelle),2)
       FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
        where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1) AS mituelle,(SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1 GROUP BY categoriemalade.taux) AS medicament,((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
       FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
        where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1
GROUP BY categoriemalade.taux)-(SELECT ROUND(SUM(facturation.montantmituelle),2)
       FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
        where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' and facturation.ismedicament=1 AND facturation.solde=1 AND facturation.ispaiementmalade=1)-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE facturation.id_malade=" + id_malade + @"  AND malade_avance.solde=1)) AS TotGen
       FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                    INNER JOIN tempAvance ON malade.id=tempAvance.id_malade
where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)  ='" + s + @"' AND facturation.solde=1 AND facturation.ispaiementmalade=1 ORDER BY facturation.designation ASC";

                        #region On execute la query pour savoir s'il s'agit d'un article de Labo seulement ou non (Si deja solde)
                        SqlCommand cmdLabo = null, cmdLabo1 = null;
                        bool rec = false;
                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        cmdLabo = conn.CreateCommand();
                        //On compte le nombre des record correspondant aux labo pour le malade choisi à la date choisi pour la comparer au total des records 
                        //en vu de savoir si la facture ne concerne que le labo on non
                        //Si ça concerne uniquement le labo, on appelle FactureClient3
                        cmdLabo.CommandText = "SELECT COUNT(id)AS nbrRecord FROM facturation WHERE facturation.isexamen=1 AND facturation.id_malade=" + id_malade + @" AND facturation.date='" + s + @"' AND facturation.solde=1";
                        SqlDataReader rdLabo = cmdLabo.ExecuteReader();
                        int record = -1;
                        if (rdLabo.Read())
                        {
                            record = Convert.ToInt32(rdLabo["nbrRecord"]);
                            rec = true;
                        }
                        else isOnlyLabo = false;
                        rdLabo.Dispose();
                        cmdLabo.Dispose();

                        if (rec)
                        {
                            cmdLabo1 = conn.CreateCommand();
                            cmdLabo1.CommandText = "SELECT COUNT(id) AS nbrRecord FROM facturation WHERE facturation.id_malade=" + id_malade + @" AND facturation.date='" + s + @"' AND facturation.solde=1";
                            SqlDataReader rdLabo1 = cmdLabo1.ExecuteReader();
                            if (rdLabo1.Read())
                            {
                                if (record == Convert.ToInt32(rdLabo1["nbrRecord"])) isOnlyLabo = true;
                                else isOnlyLabo = false;
                            }
                            rdLabo1.Dispose();
                            cmdLabo1.Dispose();
                        }
                        #endregion

                        #region Cette requete permet de choisir s'il faut requete3 ou requete4 au cas ou il s'agit d'un abonnéet suivant le cas ou c'est requete3 qui devrait être appele
                        bool getQuery = false;
                        SqlCommand cmdReq = null;
                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        cmdReq = conn.CreateCommand();
                        cmdReq.CommandText = @"SELECT COUNT(DISTINCT ROUND(facturation.montantmituelle,2)) AS nbrRec
                        FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                        where facturation.id_malade=" + id_malade + @" and convert (date,facturation.date,100)='" + s + @"' AND facturation.solde=0 AND facturation.ispaiementmalade=1";

                        SqlDataReader rdReq = cmdReq.ExecuteReader();

                        if (rdReq.Read())
                        {
                            if (Convert.ToInt32(rdReq["nbrRec"].ToString()) > 1) getQuery = true;
                            else getQuery = false;
                        }
                        rdReq.Dispose();
                        cmdReq.Dispose();
                        #endregion

                        //On execute les requetes de test pour avoir la bonne requete pour le report
                        //Pour medicaments et autres article (Tous)
                        SqlCommand cmd3 = null;
                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        cmd3 = conn.CreateCommand();

                        if(!getQuery) cmd3.CommandText = requete3;
                        else cmd3.CommandText = requete4;
                        SqlDataReader rd3 = cmd3.ExecuteReader();
                        if (rd3.Read()) query = 3;
                        else ok3 = true;
                        rd3.Dispose();
                        cmd3.Dispose();

                        //Pour les autres type d'article seulement
                        if (ok3)
                        {
                            SqlCommand cmd2 = null;
                            cmd2 = conn.CreateCommand();
                            cmd2.CommandText = requete2;
                            SqlDataReader rd2 = cmd2.ExecuteReader();
                            if (rd2.Read()) query = 2;
                            else ok2 = true;
                            rd2.Dispose();
                            cmd2.Dispose();
                        }

                        //Pour medicaments seulement
                        if (ok2)
                        {
                            SqlCommand cmd1 = null;
                            cmd1 = conn.CreateCommand();
                            cmd1.CommandText = requete1;
                            SqlDataReader rd1 = cmd1.ExecuteReader();
                            if (rd1.Read()) query = 1;
                            rd1.Dispose();
                            cmd1.Dispose();
                        }

                        //FactureClient rpt = new FactureClient();
                        SqlCommand cmd = null;
                        if (query == 3)
                        {
                            if(!getQuery) cmd = new SqlCommand(requete3, clsMetier.GetInstance().InitializeReport());//Tous les articles
                            else cmd = new SqlCommand(requete4, clsMetier.GetInstance().InitializeReport());//Tous les articles
                            cmdSoldeFacture.Enabled = true;
                            isOnlyMedicament = false;
                        }
                        else if (query == 2)
                        {
                            cmd = new SqlCommand(requete2, clsMetier.GetInstance().InitializeReport());//Autres articles seulement
                            cmdSoldeFacture.Enabled = true;
                            isOnlyMedicament = false;
                        }
                        else if (query == 1)
                        {
                            cmd = new SqlCommand(requete1, clsMetier.GetInstance().InitializeReport());//Médicaments seulement
                            cmdSoldeFacture.Enabled = true;
                            isOnlyMedicament = true;
                        }
                        else
                        {
                            MessageBox.Show("Il n'ya aucune information à afficher", "Facture déjà soldé pour le client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmdSoldeFacture.Enabled = false;
                        }

                        if ((query == 1 || query == 2 || query == 3) && isOnlyLabo == true)
                        {
                            //FactureClient3 rpt = new FactureClient3();
                            FactureClient_Labo rpt = new FactureClient_Labo();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }
                        else if ((query == 2 || query == 3) && isOnlyMedicament == false)
                        {
                            FactureClient rpt = new FactureClient();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }
                        else if (query == 1 && isOnlyMedicament == true)
                        {
                            //FactureClient2 rpt = new FactureClient2();
                            FactureClient_Mdct rpt = new FactureClient_Mdct();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }
                        #endregion
                    }
                    else if (rdMituelle.Checked & rdSolde.Checked)
                    {
                        //Facture déjà soldées des mituelles
                        #region Traitement Mutuelle pour factures déjà soldées
                        string s, requete = "", denominationEntreprise = "", date1, date2;
                        bool okFacture = false;
                        int id_malade = ((clsfacturation)cboMalade.SelectedItem).Id_malade;
                        s = cboDateMituelle.Text.Substring(0, 10);
                        date1 = txtDateDebut.Text.Substring(0, 10);
                        date2 = txtDateFin.Text.Substring(0, 10);
                        denominationEntreprise = cboEntreprise.Text;
                        numerofacture.Clear();
                        FactureMituelle rpt = new FactureMituelle();
                        if (chkMensuel.Checked)
                        {
                            //Echeance
                            requete = @"SELECT ROUND(etablissementpriseencharge.taux,2) AS taux,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu,facturation.quantite,facturation.montantmituelle,personne.sexe, 
                                   malade.numero,etablissementpriseencharge.id AS idEtablissement,malade.id,facturation.numero_facture,etablissementpriseencharge.denomination, (SELECT ROUND(SUM(facturation.montantmituelle),2)
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE facturation.date BETWEEN '" + date1 + @"' AND '" + date2 + @"' and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND etablissementpriseencharge.denomination='" + denominationEntreprise + @"' AND facturation.soldemituelle=1) AS mituelle
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                                                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement=etablissementpriseencharge.id
                                   WHERE facturation.date BETWEEN '" + date1 + @"' AND '" + date2 + @"' and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND facturation.soldemituelle=1 AND etablissementpriseencharge.denomination='" + denominationEntreprise + "' ORDER BY facturation.designation ASC";
                        }
                        else
                        {
                            //Mensuelle
                            requete = @"SELECT ROUND(etablissementpriseencharge.taux,2) AS taux,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu,facturation.quantite,facturation.montantmituelle,personne.sexe, 
                                   malade.numero,etablissementpriseencharge.id AS idEtablissement,malade.id,facturation.numero_facture,etablissementpriseencharge.denomination, (SELECT ROUND(SUM(facturation.montantmituelle),2)
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                                   WHERE MONTH(facturation.date)=(SELECT DISTINCT MONTH(facturation.date) from facturation WHERE convert(date,facturation.date,100)='" + s + @"') and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND etablissementpriseencharge.denomination='" + denominationEntreprise + @"' AND facturation.soldemituelle=1) AS mituelle
                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement=etablissementpriseencharge.id
                                   WHERE MONTH(facturation.date)=(SELECT DISTINCT MONTH(facturation.date) from facturation WHERE convert(date,facturation.date,100)='" + s + @"') and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND facturation.soldemituelle=1 AND etablissementpriseencharge.denomination='" + denominationEntreprise + "' ORDER BY facturation.designation ASC";
                        }

                        conn = new SqlConnection(clsMetier.strChaineConnection);
                        conn.Open();
                        SqlCommand cmd1 = conn.CreateCommand();
                        cmd1.CommandText = requete;
                        SqlDataReader rd3 = cmd1.ExecuteReader();
                        while (rd3.Read())
                        {
                            cmdSoldeFacture.Enabled = true; ;
                            numerofacture.Add(Convert.ToInt32(rd3["numero_facture"].ToString()));
                            okFacture = true;
                        }

                        if (okFacture)
                        {
                            SqlCommand cmd = null;
                            cmd = new SqlCommand(requete, clsMetier.GetInstance().InitializeReport());
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "doc");
                            rpt.SetDataSource(ds.Tables["doc"]);
                            crvFacture.ReportSource = rpt;
                            crvFacture.Refresh();
                            da.Dispose();
                            ds.Dispose();
                            cmd.Dispose();
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Il n'ya aucune information à afficher", "Facture de la mituelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmdSoldeFacture.Enabled = false;
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                if (rdMituelle.Checked) MessageBox.Show("Erreur lors de l'ouverture du rapport, rassurer-vous que vous avez sélectionné une entreprise et que la(les) date(s) est(sont) valide(s)", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else MessageBox.Show(ex.Message + ">> Erreur lors de l'ouverture du rapport, rassurer-vous que vous avez sélectionné une entreprise et que la(les) date(s) est(sont) valide(s)", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                clsMetier.GetInstance().InitializeReport().Close();
                //Réinitialisation des variables
                isOnlyMedicament = false;
                isOnlyLabo = false;
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            loadReport();
            isOnlyMedicament = false;
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        private void frmFacture_Load(object sender, EventArgs e)
        {
            rdMalade.Checked = true;
            cmdSoldeFacture.Enabled = false;
            chkMensuel.Checked = true;
            rdNonSolde.Checked = true;
            rdSolde.Checked = false;
            chkFactureDetaille.Checked = false;

            try
            {
                cboMalade.DataSource = clsMetier.GetInstance().getAllClsfacturationPersonne();
                setMembersallcbo(cboMalade, "NomComplet", "Id_malade");

                cboEntreprise.DataSource = clsMetier.GetInstance().getAllClsetablissementpriseenchargeMituelle();
                setMembersallcbo(cboEntreprise, "Denomination", "Id");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement des listes déroulantes, " + ex.Message, "Erreur de chargement");
            }
        }

        private void cboMalade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMalade.Items.Count > 0)
                    
                cboDate.DataSource = clsMetier.GetInstance().getAllClsfacturationPersonne(((clsfacturation)cboMalade.SelectedItem).Id_malade);
                setMembersallcbo(cboDate, "Date", "Id_malade");        
            }
            catch (Exception )
            {
                MessageBox.Show("Erreur de lors de la sélection d'un malade", "Sélection malade");
            }
        }

        private void rdMalade_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMalade.Checked)
            {
                pnMalade.Enabled = true;
                pnMituelle.Enabled = false;
            }
        }

        private void rdMituelle_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMituelle.Checked)
            {
                pnMalade.Enabled = false;
                pnMituelle.Enabled = true;
            }
        }

        private void chkMensuel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMensuel.Checked)
            {
                cboDateMituelle.Enabled = false;
                txtDateDebut.Enabled = true;
                txtDateFin.Enabled = true;
            }
            else
            {
                cboDateMituelle.Enabled = true;
                txtDateDebut.Enabled = false;
                txtDateFin.Enabled = false;
            }
        }

        private void cboNomEntreprise_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboEntreprise.Items.Count > 0)
                {
                    List<clsfacturation> lst = new List<clsfacturation>();
                    lst = clsMetier.GetInstance().getAllClsfacturationPersonne1(((clsetablissementpriseencharge)cboEntreprise.SelectedItem).Denomination);
                    cboDateMituelle.DataSource = lst;
                    setMembersallcbo(cboDateMituelle, "Date", "Id_etablissement");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur de lors de la sélection de l'entreprise", "Sélection entreprise");
            }
        }

        private void cmdSoldeFacture_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez vous vraiment solder cette facture pour l'archiver ?", "Solder facture", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes) 
            {
                try
                {
                    if (rdMalade.Checked)
                    {
                        //On commence par recupérer tous les numéros de facture correspondant au malade choisi pour la date choisie
                        numerofacture.Clear();
                        numerofacture = clsMetier.GetInstance().getAllClsfacturation2(((clsfacturation)cboMalade.SelectedItem).Id_malade, cboDate.Text);

                        for (int i = 0; i < numerofacture.Count;i++) clsMetier.GetInstance().updateClsfacturationSolde(numerofacture[i]);
                        numerofacture.Clear();
                    }
                    else if (rdMituelle.Checked)
                    {
                        //On commence par recupérer tous les numéros de facture correspondant à la mitulle choisi pour la date choisie
                        if (chkMensuel.Checked)
                        {
                            //Mensuelle avec date debut et date fin
                            numerofacture.Clear();
                            numerofacture = clsMetier.GetInstance().getAllClsfacturation3(cboEntreprise.Text, txtDateDebut.Text, txtDateFin.Text);
                        }
                        else
                        {
                            //Journalier pour une seule date
                            numerofacture.Clear();
                            numerofacture = clsMetier.GetInstance().getAllClsfacturation3(cboEntreprise.Text, cboDateMituelle.Text);
                        }
                        
                        for (int i = 0; i < numerofacture.Count; i++) clsMetier.GetInstance().updateClsfacturationmituelleSolde(numerofacture[i]);
                        numerofacture.Clear();
                    }
                    
                    MessageBox.Show("La facture a été soldé avec succès", "Solder facture", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Echec du soldage de la facture, " + ex.Message, "Solder facture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else MessageBox.Show("Aucune action n'a été éffectuée ?", "Solder facture", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rdSolde_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSolde.Checked) cmdSoldeFacture.Enabled = false;
        }

        private void frmFacture_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ComboBox[] cbo = { cboEntreprise, cboDate, cboDateMituelle, cboMalade };
                clsDoTraitement.GetInstance().unloadData(cbo);
            }
            catch (Exception) { }
        }
    }
}
