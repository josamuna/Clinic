SELECT MAX(id) AS lastId FROM facturation
--Facture1
CREATE VIEW fact1
	AS
	SELECT facturation.numero_facture,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'')+ ' ' + ISNULL(personne.prenom,'') AS nom,facturation.quantite,facturation.pu,facturation.designation,facturation.pu*facturation.quantite AS PT,categoriemalade.taux,categoriemalade.designation AS catMalade FROM facturation
	INNER JOIN malade ON malade.id=facturation.id_malade
	INNER JOIN categoriemalade ON categoriemalade.id=malade.id_categoriemalade
	INNER JOIN personne ON personne.id=malade.id_personne
	GROUP BY facturation.numero_facture,personne.nom,personne.postnom,personne.prenom,facturation.quantite,facturation.pu,facturation.designation,categoriemalade.taux,categoriemalade.designation

--Facture2
CREATE VIEW fact2
	AS
	SELECT fact1.numero_facture,SUM(fact1.PT) AS Total_General,SUM(fact1.PT)*fact1.taux  AS Net_a_payer FROM fact1
	GROUP BY fact1.taux,fact1.numero_facture

--Facture
SELECT fact1.numero_facture,fact1.nom,fact1.quantite,fact1.pu,fact1.designation,fact1.PT,fact2.Total_General,fact2.Net_a_payer FROM fact1
INNER JOIN fact2 ON fact1.numero_facture=fact2.numero_facture 

SELECT fact1.numero_facture,fact1.nom,fact1.quantite,fact1.pu,fact1.designation,fact1.pu,fact1.quantite, SUM(fact1.PT) AS Total_General,SUM(PT)*fact1.taux AS Net_a_payer FROM fact1
GROUP BY fact1.numero_facture,fact1.nom,fact1.quantite,fact1.pu,fact1.designation,fact1.pu,fact1.quantite,fact1.PT,fact1.taux

SELECT MAX(numero_facture) AS lastNumFacture FROM facturation
SELECT hospitalisation.id AS idHospitalisation,chambre.id,chambre.id_categoriechambre,chambre.designation AS designation,chambre.numero AS numero,categoriechambre.designation AS desi,categoriechambre.prix AS prix,ISNULL(DATEDIFF(DAY,hospitalisation.datedebut,hospitalisation.datefin),0) AS nbrjour FROM categoriechambre
                    INNER JOIN chambre ON categoriechambre.id=chambre.id_categoriechambre
                    INNER JOIN hospitalisation ON chambre.id=hospitalisation.id_chambre 
                    INNER JOIN malade ON malade.id=hospitalisation.id_malade WHERE malade.id=3 AND (hospitalisation.etatpaiement='Non cloturé non payé' OR hospitalisation.etatpaiement='Cloturé non payé')

SELECT CONVERT(varchar(50), MONTH(date)) AS mois, CONVERT(varchar(50), YEAR(date)) AS annee FROM paiement WHERE archive=0 ORDER BY date DESC


