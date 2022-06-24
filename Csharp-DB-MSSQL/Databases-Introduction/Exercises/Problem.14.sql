--Using SQL queries create CarRental database with the following entities:
--Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
--Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
--Employees (Id, FirstName, LastName, Title, Notes)
--Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
--RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
--Set the most appropriate data types for each column. Set a primary key to each table. Populate each table with only 3 records. Make sure the columns that are present in 2 tables would be of the same data type. Consider which fields are always required and which are optional. Submit your CREATE TABLE and INSERT statements as Run queries & check DB.

CREATE DATABASE [CarRental]

CREATE TABLE [Categories]([Id] INT PRIMARY KEY IDENTITY(1,1)
	,[CategoryName] NVARCHAR(50) UNIQUE NOT NULL
	,[DailyRate] DECIMAL (10,2) NOT NULL
	,[WeeklyRate] DECIMAL (10,2) 
	,[MonthlyRate] DECIMAL (10,2) 
	,[WeekendRate] DECIMAL (10,2) )

INSERT INTO [Categories] ([CategoryName],[DailyRate],[WeeklyRate],[MonthlyRate],[WeekendRate])
	Values
	('Sedan',4.20,50,350,14),
	('Hatchback',4.21,50,310,11),
	('SUV',4.14,51,330,15)

CREATE TABLE [Cars]([Id] INT PRIMARY KEY IDENTITY(1,1)
	,[PlateNumber] NVARCHAR(10) UNIQUE NOT NULL
	,[Manufacturer] NVARCHAR(50)  NOT NULL
	,[Model] NVARCHAR(100) NOT NULL
	,[CarYear] SMALLINT NOT NULL
	,[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id) 
	,[Doors] TINYINT --not null
	,[Picture] VARBINARY
	CONSTRAINT CK_DATALENGTH CHECK (DATALENGTH(Picture) < 2000000)
	,[Condition] NVARCHAR(30) -- not null
	,[Available] CHAR(1) --not null
	CONSTRAINT CK_YESORNO CHECK ([Available] = 'y' OR [Available] = 'n'))

	
	

	


INSERT INTO [Cars] ([PlateNumber],[Manufacturer],[Model],[CarYear],[CategoryId],[Doors],[Condition],[Available])
	Values
	('BG 134 MG','Audi','A4',2009,1,5,'new','y'),
	('BG 114 MG','BMW','B3',2010,1,3,'used','n'),
	('BG 144 MG','Mercedes','C220',2041,1,2,'used','y')

CREATE TABLE [Employees] ([Id] INT PRIMARY KEY IDENTITY(1,1)
	,[FirstName] NVARCHAR(50) NOT NULL
	,[LastName] NVARCHAR(50) NOT NULL
	,[Title] NVARCHAR(50) 
	Constraint CK_TITLE CHECK ([Title] = 'CEO' OR [Title] = 'CTO' OR [Title] = 'Worker')
	,[Notes] NVARCHAR(MAX))

	


INSERT INTO [Employees] ([FirstName],[LastName],[Title])
	Values
		('Ivan','Ivanov','CEO'),
		('Petar','Ivanov','CTO'),
		('Georgi','Ivanov','Worker')

CREATE TABLE [Customers] ([Id] INT PRIMARY KEY IDENTITY(1,1)
	,[DriverLicenceNumber] NVARCHAR(50) UNIQUE NOT NULL
	,[FullName] NVARCHAR(200) NOT NULL
	,[Address] NVARCHAR(200) NOT NULL 
	,[City] NVARCHAR(60)  NOT NULL
	,[ZipCode] NVARCHAR(10) NOT NULL
	,[Notes] NVARCHAR(MAX))



INSERT INTO [Customers] ([DriverLicenceNumber],[FullName],[Address],[City],[ZipCode])
	VALUES
	('124d1','Ivan Ivanov','Bul. Bulgaria 22','Sofia',4000),
	('1241d1','Ivan Ivanov','Bul. Bulgaria 23','Varna',4100),
	('124d21','Ivan Ivanov','Bul. Bulgaria 21','Plovdiv',4020)

	

CREATE TABLE [RentalOrders] ([Id] INT PRIMARY KEY IDENTITY(1,1),
	[EmployeeId] INT Foreign KEY References Employees(Id) NOT NULL,
	[CustomerId] INT Foreign KEY References Customers(Id) NOT NULL,
	[CarId] INT Foreign KEY References Cars(Id) NOT NULL,
	[TankLevel] SMALLINT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] Date NOT NULL,
	[EndDate] Date NOT NULL,
	[TotalDays] SmallInt NOT NULL,
	[RateApplied] NVARCHAR(30) NOT NULL,
	[TaxRate] TinyInt NOT NULL,
	[OrderStatus] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(MAX)) 

	INSERT INTO [RentalOrders]([EmployeeId],[CustomerId],[CarId],[TankLevel],[KilometrageStart],[KilometrageEnd],[TotalKilometrage],[StartDate],[EndDate],[TotalDays],[RateApplied],[TaxRate],[OrderStatus])
		VALUES
			(2,1,3,242,1234,1525,331,'2021-08-11','2021-08-15',4,'Weekend Rate',20,'Completed'),
			(2,1,2,241,1231,1535,334,'2021-08-12','2021-08-13',1,'Daily Rate',20,'Completed'),
			(3,3,1,243,1232,1545,332,'2021-08-10','2021-08-11',1,'Daily Rate',20,'Completed')

