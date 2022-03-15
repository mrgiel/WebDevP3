DROP TABLE IF EXISTS Persoon;

CREATE TABLE Persoon
(
    persoon_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    voornaam varchar(30) NOT NULL,
    achternaam varchar(30) NOT NULL
);

INSERT INTO Persoon (voornaam, achternaam)  VALUE('Nigel', 'Terpstra');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('Egon', '$%^GHRTH');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('piet','jan');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('janus', 'u56u$%^&--');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('--t345t!//', 'gesla');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('ruben', 'jan');