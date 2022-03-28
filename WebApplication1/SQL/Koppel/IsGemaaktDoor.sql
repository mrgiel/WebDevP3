DROP TABLE IF EXISTS IsGemaaktDoor;

CREATE TABLE IsGemaaktDoor
(
    rol ENUM('Auteur', 'Tekenaar') NOT NULL,
    persoon_id INT NOT NULL,
    versie_id INT NOT NULL,
    PRIMARY KEY (persoon_id, versie_id, rol),
    FOREIGN KEY (persoon_id) REFERENCES Persoon (persoon_id),
    FOREIGN KEY (versie_id) REFERENCES Versie(versie_id)
);


INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', 1, 3);
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', 5, 5);
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', 3, 2);
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', 6, 3);
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', 2, 6);
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', 6, 4);
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', 2, 4);