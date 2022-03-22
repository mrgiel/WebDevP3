DROP PROCEDURE IF EXISTS HaalStripboekInformatieOp;

#Haalt alle informatie van een stripboek op
#params: versie_id --> de primairy key van de versie

CREATE PROCEDURE HaalStripboekInformatieOp(versie_idVAR int)
BEGIN
    SELECT

        #Versie
           v.Versie_id,
        afbeelding_url,
        isbn,
        datum,
        druk,
        prijs,

        #Uitgave
        naam as split,
        beschrijving,
        hoogte,
        nsfw,

        #Uitgever
        uitgever_naam as split,

        #Categorie
        cat_naam as split,

        #Reeks
        reeks_naam as split,

        #IsGemaaktDoor
        i.rol as split,

        #Persoon
        p.voornaam as split,
        achternaam

    FROM Versie v
             LEFT JOIN statusuitgave s on v.Versie_id = s.versie_id
             LEFT JOIN Uitgave u ON u.uitgave_id = v.uitgave_id
             LEFT JOIN uitgever u2 on v.uitgever_id = u2.uitgever_id
             LEFT JOIN Categorie c ON c.cat_id = u.cat_id
             LEFT JOIN Reeks r ON r.reeks_id = u.reeks_id
             LEFT JOIN isgemaaktdoor i on v.Versie_id = i.versie_id
             LEFT JOIN persoon p ON p.persoon_id = i.persoon_id
    WHERE v.Versie_id = versie_idVAR;
END
