DROP TABLE IF EXISTS UserLogins;

CREATE TABLE UserLogins (
                            LoginProvider varchar(255) NOT NULL,
                            ProviderKey varchar(255) NOT NULL,
                            ProviderDisplayName longtext NULL,
                            UserID varchar(255) NOT NULL,
                            PRIMARY KEY (LoginProvider,ProviderKey),
                            FOREIGN KEY (UserID) REFERENCES Gebruiker(Id)
)