DROP TABLE IF EXISTS Uitgever;

CREATE TABLE Uitgever
(
    uitgever_id   int AUTO_INCREMENT PRIMARY KEY NOT NULL,
    uitgever_naam varchar(100) NOT NULL unique 
);

INSERT INTO Uitgever (uitgever_naam) VALUE('DPG_Media');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Standaard_Uitgeverij');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Uitgeverij_Syndikaat)');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Uitgeverij_L');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Uitgeverij_Hum!');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Scratch_Books');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Concerto_Books');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Silvester_Strips');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Soul_Food_Comics');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Tasschen_Nederland');