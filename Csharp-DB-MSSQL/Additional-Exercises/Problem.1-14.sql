--1
USE DIABLO
SELECT *,COUNT(*) AS [Number of Users]
FROM(
	SELECT SUBSTRING(Email,CHARINDEX('@',Email,1) + 1,LEN(Email)) AS [Email Provider]
FROM USERS) as u
GROUP BY u.[Email Provider]
ORDER BY [Number of Users] DESC,u.[Email Provider]

--2

SELECT g.Name,gt.Name,u.Username,ug.Level,ug.Cash,c.Name 
FROM UsersGames AS ug
JOIN USERS AS u ON  ug.UserId = u.Id
JOIN Games as g ON ug.GameId = g.Id
JOIN GameTypes as gt ON g.GameTypeId = gt.Id
JOIN Characters AS c ON c.Id = ug.CharacterId
ORDER BY ug.Level DESC,u.Username,g.Name

--3

--Find all users in games with their items count and items price. Display the username, game name, items count and items price. 
--Display only user in games with items count more or equal to 10. 
--Sort the results by items count in descending order then by price in descending order and by username in ascending order. Submit your query statement as Prepare DB & run queries in Judge.

SELECT u.Username,g.Name,Count(ugi.ItemId) AS [Items Count],SUM(i.Price) AS [Items Price]
FROM UsersGames AS ug
JOIN UserGameItems as ugi ON ug.Id = ugi.UserGameId
JOIN Users as u ON u.Id = ug.UserId
JOIN Games as g ON g.Id = ug.GameId
JOIN Items as i ON ugi.ItemId = i.Id
GROUP BY u.Username,g.Name
HAVING Count(ugi.ItemId) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC,u.Username

--4

SELECT u.Username,g.Name,MAX(c.Name) AS CharacterName,
	Sum(istats.Strength) + Max(gameStats.Strength) + Max(charStats.Strength) AS Strength,
	Sum(istats.Defence) + Max(gameStats.Defence) + Max(charStats.Defence) AS Defence,
	Sum(istats.Speed) + Max(gameStats.Speed) + Max(charStats.Speed) AS Speed,
	Sum(istats.Mind) + Max(gameStats.Mind) + Max(charStats.Mind) AS Mind,
	Sum(istats.Luck) + Max(gameStats.Luck) + Max(charStats.Luck) AS Luck
FROM UsersGames AS ug
JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
JOIN Users AS u ON u.Id = ug.UserId
JOIN Items AS i ON i.Id = ugi.ItemId
JOIN [Statistics] AS istats ON istats.Id = i.StatisticId
JOIN Games AS g ON g.Id = ug.GameId
JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
JOIN [Statistics] AS gameStats ON gameStats.Id = gt.BonusStatsId
JOIN Characters AS c on c.Id = ug.CharacterId
JOIN [Statistics] AS charStats ON charStats.Id = c.StatisticId
GROUP BY u.Username,g.Name
ORDER BY Strength DESC,Defence DESC,Speed DESC,Mind DESC,Luck Desc

--5
--Find all items with statistics larger than average. 
--Display only items that have Mind, Luck and Speed greater than average Items mind, luck and speed.
--Sort the results by item names in alphabetical order. Submit your query statement as Prepare DB & run queries in Judge.

DECLARE @avarageMind INT = (SELECT AVG(Mind) FROM [Statistics] AS s JOIN Items ON Items.StatisticId = s.Id)
DECLARE @avarageLuck INT = (SELECT AVG(Luck) FROM [Statistics] AS s JOIN Items ON Items.StatisticId = s.Id)
DECLARE @avarageSpeed INT = (SELECT AVG(Speed) FROM [Statistics] AS s JOIN Items ON Items.StatisticId = s.Id)
SELECT i.Name,i.Price,i.MinLevel,s.Strength,s.Defence,s.Speed,s.Luck,s.Mind
FROM Items as i
JOIN [Statistics] AS s ON i.StatisticId = s.Id
WHERE s.Mind > @avarageMind AND s.Luck > @avarageLuck AND s.Speed > @avarageSpeed
ORDER BY i.Name

