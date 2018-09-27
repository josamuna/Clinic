SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom, numero AS numero, designEntreprise, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, 
                  SUM(isnull([ConsultationP], 0)) AS resultatConsult, SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, 
                  SUM(isnull([ConsultationPrenatale], 0)) AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, 
                  SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_Fraie], 0)) 
                  AS resultAutreFraie, SUM(isnull([Hospitalisation], 0)) AS resultHospitalisation, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([Accouchement], 0)) 
                  AS resultAccouchement, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) 
                  + SUM(isnull([ConsultationPrenatale], 0)) + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) 
                  + SUM(isnull([Autre_Fraie], 0)) + SUM(isnull([Hospitalisation], 0)) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0)) + SUM(isnull([Accouchement], 0)) 
                  AS somme
FROM         (SELECT     SUM(dbo.examen.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                          operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id LEFT OUTER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id 
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='Echo Flight' and (convert(date,operation_laboratoire.date,100) between '01/08/2015' and '04/08/2015') and (convert(date,hospitalisation.datefin,100) between '01/08/2015' and '04/08/2015')
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                          operation_laboratoire.date, etablissementpriseencharge.denomination
                   UNION
                   SELECT     SUM(dbo.intervention.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'    and etablissementpriseencharge.denomination='Echo Flight' and (convert(date,subit.date,100) between '01/08/2015' and '04/08/2015') and (convert(date,hospitalisation.datefin,100) between '01/08/2015' and '04/08/2015')
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, subit.date
                   UNION
                   SELECT     SUM(tarifpreconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade LEFT OUTER JOIN
                                         hospitalisation ON dbo.malade.id=dbo.hospitalisation.id_malade INNER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id LEFT OUTER JOIN
                                         dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     dossierpreconsultation.etatpaiement = 'Fiche payée' AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='Echo Flight' and (convert(date,dossierpreconsultation.date,100) between '01/08/2015' and '04/08/2015') and (convert(date,hospitalisation.datefin,100) between '01/08/2015' and '04/08/2015')
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossierpreconsultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='Echo Flight' and (convert(date,consultation.date,100) between '01/08/2015' and '04/08/2015') and (convert(date,hospitalisation.datefin,100) between '01/08/2015' and '04/08/2015')
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         consultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationprenatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='Echo Flight' and (convert(date,dossierconsultationprenatale.date,100) between '01/08/2015' and '04/08/2015') and (convert(date,hospitalisation.datefin,100) between '01/08/2015' and '04/08/2015')
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossierconsultationprenatale.date
                   UNION
                   SELECT     SUM(dbo.tarifechographie.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='Echo Flight' and (convert(date,dossierechographie.date,100) between '01/08/2015' and '04/08/2015') and (convert(date,hospitalisation.datefin,100) between '01/08/2015' and '04/08/2015')
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossierechographie.date
                   UNION
                   SELECT     SUM(dbo.tarifsoin.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id LEFT OUTER JOIN 
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='Echo Flight' and (convert(date,dossiersoin.date,100) between '01/08/2015' and '04/08/2015') and (convert(date,hospitalisation.datefin,100) between '01/08/2015' and '04/08/2015')
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossiersoin.date
                   UNION
                   SELECT     SUM(dbo.tarifnursing.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='Echo Flight' and (convert(date,dossiernursing.date,100) between '01/08/2015' and '04/08/2015') and (convert(date,hospitalisation.datefin,100) between '01/08/2015' and '04/08/2015')
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
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='Echo Flight'  and (convert(date,dossierconsultationgynecologique.date,100) between '01/08/2015' and '04/08/2015') and (convert(date,hospitalisation.datefin,100) between '01/08/2015' and '04/08/2015')
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossierconsultationgynecologique.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationpostnatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='Echo Flight' and (convert(date,dossierconsultationpostnatal.date,100) between '01/08/2015' and '04/08/2015') and (convert(date,hospitalisation.datefin,100) between '01/08/2015' and '04/08/2015')
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         dossierconsultationpostnatal.date
                   UNION
                   SELECT     SUM(dbo.typeaccouchement.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossieraccouchement.date AS dateEvent, 'Accouchement' AS DIMENSION
                   FROM         dbo.typeaccouchement INNER JOIN
                                         dbo.dossieraccouchement ON dbo.typeaccouchement.id = dbo.dossieraccouchement.id_typeaccouchement LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossieraccouchement.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     ((dbo.dossieraccouchement.etatpaiement = 'Non cloturé payé') OR (dbo.dossieraccouchement.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='Echo Flight' and (convert(date,dossieraccouchement.date,100) between '01/08/2015' and '04/08/2015') and (convert(date,hospitalisation.datefin,100) between '01/08/2015' and '04/08/2015')
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossieraccouchement.date
                   UNION
                   SELECT     SUM(dbo.article.pu) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='Echo Flight' and (convert(date,sortie.date,100) between '01/08/2015' and '04/08/2015') and (convert(date,hospitalisation.datefin,100) between '01/08/2015' and '04/08/2015')
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, sortie.date
                   UNION
                   SELECT     SUM(dbo.detailsautrefraie.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             etablissementpriseencharge.denomination AS designEntreprise,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie RIGHT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='Echo Flight' and (convert(date,autrefraie.dateenregistrement,100) between '01/08/2015' and '04/08/2015') and (convert(date,hospitalisation.datefin,100) between '01/08/2015' and '04/08/2015')
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         autrefraie.dateenregistrement
                   UNION
                   SELECT     SUM(dbo.categoriechambre.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         hospitalisation.datefin AS dateEvent, 'Hospitalisation' AS DIMENSION
                   FROM         dbo.hospitalisation INNER JOIN
                                         dbo.chambre LEFT OUTER JOIN
                                         dbo.categoriechambre ON dbo.chambre.id_categoriechambre = dbo.categoriechambre.id ON 
                                         dbo.hospitalisation.id_chambre = dbo.chambre.id LEFT OUTER JOIN
                                         dbo.personne LEFT OUTER JOIN
                                         dbo.malade ON dbo.personne.id = dbo.malade.id_personne ON dbo.hospitalisation.id_malade = dbo.malade.id LEFT OUTER JOIN
                                         dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.hospitalisation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.hospitalisation.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' and etablissementpriseencharge.denomination='Echo Flight' and (convert(date,hospitalisation.datefin,100) between '01/08/2015' and '04/08/2015') and (convert(date,hospitalisation.datefin,100) between '01/08/2015' and '04/08/2015')
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         hospitalisation.datefin) MES_UNIONS PIVOT (sum(VALEUR) FOR dimension IN ([examenP], [ConsultationP], [ConsultationGP], [peconsult], 
                  [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Hospitalisation], [Nursing], [InterventionP], [Accouchement])) 
                  AS MON_PIVOT
GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent, numero, designEntreprise 