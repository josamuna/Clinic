 
---- ----Abonne et Non Abonné pour medicament seulement                                 
--SELECT DISTINCT facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,personne.sexe,malade.numero, categoriemalade.designation AS TypeMalade, categoriemalade.taux, etablissementpriseencharge.denomination,facturation.numero_facture, 
--facturation.id_malade,(SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
--                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--                                    where facturation.id_malade=4 and convert (date,facturation.date,100)='04/09/2014' and facturation.ismedicament=1 AND facturation.solde=0
-- GROUP BY categoriemalade.taux) AS medicament,(SELECT SUM(facturation.montantmituelle)
--                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--                                    where facturation.id_malade=4 and convert (date,facturation.date,100)='04/09/2014' and facturation.ismedicament=1 AND facturation.solde=0
-- GROUP BY categoriemalade.taux) AS mituelle,(SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
--                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--                                    where facturation.id_malade=4 and convert (date,facturation.date,100)='04/09/2014' and facturation.ismedicament=1 AND facturation.solde=0
-- GROUP BY categoriemalade.taux) AS TotGen
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
--                            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=4 and convert (date,facturation.date,100)='04/09/2014' and facturation.ismedicament=1 AND facturation.solde=0

------------ --Non Abonne pour medicament                                   
------------SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2) AS medicament,SUM(facturation.montantmituelle) AS mituelle,ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2) AS TotGen
------------                                   FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
------------                                                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
------------                                                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
------------                                                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
------------                                    where facturation.id_malade=4 and convert (date,facturation.date,100)='04/09/2014' and facturation.ismedicament=1
------------ GROUP BY categoriemalade.taux
 
-- -----Abonné et Non abonné pour autres articles seulement
-- SELECT facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu, facturation.avance,ROUND(facturation.dette,2) AS dette,
--               facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
--               malade.numero, categoriemalade.designation AS TypeMalade, categoriemalade.taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=6 and convert (date,facturation.date,100)='04/09/2014' and facturation.ismedicament=0 GROUP BY categoriemalade.taux) - (SELECT ROUND(SUM(facturation.montantmituelle),2)
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=4 and convert (date,facturation.date,100)='04/09/2014' and facturation.ismedicament=0 AND facturation.solde=0 GROUP BY categoriemalade.taux)) AS TotGen,(SELECT ROUND(SUM(facturation.montantmituelle),2)
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=4 and convert (date,facturation.date,100)='04/09/2014' and facturation.ismedicament=0 AND facturation.solde=0 GROUP BY categoriemalade.taux) AS mituelle
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
--                            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=4 and convert (date,facturation.date,100)  = '04/09/2014' and facturation.ismedicament=0 AND facturation.solde=0 
--------GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.personne.sexe, dbo.categoriemalade.designation, dbo.categoriemalade.taux, 
--------dbo.etablissementpriseencharge.denomination, dbo.malade.numero, dbo.facturation.designation, dbo.facturation.date, dbo.facturation.pu, dbo.facturation.avance, 
--------dbo.facturation.dette, dbo.facturation.montantmituelle, dbo.facturation.quantite, dbo.facturation.id_malade, dbo.facturation.numero_facture

--------Touts les article pour abonné et non abonné
--SELECT facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu, facturation.avance,ROUND(facturation.dette,2) AS dette,
--               facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
--               malade.numero, categoriemalade.designation AS TypeMalade, categoriemalade.taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,(SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=6 and convert (date,facturation.date,100)='04/09/2014' and facturation.ismedicament=1 AND facturation.solde=0 GROUP BY categoriemalade.taux) AS medicament,((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=6 and convert (date,facturation.date,100)='04/09/2014' and facturation.ismedicament=0 AND facturation.solde=0 GROUP BY categoriemalade.taux) + (SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=6 and convert (date,facturation.date,100)='04/09/2014' and facturation.ismedicament=1 AND facturation.solde=0 GROUP BY categoriemalade.taux) - (SELECT ROUND(SUM(facturation.montantmituelle),2)
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=6 and convert (date,facturation.date,100)='04/09/2014' AND facturation.solde=0  GROUP BY categoriemalade.taux)) AS TotGen,(SELECT ROUND(SUM(facturation.montantmituelle),2)
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=6 and convert (date,facturation.date,100)='04/09/2014' AND facturation.solde=0  GROUP BY categoriemalade.taux) AS mituelle
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
--                            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=6 and convert (date,facturation.date,100)  = '04/09/2014' and facturation.ismedicament=0 AND facturation.solde=0 
------------GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.personne.sexe, dbo.categoriemalade.designation, dbo.categoriemalade.taux, 
------------dbo.etablissementpriseencharge.denomination, dbo.malade.numero, dbo.facturation.designation, dbo.facturation.date, dbo.facturation.pu, dbo.facturation.avance, 
------------dbo.facturation.dette, dbo.facturation.montantmituelle, dbo.facturation.quantite, dbo.facturation.id_malade, dbo.facturation.numero_facture

