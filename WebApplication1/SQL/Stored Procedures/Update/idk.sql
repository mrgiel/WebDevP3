DROP PROCEDURE IF EXISTS idk;

CREATE PROCEDURE idk(Model varchar(100))
BEGIN 
INSERT INTO reeks(reeks_id,reeks_naam)VALUE(null,@Model) ;
end;
