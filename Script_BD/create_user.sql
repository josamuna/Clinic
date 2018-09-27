exec sp_addlogin 'josue','pwd','gestionclinic' --Cree un login
go
exec sp_grantdbaccess 'josue'--L'attribution du login au role de connexion du serveur cré l'utilisateur
go

exec sp_addlogin 'p','p','gestionclinic' --Cree un login
go
exec sp_grantdbaccess 'p'--L'attribution du login au role de connexion du serveur cré l'utilisateur
go

alter LOGIN josue WITH PASSWORD = 'jo';--Modification du mot de passe en modifiant le login
go

--alter user josue with name=jos
go
--exec sp_grantdbaccess 'jos'
alter login josue with name=jos; --Modification du nom d'utilisateur en modifiant selement son login
go

go
exec sp_dropuser 'josue'
exec sp_droplogin 'josue'

exec sp_dropuser 'p'
exec sp_droplogin 'p'

drop schema josue  --Suppression de l'utilisateur en supprimant d'abord son schema,puis son user et enfin son login
drop user josue 
drop login josue



--Droit serveur
--commandesql.CommandText = "sp_addsrvrolemember '" + cmbuser.Text.Trim() + "','sysadmin'";//Administrateur du serveur
--commandesql.CommandText = "sp_addsrvrolemember '" + cmbuser.Text.Trim() + "','securityadmin'";//Gestion des connexions au serveur
--commandesql.CommandText = "sp_addsrvrolemember '" + cmbuser.Text.Trim() + "','dbcreator'";//créer ou modifier les BD


--commandesql.CommandText = "  sp_addrolemember 'db_owner', '" + cmbuser.Text + "'";//Tous les droits: Proprietaire de la BD
--commandesql.CommandText = "  sp_addrolemember 'db_ddladmin', '" + cmbuser.Text + "'";//Operation sur les objets de la bd
--commandesql.CommandText = "  sp_addrolemember 'db_accessadmin', '" + cmbuser.Text + "'";//Creer des utilisateur et roles


--commandesql.CommandText = "sp_grantdbaccess'" + cmbuser.Text.Trim() + "'";//Droit de connexio au serveur

select schema_user from utilisateur

GO
CREATE USER josue FOR LOGIN josue 
GO
GRANT 

DROP LOGIN josue
DROP USER josue




grant connect to josue


revoke select,insert,delete,update to test2
go
drop schema josue
drop user jos
drop login jos
go


alter LOGIN josue WITH PASSWORD = 'jo'



SELECT DB_NAME() AS bd_encours
revoke select,insert,delete on dbo.personne to test2

exec sp_addsrvrolemember '','@@VERSION' 
 select * from Sys.server_permissions
 select * from Sys.database_permissions
 
 create table test
 (
	id int,
	designation varchar(20)
 )
 SELECT SYSTEM_USER, SESSION_USER, CURRENT_USER
 
 GRANT select,insert,update,delete ON dbo.tempStock
 TO testrole
 
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.tempStock 
TO testrole

--Attribution droits au role
GRANT SELECT,INSERT,UPDATE,DELETE ON dbo.test
TO testrole
 
 drop role testrole
 
 
 --Affectation role à l'utlisateur
 GRANT ROLE testrole TO test2

 go
 
 --Creation role
CREATE ROLE testrole
AUTHORIZATION dbo

GRANT testrole ON dbo.tempStock to josue
 