--Test
--SELECT facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu, facturation.avance,ROUND(facturation.dette,2) AS dette,
--               facturation.quantite,facturation.pu*facturation.quantite*categoriemalade.taux AS PT,personne.sexe, 
--               malade.numero, categoriemalade.designation AS TypeMalade, categoriemalade.taux, etablissementpriseencharge.denomination, facturation.id_malade,facturation.numero_facture,(SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=4 and convert (date,facturation.date,100)='04/09/2014' and facturation.ismedicament=1 AND facturation.solde=0 GROUP BY categoriemalade.taux) AS medicament,((SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=4 and convert (date,facturation.date,100)='04/09/2014' and facturation.ismedicament=0 AND facturation.solde=0 GROUP BY categoriemalade.taux) + (SELECT ROUND(SUM(facturation.pu*facturation.quantite)*categoriemalade.taux,2)
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=4 and convert (date,facturation.date,100)='04/09/2014' and facturation.ismedicament=1 AND facturation.solde=0 GROUP BY categoriemalade.taux) - (SELECT ROUND(SUM(facturation.montantmituelle),2)
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=4 and convert (date,facturation.date,100)='04/09/2014' AND facturation.solde=0 GROUP BY categoriemalade.taux)) AS TotGen,(SELECT ROUND(SUM(facturation.montantmituelle),2)
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=4 and convert (date,facturation.date,100)='04/09/2014' AND facturation.solde=0 GROUP BY categoriemalade.taux) AS mituelle
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
--                            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            where facturation.id_malade=4 and convert (date,facturation.date,100)  = '04/09/2014' and facturation.ismedicament=0 AND facturation.solde=0 

----Facture mensuelle pour mituelle                      
SELECT facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu,facturation.quantite,facturation.montantmituelle,personne.sexe, 
               malade.numero,etablissementpriseencharge.id AS idEtablissement,malade.id,facturation.numero_facture,etablissementpriseencharge.denomination, (SELECT ROUND(SUM(facturation.montantmituelle),2)
           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            WHERE MONTH(facturation.date)=(SELECT DISTINCT MONTH(facturation.date) from facturation WHERE convert(date,facturation.date,100)='04/09/2014') and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND etablissementpriseencharge.denomination='CARMEL' AND facturation.soldemituelle=0) AS mituelle
           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement=etablissementpriseencharge.id
            WHERE MONTH(facturation.date)=(SELECT DISTINCT MONTH(facturation.date) from facturation WHERE convert(date,facturation.date,100)='04/09/2014') and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND facturation.soldemituelle=0 AND etablissementpriseencharge.denomination='CARMEL'
-- UNION
            
--(SELECT facturationmituelle.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturationmituelle.avance, facturationmituelle.date, facturationmituelle.dette,facturationmituelle.dette,facturationmituelle.id_paiement,personne.sexe, 
--               malade.numero,etablissementpriseencharge.id AS idEtablissement,malade.id,facturationmituelle.numero_facture,etablissementpriseencharge.denomination, (SELECT ROUND(SUM(facturationmituelle.montantpaye),2)
--   FROM facturationmituelle INNER JOIN malade ON facturationmituelle.id_malade = malade.id 
--                LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id
--                LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--    WHERE MONTH(facturationmituelle.date)=(SELECT DISTINCT MONTH(facturationmituelle.date) from facturationmituelle WHERE convert(date,facturationmituelle.date,100)='04/09/2014') AND etablissementpriseencharge.denomination='CARMEL') AS mituelle
--   FROM facturationmituelle INNER JOIN malade ON facturationmituelle.id_malade = malade.id
--                    LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                    LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                    LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement=etablissementpriseencharge.id
--    WHERE MONTH(facturationmituelle.date)=(SELECT DISTINCT MONTH(facturationmituelle.date) from facturationmituelle WHERE convert(date,facturationmituelle.date,100)='04/09/2014') AND etablissementpriseencharge.denomination='CARMEL'

-----Facturation pour mituelle suivant une echéance de date
--SELECT facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.designation, facturation.date, facturation.pu,facturation.quantite,facturation.montantmituelle,personne.sexe, 
--               malade.numero,etablissementpriseencharge.id AS idEtablissement,malade.id,facturation.numero_facture,etablissementpriseencharge.denomination, (SELECT ROUND(SUM(facturation.montantmituelle),2)
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
--                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
--            WHERE facturation.date BETWEEN '04/09/2014' AND '04/09/2014' and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND etablissementpriseencharge.denomination='CARMEL' AND facturation.soldemituelle=0) AS mituelle
--           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
--                            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
--                            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
--                            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement=etablissementpriseencharge.id
--            WHERE facturation.date BETWEEN '04/09/2014' AND '04/09/2014' and (facturation.ismedicament=0 OR facturation.ismedicament=1) AND facturation.soldemituelle=0 AND etablissementpriseencharge.denomination='CARMEL'

--                      SELECT DISTINCT MONTH(facturation.date) from facturation WHERE convert(date,facturation.date,100)='04/09/2014'
--------------select facturation.date,etablissementpriseencharge.id,facturation.id_malade
--------------						from facturation
--------------						LEFT OUTER JOIN malade ON malade.id=facturation.id_malade
--------------						RIGHT OUTER JOIN etablissementpriseencharge ON etablissementpriseencharge.id=malade.id_etablissement 
--------------						where etablissementpriseencharge.denomination='CARMEL' group by facturation.date,facturation.id_malade,etablissementpriseencharge.id

select facturation.date, facturation.id_malade
						from facturation
						where facturation.id_malade=6 group by facturation.date,facturation.id_malade
						
						SELECT *  FROM etablissementpriseencharge WHERE denomination!='Privée' AND denomination!='privée' AND denomination!='Privee' AND denomination!='Prive' AND denomination!='prive'
