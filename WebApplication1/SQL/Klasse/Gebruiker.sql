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

INSERT INTO Gebruiker (Id, UserName, rol, Email, 18_plus, PasswordHash) VALUES ('1','ruho20', 'moderator', 'ruben.hoekuma@hotmail.com', True, MD5('wachtwoord1'));
INSERT INTO Gebruiker (Id,UserName, rol, Email, 18_plus, PasswordHash) VALUES ('2','gk', 'moderator', 'g.k@ogmail.com', True, MD5('wachtwoord2'));
INSERT INTO Gebruiker (Id,UserName, rol, Email, 18_plus, PasswordHash) VALUES ('3','mrgiel', 'gebruiker', 'mr.giel@mail.com', False, MD5('wachtwoord3'));
INSERT INTO Gebruiker (Id,UserName, rol, Email, 18_plus, PasswordHash) VALUES ('4','nigel', 'moderator', 'nigel@hotmail.com', True, MD5('wachtwoord4'));
INSERT INTO Gebruiker (Id,UserName, rol, Email, 18_plus, PasswordHash) VALUES ('5','tim', 'moderator', 'tim.stokkers@hotmail.com', True, MD5('wachtwoord5'));