--Using SQL queries create Movies database with the following entities:
--Directors (Id, DirectorName, Notes)
--Genres (Id, GenreName, Notes)
--Categories (Id, CategoryName, Notes)
--Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
--Set the most appropriate data types for each column. Set a primary key to each table. Populate each table with exactly 5 records. Make sure the columns that are present in 2 tables would be of the same data type. Consider which fields are always required and which are optional. Submit your CREATE TABLE and INSERT statements as Run queries & check DB.

CREATE TABLE [Directors]([Id] INT PRIMARY KEY IDENTITY(1,1)
	,[DirectorName] NVARCHAR(200) NOT NULL
	,[Notes] NVARCHAR(MAX))

	GO
	INSERT INTO [Directors] ([DirectorName])
		Values
		('John'),
		('Ivan'),
		('Iva'),
		('Sam'),
		('Bam')
CREATE TABLE [Genres]([Id] INT PRIMARY KEY IDENTITY(1,1)
	,[GenreName] NVARCHAR(200) NOT NULL
	,[Notes] NVARCHAR(MAX))

	GO

	INSERT INTO [Genres] ([GenreName])
		Values
		('Action'),
		('Drama'),
		('Anime'),
		('Soap Opera'),
		('Adventure')

CREATE TABLE [Categories]([Id] INT PRIMARY KEY IDENTITY(1,1)
	,[CategoryName] NVARCHAR(200) NOT NULL
	,[Notes] NVARCHAR(MAX))

	GO
	INSERT INTO [Categories] ([CategoryName])
		Values
		('PG13'),
		('All'),
		('Kids'),
		('Teens'),
		('Kids')
	
	GO

CREATE TABLE [Movies]([Id] INT PRIMARY KEY IDENTITY(1,1)
	,[Title] NVARCHAR(300) NOT NULL
	,[DirectorId] INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL
	,[CopyrightYear] SMALLINT NOT NULL
	,[Length] TIME(0) NOT NULL
	,[GenreId]INT FOREIGN KEY REFERENCES Genres(Id)
	,[CategoryId]INT FOREIGN KEY REFERENCES Categories(Id)
	,[Rating] DECIMAL(3,1)
	CONSTRAINT CK_RATINGVALUE CHECK([Rating] >= 0 AND [Rating] <= 10)
	,[Notes] NVARCHAR(MAX))
	GO

	INSERT INTO [Movies] ([Title],[DirectorId],[CopyrightYear],[Length],[GenreId],[CategoryId],[Rating])
		Values
		('Movie1',3,1990,'02:01:00',1,NULL,0),
		('Movie2',1,1990,'02:01:00',Null,1,10),
		('Movie3',2,1990,'02:01:00',4,NULL,1.2),
		('Movie4',5,1990,'02:01:00',3,3,9.4),
		('Movie5',1,1990,'02:01:00',2,NULL,0.6)

	GO
		DROP TABLE [Directors]
		DROP TABLE [Categories]
		DROP TAble[Movies]
		DROP TABLE[Genres]
