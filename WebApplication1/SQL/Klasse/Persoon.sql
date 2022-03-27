DROP TABLE IF EXISTS Persoon;

CREATE TABLE Persoon
(
    persoon_id INT NOT NULL AUTO_INCREMENT,
    voornaam varchar(50),
    achternaam varchar(50),
        PRIMARY KEY(persoon_id,voornaam,achternaam)
);

INSERT INTO Persoon (voornaam, achternaam)  VALUE('Nigel', 'Terpstra');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('Egon', '$%^GHRTH');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('piet','jan');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('janus', 'u56u$%^&--');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('--t345t!//', 'gesla');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('ruben', 'jan');