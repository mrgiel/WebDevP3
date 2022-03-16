DROP PROCEDURE IF EXISTS PersoonlijkeInformatie;

#Haalt de bruikbare informatie van de gebruiker op
#params: gebruiker_id --> de primairy key van de gebruiker
CREATE PROCEDURE PersoonlijkeInformatie(gebruiker_id varchar(255))
BEGIN
SELECT UserName, rol, `18_plus`, Email
FROM gebruiker
WHERE id = @gebruiker_id;
END
