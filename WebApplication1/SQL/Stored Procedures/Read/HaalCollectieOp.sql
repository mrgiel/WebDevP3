DROP PROCEDURE IF EXISTS HaalCollectieOp;

CREATE PROCEDURE HaalCollectieOp()
BEGIN 
SELECT v.afbeelding_url, u.naam
FROM Versie v
INNER JOIN Uitgave u ON u.uitgave_id = v.uitgave_id;
END 