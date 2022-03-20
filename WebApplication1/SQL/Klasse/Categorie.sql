DROP TABLE IF EXISTS Categorie;

CREATE TABLE Categorie
(
    cat_id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    cat_naam VARCHAR(30) UNIQUE
);

INSERT INTO Categorie (cat_naam) VALUE ('drama');
INSERT INTO Categorie (cat_naam) VALUE ('comedy');
INSERT INTO Categorie (cat_naam) VALUE ('avontuur');
INSERT INTO Categorie (cat_naam) VALUE ('actie');
INSERT INTO Categorie (cat_naam) VALUE ('horror');
INSERT INTO Categorie (cat_naam) VALUE ('romance');
INSERT INTO Categorie (cat_naam) VALUE ('educatief');
INSERT INTO Categorie (cat_naam) VALUE ('manga');
INSERT INTO Categorie (cat_naam) VALUE ('sensueel');
INSERT INTO Categorie (cat_naam) VALUE ('historisch');
INSERT INTO Categorie (cat_naam) VALUE ('zwart-wit');
INSERT INTO Categorie (cat_naam) VALUE ('kleur');
INSERT INTO Categorie (cat_naam) VALUE ('kinder');
INSERT INTO Categorie (cat_naam) VALUE ('anime');