--6
--Find all items and information whether and what forbidden game types they have.
--Display item name, price, min level and forbidden game type. Display all items.
--Sort the results by game type in descending order, then by item name in ascending order. 

SELECT i.Name,i.Price,i.MinLevel,gt.Name AS ForbiddenGameType
FROM ITEMS AS i
LEFT JOIN GameTypeForbiddenItems AS fi ON i.Id = fi.ItemId
LEFT JOIN GameTypes as gt ON gt.Id = fi.GameTypeId
ORDER BY gt.Name DESC, i.Name

--7

--User Alex is in the shop in the game “Edinburgh” and she wants to buy some items. She likes Blackguard, Bottomless Potion of Amplification, Eye of Etlich (Diablo III), Gem of Efficacious Toxin, Golden Gorget of Leoric and Hellfire Amulet. Buy the items. You should add the data in the right tables. Get the money for the items from user in game Cash.
--Select all users in the current game with their items. Display username, game name, cash and item name. Sort the result by item name.

SELECT SUM(Price)
FROM Items 
WHERE Name IN ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin','Golden Gorget of Leoric' ,'Hellfire Amulet')

SELECT ID
FROM Items 
WHERE Name IN ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin','Golden Gorget of Leoric' ,'Hellfire Amulet')

SELECT ug.ID
FROM UsersGames as ug
JOIN Users as u ON u.Id = ug.UserId
JOIN Games as g ON g.Id = ug.GameId
WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh'

SELECT CASH 
FROM UsersGames as ug
JOIN Users as u ON u.Id = ug.UserId
JOIN Games as g ON g.Id = ug.GameId
WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh'

