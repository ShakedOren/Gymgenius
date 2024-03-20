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
    IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Exercise' AND schema_id = SCHEMA_ID('dbo'))
    BEGIN
        CREATE TABLE dbo.Exercise (
          Name NVARCHAR(50) NOT NULL PRIMARY KEY,
          DateCreated DATETIME DEFAULT (GETDATE()) NOT NULL
        );
    END
    ELSE
    BEGIN
        TRUNCATE TABLE dbo.Exercise;
    END

    IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Users' AND schema_id = SCHEMA_ID('dbo'))
    BEGIN
        CREATE TABLE dbo.Users (
          Id INT PRIMARY KEY NOT NULL,
          DateCreated DATETIME DEFAULT (GETDATE()) NOT NULL,
          FirstName VARCHAR(50) NOT NULL,
          LastName VARCHAR(50) NOT NULL,
          Age INT,
          Email VARCHAR(255)
        );
    END
    ELSE
    BEGIN
        TRUNCATE TABLE dbo.Users;
    END

    IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'TrainingProgram' AND schema_id = SCHEMA_ID('dbo'))
    BEGIN
        CREATE TABLE dbo.TrainingProgram (
          Id INT PRIMARY KEY NOT NULL,
          DateCreated DATETIME DEFAULT (GETDATE()) NOT NULL,
          Name NVARCHAR(255) NOT NULL,
          Description NVARCHAR(MAX)
        );
    END
    ELSE
    BEGIN
        TRUNCATE TABLE dbo.TrainingProgram;
    END
END