SELECT paiement.*,tarifconsultation.designation + '=>' + CONVERT(varchar(50),tarifconsultation.montant) + ' $US' AS desiConsultation,tarifpreconsultation.designation + '=>' + CONVERT(varchar(50),tarifconsultation.montant) + ' $US' AS desiPreconsultation,tarifconsultationpostnatal.designation + '=>' + CONVERT(varchar(50),tarifconsultationpostnatal.montant) + ' $US' AS desiCPOS,tarifconsultationprenatal.designation + '=>' + CONVERT(varchar(50),tarifconsultationprenatal.montant) + ' $US' AS desiCPN,examen.designation + '=>' + CONVERT(varchar(50),examen.prix) + ' $US' AS desiLaboratoire,article.desination + '=>' + CONVERT(varchar(50),sortie.quantinte * article.pu) + ' $US' AS desiSortie,intervention.designation + '=>' + CONVERT(varchar(50),intervention.prix) + ' $US' AS desiIntervention,chambre.designation + '' + CONVERT(varchar(100),chambre.numero) + '=>' + CONVERT(varchar(50),categoriechambre.prix) + ' $US' AS desiChambre FROM paiement
INNER JOIN malade ON malade.id=paiement.id_malade
RIGHT OUTER JOIN dossierpreconsultation ON dossierpreconsultation.id=paiement.id_dossierpreconsultation
INNER JOIN tarifpreconsultation ON tarifpreconsultation.id=dossierpreconsultation.id_tarifpreconsultation
RIGHT OUTER JOIN consultation ON consultation.id=paiement.id_consultation
INNER JOIN tarifconsultation ON tarifconsultation.id=consultation.id
RIGHT OUTER JOIN dossierconsultationpostnatal ON dossierconsultationpostnatal.id=paiement.id_dossierconsultationpostnatal
INNER JOIN tarifconsultationpostnatal ON tarifconsultationpostnatal.id=dossierconsultationpostnatal.id_tarifconsultationpostnatal
RIGHT OUTER JOIN dossierconsultationprenatale ON dossierconsultationprenatale.id=paiement.id_dossierconsultationprenatale
INNER JOIN tarifconsultationprenatal ON tarifconsultationprenatal.id=dossierconsultationprenatale.id_tarifconsultationprenatal
RIGHT OUTER JOIN hospitalisation ON hospitalisation.id=paiement.id_hospitalisation
RIGHT JOIN operation_laboratoire ON operation_laboratoire.id=paiement.id_operation_laboratoire
INNER JOIN examen ON examen.id=operation_laboratoire.id_examen
RIGHT OUTER JOIN chambre ON chambre.id=hospitalisation.id_chambre
INNER JOIN categoriechambre ON categoriechambre.id=chambre.id_categoriechambre
RIGHT OUTER JOIN subit ON subit.id=paiement.id_subit
INNER JOIN intervention ON intervention.id=subit.id_intervention
RIGHT OUTER JOIN sortie ON sortie.id=paiement.id_sortie
INNER JOIN article ON article.id=sortie.id_article
WHERE ((dossierpreconsultation.etatpaiement='Fiche payée')
OR (consultation.etatpaiement='Non cloturé payé' OR consultation.etatpaiement='Cloturé payé')
OR (dossierconsultationpostnatal.etatpaiement='Non cloturé payé' OR dossierconsultationpostnatal.etatpaiement='Cloturé payé')
OR (dossierconsultationprenatale.etatpaiement='Non cloturé payé' OR dossierconsultationprenatale.etatpaiement='Cloturé payé')
OR (hospitalisation.etatpaiement='Non cloturé payé' OR hospitalisation.etatpaiement='Cloturé payé')
OR (operation_laboratoire.etatpaiement='Non cloturé payé' OR operation_laboratoire.etatpaiement='Cloturé payé')
OR (subit.etatpaiement='Non cloturé payé' OR subit.etatpaiement='Cloturé payé')
OR (sortie.etatpaiement='Payé')) AND paiement.id=1 

-----------


SELECT paiement.*,tarifconsultation.designation + '=>' + CONVERT(varchar(50),tarifconsultation.montant) + ' $US' AS desiConsultation FROM paiement
LEFT OUTER JOIN malade ON malade.id=paiement.id_malade
RIGHT OUTER JOIN consultation ON consultation.id=paiement.id_consultation
INNER JOIN tarifconsultation ON tarifconsultation.id=consultation.id

OR consultation.etatpaiement='Non cloturé payé' OR consultation.etatpaiement='Cloturé payé' 

SELECT dossierpreconsultation.id AS idPrecons,tarifpreconsultation.id,tarifpreconsultation.designation,tarifpreconsultation.montant FROM tarifpreconsultation 
                    INNER JOIN dossierpreconsultation ON tarifpreconsultation.id=dossierpreconsultation.id_tarifpreconsultation 
                    INNER JOIN malade ON malade.id=dossierpreconsultation.id_malade 
                    INNER JOIN personne ON personne.id=malade.id_personne 
                    WHERE malade.id=1 AND (dossierpreconsultation.etatpaiement='Fiche non payé') ORDER BY tarifpreconsultation.designation ASC

--SELECT @@IDENTITY FROM paiement AS lastIdInserted
--drop table test
--create table test
--(
--date1 datetime ,
--date2 datetime 
--) 
--insert into test(date1,date2) values
--('12-03-2000','14-03-1989'),
--('12/03/2015','14/03/2014'),
--('12/03/2012','14/03/1990')
--go
--create table test
--(
--id int identity ,
--date2 varchar(10) 
--) 
--insert into test(date2) values
--('14/03/1990'),
--('12/03/2012')
--go
--SELECT @@IDENTITY FROM test AS lastIdInserted
----select DATEDIFF(DAY,test.date1,test.date2) from test
----select (date1-date2) As nt FROM test


SELECT operation_laboratoire.id,operation_laboratoire.date,examen.designation,examen.prix FROM examen
INNER JOIN operation_laboratoire ON examen.id=operation_laboratoire.id_examen
INNER JOIN malade ON malade.id=operation_laboratoire.id_malade WHERE malade.id=5 AND (operation_laboratoire.etatpaiement='Non cloturé non payé' OR operation_laboratoire.etatpaiement='Cloturé non payé')

