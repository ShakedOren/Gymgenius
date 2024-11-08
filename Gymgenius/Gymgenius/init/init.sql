USE master;
GO

IF DB_ID(N'GymGenius') IS NOT NULL
BEGIN
    DROP DATABASE GymGenius;
END
GO

-- Create the GymGenius database
CREATE DATABASE GymGenius;
GO

USE GymGenius;
GO

-- If the GymGenius database exists
IF DB_ID(N'GymGenius') IS NOT NULL
BEGIN
    -- Truncate existing tables if they exist and then create them
    IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Exercises' AND schema_id = SCHEMA_ID('dbo'))
    BEGIN
        DROP TABLE Exercises;
    END

    CREATE TABLE dbo.Exercises (
        Name NVARCHAR(50) NOT NULL PRIMARY KEY,
        DateCreated DATETIME DEFAULT (GETDATE()) NOT NULL
    );

    IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Roles' AND schema_id = SCHEMA_ID('dbo'))
    BEGIN
        DROP TABLE Roles;
    END
    
    CREATE TABLE Roles (
        RoleId INT PRIMARY KEY IDENTITY,
        RoleName NVARCHAR(50) NOT NULL
    );

    INSERT INTO Roles (RoleName) VALUES ('Admin');
    INSERT INTO Roles (RoleName) VALUES ('Trainer');
    INSERT INTO Roles (RoleName) VALUES ('Trainee');
    
    IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Users' AND schema_id = SCHEMA_ID('dbo'))
    BEGIN
        DROP TABLE Users;
    END
    
    CREATE TABLE dbo.Users (
        Id INT IDENTITY NOT NULL,
        DateCreated DATETIME DEFAULT (GETDATE()) NOT NULL,
        UserName NVARCHAR(50) PRIMARY KEY NOT NULL,
        FirstName NVARCHAR(50) NOT NULL,
        LastName NVARCHAR(50) NOT NULL,
        Password NVARCHAR(255) NOT NULL,
        Age INT,
        Email VARCHAR(255),
        RoleId INT NOT NULL,
        FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
    );

    IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'TrainingPrograms' AND schema_id = SCHEMA_ID('dbo'))
    BEGIN
        DROP TABLE TrainingPrograms;
    END
    CREATE TABLE dbo.TrainingPrograms (
        Id INT IDENTITY NOT NULL,
        DateCreated DATETIME DEFAULT (GETDATE()) NOT NULL,
        Name NVARCHAR(50) PRIMARY KEY NOT NULL,
        Description NVARCHAR(MAX)
    );

    IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ExerciseToTrainingProgram' AND schema_id = SCHEMA_ID('dbo'))
    BEGIN
        DROP TABLE ExerciseToTrainingProgram;
    END
    CREATE TABLE dbo.ExerciseToTrainingProgram (
        Id INT IDENTITY PRIMARY KEY NOT NULL,
        DateCreated DATETIME DEFAULT (GETDATE()) NOT NULL,
        TrainingProgramName NVARCHAR(50) FOREIGN KEY REFERENCES TrainingPrograms(Name),
        ExerciseName NVARCHAR(50) FOREIGN KEY REFERENCES Exercises(Name)
    );

    IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'UserToTrainingProgram' AND schema_id = SCHEMA_ID('dbo'))
    BEGIN
        DROP TABLE UserToTrainingProgram;
    END
    CREATE TABLE dbo.UserToTrainingProgram (
        Id INT IDENTITY PRIMARY KEY NOT NULL,
        DateCreated DATETIME DEFAULT (GETDATE()) NOT NULL,
        TrainingProgramName NVARCHAR(50) NOT NULL,
        UserName NVARCHAR(50) NOT NULL,
        FOREIGN KEY (TrainingProgramName) REFERENCES dbo.TrainingPrograms(Name),
        FOREIGN KEY (UserName) REFERENCES dbo.Users(UserName)
    );

    IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'TrainingLogs' AND schema_id = SCHEMA_ID('dbo'))
    BEGIN
        DROP TABLE TrainingLogs;
    END
    CREATE TABLE dbo.TrainingLogs (
        Id INT IDENTITY PRIMARY KEY NOT NULL,
        DateCreated DATETIME DEFAULT (GETDATE()) NOT NULL,
        TrainingProgramName NVARCHAR(50) NOT NULL,
        UserName NVARCHAR(50) NOT NULL,
        FOREIGN KEY (TrainingProgramName) REFERENCES dbo.TrainingPrograms(Name),
        FOREIGN KEY (UserName) REFERENCES dbo.Users(UserName)
    );

    IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ExerciseLogs' AND schema_id = SCHEMA_ID('dbo'))
    BEGIN
        DROP TABLE ExerciseLogs;
    END
    CREATE TABLE dbo.ExerciseLogs (
        Id INT IDENTITY PRIMARY KEY NOT NULL,
        TrainingLogId INT NOT NULL,
        ExerciseName NVARCHAR(50) NOT NULL,
        Sets INT NOT NULL,
        Reps INT NOT NULL,
        FOREIGN KEY (TrainingLogId) REFERENCES dbo.TrainingLogs(Id),
        FOREIGN KEY (ExerciseName) REFERENCES dbo.Exercises(Name)
    );

END