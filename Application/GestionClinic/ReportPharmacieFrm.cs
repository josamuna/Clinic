using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GestionClinic_LIB;
using GestionClinic_WIN.Reports;

namespace GestionClinic_WIN
{
    public partial class ReportPharmacieFrm : Form
    {
        public ReportPharmacieFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        SqlConnection con = null;

        private void openConnection()
        {
            if (con.State.ToString().Equals("Open")) { }
            else
            {
                con = new SqlConnection(clsMetier.strChaineConnection);
                con.Open();
            }
        }

        private void setMembersallcbo(ComboBox cbo, string displayMember, string valueMember)
        {
            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
        }

        public void loadReport()
        {
            try
            {

                ArticleEnstock rpt = new ArticleEnstock();
                SqlCommand cmd = null;
                cmd = new SqlCommand("select * from article WHERE article.fiche_supplementaire=0", clsMetier.GetInstance().InitializeReport());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "doc");
                rpt.SetDataSource(ds.Tables["doc"]);
                crvSatistiquePharmacie.ReportSource = rpt;
                crvSatistiquePharmacie.Refresh();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + ">> Erreur lors de l'ouverture du rapport", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void loadReportService()
        {
            try
            {
                ArticleEnstock rpt = new ArticleEnstock();
                SqlCommand cmd = null;
                cmd = new SqlCommand("select * from service", clsMetier.GetInstance().InitializeReport());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "doc");
                rpt.SetDataSource(ds.Tables["doc"]);
                crvSatistiquePharmacie.ReportSource = rpt;
                crvSatistiquePharmacie.Refresh();
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
                if (rdEntreeSorties.Checked)
                {
                    #region Fiche de stock avec sorties et entrées
                    FicheStock rpt = new FicheStock();
                    SqlCommand cmd = null;
                    bool ok_execute_query = false;

                    if (chkTous.Checked)
                    {
                        #region Tous
                        //Mise à jour dans la table tempStock
                        con = new SqlConnection(clsMetier.strChaineConnection);
                        con.Open();

                        SqlCommand cmdTemp = con.CreateCommand();
                        cmd = new SqlCommand(@"SELECT article.id,article.desination, livraison.date AS dateEntree,ISNULL(livraison.quantinte,0) AS qteEntree,ISNULL(livraison.puAchat,0) AS puAchat,ISNULL(livraison.puAchat*livraison.quantinte,0) AS prixTotalAchat,livraison.stock_out AS stock_out,sortie.date AS dtSortie, ISNULL(sortie.quantinte,0) AS qteSortie,ISNULL(article.pu,0) AS pu,ISNULL(sortie.quantinte*article.pu,0) AS prixTotalVente,sortie.stock_in AS stock_in FROM article  
                        RIGHT JOIN sortie ON article.id=sortie.id_article  
                        RIGHT JOIN livraison ON	article.id=livraison.id_article 
                        WHERE article.desination IS NOT NULL AND article.fiche_supplementaire=0 
                        ORDER BY article.desination ASC", clsMetier.GetInstance().InitializeReport());
                        ok_execute_query = true;
                        #endregion
                    }
                    else if (!chkTous.Checked && rdJournalier.Checked)
                    {
                        #region Journalier

                        //Mise à jour dans la table tempStock
                        string s = txtDate.Value.ToShortDateString().ToString().Substring(0, 10);

                        con = new SqlConnection(clsMetier.strChaineConnection);
                        con.Open();
                        string goodQuery = "";
                        bool okEntree = false;//Est vrai s'il ya au moins une entrée à une date X et faux dans le cas contraire
                        bool okSortie = false;//Est vrai s'il ya au moins une sorie à une date X et faux dans le cas contraire
                        //On commence par vérifier le nombre d'enregistrement pour sortie et des entrée pour une date X
                        //Si c'est >=1 alors on exécute le first bloc dans le cas contraire le second car n'a pas de correspond des deux côté (Entree et Sortie)

                        IDbCommand commande1 = con.CreateCommand();
                        commande1.CommandText = "SELECT COUNT(livraison.id) AS nbr_Rec FROM livraison WHERE livraison.date='" + s + "'";
                        IDataReader reader1 = commande1.ExecuteReader();
                        if (reader1.Read())
                        {
                            if (Convert.ToInt32(reader1["nbr_Rec"]) >= 1) okEntree = true;
                        }
                        reader1.Dispose();
                        commande1.Dispose();

                        IDbCommand commande2 = con.CreateCommand();
                        commande2.CommandText = "SELECT COUNT(sortie.id) AS nbr_Rec FROM sortie WHERE sortie.date='" + s + "'";
                        IDataReader reader2 = commande2.ExecuteReader();
                        if (reader2.Read())
                        {
                            if (Convert.ToInt32(reader2["nbr_Rec"]) >= 1) okSortie = true;
                        }
                        reader2.Dispose();
                        commande2.Dispose();

                        SqlCommand cmdTemp = con.CreateCommand();

                        //Selection de la requete principale à exécuter
                        if (okEntree == true && okSortie == true)
                        {
                            //On a au moins une entré et au moin une sortie pour une même date X

                            //Requete qui va générer le report
                            goodQuery = @"SELECT article.id,article.desination, livraison.date AS dateEntree,ISNULL(livraison.quantinte,0) AS qteEntree,ISNULL(livraison.puAchat,0) AS puAchat,ISNULL(livraison.puAchat*livraison.quantinte,0) AS prixTotalAchat,livraison.stock_out AS stock_out,sortie.date AS dtSortie, ISNULL(sortie.quantinte,0) AS qteSortie,ISNULL(article.pu,0) AS pu,ISNULL(sortie.quantinte*article.pu,0) AS prixTotalVente,sortie.stock_in AS stock_in FROM article  
                            RIGHT JOIN sortie ON article.id=sortie.id_article  
                            RIGHT JOIN livraison ON	article.id=livraison.id_article 
                            WHERE article.desination IS NOT NULL AND sortie.date='" + s + "' AND livraison.date='" + s + "' AND article.fiche_supplementaire=0 ORDER BY article.desination ASC";
                        }
                        else if (okEntree == false && okSortie == true)
                        {
                            //On a une entrée pour une date X et non une sortie pour la même date
                            //Requete qui va générer le report
                            goodQuery = @"SELECT article.id,article.desination, '-' AS dateEntree,'-' AS qteEntree,'-' AS puAchat,'-' AS prixTotalAchat,'-' AS stock_out,sortie.date AS dtSortie, ISNULL(sortie.quantinte,0) AS qteSortie,ISNULL(article.pu,0) AS pu,ISNULL(sortie.quantinte*article.pu,0) AS prixTotalVente,sortie.stock_in AS stock_in FROM article  
                            FULL JOIN sortie ON article.id=sortie.id_article  
                            RIGHT JOIN livraison ON	article.id=livraison.id_article 
                            WHERE article.desination IS NOT NULL AND sortie.date='" + s + "' AND article.fiche_supplementaire=0 ORDER BY article.desination ASC";
                        }
                        else if (okEntree == true && okSortie == false)
                        {
                            //On a une entrée pour une date X et non une sortie pour la même date

                            //Requete qui va générer le report
                            goodQuery = @"SELECT article.id,article.desination, livraison.date AS dateEntree,ISNULL(livraison.quantinte,0) AS qteEntree,ISNULL(livraison.puAchat,0) AS puAchat,ISNULL(livraison.puAchat*livraison.quantinte,0) AS prixTotalAchat,livraison.stock_out AS stock_out,'-' AS dtSortie, '-' AS qteSortie,'-' AS pu,'-' AS prixTotalVente,'-' AS stock_in FROM article  
                            INNER JOIN livraison ON	article.id=livraison.id_article
                            FULL JOIN sortie ON article.id=sortie.id_article   
                            WHERE article.desination IS NOT NULL AND livraison.date='" + s + "' AND article.fiche_supplementaire=0 ORDER BY article.desination ASC";
                        }

                        if (string.IsNullOrEmpty(goodQuery))
                        {
                            MessageBox.Show("Il n'ya rien à afficher", "Affichage de la fiche de stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            ok_execute_query = false;
                            con.Close();
                        }
                        else
                        {
                            cmdTemp.CommandText = goodQuery;
                            int v = cmdTemp.ExecuteNonQuery();
                            con.Close();

                            cmd = new SqlCommand(goodQuery, clsMetier.GetInstance().InitializeReport());
                            ok_execute_query = true;
                        }
                        #endregion
                    }
                    else if (!chkTous.Checked && rdMensuel.Checked)
                    {
                        #region Mensuel
                        //Mise à jour dans la table tempStock
                        string[] tb = cboMois.Text.Split('/');
                        int s = Convert.ToInt32(tb[0]);

                        con = new SqlConnection(clsMetier.strChaineConnection);
                        con.Open();

                        string goodQuery = "";
                        bool okEntree = false;//Est vrai s'il ya au moins une entrée à une date X et faux dans le cas contraire
                        bool okSortie = false;//Est vrai s'il ya au moins une sorie à une date X et faux dans le cas contraire
                        //On commence par vérifier le nombre d'enregistrement pour sortie et des entrée pour une date X
                        //Si c'est >=1 alors on exécute le first bloc dans le cas contraire le second car n'a pas de correspond des deux côté (Entree et Sortie)

                        IDbCommand commande1 = con.CreateCommand();
                        commande1.CommandText = "SELECT COUNT(livraison.id) AS nbr_Rec FROM livraison WHERE MONTH(livraison.date)=" + s;
                        IDataReader reader1 = commande1.ExecuteReader();
                        if (reader1.Read())
                        {
                            if (Convert.ToInt32(reader1["nbr_Rec"]) >= 1) okEntree = true;
                        }
                        reader1.Dispose();
                        commande1.Dispose();

                        IDbCommand commande2 = con.CreateCommand();
                        commande2.CommandText = "SELECT COUNT(sortie.id) AS nbr_Rec FROM sortie WHERE MONTH(sortie.date)=" + s;
                        IDataReader reader2 = commande2.ExecuteReader();
                        if (reader2.Read())
                        {
                            if (Convert.ToInt32(reader2["nbr_Rec"]) >= 1) okSortie = true;
                        }
                        reader2.Dispose();
                        commande2.Dispose();

                        SqlCommand cmdTemp = con.CreateCommand();

                        //Selection de la requete principale à exécuter
                        if (okEntree == true && okSortie == true)
                        {
                            //On a au moins une entré et au moin une sortie pour une même date X
                            //Requete qui va générer le report
                            goodQuery = @"SELECT article.id,article.desination, livraison.date AS dateEntree,ISNULL(livraison.quantinte,0) AS qteEntree,ISNULL(livraison.puAchat,0) AS puAchat,ISNULL(livraison.puAchat*livraison.quantinte,0) AS prixTotalAchat,livraison.stock_out AS stock_out,sortie.date AS dtSortie, ISNULL(sortie.quantinte,0) AS qteSortie,ISNULL(article.pu,0) AS pu,ISNULL(sortie.quantinte*article.pu,0) prixTotalVente,sortie.stock_in AS stock_in FROM article  
                            RIGHT JOIN sortie ON article.id=sortie.id_article  
                            RIGHT JOIN livraison ON	article.id=livraison.id_article 
                            WHERE article.desination IS NOT NULL AND MONTH(sortie.date)=" + s + " AND MONTH(livraison.date)=" + s + @" AND article.fiche_supplementaire=0 ORDER BY article.desination ASC";
                        }
                        else if (okEntree == true && okSortie == false)
                        {
                            //On a une entrée pour une date X et non une sortie pour la même date

                            //Requete qui va générer le report
                            goodQuery = @"SELECT article.id,article.desination, livraison.date AS dateEntree,ISNULL(livraison.quantinte,0) AS qteEntree,ISNULL(livraison.puAchat,0) AS puAchat,ISNULL(livraison.puAchat*livraison.quantinte,0) AS prixTotalAchat,livraison.stock_out AS stock_out,'-' AS dtSortie, '-' AS qteSortie,'-' AS pu,'-' AS prixTotalVente,'-' AS stock_in FROM article  
                            INNER JOIN livraison ON	article.id=livraison.id_article
                            FULL JOIN sortie ON article.id=sortie.id_article   
                            WHERE article.desination IS NOT NULL AND MONTH(livraison.date)=" + s + @" AND article.fiche_supplementaire=0 ORDER BY article.desination ASC";
                        }
                        else if (okEntree == false && okSortie == true)
                        {
                            //On a une sortie pour une date X et non une entree pour la même date

                            //Requete qui va générer le report
                            goodQuery = @"SELECT article.id,article.desination, '-' AS dateEntree,'-' AS qteEntree,'-' AS puAchat,'-' AS prixTotalAchat,'-' AS stock_out,sortie.date AS dtSortie, ISNULL(sortie.quantinte,0) AS qteSortie,ISNULL(article.pu,0) AS pu,ISNULL(sortie.quantinte*article.pu,0) AS prixTotalVente,sortie.stock_in AS stock_in FROM article  
                            FULL JOIN sortie ON article.id=sortie.id_article  
                            RIGHT JOIN livraison ON	article.id=livraison.id_article 
                            WHERE article.desination IS NOT NULL AND MONTH(sortie.date)=" + s + @" AND article.fiche_supplementaire=0 ORDER BY article.desination ASC";
                        }
                        if (string.IsNullOrEmpty(goodQuery))
                        {
                            MessageBox.Show("Il n'ya rien à afficher", "Affichage de la fiche de stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            ok_execute_query = false;
                            con.Close();
                        }
                        else
                        {
                            cmdTemp.CommandText = goodQuery;
                            int v = cmdTemp.ExecuteNonQuery();
                            con.Close();

                            cmd = new SqlCommand(goodQuery, clsMetier.GetInstance().InitializeReport());
                            ok_execute_query = true;
                        }
                        #endregion
                    }

                    if (ok_execute_query)
                    {
                        //Chargement report
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "doc");
                        rpt.SetDataSource(ds.Tables["doc"]);
                        crvSatistiquePharmacie.ReportSource = rpt;
                        crvSatistiquePharmacie.Refresh();
                        da.Dispose();
                        ds.Dispose();
                        cmd.Dispose();
                    }
                    #endregion
                }
                else if (rdEntreeSeul.Checked)
                {
                    #region Rapport pour entrées seulement
                    FicheStock_Entrees rpt = new FicheStock_Entrees();
                    SqlCommand cmd = null;
                    bool ok_execute_query = false;

                    if (chkTous.Checked)
                    {
                        #region Tous
                        //Mise à jour dans la table tempStock
                        con = new SqlConnection(clsMetier.strChaineConnection);
                        con.Open();
                        ok_execute_query = true;

                        cmd = new SqlCommand(@"SELECT article.id,article.desination, livraison.date AS dateEntree,ISNULL(livraison.quantinte,0) AS qteEntree,ISNULL(livraison.puAchat,0) AS puAchat,ISNULL(livraison.puAchat*livraison.quantinte,0) AS prixTotalAchat,livraison.stock_out AS stock_out FROM article  
                        INNER JOIN livraison ON article.id=livraison.id_article WHERE article.fiche_supplementaire=0
                        ORDER BY article.desination ASC", clsMetier.GetInstance().InitializeReport());
                        #endregion
                    }
                    else if (!chkTous.Checked && rdJournalier.Checked)
                    {
                        #region Journalier

                        //Mise à jour dans la table tempStock
                        string s = txtDate.Value.ToShortDateString().ToString().Substring(0, 10);

                        con = new SqlConnection(clsMetier.strChaineConnection);
                        con.Open();

                        //Requete qui va générer le report
                        cmd = new SqlCommand(@"SELECT article.id,article.desination, livraison.date AS dateEntree,ISNULL(livraison.quantinte,0) AS qteEntree,ISNULL(livraison.puAchat,0) AS puAchat,ISNULL(livraison.puAchat*livraison.quantinte,0) AS prixTotalAchat,livraison.stock_out AS stock_out FROM article  
                        INNER JOIN livraison ON article.id=livraison.id_article 
                        WHERE livraison.date='" + s + "' AND article.fiche_supplementaire=0 ORDER BY article.desination ASC", clsMetier.GetInstance().InitializeReport());
                        ok_execute_query = true;
                        #endregion
                    }
                    else if (!chkTous.Checked && rdMensuel.Checked)
                    {
                        #region Mensuel
                        //Mise à jour dans la table tempStock
                        string[] tb = cboMois.Text.Split('/');
                        int s = Convert.ToInt32(tb[0]);

                        //con = new SqlConnection(clsMetier.strChaineConnection);
                        //con.Open();

                        //Requete qui va générer le report
                        cmd = new SqlCommand(@"SELECT article.id,article.desination, livraison.date AS dateEntree,ISNULL(livraison.quantinte,0) AS qteEntree,ISNULL(livraison.puAchat,0) AS puAchat,ISNULL(livraison.puAchat*livraison.quantinte,0) AS prixTotalAchat,livraison.stock_out AS stock_out FROM article  
                        INNER JOIN livraison ON article.id=livraison.id_article 
                        WHERE MONTH(livraison.date)=" + s + " AND article.fiche_supplementaire=0 ORDER BY article.desination ASC", clsMetier.GetInstance().InitializeReport());
                        ok_execute_query = true;
                        #endregion
                    }

                    if (ok_execute_query)
                    {
                        //Chargement report
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "doc");
                        rpt.SetDataSource(ds.Tables["doc"]);
                        crvSatistiquePharmacie.ReportSource = rpt;
                        crvSatistiquePharmacie.Refresh();
                        da.Dispose();
                        ds.Dispose();
                        cmd.Dispose();
                    }
                    #endregion
                }
                else if (rdSortiesSeul.Checked)
                {
                    #region Rapport pour sorties seulement
                    FicheStock_Sorties rpt = new FicheStock_Sorties();
                    SqlCommand cmd = null;
                    bool ok_execute_query = false;

                    if (chkTous.Checked)
                    {
                        #region Tous
                        //Mise à jour dans la table tempStock
                        //con = new SqlConnection(clsMetier.strChaineConnection);
                        //con.Open();

                        cmd = new SqlCommand(@"SELECT article.id,article.desination,sortie.date AS dtSortie, ISNULL(sortie.quantinte,0) AS qteSortie,ISNULL(article.pu,0) AS pu,ISNULL(sortie.quantinte*article.pu,0) prixTotalVente,sortie.stock_in AS stock_in FROM article  
                        INNER JOIN sortie ON sortie.id_article=article.id WHERE article.fiche_supplementaire=0
                        ORDER BY article.desination ASC", clsMetier.GetInstance().InitializeReport());
                        ok_execute_query = true;
                        #endregion
                    }
                    else if (!chkTous.Checked && rdJournalier.Checked)
                    {
                        #region Journalier

                        //Mise à jour dans la table tempStock
                        string s = txtDate.Value.ToShortDateString().ToString().Substring(0, 10);

                        //con = new SqlConnection(clsMetier.strChaineConnection);
                        //con.Open();

                        //Requete qui va générer le report
                        cmd = new SqlCommand(@"SELECT article.id,article.desination,sortie.date AS dtSortie, ISNULL(sortie.quantinte,0) AS qteSortie,ISNULL(article.pu,0) AS pu,ISNULL(sortie.quantinte*article.pu,0) prixTotalVente,sortie.stock_in AS stock_in FROM article  
                            INNER JOIN sortie ON sortie.id_article=article.id WHERE sortie.date='" + s + "' AND article.fiche_supplementaire=0 ORDER BY article.desination ASC", clsMetier.GetInstance().InitializeReport());
                        ok_execute_query = true;
                        #endregion
                    }
                    else if (!chkTous.Checked && rdMensuel.Checked)
                    {
                        #region Mensuel
                        //Mise à jour dans la table tempStock
                        string[] tb = cboMois.Text.Split('/');
                        int s = Convert.ToInt32(tb[0]);

                        //con = new SqlConnection(clsMetier.strChaineConnection);
                        //con.Open();

                        cmd = new SqlCommand(@"SELECT article.id,article.desination,sortie.date AS dtSortie, ISNULL(sortie.quantinte,0) AS qteSortie,ISNULL(article.pu,0) AS pu,ISNULL(sortie.quantinte*article.pu,0) prixTotalVente,sortie.stock_in AS stock_in FROM article  
                        INNER JOIN sortie ON sortie.id_article=article.id WHERE MONTH(sortie.date)=" + s + " AND article.fiche_supplementaire=0 ORDER BY article.desination ASC", clsMetier.GetInstance().InitializeReport());
                        ok_execute_query = true;
                        #endregion
                    }

                    if (ok_execute_query)
                    {
                        //Chargement report
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "doc");
                        rpt.SetDataSource(ds.Tables["doc"]);
                        crvSatistiquePharmacie.ReportSource = rpt;
                        crvSatistiquePharmacie.Refresh();
                        da.Dispose();
                        ds.Dispose();
                        cmd.Dispose();
                    }
                    #endregion
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + ">> Erreur lors de l'ouverture du rapport", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void loadReport3()
        {
            try
            {
                ArticlesEnExpiration rpt = new ArticlesEnExpiration();
                SqlCommand cmd = null;
                cmd = new SqlCommand(@"select article.desination,article.stock, article.stock_alert, livraison.dateexpiration
                        from article inner join livraison on livraison.id_article=article.id where article.fiche_supplementaire=0 AND livraison.dateexpiration < GETDATE()", clsMetier.GetInstance().InitializeReport());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "doc");
                rpt.SetDataSource(ds.Tables["doc"]);
                crvSatistiquePharmacie.ReportSource = rpt;
                crvSatistiquePharmacie.Refresh();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + ">> Erreur lors de l'ouverture du rapport", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void loadReport4()
        {
            try
            {
                string s = txtDateDebut.Value.ToShortDateString().ToString().Substring(0, 10);
                string t = txtDateFin.Value.ToShortDateString().ToString().Substring(0, 10);

                FicheStock_Sorties_Services rpt = new FicheStock_Sorties_Services();
                SqlCommand cmd = null;
                cmd = new SqlCommand(@"select article.id,article.desination,sortie.date AS dtSortie, ISNULL(sortie.quantinte,0) AS qteSortie,ISNULL(article.pu,0) AS pu,ISNULL(sortie.quantinte*article.pu,0) prixTotalVente,sortie.stock_in AS stock_in,service.id AS id_service,service.designation from article 
                INNER JOIN sortie ON article.id=sortie.id_article
                INNER JOIN service ON service.id=sortie.id_service WHERE sortie.date BETWEEN '" + s + "' AND '" + t + "' AND article.fiche_supplementaire=0", clsMetier.GetInstance().InitializeReport());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "doc");
                rpt.SetDataSource(ds.Tables["doc"]);
                crvSatistiquePharmacie.ReportSource = rpt;
                crvSatistiquePharmacie.Refresh();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + ">> Erreur lors de l'ouverture du rapport", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void loadReport5()
        {
            try
            {
                string s = txtDateDebut.Value.ToShortDateString().ToString().Substring(0, 10);
                string t = txtDateFin.Value.ToShortDateString().ToString().Substring(0, 10);

                FicheStock_Sorties_Services rpt = new FicheStock_Sorties_Services();
                SqlCommand cmd = null;
                cmd = new SqlCommand(@"select article.id,article.desination,sortie.date AS dtSortie, ISNULL(sortie.quantinte,0) AS qteSortie,ISNULL(article.pu,0) AS pu,ISNULL(sortie.quantinte*article.pu,0) prixTotalVente,sortie.stock_in AS stock_in,service.id AS id_service,service.designation from article 
                INNER JOIN sortie ON article.id=sortie.id_article
                INNER JOIN service ON service.id=sortie.id_service WHERE sortie.date BETWEEN '" + s + "' AND '" + t + "' AND service.designation ='" + cboService.Text + "' AND article.fiche_supplementaire=0", clsMetier.GetInstance().InitializeReport());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "doc");
                rpt.SetDataSource(ds.Tables["doc"]);
                crvSatistiquePharmacie.ReportSource = rpt;
                crvSatistiquePharmacie.Refresh();
                da.Dispose();
                ds.Dispose();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + ">> Erreur lors de l'ouverture du rapport", "Rapport", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmReportPharmacie_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ComboBox[] cbo = { cboMois };
                clsDoTraitement.GetInstance().unloadData(cbo);
            }
            catch (Exception) { }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            loadReport();
        }

        private void btnAfficherExp_Click(object sender, EventArgs e)
        {
            loadReport3();
        }

        private void btnAffTout_Click(object sender, EventArgs e)
        {
            loadReport2();
        }

        private void chkTous_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTous.Checked)
            {
                rdMensuel.Enabled = false;
                rdJournalier.Enabled = false;

                rdMensuel.Checked = false;
                rdJournalier.Checked = false;
                txtDate.Enabled = false;
                cboMois.Enabled = false;
            }
            else
            {
                rdMensuel.Enabled = true;
                rdJournalier.Enabled = true;

                rdMensuel.Checked = true;
                rdJournalier.Checked = false;
                txtDate.Enabled = false;
                cboMois.Enabled = true;
            }
        }

        private void FrmReportPharmacie_Load(object sender, EventArgs e)
        {
            chkTous.Checked = true;
            rdMensuel.Enabled = false;
            rdJournalier.Enabled = false;

            rdSortiesSeul.Checked = false;
            rdEntreeSeul.Checked = false;
            rdEntreeSorties.Checked = true;

            try
            {
                cboMois.DataSource = clsMetier.GetInstance().getAllMonthStk();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ">> Erreur lors du chargement des mois", "Chargement mois", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            try
            {
                cboService.DataSource = clsMetier.GetInstance().getAllClsservice();
                setMembersallcbo(cboService, "Designation", "Id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ">> Erreur lors du chargement des services", "Chargement des services", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void rdMensuel_CheckedChanged(object sender, EventArgs e)
        {
            txtDate.Enabled = false;
            cboMois.Enabled = true;
        }

        private void rdJournalier_CheckedChanged(object sender, EventArgs e)
        {
            txtDate.Enabled = true;
            cboMois.Enabled = false;
        }

        private void btnAfficherService_Click(object sender, EventArgs e)
        {
            if (chkTousService.Checked)
            {
                //On affiche les sorties correspondants à tous les services pour une échéance donnée
                loadReport4();
            }
            else
            {
                //On affiche les sorties correspondants à un services sélectionné dans le combobox pour une échéance donnée
                loadReport5();
            }
        }

        private void chkTousService_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTousService.Checked)
            {
                cboService.Enabled = false;
            }
            else if (!chkTousService.Checked)
            {
                cboService.Enabled = true;
            }
        }
    }
}
