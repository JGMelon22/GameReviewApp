-- Triggers to reset Id (some) values after delete it on swagger (if needed)
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