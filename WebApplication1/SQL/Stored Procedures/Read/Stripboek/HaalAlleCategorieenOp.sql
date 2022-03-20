#Dit kan ook via multi-mapping
#
#Moet later uit HaalStripboekInformatieOp gehaald worden
#


DROP PROCEDURE IF EXISTS HaalAlleCategorieenOp;

#Haalt alle categorieen op
CREATE PROCEDURE HaalAlleCategorieenOp()
BEGIN
SELECT cat_naam
FROM categorie;
END
