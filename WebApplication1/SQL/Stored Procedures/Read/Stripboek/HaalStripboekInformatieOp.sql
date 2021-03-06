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
        u.uitgave_id,
        naam,
        beschrijving,
        hoogte,
        nsfw,

        #Uitgever
        u2.uitgever_id,
        uitgever_naam,

        #Categorie
        c.cat_id,
        cat_naam,

        #Reeks
        r.reeks_id,
        reeks_naam,
    
        #IsGemaaktDoor
        case count(rol)
            when 2 then ('Tekenaar, Auteur')
            when 1 then rol
            end as rol,
        i.persoon_id,
    
        #Persoon
        p.persoon_id,
        p.voornaam,
        p.achternaam

    FROM Versie v
             INNER JOIN statusuitgave s on v.Versie_id = s.versie_id
             INNER JOIN Uitgave u ON u.uitgave_id = v.uitgave_id
             INNER JOIN uitgever u2 on v.uitgever_id = u2.uitgever_id
             INNER JOIN Categorie c ON c.cat_id = u.cat_id
             INNER JOIN Reeks r ON r.reeks_id = u.reeks_id
             LEFT JOIN isgemaaktdoor i on v.Versie_id = i.versie_id
             INNER JOIN persoon p on i.persoon_id = p.persoon_id
    WHERE v.Versie_id = versie_idVAR;
END
