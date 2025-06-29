USE EmployeeDB;
GO

CREATE OR ALTER PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        e.EmployeeID,
        e.FirstName,
        e.LastName,
        d.DepartmentName,
        e.Salary,
        e.JoinDate
    FROM Employees AS e
    JOIN Departments AS d
      ON e.DepartmentID = d.DepartmentID
    WHERE e.DepartmentID = @DepartmentID
    ORDER BY e.LastName, e.FirstName;
END;
GO
