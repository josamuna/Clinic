--drop database gestionclinic
create database gestionclinic
go
use gestionclinic
go

---------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------
--------Triage-------------------------------------------------------------------------------------------------------
create table fonction
(
	id int identity,
	designation varchar(100) not null,
	constraint pk_fonction primary key(id),
	constraint uk_fonction_designation unique(designation)
)
go

create table qualification
(
	id int identity,
	designation varchar(50) not null,
	constraint pk_qualification primary key(id),
	constraint uk_qualification_designation unique(designation)
)
go

create table profession
(
	id int identity,
	designation varchar(100) not null,
	constraint pk_profession primary key(id),
	constraint uk_profession_designation unique(designation)
)
go

create table personne
(
	id int identity,
	nom varchar(30) not null,
	postnom varchar(40),
	prenom varchar(30),
	sexe varchar(1) default 'M',
	etatcivil varchar(15) default 'Celibataire',
	datenaissance smalldatetime,
	telephone varchar(100),
	adresse varchar(300),
	photo image,
	constraint pk_personne primary key(id)
)
go
 
 create table categorieagent
(
	id int identity,
	designation varchar(50) not null,
	constraint pk_categorieagent primary key(id)
)
go 

--Pharmacie
create table service
(
	id int identity,
	designation varchar(100) not null,
	constraint pk_service primary key(id)
)
go

create table agent
(
	id int identity,
	id_personne int not null,
	id_categorieagent int not null,
	id_fonction int not null,
	id_qualification int not null,
	id_service int not null,
	matricule varchar(20),
	grade varchar(30),
	dateangagement smalldatetime default GETDATE(),
	numeroinss varchar(20)
	constraint pk_agent primary key(id),
	constraint fk_agent_id_fonction foreign key(id_fonction) references fonction(id),
	constraint fk_agent_id_categorieagent foreign key(id_categorieagent) references categorieagent(id),
	constraint fk_agent_id_qualification foreign key(id_qualification) references qualification(id),
	constraint fk_agent_id_personne foreign key(id_personne) references personne(id), 
	constraint fk_agent_id_service foreign key(id_service) references service(id), 	
	constraint uk_agent_id_personne unique(id_personne)
)
go
create table airsante
(
	id int identity,
	designation varchar(100) not null,
	constraint pk_airSante primary key(id)
)
go

create table etablissementpriseencharge
(
	id int identity,
	denomination varchar(100) not null,
	adresse varchar(100),
	telephone varchar(14),
	taux float,
	constraint pk_etablissementpriseencharge primary key(id),
	constraint uk_entreprise unique(denomination)
)
go

create table etablissementexterne
(
	id int identity,
	denomination varchar(100) not null,
	adresse varchar(100),
	telephone varchar(14),
	constraint pk_etablissementexterne primary key(id),
	constraint uk_entrepriseexterne unique(denomination)
)
go

--Insertion de l'entreprise privée
INSERT INTO etablissementpriseencharge(denomination,adresse,telephone,taux) 
VALUES('Privée','Aucune','Aucun',1)

create table categoriemalade
(
	id int identity,
	designation varchar(100) not null,
	taux float not null,
	constraint pk_categorie primary key(id)
)
go

INSERT INTO categoriemalade(designation,taux) VALUES('Abonné',1.2)
INSERT INTO categoriemalade(designation,taux) VALUES('Non abonné',1)

create table groupesanguin
(
	id int identity,
	designation varchar(50) not null,
	constraint pk_groupesanguin primary key(id),
	constraint uk_groupesanguin unique(designation)
)
go

create table malade
(
	id int identity,
	id_personne int not null,
	id_categoriemalade int not null,
	id_etablissement int not null,
	id_airsante int not null,
	id_profession int not null,
	id_groupesanguin int not null,
	numero varchar(20),
	numero_fiche varchar(30) DEFAULT 'Non Attribué',
	constraint pk_malade primary key(id),
	constraint fk_malade_id_categorie foreign key(id_categoriemalade) references categoriemalade(id),
	constraint fk_malade_id_etablissement foreign key(id_etablissement) references etablissementpriseencharge(id),
	constraint fk_malade_id_profession foreign key(id_profession) references profession(id),
	constraint fk_malade_id_personne foreign key(id_personne) references personne(id),
	constraint fk_malade_id_airsante foreign key(id_airsante) references airsante(id), 
	constraint fk_malade_id_groupesanguin foreign key(id_groupesanguin) references groupesanguin(id),
	constraint uk_malade_id_personne unique(id_personne),
	constraint uk_numero unique(numero)
)
go
create table tarifconsultationgynecologique
(
	id int identity,
	designation varchar(100) not null,
	montant float,
	constraint pk_tarifconsultationgynecologique primary key(id),
	constraint uk_designation_tarifconsultationgynecologique unique(designation)
)
go
create table dossierconsultationgynecologique
(
	id int identity,
	date smalldatetime default GETDATE(),
	id_malade int not null,
	id_agent int not null,
	id_tarifconsultationgynecologique int not null,
	etatpaiement varchar(50),
	constraint pk_dossierconsultationgynecologique primary key(id),
	constraint fk_dossierconsultationgynecologique_id_malade foreign key(id_malade) references malade(id),
	constraint fk_dossierconsultationgynecologique_id_tarifconsultationgynecologique foreign key(id_tarifconsultationgynecologique) references tarifconsultationgynecologique(id),
	constraint fk_dossierconsultationgynecologique_id_agent foreign key(id_agent) references agent(id)
)
go
create table maladiegynecologique
(
	id int identity,
	designation varchar(20) not null,
	constraint pk_maladiegynecologique primary key(id),
	constraint uk_designation_maladiegynecologique unique(designation)
)
go

create table criterechographie
(
	id int identity,
	designation varchar(100) not null,
	constraint pk_criterechographie primary key(id)
)
go

create table consultationgynecologique
(
	id int identity,
	ddr smalldatetime default GETDATE(),
	dpa smalldatetime default GETDATE(),
	date_consultation smalldatetime default GETDATE(),
	id_critere_echo int ,
	id_dossierconsultationgyneco int not null,
	examengyneco varchar(500),
	diagnostic varchar(500),
	constraint pk_consultationgynecologie primary key(id),
	constraint fk_criteregyneco_consultationgynecologique foreign key(id_critere_echo) references criterechographie(id),
	constraint fk_id_dossierconsultationgyneco foreign key(id_dossierconsultationgyneco) references dossierconsultationgynecologique(id)
)
go

create table mouvementmaladiegynecologique
(
	id int identity,
	id_maladie int not null,
	id_consultationgynecologique int not null,
	date smalldatetime default GETDATE(),
	constraint pk_mouvementmaladiegynecologique primary key(id),
	constraint fk_mouvementmaladiegynecologique_id_maladie foreign key(id_maladie) references maladiegynecologique(id),
	constraint fk_mouvementmaladiegynecologique_id_mouvementconsultation foreign key(id_consultationgynecologique) references consultationgynecologique(id)
)
go

create table tarifpreconsultation
(
	id int identity,
	designation varchar(100) not null,
	montant float,
	constraint pk_tarifpreconsultation primary key(id),
	constraint uk_designation_tarifpreconsultation unique(designation)
)
go

create table dossierpreconsultation
(
	id int identity,
	date smalldatetime default GETDATE(),
	id_malade int not null,
	id_tarifpreconsultation int not null,
	etatpaiement varchar(50),
	cumul float default 0,
	constraint pk_dossierpreconsultation primary key(id),
	constraint fk_preconsultation_id_malade foreign key(id_malade) references malade(id),
	constraint fk_preconsultation_id_tarifpreconsultation foreign key(id_tarifpreconsultation) references tarifpreconsultation(id)
)
go

create table fichesupplementaire
(
	id int identity,
	date smalldatetime default GETDATE(),
	id_dossierpreconsultation int not null,
	id_tarifpreconsultation int not null,
	etatpaiement varchar(50),
	montant float not null,
	constraint pk_fichesupplementaire primary key(id),
	constraint fk_fichesupplementaire_id_dossierpreconsultation foreign key(id_dossierpreconsultation) references dossierpreconsultation(id),
	constraint fk_fichesupplementaire_id_tarifpreconsultation foreign key(id_tarifpreconsultation) references tarifpreconsultation(id)
)
go

create table preconsultation
(
	id int identity,
	id_dossierpreconsultation int not null,
	poid float,
	temperature float,
	pressionArterielle varchar(30),
	pouls int,
	taille float,
	observation varchar(3000),
	datePrecons smalldatetime default GETDATE(),
	constraint pk_preconsultation primary key(id),
	constraint fk_preconsultation_id_dossierpreconsultation foreign key(id_dossierpreconsultation) references dossierpreconsultation(id)
)
go

--Aptitude Physique
create table province
(
	id int identity,
	designation varchar(100) not null,
	constraint pk_province primary key(id),
	constraint uk_province_designation unique(designation)
)
go

create table districtville
(
	id int identity,
	designation varchar(100) not null,
	constraint pk_districtville primary key(id),
	constraint uk_districtville_designation unique(designation)
)
go

create table territoirecommune
(
	id int identity,
	designation varchar(100) not null,
	constraint pk_territoirecommune primary key(id),
	constraint uk_territoirecommune_designation unique(designation)
)
go

create table collectivitequartier
(
	id int identity,
	designation varchar(100) not null,
	constraint pk_collectivitequartier primary key(id),
	constraint uk_collectivitequartier_designation unique(designation)
)
go

create table aptitudephysique
(
	id int identity,
	id_province int not null,
	id_districtville int not null,
	id_territoirecommune int not null,
	id_collectivitequartier int not null,
	id_personne int not null,
	age int not null,
	taille float not null,
	poid float not null,
	perimetrethoracique float not null,
	quotientvervaeck float not null,
	indicepigment float not null,
	remarque varchar(3000),
	dateexamen smalldatetime default GETDATE(),
	constraint pk_aptitudephysique primary key(id),
	constraint fk_aptitudephysique_id_province foreign key(id_province) references province(id),
	constraint fk_aptitudephysique_id_districtville foreign key(id_districtville) references districtville(id),
	constraint fk_aptitudephysique_id_territoirecommune foreign key(id_territoirecommune) references territoirecommune(id),
	constraint fk_aptitudephysique_id_collectivitequartier foreign key(id_collectivitequartier) references collectivitequartier(id),
	constraint fk_aptitudephysique_id_personne foreign key(id_personne) references personne(id)
)
go

-------------------------------------------------------------------------------------
---------------SOIN------------------------------------------------------------------
-------------------------------------------------------------------------------------
create table tarifsoin
(
	id int identity,
	designation varchar(100) not null,
	montant float,
	constraint pk_tarifsoin primary key(id),
	constraint uk_designation_tarifsoin unique(designation)
)
go

create table dossiersoin
(
	id int identity,
	date smalldatetime default GETDATE(),
	id_malade int not null,
	id_agent int not null,
	id_tarifsoin int not null,
	etatpaiement varchar(50),
	constraint pk_dossiersoin primary key(id),
	constraint fk_dossiersoin_id_malade foreign key(id_malade) references malade(id),
	constraint fk_dossiersoin_id_tarifsoin foreign key(id_tarifsoin) references tarifsoin(id),
	constraint fk_dossiersoin_id_agent foreign key(id_agent) references agent(id)
)
go

-------------------------------------------------------------------------------------
---------------NURSING------------------------------------------------------------------
-------------------------------------------------------------------------------------
create table tarifnursing
(
	id int identity,
	designation varchar(100) not null,
	montant float,
	constraint pk_tarifnursing primary key(id),
	constraint uk_designation_tarifnursing unique(designation)
)
go

create table dossiernursing
(
	id int identity,
	date smalldatetime default GETDATE(),
	id_malade int not null,
	id_agent int not null,
	id_tarifnursing int not null,
	etatpaiement varchar(50),
	constraint pk_dossiernursing primary key(id),
	constraint fk_dossiernursing_id_malade foreign key(id_malade) references malade(id),
	constraint fk_dossiernursing_id_tarifnursing foreign key(id_tarifnursing) references tarifnursing(id),
	constraint fk_dossiernursing_id_agent foreign key(id_agent) references agent(id)
)
go

-------------------------------------------------------------------------------------
---------------ECHOGRAPHIE------------------------------------------------------------------
-------------------------------------------------------------------------------------
create table tarifechographie
(
	id int identity,
	designation varchar(100) not null,
	montant float,
	constraint pk_tarifechographie primary key(id),
	constraint uk_designation_tarifechographie unique(designation)
)
go

create table dossierechographie
(
	id int identity,
	date smalldatetime default GETDATE(),
	id_malade int not null,
	id_agent int not null,
	id_tarifechographie int not null,
	etatpaiement varchar(50),
	constraint pk_dossierechographie primary key(id),
	constraint fk_dossierechographie_id_malade foreign key(id_malade) references malade(id),
	constraint fk_dossierechographie_id_tarifechographie foreign key(id_tarifechographie) references tarifechographie(id),
	constraint fk_dossierechographie_id_agent foreign key(id_agent) references agent(id)
)
go

-------------------------------------------------------------------------------------
---------------AVANCE------------------------------------------------------------------
-------------------------------------------------------------------------------------
create table tarifavance
(
	id int identity,
	designation varchar(100) not null,
	montant float,
	constraint pk_tarifavance primary key(id),
	constraint uk_designation_tarifavance unique(designation)
)
go

create table dossieravance
(
	id int identity,
	date smalldatetime default GETDATE(),
	id_malade int not null,
	id_tarifavance int not null,
	etatpaiement varchar(50),
	constraint pk_dossieravance primary key(id),
	constraint fk_dossieravance_id_malade foreign key(id_malade) references malade(id),
	constraint fk_dossieravance_id_tarifavance foreign key(id_tarifavance) references tarifavance(id)
)
go

--Table servant de tempon pour affichage avance
create table tempAvance
(
	id_malade int,
	montant float,
	constraint fk_tempAvance_id_malade foreign key(id_malade) references malade(id)
)
go

insert into tempAvance values(null,220)
go

create table malade_avance
(
	id int identity,
	id_dossieravance int not null,
	id_malade int not null,
	date smalldatetime,
	avance float not null,
	montant float not null,
	cumul float not null,
	solde bit not null,
	constraint pk_malade_avance primary key(id),
	constraint fk_malade_avance_id_malade foreign key(id_malade) references malade(id),
	constraint fk_malade_avance_id_dossieravance foreign key(id_dossieravance) references dossieravance(id)
)
go

create table utilisateur
(
	id int identity,
	id_agent int not null,
	nomuser varchar(30) not null,
	motpass varchar(30) not null,
	schema_user varchar(100) not null,
	droits varchar(300) DEFAULT 'Aucun',
	activation bit,
	constraint pk_utilisateur primary key(id),
	constraint fk_utilisateur_id_agent foreign key(id_agent) references agent(id)
)
go

create table groupe
(
	id int identity,
	designation varchar(30) not null,
	niveau int,
	schema_user varchar(100),
	constraint pk_groupe primary key(id)
)
go

insert into groupe(designation,niveau) values('Administrateur',0)
insert into groupe(designation,niveau) values('Médecin',1)
insert into groupe(designation,niveau) values('Infirmier',2)
insert into groupe(designation,niveau) values('Laborantin',3)
insert into groupe(designation,niveau) values('Pharmacien',4)
insert into groupe(designation,niveau) values('Caissier',5)
insert into groupe(designation,niveau) values('Médecin gynéco.',6)
insert into groupe(designation,niveau) values('Service',7)

go

create table utilisateur_groupe
(
	id int identity,
	id_utilisateur int not null,
	id_groupe int not null,
	constraint pk_utilisateur_groupe primary key(id),
	constraint fk_utilisateur_groupe_id_utilisateur foreign key(id_utilisateur) references utilisateur(id),
	constraint fk_utilisateur_groupe_id_groupe foreign key(id_groupe) references groupe(id)
)
go

