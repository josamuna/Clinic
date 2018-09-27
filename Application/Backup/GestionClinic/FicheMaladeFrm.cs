using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GestionClinic_LIB;
using GestionClinic_WIN.Reports;

namespace GestionClinic_WIN
{
    public partial class FicheMaladeFrm : Form
    {
        public FicheMaladeFrm()
        {
            InitializeComponent();
        }

        frmMainMenu principal = new frmMainMenu();

        public void setFormPrincipal(frmMainMenu frmPrinc)
        {
            principal = frmPrinc;
        }

        private void loadRpt(int id_malade)
        {
            FicheMalade rpt = new FicheMalade();
            SqlCommand cmd = null;
            cmd = new SqlCommand(@"SELECT     'Préconsultation' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne, 
                                  malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid, 
                                  ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature, preconsultation.datePrecons, DATEDIFF(YEAR, personne.datenaissance, 
                                  GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche, 
                                  personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'POIDS : ' + CONVERT(varchar(30),ISNULL(ROUND(preconsultation.poid, 2),0)) + ' Kg; T° : ' + CONVERT(varchar(30),ISNULL(preconsultation.temperature,0)) + ' °C; PRESSION ARTERIELLE : ' + CONVERT(varchar(30),ISNULL(preconsultation.pressionArterielle,0)) + ' mm Hg; POULS : ' + CONVERT(varchar(30),ISNULL(preconsultation.pouls,0)) + ' Bat/min; TAILLE : ' + CONVERT(varchar(30),ISNULL(ROUND(preconsultation.taille, 2),0)) +  ' Cm; OBSERVATION : ' + preconsultation.observation AS observation
            FROM         preconsultation INNER JOIN
                                  dossierpreconsultation ON dossierpreconsultation.id = preconsultation.id_dossierpreconsultation INNER JOIN
                                  malade ON malade.id = dossierpreconsultation.id_malade INNER JOIN
                                  airsante ON airsante.id = malade.id_airsante INNER JOIN
                                  profession ON profession.id = malade.id_profession INNER JOIN
                                  etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement INNER JOIN
                                  personne ON personne.id = malade.id_personne WHERE malade.id=" + id_malade +

            @" UNION
            SELECT 'Consultation' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,consultation.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers,'ANAMNESES : ' + mouvementconsultation.plainte + '; EXAMEN PHYSIQUE / DIAGNOSTIQUE DE PRESOMPTION  : ' + mouvementconsultation.symptome + '; DIAGNOSTIQUE DE CONFORMITE : ' + mouvementconsultation.medicamentaprescrire + '; CONDUITE A TENIR : ' + mouvementconsultation.Conduite + '; EXAMEN PARACLINIC : ' + mouvementconsultation.diagnostics AS observation FROM consultation 
            LEFT OUTER JOIN mouvementconsultation ON consultation.id=mouvementconsultation.id_consultation
            INNER JOIN malade ON malade.id=consultation.id_malade 
            INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
            INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
            INNER JOIN airsante ON airsante.id = malade.id_airsante 
            INNER JOIN profession ON profession.id = malade.id_profession 
            INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
            INNER JOIN personne ON personne.id = malade.id_personne WHERE malade.id=" + id_malade +

            @" UNION
            SELECT 'Laboratoire' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,CONVERT(date,ISNULL(operation_laboratoire.date,null),100) AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'CRITERE DE RESULTAT : ' + critereresultat.designation + '; RESULTATS : ' + mouvementoperation_laboratoire.resultat + '; EXAMEN : ' + examen.designation + '; TYPE EXAMEN : ' + typeexamen.designation AS observation FROM mouvementoperation_laboratoire 
            RIGHT OUTER JOIN operation_laboratoire ON operation_laboratoire.id=mouvementoperation_laboratoire.id_operation_laboratoire
            INNER JOIN critereresultat ON critereresultat.id=mouvementoperation_laboratoire.id_critere
            INNER JOIN examen ON examen.id=operation_laboratoire.id_examen
            INNER JOIN typeexamen ON typeexamen.id=examen.id_typeexamen
            INNER JOIN malade ON malade.id=operation_laboratoire.id_malade 
            INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
            INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
            INNER JOIN airsante ON airsante.id = malade.id_airsante 
            INNER JOIN profession ON profession.id = malade.id_profession 
            INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
            INNER JOIN personne ON personne.id = malade.id_personne WHERE malade.id=" + id_malade +

            @" UNION
            SELECT 'Hospitalisation' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,CONVERT(date,ISNULL(mvmhospitalisation.date,null),100) AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers,'DATE DEBUT : ' + CONVERT(varchar(30),CONVERT(date,ISNULL(hospitalisation.datedebut,null),100)) + '; DATE FIN : ' + CONVERT(varchar(30),CONVERT(date,ISNULL(hospitalisation.datefin,null),100)) + '; CHAMBRE : ' + chambre.designation + 'N°' + CONVERT(varchar(30),ISNULL(chambre.numero,0)) + '; CATEGORIE CHAMBRE : ' + categoriechambre.designation + '; PLS : ' + CONVERT(varchar(30),ISNULL(mvmhospitalisation.pls,0)) + '; RESPIRATION : ' + mvmhospitalisation.resiration + '; TA : ' + CONVERT(varchar(30),ISNULL(mvmhospitalisation.ta,0)) + '; T° : ' + CONVERT(varchar(30),ISNULL(mvmhospitalisation.temperature,0)) AS observation FROM mvmhospitalisation 
            RIGHT OUTER JOIN hospitalisation ON hospitalisation.id=mvmhospitalisation.id_hospitalisation
            INNER JOIN chambre ON chambre.id=hospitalisation.id_chambre
            INNER JOIN categoriechambre ON categoriechambre.id=chambre.id_categoriechambre
            INNER JOIN malade ON malade.id=hospitalisation.id_malade
            INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
            INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
            INNER JOIN airsante ON airsante.id = malade.id_airsante 
            INNER JOIN profession ON profession.id = malade.id_profession 
            INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
            INNER JOIN personne ON personne.id = malade.id_personne WHERE malade.id=" + id_malade +

            @" UNION
            SELECT 'Intervention' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,CONVERT(date,ISNULL(subit.date,null),100) AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'OBSERVATION : ' + subit.observation + '; BLOC : ' + bloc.designation + '; SERVICE : ' + service.designation AS observation FROM subit 
            RIGHT OUTER JOIN intervention ON intervention.id=subit.id_intervention
            INNER JOIN bloc ON bloc.id=intervention.id_bloc
            INNER JOIN service ON service.id=bloc.id_service
            INNER JOIN malade ON malade.id=subit.id_malade
            INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
            INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
            INNER JOIN airsante ON airsante.id = malade.id_airsante 
            INNER JOIN profession ON profession.id = malade.id_profession 
            INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
            INNER JOIN personne ON personne.id = malade.id_personne WHERE malade.id=" + id_malade +

            @" UNION
            SELECT 'Consultation Gynécologique' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,CONVERT(date,ISNULL(consultationgynecologique.date_consultation,null),100) AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers,'DDR : ' + CONVERT(varchar(30),CONVERT(date,ISNULL(consultationgynecologique.ddr,''),100)) + '; DPA : ' + CONVERT(varchar(30),CONVERT(date,ISNULL(consultationgynecologique.dpa,''),100)) + '; EXAMEN : ' + consultationgynecologique.examengyneco + '; DIAGNOSTIC : ' + consultationgynecologique.diagnostic + '; CRITERE ECHOGRAPHIE : ' + criterechographie.designation AS observation FROM consultationgynecologique 
            LEFT OUTER JOIN criterechographie ON criterechographie.id=consultationgynecologique.id_critere_echo
            INNER JOIN tarifconsultationgynecologique ON tarifconsultationgynecologique.id=consultationgynecologique.id_dossierconsultationgyneco
            INNER JOIN dossierconsultationgynecologique ON tarifconsultationgynecologique.id=dossierconsultationgynecologique.id_tarifconsultationgynecologique
            INNER JOIN malade ON malade.id=dossierconsultationgynecologique.id_malade 
            INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
            INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
            INNER JOIN airsante ON airsante.id = malade.id_airsante 
            INNER JOIN profession ON profession.id = malade.id_profession 
            INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
            INNER JOIN personne ON personne.id = malade.id_personne WHERE malade.id=" + id_malade +

            @" UNION 
            SELECT 'Médicaments' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,sortie.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers,'ARTICLE CONSOMME : ' + article.desination + '; CARACTERISTIQUE DU PRODUIT CONSOMME : ' + article.caracteristique + '; Qté PRISE : ' + CONVERT(varchar(20),sortie.quantinte) + '; SERVICE : ' + service.designation AS observation FROM article 
            INNER JOIN sortie ON article.id=sortie.id_article
            INNER JOIN service ON service.id=sortie.id_service
            INNER JOIN malade ON malade.id=sortie.id_malade 
            INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
            INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
            INNER JOIN airsante ON airsante.id = malade.id_airsante 
            INNER JOIN profession ON profession.id = malade.id_profession 
            INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
            INNER JOIN personne ON personne.id = malade.id_personne WHERE malade.id=" + id_malade +

            @" UNION 
            SELECT 'Autres frais' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,autrefraie.datepaiement AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers,'ETABLISSEMENT EXTERNE : ' + etablissementexterne.denomination + '; N° FACTURE : ' + autrefraie.numerofacture + '; EXAMEN PASSE : ' + detailsautrefraie.designation + '; DATE PASSATION : ' + CONVERT(varchar(30),CONVERT(date,autrefraie.dateenregistrement,100)) AS observation FROM etablissementexterne 
            INNER JOIN autrefraie ON etablissementexterne.id=autrefraie.id_etablissementexterne
            INNER JOIN detailsautrefraie ON autrefraie.id=detailsautrefraie.id_autrefraie
            INNER JOIN malade ON malade.id=autrefraie.id_malade 
            INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
            INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
            INNER JOIN airsante ON airsante.id = malade.id_airsante 
            INNER JOIN profession ON profession.id = malade.id_profession 
            INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
            INNER JOIN personne ON personne.id = malade.id_personne WHERE malade.id=" + id_malade +

            @" UNION
            SELECT 'CPN' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,consultationprenatal.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'CONJONCTIVE : ' + consultationprenatal.conjoctivepalpebrale + '; DDR : ' + consultationprenatal.ddr + '; DRP : ' + consultationprenatal.drp + '; ANTECEDENT : ' + consultationprenatal.entecedent + '; GESTE TRAITEMENT : ' + consultationprenatal.gesttte + '; Gp. SANGUN : ' + consultationprenatal.gropeSanguin + '; HISTORIQUE GROSSESSE : ' +  consultationprenatal.historiqueGrossesse AS observation FROM consultationprenatal 
            INNER JOIN dossierconsultationprenatale ON dossierconsultationprenatale.id=consultationprenatal.id_dossierconsultationprenatale
            INNER JOIN malade ON malade.id=dossierconsultationprenatale.id_malade  
            INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
            INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
            INNER JOIN airsante ON airsante.id = malade.id_airsante 
            INNER JOIN profession ON profession.id = malade.id_profession 
            INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
            INNER JOIN personne ON personne.id = malade.id_personne WHERE malade.id=" + id_malade +

            @" UNION
            SELECT 'CPOS' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,maladeenconsultationpostnatal.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'PERE : ' + maladeenconsultationpostnatal.nompere + '; MERE : ' + maladeenconsultationpostnatal.nommere + '; POIDS NAISSANCE : ' + CONVERT(varchar(30),ISNULL(maladeenconsultationpostnatal.poidsnaisance,0)) AS observation FROM maladeenconsultationpostnatal 
            INNER JOIN dossierconsultationpostnatal ON dossierconsultationpostnatal.id=maladeenconsultationpostnatal.id_dossierconsultationpostnatal
            INNER JOIN malade ON malade.id=dossierconsultationpostnatal.id_malade  
            INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
            INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
            INNER JOIN airsante ON airsante.id = malade.id_airsante 
            INNER JOIN profession ON profession.id = malade.id_profession 
            INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
            INNER JOIN personne ON personne.id = malade.id_personne WHERE malade.id=" + id_malade +

            @" UNION
            SELECT 'Echographie' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,dossierechographie.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'EXAMEN CONCERNE : ' + tarifechographie.designation AS observation FROM dossierechographie 
            INNER JOIN tarifechographie ON tarifechographie.id=dossierechographie.id_tarifechographie
            INNER JOIN malade ON malade.id=dossierechographie.id_malade   
            INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
            INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
            INNER JOIN airsante ON airsante.id = malade.id_airsante 
            INNER JOIN profession ON profession.id = malade.id_profession 
            INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
            INNER JOIN personne ON personne.id = malade.id_personne WHERE malade.id=" + id_malade +

            @" UNION
            SELECT 'Soins' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,dossiersoin.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'SOINS CONCERNE : ' + tarifsoin.designation AS observation FROM dossiersoin 
            INNER JOIN tarifsoin ON tarifsoin.id=dossiersoin.id_tarifsoin
            INNER JOIN malade ON malade.id=dossiersoin.id_malade 
            INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
            INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
            INNER JOIN airsante ON airsante.id = malade.id_airsante 
            INNER JOIN profession ON profession.id = malade.id_profession 
            INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
            INNER JOIN personne ON personne.id = malade.id_personne WHERE malade.id=" + id_malade +

            @" UNION
            SELECT 'Nursing' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,dossiernursing.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'NURSING : ' + tarifnursing.designation AS observation FROM dossiernursing 
            INNER JOIN tarifnursing ON tarifnursing.id=dossiernursing.id_tarifnursing
            INNER JOIN malade ON malade.id=dossiernursing.id_malade  
            INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
            INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
            INNER JOIN airsante ON airsante.id = malade.id_airsante 
            INNER JOIN profession ON profession.id = malade.id_profession 
            INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
            INNER JOIN personne ON personne.id = malade.id_personne WHERE malade.id=" + id_malade +

            @" UNION
            SELECT 'Accouchement' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,dossieraccouchement.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'TYPE ACCOUCHEMENT : ' + typeaccouchement.designation  AS observation FROM typeaccouchement
            INNER JOIN dossieraccouchement ON typeaccouchement.id=dossieraccouchement.id_typeaccouchement
            INNER JOIN malade ON malade.id=dossieraccouchement.id_malade  
            INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
            INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
            INNER JOIN airsante ON airsante.id = malade.id_airsante 
            INNER JOIN profession ON profession.id = malade.id_profession 
            INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
            INNER JOIN personne ON personne.id = malade.id_personne WHERE malade.id=" + id_malade +

            @" UNION 
            SELECT 'Avance' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,dossieravance.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'AVANCE PRISE : ' + tarifavance.designation AS observation FROM dossieravance 
            INNER JOIN tarifavance ON tarifavance.id=dossieravance.id_tarifavance
            INNER JOIN malade ON malade.id=dossieravance.id_malade  
            INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
            INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
            INNER JOIN airsante ON airsante.id = malade.id_airsante 
            INNER JOIN profession ON profession.id = malade.id_profession 
            INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
            INNER JOIN personne ON personne.id = malade.id_personne WHERE malade.id=" + id_malade, clsMetier.GetInstance().InitializeReport());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "doc");
            rpt.SetDataSource(ds.Tables["doc"]);
            crvRapport.ReportSource = rpt;
            crvRapport.Refresh();
            da.Dispose();
            ds.Dispose();
            cmd.Dispose();
        }

        private void cmdAfficher_Click(object sender, EventArgs e)
        {
            try
            {
                int idMalade = clsDoTraitement.IdMalade;
                loadRpt(idMalade);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Affichage du rapport, " + ex.Message, "Erreur lors de l'affichage du rapport", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblRecherche_MouseEnter(object sender, EventArgs e)
        {
            ((Control)lblRecherche).ForeColor = Color.WhiteSmoke;
            ((Control)lblRecherche).BackColor = Color.FromArgb(163, 185, 207);
        }

        private void lblRecherche_MouseLeave(object sender, EventArgs e)
        {
            ((Control)lblRecherche).BackColor = Color.Empty;
            ((Control)lblRecherche).ForeColor = Color.Black;
        }

        private void lblRecherche_Click(object sender, EventArgs e)
        {
            RecherchePersonneFrm form = new RecherchePersonneFrm();
            form.setFormPrincipal(principal);
            form.Icon = principal.Icon;
            form.ShowDialog();
        }
    }
}
