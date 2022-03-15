DROP TABLE IF EXISTS Versie;

CREATE TABLE Versie
(
    Versie_id INT NOT NULL PRIMARY KEY  AUTO_INCREMENT,
    isbn VARCHAR(50) UNIQUE ,
    datum DATE,
    druk INT NOT NULL,
    prijs decimal(6,2),
    uitgever_id INT NOT NULL,
    uitgave_id INT NOT NULL,
    FOREIGN KEY (uitgever_id) REFERENCES Uitgever (uitgever_id),
    FOREIGN KEY (uitgave_id) REFERENCES Uitgave (uitgave_id)
);
INSERT INTO Versie (isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('345345','1995-2-4',1,7,5,6);
INSERT INTO Versie (isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('6456456','1993-2-4',1,2,8,3);
INSERT INTO Versie (isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('45645645','991-4-23',1,0,8,1);
INSERT INTO Versie (isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('34565465','1999-7-24',1,3,3,7);
INSERT INTO Versie (isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('234234','1993-5-9',1,8,8,2);
INSERT INTO Versie (isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('64565456','196-3-19',1,2,7,2);
INSERT INTO Versie (isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('6786878','290-4-16',1,1,3,2);
INSERT INTO Versie (isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('64564567','1190-6-13',1,0,7,2);
INSERT INTO Versie (isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('567','2004-4-4',1,.89,8,1);
INSERT INTO Versie (isbn, datum, druk, prijs, uitgave_id,uitgever_id)  VALUE ('123123','1999-2-20',1,6,7,2);