---------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------
--------Consultation-----------------------------------------------------------------------------------------------------
create table evacuation
(
	id int identity,
	id_malade int not null,
	dateevacuation smalldatetime default GETDATE(),
	motif varchar(500),
	constraint pk_evacuation primary key(id),
	constraint fk_evacuation_id_malade foreign key(id_malade) references malade(id)
)
go

create table tarifconsultation
(
	id int identity,
	designation varchar(100) not null,
	montant float,
	constraint pk_tarifconsultation primary key(id),
	constraint pk_designation_tarifconsultation unique(designation)
)
go
create table consultation
(
	id int identity,
	date smalldatetime default GETDATE(),
	id_agent int not null,
	id_malade int not null,
	id_tarifconsultation int not null,
	etatpaiement varchar(50) not null,
	constraint pk_consultation primary key(id),
	constraint fk_consultation_id_agent foreign key(id_agent) references agent(id),
	constraint fk_consultation_id_malade foreign key(id_malade) references malade(id),
	constraint fk_consultation_id_tarifconsultation foreign key(id_tarifconsultation) references tarifconsultation(id)
)
go
create table allergie
(
	id int identity,
	designation varchar(50) not null,
	constraint pk_allergie primary key(id)
)
go

create table antecedentallergie
(
	id int identity,
	id_malade int not null,
	id_allergie int not null,
	commentaire varchar(50),
	constraint pk_antecedentallergie primary key(id),
	constraint fk_antecedentallergie_id_malade foreign key(id_malade) references malade(id),
	constraint fk_antecedentallergie_id_allergie foreign key(id_allergie) references allergie(id)
)
go

create table maladie
(
	id int identity,
	designation varchar(20) not null,
	constraint pk_maladie primary key(id),
	constraint uk_designation_maladie unique(designation)
)
go

create table antecedentmaladie
(
	id int identity,
	id_malade int not null,
	id_maladie int not null,
	commentaire varchar(50),
	constraint pk_antecedentmaladie primary key(id),
	constraint fk_antecedentmaladie_id_malade foreign key(id_malade) references malade(id),
	constraint fk_antecedentmaladie_id_maladie foreign key(id_maladie) references maladie(id)
)
go
create table mouvementconsultation
(
	id int identity,
	date smalldatetime default GETDATE(),
	id_consultation int not null,
	plainte varchar(3000),
	symptome varchar(3000),
	diagnostics varchar(3000),
	medicamentaprescrire varchar(3000), 
	Conduite varchar(3000),
	constraint pk_mouvementconsultation primary key(id),
	constraint fk_mouvementconsultation_id_consultation foreign key(id_consultation) references consultation(id)
)
go

create table examengynecoobsetrical
(
	id int identity,
	hu int,
	presentation int,
	bcf int,
	contractionuterine varchar(100),
	mfa varchar(100),
	exauspeculum varchar(100),
	colaspect varchar(100),
	tvcolefface int,
	tvcoldilate int,
	pochedeeaux varchar(100),
	dateheureruptrurecole smalldatetime default GETDATE(),
	aspectduliquide varchar(100),
	degreengagement varchar(100),
	appreciationdubassin varchar(100),
	id_mouvementconsultation int not null,
	constraint pk_examengynecoobsetrical primary key(id),
	constraint fk_examengynecoobsetrical_id_mouvementconsultation foreign key(id_mouvementconsultation) references mouvementconsultation(id)
)
go

create table mouvementmaladie
(
	id int identity,
	id_maladie int not null,
	id_mouvementconsultation int not null,
	date smalldatetime default GETDATE(),
	constraint pk_mouvementmaladie primary key(id),
	constraint fk_mouvementmaladie_id_maladie foreign key(id_maladie) references maladie(id),
	constraint fk_mouvementmaladie_id_mouvementconsultation foreign key(id_mouvementconsultation) references mouvementconsultation(id)
)
go

---------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------
--------CPN-----------------------------------------------------------------------------------------------------

create table maladegrosse
(
	id int identity,
	id_malade int not null,
	conjoin varchar(100),
	numeroregistre varchar(30) not null,
	constraint pk_maladegrosse primary key(id),
	constraint uk_maladegrosse_numeroregistre unique(numeroregistre),
	constraint fk_maladegrosse_id_malade foreign key(id_malade) references malade(id)
)
go

create table avortement
(
	id int identity not null,
	date smalldatetime default GETDATE(),
	id_maladegrosse int not null,
	constraint pk_avortement primary key(id),
	constraint fk_avortement_id_maladegrosse foreign key(id_maladegrosse) references maladegrosse(id)
)
go

create table delivrance
(
	id int identity,
	ocyticine10uim varchar(50),
	tractioncontroleducordon bit,
	massageuterinapredelivrance bit,
	delivranceartificiel smalldatetime default GETDATE(),
	plancenta varchar(100),
	aspect varchar(100),
	membranes varchar(200),
	hemoragie varchar(100),
	date smalldatetime default GETDATE(),
	id_maladeGrosse int not null,
	constraint pk_delivrance primary key(id),
	constraint fk_delivrance_id_maladegrosse foreign key(id_maladegrosse) references maladegrosse(id)
)
go
create table tarifconsultationprenatal
(
	id int identity,
	designation varchar(100) not null,
	montant float,
	constraint pk_tarifconsultationprenatal primary key(id),
	constraint pk_designation_tarifconsultationprenatal unique(designation)
)
go
create table dossierconsultationprenatale
(
	id int identity,
	date smalldatetime default GETDATE(),
	id_malade int not null,
	id_tarifconsultationprenatal int not null,
	id_agent int not null,
	etatpaiement varchar(50)not null,
	constraint pk_dossierconsultationprenatale primary key(id),
	constraint fk_dossierconsultationprenatale_id_tarifconsultationprenatal foreign key(id_tarifconsultationprenatal) references tarifconsultationprenatal(id),
	constraint fk_dossierconsultationprenatale_id_agent foreign key(id_agent) references agent(id),
	constraint fk_dossierconsultationprenatale_id_malade foreign key(id_malade) references malade(id)
)
go
create table consultationprenatal
(
	id int identity,
	ddr varchar(100),
	drp varchar(100),
	entecedent varchar(100),
	motif varchar(100),
	historiqueGrossesse varchar(100),
	gropeSanguin varchar(30),
	rh varchar(100),
	gesttte varchar(100),
	parite varchar(100),
	statuthemoglobique varchar(100),
	conseiller bit,
	testee bit,
	oedeme bit,
	conjoctivepalpebrale varchar(200),
	date smalldatetime,
	poid float not null,
	temperature float not null,
	pressionArterielle float not null,
	pouls int,
	taille float,
	id_maladeGrosse int not null,
	id_tarifconsultationprenatal int null,
	id_dossierconsultationprenatale int not null,
	constraint pk_consultationprenatal primary key(id),
	constraint fk_consultationprenatal_id_maladegrosse foreign key(id_maladegrosse) references maladegrosse(id),
	constraint fk_consultationprenatal_id_dossierconsultationprenatale foreign key(id_dossierconsultationprenatale) references dossierconsultationprenatale(id)
)
go

create table typeaccouchement
(
	id int identity,
	designation varchar(100) not null,
	prix float not null,
	constraint pk_typeaccouchement primary key(id)
)
go
create table dossieraccouchement
(
	id int identity,
	date smalldatetime default GETDATE(),
	id_malade int not null,
	id_typeaccouchement int not null,
	id_agent int not null,
	etatpaiement varchar(50) not null,
	constraint pk_dossieraccouchement primary key(id),
	constraint fk_dossieraccouchement_id_typeaccouchement foreign key(id_typeaccouchement) references typeaccouchement(id),
	constraint fk_dossieraccouchement_id_agent foreign key(id_agent) references agent(id),
	constraint fk_dossieraccouchement_id_malade foreign key(id_malade) references malade(id)
)
go
create table accouchement
(
	id int identity,
	lieu varchar(100),
	traitement varchar(100),
	bcg int,
	vat int,
	degree int,
	date smalldatetime default GETDATE(),
	--etatpaiement varchar(50) not null,
	id_maladegrosse int not null,
	id_typeaccouchement int not null,
	constraint pk_accouchement primary key(id),
	constraint fk_accouchement_id_maladegrosse foreign key(id_maladegrosse) references maladegrosse(id),
	constraint fk_accouchement_id_typeaccouchement foreign key(id_typeaccouchement) references typeaccouchement(id)
)
go
create table consellingettestrapide
(
	id int identity,
	rvtregine varchar(100),
	datedebutttt smalldatetime default GETDATE(),
	datedebuttravail smalldatetime default GETDATE(),
	heure smalldatetime default GETDATE(),
	id_consultationPrenatal int not null,
	constraint pk_consellingettestrapide primary key(id),
	constraint fk_consellingettestrapide_id_consultationprenatal foreign key(id_consultationprenatal) references consultationprenatal(id)
)
go

create table typesysteme
(
	id int identity,
	designation varchar(100) not null,
	constraint pk_typesysteme primary key(id)
)
go
create table mouvementsysteme
(
	id int identity,
	commentaire varchar(1000),
	id_consultationPrenatal int not null,
	id_typeSysteme int not null,
	constraint pk_mouvementsysteme primary key(id),
	constraint fk_mouvementsysteme_id_consultationprenatal foreign key(id_consultationprenatal) references consultationprenatal(id),
	constraint fk_mouvementsysteme_id_typesysteme foreign key(id_typesysteme) references typesysteme(id)
)
go

create table enfant
(
	id int identity,
	id_maladegrosse int not null,
	poid float,
	taille float,
	senn varchar(200),
	soinsDuCordo varchar(200),
	miseAusienDansHeurQuiSuitAccouchement bit,
	pc int,
	malformation varchar(20),
	constraint pk_enfant primary key(id),
	constraint fk_enfant_id_maladegrosse foreign key(id_maladegrosse) references maladegrosse(id)
)
go
create table entecedentmedicauxobsetricaux
(
	id int identity,
	nombreenfantvivant int,
	nombreenfantmort int,
	nombreenfantmordnee int,
	mortavant7jour int,
	datedernieraccouchement smalldatetime default GETDATE(),
	eutocine int,
	dynstocine int,
	nbrebebepoidssuperieura4 int,
	nbrebebepoidsinferieura4 int,
	nbregrossessemultiple int,
	id_consultationprenatal int not null,
	constraint pk_entecedentmedicauxobsetricaux primary key(id),
	constraint fk_entecedentmedicauxobsetricaux_id_consultationprenatal foreign key(id_consultationprenatal) references consultationprenatal(id)
)
go
---------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------
--------CPOS-----------------------------------------------------------------------------------------------------
create table tarifconsultationpostnatal
(
	id int identity,
	designation varchar(100) not null,
	montant float,
	constraint pk_tariftarifconsultationpostnatal primary key(id),
	constraint pk_designation_tarifconsultationpostnatal unique(designation)
)
go
create table dossierconsultationpostnatal
(
	id int identity,
	date smalldatetime default GETDATE(),
	id_malade int not null,
	id_tarifconsultationpostnatal int not null,
	id_agent int not null,
	etatpaiement varchar(50) not null,
	constraint pk_dossierconsultationpostnatal primary key(id),
	constraint fk_dossierconsultationpostnatal_id_tarifconsultationpostnatal foreign key(id_tarifconsultationpostnatal) references tarifconsultationpostnatal(id),
	constraint fk_dossierconsultationpostnatal_id_agent foreign key(id_agent) references agent(id),
	constraint fk_dossierconsultationpostnatal_id_malade foreign key(id_malade) references malade(id)
)
go
create table maladeenconsultationpostnatal
(
	id int identity,
	numeronaissance int not null,
	id_malade int not null,
	id_dossierconsultationpostnatal int not null,
	poidsnaisance float,
	lieunaissance varchar(50),
	nommere varchar(50),
	nompere varchar(50),
	date smalldatetime default GETDATE(),
	constraint pk_maladeenconsultationpostnatal primary key(id),
	constraint pk_maladeenconsultationpostnatal_id_malade foreign key(id_malade) references malade(id),
	constraint fk_maladeenconsultationpostnatal_id_dossierconsultationpostnatal foreign key(id_dossierconsultationpostnatal) references dossierconsultationpostnatal(id),
	constraint uk_numeroEnfant unique(numeronaissance)
)
go

create table attention
(
	id int identity,
	designation char(50),
	constraint pk_attention primary key(id)
)

go
create table attention_speciale
(
	id int identity,
	id_malade int not null,
	id_attention int not null,
	dort_sous_moust bit,
	constraint fk_attention_spciale_fiche_id_malade foreign key(id_malade) references maladeenconsultationpostnatal(id),
	constraint fk_attention_speciale_id_attention_speciale foreign key(id_attention) references attention(id),
	constraint pk_id_attention_speciale primary key(id)
)
go
create table suivicroissance
(
	id int identity,
	mois int,
	poid int,
	date smalldatetime default GETDATE(),
	id_maladeenconsultationpostnatal int not null,
	constraint pk_suivicroissance primary key(id),
	constraint fk_suivicroissance_id_malade foreign key(id_maladeenconsultationpostnatal) references maladeenconsultationpostnatal(id)
)
go
create table rendezvous
(
	id int identity,
	date smalldatetime default GETDATE(),
	observation varchar(100),
	id_maladeenconsultationpostnatal int,
	constraint pk_rendezvous primary key(id),
	constraint fk_rendezvous_id_malade foreign key(id_maladeenconsultationpostnatal) references maladeenconsultationpostnatal(id)
)
go

create table periode
(
	id int identity,
	designation varchar(50),
	constraint pk_periode primary key(id)
)
go

create table vitamine
(
	id int identity,
	designation varchar(50),
	constraint pk_vitamine primary key(id)
)
go
create table prise_vitamine
(
	id int identity,
	id_periode int,
	id_malade int,
	id_vitamine int,
	date_operation smalldatetime default GETDATE(),
	constraint fk_malade foreign key(id_malade)references maladeenconsultationpostnatal(id),
	constraint fk_periode foreign key(id_periode)references periode(id),
	constraint fk_vitamine foreign key(id_vitamine)references vitamine(id),
	constraint pk_prise_vitamine primary key(id)
)
go

create table periodevaccination
(
	id int identity,
	designation varchar(20) not null,
	constraint pk_periodevaccination primary key(id)
)
go

create table vaccin
(
	id int identity,
	designation varchar(20),
	constraint pk_vaccin primary key(id)
)
go
create table vaccination
(
	id int identity,
	date smalldatetime default GETDATE(),
	id_maladeenconsultationpostnatal int not null,
	id_periodevaccination int not null,
	id_prise_vitamine int,
	id_vaccin int,
	constraint pk_vaccination primary key(id),	
	constraint fk_vaccination_id_malade foreign key(id_maladeenconsultationpostnatal) references maladeenconsultationpostnatal(id),
	constraint fk_vaccination_id_periodevaccination foreign key(id_periodevaccination) references periodevaccination(id),
	constraint fk_vaccination_id_prise_vitamine foreign key(id_prise_vitamine) references prise_vitamine(id),
	constraint fk_vaccination_id_vaccin foreign key(id_vaccin) references vaccin(id)
)
go

-------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------
---Laboratiore
create table typeexamen
(
	id int identity,
	designation varchar(20) not null,
	constraint pk_typeexamen primary key(id),
	constraint uk_designation unique(designation)
)
go

create table examen
(
	id int identity,
	designation varchar(20) not null,
	id_typeexamen int not null,
	prix float,
	constraint pk_examen primary key(id),
	constraint fk_examen_id_typeexamen foreign key(id_typeexamen) references typeexamen(id),
	constraint uk_designation_examen unique(designation)
)
go

create table critereresultat
(
	id int identity,
	designation varchar(100) not null,
	constraint pk_critere primary key(id),
	constraint uk_critere_designation unique(designation)
)
go

create table operation_laboratoire
(
	id int identity,
	id_malade int not null,
	date smalldatetime default GETDATE(),
	id_examen int not null,
	etatpaiement varchar(50),
	constraint pk_operation_laboratoire primary key(id),
	constraint fk_operation_laboratoire_id_malade foreign key(id_malade) references malade(id),
	constraint fk_operation_laboratoire_id_examen foreign key(id_examen) references examen(id)
)
go

