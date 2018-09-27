
--Medicaments pris par un malade
 SELECT personne.nom + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') + ' => N° fiche : ' + malade.numero_fiche + ' => N° malade : ' + malade.numero AS nom,article.desination,article.pu,article.caracteristique,sortie.date,sortie.quantinte,sortie.etatpaiement,categoriemalade.designation,etablissementpriseencharge.denomination FROM sortie 
 INNER JOIN article ON article.id=sortie.id_article
 INNER JOIN malade ON malade.id = sortie.id_malade 
 INNER JOIN categoriemalade ON categoriemalade.id=malade.id_categoriemalade
 INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id=malade.id_etablissement
 INNER JOIN personne ON malade.id_personne = personne.id 
 WHERE malade.id=1 AND sortie.date BETWEEN '10/08/15' AND '01/11/15'--sortie.etatpaiement = 'Payé' 
 
--Medicaments pris pour tous les malades (hospitalisé et non hospitalisé)
 SELECT malade.numero_fiche,personne.nom + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS nom,article.desination,article.pu,article.caracteristique,sortie.date,sortie.quantinte,sortie.etatpaiement,categoriemalade.designation,etablissementpriseencharge.denomination FROM sortie 
 INNER JOIN article ON article.id=sortie.id_article
 INNER JOIN malade ON malade.id = sortie.id_malade 
 INNER JOIN categoriemalade ON categoriemalade.id=malade.id_categoriemalade
 INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id=malade.id_etablissement
 INNER JOIN personne ON malade.id_personne = personne.id 
 WHERE sortie.date BETWEEN '10/08/15' AND '01/11/15' 
 
 --Medicaments pris pour malade hospitalisé
 SELECT malade.numero_fiche,personne.nom + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS nom,article.desination,article.pu,article.caracteristique,sortie.date,sortie.quantinte,sortie.etatpaiement,categoriemalade.designation,etablissementpriseencharge.denomination,hospitalisation.etatpaiement AS etatPaiement_Hospitalisation,chambre.designation + ' N° ' + CONVERT(VARCHAR(20),chambre.numero) AS chambre FROM sortie 
 INNER JOIN article ON article.id=sortie.id_article
 INNER JOIN malade ON malade.id = sortie.id_malade 
 INNER JOIN hospitalisation ON malade.id=hospitalisation.id_malade
 INNER JOIN chambre ON chambre.id=hospitalisation.id_chambre
 INNER JOIN categoriemalade ON categoriemalade.id=malade.id_categoriemalade
 INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id=malade.id_etablissement
 INNER JOIN personne ON malade.id_personne = personne.id 
 WHERE sortie.date BETWEEN '10/08/15' AND '01/11/15' AND hospitalisation.datefin BETWEEN '10/08/15' AND '01/11/15'
 
  --Medicaments pris pour malade non hospitalisé
 SELECT malade.numero_fiche,personne.nom + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS nom,article.desination,article.pu,article.caracteristique,sortie.date,sortie.quantinte,sortie.etatpaiement,categoriemalade.designation,etablissementpriseencharge.denomination,hospitalisation.etatpaiement AS etatPaiement_Hospitalisation,chambre.designation + ' N° ' + CONVERT(VARCHAR(20),chambre.numero) AS chambre FROM sortie 
 INNER JOIN article ON article.id=sortie.id_article
 LEFT OUTER JOIN malade ON malade.id = sortie.id_malade 
 INNER JOIN hospitalisation ON malade.id=hospitalisation.id_malade
 INNER JOIN chambre ON chambre.id=hospitalisation.id_chambre
 INNER JOIN categoriemalade ON categoriemalade.id=malade.id_categoriemalade
 INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id=malade.id_etablissement
 INNER JOIN personne ON malade.id_personne = personne.id 
 WHERE sortie.date BETWEEN '10/08/15' AND '01/11/15' AND (SELECT hospitalisation.id_malade WHERE hospitalisation.datefin BETWEEN '10/08/15' AND '01/11/15') IS NULL--)NOT IN(SELECT id_malade FROM hospitalisation WHERE hospitalisation.datefin BETWEEN '10/08/15' AND '01/11/15'))
  
  
 SELECT malade.numero_fiche,personne.nom + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS nom,article.desination,article.pu,article.caracteristique,sortie.date,sortie.quantinte,sortie.etatpaiement,categoriemalade.designation,etablissementpriseencharge.denomination,hospitalisation.etatpaiement AS etatPaiement_Hospitalisation,chambre.designation + ' N° ' + CONVERT(VARCHAR(20),chambre.numero) AS chambre FROM sortie 
 INNER JOIN article ON article.id=sortie.id_article
 INNER JOIN malade ON malade.id = sortie.id_malade 
 INNER JOIN hospitalisation ON malade.id=hospitalisation.id_malade
 INNER JOIN chambre ON chambre.id=hospitalisation.id_chambre
 INNER JOIN categoriemalade ON categoriemalade.id=malade.id_categoriemalade
 INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id=malade.id_etablissement
 INNER JOIN personne ON malade.id_personne = personne.id 
 WHERE sortie.date BETWEEN '10/08/15' AND '01/11/15'







