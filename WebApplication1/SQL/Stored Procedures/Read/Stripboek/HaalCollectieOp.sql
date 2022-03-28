DROP PROCEDURE IF EXISTS HaalCollectieOp;

#Haalt de afbeelding, isbn, druk, naam, reeks
CREATE PROCEDURE HaalCollectieOp()
BEGIN
    SELECT

        #Versie
           s.versie_id,
        afbeelding_url,
        isbn,
        druk,
        datum,

        #Uitgave
        naam,

        #Reeks
        reeks_naam

    FROM versie v
             INNER JOIN statusuitgave s on v.Versie_id = s.versie_id
             INNER JOIN uitgave u on v.uitgave_id = u.uitgave_id
             INNER JOIN reeks r ON r.reeks_id = u.reeks_id
    WHERE s.status = true;
END 