create table mouvementoperation_laboratoire
(
	id int identity,
	id_operation_laboratoire int not null,
	id_critere int not null,
	resultat varchar(100),
	date smalldatetime default GETDATE(),
	constraint pk_mouvementoperation_laboratoire primary key(id),
	constraint fk_mouvementoperation_laboratoire_id_operation_laboratoire foreign key(id_operation_laboratoire) references operation_laboratoire(id),
	constraint fk_mouvementoperation_laboratoire_id_critere foreign key (id_critere) references critereresultat(id)
)
go
---------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------
--------Pharmacie-----------------------------------------------------------------------------------------------------

create table fournisseur
(
	id int identity,
	id_personne int not null,
	numero varchar(20),
	constraint pk_fournisseur primary key(id),
	constraint fk_fournisseur_id_personne foreign key(id_personne) references personne(id),
	constraint uk_fournisseur_id_personne unique(id_personne),
	constraint uk_fournisseur unique(numero)
)
go

create table article
(
	id int identity,
	desination varchar(100) not null,
	pu float,
	caracteristique varchar(200),
	stock float not null,
	stock_alert int not null,
	fiche_supplementaire bit default 0,
	constraint pk_article primary key(id),
	constraint uk_article unique(desination)
)
go

--Table servant de tempon pour affichage totaux fiche de stock
--create table tempStock
--(
--	id_article int,
--	qte varchar(30),
--	pu_achat varchar(30),
--	pt_achat varchar(30),
--	qts varchar(30),
--	pu_vente varchar(30),
--	pt_vente varchar(30),
--	constraint fk_tempStock_article foreign key(id_article) references article(id)
--)
--go

--Table servant de tempon pour affichage totaux fiche de stock
create table tempStock
(
	id_article int,
	qte float,
	pu_achat float,
	pt_achat float,
	qts int,
	pu_vente float,
	pt_vente float,
	constraint fk_tempStock_article foreign key(id_article) references article(id)
)
go

--drop table tempStock
insert into tempStock values(null,null,null,null,null,null,null)
go

create table conditionnement
(
	id int identity,
	designation varchar(50) not null,
	constraint pk_conditionnement primary key(id),
	constraint uk_conditionnement unique(designation)
)

create table livraison
(
	id int identity,
	date smalldatetime default GETDATE(),
	quantinte int,
	puAchat float,
	dateexpiration smalldatetime,
	id_fournisseur int not null,
	id_article int not null,
	id_conditionnement int not null,
	stock_out int not null,
	constraint pk_livraison primary key(id),
	constraint fk_livraison_id_fournisseur foreign key(id_fournisseur) references fournisseur(id),
	constraint fk_livraison_id_article foreign key(id_article) references article(id),
	constraint fk_livraison_id_conditionnement foreign key(id_conditionnement) references conditionnement(id)
)

create table sortie
(
	id int identity,
	id_article int not null,
	id_service int,
	id_malade int,
	date smalldatetime default GETDATE(),
	quantinte int,
	montant float,
	sortiemalade bit not null,
	etatpaiement varchar(50) not null,
	stock_in int not null,
	constraint pk_sortie primary key(id),
	constraint fk_sortie_id_article foreign key(id_article) references article(id),
	constraint fk_sortie_id_service foreign key(id_service) references service(id),
	constraint fk_sortie_id_malade foreign key(id_malade) references malade(id)
)
go

create table sortiecancel
(
	id int identity,
	id_sortie int not null,
	id_article int not null,
	id_service int,
	id_malade int,
	date smalldatetime default GETDATE(),
	quantinte int,
	montant float,
	sortiemalade bit not null,
	etatpaiement varchar(50) not null,
	constraint pk_sortiecancel primary key(id),
	constraint fk_sortiecancel_id_sortie foreign key(id_sortie) references sortie(id),
	constraint fk_sortiecancel_id_article foreign key(id_article) references article(id),
	constraint fk_sortiecancel_id_service foreign key(id_service) references service(id),
	constraint fk_sortiecancel_id_malade foreign key(id_malade) references malade(id)
)
go
---------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------
--------Hospitalisation-----------------------------------------------------------------------------------------------------
create table bloc
(
	id int identity,
	designation varchar(100),
	id_service int,
	constraint pk_bloc primary key(id),
	constraint fk_bloc_id_service foreign key(id_service) references service(id)
)
go

create table intervention
(
	id int identity,
	designation varchar(100),
	prix float,
	id_bloc int not null,
	constraint pk_intervention primary key(id),
	constraint fk_intervention_id_bloc foreign key(id_bloc) references bloc(id)
)
go

create table categoriechambre
(
	id int identity,
	designation varchar(100) not null,
	prix float,
	constraint pk_categoriechambre primary key(id)
)
go

create table chambre
(
	id int identity,
	designation varchar(100) not null,
	numero float,
	id_categoriechambre int,
	constraint pk_chambre primary key(id),
	constraint fk_chambre_id_categoriechambre foreign key(id_categoriechambre) references categoriechambre(id)
)
go

create table hospitalisation
(
	id int identity,
	datedebut smalldatetime default GETDATE(),
	datefin smalldatetime default GETDATE(),
	id_malade int not null,
	id_chambre int not null,
	etatpaiement varchar(50) not null,
	constraint pk_hospitalisation primary key(id),
	constraint fk_hospitalisation_id_malade foreign key(id_malade) references malade(id),
	constraint fk_hospitalisation_id_chambre foreign key(id_chambre) references chambre(id), 
	constraint uk_hospitalisation_unique_chambre unique(id_chambre,id_malade,datefin) 
)
go

create table mvmhospitalisation
(
	id int identity,
	temperature int,
	date smalldatetime default GETDATE(),
	ta int,
	pls int,
	resiration varchar(50),
	id_hospitalisation int not null,
	constraint pk_mvmhospitalisation primary key(id),	
	constraint fk_mvmhospitalisation_id_hospitalisation foreign key(id_hospitalisation) references hospitalisation(id)
)
go

--create table autrefraie
--(
--	id int identity,
--	designation varchar(100) not null,
--	prix float not null,
--	constraint pk_autreFraie primary key(id)
--)
--go

create table autrefraie
(
	id int identity,
	id_etablissementexterne int not null,--id_etablissementexterne,id_malade,numerofacture,datepaiement,dateenregistrement,designation,prix,montant,etatpaiement
	id_malade int not null,
	numerofacture varchar(20) not null,
	datepaiement smalldatetime not null,
	dateenregistrement smalldatetime not null,
	montant float not null,
	etatpaiement varchar(50) not null,
	constraint pk_autrefraie primary key(id),
	constraint fk_autreFraie_etablissementexterne foreign key(id_etablissementexterne) references etablissementexterne(id),
	constraint fk_autreFraie_malade foreign key(id_malade) references malade(id)
)
go

create table detailsautrefraie
(
	id int identity,
	id_autrefraie int not null,
	designation varchar(100) not null,
	prix float not null,
	quantinte int not null,
	constraint pk_detailsautrefraie primary key(id),
	constraint fk_detailsautrefraie_autreFraie foreign key(id_autrefraie) references autrefraie(id),
	constraint uk_designation_detailsautrefraie unique(designation,id_autrefraie)
)
go

--create table sortieexterne
--(
--	id int identity,
--	id_autrefraie int not null,
--	id_malade int,
--	date smalldatetime default GETDATE(),
--	quantinte int,
--	montant float,
--	etatpaiement varchar(50) not null,
--	constraint pk_sortieexterne primary key(id),
--	constraint fk_sortieexterne_id_autrefraie foreign key(id_autrefraie) references autrefraie(id),
--	constraint fk_sortieexterne_id_malade foreign key(id_malade) references malade(id)
--)
--go

create table subit
(
	id int identity,
	date smalldatetime default GETDATE(),
	observation varchar(2000),
	id_malade int not null,
	id_intervention int not null,
	etatpaiement varchar(50) not null,
	constraint pk_subit primary key(id),
	constraint fk_subit_id_malade foreign key(id_malade) references malade(id),
	constraint fk_subit_id_intervention foreign key(id_intervention) references intervention(id)
)
go

---------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------
-----------Caisse-----------------------------------------------------------------------------------------------------
create table paiement
(
	id int identity,
	id_malade int not null,
	id_sortie int,
	id_dossierpreconsultation int,
	id_consultation int,
	id_dossierconsultationprenatale int,
	id_dossierconsultationpostnatal int,
	id_operation_laboratoire int,
	id_hospitalisation int,
	id_subit int,
	id_dossierconsultationgyneco int, 
	id_autrefraie int,
	id_accouchement int,
	id_dossiersoin int,
	id_dossierechographie int, 
	id_dossiernursing int,
	--id_dossieravance int,
	date smalldatetime default GETDATE(),
	montantdu float not null,
	montantpaye float not null,
	montantmituelle float not null,
	dette float,
	archive bit,
	mituelle bit not null,
	constraint pk_paiement primary key(id),
	constraint fk_paiement_id_malade foreign key(id_malade) references malade(id),
	constraint fk_paiement_id_sortie foreign key(id_sortie) references sortie(id),
	constraint fk_paiement_id_dossierpreconsultation foreign key(id_dossierpreconsultation) references dossierpreconsultation(id),
	constraint fk_paiement_id_consultation foreign key(id_consultation) references consultation(id),
	constraint fk_paiement_id_dossierconsultationprenatale foreign key(id_dossierconsultationprenatale) references dossierconsultationprenatale(id),
	constraint fk_paiement_id_dossierconsultationpostnatal foreign key(id_dossierconsultationpostnatal) references dossierconsultationpostnatal(id),
	constraint fk_paiement_id_operation_laboratoire foreign key(id_operation_laboratoire) references operation_laboratoire(id),
	constraint fk_paiement_id_hospitalisation foreign key(id_hospitalisation) references hospitalisation(id),
	constraint fk_paiement_id_accouchement foreign key(id_accouchement) references dossieraccouchement(id),
	constraint fk_paiement_id_subit foreign key(id_subit) references subit(id),
	constraint fk_paiement_id_dossierconsultationgyneco foreign key(id_dossierconsultationgyneco) references dossierconsultationgynecologique(id),
	constraint fk_paiement_id_autrefraie foreign key(id_autrefraie) references autrefraie(id), 
	constraint fk_paiement_id_dossiersoin foreign key(id_dossiersoin) references dossiersoin(id), 
	constraint fk_paiement_id_dossierechographie foreign key(id_dossierechographie) references dossierechographie(id),
	constraint fk_paiement_id_dossiernursing foreign key(id_dossiernursing) references dossiernursing(id)
	--constraint fk_paiement_id_dossieravance foreign key(id_dossieravance) references dossieravance(id)
)
go

create table facturation
(
	id int,
	numero_facture int not null,
	id_malade int not null,
	id_article int not null,
	id_article_f int,
	id_paiement int not null,
	designation varchar(200) not null,
	pu float not null,
	quantite int not null,
	montantpaye float not null,
	montantmituelle float ,
	dette float ,
	avance float ,
	ismedicament bit not null,  
	isexamen bit not null,
	ispaiementmalade bit not null,
	solde bit default 0,
	soldemituelle bit default 0,
	designation_service varchar(200) not null,
	date smalldatetime not null,
	constraint pk_facturation primary key(id),
	constraint fk_facturation_id_malade foreign key(id_malade) references malade(id),
)
go

--create table facturationmituelle
--(
--	id int,
--	numero_facture int not null,
--	id_malade int not null,
--	id_paiement int not null,
--	montantpaye float not null,
--	dette float,
--	avance float,
--	solde bit default 0,
--	date smalldatetime not null,
--	constraint pk_facturationmituelle primary key(id),
--	constraint facturationmituelle_id_malade foreign key(id_malade) references malade(id),
--)
--go

create table article_paye
(
	id int identity,
	id_paiement int not null,
	id_article int not null,
	designation varchar(200),
	designation_classe varchar(50),
	constraint pk_article_paye primary key(id),
	constraint fk_article_paye_id_paiement foreign key(id_paiement) references paiement(id)
)
go

--Vue pour la facture des clients
CREATE VIEW FactureQUery
AS 
SELECT facturation.designation_service,dbo.facturation.id,tempAvance.montant AS avance2,ISNULL(dbo.personne.nom, '') + ' ' + ISNULL(dbo.personne.postnom, '') + ' ' + ISNULL(dbo.personne.prenom, '') AS NomComplet, dbo.facturation.designation, 
                      dbo.facturation.date, dbo.facturation.pu, ROUND(dbo.facturation.dette, 2) AS dette, ROUND(dbo.facturation.montantmituelle, 2) AS mituelle1, 
                      dbo.facturation.quantite, dbo.facturation.pu * dbo.facturation.quantite AS PT, 
                      dbo.facturation.pu * dbo.facturation.quantite + dbo.facturation.pu * dbo.facturation.quantite AS sousTot, dbo.personne.sexe, dbo.malade.numero, 
                      dbo.categoriemalade.designation AS TypeMalade, ROUND(dbo.categoriemalade.taux,2) AS taux, dbo.etablissementpriseencharge.denomination, dbo.facturation.id_malade, 
                      dbo.facturation.numero_facture,(SELECT SUM(dbo.facturation.pu*facturation.quantite) 
                                   FROM dbo.facturation INNER JOIN dbo.malade ON dbo.facturation.id_malade = dbo.malade.id 
                                                LEFT OUTER JOIN dbo.personne ON dbo.malade.id_personne = dbo.personne.id 
                                                LEFT OUTER JOIN dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                                                LEFT OUTER JOIN dbo.etablissementpriseencharge ON dbo.malade.id_etablissement = dbo.etablissementpriseencharge.id
                                    where dbo.facturation.ismedicament=1) AS medicament,(SELECT SUM(dbo.facturation.pu*facturation.quantite) 
                                   FROM dbo.facturation INNER JOIN dbo.malade ON dbo.facturation.id_malade = dbo.malade.id 
                                                LEFT OUTER JOIN dbo.personne ON dbo.malade.id_personne = dbo.personne.id 
                                                LEFT OUTER JOIN dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                                                LEFT OUTER JOIN dbo.etablissementpriseencharge ON dbo.malade.id_etablissement = dbo.etablissementpriseencharge.id
                                    where dbo.facturation.isexamen=1) AS labo,(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE malade_avance.solde=0) AS avanceMal,SUM(dbo.facturation.pu * dbo.facturation.quantite) + (SELECT SUM(dbo.facturation.pu*facturation.quantite) 
                                   FROM dbo.facturation INNER JOIN dbo.malade ON dbo.facturation.id_malade = dbo.malade.id 
                                                LEFT OUTER JOIN dbo.personne ON dbo.malade.id_personne = dbo.personne.id 
                                                LEFT OUTER JOIN dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                                                LEFT OUTER JOIN dbo.etablissementpriseencharge ON dbo.malade.id_etablissement = dbo.etablissementpriseencharge.id
                                    where dbo.facturation.ismedicament=1-(SELECT ROUND(ISNULL(MAX(cumul),0),2) from malade_avance RIGHT OUTER JOIN malade on malade.id=malade_avance.id_malade INNER JOIN facturation ON malade.id=facturation.id_malade WHERE malade_avance.solde=0)) AS TotGen,(SELECT ROUND(SUM(facturation.montantmituelle),2)
           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id) AS mituelle
FROM         dbo.facturation INNER JOIN
                      dbo.malade ON dbo.facturation.id_malade = dbo.malade.id LEFT OUTER JOIN
                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                      dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id LEFT OUTER JOIN
                      dbo.etablissementpriseencharge ON dbo.malade.id_etablissement = dbo.etablissementpriseencharge.id INNER JOIN tempAvance ON malade.id=tempAvance.id_malade WHERE facturation.ismedicament=0
                      
GROUP BY dbo.facturation.designation_service,dbo.facturation.id,dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.personne.sexe, dbo.categoriemalade.designation, dbo.categoriemalade.taux, 
                      dbo.etablissementpriseencharge.denomination, dbo.malade.numero, dbo.facturation.designation, dbo.facturation.date, dbo.facturation.pu, 
                      dbo.facturation.dette, dbo.facturation.montantmituelle, dbo.facturation.quantite, dbo.facturation.id_malade, dbo.facturation.numero_facture,dbo.tempAvance.id_malade,dbo.tempAvance.montant
