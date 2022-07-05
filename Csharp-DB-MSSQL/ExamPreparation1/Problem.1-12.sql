

CREATE TABLE Clients(
ClientId INT Primary Key IDENTITY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Phone CHAR(12) CHECK(LEN(PHONE) = 12) NOT NULL)

CREATE TABLE Mechanics(
MechanicId INT Primary Key IDENTITY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
[Address] VARCHAR(255) NOT NULL) 

CREATE TABLE Models(
ModelId INT Primary Key IDENTITY,
[Name] VARCHAR(50) UNIQUE NOT NULL )

CREATE TABLE Jobs(
JobId INT Primary Key IDENTITY,
ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
[Status] VARCHAR(11) DEFAULT 'Pending'
CHECK ([Status] IN ('Pending','In Progress','Finished')) NOT NULL,
ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
IssueDate DATE NOT NULL,
FinishDate DATE
)

CREATE TABLE Orders(
OrderId INT Primary Key IDENTITY,
JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
IssueDate DATE,
Delivered BIT DEFAULT 0 NOT NULL)

CREATE TABLE Vendors(
VendorId INT Primary Key IDENTITY,
[Name] VARCHAR(50) UNIQUE NOT NULL)

CREATE TABLE Parts(
PartId INT Primary Key IDENTITY,
SerialNumber VARCHAR(50) UNIQUE NOT NULL,
[Description] VARCHAR(255),
Price Decimal(15,2) CHECK (Price >0 AND Price <= 9999.99) NOT NULL,
VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
StockQty INT DEFAULT 0 CHECK (StockQty >= 0) NOT NULL)

CREATE TABLE OrderParts(
OrderId INT FOREIGN KEY REFERENCES Orders(OrderId) NOT NULL,
PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
Quantity INT  DEFAULT 1 CHECK (Quantity > 0) NOT NULL,
CONSTRAINT PK_OrdersParts PRIMARY KEY (OrderId,PartId))

CREATE TABLE PartsNeeded(
JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
Quantity INT DEFAULT 1 CHECK (Quantity > 0) NOT NULL,
CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId,PartId))

--2

--First Name	Last Name	Phone
--Teri	Ennaco	570-889-5187
--Merlyn	Lawler	201-588-7810
--Georgene	Montezuma	925-615-5185
--Jettie	Mconnell	908-802-3564
--Lemuel	Latzke	631-748-6479
--Melodie	Knipp	805-690-1682
--Candida	Corbley	908-275-8357

INSERT INTO Clients(FirstName,LastName,Phone)
	VALUES
	('Teri','Ennaco','570-889-5187'),
	('Merlyn','Lawler','201-588-7810'),
	('Georgene','Montezuma','925-615-5185'),
	('Jettie','Mconnell','908-802-3564'),
	('Lemuel','Latzke','631-748-6479'),
	('Melodie','Knipp'	,'805-690-1682'),
	('Candida','Corbley','908-275-8357')

--Serial Number	Description	Price	VendorId
--WP8182119	Door Boot Seal	117.86	2
--W10780048	Suspension Rod	42.81	1
--W10841140	Silicone Adhesive 	6.77	4
--WPY055980	High Temperature Adhesive	13.94	3
--

INSERT INTO Parts(SerialNumber,Description,Price,VendorId)
	VALUES
	('WP8182119',	'Door Boot Seal',			'117.86','2'),
	('W10780048',	'Suspension Rod',			'42.81'	,'1'),
	('W10841140',	'Silicone Adhesive', 		'6.77'	,'4'),
	('WPY055980',	'High Temperature Adhesive','13.94'	,'3')

--3
UPDATE JOBS
SET MechanicId = 3
WHERE Status = 'Pending'
UPDATE JOBS
SET Status = 'In Progress'
WHERE Status = 'Pending'

--4

DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

--5

 
--Select all mechanics with their jobs.
--Include job status and issue date. 
--Order by mechanic Id, issue date, job Id (all ascending).
--Required columns: Mechanic Full Name --	Job Status	--Job Issue Date

SELECT CONCAT(m.FirstName,' ',m.LastName) as Mechanic, j.Status,j.IssueDate
FROM JOBS as j
JOIN Mechanics as m ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId,j.IssueDate,j.JobId

--6
--Select the names of all clients with active jobs (not Finished).
--Include the status of the job and how many days it’s been since it was submitted. Assume the current date is 24 April 2017.
--Order results by time length (descending) and by client ID (ascending).
--Required columns: --Client Full Name --Days going – how many days have passed since the issuing --Status
	
	
SELECT CONCAT(c.FirstName,' ',c.LastName) as Client,  DATEDIFF(dd,j.IssueDate,'2017-04-24') as [Days Going],  Status
FROM JOBS as j
JOIN CLIENTS as c ON c.ClientId = j.ClientId 
WHERE j.Status != 'Finished'
ORDER BY [Days Going] DESC,c.ClientId

--7
--Select all mechanics and the average time they take to finish their assigned jobs.
--Calculate the average as an integer.
--Order results by mechanic ID (ascending).
--	Mechanic Full Name -- Average Days – average number of days the machanic took to finish the job
SELECT  sq1.Mechanic,sq1.[Average days]
FROM(
SELECT CONCAT(m.FirstName,' ',m.LastName) as Mechanic, AVG(DATEDIFF(dd,j.IssueDate,j.FinishDate)) as [Average days],m.MechanicId
FROM JOBS as j
JOIN Mechanics as m ON j.MechanicId = m.MechanicId
GROUP BY CONCAT(m.FirstName,' ',m.LastName), m.MechanicId) as sq1
ORDER BY sq1.MechanicId

