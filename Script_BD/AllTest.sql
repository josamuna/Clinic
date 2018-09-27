SELECT     SUM(dbo.article.pu) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
       FROM         dbo.article INNER JOIN
                             dbo.sortie ON dbo.sortie.id_article = dbo.article.id LEFT OUTER JOIN
                             dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                              hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                              dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE     (dbo.sortie.etatpaiement = 'Payé') and (convert(date,sortie.date,100)='03/08/2015') and (hospitalisation.id_malade not in (select hospitalisation.id_malade where (convert(date,hospitalisation.datefin,100)='03/08/2015'))) and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
       
       
SELECT     SUM(dbo.article.pu) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
       FROM         dbo.article INNER JOIN
                             dbo.sortie ON dbo.sortie.id_article = dbo.article.id LEFT OUTER JOIN
                             dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                              hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                              dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE     (dbo.sortie.etatpaiement = 'Payé') and (convert(date,sortie.date,100)='03/08/2015') and  (hospitalisation.id_malade not in (select hospitalisation.id_malade where (convert(date,hospitalisation.datefin,100) between '03/08/2015' and '03/08/2015'))) and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
                   