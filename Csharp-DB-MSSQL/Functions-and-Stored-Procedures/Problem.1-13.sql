--1
USE SoftUni
CREATE Proc dbo.usp_GetEmployeesSalaryAbove35000 
AS

Select FirstName,LastName
FROM Employees
WHERE Salary > 35000

GO

EXEC usp_GetEmployeesSalaryAbove35000;

--2
--Create stored procedure usp_GetEmployeesSalaryAboveNumber that accept a number (of type DECIMAL(18,4)) as parameter and returns all employees’ first and last names whose salary is above or equal to the given number. 

CREATE PROC usp_GetEmployeesSalaryAboveNumber @salary DECIMAL(18,4)
AS
SELECT FirstName,LastName
FROM Employees
WHERE Salary >= @salary 

EXEC usp_GetEmployeesSalaryAboveNumber 5000;


--3
CREATE OR ALTER PROC usp_GetTownsStartingWith @startsWith VARCHAR(MAX)
AS
SELECT [Name]
FROM Towns
WHERE [NAME] LIKE @startsWith + '%'

EXEC usp_GetTownsStartingWith 'b'

--4
--Write a stored procedure usp_GetEmployeesFromTown that accepts town name as parameter and return the employees’ first and last name that live in the given town

CREATE PROC usp_GetEmployeesFromTown @townName VARCHAR(MAX)
AS
SELECT FirstName,LastName
FROM Employees as e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON t.TownID = a.TownID
WHERE t.Name = @townName

EXEC usp_GetEmployeesFromTown 'Sofia';

--5
--Write a function ufn_GetSalaryLevel(@salary DECIMAL(18,4)) that receives salary of an employee and returns the level of the salary.
--If salary is < 30000 return "Low"
--If salary is between 30000 and 50000 (inclusive) return "Average"
--If salary is > 50000 return "High"

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS 
BEGIN

IF @salary < 30000
	RETURN 'Low'
ELSE IF @salary <= 50000
	RETURN 'Average'
ELSE RETURN 'High'

RETURN NULL

END

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS Salary Level
FROM Employees

--6
--Write a stored procedure usp_EmployeesBySalaryLevel that receive as parameter level of salary (low, average or high) and print the names of all employees that have given level of salary. You should use the function - "dbo.ufn_GetSalaryLevel(@Salary) ", which was part of the previous task, inside your "CREATE PROCEDURE …" query.

CREATE PROC usp_EmployeesBySalaryLevel @salary AS VARCHAR(7)
AS

SELECT firstName,LastName
FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @salary

EXEC usp_EmployeesBySalaryLevel 'high';


--7
--Define a function ufn_IsWordComprised(@setOfLetters, @word) that returns true or false depending on that if the word is a comprised of the given set of letters. 

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(Max))
RETURNS BIT
AS
BEGIN
	
	DECLARE @ISCONTAINED BIT = 1
	DECLARE @i SMALLINT = 1
	WHILE Len(@word) >= @i
	BEGIN
		IF CHARINDEX(SUBSTRING(@word,@i,1),@setOfLetters,1) = 0
			BEGIN
			SET @ISCONTAINED = 0
			BREAK;
			END
		SET @i+=1
	END

	RETURN @ISCONTAINED;
	   	 
END

SELECT dbo.ufn_IsWordComprised('bobr','Rob')