--8
--Select all mechanics without active jobs (include mechanics which don’t have any job assigned or all of their jobs are finished). Order by ID (ascending).
--Required columns:
--	Mechanic Full Name

SELECT CONCAT(m.FirstName,' ',m.LastName) AS Avaliable
FROM MECHANICS as m
WHERE m.MechanicId NOT IN (SELECT MechanicID FROM Jobs WHERE Status != 'Finished' AND MechanicId IS NOT NULL) 
ORDER BY m.MechanicId

--9
-- Select all finished jobs and the total cost of all parts that were ordered for them. 
--Sort by total cost of parts ordered (descending) and by job ID (ascending).

SELECT j.JobId, ISNULL(Sum(p.Price * op.Quantity),0.00) as Total
FROM JOBS as j
LEFT JOIN Orders as o  ON j.JobId = o.JobId
LEFT JOIN OrderParts as op ON o.OrderId = op.OrderId
LEFT JOIN Parts as p ON p.PartId = op.PartId
WHERE STATUS = 'Finished'
GROUP BY j.JobId
ORDER BY Sum(p.Price * op.Quantity) DESC, j.JobId 

--10

-- List all parts that are needed for active jobs (not Finished) without sufficient quantity in stock and in pending orders (the sum of parts in stock and parts ordered is less than the required quantity). 
--Order them by part ID (ascending).
--Required columns:
	--Part ID
	--Description
	--Required – number of parts required for active jobs
	--In Stock – how many of the part are currently in stock
	--Ordered – how many of the parts are expected to be delivered (associated with order that is not Delivered)


SELECT p.PartId,p.Description,Sum(pn.Quantity) as Required,SUM(p.StockQty) as [In Stock],ISNULL(Sum(op.Quantity),0) as Ordered
FROM Jobs as j
LEFT JOIN PartsNeeded as pn ON j.JobId = pn.JobId
LEFT JOIN Parts as p ON p.PartId = pn.PartId
LEFT JOIN Orders as o ON j.JobId = o.JobId
LEFT JOIN OrderParts as op ON op.OrderId = o.OrderId
WHERE j.Status != 'Finished' AND (Delivered = 0 OR DELIVERED IS NULL)
GROUP BY p.PartId,p.Description
HAVING Sum(pn.Quantity) > SUM(p.StockQty) + ISNULL(Sum(op.Quantity),0)

--11
--⦁	JobId
--	Part Serial Number
--⦁	Quantity

GO
CREATE PROC usp_PlaceOrder @JobId INT,@PartSN VARCHAR(50),@Quantity INT
AS
BEGIN TRANSACTION

DECLARE @status VARCHAR(12) = (SELECT Status
FROM JOBS
WHERE @JobId = JobId)

IF @Quantity<=0
BEGIN
;Throw 50012,'Part quantity must be more than zero!
',1
ROLLBACK
RETURN
END

IF @status = 'Finished'
BEGIN
;Throw 50011,'This job is not active!',1
ROLLBACK
RETURN
END





IF @status IS NULL
BEGIN
;Throw 50013,'Job not found!',1
ROLLBACK
RETURN
END

DECLARE @part INT = (SELECT PartId FROM PARTS WHERE SerialNumber = @PartSN)

IF @part IS NULL
BEGIN
;Throw 50014,'Part not found!',1
ROLLBACK
RETURN
END

DECLARE @orderExists INT = ISNULL((SELECT OrderId
FROM ORders
WHERE @JOBID = Orders.JobId AND IssueDate IS NULL),0)

IF @orderExists != 0
BEGIN

DECLARE @ITEMEXISTS INT = ISNULL((SELECT PartId
FROM OrderParts
WHERE OrderId = @orderExists AND PartId = (SELECT PartID FROM Parts WHERE Parts.SerialNumber = @PartSN)),0)

	IF @ITEMEXISTS != 0
	BEGIN

	UPDATE OrderParts
	SET Quantity+=@Quantity
	WHERE PartId = @ITEMEXISTS AND OrderId = @orderExists

	END

	ELSE 
	BEGIN
	DECLARE @PartId INT = (SELECT PartID FROM Parts WHERE Parts.SerialNumber = @PartSN)
	INSERT INTO OrderParts
		VALUES
		(@orderExists,@PartId,@Quantity)
	END
END

ELSE 
BEGIN
INSERT INTO Orders(JobId)
	VALUES
		(@JobId)
DECLARE @orderToInsert INT = (SELECT MAX(OrderID) FROM Orders)
DECLARE @PartToInsert INT = (SELECT PartID FROM Parts WHERE SerialNumber = @PartSN)

INSERT INTO OrderParts
	VALUES (@orderToInsert,@PartToInsert,@Quantity)
END
COMMIT





--12

--Create a user defined function (udf_GetCost) that receives a job’s ID and returns the total cost of all parts that were ordered for it. Return 0 if there are no orders.
GO
CREATE FUNCTION udf_GetCost (@JobId INT)
RETURNS DECIMAL (18,2)
AS
BEGIN

DECLARE @toBeReturned DECIMAL(18,2) = (SELECT ISNULL(Sum(p.Price * op.Quantity),0.00)
FROM JOBS as j
LEFT JOIN Orders as o  ON j.JobId = o.JobId
LEFT JOIN OrderParts as op ON o.OrderId = op.OrderId
LEFT JOIN Parts as p ON p.PartId = op.PartId
WHERE j.JobId = @JobId)

RETURN @toBeReturned
END