SELECT  *, 235
FROM (SELECT ID
FROM Items 
WHERE Name IN ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin','Golden Gorget of Leoric' ,'Hellfire Amulet')) as it

INSERT INTO UserGameItems (ItemId,UserGameId)
SELECT *, 235
FROM (SELECT ID
FROM Items 
WHERE Name IN ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin','Golden Gorget of Leoric' ,'Hellfire Amulet')) as it

SELECT *
FROM UserGameItems
WHERE UserGameId = 235

UPDATE UsersGames
SET CASH -= (SELECT SUM(Price)
FROM Items 
WHERE Name IN ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin','Golden Gorget of Leoric' ,'Hellfire Amulet'))
WHERE ID = 235

SELECT u.Username,g.Name,ug.Cash,i.Name
FROM UsersGames as ug
JOIN Users as U ON ug.UserId = u.Id
JOIN Games as g ON g.Id = ug.GameId
JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
JOIN Items as i ON i.Id = ugi.ItemId
WHERE g.Name = 'Edinburgh'
ORDER BY i.Name

--8
USE GEOGRAPHY
-- Find all peaks along with their mountain sorted by elevation (from the highest to the lowest), then by peak name alphabetically. 
-- Display the peak name, mountain range name and elevation. Submit your query statement as Prepare DB & run queries in Judge.

SELECT p.PeakName,m.MountainRange,p.Elevation
FROM PEAKS as p
JOIN Mountains as m ON p.MountainId = m.Id
ORDER BY p.Elevation DESC

--9
--Find all peaks along with their mountain, country and continent. 
--When a mountain belongs to multiple countries, display them all.
--Sort the results by peak name alphabetically, then by country name alphabetically. 

SELECT p.PeakName,m.MountainRange,c.CountryName,con.ContinentName
FROM PEAKS as p
JOIN Mountains as m on p.MountainId = m.Id
JOIN MountainsCountries as mc ON m.Id = mc.MountainId
JOIN Countries as c ON mc.CountryCode = c.CountryCode
JOIN Continents as con ON con.ContinentCode = c.ContinentCode
ORDER BY p.PeakName,c.CountryName

--10
--For each country in the database, display the number of rivers passing through that country and the total length of these rivers.
--When a country does not have any river, display 0 as rivers count and as total length. 
--Sort the results by rivers count (from largest to smallest), then by total length (from largest to smallest), then by country alphabetically. 

SELECT c.CountryName,con.ContinentName,ISNULL(COUNT(r.ID),0) AS RiversCount,ISNULL(SUM(r.Length),0) AS TotalLength
FROM Countries as c
LEFT JOIN Continents as con ON c.ContinentCode = con.ContinentCode
LEFT JOIN CountriesRivers as cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers as r ON r.Id = cr.RiverId
GROUP BY c.CountryName,con.ContinentName
ORDER BY COUNT(r.ID) DESC, SUM(r.Length) DESC,c.CountryName

--11
--Find the number of countries for each currency. 
--Display three columns: currency code, currency description and number of countries. 
--Sort the results by number of countries (from highest to lowest), then by currency description alphabetically.
--Name the columns exactly like in the table below. 

SELECT cur.CurrencyCode,cur.Description as Currency,COUNT(c.CountryCode) as NumberOfCountries
FROM Currencies as cur
LEFT JOIN Countries as c on c.CurrencyCode = cur.CurrencyCode
GROUP BY cur.CurrencyCode,cur.Description
ORDER BY NumberOfCountries DESC,Currency

--12
-- For each continent, display the total area and total population of all its countries.
-- Sort the results by population from highest to lowest. 

SELECT con.ContinentName, SUM(c.AreaInSqKm) AS CountriesArea, SUM(CAST(c.Population AS BigINT)) AS CountriesPopulation
FROM Continents as con
JOIN Countries as c ON con.ContinentCode = c.ContinentCode
GROUP BY con.ContinentName
ORDER BY CountriesPopulation DESC

--13

--Create a table Monasteries(Id, Name, CountryCode).
--Use auto-increment for the primary key.
--Create a foreign key between the tables Monasteries and Countries

CREATE TABLE Monasteries(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(200) NOT NULL,
CountryCode CHAR(2) REFERENCES Countries(CountryCode))

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

SELECT * FROM
Monasteries

ALTER TABLE Countries
ADD IsDeleted BIT NOT NULL DEFAULT  0

SELECT * 
FROM Countries

SELECT cr.CountryCode, COUNT(cr.riverId) as CountOfRivers
FROM Countries as c
JOIN CountriesRivers as cr ON c.CountryCode = cr.CountryCode
GROUP BY cr.CountryCode

UPDATE Countries
SET IsDeleted = 1
FROM COUNTRIES as c
JOIN (SELECT cr.CountryCode, COUNT(cr.riverId) as CountOfRivers
FROM Countries as c
JOIN CountriesRivers as cr ON c.CountryCode = cr.CountryCode
GROUP BY cr.CountryCode) as rc ON c.CountryCode = rc.CountryCode
WHERE rc.CountOfRivers >3

--Write a query to display all monasteries along with their countries sorted by monastery name. 
--Skip all deleted countries and their monasteries.

SELECT m.Name as Monastery,c.CountryName as Country 
FROM Monasteries as m
JOIN Countries as c ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
ORDER BY m.Name

--14

UPDATE Countries
SET CountryName ='Burma'
WHERE CountryName = 'Myanmar'


INSERT INTO Monasteries (Name,CountryCode)
	VALUES
	('Hanga Abbey',(SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania'))

INSERT INTO Monasteries (Name,CountryCode)
VALUES
('Myin-Tin-Daik',(SELECT CountryCode FROM Countries  WHERE CountryName = 'Myanmar'))



--Find the count of monasteries for each continent and not deleted country.
--Display the continent name, the country name and the count of monasteries. 
--Include also the countries with 0 monasteries. 
--Sort the results by monasteries count (from largest to lowest), then by country name alphabetically. Name the columns exactly like in the table below.

SELECT con.ContinentName,c.CountryName, Count(m.Name) as MonastrariesCount
FROM Continents as con
JOIN Countries as c ON con.ContinentCode = c.ContinentCode
LEFT JOIN Monasteries as m ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
Group BY con.ContinentName,c.CountryName
ORDER BY MonastrariesCount DESC, c.CountryName