--8
--* Delete Employees and Departments
--Write a procedure with the name usp_DeleteEmployeesFromDepartment (@departmentId INT) which deletes all Employees from a given department. Delete these departments from the Departments table too. Finally SELECT the number of employees from the given department. If the delete statements are correct the select query should return 0.
--After completing that exercise restore your database to revert all changes.
--Hint:
--You may set ManagerID column in Departments table to nullable (using query "ALTER TABLE …").


		
CREATE PROC usp_DeleteEmployeesFromDepartment @departmentId INT
	AS

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT 
		
	UPDATE Departments
	SET ManagerID = NULL 
	WHERE MANAGERID IN (Select EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
		
	DELETE FROM EmployeesProjects
	FROM EmployeesProjects as ep
	JOIN Employees as e1 ON ep.EmployeeID = e1.EmployeeID
	JOIN Departments as d ON d.DepartmentID = e1.DepartmentID
	WHERE d.DepartmentID = @departmentId
		
	UPDATE Employees
	SET ManagerID = Null
	WHERE ManagerID IN (Select EmployeeID FROM Employees WHERE DepartmentID = @departmentId) 
	
	DELETE FROM Employees
	WHERE DepartmentID = @departmentId
		
	DELETE FROM Departments
	WHERE DepartmentID = @departmentId
	
	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @departmentId

EXEC usp_DeleteEmployeesFromDepartment 1;


--9

CREATE PROC usp_GetHoldersFullName 
AS

SELECT FirstName + ' ' + LastName AS [Full Name]
FROM AccountHolders

EXEC usp_GetHoldersFullName

--10
--Your task is to create a stored procedure usp_GetHoldersWithBalanceHigherThan that accepts a number as a parameter and returns all people who have more money in total of all their accounts than the supplied number. Order them by first name, then by last name

CREATE PROC usp_GetHoldersWithBalanceHigherThan @balance DECIMAL (18,4)
AS
SELECT ac.FirstName,ac.LastName
FROM(
	SELECT AccountHolderId,SUM(Balance) as totalAmmount
	FROM Accounts
	GROUP BY AccountHolderId) as c
	JOIN AccountHolders as ac ON c.AccountHolderId = ac.Id
	WHERE @balance < c.totalAmmount
	Order By ac.FirstName,ac.LastName

EXEC usp_GetHoldersWithBalanceHigherThan 0

--11

--Your task is to create a function ufn_CalculateFutureValue that accepts as parameters – sum (decimal), yearly interest rate (float) and number of years(int). It should calculate and return the future value of the initial sum rounded to the fourth digit after the decimal delimiter. Using the following formula:

--I – Initial sum
--R – Yearly interest rate
--T – Number of years

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue(@sum DECIMAL (18,4), @rate DECIMAL(18,4), @period INT)
RETURNS DECIMAL(18,4)
AS
BEGIN

	WHILE @period > 0
	BEGIN
	SET @sum += @rate * @sum
	SET @period-=1
	END
	RETURN @sum

END

SELECT dbo.ufn_CalculateFutureValue(1000.98, 0.05, 3)

--12
--Your task is to create a stored procedure usp_CalculateFutureValueForAccount that uses the function from the previous problem to give an interest to a person's account for 5 years, along with information about his/her account id, first name, last name and current balance as it is shown in the example below. It should take the AccountId and the interest rate as parameters. Again you are provided with “dbo.ufn_CalculateFutureValue” function which was part of the previous task.

USE Bank

CREATE PROC usp_CalculateFutureValueForAccount @AccountID INT, @InterestRate DECIMAL(18,4)
AS

SELECT a.Id,ah.FirstName,ah.LastName,a.Balance, dbo.ufn_CalculateFutureValue(a.Balance,@InterestRate,5) AS [Balance in 5 years]
FROM Accounts as a
JOIN AccountHolders as ah ON a.AccountHolderId = ah.Id
WHERE a.Id = @AccountID

EXEC usp_CalculateFutureValueForAccount 1,0.1

--13

USE DIABLO

-- *Scalar Function: Cash in User Games Odd Rows
--Create a function ufn_CashInUsersGames that sums the cash of odd rows. Rows must be ordered by cash in descending order. The function should take a game name as a parameter and return the result as table. Submit only your function in.
--Execute the function over the following game names, ordered exactly like: "Love in a mist".


SELECT * FROM 
GAMES

CREATE FUNCTION ufn_CashInUsersGames (@name VARCHAR(50))
RETURNS TABLE 
AS
RETURN 
SELECT Sum(t.Cash) AS SumCash
FROM
(
SELECT ug.Cash ,ROW_Number () OVER (Partition By g.Name ORDER BY ug.Cash DESC) AS [ROW]
FROM GAMES AS g  
JOIN UsersGames AS ug ON  ug.GameId = g.Id 
WHERE g.Name = @name
) AS t
WHERE t.ROW % 2 <> 0

SELECT *
FROM dbo.ufn_CashInUsersGames('Love in a mist')




