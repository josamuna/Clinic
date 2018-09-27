SELECT     ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS nom, facturation.designation, facturation.date, facturation.pu, facturation.avance,ROUND(facturation.dette,2) AS dette,ROUND(facturation.montantmituelle,2) AS mituelle,facturation.quantite,facturation.pu*facturation.quantite AS PT,personne.sexe, 
                      malade.numero, categoriemalade.designation AS TypeMalade, categoriemalade.taux, etablissementpriseencharge.denomination, 
                      facturation.id_malade
FROM       facturation INNER JOIN
                      malade ON facturation.id_malade = malade.id LEFT OUTER JOIN
                      personne ON malade.id_personne = personne.id LEFT OUTER JOIN
                      categoriemalade ON malade.id_categoriemalade = categoriemalade.id LEFT OUTER JOIN
                      etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                      GROUP BY personne.nom,personne.postnom,personne.prenom,personne.sexe,categoriemalade.designation,categoriemalade.taux,etablissementpriseencharge.denomination,malade.numero,facturation.designation,facturation.date,facturation.pu,facturation.avance,facturation.dette,facturation.montantmituelle,facturation.quantite,facturation.id_malade