DROP TABLE IF EXISTS StatusUitgave;

CREATE TABLE StatusUitgave
(
    status            BOOL,
    datum_goedkeuring DATE,
    gebruiker_id     varchar(255) NOT NULL,
    versie_id                INT NOT NULL,
    FOREIGN KEY (gebruiker_id) REFERENCES Gebruiker (Id),
    FOREIGN KEY (versie_id) REFERENCES Versie (versie_id)
);


INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, versie_id) VALUE(true,'5930-12-6',2,1);
INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, versie_id) VALUE(false,'130-12-6',4,3);
INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, versie_id) VALUE(true,'1930-12-6',2,4);
INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, versie_id) VALUE(false,'2930-12-6',3,8);
INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, versie_id) VALUE(false,'1530-12-6',3,2);
INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, versie_id) VALUE(false,'1936-12-6',3,3);
INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, versie_id) VALUE(true,'6516-12-6',3,5);
INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, versie_id) VALUE(true,'1990-12-6',3,6);
