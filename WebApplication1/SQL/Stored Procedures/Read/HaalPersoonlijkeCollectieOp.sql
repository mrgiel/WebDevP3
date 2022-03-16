DROP PROCEDURE IF EXISTS HaalPersoonlijkeCollectieOp;

#haalt de persoonlijke collectie op van de gebruiker
#params: gebruiker_id --> de primairy key van de gebruiker
CREATE PROCEDURE HaalPersoonlijkeCollectieOp(gebruiker_id int)
BEGIN
    SELECT afbeelding_url, isbn, datum, druk, prijs, rating, staat, b.beschrijving, hoeveelheid, prijs_betaald, naam
    FROM Bezit b
             INNER JOIN versie v on b.versie_id = v.Versie_id
             INNER JOIN uitgave u on v.uitgave_id = u.uitgave_id
    WHERE b.gebruiker_id = @gebruiker_id;
END 