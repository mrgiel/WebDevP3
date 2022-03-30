#Voegt alles van stripboeken toe via inser intos
#Alleen moet de auteur/tekenaar nog toevoegen

DROP PROCEDURE IF EXISTS StripboekToevoegen;

CREATE PROCEDURE StripboekToevoegen(

#Versie
    afbeelding_urlVAR varchar(200), isbnVAR varchar(50), datumVAR date, drukVAR int, prijsVAR float,

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

#isgemaaktdoor
    rolARRAY varchar(200),

#Persoon
    voornaamARRAY varchar(200),
    achternaamARRAY varchar(200),

#length
    length int)

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
    INSERT ignore Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id)
    SELECT null,
           afbeelding_urlVAR,
           isbnVAR,
           datumVAR,
           drukVAR,
           prijsVAR,
           (SELECT uitgever_id 
           where uitgever_naam = uitgever_naamVAR),
           (SELECT uitgave_id
            from reeks,
                 categorie
            where uitgave.naam = naamVAR
              AND cat_naamVAR = categorie.cat_naam
              AND reeks_naamVAR = reeks.reeks_naam)
    FROM uitgever,
         uitgave
    WHERE isbnVAR NOT IN (
        SELECT isbn
        from versie);

    #StatusUitgave
    INSERT ignore statusuitgave(status, gebruiker_id, versie_id)
    SELECT false, Id, Versie.Versie_id
    FROM versie,
         gebruiker
    WHERE versie.isbn = isbnVAR
      and gebruiker_idVAR = gebruiker.Id;
    BEGIN
        #declare
        DECLARE counter INT DEFAULT 1;
        DECLARE voornaamSingle varchar(50);
        DECLARE achternaamSingle varchar(50);
        DECLARE rolSingle varchar(50);
        DECLARE versieID int;
        SET versieID = @versie_id;
        SELECT versieID;

        #while loop
        WHILE counter <= length
            DO
                #haal array uit elkaar
                SET voornaamSingle = substring_index(
                        substring_index(voornaamARRAY, ',', counter)
                    , ',', -1);
                SET achternaamSingle = substring_index(
                        substring_index(achternaamARRAY, ',', counter)
                    , ',', -1);
                SET rolSingle = substring_index(
                        substring_index(rolARRAY, ',', counter)
                    , ',', -1);

                #als voornaam en achternaam niet bestaat
                if (
                            voornaamSingle NOT IN (
                            SELECT voornaam
                            FROM persoon
                        ) or achternaamSingle NOT IN (
                        SELECT achternaam
                        FROM persoon))

                    #insert into individueel id per met voornaam achternaam
                THEN
                    INSERT INTO persoon(persoon_id, voornaam, achternaam)
                    SELECT

                        #persoon_id
                        null,

                        #voornaam
                        voornaamSingle,

                        #achternaam
                        achternaamSingle;

                    INSERT INTO isgemaaktdoor(rol, persoon_id, versie_id)
                    SELECT

                        #rol
                        rolSingle,

                        #persoon_id
                        (SELECT LAST_INSERT_ID()
                         FROM persoon
                         LIMIT 1),

                        #versie_id
                        (select Versie_id
                         from versie
                         where isbn = isbnVAR
                         limit 1);
                    #als de voornaam/achternaam wel bestaat


                else

                    insert ignore isgemaaktdoor(rol, persoon_id, versie_id)
                    SELECT
                        #rol
                        rolSingle,

                        #persoon_id
                        (SELECT persoon_id
                         FROM persoon
                         WHERE voornaam = voornaamSingle
                           and achternaam = achternaamSingle),

                        #versie_id
                        (select Versie_id
                         from versie
                         where isbn = isbnVAR
                         limit 1)
                    ON DUPLICATE KEY UPDATE rol = rolSingle;
                end if;
                #counter++
                SET counter = counter + 1;
            END WHILE;
    end;
END