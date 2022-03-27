
DROP PROCEDURE IF EXISTS GebruikerAanpassen;

CREATE PROCEDURE GebruikerAanpassen(

    #Gebruiker
    Id_ VARCHAR(255),
    rol_ VARCHAR(100),
    UserName_ VARCHAR(256),
    Email_ VARCHAR(256)
)
BEGIN
    UPDATE gebruiker
    SET rol = rol_, 
    UserName = UserName_,
    NormalizedUsername = UPPER(UserName_),
    Email = Email_
    WHERE Id = Id_;
END;
