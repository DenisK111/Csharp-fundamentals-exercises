USE Bank

--1
CREATE TABLE Logs(
LogId INT PRIMARY KEY Identity(1,1),
AccountID INT NOT NULL,
OldSum MONEY NOT NULL,
NewSum MONEY NOT NULL)
GO

CREATE Trigger tr_LogTransactions ON Accounts
FOR UPDATE
AS

INSERT INTO Logs(AccountId,OldSum,NewSum)
	SELECT i.Id,d.Balance,i.Balance
	FROM inserted as i
	JOIN deleted as d ON i.Id = d.Id
	WHERE d.Balance != i.Balance

--2
--Create another table – NotificationEmails(Id, Recipient, Subject, Body). Add a trigger to logs table and create new email whenever new record is inserted in logs table. The following data is required to be filled for each email:
--Recipient – AccountId
--Subject – "Balance change for account: {AccountId}"
--Body - "On {date} your balance was changed from {old} to {new}."
--Submit your query only for the trigger action.

CREATE TABLE NotificationEmails(
Id INT PRIMARY KEY IDENTITY (1,1),
Recepient INT NOT NULL,
[Subject] VARCHAR(100) NOT NULL,
[Body] VARCHAR(200) NOT NULL)
GO
CREATE TRIGGER tr_NotificationEmails ON Logs
FOR INSERT 
AS
INSERT INTO NotificationEmails 
SELECT l.AccountID, CONCAT('Balance change for account: ', l.AccountID) AS [Subject],CONCAT('On ',GetDate(),' your balance was changed from ',l.OldSum,' to ',l.NewSum,'.') AS Body
FROM Logs as l

--3
--Add stored procedure usp_DepositMoney (AccountId, MoneyAmount) that deposits money to an existing account. Make sure to guarantee valid positive MoneyAmount with precision up to the fourth sign after the decimal point. The procedure should produce exact results working with the specified precision.
GO
CREATE OR ALTER PROC usp_DepositMoney @accountId INT,@moneyAmount DECIMAL (18,4)
AS

BEGIN TRANSACTION

DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)

IF @account IS NULL
BEGIN
	RAISERROR('Invalid Account ID',16,1)
	ROLLBACK
	RETURN
END
ELSE IF @moneyAmount < 0 
	BEGIN
	RAISERROR('Invalid Money Ammount',16,1)
	ROLLBACK
	RETURN
	END


BEGIN TRY
	 
	UPDATE Accounts
	SET Balance += @moneyAmount
	WHERE Id = @accountId
END TRY
BEGIN CATCH
THROW
ROLLBACK
RETURN
END CATCH

COMMIT TRANSACTION


EXEC usp_DepositMoney 0,3
SELECT * FROM Accounts

--4


GO
CREATE OR ALTER PROC usp_WithdrawMoney @accountId INT,@moneyAmount DECIMAL (18,4)
AS

BEGIN TRANSACTION

DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)

IF @account IS NULL
BEGIN
	RAISERROR('Invalid Account ID',16,1)
	ROLLBACK
	RETURN
END
ELSE IF @moneyAmount < 0 
	BEGIN
	RAISERROR('Invalid Money Ammount',16,1)
	ROLLBACK
	RETURN
	END


BEGIN TRY
	 
	UPDATE Accounts
	SET Balance -= @moneyAmount
	WHERE Id = @accountId
	IF (Select Balance FROM Accounts WHERE Id = @accountId) < 0
	BEGIN
	RAISERROR('Not enough funds in account',16,2)
	ROLLBACK
	RETURN
	END
END TRY
BEGIN CATCH
THROW
ROLLBACK
RETURN
END CATCH

COMMIT TRANSACTION

--5 
GO
CREATE PROC usp_TransferMoney @senderID INT,@receiverID int, @ammount DECIMAL(18,4)
AS
BEGIN TRANSACTION
BEGIN TRY
EXEC usp_WithdrawMoney @senderID,@ammount
EXEC usp_DepositMoney @receiverID,@ammount
END TRY
BEGIN CATCH
ROLLBACK
RETURN
END CATCH
COMMIT TRANSACTION

EXEC usp_TransferMoney 5,1,5000

SELECT * FROM Accounts WHERE ID IN (1,5)
	
--6 
GO
USE Diablo
GO
--Users should not be allowed to buy items with a higher level than their level. Create a trigger that restricts that. The trigger should prevent inserting items that are above the specified level while allowing all others to be inserted.
--Add bonus cash of 50000 to users: baleremuda, loosenoise, inguinalself, buildingdeltoid, monoxidecos in the game "Bali".
--There are two groups of items that you must buy for the above users. The first are items with id between 251 and 299 including. The second group are items with id between 501 and 539 including.
--Take cash from each user for the bought items.
--Select all users in the current game ("Bali") with their items. Display username, game name, cash and item name. Sort the result by username alphabetically, then by item name alphabetically. 
GO

