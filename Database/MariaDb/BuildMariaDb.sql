/* 
 * This is the SQL Script for building the SQL database structure for the application
 * in either MariaDB or MySQL and should be compliant with both services
 */
 
 CREATE TABLE SiteUser (
     Id BIGINT PRIMARY KEY NOT NULL AUTO_INCREMENT,
     UserName VARCHAR(30) UNIQUE NOT NULL,
     PasswordHash VARCHAR(128) NOT NULL,
     PasswordSalt VARCHAR(128) NOT NULL,
     Email VARCHAR(200) UNIQUE NOT NULL,
     IsActive BIT NOT NULL DEFAULT 1,
     IsBanned BIT NOT NULL DEFAULT 0
 );
 
 CREATE TABLE SiteRole (
     Id BIGINT PRIMARY KEY NOT NULL AUTO_INCREMENT,
     RoleName VARCHAR(30) UNIQUE NOT NULL
 );

CREATE TABLE SiteUserRoleRelation (
    UserId BIGINT NOT NULL REFERENCES SiteUser (Id),
    RoleId BIGINT NOT NULL REFERENCES SiteRole (Id),
    UNIQUE unique_user_role (UserId, RoleId)
);

CREATE TABLE Player (
    Id BIGINT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    PlayerName VARCHAR(100) NOT NULL,
    SteamId VARCHAR(30),
    SteamId64 VARCHAR(17)
)