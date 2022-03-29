### Maak table Categorie
DROP TABLE IF EXISTS Categorie;

CREATE TABLE Categorie
(
    cat_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    cat_naam VARCHAR(30) UNIQUE
);

###Maak table Reeks
DROP TABLE IF EXISTS Reeks;

CREATE TABLE Reeks
(
    reeks_id   int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    reeks_naam varchar(100) null unique
);

###Maak table Gebruiker
DROP TABLE IF EXISTS Gebruiker;

CREATE TABLE Gebruiker
(
    Id varchar(255) not null,
    rol ENUM('admin', 'gebruiker', 'moderator') NOT NULL,
    18_plus BOOLEAN DEFAULT FALSE NOT NULL,

    UserName varchar(256) null,
    NormalizedUserName varchar(256) null,
    Email varchar(256) null,
    NormalizedEmail varchar(256) null,
    EmailConfirmed tinyint(1) DEFAULT FALSE not null,
    PasswordHash longtext null,
    SecurityStamp longtext null,
    ConcurrencyStamp longtext null,
    PhoneNumber longtext     null,
    PhoneNumberConfirmed tinyint(1)  DEFAULT FALSE not null,
    TwoFactorEnabled tinyint(1) DEFAULT FALSE not null,
    LockoutEnd datetime(6) DEFAULT 0 null,
    LockoutEnabled tinyint(1) DEFAULT TRUE  not null,
    AccessFailedCount int DEFAULT 0 not null,
    PRIMARY KEY (Id),
    constraint UserNameIndex
        unique (NormalizedUserName)

);
create index EmailIndex
    on Gebruiker (NormalizedEmail);


###Maak table Uitgave
DROP TABLE IF EXISTS Uitgave;

CREATE TABLE Uitgave
(
    uitgave_id             INT AUTO_INCREMENT PRIMARY KEY,
    naam           varchar(100) NOT NULL,
    hoogte         INT,
    beschrijving   VARCHAR(255),
    nsfw           BOOL         NOT NULL DEFAULT False,
    cat_id         INT,
    reeks_id       INT,
    FOREIGN KEY (cat_id) REFERENCES Categorie (cat_id),
    FOREIGN KEY (reeks_id) REFERENCES Reeks (reeks_id)
);

###Maak table Persoon
DROP TABLE IF EXISTS Persoon;

CREATE TABLE Persoon
(
    persoon_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    voornaam varchar(30) NOT NULL,
    achternaam varchar(30) NOT NULL
);

###Maak table Uitgever
DROP TABLE IF EXISTS Uitgever;

CREATE TABLE Uitgever
(
    uitgever_id   int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    uitgever_naam varchar(100) NOT NULL unique
);

###Maak table Versie
DROP TABLE IF EXISTS Versie;

CREATE TABLE Versie
(
    Versie_id INT NOT NULL PRIMARY KEY  AUTO_INCREMENT,
    afbeelding_url varchar(200),
    isbn VARCHAR(50) UNIQUE,
    datum DATE,
    druk INT NOT NULL,
    prijs decimal(6,2),
    uitgever_id INT NOT NULL,
    uitgave_id INT NOT NULL,
    FOREIGN KEY (uitgever_id) REFERENCES Uitgever (uitgever_id),
    FOREIGN KEY (uitgave_id) REFERENCES Uitgave (uitgave_id)
);

###Maak table Bezit
DROP TABLE IF EXISTS BEZIT;

CREATE TABLE Bezit
(
    rating INT DEFAULT 1,
    staat ENUM('slecht', 'gemiddeld', 'goed') NOT NULL,
    beschrijving VARCHAR(255),
    hoeveelheid INT DEFAULT 1,
    prijs_betaald DECIMAL(6,2) DEFAULT 0.00,
    gebruiker_id varchar(255) NOT NULL,
    versie_id INT NOT NULL,
    PRIMARY KEY (gebruiker_id, versie_id),
    FOREIGN KEY (gebruiker_id) REFERENCES Gebruiker(Id),
    FOREIGN KEY (versie_id) REFERENCES Versie(versie_id)
);

