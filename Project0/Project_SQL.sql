

CREATE TABLE UserTable(
    UserID INT NOT NULL IDENTITY(1,1),
    [Name] NVARCHAR(50),
    EmailID NVARCHAR(50),
    [Password] NVARCHAR(10),
    CONSTRAINT PK_Users PRIMARY KEY (UserID)
)
ALTER TABLE UserTable
ADD CONSTRAINT EmailUnique UNIQUE(EmailID);

ALTER TABLE UserTable
ADD CONSTRAINT PK_Users PRIMARY KEY (UserID)

ALTER TABLE UserTable
DROP CONSTRAINT PK_Users;

UPDATE Details set Address = 'Sathak' where UserID = 1;

SELECT * FROM UserTable;
SELECT * FROM Details;
SELECT * FROM Skills;
SELECT * FROM Experience;
SELECT * FROM Education;

TRUNCATE TABLE UserTable;
TRUNCATE TABLE Details;
TRUNCATE TABLE Skills;
TRUNCATE TABLE Experience;
TRUNCATE TABLE Education;

DELETE FROM UserTable WHERE UserID = 3;
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
    CONSTRAINT FK_DetailsID FOREIGN KEY (UserID)
    REFERENCES UserTable(UserID) ON UPDATE CASCADE ON DELETE CASCADE
)
ALTER TABLE Details
ADD CONSTRAINT FK_DetailsID
FOREIGN KEY (UserID) REFERENCES UserTable(UserID);

UPDATE Details set Address='sathak' where Email_ID

ALTER TABLE Details
DROP CONSTRAINT FK_DetailsID;

ALTER TABLE Details 
ADD CONSTRAINT UserID_unique UNIQUE(UserID)
select * from Details;
ALTER TABLE Details DROP CONSTRAINT UserID_unique

INSERT INTO Details VALUES (1, 'Cibi', 'male', 'c4, kotturpuram', 'Im a good boy', 8056175372, 'cb@gmail.com', 'cb.com');

-- ALTER TABLE Details
-- DROP CONSTRAINT FK_PersonOrder;

DELETE FROM Details WHERE FullName LIKE '%cb%'

--SELECT * FROM Details WHERE  LIKE 'cb'
-- DROP TABLE Details
SELECT * FROM Details;


CREATE TABLE Skills(
   UserID INT NOT NULL,
   Skill_1 NVARCHAR(100) NOT NULL,
   Skill_2 NVARCHAR(100),
   Skill_3 NVARCHAR(100), 
   CONSTRAINT FK_SkillsID FOREIGN KEY (UserID)
    REFERENCES UserTable(UserID) ON UPDATE CASCADE ON DELETE CASCADE
)
ALTER TABLE Skills
ADD CONSTRAINT FK_SkillsID
FOREIGN KEY (UserID) REFERENCES UserTable(UserID);

ALTER TABLE Skills
DROP CONSTRAINT FK_SkillsID;
SELECT * FROM Skills;

 CREATE TABLE Experience(
     UserID INT NOT NULL,
     Company1 NVARCHAR(MAX) NOT NULL,
     Company2 NVARCHAR(MAX),
     Company3 NVARCHAR(MAX),
    CONSTRAINT FK_ExperienceID FOREIGN KEY (UserID)
    REFERENCES UserTable(UserID) ON UPDATE CASCADE ON DELETE CASCADE
 )
 ALTER TABLE Experience
ADD CONSTRAINT FK_ExperienceID
FOREIGN KEY (UserID) REFERENCES UserTable(UserID);

ALTER TABLE Experience
DROP CONSTRAINT FK_ExperienceID;


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
     REFERENCES UserTable(UserID) ON UPDATE CASCADE ON DELETE CASCADE
 )

 ALTER TABLE Education
ADD CONSTRAINT FK_Education
FOREIGN KEY (UserID) REFERENCES UserTable(UserID);

ALTER TABLE Education
DROP CONSTRAINT FK_EducationUser;
-- TO DISPLAY ALL TABLES
--SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE';

-- INSERT INTO Users VALUES('Cibi'),('Kumaran');

-- SELECT * FROM UserTable;
INSERT INTO UserTable VALUES ('Cibi', 'cb@gmail.com', 'abcde');
INSERT INTO UserTable VALUES ('Shaa', 'sha@gmail.com', 'fghik');