--1.
CREATE TRIGGER tr_CheckItemLevel ON UserGameItems
INSTEAD OF INSERT
AS

DECLARE @itemID INT = (SELECT TOP(1) inserted.ItemId FROM  inserted)
DECLARE @userGameId INT = (SELECT TOP(1) inserted.UserGameId FROM  inserted)
DECLARE @minLevelOfItem INT = (SELECT MinLevel FROM items AS i JOIN inserted as id ON i.Id = id.ItemId)
DECLARE @level INT = (SELECT level FROM UsersGames AS g JOIN inserted as id ON g.Id = id.UserGameId)

IF @minLevelOfItem <= @level
BEGIN
INSERT INTO UserGameItems (ItemId,UserGameId)
	Values(@itemID,@userGameId)
END
ELSE RAISERROR('Level too low to buy this item!',16,3)


--SELECT * FROM 
--UserGameItems

GO

--SELECT * FROM Items

--SELECT * FROM UsersGames

--INSERT INTO UserGameItems (ItemId,UserGameId)
	--VALUES (3,30)

--2.
BEGIN TRANSACTION 

DECLARE @gameName NVARCHAR(50) = 'Bali'
UPDATE UsersGames 
SET Cash += 50000
FROM  UsersGames as ug
		JOIN Users as u ON ug.UserId = u.Id
		JOIN Games as g ON ug.GameId = g.Id
		WHERE g.Name = @gameName AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
COMMIT TRANSACTION
GO



--SELECT * 
--FROM UsersGames as ug
--		JOIN Users as u ON ug.UserId = u.Id
--		JOIN Games as g ON ug.GameId = g.Id
--		WHERE g.Name = 'Bali' AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')

--3.

CREATE PROC usp_BuyItem @inputUserId INT,@inputItemID INT,@inputGameId INT
AS
BEGIN TRANSACTION
	DECLARE @UserId INT = (SELECT DISTINCT ug.UserId FROM UsersGames AS ug WHERE ug.UserId = @inputUserId)
	DECLARE @itemId INT = (SELECT i.Id FROM Items AS i WHERE i.Id = @inputItemID)

IF (@UserId IS NULL OR @itemId IS NULL)
	BEGIN
		ROLLBACK
		RETURN
END
	DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE @UserId = UsersGames.UserId AND GameId = @inputGameId) 
	DECLARE @price DECIMAL(18,4) = (SELECT Price FROM Items WHERE @itemId = Items.Id) 
	DECLARE @funds DECIMAL(18,4) = (SELECT Cash FROM UsersGames WHERE @UserId = UsersGames.UserId AND GameId = @inputGameId)
IF (@funds - @price < 0)
	BEGIN
	ROLLBACK
	RETURN
END
BEGIN TRY
	INSERT INTO UserGameItems(ItemId,UserGameId)
	VALUES (@itemId,@UserGameId)
END TRY
BEGIN CATCH
	ROLLBACK
	RAISERROR('Cannot continue',16,1)
	RETURN
END CATCH
UPDATE UsersGames
	SET CASH -= @price
	WHERE UsersGames.Id = @UserGameId
COMMIT

SELECT * FROM 
UsersGames

SELECT * FROM UserGameItems

SELECT * FROM Items

EXEC usp_BuyItem -1,2,138

-----------------SP END, buy being
GO
CREATE OR ALTER PROC usp_BuyItemsInBulk @start INT, @end INT, @gameId INT
AS
	DECLARE @tempT TABLE(Id INT,UserId INT, RowNumber INT)

INSERT INTO @tempT
SELECT ug.Id,u.Id,ROW_NUMBER() OVER (ORDER BY UserName) as rn
	FROM UsersGames as ug
	JOIN Users as u ON ug.UserId = u.Id
	WHERE u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
		AND ug.GameId = @gameId

	DECLARE @COUNT INT = (SELECT COUNT(*) 
								FROM @tempT)
	DECLARE @i INT = 1
	
WHILE (@i<=@COUNT)
	BEGIN
	DECLARE @user VARCHAR(100) = (SELECT UserId
										FROM @tempT
										WHERE RowNumber = @i)
	DECLARE @startItem INT = @start
	DECLARE @endItem INT = @end
	WHILE (@startItem <= @endItem)
		BEGIN
		EXEC usp_BuyItem @user,@startItem, @gameId
		SET @startItem +=1

	END
	SET @i+=1
END

----- END BULKBUY, EXECUTE

EXEC usp_BuyItemsInBulk 251,299,212
EXEC usp_BuyItemsInBulk 501,539,212


SELECT * FROM UserGameItems


