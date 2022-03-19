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
    gebruiker_idVAR varchar(255)
)
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
            INSERT INTO statusuitgave(status,gebruiker_id, versie_id)
            SELECT null,Id, Versie.Versie_id
            FROM versie,
                 gebruiker
            WHERE versie.isbn = isbnVAR
              and gebruiker_idVAR = gebruiker.Id;

        END;
