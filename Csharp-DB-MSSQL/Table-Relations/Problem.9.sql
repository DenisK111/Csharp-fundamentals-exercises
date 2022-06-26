USE Geography

SELECT m.MountainRange,p.PeakName,p.Elevation 
FROM Peaks as p
JOIN Mountains m on m.Id = p.MountainId
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC