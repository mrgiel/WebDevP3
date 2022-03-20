#Voegt alles van stripboeken toe via inser intos
#Alleen moet de auteur/tekenaar nog toevoegen

DROP PROCEDURE IF EXISTS StripboekAanpassen;

CREATE PROCEDURE StripboekAanpassen(

    #Versie
    versie_idVAR int,
    afbeelding_urlVAR varchar(200),
    isbnVAR varchar(50),
    datumVAR date,
    drukVAR int,
    prijsVAR decimal(6, 2),

    #Uitgave
    naamVAR varchar(100),
    beschrijvingVAR varchar(255),
    hoogteVAR int,
    nsfwVAR boolean,

    #Uitgever
    uitgever_naamVAR varchar(100),

    #Categorie
    cat_naamVAR varchar(30),

    #Reeks
    reeks_naamVAR varchar(100)
)
BEGIN
    #Versie
    UPDATE versie
    SET afbeelding_url = afbeelding_urlVAR,
        isbn           = isbnVAR,
        datum          = datumVAR,
        druk           = drukVAR,
        prijs          = prijsVAR
    WHERE Versie_id = versie_idVAR;

    #Uitgave
    UPDATE uitgave as u
        INNER JOIN versie v on u.uitgave_id = v.uitgave_id
    SET naam         = naamVAR,
        beschrijving = beschrijvingVAR,
        hoogte       = hoogteVAR,
        nsfw         = nsfwVAR
    WHERE u.uitgave_id = v.uitgave_id
      and v.Versie_id = versie_idVAR;

    #Uitgever
    UPDATE uitgever as u
        INNER JOIN versie v on u.uitgever_id = v.uitgever_id
    SET uitgever_naam = uitgever_naamVAR
    WHERE u.uitgever_id = v.uitgever_id
      and v.Versie_id = versie_idVAR;

    #Categorie
    UPDATE categorie as c
        INNER JOIN uitgave u on c.cat_id = u.cat_id
        INNER JOIN versie v on u.uitgave_id = v.uitgave_id
    SET cat_naam = cat_naamVAR
    WHERE c.cat_id = u.cat_id
      and u.uitgave_id = v.uitgave_id
      and v.Versie_id = versie_idVAR;

    #Reeks
    UPDATE reeks as r
        INNER JOIN uitgave u on r.reeks_id = u.reeks_id
        INNER JOIN versie v on u.uitgave_id = v.uitgave_id
    SET reeks_naam = reeks_naamVAR
    WHERE r.reeks_id = u.reeks_id
      and u.uitgave_id = v.uitgave_id
      and v.Versie_id = versie_idVAR;


END;