SELECT u.Username,g.[Name],ug.Cash,i.[Name] AS [Item Name]
FROM UsersGames as ug
JOIN Users as u ON ug.UserId = u.Id
JOIN Games as g ON ug.GameId = g.Id
JOIN UserGameItems as ugi ON ugi.UserGameId = ug.Id
JOIN Items as i ON i.Id = ugi.ItemId
WHERE g.Name = 'Bali'
ORDER BY u.Username,i.Name

--7


SELECT * FROM
UsersGames 
WHERE UserId = (SELECT ID FROM Users WHERE USERS.FirstName = 'Stamat')
 AND GameID = (SELECT ID FROM Games WHERE Games.Name = 'Safflower')
 GO
 
 CREATE OR ALTER PROC usp_ExecBulkLevelBuy 
 AS
 BEGIN
	set nocount on
    declare @trancount int;
    set @trancount = @@trancount;
	 declare  @xstate int;

 BEGIN TRY


 if @trancount = 0
            begin transaction tr2
        else
            save transaction usp_ExecBulkLevelBuy;

 EXEC usp_BuyInBulkPerLevel 11,87
 EXEC usp_BuyInBulkPerLevel 12,87
 COMMIT TRANSACTION tr2
 END TRY
 BEGIN CATCH 
         SELECT @xstate = XACT_STATE();
        if @xstate = -1
            rollback;
        if @xstate = 1 and @trancount = 0
            rollback
        if @xstate = 1 and @trancount > 0
            rollback transaction tr2;
END CATCH

 BEGIN TRY
 if @trancount = 0
            begin transaction tr3
        else
            save transaction usp_ExecBulkLevelBuy;
 
 EXEC usp_BuyInBulkPerLevel 19,87
 EXEC usp_BuyInBulkPerLevel 20,87
 EXEC usp_BuyInBulkPerLevel 21,87
 COMMIT TRANSACTION tr3
 END TRY
 BEGIN CATCH

        SELECT @xstate = XACT_STATE();
        if @xstate = -1
            rollback
        if @xstate = 1 and @trancount = 0
            rollback
        if @xstate = 1 and @trancount > 0
            rollback transaction tr3
 END CATCH
 END

 GO
 EXEC usp_ExecBulkLevelBuy 

 SELECT i.Name FROM 
 UserGameItems as ugi
 JOIN Items  AS i ON i.Id = ugi.ItemId 
 WHERE UserGameId = (SELECT ID FROM UsersGames WHERE GameId = 87 AND UserId = (SELECT ID FROM USERS WHERE USERS.FirstName = 'Stamat'))
 ORDER BY i.Name

 DROP DATABASE Diablo
 

 GO

---
CREATE OR ALTER PROC usp_BuyInBulkPerLevel @level INT, @gameId INT
AS
BEGIN TRANSACTION 
	DECLARE @tempT TABLE(Id INT,UserId INT, RowNumber INT)

INSERT INTO @tempT
SELECT ug.Id,u.Id,ROW_NUMBER() OVER (ORDER BY UserName) as rn
	FROM UsersGames as ug
	JOIN Users as u ON ug.UserId = u.Id
	WHERE u.Username IN ('Stamat')
		AND ug.GameId = @gameId

	DECLARE @COUNT INT = (SELECT COUNT(*) 
								FROM @tempT)
	DECLARE @i INT = 1

DECLARE @temptperlevels TABLE (itemId INT,RowNumber INT)

   INSERT INTO @temptperlevels
   SELECT Id,ROW_NUMBER() OVER (ORDER BY ID)
	FROM ITEMS
	WHERE MinLevel = @level
	DECLARE @endItem INT = (SELECT (Max(RowNumber)) FROM @temptperlevels)
	
WHILE (@i<=@COUNT)
	BEGIN
	DECLARE @user VARCHAR(100) = (SELECT UserId
										FROM @tempT
										WHERE RowNumber = @i)
	DECLARE @StartItem INT = 1
	
	WHILE (@startItem <= @endItem)
		BEGIN
		DECLARE @itemID INT = (SELECT itemId FROM @temptperlevels WHERE @StartItem = RowNumber)
		BEGIN TRY
		EXEC usp_BuyItemPerLevel @user,@itemId, @gameId
		END TRY
		BEGIN CATCH
		ROLLBACK
		RAISERROR('Cannot Continue',16,1)
		RETURN
		END CATCH
		SET @startItem +=1

	END
	SET @i+=1
END
COMMIT
GO
CREATE OR ALTER PROC usp_BuyItemPerLevel @inputUserId INT,@inputItemID INT,@inputGameId INT
AS
BEGIN TRANSACTION
	DECLARE @UserId INT = (SELECT DISTINCT ug.UserId FROM UsersGames AS ug WHERE ug.UserId = @inputUserId)
	DECLARE @itemId INT = (SELECT i.Id FROM Items AS i WHERE i.Id = @inputItemID)

