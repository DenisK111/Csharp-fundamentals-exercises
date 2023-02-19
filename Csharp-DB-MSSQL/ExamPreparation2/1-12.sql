USE MASTER

GO
DROP DATABASE ZOO

GO

CREATE DATABASE ZOO

GO

USE ZOO

GO

CREATE TABLE OWNERS(
Id INT CHECK(Id >=0) Primary Key Identity,
Name Varchar(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
Address VARCHAR(50) NULL)

CREATE TABLE AnimalTypes(
Id INT CHECK(Id >=0) Primary Key Identity,
AnimalType Varchar(30) NOT NULL)

CREATE TABLE CAGES(
Id INT CHECK(Id >=0) Primary Key Identity,
AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(ID) NOT NULL)

CREATE TABLE Animals(
Id INT CHECK(Id >=0) Primary Key Identity,
Name VarChar(30) NOT NULL,
BirthDate Date NOT NULL,
OwnerId INT FOREIGN KEY REFERENCES Owners(Id) Null,
AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL)

CREATE TABLE AnimalsCages(
CageId INT FOREIGN KEY REFERENCES Cages(Id) NOT NULL,
AnimalId INT FOREIGN KEY REFERENCES Animals(Id) NOT NULL,
CONSTRAINT Pk_AnimalsCages Primary Key (CageId,AnimalId))

Create TABLE VolunteersDepartments(
Id INT CHECK(Id >=0) Primary Key Identity,
DepartmentName Varchar(30) NOT NULL)

CREATE TABLE VOLUNTEERS(
Id INT CHECK(Id >=0 ) Primary Key Identity,
NAME VARCHAR(50) NOT NULL,
PhoneNumber Varchar(15) NOT NULL,
Address Varchar(50) NULL,
AnimalId INT FOREIGN KEY REFERENCES Animals(Id) NULL,
DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL)

---------- 2 ----

INSERT INTO Volunteers (Name,PhoneNumber,Address,AnimalId,DepartmentId)
VALUES 
('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
('Dimitur Stoev','0877564223',null,42,4),
('Kalina Evtimova','0896321112','Silistra, 21 Breza str.',9,7),
('Stoyan Tomov','0898564100','Montana, 1 Bor str',18,8),
('Boryana Mileva','0888112233',null,31,5)


INSERT INTO Animals(Name,BirthDate,OwnerId,AnimalTypeId)
VALUES
('Giraffe',CAST('2018-09-21' AS DATE),21,1),
('Harpy Eagle',CAST('2015-04-7' AS DATE), 21, 1),
('Hamadryas Baboon',CAST('2017-11-02' AS DATE),null,1),
('Tuatara',CAST('2021-06-30' AS DATE),2,4)

------3----

SELECT * FROM OWNERS WHERE NAME = 'Kaloqn Stoqnov'

SELECT * FROM ANIMALS

UPDATE ANIMALS
SET OwnerId = 4
WHERE OwnerId IS NULL

----4----

SELECT * FROM VolunteersDepartments

DELETE FROM VOLUNTEERS WHERE DepartmentId = 2
DELETE FROM VolunteersDepartments WHERE Id = 2

--5---


SELECT Name,PhoneNumber,Address,AnimalId,DepartmentId FROM VOLUNTEERS
Order By Name, AnimalId, DepartmentId

---6----

SELECT a.Name,ats.AnimalType,FORMAT(a.BirthDate,'dd.MM.yyyy') as BirthDate FROM ANIMALS a
Join AnimalTypes ats ON a.AnimalTypeId = ats.Id
ORDER BY a.Name

---7----

SELECT TOP 5 o.Name, Count(o.Name) as CountOfAnimals FROM ANIMALS a
JOIN OWNERS o on a.OwnerId = o.Id
GROUP BY o.Name
Order BY CountOfAnimals DESC, o.Name

---8---

SELECT CONCAT(o.Name,'-', a.Name) as OwnersAnimals, o.PhoneNumber, ac.CageId FROM Animals a
JOIN Owners o ON a.OwnerId = o.Id
JOIN AnimalsCages ac on ac.AnimalId = a.Id
WHERE a.AnimalTypeId =1
ORDER BY o.Name, a.Name DESC

---9----

SELECT v.NAME,v.PhoneNumber, TRIM(SubString(Replace(TRIM(v.Address),',',''),7,20000)) as Address FROM VOLUNTEERS v
WHERE SUBSTRING(Trim(v.Address),1,5) = 'Sofia' AND v.DepartmentId=2
ORDER BY v.NAME

---10---

SELECT a.Name, Year(a.BirthDate) as BirthYear, ats.AnimalType FROM Animals a
JOIN AnimalTypes ats on a.AnimalTypeId = ats.Id
WHERE OwnerId is NULL AND AnimalTypeId NOT IN(3) AND DATEDIFF(year,a.BirthDate,CAST('01/01/2022' AS DATE)) < 5
ORDER BY a.Name

---11---

CREATE FUNCTION udv_getCount2 (@DName Varchar(Max))
RETURNS INT
AS
BEGIN

DECLARE @toBeReturned INT = (SELECT TOP 1 Count(vd.DepartmentName) FROM Volunteers v 
JOIN VolunteersDepartments vd on v.DepartmentId = vd.Id
WHERE vd.DepartmentName = @DName
GROUP BY vd.DepartmentName)

RETURN @toBeReturned;
END

SELECT dbo.udv_getCount2('Guest engagement')


----12----

GO

CREATE PROC usp_GetOwner @Name VARCHAR(MAX)
AS
BEGIN

SELECT TOP 1 a.Name, COALESCE(o.Name,'For adoption') as OwnersName FROM Animals a
LEFT JOIN OWNERS o on a.OwnerId = o.Id
WHERE a.Name = @Name

END

EXEC usp_GetOwner 'Brown bear'