CREATE DATABASE [Minions] 
		
		CREATE TABLE [Minions](
		[Id] INT PRIMARY KEY,
		[Name] NVARCHAR(50) Not NULL,
		[Age] SMALLINT Not null)

		CREATE TABLE [Towns](
		[Id] INT PRIMARY KEY,
		[Name] NVARCHAR(50) NOT NULL
		)


		ALTER TABLE [Minions]
    ADD [TownId] INTEGER,
    FOREIGN KEY ([TownId]) REFERENCES [Towns](Id);

	INSERT INTO [Towns] ([Id],[Name])
	Values (1,'Sofia')
	INSERT INTO [Towns] ([Id],[Name])
	Values (2,'Plovdiv')
	INSERT INTO [Towns] ([Id],[Name])
	Values (3,'Varna')

	ALTER TABLE [Minions] ALTER COLUMN [Age] INT NULL

	INSERT INTO [Minions] ([Id],[Name],[Age],[TownId])
	Values (1,'Kevin',22,1)
	INSERT INTO [Minions] ([Id],[Name],[Age],[TownId])
	Values (2,'Bob',15,3)
	INSERT INTO [Minions] ([Id],[Name],[TownId])
	Values (3,'Steward',2)

	UPDATE [Minions]
	SET [Age] = NULL
	WHERE [Id] = 3

	Select * FROM [Minions]
	WHERE Id = 3

	UPDATE [Minions]
	SET [Name] = 'Steward'
	WHERE [Id] = 3

		Select * FROM [Minions]
	WHERE Id = 3

	TRUNCATE TABLE [Minions]
	DROP TABLE [Minions]
	DROP TABLE [Towns]

