--Create Table Users
--Using SQL query create table Users with columns:
--Id – unique number for every user. There will be no more than 263-1 users. (Auto incremented)
--Username – unique identifier of the user. It will be no more than 30 characters (non Unicode). (Required)
--Password – password will be no longer than 26 characters (non Unicode). (Required)
--ProfilePicture – image with size up to 900 KB. 
--LastLoginTime
--IsDeleted – shows if the user deleted his/her profile. Possible states are true or false.
--Make the Id a primary key. Populate the table with exactly 5 records. Submit your CREATE and INSERT statements as Run queries & check DB.


CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY(1,1),
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR (26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX)
	CHECK (DATALENGTH(ProfilePicture) <= 900000),
	[LastLoginTime] DATETIME2 NOT NULL,
	[IsDeleted] BIT NOT NULL)
	--YYYY-MM-DD hh:mm:ss

	GO
INSERT INTO [Users] ([Username],[Password],[ProfilePicture],[LastLoginTime],[IsDeleted])
	VALUES 
	('Gosjho','wadwad',NULL,'1990-11-10 05:20:12',1),
	('Goawd','wadwadsa',NULL,'1990-06-10 05:20:12',1),
	('Gosjhasdao','waawdawddwad',NULL,'1991-03-10 05:20:12',0),
	('Gosjhasdaod','wadwasdad',NULL,'1230-09-10 05:20:12',0),
	('Gosjhawdawdo','wadwawdadwad',NULL,'1141-09-11 03:21:02',0)

	
	GO
	

	SELECT name
FROM   sys.key_constraints
WHERE  [type] = 'PK'
       AND [parent_object_id] = Object_id('dbo.Users');
	   GO

	ALTER TABLE [USERS]
	DROP CONSTRAINT PK__Users__3214EC0797187B55
	GO

	ALTER TABLE [Users]
	ADD CONSTRAINT PK_Users PRIMARY KEY ([Id],[Username]);

	GO
	ALTER TABLE [Users]
	ADD CONSTRAINT [CHKPASS_ATLEAST_5_SYMBOLS_LONG] CHECK (DATALENGTH([Password]) >=5)

	--ADD CONSTRAINT CHK_PersonAge CHECK (Age>=18 AND City='Sandnes');
	   
	   --ALTER TABLE Persons
--ADD CONSTRAINT df_City
--DEFAULT 'Sandnes' FOR City;

	ALTER TABLE [Users]
	ADD CONSTRAINT df_loginTime
	DEFAULT SYSDATETIME() FOR [LastLoginTime]

	GO

	ALTER TABLE [Users]
	DROP CONSTRAINT PK_Users 

	GO

	ALTER TABLE [Users]
	Add CONSTRAINT PK_Users PRIMARY KEY([Id])

	GO
	ALTER TABLE [Users]
	ADD CONSTRAINT CHECK_MINLENTGH_USERNAME CHECK (DATALENGTH([Username]) >=3)