go

CREATE VIEW vRecetteGlobaleAbonneInterneExterne
AS
SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom,numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, SUM(isnull([ConsultationP], 0)) 
          AS resultatConsult, SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, SUM(isnull([ConsultationPrenatale], 0)) 
          AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_Fraie], 0)) 
          AS resultAutreFraie, SUM(isnull([Hospitalisation], 0)) AS resultHospitalisation, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([Accouchement], 0)) 
          AS resultAccouchement, isnull([Avance],0) AS resultAvance, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) + SUM(isnull([ConsultationPrenatale], 0)) 
          + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) + SUM(isnull([Autre_Fraie], 0)) + SUM(isnull([Hospitalisation], 0)) + isnull([Avance],0) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0)) + SUM(isnull([Accouchement], 0))  
              AS somme
        FROM         (SELECT     SUM(dbo.examen.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                      dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero,operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
               FROM          dbo.examen INNER JOIN
                                      dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id LEFT OUTER JOIN
                                      dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade INNER JOIN 
                                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                     dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
               WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                      (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
               GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, operation_laboratoire.date
               UNION
               SELECT     SUM(dbo.intervention.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                     dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
               FROM         dbo.intervention INNER JOIN
                                     dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id LEFT OUTER JOIN
                                     dbo.malade ON dbo.malade.id = dbo.subit.id_malade INNER JOIN 
                                     hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                     dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                     dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
               WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                     (dbo.subit.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
               GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, subit.date
               UNION
               SELECT     SUM(tarifpreconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                     dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
               FROM         dossierpreconsultation INNER JOIN
                                     dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade INNER JOIN 
                                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN 
                                     tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id LEFT OUTER JOIN
                                     dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
               WHERE     dossierpreconsultation.etatpaiement = 'Fiche payée' and dbo.categoriemalade.designation='Abonné'
               GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierpreconsultation.date
               UNION
               SELECT     SUM(dbo.tarifconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                     dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
               FROM         dbo.tarifconsultation INNER JOIN
                                     dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id LEFT OUTER JOIN
                                     dbo.malade ON dbo.malade.id = dbo.consultation.id_malade INNER JOIN 
                                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                     dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
               WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                     (dbo.consultation.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
               GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, consultation.date
               UNION
               SELECT     SUM(dbo.tarifconsultationprenatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                     dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
               FROM         dbo.tarifconsultationprenatal INNER JOIN
                                     dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id LEFT OUTER JOIN
                                     dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade INNER JOIN 
                                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                     dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
               WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                     (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
               GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationprenatale.date
               
               UNION
               SELECT     SUM(dbo.tarifechographie.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                     dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
               FROM         dbo.tarifechographie INNER JOIN
                                     dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id LEFT OUTER JOIN
                                     dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade INNER JOIN 
                                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                     dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
               WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                     (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
               GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierechographie.date
               UNION
               SELECT     SUM(dbo.tarifsoin.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                     dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
               FROM         dbo.tarifsoin INNER JOIN
                                     dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id LEFT OUTER JOIN
                                     dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade INNER JOIN 
                                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                     dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
               WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                     (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
               GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiersoin.date    
               UNION
               SELECT     SUM(dbo.tarifnursing.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                     dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
               FROM         dbo.tarifnursing INNER JOIN
                                     dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id LEFT OUTER JOIN
                                     dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade INNER JOIN 
                                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                     dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
               WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                     (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
               GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiernursing.date               
               UNION
               SELECT     SUM(dbo.tarifconsultationgynecologique.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                     dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
               FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                     dbo.dossierconsultationgynecologique ON 
                                     dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id LEFT OUTER JOIN
                                     dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade INNER JOIN 
                                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                     dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
               WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                     (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and convert(date,dossierconsultationgynecologique.date,100)='03/08/2015' and dbo.categoriemalade.designation='Abonné'
               GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationgynecologique.date
               UNION
               SELECT     SUM(dbo.tarifconsultationpostnatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                     dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
               FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                     dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id LEFT OUTER JOIN
                                     dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade INNER JOIN 
                                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                     dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
               WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                     (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
               GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationpostnatal.date
               UNION
               SELECT     SUM(dbo.typeaccouchement.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                     dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero,dossieraccouchement.date AS dateEvent, 'Accouchement' AS DIMENSION
               FROM         dbo.typeaccouchement INNER JOIN
                                     dbo.dossieraccouchement ON dbo.typeaccouchement.id = dbo.dossieraccouchement.id_typeaccouchement LEFT OUTER JOIN
                                     dbo.malade ON dbo.malade.id = dbo.dossieraccouchement.id_malade LEFT OUTER JOIN
                                     dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                     dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
               WHERE     ((dbo.dossieraccouchement.etatpaiement = 'Non cloturé payé') OR (dbo.dossieraccouchement.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
               GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossieraccouchement.date
               UNION
               SELECT     SUM(dbo.article.pu) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                     dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
               FROM         dbo.article INNER JOIN
                                     dbo.sortie ON dbo.sortie.id_article = dbo.article.id LEFT OUTER JOIN
                                     dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                     dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
               WHERE     (dbo.sortie.etatpaiement = 'Payé') and dbo.categoriemalade.designation='Abonné'
               GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
               UNION
               SELECT     SUM(dbo.detailsautrefraie.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
               FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                     dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade INNER JOIN 
                                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                     dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
               WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and dbo.categoriemalade.designation='Abonné'
               GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, autrefraie.dateenregistrement
               UNION
               SELECT     SUM(dbo.categoriechambre.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                     dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, hospitalisation.datefin AS dateEvent, 'Hospitalisation' AS DIMENSION
               FROM         dbo.hospitalisation INNER JOIN
                                     dbo.chambre LEFT OUTER JOIN
                                     dbo.categoriechambre ON dbo.chambre.id_categoriechambre = dbo.categoriechambre.id ON 
                                     dbo.hospitalisation.id_chambre = dbo.chambre.id LEFT OUTER JOIN
                                     dbo.personne LEFT OUTER JOIN
                                     dbo.malade ON dbo.personne.id = dbo.malade.id_personne ON dbo.hospitalisation.id_malade = dbo.malade.id LEFT OUTER JOIN
                                     dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
               WHERE     ((dbo.hospitalisation.etatpaiement = 'Non cloturé payé') OR
                                     (dbo.hospitalisation.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
               GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, hospitalisation.datefin
               UNION
               SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                     dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
               FROM         dbo.malade_avance INNER JOIN											 
                                     dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance LEFT OUTER JOIN
                                     dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade INNER JOIN 
                                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                     dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
               WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                                     (dbo.dossieravance.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
               GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date) MES_UNIONS PIVOT (sum(VALEUR) FOR 
               dimension IN ([examenP], [ConsultationP], [ConsultationGP], [peconsult], [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_Fraie], [Hospitalisation],[Nursing], 
               [InterventionP],[Accouchement],[Avance])) AS MON_PIVOT
        GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent,numero,Avance

go     

CREATE VIEW vRecetteGlobaleNonAbonneInterneExterne
AS
SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom,numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, SUM(isnull([ConsultationP], 0)) 
  AS resultatConsult, SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, SUM(isnull([ConsultationPrenatale], 0)) 
  AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_Fraie], 0)) 
  AS resultAutreFraie, SUM(isnull([Hospitalisation], 0)) AS resultHospitalisation, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([Accouchement], 0)) 
  AS resultAccouchement, isnull([Avance],0) AS resultAvance, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) + SUM(isnull([ConsultationPrenatale], 0)) 
  + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) + SUM(isnull([Autre_Fraie], 0)) + SUM(isnull([Hospitalisation], 0)) + isnull([Avance],0) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0)) + SUM(isnull([Accouchement], 0))  
      AS somme
FROM         (SELECT     SUM(dbo.examen.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                              dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero,operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
       FROM          dbo.examen INNER JOIN
                              dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id LEFT OUTER JOIN
                              dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade INNER JOIN 
                              dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                              (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and convert(date,operation_laboratoire.date,100)= '03/08/2015' and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, operation_laboratoire.date
       UNION
       SELECT     SUM(dbo.intervention.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
       FROM         dbo.intervention INNER JOIN
                             dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id LEFT OUTER JOIN
                             dbo.malade ON dbo.malade.id = dbo.subit.id_malade INNER JOIN 
                             dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                             (dbo.subit.etatpaiement = 'Cloturé payé')) and convert(date,subit.date,100)='03/08/2015' and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, subit.date
       UNION
       SELECT     SUM(tarifpreconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
       FROM         dossierpreconsultation INNER JOIN
                             dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade INNER JOIN 
                              dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN 
                             tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE     dossierpreconsultation.etatpaiement = 'Fiche payée' and convert(date,dossierpreconsultation.date,100)='03/08/2015' and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierpreconsultation.date
       UNION
       SELECT     SUM(dbo.tarifconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
       FROM         dbo.tarifconsultation INNER JOIN
                             dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id LEFT OUTER JOIN
                             dbo.malade ON dbo.malade.id = dbo.consultation.id_malade INNER JOIN 
                              dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                             (dbo.consultation.etatpaiement = 'Cloturé payé')) and convert(date,consultation.date,100)='03/08/2015' and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, consultation.date
       UNION
       SELECT     SUM(dbo.tarifconsultationprenatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
       FROM         dbo.tarifconsultationprenatal INNER JOIN
                             dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id LEFT OUTER JOIN
                             dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade INNER JOIN 
                              dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                             (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and convert(date,dossierconsultationprenatale.date,100)='03/08/2015' and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationprenatale.date
       
       UNION
       SELECT     SUM(dbo.tarifechographie.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
       FROM         dbo.tarifechographie INNER JOIN
                             dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id LEFT OUTER JOIN
                             dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade INNER JOIN 
                              dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                             (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and convert(date,dossierechographie.date,100)='03/08/2015' and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierechographie.date
       UNION
       SELECT     SUM(dbo.tarifsoin.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
       FROM         dbo.tarifsoin INNER JOIN
                             dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id LEFT OUTER JOIN
                             dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade INNER JOIN 
                              dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                             (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and convert(date,dossiersoin.date,100)='03/08/2015' and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiersoin.date    
       UNION
       SELECT     SUM(dbo.tarifnursing.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
       FROM         dbo.tarifnursing INNER JOIN
                             dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id LEFT OUTER JOIN
                             dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade INNER JOIN 
                              dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                             (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and convert(date,dossiernursing.date,100)='03/08/2015' and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiernursing.date               
       UNION
       SELECT     SUM(dbo.tarifconsultationgynecologique.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
       FROM         dbo.tarifconsultationgynecologique INNER JOIN
                             dbo.dossierconsultationgynecologique ON 
                             dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id LEFT OUTER JOIN
                             dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade INNER JOIN 
                              dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                             (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and convert(date,dossierconsultationgynecologique.date,100)='03/08/2015' and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationgynecologique.date
       UNION
       SELECT     SUM(dbo.tarifconsultationpostnatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
       FROM         dbo.tarifconsultationpostnatal INNER JOIN
                             dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id LEFT OUTER JOIN
                             dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade INNER JOIN 
                              dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                             (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) and convert(date,dossierconsultationpostnatal.date,100)='03/08/2015' and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationpostnatal.date
       UNION
       SELECT     SUM(dbo.typeaccouchement.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero,dossieraccouchement.date AS dateEvent, 'Accouchement' AS DIMENSION
       FROM         dbo.typeaccouchement INNER JOIN
                             dbo.dossieraccouchement ON dbo.typeaccouchement.id = dbo.dossieraccouchement.id_typeaccouchement LEFT OUTER JOIN
                             dbo.malade ON dbo.malade.id = dbo.dossieraccouchement.id_malade LEFT OUTER JOIN
                             dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE     ((dbo.dossieraccouchement.etatpaiement = 'Non cloturé payé') OR (dbo.dossieraccouchement.etatpaiement = 'Cloturé payé')) and convert(date,dossieraccouchement.date,100)='03/08/2015' and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossieraccouchement.date
       UNION
       SELECT     SUM(dbo.article.pu) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
       FROM         dbo.article INNER JOIN
                             dbo.sortie ON dbo.sortie.id_article = dbo.article.id LEFT OUTER JOIN
                             dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                              dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE     (dbo.sortie.etatpaiement = 'Payé') and convert(date,sortie.date,100)='03/08/2015' and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
       UNION
       SELECT     SUM(dbo.detailsautrefraie.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                 dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
       FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                             dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade INNER JOIN 
                              dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and convert(date,autrefraie.dateenregistrement,100)='03/08/2015' and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, autrefraie.dateenregistrement
       UNION
       SELECT     SUM(dbo.categoriechambre.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, hospitalisation.datefin AS dateEvent, 'Hospitalisation' AS DIMENSION
       FROM         dbo.hospitalisation INNER JOIN
                             dbo.chambre LEFT OUTER JOIN
                             dbo.categoriechambre ON dbo.chambre.id_categoriechambre = dbo.categoriechambre.id ON 
                             dbo.hospitalisation.id_chambre = dbo.chambre.id LEFT OUTER JOIN
                             dbo.personne LEFT OUTER JOIN
                             dbo.malade ON dbo.personne.id = dbo.malade.id_personne ON dbo.hospitalisation.id_malade = dbo.malade.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
       WHERE     ((dbo.hospitalisation.etatpaiement = 'Non cloturé payé') OR
                             (dbo.hospitalisation.etatpaiement = 'Cloturé payé')) and convert(date,hospitalisation.datefin,100)='03/08/2015' and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, hospitalisation.datefin
       UNION
       SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
       FROM         dbo.malade_avance INNER JOIN											 
                             dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance LEFT OUTER JOIN
                             dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade INNER JOIN 
                              dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                             dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
       WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                             (dbo.dossieravance.etatpaiement = 'Cloturé payé')) and convert(date,dossieravance.date,100)='03/08/2015' and dbo.categoriemalade.designation='Non abonné'
       GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date) MES_UNIONS PIVOT (sum(VALEUR) FOR 
       dimension IN ([examenP], [ConsultationP], [ConsultationGP], [peconsult], [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_Fraie], [Hospitalisation],[Nursing], 
       [InterventionP],[Accouchement],[Avance])) AS MON_PIVOT
GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent,numero,Avance
go  

--Vue pour la facture des mituelles
CREATE VIEW FactureQUery1
AS 
SELECT ROUND(etablissementpriseencharge.taux,2) AS taux,facturation.id AS idFacturation,ISNULL(personne.nom,'') + ' ' + ISNULL(personne.postnom,'') + ' ' + ISNULL(personne.prenom,'') AS NomComplet,facturation.date, facturation.pu,facturation.quantite,facturation.montantmituelle,personne.sexe, 
               malade.numero,etablissementpriseencharge.id AS idEtablissement,malade.id,facturation.numero_facture,facturation.designation,etablissementpriseencharge.denomination, (SELECT ROUND(SUM(facturation.montantmituelle),2)
           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id 
                        LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                        LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                        LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
            WHERE (facturation.ismedicament=0 OR facturation.ismedicament=1) AND facturation.soldemituelle=0) AS mituelle
           FROM facturation INNER JOIN malade ON facturation.id_malade = malade.id
                            LEFT OUTER JOIN personne ON malade.id_personne = personne.id 
                            LEFT OUTER JOIN categoriemalade ON malade.id_categoriemalade = categoriemalade.id 
                            LEFT OUTER JOIN etablissementpriseencharge ON malade.id_etablissement=etablissementpriseencharge.id
            WHERE (facturation.ismedicament=0 OR facturation.ismedicament=1) AND facturation.soldemituelle=0
go

CREATE VIEW RenseignementMalade
AS
SELECT     'Préconsultation' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne, 
                      malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid, 
                      ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature, preconsultation.datePrecons, DATEDIFF(YEAR, personne.datenaissance, 
                      GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche, 
                      personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'POIDS : ' + CONVERT(varchar(30),ISNULL(ROUND(preconsultation.poid, 2),0)) + '; TAILLE : ' + CONVERT(varchar(30),ISNULL(ROUND(preconsultation.taille, 2),0)) + '; T° : ' + CONVERT(varchar(30),ISNULL(preconsultation.temperature,0))  + '; OBSERVATION : ' + preconsultation.observation AS observation
FROM         preconsultation INNER JOIN
                      dossierpreconsultation ON dossierpreconsultation.id = preconsultation.id_dossierpreconsultation INNER JOIN
                      malade ON malade.id = dossierpreconsultation.id_malade INNER JOIN
                      airsante ON airsante.id = malade.id_airsante INNER JOIN
                      profession ON profession.id = malade.id_profession INNER JOIN
                      etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement INNER JOIN
                      personne ON personne.id = malade.id_personne
                      
UNION 
SELECT 'Consultation' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,consultation.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers,'CONDUITE : ' + mouvementconsultation.Conduite + '; DIAGNOSTICS : ' + mouvementconsultation.diagnostics + '; PLAINTES : ' + mouvementconsultation.plainte + '; SYMPTOME : ' + mouvementconsultation.symptome + '; MEDICAMENTS A PRESCRIRE : ' + mouvementconsultation.medicamentaprescrire AS observation FROM consultation 
INNER JOIN mouvementconsultation ON consultation.id=mouvementconsultation.id_consultation
INNER JOIN malade ON malade.id=consultation.id_malade 
INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
INNER JOIN airsante ON airsante.id = malade.id_airsante 
INNER JOIN profession ON profession.id = malade.id_profession 
INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
INNER JOIN personne ON personne.id = malade.id_personne  

UNION 
SELECT 'Laboratoire' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,operation_laboratoire.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'CRITERE DE RESULTAT : ' + critereresultat.designation + '; RESULTATS : ' + mouvementoperation_laboratoire.resultat + '; EXAMEN : ' + examen.designation + '; TYPE EXAMEN : ' + typeexamen.designation AS observation FROM mouvementoperation_laboratoire 
INNER JOIN operation_laboratoire ON operation_laboratoire.id=mouvementoperation_laboratoire.id_operation_laboratoire
INNER JOIN critereresultat ON critereresultat.id=mouvementoperation_laboratoire.id_critere
INNER JOIN examen ON examen.id=operation_laboratoire.id_examen
INNER JOIN typeexamen ON typeexamen.id=examen.id_typeexamen
INNER JOIN malade ON malade.id=operation_laboratoire.id_malade 
INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
INNER JOIN airsante ON airsante.id = malade.id_airsante 
INNER JOIN profession ON profession.id = malade.id_profession 
INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
INNER JOIN personne ON personne.id = malade.id_personne    

UNION 
SELECT 'Hospitalisation' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,mvmhospitalisation.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers,'DATE DEBUT : ' + CONVERT(varchar(30),CONVERT(date,ISNULL(hospitalisation.datedebut,null),100)) + '; DATE FIN : ' + CONVERT(varchar(30),CONVERT(date,ISNULL(hospitalisation.datefin,null),100)) + '; CHAMBRE : ' + chambre.designation + 'N°' + CONVERT(varchar(30),ISNULL(chambre.numero,0)) + '; CATEGORIE CHAMBRE : ' + categoriechambre.designation + '; PLS : ' + CONVERT(varchar(30),ISNULL(mvmhospitalisation.pls,0)) + '; RESPIRATION : ' + mvmhospitalisation.resiration + '; TA : ' + CONVERT(varchar(30),ISNULL(mvmhospitalisation.ta,0)) + '; T° : ' + CONVERT(varchar(30),ISNULL(mvmhospitalisation.temperature,0)) AS observation FROM mvmhospitalisation 
INNER JOIN hospitalisation ON hospitalisation.id=mvmhospitalisation.id_hospitalisation
INNER JOIN chambre ON chambre.id=hospitalisation.id_chambre
INNER JOIN categoriechambre ON categoriechambre.id=chambre.id_categoriechambre
INNER JOIN malade ON malade.id=hospitalisation.id_malade
INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
INNER JOIN airsante ON airsante.id = malade.id_airsante 
INNER JOIN profession ON profession.id = malade.id_profession 
INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
INNER JOIN personne ON personne.id = malade.id_personne 

UNION 
SELECT 'Intervention' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,subit.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'OBSERVATION : ' + subit.observation + '; BLOC : ' + bloc.designation + '; SERVICE : ' + service.designation AS observation FROM subit 
INNER JOIN intervention ON intervention.id=subit.id_intervention
INNER JOIN bloc ON bloc.id=intervention.id_bloc
INNER JOIN service ON service.id=bloc.id_service
INNER JOIN malade ON malade.id=subit.id_malade
INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
INNER JOIN airsante ON airsante.id = malade.id_airsante 
INNER JOIN profession ON profession.id = malade.id_profession 
INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
INNER JOIN personne ON personne.id = malade.id_personne 

UNION 
SELECT 'Consultation Gynécologique' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,consultationgynecologique.date_consultation AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers,'DDR : ' + CONVERT(varchar(30),CONVERT(date,ISNULL(consultationgynecologique.ddr,''),100)) + '; DPA : ' + CONVERT(varchar(30),CONVERT(date,ISNULL(consultationgynecologique.dpa,''),100)) + '; EXAMEN : ' + consultationgynecologique.examengyneco + '; DIAGNOSTIC : ' + consultationgynecologique.diagnostic + '; CRITERE ECHOGRAPHIE : ' + criterechographie.designation AS observation FROM consultationgynecologique 
INNER JOIN criterechographie ON criterechographie.id=consultationgynecologique.id_critere_echo
INNER JOIN tarifconsultationgynecologique ON tarifconsultationgynecologique.id=consultationgynecologique.id_dossierconsultationgyneco
INNER JOIN dossierconsultationgynecologique ON tarifconsultationgynecologique.id=dossierconsultationgynecologique.id_tarifconsultationgynecologique
INNER JOIN malade ON malade.id=dossierconsultationgynecologique.id_malade 
INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
INNER JOIN airsante ON airsante.id = malade.id_airsante 
INNER JOIN profession ON profession.id = malade.id_profession 
INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
INNER JOIN personne ON personne.id = malade.id_personne  

UNION 
SELECT 'Médicaments' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,sortie.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers,'ARTICLE CONSOMME : ' + article.desination + '; CARACTERISTIQUE DU PRODUIT CONSOMME : ' + article.caracteristique + '; Qté PRISE : ' + CONVERT(varchar(20),sortie.quantinte) + '; SERVICE : ' + service.designation AS observation FROM article 
INNER JOIN sortie ON article.id=sortie.id_article
INNER JOIN service ON service.id=sortie.id_service
INNER JOIN malade ON malade.id=sortie.id_malade 
INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
INNER JOIN airsante ON airsante.id = malade.id_airsante 
INNER JOIN profession ON profession.id = malade.id_profession 
INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
INNER JOIN personne ON personne.id = malade.id_personne 

UNION 
SELECT 'Autres frais' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,autrefraie.datepaiement AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers,'ETABLISSEMENT EXTERNE : ' + etablissementexterne.denomination + '; N° FACTURE : ' + autrefraie.numerofacture + '; EXAMEN PASSE : ' + detailsautrefraie.designation + '; DATE PASSATION : ' + CONVERT(varchar(30),CONVERT(date,autrefraie.dateenregistrement,100)) AS observation FROM etablissementexterne 
INNER JOIN autrefraie ON etablissementexterne.id=autrefraie.id_etablissementexterne
INNER JOIN detailsautrefraie ON autrefraie.id=detailsautrefraie.id_autrefraie
INNER JOIN malade ON malade.id=autrefraie.id_malade 
INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
INNER JOIN airsante ON airsante.id = malade.id_airsante 
INNER JOIN profession ON profession.id = malade.id_profession 
INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
INNER JOIN personne ON personne.id = malade.id_personne 

UNION 
SELECT 'CPN' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,consultationprenatal.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'CONJONCTIVE : ' + consultationprenatal.conjoctivepalpebrale + '; DDR : ' + consultationprenatal.ddr + '; DRP : ' + consultationprenatal.drp + '; ANTECEDENT : ' + consultationprenatal.entecedent + '; GESTE TRAITEMENT : ' + consultationprenatal.gesttte + '; Gp. SANGUN : ' + consultationprenatal.gropeSanguin + '; HISTORIQUE GROSSESSE : ' +  consultationprenatal.historiqueGrossesse AS observation FROM consultationprenatal 
INNER JOIN dossierconsultationprenatale ON dossierconsultationprenatale.id=consultationprenatal.id_dossierconsultationprenatale
INNER JOIN malade ON malade.id=dossierconsultationprenatale.id_malade  
INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
INNER JOIN airsante ON airsante.id = malade.id_airsante 
INNER JOIN profession ON profession.id = malade.id_profession 
INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
INNER JOIN personne ON personne.id = malade.id_personne          

UNION 
SELECT 'CPOS' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,maladeenconsultationpostnatal.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'PERE : ' + maladeenconsultationpostnatal.nompere + '; MERE : ' + maladeenconsultationpostnatal.nommere + '; POIDS NAISSANCE : ' + CONVERT(varchar(30),ISNULL(maladeenconsultationpostnatal.poidsnaisance,0)) AS observation FROM maladeenconsultationpostnatal 
INNER JOIN dossierconsultationpostnatal ON dossierconsultationpostnatal.id=maladeenconsultationpostnatal.id_dossierconsultationpostnatal
INNER JOIN malade ON malade.id=dossierconsultationpostnatal.id_malade  
INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
INNER JOIN airsante ON airsante.id = malade.id_airsante 
INNER JOIN profession ON profession.id = malade.id_profession 
INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
INNER JOIN personne ON personne.id = malade.id_personne 

UNION 
SELECT 'Echographie' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,dossierechographie.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'EXAMEN CONCERNE : ' + tarifechographie.designation AS observation FROM dossierechographie 
INNER JOIN tarifechographie ON tarifechographie.id=dossierechographie.id_tarifechographie
INNER JOIN malade ON malade.id=dossierechographie.id_malade   
INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
INNER JOIN airsante ON airsante.id = malade.id_airsante 
INNER JOIN profession ON profession.id = malade.id_profession 
INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
INNER JOIN personne ON personne.id = malade.id_personne                                            
                                                             
UNION 
SELECT 'Soins' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,dossiersoin.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'SOINS CONCERNE : ' + tarifsoin.designation AS observation FROM dossiersoin 
INNER JOIN tarifsoin ON tarifsoin.id=dossiersoin.id_tarifsoin
INNER JOIN malade ON malade.id=dossiersoin.id_malade 
INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
INNER JOIN airsante ON airsante.id = malade.id_airsante 
INNER JOIN profession ON profession.id = malade.id_profession 
INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
INNER JOIN personne ON personne.id = malade.id_personne 

UNION 
SELECT 'Nursing' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,dossiernursing.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'NURSING : ' + tarifnursing.designation AS observation FROM dossiernursing 
INNER JOIN tarifnursing ON tarifnursing.id=dossiernursing.id_tarifnursing
INNER JOIN malade ON malade.id=dossiernursing.id_malade  
INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
INNER JOIN airsante ON airsante.id = malade.id_airsante 
INNER JOIN profession ON profession.id = malade.id_profession 
INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
INNER JOIN personne ON personne.id = malade.id_personne 

UNION 
SELECT 'Accouchement' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,dossieraccouchement.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'TYPE ACCOUCHEMENT : ' + typeaccouchement.designation  AS observation FROM typeaccouchement --+ '; BCG : ' + CONVERT(varchar(30),ISNULL(accouchement.bcg,0)) + '; DEGRE : ' + CONVERT(varchar(30),ISNULL(accouchement.degree,0)) + '; VAT : ' + CONVERT(varchar(30),ISNULL(accouchement.vat,0)) + '; LIEU : ' + accouchement.lieu + '; TRAITEMENT : ' + accouchement.traitement
INNER JOIN dossieraccouchement ON typeaccouchement.id=dossieraccouchement.id_typeaccouchement
--INNER JOIN accouchement ON typeaccouchement.id=accouchement.id_typeaccouchement
INNER JOIN malade ON malade.id=dossieraccouchement.id_malade  
INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
INNER JOIN airsante ON airsante.id = malade.id_airsante 
INNER JOIN profession ON profession.id = malade.id_profession 
INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
INNER JOIN personne ON personne.id = malade.id_personne

UNION 
SELECT 'Avance' AS item,ISNULL(personne.nom, '') + ' ' + ISNULL(personne.postnom, '') + ' ' + ISNULL(personne.prenom, '') AS nom, personne.sexe, malade.id_personne,malade.id, personne.datenaissance, airsante.designation, profession.designation AS profession, ROUND(preconsultation.poid, 2) AS poid,ROUND(preconsultation.taille, 2) AS taille, preconsultation.temperature,dossieravance.date AS datePrecons,DATEDIFF(YEAR, personne.datenaissance,GETDATE()) AS age, preconsultation.pressionArterielle, etablissementpriseencharge.denomination, malade.numero AS numMal,malade.numero_fiche,personne.telephone AS numero, etablissementpriseencharge.adresse,personne.adresse AS adressePers, 'AVANCE PRISE : ' + tarifavance.designation AS observation FROM dossieravance 
INNER JOIN tarifavance ON tarifavance.id=dossieravance.id_tarifavance
INNER JOIN malade ON malade.id=dossieravance.id_malade  
INNER JOIN dossierpreconsultation ON malade.id=dossierpreconsultation.id_malade
INNER JOIN preconsultation ON dossierpreconsultation.id=preconsultation.id_dossierpreconsultation
INNER JOIN airsante ON airsante.id = malade.id_airsante 
INNER JOIN profession ON profession.id = malade.id_profession 
INNER JOIN etablissementpriseencharge ON etablissementpriseencharge.id = malade.id_etablissement
INNER JOIN personne ON personne.id = malade.id_personne 
GO

CREATE VIEW vConsultation
AS
SELECT     dbo.consultation.date, dbo.malade.numero, dbo.personne.nom, dbo.personne.prenom, dbo.personne.postnom, dbo.personne.sexe, 
                      dbo.antecedentallergie.commentaire, dbo.allergie.designation AS DesignationAllergie, dbo.mouvementconsultation.plainte, dbo.mouvementconsultation.symptome, 
                      dbo.mouvementconsultation.diagnostics, dbo.mouvementconsultation.medicamentaprescrire, dbo.mouvementconsultation.conduite, 
                      dbo.mouvementconsultation.date AS dateConsultationProprementDite, dbo.antecedentmaladie.commentaire AS CommentaireAntecedentMaladie, 
                      dbo.maladie.designation, dbo.groupesanguin.designation AS DesignationGroupeSanguin
FROM         dbo.malade INNER JOIN
                      dbo.consultation ON dbo.malade.id = dbo.consultation.id_malade INNER JOIN
                      dbo.mouvementconsultation ON dbo.consultation.id = dbo.mouvementconsultation.id_consultation INNER JOIN
                      dbo.antecedentallergie ON dbo.malade.id = dbo.antecedentallergie.id_malade INNER JOIN
                      dbo.antecedentmaladie ON dbo.malade.id = dbo.antecedentmaladie.id_malade INNER JOIN
                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                      dbo.allergie ON dbo.antecedentallergie.id_allergie = dbo.allergie.id INNER JOIN
                      dbo.maladie ON dbo.antecedentmaladie.id_maladie = dbo.maladie.id INNER JOIN
                      dbo.groupesanguin ON dbo.malade.id_groupesanguin = dbo.groupesanguin.id
GO

CREATE VIEW vConsultationGyn
AS
SELECT     dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.personne.sexe, dbo.malade.numero, dbo.agent.matricule, dbo.agent.grade, 
                      dbo.consultationgynecologique.date_consultation, dbo.mouvementmaladiegynecologique.date, dbo.antecedentallergie.commentaire AS comentaireAntecedentAllergie, 
                      mouvementmaladiegynecologique_1.date AS Expr1, dbo.allergie.designation AS designationAllergie, 
                      dbo.dossierconsultationgynecologique.date AS dateOuvertureDossierConsultationGyn, dbo.consultationgynecologique.diagnostic, 
                      dbo.consultationgynecologique.examengyneco, dbo.consultationgynecologique.dpa, dbo.consultationgynecologique.ddr
FROM         dbo.dossierconsultationgynecologique INNER JOIN
                      dbo.consultationgynecologique INNER JOIN
                      dbo.mouvementmaladiegynecologique ON dbo.consultationgynecologique.id = dbo.mouvementmaladiegynecologique.id_consultationgynecologique INNER JOIN
                      dbo.mouvementmaladiegynecologique AS mouvementmaladiegynecologique_1 ON 
                      dbo.consultationgynecologique.id = mouvementmaladiegynecologique_1.id_consultationgynecologique ON 
                      dbo.dossierconsultationgynecologique.id = dbo.consultationgynecologique.id_dossierconsultationgyneco INNER JOIN
                      dbo.personne INNER JOIN
                      dbo.malade ON dbo.personne.id = dbo.malade.id_personne ON dbo.dossierconsultationgynecologique.id_malade = dbo.malade.id INNER JOIN
                      dbo.agent ON dbo.dossierconsultationgynecologique.id_agent = dbo.agent.id AND dbo.personne.id = dbo.agent.id_personne INNER JOIN
                      dbo.antecedentallergie ON dbo.malade.id = dbo.antecedentallergie.id_malade INNER JOIN
                      dbo.allergie ON dbo.antecedentallergie.id_allergie = dbo.allergie.id INNER JOIN
                      dbo.antecedentmaladie ON dbo.malade.id = dbo.antecedentmaladie.id_malade INNER JOIN
                      dbo.maladie ON dbo.antecedentmaladie.id_maladie = dbo.maladie.id
GO

CREATE VIEW vHospitalisation
AS
SELECT     dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.personne.sexe, dbo.hospitalisation.datefin, dbo.chambre.numero, 
                      dbo.chambre.designation, dbo.mvmhospitalisation.temperature, dbo.malade.numero AS Expr1, dbo.mvmhospitalisation.date
FROM         dbo.personne INNER JOIN
                      dbo.malade ON dbo.personne.id = dbo.malade.id_personne INNER JOIN
                      dbo.mvmhospitalisation ON dbo.personne.id = dbo.mvmhospitalisation.id INNER JOIN
                      dbo.hospitalisation ON dbo.malade.id = dbo.hospitalisation.id_malade AND dbo.mvmhospitalisation.id_hospitalisation = dbo.hospitalisation.id INNER JOIN
                      dbo.chambre ON dbo.hospitalisation.id_chambre = dbo.chambre.id
GO

CREATE VIEW vHospitalisationFiche
AS
SELECT     dbo.hospitalisation.datedebut, dbo.hospitalisation.datefin, dbo.malade.numero, dbo.personne.nom, dbo.personne.postnom, dbo.chambre.designation, 
                      dbo.groupesanguin.designation AS DesignationGroupeSanguin, dbo.chambre.numero AS NumeroChambre, 
                      dbo.categoriechambre.designation AS DesignationCategorieChambre
FROM         dbo.hospitalisation INNER JOIN
                      dbo.malade ON dbo.hospitalisation.id_malade = dbo.malade.id LEFT OUTER JOIN
                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                      dbo.groupesanguin ON dbo.malade.id_groupesanguin = dbo.groupesanguin.id LEFT OUTER JOIN
                      dbo.chambre ON dbo.hospitalisation.id_chambre = dbo.chambre.id LEFT OUTER JOIN
                      dbo.categoriechambre ON dbo.chambre.id_categoriechambre = dbo.categoriechambre.id
GO

CREATE VIEW vLaboratoire
AS
SELECT     dbo.mouvementoperation_laboratoire.date AS datePassationExamen, dbo.operation_laboratoire.date AS dateOperation, 
                      dbo.examen.designation AS designationExamen, dbo.malade.numero, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, 
                      dbo.critereresultat.designation AS designationCritere, dbo.mouvementoperation_laboratoire.resultat, 
                      dbo.groupesanguin.designation AS designationgroupesanguin
FROM         dbo.mouvementoperation_laboratoire INNER JOIN
                      dbo.operation_laboratoire ON dbo.mouvementoperation_laboratoire.id_operation_laboratoire = dbo.operation_laboratoire.id LEFT OUTER JOIN
                      dbo.examen ON dbo.operation_laboratoire.id_examen = dbo.examen.id LEFT OUTER JOIN
                      dbo.malade ON dbo.operation_laboratoire.id_malade = dbo.malade.id LEFT OUTER JOIN
                      dbo.groupesanguin ON dbo.malade.id_groupesanguin = dbo.groupesanguin.id LEFT OUTER JOIN
                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                      dbo.critereresultat ON dbo.mouvementoperation_laboratoire.id_critere = dbo.critereresultat.id
GO

CREATE VIEW vPreconsultation
AS
SELECT     dbo.preconsultation.poid, dbo.preconsultation.temperature, dbo.preconsultation.pressionArterielle, dbo.preconsultation.pouls, dbo.preconsultation.taille, 
                      dbo.preconsultation.observation, dbo.preconsultation.datePrecons, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.personne.sexe, 
                      dbo.personne.etatcivil, dbo.personne.datenaissance, dbo.malade.numero, dbo.etablissementpriseencharge.denomination, dbo.groupesanguin.designation
FROM         dbo.dossierpreconsultation INNER JOIN
                      dbo.preconsultation ON dbo.dossierpreconsultation.id = dbo.preconsultation.id_dossierpreconsultation INNER JOIN
                      dbo.malade INNER JOIN
                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id ON dbo.dossierpreconsultation.id_malade = dbo.malade.id INNER JOIN
                      dbo.airsante ON dbo.malade.id_airsante = dbo.airsante.id INNER JOIN
                      dbo.etablissementpriseencharge ON dbo.malade.id_etablissement = dbo.etablissementpriseencharge.id INNER JOIN
                      dbo.groupesanguin ON dbo.malade.id_groupesanguin = dbo.groupesanguin.id
GO

CREATE VIEW vStatistiqueLabo
AS
	SELECT     TOP (100) PERCENT COUNT(dbo.operation_laboratoire.id_examen) AS nb, dbo.examen.designation, dbo.operation_laboratoire.date
	FROM         dbo.examen INNER JOIN
						  dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id
	GROUP BY dbo.operation_laboratoire.id_examen, dbo.examen.designation, dbo.operation_laboratoire.date
	ORDER BY dbo.examen.designation
GO

CREATE VIEW vStatistiqueMaladie
AS
SELECT     TOP (100) PERCENT COUNT(dbo.mouvementmaladie.id_maladie) AS nb, dbo.mouvementmaladie.date, dbo.maladie.designation
FROM         dbo.mouvementmaladie INNER JOIN
                      dbo.maladie ON dbo.mouvementmaladie.id_maladie = dbo.maladie.id LEFT OUTER JOIN
                      dbo.mouvementconsultation ON dbo.mouvementmaladie.id_mouvementconsultation = dbo.mouvementconsultation.id LEFT OUTER JOIN
                      dbo.consultation ON dbo.mouvementconsultation.id_consultation = dbo.consultation.id LEFT OUTER JOIN
                      dbo.malade ON dbo.consultation.id_malade = dbo.malade.id LEFT OUTER JOIN
                      dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                      dbo.airsante ON dbo.malade.id_groupesanguin = dbo.airsante.id LEFT OUTER JOIN
                      dbo.groupesanguin ON dbo.malade.id_groupesanguin = dbo.groupesanguin.id LEFT OUTER JOIN
                      dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
GROUP BY dbo.mouvementmaladie.id_maladie, dbo.mouvementmaladie.date, dbo.maladie.designation
ORDER BY dbo.maladie.designation
GO

CREATE VIEW vRecetteJournaliereAbonneInterne
AS
SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom,numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, SUM(isnull([ConsultationP], 0)) 
              AS resultatConsult,SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, SUM(isnull([ConsultationPrenatale], 0)) 
              AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_fraie], 0)) 
              AS resultAutreFraie, SUM(isnull([Hospitalisation], 0)) AS resultHospitalisation, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([Accouchement], 0)) 
              AS resultAccouchement, isnull([Avance],0) AS resultAvance, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) + SUM(isnull([ConsultationPrenatale], 0)) 
              + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) + SUM(isnull([Autre_fraie], 0)) + SUM(isnull([Hospitalisation], 0)) + isnull([Avance],0) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0)) + SUM(isnull([Accouchement], 0))  
                  AS somme
            FROM         (SELECT     SUM(dbo.examen.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero,operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id LEFT OUTER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, operation_laboratoire.date
                   UNION
                   SELECT     SUM(dbo.intervention.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade INNER JOIN 
                                         hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, subit.date
                   UNION
                   SELECT     SUM(tarifpreconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN 
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dossierpreconsultation.etatpaiement = 'Fiche payée') and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierpreconsultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé'))  and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, consultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationprenatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationprenatale.date
                   
                   UNION
                   SELECT     SUM(dbo.tarifechographie.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierechographie.date
                   UNION
                   SELECT     SUM(dbo.tarifsoin.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiersoin.date    
                   UNION
                   SELECT     SUM(dbo.tarifnursing.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiernursing.date               
                   UNION
                   SELECT     SUM(dbo.tarifconsultationgynecologique.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationgynecologique.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationpostnatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationpostnatal.date
                   UNION
                   SELECT     SUM(dbo.typeaccouchement.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero,dossieraccouchement.date AS dateEvent, 'Accouchement' AS DIMENSION
                   FROM         dbo.typeaccouchement INNER JOIN
                                         dbo.dossieraccouchement ON dbo.typeaccouchement.id = dbo.dossieraccouchement.id_typeaccouchement LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossieraccouchement.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieraccouchement.etatpaiement = 'Non cloturé payé') OR (dbo.dossieraccouchement.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossieraccouchement.date
                   UNION
                   SELECT     SUM(dbo.article.pu) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
                   UNION
                   SELECT     SUM(dbo.detailsautrefraie.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, autrefraie.dateenregistrement
                   UNION
                   SELECT     SUM(dbo.categoriechambre.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, hospitalisation.datefin AS dateEvent, 'Hospitalisation' AS DIMENSION
                   FROM         dbo.hospitalisation INNER JOIN
                                         dbo.chambre ON dbo.chambre.id=dbo.hospitalisation.id_chambre INNER JOIN
                                         dbo.categoriechambre ON dbo.categoriechambre.id=dbo.chambre.id_categoriechambre INNER JOIN 
                                         dbo.malade ON dbo.malade.id=dbo.hospitalisation.id_malade INNER JOIN
                                         dbo.categoriemalade ON dbo.categoriemalade.id=dbo.malade.id_categoriemalade INNER JOIN
                                         dbo.personne ON dbo.personne.id = dbo.malade.id_personne
                   WHERE     ((dbo.hospitalisation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.hospitalisation.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, hospitalisation.datefin
                   UNION
                   SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
                   FROM         dbo.malade_avance INNER JOIN											 
                                         dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossieravance.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date) MES_UNIONS PIVOT (sum(VALEUR) FOR 
                   dimension IN ([examenP], [ConsultationP],[ConsultationGP],[peconsult], [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Hospitalisation],[Nursing], 
                   [InterventionP],[Accouchement],[Avance])) AS MON_PIVOT  
            GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent,numero,Avance
GO

CREATE VIEW vRecetteJournaliereNonAbonneInterne
AS
SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom,numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, SUM(isnull([ConsultationP], 0)) 
              AS resultatConsult, SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, SUM(isnull([ConsultationPrenatale], 0)) 
              AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_fraie], 0)) 
              AS resultAutreFraie, SUM(isnull([Hospitalisation], 0)) AS resultHospitalisation, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([Accouchement], 0)) 
              AS resultAccouchement, isnull([Avance],0) AS resultAvance, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0))  + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) + SUM(isnull([ConsultationPrenatale], 0)) 
              + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) + SUM(isnull([Autre_fraie], 0)) + SUM(isnull([Hospitalisation], 0)) + isnull([Avance],0) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0)) + SUM(isnull([Accouchement], 0))  
                  AS somme
            FROM         (SELECT     SUM(dbo.examen.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero,operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id LEFT OUTER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, operation_laboratoire.date
                   UNION
                   SELECT     SUM(dbo.intervention.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade INNER JOIN 
                                         hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, subit.date
                   UNION
                   SELECT     SUM(tarifpreconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN 
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dossierpreconsultation.etatpaiement = 'Fiche payée') and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierpreconsultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, consultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationprenatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationprenatale.date
                   
                   UNION
                   SELECT     SUM(dbo.tarifechographie.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierechographie.date
                   UNION
                   SELECT     SUM(dbo.tarifsoin.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiersoin.date    
                   UNION
                   SELECT     SUM(dbo.tarifnursing.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossiernursing.date               
                   UNION
                   SELECT     SUM(dbo.tarifconsultationgynecologique.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationgynecologique.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationpostnatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossierconsultationpostnatal.date
                   UNION
                   SELECT     SUM(dbo.typeaccouchement.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero,dossieraccouchement.date AS dateEvent, 'Accouchement' AS DIMENSION
                   FROM         dbo.typeaccouchement INNER JOIN
                                         dbo.dossieraccouchement ON dbo.typeaccouchement.id = dbo.dossieraccouchement.id_typeaccouchement LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossieraccouchement.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieraccouchement.etatpaiement = 'Non cloturé payé') OR (dbo.dossieraccouchement.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossieraccouchement.date
                   UNION
                   SELECT     SUM(dbo.article.pu) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, sortie.date
                   UNION
                   SELECT     SUM(dbo.detailsautrefraie.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, autrefraie.dateenregistrement
                   UNION
                   SELECT     SUM(dbo.categoriechambre.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, hospitalisation.datefin AS dateEvent, 'Hospitalisation' AS DIMENSION
                   FROM         dbo.hospitalisation INNER JOIN
                                         dbo.chambre ON dbo.chambre.id=dbo.hospitalisation.id_chambre INNER JOIN
                                         dbo.categoriechambre ON dbo.categoriechambre.id=dbo.chambre.id_categoriechambre INNER JOIN 
                                         dbo.malade ON dbo.malade.id=dbo.hospitalisation.id_malade INNER JOIN
                                         dbo.categoriemalade ON dbo.categoriemalade.id=dbo.malade.id_categoriemalade INNER JOIN
                                         dbo.personne ON dbo.personne.id = dbo.malade.id_personne
                   WHERE     ((dbo.hospitalisation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.hospitalisation.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, hospitalisation.datefin
                   UNION
                   SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
                   FROM         dbo.malade_avance INNER JOIN											 
                                         dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossieravance.etatpaiement = 'Cloturé payé'))and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date) MES_UNIONS PIVOT (sum(VALEUR) FOR 
                   dimension IN ([examenP], [ConsultationP],[ConsultationGP], [peconsult], [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Hospitalisation],[Nursing], 
                   [InterventionP],[Accouchement],[Avance])) AS MON_PIVOT  
            GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent,numero,Avance
go

CREATE VIEW rConsommationAbonné
AS
SELECT     nomPersonne, postNomPersonne, isnull(prenomPersonne, '-') AS prenom, numero AS numero, designEntreprise, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, 
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
                                  dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade LEFT OUTER JOIN
                                  dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                  dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                  dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                  (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                  operation_laboratoire.date, etablissementpriseencharge.denomination
           UNION
           SELECT     SUM(dbo.intervention.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 subit.date AS dateEvent, 'InterventionP' AS DIMENSION
           FROM         dbo.intervention INNER JOIN
                                 dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.subit.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.subit.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
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
           WHERE     dossierpreconsultation.etatpaiement = 'Fiche payée' AND categoriemalade.designation = 'Abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 dossierpreconsultation.date
           UNION
           SELECT     SUM(dbo.tarifconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
           FROM         dbo.tarifconsultation INNER JOIN
                                 dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.consultation.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.consultation.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 consultation.date
           UNION
           SELECT     SUM(dbo.tarifconsultationprenatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
           FROM         dbo.tarifconsultationprenatal INNER JOIN
                                 dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 dossierconsultationprenatale.date
           UNION
           SELECT     SUM(dbo.tarifechographie.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
           FROM         dbo.tarifechographie INNER JOIN
                                 dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 dossierechographie.date
           UNION
           SELECT     SUM(dbo.tarifsoin.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
           FROM         dbo.tarifsoin INNER JOIN
                                 dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 dossiersoin.date
           UNION
           SELECT     SUM(dbo.tarifnursing.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
           FROM         dbo.tarifnursing INNER JOIN
                                 dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 dossiernursing.date
           UNION
           SELECT     SUM(dbo.tarifconsultationgynecologique.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
           FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                 dbo.dossierconsultationgynecologique ON 
                                 dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 dossierconsultationgynecologique.date
           UNION
           SELECT     SUM(dbo.tarifconsultationpostnatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
           FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                 dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 dossierconsultationpostnatal.date
           UNION
           SELECT     SUM(dbo.typeaccouchement.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 accouchement.date AS dateEvent, 'Accouchement' AS DIMENSION
           FROM         dbo.typeaccouchement INNER JOIN
                                 dbo.dossieraccouchement ON dbo.typeaccouchement.id = dbo.dossieraccouchement.id_typeaccouchement LEFT OUTER JOIN
                                 dbo.accouchement ON dbo.accouchement.id_typeaccouchement = dbo.typeaccouchement.id LEFT OUTER JOIN
                                 dbo.maladegrosse ON dbo.maladegrosse.id = dbo.accouchement.id_maladegrosse LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.maladegrosse.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     (dbo.dossieraccouchement.etatpaiement = 'Payé') AND categoriemalade.designation = 'Abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 accouchement.date
           UNION
           SELECT     SUM(dbo.article.pu) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 sortie.date AS dateEvent, 'Autre_Fraie' AS DIMENSION
           FROM         dbo.article INNER JOIN
                                 dbo.sortie ON dbo.sortie.id_article = dbo.article.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.sortie.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     (dbo.sortie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, sortie.date
           UNION
           SELECT     SUM(dbo.detailsautrefraie.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
           FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON autrefraie.id=detailsautrefraie.id_autrefraie INNER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     (dbo.autrefraie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Abonné'
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
           WHERE     (dbo.hospitalisation.etatpaiement = 'Non cloturé payé' OR
                                 dbo.hospitalisation.etatpaiement = 'Cloturé payé') AND categoriemalade.designation = 'Abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 hospitalisation.datefin) MES_UNIONS PIVOT (sum(VALEUR) FOR dimension IN ([examenP], [ConsultationP], [ConsultationGP], [peconsult], 
          [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_Fraie], [Hospitalisation], [Nursing], [InterventionP], [Accouchement])) 
          AS MON_PIVOT
GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent, numero, designEntreprise
GO

CREATE VIEW rConsommationNonAbonné
AS
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
                                  dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade LEFT OUTER JOIN
                                  dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                  dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                  dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                  (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                  operation_laboratoire.date, etablissementpriseencharge.denomination
           UNION
           SELECT     SUM(dbo.intervention.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 subit.date AS dateEvent, 'InterventionP' AS DIMENSION
           FROM         dbo.intervention INNER JOIN
                                 dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.subit.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.subit.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné'
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
           WHERE     dossierpreconsultation.etatpaiement = 'Fiche payée' AND categoriemalade.designation = 'Non abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 dossierpreconsultation.date
           UNION
           SELECT     SUM(dbo.tarifconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
           FROM         dbo.tarifconsultation INNER JOIN
                                 dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.consultation.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.consultation.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 consultation.date
           UNION
           SELECT     SUM(dbo.tarifconsultationprenatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
           FROM         dbo.tarifconsultationprenatal INNER JOIN
                                 dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 dossierconsultationprenatale.date
           UNION
           SELECT     SUM(dbo.tarifechographie.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
           FROM         dbo.tarifechographie INNER JOIN
                                 dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 dossierechographie.date
           UNION
           SELECT     SUM(dbo.tarifsoin.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
           FROM         dbo.tarifsoin INNER JOIN
                                 dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 dossiersoin.date
           UNION
           SELECT     SUM(dbo.tarifnursing.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
           FROM         dbo.tarifnursing INNER JOIN
                                 dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 dossiernursing.date
           UNION
           SELECT     SUM(dbo.tarifconsultationgynecologique.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
           FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                 dbo.dossierconsultationgynecologique ON 
                                 dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 dossierconsultationgynecologique.date
           UNION
           SELECT     SUM(dbo.tarifconsultationpostnatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
           FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                 dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 dossierconsultationpostnatal.date
           UNION
           SELECT     SUM(dbo.typeaccouchement.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 accouchement.date AS dateEvent, 'Accouchement' AS DIMENSION
           FROM         dbo.typeaccouchement INNER JOIN
                                 dbo.dossieraccouchement ON dbo.typeaccouchement.id = dbo.dossieraccouchement.id_typeaccouchement LEFT OUTER JOIN
                                 dbo.accouchement ON dbo.accouchement.id_typeaccouchement = dbo.typeaccouchement.id LEFT OUTER JOIN
                                 dbo.maladegrosse ON dbo.maladegrosse.id = dbo.accouchement.id_maladegrosse LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.maladegrosse.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     (dbo.dossieraccouchement.etatpaiement = 'Payé') AND categoriemalade.designation = 'Non abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 accouchement.date
           UNION
           SELECT     SUM(dbo.article.pu) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 sortie.date AS dateEvent, 'Autre_Fraie' AS DIMENSION
           FROM         dbo.article INNER JOIN
                                 dbo.sortie ON dbo.sortie.id_article = dbo.article.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.sortie.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     (dbo.sortie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Non abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, sortie.date
           UNION
           SELECT     SUM(dbo.detailsautrefraie.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                 autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
           FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON autrefraie.id=detailsautrefraie.id_autrefraie INNER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     (dbo.autrefraie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Non abonné'
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
                                 (dbo.hospitalisation.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné'
           GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                 hospitalisation.datefin) MES_UNIONS PIVOT (sum(VALEUR) FOR dimension IN ([examenP], [ConsultationP], [ConsultationGP], [peconsult], 
          [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_Fraie], [Hospitalisation], [Nursing], [InterventionP], [Accouchement])) 
          AS MON_PIVOT
GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent, numero, designEntreprise
GO

CREATE VIEW RecetteJournaliereAbonneExterne
AS
   SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom, numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, 
          SUM(isnull([ConsultationP], 0)) AS resultatConsult, SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, 
          SUM(isnull([ConsultationPrenatale], 0)) AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, 
          SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_Fraie], 0)) 
          AS resultAutreFraie, SUM(isnull([InterventionP], 0)) AS resultIntervention, isnull([Avance],0) AS resultAvance, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) 
          + SUM(isnull([peconsult], 0)) + SUM(isnull([ConsultationPrenatale], 0)) + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) 
          + SUM(isnull([sortieArt], 0)) + SUM(isnull([Autre_Fraie], 0)) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Avance],0)) + SUM(isnull([Nursing], 0)) AS somme
FROM         (SELECT     SUM(dbo.examen.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                  dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
           FROM          dbo.examen INNER JOIN
                                  dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id LEFT OUTER JOIN
                                  dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade LEFT OUTER JOIN
                                  dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                  (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
           GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, operation_laboratoire.date
           UNION
           SELECT     SUM(dbo.intervention.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
           FROM         dbo.intervention INNER JOIN
                                 dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.subit.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.subit.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
           GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, subit.date
           UNION
           SELECT     SUM(tarifpreconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
           FROM         dossierpreconsultation INNER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     (dossierpreconsultation.etatpaiement = 'Fiche payée')  and dbo.categoriemalade.designation='Abonné'
           GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, dossierpreconsultation.date
           UNION
           SELECT     SUM(dbo.tarifconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
           FROM         dbo.tarifconsultation INNER JOIN
                                 dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.consultation.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.consultation.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
           GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, consultation.date
           UNION
           SELECT     SUM(dbo.tarifconsultationprenatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 
                                 'ConsultationPrenatale' AS DIMENSION
           FROM         dbo.tarifconsultationprenatal INNER JOIN
                                 dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
           GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, dossierconsultationprenatale.date
           UNION
           SELECT     SUM(dbo.tarifechographie.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
           FROM         dbo.tarifechographie INNER JOIN
                                 dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
           GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, dossierechographie.date
           UNION
           SELECT     SUM(dbo.tarifsoin.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
           FROM         dbo.tarifsoin INNER JOIN
                                 dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
           GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, dossiersoin.date
           UNION
           SELECT     SUM(dbo.tarifnursing.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
           FROM         dbo.tarifnursing INNER JOIN
                                 dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
           GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, dossiernursing.date
           UNION
           SELECT     SUM(dbo.tarifconsultationgynecologique.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, dossierconsultationgynecologique.date AS dateEvent, 
                                 'ConsultationGP' AS DIMENSION
           FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                 dbo.dossierconsultationgynecologique ON 
                                 dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
           GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, dossierconsultationgynecologique.date
           UNION
           SELECT     SUM(dbo.tarifconsultationpostnatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 
                                 'ConsultationPost' AS DIMENSION
           FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                 dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                 (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé'))  and dbo.categoriemalade.designation='Abonné'
           GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, dossierconsultationpostnatal.date
           UNION
           SELECT     SUM(dbo.article.pu) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                 dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
           FROM         dbo.article INNER JOIN
                                 dbo.sortie ON dbo.sortie.id_article = dbo.article.id LEFT OUTER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.sortie.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     (dbo.sortie.etatpaiement = 'Payé') and dbo.categoriemalade.designation='Abonné'
           GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, sortie.date
           UNION
           SELECT     SUM(dbo.detailsautrefraie.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                     dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
           FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                 dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade LEFT OUTER JOIN
                                 dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                 dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
           WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and dbo.categoriemalade.designation='Abonné'
           GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, autrefraie.dateenregistrement
           UNION
           SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
                   FROM         dbo.malade_avance INNER JOIN											 
                                         dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossieravance.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date) MES_UNIONS PIVOT (sum(VALEUR) FOR 
          dimension IN ([examenP], [ConsultationP], [ConsultationGP], [peconsult], [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_Fraie], 
          [Nursing], [Avance],[InterventionP])) AS MON_PIVOT
GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent, numero,Avance
go

CREATE VIEW vEntrepriseInterneAbonne
AS
SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom, numero AS numero, designEntreprise, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, 
                  SUM(isnull([ConsultationP], 0)) AS resultatConsult, SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, 
                  SUM(isnull([ConsultationPrenatale], 0)) AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, 
                  SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_Fraie], 0)) 
                  AS resultAutreFraie, SUM(isnull([Hospitalisation], 0)) AS resultHospitalisation, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([Accouchement], 0)) 
                  AS resultAccouchement, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) 
                  + SUM(isnull([ConsultationPrenatale], 0)) + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) 
                  + SUM(isnull([Autre_Fraie], 0)) + SUM(isnull([Hospitalisation], 0)) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0)) + SUM(isnull([Accouchement], 0)) AS somme
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
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' 
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
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
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
                   WHERE     dossierpreconsultation.etatpaiement = 'Fiche payée' AND categoriemalade.designation = 'Abonné'
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
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
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
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
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
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
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
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' 
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
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
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
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
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
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' 
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
                   WHERE     ((dbo.dossieraccouchement.etatpaiement = 'Non cloturé payé') OR (dbo.dossieraccouchement.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'
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
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Abonné' 
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
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Abonné' 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         autrefraie.dateenregistrement
                   UNION
                   SELECT     SUM(dbo.categoriechambre.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         etablissementpriseencharge.denomination AS designEntreprise, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         hospitalisation.datefin AS dateEvent, 'Hospitalisation' AS DIMENSION
                   FROM         dbo.hospitalisation INNER JOIN
                                         dbo.chambre ON dbo.chambre.id=dbo.hospitalisation.id_chambre INNER JOIN
                                         dbo.categoriechambre ON dbo.categoriechambre.id=dbo.chambre.id_categoriechambre INNER JOIN 
                                         dbo.malade ON dbo.malade.id=dbo.hospitalisation.id_malade INNER JOIN
                                         dbo.categoriemalade ON dbo.categoriemalade.id=dbo.malade.id_categoriemalade INNER JOIN
                                         dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id INNER JOIN
                                         dbo.personne ON dbo.personne.id = dbo.malade.id_personne
                   WHERE     ((dbo.hospitalisation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.hospitalisation.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         hospitalisation.datefin) MES_UNIONS PIVOT (sum(VALEUR) FOR dimension IN ([examenP], [ConsultationP], [ConsultationGP], [peconsult], 
                  [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Hospitalisation], [Nursing], [InterventionP], [Accouchement])) 
                  AS MON_PIVOT
GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent, numero, designEntreprise
GO

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
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' 
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
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné'  
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
                   WHERE     dossierpreconsultation.etatpaiement = 'Fiche payée' AND categoriemalade.designation = 'Abonné' 
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
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' 
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
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' 
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
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' 
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
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' 
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
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' 
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
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' 
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
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Abonné' 
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
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Abonné' 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, sortie.date
                   UNION
                   SELECT     SUM(dbo.detailsautrefraie.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             etablissementpriseencharge.denomination AS designEntreprise,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie RIGHT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id INNER JOIN
                                          dbo.etablissementpriseencharge ON malade.id_etablissement = etablissementpriseencharge.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Abonné' 
                   GROUP BY etablissementpriseencharge.denomination, dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         autrefraie.dateenregistrement) MES_UNIONS PIVOT (sum(VALEUR) FOR dimension IN ([examenP], [ConsultationP], [ConsultationGP], [peconsult], 
                  [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Nursing], [InterventionP])) 
                  AS MON_PIVOT
GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent, numero, designEntreprise 
GO

CREATE VIEW vConsommationNonAbonneInterne
AS
SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom, numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, 
                  SUM(isnull([ConsultationP], 0)) AS resultatConsult, SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, 
                  SUM(isnull([ConsultationPrenatale], 0)) AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, 
                  SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_Fraie], 0)) 
                  AS resultAutreFraie, SUM(isnull([Hospitalisation], 0)) AS resultHospitalisation, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([Accouchement], 0)) 
                  AS resultAccouchement, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) 
                  + SUM(isnull([ConsultationPrenatale], 0)) + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) 
                  + SUM(isnull([Autre_Fraie], 0)) + SUM(isnull([Hospitalisation], 0)) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0)) + SUM(isnull([Accouchement], 0)) 
                  AS somme
FROM         (SELECT     SUM(dbo.examen.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                          operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id LEFT OUTER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY  dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,operation_laboratoire.date
                   UNION
                   SELECT     SUM(dbo.intervention.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY  dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, subit.date
                   UNION
                   SELECT     SUM(tarifpreconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade LEFT OUTER JOIN
                                         hospitalisation ON dbo.malade.id=dbo.hospitalisation.id_malade INNER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     dossierpreconsultation.etatpaiement = 'Fiche payée' AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierpreconsultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,consultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationprenatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné'
                   GROUP BY  dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationprenatale.date
                   UNION
                   SELECT     SUM(dbo.tarifechographie.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierechographie.date
                   UNION
                   SELECT     SUM(dbo.tarifsoin.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id LEFT OUTER JOIN 
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossiersoin.date
                   UNION
                   SELECT     SUM(dbo.tarifnursing.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossiernursing.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationgynecologique.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationgynecologique.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationpostnatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationpostnatal.date
                   UNION
                   SELECT     SUM(dbo.typeaccouchement.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossieraccouchement.date AS dateEvent, 'Accouchement' AS DIMENSION
                   FROM         dbo.typeaccouchement INNER JOIN
                                         dbo.dossieraccouchement ON dbo.typeaccouchement.id = dbo.dossieraccouchement.id_typeaccouchement LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossieraccouchement.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     ((dbo.dossieraccouchement.etatpaiement = 'Non cloturé payé') OR (dbo.dossieraccouchement.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossieraccouchement.date
                   UNION
                   SELECT     SUM(dbo.article.pu) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, sortie.date
                   UNION
                   SELECT     SUM(dbo.detailsautrefraie.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie RIGHT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade INNER JOIN 
                                          hospitalisation on malade.id=hospitalisation.id_malade INNER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, autrefraie.dateenregistrement
                   UNION
                   SELECT     SUM(dbo.categoriechambre.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         hospitalisation.datefin AS dateEvent, 'Hospitalisation' AS DIMENSION
                   FROM         dbo.hospitalisation INNER JOIN
                                         dbo.chambre ON dbo.chambre.id=dbo.hospitalisation.id_chambre INNER JOIN
                                         dbo.categoriechambre ON dbo.categoriechambre.id=dbo.chambre.id_categoriechambre INNER JOIN 
                                         dbo.malade ON dbo.malade.id=dbo.hospitalisation.id_malade INNER JOIN
                                         dbo.categoriemalade ON dbo.categoriemalade.id=dbo.malade.id_categoriemalade INNER JOIN
                                         dbo.personne ON dbo.personne.id = dbo.malade.id_personne
                   WHERE     ((dbo.hospitalisation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.hospitalisation.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, 
                                         hospitalisation.datefin) MES_UNIONS PIVOT (sum(VALEUR) FOR dimension IN ([examenP], [ConsultationP], [ConsultationGP], [peconsult], 
                  [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Hospitalisation], [Nursing], [InterventionP], [Accouchement])) 
                  AS MON_PIVOT
GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent, numero 
GO

CREATE VIEW vConsommationNonAbonneExterne
AS
SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom, numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, 
                  SUM(isnull([ConsultationP], 0)) AS resultatConsult, SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, 
                  SUM(isnull([ConsultationPrenatale], 0)) AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, 
                  SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_Fraie], 0)) 
                  AS resultAutreFraie, SUM(isnull([InterventionP], 0)) AS resultIntervention, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) + SUM(isnull([peconsult], 0)) 
                  + SUM(isnull([ConsultationPrenatale], 0)) + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) + SUM(isnull([sortieArt], 0)) 
                  + SUM(isnull([Autre_Fraie], 0)) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Nursing], 0))  
                  AS somme
FROM         (SELECT     SUM(dbo.examen.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                          operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id LEFT OUTER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné'
                   GROUP BY  dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,operation_laboratoire.date
                   UNION
                   SELECT     SUM(dbo.intervention.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY  dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, subit.date
                   UNION
                   SELECT     SUM(tarifpreconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     dossierpreconsultation.etatpaiement = 'Fiche payée' AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierpreconsultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,consultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationprenatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationprenatale.date AS dateEvent, 'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY  dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationprenatale.date
                   UNION
                   SELECT     SUM(dbo.tarifechographie.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierechographie.date
                   UNION
                   SELECT     SUM(dbo.tarifsoin.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id LEFT OUTER JOIN 
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossiersoin.date
                   UNION
                   SELECT     SUM(dbo.tarifnursing.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossiernursing.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationgynecologique.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationgynecologique.date AS dateEvent, 'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationgynecologique.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationpostnatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         dossierconsultationpostnatal.date AS dateEvent, 'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero,dossierconsultationpostnatal.date
                   UNION
                   SELECT     SUM(dbo.article.pu) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne,dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, 
                                         sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, sortie.date
                   UNION
                   SELECT     SUM(dbo.detailsautrefraie.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie RIGHT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id INNER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id 
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') AND categoriemalade.designation = 'Non abonné' 
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, autrefraie.dateenregistrement) MES_UNIONS PIVOT (sum(VALEUR) FOR dimension IN ([examenP], [ConsultationP], [ConsultationGP], [peconsult], 
                  [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_fraie], [Nursing], [InterventionP])) 
                  AS MON_PIVOT
GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent, numero 
go

CREATE VIEW vRecetteJournaliereNonAbonneExterne
AS
           SELECT     nomPersonne, isnull(postNomPersonne, '-') AS postNomPersonne, isnull(prenomPersonne, '-') AS prenom, numero AS numero, dateEvent, SUM(isnull([examenP], 0)) AS resultatEx, 
                  SUM(isnull([ConsultationP], 0)) AS resultatConsult, SUM(isnull([ConsultationGP], 0)) AS resultatConsultG, SUM(isnull([peconsult], 0)) AS resultPrecon, 
                  SUM(isnull([ConsultationPrenatale], 0)) AS resultPrenatal, SUM(isnull([ConsultationPost], 0)) AS resulConsultPost, SUM(isnull([Echographie], 0)) AS resulEchographie, 
                  SUM(isnull([Soins], 0)) AS resulSoins, SUM(isnull([sortieArt], 0)) AS resultSortieArt, SUM(isnull([Nursing], 0)) AS resultNursing, SUM(isnull([Autre_Fraie], 0)) 
                  AS resultAutreFraie, SUM(isnull([InterventionP], 0)) AS resultIntervention, isnull([Avance],0) AS resultAvance, SUM(isnull([examenP], 0)) + SUM(isnull([ConsultationP], 0)) + SUM(isnull([ConsultationGP], 0)) 
                  + SUM(isnull([peconsult], 0)) + SUM(isnull([ConsultationPrenatale], 0)) + SUM(isnull([ConsultationPost], 0)) + SUM(isnull([Echographie], 0)) + SUM(isnull([Soins], 0)) 
                  + SUM(isnull([sortieArt], 0)) + SUM(isnull([Autre_Fraie], 0)) + SUM(isnull([InterventionP], 0)) + SUM(isnull([Avance],0)) + SUM(isnull([Nursing], 0)) AS somme
FROM         (SELECT     SUM(dbo.examen.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                          dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, operation_laboratoire.date AS dateEvent, 'examenP' AS DIMENSION
                   FROM          dbo.examen INNER JOIN
                                          dbo.operation_laboratoire ON dbo.operation_laboratoire.id_examen = dbo.examen.id LEFT OUTER JOIN
                                          dbo.malade ON dbo.malade.id = dbo.operation_laboratoire.id_malade LEFT OUTER JOIN
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE      ((dbo.operation_laboratoire.etatpaiement = 'Non cloturé payé') OR
                                          (dbo.operation_laboratoire.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, operation_laboratoire.date
                   UNION
                   SELECT     SUM(dbo.intervention.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, subit.date AS dateEvent, 'InterventionP' AS DIMENSION
                   FROM         dbo.intervention INNER JOIN
                                         dbo.subit ON dbo.subit.id_intervention = dbo.intervention.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.subit.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.subit.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.subit.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, subit.date
                   UNION
                   SELECT     SUM(tarifpreconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, dossierpreconsultation.date AS dateEvent, 'peconsult' AS DIMENSION
                   FROM         dossierpreconsultation INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierpreconsultation.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         tarifpreconsultation ON dossierpreconsultation.id_tarifpreconsultation = tarifpreconsultation.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dossierpreconsultation.etatpaiement = 'Fiche payée') and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, dossierpreconsultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultation.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, consultation.date AS dateEvent, 'ConsultationP' AS DIMENSION
                   FROM         dbo.tarifconsultation INNER JOIN
                                         dbo.consultation ON dbo.consultation.id_tarifconsultation = dbo.tarifconsultation.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.consultation.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.consultation.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.consultation.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, consultation.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationprenatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, dossierconsultationprenatale.date AS dateEvent, 
                                         'ConsultationPrenatale' AS DIMENSION
                   FROM         dbo.tarifconsultationprenatal INNER JOIN
                                         dbo.dossierconsultationprenatale ON dbo.dossierconsultationprenatale.id_tarifconsultationprenatal = dbo.tarifconsultationprenatal.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationprenatale.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationprenatale.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationprenatale.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, dossierconsultationprenatale.date
                   UNION
                   SELECT     SUM(dbo.tarifechographie.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, dossierechographie.date AS dateEvent, 'Echographie' AS DIMENSION
                   FROM         dbo.tarifechographie INNER JOIN
                                         dbo.dossierechographie ON dbo.dossierechographie.id_tarifechographie = dbo.tarifechographie.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierechographie.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierechographie.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierechographie.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, dossierechographie.date
                   UNION
                   SELECT     SUM(dbo.tarifsoin.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, dossiersoin.date AS dateEvent, 'Soins' AS DIMENSION
                   FROM         dbo.tarifsoin INNER JOIN
                                         dbo.dossiersoin ON dbo.dossiersoin.id_tarifsoin = dbo.tarifsoin.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiersoin.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiersoin.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiersoin.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, dossiersoin.date
                   UNION
                   SELECT     SUM(dbo.tarifnursing.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, dossiernursing.date AS dateEvent, 'Nursing' AS DIMENSION
                   FROM         dbo.tarifnursing INNER JOIN
                                         dbo.dossiernursing ON dbo.dossiernursing.id_tarifnursing = dbo.tarifnursing.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossiernursing.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossiernursing.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossiernursing.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, dossiernursing.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationgynecologique.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, dossierconsultationgynecologique.date AS dateEvent, 
                                         'ConsultationGP' AS DIMENSION
                   FROM         dbo.tarifconsultationgynecologique INNER JOIN
                                         dbo.dossierconsultationgynecologique ON 
                                         dbo.dossierconsultationgynecologique.id_tarifconsultationgynecologique = dbo.tarifconsultationgynecologique.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationgynecologique.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationgynecologique.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationgynecologique.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, dossierconsultationgynecologique.date
                   UNION
                   SELECT     SUM(dbo.tarifconsultationpostnatal.montant) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, dossierconsultationpostnatal.date AS dateEvent, 
                                         'ConsultationPost' AS DIMENSION
                   FROM         dbo.tarifconsultationpostnatal INNER JOIN
                                         dbo.dossierconsultationpostnatal ON dbo.dossierconsultationpostnatal.id_tarifconsultationpostnatal = dbo.tarifconsultationpostnatal.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.dossierconsultationpostnatal.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossierconsultationpostnatal.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossierconsultationpostnatal.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, dossierconsultationpostnatal.date
                   UNION
                   SELECT     SUM(dbo.article.pu) AS VALEUR,dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, sortie.date AS dateEvent, 'sortieArt' AS DIMENSION
                   FROM         dbo.article INNER JOIN
                                         dbo.sortie ON dbo.sortie.id_article = dbo.article.id LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.sortie.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.sortie.etatpaiement = 'Payé') and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom,dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, sortie.date
                   UNION
                   SELECT     SUM(dbo.detailsautrefraie.prix) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                             dbo.personne.prenom AS prenomPersonne, dbo.malade.numero AS numero, autrefraie.dateenregistrement AS dateEvent, 'Autre_Fraie' AS DIMENSION
                   FROM         dbo.detailsautrefraie INNER JOIN dbo.autrefraie ON dbo.autrefraie.id = dbo.detailsautrefraie.id_autrefraie INNER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.autrefraie.id_malade LEFT OUTER JOIN
                                         dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     (dbo.autrefraie.etatpaiement = 'Payé') and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom, dbo.malade.numero, autrefraie.dateenregistrement
                   UNION
                   SELECT     MAX(dbo.malade_avance.cumul) AS VALEUR, dbo.personne.nom AS nomPersonne, dbo.personne.postnom AS postNomPersonne, 
                                         dbo.personne.prenom AS prenomPersonne,dbo.malade.numero AS numero, dossieravance.date AS dateEvent, 'Avance' AS DIMENSION
                   FROM         dbo.malade_avance INNER JOIN											 
                                         dbo.dossieravance ON dbo.dossieravance.id = dbo.malade_avance.id_dossieravance LEFT OUTER JOIN
                                         dbo.malade ON dbo.malade.id = dbo.malade_avance.id_malade INNER JOIN 
                                          dbo.personne ON dbo.malade.id_personne = dbo.personne.id LEFT OUTER JOIN
                                         dbo.categoriemalade ON dbo.malade.id_categoriemalade = dbo.categoriemalade.id
                   WHERE     ((dbo.dossieravance.etatpaiement = 'Non cloturé payé') OR
                                         (dbo.dossieravance.etatpaiement = 'Cloturé payé')) and dbo.categoriemalade.designation='Non abonné'
                   GROUP BY dbo.personne.nom, dbo.personne.postnom, dbo.personne.prenom,dbo.malade.numero, dossieravance.date) MES_UNIONS PIVOT (sum(VALEUR) FOR 
                  dimension IN ([examenP], [ConsultationP],[Avance], [ConsultationGP], [peconsult], [ConsultationPrenatale], [ConsultationPost], [Echographie], [Soins], [sortieArt], [Autre_Fraie], 
                  [Nursing], [InterventionP])) AS MON_PIVOT
GROUP BY nomPersonne, postNomPersonne, prenomPersonne, dateEvent,numero,Avance
go

--Vue permettant d'avoir le nombre des livraisons pour chaque date
CREATE VIEW allEntreeStk
AS
	SELECT livraison.date AS dateE,COUNT(livraison.date) AS nbr_E from livraison
	GROUP BY livraison.date
go

--Vue permettant d'avoir le nombre des sorties pour chaque date
CREATE VIEW allSortieStk
AS
	SELECT sortie.date AS dateS,COUNT(sortie.date) AS nbr_S from sortie
	GROUP BY sortie.date
go

CREATE TRIGGER misajour_sortiecancel_insert ON sortie AFTER INSERT AS 
BEGIN
	DECLARE @id_sortie int,@id_article int,@id_service int,@id_malade int,@quantinte int,@montant float,@date smalldatetime,
	@sortiemalade bit,@etatpaiement varchar(50)
	
	SELECT @id_sortie=id,@id_article=id_article,@id_service=id_service,@id_malade=id_malade,@date=date,@quantinte=quantinte,@montant=montant,@sortiemalade=sortiemalade,@etatpaiement=etatpaiement FROM INSERTED
	INSERT INTO sortiecancel(id_sortie,id_article,id_service,id_malade,date,quantinte,montant,sortiemalade,etatpaiement)
	VALUES (@id_sortie,@id_article,@id_service,@id_malade,@date,@quantinte,@montant,@sortiemalade,@etatpaiement)
END 
go  

--Création du trigger qui sera  chargé de chaque fois mettre à jour (Update) les records de sortie
--dans la table sortiecancel
CREATE TRIGGER misajour_sortiecancel_update ON sortie AFTER UPDATE AS 
BEGIN
	DECLARE @id_sortie int,@id_article int,@id_service int,@id_malade int,@quantinte int,@montant float,@date smalldatetime,
	@sortiemalade bit,@etatpaiement varchar(50)
	
	SELECT @id_sortie=id,@id_article=id_article,@id_service=id_service,@id_malade=id_malade,@date=date,@quantinte=quantinte,@montant=montant,@sortiemalade=sortiemalade,@etatpaiement=etatpaiement FROM INSERTED
	UPDATE sortiecancel SET id_sortie=@id_sortie,id_article=@id_article,id_service=@id_service,id_malade=@id_malade,date=@date,quantinte=@quantinte,montant=@montant,sortiemalade=@sortiemalade,etatpaiement=@etatpaiement
	WHERE id_sortie=@id_sortie
END 
go   

--drop trigger misajour_sortiecancel_delete1
--Création du trigger qui sera  chargé de supprimer une ligne de sortie quand celle-ci a été supprimée dans sortiecancel
CREATE TRIGGER misajour_sortiecancel_delete ON sortiecancel AFTER DELETE AS 
BEGIN
	DECLARE @id_sortie int
	
	SELECT @id_sortie=id_sortie FROM DELETED
	--DELETE FROM sortie WHERE id=@id_sortie
	DELETE FROM sortie WHERE id=@id_sortie
END 
go    
   
                   