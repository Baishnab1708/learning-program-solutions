USE EmployeeDB;
GO

CREATE TABLE Departments (
    DepartmentID   INT           PRIMARY KEY,
    DepartmentName VARCHAR(100)  NOT NULL
);

CREATE TABLE Employees (
    EmployeeID    INT           IDENTITY(1,1) PRIMARY KEY,
    FirstName     VARCHAR(50)   NOT NULL,
    LastName      VARCHAR(50)   NOT NULL,
    DepartmentID  INT           NOT NULL
                   FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary        DECIMAL(10,2) NOT NULL,
    JoinDate      DATE          NOT NULL
);
GO
