CREATE VIEW vEntrepriseExterneAbonne
AS
SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom, numero AS numero, designEntreprise, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, 
                  SUM(isnull([ConsultationP], 0)) AS resultatConsult, SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, 
                  SUM(isnull([ConsultationPrenatale], 0)) AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, 
                  SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_Fraie], 0)) 
                  AS resultAutreFraie, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) 
                  + SUM(isnull([ConsultationPrenatale], 0)) + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) 
                  + SUM(isnull([Autre_Fraie], 0)) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0)) 
                  AS somme
FROM         (SELECT     SUM(dbo.examen.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                          operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id LEFT OUTER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id 
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non clotur� pay�') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Clotur� pay�')) AND categoriemalade.designation = 'Abonn�' 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                          operation_laboratoire.date, etablissementpriseencharge.denomination
                   UNION
                   SELECT     SUM(dbo.intervention.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non clotur� pay�') OR
                                         (dbo.subit.etatpaiement = 'Clotur� pay�')) AND categoriemalade.designation = 'Abonn�'  
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, subit.date
                   UNION
                   SELECT     SUM(tarifpreconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id LEFT OUTER JOIN
                                         dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     dossierpreconsultation.etatpaiement = 'Fiche pay�e' AND categoriemalade.designation = 'Abonn�' 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossierpreconsultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non clotur� pay�') OR
                                         (dbo.consultation.etatpaiement = 'Clotur� pay�')) AND categoriemalade.designation = 'Abonn�' 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         consultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationprenatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non clotur� pay�') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Clotur� pay�')) AND categoriemalade.designation = 'Abonn�' 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossierconsultationprenatale.date
                   UNION
                   SELECT     SUM(dbo.tarifechographie.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non clotur� pay�') OR
                                         (dbo.dossierechographie.etatpaiement = 'Clotur� pay�')) AND categoriemalade.designation = 'Abonn�' 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossierechographie.date
                   UNION
                   SELECT     SUM(dbo.tarifsoin.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id LEFT OUTER JOIN 
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non clotur� pay�') OR
                                         (dbo.dossiersoin.etatpaiement = 'Clotur� pay�')) AND categoriemalade.designation = 'Abonn�' 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossiersoin.date
                   UNION
                   SELECT     SUM(dbo.tarifnursing.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non clotur� pay�') OR
                                         (dbo.dossiernursing.etatpaiement = 'Clotur� pay�')) AND categoriemalade.designation = 'Abonn�' 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossiernursing.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationgynecologique.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non clotur� pay�') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Clotur� pay�')) AND categoriemalade.designation = 'Abonn�' 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossierconsultationgynecologique.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationpostnatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non clotur� pay�') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Clotur� pay�')) AND categoriemalade.designation = 'Abonn�' 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossierconsultationpostnatal.date
                   UNION
                   SELECT     SUM(dbo.article.pu) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dbo.sortie.etatpaiement = 'Pay�') AND categoriemalade.designation = 'Abonn�' 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, sortie.date
                   UNION
                   SELECT     SUM(dbo.detailsautrefraie.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             etablissementpriseencharge.denomination AS designEntreprise,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie RIGHT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Pay�') AND categoriemalade.designation = 'Abonn�' 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         autrefraie.dateenregistrement) MES_UNIONS PIVOT (sum(VALEUR) FOR dimension IN ([examenP], [ConsultationP], [ConsultationGP], [peconsult], 
                  [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Nursing], [InterventionP])) 
                  AS MON_PIVOT
GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent, numero, designEntreprise 