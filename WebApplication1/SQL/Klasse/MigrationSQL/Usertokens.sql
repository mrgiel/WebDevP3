DROP TABLE IF EXISTS UserTokens;

CREATE TABLE UserTokens(
                           UserID varchar(255) NOT NULL ,
                           LoginProvider varchar(255) NOT NULL,
                           Name varchar(255) NOT NULL,
                           Value longtext NULL,
                           FOREIGN KEY (UserID) REFERENCES Gebruiker(Id),
                               PRIMARY KEY(UserID,LoginProvider)
)