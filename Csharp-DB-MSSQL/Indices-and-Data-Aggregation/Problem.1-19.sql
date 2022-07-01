USE Gringotts

--1
SELECT Count(*) as Count
FROM WizzardDeposits

--2
SELECT Max(MagicWandSize) as LongestMagicWand
FROM WizzardDeposits


--3

SELECT DepositGroup,Max(MagicWandSize) as LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup
--4
SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--5
SELECT DepositGroup, Sum(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

--6
SELECT DepositGroup, Sum(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--7
SELECT DepositGroup, Sum(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING Sum(DepositAmount) <= 150000
ORDER BY TotalSum DESC

--8 
--Create a query that selects:
--Deposit group 
--Magic wand creator
--Minimum deposit charge for each group 
--Select the data in ascending ordered by MagicWandCreator and DepositGroup.

SELECT DepositGroup,MagicWandCreator,MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator,DepositGroup

--9


SELECT w.Groups,Count(Age) AS WizardCount 
FROM(SELECT CASE 
        WHEN Age BETWEEN 0 AND 10
		THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20
		THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30
		THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40
		THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50
		THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60
		THEN '[51-60]'
		WHEN Age >60
		THEN '[61+]'
		END AS Groups,Age
FROM WizzardDeposits) AS w
GROUP BY w.Groups

--10
SELECT LEFT(FirstName,1) as FirstLetter
FROM WizzardDeposits
WHERE DepositGroup ='Troll Chest'
GROUP BY LEFT(FirstName,1)
ORDER BY FirstLetter

--11
--Mr. Bodrog is highly interested in profitability. He wants to know the average interest of all deposit groups split by whether the deposit has expired or not. But that’s not all. He wants you to select deposits with start date after 01/01/1985. Order the data descending by Deposit Group and ascending by Expiration Flag.
--The output should consist of the following columns:

SELECT DepositGroup,IsDepositExpired,AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup,IsDepositExpired
ORDER BY DepositGroup DESC,IsDepositExpired

--12
SELECT SUM(d.[Difference])
FROM
	(SELECT w.FirstName,w.DepositAmount,wd.FirstName as GuestFirstName,wd.DepositAmount as GuestDepositAmount,(w.DepositAmount-wd.DepositAmount) AS [Difference]
	FROM WizzardDeposits as w 
	JOIN WizzardDeposits  as wd ON w.Id + 1 = wd.Id) as d

--13
--That’s it! You no longer work for Mr. Bodrog. You have decided to find a proper job as an analyst in SoftUni. 
--It’s not a surprise that you will use the SoftUni database. Things get more exciting here!
--Create a query that shows the total sum of salaries for each department. Order by DepartmentID.
--Your query should return:	
--DepartmentID

USE SoftUni

SELECT DepartmentID,SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID

--14
--Select the minimum salary from the employees for departments with ID (2, 5, 7) but only for those hired after 01/01/2000.
--Your query should return:

SELECT DepartmentID,MIN(Salary) AS MinimumSalary
FROM Employees
WHERE HireDate >'01/01/2000'
GROUP BY DepartmentID
HAVING DepartmentID IN (2,5,7)

--15
--Select all employees who earn more than 30000 into a new table. Then delete all employees who have ManagerID = 42 (in the new table). Then increase the salaries of all employees with DepartmentID=1 by 5000. Finally, select the average salaries in each department.

SELECT * INTO NewTable FROM Employees WHERE Salary > 30000

DELETE FROM NewTable
WHERE ManagerID = 42

UPDATE NewTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentId,AVG(Salary)
FROM NewTable
GROUP BY DepartmentID

--16

-- Find the max salary for each department. Filter those, which have max salaries NOT in the range 30000 – 70000.

SELECT DepartmentID,Max(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--17

SELECT COUNT(*) AS COUNT
FROM Employees
WHERE ManagerID IS NULL

--18
SELECT s.DepartmentID, MAX(s.Salary) as ThirdHighestSalary
FROM
(SELECT DepartmentID, DENSE_RANK() OVER (Partition BY DepartmentID ORDER BY Salary DESC) AS ThirdLargestSalary,Salary
FROM Employees) as s
WHERE s.ThirdLargestSalary = 3
GROUP BY DepartmentID

--19

--Write a query that returns:
--FirstName
--LastName
--DepartmentID
--Select all employees who have salary higher than the average salary of their respective departments. Select only the first 10 rows. Order by DepartmentID.
SELECT TOP(10) FirstName,LastName,e.DepartmentId
FROM Employees as e
JOIN (SELECT DepartmentId,AVG(Salary) as Avarage
FROM Employees
GROUP BY DepartmentID) as ep ON e.DepartmentID = ep.DepartmentID
WHERE Salary > ep.Avarage
ORDER BY DepartmentID



