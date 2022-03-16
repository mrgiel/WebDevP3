DROP PROCEDURE IF EXISTS HaalStripboekInformatieOp;

CREATE PROCEDURE HaalStripboekInformatieOp(id int)
BEGIN
SELECT v.afbeelding_url, isbn, datum, druk, prijs, u.naam, beschrijving, c.cat_naam, r.reeks_naam, i.rol, p.voornaam, achternaam
FROM Versie v
INNER JOIN Uitgave u ON u.uitgave_id = v.uitgave_id
INNER JOIN Categorie c ON c.cat_id = u.cat_id
INNER JOIN Reeks r ON r.reeks_id = u.reeks_id
INNER JOIN isgemaaktdoor i on v.Versie_id = i.versie_id
INNER JOIN persoon p ON p.persoon_id = i.persoon_id
WHERE v.Versie_id = @id;
END