IF (@UserId IS NULL OR @itemId IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Cannot continue',16,1)
		RETURN
END
	DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE @UserId = UsersGames.UserId AND GameId = @inputGameId) 
	DECLARE @price DECIMAL(18,4) = (SELECT Price FROM Items WHERE @itemId = Items.Id) 
	DECLARE @funds DECIMAL(18,4) = (SELECT Cash FROM UsersGames WHERE @UserId = UsersGames.UserId AND GameId = @inputGameId)
IF (@funds - @price < 0)
	BEGIN
	ROLLBACK
	RAISERROR('Cannot continue',16,1)
	RETURN
END
BEGIN TRY
	INSERT INTO UserGameItems(ItemId,UserGameId)
	VALUES (@itemId,@UserGameId)
END TRY
BEGIN CATCH
	ROLLBACK
	RAISERROR('Cannot continue',16,1)
	RETURN
END CATCH
UPDATE UsersGames
	SET CASH -= @price
	WHERE UsersGames.Id = @UserGameId

COMMIT



--8
USE SoftUni

--Create a procedure usp_AssignProject(@emloyeeId, @projectID) that assigns projects to an employee. If the employee has more than 3 project throw exception and rollback the changes. The exception message must be: "The employee has too many projects!" with Severity = 16, State = 1.
GO
CREATE OR ALTER PROC usp_AssignProject @employeeId INT, @projectID INT 
AS
BEGIN TRANSACTION
INSERT INTO EmployeesProjects(EmployeeID,ProjectID)
	VALUES (@employeeId,@projectID)
DECLARE @count INT = (SELECT COUNT(*) FROM
											(SELECT EmployeeID
											FROM EmployeesProjects
											WHERE EmployeeID = @employeeId) as s)
IF (@count > 3)
	BEGIN
	ROLLBACK
	RAISERROR('The employee has too many projects!',16,1)
	RETURN
END
COMMIT

SELECT * FROM EMPloyeesProjects
EXEC usp_AssignProject 267,4

--9 
--Create a table Deleted_Employees(EmployeeId PK, FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary) that will hold information about fired (deleted) employees from the Employees table. Add a trigger to Employees table that inserts the corresponding information about the deleted records in Deleted_Employees.

	CREATE TABLE Deleted_Employees(
	EmployeeID INT PRIMARY KEY IDENTITY(1,1)
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	MiddleName VARCHAR(50),
	JobTitle VARCHAR(50),
	DepartmentId INT,
	Salary Money)
	
	GO
	CREATE TRIGGER tr_AddDeletedEmployees ON Employees
	FOR DELETE
	AS

	INSERT INTO Deleted_Employees(FirstName,LastName,MiddleName,JobTitle,DepartmentId,Salary)
		SELECT  d.FirstName,d.LastName,d.MiddleName,d.JobTitle,d.DepartmentId,d.Salary
		FROM deleted as d


-- 8v2
SELECT * FROM --110
UsersGames 
WHERE UserId = (SELECT ID FROM Users WHERE USERS.FirstName = 'Stamat') --- stamat - 9
 AND GameID = (SELECT ID FROM Games WHERE Games.Name = 'Safflower') -- gameID-87

SELECT MinLevel,Id
	FROM ITEMS 
	WHERE MinLevel IN(19,20,21,11,12)
	ORDER BY MinLevel



	
IF ((SELECT Cash FROM UsersGames WHERE ID = 110) 
	- (SELECT SUM(Price)
					FROM Items
					WHERE MinLevel IN (11,12))>=0)
					BEGIN
BEGIN TRANSACTION

INSERT INTO UserGameItems (ItemId,UserGameId)
	SELECT Id,110
	FROM Items
	WHERE MinLevel IN (11,12)

UPDATE UsersGames
SET CASH -= (SELECT SUM(Price)
					FROM Items
					WHERE MinLevel IN (11,12))
WHERE Id = 110

COMMIT 
END

IF ((SELECT Cash FROM UsersGames WHERE ID = 110) 
	- (SELECT SUM(Price)
					FROM Items
					WHERE MinLevel IN (19,20,21))>=0)
					BEGIN

BEGIN TRANSACTION
INSERT INTO UserGameItems (ItemId,UserGameId)
	SELECT Id,110
	FROM Items
	WHERE MinLevel IN (19,20,21)

UPDATE UsersGames
SET CASH -= (SELECT SUM(Price)
					FROM Items
					WHERE MinLevel IN (19,20,21))
WHERE Id = 110

COMMIT 
END

SELECT i.Name FROM 
 UserGameItems as ugi
 JOIN Items  AS i ON i.Id = ugi.ItemId 
 WHERE UserGameId = (SELECT ID FROM UsersGames WHERE GameId = 87 AND UserId = (SELECT ID FROM USERS WHERE USERS.FirstName = 'Stamat'))
 ORDER BY i.Name


