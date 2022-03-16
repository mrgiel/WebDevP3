DROP TABLE IF EXISTS Role;

CREATE TABLE Role (
                      Id varchar(255) NOT NULL PRIMARY KEY,
                      Name varchar(255),
                      NormalizedName varchar(255),
                      ConcurrencyStamp longtext
); 