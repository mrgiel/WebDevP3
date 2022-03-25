#Voegt alles van stripboeken toe via inser intos
#Alleen moet de auteur/tekenaar nog toevoegen

DROP PROCEDURE IF EXISTS StripboekToevoegen;

CREATE PROCEDURE StripboekToevoegen(

#Versie
    versie_idVAR int, afbeelding_urlVAR varchar(200), isbnVAR varchar(50), datumVAR date, drukVAR int, prijsVAR float,

#Uitgave
    naamVAR VARCHAR(100), hoogteVAR INT, beschrijvingVAR VARCHAR(255), nsfwVar bool,

#Reeks
    reeks_naamVAR varchar(100),

#Categorie
    cat_naamVAR varchar(30),

#Uitgever
    uitgever_naamVAR varchar(100),

#Gebruiker
    gebruiker_idVAR varchar(255),

#Persoon
    voornaamARRAY varchar(200),
    achternaamARRAY varchar(200))
BEGIN

    #Reeks
    INSERT INTO Reeks(reeks_id, reeks_naam)
    SELECT null, reeks_naamVAR
    WHERE reeks_naamVAR NOT IN (
        SELECT reeks.reeks_naam
        FROM reeks
    );

#Categorie
    INSERT INTO Categorie(cat_id, cat_naam)
    SELECT null, cat_naamVAR
    WHERE cat_naamVAR NOT IN (
        SELECT categorie.cat_naam
        FROM categorie
    );

#Uitgever
    INSERT INTO Uitgever(uitgever_id, uitgever_naam)
    SELECT null, uitgever_naamVAR
    WHERE uitgever_naamVAR NOT IN (
        SELECT uitgever.uitgever_naam
        FROM uitgever
    );

    #Uitgave
    INSERT INTO Uitgave(uitgave_id, naam, hoogte, beschrijving, nsfw, cat_id, reeks_id)
    SELECT null, naamVAR, hoogteVAR, beschrijvingVAR, nsfwVar, cat_id, reeks_id
    FROM categorie,
         reeks
    WHERE naamVAR NOT IN (
        SELECT Uitgave.naam
        FROM Uitgave
    )
      AND cat_naamVAR = categorie.cat_naam
      AND reeks_naamVAR = reeks.reeks_naam;

    #Versie
    INSERT INTO Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id)
    SELECT null,
           afbeelding_urlVAR,
           isbnVAR,
           datumVAR,
           drukVAR,
           prijsVAR,
           uitgever_id,
           uitgave_id
    FROM uitgever,
         uitgave
    WHERE isbnVAR NOT IN (
        SELECT Versie.isbn
        FROM Versie
    )
      AND (uitgever_naamVAR = uitgever.uitgever_naam AND naamVAR = uitgave.naam);

    #StatusUitgave
    INSERT INTO statusuitgave(status, gebruiker_id, versie_id)
    SELECT false, Id, Versie.Versie_id
    FROM versie,
         gebruiker
    WHERE versie.isbn = isbnVAR
      and gebruiker_idVAR = gebruiker.Id;

    DROP PROCEDURE IF EXISTS Test;

#     CREATE PROCEDURE Test(
#     )
#     BEGIN
#         BEGIN
#             #declare
#             DECLARE counter INT DEFAULT 1;
#             DECLARE voornaamSingle varchar(50);
#             DECLARE achternaamSingle varchar(50);
#             DECLARE voornaamARRAY varchar(255);
#             DECLARE achternaamARRAY varchar(255);
#             DECLARE persoon_idVAR int;
#             SET voornaamARRAY = 'adis,dolop,sal';
#             SET achternaamARRAY = 'lop,igr,fsfes';
# 
# 
# #while loop (kan misschien nog in een declare?)
#             WHILE counter <= 3
#                 DO
#                     SET voornaamSingle = substring_index(
#                             substring_index(voornaamARRAY, ',', counter)
#                         , ',', -1);
#                     SET achternaamSingle = substring_index(
#                             substring_index(achternaamARRAY, ',', counter)
#                         , ',', -1);
# 
#                     if (
#                                 voornaamSingle NOT IN (
#                                 SELECT voornaam
#                                 FROM persoon
#                             )
#                             and achternaamSingle NOT IN (
#                             SELECT achternaam
#                             FROM persoon
#                         ))
#                     THEN
#                         INSERT INTO persoon(persoon_id, voornaam, achternaam)
#                         SELECT null,
#                                voornaamSingle,
#                                achternaamSingle;
#                         SELECT LAST_INSERT_ID()
#                         FROM persoon LIMIT 1;
#                     else
#                         SELECT persoon_id FROM persoon WHERE voornaam = voornaamSingle and achternaam = achternaamSingle INTO @persoon_id;
#                         SET persoon_idVAR = @persoon_id;
#                         insert into isgemaaktdoor(rol, persoon_id, versie_id)
#                         SELECT 'tekenaar',persoon_idVAR, 3;
#                     end if;
# 
# #counter++
#                     SET counter = counter + 1;
#                 END WHILE;
#         end;
#     end;
#     call test();
END;
