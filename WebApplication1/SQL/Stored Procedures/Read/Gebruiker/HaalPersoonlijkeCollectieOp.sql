DROP PROCEDURE IF EXISTS HaalPersoonlijkeCollectieOp;

#haalt de persoonlijke collectie op van de gebruiker
#params: gebruiker_id --> de primairy key van de gebruiker
CREATE PROCEDURE HaalPersoonlijkeCollectieOp(gebruiker_id VARCHAR(255))
BEGIN
    SELECT 
           #bezit
        b.rating, 
        b.staat, 
        b.beschrijving, 
        b.hoeveelheid, 
        b.prijs_betaald,
        
           #versie
        b.versie_id,
        v.afbeelding_url, 
        v.datum,
        
           #uitgave
        u.uitgave_id,
        u.naam
    FROM Bezit b
             INNER JOIN Versie v on b.versie_id = v.Versie_id
             INNER JOIN Uitgave u on v.uitgave_id = u.uitgave_id
    WHERE b.gebruiker_id = gebruiker_id;
END 