
--Now create bigger database called SoftUni. You will use the same database in the future tasks. It should hold information about
--Towns (Id, Name)
--Addresses (Id, AddressText, TownId)
--Departments (Id, Name)
--Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
--The Id columns are auto incremented, starting from 1 and increased by 1 (1, 2, 3, 4…). Make sure you use appropriate data types for each column. Add primary and foreign keys as constraints for each table. Use only SQL queries. Consider which fields are always required and which are optional.

--

CREATE DATABASE [SoftUni]

CREATE TABLE [Towns] ([Id] INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(100) NOT NULL)

CREATE TABLE [Addresses]([Id] INT PRIMARY KEY IDENTITY(1,1),
[AddressText] NVARCHAR(200) NOT NULL,
[TownId] INT FOREIGN KEY REFERENCES Towns(Id))

CREATE TABLE [Departments]([Id] INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(150) NOT NULL)

CREATE TABLE [Employees]([Id] INT PRIMARY KEY IDENTITY(1,1),
	[FirstName] NVARCHAR(50) NOT NULL,
	[MiddleName]NVARCHAR(50),
	[LastName]NVARCHAR(50) NOT NULL,
	[JobTitle]NVARCHAR(60) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	[HireDate] DATE NOT NULL,
	[Salary] DECIMAL (12,2) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES Addresses(Id))

INSERT INTO [Towns] ([Name])
	VALUES
		('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas')

INSERT INTO [Departments] ([Name])
	VALUES
		('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Development'),
		('Quality Assurance')


--Engineering, Sales, Marketing, Software Development, Quality Assurance

INSERT INTO [Employees]([FirstName],[MiddleName],[LastName],[JobTitle],[DepartmentId],[HireDate],[Salary])
	Values
	--Ivan Ivanov Ivanov	.NET Developer	Software Development	01/02/2013	3500.00
	--Petar Petrov Petrov	Senior Engineer	Engineering	02/03/2004	4000.00
	--Maria Petrova Ivanova	Intern	Quality Assurance	28/08/2016	525.25
	--Georgi Teziev Ivanov	CEO	Sales	09/12/2007	3000.00
	--Peter Pan Pan	Intern	Marketing	28/08/2016	599.88

	('Ivan','Ivanov','Ivanov','.NET Developer',4,'2013-02-01',3500.00),
	('Petar','Petrov','Petrov','Senior Engineer',1,'2004-03-02',4000.00),
	('Maria','Petrova','Ivanova','Intern',5,'2016-08-28',525.25),
	('Georgi','Terziev','Ivanov','CEO',2,'2007-12-09',3000.00),
	('Peter','Pan','Pan','Intern',3,'2016-08-28',599.88)

	Select [Name]
	FROM [Towns]
	ORDER BY [NAME] 

	Select [Name]
	FROM [Departments]
	ORDER BY [NAME] 

	Select FirstName, LastName, JobTitle, Salary
	FROM [Employees]
	ORDER BY Salary DESC

	UPDATE [EMPLOYEES]
	SET Salary = Salary * 1.1

	SELECT SALARY 
	FROM EMPLOYEES