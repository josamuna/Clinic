--Vues � supprimer et r�cr�er apr�s MAJ 21h45
drop view RenseignementMalade

--Vues � supprimer en permanence
--vConsommationAbonn�=>vEntrepriseInterneAbonne
drop view vConsommationAbonn�
--vConsommationNonAbonn�=>vConsommationNonAbonneInterne
drop view vConsommationNonAbonn�
--vConsommationExterne=>vRecetteJournaliereAbonneInterne     
drop view vConsommationInterne
--rConsommation=>vRecetteGlobaleAbonneInterneExterne


--Vues � ajouter
create view vEntrepriseExterneAbonne
create view vConsommationNonAbonneExterne
create view vRecetteJournaliereAbonneInterne
create view vRecetteJournaliereNonAbonneInterne
create view vRecetteJournaliereAbonneExterne
create view vRecetteJournaliereNonAbonneExterne
create view vRecetteGlobaleNonAbonneInterneExterne