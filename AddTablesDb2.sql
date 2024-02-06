
DROP TABLE Profiles


CREATE TABLE Profiles (
ProfileId int,
FirstName varchar(300),
LastName varchar(300),
RoleId int,
AllianceId int,
LanguageId int
);

CREATE TABLE Roles (
RoleId int,
Role varchar(max)
);

CREATE TABLE Alliances (
AllianceId int,
Alliance varchar(max)
);

CREATE TABLE Languages (
LanguageId int,
Language varchar(max)
);