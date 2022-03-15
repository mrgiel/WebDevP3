DROP TABLE IF EXISTS userclaims;

create table userclaims
(
    Id         int auto_increment
        primary key,
    UserId     varchar(255) not null,
    ClaimType  longtext     null,
    ClaimValue longtext     null,
    constraint FK_UserClaims_Gebruiker_UserId
        foreign key (UserId) references Gebruiker (Id)
            on delete cascade
);

create index IX_UserClaims_UserId
    on userclaims (UserId);