SELECT tarifconsultationpostnatal.id,tarifconsultationpostnatal.designation,tarifconsultationpostnatal.montant FROM tarifconsultationpostnatal 
INNER JOIN dossierconsultationpostnatal ON tarifconsultationpostnatal.id=dossierconsultationpostnatal.id_tarifconsultationpostnatal
INNER JOIN malade ON malade.id=dossierconsultationpostnatal.id_malade 
WHERE malade.id=1 AND (dossierconsultationpostnatal.etatpaiement='Non cloturé non payé' OR dossierconsultationpostnatal.etatpaiement='Cloturé non payé') ORDER BY tarifconsultationpostnatal.designation ASC

SELECT tarifconsultationprenatal.id,tarifconsultationprenatal.designation,tarifconsultationprenatal.montant FROM tarifconsultationprenatal 
INNER JOIN dossierconsultationprenatale ON tarifconsultationprenatal.id=dossierconsultationprenatale.id_tarifconsultationprenatal
INNER JOIN malade ON malade.id=dossierconsultationprenatale.id_malade 
WHERE malade.id=1 AND (dossierconsultationprenatale.etatpaiement='Non cloturé non payé' OR dossierconsultationprenatale.etatpaiement='Cloturé non payé') ORDER BY tarifconsultationprenatal.designation ASC


SELECT ISNULL(personne.nom,'') + ISNULL(personne.postnom,'') + ISNULL(personne.prenom,'') AS nom,personne.sexe,personne.etatcivil,personne.datenaissance,personne.telephone,personne.photo,malade.id AS idMal,malade.id_personne,malade.id_airsante,malade.id_categoriemalade,malade.id_etablissement,malade.id_profession,malade.numero FROM personne
INNER JOIN malade ON personne.id=malade.id_personne
INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
INNER JOIN consultation ON malade.id=consultation.id_malade
INNER JOIN dossierconsultationprenatale ON malade.id=dossierconsultationprenatale.id_malade
INNER JOIN dossierconsultationpostnatal ON malade.id=dossierconsultationpostnatal.id_malade
INNER JOIN operation_laboratoire ON malade.id=operation_laboratoire.id_malade
INNER JOIN hospitalisation ON malade.id=hospitalisation.id_malade
INNER JOIN subit ON malade.id=subit.id_malade
WHERE dossierpreconsultation.etatpaiement='Fiche non payée'
OR consultation.etatpaiement='Non cloturé non payé' AND consultation.etatpaiement='Cloturé non payé' 
OR dossierconsultationprenatale.etatpaiement='Non cloturé non payé' AND dossierconsultationprenatale.etatpaiement='Cloturé non payé' 
OR dossierconsultationpostnatal.etatpaiement='Non cloturé non payé' AND dossierconsultationpostnatal.etatpaiement='Cloturé non payé' 
OR operation_laboratoire.etatpaiement='Non cloturé non payé' AND operation_laboratoire.etatpaiement='Cloturé non payé' 
OR hospitalisation.etatpaiement='Non cloturé non payé' AND hospitalisation.etatpaiement='Cloturé non payé'
OR subit.etatpaiement='Non cloturé non payé' AND subit.etatpaiement='Cloturé non payé'
ORDER BY personne.nom ASC


SELECT tarifconsultation.id,tarifconsultation.designation,tarifconsultation.montant FROM tarifconsultation 
INNER JOIN consultation ON tarifconsultation.id=consultation.id_tarifconsultation 
INNER JOIN malade ON malade.id=consultation.id_malade 
INNER JOIN personne ON personne.id=malade.id_personne WHERE malade.id=1 ORDER BY tarifconsultation.designation ASC

SELECT intervention.id,intervention.designation,intervention.prix FROM intervention 
INNER JOIN subit ON intervention.id=subit.id_intervention 
INNER JOIN malade ON malade.id=subit.id_malade 
INNER JOIN personne ON personne.id=malade.id_personne WHERE malade.id=1 ORDER BY intervention.designation ASC

SELECT article.id,article.desination,article.pu,article.caracteristique FROM article 
INNER JOIN sortie ON article.id=sortie.id_article
INNER JOIN malade ON malade.id=sortie.id_malade
WHERE malade.id=1 ORDER BY article.desination ASC

SELECT hospitalisation.id AS idHospitalisation,chambre.id,chambre.id_categoriechambre,chambre.designation AS designation,chambre.numero AS numero,categoriechambre.designation AS desi,categoriechambre.prix AS prix,DATEDIFF(DAY,hospitalisation.datedebut,hospitalisation.datefin) AS nbrjour FROM categoriechambre
INNER JOIN chambre ON categoriechambre.id=chambre.id_categoriechambre
INNER JOIN hospitalisation ON chambre.id=hospitalisation.id_chambre 
INNER JOIN malade ON malade.id=hospitalisation.id_malade WHERE malade.id=1 AND (hospitalisation.etatpaiement='Non cloturé non payé' OR hospitalisation.etatpaiement='Cloturé non payé')


