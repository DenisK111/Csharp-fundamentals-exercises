--1

SELECT TOP(5) EmployeeID,JobTitle,e.AddressID,AddressText
FROM Employees as e
JOIN Addresses as a ON e.AddressID = a.AddressID
ORDER BY e.AddressID

--2
SELECT TOP(50) FirstName,LastName,t.Name,AddressText
FROM Employees as e
JOIN Addresses as a ON e.AddressID = a.AddressID
JOIN Towns as t ON a.TownID = t.TownID
ORDER BY FirstName,LastName

--3
SELECT e.EmployeeID,e.FirstName,e.LastName,d.[Name]
FROM Employees as e
JOIN Departments as d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

--4
Select TOP(5) e.EmployeeID,e.FirstName,e.Salary,d.[Name]
FROM Employees as e
JOIN Departments as d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID
--5
SELECT TOP(3) e.EmployeeID,FirstName
FROM Employees as e
FULL JOIN EmployeesProjects as ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID
--6
SELECT e.FirstName,e.LastName,e.HireDate,d.[Name]
FROM Employees as e
JOIN Departments as d ON e.DepartmentID = d.DepartmentID
WHERE DATEPART(YY,HireDate) >= 1999 AND d.[Name] IN ('Sales','Finance')
ORDER BY HireDate
--7
SELECT TOP(5) e.EmployeeID,e.FirstName,p.[Name] 
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND EndDate IS NULL
ORDER BY e.EmployeeID
--8
SELECT 
	e.EmployeeID,
	e.FirstName,
	CASE 
		WHEN DATEPART(yy,p.StartDate) >= 2005
		THEN NULL
		ELSE p.[Name]
	END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24


--9

SELECT e.EmployeeID,e.FirstName,e.ManagerID,em.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS em ON em.EmployeeID = e.ManagerID 
WHERE em.EmployeeID IN(3,7)
ORDER BY e.EmployeeID

--10
--Write a query that selects:
--EmployeeID
--EmployeeName
--ManagerName
--DepartmentName
--Show first 50 employees with their managers and the departments they are in (show the departments of the employees). Order by EmployeeID.

SELECT TOP(50)
	e.EmployeeID,
	CONCAT(e.FirstName,' ',e.LastName) as EmployeeName,
	CONCAT(em.FirstName,' ',em.LastName) as ManagerName,
	d.Name AS DepartmentName
FROM Employees as e
LEFT JOIN Employees as em ON em.EmployeeID = e.ManagerID
LEFT JOIN Departments as d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--11
SELECT TOP(1)
	(SELECT 
		AVG(e.Salary) 
		FROM Employees e 
		WHERE e.DepartmentID = d.DepartmentID)  as MinAvarageSalary
FROM Departments as d
ORDER BY MinAvarageSalary
--12
USE GEOGRAPHY
--Write a query that selects:
--CountryCode
--MountainRange
--PeakName
--Elevation
--Filter all peaks in Bulgaria with elevation over 2835. Return all the rows sorted by elevation in descending order.

SELECT c.CountryCode,m.MountainRange,p.PeakName,p.Elevation
FROM Countries as c
JOIN MountainsCountries as mc ON mc.CountryCode = c.CountryCode
JOIN Mountains as m ON m.Id = mc.MountainId
JOIN Peaks as p ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--13


SELECT c.CountryCode,
 (Select Count(MountainRange)
	FROM Mountains AS mi
	JOIN MountainsCountries AS mci ON mci.MountainId = mi.Id
	WHERE mci.CountryCode = c.CountryCode) AS MountainRanges
FROM Countries AS c
--LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode 
--LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE c.CountryName IN('United States', 'Russia' , 'Bulgaria')

--14

SELECT TOP(5) c.CountryName,r.RiverName
FROM Countries as c
LEFT JOIN CountriesRivers as cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers as r ON r.Id = cr.RiverId
WHERE c.ContinentCode = (Select ContinentCode FROM Continents as co WHERE co.ContinentName = 'Africa')
ORDER BY c.CountryName

--15
--Write a query that selects:
--ContinentCode
--CurrencyCode
--CurrencyUsage
--Find all continents and their most used currency. Filter any currency that is used in only one country. Sort your results by ContinentCode.


SELECT curr.ContinentCode,curr.CurrencyCode,curr.CurrencyUsage
FROM
(SELECT ContinentCode,CurrencyCode,Count(CurrencyCode) as CurrencyUsage,DENSE_RANK() OVER (Partition BY ContinentCode ORDER BY Count(CurrencyCode) DESC) as ranked
FROM Countries as c
GROUP BY ContinentCode,CurrencyCode) as curr
WHERE ranked = 1 AND CurrencyUsage >1

 
--16

SELECT Count(*) as Count
FROM Countries as c
LEFT OUTER JOIN MountainsCountries as mc ON c.CountryCode = mc.CountryCode
WHERE mc.MountainId IS NULL

--17

--For each country, find the elevation of the highest peak and the length of the longest river, sorted by the highest peak elevation (from highest to lowest), then by the longest river length (from longest to smallest), then by country name (alphabetically). Display NULL when no data is available in some of the columns. Limit only the first 5 rows.


SELECT TOP(5) CountryName,MAX(p.Elevation) as HighestPeakElevation,Max(r.Length) as LongestRiverLength
FROM COUNTRIES as c
LEFT JOIN  MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN PEAKS as p ON p.MountainId = mc.MountainId
LEFT JOIN CountriesRivers as cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers as r ON r.Id = cr.RiverId
GROUP BY CountryName
ORDER BY HighestPeakElevation DESC,LongestRiverLength DESC,c.CountryName

--18

--For each country, find the name and elevation of the highest peak, along with its mountain. When no peaks are available in some country, display elevation 0, "(no highest peak)" as peak name and "(no mountain)" as mountain name. When multiple peaks in some country have the same elevation, display all of them. Sort the results by country name alphabetically, then by highest peak name alphabetically. Limit only the first 5 rows.
SELECT TOP(5)r.CountryName, 
				CASE 
					WHEN r.PeakName IS NULL
					THEN '(no highest peak)'
					ELSE r.PeakName
				END as '(Highest Peak Name)',
				CASE 
					WHEN r.Elevation IS NULL
					THEN 0
					ELSE r.Elevation
				END as '(Highest Peak Elevation)',
				CASE 
					WHEN r.MountainRange IS NULL
					THEN '(no mountain)'
					ELSE r.MountainRange
				END as '(Mountain)'

FROM(
SELECT c.CountryName,p.PeakName,p.Elevation,m.MountainRange,DENSE_RANK() OVER (Partition BY c.CountryName ORDER BY p.Elevation DESC) as ranked
FROM countries as c
LEFT JOIN MountainsCountries as mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Peaks as p on p.MountainId = mc.MountainId
LEFT JOIN Mountains as m ON p.MountainId = m.Id
GROUP BY c.CountryName,p.PeakName,p.Elevation,m.MountainRange
	) as r
WHERE ranked = 1
ORDER BY r.CountryName,r.PeakName







