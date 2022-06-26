CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50) NOT NULL)

CREATE TABLE Exams(
ExamID INT PRIMARY KEY IDENTITY (101,1),
[Name] NVARCHAR(50) NOT NULL)

CREATE TABLE StudentsExams(
StudentID INT REFERENCES Students(StudentID),
ExamID INT REFERENCES Exams(ExamID),
PRIMARY KEY(StudentID,ExamID))

INSERT INTO STUDENTS
	VALUES 
	('Mila'),
	('Toni'),
	('Ron')

INSERT INTO Exams
	VALUES 
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

	SELECT StudentID,ExamID
		FROM STUDENTS,Exams

		INSERT INTO StudentsExams (StudentID, ExamID) 
SELECT STUDENTS.StudentID,Exams.ExamID
FROM STUDENTS,Exams




	
SELECT *
FROM StudentsExams



