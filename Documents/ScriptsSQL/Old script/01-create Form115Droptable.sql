USE form115

--suppression des tables de la BDD Form115 si elles existent


if EXISTS (select name FROM sys.sysobjects WHERE type = 'U' and name = 'Reservations')

DROP TABLE Reservations;

if EXISTS (select name FROM sys.sysobjects WHERE type = 'U' and name = 'Utilisateurs')

DROP TABLE Utilisateurs;

if EXISTS (select name FROM sys.sysobjects WHERE type = 'U' and name = 'Produits')

DROP TABLE Produits;

if EXISTS (select name FROM sys.sysobjects WHERE type = 'U' and name = 'Sejours')

DROP TABLE Sejours;

if EXISTS (select name FROM sys.sysobjects WHERE type = 'U' and name = 'Hotels')

DROP TABLE Hotels;

if EXISTS (select name FROM sys.sysobjects WHERE type = 'U' and name = 'Categories')

DROP TABLE Categories;


if EXISTS (select name FROM sys.sysobjects WHERE type = 'U' and name = 'Villes')

DROP TABLE Villes;

if EXISTS (select name FROM sys.sysobjects WHERE type = 'U' and name = 'Pays')

DROP TABLE Pays;


if EXISTS (select name FROM sys.sysobjects WHERE type = 'U' and name = 'Regions')

DROP TABLE Regions;

if EXISTS (select name FROM sys.sysobjects WHERE type = 'U' and name = 'Continents')

DROP TABLE Continents;









-- Création Table


CREATE TABLE Produits ( 
	IdProduit			   int       NOT NULL IDENTITY,
	IdSejour               int       NOT NULL   ,
	NbPlaces               int       NOT NULL   ,
	DateDepart             date      NOT NULL   ,
	Prix				   numeric         ,
	CONSTRAINT Pk_Produits PRIMARY KEY ( IdProduit )
 );


CREATE TABLE Sejours ( 
	IdSejour             int NOT NULL   IDENTITY,
	IdHotel              int NOT NULL   ,
	Duree				 tinyint    NOT NULL,
	CONSTRAINT Pk_Sejours PRIMARY KEY ( IdSejour )
 );

 
CREATE TABLE Hotels ( 
	IdHotel              int NOT NULL    IDENTITY,
	Nom					 nvarchar(60),
	IdVille				 int,
	Categorie            tinyint,
	Description          ntext           ,
	Photo				 varchar(60),
	CONSTRAINT Pk_Hotels PRIMARY KEY ( IdHotel )
 );

 CREATE TABLE Categories ( 
	IdCategorie       tinyint IDENTITY,
	Description       varchar(20)  NOT NULL,
	CONSTRAINT Pk_Categorie PRIMARY KEY (IdCategorie)
	 );
	   
 
CREATE TABLE Reservations ( 
	IdReservation		int NOT NULL    IDENTITY,
	IdProduit           int NOT NULL ,
	Quantity			int NOT NULL,
	IdUtilisateur		int NOT NULL,
	CONSTRAINT Pk_Reservations PRIMARY KEY ( IdReservation )
 );

   
CREATE TABLE Utilisateurs ( 
	IdUtilisateur	int NOT NULL    IDENTITY,
	Nom				nvarchar(60) ,
	Prenom			nvarchar(60) ,
	Telephone		varchar(12) ,
	CONSTRAINT Pk_Utilisateurs PRIMARY KEY ( IdUtilisateur )
);

