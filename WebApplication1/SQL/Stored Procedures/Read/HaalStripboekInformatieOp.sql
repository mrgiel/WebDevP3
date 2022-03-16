DROP PROCEDURE IF EXISTS HaalStripboekInformatieOp;

#Haalt alle informatie van een stripboek op
#params: versie_id --> de primairy key van de versie
CREATE PROCEDURE HaalStripboekInformatieOp(versie_id int)
BEGIN
SELECT afbeelding_url, isbn, datum, druk, prijs, u.naam, beschrijving, cat_naam, reeks_naam, rol, voornaam, achternaam
FROM Versie v
INNER JOIN Uitgave u ON u.uitgave_id = v.uitgave_id
INNER JOIN Categorie c ON c.cat_id = u.cat_id
INNER JOIN Reeks r ON r.reeks_id = u.reeks_id
INNER JOIN isgemaaktdoor i on v.Versie_id = i.versie_id
INNER JOIN persoon p ON p.persoon_id = i.persoon_id
WHERE v.Versie_id = @versie_id;
END
