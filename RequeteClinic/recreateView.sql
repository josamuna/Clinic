--Vues à supprimer et récréer après MAJ 21h45
drop view RenseignementMalade

--Vues à supprimer en permanence
--vConsommationAbonné=>vEntrepriseInterneAbonne
drop view vConsommationAbonné
--vConsommationNonAbonné=>vConsommationNonAbonneInterne
drop view vConsommationNonAbonné
--vConsommationExterne=>vRecetteJournaliereAbonneInterne     
drop view vConsommationInterne
--rConsommation=>vRecetteGlobaleAbonneInterneExterne


--Vues à ajouter
create view vEntrepriseExterneAbonne
create view vConsommationNonAbonneExterne
create view vRecetteJournaliereAbonneInterne
create view vRecetteJournaliereNonAbonneInterne
create view vRecetteJournaliereAbonneExterne
create view vRecetteJournaliereNonAbonneExterne
create view vRecetteGlobaleNonAbonneInterneExterne