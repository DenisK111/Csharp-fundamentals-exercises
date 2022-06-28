USE SoftUni
--1
SELECT FirstName,LastName
FROM
Employees
WHERE LEFT(FirstName,2) = 'SA'
--2
SELECT FirstName,LastName
FROM
Employees
WHERE LastName LIKE '%ei%'

--3
SELECT FirstName
FROM
Employees
WHERE DepartmentID IN (3,10) and Year(HireDate) Between 1995 AND 2005

--4

SELECT FirstName,LastName
FROM
Employees
WHERE JobTitle NOT LIKE '%engineer%'

--5
SELECT [Name]
FROM Towns
WHERE LEN([Name]) IN (5,6)
ORDER BY [Name]

--6
SELECT *
FROM TOWNS
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

--7

SELECT *
FROM TOWNS
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]

--8

CREATE VIEW V_EmployeesHiredAfter2000 
AS
	SELECT FirstName,LastName
	FROM Employees
	WHERE YEAR(HireDate) >= 2001

SELECT *
FROM V_EmployeesHiredAfter2000

--9
SELECT FirstName,LastName 
FROM Employees
WHERE LEN(LastName) = 5
--10
SELECT 
	EmployeeID,
	FirstName,
	LastName,
	Salary,
	DENSE_RANK() OVER(PARTITION BY Salary
	ORDER BY EMPLOYEEID) [Rank] 
FROM
EMPLOYEES
WHERE SALARY BETWEEN 10000 and 50000
ORDER BY SALARY DESC


--11

SELECT * 
FROM
		(SELECT 
			EmployeeID,
			FirstName,
			LastName,
			Salary,
			DENSE_RANK() OVER(PARTITION BY Salary
			ORDER BY EMPLOYEEID) [Rank]
		FROM
		EMPLOYEES
		WHERE SALARY BETWEEN 10000 and 50000 
		) as s
WHERE [Rank] = 2
ORDER BY SALARY DESC

--12
USE [Geography]

SELECT CountryName,IsoCode
FROM Countries
WHERE DATALENGTH(CountryName) - DATALENGTH(REPLACE(COUNTRYNAME,'a','')) >= 3
ORDER BY IsoCode

--13
SELECT *, LOWER(CONCAT(SUBSTRING(PeakName,1,Len(PeakName)-1), RiverName)) AS Mix
FROM(
		SELECT p.PeakName AS PeakName
		,r.RiverName AS RiverName
		FROM [PEAKS] AS p
		JOIN Rivers AS r ON Left(r.RiverName,1) = Right(p.PeakName,1) 
		) AS s
ORDER BY Mix

--14
USE DIABLO

SELECT TOP(50) [Name],FORMAT([Start],'yyyy-MM-dd') AS [Start]
FROM Games
WHERE Year([Start]) IN (2011,2012)
ORDER BY [Start],[Name]

--15
SELECT Username,SUBSTRING(Email,CHARINDEX('@',Email) + 1,Len(Email) - CHARINDEX('@',Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider],Username

--16
SELECT Username,IpAddress
FROM USERS
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--17

SELECT [Name] AS Game, 
		CASE 
			WHEN (DATEPART(hour,[Start]) BETWEEN 0 AND 11)
			THEN 'Morning'
			WHEN (DATEPART(hour,[Start]) BETWEEN 12 AND 17)
			THEN 'Afternoon'
			WHEN (DATEPART(hour,[Start]) BETWEEN 18 AND 23)
			THEN 'Evening'
		END AS [Part of the Day],
		CASE 
			WHEN Duration<=3
			THEN 'Extra Short'
			WHEN Duration BETWEEN 4 AND 6
			THEN 'Short'
			WHEN Duration>6
			THEN 'Long'
			WHEN Duration IS NULL
			THEN 'Extra Long'
		END AS Duration
FROM Games
ORDER BY Game,Duration,[Part of the Day]

--18
USE Orders

SELECT 
	*,
	DATEADD(DD,3,OrderDate) AS [Pay Due],
	DATEADD(MM,1,OrderDate) AS [Deliver Due]
FROM Orders
--19

--Create a table People(Id, Name, Birthdate). Write a query to find age in years, months, days and minutes for each person for the current time of executing the query.

USE Relations

CREATE TABLE People (
Id INT  PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
BirthDate Datetime2)

INSERT INTO People
	VALUES
	('Victor','2000-12-07 '),
	('Steven','1992-09-10 '),
	('Stephen','1910-09-19 '),
	('John','2010-01-06 ')

SELECT 
	[Name],
	DATEDIFF(YY,BirthDate,GetDate()) AS [Age in Years],
	DATEDIFF(MM,BirthDate,GetDate()) AS [Age in Months],
	DATEDIFF(DD,BirthDate,GetDate()) AS [Age in Days],
	DATEDIFF(MINUTE,BirthDate,GetDate()) AS [Age in Minutes]

FROM People
