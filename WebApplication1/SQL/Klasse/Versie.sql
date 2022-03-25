DROP TABLE IF EXISTS Versie;

CREATE TABLE Versie
(
    Versie_id INT NOT NULL PRIMARY KEY  AUTO_INCREMENT,
    afbeelding_url varchar(200),
    isbn VARCHAR(50),
    datum DATE,
    druk INT NOT NULL,
    prijs decimal(6,2),
    uitgever_id INT NOT NULL,
    uitgave_id INT NOT NULL,
    FOREIGN KEY (uitgever_id) REFERENCES Uitgever (uitgever_id),
    FOREIGN KEY (uitgave_id) REFERENCES Uitgave (uitgave_id)
);
INSERT INTO Versie (afbeelding_url,isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://i.ibb.co/G3xrpYC/cover-250x350-3.jpg','345345','1995-2-4',1,7,5,6);
INSERT INTO Versie (afbeelding_url,isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://i.ibb.co/PN36DbY/cover-250x350-2.jpg','6456456','1993-2-4',1,2,8,3);
INSERT INTO Versie (afbeelding_url,isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://i.ibb.co/7KwJM7h/cover-250x350-1.jpg','45645645','991-4-23',1,0,8,1);
INSERT INTO Versie (afbeelding_url,isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://i.ibb.co/3MwC4s7/cover-250x350.jpg','34565465','1999-7-24',1,3,3,7);
INSERT INTO Versie (afbeelding_url,isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://i.ibb.co/3MwC4s7/cover-250x350.jpg'',''34565465','234234','1993-5-9',1,8,8,2);
INSERT INTO Versie (afbeelding_url,isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://i.ibb.co/3MwC4s7/cover-250x350.jpg','64565456','196-3-19',1,2,7,2);
INSERT INTO Versie (afbeelding_url,isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://i.ibb.co/7KwJM7h/cover-250x350-1.jpg','6786878','290-4-16',1,1,3,2);
INSERT INTO Versie (afbeelding_url,isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('https://i.ibb.co/G3xrpYC/cover-250x350-3.jpg','64564567','1190-6-13',1,0,7,2);
