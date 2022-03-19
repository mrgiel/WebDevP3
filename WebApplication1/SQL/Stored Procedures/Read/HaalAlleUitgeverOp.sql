DROP PROCEDURE IF EXISTS HaalAlleUitgeverOp;

#Haalt alle uitgevers op
CREATE PROCEDURE HaalAlleUitgeverOp()
BEGIN
SELECT uitgever_naam
FROM uitgever;
END
