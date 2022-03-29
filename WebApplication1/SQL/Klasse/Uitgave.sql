DROP TABLE IF EXISTS Uitgave;

CREATE TABLE Uitgave
(
    uitgave_id             INT AUTO_INCREMENT PRIMARY KEY,
    naam           varchar(100) unique NOT NULL,
    hoogte         INT,
    beschrijving   VARCHAR(255),
    nsfw           BOOL         NOT NULL DEFAULT False,
    cat_id         INT,
    reeks_id       INT,
    FOREIGN KEY (cat_id) REFERENCES Categorie (cat_id),
    FOREIGN KEY (reeks_id) REFERENCES Reeks (reeks_id)
);

INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('Het_schepsel_van_Rhamane',26,'dit is een beschrijving van een stripboek jaja', True,'2','10'  );
INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('Advocaten',30,'dit is een beschrijving van een stripboek jaja', True,'6','1'  );
INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('Advocatureluurs',20,'dit is een beschrijving van een stripboek jaja', False,'8','10'  );
INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('Alinoë',35,'dit is een  23442HRT{} een stripboek jaja', True,'3','5'  );
INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('{}564}',10,'dit is een ^234222 van een stripboek jaja', True,'2','3'  );
INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('Alleen_op_de_wereld%^&P{',30,'dit is een 324 van een stripboek jaja', False,'3','9');
INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('Alda',26,'dit is een $% van een stripboek jaja', False,'7','8'  );
INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('Het_schepsel_van_Rhamane',30,'dit is een ^$%^$% van een stripboek jaja', False,'9','5'  );