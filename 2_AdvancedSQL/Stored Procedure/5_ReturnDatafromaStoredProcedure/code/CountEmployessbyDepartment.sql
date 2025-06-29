USE EmployeeDB;
GO

DECLARE @Count INT;

-- Call the proc for DepartmentID = 3 (IT)
EXEC sp_CountEmployeesByDepartment
     @DepartmentID   = 3,
     @TotalEmployees = @Count OUTPUT;

-- Return the output value as a resultset
SELECT @Count AS TotalEmployees;
GO
