--Using SQL query, create table People with the following columns:
--Id – unique number. For every person there will be no more than 231-1 people. (Auto incremented)
--Name – full name of the person. There will be no more than 200 Unicode characters. (Not null)
--Picture – image with size up to 2 MB. (Allow nulls)
--Height – in meters. Real number precise up to 2 digits after floating point. (Allow nulls)
--Weight – in kilograms. Real number precise up to 2 digits after floating point. (Allow nulls)
--Gender – possible states are m or f. (Not null)
--Birthdate – (Not null)
--Biography – detailed biography of the person. It can contain max allowed Unicode characters. (Allow nulls)



CREATE TABLE [People] ( [Id] INT IDENTITY(1,1) PRIMARY KEY
	,[Name] NVARCHAR(200) Not NUll
	,[Picture] VARBINARY(max)
	CHECK (DATALENGTH([Picture]) <= 2000000)
	,[Height] DECIMAL(3,2)
	,[Weight] DECIMAL(5,2)
	,[Gender] CHAR(1) Not NUll
	CHECK([GENDER] = 'm' OR [GENDER] ='f')
	,[Birthdate] DATE Not NUll
	,[Biography] NVARCHAR(MAX))


INSERT INTO [People] ([Name],[Picture],[Height],[Weight],[Gender],[Birthdate],[Biography])
	Values 
	('Ivan',NULL,1.80,69.90,'m','1990-09-13','Lorem ipsum'),
	('Mira',NULL,NULL,NUll,'f','1980-09-11','Lorem ipsum'),
	('Joro',NULL,1.50,50.12,'m','1910-09-13','Lorem ipsum'),
	('Koko',NULL,1.87,80,'m','2001-03-04','Lorem ipsum'),
	('Soko',NULL,1.99,Null,'m','1991-12-30','Lorem ipsum')

	