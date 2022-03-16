DROP PROCEDURE IF EXISTS HaalCollectieOp;

#Haalt de afbeelding, reeks en naam op
CREATE PROCEDURE HaalCollectieOp()
BEGIN 
SELECT afbeelding_url, naam, reeks_naam
FROM Versie v
INNER JOIN Uitgave u ON u.uitgave_id = v.uitgave_id
INNER JOIN reeks r ON r.reeks_id = u.reeks_id;
END 