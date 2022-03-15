DROP TABLE IF EXISTS StatusUitgave;

CREATE TABLE StatusUitgave
(
    status            BOOL,
    datum_goedkeuring DATE,
    gebruiker_id     varchar(255) NOT NULL,
    uitgave_id                INT NOT NULL,
    PRIMARY KEY (gebruiker_id, uitgave_id),
    FOREIGN KEY (gebruiker_id) REFERENCES Gebruiker (Id),
    FOREIGN KEY (uitgave_id) REFERENCES Uitgave (uitgave_id)
);


INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, uitgave_id) VALUE(true,'5930-12-6',2,1);
INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, uitgave_id) VALUE(false,'130-12-6',4,3);
INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, uitgave_id) VALUE(true,'1930-12-6',2,4);
INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, uitgave_id) VALUE(false,'2930-12-6',3,8);
INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, uitgave_id) VALUE(false,'1530-12-6',3,2);
INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, uitgave_id) VALUE(false,'1936-12-6',3,3);
INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, uitgave_id) VALUE(true,'6516-12-6',3,5);
INSERT INTO StatusUitgave (status, datum_goedkeuring, gebruiker_id, uitgave_id) VALUE(true,'1990-12-6',3,6);
