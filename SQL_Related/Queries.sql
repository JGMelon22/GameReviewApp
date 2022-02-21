-- Database creation
CREATE DATABASE [GamesAppApi];

-- Swicthes to the newly created database
USE [GamesAppApi];
GO

-- Tables creation
-- Game
BEGIN TRANSACTION
CREATE TABLE [Game]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [NVARCHAR](100) NOT NULL,
    [ReleaseDate] [DateTime] NOT NULL
)
    GO
ALTER TABLE [Game]
    ADD CONSTRAINT [Pk_Game]
        PRIMARY KEY([Id])
ROLLBACK
-- COMMIT

-- Category
BEGIN TRANSACTION
CREATE TABLE [Category]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [NVARCHAR](100) NOT NULL,
)
    GO
ALTER TABLE [Category]
    ADD CONSTRAINT [Pk_Category]
        PRIMARY KEY([Id])
ROLLBACK
-- COMMIT

-- Publisher
BEGIN TRANSACTION
CREATE TABLE [Publisher]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [NVARCHAR](100) NOT NULL,
)
    GO
ALTER TABLE [Publisher]
    ADD CONSTRAINT [Pk_Publisher]
        PRIMARY KEY([Id])
ROLLBACK
-- COMMIT

-- Review
BEGIN TRANSACTION
CREATE TABLE [Review]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [NVARCHAR](100) NOT NULL,
    [Text] [NVARCHAR](180) NOT NULL
)
    GO
ALTER TABLE [Review]
    ADD CONSTRAINT [Pk_Review]
        PRIMARY KEY([Id])
ROLLBACK
-- COMMIT

-- Country
BEGIN TRANSACTION
CREATE TABLE [Country]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [NVARCHAR](100) NOT NULL,
)
    GO
ALTER TABLE [Country]
    ADD CONSTRAINT [Pk_Country]
        PRIMARY KEY([Id])
ROLLBACK
-- COMMIT

-- Reviewer
BEGIN TRANSACTION
CREATE TABLE [Reviewer]
(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [FirstName] [NVARCHAR](100) NOT NULL,
    [LastName] [NVARCHAR](100) NOT NULL
)
    GO
ALTER TABLE [Reviewer]
    ADD CONSTRAINT [Pk_Reviewer]
        PRIMARY KEY([Id])
ROLLBACK
-- COMMIT

-- Triggers to reset Id value after delete it on swagger
-- Game
CREATE Trigger [dbo].[GameIdReset] 
ON [dbo].[Game]
INSTEAD OF DELETE
AS 
BEGIN
    DBCC CHECKIDENT ('[Game]', RESEED, 0);
END

-- Category
CREATE Trigger [dbo].[CategoryIdReset] 
ON [dbo].[Category]
INSTEAD OF DELETE
AS 
BEGIN
    DBCC CHECKIDENT ('[Category]', RESEED, 0);
END

-- Publisher
CREATE Trigger [dbo].[PublisherIdReset] 
ON [dbo].[Publisher]
INSTEAD OF DELETE
AS 
BEGIN
    DBCC CHECKIDENT ('[Publisher]', RESEED, 0);
END

-- Review
CREATE Trigger [dbo].[ReviewIdReset] 
ON [dbo].[Review]
INSTEAD OF DELETE
AS 
BEGIN
    DBCC CHECKIDENT ('[Review]', RESEED, 0);
END

-- Country
CREATE Trigger [dbo].[CountryIdReset] 
ON [dbo].[Country]
INSTEAD OF DELETE
AS 
BEGIN
    DBCC CHECKIDENT ('[Country]', RESEED, 0);
END

-- Review
CREATE Trigger [dbo].[ReviewerIdReset] 
ON [dbo].[Reviewer]
INSTEAD OF DELETE
AS 
BEGIN
    DBCC CHECKIDENT ('[Reviewer]', RESEED, 0);
END