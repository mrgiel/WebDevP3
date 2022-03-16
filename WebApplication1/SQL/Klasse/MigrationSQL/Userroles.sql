DROP TABLE IF EXISTS userroles;

create table userroles
(
    UserId varchar(255) not null,
    RoleId varchar(255) not null,
    primary key (UserId, RoleId),
    constraint FK_UserRoles_Gebruiker_UserId
        foreign key (UserId) references Gebruiker (Id)
            on delete cascade,
    constraint FK_UserRoles_Role_RoleId
        foreign key (RoleId) references role (Id)
            on delete cascade
);

create index IX_UserRoles_RoleId
    on userroles (RoleId);

