DROP PROCEDURE IF EXISTS StripboekToevoegen;

CREATE PROCEDURE StripboekToevoegen(

#Versie
    afbeelding_url varchar(200), isbn varchar(50), datum date, druk int, prijs float,

#Uitgave
    naam VARCHAR(100), hoogte INT, beschrijving VARCHAR(255),

#Reeks
    reeks_naam varchar(100),

#Categorie
    cat_naam varchar(30),

#Uitgever
    uitgever_naam varchar(100),

#Gebruiker
    gebruiker_id varchar(255)
)
    IF (SELECT Id
        FROM gebruiker
        WHERE gebruiker_id = Id)
    THEN
        BEGIN

            #Reeks
            INSERT INTO Reeks(reeks_id, reeks_naam)
            SELECT null, @reeks_naam
            WHERE reeks_naam NOT IN (
                SELECT reeks.reeks_naam
                FROM reeks
            );

#Categorie
            INSERT INTO Categorie(cat_id, cat_naam)
            SELECT null, @cat_naam
            WHERE cat_naam NOT IN (
                SELECT categorie.cat_naam
                FROM categorie
            );

#Uitgever
            INSERT INTO Uitgever(uitgever_id, uitgever_naam)
            SELECT null, @uitgever_naam
            WHERE uitgever_naam NOT IN (
                SELECT uitgever.uitgever_naam
                FROM uitgever
            );

            #Uitgave
            INSERT INTO Uitgave(uitgave_id,naam, hoogte, beschrijving, cat_id, reeks_id)
            SELECT null,@naam, @hoogte, @beschrijving, cat_id, reeks_id
            FROM categorie,
                 reeks
            WHERE naam NOT IN (
                SELECT Uitgave.naam
                FROM Uitgave
            ) AND cat_naam = categorie.cat_naam
              AND reeks_naam = reeks.reeks_naam;

#Versie moet nog iets anders
            INSERT INTO Versie(Versie_id, afbeelding_url, isbn, datum, druk, prijs, uitgever_id, uitgave_id)
            SELECT null,
                   @afbeelding_url,
                   @isbn,
                   @datum,
                   @druk,
                   @prijs,
                   uitgever_id,
                   uitgave_id
            FROM uitgever,
                 uitgave
            WHERE isbn NOT IN (
                SELECT Versie.isbn
                FROM Versie
            ) AND (uitgever_naam = uitgever.uitgever_naam AND naam = uitgave.naam);

#StatusUitgave
            INSERT INTO statusuitgave(gebruiker_id, versie_id)
            SELECT @gebruiker_id, Versie_id
            FROM versie
            WHERE isbn = versie.isbn;

        END;
    END IF;