
DROP TABLE Languages
DROP TABLE Roles
DROP TABLE Alliances
DROP TABLE Profiles


CREATE TABLE Profiles (
    ProfileId int PRIMARY KEY,
    FirstName nvarchar(200) NOT NULL,
    LastName nvarchar(200) NOT NULL,
    RoleId int,
    AllianceId int,
    LanguageId int,
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId),
    FOREIGN KEY (AllianceId) REFERENCES Alliances(AllianceId),
    FOREIGN KEY (LanguageId) REFERENCES Languages(LanguageId)
);

CREATE TABLE Roles (
    RoleId int PRIMARY KEY,
    RoleName nvarchar(200)
);

CREATE TABLE Alliances (
    AllianceId int PRIMARY KEY,
    AllianceName nvarchar(200)
);

CREATE TABLE Languages (
    LanguageId int PRIMARY KEY,
    LanguageName nvarchar(200)
);