DROP TABLE IF EXISTS roleclaims;

create table roleclaims
(
    Id         int auto_increment
        primary key,
    RoleId     varchar(255) not null,
    ClaimType  longtext     null,
    ClaimValue longtext     null,
    constraint FK_RoleClaims_Role_RoleId
        foreign key (RoleId) references role (Id)
            on delete cascade
);

create index IX_RoleClaims_RoleId
    on roleclaims (RoleId);



