DROP TABLE IF EXISTS _efmigrationshistory;

CREATE TABLE _efmigrationshistory
(
    MigrationId    varchar(150) not null
        primary key,
    ProductVersion varchar(32)  not null
);

INSERT INTO _efmigrationshistory (migrationid, productversion) VALUE ('20220315193554_naam','5.0.14');
