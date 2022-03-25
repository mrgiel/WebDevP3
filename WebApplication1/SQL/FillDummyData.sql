INSERT INTO Gebruiker (Id, UserName, rol, Email, 18_plus, PasswordHash) VALUES ('1','ruho20', 'moderator', 'ruben.hoekuma@hotmail.com', True, MD5('wachtwoord1'));

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

INSERT INTO Reeks (reeks_naam) VALUE('Suske & Wiske');
INSERT INTO Reeks (reeks_naam) VALUE ('Donald Duck');
INSERT INTO Reeks (reeks_naam) VALUE ('Lucky Luke');
INSERT INTO Reeks (reeks_naam) VALUE ('De Rode Ridder');
INSERT INTO Reeks (reeks_naam) VALUE ('Bestemming Peru');
INSERT INTO Reeks (reeks_naam) VALUE ('F.C. de Kampioenen');
INSERT INTO Reeks (reeks_naam) VALUE ('Jommeke');
INSERT INTO Reeks (reeks_naam) VALUE ('Kuifje');
INSERT INTO Reeks (reeks_naam) VALUE ('Rooie Oortjes');
INSERT INTO Reeks (reeks_naam) VALUE ('Colby');
INSERT INTO Reeks (reeks_naam) VALUE ('Comanche');
INSERT INTO Reeks (reeks_naam) VALUE ('Condor');
INSERT INTO Reeks (reeks_naam) VALUE ('Cupido');

INSERT INTO Persoon (voornaam, achternaam) VALUE('Carl', 'Barks');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('Walt', 'Disney');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('René','Goscinny');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('Willy', 'Vandersteen');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('Paul', 'Geerts');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('Marc', 'Verhaegen');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('Peter', 'Van Gucht');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('Luc', 'Morjaeu');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('Hergé', 'Remi');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('Jacques', 'Martin');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('Edgar P.', 'Jacobs');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('Hec', 'Leemans');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('Tom', 'Bouden');
INSERT INTO Persoon (voornaam, achternaam) VALUE ('François', 'Corteggiani');

INSERT INTO Uitgever (uitgever_naam) VALUE ('DPG Media');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Standaard Uitgeverij');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Uitgeverij Syndikaat)');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Uitgeverij L');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Uitgeverij Hum!');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Scratch Books');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Concerto Books');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Silvester Strips');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Soul Food Comics');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Tasschen Nederland');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Oberon');
INSERT INTO Uitgever (uitgever_naam) VALUE ('Dupuis');

INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('als Cowboy',48,'dit is een beschrijving van een stripboek jaja', FALSE,'2','2'  );
INSERT INTO Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id) VALUE('1','https://www.stripinfo.be/image.php?i=88844&s=12406&m=440','9032005235', '1976-2-4','1','1.70','11','1' );
INSERT INTO statusuitgave(status,gebruiker_id, versie_id) VALUE('1','1','1');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', '1', '1');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', '6', '1');

INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('als Schipper',48,'dit is een beschrijving van een stripboek jaja', FALSE,'2','2'  );
INSERT INTO Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id) VALUE('2','https://www.stripinfo.be/image.php?i=187526&s=58834&m=440','9032005243', '1976-5-4','1','2.70','11','2' );
INSERT INTO statusuitgave(status,gebruiker_id, versie_id) VALUE('1','1','2');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', '1', '2');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', '6', '2');

INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('als Postbode',56,'dit is een beschrijving van een stripboek jaja', FALSE,'2','2'  );
INSERT INTO Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id) VALUE('3','https://www.stripinfo.be/image.php?i=187528&s=12408&m=440','9032005246', '1977-5-4','1','1.70','11','3' );
INSERT INTO statusuitgave(status,gebruiker_id, versie_id) VALUE('1','1','3');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', '1', '3');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', '6', '3');

INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('als Slaapwandelaar',56,'dit is een beschrijving van een stripboek jaja', FALSE,'2','2'  );
INSERT INTO Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id) VALUE('4','https://www.stripinfo.be/image.php?i=88846&s=12409&m=440','9032005250', '1977-1-4','1','2.70','11','4' );
INSERT INTO statusuitgave(status,gebruiker_id, versie_id) VALUE('1','1','4');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', '1', '4');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', '6', '4');

INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('als Sportman',56,'dit is een beschrijving van een stripboek jaja', FALSE,'2','2'  );
INSERT INTO Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id) VALUE('5','https://www.stripinfo.be/image.php?i=88855&s=12418&m=440','9032005264', '1979-1-4','1','3.30','11','5' );
INSERT INTO statusuitgave(status,gebruiker_id, versie_id) VALUE('1','1','5');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', '1', '5');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', '6', '5');

INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('als Kustwachter',56,'dit is een beschrijving van een stripboek jaja', FALSE,'2','2'  );
INSERT INTO Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id) VALUE('6','https://www.stripinfo.be/image.php?i=88856&s=12419&m=440','9032005480', '1979-3-4','1','3.30','11','6' );
INSERT INTO statusuitgave(status,gebruiker_id, versie_id) VALUE('1','1','6');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', '1', '6');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', '6', '6');

INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('op het eiland Amoras',56,'dit is een beschrijving van een stripboek jaja', FALSE,'5','1'  );
INSERT INTO Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id) VALUE('7','https://www.stripinfo.be/image.php?i=82441&s=10479&m=440','20978134', '1947-3-4','1','112.17','2','7' );
INSERT INTO statusuitgave(status,gebruiker_id, versie_id) VALUE('1','1','7');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', '2', '7');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', '4', '7');

INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('de sprietatoom',60,'dit is een beschrijving van een stripboek jaja', FALSE,'5','1'  );
INSERT INTO Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id) VALUE('8','https://www.stripinfo.be/image.php?i=689&s=10481&m=440','20978234', '1948-3-4','1','507','2','8' );
INSERT INTO statusuitgave(status,gebruiker_id, versie_id) VALUE('1','1','8');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', '2', '8');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', '4', '8');

INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('de sprietatoom',56,'dit is een beschrijving van een stripboek jaja', FALSE,'5','1'  );
INSERT INTO Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id) VALUE('9','https://www.stripinfo.be/image.php?i=12730&s=20899&m=440','20978124', '1981-2-4','2','4.05','2','9' );
INSERT INTO statusuitgave(status,gebruiker_id, versie_id) VALUE('1','1','9');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', '2', '9');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', '4', '9');

INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('de Tuftuf-club',56,'dit is een beschrijving van een stripboek jaja', FALSE,'5','1'  );
INSERT INTO Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id) VALUE('10','https://www.stripinfo.be/image.php?i=12730&s=20899&m=440','20978154', '1952-5-10','1','81.86','2','10' );
INSERT INTO statusuitgave(status,gebruiker_id, versie_id) VALUE('1','1','10');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', '2', '10');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', '4', '10');

INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('Billy the Kid',48,'dit is een beschrijving van een stripboek jaja', FALSE,'3','3'  );
INSERT INTO Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id) VALUE('11','https://www.stripinfo.be/image.php?i=8787&s=13357&m=440','16413623', '1962-6-11','1','1.94','12','11' );
INSERT INTO statusuitgave(status,gebruiker_id, versie_id) VALUE('1','1','11');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', '3', '11');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', '8', '11');

INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('de spookstad',48,'dit is een beschrijving van een stripboek jaja', FALSE,'3','3'  );
INSERT INTO Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id) VALUE('12','https://www.stripinfo.be/image.php?i=8791&s=13361&m=440','23533623', '1965-1-11','1','2.08','12','12' );
INSERT INTO statusuitgave(status,gebruiker_id, versie_id) VALUE('1','1','12');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', '3', '12');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', '8', '12');

INSERT INTO Uitgave (naam,hoogte,beschrijving, nsfw, cat_id, reeks_id) VALUE('witte Swan en zwarte Swan',48,'dit is een beschrijving van een stripboek jaja', True,'9','1'  );
INSERT INTO Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id) VALUE('13','https://www.stripboekenhandel.nl/wp-content/uploads/2019/06/140320.jpg?m=440','69420123', '2022-1-2','1','4.20','3','13' );
INSERT INTO statusuitgave(status,gebruiker_id, versie_id) VALUE('1','1','13');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Auteur', '5', '13');
INSERT INTO IsGemaaktDoor (rol, persoon_id, versie_id) VALUES ('Tekenaar', '1', '13');