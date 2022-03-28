#Voegt stripboek toe aan bezit

DROP PROCEDURE IF EXISTS VoegToeAanCollectie;

CREATE PROCEDURE VoegToeAanCollectie(
gebruiker_idVAR varchar (255),
versie_idVAR int
)
INSERT into bezit(gebruiker_id, versie_id)
SELECT gebruiker_idVAR, versie_idVAR
on duplicate key update hoeveelheid = (select hoeveelheid where versie_id = versie_idVAR and gebruiker_id = gebruiker_idVAR) + 1
