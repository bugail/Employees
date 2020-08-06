DROP DATABASE [CodeBase8]

CREATE DATABASE [CodeBase8];

CREATE TABLE [Title]
(
    [TitleId] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(10)
)

CREATE TABLE [Gender]
(
    [GenderId] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(10)
)

CREATE TABLE [Roles]
(
    [RoleId] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR (50)
)

CREATE TABLE [Employees]
(
    [EmployeesId] INT PRIMARY KEY IDENTITY,
    [TitleId] INT FOREIGN KEY (TitleId) REFERENCES [Title](TitleId),
    [Firstname] NVARCHAR (250) NOT NULL,
    [Lastname] NVARCHAR (250) NOT NULL,
    [GenderId] INT FOREIGN KEY (GenderId) REFERENCES [Gender](GenderId),
    [DateOfBirth] DATETIME NOT NULL,
    [Email] NVARCHAR (320),
    [RoleId] INT FOREIGN KEY (RoleId) REFERENCES [Roles](RoleId),
    [Salary] MONEY
)

INSERT INTO [Title] VALUES ('Dr')
INSERT INTO [Title] VALUES ('Rev')
INSERT INTO [Title] VALUES ('Mrs')
INSERT INTO [Title] VALUES ('Mr')
INSERT INTO [Title] VALUES ('Honorable')

INSERT INTO [Gender] VALUES ('M')
INSERT INTO [Gender] VALUES ('F')

INSERT INTO [Roles] VALUES ('Safety Technician III')
INSERT INTO [Roles] VALUES ('Health Coach IV')
INSERT INTO [Roles] VALUES ('Physical Therapy Assistant')
INSERT INTO [Roles] VALUES ('Financial Advisor')
INSERT INTO [Roles] VALUES ('Environmental Specialist')
INSERT INTO [Roles] VALUES ('Accountant II')
INSERT INTO [Roles] VALUES ('Senior Developer')
INSERT INTO [Roles] VALUES ('VP Quality Control')
INSERT INTO [Roles] VALUES ('Civil Engineer')

GO  
CREATE PROCEDURE AddEmployees   
    @Title NVARCHAR(10),
    @Firstname NVARCHAR(250),
    @Lastname NVARCHAR(250),
    @Gender NVARCHAR(10),
    @DateOfBirth DATETIME,
    @Email NVARCHAR(320),
    @Role NVARCHAR(50),
    @Salary MONEY
AS   

    SET NOCOUNT ON;

    INSERT INTO [Employees] ([TitleId], [Firstname], [Lastname], [GenderId], [DateOfBirth], [Email], [RoleId], [Salary]) 
    VALUES ((SELECT [TitleId] FROM [Title] WHERE [Name] = @Title), @Firstname, @Lastname, (SELECT [GenderId] FROM [Gender] WHERE [Name] = @Gender), @DateOfBirth, @Email, (SELECT [RoleId] FROM [Roles] WHERE [Name] = @Role), @Salary)
GO 

GO  
CREATE PROCEDURE GetEmployees
AS   
    SET NOCOUNT ON;

    SELECT 
        [title].[Name] AS 'Title',
        [emp].[Firstname],
        [emp].[Lastname],
        [gender].[Name] AS 'Gender',
        [emp].[DateOfBirth],
        [emp].[Email],
        [roles].[Name] AS 'Role',
        [emp].[Salary]
    FROM 
        [Employees] emp
    LEFT JOIN [Title] title ON [title].[TitleId] = [emp].[TitleId]
    LEFT JOIN [Gender] gender ON [Gender].[GenderId] = [emp].[GenderId]
    LEFT JOIN [Roles] roles ON [Roles].[RoleId] = [emp].[RoleId]
    
GO 