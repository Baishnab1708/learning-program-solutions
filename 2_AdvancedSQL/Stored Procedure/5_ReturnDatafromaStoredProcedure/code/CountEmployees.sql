USE EmployeeDB;
GO

CREATE OR ALTER PROCEDURE sp_CountEmployeesByDepartment
    @DepartmentID INT,
    @TotalEmployees INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT @TotalEmployees = COUNT(*)
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO
