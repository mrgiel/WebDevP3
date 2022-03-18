DROP PROCEDURE IF EXISTS idk;

CREATE PROCEDURE idk(cat_naam varchar(100),
#Uitgever
    uitgever_naam varchar (100),
    #Uitgave
                     naam VARCHAR(100), hoogte INT, beschrijving VARCHAR(255),
                     reeks_naam varchar(100))
BEGIN
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
end;
