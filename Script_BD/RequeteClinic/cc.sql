SELECT (SUM(fichesupplementaire.montant) + SUM(ISNULL(dossierpreconsultation.cumul,0))) AS montant2, fichesupplementaire.id_tarifpreconsultation FROM fichesupplementaire 
INNER JOIN dossierpreconsultation ON dossierpreconsultation.id=fichesupplementaire.id_dossierpreconsultation
WHERE fichesupplementaire.id_dossierpreconsultation=1 and fichesupplementaire.etatpaiement='Fiche non payée' 
GROUP BY fichesupplementaire.id_tarifpreconsultation
                        
                        
select * from fichesupplementaire
select * from dossierpreconsultation where id_malade=37
select * from tarifpreconsultation

SELECT tarifpreconsultation.montant AS montant1 FROM tarifpreconsultation INNER JOIN dossierpreconsultation ON tarifpreconsultation.id=dossierpreconsultation.id_tarifpreconsultation WHERE dossierpreconsultation.id=1
delete from fichesupplementaire
update dossierpreconsultation set etatpaiement='Fiche non payée' where id_malade=37
(SELECT tarifpreconsultation.montant AS montant1 FROM tarifpreconsultation INNER JOIN dossierpreconsultation ON tarifpreconsultation.id=dossierpreconsultation.id_tarifpreconsultation WHERE dossierpreconsultation.id=25)
(SELECT SUM(fichesupplementaire.montant) AS montant2 FROM fichesupplementaire WHERE fichesupplementaire.id_dossierpreconsultation=25)

SELECT dossierpreconsultation.cumul,dossierpreconsultation.etatpaiement FROM dossierpreconsultation WHERE dossierpreconsultation.id=25
                        
 
SELECT SUM(fichesupplementaire.montant) AS montant2 FROM fichesupplementaire 
                        WHERE fichesupplementaire.id_dossierpreconsultation=25 and fichesupplementaire.etatpaiement='Fiche non payée' 
                        --GROUP BY fichesupplementaire.id_tarifpreconsultation
                        
                        
                        
--                        (SUM(dbo.examen.prix*categoriemalade.taux)-SUM(dbo.examen.prix*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR
--(SUM(dbo.intervention.prix*categoriemalade.taux)-SUM(dbo.intervention.prix*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR
--(SUM(dbo.tarifpreconsultation.montant*categoriemalade.taux)-SUM(dbo.tarifpreconsultation.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR
--(SUM(dbo.tarifconsultation.montant*categoriemalade.taux)-SUM(dbo.tarifconsultation.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR
--(SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux)-SUM(dbo.tarifconsultationprenatal.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR
--(SUM(dbo.tarifechographie.montant*categoriemalade.taux)-SUM(dbo.tarifechographie.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR
--(SUM(dbo.tarifsoin.montant*categoriemalade.taux)-SUM(dbo.tarifsoin.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR
--(SUM(dbo.tarifnursing.montant*categoriemalade.taux)-SUM(dbo.tarifnursing.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR
--(SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux)-SUM(dbo.tarifconsultationgynecologique.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR
--(SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux)-SUM(dbo.tarifconsultationpostnatal.montant*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR
--(SUM(dbo.typeaccouchement.prix*categoriemalade.taux)-SUM(dbo.typeaccouchement.prix*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR
--(SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux)-SUM(dbo.article.pu*dbo.sortie.quantinte*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR
--(SUM(dbo.categoriechambre.prix*ISNULL(DATEDIFF(DAY,hospitalisation.datedebut,hospitalisation.datefin),0)*categoriemalade.taux)-SUM(dbo.categoriechambre.prix*ISNULL(DATEDIFF(DAY,hospitalisation.datedebut,hospitalisation.datefin),0)*categoriemalade.taux*etablissementpriseencharge.taux)) AS VALEUR
--(SUM(dbo.detailsautrefraie.prix)-SUM(dbo.detailsautrefraie.prix*etablissementpriseencharge.taux))
--MAX(dbo.malade_avance.cumul) AS VALEUR


 INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id