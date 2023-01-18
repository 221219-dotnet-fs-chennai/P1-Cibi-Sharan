create DATABASE MyProject1DB

CREATE TABLE UserTable(
    UserID INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(50),
    EmailID NVARCHAR(50),
    [Password] NVARCHAR(10),
    CONSTRAINT PK_Users PRIMARY KEY (UserID)
)

--ALTER TABLE UserTable DROP COLUMN Phone_No;

CREATE TABLE Details(
    UserID INT NOT NULL,
    FullName NVARCHAR(50),
    Gender VARCHAR(8),
    [Address] NVARCHAR(MAX),
    AboutMe NVARCHAR(MAX),
    Phone_No NVARCHAR(20),
    Email_ID NVARCHAR(MAX),
    Website NVARCHAR(MAX),
)

ALTER TABLE Details
ADD CONSTRAINT FK_UserID
FOREIGN KEY (UserID) REFERENCES UserTable(UserID)
-- ALTER TABLE Details
-- DROP CONSTRAINT FK_PersonOrder;

-- DROP TABLE Details

CREATE TABLE Skills(
   UserID INT NOT NULL,
   Skill_1 NVARCHAR(100) NOT NULL,
   Skill_2 NVARCHAR(100),
   Skill_3 NVARCHAR(100), 
   CONSTRAINT FK_SkillsID FOREIGN KEY (UserID)
    REFERENCES UserTable(UserID)
)
DROP TABLE Skills;

 CREATE TABLE Experience(
     UserID INT NOT NULL,
     Company1 NVARCHAR(MAX) NOT NULL,
     Company2 NVARCHAR(MAX),
     Company3 NVARCHAR(MAX) 
 )

 CREATE TABLE Education(
     Register_No BIGINT NOT NULL,
     UserID INT NOT NULL,
     College_Name NVARCHAR(MAX),
     Stream NVARCHAR(50),
     Branch NVARCHAR(50),
     Percentage FLOAT,
     StartYear INT,
     EndYear INT,
     CONSTRAINT PK_Register_No PRIMARY KEY (Register_No),
     CONSTRAINT FK_EducationUser FOREIGN KEY(UserID)
     REFERENCES UserTable(UserID)
 )

-- TO DISPLAY ALL TABLES
SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE';

-- INSERT INTO Users VALUES('Cibi'),('Kumaran');

-- SELECT * FROM Users;