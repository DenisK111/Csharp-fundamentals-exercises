
CREATE TABLE Passports(
[PassportID] INT PRIMARY KEY IDENTITY(101,1),
[PassportNumber] CHAR(8) UNIQUE NOT NULL)

CREATE TABLE Persons (
[ID] INT PRIMARY KEY IDENTITY(1,1),
[FirstName] NVARCHAR(50) NOT NULL,
[Salary] DECIMAL(10,2),
[PassportID] INT UNIQUE FOREIGN KEY REFERENCES Passports(PassportID)) 



--ALTER TABLE Persons
--ADD 
	--UNIQUE ([Passport Id]),
	--CONSTRAINT FK_PassportId FOREIGN KEY ([Passport Id]) REFERENCES Passports(PassportID)

INSERT INTO Passports 
	VALUES 
	('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2')

INSERT INTO Persons 
	VALUES 
	('Roberto',43300.00,102),
	('Tom',56100.00,103),
	('Yana',60200.00,101)