###Maak table IsGemaaktDoor
DROP TABLE IF EXISTS IsGemaaktDoor;

CREATE TABLE IsGemaaktDoor
(
    rol ENUM('Auteur', 'Tekenaar') NOT NULL,
    persoon_id INT NOT NULL,
    versie_id INT NOT NULL,
    PRIMARY KEY (rol, persoon_id, versie_id),
    FOREIGN KEY (persoon_id) REFERENCES Persoon (persoon_id),
    FOREIGN KEY (versie_id) REFERENCES Versie(versie_id)
);

###Maak table StatusUitgave
DROP TABLE IF EXISTS StatusUitgave;

CREATE TABLE StatusUitgave
(
    status            BOOL DEFAULT FALSE,
    datum_goedkeuring DATE,
    gebruiker_id     varchar(255) NOT NULL,
    versie_id                INT NOT NULL,
    FOREIGN KEY (gebruiker_id) REFERENCES Gebruiker (Id),
    FOREIGN KEY (versie_id) REFERENCES Versie (versie_id)
);

###Maak alle tables voor het inloggen
DROP TABLE IF EXISTS _efmigrationshistory;

CREATE TABLE _efmigrationshistory
(
    MigrationId    varchar(150) not null
        primary key,
    ProductVersion varchar(32)  not null
);

INSERT INTO _efmigrationshistory (migrationid, productversion) VALUE ('20220315193554_naam','5.0.14');
DROP TABLE IF EXISTS Role;

CREATE TABLE Role (
                      Id varchar(255) NOT NULL PRIMARY KEY,
                      Name varchar(255),
                      NormalizedName varchar(255),
                      ConcurrencyStamp longtext
);
DROP TABLE IF EXISTS roleclaims;

create table roleclaims
(
    Id         int auto_increment
        primary key,
    RoleId     varchar(255) not null,
    ClaimType  longtext     null,
    ClaimValue longtext     null,
    constraint FK_RoleClaims_Role_RoleId
        foreign key (RoleId) references role (Id)
            on delete cascade
);

create index IX_RoleClaims_RoleId
    on roleclaims (RoleId);
DROP TABLE IF EXISTS userclaims;

create table userclaims
(
    Id         int auto_increment
        primary key,
    UserId     varchar(255) not null,
    ClaimType  longtext     null,
    ClaimValue longtext     null,
    constraint FK_UserClaims_Gebruiker_UserId
        foreign key (UserId) references Gebruiker (Id)
            on delete cascade
);

create index IX_UserClaims_UserId
    on userclaims (UserId);

DROP TABLE IF EXISTS UserLogins;

CREATE TABLE UserLogins (
                            LoginProvider varchar(255) NOT NULL,
                            ProviderKey varchar(255) NOT NULL,
                            ProviderDisplayName longtext NULL,
                            UserID varchar(255) NOT NULL,
                            PRIMARY KEY (LoginProvider,ProviderKey),
                            FOREIGN KEY (UserID) REFERENCES Gebruiker(Id)
);

DROP TABLE IF EXISTS userroles;

create table userroles
(
    UserId varchar(255) not null,
    RoleId varchar(255) not null,
    primary key (UserId, RoleId),
    constraint FK_UserRoles_Gebruiker_UserId
        foreign key (UserId) references Gebruiker (Id)
            on delete cascade,
    constraint FK_UserRoles_Role_RoleId
        foreign key (RoleId) references role (Id)
            on delete cascade
);

create index IX_UserRoles_RoleId
    on userroles (RoleId);

DROP TABLE IF EXISTS UserTokens;

CREATE TABLE UserTokens(
                           UserID varchar(255) NOT NULL ,
                           LoginProvider varchar(255) NOT NULL,
                           Name varchar(255) NOT NULL,
                           Value longtext NULL,
                           FOREIGN KEY (UserID) REFERENCES Gebruiker(Id),
                           PRIMARY KEY(UserID,LoginProvider)
)



