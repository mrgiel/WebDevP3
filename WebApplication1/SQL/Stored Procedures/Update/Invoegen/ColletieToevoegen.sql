#Voegt stripboek toe aan bezit

DROP PROCEDURE IF EXISTS ColletieToevoegen;

CREATE PROCEDURE ColletieToevoegen(
gebruiker_idVAR varchar (255),
versie_idVAR int,
ratingVAR int,
staatVAR varchar(50),
beschrijvingVAR varchar(255),
prijs_betaaldVAR float,
hoeveelheidVAR int
)
INSERT into bezit(rating, staat,hoeveelheid, beschrijving, prijs_betaald, gebruiker_id, versie_id) 
SELECT ratingVAR,staatVAR,hoeveelheidVAR,beschrijvingVAR,prijs_betaaldVAR,gebruiker_idVAR, versie_idVAR
on duplicate key update rating = ratingVAR, staat = staatVAR, beschrijving = beschrijvingVAR, prijs_betaald = prijs_betaaldVAR, hoeveelheid = hoeveelheidVAR