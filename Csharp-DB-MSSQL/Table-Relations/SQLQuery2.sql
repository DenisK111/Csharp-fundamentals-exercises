USE Relations

CREATE TABLE PERSONS (
[Id] INT,
[FirstName] NVARCHAR NOT NULL,
[Salary] DECIMAL(10,2),
[Passport Id] INT) 

CREATE TABLE Passports(
[PassportID] INT PRIMARY KEY IDENTITY(101,1),
[PassportNumber] CHAR(8) UNIQUE NOT NULL)

ALTER TABLE Persons
ADD 
	UNIQUE ([Passport Id]),
	CONSTRAINT FK_PassportId FOREIGN KEY ([Passport Id]) REFERENCES Passports(PassportID)




