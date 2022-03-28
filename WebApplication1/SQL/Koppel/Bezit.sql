DROP TABLE IF EXISTS BEZIT;

CREATE TABLE Bezit
(
    rating INT DEFAULT 1,
    staat ENUM('slecht', 'gemiddeld', 'goed'),
    beschrijving VARCHAR(255),
    hoeveelheid INT DEFAULT 1,
    prijs_betaald DECIMAL(6,2) DEFAULT 0.00,
    gebruiker_id varchar(255) NOT NULL,
    versie_id INT NOT NULL,
    PRIMARY KEY (gebruiker_id, versie_id),
    FOREIGN KEY (gebruiker_id) REFERENCES Gebruiker(Id),
    FOREIGN KEY (versie_id) REFERENCES Versie(versie_id)
);

INSERT INTO Bezit (rating, staat, beschrijving, hoeveelheid, prijs_betaald, gebruiker_id, versie_id) VALUES (4, 'slecht', 'mooi boek hoor!', 1, 40.32, 1, 1);
INSERT INTO Bezit (rating, staat, beschrijving, hoeveelheid, prijs_betaald, gebruiker_id, versie_id) VALUES (8, 'gemiddeld', 'leuke herrineringen aan.', 2, 30.32, 1, 4);
INSERT INTO Bezit (rating, staat, beschrijving, hoeveelheid, prijs_betaald, gebruiker_id, versie_id) VALUES (4, 'slecht', 'wat een slechte plaatjes', 1, 10.32, 1, 3);
INSERT INTO Bezit (rating, staat, beschrijving, hoeveelheid, prijs_betaald, gebruiker_id, versie_id) VALUES (4, 'goed', 'mooi boek van mijn kleinkinderen gekregen', 2, 10.50, 2, 1);
INSERT INTO Bezit (rating, staat, beschrijving, hoeveelheid, prijs_betaald, gebruiker_id, versie_id) VALUES (4, 'gemiddeld', 'veel te duur! Maar wel een leuk boekje', 1, 1140.32, 1,8);
INSERT INTO Bezit (rating, staat, beschrijving, hoeveelheid, prijs_betaald, gebruiker_id, versie_id) VALUES (4, 'slecht', 'het einde was niet wat ik had gedacht', 1, 60.32, 1, 9);
INSERT INTO Bezit (rating, staat, beschrijving, hoeveelheid, prijs_betaald, gebruiker_id, versie_id) VALUES (4, 'slecht', 'mooi boek voor als je je verveeld', 1, 120.10, 2, 8);