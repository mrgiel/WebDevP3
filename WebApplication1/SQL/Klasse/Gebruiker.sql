DROP TABLE IF EXISTS Gebruiker;

CREATE TABLE Gebruiker
(
    gebruiker_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    gebruikersnaam VARCHAR(30) NOT NULL UNIQUE,
    rol ENUM('admin', 'gebruiker', 'moderator') NOT NULL,
    mail VARCHAR(100) NOT NULL,
    18_plus BOOLEAN NOT NULL,
    password VARCHAR(512) NOT NULL
);

INSERT INTO Gebruiker (gebruikersnaam, rol, mail, 18_plus, password) VALUES ('ruho20', 'moderator', 'ruben.hoekuma@hotmail.com', True, MD5('wachtwoord1'));
INSERT INTO Gebruiker (gebruikersnaam, rol, mail, 18_plus, password) VALUES ('gk', 'moderator', 'g.k@ogmail.com', True, MD5('wachtwoord2'));
INSERT INTO Gebruiker (gebruikersnaam, rol, mail, 18_plus, password) VALUES ('mrgiel', 'gebruiker', 'mr.giel@mail.com', False, MD5('wachtwoord3'));
INSERT INTO Gebruiker (gebruikersnaam, rol, mail, 18_plus, password) VALUES ('nigel', 'moderator', 'nigel@hotmail.com', True, MD5('wachtwoord4'));
INSERT INTO Gebruiker (gebruikersnaam, rol, mail, 18_plus, password) VALUES ('tim', 'moderator', 'tim.stokkers@hotmail.com', True, MD5('wachtwoord5'));