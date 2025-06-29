USE EmployeeDB;
GO

-- Execute for DepartmentID = 3 (IT)
EXEC sp_GetEmployeesByDepartment @DepartmentID = 3;
GO
